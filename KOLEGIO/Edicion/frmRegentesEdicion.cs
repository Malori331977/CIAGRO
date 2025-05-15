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

namespace KOLEGIO
{
    public partial class frmRegentesEdicion : frmEdicion
    {
        private FuncsInternas fInternas;
        string Nconsecutivo = "";
        private bool onChanged = true;
        private DateTimePicker dtp = new DateTimePicker();
        List<int> listaIndiceComboSancion = new List<int>();
        //DataTable dtColegiadosPendienteCambioSancionado = new DataTable();

        public frmRegentesEdicion(List<string> valoresPk,string NColegiado = "")
            : base(valoresPk)
        {
            this.fInternas = new FuncsInternas();
            Nconsecutivo = NColegiado;
            InitializeComponent();
            listaTipos();
            if (cmbTipo.Count > 0)
                cmbTipo.Index = 0;
            cargarDatos();
            cmbTipo.SelectedValueChanged(new EventHandler(OnTipoChanged));

            listaIndiceComboSancion.AddRange(new int[] { 0, 1 });

            if (fInternas.registroDeshabilitado(txtNumColegiado.Valor, ref error))
            {
                btnGuardar.Visible = false;
                btnGuardarSalir.Visible = false;
                toolStripSeparator4.Visible = false;
            }
            if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ELIMINAR_REG_ESTABLES))
            {
                btnEliminaEst.Visible = false;
                btnEliminaHorario.Visible = false;
                btnEliminaInforme.Visible = false;
                btnEliminarLibro.Visible = false;
                btnEliminaVisita.Visible = false;
            }
            //dtColegiadosPendienteCambioSancionado.Columns.Add("estable", typeof(String));
            //dtColegiadosPendienteCambioSancionado.Columns.Add("categ", typeof(String));
            //dtColegiadosPendienteCambioSancionado.Columns.Add("sesion", typeof(String));
            //dtColegiadosPendienteCambioSancionado.Columns.Add("fecha", typeof(String));
        }

        protected override void initInstance()
        {
            try
            {
                //listar.TITULO_LISTADO = "Administración de Regentes";
                //lblPerfil.Text = "Perfil de Regente";

                //listar.COLUMNAS = "T1.NumeroColegiado,(select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = T1.NumeroColegiado) as NumColegiado,T1.Cobrador,T1.AvaluoCursos,T1.SesionAprobacion," +
                //    "T1.FechaSesionAprobacion,T1.SesionPerdida,T1.FechaSesionPerdida";

                //listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                //listar.TABLA = "NV_REGENTES as T1";

                listar.TITULO_LISTADO = "Administración de Regentes";
                lblPerfil.Text = "Perfil de Regente";

                listar.COLUMNAS = "NumeroColegiado,Cobrador,AvaluoCursos,Tipo,SesionAprobacion," +
                    "FechaSesionAprobacion,SesionPerdida,FechaSesionPerdida,NumeroPoliza,FechaPoliza,MontoPoliza,FechaVencimientoPoliza,Observaciones";

                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_REGENTES ";

                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("NumeroColegiado");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);
                identificadorFormulario = "De Regentes";

                insertar = Constantes.REGENCIAS_INSERTAR;
                editar = Constantes.REGENCIAS_EDITAR;
                borrar = Constantes.REGENCIAS_BORRAR;
                seleccionar = Constantes.REGENCIAS_SELECCIONAR;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia del formulario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool llenarParametros()
        {
            dgvEstablecimientos.EndEdit();
            dgvHorarios.EndEdit();
            dgvInformes.EndEdit();
            dgvVisitasFisc.EndEdit();
            dgvProtocolos.EndEdit();
            dgvSanciones.EndEdit();


            parametros.Clear();
            parametros.Add(txtNumColegiado.Valor);
            parametros.Add(txtCobrador.Valor);

            if (chkCurso.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            //parametros.Add(cmbTipo.Texto[0] + "");
            if(!cmbTipo.Valor.Equals(""))
                parametros.Add(cmbTipo.Valor);
            else
                parametros.Add("null");

            if (txtSesionAprob.Valor != "")
            {
                parametros.Add(txtSesionAprob.Valor);
                parametros.Add(dtpAprobacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
            }

            if (txtSesionPerdida.Valor != "")
                parametros.Add(txtSesionPerdida.Valor);
            else
                parametros.Add("null");

            if (dtpPerdida.Checked)
                parametros.Add(dtpPerdida.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (!txtNPoliza.Valor.Equals("")) { 
                parametros.Add(txtNPoliza.Valor);
                parametros.Add(dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                if (!txtMonto.Valor.Equals(""))
                    parametros.Add(txtMonto.Valor);
                else
                    parametros.Add("null");
                parametros.Add(dtpVencimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
                parametros.Add("null");
                parametros.Add("null");
            }

            parametros.Add(rtbObservaciones.Text);

            return true;
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
                    txtCobrador.ReadOnly = true;
                }
                else
                {
                    txtNColegiado.Clear();
                    txtNumColegiado.Clear();
                    txtCobrador.Clear();
                    txtCobradorNombre.Clear();
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

            //cmbTipo.agregarItems("Forestal");
            //cmbTipo.agregarItems("Agropecuario");
            //cmbTipo.Index = 0;

            if (valoresPk.Count > 0)
            {
                if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDatos.Rows)
                        {
                            txtNColegiado.Valor = Nconsecutivo;
                            txtNumColegiado.Valor = row["NumeroColegiado"].ToString();
                            buscaColegiado(row["NumeroColegiado"].ToString());

                            txtCobrador.Valor = row["Cobrador"].ToString();
                            buscaCobrador(txtCobrador.Valor);
                            if (row["AvaluoCursos"].ToString() == "S")
                                chkCurso.Checked = true;
                            else
                                chkCurso.Checked = false;

                            //if (row["Tipo"].ToString() == "F")
                            //{
                            //    cmbTipo.Index = 0;
                            //    txtNPoliza.Valor = row["NumeroPoliza"].ToString();
                            //    txtMonto.Valor = row["MontoPoliza"].ToString();
                            //    dtpFecha.Value = DateTime.Parse(row["FechaPoliza"].ToString());
                            //    dtpVencimiento.Value = DateTime.Parse(row["FechaVencimientoPoliza"].ToString());
                            //}
                            //else
                            //    cmbTipo.Index = 1;

                            cmbTipo.Valor = row["Tipo"].ToString();
                            verificarSiRequierePoliza();
                            txtSesionAprob.Valor = row["SesionAprobacion"].ToString();
                            if (row["FechaSesionAprobacion"].ToString() != "")
                                dtpAprobacion.Value = DateTime.Parse(row["FechaSesionAprobacion"].ToString());


                            txtSesionPerdida.Valor = row["SesionPerdida"].ToString();
                            if (row["FechaSesionPerdida"].ToString() != "")
                            {
                                dtpPerdida.Checked = true;
                                dtpPerdida.Value = DateTime.Parse(row["FechaSesionPerdida"].ToString());
                            }

                            txtNPoliza.Valor = row["NumeroPoliza"].ToString();
                            if (row["MontoPoliza"].ToString() != "")
                                txtMonto.Valor = decimal.Parse(row["MontoPoliza"].ToString()).ToString("N2");
                            if (row["FechaPoliza"].ToString() != "")
                                dtpFecha.Value = DateTime.Parse(row["FechaPoliza"].ToString());
                            if (row["FechaVencimientoPoliza"].ToString() != "")
                                dtpVencimiento.Value = DateTime.Parse(row["FechaVencimientoPoliza"].ToString());

                            rtbObservaciones.Text = row["Observaciones"].ToString();
                        }
                        
                        cargarEstablecimientos(ref error);
                        cargarProtocolos();
                        cargarSanciones();
                        cargarHistorialRegencias();
                        cargarVidaSilvestre(ref error);
                        deshabilitarLlave();
                    }
                }
            }
            else
            {
                cargarDatosDesdeColegiado(Nconsecutivo);
            }
        }

        private void habilitarPoliza()
        {
            lblNPoliza.Visible = true;
            lblMonto.Visible = true;
            LblFecha.Visible = true;
            lblVencimiento.Visible = true;
            txtNPoliza.Visible = true;
            txtMonto.Visible = true;
            dtpFecha.Visible = true;
            dtpVencimiento.Visible = true;
        }

        private void deshabilitarPoliza()
        {
            lblNPoliza.Visible = false;
            lblMonto.Visible = false;
            LblFecha.Visible = false;
            lblVencimiento.Visible = false;
            txtNPoliza.Visible = false;
            txtMonto.Visible = false;
            dtpFecha.Visible = false;
            dtpVencimiento.Visible = false;
        }

        private void habilitarSilvestre()
        {
            gbVidaSilvestre.Visible = true;
        }

        private void deshabilitarSilvestre()
        {
            gbVidaSilvestre.Visible = false;
        }

        private void deshabilitarEstadoRegente()
        {
            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                bool requiereDeshabilitarEstado = false;

                verificarEstadoEstablecimiento(row.Cells["colCodigoEstablecimiento"].Value.ToString(),ref requiereDeshabilitarEstado);

                if (requiereDeshabilitarEstado)
                {
                    row.Cells["colEstado"].ReadOnly = true;
                }
            }
        }

        private void cargarVidaSilvestre(ref string error)
        {
            string sQuery = "select t1.CodigoSilvestre, t2.NombreSilvestre, t2.DescripcionSilvestre from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SILVESTRE t1 " +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_VIDA_SILVESTRE t2 on t2.CodigoSilvestre = t1.CodigoSilvestre where t1.IdColegiado = '" + txtNumColegiado.Valor + "'";

            DataTable dt = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                dgvVidaSilvestre.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvVidaSilvestre.Rows.Add(row["CodigoSilvestre"].ToString(), row["NombreSilvestre"].ToString(), row["DescripcionSilvestre"].ToString());
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarEstablecimientos(ref string error)
        {
            string sQuery = "SELECT T1.CodigoEstablecimiento,T2.Nombre,T1.SesionAprobacion,T1.FechaAprobacion,"+
                "T3.CodigoCategoria,T3.NombreCategoria,T1.Estado, T1.Cobrador, t4.NOMBRE as NomCobrador FROM " + Consultas.sqlCon.COMPAÑIA+".NV_REGENTES_ESTABLECIMIENTOS T1 JOIN "+Consultas.sqlCon.COMPAÑIA+
                ".NV_ESTABLECIMIENTOS T2 ON T1.CodigoEstablecimiento=T2.NumRegistro JOIN " + Consultas.sqlCon.COMPAÑIA +
                ".NV_CATEGORIAS T3 ON T1.CodigoCategoria=T3.CodigoCategoria LEFT JOIN " + Consultas.sqlCon.COMPAÑIA +".COBRADOR T4 ON T1.Cobrador=T4.COBRADOR where T1.NumeroColegiado = '" + txtNumColegiado.Valor+"' order by T1.CodigoEstablecimiento";
            DataTable dtEstablecimientos = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtEstablecimientos, ref error))
            {
                
                foreach (DataRow row in dtEstablecimientos.Rows)
                {
                    
                    dgvEstablecimientos.Rows.Add(row["CodigoEstablecimiento"].ToString(),
                    row["Nombre"].ToString(), row["SesionAprobacion"].ToString(), DateTime.Parse(row["FechaAprobacion"].ToString()), row["CodigoCategoria"].ToString(), row["NombreCategoria"].ToString(),
                    row["Cobrador"].ToString(), row["NomCobrador"].ToString(), fInternas.obtenerEstado(row["Estado"].ToString()));
                    //row["Cobrador"].ToString(), row["NomCobrador"].ToString(), row["Estado"].ToString() == "A" ? "Activo" : "Inactivo");
                }



                if (dgvEstablecimientos.RowCount > 0)
                {
                    colorearFilas();
                    dgvEstablecimientos.CurrentCell = dgvEstablecimientos[0, 0];
                    cargarInfoEstablecimiento(dgvEstablecimientos[0, 0].Value.ToString());
                    //deshabilitarEstadoRegente();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarProtocolos()
        {
       
            string sQuery = "SELECT Codigo,Libro,Folio,Asiento,LibCol,FechaApertura,FechaCierre,Observaciones FROM " 
                + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_LIB_PROTOCOLOS WHERE NumeroColegiado='"+txtNumColegiado.Valor+"'"+
                "order by Codigo";
            DataTable dtProtocolos = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtProtocolos, ref error))
            {
                dgvProtocolos.Rows.Clear();
                foreach (DataRow row in dtProtocolos.Rows)
                {
                    dgvProtocolos.Rows.Add(row["Codigo"].ToString(),
                        row["Libro"].ToString(), row["Folio"].ToString(), row["Asiento"].ToString(),
                        row["LibCol"].ToString(), row["FechaApertura"].ToString() != "" ? DateTime.Parse(row["FechaApertura"].ToString()).ToString("dd/MM/yyyy") : "" ,
                        row["FechaCierre"].ToString() != "" ? DateTime.Parse(row["FechaCierre"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString());
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarSanciones()
        {
            //string sQuery = "SELECT Id,Fecha,Observaciones FROM "
            //   + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SANCIONES WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'" +
            //   "order by Id";
            string sQuery = "SELECT Id,CodigoEstablecimiento,(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t1 where t1.NumRegistro = CodigoEstablecimiento) as Estable, " +
                " CodigoCategoria,(select NombreCategoria from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS where CodigoCategoria = t1.CodigoCategoria) as Categ,SesionAprobacion,Fecha,FechaHasta,Observaciones" +
                " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SANCIONES t1 WHERE NumeroColegiado = '" + txtNumColegiado.Valor + "' order by Id";

            DataTable dtSanciones = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtSanciones, ref error))
            {
                dgvSanciones.Rows.Clear();
                foreach (DataRow row in dtSanciones.Rows)
                {
                    //dgvSanciones.Rows.Add(row["Id"].ToString(), DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                    dgvSanciones.Rows.Add(row["Id"].ToString(), row["CodigoEstablecimiento"].ToString(), row["Estable"].ToString(), row["CodigoCategoria"].ToString(), row["Categ"].ToString(), row["SesionAprobacion"].ToString(),
                        row["Fecha"].ToString() != "" ? DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy") : "", row["FechaHasta"].ToString() != "" ? DateTime.Parse(row["FechaHasta"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString().Trim());
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarHistorialRegencias()
        {
            //string sQuery = "select NumRegistro,(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = t1.NumRegistro) as Estable," +
            //        " CodigoCategoria,(select NombreCategoria from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS where CodigoCategoria = t1.CodigoCategoria) as Categ," +
            //        " SesionAprobacion,FechaAprobacion,EstadoPrevio,EstadoActual" +
            //        " from "+ Consultas.sqlCon.COMPAÑIA +".NV_CAMBIO_REGENCIA t1 where IdColegiado = '"+ txtNumColegiado.Valor +"' order by NumRegistro";

            //DataTable dt = new DataTable();

            //if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            //{
            //    dgvHistorialRegencias.Rows.Clear();
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        //dgvSanciones.Rows.Add(row["Id"].ToString(), DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
            //        dgvHistorialRegencias.Rows.Add(row["NumRegistro"].ToString(), row["Estable"].ToString(),row["CodigoCategoria"].ToString(), row["Categ"].ToString(), row["SesionAprobacion"].ToString(),
            //            row["FechaAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaAprobacion"].ToString()).ToString("dd/MM/yyyy") : "", fInternas.obtenerEstado(row["EstadoPrevio"].ToString()), fInternas.obtenerEstado(row["EstadoActual"].ToString()));
            //    }
            //}
            //else
            //    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string sQuery = "select NumRegistro,(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = t1.NumRegistro) as Estable," +
                    " CodigoCategoria,(select NombreCategoria from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS where CodigoCategoria = t1.CodigoCategoria) as Categ," +
                    " SesionAprobacion,FechaAprobacion,Estado" +
                    " from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_DE_REGENCIA t1 where IdColegiado = '" + txtNumColegiado.Valor + "' order by NumRegistro";

            DataTable dt = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                dgvHistorialRegencias.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    //dgvSanciones.Rows.Add(row["Id"].ToString(), DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                    //dgvHistorialRegencias.Rows.Add(row["NumRegistro"].ToString(), row["Estable"].ToString(), row["CodigoCategoria"].ToString(), row["Categ"].ToString(), row["SesionAprobacion"].ToString(),
                    //    row["FechaAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaAprobacion"].ToString()).ToString("dd/MM/yyyy") : "", fInternas.obtenerEstado(row["EstadoPrevio"].ToString()), fInternas.obtenerEstado(row["EstadoActual"].ToString()));
                    dgvHistorialRegencias.Rows.Add(row["NumRegistro"].ToString(), row["Estable"].ToString(), row["CodigoCategoria"].ToString(), row["Categ"].ToString(), row["SesionAprobacion"].ToString(),
                       row["FechaAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaAprobacion"].ToString()).ToString("dd/MM/yyyy") : "", fInternas.obtenerEstado(row["Estado"].ToString()));
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override bool validarDatos(ref string errores)
        {
            dgvEstablecimientos.EndEdit();
            dgvHorarios.EndEdit();
            dgvInformes.EndEdit();
            dgvVisitasFisc.EndEdit();
            if (txtNumColegiado.Valor == "")
            {
                errores = "Debe seleccionar un colegiado.";
                txtNumColegiado.Focus();
                return false;
            }

            if (txtCobrador.Valor == "")
            {
                errores = "Debe seleccionar un Cobrador.";
                txtCobrador.Focus();
                return false;
            }

            if (chkCurso.Checked == false)
            {
                errores = "No se puede registrar regente sin tener los cursos de regencias.";
                chkCurso.Focus();
                return false;
            }

            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                if (row.Cells["colCodigoEstablecimiento"].Value.ToString() == "")
                {
                    errores = "Debe definir un código de establecimiento en la fila "+(row.Index+1)+" de la tabla de establecimientos.";
                    return false;
                }

                if (row.Cells["colCodigoCategoria"].Value.ToString() == "")
                {
                    errores = "Debe definir una categoria para el establecimiento en la fila " + (row.Index + 1) + " de la tabla de establecimientos.";
                    return false;
                }

                if (row.Cells["colEstado"].Value==null)
                {
                    errores = "Debe definir un estado para el establecimiento en la fila " + (row.Index + 1) + " de la tabla de establecimientos.";
                    return false;
                }
            }

            foreach (DataGridViewRow row in dgvHorarios.Rows)
            {
                if (row.Cells["colDia"].Value.ToString() == "")
                {
                    errores = "Debe definir un día en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }

                if (row.Cells["colHoraInicio"].Value.ToString() == "")
                {
                    errores = "Debe definir una hora de inicio en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }

                if (row.Cells["colMinInicio"].Value.ToString() == "")
                {
                    errores = "Debe definir una hora de inicio en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }

                if (row.Cells["colTipoInicio"].Value.ToString() == "")
                {
                    errores = "Debe definir el tipo de hora (AM/PM) para la hora de inicio en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }



                if (row.Cells["colHoraFin"].Value.ToString() == "")
                {
                    errores = "Debe definir una hora de Fin en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }

                if (row.Cells["colMinFin"].Value.ToString() == "")
                {
                    errores = "Debe definir una hora de Fin en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }

                if (row.Cells["colTipoFin"].Value.ToString() == "")
                {
                    errores = "Debe definir el tipo de hora (AM/PM) para la hora de Fin en la fila " + (row.Index + 1) + " de la tabla de horarios.";
                    return false;
                }
            }

            foreach (DataGridViewRow row in dgvInformes.Rows)
            {
                if (row.Cells["colFechaInf"].Value.ToString() == "")
                {
                    errores = "Debe definir una fecha en la fila " + (row.Index + 1) + " de la tabla de Informes Realizados.";
                    return false;
                }
                
            }

            foreach (DataGridViewRow row in dgvVisitasFisc.Rows)
            {
                if (row.Cells["colFechaFisc"].Value.ToString() == "")
                {
                    errores = "Debe definir una fecha en la fila " + (row.Index + 1) + " de la tabla de Visitas Fiscalía.";
                    return false;
                }

            }

            foreach (DataGridViewRow row in dgvProtocolos.Rows)
            {
                if (row.Cells["colLibro"].Value.ToString() == "")
                {
                    errores = "Debe definir el libro en la fila " + (row.Index + 1) + " de la sección de Libros Protocolo.";
                    return false;
                }

                if (row.Cells["colFechaApertura"].Value.ToString() == "")
                {
                    errores = "Debe definir la fecha de apertura en la fila " + (row.Index + 1) + " de la sección de Libros Protocolo.";
                    return false;
                }

                //if (row.Cells["colFechaCierre"].Value.ToString() == "")
                //{
                //    errores = "Debe definir la fecha de cierre en la fila " + (row.Index + 1) + " de la sección de Libros Protocolo.";
                //    return false;
                //}

            }

            foreach (DataGridViewRow row in dgvSanciones.Rows)
            {
                if (row.Cells["colFechaSancion"].Value.ToString() == "")
                {
                    errores = "Debe definir una fecha en la fila " + (row.Index + 1) + " de la sección de Sanciones.";
                    return false;
                }

            }

            return true;
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
                    //txtCobrador.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    //buscaCobrador(txtCobrador.Valor);
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
                    //txtCobrador.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    //buscaCobrador(txtCobrador.Valor);
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

        private void listaTipos()
        {
            DataTable dtTpos = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoTipo,NombreTipo";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_TIPOS";
            listA.FILTRO = "where Diferenciador = 'R'";
            listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dtTpos, ref error))
            {
                if (dtTpos.Rows.Count > 0)
                {
                    cmbTipo.DataSource(dtTpos, "CodigoTipo", "NombreTipo");
                    cmbTipo.Valor = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buscaCobrador(string codigo)
        {

            if (txtCobrador.Valor.Trim() == "")
            {
                txtCobradorNombre.Clear();
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
                    txtCobradorNombre.Valor = dtCobrador.Rows[0]["Nombre"].ToString();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El código de cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCobrador.Clear();
                        txtCobradorNombre.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtNumColegiado.Valor);
            txtNumColegiado.ReadOnly = true;
            txtNColegiado.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Regente: "+ txtNColegiado.Valor.Trim()+ "-" + txtNombreColegiado.Valor;
        }

        private void txtNumColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtNumColegiado.ReadOnly)
            {
                listaColegiados();
            }
        }

        private void txtNumColegiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtNumColegiado.ReadOnly)
                listaColegiados();
        }

        private void txtNumColegiado_Leave(object sender, EventArgs e)
        {
            buscaColegiadoLeave(txtNColegiado.Valor);
        }

        private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCobradores("cobrador");
        }

        protected override void limpiarFormulario()
        {
            txtNumColegiado.Clear();
            txtNColegiado.Clear();
            txtNColegiado.ReadOnly = false;
            txtNombreColegiado.Clear();
            chkCurso.Checked = false;
            txtCobrador.Clear();
            txtCobradorNombre.Clear();
            txtSesionAprob.Clear();
            txtSesionPerdida.Clear();
            dtpAprobacion.Value = DateTime.Now;
            dtpPerdida.Value = DateTime.Now;
            cmbTipo.Valor = "";
            rtbObservaciones.Clear();
            limpiarPoliza();
            dgvEstablecimientos.Rows.Clear();
            dgvHorarios.Rows.Clear();
            dgvInformes.Rows.Clear();
            dgvSanciones.Rows.Clear();
            dgvVisitasFisc.Rows.Clear();
            dgvProtocolos.Rows.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Colegiado";
        }

        private void listaCobradores(string identificador)
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
                if(identificador == "establecimiento")
                {
                    dgvEstablecimientos.CurrentCell.Value = f1Cobrador.item.SubItems[1].Text;
                    dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoCobrador"].Value = f1Cobrador.item.SubItems[0].Text;
                    dgvEstablecimientos.EndEdit();
                }
                else
                {
                    txtCobrador.Valor = f1Cobrador.item.SubItems[0].Text;
                    txtCobradorNombre.Valor = f1Cobrador.item.SubItems[1].Text;
                }
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCobradores("cobrador");
        }

        private void txtCobrador_Leave(object sender, EventArgs e)
        {
            buscaCobrador(txtCobrador.Valor);
        }

        private void btnNuevoEst_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_EDITAR))
            {
                if (!tieneSancion())
                {
                    dgvEstablecimientos.Rows.Add("", "", "", "", "", "", "", "");
                }
                else
                {
                    MessageBox.Show("El regente esta sancionado, no se puede agregar ninguna regencia.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           
        }

        private bool tieneSancion()
        {
            bool tiene = false;

            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                if (row.Cells["colEstado"].Value.ToString() == "Sancionado")
                    tiene = true;
            }

            return tiene;
        }

        private void dgvEstablecimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (e.RowIndex != -1)
            {
                if ((dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colFechaAprobacion"))
                {

                    dtp = new DateTimePicker();
                    dgvEstablecimientos.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvEstablecimientos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colFechaAprobacion" && dgvEstablecimientos.Rows[e.RowIndex].Cells["colFechaAprobacion"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvEstablecimientos.Rows[e.RowIndex].Cells["colFechaAprobacion"].Value.ToString());

                    dtp.Visible = true;

                }
                
                if (dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() != "")
                    cargarInfoEstablecimiento(dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString());

            }


            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void cargarInfoEstablecimiento(string codigoEst)
        {
            StringBuilder errores = new StringBuilder();
            try
            {
                DataTable dt = new DataTable();
                string sQuery = "SELECT Id,Dia,HoraInicio,HoraFin from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS WHERE NumeroColegiado='" + txtNumColegiado.Valor +
                    "' AND CodigoEstablecimiento='" + codigoEst + "'";

                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    dgvHorarios.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string dia = "", horaInicio = "", minInicio = "", tipoInicio = "", horaFin = "", minFin = "", tipoFin = "";
                        if (row["Dia"].ToString() == "2")
                            dia = "Lunes";

                        if (row["Dia"].ToString() == "3")
                            dia = "Martes";

                        if (row["Dia"].ToString() == "4")
                            dia = "Miércoles";

                        if (row["Dia"].ToString() == "5")
                            dia = "Jueves";

                        if (row["Dia"].ToString() == "6")
                            dia = "Viernes";

                        if (row["Dia"].ToString() == "7")
                            dia = "Sábado";

                        if (row["Dia"].ToString() == "1")
                            dia = "Domingo";

                        string[] minutosIni = row["HoraInicio"].ToString().Split(' ');
                        string[] minutosFin = row["HoraFin"].ToString().Split(' ');

                        horaInicio = minutosIni[1].Split(':')[0];
                        minInicio = minutosIni[1].Split(':')[1];
                        tipoInicio = minutosIni[2];
                        tipoFin = minutosFin[2];

                        horaFin = minutosFin[1].Split(':')[0];
                        minFin = minutosFin[1].Split(':')[1];

                        string param = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern;
                        if (!param.Equals("hh:mm:ss tt"))
                        {
                            //Se comenta pues el formato requerido es hhmmss tt
                            if (int.Parse(horaInicio) < 10)
                                horaInicio = "0" + horaInicio;

                            if (int.Parse(horaFin) < 10)
                                horaFin = "0" + horaFin;
                        }

                        dgvHorarios.Rows.Add(row["Id"].ToString(), dia, horaInicio, minInicio, tipoInicio, horaFin, minFin, tipoFin);
                    }
                }
                else
                    errores.AppendLine(error);


                sQuery = "SELECT Id,FechaInforme,Observaciones FROM "+Consultas.sqlCon.COMPAÑIA+
                    ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES WHERE NumeroColegiado='"+txtNumColegiado.Valor+"' AND "+
                    "CodigoEstablecimiento='"+codigoEst+ "' order by FechaInforme asc";

                dt = new DataTable();

                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    dgvInformes.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvInformes.Rows.Add(row["Id"].ToString(), DateTime.Parse(row["FechaInforme"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                    }
                }
                else
                    errores.AppendLine(error);


                sQuery = "SELECT Id,FechaVisita,Observaciones FROM " + Consultas.sqlCon.COMPAÑIA +
                    ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC WHERE NumeroColegiado='" + txtNumColegiado.Valor + "' AND " +
                    "CodigoEstablecimiento='" + codigoEst + "' order by FechaVisita asc";

                dt = new DataTable();

                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    dgvVisitasFisc.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvVisitasFisc.Rows.Add(row["Id"].ToString(), DateTime.Parse(row["FechaVisita"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                    }
                }
                else
                    errores.AppendLine(error);

                if (errores.ToString() != "")
                {
                    MessageBox.Show("Ocurrieron los siguientes errores:\n" + errores.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            dgvEstablecimientos.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtp_OnTextChangeInf(object sender, EventArgs e)
        {
            dgvInformes.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtp_OnTextChangeVisitas(object sender, EventArgs e)
        {
            dgvVisitasFisc.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtp_OnTextChangeProt(object sender, EventArgs e)
        {
            dgvProtocolos.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtp_OnTextChangeSanciones(object sender, EventArgs e)
        {
            dgvSanciones.CurrentCell.Value = dtp.Text.ToString();
        }

        void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void btnNuevoHorario_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_EDITAR))
            {
                if (dgvEstablecimientos.RowCount == 0)
                {
                    MessageBox.Show("Primero debe agregar un establecimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvHorarios.Rows.Add(dgvHorarios.RowCount + 1, "", "", "", "", "", "", "");
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           
        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void btnNuevoInforme_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_EDITAR))
            {
                if (dgvEstablecimientos.RowCount == 0)
                {
                    MessageBox.Show("Primero debe agregar un establecimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvInformes.RowCount > 0)
                {
                    if (dgvInformes.Rows[dgvInformes.Rows.Count - 1].Cells["colFechaInf"].Value.ToString().Equals("")
                    && dgvInformes.Rows[dgvInformes.Rows.Count - 1].Cells["colObservacionInf"].Value.ToString().Equals(""))
                    {
                        MessageBox.Show("Primero debe debe llenar la ultima fila.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int idInformes = 0;
                if (fInternas.obtenerUltimoIdInformes(ref idInformes))
                {
                    dgvInformes.Rows.Add(idInformes + 1, "", "");
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void dgvInformes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (e.RowIndex != -1)
            {
                if ((dgvInformes.CurrentCell.OwningColumn.Name == "colFechaInf"))
                {

                    dtp = new DateTimePicker();
                    dgvInformes.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvInformes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChangeInf);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvInformes.CurrentCell.OwningColumn.Name == "colFechaInf" && dgvInformes.Rows[e.RowIndex].Cells["colFechaInf"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvInformes.Rows[e.RowIndex].Cells["colFechaInf"].Value.ToString());

                    dtp.Visible = true;

                }
            }
            
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void btnNuevoVisita_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_EDITAR))
            {
                if (dgvEstablecimientos.RowCount == 0)
                {
                    MessageBox.Show("Primero debe agregar un establecimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvVisitasFisc.RowCount > 0)
                {
                    if (dgvVisitasFisc.Rows[dgvVisitasFisc.Rows.Count - 1].Cells["colFechaFisc"].Value.ToString().Equals("")
                    && dgvVisitasFisc.Rows[dgvVisitasFisc.Rows.Count - 1].Cells["colObservacionFisc"].Value.ToString().Equals(""))
                    {
                        MessageBox.Show("Primero debe debe llenar la ultima fila.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                dgvVisitasFisc.Rows.Add(dgvVisitasFisc.RowCount + 1, "", "");
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void dgvVisitasFisc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if(e.RowIndex != -1)
            {
                if ((dgvVisitasFisc.CurrentCell.OwningColumn.Name == "colFechaFisc"))
                {

                    dtp = new DateTimePicker();
                    dgvVisitasFisc.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvVisitasFisc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChangeVisitas);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvVisitasFisc.CurrentCell.OwningColumn.Name == "colFechaFisc" && dgvVisitasFisc.Rows[e.RowIndex].Cells["colFechaFisc"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvVisitasFisc.Rows[e.RowIndex].Cells["colFechaFisc"].Value.ToString());

                    dtp.Visible = true;

                }
            }
            
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        protected override bool guardarDetalle(ref string error)
        {
            bool lbOk = true;

            lbOk = guardarEstablecimientos(ref error);

            if (lbOk)
                lbOk = guardarLibrosProtocolos(ref error);

            if (lbOk)
                lbOk = guardarSanciones(ref error);

            if (lbOk)
                lbOk = guardarHorarios(ref error);

            if (lbOk)
                lbOk = guardarInformes(ref error);

            if (lbOk)
                lbOk = guardarVisitasFiscalia(ref error);

            if (lbOk)
                lbOk = InsertarVidaSilvestre(ref error);


            return lbOk;
        }

        private void cargarSancionesTemp(ref DataTable dtSanciones)
        {

            string sQuery = "SELECT Id,CodigoEstablecimiento,CodigoCategoria FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SANCIONES WHERE NumeroColegiado = '" + txtNumColegiado.Valor + "' order by Id";

            //DataTable dtSanciones = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtSanciones, ref error))
            {
                
                //foreach (DataRow row in dtSanciones.Rows)
                //{
                //    //dgvSanciones.Rows.Add(row["Id"].ToString(), DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                //    dgvSanciones.Rows.Add(row["Id"].ToString(), row["CodigoEstablecimiento"].ToString(), row["Estable"].ToString(), row["CodigoCategoria"].ToString(), row["Categ"].ToString(), row["SesionAprobacion"].ToString(),
                //        row["Fecha"].ToString() != "" ? DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy") : "", row["FechaHasta"].ToString() != "" ? DateTime.Parse(row["FechaHasta"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString().Trim());
                //}
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool esSancionNueva(DataTable dtSanciones, string cole, string estable, string categ)
        {
            bool existe = false;

            if (dtSanciones.Rows.Count > 0)
            {
                foreach (DataRow row in dtSanciones.Rows)
                {
                    if (row["NumeroColegiado"].ToString().Equals(cole) && row["CodigoEstablecimiento"].ToString().Equals(estable) && row["CodigoCategoria"].ToString().Equals(categ))
                        existe = true;
                    else
                        existe = false;
                }

            }

            return existe;
        }

        //private bool guardarEstablecimientos(ref string error)
        //{
        //    Listado list = new Listado();
        //    list.COLUMNAS = "NumeroColegiado,CodigoEstablecimiento,SesionAprobacion,FechaAprobacion,Estado,CodigoCategoria,Cobrador";
        //    list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
        //    bool lbOk = true;
        //    try
        //    {
        //        string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'";

        //        lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

        //        if (lbOk)
        //        {
        //            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
        //            {
        //                parametros.Clear();
        //                list.COLUMNAS_PK.Add("NumeroColegiado");
        //                parametros.Add(txtNumColegiado.Valor);
        //                parametros.Add(row.Cells["colCodigoEstablecimiento"].Value.ToString());
        //                if (row.Cells["colSesionApEst"].Value.ToString() != "")
        //                {
        //                    parametros.Add(row.Cells["colSesionApEst"].Value.ToString());
        //                    parametros.Add(DateTime.Parse(row.Cells["colFechaAprobacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
        //                }
        //                else
        //                {
        //                    parametros.Add("null");
        //                    parametros.Add("null");
        //                }

        //                parametros.Add(row.Cells["colEstado"].Value.ToString()[0]+"");
        //                parametros.Add(row.Cells["colCodigoCategoria"].Value.ToString());
        //                if(!row.Cells["colCodigoCobrador"].Value.ToString().Equals(""))
        //                    parametros.Add(row.Cells["colCodigoCobrador"].Value.ToString());
        //                else
        //                    parametros.Add("null");

        //                lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //        return false;
        //    }
        //    return lbOk;
        //}

        private bool guardarEstablecimientos(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumeroColegiado,CodigoEstablecimiento,SesionAprobacion,FechaAprobacion,Estado,CodigoCategoria,Cobrador";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
            bool lbOk = true;
            try
            {
                lbOk = VerificaEstadoRegenciasVrsCategorias(ref error);
                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
                    {
                        lbOk = fInternas.insertarHistorialRegencias(txtNumColegiado.Valor, row.Cells["colCodigoEstablecimiento"].Value.ToString(), row.Cells["colCodigoCategoria"].Value.ToString(), row.Cells["colEstado"].Value.ToString()[0].ToString(), ref error);
                    }
                }
                    

                if (lbOk)
                {
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'";

                    lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
                }

                if (lbOk)
                {

                    foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("NumeroColegiado");
                        parametros.Add(txtNumColegiado.Valor);
                        parametros.Add(row.Cells["colCodigoEstablecimiento"].Value.ToString());
                        if (row.Cells["colSesionApEst"].Value.ToString() != "")
                        {
                            parametros.Add(row.Cells["colSesionApEst"].Value.ToString());
                            parametros.Add(DateTime.Parse(row.Cells["colFechaAprobacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                        }
                        else
                        {
                            parametros.Add("null");
                            parametros.Add("null");
                        }

                        parametros.Add(row.Cells["colEstado"].Value.ToString()[0] + "");
                        parametros.Add(row.Cells["colCodigoCategoria"].Value.ToString());
                        if (!row.Cells["colCodigoCobrador"].Value.ToString().Equals(""))
                            parametros.Add(row.Cells["colCodigoCobrador"].Value.ToString());
                        else
                            parametros.Add("null");

                        lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }
        private bool guardarLibrosProtocolos(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumeroColegiado,Codigo,Libro,Folio,Asiento,LibCol,FechaApertura,FechaCierre,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_LIB_PROTOCOLOS";
            bool lbOk = true;
            try
            {
                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_LIB_PROTOCOLOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvProtocolos.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("NumeroColegiado");
                        list.COLUMNAS_PK.Add("Codigo");
                        parametros.Add(txtNumColegiado.Valor);
                        parametros.Add(row.Cells["colCodigoProtocolo"].Value.ToString());
                        parametros.Add(row.Cells["colLibro"].Value.ToString());
                        parametros.Add(row.Cells["colFolio"].Value.ToString());
                        parametros.Add(row.Cells["colAsiento"].Value.ToString());
                        parametros.Add(row.Cells["colLibCol"].Value.ToString());
                        if(!row.Cells["colFechaApertura"].Value.ToString().Equals(""))
                            parametros.Add(DateTime.Parse(row.Cells["colFechaApertura"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                        else
                            parametros.Add("null");

                        if (!row.Cells["colFechaCierre"].Value.ToString().Equals(""))
                            parametros.Add(DateTime.Parse(row.Cells["colFechaCierre"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                        else
                            parametros.Add("null");
                        //parametros.Add(DateTime.Parse(row.Cells["colFechaCierre"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                      
                        parametros.Add(row.Cells["colObservacionesProtocolo"].Value.ToString());


                        lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        private bool guardarHorarios(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "Id,NumeroColegiado,CodigoEstablecimiento,Dia,HoraInicio,HoraFin";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS_HORARIOS";
            bool lbOk = true;
            try
            {
                //string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + 
                //  "' AND CodigoEstablecimiento='"+ dgvEstablecimientos.SelectedCells[0].OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString()+"'";
                if (dgvEstablecimientos.Rows.Count > 0)
                {
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'" +
                   " AND CodigoEstablecimiento='" + dgvEstablecimientos.SelectedCells[0].OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'"; ;

                    lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                    if (lbOk)
                    {
                        foreach (DataGridViewRow row in dgvHorarios.Rows)
                        {
                            parametros.Clear();
                            list.COLUMNAS_PK.Clear();
                            list.COLUMNAS_PK.Add("Id");
                            list.COLUMNAS_PK.Add("NumeroColegiado");
                            list.COLUMNAS_PK.Add("CodigoEstablecimiento");
                            parametros.Add(row.Cells["colIdHorario"].Value.ToString());
                            parametros.Add(txtNumColegiado.Valor);
                            parametros.Add(dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString());
                            int dia = 0;

                            if (row.Cells["colDia"].Value.ToString() == "Lunes")
                                dia = 2;
                            else
                                if (row.Cells["colDia"].Value.ToString() == "Martes")
                                dia = 3;
                            else
                                if (row.Cells["colDia"].Value.ToString() == "Miércoles")
                                dia = 4;
                            else
                                if (row.Cells["colDia"].Value.ToString() == "Jueves")
                                dia = 5;
                            else
                                if (row.Cells["colDia"].Value.ToString() == "Viernes")
                                dia = 6;
                            else
                                if (row.Cells["colDia"].Value.ToString() == "Sábado")
                                dia = 7;
                            else
                                dia = 1;

                            parametros.Add(dia + "");

                            string horaInicio = "";
                            string horaFin = "";

                            horaInicio += DateTime.Now.ToString("yyyy-MM-ddT") + row.Cells["colHoraInicio"].Value.ToString() + ":" +
                                row.Cells["colMinInicio"].Value.ToString() + ":00.000 " + row.Cells["colTipoInicio"].Value.ToString();

                            horaFin += DateTime.Now.ToString("yyyy-MM-ddT") + row.Cells["colHoraFin"].Value.ToString() + ":" +
                                row.Cells["colMinFin"].Value.ToString() + ":00.000 " + row.Cells["colTipoFin"].Value.ToString();

                            parametros.Add(horaInicio);
                            parametros.Add(horaFin);
                            lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        private bool guardarInformes(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "Id,NumeroColegiado,CodigoEstablecimiento,FechaInforme,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS_INFORMES";
            bool lbOk = true;
            try
            {
                //string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES WHERE NumeroColegiado='" + txtNumColegiado.Valor +
                //  "' AND CodigoEstablecimiento='" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";
                if (dgvEstablecimientos.Rows.Count > 0)
                {
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES WHERE NumeroColegiado='" + txtNumColegiado.Valor +
                 "' AND CodigoEstablecimiento='" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

                    lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                    if (lbOk)
                    {
                        foreach (DataGridViewRow row in dgvInformes.Rows)
                        {
                            parametros.Clear();
                            list.COLUMNAS_PK.Clear();
                            list.COLUMNAS_PK.Add("Id");
                            list.COLUMNAS_PK.Add("NumeroColegiado");
                            list.COLUMNAS_PK.Add("CodigoEstablecimiento");
                            parametros.Add(row.Cells["colIdInforme"].Value.ToString());
                            parametros.Add(txtNumColegiado.Valor);
                            parametros.Add(dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString());
                            parametros.Add(DateTime.Parse(row.Cells["colFechaInf"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

                            parametros.Add(row.Cells["colObservacionInf"].Value.ToString());
                            lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        private bool guardarVisitasFiscalia(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "Id,NumeroColegiado,CodigoEstablecimiento,FechaVisita,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC";
            bool lbOk = true;
            try
            {
                //  string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC WHERE NumeroColegiado='" + txtNumColegiado.Valor +
                // "' AND CodigoEstablecimiento='" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";
                if (dgvEstablecimientos.Rows.Count > 0)
                {
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC WHERE NumeroColegiado='" + txtNumColegiado.Valor +
               "' AND CodigoEstablecimiento='" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

                    lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                    if (lbOk)
                    {
                        foreach (DataGridViewRow row in dgvVisitasFisc.Rows)
                        {
                            parametros.Clear();
                            list.COLUMNAS_PK.Clear();
                            list.COLUMNAS_PK.Add("Id");
                            list.COLUMNAS_PK.Add("NumeroColegiado");
                            list.COLUMNAS_PK.Add("CodigoEstablecimiento");
                            parametros.Add(row.Cells["colIdVisitas"].Value.ToString());
                            parametros.Add(txtNumColegiado.Valor);
                            parametros.Add(dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString());
                            parametros.Add(DateTime.Parse(row.Cells["colFechaFisc"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

                            parametros.Add(row.Cells["colObservacionFisc"].Value.ToString());
                            lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        private bool guardarSanciones(ref string error)
        {
            Listado list = new Listado();
            DataTable dtTemp = new DataTable();
            //list.COLUMNAS = "Id,NumeroColegiado,Fecha,Observaciones";
            list.COLUMNAS = "Id,NumeroColegiado,CodigoEstablecimiento,CodigoCategoria,SesionAprobacion,Fecha,FechaHasta,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_SANCIONES";
            bool lbOk = true;
            try
            {
                //cargarSancionesTemp(ref dtTemp);

                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SANCIONES WHERE NumeroColegiado='" + txtNumColegiado.Valor +"'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvSanciones.Rows)
                    {
                        //if (esSancionNueva(dtTemp, txtNumColegiado.Valor, row.Cells["colCodigoEstable"].Value.ToString(), row.Cells["colCodigoCategoriaS"].Value.ToString()))
                        //{
                            parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("Id");
                            list.COLUMNAS_PK.Add("NumeroColegiado");
                            parametros.Add(row.Cells["colIdSancion"].Value.ToString());
                            parametros.Add(txtNumColegiado.Valor);
                            parametros.Add(row.Cells["colCodigoEstable"].Value.ToString());
                            parametros.Add(row.Cells["colCodigoCategoriaS"].Value.ToString());
                            parametros.Add(row.Cells["colSesionSancion"].Value.ToString());
                            parametros.Add(DateTime.Parse(row.Cells["colFechaSancion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                            parametros.Add(DateTime.Parse(row.Cells["colFechaHasta"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

                            parametros.Add(row.Cells["colObservacionesSancion"].Value.ToString());
                            lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        //public bool insertarHistorialRegencias(string NumRegistro, string CodigoCategoria, string EstadoPrevio, string EstadoActual, string SesionAprobacion, string FechaAprobacion, ref string error)
        //{
        //    StringBuilder sQuery = new StringBuilder();
        //    List<string> parametrosQuery = new List<string>();


        //    sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_REGENCIA (IdColegiado,NumRegistro,CodigoCategoria,EstadoPrevio,EstadoActual,SesionAprobacion,FechaAprobacion)");
        //    sQuery.AppendLine("VALUES (@IdColegiado,@NumRegistro,@CodigoCategoria,@EstadoPrevio,@EstadoActual,@SesionAprobacion,@FechaAprobacion)");

        //    #region PARAMETROS

        //    parametrosQuery.Add("@IdColegiado," + txtNumColegiado.Valor);
        //    parametrosQuery.Add("@NumRegistro," + NumRegistro);
        //    parametrosQuery.Add("@CodigoCategoria," + CodigoCategoria);
        //    parametrosQuery.Add("@EstadoPrevio," + EstadoPrevio[0] + "");
        //    parametrosQuery.Add("@EstadoActual," + EstadoActual[0] + "");
        //    parametrosQuery.Add("@SesionAprobacion," + SesionAprobacion);
        //    if(!FechaAprobacion.Equals(""))
        //        parametrosQuery.Add("@FechaAprobacion," + DateTime.Parse(FechaAprobacion).ToString("yyyy-MM-ddTHH:mm:ss"));
        //    else
        //        parametrosQuery.Add("@FechaAprobacion,null");

        //    #endregion

        //    if (Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametrosQuery, ref error))
        //        return true;
        //    else
        //        return false;

        //}

        private void btnEliminaEst_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_BORRAR))
            {
                if (dgvEstablecimientos.RowCount == 0)
                    return;

                if (MessageBox.Show("Se borrará toda la información asociada al establecimiento (Horario, Informes, Visitas Fiscalía), ¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString().Equals("") && !dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoCategoria"].Value.ToString().Equals(""))
                    {
                        Consultas.sqlCon.iniciaTransaccion();
                        bool OK = true;
                        string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS where NumeroColegiado='"
                            + txtNumColegiado.Valor +
                            "' and CodigoEstablecimiento='" +
                            dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

                        OK = Consultas.ejecutarSentencia(sQuery, ref error);

                        if (OK)
                        {
                            sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES where NumeroColegiado='"
                            + txtNumColegiado.Valor +
                            "' and CodigoEstablecimiento='" +
                            dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

                            OK = Consultas.ejecutarSentencia(sQuery, ref error);
                        }

                        if (OK)
                        {
                            sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC where NumeroColegiado='"
                            + txtNumColegiado.Valor +
                            "' and CodigoEstablecimiento='" +
                            dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

                            OK = Consultas.ejecutarSentencia(sQuery, ref error);
                        }

                        if (OK)
                        {
                            sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado='"
                            + txtNumColegiado.Valor +
                            "' and CodigoEstablecimiento='" +
                            dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

                            OK = Consultas.ejecutarSentencia(sQuery, ref error);
                        }

                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            dgvHorarios.Rows.Clear();
                            dgvInformes.Rows.Clear();
                            dgvVisitasFisc.Rows.Clear();
                            dgvEstablecimientos.Rows.Remove(dgvEstablecimientos.CurrentRow);
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                        }
                    }
                    else
                    {
                        dgvEstablecimientos.Rows.Remove(dgvEstablecimientos.CurrentRow);
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnEliminaHorario_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_BORRAR))
            {
                if (dgvHorarios.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS where NumeroColegiado='"
                        + txtNumColegiado.Valor +
                        "' and CodigoEstablecimiento='" +
                        dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "' AND " +
                        "Id=" + dgvHorarios.CurrentCell.OwningRow.Cells["colIdHorario"].Value.ToString();

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvHorarios.Rows.Remove(dgvHorarios.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnNuevoSancion_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO,Constantes.REGENCIAS_EDITAR))
            {
                string id = "";
                if (dgvSanciones.Rows.Count > 0)
                {
                    if (dgvSanciones.Rows[dgvSanciones.Rows.Count - 1].Cells["colFechaSancion"].Value.ToString().Equals("")
                    && dgvSanciones.Rows[dgvSanciones.Rows.Count - 1].Cells["colObservacionesSancion"].Value.ToString().Equals(""))
                    {
                        MessageBox.Show("Primero debe llenar la ultima fila.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (txtNumRegistroSancion.Valor.Equals("") && txtCategoriaSancion.Valor.Equals(""))
                {
                    MessageBox.Show("Primero debe ingresar una regencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (validarIngresoSancion(txtNumRegistroSancion.Valor, txtCategoriaSancion.Valor,ref id))
                //{
                //    if (!id.Equals(txtIdSancion.Valor))
                //    {
                //        MessageBox.Show("La regencia a sancionar tiene una sancion vigente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}

                dgvSanciones.Rows.Add(dgvSanciones.RowCount + 1, txtNumRegistroSancion.Valor, txtNumRegistroSancionDesc.Valor,
                    txtCategoriaSancion.Valor, txtCategoriaSancionDesc.Valor, txtSesionSancion.Valor, dtpFechaSesionSancion.Value.ToString("dd/MM/yyyy"), dtpFechaHastaSancion.Value.ToString("dd/MM/yyyy"), rtbObservacionSancion.Text);

                if (btnGuardar.Visible)
                {
                    if (guardarSanciones(ref error))
                    {
                        CambioEstadoSancionado(txtNumRegistroSancion.Valor, txtCategoriaSancion.Valor, txtSesionSancion.Valor, dtpFechaSesionSancion.Value.ToString("dd/MM/yyyy"));
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //btnGuardar.Enabled = true;
            //btnGuardarSalir.Enabled = true;
        }

        private void btnNuevoLibro_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_EDITAR))
            {
                int contFechaCierre = 0;


                foreach (DataGridViewRow row in dgvProtocolos.Rows)
                {
                    if (row.Cells["colFechaCierre"].Value.ToString() == "")
                    {
                        contFechaCierre++;
                    }
                }

                if (contFechaCierre == 0)
                {
                    dgvProtocolos.Rows.Add(dgvProtocolos.RowCount + 1, "", "", "", "", "", "", "", "");
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe indicar una fecha de cierre para un nuevo registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                contFechaCierre = 0;
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void dgvSanciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dtp.Visible = false;
            //if (e.RowIndex != -1)
            //{
            //    if ((dgvSanciones.CurrentCell.OwningColumn.Name == "colFechaSancion"))
            //    {

            //        dtp = new DateTimePicker();
            //        dgvSanciones.Controls.Add(dtp);
            //        dtp.Format = DateTimePickerFormat.Custom;
            //        dtp.CustomFormat = "dd/MM/yyyy";
            //        Rectangle Rectangle = dgvSanciones.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //        dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
            //        dtp.Location = new Point(Rectangle.X, Rectangle.Y);

            //        dtp.CloseUp += new EventHandler(dtp_CloseUp);
            //        dtp.TextChanged += new EventHandler(dtp_OnTextChangeSanciones);
            //        dtp.LostFocus += new EventHandler(dtp_CloseUp);

            //        if (dgvSanciones.CurrentCell.OwningColumn.Name == "colFechaSancion" && dgvSanciones.Rows[e.RowIndex].Cells["colFechaSancion"].Value.ToString() != string.Empty)
            //            dtp.Value = DateTime.Parse(dgvSanciones.Rows[e.RowIndex].Cells["colFechaSancion"].Value.ToString());

            //        dtp.Visible = true;

            //    }

            //    if ((dgvSanciones.CurrentCell.OwningColumn.Name == "colFechaHasta"))
            //    {

            //        dtp = new DateTimePicker();
            //        dgvSanciones.Controls.Add(dtp);
            //        dtp.Format = DateTimePickerFormat.Custom;
            //        dtp.CustomFormat = "dd/MM/yyyy";
            //        Rectangle Rectangle = dgvSanciones.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //        dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
            //        dtp.Location = new Point(Rectangle.X, Rectangle.Y);

            //        dtp.CloseUp += new EventHandler(dtp_CloseUp);
            //        dtp.TextChanged += new EventHandler(dtp_OnTextChangeSanciones);
            //        dtp.LostFocus += new EventHandler(dtp_CloseUp);

            //        if (dgvSanciones.CurrentCell.OwningColumn.Name == "colFechaHasta" && dgvSanciones.Rows[e.RowIndex].Cells["colFechaHasta"].Value.ToString() != string.Empty)
            //            dtp.Value = DateTime.Parse(dgvSanciones.Rows[e.RowIndex].Cells["colFechaHasta"].Value.ToString());

            //        dtp.Visible = true;

            //    }
                
            //}

            //btnGuardar.Enabled = true;
            //btnGuardarSalir.Enabled = true;
        }

        private void dgvProtocolos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (e.RowIndex != -1)
            {
                if ((dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaApertura" ||
                dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaCierre"))
                {
                    dtp = new DateTimePicker();
                    dgvProtocolos.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvProtocolos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChangeProt);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaApertura" && dgvProtocolos.Rows[e.RowIndex].Cells["colFechaApertura"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvProtocolos.Rows[e.RowIndex].Cells["colFechaApertura"].Value.ToString());

                    if (dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaCierre" && dgvProtocolos.Rows[e.RowIndex].Cells["colFechaCierre"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvProtocolos.Rows[e.RowIndex].Cells["colFechaCierre"].Value.ToString());

                    dtp.Visible = true;
                }
            }
            
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void btnEliminaInforme_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_BORRAR))
            {
                if (dgvInformes.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES where NumeroColegiado='"
                        + txtNumColegiado.Valor +
                        "' and CodigoEstablecimiento='" +
                        dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "' AND " +
                        "Id=" + dgvInformes.CurrentCell.OwningRow.Cells["colIdInforme"].Value.ToString();

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvInformes.Rows.Remove(dgvInformes.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void dgvEstablecimientos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colCodigoEstablecimiento" || dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colNombreEstablecimiento"/*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
            {
                listaEstablecimientos();
            }
            if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colCategoria" /*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
            {
                listaCategorias();
            }
            if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colCobradorRegencia" )
            {
                listaCobradores("establecimiento");
            }
        }

        private void listaCategorias()
        {
            //bool ok = true;
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoCategoria as Categoría,NombreCategoria as Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
            listP.ORDERBY = "order by CodigoCategoria";
            listP.FILTRO = "where NumRegistroEstablecimiento = '" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value + "'";
            listP.TITULO_LISTADO = "Categorias";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();

            if (f1Colegiado.item != null)
            {

                dgvEstablecimientos.CurrentCell.Value = f1Colegiado.item.SubItems[1].Text;
                dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoCategoria"].Value = f1Colegiado.item.SubItems[0].Text;
                dgvEstablecimientos.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }


        }

        private void listaEstablecimientos()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "NumRegistro as Código,Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_ESTABLECIMIENTOS";
            listP.ORDERBY = "order by NumRegistro";
            listP.TITULO_LISTADO = "Establecimientos";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                //foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
                //{
                //    if (row.Cells["colCodigoEstablecimiento"].Value.ToString() == f1Colegiado.item.SubItems[0].Text)
                //    {
                //        MessageBox.Show("Este establecimiento ya fue agregado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        dgvEstablecimientos.EndEdit();
                //        return;
                //    }
                //}
                dgvEstablecimientos.CurrentCell.Value = f1Colegiado.item.SubItems[0].Text;
                dgvEstablecimientos.CurrentCell.OwningRow.Cells["colNombreEstablecimiento"].Value = f1Colegiado.item.SubItems[1].Text;
                dgvEstablecimientos.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void listaRegencias()
        {
            Listado listP = new Listado();
            //listP.COLUMNAS = "NumRegistro as Código,Nombre";
            listP.COLUMNAS = "t1.CodigoEstablecimiento,(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = t1.CodigoEstablecimiento) as Establecimiento,t1.CodigoCategoria,(select NombreCategoria from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS where CodigoCategoria = t1.CodigoCategoria) as Categoria,t1.Estado";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_REGENTES_ESTABLECIMIENTOS t1";
            listP.ORDERBY = "order by t1.CodigoEstablecimiento";
            listP.FILTRO = "where t1.NumeroColegiado = '"+ txtNumColegiado.Valor +"'";
            listP.TITULO_LISTADO = "Regencias";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                txtNumRegistroSancion.Valor = f1Colegiado.item.SubItems[0].Text;
                txtNumRegistroSancionDesc.Valor = f1Colegiado.item.SubItems[1].Text;
                txtCategoriaSancion.Valor = f1Colegiado.item.SubItems[2].Text;
                txtCategoriaSancionDesc.Valor = f1Colegiado.item.SubItems[3].Text;
                //dgvSanciones.CurrentCell.OwningRow.Cells["colCodigoEstable"].Value = f1Colegiado.item.SubItems[0].Text;
                //dgvSanciones.CurrentCell.OwningRow.Cells["colEstable"].Value = f1Colegiado.item.SubItems[1].Text;
                //dgvSanciones.CurrentCell.OwningRow.Cells["colCodigoCategoriaS"].Value = f1Colegiado.item.SubItems[2].Text;
                //dgvSanciones.CurrentCell.OwningRow.Cells["colCategoriaS"].Value = f1Colegiado.item.SubItems[3].Text;
                //dgvSanciones.AutoResizeColumns();
                //dgvSanciones.EndEdit();

                //dtColegiadosPendienteCambioSancionado.Rows.Clear();
                //dtColegiadosPendienteCambioSancionado.Rows.Add(
                //    f1Colegiado.item.SubItems[0].Text, f1Colegiado.item.SubItems[2].Text,
                //    dgvSanciones.CurrentCell.OwningRow.Cells["colSesionSancion"].Value.ToString(), 
                //   dgvSanciones.CurrentCell.OwningRow.Cells["colFechaSancion"].Value.ToString()
                //   );
                //CambioEstadoSancionado(f1Colegiado.item.SubItems[0].Text, f1Colegiado.item.SubItems[2].Text, 
                //    dgvSanciones.CurrentCell.OwningRow.Cells["colSesionSancion"].Value.ToString(), 
                //    dgvSanciones.CurrentCell.OwningRow.Cells["colFechaSancion"].Value.ToString());
                //btnGuardar.Enabled = true;
                //btnGuardarSalir.Enabled = true;
            }
        }

        private void OnTipoChanged(object sender, EventArgs e)
        {
            verificarSiRequierePoliza();
        }

        private void btnAjustarCol_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvSanciones.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void verificarSiRequierePoliza()
        {
            DataTable dtTpos = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "RequierePoliza,RequiereVidaSilvestre";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_TIPOS";
            listA.FILTRO = "where Diferenciador = 'R' and CodigoTipo = '" + cmbTipo.Valor + "'";
            //listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dtTpos, ref error))
            {
                if (dtTpos.Rows.Count > 0)
                {
                    if (dtTpos.Rows[0]["RequierePoliza"].ToString() == "S")
                    {
                        habilitarPoliza();
                    }
                    else
                    {
                        deshabilitarPoliza();
                        limpiarPoliza();
                    }

                    if (dtTpos.Rows[0]["RequiereVidaSilvestre"].ToString() == "S")
                    {
                        habilitarSilvestre();
                    }
                    else
                    {
                        deshabilitarSilvestre();
                        limpiarSilvestre();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void verificarEstadoEstablecimiento(string estable, ref bool flat)
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "RequiereRegresoEstado,EsEstadoCierre";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where CodigoEstado = (select Estado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = '" + estable + "')";
            //listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RequiereRegresoEstado"].ToString() == "S" || dt.Rows[0]["EsEstadoCierre"].ToString() == "S")
                        flat = true;
                    else
                        flat = false;
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarPoliza()
        {
            txtNPoliza.Clear();
            txtMonto.Clear();
            dtpFecha.Value = DateTime.Now;
            dtpVencimiento.Value = DateTime.Now;
        }

        private void limpiarSilvestre()
        {
            dgvVidaSilvestre.Rows.Clear();
        }

        private void btnEliminaVisita_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_BORRAR))
            {
                if (dgvVisitasFisc.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC where NumeroColegiado='"
                        + txtNumColegiado.Valor +
                        "' and CodigoEstablecimiento='" +
                        dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "' AND " +
                        "Id=" + dgvVisitasFisc.CurrentCell.OwningRow.Cells["colIdVisitas"].Value.ToString();

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvVisitasFisc.Rows.Remove(dgvVisitasFisc.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_BORRAR))
            {
                if (dgvProtocolos.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_LIB_PROTOCOLOS where NumeroColegiado='"
                        + txtNumColegiado.Valor +
                        "' and Codigo='" +
                        dgvProtocolos.CurrentCell.OwningRow.Cells["colCodigoProtocolo"].Value.ToString() + "'";

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvProtocolos.Rows.Remove(dgvProtocolos.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           
        }

        private void btnBorrarSancion_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_BORRAR))
            {
                if (dgvSanciones.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_SANCIONES where NumeroColegiado='"
                        + txtNumColegiado.Valor +
                        "' and Id='" +
                        dgvSanciones.CurrentCell.OwningRow.Cells["colIdSancion"].Value.ToString() + "'";

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvSanciones.Rows.Remove(dgvSanciones.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////solo permitir numeros y teclas de control
            //if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false; //permitir el caracter
            //}
            //else
            //{
            //    e.Handled = true; //rechazar el caracter
            //}
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvProtocolos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProtocolos.IsCurrentCellDirty)
            {
                dgvProtocolos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvEstablecimientos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEstablecimientos.IsCurrentCellDirty)
            {
                dgvEstablecimientos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvInformes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInformes.IsCurrentCellDirty)
            {
                dgvInformes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvVisitasFisc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVisitasFisc.IsCurrentCellDirty)
            {
                dgvVisitasFisc.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvSanciones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dgvSanciones.IsCurrentCellDirty)
            //{
            //    dgvSanciones.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        private void dgvEstablecimientos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dgvEstablecimientos.Columns["colEstado"].Index) && e.RowIndex != -1)
            {
                DataGridViewCell cell = dgvEstablecimientos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgvEstablecimientos.CurrentCell.ReadOnly)
                    cell.ToolTipText = "Deshabilitado por Estado del Establecimiento";
                else
                    cell.ToolTipText = "";
            }
        }
        
        private void colorearFilas()
        {
            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                if (dgvEstablecimientos.Rows[row.Index].Cells["colEstado"].Value.ToString() == "Inactivo")
                    dgvEstablecimientos.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                else if (dgvEstablecimientos.Rows[row.Index].Cells["colEstado"].Value.ToString() == "Sancionado")
                    dgvEstablecimientos.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                else
                    dgvEstablecimientos.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvEstablecimientos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;
           
            if (dgvCombo != null)
            {
                //
                // se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
                // evitando asi que se ejecuten varias veces el evento
                //
                //dgvCombo.DrawItem -= new DrawItemEventHandler(dvgCombo_DrawItem);

                //dgvCombo.DrawItem += new DrawItemEventHandler(dvgCombo_DrawItem);

                dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);

                dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            }

        }

        private void dvgCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                e.DrawBackground();

                e.Graphics.DrawString(((ComboBox)sender).Items[e.Index].ToString(),
                    ((ComboBox)sender).Font,
                    (listaIndiceComboSancion.Contains(e.Index)) ? Brushes.Black : Brushes.LightGray,
                    e.Bounds);
            }

        }

        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            
            DataGridViewRow row = dgvEstablecimientos.CurrentRow;

            //if (!listaIndiceComboSancion.Contains(combo.SelectedIndex))
            //{
            //    combo.SelectedIndex = -1;
            //    //txtVocalSeleccionada.Text = string.Empty;
            //}
            //else
            //{
            //    //txtVocalSeleccionada.Text = combo.Text;
            //}

            //DataGridViewCheckBoxCell cell = row.Cells["Seleccionado"] as DataGridViewCheckBoxCell;
            //cell.Value = true;

            if (dgvEstablecimientos.Rows.Count > 0 && validarExistencia(txtNumColegiado.Valor, row.Cells["colCodigoEstablecimiento"].Value.ToString(), row.Cells["colCodigoCategoria"].Value.ToString()))
            {
                if (row.Cells["colEstado"].Value != null && row.Cells["colEstado"].Value.ToString() != combo.SelectedItem.ToString())
                {
                    if (MessageBox.Show("¿Desea realizar el cambio de Estado? Al continuar el proceso, se hará una insercion al historial de regencias", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (combo.SelectedItem.Equals("Inactivo"))
                            row.DefaultCellStyle.BackColor = Color.Red;
                        else if (combo.SelectedItem.Equals("Sancionado"))
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        else
                            row.DefaultCellStyle.BackColor = Color.White;

                        //fInternas.insertarHistorialRegencias(txtNumColegiado.Valor, row.Cells["colCodigoEstablecimiento"].Value.ToString(), row.Cells["colCodigoCategoria"].Value.ToString(),
                        //row.Cells["colEstado"].Value.ToString(), row.Cells["colSesionApEst"].Value.ToString(),
                        //row.Cells["colFechaAprobacion"].Value.ToString(), ref error);

                        cargarHistorialRegencias();
                    }
                    else
                    {
                        combo.SelectedItem = row.Cells["colEstado"].Value;
                    }

                }
            }
        }

        private void dgvSanciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgvSanciones.CurrentCell.OwningColumn.Name == "colCodigoEstable" || dgvSanciones.CurrentCell.OwningColumn.Name == "colEstable" || dgvSanciones.CurrentCell.OwningColumn.Name == "colCodigoCategoriaS" || dgvSanciones.CurrentCell.OwningColumn.Name == "colCategoriaS"/*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
            //{
            //    listaRegencias();
            //}
        }

        private void CambioEstadoSancionado(string estable, string categ, string sesionApro, string fechaApro)
        {
            string error = "";
            string estadoSancionado = "Sancionado";
            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                
                if (row.Cells["colCodigoEstablecimiento"].Value.ToString() == estable && row.Cells["colCodigoCategoria"].Value.ToString() == categ)
                {
                    //fInternas.insertarHistorialRegencias(txtNumColegiado.Valor,estable,categ,row.Cells["colEstado"].Value.ToString()[0] + "", estadoSancionado[0]+"",sesionApro,fechaApro, ref error);
                    fInternas.insertarHistorialRegencias(txtNumColegiado.Valor, estable, categ, row.Cells["colEstado"].Value.ToString()[0] + "", sesionApro, fechaApro, ref error);
                    row.Cells["colEstado"].Value = estadoSancionado;
                    cargarHistorialRegencias();
                    colorearFilas();
                }
            }

        }

        private bool validarExistencia(string colegiado, string estable, string categ)
        {
            bool existe = true;
            string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado = '" + colegiado + "' and CodigoEstablecimiento = '"+estable+"' and CodigoCategoria = '"+categ+"'";
            DataTable dtEstablecimientos = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtEstablecimientos, ref error))
            {
                if (dtEstablecimientos.Rows.Count > 0)
                    existe = true;
                else
                    existe = false;
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return existe;
        }

        private void txtNumRegistroSancion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaRegencias();
        }

        private void frmRegentesEdicion_Load(object sender, EventArgs e)
        {
            panel10.Size = new Size(1219, 21);
            panel8.Size = new Size(1219, 21);
            panel11.Size = new Size(1219, 21);
            grbFechas.Location = new Point(442, 45);
            txtMonto.Right();
            dgvHistorialRegencias.Size = new Size(1179, 469);
        }

        private void btnModificarSancion_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REGENCIAS_EDITAR))
            {
                if (dgvSanciones.RowCount > 0)
                {
                    //cargarPuesto(dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colCodigoPuesto"].Value.ToString());
                    txtIdSancion.Valor = dgvSanciones.CurrentCell.OwningRow.Cells["colIdSancion"].Value.ToString();
                    txtNumRegistroSancion.Valor = dgvSanciones.CurrentCell.OwningRow.Cells["colCodigoEstable"].Value.ToString();
                    txtNumRegistroSancionDesc.Valor = dgvSanciones.CurrentCell.OwningRow.Cells["colEstable"].Value.ToString();
                    txtCategoriaSancion.Valor = dgvSanciones.CurrentCell.OwningRow.Cells["colCodigoCategoriaS"].Value.ToString();
                    txtCategoriaSancionDesc.Valor = dgvSanciones.CurrentCell.OwningRow.Cells["colCategoriaS"].Value.ToString();
                    txtSesionSancion.Valor = dgvSanciones.CurrentCell.OwningRow.Cells["colSesionSancion"].Value.ToString();
                    rtbObservacionSancion.Text = dgvSanciones.CurrentCell.OwningRow.Cells["colObservacionesSancion"].Value.ToString();
                    if (!dgvSanciones.CurrentCell.OwningRow.Cells["colFechaHasta"].Value.ToString().Equals(""))
                        dtpFechaHastaSancion.Value = DateTime.Parse(dgvSanciones.CurrentCell.OwningRow.Cells["colFechaHasta"].Value.ToString());

                    if (!dgvSanciones.CurrentCell.OwningRow.Cells["colFechaSancion"].Value.ToString().Equals(""))
                        dtpFechaSesionSancion.Value = DateTime.Parse(dgvSanciones.CurrentCell.OwningRow.Cells["colFechaSancion"].Value.ToString());

                    dgvSanciones.Rows.Remove(dgvSanciones.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private bool validarIngresoSancion(string estable, string categ, ref string id)
        {
            bool result = false;
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_REGENTES_SANCIONES";
            listA.FILTRO = "where NumeroColegiado = '"+txtNumColegiado.Valor+"' and CodigoEstablecimiento = '"+estable+ "' and CodigoCategoria = '" + categ + "' and (FechaHasta is not null and CAST(FechaHasta AS date) >= CAST(GETDATE() AS date))";
  
            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    id = dt.Rows[0]["Id"].ToString();
                    result = true;
                }
                else
                    result = false;
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return result;
        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {
            if (valoresPk.Count == 0)
            {
                MessageBox.Show("Primero debe guardar el registro.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
             dgvVidaSilvestre.Rows.Add("", "", "");
        }

        private void listaSilvestre()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoSilvestre as Código, NombreSilvestre as Nombre , DescripcionSilvestre as Descripción";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_VIDA_SILVESTRE";
            listP.ORDERBY = "order by CodigoSilvestre";
            listP.TITULO_LISTADO = "Vida Silvestre";

            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();

            if (f1Colegiado.item != null)
            {

                dgvVidaSilvestre.CurrentCell.Value = f1Colegiado.item.SubItems[0].Text;
                dgvVidaSilvestre.CurrentCell.OwningRow.Cells["colNombreSilvestre"].Value = f1Colegiado.item.SubItems[1].Text;
                dgvVidaSilvestre.CurrentCell.OwningRow.Cells["colDescripcionSilvestre"].Value = f1Colegiado.item.SubItems[2].Text;
                dgvVidaSilvestre.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }


        private bool InsertarVidaSilvestre(ref string error)
        {

            Listado list = new Listado();
            list.COLUMNAS = "IdColegiado,CodigoSilvestre";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_SILVESTRE";
            bool lbOk = true;
            try
            {
                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SILVESTRE WHERE IdColegiado='" + txtNumColegiado.Valor + "'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvVidaSilvestre.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("IdColegiado");
                        list.COLUMNAS_PK.Add("CodigoSilvestre");
                        parametros.Add(txtNumColegiado.Valor);
                        parametros.Add(row.Cells["colCodigoSilvestre"].Value.ToString());

                        lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;

        }

        private void dgvVidaSilvestre_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvVidaSilvestre_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colCodigoSilvestre")
            {
                listaSilvestre();
            }
        }

        private void btnEliminarCampo_Click(object sender, EventArgs e)
        {
            dgvVidaSilvestre.Rows.Remove(dgvVidaSilvestre.CurrentRow);
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private bool VerificaEstadoRegenciasVrsCategorias(ref string error)
        {
            error = "";
            bool lbOk = true;

            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                if (row.Cells["colEstado"].Value.ToString()[0].ToString()=="A")
                {
                    if (!ExisteCategoriaActiva(row.Cells["colCodigoCategoria"].Value.ToString(), row.Cells["colCodigoEstablecimiento"].Value.ToString()))
                    {
                        if (MessageBox.Show($"La categoria {row.Cells["colCategoria"].Value.ToString()} para el establecimiento {row.Cells["colCodigoEstablecimiento"].Value.ToString()} {row.Cells["colNombreEstablecimiento"].Value.ToString()} se encuentra INACTIVA.¿Desea activar el Estado de la Categoría para el establecimiento?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            lbOk = ActivaCategoriaRegenciaEstablecimento(row.Cells["colCodigoEstablecimiento"].Value.ToString(), 
                                                                         row.Cells["colCodigoCategoria"].Value.ToString(), 
                                                                         row.Cells["colCategoria"].Value.ToString(),
                                                                         ref error);
                        }
                        else
                        {
                            error = $"Mientras la categoria  {row.Cells["colCategoria"].Value.ToString()} se encuentre INACTIVA no se podrá realizar el cambio de estado para el establecimiento {row.Cells["colCodigoEstablecimiento"].Value.ToString()} {row.Cells["colNombreEstablecimiento"].Value.ToString()}.";
                            lbOk = false;
                            return lbOk;
                        }
                            
                        
                    }
                }                
            }
            return lbOk;
        }

        private bool ExisteCategoriaActiva(string categoria, string establecimiento)
        {
            DataTable dtCatEst = new DataTable();
            string sSelectCl = $"select * from {Consultas.sqlCon.COMPAÑIA}.NV_ESTABLECIMIENTOS_CATEGORIAS where CodigoCategoria = '{categoria}' and NumRegistroEstablecimiento='{establecimiento}' and Estado='A'";

            var lbOk = Consultas.fillDataTable(sSelectCl, ref dtCatEst, ref error);

            if (lbOk && dtCatEst.Rows.Count > 0)
                return true;

            return false;
        }

        private bool ActivaCategoriaRegenciaEstablecimento(string establecimiento, string categoria, string nombreCategoria, ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumRegistroEstablecimiento,CodigoCategoria,NombreCategoria,Estado";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
            bool lbOk = true;
            try
            {
                parametros.Clear();
                list.COLUMNAS_PK.Clear();
                list.COLUMNAS_PK.Add("NumRegistroEstablecimiento");
                list.COLUMNAS_PK.Add("CodigoCategoria");
                parametros.Add(establecimiento);
                parametros.Add(categoria);
                parametros.Add(nombreCategoria);
                parametros.Add("A");
                parametros.Add(establecimiento);
                list.FILTRO = " WHERE NumRegistroEstablecimiento='" + establecimiento + "' AND CodigoCategoria='" + categoria + "'";

                lbOk = Consultas.actualizar(parametros, list, identificadorFormulario, ref error);
                    
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }
    }
}
