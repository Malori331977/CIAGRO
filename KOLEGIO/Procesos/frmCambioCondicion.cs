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
    public partial class frmCambioCondicion : Form
    {
        private string error = "";
        private string identificadorF1Ini = "CondicionInicio";
        private string identificadorF1Fin = "CondicionFin";
        private int totalRegistros = 0;
        private int marcados = 0;
        private string idCole = "";
        private bool desdeColegiado = false;
        private bool esSesionIncorporacion = false, requiereRegresoCondicion = false;
        private bool RequiereLevantamiento = false;
        private string CondicionLevantamiento = "";
        private DataTable dtArtLevantamiento = new DataTable();
        private DataTable dtDatosRefrescar = new DataTable();
        private DataTable dtRefrescar = new DataTable();
        private FuncsInternas fInternas;
        private BindingSource source1 = new BindingSource();

        public frmCambioCondicion()
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            dgvColegiados.Columns.Clear();
            dtRefrescar.Columns.Add("Aplicar", typeof(Boolean));
            dtRefrescar.Columns.Add("Id Colegiado", typeof(String));
            dtRefrescar.Columns.Add("Nº Colegiado", typeof(String));
            dtRefrescar.Columns.Add("Nombre", typeof(String));
            dtRefrescar.Columns.Add("Estado", typeof(Image));
            dtRefrescar.Columns.Add("Observaciones", typeof(String));
        }

        public frmCambioCondicion(string IdColegiado, string condicionActual)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            desdeColegiado = true;
            idCole = IdColegiado;
            dgvColegiados.Columns.Clear();
            dtRefrescar.Columns.Add("Aplicar", typeof(Boolean));
            dtRefrescar.Columns.Add("Id Colegiado", typeof(String));
            dtRefrescar.Columns.Add("Nº Colegiado", typeof(String));
            dtRefrescar.Columns.Add("Nombre", typeof(String));
            dtRefrescar.Columns.Add("Estado", typeof(Image));
            dtRefrescar.Columns.Add("Observaciones", typeof(String));
            cargarDatosColegiados(IdColegiado,condicionActual);
            verificarConfigurablesCondicion(true);
            
        }

        private void cargarDatosColegiados(string colegiado, string condicionActual)
        {
            txtCondicionIni.Text = condicionActual;
            txtCondicionIni.ReadOnly = true;
            buscaCondicion(txtCondicionIni.Text,identificadorF1Ini);
            refrescarDatos(colegiado);
        }

        private void bwProceso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = e.ProgressPercentage;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            dgvColegiados.EndEdit();
            if (dgvColegiados.RowCount > 0)
            {
                marcados = 0;
                foreach (DataGridViewRow row in dgvColegiados.Rows)
                {
                    //if ((bool)row.Cells["colSeleccion"].Value)
                    //{
                    //    marcados += 1;
                    //}
                    if ((bool)row.Cells["Aplicar"].Value)
                    {
                        marcados += 1;
                    }
                }
                //dgvColegiados.EndEdit();
                if (validarDatos())
                {
                    
                    btnSalir.Enabled = false;
                    btnProcesar.Enabled = false;
                    fInternas.deshabilitarOrdenDgv(ref dgvColegiados);
                    CheckForIllegalCrossThreadCalls = false;
                    pbProceso.Minimum = 0;
                    //pbProceso.Maximum = dgvColegiados.RowCount + 1;
                    pbProceso.Maximum = marcados;
                    bwProceso = new BackgroundWorker();

                    // Seteamos al bw que sea de manera Async.
                    bwProceso.DoWork += bwProceso_DoWork;

                    // Seteamos al bw que sea de manera Async.
                    bwProceso.ProgressChanged += bwProceso_ProgressChanged;

                    // Seteamos al bw que sea de manera Async.
                    bwProceso.RunWorkerCompleted += bwProceso_RunWorkerCompleted;

                    // Necesitamos setear esta propiedad para reportar al bw los cambios.
                    bwProceso.WorkerReportsProgress = true;

                    bwProceso.RunWorkerAsync();
                }
            }
            else
                MessageBox.Show("No hay información para procesar.", "Cambio de Condición de Colegiados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            procesoCambioCondicion();
        }

        private void bwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSalir.Enabled = true;
            btnProcesar.Enabled = true;
            fInternas.habilitarOrdenDgv(ref dgvColegiados);
            pbProceso.Value = 0; 
        }

        private void limpiarForm()
        {

        }

        private void verificarConfigurablesCondicion(bool esCondicionIni)
        {
            bool OK = true;
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            //listA.COLUMNAS = "CondicionFallecido,PermitePedConcepto,RequiereLevantamiento";
            listA.COLUMNAS = "CondicionIncorporacion,RequiereRegresoCondicion";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_CONDICIONES";
            if(esCondicionIni)
                listA.FILTRO = "where CodigoCondicion = '" + txtCondicionIni.Text + "'";
            else
                listA.FILTRO = "where CodigoCondicion = '" + txtCondicionFin.Text + "'";
            //listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    if (esCondicionIni)
                    {
                        if (dt.Rows[0]["CondicionIncorporacion"].ToString() == "S")
                            esSesionIncorporacion = true;
                        else
                            esSesionIncorporacion = false;
                    }

                    if (!esCondicionIni)
                    {
                        if (dt.Rows[0]["RequiereRegresoCondicion"].ToString() == "S")
                        {
                            lblRegresoCondicion.Visible = true;
                            dtpRegresoCondicion.Visible = true;
                            requiereRegresoCondicion = true;
                        }
                        else
                        {
                            lblRegresoCondicion.Visible = false;
                            dtpRegresoCondicion.Visible = false;
                            requiereRegresoCondicion = false;
                        }
                    }
                    
                    //if (dt.Rows[0]["CondicionFallecido"].ToString() == "S")
                    //{

                    //}
                    //else
                    //{

                    //}

                    //if (dt.Rows[0]["PermitePedConcepto"].ToString() == "S")
                    //{

                    //}
                    //else
                    //{

                    //}

                    //if (dt.Rows[0]["RequiereLevantamiento"].ToString() == "S")
                    //{
                    //    RequiereLevantamiento = true;
                    //    string sQuery = "select t1.CodigoArticulo AS ARTICULO, t2.DESCRIPCION as DESCRIPCION, t3.PRECIO as PRECIO, '1' AS CANTIDAD" +
                    //                    " from "+Consultas.sqlCon.COMPAÑIA+".NV_CONDICIONES_LEVANTAMIENTO_ART t1"+
                    //                    " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t2 on t2.ARTICULO = t1.CodigoArticulo" +
                    //                    " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t3 on t3.ARTICULO = t1.CodigoArticulo" +
                    //                    " where t1.CodigoCondicion = '"+txtCondicionIni.Text+"'";

                    //    OK = Consultas.fillDataTable(sQuery, ref dtArtLevantamiento,ref error);

                    //    if (OK)
                    //    {
                    //        DataTable dtCondiLev = new DataTable();

                    //        string sQueryCondicion = "select CondicionLevantamiento FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES" +
                    //                        " where CodigoCondicion = '" + txtCondicionIni.Text + "'";
                    //        OK = Consultas.fillDataTable(sQueryCondicion, ref dtCondiLev, ref error);

                    //        if(dtCondiLev.Rows.Count > 0)
                    //        {
                    //            CondicionLevantamiento = dtCondiLev.Rows[0]["CondicionLevantamiento"].ToString();
                    //            txtCondicionFin.Text = CondicionLevantamiento;
                    //            txtCondicionFin.ReadOnly = true;
                    //            buscaCondicion(txtCondicionFin.Text, identificadorF1Fin);
                    //        }
                    //    }

                    //    if(!OK)
                    //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                    //else
                    //{
                    //    RequiereLevantamiento = false;
                    //    CondicionLevantamiento = "";
                    //    if (txtCondicionFin.ReadOnly)
                    //    {
                    //        txtCondicionFin.ReadOnly = false;
                    //        txtCondicionFin.Clear();
                    //        txtDescCondicionFin.Clear();
                    //    }

                    //    dtArtLevantamiento = new DataTable();
                    //}
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool obtenerCobrador(string colegiado, ref string cobrador, ref string error)
        {
            bool OK = true;
            string queryCobrador = "SELECT Cobrador FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado = '" + colegiado + "'";

            DataTable dtCobrador = new DataTable();

            OK = Consultas.fillDataTable(queryCobrador, ref dtCobrador, ref error);

            if (OK)
            {
                if (dtCobrador.Rows.Count > 0)
                {
                    cobrador = dtCobrador.Rows[0]["Cobrador"].ToString();
                }
            }
            return OK;
        }

        private bool calculoArticulo(ref DataTable dtArt,string colegiado, ref string error)
        {
            bool OK = true;
            DateTime fechaAprobacion = DateTime.Now;
            DateTime fechaActual = DateTime.Now;
            //string query = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '"+txtCondicionIni.Text+"'";

            string query = "select  FechaAprobacion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '" + txtCondicionIni.Text + "' and FechaAprobacion = (select MAX(FechaAprobacion) from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '" + txtCondicionIni.Text + "')";

            DataTable dt = new DataTable();

            OK = Consultas.fillDataTable(query, ref dt, ref error);

            if (OK)
            {
                if (dt.Rows.Count > 0)
                {
                    fechaAprobacion = DateTime.Parse(dt.Rows[0]["FechaAprobacion"].ToString());
                }
                else
                {
                    error = "No hay registro del cambio de condición";
                    OK = false;
                }
            }



            string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART where CodigoCondicion = '" + txtCondicionIni.Text + "' and ArticuloFms = 'S'";

            DataTable dtArticuloFms = new DataTable();

            if (OK)
            {
                OK = Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error);

                if (dtArticuloFms.Rows.Count > 0)
                {
                    foreach (DataRow row in dtArt.Rows)
                    {
                        if (dtArticuloFms.Rows[0][0].ToString() == row["ARTICULO"].ToString())
                        {
                            int meses = fInternas.GetMonthDifference(fechaAprobacion, fechaActual, ref error);
                            row["CANTIDAD"] = meses;
                        }
                    }
                }
                else
                {
                    error = "Debe especificar el articulo FMS para esta condicion en los configurables";
                    OK = false;
                }
            }


            return OK;
        }

        private bool activarUsuarioERP(string colegiado,ref string error)
        {
            bool OK = true;
            DataTable dt = new DataTable();
            List<string> parametros = new List<string>();

            string sQuery = "SELECT ACTIVO FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE = '" + colegiado + "'";

            try
            {
                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ACTIVO"].ToString() != "S")
                        {
                            string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE set ACTIVO = @ACTIVO" +
                                 " WHERE CLIENTE = @CLIENTE";
                            parametros.Add("@ACTIVO,S");
                            parametros.Add("@CLIENTE," + colegiado);


                            OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);
                        }
                    }
                    else
                    {
                        error = "No se encontraro el cliente en el ERP.";
                        OK = false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "[activarUsuarioERP] Ocurrió un error al obtener registros para actualizar cobrador:\n" + ex.Message;
                OK = false;
            }

            return OK;
        }

        private bool desactivarUsuarioERP(string colegiado, ref string error)
        {
            bool OK = true;
            DataTable dt = new DataTable();
            List<string> parametros = new List<string>();

            string sQuery = "SELECT ACTIVO FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE = '" + colegiado + "'";

            try
            {
                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ACTIVO"].ToString() != "N")
                        {
                            string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE set ACTIVO = @ACTIVO" +
                                 " WHERE CLIENTE = @CLIENTE";
                            parametros.Add("@ACTIVO,N");
                            parametros.Add("@CLIENTE," + colegiado);


                            OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);
                        }
                    }
                    else
                    {
                        error = "No se encontraro el cliente en el ERP.";
                        OK = false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = "[desactivarUsuarioERP] Ocurrió un error al obtener registros para actualizar cobrador:\n" + ex.Message;
                OK = false;
            }

            return OK;
        }

        private void procesoCambioCondicion()
        {
            string error = "";
            //string queryArt = "";
            int progreso = 0;
            //string cobrador = "";
            //string pedido = "";
            //decimal montoDesc = 0, porcDescuento = 0;
            //int indiceArticulo = 0;
            DataTable dtArticulos = new DataTable();


            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                    bool OK = true;
                int d = dgvColegiados.Rows.Count;
                if ((bool)row.Cells["Aplicar"].Value)
                {
                    try
                    {
                        Consultas.sqlCon.iniciaTransaccion();

                        //if (RequiereLevantamiento)
                        //{

                        //    //if (Consultas.fillDataTable(queryArt, ref dtArticulos, ref error))
                        //    //{

                        //    OK = obtenerCobrador(row.Cells["Id Colegiado"].Value.ToString(), ref cobrador, ref error);

                        //    if (OK)
                        //    {
                        //        OK = calculoArticulo(ref dtArtLevantamiento, row.Cells["Id Colegiado"].Value.ToString(), ref error);
                        //    }

                        //    if (OK)
                        //    {
                        //        //OK = controlerBD.crearPedidoCambioCondicion(dtArtLevantamiento, row.Cells["Id Colegiado"].Value.ToString(), cobrador, txtDescCondicionIni.Text, txtDescCondicionFin.Text, ref error);
                        //        OK = controlerBD.crearPedidoGenerico(dtArtLevantamiento, row.Cells["Id Colegiado"].Value.ToString(),ref pedido,montoDesc,porcDescuento,false,indiceArticulo,cobrador,"ADEL","PEDIDOS", "Levantamiento Condición-KOLEGIO "+txtDescCondicionIni.Text+"->"+txtDescCondicionFin.Text+"","",  ref error);
                        //    }

                        //    //}

                        //}


                        //string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION (IdColegiado,CondicionPrevia,CondicionActual,SesionAprobacion,FechaAprobacion) " +
                        //    "VALUES ('" + row.Cells["Id Colegiado"].Value.ToString()/*row.Cells["colIdColegiado"].Value.ToString()*/ + "','" + txtCondicionIni.Text + "','" + txtCondicionFin.Text + "','" + txtSesionApro.Text + "','" + dtpFechaApro.Value.ToString("yyyy-MM-ddTHH:mm:ss") + "')";

                        //if (OK)
                        //    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                        if (OK)
                            OK = insertarEnHistorialCondicion(row.Cells["Id Colegiado"].Value.ToString(), ref error);

                        if (OK)
                            OK = cambioCondicion(row.Cells["Id Colegiado"].Value.ToString()/*row.Cells["colIdColegiado"].Value.ToString()*/, txtCondicionFin.Text, dtpRegresoCondicion.Value.Date, ref error);

                        //if (OK)
                        //    OK = fInternas.actualizarMachotesColegiados(row.Cells["Id Colegiado"].Value.ToString()/*row.Cells["colIdColegiado"].Value.ToString()*/, txtCondicionFin.Text, ref error);

                        if (OK && (txtCondicionIni.Text.Equals("C-10") || txtCondicionIni.Text.Equals("C-11") || txtCondicionIni.Text.Equals("C-08")) && txtCondicionFin.Text.Equals("C-01"))
                            OK = activarUsuarioERP(row.Cells["Id Colegiado"].Value.ToString(), ref error);
                        else if (OK && (txtCondicionFin.Text.Equals("C-10") || txtCondicionFin.Text.Equals("C-11") || txtCondicionFin.Text.Equals("C-08")))
                            OK = desactivarUsuarioERP(row.Cells["Id Colegiado"].Value.ToString(), ref error);

                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            //row.Cells["colResultado"].Value = iList.Images[2];
                            //row.Cells["colObservaciones"].Value = "¡Cambio Exitoso!";
                            row.Cells["Estado"].Value = iList.Images[2];
                            row.Cells["Observaciones"].Value = "¡Cambio de Condición Exitoso!";
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            //row.Cells["colResultado"].Value = iList.Images[1];
                            //row.Cells["colObservaciones"].Value = error;
                            row.Cells["Estado"].Value = iList.Images[1];
                            row.Cells["Observaciones"].Value = error;
                        }

                    }
                    catch (Exception ex)
                    {
                        Consultas.sqlCon.Rollback();
                        //row.Cells["colResultado"].Value = iList.Images[1];
                        //row.Cells["colObservaciones"].Value = ex.Message;
                        row.Cells["Estado"].Value = iList.Images[1];
                        row.Cells["Observaciones"].Value = ex.Message;
                    }
                progreso += 1;
                bwProceso.ReportProgress(progreso);
                }
                     
            }

        }

        private bool cambioCondicion(string idColegiado, string condicion, DateTime regresoCondicion, ref string error)
        {
            string strSQL = "", queryRegreso = "";

            if (requiereRegresoCondicion)
                queryRegreso = ", FechaRegresoCondicion = '" + regresoCondicion.ToString("yyyy-MM-ddTHH:mm:ss") + "' ";
            else
                queryRegreso = "";

            if (esSesionIncorporacion)
                strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Condicion = '" + condicion + "' " + queryRegreso + " , FechaIngreso = '" + dtpFechaApro.Value.ToString("yyyy-MM-ddTHH:mm:ss") + "', SesionIngreso = '" + txtSesionApro.Text + "' where IdColegiado='" + idColegiado + "'";
            else
                strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Condicion = '" + condicion + "' " + queryRegreso + " where IdColegiado='" + idColegiado + "'";

            return Consultas.ejecutarSentencia(strSQL, ref error);
             
        }

        private bool insertarEnHistorialCondicion(string colegiado, ref string error)
        {


            List<string> parametros = new List<string>();
            Listado list = new Listado();
            list.COLUMNAS = "IdColegiado,CondicionPrevia,CondicionActual,SesionAprobacion,FechaAprobacion";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_CAMBIO_CONDICION";
            bool lbOk = true;
            try
            {

                parametros.Clear();
                list.COLUMNAS_PK.Clear();
                //list.COLUMNAS_PK.Add("Id");
                list.COLUMNAS_PK.Add("IdColegiado");
                //parametros.Add(row.Cells["colId"].Value.ToString());
                parametros.Add(colegiado);
                parametros.Add(txtCondicionIni.Text);
                parametros.Add(txtCondicionFin.Text);
                parametros.Add(txtSesionApro.Text);
                parametros.Add(dtpFechaApro.Value.ToString("yyyy-MM-ddTHH:mm:ss"));


                lbOk = Consultas.insertar(parametros, list, Constantes.ID_BIT_CAMBIO_CONDICION, ref error);

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        //private bool cambioCondicionDetalle(string idColegiado, string condicion, ref string error)
        //{
        //    bool OK = true;

        //    OK = EliminarDetalle(idColegiado, ref error);

        //    if (OK)
        //        OK = InsertarDetalle(idColegiado, condicion, ref error);

        //    return OK;

        //}

        //private bool EliminarDetalle(string idColegiado, ref string error)
        //{
        //    string sQuery = "DELETE "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado = '"+ idColegiado + "'";

        //    return Consultas.ejecutarSentencia(sQuery, ref error); 
        //}

        //private bool InsertarDetalle(string idColegiado, string condicion, ref string error)
        //{
        //    bool OK = true;
        //    DataTable dt = new DataTable();
        //    DataTable dtCambioCondicion = new DataTable();
        //    string sSelect = "select t2.CodigoArticulo, t1.CodigoPlantilla, t3.CodigoFrecuencia,t5.PRECIO as Precio from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1"+
        //                     " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t2 on t2.CodigoPlantilla = t1.CodigoPlantilla" +
        //                     " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 on t3.CodigoPlantilla = t1.CodigoPlantilla" +
        //                     " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t2.CodigoArticulo" +
        //                     " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t2.CodigoArticulo" +
        //                     " where t1.CodigoCondicion = '" + condicion + "'";

        //    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

        //    if (OK)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Monto,CodigoFrecuencia) " +
        //            "VALUES ('" + idColegiado + "','" + condicion + "','"+ row["CodigoArticulo"].ToString() + "','" + row["CodigoPlantilla"].ToString() + "','" + row["Precio"].ToString() + "','" + row["CodigoFrecuencia"].ToString() + "')";

        //            OK = Consultas.ejecutarSentencia(sQuery, ref error);

        //            if (!OK)
        //                break;
        //        }
        //    }

        //    return OK;

        //}

        private bool validarDatos()
        {
            string error = "";
            bool OK = true;
            if (marcados == 0)
            {
                error = "Debe marcar los registros que proceden al cambio de condición o marcar la casilla de masivo";
                chkMasivo.Focus();
                OK = false;
            }

            if (!txtFiltro.Text.Equals(""))
            {
                error = "Debe borrar el filtro para procesar";
                txtFiltro.Focus();
                OK = false;
            }

            if (txtCondicionIni.Text.Trim() == "" && !txtCondicionIni.ReadOnly)
            {
                error = "Debe digitar la condición inicial.";
                txtCondicionIni.Focus();
                OK = false;
            }

            if (txtCondicionFin.Text.Trim() == "")
            {
                error = "Debe digitar la condición final.";
                txtCondicionFin.Focus();
                OK = false;
            }

            if (txtSesionApro.Text.Trim() == "")
            {
                error = "Debe digitar la sesion de aprobación.";
                txtSesionApro.Focus();
                OK = false;
            }
            if (txtCondicionFin.Text == txtCondicionIni.Text)
            {
                error = "La condición incial y la condición final deben ser diferentes";
                txtCondicionFin.Focus();
                OK = false;
            }

            if (dtpRegresoCondicion.Visible)
            {
                if (dtpRegresoCondicion.Value.Date == DateTime.Now.Date)
                {
                    error = "La fecha de regreso debe ser mayor al día actual";
                    dtpRegresoCondicion.Focus();
                    OK = false;
                }
            }

            if (!OK)
            {
                MessageBox.Show(error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return OK;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if(!desdeColegiado)
                refrescarDatos();
            else
                refrescarDatos(idCole);
        }

        private void refrescarDatos()
        {
            
            string sQuery = "SELECT IdColegiado,NumeroColegiado,Nombre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE Condicion='" + txtCondicionIni.Text + "'";
            //dtDatosRefrescar = new DataTable();
            //dtRefrescar = new DataTable();
            string error = "";
            try
            {
                dtDatosRefrescar.Rows.Clear();

                if (Consultas.fillDataTable(sQuery, ref dtDatosRefrescar, ref error))
                {
                    //dgvColegiados.DataSource = dtIngresos;
                    
                    //dgvColegiados.Rows.Clear();
                    //dgvColegiados.Columns.Clear();
                    dtRefrescar.Rows.Clear();
                    
                    totalRegistros = 0;

                    
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataRow row in dtDatosRefrescar.Rows)
                    {
                        totalRegistros += 1;
                        dtRefrescar.Rows.Add(false, row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                            row["Nombre"].ToString(), iList.Images[0], "");
                        //dgvColegiados.Rows.Add(false,row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                        //    row["Nombre"].ToString(), iList.Images[0], "");
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
                    Cursor.Current = Cursors.Default;

                    
                    DataView view = new DataView(dtRefrescar);
                    source1.DataSource = view;
                    dgvColegiados.DataSource = view;
                    dgvColegiados.AutoResizeColumns();
                    dgvColegiados.Refresh();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refrescarDatos(string idColegiado)
        {

            string sQuery = "SELECT NumeroColegiado,Nombre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado = '"+idColegiado+"'";

            string error = "";
            try
            {
                dtDatosRefrescar.Rows.Clear();

                if (Consultas.fillDataTable(sQuery, ref dtDatosRefrescar, ref error))
                {
                    //dgvColegiados.DataSource = dtIngresos;

                    //dgvColegiados.Rows.Clear();
                    //dgvColegiados.Columns.Clear();
                    dtRefrescar.Rows.Clear();

                    totalRegistros = 0;


                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataRow row in dtDatosRefrescar.Rows)
                    {
                        totalRegistros += 1;
                        dtRefrescar.Rows.Add(false, idColegiado, row["NumeroColegiado"].ToString(),
                            row["Nombre"].ToString(), iList.Images[0], "");
                        //dgvColegiados.Rows.Add(false,row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                        //    row["Nombre"].ToString(), iList.Images[0], "");
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
                    
                    DataView view = new DataView(dtRefrescar);
                    source1.DataSource = view;
                    dgvColegiados.DataSource = view;
                    dgvColegiados.AutoResizeColumns();
                    dgvColegiados.Refresh();
                    chkMasivo.Checked = false;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvColegiados.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void txtCondicionIni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondicionIni.ReadOnly)
            {
                listaCondiciones(identificadorF1Ini);
            }
        }

        private void listaCondiciones(string IdentificadorF1)
        {
            Listado listD = new Listado();
            listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición,CodigoPlantilla";
            // listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición";
            listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listD.TABLA = "NV_CONDICIONES";
            listD.TITULO_LISTADO = "Condiciones Colegiado";
            listD.COLUMNAS_OCULTAS.Add("CodigoPlantilla");

            frmF1 f1 = new frmF1(listD);
            f1.ShowDialog();
            if (f1.item != null)
            {
               
                    
                if (IdentificadorF1 == identificadorF1Ini)
                {
                    txtCondicionIni.Text = f1.item.SubItems[0].Text;
                    txtDescCondicionIni.Text = f1.item.SubItems[1].Text;
                    refrescarDatos();
                    verificarConfigurablesCondicion(true);
                }

                if (IdentificadorF1 == identificadorF1Fin)
                {
                    txtCondicionFin.Text = f1.item.SubItems[0].Text;
                    txtDescCondicionFin.Text = f1.item.SubItems[1].Text;
                    verificarConfigurablesCondicion(false);
                    //refrescarDatos();
                }
                    
                   
                
            }
        }

        private void buscaCondicion(string condicion, string IdentificadorF1)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_CONDICIONES";
            listA.FILTRO = "where CodigoCondicion = '" + condicion + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    //txtCondicionIni.Valor = dtTTs.Rows[0]["CodigoCondicion"].ToString();
                    //txtDescCondicion.Valor = dtTTs.Rows[0]["NombreCondicion"].ToString();
                    //plantilla = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
                    //cargarPlantilla();
                    if (IdentificadorF1 == identificadorF1Ini)
                    {
                        txtCondicionIni.Text = dtTTs.Rows[0]["CodigoCondicion"].ToString();
                        txtDescCondicionIni.Text = dtTTs.Rows[0]["NombreCondicion"].ToString();
                        //refrescarDatos();
                    }

                    if (IdentificadorF1 == identificadorF1Fin)
                    {
                        txtCondicionFin.Text = dtTTs.Rows[0]["CodigoCondicion"].ToString();
                        txtDescCondicionFin.Text = dtTTs.Rows[0]["NombreCondicion"].ToString();
                        //refrescarDatos();
                    }
                }
                
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiar()
        {
            if (dgvColegiados.Rows.Count > 0)
            {
                dgvColegiados.Rows.Clear();
            }

        }

        private void txtCondicionIni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondicionIni.ReadOnly)
            {
                listaCondiciones(identificadorF1Ini);
            }
        }

        private void txtCondicionFin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondicionFin.ReadOnly)
            {
                listaCondiciones(identificadorF1Fin);
            }
        }

        private void txtCondicionFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondicionFin.ReadOnly)
            {
                listaCondiciones(identificadorF1Fin);
            }
        }
        
        private void chkMasivo_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkMasivo.Checked)
            {
                activarMasivo();
            }
            else
            {
                desactivarMasivo();
            }
             
        }

        private void activarMasivo()
        {
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                //row.Cells["colSeleccion"].Value = true;
                row.Cells["Aplicar"].Value = true;
                //row.Cells["colSeleccion"].ReadOnly = true;
            }
            dgvColegiados.EndEdit();
            //chkMasivo.Checked = true;
        }

        private void desactivarMasivo()
        {
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                //row.Cells["colSeleccion"].Value = false;
                row.Cells["Aplicar"].Value = false;
                //row.Cells["colSeleccion"].ReadOnly = false;
            }
            dgvColegiados.EndEdit();

            //chkMasivo.Checked = false;
        }

        private void frmCambioCondicion_Load(object sender, EventArgs e)
        {
            dtpFechaApro.Value = DateTime.Now;
            
        }

        private void dgvColegiados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //bool masivo = true;
            //if (dgvColegiados.CurrentCell.OwningColumn.Name == "colSeleccion")
            //{
            //    if ((bool)dgvColegiados.Rows[e.RowIndex].Cells["colSeleccion"].Value == false)
            //    {
            //        dgvColegiados.Rows[e.RowIndex].Cells["colSeleccion"].Value = true;
            //    }
            //    else
            //        dgvColegiados.Rows[e.RowIndex].Cells["colSeleccion"].Value = false;

            //    foreach (DataGridViewRow row in dgvColegiados.Rows)
            //    {
            //        if (!(bool)row.Cells["colSeleccion"].Value)
            //        {
            //            masivo = false;
            //        }
            //    }
            //    dgvColegiados.EndEdit();

            //    if(masivo)
            //        chkMasivo.Checked = true;
            //    else
            //        chkMasivo.Checked = false;
            //}
            if (dgvColegiados.Rows.Count > 0)
            {
                bool masivo = true;
                if (dgvColegiados.CurrentCell.OwningColumn.Name == "Aplicar")
                {
                    if (e.RowIndex >= 0)
                    {
                        if ((bool)dgvColegiados.Rows[e.RowIndex].Cells["Aplicar"].Value == false)
                        {
                            dgvColegiados.Rows[e.RowIndex].Cells["Aplicar"].Value = true;
                        }
                        else
                            dgvColegiados.Rows[e.RowIndex].Cells["Aplicar"].Value = false;

                        foreach (DataGridViewRow row in dgvColegiados.Rows)
                        {
                            if (!(bool)row.Cells["Aplicar"].Value)
                            {
                                masivo = false;
                            }
                        }
                        dgvColegiados.EndEdit();

                        if (masivo)
                            chkMasivo.Checked = true;
                        else
                            chkMasivo.Checked = false;
                    }
                }
            }
        }
       
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (!txtCondicionIni.Text.Equals(""))
            {
                if (!txtFiltro.Text.Equals(""))
                {
                    source1.Filter = "[Nº Colegiado] like '%" + txtFiltro.Text + "%' or [Id Colegiado] like '%" + txtFiltro.Text + "%' or [Nombre] like '%" + txtFiltro.Text + "%'";

                }
                else
                {
                    //refrescarDatos();
                }
            }
            else
            {
                MessageBox.Show("No hay información para filtrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFiltro.Clear();
            }
        }
    }
}
