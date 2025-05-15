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
    public partial class frmCobrosRegenciasNuevo : Form
    {
        private int totalRegistros = 0;
        private int totalRegistrosExitosos = 0;
        private int totalRegistrosErroneos = 0;
        private int marcados = 0;
        private DataTable dtIngresos = new DataTable();
        private DataTable dtDatosIngresos = new DataTable();
        private BindingSource source1 = new BindingSource();
        private FuncsInternas fInternas;

        public frmCobrosRegenciasNuevo()
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            dgvRegentes.Columns.Clear();
            dtIngresos.Columns.Add("Aplicar", typeof(Boolean));
            dtIngresos.Columns.Add("Nº Colegiado", typeof(String));
            dtIngresos.Columns.Add("Id Colegiado", typeof(String));
            dtIngresos.Columns.Add("Cedula", typeof(String));
            dtIngresos.Columns.Add("Nombre", typeof(String));
            dtIngresos.Columns.Add("NumEstablecimiento", typeof(String));
            dtIngresos.Columns.Add("Establecimiento", typeof(String));
            dtIngresos.Columns.Add("CodCategoria", typeof(String));
            dtIngresos.Columns.Add("Categoria", typeof(String));
            dtIngresos.Columns.Add("Último Cobro", typeof(String));
            dtIngresos.Columns.Add("Cobrador", typeof(String));
            dtIngresos.Columns.Add("Estado", typeof(Image));
            dtIngresos.Columns.Add("Observaciones", typeof(String));

            bool masivo = Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, Constantes.PROCESO_COBRO_REGENCIAS_MASIVA);
            bool individual = Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, Constantes.PROCESO_COBRO_REGENCIAS_INDIVIDUAL);

            if (masivo && individual)
            {
                chkMasivo.Enabled = true;
                chkGenTotal.Enabled = true;
            }

            if (!masivo)
            {
                chkMasivo.Enabled = false;
                chkGenTotal.Enabled = false;
            }

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
                marcados = 0;
                foreach (DataGridViewRow row in dgvRegentes.Rows)
                {
                    //if ((bool)row.Cells["colCheck"].Value)
                    if ((bool)row.Cells["Aplicar"].Value)
                    {
                        marcados += 1;
                    }
                }

                if (validarDatos())
                {
                    limpiarEstadoCeldas();
                    btnSalir.Enabled = false;
                    btnProcesar.Enabled = false;
                    fInternas.deshabilitarOrdenDgv(ref dgvRegentes);
                    desactivarLabels();
                    CheckForIllegalCrossThreadCalls = false;
                    pbProceso.Minimum = 0;
                    //pbProceso.Maximum = dgvRegentes.RowCount + 1;
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
            pbProceso.Value = 0;
            activarLabels();
        }

        private bool validarDatos()
        {
            string error = "";
            bool OK = true;
            if (marcados == 0)
            {
                error = "Debe marcar los registros que proceden al cobro o marcar la casilla de masivo";
                //chkMasivo.Focus();
                OK = false;
            }

            if (!txtFiltro.Text.Equals(""))
            {
                error = "Debe borrar el filtro para procesar";
                txtFiltro.Focus();
                OK = false;
            }


            if (!OK)
            {
                MessageBox.Show(error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return OK;
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
                row.Cells["Estado"].Value = iList.Images[0];
                row.Cells["Observaciones"].Value = "";
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

        private bool actualizarUltMesCobro(string colegiado, string estable, string codCategoria, DateTime ultimoCobro, ref string error)
        {
            bool OK = true;
            string sUpdate = "";
            string sInsert = "";
            string sSelect = "";
            //DateTime mesUltCobro = DateTime.Now;
            DataTable dt = new DataTable();

            //if (ultimoCobro.Equals(""))
            //{
            //    mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, /*mesUltCobro.Day*/ 25);
            //}
            //else
            //{
            //    DateTime ActualizarCobro = DateTime.Parse(ultimoCobro);
            //    mesUltCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month, /*mesUltCobro.Day*/ 25).AddMonths(1);
            //    //mesUltCobro = DateTime.Parse(ultimoCobro).AddMonths(1);
            //    //mesUltCobro = mesUltCobro.AddMonths(1);
            //}

            string mes = "";
            //mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");
            mes = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");

            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS where IdColegiado = '" + colegiado + "' and NumRegistro = '" + estable + "' and Categoria = '" + codCategoria + "'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count > 0)
            {
                sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "' and NumRegistro = '" + estable + "' and Categoria = '" + codCategoria + "'";

                OK = Consultas.ejecutarSentencia(sUpdate, ref error);
            }
            else
            {
                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS (IdColegiado,NumRegistro,Categoria,MesUltimoCobro) values ('" + colegiado + "', '" + estable + "', '" + codCategoria + "', '" + mes + "')";

                OK = Consultas.ejecutarSentencia(sInsert, ref error);
            }

            
            return OK;
        }

        private void generarCobroRegencias()
        {
            string error = "";
            int progreso = 0;
            //string referenciaCobro = "regencia";
            bwProceso.ReportProgress(progreso);

            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                bool OK = true;
                DataTable dtCliente = new DataTable();
                DataTable dtAplicaClie = new DataTable();
                DateTime mesUltCobro = DateTime.Now;
                DateTime fechaActu = DateTime.Now;
                DateTime fechaDgv = DateTime.Now;
                fechaActu = new DateTime(fechaActu.Year, fechaActu.Month, 25);

                if ((bool)row.Cells["Aplicar"].Value)
                {
                    if (!row.Cells["Último Cobro"].Value.ToString().Equals(""))
                        fechaDgv = new DateTime(DateTime.Parse(row.Cells["Último Cobro"].Value.ToString()).Year, DateTime.Parse(row.Cells["Último Cobro"].Value.ToString()).Month, 25);
                    else
                        fechaDgv = new DateTime(1900, 01, 25);

                    //if (row.Cells["Último Cobro"].Value.ToString().Equals("") || DateTime.Parse(row.Cells["Último Cobro"].Value.ToString()) < fechaActu)
                    if (row.Cells["Último Cobro"].Value.ToString().Equals("") || fechaDgv < fechaActu)
                    {
                        try
                        {
                            Consultas.sqlCon.iniciaTransaccion();

                            //OK = generarPedido(row.Cells["Id Colegiado"].Value.ToString(), dtCliente, referenciaCobro, ref error);

                            //string sSelect = "select AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = (select distinct CodigoPlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO where NumeroColegiado = '" + row.Cells["Id Colegiado"].Value.ToString() + "') and AplicaClienteErp = 'S'";
                            string sSelect = "select t3.AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
                                    " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 on t3.CodigoPlantilla = t2.CodigoPlantilla where t1.IdColegiado = '" + row.Cells["Id Colegiado"].Value.ToString() + "'";
                            OK = Consultas.fillDataTable(sSelect, ref dtAplicaClie, ref error);
                            string sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + row.Cells["Id Colegiado"].Value.ToString() + "'";
                            OK = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

                            if (OK && dtAplicaClie.Rows.Count > 0 && dtCliente.Rows.Count == 0)
                            {

                                OK = fInternas.generarNit(row.Cells["Cedula"].Value.ToString(), row.Cells["Id Colegiado"].Value.ToString(),ref dtCliente, "colegiado", ref error);

                                if (OK)
                                    OK = fInternas.generarCliente(row.Cells["Id Colegiado"].Value.ToString(), ref dtCliente, "colegiado", "R", ref error);

                            }

                            //Ya no se requiere pues al insertarse facturas no es necesario
                            //if (OK)
                            //    OK = fInternas.verificarAceptaDocElectronicoClienteERP(row.Cells["Id Colegiado"].Value.ToString(), ref error);

                            if (OK)
                            {
                                if (row.Cells["Último Cobro"].Value.ToString().Equals(""))
                                {
                                    mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 25);
                                }
                                else
                                {
                                    DateTime ActualizarCobro = DateTime.Parse(row.Cells["Último Cobro"].Value.ToString());
                                    mesUltCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month, 25).AddMonths(1);
                                }

                                OK = generarPedidoRegencia(row.Cells["Id Colegiado"].Value.ToString(), row.Cells["CodCategoria"].Value.ToString(), row.Cells["NumEstablecimiento"].Value.ToString(), row.Cells["Establecimiento"].Value.ToString(), row.Cells["Categoria"].Value.ToString(), row.Cells["Cobrador"].Value.ToString(), dtCliente, mesUltCobro.ToString("MM/yyyy"), ref error);

                            }

                            //if (OK)
                            //    OK = actualizarUltMesCobro(row.Cells["Id Colegiado"].Value.ToString(), row.Cells["NumEstablecimiento"].Value.ToString(), row.Cells["CodCategoria"].Value.ToString(), mesUltCobro, ref error);
                            if (OK)
                                OK = guardarUltimoCobro(row.Cells["Id Colegiado"].Value.ToString(), row.Cells["NumEstablecimiento"].Value.ToString(), row.Cells["CodCategoria"].Value.ToString(), mesUltCobro, ref error);

							if (OK)
							{
								Consultas.sqlCon.Commit();
								totalRegistrosExitosos += 1;
								row.Cells["Estado"].Value = iList.Images[2];
								row.Cells["Observaciones"].Value = "¡Cobro de Regencia Exitoso!";
								actualizarMesCobro(row.Cells["Id Colegiado"].Value.ToString(), row.Cells["NumEstablecimiento"].Value.ToString(), row.Cells["CodCategoria"].Value.ToString(), row.Cells["Último Cobro"].Value.ToString());
							}
							else
							{
								Consultas.sqlCon.Rollback();
								totalRegistrosErroneos += 1;
								row.Cells["Estado"].Value = iList.Images[1];
								row.Cells["Observaciones"].Value = error;

							}

						}
                        catch (Exception ex)
                        {
                            Consultas.sqlCon.Rollback();
                            row.Cells["Estado"].Value = iList.Images[1];
                            row.Cells["Observaciones"].Value = ex.Message;
                        }
                    }
                    else
                    {
                        //Consultas.sqlCon.Rollback();
                        totalRegistrosErroneos += 1;
                        row.Cells["Estado"].Value = iList.Images[3];
                        row.Cells["Observaciones"].Value = "Ya se le cobró esta regencia en el mes actual";

                    }
                    
                    progreso += 1;
                    bwProceso.ReportProgress(progreso);
                }
            }
        }

        private bool guardarUltimoCobro(string colegiado, string numReg, string categ, DateTime mesUltCobro, ref string error)
        {
            Listado list = new Listado();
            List<string> parametros = new List<string>();
            bool lbOK = true;

            if (fInternas.existeUltimoCobro(colegiado, numReg, categ, string.Empty, "REG"))
            {
                fInternas.actualizarUltimoCobro(ref parametros, ref list, string.Empty, mesUltCobro, colegiado, numReg, categ, "REG");

                if (lbOK)
                    lbOK = Consultas.actualizar(parametros, list, Constantes.ID_BIT_UPDATE_ULTIMO_COBRO, ref error);
            }
            else
            {
                fInternas.agregarUltimoCobro(ref parametros, ref list, string.Empty, mesUltCobro, colegiado, numReg, categ, "REG");
                if (lbOK)
                    lbOK = Consultas.insertar(parametros, list, Constantes.ID_BIT_CREAR_ULTIMO_COBRO, ref error);
            }

            return lbOK;
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
                if (id == row.Cells["Id Colegiado"].Value.ToString() && numReg == row.Cells["NumEstablecimiento"].Value.ToString() && categ == row.Cells["CodCategoria"].Value.ToString())
                {
                    row.Cells["Último Cobro"].Value = NuevoMesCobro;
                }
            }


        }

        private bool generarPedidoRegencia(string idColegiado, string numCategoria, string numEstablecimiento, string nombreEstablecimiento, string categoria, string cobrador, DataTable dtCliente, string ultimoCobro, ref string error)
        {
            decimal montoDesc = 0;
            int cantidad = 1, porcDescuento = 0, indiceArticulo = 0;
            string factura = "";
            //string sQuery = "SELECT t3.CodigoArticulo,t4.COSTO_STD_LOC as monto, t5.Nombre as nombreEstablecimiento FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.NumeroColegiado" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t3 ON t3.CodigoCategoria = t1.CodigoCategoria" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 ON t4.ARTICULO = t3.CodigoArticulo" +
            //                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t5 ON t5.NumRegistro = t1.CodigoEstablecimiento" +
            //                " WHERE t1.NumeroColegiado = '" + idColegiado + "'";
            //string sQuery = "SELECT t3.CodigoArticulo,t7.DESCRIPCION as descripcion,t4.PRECIO as monto, t5.Nombre as nombreEstablecimiento, t6.NombreCategoria as nomCategoria" + 
            string sQuery = "select t3.CodigoArticulo ARTICULO, t7.DESCRIPCION, t4.PRECIO, '1' CANTIDAD, '0' DESCUENTO"+
                            " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.NumeroColegiado" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t3 ON t3.CodigoCategoria = t1.CodigoCategoria" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 ON t4.ARTICULO = t3.CodigoArticulo" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t8 on t8.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t8.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t8.FECHA_INICIO AND t8.FECHA_CORTE) AND t8.ESTADO = 'A'" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t5 ON t5.NumRegistro = t1.CodigoEstablecimiento" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t6 ON t6.CodigoCategoria = t1.CodigoCategoria" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t7 ON t7.ARTICULO = t3.CodigoArticulo" +
                            " WHERE t1.Estado='A' and t1.NumeroColegiado = '" + idColegiado + "' AND t5.NumRegistro = '" + numEstablecimiento + "' and t1.CodigoCategoria = '" + numCategoria + "'";

            DataTable dtArticulos = new DataTable();


            if (Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
            {
                if (dtArticulos.Rows.Count > 0)
                {
                    //string observacion = numEstablecimiento + "-" + categoria + " " + DateTime.Parse(ultimoCobro).ToString("MMMM yyyy").ToUpper();
                    string observacion = categoria + "-" + numEstablecimiento + " " + nombreEstablecimiento;
                    return controlerBD.FacturarSinPedido(dtArticulos, idColegiado, ref factura, montoDesc, porcDescuento, false, indiceArticulo, cobrador, "R", "FACTURAS", "REG", observacion, observacion, numEstablecimiento, numCategoria, ref error);
                    //return controlerBD.crearPedidoRegencia(dtArticulos, idColegiado, numEstablecimiento, numCategoria, categoria, cantidad, montoDesc, porcDescuento,cobrador,"cobro",ultimoCobro, ref error);
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

            string sQuery = "select t2.IdColegiado as IdColegiado,t2.Cedula,t2.NumeroColegiado as NumCole,t2.Nombre as NombreCole, t3.NumRegistro as NumEstablecimiento, t3.Nombre as NomEstablecimiento, t4.NombreCategoria as nomCategoria, t4.CodigoCategoria as codCategoria, t6.MesUltimoCobro as UltMesCobro, t1.Cobrador as cobradorRegente " +
                            " from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.NumeroColegiado" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t3 on t3.NumRegistro = t1.CodigoEstablecimiento" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t4 on t1.CodigoCategoria = t4.CodigoCategoria" +
                            //" join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t5 on t1.CodigoCategoria = t5.CodigoCategoria" +
                            " left join " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t6 on  t6.IdColegiado = t1.NumeroColegiado and t6.NumRegistro = t1.CodigoEstablecimiento and t6.Categoria = t1.CodigoCategoria  " +
                            " where t1.Estado = 'A' and t1.CodigoCategoria = '" + txtCategoria.Text + "' and t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')" +
                            " group by t2.IdColegiado ,t2.NumeroColegiado,t2.Cedula ,t2.Nombre , t3.NumRegistro ,  t3.Nombre , t4.NombreCategoria , t4.CodigoCategoria , t6.MesUltimoCobro , t1.Cobrador";
            
            string error = "";
            
            try
            {
                dtDatosIngresos.Rows.Clear();
                Cursor.Current = Cursors.WaitCursor;

                if (Consultas.fillDataTable(sQuery, ref dtDatosIngresos, ref error))
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    //dgvRegentes.Rows.Clear();
                    dtIngresos.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtDatosIngresos.Rows)
                    {
                        if (row["UltMesCobro"].ToString().Equals(""))
                        {
                            totalRegistros += 1;
                            dtIngresos.Rows.Add(false, row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(),
                                row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "",
                                row["cobradorRegente"].ToString(), iList.Images[0], "");
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
                                dtIngresos.Rows.Add(false, row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(),
                                    row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "",
                                    row["cobradorRegente"].ToString(), iList.Images[0], "");
                            }
                        }
                        //totalRegistros += 1;
                        //dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["NombreCole"].ToString(),
                        //    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), 
                        //    row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", 
                        //    row["cobradorRegente"].ToString());
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();

                    DataView view = new DataView(dtIngresos);
                    source1.DataSource = view;
                    dgvRegentes.DataSource = view;
                    dgvRegentes.Columns["Id Colegiado"].Visible = false;
                    dgvRegentes.Columns["NumEstablecimiento"].Visible = false;
                    dgvRegentes.Columns["CodCategoria"].Visible = false;
                    dgvRegentes.Columns["Cobrador"].Visible = false;
                    dgvRegentes.Columns["Cedula"].Visible = false;
                    dgvRegentes.AutoResizeColumns();
                    dgvRegentes.Refresh();

                    chkMasivo.Checked = false;

                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refrescarDatosGeneracionTotal()//Falta validar que el colegiado no sea suspendido o retirado o fallecido
        {

            string sQuery = "select t2.IdColegiado as IdColegiado,t2.Cedula,t2.NumeroColegiado as NumCole,t2.Nombre as NombreCole, t3.NumRegistro as NumEstablecimiento, "+
                " t3.Nombre as NomEstablecimiento, t4.NombreCategoria as nomCategoria, t4.CodigoCategoria as codCategoria,t1.Cobrador as cobradorRegente, t6.MesUltimoCobro as UltMesCobro"+
                " from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.NumeroColegiado" +
                " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t3 on t3.NumRegistro = t1.CodigoEstablecimiento" +
                " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t4 on t1.CodigoCategoria = t4.CodigoCategoria" +
                //" join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t5 on t1.CodigoCategoria = t5.CodigoCategoria" +
                " left join " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t6 on  t6.IdColegiado = t1.NumeroColegiado and t6.NumRegistro = t1.CodigoEstablecimiento and t6.Categoria = t1.CodigoCategoria  " +
                " where t1.Estado = 'A' and t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')" +
                " group by t2.IdColegiado ,t2.NumeroColegiado,t2.Cedula ,t2.Nombre , t3.NumRegistro , t3.Nombre , t4.NombreCategoria , t4.CodigoCategoria , t6.MesUltimoCobro ,  t1.Cobrador, t2.Condicion order by t2.Nombre";
            
            string error = "";
            try
            {
                dtDatosIngresos.Rows.Clear();
                Cursor.Current = Cursors.WaitCursor;

                if (Consultas.fillDataTable(sQuery, ref dtDatosIngresos, ref error))
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    //dgvRegentes.Rows.Clear();
                    dtIngresos.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtDatosIngresos.Rows)
                    {
                        if (row["UltMesCobro"].ToString().Equals(""))
                        {
                            totalRegistros += 1;
                            dtIngresos.Rows.Add(false, row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["cobradorRegente"].ToString(), iList.Images[0], "");
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
                                dtIngresos.Rows.Add(false, row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NombreCole"].ToString(),
                                    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["cobradorRegente"].ToString(), iList.Images[0], "");
                            }
                        }
                        //totalRegistros += 1;
                        //dgvRegentes.Rows.Add(row["NumCole"].ToString(), row["IdColegiado"].ToString(), row["NombreCole"].ToString(),
                        //    row["NumEstablecimiento"].ToString(), row["NomEstablecimiento"].ToString(), row["codCategoria"].ToString(), row["nomCategoria"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["cobradorRegente"].ToString());
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();

                    DataView view = new DataView(dtIngresos);
                    source1.DataSource = view;
                    dgvRegentes.DataSource = view;
                    dgvRegentes.Columns["Id Colegiado"].Visible = false;
                    dgvRegentes.Columns["NumEstablecimiento"].Visible = false;
                    dgvRegentes.Columns["CodCategoria"].Visible = false;
                    dgvRegentes.Columns["Cobrador"].Visible = false;
                    dgvRegentes.Columns["Cedula"].Visible = false;
                    dgvRegentes.AutoResizeColumns();
                    dgvRegentes.Refresh();

                    chkMasivo.Checked = false;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void limpiar()
        {
            //if (dgvRegentes.Rows.Count > 0)
            //{
            //    dgvRegentes.Rows.Clear();
            //}
            dtDatosIngresos.Rows.Clear();
            dtIngresos.Rows.Clear();
            lblRegistrosCant.Text = dgvRegentes.Rows.Count.ToString();
        }

        private void activarMasivo()
        {
            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                row.Cells["Aplicar"].Value = true;
            }
            dgvRegentes.EndEdit();
        }

        private void desactivarMasivo()
        {
            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                row.Cells["Aplicar"].Value = false;
            }
            dgvRegentes.EndEdit();

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

                colFechas.Add("Ultimo Cobro");
                //colFechas.Add("Desde");
                //colFechas.Add("Hasta");

                int columnas = dgvRegentes.ColumnCount; 
                int rows = dgvRegentes.RowCount;
                object[] Header = new object[columnas];

                // column headings               
                for (int i = 0; i < columnas; i++)
                {
                    if (dgvRegentes.Columns[i].HeaderText != "Estado" && dgvRegentes.Columns[i].HeaderText != "Aplicar")
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
                        if (!fecha && (dgvRegentes.Columns[i].HeaderText != "Estado" && dgvRegentes.Columns[i].HeaderText != "Aplicar" && dgvRegentes.Columns[i].Visible == true))
                            if (dgvRegentes[i, j].Value != null)
                                Cells[j, i] = dgvRegentes[i, j].Value.ToString();
                            else
                                Cells[j, i] = "";
                          
                    }

                }

                Worksheet.Name = "Generación de Regencias";
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (!txtCategoria.Text.Equals("") || chkGenTotal.Checked)
            {
                if (!txtFiltro.Text.Equals(""))
                {
                    source1.Filter = "[Nº Colegiado] like '%" + txtFiltro.Text + "%' or [Último Cobro] like '%" + txtFiltro.Text + "%' or [Nombre] like '%" + txtFiltro.Text + "%' or [Categoria] like '%" + txtFiltro.Text + "%' or [Establecimiento] like '%" + txtFiltro.Text + "%'";
                    lblRegistrosCant.Text = dgvRegentes.Rows.Count.ToString();
                }
                else
                {
                    source1.Filter = "";
                    lblRegistrosCant.Text = dgvRegentes.Rows.Count.ToString();
                    //refrescarDatos();
                }
            }
            else
            {
                MessageBox.Show("No hay información para filtrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFiltro.Clear();
            }
        }

        private void dgvRegentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegentes.Rows.Count > 0)
            {
                bool masivo = true;
                if (dgvRegentes.CurrentCell.OwningColumn.Name == "Aplicar")
                {
                    if (e.RowIndex >= 0)
                    {
                        if ((bool)dgvRegentes.Rows[e.RowIndex].Cells["Aplicar"].Value == false)
                        {
                            dgvRegentes.Rows[e.RowIndex].Cells["Aplicar"].Value = true;
                        }
                        else
                            dgvRegentes.Rows[e.RowIndex].Cells["Aplicar"].Value = false;

                        if (txtFiltro.Text.Equals(""))
                        {
                            foreach (DataGridViewRow row in dgvRegentes.Rows)
                            {
                                if (!(bool)row.Cells["Aplicar"].Value)
                                {
                                    masivo = false;
                                }
                            }
                        }
                        else
                            masivo = false;

                        dgvRegentes.EndEdit();

                        if (masivo)
                            chkMasivo.Checked = true;
                        else
                            chkMasivo.Checked = false;
                    }
                }
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
    }
}
