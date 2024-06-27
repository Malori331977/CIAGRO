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
    public partial class frmPagosAdelantados : Form
    {
        MaskFormat mfMask;
        private FuncsInternas fInternas;

        public frmPagosAdelantados()
        {
            InitializeComponent();
            txtMeses.Text = "1";
            txtDescuento.Text = "0.00";
            mfMask = mtbMesUltimoCobro.TextMaskFormat;
            this.fInternas = new FuncsInternas();
        }

        private void txtColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaColegiados();
        }

        

        private void listaColegiados()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado, NumeroColegiado as Colegiado, Nombre, Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.COLUMNAS_PK.Add("IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("Cobrador");

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
                cargarUltimoMes(txtColegiado.Text);
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
            listP.COLUMNAS = "IdColegiado,NumeroColegiado,Nombre,Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where NumeroColegiado = '" + codigo + "'";
            string error = "";
            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNombreColegiado.Text = dtColegiado.Rows[0]["Nombre"].ToString();
                    txtColegiado.Text = dtColegiado.Rows[0]["IdColegiado"].ToString();
                    txtNumeroColegiado.Valor = dtColegiado.Rows[0]["NumeroColegiado"].ToString();
                    txtCobrador.Text = dtColegiado.Rows[0]["Cobrador"].ToString();
                    cargarUltimoMes(txtColegiado.Text);
                    refrescar();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtColegiado.Clear();
                        txtNombreColegiado.Clear();
                        txtNumeroColegiado.Clear();
                        txtCobrador.Clear();
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

        private void cargarUltimoMes(string colegiado)
        {
            string sQuery = "select distinct MesUltimoCobro from "+Consultas.sqlCon.COMPAÑIA+ ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + colegiado+"'";

            DataTable dt = new DataTable();
            string error = "";
            

            Cursor.Current = Cursors.WaitCursor;
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["MesUltimoCobro"].ToString()))
                {
                    mtbMesUltimoCobro.TextMaskFormat = mfMask;
                    mtbMesUltimoCobro.Text = DateTime.Parse(dt.Rows[0]["MesUltimoCobro"].ToString()).ToString("MM/yyyy");
                }
                else
                {
                    mtbMesUltimoCobro.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtbMesUltimoCobro.Text = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor.Current = Cursors.Default;
        }

        private bool actualizarUltMesCobro(string colegiado, DateTime ultimoCobro, int mesesAdelanto, ref string error)
        {
            bool OK = true;
            string sUpdate = "";
            string sSelect = "";
            string sInsert = "";
            DataTable dt = new DataTable();
            DateTime mesUltCobro = DateTime.Now;
            //if (ultimoCobro.Equals("") || ultimoCobro.Equals("  /"))
            //{
            //    mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 1);
            //}
            //else
            //{
            //    mesUltCobro = DateTime.Parse(ultimoCobro);
            //}
            string mes = "";


            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + colegiado + "'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count > 0)
            {
                ultimoCobro = ultimoCobro.AddMonths(mesesAdelanto);
                mes = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");
                sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "'";

                OK = Consultas.ejecutarSentencia(sUpdate, ref error);
            }
            else
            {
                //if (mesesAdelanto > 1)//Si son mas de un mes le sumo todos menos el actual
                //{
                //  mesesAdelanto = mesesAdelanto - 1;
                ultimoCobro = ultimoCobro.AddMonths(mesesAdelanto);
                //}

                mes = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");
                sInsert = "insert into " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS (IdColegiado,MesUltimoCobro) values ('" + colegiado + "', '" + mes + "')";

                OK = Consultas.ejecutarSentencia(sInsert, ref error);

            }

            return OK;
        }

        private void refrescar()
        {   //Se quito condicion de activo
            //string sQuery = "SELECT T2.DESCRIPCION,T1.Monto FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO T1 JOIN " +
            //   Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 ON T1.CodigoArticulo=T2.ARTICULO WHERE " +
            //   "T1.NumeroColegiado='" + txtColegiado.Text + "' AND T1.CodigoCondicion=(SELECT Condicion from " + Consultas.sqlCon.COMPAÑIA +
            //   ".NV_COLEGIADO WHERE IdColegiado='" + txtColegiado.Text + "') AND T1.Activo='S' "; 
            //string sQuery = "SELECT T3.ARTICULO as CODIGO,T3.DESCRIPCION,T4.PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO T1" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES T2 ON t2.CodigoCondicion = t1.CodigoCondicion" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T3 ON T1.CodigoArticulo = T3.ARTICULO" +
            //        " JOIN "+Consultas.sqlCon.COMPAÑIA+".ARTICULO_PRECIO T4 on T4.ARTICULO = T1.CodigoArticulo"+
            //        " WHERE T1.NumeroColegiado = '"+ txtColegiado.Text + "'";
            string sQuery = "SELECT t4.ARTICULO as CODIGO, t4.DESCRIPCION, t5.PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t3 ON t3.CodigoPlantilla = t2.CodigoPlantilla" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t3.CodigoArticulo" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t3.CodigoArticulo" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t5.NIVEL_PRECIO AND t6.VERSION = t5.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                    " WHERE t1.IdColegiado = '" + txtColegiado.Text + "'";

            DataTable dt = new DataTable();
            string error = "";
            Cursor.Current = Cursors.WaitCursor;
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                //dgvRubros.DataSource = dt;
                dgvRubros.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    dgvRubros.Rows.Add(row["CODIGO"].ToString(), row["DESCRIPCION"].ToString(), decimal.Parse(row["PRECIO"].ToString()).ToString("N2"));
                }
                //dgvRubros.Columns["colPrecio"].DefaultCellStyle.Format = "c";
                dgvRubros.Columns["colPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRubros.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                calcular();
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            Cursor.Current = Cursors.Default;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcular();
        }

        private void calcular()
        {
            if (Utilitario.EsNumeroMayorCero(txtMeses.Text))
            {
                decimal total = 0;
                //decimal descuento = 0;
                //foreach (DataGridViewRow row in dgvRubros.Rows)
                //{
                //    total += decimal.Parse(row.Cells["colMonto"].Value.ToString());
                //}
                //descuento = decimal.Parse(txtDescuento.Text) / 100;
                //total = total * decimal.Parse(txtMeses.Text);
                //descuento = total * descuento;
                total = calcularTotal(decimal.Parse(txtMeses.Text));
                total = total - calcularDescuento(total);
                txtTotal.Text = total.ToString("N2");
            }
            else
                MessageBox.Show("La cantidad de meses debe ser un valor númerico y mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private decimal calcularDescuento(decimal total)
        {
            decimal descuento = 0;
            if(txtDescuento.Text.Equals(""))
                descuento = 0 / 100;
            else
                descuento = decimal.Parse(txtDescuento.Text) / 100;
            descuento = total * descuento;
            return descuento;
        }

        private decimal calcularTotal(decimal cantidadMeses)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                total += decimal.Parse(row.Cells["colPrecio"].Value.ToString());
            }
            total = total * decimal.Parse(txtMeses.Text);
            return total;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvRubros.AutoResizeColumns();
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
                MessageBox.Show("No existen rubros por cobrar para el colegiado seleccionado, revise su condición actual y su plantilla de cobro asociada.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMeses.Text == "")
            {
                MessageBox.Show("Defina la cantidad de meses a pagar por adelantado.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDescuento.Text == "")
            {
                MessageBox.Show("Defina el porcentaje de descuento para el adelanto.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Utilitario.EsNumeroMayorCero(txtMeses.Text))
            {
                MessageBox.Show("La cantidad de meses a pagar debe ser un valor númerico y mayor que 0.",
                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (tienePedidosPenditentes())
            //{
            //    MessageBox.Show("El colegiado tiene pedidos pendientes de procesar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (tieneDocumentosPenditentes())
            //{
            //    MessageBox.Show("El colegiado tiene documentos pendientes", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            realizarDocumentos();
        }

        private void realizarDocumentos()
        {
            Cursor.Current = Cursors.WaitCursor;
            string error = "", factura = "", observacion = "", comentarioLinea = "";
            int indiceArticulo = 0;
            DateTime mesCobro = DateTime.Now;
            bool OK = true;
            DataTable dtArticulos = new DataTable();
            calcular();
            Consultas.sqlCon.iniciaTransaccion();
            ////if(controlerBD.crearDocumentosAdelantos(txtColegiado.Text, decimal.Parse(txtTotal.Text), int.Parse(txtMeses.Text), calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), ref error))
            ////{
            ////    Consultas.sqlCon.Commit();
            ////    MessageBox.Show("Se generaron los documentos exitosamente en el ERP.", "Adelanto de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ////}
            ////else
            ////{
            ////    Consultas.sqlCon.Rollback();
            ////    MessageBox.Show("Error generando los pagos:\n"+error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////}
            ////string sQuery = "SELECT T3.ARTICULO as CODIGO,T3.DESCRIPCION,T4.PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO T1" +
            ////        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES T2 ON t2.CodigoCondicion = t1.CodigoCondicion" +
            ////        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T3 ON T1.CodigoArticulo = T3.ARTICULO" +
            ////        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T4 on T4.ARTICULO = T1.CodigoArticulo" +
            ////        " WHERE T1.NumeroColegiado = '" + txtColegiado.Text + "'";
            //string sQuery = "SELECT t4.ARTICULO as CODIGO, t4.DESCRIPCION, t5.PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t3 ON t3.CodigoPlantilla = t2.CodigoPlantilla" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t3.CodigoArticulo" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t3.CodigoArticulo" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t5.NIVEL_PRECIO AND t6.VERSION = t5.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
            //        " WHERE t1.IdColegiado = '" + txtColegiado.Text + "'";
            decimal desc = txtDescuento.Text != "" ? decimal.Parse(txtDescuento.Text) : 0 ;
            string sQuery = "select t4.ARTICULO as CODIGO, t4.DESCRIPCION, t5.PRECIO, '" + txtMeses.Text + "' CANTIDAD, (t5.PRECIO * CONVERT(numeric(4,2),(" + desc + "/100.00))) DESCUENTO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t3 ON t3.CodigoPlantilla = t2.CodigoPlantilla" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t3.CodigoArticulo" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t3.CodigoArticulo" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t5.NIVEL_PRECIO AND t6.VERSION = t5.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                    " WHERE t1.IdColegiado = '" + txtColegiado.Text + "'";


            OK = Consultas.fillDataTable(sQuery, ref dtArticulos, ref error);
            if (OK)
            {
                if (mtbMesUltimoCobro.Text.Length == 0)
                {
                    mesCobro = new DateTime(mesCobro.Year, mesCobro.Month-1, 25);
                }
                else
                {
                    mesCobro = DateTime.Parse(mtbMesUltimoCobro.Text);
                   // mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
                }

                if (OK)
                    OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtColegiado.Text , ref error);

                observacion = "COLEGIATURA HASTA " + mesCobro.AddMonths(int.Parse(txtMeses.Text)).ToString("MMMM yyyy").ToUpper();
                //comentarioLinea = "COLEGIATURA HASTA " + mesCobro.AddMonths(int.Parse(txtMeses.Text)).ToString("MMMM yyyy").ToUpper();
                if (controlerBD.crearPedido(dtArticulos, txtColegiado.Text, int.Parse(txtMeses.Text), calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), decimal.Parse(txtDescuento.Text), "adelanto", false, 0, txtCobrador.Text, mesCobro.ToString("MMMM yyyy"), ref error))
                //if (controlerBD.FacturarSinPedido(dtArticulos, txtColegiado.Text, ref factura, calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), decimal.Parse(txtDescuento.Text), false, indiceArticulo, txtCobrador.Text, "ADEL", "FACTURAS", "COL", observacion, observacion, string.Empty, string.Empty, ref error))
                {
                //OK = actualizarUltMesCobro(txtColegiado.Text, mesCobro, int.Parse(txtMeses.Text), ref error);
                    OK = guardarUltimoCobro(mesCobro, int.Parse(txtMeses.Text), ref error);

                    if (OK)
                    {
                        Consultas.sqlCon.Commit();
                        buscaColegiado(txtNumeroColegiado.Valor);
                        MessageBox.Show("Se genero el adelanto exitosamente en el ERP.", "Adelanto de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    Consultas.sqlCon.Rollback();
                    MessageBox.Show("Error generando el adelanto:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            Cursor.Current = Cursors.Default;
        }

        private bool guardarUltimoCobro(DateTime mesUltCobro, int mesesAdelanto, ref string error)
        {
            Listado list = new Listado();
            List<string> parametros = new List<string>();
            bool lbOK = true;
            //DateTime mesUltCobro = DateTime.Now;

            //if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
            //{
            //    mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 25);
            //    mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
            //}
            //else
            //{
            //    mesUltCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
            //}

            if (fInternas.existeUltimoCobro(txtColegiado.Text, string.Empty, string.Empty, string.Empty, "COL"))
            {
                fInternas.actualizarUltimoCobro(ref parametros, ref list, string.Empty, mesUltCobro, txtColegiado.Text, string.Empty, string.Empty, "COL");

                if (lbOK)
                    lbOK = Consultas.actualizar(parametros, list, Constantes.ID_BIT_UPDATE_ULTIMO_COBRO, ref error);
            }
            else
            {
                fInternas.agregarUltimoCobro(ref parametros, ref list, string.Empty, mesUltCobro, txtColegiado.Text, string.Empty, string.Empty, "COL");
                if (lbOK)
                    lbOK = Consultas.insertar(parametros, list, Constantes.ID_BIT_CREAR_ULTIMO_COBRO, ref error);
            }

            return lbOK;
        }

        private bool tieneDocumentosPenditentes()
        {
            bool Ok = false;
            bool pendientes = false;
            string error = "";
            DataTable dt = new DataTable();
            string sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC "+
                    "where CLIENTE = '"+txtColegiado.Text+ "' and CAST(FECHA_VENCE as  date) < CAST(GETDATE() as date) and SALDO > 0 and (TIPO = 'FAC' or(TIPO = 'O/D' and SUBTIPO = '176'))";

            Ok = Consultas.fillDataTable(sQuery,ref dt,ref error);

            if (Ok)
            {
                if (dt.Rows.Count > 0)
                    pendientes = true;
                else
                    pendientes = false;
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return pendientes;
        }

        //private bool tienePedidosPenditentes()
        //{
        //    bool Ok = false;
        //    bool pendientes = false;
        //    string error = "";
        //    DataTable dt = new DataTable();
        //    string sQuery = "select * from "+Consultas.sqlCon.COMPAÑIA+".PEDIDO where ESTADO = 'N' and CLIENTE = '"+ txtColegiado.Text + "' and VENDEDOR = 'COL'";

        //    Ok = Consultas.fillDataTable(sQuery, ref dt, ref error);

        //    if (Ok)
        //    {
        //        if (dt.Rows.Count > 0)
        //            pendientes = true;
        //        else
        //            pendientes = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //    return pendientes;
        //}

        private void txtMeses_KeyUp(object sender, KeyEventArgs e)
        {
            if(!txtMeses.Text.Equals(""))
                calcular();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            //if (!txtDescuento.Text.Equals(""))
            //{
            //    //decimal valorDescuento = decimal.Parse(txtDescuento.Text);
            //    if (!Utilitario.EsNumeroMayorCero(txtDescuento.Text))
            //    {
            //        MessageBox.Show("La cantidad de meses debe ser un valor númerico y mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtDescuento.Text = "0.00";
            //    }
            //}else
            //    txtDescuento.Text = "0.00";

        }

        private void txtDescuento_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtDescuento.Text.Equals(""))
            {
                //decimal valorDescuento = decimal.Parse(txtDescuento.Text);
                //if (decimal.Parse(txtDescuento.Text) < 0)
                //{
                //    MessageBox.Show("El descuento debe ser un valor númerico mayor o igual a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtDescuento.Text = "0.00";
                //}
                if(Decimal.Parse(txtDescuento.Text) > 100)
                {
                    MessageBox.Show("El descuento debe ser un valor entre 0 y 100.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescuento.Text = "0.00";
                }
                
            }
            calcular();
            //else
            //    txtDescuento.Text = "0.00";
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

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescuento_Enter(object sender, EventArgs e)
        {
            txtDescuento.Clear();
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if(txtDescuento.Text.Equals(""))
                txtDescuento.Text = "0.00";
        }
    }
}
