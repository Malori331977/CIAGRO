using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelInterop = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class frmCobrosColegiados : Form
    {
        int totalRegistros = 0;
        int totalRegistrosExitosos = 0;
        int totalRegistrosErroneos = 0;
        private FuncsInternas fInternas;

        public frmCobrosColegiados()
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
        }

        private void bwProceso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = e.ProgressPercentage;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Se esta trabajando en este proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgvColegiados.RowCount > 0)
            {
                limpiarEstadoCeldas();
                btnSalir.Enabled = false;
                btnProcesar.Enabled = false;
                desactivarLabels();
                fInternas.deshabilitarOrdenDgv(ref dgvColegiados);
                CheckForIllegalCrossThreadCalls = false;
                pbProceso.Minimum = 0;
                pbProceso.Maximum = dgvColegiados.RowCount + 1;
                //bwProceso = new BackgroundWorker();

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
            else
                MessageBox.Show("No hay información para procesar.", "Carga Masiva de Pólizas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            generarIngresoColegiado();
        }

        private void bwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSalir.Enabled = true;
            btnProcesar.Enabled = true;
            fInternas.habilitarOrdenDgv(ref dgvColegiados);
            activarLabels();
        }

        private void activarLabels()
        {
            lblErrores.Visible = true;
            lblExitosos.Visible = true;
            lblErroresCant.Visible = true;
            lblExitososCant.Visible = true;
            lblErroresCant.Text = totalRegistrosErroneos.ToString();
            lblExitososCant.Text = totalRegistrosExitosos.ToString();
        }

        private void desactivarLabels()
        {
            bwProceso = new BackgroundWorker();
            totalRegistrosErroneos = 0;
            totalRegistrosExitosos = 0;
            lblErrores.Visible = false;
            lblExitosos.Visible = false;
            lblErroresCant.Visible = false;
            lblExitososCant.Visible = false;
            lblErroresCant.Text = "0";
            lblExitososCant.Text = "0";
        }
        

        private void limpiarEstadoCeldas()
        {
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                row.Cells["colResultado"].Value = iList.Images[0];
                row.Cells["colObservaciones"].Value = "";
            }
        }

        private void generarIngresoColegiado()
        {
            string error = "";
            int progreso = 1;
            bwProceso.ReportProgress(progreso);

            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                bool OK = true;
                //string referenciaCobro = "colegiatura";
                DataTable dtCliente = new DataTable();

                string sSelect = "";
                string sSelectCl = "";
                DataTable dtAplicaClie = new DataTable();
                DateTime fechaActu = DateTime.Now;
                DateTime fechaDgv = DateTime.Now;
                DateTime mesCobro = DateTime.Now;
                fechaActu = new DateTime(fechaActu.Year, fechaActu.Month, /*DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Day*/ 25);
                if(!row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                    fechaDgv = new DateTime(DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Year, DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Month,  25);
                else
                    fechaDgv = new DateTime(1900, 01, 25);
                //if (row.Cells["colUltimoCobro"].Value.ToString().Equals("") || DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()) < fechaActu)
                if (row.Cells["colUltimoCobro"].Value.ToString().Equals("") || fechaDgv < fechaActu)
                {
                    try
                    {
                        Consultas.sqlCon.iniciaTransaccion();

                        
                        //sSelect = "select AplicaClienteErp from "+ Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = (select distinct CodigoPlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO where NumeroColegiado = '"+ row.Cells["colNumeroColegiado"].Value.ToString() + "') and AplicaClienteErp = 'S'";
                        
                        sSelect = "select t3.AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 on t3.CodigoPlantilla = t2.CodigoPlantilla where t1.IdColegiado = '" + row.Cells["colIdColegiado"].Value.ToString() + "'";
                        OK = Consultas.fillDataTable(sSelect, ref dtAplicaClie, ref error);
                        

                        if (OK)
                        {
                            sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + row.Cells["colIdColegiado"].Value.ToString() + "'";
                            OK = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

                        }

                        if (OK && dtAplicaClie.Rows.Count > 0 && dtCliente.Rows.Count == 0)
                        {

                            OK = fInternas.generarNit(row.Cells["colCedula"].Value.ToString(), row.Cells["colIdColegiado"].Value.ToString(), ref dtCliente, "colegiado", ref error);

                            if (OK)
                                OK = fInternas.generarCliente(row.Cells["colIdColegiado"].Value.ToString(), ref dtCliente, "colegiado", "C", ref error);

                        }

                        if(OK)
                            OK = fInternas.verificarAceptaDocElectronicoClienteERP(row.Cells["colIdColegiado"].Value.ToString(), ref error);


                        if (OK)
                        {
                            if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                            {
                                mesCobro = new DateTime(mesCobro.Year, mesCobro.Month, /*mesCobro.Day*/ 25);
                            }
                            else
                            {
                                DateTime ActualizarCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                                mesCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month,/*mesCobro.Day*/ 25).AddMonths(1);
                                //mesUltCobro = mesUltCobro.AddMonths(1);
                            }
                            //mesCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).AddMonths(1);
                            OK = generarPedido(row.Cells["colIdColegiado"].Value.ToString(), dtCliente, row.Cells["colCobradorCole"].Value.ToString(), mesCobro.ToString("MM/yyyy"), ref error);
                        }

                        if (OK)
                            OK = actualizarUltMesCobro(row.Cells["colIdColegiado"].Value.ToString(), mesCobro, ref error);

                        //if (OK && aceptabaDoc)//Se actualiza check a S porque se verifica al inicio si esta chequeado 
                        //    controlerBD.actualizarAceptaDocElectronicoClienteERP(row.Cells["colIdColegiado"].Value.ToString(),"S",ref error);

                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            totalRegistrosExitosos += 1;
                            row.Cells["colResultado"].Value = iList.Images[2];
                            row.Cells["colObservaciones"].Value = "¡Proceso exitoso!";
                            actualizarMesCobro(row.Cells["colIdColegiado"].Value.ToString(), mesCobro.ToString("MM/yyyy"));
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            totalRegistrosErroneos += 1;
                            row.Cells["colResultado"].Value = iList.Images[1];
                            row.Cells["colObservaciones"].Value = error;

                        }

                    }
                    catch (Exception ex)
                    {
                        Consultas.sqlCon.Rollback();
                        row.Cells["colResultado"].Value = iList.Images[1];
                        row.Cells["colObservaciones"].Value = ex.Message;
                    }
                }
                else
                {
                    //Consultas.sqlCon.Rollback();
                    totalRegistrosErroneos += 1;
                    row.Cells["colResultado"].Value = iList.Images[3];
                    row.Cells["colObservaciones"].Value = "Ya se le cobró el mes actual a este colegiado";

                }


                progreso += 1;
                bwProceso.ReportProgress(progreso);
            }
        }

        private bool actualizarUltMesCobro(string colegiado, DateTime ultimoCobro, ref string error)
        {
            bool OK = true;
            string sUpdate = "";
            string sInsert = "";
            string sSelect = "";
            DateTime mesUltCobro = DateTime.Now;
            DataTable dt = new DataTable();
            //if (ultimoCobro.Equals(""))
            //{
            //    mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 1);
            //}
            //else
            //{
            //    mesUltCobro = DateTime.Parse(ultimoCobro);
            //    mesUltCobro = mesUltCobro.AddMonths(1);
            //}

            string mes = "";
            mes = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");

            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + colegiado + "'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count > 0)
            {
                sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "'";

                OK = Consultas.ejecutarSentencia(sUpdate, ref error);
            }
            else
            {
                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS (IdColegiado,MesUltimoCobro) values ('" + colegiado + "', '" + mes + "')";

                OK = Consultas.ejecutarSentencia(sInsert, ref error);
            }

            return OK;
        }

        //private bool generarCliente(string idColegiado,ref DataTable dtCliente,ref string error)
        //{
        //    string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idColegiado + "'";
        //    dtCliente = new DataTable();

        //    if (Consultas.fillDataTable(sQuery, ref dtCliente, ref error))
        //        return controlerBD.crearCliente(dtCliente, ref error);
        //    else
        //        return false;
        //}

        //private bool generarNit(string idColegiado, ref DataTable dtCliente, ref string error)
        //{
        //    string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idColegiado + "'";
        //    dtCliente = new DataTable();

        //    string sQueryNit = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NIT WHERE NIT='" + idColegiado + "'";
        //    DataTable dtNit = new DataTable();

        //    if (Consultas.fillDataTable(sQueryNit, ref dtNit, ref error))
        //    {
        //        if (Consultas.fillDataTable(sQuery, ref dtCliente, ref error))
        //        {
        //            if (dtNit.Rows.Count > 0)
        //            {
        //                if (dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() != dtCliente.Rows[0]["Nombre"].ToString().ToUpper())
        //                {
        //                    return controlerBD.crearNit(dtCliente, ref error);
        //                }
        //                else//Si es igual ya existe y no se crea pero se sigue con la transaccion
        //                {
        //                    error = "Ya existe una razón social '" + dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() + "' asociado al NIT '" + dtNit.Rows[0]["NIT"].ToString() + "'";
        //                    return false;
        //                }
        //            }else
        //                return controlerBD.crearNit(dtCliente, ref error);
        //        }
        //        else
        //            return false;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private bool generarPedido(string idColegiado, DataTable dtCliente, string cobradorCole, string ultimoCobro, ref string error)
        {
            decimal montoDesc = 0;
            int cantidad = 1, porcDescuento = 0, indiceArticulo = 0;
            bool pedidoPorConcepto = false, OK = false;
            DateTime mesUltCobro = DateTime.Now;

            //string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado=(SELECT NumeroColegiado FROM "+Consultas.sqlCon.COMPAÑIA+ ".NV_COLEGIADO where IdColegiado = '" + idColegiado + "') AND CodigoCondicion='I' And Activo='S'";
            //string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado=(SELECT IdColegiado FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where NumeroColegiado = (select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = '" + idColegiado + "') )";
            //string sQuery = "SELECT t1.*, t2.NombreCondicion FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.CodigoCondicion WHERE t1.NumeroColegiado=(SELECT IdColegiado FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = '" + idColegiado + "')";
            //string sQuery = "SELECT t1.CodigoArticulo, t3.DESCRIPCION as descripcion, t4.PRECIO as Monto, t2.NombreCondicion, t1.PedidoPorConcepto FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO t1" +
            //    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.CodigoCondicion" +
            //    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t1.CodigoArticulo" +
            //    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t1.CodigoArticulo" +
            //    " WHERE t1.NumeroColegiado = '" + idColegiado + "'";
            string sQuery = "SELECT t4.ARTICULO as CodigoArticulo, t4.DESCRIPCION as descripcion, t5.PRECIO as Monto, t2.NombreCondicion, 'N' as PedidoPorConcepto FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t3 ON t3.CodigoPlantilla = t2.CodigoPlantilla" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t3.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t3.CodigoArticulo" +
                        " WHERE t1.IdColegiado = '" + idColegiado + "'";//El pedido por concepto va quemado, consultar si es necesario en el proceso de cobros masivos 

            DataTable dtArticulos = new DataTable();



            if (Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
            {
                //foreach (DataRow row in dtArticulos.Rows)
                //{
                //    if (row["PedidoPorConcepto"].ToString() == "S")
                //        pedidoPorConcepto = true;
                //}

                if (ultimoCobro.Equals(""))
                {
                    ultimoCobro = mesUltCobro.ToString("MM/yyyy");
                }
                else
                {
                    ultimoCobro = DateTime.Parse(ultimoCobro).ToString("MM/yyyy");
                }


                //if (pedidoPorConcepto)
                //{
                //    foreach (DataRow row in dtArticulos.Rows)
                //    {
                //        OK = controlerBD.crearPedido(dtArticulos, idColegiado, cantidad, montoDesc, porcDescuento, "cobro", pedidoPorConcepto, indiceArticulo, cobradorCole, ultimoCobro, ref error);
                //        indiceArticulo++;
                //        if (!OK)
                //            return false;
                //    }
                //}
                //else
                    return controlerBD.crearPedido(dtArticulos, idColegiado, cantidad, montoDesc, porcDescuento, "cobro", pedidoPorConcepto, indiceArticulo, cobradorCole, ultimoCobro, ref error);
            }
            else
                return false;

            //return OK;
        }

        private void actualizarMesCobro(string id, string NuevoMesCobro)
        {
           
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                if (id == row.Cells["colIdColegiado"].Value.ToString())
                {
                    row.Cells["colUltimoCobro"].Value = NuevoMesCobro;
                }
            }
                  
            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (!chkGenTotal.Checked)
                refrescarDatos();
            else
                refrescarDatosGeneracionTotal();
        }

        private void refrescarDatos()
        {
            string sQuery = "SELECT t1.IdColegiado,t1.Cedula,t1.NumeroColegiado,t1.Nombre,t2.MesUltimoCobro as UltMesCobro, t1.Cobrador"+ 
                            " FROM "+Consultas.sqlCon.COMPAÑIA+".NV_COLEGIADO t1"+
                            " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS t2 ON t2.IdColegiado = t1.IdColegiado" +
                            " WHERE t1.Condicion = '"+txtCondicion.Text+"'";
            DataTable dtIngresos = new DataTable();
            string error = "";
            try
            {
                
                if (Consultas.fillDataTable(sQuery,ref dtIngresos,ref error))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //dgvColegiados.DataSource = dtIngresos;
                    dgvColegiados.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtIngresos.Rows)
                    {
                        if (row["UltMesCobro"].ToString().Equals(""))
                        {
                            totalRegistros += 1;
                            dgvColegiados.Rows.Add(row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NumeroColegiado"].ToString(),
                                row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
                        }
                        else
                        {
                            DateTime fechaactual = DateTime.Now;
                            DateTime fecha = DateTime.Parse(row["UltMesCobro"].ToString());
                            fechaactual = new DateTime(fechaactual.Year, fechaactual.Month, 1);
                            fecha = new DateTime(fecha.Year, fecha.Month, 1);
                            int result = DateTime.Compare(fecha, fechaactual);
                            if (result < 0)
                            {
                                totalRegistros += 1;
                                dgvColegiados.Rows.Add(row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NumeroColegiado"].ToString(),
                                    row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
                            }
                        }
                        
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
                    Cursor.Current = Cursors.Default;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refrescarDatosGeneracionTotal()
        {
            string sQuery = "SELECT t1.IdColegiado,t1.Cedula,t1.NumeroColegiado,t1.Nombre,t2.MesUltimoCobro as UltMesCobro, t1.Cobrador" +
                            " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
                            " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS t2 ON t2.IdColegiado = t1.IdColegiado"+
                            " WHERE t1.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')";
            DataTable dtIngresos = new DataTable();
            string error = "";
            try
            {
                
                if (Consultas.fillDataTable(sQuery, ref dtIngresos, ref error))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //dgvColegiados.DataSource = dtIngresos;
                    dgvColegiados.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtIngresos.Rows)
                    {
                        if (row["UltMesCobro"].ToString().Equals(""))
                        {
                            totalRegistros += 1;
                            dgvColegiados.Rows.Add(row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NumeroColegiado"].ToString(),
                                row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
                        }
                        else
                        {
                            DateTime fechaactual = DateTime.Now;
                            DateTime fecha = DateTime.Parse(row["UltMesCobro"].ToString());
                            fechaactual = new DateTime(fechaactual.Year, fechaactual.Month, 1);
                            fecha = new DateTime(fecha.Year, fecha.Month, 1);
                            int result = DateTime.Compare(fecha, fechaactual);
                            if (result < 0)
                            {
                                totalRegistros += 1;
                                dgvColegiados.Rows.Add(row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NumeroColegiado"].ToString(),
                                    row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
                            }
                        }
                        //totalRegistros += 1;
                        //dgvColegiados.Rows.Add(row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                        //    row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
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

        private void txtCondicion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondicion.ReadOnly)
            {
                listaCondiciones();
            }
        }

        private void listaCondiciones()
        {
            Listado listD = new Listado();
            listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición,CodigoPlantilla";
           // listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición";
            listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listD.TABLA = "NV_CONDICIONES";
            //listD.FILTRO = "where CondicionFallecido != 'S' and CondicionFallecido != 'S' and CodigoCondicion != 'C-07' and  CodigoCondicion != 'C-10' and  CodigoCondicion != 'C-11' and  CodigoCondicion != 'C-13'";
            listD.FILTRO = "WHERE GeneraCobro != 'NO'";
            listD.TITULO_LISTADO = "Condiciones Colegiado";
            listD.COLUMNAS_OCULTAS.Add("CodigoPlantilla");

            frmF1 f1 = new frmF1(listD);
            f1.ShowDialog();
            if (f1.item != null)
            {
                txtCondicion.Text = f1.item.SubItems[0].Text;
                txtDescCondicion.Text = f1.item.SubItems[1].Text;
                refrescarDatos();
            }
        }

        private void limpiar()
        {
            if(dgvColegiados.Rows.Count > 0)
            {
                dgvColegiados.Rows.Clear();
            }
            lblRegistrosCant.Text = dgvColegiados.Rows.Count.ToString();
        }

        private void txtCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondicion.ReadOnly)
            {
                listaCondiciones();
            }
        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkGenTotal_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkGenTotal.Checked)
            {
                txtCondicion.ReadOnly = true;
                txtCondicion.Clear();
                txtDescCondicion.Clear();
                refrescarDatosGeneracionTotal();
            }
            else
            {
                limpiar();
                txtCondicion.ReadOnly = false;
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvColegiados.RowCount == 0)
            {
                MessageBox.Show("No existen datos para exportar a excel.", "Exportación a excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExcelInterop.Application Excel = new ExcelInterop.Application();
                Excel.Workbooks.Add();
                // single worksheet
                ExcelInterop._Worksheet Worksheet = Excel.ActiveSheet;

                List<int> ColumnasNoVisibles = new List<int>();
                List<string> colFechas = new List<string>();

                colFechas.Add("colUltimoCobro");
                //colFechas.Add("Desde");
                //colFechas.Add("Hasta");
                
                int columnas = dgvColegiados.ColumnCount;
                int rows = dgvColegiados.RowCount;
                object[] Header = new object[columnas];

                // column headings               
                for (int i = 0; i < columnas; i++)
                {
                    //if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga")
                    //    Header[i] = dgvColegiados.Columns[i].HeaderText;
                    if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga")
                    {
                        if (dgvColegiados.Columns[i].Visible == true)
                            Header[i] = dgvColegiados.Columns[i].HeaderText;
                        else
                            ColumnasNoVisibles.Add(i + 1);
                    }
                }



                ExcelInterop.Range HeaderRange = Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[1, 1]), (ExcelInterop.Range)(Worksheet.Cells[1, columnas]));
                HeaderRange.Value = Header;
                HeaderRange.Font.Bold = true;
                HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                // DataCells

                object[,] Cells = new object[rows, columnas];
                bool fecha = false;
                for (int j = 0; j < rows; j++)
                {
                    for (int i = 0; i < columnas; i++)
                    {

                        fecha = false;
                        for (int k = 0; k < colFechas.Count; k++)
                        {
                            if (dgvColegiados.Columns[i].HeaderText == colFechas[k])
                            {
                                if (dgvColegiados[i, j].Value.ToString() != "")
                                    Cells[j, i] = DateTime.Parse(dgvColegiados[i, j].Value.ToString()).ToString("yyyy-MM");
                                else
                                    Cells[j, i] = "";
                                fecha = true;
                                break;
                            }
                        }
                        if (!fecha && (dgvColegiados.Columns[i].HeaderText != "Detalle Carga" && dgvColegiados.Columns[i].Visible == true))
                            if (dgvColegiados[i, j].Value != null)
                                Cells[j, i] = dgvColegiados[i, j].Value.ToString();
                            else
                                Cells[j, i] = "";


                    }
                    
                }

                Worksheet.Name = "Proceso Cobros Colegiaturas";
                Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[rows + 1, columnas])).Value = Cells;
                Worksheet.Columns.AutoFit();
                //Eliminar columnas que no estan visibles en el dgv
                int cont = 0;
                foreach (int column in ColumnasNoVisibles)
                {
                    if (cont == 0)
                        Worksheet.Columns[column].Delete();
                    else
                        Worksheet.Columns[column - cont].Delete();
                    cont++;
                }
                Excel.Visible = true;
                // DateTime tiempo2 = DateTime.Now;
                // TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
                // MessageBox.Show("Duracion: " + total.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la exportación de datos a excel: " + ex.Message, "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
