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
    public partial class frmLevantamiento : Form
    {
        private FuncsInternas fInternas;
        private string oldValue = "";

        public frmLevantamiento()
        {
            InitializeComponent();
            txtMeses.Text = "1";
            txtMesesArreglo.Text = "0";
            txtPorcPrima.Text = "0";
            txtMontoPrima.Text = "0";
            txtMontoArreglo.Text = "0";
            this.fInternas = new FuncsInternas();
        }

        private void txtColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaColegiados();
        }


        private void listaColegiados()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado, NumeroColegiado as Colegiado, Nombre, Cobrador, Condicion, (select t1.NombreCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1 where t1.CodigoCondicion = Condicion) as Condición";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where Condicion in (select CodigoCondicion from "+Consultas.sqlCon.COMPAÑIA+".NV_CONDICIONES where RequiereLevantamiento = 'S')";
            listP.COLUMNAS_PK.Add("IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("Cobrador");
            listP.COLUMNAS_OCULTAS.Add("Condicion");

            listP.ORDERBY = "order by IdColegiado";
            listP.TITULO_LISTADO = "Colegiados";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                txtColegiado.Text = f1Colegiado.item.SubItems[0].Text;
                txtNumeroColegiado.Valor = f1Colegiado.item.SubItems[1].Text;
                txtNombreColegiado.Text = f1Colegiado.item.SubItems[2].Text;
                txtCobrador.Text = f1Colegiado.item.SubItems[3].Text;
                txtCondicion.Text = f1Colegiado.item.SubItems[4].Text;
                txtDescCondicion.Text = f1Colegiado.item.SubItems[5].Text;

                refrescar();
            }
        }

        private void buscaColegiado(string codigo)
        {

            if (txtNumeroColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                refrescar();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado,NumeroColegiado,Nombre,Cobrador, Condicion, (select t1.NombreCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1 where t1.CodigoCondicion = Condicion) as NombreCondicion";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where NumeroColegiado = '" + codigo + "' and Condicion in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where RequiereLevantamiento = 'S')";
            string error = "";
            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNombreColegiado.Text = dtColegiado.Rows[0]["Nombre"].ToString();
                    txtColegiado.Text = dtColegiado.Rows[0]["IdColegiado"].ToString();
                    txtNumeroColegiado.Valor = dtColegiado.Rows[0]["NumeroColegiado"].ToString();
                    txtCobrador.Text = dtColegiado.Rows[0]["Cobrador"].ToString();
                    txtCondicion.Text = dtColegiado.Rows[0]["Condicion"].ToString();
                    txtDescCondicion.Text = dtColegiado.Rows[0]["NombreCondicion"].ToString();
                    //cargarUltimoMes(txtColegiado.Text);
                    refrescar();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe o no pertenece a una condición de levantamiento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtColegiado.Clear();
                        txtNombreColegiado.Clear();
                        txtNumeroColegiado.Clear();
                        txtCobrador.Clear();
                        txtCondicion.Clear();
                        refrescar();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtColegiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaColegiados();
        }

        private void txtColegiado_Leave(object sender, EventArgs e)
        {
            buscaColegiado(txtNumeroColegiado.Valor);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        //private void cargarUltimoMes(string colegiado)
        //{
        //    string sQuery = "select distinct MesUltimoCobro from "+Consultas.sqlCon.COMPAÑIA+ ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + colegiado+"'";

        //    DataTable dt = new DataTable();
        //    string error = "";
            

        //    Cursor.Current = Cursors.WaitCursor;
        //    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
        //    {
        //        if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["MesUltimoCobro"].ToString()))
        //        {
        //            mtbMesUltimoCobro.TextMaskFormat = mfMask;
        //            mtbMesUltimoCobro.Text = DateTime.Parse(dt.Rows[0]["MesUltimoCobro"].ToString()).ToString("MM/yyyy");
        //        }
        //        else
        //        {
        //            mtbMesUltimoCobro.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        //            mtbMesUltimoCobro.Text = "";
        //        }
        //    }
        //    else
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    Cursor.Current = Cursors.Default;
        //}

        //private bool actualizarUltMesCobro(string colegiado, DateTime ultimoCobro, int mesesAdelanto, ref string error)
        //{
        //    bool OK = true;
        //    string sUpdate = "";
        //    string sSelect = "";
        //    string sInsert = "";
        //    DataTable dt = new DataTable();
        //    DateTime mesUltCobro = DateTime.Now;
        //    //if (ultimoCobro.Equals("") || ultimoCobro.Equals("  /"))
        //    //{
        //    //    mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 1);
        //    //}
        //    //else
        //    //{
        //    //    mesUltCobro = DateTime.Parse(ultimoCobro);
        //    //}
        //    string mes = "";


        //    sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + colegiado + "'";

        //    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

        //    if (OK && dt.Rows.Count > 0)
        //    {
        //        ultimoCobro = ultimoCobro.AddMonths(mesesAdelanto);
        //        mes = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");
        //        sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "'";

        //        OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //    }
        //    else
        //    {
        //        //if (mesesAdelanto > 1)//Si son mas de un mes le sumo todos menos el actual
        //        //{
        //        //  mesesAdelanto = mesesAdelanto - 1;
        //        ultimoCobro = ultimoCobro.AddMonths(mesesAdelanto);
        //        //}

        //        mes = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");
        //        sInsert = "insert into " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS (IdColegiado,MesUltimoCobro) values ('" + colegiado + "', '" + mes + "')";

        //        OK = Consultas.ejecutarSentencia(sInsert, ref error);

        //    }

        //    return OK;
        //}

        private void refrescar()
        {    
            string sQuery = "select t1.CodigoArticulo AS ARTICULO, t2.DESCRIPCION as DESCRIPCION, t3.PRECIO as PRECIO, '1' AS CANTIDAD" +
                            " from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t2 on t2.ARTICULO = t1.CodigoArticulo" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t3 on t3.ARTICULO = t1.CodigoArticulo" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t3.NIVEL_PRECIO AND t6.VERSION = t3.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                            " where t1.CodigoCondicion = '" + txtCondicion.Text + "'";

            DataTable dt = new DataTable();
            string error = "";
            Cursor.Current = Cursors.WaitCursor;
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                //dgvRubros.DataSource = dt;
                dgvRubros.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvRubros.Rows.Add(row["ARTICULO"].ToString(), row["CANTIDAD"].ToString(), row["DESCRIPCION"].ToString(), decimal.Parse(row["PRECIO"].ToString()).ToString("N2"));
                }
                //dgvRubros.Columns["colPrecio"].DefaultCellStyle.Format = "c";
                dgvRubros.Columns["colPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRubros.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                cargarMeses(txtColegiado.Text,ref error);
                cargarMesesDgv(ref dgvRubros, ref error);
                cargarPendientes();

                calcular();
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            Cursor.Current = Cursors.Default;
        }

        private void cargarPendientes()
        {
            string error = "";
            DataTable dt = new DataTable();

            
            //string sQueryDetalle = "select t1.DOCUMENTO,APLICACION,FECHA,MONTO,SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
            //            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
            //            " where t1.CLIENTE = '" + txtColegiado.Text + "' and t1.SALDO > 0 and (t1.TIPO = 'FAC' or t1.TIPO = 'O/D')";

            //Todo lo que tenga pendiente(en cuentas por cobrar)
            string sQueryDetalle = "select t1.DOCUMENTO,APLICACION,FECHA,MONTO,SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
                        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
                        " where t1.CLIENTE = '" + txtColegiado.Text + "' and t1.SALDO > 0";


            dt = new DataTable();

            if (Consultas.fillDataTable(sQueryDetalle, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    dgvGestionCobro.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvGestionCobro.Rows.Add(row["DOCUMENTO"].ToString(), row["APLICACION"].ToString(), row["FECHA"].ToString() != "" ? DateTime.Parse(row["FECHA"].ToString()).ToString("dd/MM/yyyy") : "", decimal.Parse(row["MONTO"].ToString()).ToString("N2"), decimal.Parse(row["SALDO"].ToString()).ToString("N2"));
                    }
                    dgvGestionCobro.Columns["colMonto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvGestionCobro.Columns["colMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvGestionCobro.Columns["colSaldo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvGestionCobro.Columns["colSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    dgvGestionCobro.Rows.Clear();
                }

            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarMeses(string colegiado, ref string error)
        {
            bool OK = true;
            DateTime fechaAprobacion = DateTime.Now;
            DateTime fechaActual = DateTime.Now;
            //string query = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '"+txtCondicionIni.Text+"'";

            string query = "select  FechaAprobacion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '" + txtCondicion.Text + "' and FechaAprobacion = (select MAX(FechaAprobacion) from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '" + txtCondicion.Text + "')";

            DataTable dt = new DataTable();

            OK = Consultas.fillDataTable(query, ref dt, ref error);

            if (OK)
            {
                if (dt.Rows.Count > 0)
                {
                    fechaAprobacion = DateTime.Parse(dt.Rows[0]["FechaAprobacion"].ToString());
                    txtMeses.Text = fInternas.GetMonthDifference(fechaAprobacion, fechaActual, ref error).ToString();
                }
                else
                {
                    txtMeses.Text = "1";
                }
            }




            //string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART where CodigoCondicion = '" + txtCondicion.Text + "' and ArticuloFms = 'S'";

            //DataTable dtArticuloFms = new DataTable();

            //if (OK)
            //{
            //    OK = Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error);

            //    if (dtArticuloFms.Rows.Count > 0)
            //    {
            //        foreach (DataGridViewRow row in dgvArt.Rows)
            //        {
            //            if (dtArticuloFms.Rows[0][0].ToString() == row.Cells["ARTICULO"].Value.ToString())
            //            {
            //                int meses = 1;
            //                if (tieneFechAproba)
            //                    meses = fInternas.GetMonthDifference(fechaAprobacion, fechaActual, ref error);
            //                else
            //                    meses = int.Parse(txtMeses.Text);

            //                row.Cells["CANTIDAD"].Value = meses.ToString();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        error = "Debe especificar el articulo FMS para esta condicion en los configurables";
            //        OK = false;
            //    }
            //}

            
        }

        private void cargarMesesDgv(ref DataGridView dgvArt, ref string error)
        {
            bool OK = true;

            if (!txtMeses.Text.Equals(""))
            {
                //if (int.Parse(txtMeses.Text) > 1)
                //{
                    string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART where CodigoCondicion = '" + txtCondicion.Text + "' and ArticuloFms = 'S'";

                    DataTable dtArticuloFms = new DataTable();

                    if (OK)
                    {
                        OK = Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error);

                        if (dtArticuloFms.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dgvArt.Rows)
                            {
                                foreach (DataRow dtRow in dtArticuloFms.Rows)
                                {
                                    if (dtRow["CodigoArticulo"].ToString() == row.Cells["colArticulo"].Value.ToString())
                                    {
                                        if (int.Parse(txtMeses.Text) > 1)
                                            row.Cells["colCantidad"].Value = txtMeses.Text;
                                        else
                                            row.Cells["colCantidad"].Value = "1";
                                    }
                                }
                                //if (dtArticuloFms.Rows[0][0].ToString() == row.Cells["colArticulo"].Value.ToString())
                                //    {
                                //        if (int.Parse(txtMeses.Text) > 1)
                                //            row.Cells["colCantidad"].Value = txtMeses.Text;
                                //        else
                                //            row.Cells["colCantidad"].Value = "1";
                                //    }
                            }
                        }
                        else
                        {
                            error = "Debe especificar el articulo FMS para esta condicion en los configurables";
                            OK = false;
                        }
                    }
                //}

            }
            else
            {
                string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART where CodigoCondicion = '" + txtCondicion.Text + "' and ArticuloFms = 'S'";

                DataTable dtArticuloFms = new DataTable();

                if (OK)
                {
                    OK = Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error);

                    if (dtArticuloFms.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvArt.Rows)
                        {
                            if (dtArticuloFms.Rows[0][0].ToString() == row.Cells["colArticulo"].Value.ToString())
                            {
                                row.Cells["colCantidad"].Value = "1";
                            }
                        }
                    }
                    else
                    {
                        error = "Debe especificar el articulo FMS para esta condicion en los configurables";
                        OK = false;
                    }
                }
            }

        }

        private bool actualizarCantidadArticulo(ref DataGridView dgvArt, string colegiado, ref string error)
        {
            bool OK = true;
            bool tieneFechAproba = true;
            DateTime fechaAprobacion = DateTime.Now;
            DateTime fechaActual = DateTime.Now;
            //string query = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '"+txtCondicionIni.Text+"'";

            string query = "select  FechaAprobacion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '" + txtCondicion.Text + "' and FechaAprobacion = (select MAX(FechaAprobacion) from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION where IdColegiado = '" + colegiado + "' and CondicionActual = '" + txtCondicion.Text + "')";

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
                    tieneFechAproba = false;
                }
            }



            string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART where CodigoCondicion = '" + txtCondicion.Text + "' and ArticuloFms = 'S'";

            DataTable dtArticuloFms = new DataTable();

            if (OK)
            {
                OK = Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error);

                if (dtArticuloFms.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvArt.Rows)
                    {
                        if (dtArticuloFms.Rows[0][0].ToString() == row.Cells["ARTICULO"].Value.ToString())
                        {
                            int meses = 1;
                            if (tieneFechAproba)
                                meses = fInternas.GetMonthDifference(fechaAprobacion, fechaActual, ref error);
                            else
                                meses = int.Parse(txtMeses.Text);

                            row.Cells["CANTIDAD"].Value = meses.ToString();
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

        private void calcularPrima()
        {
            //if (Utilitario.EsNumeroMayorCero(txtPorcPrima.Text))
            //{
                decimal total = 0;
                decimal prima = 0;
            if (!txtPorcPrima.Text.Equals("") && !txtSubTotal.Text.Equals(""))
            {
                prima = decimal.Parse(txtPorcPrima.Text) / 100;
                total = decimal.Parse(txtSubTotal.Text) * prima;
            }
                

                txtMontoPrima.Text = total.ToString("N2");
            //}
            //else
            //    MessageBox.Show("La cantidad de meses debe ser un valor númerico y mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void calcularArreglo()
        {
            
            decimal total = 0;

            //if (txtMesesArreglo.Text.Equals(""))
            //    total = decimal.Parse(txtTotal.Text) / int.Parse(txtMesesArreglo.Text);
            
            if (!txtTotal.Text.Equals("") && !txtMesesArreglo.Text.Equals(""))
                if(int.Parse(txtMesesArreglo.Text) != 0 )
                    total = decimal.Parse(txtTotal.Text) / int.Parse(txtMesesArreglo.Text);
            
                txtMontoArreglo.Text = total.ToString("N2");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcular();
        }

        private void calcular()
        {
            if (Utilitario.EsNumeroMayorCero(txtMeses.Text))
            {
                decimal subtotal = 0;
                decimal total = 0;
                decimal totalLev = 0;
                decimal totalPen = 0;

                totalLev = calcularTotalLev();
                totalPen = calcularTotalPend();
                subtotal = totalLev + totalPen;
                txtSubTotal.Text = subtotal.ToString("N2");
                
                txtSubTotalLev.Text = totalLev.ToString("N2");
                txtSubTotalPend.Text = totalPen.ToString("N2");

                calcularPrima();

                if (!txtMontoPrima.Text.Equals(""))
                    total = subtotal - decimal.Parse(txtMontoPrima.Text);
                txtTotal.Text = total.ToString("N2");

                calcularArreglo();
                
            }
            else
                MessageBox.Show("La cantidad de meses debe ser un valor númerico y mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private decimal calcularTotalLev()
        {
            decimal total = 0;
            if (dgvRubros.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvRubros.Rows)
                {
                    total += decimal.Parse(row.Cells["colPrecio"].Value.ToString()) * decimal.Parse(row.Cells["colCantidad"].Value.ToString());
                }
            }

            //if (dgvGestionCobro.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dgvGestionCobro.Rows)
            //    {
            //        total += decimal.Parse(row.Cells["colSaldo"].Value.ToString());
            //    }
            //}
            //total = total * decimal.Parse(txtMeses.Text);
            return total;
        }

        private decimal calcularTotalPend()
        {
            decimal total = 0;
            //if (dgvRubros.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dgvRubros.Rows)
            //    {
            //        total += decimal.Parse(row.Cells["colPrecio"].Value.ToString()) * decimal.Parse(row.Cells["colCantidad"].Value.ToString());
            //    }
            //}

            if (dgvGestionCobro.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvGestionCobro.Rows)
                {
                    total += decimal.Parse(row.Cells["colSaldo"].Value.ToString());
                }
            }
            //total = total * decimal.Parse(txtMeses.Text);
            return total;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvRubros.AutoResizeColumns();
            dgvGestionCobro.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Se esta trabajando en este proceso","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dgvRubros.RowCount == 0)
            {
                MessageBox.Show("No existen rubros por cobrar para el colegiado seleccionado, revise las configurables de la condición.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMeses.Text == "")
            {
                MessageBox.Show("Defina la cantidad de meses a pagar por adelantado.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Utilitario.EsNumeroMayorCero(txtMeses.Text))
            {
                MessageBox.Show("La cantidad de meses a pagar debe ser un valor númerico y mayor que 0.",
                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            realizarDocumentos();
        }

        private bool activarUsuarioERP(ref string error)
        {
            bool OK = true;
            DataTable dt = new DataTable();
            List<string> parametros = new List<string>();

            string sQuery = "SELECT ACTIVO FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE = '" + txtColegiado.Text + "'";
            
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
                            parametros.Add("@CLIENTE," + txtColegiado.Text);


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
                error = "[cambiarCobrador_CC] Ocurrió un error al obtener registros para actualizar cobrador:\n" + ex.Message;
                OK = false;
            }

            return OK;
        }

        private void realizarDocumentos()
        {
            Cursor.Current = Cursors.WaitCursor;
            string error = "", factura = "", pedido = "";
            decimal montoDesc = 0, porcDescuento = 0;
            int indiceArticulo = 0;
            bool OK = true;
            DataTable dtArticulos = new DataTable();
            calcular();


            Consultas.sqlCon.iniciaTransaccion();
           
            //string sQuery = "SELECT T3.ARTICULO as CODIGO,T3.DESCRIPCION,T4.PRECIO, CASE WHEN t1.CodigoArticulo = (SELECT CodigoArticulo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART WHERE ArticuloFms = 'S') THEN '" + txtMeses.Text + "' ELSE '1' END AS CANTIDAD FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO T1" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES T2 ON t2.CodigoCondicion = t1.CodigoCondicion" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T3 ON T1.CodigoArticulo = T3.ARTICULO" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T4 on T4.ARTICULO = T1.CodigoArticulo" +
            //        " WHERE T1.NumeroColegiado = '" + txtColegiado.Text + "'";

            string sQuery = "select t1.CodigoArticulo AS ARTICULO, t2.DESCRIPCION, t3.PRECIO, CASE WHEN  t1.ArticuloFms = 'S'  THEN '" + txtMeses.Text + "' ELSE '1' END AS CANTIDAD, '0' DESCUENTO" +
                            " from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t2 on t2.ARTICULO = t1.CodigoArticulo" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t3 on t3.ARTICULO = t1.CodigoArticulo" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t3.NIVEL_PRECIO AND t6.VERSION = t3.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                            " where t1.CodigoCondicion = '" + txtCondicion.Text + "'";

            OK = Consultas.fillDataTable(sQuery, ref dtArticulos, ref error);

            if (OK)
                OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtColegiado.Text, ref error);

            if (OK)
            {

                //OK = controlerBD.FacturarSinPedido(dtArticulos, txtColegiado.Text, ref factura, montoDesc, porcDescuento, false, indiceArticulo, txtCobrador.Text, "ADEL", "FACTURAS", "COL", "LEVANTAMIENTO CONDICIÓN-" + txtDescCondicion.Text + " KOLEGIO", string.Empty, string.Empty, string.Empty, ref error);

                //if (OK)
                //{
                    OK = activarUsuarioERP(ref error);
                //}

                if (OK)
                    OK = controlerBD.crearPedidoGenerico(dtArticulos, txtColegiado.Text, ref pedido, montoDesc, porcDescuento, false, indiceArticulo, txtCobrador.Text, "ADEL", "PEDIDOS", "COL", "Levantamiento Condición-" + txtDescCondicion.Text, string.Empty, ref error);

                if (OK)
                {

                    Consultas.sqlCon.Commit();
                    //buscaColegiado(txtNumeroColegiado.Valor);
                    MessageBox.Show("Se genero la factura exitosamente.", "Levantamiento de Condición", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                }
                else
                {
                    Consultas.sqlCon.Rollback();
                    MessageBox.Show("Error generando la factura:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Consultas.sqlCon.Rollback();
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }

            
        }
        
        private void txtMeses_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            cargarMesesDgv(ref dgvRubros, ref error);

            if (!txtMeses.Text.Equals(""))
            {
                calcular();
            }
            
        }

        private void txtPorcPrima_TextChanged(object sender, EventArgs e)
        {
            if (!txtPorcPrima.Text.Equals(""))
            {
                //calcularPrima();
                calcular();
            }
            else
            {
                txtMontoPrima.Text = "0";
            }
        }

        private void txtPorcPrima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtMesesArreglo_TextChanged(object sender, EventArgs e)
        {
            //if (!txtMesesArreglo.Text.Equals(""))
            //{
            //    calcularArreglo();
            //}
        }

        private void txtMesesArreglo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtPorcPrima_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!txtPorcPrima.Text.Equals(""))
            //{
                
            //    if (Decimal.Parse(txtPorcPrima.Text) > 100)
            //    {
            //        MessageBox.Show("El porcentaje de prima debe ser un valor menor o igual a 100.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtPorcPrima.Text = "0.00";
            //    }

            //}
            //calcularPrima();
        }

        private void txtPorcPrima_Leave(object sender, EventArgs e)
        {
            if (txtPorcPrima.Text.Equals(""))
                txtPorcPrima.Text = "0";
        }

        private void txtPorcPrima_Enter(object sender, EventArgs e)
        {
            //txtPorcPrima.Clear();
        }

        private void txtMesesArreglo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtMesesArreglo.Text.Equals(""))
            {
                //calcularArreglo();
                calcular();
            }
            else
            {
                txtMontoArreglo.Text = "0.00";
            }
        }

        private void txtMesesArreglo_Leave(object sender, EventArgs e)
        {
            if (txtMesesArreglo.Text.Equals(""))
                txtMesesArreglo.Text = "0";
        }

        private void txtMesesArreglo_Enter(object sender, EventArgs e)
        {
            //txtMesesArreglo.Clear();
        }
    }
}
