using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO.Edicion
{
    public partial class frmInvestigacionPlaguicidasEdicion : frmEdicion
    {
        string Nconsecutivo = "";

        public frmInvestigacionPlaguicidasEdicion(List<string> valoresPk, string NColegiado = "")
            : base(valoresPk)
        {
            Nconsecutivo = NColegiado;
            armarFiltroPK(valoresPk);
            InitializeComponent();
            cargarDatos();
        }

        
        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Administración de Peritos";
                lblPerfil.Text = "Perfil de Perito";

                listar.COLUMNAS = "IdColegiado,Tipo,CodigoEmpresa,Cobrador,CursoAvaluosPeritaje,NumSesionAprobacion," +
                    "FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones";

                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_PERITOS";

                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("IdColegiado");
                listar.VALORES_PK = valoresPk;

                identificadorFormulario = "De Peritos";

                insertar = Constantes.PERITAJES_INSERTAR;
                editar = Constantes.PERITAJES_EDITAR;
                borrar = Constantes.PERITAJES_BORRAR;
                seleccionar = Constantes.PERITAJES_SELECCIONAR;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia del formulario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDatosDesdeColegiado(string NumeroColegiado)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_COLEGIADO";
            listA.FILTRO = "where NumeroColegiado = '" + NumeroColegiado + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    txtNColegiado.Valor = NumeroColegiado;
                    txtNumColegiado.Valor = dtTTs.Rows[0]["IdColegiado"].ToString();
                    buscaColegiado(txtNumColegiado.Valor);
                    txtNColegiado.ReadOnly = true;
                    txtCampoInvestigacion.ReadOnly = true;
                }
                else
                {
                    txtNColegiado.Clear();
                    txtNumColegiado.Clear();
                    txtCampoInvestigacion.Clear();
                    txtCampoInvestigacionNombre.Clear();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void cargarDatos()
        {
            tabControl.TabPages.Remove(tpAdjuntos);
            tabControl.TabPages.Add(tpAdjuntos);
            tabControl.TabPages.Remove(tpAdmin);
            tabControl.TabPages.Add(tpAdmin);
            

            if (valoresPk.Count > 0)
            {
                if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDatos.Rows)
                        {
                            txtNColegiado.Valor = Nconsecutivo;
                            txtNumColegiado.Valor = row["IdColegiado"].ToString();
                            buscaColegiado(row["IdColegiado"].ToString());
                   

                            //txtCobrador.Valor = row["Cobrador"].ToString();
                            //buscaCobrador(txtCobrador.Valor);
                            if (row["CursoAvaluosPeritaje"].ToString() == "S")
                                chkPagaCanon.Checked = true;
                            else
                                chkPagaCanon.Checked = false;

                            txtSesionAprob.Valor = row["NumSesionAprobacion"].ToString();
                            if (row["FechaSesionAprobacion"].ToString() != "")
                                dtpAprobacion.Value = DateTime.Parse(row["FechaSesionAprobacion"].ToString());

                            txtSesionRenov.Valor = row["NumSesionRenovacion"].ToString();
                            if (row["FechaSesionRenovacion"].ToString() != "")
                                dtpRenovacion.Value = DateTime.Parse(row["FechaSesionRenovacion"].ToString());

                            txtSesionPerdida.Valor = row["NumSesionPerdida"].ToString();
                            if (row["FechaSesionPerdida"].ToString() != "")
                                dtpPerdida.Value = DateTime.Parse(row["FechaSesionPerdida"].ToString());

                            rtbObservaciones.Text = row["Observaciones"].ToString();

                        }
                        deshabilitarLlave();
                    }
                }
            }
            else
            {
                cargarDatosDesdeColegiado(Nconsecutivo);
            }
        }

        private void frmPeritosEdicion_Load(object sender, EventArgs e)
        {

        }

        private void listaColegiados()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado, NumeroColegiado as Colegiado, Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.COLUMNAS_PK.Add("IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("IdColegiado");

            listP.ORDERBY = "order by IdColegiado";
            listP.TITULO_LISTADO = "Colegiados";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                txtNumColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
                txtNColegiado.Valor = f1Colegiado.item.SubItems[1].Text;
                txtNombreColegiado.Valor = f1Colegiado.item.SubItems[2].Text;
            }
            buscaColegiado(txtNumColegiado.Valor);
        }

        private void listaCobradores()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "Cobrador,Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "COBRADOR";
            listP.ORDERBY = "order by Cobrador";
            listP.TITULO_LISTADO = "Cobradores";
            frmF1 f1Cobrador = new frmF1(listP);
            f1Cobrador.ShowDialog();
            if (f1Cobrador.item != null)
            {
                txtCampoInvestigacion.Valor = f1Cobrador.item.SubItems[0].Text;
                txtCampoInvestigacionNombre.Valor = f1Cobrador.item.SubItems[1].Text;
            }
        }

        protected override bool validarDatos(ref string errores)
        {
            if (txtNumColegiado.Valor == "")
            {
                errores = "Debe seleccionar un Colegiado.";
                txtNumColegiado.Focus();
                return false;
            }

            if (txtCampoInvestigacion.Valor == "")
            {
                errores = "Debe seleccionar un Cobrador.";
                txtCampoInvestigacion.Focus();
                return false;
            }

            if (chkPagaCanon.Checked == false)
            {
                errores = "No se puede registrar perito sin tener los cursos de avalúos de peritaje.";
                chkPagaCanon.Focus();
                return false;
            }

            return true;
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtNumColegiado.Valor.Trim());
            parametros.Add(txtCampoInvestigacion.Valor.Trim());
            if (chkPagaCanon.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (txtSesionAprob.Valor.Trim() != "")
            {
                parametros.Add(txtSesionAprob.Valor.Trim());
                parametros.Add(dtpAprobacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
            }

            if (txtSesionRenov.Valor.Trim() != "")
            {
                parametros.Add(txtSesionRenov.Valor.Trim());
                parametros.Add(dtpRenovacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
            }

            if (txtSesionPerdida.Valor.Trim() != "")
            {
                parametros.Add(txtSesionPerdida.Valor.Trim());
                parametros.Add(dtpPerdida.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
            }

            parametros.Add(rtbObservaciones.Text);
            return true;
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtNumColegiado.Valor);
            txtNumColegiado.ReadOnly = true;
            txtNColegiado.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Perito: " + txtNombreColegiado.Valor;
        }

        private void txtNumColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaColegiados();
        }
        
        

        private void buscaColegiadoLeave(string codigo)
        {

            if (txtNColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado,Nombre,Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where NumeroColegiado = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNumColegiado.Valor = dtColegiado.Rows[0]["IdColegiado"].ToString();
                    txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
                    txtCampoInvestigacion.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    buscaCobrador(txtCampoInvestigacion.Valor);
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumColegiado.Clear();
                        txtNColegiado.Clear();
                        txtNombreColegiado.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buscaColegiado(string codigo)
        {

            if (txtNumColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado,Nombre,Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where IdColegiado = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
                    txtCampoInvestigacion.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    buscaCobrador(txtCampoInvestigacion.Valor);
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumColegiado.Clear();
                        txtNColegiado.Clear();
                        txtNombreColegiado.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void buscaCobrador(string codigo)
        {

            if (txtCampoInvestigacion.Valor.Trim() == "")
            {
                txtCampoInvestigacionNombre.Clear();
                return;
            }

            DataTable dtCobrador = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "Cobrador,Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "COBRADOR";
            listP.FILTRO = "where Cobrador = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtCobrador, ref error))
            {
                if (dtCobrador.Rows.Count > 0)
                {
                    txtCampoInvestigacionNombre.Valor = dtCobrador.Rows[0]["Nombre"].ToString();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El código de cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCampoInvestigacion.Clear();
                        txtCampoInvestigacionNombre.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool validarCampoInv(string articulo)
        {
            foreach (DataGridViewRow r in dgvCampoInvestigacion.Rows)
            {
                if (r.Cells["colCodigo"].Value.ToString().Equals(articulo))
                {
                    return false;
                }
            }
            return true;
        }

        private void listaCamposInvestigacion()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoCampo as Código,NombreCampo as Nombre, DescripcionCampo as Descripcion";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_CAMPOS_INVESTIGACION";
            listP.ORDERBY = "order by CodigoCampo";
            listP.TITULO_LISTADO = "Campos de Investigación";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                if (!validarCampoInv(f1.item.SubItems[0].Text))
                {
                    MessageBox.Show("Ya existe un detalle con la misma información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

             
                dgvCampoInvestigacion.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, f1.item.SubItems[2].Text);
             

            }
        }

        protected override void limpiarFormulario()
        {
            txtNumColegiado.Clear();
            txtNombreColegiado.Clear();
            chkPagaCanon.Checked = false;
            txtCampoInvestigacion.Clear();
            txtCampoInvestigacionNombre.Clear();
            txtSesionAprob.Clear();
            txtSesionPerdida.Clear();
            txtSesionRenov.Clear();
            dtpAprobacion.Value = DateTime.Now;
            dtpPerdida.Value = DateTime.Now;
            dtpRenovacion.Value = DateTime.Now;
            rtbObservaciones.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Colegiado";
        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {
            listaCamposInvestigacion();
        }
    }
}
