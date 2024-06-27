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
    public partial class frmPagosAdelantadosRegencia : Form
    {
        private FuncsInternas fInternas;

        public frmPagosAdelantadosRegencia()
        {
            InitializeComponent();
            txtMeses.Text = "1";
            txtDescuento.Text = "0.00";
            this.fInternas = new FuncsInternas();
        }

        private void txtColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaRegentes();
        }

        private void listaRegentes()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "distinct (select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as [Numero],(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as [Nombre de Regente],t1.NumeroColegiado as 'Num'";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_REGENTES_ESTABLECIMIENTOS t1";
            //listP.FILTRO = "where AvaluoCursos = 'S'";
            listP.ORDERBY = "order by t1.NumeroColegiado";
            listP.COLUMNAS_PK.Add("NumeroColegiado");
            listP.COLUMNAS_ALIAS_PK.Add("Num");
            listP.COLUMNAS_OCULTAS.Add("Num");


            listP.TITULO_LISTADO = "Regentes";

            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                txtColegiado.Text = f1Colegiado.item.SubItems[2].Text;
                txtNumeroColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
                txtNombreColegiado.Text = f1Colegiado.item.SubItems[1].Text;
                refrescar();
            }
        }

        private void buscaRegente(string codigo)
        {

            if (txtNumeroColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                refrescar();
                return;
            }

            DataTable dtColegiado = new DataTable();
            string sQuery = "SELECT distinct t3.IdColegiado,t3.NumeroColegiado,t3.Nombre" +
            " FROM "+Consultas.sqlCon.COMPAÑIA+ ".NV_REGENTES t1" +
            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t2 on t2.NumeroColegiado = t1.NumeroColegiado" +
            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 on t3.IdColegiado = t2.NumeroColegiado" +
            " where t3.NumeroColegiado = '"+codigo+"'";
            string error = "";
            if (Consultas.fillDataTable(sQuery, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtColegiado.Text = dtColegiado.Rows[0]["IdColegiado"].ToString();
                    txtNumeroColegiado.Valor = dtColegiado.Rows[0]["NumeroColegiado"].ToString();
                    txtNombreColegiado.Text = dtColegiado.Rows[0]["Nombre"].ToString();
                    refrescar();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El colegiado no existe como regente o no esta asociado a ningún establecimiento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtColegiado.Clear();
                        txtNombreColegiado.Clear();
                        dgvRubros.Rows.Clear();
                        //refrescar();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtColegiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaRegentes();
        }

        private void txtColegiado_Leave(object sender, EventArgs e)
        {
            buscaRegente(txtNumeroColegiado.Valor);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void refrescar()
        {
            string sQuery = "SELECT t1.CodigoEstablecimiento as COD_ESTABLE,t7.Nombre as ESTABLECIMIENTO,t1.CodigoCategoria as COD_CATEG,t8.NombreCategoria as CATEGORÍA,t9.MesUltimoCobro as UltMesCobro,t4.CodigoArticulo as CODIGO,t5.DESCRIPCION,t6.PRECIO, t2.Cobrador as cobradorRegente FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES t2 ON t2.NumeroColegiado = t1.NumeroColegiado" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 ON t3.IdColegiado = t2.NumeroColegiado" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t4 ON t4.CodigoCategoria = t1.CodigoCategoria" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T5 ON T5.ARTICULO = T4.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t6 ON t6.ARTICULO = t4.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t7 on t7.NumRegistro = t1.CodigoEstablecimiento" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t8 on t8.CodigoCategoria = t4.CodigoCategoria" +
                        " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t9 on t9.NumRegistro = t7.NumRegistro" +
                        " WHERE t2.NumeroColegiado = '" + txtColegiado.Text + "' and t1.Estado = 'A'";
            //string sQuery = "SELECT t1.CodigoEstablecimiento as COD_ESTABLE,t7.Nombre as ESTABLECIMIENTO,t1.CodigoCategoria as COD_CATEG,t8.NombreCategoria as CATEGORÍA,t1.MesUltimoCobro as UltMesCobro,t4.CodigoArticulo as CODIGO,t5.DESCRIPCION,t6.PRECIO, t1.Cobrador as cobradorRegente FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 ON t3.IdColegiado = t1.NumeroColegiado" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t4 ON t4.CodigoCategoria = t1.CodigoCategoria" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T5 ON T5.ARTICULO = T4.CodigoArticulo" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t6 ON t6.ARTICULO = t4.CodigoArticulo" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t7 on t7.NumRegistro = t1.CodigoEstablecimiento" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t8 on t8.CodigoCategoria = t4.CodigoCategoria" +
            //            " WHERE t1.NumeroColegiado = '" + txtColegiado.Text + "' and t1.Estado = 'A'";

            DataTable dt = new DataTable();
            string error = "";
            Cursor.Current = Cursors.WaitCursor;
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if(dt.Rows.Count > 0)
                {
                    dgvRubros.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        //txtCobrador.Text = row["cobradorRegente"].ToString();
                        txtCobrador.Text = "ND";
                        dgvRubros.Rows.Add(false, row["COD_ESTABLE"].ToString(), row["ESTABLECIMIENTO"].ToString(), row["COD_CATEG"].ToString(), row["CATEGORÍA"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "", row["CODIGO"].ToString(), row["DESCRIPCION"].ToString(), /*row["cobradorRegente"].ToString(),*/ decimal.Parse(row["PRECIO"].ToString()).ToString("N2"));
                    }
                    //dgvRubros.Columns["colPrecio"].DefaultCellStyle.Format = "c";
                    dgvRubros.Columns["colPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvRubros.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    calcular();
                    //txtMeses.Text = "1";
                    //txtDescuento.Text = "0.00";
                }
                else
                {
                    txtColegiado.Clear();
                    txtNumeroColegiado.Clear();
                    txtNombreColegiado.Clear();
                    txtCobrador.Clear();
                    dgvRubros.Rows.Clear();
                    MessageBox.Show("La categoría asociada al regente no posee ningún rubro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    

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
            if(!txtDescuento.Text.Equals(""))
                descuento = decimal.Parse(txtDescuento.Text) / 100;
            else
                descuento = 0 / 100;
            descuento = total * descuento;
            return descuento;
        }

        private decimal calcularTotal(decimal cantidadMeses)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if ((bool)row.Cells["colSeleccionada"].Value)
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

        private bool tieneDocumentosPenditentes()
        {
            bool Ok = false;
            bool pendientes = false;
            string error = "";
            DataTable dt = new DataTable();
            string sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC " +
                    "where CLIENTE = '" + txtColegiado.Text + "' and SALDO > 0 and(TIPO = 'FAC' or(TIPO = 'O/D' and SUBTIPO = '176'))";

            Ok = Consultas.fillDataTable(sQuery, ref dt, ref error);

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

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Se esta trabajando en este proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (!Utilitario.EsNumeroMayorCero(txtMeses.Text))
            {
                MessageBox.Show("La cantidad de meses a pagar debe ser un valor númerico y mayor que 0.",
                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (tieneDocumentosPenditentes())
            //{
            //    MessageBox.Show("El colegiado tiene documentos pendientes", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (validarMarcadas())
            {
                realizarDocumentos();
            }
            else
            {
                MessageBox.Show("Debe marcar las regencias que desea realizar un adelanto","Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void realizarDocumentos()
        {
            Cursor.Current = Cursors.WaitCursor;
            string error = "";
            bool OK = true;
            DataTable dtArticulos = new DataTable();
            //DataTable dt = new DataTable();
            calcular();
            Consultas.sqlCon.iniciaTransaccion();
            //if(controlerBD.crearDocumentosAdelantos(txtColegiado.Text, decimal.Parse(txtTotal.Text), int.Parse(txtMeses.Text), calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), ref error))
            //{
            //    Consultas.sqlCon.Commit();
            //    MessageBox.Show("Se generaron los documentos exitosamente en el ERP.", "Adelanto de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //else
            //{
            //    Consultas.sqlCon.Rollback();
            //    MessageBox.Show("Error generando los pagos:\n"+error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //string sQuery = "SELECT T3.ARTICULO as CODIGO,T3.DESCRIPCION,T4.PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO T1" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES T2 ON t2.CodigoCondicion = t1.CodigoCondicion" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T3 ON T1.CodigoArticulo = T3.ARTICULO" +
            //        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T4 on T4.ARTICULO = T1.CodigoArticulo" +
            //        " WHERE T1.NumeroColegiado = '" + txtColegiado.Text + "'";


            dtArticulos.Columns.Add("CODIGO", typeof(String));
            dtArticulos.Columns.Add("DESCRIPCION", typeof(String));
            dtArticulos.Columns.Add("PRECIO", typeof(Decimal));
            dtArticulos.Columns.Add("CATEGORIA", typeof(String));
            dtArticulos.Columns.Add("ESTABLECIMIENTO", typeof(String));

            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if ((bool)row.Cells["colSeleccionada"].Value)
                {
                    DataRow dr = dtArticulos.NewRow();
                    dr[0] = row.Cells[6].Value.ToString();
                    dr[1] = row.Cells[7].Value.ToString();
                    dr[2] = row.Cells[8].Value.ToString();
                    dr[3] = row.Cells[4].Value.ToString();
                    dr[4] = row.Cells[2].Value.ToString();
                    dtArticulos.Rows.Add(dr);
                }
                
            }

            //OK = Consultas.fillDataTable(sQuery, ref dtArticulos, ref error);
            //if (OK)
            //{

            if (OK)
                OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtColegiado.Text, ref error);

            //if (controlerBD.crearPedidoRegencia(dtArticulos, txtColegiado.Text, "", "", int.Parse(txtMeses.Text), calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), decimal.Parse(txtDescuento.Text),txtCobrador.Text,"adelanto", ref error))
            //{
            //    OK = actualizarUltMesCobro(txtColegiado.Text, int.Parse(txtMeses.Text), ref error);
            //    if (OK)
            //    {
            //        Consultas.sqlCon.Commit();
            //        buscaRegente(txtNumeroColegiado.Valor);
            //        MessageBox.Show("Se genero el adelanto exitosamente en el ERP.", "Adelanto de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    }
            //}
            //else
            //{
            //    Consultas.sqlCon.Rollback();
            //    MessageBox.Show("Error generando el adelanto:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //}
            
            Cursor.Current = Cursors.Default;
        }

        private bool validarMarcadas()
        {
            bool OK = false;
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if ((bool)row.Cells["colSeleccionada"].Value)
                {
                    OK = true;
                }

            }

            return OK;
        }

        //private bool actualizarUltMesCobro(string colegiado, int mesesAdelanto, ref string error)
        //{
        //    bool OK = true;
        //    string sUpdate = "";
        //    string mes = "";
        //    DateTime mesUltCobro = DateTime.Now;

        //    foreach (DataGridViewRow row in dgvRubros.Rows)
        //    {
        //        if ((bool)row.Cells["colSeleccionada"].Value)
        //        {
        //            if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
        //            {
        //                mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 25);
        //                //if (mesesAdelanto > 1)//Si son mas de un mes le sumo todos menos el actual
        //                //{
        //                //  mesesAdelanto = mesesAdelanto - 1;
        //                mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
        //                //}
        //            }
        //            else
        //            {
        //                mesUltCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
        //                mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
        //            }

        //            mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");

        //            sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS set MesUltimoCobro = '" + mes + "' where NumeroColegiado= '" + colegiado + "' and CodigoEstablecimiento = '" + row.Cells["colCodEstable"].Value.ToString() + "' and CodigoCategoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

        //            OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //        }

        //    }

        //    return OK;
        //}

        private bool actualizarUltMesCobro(string colegiado, int mesesAdelanto, ref string error)
        {
            bool OK = true;
            string sUpdate = "";
            string sSelect = "";
            string sInsert = "";
            string mes = "";
            DataTable dt = new DataTable();
            DateTime mesUltCobro = DateTime.Now;

            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if ((bool)row.Cells["colSeleccionada"].Value)
                {
                    if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                    {
                        mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month-1, 25);
                        //if (mesesAdelanto > 1)//Si son mas de un mes le sumo todos menos el actual
                        //{
                        //  mesesAdelanto = mesesAdelanto - 1;
                        mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
                        //}
                    }
                    else
                    {
                        mesUltCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                        mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
                    }

                    mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");

                    sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS where IdColegiado = '" + colegiado + "' and NumRegistro = '" + row.Cells["colCodEstable"].Value.ToString() + "' and Categoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

                    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

                    if (OK && dt.Rows.Count > 0)
                    {
                        //mes = "";
                        //mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");
                        sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "' and NumRegistro = '" + row.Cells["colCodEstable"].Value.ToString() + "' and Categoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

                        OK = Consultas.ejecutarSentencia(sUpdate, ref error);
                    }
                    else
                    {
                        sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS (IdColegiado,NumRegistro,Categoria,MesUltimoCobro) values ('" + colegiado + "', '" + row.Cells["colCodEstable"].Value.ToString() + "', '" + row.Cells["colCodCategoria"].Value.ToString() + "', '" + mes + "')";

                        OK = Consultas.ejecutarSentencia(sInsert, ref error);
                    }
                    //sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS set MesUltimoCobro = '" + mes + "' where NumeroColegiado= '" + colegiado + "' and CodigoEstablecimiento = '" + row.Cells["colCodEstable"].Value.ToString() + "' and CodigoCategoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

                    //OK = Consultas.ejecutarSentencia(sUpdate, ref error);
                }

            }
            

            return OK;
        }

        private void activarTodos()
        {
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                row.Cells["colSeleccionada"].Value = true;
            }
            dgvRubros.EndEdit();
            calcular();
        }

        private void desactivarTodos()
        {
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                row.Cells["colSeleccionada"].Value = false;
            }
            dgvRubros.EndEdit();
            calcular();
        }

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
                calcular();
            }
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

        private void chkSaseg1_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(txtColegiado.Text))
            {
                MessageBox.Show("Debe seleccionar primero el regente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkSaseg1.Checked = false;
            }
            else
            {
                if (chkSaseg1.Checked)
                {
                    activarTodos();
                }
                else
                {
                    desactivarTodos();
                }
            }
        }

        private void dgvRubros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool todos = true;
            if (dgvRubros.CurrentCell.OwningColumn.Name == "colSeleccionada")
            {
                if ((bool)dgvRubros.Rows[e.RowIndex].Cells["colSeleccionada"].Value == false)
                {
                    dgvRubros.Rows[e.RowIndex].Cells["colSeleccionada"].Value = true;
                }
                else
                    dgvRubros.Rows[e.RowIndex].Cells["colSeleccionada"].Value = false;

                foreach (DataGridViewRow row in dgvRubros.Rows)
                {
                    if (!(bool)row.Cells["colSeleccionada"].Value)
                    {
                        todos = false;
                    }
                }
                dgvRubros.EndEdit();

                if (todos)
                    chkSaseg1.Checked = true;
                else
                    chkSaseg1.Checked = false;

                calcular();
            }
        }
    }
}
