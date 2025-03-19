using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ExcelInterop = Microsoft.Office.Interop.Excel;

namespace KOLEGIO
{
    public partial class frmCobrosCanonesAnuales : Form
    {
        private int totalRegistros = 0;
        private int totalRegistrosExitosos = 0;
        private int totalRegistrosErroneos = 0;
        private string articulo = "", canonPedido = "", idVendedor = "";
        private bool esPeritaje = false, esConsultora = false, esEstable = false, esViaAerea = false, esPlaguicida = false;
        private FuncsInternas fInternas;

        public frmCobrosCanonesAnuales()
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            if(Globales.PERMITIR_PERITO == "S")
                cmbProcesos.agregarItems("Peritajes");

            cmbProcesos.agregarItems("Consultoras");
            cmbProcesos.agregarItems("Establecimientos");

            if (Globales.MANEJO_VIA_AEREA == "S")
                cmbProcesos.agregarItems("Idóneos Recetar Vía Aérea");
            if (Globales.MANEJO_PLAGUICIDAS == "S")
                cmbProcesos.agregarItems("Idóneos Investigación Plaguicidas");
            //cmbProcesos.Index = 0;

            cmbProcesos.SelectedValueChanged(new EventHandler(OnProcesosChanged));
        }

        private void bwProceso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = e.ProgressPercentage;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Se esta trabajando en este proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgvCanones.RowCount > 0)
            {
                limpiarEstadoCeldas();
                btnSalir.Enabled = false;
                btnProcesar.Enabled = false;
                desactivarLabels();
                fInternas.deshabilitarOrdenDgv(ref dgvCanones);
                CheckForIllegalCrossThreadCalls = false;
                pbProceso.Minimum = 0;
                pbProceso.Maximum = dgvCanones.RowCount + 1;
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
            generarCanones();
        }

        private void bwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSalir.Enabled = true;
            btnProcesar.Enabled = true;
            fInternas.habilitarOrdenDgv(ref dgvCanones);
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

        private void OnProcesosChanged(object sender, EventArgs e)
        {
            //if (onChanged)
            //{
            revisarCanonAGenerar();
            //}
        }

        private void revisarCanonAGenerar()
        {
            if (cmbProcesos.Texto == "Peritajes")
            {
                esPeritaje = true;
                esPlaguicida = false;
                esViaAerea = false;
                esConsultora = false;
                esEstable = false;
                canonPedido = "PER";//Identificador Canon en tabla NV_HISTORIAL_CANONES_ANUALES
                idVendedor = "PER";
                articulo = Globales.ARTICULO_COBRO_PERITAJES;
            }
            else if (cmbProcesos.Texto == "Idóneos Investigación Plaguicidas")
            {
                esPeritaje = false;
                esPlaguicida = true;
                esViaAerea = false;
                esConsultora = false;
                esEstable = false;
                canonPedido = "PLAGUI";
                idVendedor = "IDO";
                articulo = Globales.ARTICULO_COBRO_PLAGUICIDAS;
            }
            else if (cmbProcesos.Texto == "Idóneos Recetar Vía Aérea")
            {
                esPeritaje = false;
                esPlaguicida = false;
                esViaAerea = true;
                esConsultora = false;
                esEstable = false;
                canonPedido = "AEREA";
                idVendedor = "VIA";
                articulo = Globales.ARTICULO_COBRO_VIA_AEREA;
            }
            else if (cmbProcesos.Texto == "Consultoras")
            {
                esPeritaje = false;
                esPlaguicida = false;
                esViaAerea = false;
                esConsultora = true;
                esEstable = false;
                canonPedido = "CONSUL";
                idVendedor = "CIA";
                articulo = Globales.ARTICULO_COBRO_CONSULTORAS;
            }
            else
            {
                esPeritaje = false;
                esPlaguicida = false;
                esViaAerea = false;
                esConsultora = false;
                esEstable = true;
                canonPedido = "ESTABLE";
                idVendedor = "EST";
                articulo = "";
            }
        }

        private void limpiarEstadoCeldas()
        {
            foreach (DataGridViewRow row in dgvCanones.Rows)
            {
                row.Cells["colResultado"].Value = iList.Images[0];
                row.Cells["colObservaciones"].Value = "";
            }
        }

        private bool validarAñoCobro(string añoCobro)
        {
            bool validar = true;
            DateTime fechaCierreCobro = new DateTime(DateTime.Now.AddYears(1).Year, 1, 1);
            fechaCierreCobro = fechaCierreCobro.AddMonths(1).AddDays(-1); //La fecha cierre de los canones anuales es el ultimo dia de enero del año siguiente actual

            if (añoCobro.Equals(""))
                return validar;
            
            DateTime ultimoAño = new DateTime(int.Parse(añoCobro),1,1);
            ultimoAño = ultimoAño.AddMonths(1).AddDays(-1);
            
            int result = DateTime.Compare(fechaCierreCobro.Date, ultimoAño.Date);
            //DateTime.Compare(f1, f2);
            //f1==f2 -> 0
            //f1>f2 -> 1
            //f1<f2 -> -1
            if (result <= 0)
                validar = false;

            return validar;
        }

        private void generarCanones()
        {
            string error = "";
            int progreso = 1;
            bwProceso.ReportProgress(progreso);

            if (articulo.Equals(""))
                revisarCanonAGenerar();

            foreach (DataGridViewRow row in dgvCanones.Rows)
            {
                bool OK = true;
                //string referenciaCobro = "colegiatura";
                DataTable dtCliente = new DataTable();
                DataTable dtNit = new DataTable();
                int AñoCobro = 0, AñoCobroActualizado = 0, añoActual = DateTime.Now.Year;
                DateTime AñoCobro2 = DateTime.Now, AñoCobroActualizado2 = DateTime.Now, añoActual2 = new DateTime(DateTime.Now.Year, 1, 1); ;
                string sSelect = "";
                string sSelectCl = "";
                //string IdColegiado_CedJuridica = "";
                DataTable dtAplicaClie = new DataTable();
                //DateTime fechaActu = DateTime.Now;
                //DateTime mesCobro = DateTime.Now;
                //fechaActu = new DateTime(fechaActu.Year, fechaActu.Month, /*DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Day*/ 25);
                //fechaActu = new DateTime(DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).Year, 1, 1);

                if (validarAñoCobro(row.Cells["colUltimoCobro"].Value.ToString()))
                //if (row.Cells["colUltimoCobro"].Value.ToString().Equals("") || int.Parse(row.Cells["colUltimoCobro"].Value.ToString()) < añoActual)
                {
                    try
                    {
                        Consultas.sqlCon.iniciaTransaccion();

                        if (esPeritaje || esPlaguicida || esViaAerea)
                        {
                            //sSelect = "select AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = (select distinct CodigoPlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO where NumeroColegiado = '" + row.Cells["colIdentificador"].Value.ToString() + "') and AplicaClienteErp = 'S'";
                            sSelect = "select AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla =" +
                            " (SELECT t3.CodigoPlantilla FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 ON t3.CodigoPlantilla = t2.CodigoPlantilla where t1.IdColegiado = '" + row.Cells["colIdentificador"].Value.ToString() + "')" +
                            " and AplicaClienteErp = 'S'";
                            OK = Consultas.fillDataTable(sSelect, ref dtAplicaClie, ref error);

                            if (OK && dtAplicaClie.Rows.Count > 0 && dtNit.Rows.Count == 0)
                            {
                                sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NIT where NIT = '" + row.Cells["colIdentificador"].Value.ToString() + "'";
                                OK = Consultas.fillDataTable(sSelectCl, ref dtNit, ref error);

                                if (OK)
                                    OK = fInternas.generarNit(row.Cells["colCedulaJuridica"].Value.ToString(), row.Cells["colIdentificador"].Value.ToString(), ref dtCliente, "colegiado", ref error);
                            }//Lleva elcampo cedula juridica pero se envia la cedula del colegiado

                            if (OK && dtAplicaClie.Rows.Count > 0 && dtCliente.Rows.Count == 0)
                            {
                                sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + row.Cells["colIdentificador"].Value.ToString() + "'";
                                OK = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

                                if (OK)
                                    OK = fInternas.generarCliente(row.Cells["colIdentificador"].Value.ToString(), ref dtCliente, "colegiado", "C", ref error);
                            }
                        }
                        else
                        {

                            if (!row.Cells["colCedulaJuridica"].Value.ToString().Equals(""))
                            {
                                if (OK)
                                {
                                    sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NIT where NIT = '" + row.Cells["colCedulaJuridica"].Value.ToString() + "'";
                                    OK = Consultas.fillDataTable(sSelectCl, ref dtNit, ref error);

                                    if (OK && dtNit.Rows.Count == 0)
                                    {
                                        if (esEstable)
                                            OK = fInternas.generarNit(row.Cells["colCedulaJuridica"].Value.ToString(), row.Cells["colIdentificador"].Value.ToString(), ref dtCliente, "estable", ref error);
                                        else
                                            OK = fInternas.generarNit(row.Cells["colCedulaJuridica"].Value.ToString(), row.Cells["colIdentificador"].Value.ToString(), ref dtCliente, "consul", ref error);
                                    }


                                }

                                if (OK)
                                {
                                    sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + row.Cells["colIdentificador"].Value.ToString() + "'";
                                    OK = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

                                    if (OK && dtCliente.Rows.Count == 0)
                                    {
                                        if (esEstable)
                                            OK = fInternas.generarCliente(row.Cells["colIdentificador"].Value.ToString(), ref dtCliente, "estable", "C_A", ref error);
                                        else
                                            OK = fInternas.generarCliente(row.Cells["colIdentificador"].Value.ToString(), ref dtCliente, "consul", "C_A", ref error);
                                    }

                                }
                            }
                            else
                            {
                                OK = false;
                                error = "No se encontro la cedula juridica para la creacion del NIT.";
                            }
                        }

                        if (OK)
                            OK = fInternas.verificarAceptaDocElectronicoClienteERP(row.Cells["colIdentificador"].Value.ToString(), ref error);

                        if (OK)
                        {
                            if (!row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                            {
                                int año = int.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                                AñoCobro2 = new DateTime(año,1,1);
                                AñoCobro2 = AñoCobro2.AddMonths(1).AddDays(-1);
                                AñoCobroActualizado2 = AñoCobro2.AddYears(1);
                                //AñoCobro = int.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                                //AñoCobroActualizado = AñoCobro + 1;
                            }
                            else
                            {
                                AñoCobro2 = añoActual2;
                                AñoCobro2 = AñoCobro2.AddMonths(1).AddDays(-1);
                                AñoCobroActualizado2 = AñoCobro2.AddYears(1);
                            }
                            //if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                            //{
                            //    mesCobro = new DateTime(mesCobro.Year, mesCobro.Month, /*mesCobro.Day*/ 25);
                            //}
                            //else
                            //{
                            //    DateTime ActualizarCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                            //    mesCobro = new DateTime(ActualizarCobro.Year, ActualizarCobro.Month,/*mesCobro.Day*/ 25).AddMonths(1);
                            //    //mesUltCobro = mesUltCobro.AddMonths(1);
                            //}
                            //mesCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).AddMonths(1);
                            

                            OK = generarPedido(row.Cells["colIdentificador"].Value.ToString(), row.Cells["colCedulaJuridica"].Value.ToString(), /*dtPedido,*/ row.Cells["colCobrador"].Value.ToString(), AñoCobroActualizado2.ToString("yyyy"), row.Cells["colNombre"].Value.ToString(), ref error);
                            
                        }

                        if (OK)
                        {
                            //DateTime ultimoCobro = new DateTime(AñoCobroActualizado, 1, 1);
                            OK = actualizarUltAñoCobro(row.Cells["colIdentificador"].Value.ToString(), AñoCobroActualizado2, canonPedido, ref error);
                        }
                            

                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            totalRegistrosExitosos += 1;
                            row.Cells["colResultado"].Value = iList.Images[2];
                            row.Cells["colObservaciones"].Value = "¡Proceso exitoso!";
                            actualizarAñoCobro(row.Cells["colIdentificador"].Value.ToString(), AñoCobroActualizado2.ToString("yyyy"));
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
                    row.Cells["colObservaciones"].Value = "Ya se le cobró el año actual a este colegiado";

                }


                progreso += 1;
                bwProceso.ReportProgress(progreso);
            }
        }

        private void actualizarAñoCobro(string id, string NuevoAñoCobro)
        {

            foreach (DataGridViewRow row in dgvCanones.Rows)
            {
                if (id == row.Cells["colIdentificador"].Value.ToString())
                {
                    row.Cells["colUltimoCobro"].Value = NuevoAñoCobro;
                    break;
                }
            }


        }

        private bool actualizarUltAñoCobro(string id, DateTime ultimoCobro, string idCanon, ref string error)
        {
            bool OK = true;
            string sUpdate = "";
            string sInsert = "";
            string sSelect = "";
            DateTime mesUltCobro = DateTime.Now;
            DataTable dt = new DataTable();


            string año = "";
            año = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");

            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + id + "'  and Canon = '"+idCanon+"'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count > 0)
            {
                sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES set AñoUltimoCobro = '" + año + "' where Identificador = '" + id + "'  and Canon = '" + idCanon + "'";

                OK = Consultas.ejecutarSentencia(sUpdate, ref error);
            }
            else
            {
                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon, AñoUltimoCobro) values ('" + id + "', '" + idCanon + "', '" + año + "')";

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

        private bool generarPedido(string identificador, string cedJuridica, string cobrador, string ultimoCobro,string NombreCia, ref string error)
        {
            decimal montoDesc = 0;
            int porcDescuento = 0, indiceArticulo = 0;
            bool pedidoPorConcepto = false, OK = true;
            string sQuery = "", factura = "", comentario = "";
            DataTable dtArticulos = new DataTable();

            //DateTime mesUltCobro = DateTime.Now;
            
            if (esEstable)
            {
                
                sQuery = "SELECT TOP 1 t3.ARTICULO, t3.DESCRIPCION,t4.PRECIO, '1' as CANTIDAD, t1.NombreCategoria, '0' DESCUENTO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ESTABLE_ART t2 ON t2.CodigoCategoria = t1.CodigoCategoria" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                        " WHERE t1.NumRegistroEstablecimiento = '"+ identificador + "'"+
                        " AND t4.PRECIO = (SELECT MAX(PRECIO) FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ESTABLE_ART t2 ON t2.CodigoCategoria = t1.CodigoCategoria" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                        " WHERE t1.NumRegistroEstablecimiento = '" + identificador + "')";
                
            }
            else
            {
                if (!articulo.Equals(""))
                {
                    sQuery = "SELECT t1.ARTICULO, t1.DESCRIPCION,t2.PRECIO, '1' as CANTIDAD, '0' DESCUENTO FROM " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t1" +
                         " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 on t2.ARTICULO = t1.ARTICULO" +
                         " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                         " WHERE t1.ARTICULO = '" + articulo + "'";
                    
                }
                else
                {
                    error = "No se pudo obtener el articulo para aplicar el proceso";
                    OK = false;
                }
            }

            

            if (OK)
            {
                if (Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
                {
                    //if (ultimoCobro.Equals(""))
                    //{
                    //    ultimoCobro = mesUltCobro.ToString("MM/yyyy");
                    //}
                    //else
                    //{
                    //    ultimoCobro = DateTime.Parse(ultimoCobro).ToString("MM/yyyy");
                    //}

                    if (dtArticulos.Rows.Count > 0)
                    {
                        if (esEstable)
                            comentario = generarComentario(ultimoCobro, "", dtArticulos.Rows[0]["NombreCategoria"].ToString());
                        else
                            comentario = generarComentario(ultimoCobro, NombreCia, "");

                        //OK = controlerBD.crearPedidoGenerico(dtArticulos, identificador, ref pedido, montoDesc, porcDescuento, pedidoPorConcepto, indiceArticulo, cobrador, "C_A", "PEDIDOS", idVendedor, comentario, "", ref error);
                        OK = controlerBD.FacturarSinPedido(dtArticulos, identificador, ref factura, montoDesc, porcDescuento, pedidoPorConcepto, indiceArticulo, cobrador, "C_A", "FACTURAS", idVendedor, comentario, comentario, string.Empty, string.Empty, ref error);
                    }
                    else
                    {
                        OK = false;
                        error = "Error obteniendo los artículos de la categoría";
                    }
                }
                else
                    OK = false;
            }

            return OK;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            //if (!chkGenTotal.Checked)
            refrescarDatos();
            //else
            //    refrescarDatosGeneracionTotal();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvCanones.RowCount == 0)
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

                //colFechas.Add("colUltimoCobro");
                //colFechas.Add("Desde");
                //colFechas.Add("Hasta");

                int columnas = dgvCanones.ColumnCount;
                int rows = dgvCanones.RowCount;
                object[] Header = new object[columnas];

                // column headings               
                for (int i = 0; i < columnas; i++)
                {
                    if (dgvCanones.Columns[i].HeaderText != "Detalle Carga")
                    {
                        if (dgvCanones.Columns[i].Visible == true)
                            Header[i] = dgvCanones.Columns[i].HeaderText;
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
                            if (dgvCanones.Columns[i].HeaderText == colFechas[k])
                            {
                                if (dgvCanones[i, j].Value.ToString() != "")
                                    Cells[j, i] = DateTime.Parse(dgvCanones[i, j].Value.ToString()).ToString("yyyy-MM");
                                else
                                    Cells[j, i] = "";
                                fecha = true;
                                break;
                            }
                        }
                        if (!fecha && (dgvCanones.Columns[i].HeaderText != "Detalle Carga" && dgvCanones.Columns[i].Visible == true))
                            if (dgvCanones[i, j].Value != null)
                                Cells[j, i] = dgvCanones[i, j].Value.ToString();
                            else
                                Cells[j, i] = "";

                    }

                }

                Worksheet.Name = "Proceso Cobros Canones Anuales";
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

        private string generarComentario(string añoCobro, string Cia, string Categ)
        {
            string comentario = "";

            if (esPeritaje)
                comentario = "Canon Peritos - " + añoCobro + "";

            if (esPlaguicida)
                comentario = "Canon Idóneos - " + añoCobro + "";

            if (esViaAerea)
                comentario = "Canon Vía aérea - " + añoCobro + "";

            if (esEstable)
                comentario = "Canon "+ añoCobro + " - " + Categ + "";

            if (esConsultora)
                comentario = "Canon " + añoCobro + " - " + Cia + "";

            return comentario;
        }

        private void refrescarDatos()
        {
            string sQuery = "";
            #region REAL
            if (esPeritaje)
            {
                //sQuery = "SELECT t1.IdColegiado, t2.NumeroColegiado, t2.Nombre, t1.Cobrador FROM "+Consultas.sqlCon.COMPAÑIA+".NV_PERITOS t1"+
                //" INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado WHERE t1.PagaCanon = 'S'";
                sQuery = "SELECT t1.IdColegiado, t2.Cedula, t2.NumeroColegiado, t2.Nombre, t1.Cobrador, t3.AñoUltimoCobro, t2.Email FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS t1" +
                        " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado" +
                        " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t3 ON t3.Identificador = t1.IdColegiado AND t3.canon = 'PER'" +
                        " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_EMPRESAS t4 ON t4.CodigoEmpresa = t1.CodigoEmpresa" +
                        " WHERE t4.PagaCanon = 'S' AND t1.FechaSesionPerdida is null AND t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')";
            }

            if (esPlaguicida)
            {
                //sQuery = "SELECT DISTINCT t1.IdColegiado, t2.NumeroColegiado, t2.Nombre, t2.Cobrador FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t1" +
                //" INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado WHERE t1.PagaCanon = 'S'";
                sQuery = "SELECT DISTINCT t1.IdColegiado, t2.Cedula, t2.NumeroColegiado, t2.Nombre, t2.Cobrador, t3.AñoUltimoCobro, t2.Email FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t1" +
                        " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado" +
                        " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t3 ON t3.Identificador = t1.IdColegiado AND t3.canon = 'PLAGUI'" +
                        " WHERE t2.PagaCanonPlagui = 'S' AND t1.Activo = 1 AND t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')";
            }

            if (esViaAerea)
            {
                //sQuery = "SELECT DISTINCT t1.IdColegiado, t2.NumeroColegiado, t2.Nombre, t2.Cobrador FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO t1" +
                //" INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado WHERE t1.PagaCanon = 'S'";
                sQuery = "SELECT DISTINCT t1.IdColegiado, t2.Cedula, t2.NumeroColegiado, t2.Nombre, t2.Cobrador, t3.AñoUltimoCobro, t2.Email FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO t1" +
                        " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado" +
                        " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t3 ON t3.Identificador = t1.IdColegiado AND t3.canon = 'AEREA'" +
                        " WHERE t2.PagaCanonAerea = 'S' AND t1.Activo = 1 AND t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')";
            }

            if (esConsultora)
            {
                //sQuery = "SELECT t1.Codigo, t1.CedulaJuridica, t1.Nombre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS t1 INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t2 ON t2.CodigoEstado = t1.Estado WHERE t1.PagaCanon = 'S' and t2.GeneraCobro = 'S'";
                sQuery = "SELECT t1.Codigo, t1.CedulaJuridica as Cedula, t1.Nombre, t1.Cobrador, t3.AñoUltimoCobro, t1.Email FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS t1" +
                        " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t2 ON t2.CodigoEstado = t1.Estado" +
                        " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t3 ON t3.Identificador = t1.Codigo AND t3.canon = 'CONSUL'" +
                        " WHERE t1.PagaCanon = 'S' and t2.GeneraCobro = 'S'";//Agregar cobrador
            }

            if (esEstable)
            {
                //sQuery = "SELECT t1.NumRegistro as Codigo, t1.CedulaJuridica, t1.Nombre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t1 INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t2 ON t2.CodigoEstado = t1.Estado WHERE t1.PagaCanon = 'S' and t2.GeneraCobro = 'S'";
                sQuery = "SELECT t1.NumRegistro as Codigo, t1.CedulaJuridica as Cedula, t1.Nombre, t1.Cobrador, t3.AñoUltimoCobro, t1.Email FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t1" +
                        " INNER JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t2 ON t2.CodigoEstado = t1.Estado" +
                        " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t3 ON t3.Identificador = t1.NumRegistro  AND t3.canon = 'ESTABLE'" +
                        " WHERE t1.PagaCanon = 'S' and t2.GeneraCobro = 'S'";
            }
            #endregion

            DataTable dtIngresos = new DataTable();

            string error = "";
            try
            {
                if(Consultas.fillDataTable(sQuery,ref dtIngresos,ref error))
                {
                    //dgvColegiados.DataSource = dtIngresos;
                    dgvCanones.Rows.Clear();
                    totalRegistros = 0;
                    desactivarLabels();
                    foreach (DataRow row in dtIngresos.Rows)
                    {
                        if (row["AñoUltimoCobro"].ToString().Equals(""))
                        {
                            if (esPeritaje || esPlaguicida || esViaAerea)
                            {
                                totalRegistros += 1;
                                dgvCanones.Rows.Add(row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NumeroColegiado"].ToString(),
                                    row["Nombre"].ToString(), row["Email"].ToString(), row["AñoUltimoCobro"].ToString() != "" ? DateTime.Parse(row["AñoUltimoCobro"].ToString()).ToString("yyyy") : "", row["Cobrador"].ToString());
                                dgvCanones.Columns["colCedulaJuridica"].Visible = false;
                                dgvCanones.Columns["colNumeroColegiado"].Visible = true;
                            }

                            if (esConsultora || esEstable)
                            {
                                totalRegistros += 1;
                                dgvCanones.Rows.Add(row["Codigo"].ToString(), row["Cedula"].ToString(), string.Empty,
                                    row["Nombre"].ToString(), row["Email"].ToString(), row["AñoUltimoCobro"].ToString() != "" ? DateTime.Parse(row["AñoUltimoCobro"].ToString()).ToString("yyyy") : "", row["Cobrador"].ToString());
                                dgvCanones.Columns["colNumeroColegiado"].Visible = false;
                                dgvCanones.Columns["colCedulaJuridica"].Visible = true;
                            }
                        }
                        else
                        {
                            DateTime fechaCierreCobro = new DateTime(DateTime.Now.AddYears(1).Year, 1, 1);
                            fechaCierreCobro = fechaCierreCobro.AddMonths(1).AddDays(-1); //La fecha cierre de los canones anuales es el ultimo dia de enero del año siguiente actual
                            DateTime fecha = DateTime.Parse(row["AñoUltimoCobro"].ToString());
                            //fechaactual = DateTime(fechaactual.Year, 1, 31);
                            //fecha = new DateTime(fecha.Year, 1, 1);
                            int result = DateTime.Compare(fechaCierreCobro.Date, fecha.Date);
                            //DateTime.Compare(f1, f2);
                            //f1==f2 -> 0
                            //f1>f2 -> 1
                            //f1<f2 -> -1
                            if (result > 0)
                            {
                                if (esPeritaje || esPlaguicida ||esViaAerea)
                                {
                                    totalRegistros += 1;
                                    dgvCanones.Rows.Add(row["IdColegiado"].ToString(), row["Cedula"].ToString(), row["NumeroColegiado"].ToString(),
                                        row["Nombre"].ToString(), row["Email"].ToString(), row["AñoUltimoCobro"].ToString() != "" ? DateTime.Parse(row["AñoUltimoCobro"].ToString()).ToString("yyyy") : "", row["Cobrador"].ToString());
                                    dgvCanones.Columns["colCedulaJuridica"].Visible = false;
                                    dgvCanones.Columns["colNumeroColegiado"].Visible = true;
                                }

                                if (esConsultora || esEstable)
                                {
                                    totalRegistros += 1;
                                    dgvCanones.Rows.Add(row["Codigo"].ToString(), row["Cedula"].ToString(), string.Empty,
                                        row["Nombre"].ToString(), row["Email"].ToString(), row["AñoUltimoCobro"].ToString() != "" ? DateTime.Parse(row["AñoUltimoCobro"].ToString()).ToString("yyyy") : "", row["Cobrador"].ToString());
                                    dgvCanones.Columns["colNumeroColegiado"].Visible = false;
                                    dgvCanones.Columns["colCedulaJuridica"].Visible = true;
                                }
                            }
                        }

                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void refrescarDatosGeneracionTotal()
        //{
        //    string sQuery = "SELECT t1.IdColegiado,t1.NumeroColegiado,t1.Nombre,t2.MesUltimoCobro as UltMesCobro, t1.Cobrador" +
        //                    " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
        //                    " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS t2 ON t2.IdColegiado = t1.IdColegiado";
        //    DataTable dtIngresos = new DataTable();
        //    string error = "";
        //    try
        //    {
        //        if (Consultas.fillDataTable(sQuery, ref dtIngresos, ref error))
        //        {
        //            //dgvColegiados.DataSource = dtIngresos;
        //            dgvCanones.Rows.Clear();
        //            totalRegistros = 0;
        //            desactivarLabels();
        //            foreach (DataRow row in dtIngresos.Rows)
        //            {
        //                if (row["UltMesCobro"].ToString().Equals(""))
        //                {
        //                    totalRegistros += 1;
        //                    dgvCanones.Rows.Add(row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
        //                        row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
        //                }
        //                else
        //                {
        //                    DateTime fechaactual = DateTime.Now;
        //                    DateTime fecha = DateTime.Parse(row["UltMesCobro"].ToString());
        //                    fechaactual = new DateTime(fechaactual.Year, fechaactual.Month, 1);
        //                    fecha = new DateTime(fecha.Year, fecha.Month, 1);
        //                    int result = DateTime.Compare(fecha, fechaactual);
        //                    if (result < 0)
        //                    {
        //                        totalRegistros += 1;
        //                        dgvCanones.Rows.Add(row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
        //                            row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
        //                    }
        //                }
        //                //totalRegistros += 1;
        //                //dgvColegiados.Rows.Add(row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
        //                //    row["Nombre"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["Cobrador"].ToString());
        //            }
        //            lblRegistrosCant.Text = totalRegistros.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvCanones.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        //private void txtCondicion_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    if (!txtCultivo.ReadOnly)
        //    {
        //        listaCondiciones();
        //    }
        //}


        //private void listaCondiciones()
        //{
        //    Listado listD = new Listado();
        //    listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición,CodigoPlantilla";
        //   // listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición";
        //    listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listD.TABLA = "NV_CONDICIONES";
        //    listD.FILTRO = "where CondicionFallecido != 'S' and CondicionFallecido != 'S' and CodigoCondicion != 'C-07' and  CodigoCondicion != 'C-10' and  CodigoCondicion != 'C-11' and  CodigoCondicion != 'C-13'";
        //    listD.TITULO_LISTADO = "Condiciones Colegiado";
        //    listD.COLUMNAS_OCULTAS.Add("CodigoPlantilla");

        //    frmF1 f1 = new frmF1(listD);
        //    f1.ShowDialog();
        //    if (f1.item != null)
        //    {
        //        txtCultivo.Text = f1.item.SubItems[0].Text;
        //        txtDescCultivo.Text = f1.item.SubItems[1].Text;
        //        refrescarDatos();
        //    }
        //}

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            refrescarDatos();
        }

        private void limpiar()
        {
            if(dgvCanones.Rows.Count > 0)
            {
                dgvCanones.Rows.Clear();
            }
            
        }

        //private void txtCondicion_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == (char)Keys.F1 && !txtCultivo.ReadOnly)
        //    {
        //        listaCondiciones();
        //    }
        //}

        //private void txtCondicion_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void chkGenTotal_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (chkGenTotal.Checked)
        //    {
        //        txtCultivo.ReadOnly = true;
        //        txtCultivo.Clear();
        //        txtDescCultivo.Clear();
        //        refrescarDatosGeneracionTotal();
        //    }
        //    else
        //    {
        //        limpiar();
        //        txtCultivo.ReadOnly = false;
        //    }
            
        //}
    }
}
