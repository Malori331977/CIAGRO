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

namespace KOLEGIO.Procesos
{
    public partial class frmCobrosRegencias : Form
    {
        int totalRegistros = 0;
        int totalRegistrosExitosos = 0;
        int totalRegistrosErroneos = 0;
        private FuncsInternas fInternas;

        public frmCobrosRegencias()
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

            if (dgvRegentes.RowCount > 0)
            {
                limpiarEstadoCeldas();
                btnSalir.Enabled = false;
                btnProcesar.Enabled = false;
                fInternas.deshabilitarOrdenDgv(ref dgvRegentes);
                desactivarLabels();
                CheckForIllegalCrossThreadCalls = false;
                pbProceso.Minimum = 0;
                pbProceso.Maximum = dgvRegentes.RowCount + 1;
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
            else
                MessageBox.Show("No hay información para procesar.", "Carga Masiva de Pólizas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            generarCobroRegencias();
        }

        private void bwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSalir.Enabled = true;
            btnProcesar.Enabled = true;
            fInternas.habilitarOrdenDgv(ref dgvRegentes);
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
            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                row.Cells["colResultado"].Value = iList.Images[0];
                row.Cells["colObservaciones"].Value = "";
            }
        }

        //private bool actualizarUltMesCobro(string colegiado, string estable, string codCategoria, string ultimoCobro, ref string error)
        //{
        //    bool OK = true;
        //    string sUpdate = "";
        //    string sSelect = "";
        //    //string sInsert = "";
        //    DateTime mesUltCobro = DateTime.Now;
        //    DataTable dt = new DataTable();
        //    if (ultimoCobro.Equals(""))
        //    {
        //        mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, /*mesUltCobro.Day*/ 25);
        //    }
        //    else
        //    {
        //        DateTime ActualizarCobro = DateTime.Parse(ultimoCobro);
        //        mesUltCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month, /*mesUltCobro.Day*/ 25).AddMonths(1);
        //        //mesUltCobro = DateTime.Parse(ultimoCobro).AddMonths(1);
        //        //mesUltCobro = mesUltCobro.AddMonths(1);
        //    }

        //    sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado = '" + colegiado + "' and CodigoEstablecimiento = '" + estable + "' and CodigoCategoria = '" + codCategoria + "'";

        //    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

        //    if (OK && dt.Rows.Count > 0)
        //    {
        //        string mes = "";
        //        mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");
        //        sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS set MesUltimoCobro = '" + mes + "' where NumeroColegiado= '" + colegiado + "' and CodigoEstablecimiento = '" + estable + "' and CodigoCategoria = '" + codCategoria + "'";

        //        OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //    }
        //    //else
        //    //{
        //    //    sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS (IdColegiado,MesUltimoCobro) values ('" + colegiado + "', '" + ultimoCobro + "')";

        //    //    OK = Consultas.ejecutarSentencia(sInsert, ref error);
        //    //}

        //    return OK;
        //}

        private bool actualizarUltMesCobro(string colegiado, string estable, string codCategoria, string ultimoCobro, ref string error)
        {
            bool OK = true;
            string sUpdate = "";
            string sInsert = "";
            string sSelect = "";
            DateTime mesUltCobro = DateTime.Now;
            DataTable dt = new DataTable();

            if (ultimoCobro.Equals(""))
            {
                mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, /*mesUltCobro.Day*/ 25);
            }
            else
            {
                DateTime ActualizarCobro = DateTime.Parse(ultimoCobro);
                mesUltCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month, /*mesUltCobro.Day*/ 25).AddMonths(1);
                //mesUltCobro = DateTime.Parse(ultimoCobro).AddMonths(1);
                //mesUltCobro = mesUltCobro.AddMonths(1);
            }

            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS where IdColegiado = '" + colegiado + "' and NumRegistro = '" + estable + "' and Categoria = '" + codCategoria + "'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count > 0)
            {
                string mes = "";
                mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");
                sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "' and NumRegistro = '" + estable + "' and Categoria = '" + codCategoria + "'";

                OK = Consultas.ejecutarSentencia(sUpdate, ref error);
            }
            else
            {
                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS (IdColegiado,NumRegistro,Categoria,MesUltimoCobro) values ('" + colegiado + "', '" + estable + "', '" + codCategoria + "', '" + ultimoCobro + "')";

                OK = Consultas.ejecutarSentencia(sInsert, ref error);
            }

            
            return OK;
        }

        private void generarCobroRegencias()
        {
            string error = "";
            int progreso = 1;
            //string referenciaCobro = "regencia";
            bwProceso.ReportProgress(progreso);

            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                bool OK = true;
                DataTable dtCliente = new DataTable();
                DataTable dtAplicaClie = new DataTable();
                DateTime fechaActu = DateTime.Now;
                DateTime fechaDgv = DateTime.Now;
                fechaActu = new DateTime(fechaActu.Year, fechaActu.Month, 25);
                if (!row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                    fechaDgv = new DateTime(DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Year, DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Month, 25);
                else
                    fechaDgv = new DateTime(1900, 01, 25);

                //if (row.Cells["colUltimoCobro"].Value.ToString().Equals("") || DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()) < fechaActu)
                if (row.Cells["colUltimoCobro"].Value.ToString().Equals("") || fechaDgv < fechaActu)
                {
                    try
                    {
                        Consultas.sqlCon.iniciaTransaccion();

                        //OK = generarPedido(row.Cells["colIdColegiado"].Value.ToString(), dtCliente, referenciaCobro, ref error);

                        //string sSelect = "select AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = (select distinct CodigoPlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO where NumeroColegiado = '" + row.Cells["colIdColegiado"].Value.ToString() + "') and AplicaClienteErp = 'S'";
                        string sSelect = "select t3.AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
                                " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 on t3.CodigoPlantilla = t2.CodigoPlantilla where t1.IdColegiado = '" + row.Cells["colIdColegiado"].Value.ToString() + "'";
                        OK = Consultas.fillDataTable(sSelect, ref dtAplicaClie, ref error);
                        string sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + row.Cells["colIdColegiado"].Value.ToString() + "'";
                        OK = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

                        if (OK && dtAplicaClie.Rows.Count > 0 && dtCliente.Rows.Count == 0)
                        {

                            OK = fInternas.generarNit(row.Cells["colCedula"].Value.ToString(), row.Cells["colIdColegiado"].Value.ToString(), ref dtCliente, "colegiado", ref error);

                            if (OK)
                                OK = fInternas.generarCliente(row.Cells["colIdColegiado"].Value.ToString(), ref dtCliente, "colegiado", "R", ref error);

                        }

                        if (OK)
                            OK = fInternas.verificarAceptaDocElectronicoClienteERP(row.Cells["colIdColegiado"].Value.ToString(), ref error);

                        if (OK)
                            OK = generarPedidoRegencia(row.Cells["colIdColegiado"].Value.ToString(), row.Cells["colCodiCategoria"].Value.ToString(), row.Cells["colNumEstablecimiento"].Value.ToString(), row.Cells["colNombreEstablecimiento"].Value.ToString(), row.Cells["colCategoria"].Value.ToString(), row.Cells["colCobradorRegente"].Value.ToString(), dtCliente, row.Cells["colUltimoCobro"].Value.ToString(), ref error);

                        if (OK)
                            OK = actualizarUltMesCobro(row.Cells["colIdColegiado"].Value.ToString(), row.Cells["colNumEstablecimiento"].Value.ToString(), row.Cells["colCodiCategoria"].Value.ToString(), row.Cells["colUltimoCobro"].Value.ToString(), ref error);

                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            totalRegistrosExitosos += 1;
                            row.Cells["colResultado"].Value = iList.Images[2];
                            row.Cells["colObservaciones"].Value = "¡Cobro de Regencia Exitoso!";
                            actualizarMesCobro(row.Cells["colIdColegiado"].Value.ToString(), row.Cells["colNumEstablecimiento"].Value.ToString(), row.Cells["colCodiCategoria"].Value.ToString(), row.Cells["colUltimoCobro"].Value.ToString());
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
                    row.Cells["colObservaciones"].Value = "Ya se le cobró esta regencia en el mes actual";

                }


                progreso += 1;
                bwProceso.ReportProgress(progreso);
            }
        }

        private void actualizarMesCobro(string id, string numReg, string categ, string NuevoMesCobro)
        {
            DateTime actual = DateTime.Now;
            if (NuevoMesCobro.Equals(""))
            {
                NuevoMesCobro = new DateTime(actual.Year, actual.Month, 25).ToString("MM/yyyy");
            }
            else
            {
                DateTime ActualizarCobro = DateTime.Parse(NuevoMesCobro);
                NuevoMesCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month, 25).AddMonths(1).ToString("MM/yyyy");
               
            }

            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                if (id == row.Cells["colIdColegiado"].Value.ToString() && numReg == row.Cells["colNumEstablecimiento"].Value.ToString() && categ == row.Cells["colCodiCategoria"].Value.ToString())
                {
                    row.Cells["colUltimoCobro"].Value = NuevoMesCobro;
                }
            }


        }

        private bool generarPedidoRegencia(string idColegiado, string numCategoria, string numEstablecimiento, string nombreEstablecimiento, string categoria, string cobrador, DataTable dtCliente, string ultimoCobro, ref string error)
        {
            decimal montoDesc = 0;
            int cantidad = 1, porcDescuento = 0;
            //string sQuery = "SELECT t3.CodigoArticulo,t4.COSTO_STD_LOC as monto, t5.Nombre as nombreEstablecimiento FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.NumeroColegiado" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t3 ON t3.CodigoCategoria = t1.CodigoCategoria" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 ON t4.ARTICULO = t3.CodigoArticulo" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t5 ON t5.NumRegistro = t1.CodigoEstablecimiento" +
            //                " WHERE t1.NumeroColegiado = '" + idColegiado + "'";
            string sQuery = "SELECT t3.CodigoArticulo,t7.DESCRIPCION as descripcion,t4.PRECIO as monto, t5.Nombre as nombreEstablecimiento, t6.NombreCategoria as nomCategoria FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.NumeroColegiado" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t3 ON t3.CodigoCategoria = t1.CodigoCategoria" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 ON t4.ARTICULO = t3.CodigoArticulo" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t5 ON t5.NumRegistro = t1.CodigoEstablecimiento" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t6 ON t6.CodigoCategoria = t1.CodigoCategoria" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t7 ON t7.ARTICULO = t3.CodigoArticulo" +
                            " WHERE t1.NumeroColegiado = '" + idColegiado + "' AND t5.NumRegistro = '" + numEstablecimiento + "' and t1.CodigoCategoria = '" + numCategoria + "'";

            DataTable dtArticulos = new DataTable();


            if (Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
            {
                if (dtArticulos.Rows.Count > 0)
                {
                    return controlerBD.crearPedidoRegencia(dtArticulos, idColegiado, nombreEstablecimiento, numCategoria, categoria, cantidad, montoDesc, porcDescuento,cobrador,"cobro",ultimoCobro, ref error);
                }
                else
                {
                    error = "Esta categoría no posee artículos";
                    return false;
                }

                
            }
            else
                return false;

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (!chkGenTotal.Checked)
                refrescarDatos();
            else
                refrescarDatosGeneracionTotal();
        }

        private void refrescarDatos()//Falta validar que el colegiado no sea suspendido o retirado o fallecido--Se valido con el check de genera cobro en condiciones
        {

            string sQuery = "select t2.IdColegiado as IdColegiado,t1.Cedula,t2.NumeroColegiado as NumCole,t2.Nombre as NombreCole, t3.NumRegistro as NumEstablecimiento, t3.Nombre as NomEstablecimiento, t4.NombreCategoria as nomCategoria, t4.CodigoCategoria as codCategoria, t6.MesUltimoCobro as UltMesCobro, t1.Cobrador as cobradorRegente from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.NumeroColegiado" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t3 on t3.NumRegistro = t1.CodigoEstablecimiento" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t4 on t1.CodigoCategoria = t4.CodigoCategoria" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t5 on t1.CodigoCategoria = t5.CodigoCategoria" +
                            " left join " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t6 on t6.NumRegistro = t3.NumRegistro" +
                            " where t1.Estado = 'A' and t1.CodigoCategoria = '" + txtCategoria.Text + "' and t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')" +
                            " group by t2.IdColegiado ,t2.NumeroColegiado ,t2.Nombre , t3.NumRegistro ,  t3.Nombre , t4.NombreCategoria , t4.CodigoCategoria , t6.MesUltimoCobro , t1.Cobrador";
            DataTable dtIngresos = new DataTable();
            string error = "";
            
            try
            {
                if (Consultas.fillDataTable(sQuery, ref dtIngresos, ref error))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    dgvRegentes.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtIngresos.Rows)
                    {
                        if (row["UltMesCobro"].ToString().Equals(""))
                        {
                            totalRegistros += 1;
                            dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(),
                                row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "",
                                row["cobradorRegente"].ToString());
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
                                dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(),
                                    row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "",
                                    row["cobradorRegente"].ToString());
                            }
                        }
                        //totalRegistros += 1;
                        //dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["NombreCole"].ToString(),
                        //    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), 
                        //    row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", 
                        //    row["cobradorRegente"].ToString());
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

        private void refrescarDatosGeneracionTotal()//Falta validar que el colegiado no sea suspendido o retirado o fallecido
        {

            string sQuery = "select t2.IdColegiado as IdColegiado,t1.Cedula,t2.NumeroColegiado as NumCole,t2.Nombre as NombreCole, t3.NumRegistro as NumEstablecimiento, "+
                " t3.Nombre as NomEstablecimiento, t4.NombreCategoria as nomCategoria, t4.CodigoCategoria as codCategoria,t1.Cobrador as cobradorRegente, t6.MesUltimoCobro as UltMesCobro"+
                " from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.NumeroColegiado" +
                " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t3 on t3.NumRegistro = t1.CodigoEstablecimiento" +
                " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t4 on t1.CodigoCategoria = t4.CodigoCategoria" +
                " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t5 on t1.CodigoCategoria = t5.CodigoCategoria" +
                " left join " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t6 on t6.NumRegistro = t3.NumRegistro" +
                " where t1.Estado = 'A' and t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')" + 
                " group by t2.IdColegiado ,t2.NumeroColegiado ,t2.Nombre , t3.NumRegistro , t3.Nombre , t4.NombreCategoria , t4.CodigoCategoria , t6.MesUltimoCobro ,  t1.Cobrador, t2.Condicion order by t2.Nombre";
            DataTable dtIngresos = new DataTable();
            string error = "";
            try
            {
                if (Consultas.fillDataTable(sQuery, ref dtIngresos, ref error))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    dgvRegentes.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtIngresos.Rows)
                    {
                        if (row["UltMesCobro"].ToString().Equals(""))
                        {
                            totalRegistros += 1;
                            dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["cobradorRegente"].ToString());
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
                                dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["cobradorRegente"].ToString());
                            }
                        }
                        //totalRegistros += 1;
                        //dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["NombreCole"].ToString(),
                        //    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["cobradorRegente"].ToString());
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

        private void limpiar()
        {
            if (dgvRegentes.Rows.Count > 0)
            {
                dgvRegentes.Rows.Clear();
            }
            lblRegistrosCant.Text = dgvRegentes.Rows.Count.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvRegentes.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void txtCategoria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCategoria.ReadOnly)
            {
                listaCategorias();
            }
        }


        private void listaCategorias()
        {
            Listado listD = new Listado();
            listD.COLUMNAS = "CodigoCategoria as Código,NombreCategoria as Categoria,DescripcionCategoria as Descripción";
            // listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición";
            listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listD.TABLA = "NV_CATEGORIAS";
            listD.TITULO_LISTADO = "Categorias Regencias";
            //listD.COLUMNAS_OCULTAS.Add("Descripción");

            frmF1 f1 = new frmF1(listD);
            f1.ShowDialog();
            if (f1.item != null)
            {
                txtCategoria.Text = f1.item.SubItems[0].Text;
                txtDescCategoria.Text = f1.item.SubItems[1].Text;
                refrescarDatos();
            }
        }

        private void txtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCategoria.ReadOnly)
            {
                listaCategorias();
            }
        }

        private void chkGenTotal_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkGenTotal.Checked)
            {
                txtCategoria.ReadOnly = true;
                txtCategoria.Clear();
                txtDescCategoria.Clear();
                refrescarDatosGeneracionTotal();
            }
            else
            {
                limpiar();
                txtCategoria.ReadOnly = false;
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvRegentes.RowCount == 0)
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

                int columnas = dgvRegentes.ColumnCount; 
                int rows = dgvRegentes.RowCount;
                object[] Header = new object[columnas];

                // column headings               
                for (int i = 0; i < columnas; i++)
                {
                    if (dgvRegentes.Columns[i].HeaderText != "Detalle Carga")
                    {
                        if (dgvRegentes.Columns[i].Visible == true)
                            Header[i] = dgvRegentes.Columns[i].HeaderText;
                        else
                            ColumnasNoVisibles.Add(i+1);
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
                            if (dgvRegentes.Columns[i].HeaderText == colFechas[k])
                            {
                                if (dgvRegentes[i, j].Value.ToString() != "")
                                    Cells[j, i] = DateTime.Parse(dgvRegentes[i, j].Value.ToString()).ToString("yyyy-MM");
                                else
                                    Cells[j, i] = "";
                                fecha = true;
                                break;
                            }
                        }
                        if (!fecha && (dgvRegentes.Columns[i].HeaderText != "Detalle Carga" && dgvRegentes.Columns[i].Visible == true))
                            if (dgvRegentes[i, j].Value != null)
                                Cells[j, i] = dgvRegentes[i, j].Value.ToString();
                            else
                                Cells[j, i] = "";
                          
                    }

                }

                Worksheet.Name = "Proceso Cobros Regencias";
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
