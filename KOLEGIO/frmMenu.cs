using Framework;
using KOLEGIO.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using KOLEGIO.Listados;
using KOLEGIO.Edicion;

namespace KOLEGIO
{
    public partial class frmMenu : Form
    {
        //public frmMenu()
        //{
        //    InitializeComponent();
        //    string error = "";
        //    if (!Globales.cargarGlobales(ref error))
        //        MessageBox.Show(error, "Parámetros Globales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}

        protected string error = "";
        private string usuario;
        private FuncsInternas fi;

        public frmMenu(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.fi = new FuncsInternas();
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = fvi.FileDescription + " v" + fvi.FileVersion + " - Usuario: " + fi.buscaNombreUsuario(usuario);
            if (!Globales.cargarGlobales(ref error))
                MessageBox.Show(error, "Parámetros Globales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            revisarEstablecimiento();
            actualizarClienteERP();
            revisarColegiadosCondicionRegreso();
            revisarColegiadosCambioCondicionPorEdad();
            ////revisarEstadoRegencias();
        }

        private void revisarEstablecimiento()
        {
            DataTable dtEstables = new DataTable();

            string sQuery = "select NumRegistro,Estado,FechaHastaCierreTemp from " + Consultas.sqlCon.COMPAÑIA+ ".NV_ESTABLECIMIENTOS where Estado in (select CodigoEstado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS where RequiereRegresoEstado = 'S' ) and CAST(FechaHastaCierreTemp as date) <= CAST(GETDATE() as date)";

            if (Consultas.fillDataTable(sQuery, ref dtEstables, ref error))
            {
                if (dtEstables.Rows.Count > 0)
                {
                    foreach (DataRow row in dtEstables.Rows)
                    {
                        fi.revisarRegresoEstadoEstablecimiento(row["FechaHastaCierreTemp"].ToString() != "" ? DateTime.Parse(row["FechaHastaCierreTemp"].ToString()) : DateTime.Now.AddDays(1) , row["Estado"].ToString(), row["NumRegistro"].ToString());
                    }
                }
            }
        }

        private void revisarEstadoRegencias()
        {
            DataTable dt = new DataTable();

            string sQuery = "select * from "+ Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SANCIONES where CheckFechaHasta != 'S' and (FechaHasta is not null and CAST(FechaHasta AS date) <= CAST(GETDATE() AS date))";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        fi.regresoRegenciasSancionados(row["Id"].ToString(), row["FechaHasta"].ToString() != "" ? DateTime.Parse(row["FechaHasta"].ToString()) : DateTime.Now.AddDays(1), 
                            row["NumeroColegiado"].ToString(), row["CodigoEstablecimiento"].ToString(), row["CodigoCategoria"].ToString(), row["SesionAprobacion"].ToString(), row["Fecha"].ToString());
                    }
                }
            }
        }

        private void revisarColegiadosCondicionRegreso()
        {
            DataTable dt = new DataTable();

            string sQuery = "select t1.IdColegiado,t1.Condicion,t1.FechaRegresoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
                            " where t2.RequiereRegresoCondicion = 'S' and CAST(t1.FechaRegresoCondicion as date) <= CAST(GETDATE() as date)";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        fi.revisarRegresoCondicion(row["IdColegiado"].ToString(), row["FechaRegresoCondicion"].ToString() != "" ? DateTime.Parse(row["FechaRegresoCondicion"].ToString()) : DateTime.Now.AddDays(1), row["Condicion"].ToString(), Constantes.ID_BIT_REGRESO_CONDICION, ref error);
                    }
                }
            }
        }

        private void revisarColegiadosCambioCondicionPorEdad()
        {
            DataTable dt = new DataTable();

            string sQuery = "select t1.IdColegiado,t1.Condicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
                        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
                        " where t2.RequiereCambioCondicionEdad = 'S' and ((CONVERT(int, CONVERT(char(8), GETDATE(), 112)) - CONVERT(char(8), t1.FechaNacimiento, 112)) / 10000) >= t2.EdadPorCambio";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        fi.realizarCambioCondicionEdad(row["IdColegiado"].ToString(), row["Condicion"].ToString(), Constantes.ID_BIT_CAMBIO_CONDICION_EDAD, ref error);
                    }
                }
            }
        }


        private void actualizarClienteERP()
        {
            error = "";
            DataTable dt = new DataTable();

            string sQuery = "select t1.CLIENTE, t2.NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE t1 " +
                " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t1.CLIENTE = t2.IdColegiado WHERE t1.ALIAS != t2.NumeroColegiado";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE SET ALIAS = t2.NumeroColegiado FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE t1" +
                           " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t1.CLIENTE = t2.IdColegiado WHERE t1.ALIAS != t2.NumeroColegiado";

                    if (!Consultas.ejecutarSentencia(sUpdate, ref error))
                        MessageBox.Show("Error Actualizando Alias en el ERP./n" + error + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnColegiados_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.COLEGIADOS))
            {
                if (Utilitario.BuscaForm("frmListColegiados"))
                {
                    frmListColegiados frm = new frmListColegiados(usuario);
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnTipoProductos_ItemClick(object sender, EventArgs e)
        {
            //if (Utilitario.BuscaForm("frmListDesgloseColegiatura"))
            //{
            //    frmListDesgloseColegiatura frm = new frmListDesgloseColegiatura();
            //    frm.Show();
            //}
        }

        private void btnTiposCombos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.ESTABLECIMIENTO))
            {
                if (Utilitario.BuscaForm("frmListEstablecimientos"))
                {
                    frmListEstablecimientos frm = new frmListEstablecimientos();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnUsuarios_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.USUARIOS))
            {
                if (Utilitario.BuscaForm("FrmUsuariosList"))
                {
                    FrmUsuariosList frmUsuariosList = new FrmUsuariosList();
                    //frmUsuariosList.MdiParent = this;
                    frmUsuariosList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void btnCambioClave_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CAMBIO_CLAVE))
            {
                if (Utilitario.BuscaForm("frmCambioClave"))
                {
                    frmCambioClave frmCC = new frmCambioClave(Consultas.Usuario, Consultas.Contraseña, 0);
                    frmCC.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        
        private void gCentrosAcademicos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CENTROS_ACADEMICOS))
            {
                if (Utilitario.BuscaForm("FrmCentrosAcademicosList"))
                {
                    FrmCentrosAcademicosList frmCentrosAcademicosList = new FrmCentrosAcademicosList();
                    //frmUsuariosList.MdiParent = this;
                    frmCentrosAcademicosList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gEmpresas_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.EMPRESAS))
            {
                if (Utilitario.BuscaForm("FrmEmpresasList"))
                {
                    FrmEmpresasList frmEmpresasList = new FrmEmpresasList();
                    //frmUsuariosList.MdiParent = this;
                    frmEmpresasList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gPaises_ItemClick(object sender, EventArgs e)
        {
            if (Utilitario.BuscaForm("FrmPaisesList"))
            {
                FrmPaisesList frmPaisesList = new FrmPaisesList();
                //frmUsuariosList.MdiParent = this;
                frmPaisesList.Show();
            }
        }

        private void gPuestosTrabajo_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PUESTOS_TRABAJO))
            {
                if (Utilitario.BuscaForm("FrmPuestosTrabajoList"))
                {
                    FrmPuestosTrabajoList frmPuestosTrabajoList = new FrmPuestosTrabajoList();
                    //frmUsuariosList.MdiParent = this;
                    frmPuestosTrabajoList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gEstados_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.ESTADOS_ESTABLECIMIENTO))
            {
                if (Utilitario.BuscaForm("FrmEstadosList"))
                {
                    FrmEstadosList frmEstadosList = new FrmEstadosList();
                    //frmUsuariosList.MdiParent = this;
                    frmEstadosList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gTipos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.TIPOS))
            {
                if (Utilitario.BuscaForm("FrmTiposList"))
                {
                    FrmTiposList frmTiposList = new FrmTiposList();
                    //frmUsuariosList.MdiParent = this;
                    frmTiposList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);


        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void gCarreras_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.TITULOS_ACADEMICOS))
            {
                if (Utilitario.BuscaForm("FrmCarrerasList"))
                {
                    FrmCarrerasList frmCarrerasList = new FrmCarrerasList();
                    //frmUsuariosList.MdiParent = this;
                    frmCarrerasList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gCategorias_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CATEGORIAS_REGENTES))
            {
                if (Utilitario.BuscaForm("FrmCategoriasList"))
                {
                    FrmCategoriasList frmCategoriasList = new FrmCategoriasList();
                    //frmUsuariosList.MdiParent = this;
                    frmCategoriasList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gGrados_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.GRADOS_ACADEMICOS))
            {
                if (Utilitario.BuscaForm("FrmGradosList"))
                {
                    FrmGradosList frmGradosList = new FrmGradosList();
                    //frmUsuariosList.MdiParent = this;
                    frmGradosList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void gCondiciones_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CONDICIONES))
            {
                if (Utilitario.BuscaForm("FrmCondicionesList"))
                {
                    FrmCondicionesList frmCondicionesList = new FrmCondicionesList();
                    //frmUsuariosList.MdiParent = this;
                    frmCondicionesList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void gCamposInvestigacion_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CAMPOS_INVESTIGACION))
            {
                if (Utilitario.BuscaForm("FrmCamposInvestigacionList"))
                {
                    FrmCamposInvestigacionList frmCamposInvestigacionList = new FrmCamposInvestigacionList();
                    //frmUsuariosList.MdiParent = this;
                    frmCamposInvestigacionList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void gCultivos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CULTIVOS_RECETAS))
            {
                if (Utilitario.BuscaForm("FrmCultivosRecetasList"))
                {
                    FrmCultivosRecetasList frmCutltivosRecetasList = new FrmCultivosRecetasList();
                    //frmUsuariosList.MdiParent = this;
                    frmCutltivosRecetasList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void gVidaSilvestre_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.VIDA_SILVESTRE))
            {
                if (Utilitario.BuscaForm("FrmVidaSilvestreList"))
                {
                    FrmVidaSilvestreList frmVidaSilvestreList = new FrmVidaSilvestreList();
                    //frmUsuariosList.MdiParent = this;
                    frmVidaSilvestreList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void gCamposAccion_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CAMPOS_ACCION))
            {
                if (Utilitario.BuscaForm("FrmCamposAccionList"))
                {
                    FrmCamposAccionList frmCamposAccionList = new FrmCamposAccionList();
                    //frmUsuariosList.MdiParent = this;
                    frmCamposAccionList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
  
        }

        private void gOrientaciones_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.ORIENTACIONES))
            {
                if (Utilitario.BuscaForm("FrmOrientacionesList"))
                {
                    FrmOrientacionesList frmOrientacionesList = new FrmOrientacionesList();
                    //frmUsuariosList.MdiParent = this;
                    frmOrientacionesList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void gEspecialidades_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.ESPECIALIDADES))
            {
                if (Utilitario.BuscaForm("FrmEspecialidadesList"))
                {
                    FrmEspecialidadesList frmEspecialidadesList = new FrmEspecialidadesList();
                    //frmUsuariosList.MdiParent = this;
                    frmEspecialidadesList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void gCamposEspecialidad_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CAMPOS_ESPECIALIDAD))
            {
                if (Utilitario.BuscaForm("FrmCamposEspecialidadList"))
                {
                    FrmCamposEspecialidadList frmCamposEspecialidadList = new FrmCamposEspecialidadList();
                    //frmUsuariosList.MdiParent = this;
                    frmCamposEspecialidadList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }
        
        private void gZonas_ItemClick(object sender, EventArgs e)
        {
            if (Utilitario.BuscaForm("FrmZonasCobroList"))
            {
                FrmZonasCobroList frmZonasCobroList = new FrmZonasCobroList();
                //frmUsuariosList.MdiParent = this;
                frmZonasCobroList.Show();
            }
        }

        private void gFrecuencias_ItemClick(object sender, EventArgs e)
        {
            if (Utilitario.BuscaForm("FrmFrecuenciasList"))
            {
                FrmFrecuenciasList frmFrecuenciasoList = new FrmFrecuenciasList();
                //frmUsuariosList.MdiParent = this;
                frmFrecuenciasoList.Show();
            }
        }

        private void gFormas_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.FORMAS_PAGO))
            {
                if (Utilitario.BuscaForm("FrmFormasPagoList"))
                {
                    FrmFormasPagoList frmFormasPagoList = new FrmFormasPagoList();
                    //frmUsuariosList.MdiParent = this;
                    frmFormasPagoList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnGlobales_ItemClick(object sender, EventArgs e)
        {

            if (Consultas.tienePrivilegios(usuario, Constantes.CONFIG))
            {
                if (Utilitario.BuscaForm("frmGlobales"))
                {
                    frmGlobales frmGlobales = new frmGlobales();
                    //frmUsuariosList.MdiParent = this;
                    frmGlobales.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void gMachotes_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PLANTILLAS))
            {
                if (Utilitario.BuscaForm("FrmMachotesList"))
                {
                    FrmMachotesList frmMachotesList = new FrmMachotesList();
                    frmMachotesList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }

        private void btnIngresoColegiados_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_COBRO))
            {
                if (Utilitario.BuscaForm("frmCobrosColegiadosNuevo"))
                {
                    frmCobrosColegiadosNuevo frm = new frmCobrosColegiadosNuevo();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void gPeritajes_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PERITAJES))
            {
                if (Utilitario.BuscaForm("frmPeritosList"))
                {
                    frmPeritosList frm = new frmPeritosList();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void gRegencias_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.REGENCIAS))
            {
                if (Utilitario.BuscaForm("frmRegentesList"))
                {
                    frmRegentesList frm = new frmRegentesList();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void gPlantillasCobradores_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PLANTILLA_COBRADORES))
            {
                if (Utilitario.BuscaForm("frmPlantillaCobradoresList"))
                {
                    frmPlantillaCobradoresList frm = new frmPlantillaCobradoresList();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnProcesoPlantillaCobradores_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_PLANTILLA_COBRADOR))
            {
                if (Utilitario.BuscaForm("frmGenerarPlantillasCobro"))
                {
                    frmGenerarPlantillasCobro frm = new frmGenerarPlantillasCobro();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            //if (Globales.MANEJO_PLAGUICIDAS.Equals("S") || Globales.MANEJO_VIA_AEREA.Equals("S") || Globales.PERMITIR_PERITO.Equals("S"))
            //    btnProcesoCobrosAnuales.Visible = true;
            //else
            //    btnProcesoCobrosAnuales.Visible = false;
            if (Globales.MANEJO_REGENCIAS.Equals("N"))
            {
                gCategorias.Visible = false;
                gRegencias.Visible = false;
                btnCobroRegencias.Visible = false;
                btnProcesoAdelantoPagosRegencia.Visible = false;
            }

            if (Globales.PERMITIR_PERITO.Equals("N"))
                gPeritajes.Visible = false;

            if (Globales.PERMITIR_PERITO.Equals("N") && Globales.MANEJO_REGENCIAS.Equals("N"))
                gTipos.Visible = false;

            if (Globales.MANEJO_VIA_AEREA.Equals("N"))
                gCultivos.Visible = false;

            if (Globales.MANEJO_PLAGUICIDAS.Equals("N"))
                gCamposInvestigacion.Visible = false;

            if (Globales.MANEJO_ESPECIALIDADES.Equals("N"))
            {
                gEspecialidades.Visible = false;
                gCamposEspecialidad.Visible = false;
            }

            if (!Consultas.tienePrivilegios(usuario, Constantes.PROCESO_CAMBIO_ULTIMO_COBRO))
            {
                btnCambioUltimoCobro.Visible = false;
            }

            //rptColegiados.Visible = false;
            //rptConsultoras.Visible = false;
            //rptEstablecimientos.Visible = false;

            rptColegiadoCondicion.Visible = false;
            rptConsultorasCerradas.Visible = false;
            btnTipoProductos.Visible = false;
            gRecaudadores.Visible = false;
            //btnCambioUltimoCobro.Visible = false;
            //btnActualizarSistema.Visible = false;
        }

        private void btnProcesoAdelantoPagos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_ADELANTO_PAGO))
            {
                if (Utilitario.BuscaForm("frmPagosAdelantados"))
                {
                    frmPagosAdelantados frm = new frmPagosAdelantados();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnProcesoAdelantoPagosRegencia_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_ADELANTO_PAGO_REGENCIA))
            {
                if (Utilitario.BuscaForm("frmPagosAdelantadosRegenciaNuevo"))
                {
                    frmPagosAdelantadosRegenciaNuevo frm = new frmPagosAdelantadosRegenciaNuevo();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnCobroRegencias_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_COBRO_REGENCIAS))
            {
                if (Utilitario.BuscaForm("frmCobrosRegenciasNuevo"))
                {
                    frmCobrosRegenciasNuevo frm = new frmCobrosRegenciasNuevo();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void gConsultoras_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.CONSULTORA))
            {
                if (Utilitario.BuscaForm("frmListConsultas"))
                {
                    frmListConsultoras frm = new frmListConsultoras();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnCambioCondicion_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_CAMBIO_CONDICION))
            {
                if (Utilitario.BuscaForm("frmCambioCondicion"))
                {
                    frmCambioCondicion frm = new frmCambioCondicion();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnProcesoFacturarCobrador_ItemClick(object sender, EventArgs e)
        {

            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_COBRO_MASIVO_COBRADOR))
            {
                if (Utilitario.BuscaForm("frmGenerarCobroMasivoCobrador"))
                {
                    frmGenerarCobroMasivoCobrador frm = new frmGenerarCobroMasivoCobrador();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnLevantamientoCondicion_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.PROCESO_LEVANTAMIENTO_CONDICION))
            {
                if (Utilitario.BuscaForm("frmLevantamiento"))
                {
                    frmLevantamiento frm = new frmLevantamiento();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptRegEstablecimiento_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroIndividualReg"))
                {
                    frmFiltroIndividualReg frmReporte = new frmFiltroIndividualReg("estable");
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            //if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            //{
                
            //    if (Utilitario.BuscaForm("frmVisorRpt"))
            //    {
            //        DataTable dtRptCarteraGeneral = new DataTable();
            //        Listado listP = new Listado();
            //        listP.COLUMNAS = "*";
            //        listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //        listP.TABLA = "NV_REGENTES_EN_ESTABLECIMIENTOS";
            //        //listP.FILTRO = "where NumRegistro = '100005'";
            //        Cursor.Current = Cursors.WaitCursor;
            //        if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
            //        {
            //            if (dtRptCarteraGeneral.Rows.Count > 0)
            //            {

            //                frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Reporte de Establecimientos por Regentes.rpt");
            //                Cursor.Current = Cursors.Default;
            //                rptCG.ShowDialog();
            //            }
            //            else
            //            {
            //                error = "No hay información para generar el reporte.";
            //                MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
                
            //}
            //else
            //    MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptRegEstableDeudores_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroIndividualReg"))
                {
                    frmFiltroIndividualReg frmReporte = new frmFiltroIndividualReg("estable", "NV_REGENTES_EN_ESTABLECIMIENTOS_DEUDORES_COLEGIADOS", "Reporte de Establecimientos por Regentes Deudores Colegiados.rpt");
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            //{

            //    if (Utilitario.BuscaForm("frmVisorRpt"))
            //    {
            //        DataTable dtRptCarteraGeneral = new DataTable();
            //        Listado listP = new Listado();
            //        listP.COLUMNAS = "*";
            //        listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //        listP.TABLA = "NV_REGENTES_EN_ESTABLECIMIENTOS_DEUDORES_COLEGIADOS";
            //        //listP.FILTRO = "where NumRegistro = '100005'";
            //        Cursor.Current = Cursors.WaitCursor;
            //        if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
            //        {
            //            if (dtRptCarteraGeneral.Rows.Count > 0)
            //            {

            //                frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Reporte de Establecimientos por Regentes Deudores Colegiados.rpt");
            //                Cursor.Current = Cursors.Default;
            //                rptCG.ShowDialog();
            //            }
            //            else
            //            {
            //                error = "No hay información para generar el reporte.";
            //                MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else
            //    MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptConsultorasCerradas_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {

                if (Utilitario.BuscaForm("frmVisorRpt"))
                {
                    DataTable dtRptCarteraGeneral = new DataTable();
                    Listado listP = new Listado();
                    listP.COLUMNAS = "*";
                    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    listP.TABLA = "NV_CONSULTORAS";
                    //listP.FILTRO = "where NumRegistro = '100005'";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Reporte Consultoras Cerradas.rpt");
                            Cursor.Current = Cursors.Default;
                            rptCG.ShowDialog();
                        }
                        else
                        {
                            error = "No hay información para generar el reporte.";
                            MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptEstadoEstablecimiento_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroIndividual"))
                {
                    frmFiltroIndividual frmReporte = new frmFiltroIndividual("estable", "NV_Estado_Establecimiento", "Estado de Establecimientos.rpt");
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            //{

            //    if (Utilitario.BuscaForm("frmVisorRpt"))
            //    {
            //        DataTable dtRptCarteraGeneral = new DataTable();
            //        Listado listP = new Listado();
            //        listP.COLUMNAS = "*";
            //        listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //        listP.TABLA = "NV_Estado_Establecimiento";
            //        //listP.FILTRO = "where NumRegistro = '100005'";
            //        Cursor.Current = Cursors.WaitCursor;
            //        if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
            //        {
            //            if (dtRptCarteraGeneral.Rows.Count > 0)
            //            {

            //                frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Estado de Establecimientos.rpt");
            //                Cursor.Current = Cursors.Default;
            //                rptCG.ShowDialog();
            //            }
            //            else
            //            {
            //                error = "No hay información para generar el reporte.";
            //                MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else
            //    MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptColegiadoCondicion_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {

                if (Utilitario.BuscaForm("frmVisorRpt"))
                {
                    DataTable dtRptCarteraGeneral = new DataTable();
                    Listado listP = new Listado();
                    listP.COLUMNAS = "*";
                    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    listP.TABLA = "NV_CONDICION_COLEGIADO";
                    //listP.FILTRO = "where NumRegistro = '100005'";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Condicion Colegiado.rpt");
                            Cursor.Current = Cursors.Default;
                            rptCG.ShowDialog();
                        }
                        else
                        {
                            error = "No hay información para generar el reporte.";
                            MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptCatEstablecimientos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroIndividual"))
                {
                    frmFiltroIndividual frmReporte = new frmFiltroIndividual("estable", "NV_CATEGORIA_POR_ESTABLECIMIENTOS", "Categoria de Establecimientos Actualizado.rpt");
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            //{

            //    if (Utilitario.BuscaForm("frmVisorRpt"))
            //    {
            //        DataTable dtRptCarteraGeneral = new DataTable();
            //        Listado listP = new Listado();
            //        listP.COLUMNAS = "*";
            //        listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //        listP.TABLA = "NV_CATEGORIA_POR_ESTABLECIMIENTOS";
            //        //listP.FILTRO = "where NumRegistro = '100005'";
            //        Cursor.Current = Cursors.WaitCursor;
            //        if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
            //        {
            //            if (dtRptCarteraGeneral.Rows.Count > 0)
            //            {

            //                frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Categoria de Establecimientos Actualizado.rpt");
            //                Cursor.Current = Cursors.Default;
            //                rptCG.ShowDialog();
            //            }
            //            else
            //            {
            //                error = "No hay información para generar el reporte.";
            //                MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else
            //    MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnProcesoCobrosAnuales_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PROCESO_COBRO_CANONES_ANUALES))
            {
                if (Globales.MANEJO_PLAGUICIDAS.Equals("S") || Globales.MANEJO_VIA_AEREA.Equals("S") || Globales.PERMITIR_PERITO.Equals("S"))
                {
                    if (Utilitario.BuscaForm("frmCobrosCanonesAnuales"))
                    {
                        frmCobrosCanonesAnuales frm = new frmCobrosCanonesAnuales();
                        frm.Show();
                    }
                }
                else
                    MessageBox.Show("Actualmente no se maneja ningún canon anual.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGeneCelularesCobro_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PROCESO_GENERAR_ARCHIVO_CELULARES))
            {
                if (Globales.MANEJO_GENE_ARCHIVO_CELULARES.Equals("S"))
                {
                    if (Utilitario.BuscaForm("frmGenerarCelNotificacionPorMes"))
                    {
                        frmGenerarCelNotificacionPorMes frm = new frmGenerarCelNotificacionPorMes();
                        frm.Show();
                    }
                }
                else
                    MessageBox.Show("Proceso deshabilitado en las globales del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptColegiados_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroColegiado"))
                {
                    //Listado listP = new Listado();
                    //listP.COLUMNAS = "*";
                    //listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    //listP.TABLA = "NV_COLEGIADO";
                    //listP.ORDERBY = "order by AseguradoPoliza";
                    frmFiltroColegiado frmReporte = new frmFiltroColegiado();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            /*
             if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {

                if (Utilitario.BuscaForm("frmVisorRpt"))
                {
                    DataTable dtRptCarteraGeneral = new DataTable();
                    Listado listP = new Listado();
                    listP.COLUMNAS = "*";
                    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    listP.TABLA = "NV_CONDICION_COLEGIADO";
                    //listP.FILTRO = "where NumRegistro = '100005'";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Condicion Colegiado.rpt", new List<string>(), new List<string>());
                            Cursor.Current = Cursors.Default;
                            rptCG.ShowDialog();
                        }
                        else
                        {
                            error = "No hay información para generar el reporte.";
                            MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
             */
        }

        private void rptEstablecimientos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroEstables_Consul"))
                {
                    //Listado listP = new Listado();
                    //listP.COLUMNAS = "*";
                    //listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    //listP.TABLA = "NV_FICHA_ESTABLECIMIENTOS";
                    //listP.ORDERBY = "order by AseguradoPoliza";
                    frmFiltroEstables_Consul frmReporte = new frmFiltroEstables_Consul("estable");
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void rptConsultoras_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroEstables_Consul"))
                {
                    //Listado listP = new Listado();
                    //listP.COLUMNAS = "*";
                    //listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    //listP.TABLA = "NV_FICHA_CONSULTORAS";
                    frmFiltroEstables_Consul frmReporte = new frmFiltroEstables_Consul("consul");
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnActualizarSistema_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(usuario, Constantes.ACTUALIZA_KEY))
            {
                if (MessageBox.Show("¿Está seguro que desea actualizar el sistema?", "Validación", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;

                    if (File.Exists(path + "descargarFTP.exe"))
                    {
                        Process proc = new Process();
                        proc.StartInfo.FileName = path + "descargarFTP.exe";
                        //if (ConfigurationManager.AppSettings["DBHosting"] == "WN")
                        //{
                        //    proc.StartInfo.Arguments = Utilitario.DesEncriptar(ConfigurationManager.AppSettings["UsuarioWN"]) + " "
                        //        + Utilitario.DesEncriptar(ConfigurationManager.AppSettings["Password"]) + " "
                        //        + ConfigurationManager.AppSettings["Servidor"] + " " + ConfigurationManager.AppSettings["BaseDatos"];
                        //}
                        //else
                        proc.StartInfo.Arguments = Consultas.Usuario + " " + Consultas.sqlCon.PASSWORD + " " +
                            ConfigurationManager.AppSettings["Servidor"] + " " + ConfigurationManager.AppSettings["BaseDatos"];
                        proc.Start();
                        Application.Exit();
                    }
                    else
                        MessageBox.Show("No fue posible localizar el utilitario para la actualización del sistema.", "KOLEGIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        
        private void btnControlVersiones_ItemClick(object sender, EventArgs e)
        {
            if (Utilitario.BuscaForm("FrmControlVersionesList"))
            {
                FrmControlVersionesList frm = new FrmControlVersionesList();
                frm.Show();
            }
        }

        private void rptPlaguicidasAereas_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroPlaguicidas_Aerea"))
                {
                    //Listado listP = new Listado();
                    //listP.COLUMNAS = "*";
                    //listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    //listP.TABLA = "NV_FICHA_CONSULTORAS";
                    frmFiltroPlaguicidas_Aerea frmReporte = new frmFiltroPlaguicidas_Aerea();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void rptPeritos_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroPeritos"))
                {
                    frmFiltroPeritos frmReporte = new frmFiltroPeritos();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptRegentes_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroRegentes"))
                {
                    frmFiltroRegentes frmReporte = new frmFiltroRegentes();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rptInformesRegencias_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroInformeReg"))
                {
                    frmFiltroInformeReg frmReporte = new frmFiltroInformeReg();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnCambioUltimoCobro_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PROCESO_CAMBIO_ULTIMO_COBRO))
            {
                if (Utilitario.BuscaForm("frmCambioUltimoCobro"))
                {
                    frmCambioUltimoCobro frm = new frmCambioUltimoCobro();
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void rtpHaciendaColegiados_ItemClick(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTE_COLEGIADOS_HACIENDA))
            {
                try
                {
                    DataTable dtColumnas = new DataTable();
                    dtColumnas.Columns.Add("Macro");
                    dtColumnas.Columns.Add("TamColumna");
                    dtColumnas.Columns.Add("Detalle");

                    DataRow colData = dtColumnas.NewRow();
                    colData["Macro"] = "APELLIDO1";
                    colData["TamColumna"] = "18";
                    colData["Detalle"] = "Primer Apellido";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "APELLIDO2";
                    colData["TamColumna"] = "18";
                    colData["Detalle"] = "Segundo Apellido";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "NOMBRE";
                    colData["TamColumna"] = "20";
                    colData["Detalle"] = "Nombre";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "CEDULA";
                    colData["TamColumna"] = "12";
                    colData["Detalle"] = "Cedula";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "ESTADO";
                    colData["TamColumna"] = "7";
                    colData["Detalle"] = "Estado";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "FECHA_INGRESO";
                    colData["TamColumna"] = "15";
                    colData["Detalle"] = "Incorporación";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "CARNET";
                    colData["TamColumna"] = "20";
                    colData["Detalle"] = "Número de carnet";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "ESP";
                    colData["TamColumna"] = "50";
                    colData["Detalle"] = "Especialidad";
                    dtColumnas.Rows.Add(colData);

                    colData = dtColumnas.NewRow();
                    colData["Macro"] = "SUB_ESP";
                    colData["TamColumna"] = "50";
                    colData["Detalle"] = "SubEspecialidad";
                    dtColumnas.Rows.Add(colData);

                    StringBuilder texto = new StringBuilder();
                    SaveFileDialog savefile = new SaveFileDialog();
                    // set a default file name
                    savefile.FileName = "ReporteHacienda";
                    // set filters - this can be done in properties as well
                                    
                        savefile.Filter = "Text files (*.txt)|*.txt";
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        #region CREAR_SELECT
                        Cursor.Current = Cursors.WaitCursor;

                        string sQuery = "select t1.Nombre, SUBSTRING(t1.Cedula,1,12) as Cedula," +
                            " CASE WHEN t1.Condicion in ('C-07', 'C-08', 'C-10', 'C-11') THEN 'I' else 'A' END AS Estado," +
                            " FORMAT(t1.FechaIngreso, 'dd/MM/yyyy') as 'FechaIngreso', t1.NumeroColegiado," +
                            "  (select top 1 t3.NombreEspecialidad from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ESPECIALIDAD t2" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESPECIALIDADES t3 on t3.CodigoEspecialidad = t2.CodigoEspecialidad" +
                             " where IdColegiado = t2.NumeroColegiado) as 'Especialidad'," +
                            " (" +
                            " select NombreEspecialidad" +
                            " from(SELECT TOP 2" +
                            "     t3.NombreEspecialidad, ROW_NUMBER() OVER(ORDER BY t3.NombreEspecialidad) AS RowNumber" +
                            "   from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ESPECIALIDAD t2" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESPECIALIDADES t3 on t3.CodigoEspecialidad = t2.CodigoEspecialidad" +
                            " where IdColegiado = t2.NumeroColegiado) t" +
                            " WHERE RowNumber = 2" +
                            " ) as 'SubEspecialidad'" +
                            " from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 where t1.Condicion not in ('C-14','C-13','C-09') ";
                        
                            #endregion

                        DataTable dtDatos = new DataTable();

                        if (Consultas.fillDataTable(sQuery, ref dtDatos, ref error))
                        {
                            if (dtDatos.Rows.Count > 0)
                            {
                               
                                if (!File.Exists(savefile.FileName))
                                    File.Delete(savefile.FileName);

                                //int rowIndex = 0;
                                int rowIndex = 1;
                                string encabezado = "";

                                foreach (DataRow row in dtColumnas.Rows)
                                {
                                    if (row["Macro"].ToString() == "CARNET")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;
                                           
                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "CEDULA")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "APELLIDO1")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "APELLIDO2")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "NOMBRE")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "ESTADO")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "FECHA_INGRESO")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "ESP")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }

                                    if (row["Macro"].ToString() == "SUB_ESP")
                                    {
                                        encabezado += row["Detalle"].ToString();

                                        if (!row["TamColumna"].ToString().Equals(""))
                                        {
                                            int espaciosCol = int.Parse(row["TamColumna"].ToString()) - row["Detalle"].ToString().Length;

                                            if (espaciosCol > 0)
                                            {
                                                for (int j = 0; j < espaciosCol; j++)
                                                    encabezado += " ";
                                            }
                                        }
                                    }
                                }

                                File.AppendAllText(savefile.FileName, encabezado + Environment.NewLine);

                                foreach (DataRow rowDatos in dtDatos.Rows)
                                {
                                    rowIndex += 1;

                                    if (rowIndex == 559)
                                    {
                                        string co = "";
                                    }

                                    #region TXT
                                    string fila = "", noAplica = "N/A";
                                    int i = 0;
                                    foreach (DataRow row in dtColumnas.Rows)
                                    {
                                       
                                        //string formato = dtFormatos.Rows[i]["Formato"].ToString();

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "CARNET")
                                        {
                                            if (!rowDatos["NumeroColegiado"].ToString().Equals(""))
                                                fila += rowDatos["NumeroColegiado"].ToString().Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["NumeroColegiado"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - rowDatos["NumeroColegiado"].ToString().Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }
                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "CEDULA")
                                        {
                                            if (!rowDatos["Cedula"].ToString().Equals(""))
											{
                                                if(rowDatos["Cedula"].ToString().Trim().Length < 9)
												{
                                                    for (int j = 0; j < rowDatos["Cedula"].ToString().Trim().Length; j++)
                                                        fila += " ";
                                                }
                                                else
                                                    fila += rowDatos["Cedula"].ToString().Trim();
                                            }
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["Cedula"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - rowDatos["Cedula"].ToString().Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }
                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "APELLIDO1")
                                        {
                                            string[] nombre = rowDatos["Nombre"].ToString().Split(' ');
                                            
                                            if (!rowDatos["Nombre"].ToString().Equals(""))
                                                fila += nombre[0].Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["Nombre"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - nombre[0].Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "APELLIDO2")
                                        {
                                            string[] nombre = rowDatos["Nombre"].ToString().Split(' ');

                                            if (!rowDatos["Nombre"].ToString().Equals("") && nombre.Length > 1)
                                                fila += nombre[1].Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["Nombre"].ToString().Equals("") && nombre.Length > 1)
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - nombre[1].Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "NOMBRE")
                                        {
                                            string[] nombre = rowDatos["Nombre"].ToString().Split(' ');
                                            string soloNombre = "";

                                            if (nombre.Length != 1)
                                            {
                                                if (nombre.Length > 3)
                                                    soloNombre = nombre[nombre.Length - 2] + ' ' + nombre[nombre.Length - 1];
                                                else
                                                    soloNombre = nombre[nombre.Length - 1];
                                            }

                                            if (!rowDatos["Nombre"].ToString().Equals(""))
                                                fila += soloNombre.Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["Nombre"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - soloNombre.Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "ESTADO")
                                        {
                                            if (!rowDatos["Estado"].ToString().Equals(""))
                                                fila += rowDatos["Estado"].ToString().Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["Estado"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - rowDatos["Estado"].ToString().Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }
 
                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "FECHA_INGRESO")
                                        {
                                            if (!rowDatos["FechaIngreso"].ToString().Equals(""))
                                                fila += rowDatos["FechaIngreso"].ToString().Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["FechaIngreso"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - rowDatos["FechaIngreso"].ToString().Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "ESP")
                                        {
                                            if (!rowDatos["Especialidad"].ToString().Equals(""))
                                                fila += rowDatos["Especialidad"].ToString().Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["Especialidad"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - rowDatos["Especialidad"].ToString().Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }

                                        if (dtColumnas.Rows[i]["Macro"].ToString() == "SUB_ESP")
                                        {
                                            if (!rowDatos["SubEspecialidad"].ToString().Equals(""))
                                                fila += rowDatos["SubEspecialidad"].ToString().Trim();
                                            else
                                                fila += noAplica;

                                            if (!dtColumnas.Rows[i]["TamColumna"].ToString().Equals(""))
                                            {
                                                int espaciosCol = 0;
                                                if (!rowDatos["SubEspecialidad"].ToString().Equals(""))
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - rowDatos["SubEspecialidad"].ToString().Trim().Length;
                                                else
                                                    espaciosCol = int.Parse(dtColumnas.Rows[i]["TamColumna"].ToString()) - noAplica.Length;

                                                if (espaciosCol > 0)
                                                {
                                                    for (int j = 0; j < espaciosCol; j++)
                                                        fila += " ";
                                                }

                                            }
                                        }

                                        i += 1;

                                    }

                                    File.AppendAllText(savefile.FileName, fila + Environment.NewLine);
                                    #endregion
                                                   
                                }
                                                
                                              
                            }
                            else
                            {
                                //Consultas.sqlCon.Rollback();
                                MessageBox.Show("No información para generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            //Consultas.sqlCon.Rollback();
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Se genero el reporte correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //Consultas.sqlCon.Rollback();
                    }

                               
                }
                catch (Exception ex)
                {
                    //Consultas.sqlCon.Rollback();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

		private void gActividades_ItemClick(object sender, EventArgs e)
		{
            if (Consultas.tienePrivilegios(usuario, Constantes.ACTIVIDAD))
            {
                if (Utilitario.BuscaForm("FrmActividadesList"))
                {
                    FrmActividadesList frmActividadesList = new FrmActividadesList();
                    //frmUsuariosList.MdiParent = this;
                    frmActividadesList.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

		private void gRegActividades_ItemClick(object sender, EventArgs e)
		{
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REG_ACTIVIDADES_VER))
            {
                if (Utilitario.BuscaForm("frmRegistroActividadesEdicion"))
                {
                    frmRegistroActividadesEdicion frm = new frmRegistroActividadesEdicion();
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

		private void rptActividades_ItemClick(object sender, EventArgs e)
		{
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                if (Utilitario.BuscaForm("frmFiltroActividades"))
                {
                    frmFiltroActividades frmReporte = new frmFiltroActividades();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

		private void gCursos_ItemClick(object sender, EventArgs e)
		{
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CURSOS))
            {
                if (Utilitario.BuscaForm("FrmCursosList"))
                {
                    FrmCursosList frm = new FrmCursosList();
                    frm.Show();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

		private void gRegCursos_ItemClick(object sender, EventArgs e)
		{
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REG_CURSOS))
            {
                if (Utilitario.BuscaForm("FrmCursosColegiadosList"))
                {
                    FrmCursosColegiadosList frm = new FrmCursosColegiadosList();
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

		private void rptBitacora_ItemClick(object sender, EventArgs e)
		{
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTE_BITACORA))
            {
                if (Utilitario.BuscaForm("frmFiltroBitacora"))
                {
                    frmFiltroBitacora frmReporte = new frmFiltroBitacora();
                    frmReporte.ShowDialog();
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
	}
}
