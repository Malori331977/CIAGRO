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
    public partial class frmPagosAdelantadosRegenciaNuevo : Form
    {
        private FuncsInternas fInternas;

        public frmPagosAdelantadosRegenciaNuevo()
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
                        dgvRegencias.Rows.Clear();
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

        private void agregarRubro(string estables, string categorias)
        {
            //string sQuery = "select t2.CodigoArticulo as CODIGO, t3.DESCRIPCION, t4.PRECIO  from  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
            //        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t2 on t2.CodigoCategoria = t1.CodigoCategoria" +
            //        " join " + Consultas.sqlCon.COMPAÑIA + ".articulo t3 on t3.ARTICULO = t2.CodigoArticulo" +
            //        " join " + Consultas.sqlCon.COMPAÑIA + ".articulo_precio t4 on t4.ARTICULO = t2.CodigoArticulo" +
            //        " where t1.NumeroColegiado = '" + txtColegiado.Text + "' and t1.CodigoEstablecimiento in (" + estables + ") and t2.CodigoCategoria in (" + categorias + ")";
            string sQuery = "select t2.CodigoArticulo as CODIGO, t3.DESCRIPCION, t4.PRECIO  from  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                    " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t2 on t2.CodigoCategoria = t1.CodigoCategoria" +
                    " join " + Consultas.sqlCon.COMPAÑIA + ".articulo t3 on t3.ARTICULO = t2.CodigoArticulo" +
                    " join " + Consultas.sqlCon.COMPAÑIA + ".articulo_precio t4 on t4.ARTICULO = t2.CodigoArticulo" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                    " where t1.NumeroColegiado = '" + txtColegiado.Text + "' and t1.CodigoEstablecimiento = '" + estables + "' and t2.CodigoCategoria = '" + categorias + "'";


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

        //private void obtenerDatosRubros(ref string categorias, ref string estables)
        //{
        //    int cont = 0;
        //    foreach (DataGridViewRow row in dgvRegencias.Rows)
        //    {
        //        if ((bool)row.Cells["colSeleccionada"].Value)
        //        {
        //            if (cont == 0)
        //            {
        //                estables += "'" + row.Cells["colCodEstable"].Value.ToString() + "'";
        //                categorias += "'" + row.Cells["colCodCategoria"].Value.ToString() + "'";
        //            }
        //            else
        //            {
        //                estables += ",'" + row.Cells["colCodEstable"].Value.ToString() + "'";
        //                categorias += ",'" + row.Cells["colCodCategoria"].Value.ToString() + "'";
        //            } 

        //            cont++;
        //        }

        //    }
        //}

        private void refrescar()
        {
            //string sQuery = "SELECT t1.CodigoEstablecimiento as COD_ESTABLE,t7.Nombre as ESTABLECIMIENTO,t1.CodigoCategoria as COD_CATEG,t8.NombreCategoria as CATEGORÍA,t9.MesUltimoCobro as UltMesCobro,t4.CodigoArticulo as CODIGO,t5.DESCRIPCION,t6.PRECIO, t2.Cobrador as cobradorRegente FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES t2 ON t2.NumeroColegiado = t1.NumeroColegiado" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 ON t3.IdColegiado = t2.NumeroColegiado" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t4 ON t4.CodigoCategoria = t1.CodigoCategoria" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T5 ON T5.ARTICULO = T4.CodigoArticulo" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t6 ON t6.ARTICULO = t4.CodigoArticulo" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t7 on t7.NumRegistro = t1.CodigoEstablecimiento" +
            //            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t8 on t8.CodigoCategoria = t4.CodigoCategoria" +
            //            " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t9 on t9.NumRegistro = t7.NumRegistro" +
            //            " WHERE t2.NumeroColegiado = '" + txtColegiado.Text + "' and t1.Estado = 'A'";
            string sQuery = "select distinct t3.NumRegistro as COD_ESTABLE, t3.Nombre as ESTABLECIMIENTO, t4.NombreCategoria as CATEGORÍA, t4.CodigoCategoria as COD_CATEG, t6.MesUltimoCobro as UltMesCobro from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.NumeroColegiado" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t3 on t3.NumRegistro = t1.CodigoEstablecimiento" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t4 on t4.CodigoCategoria = t1.CodigoCategoria" +
                            " left join " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t6 on t6.IdColegiado = t2.IdColegiado and t6.NumRegistro = t1.CodigoEstablecimiento and t6.Categoria = t4.CodigoCategoria" +
                            " where t1.NumeroColegiado = '" + txtColegiado.Text + "' and t1.Estado = 'A' and t2.Condicion not in (select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where GeneraCobro = 'NO')";
            //and t6.NumRegistro = t1.CodigoEstablecimiento and t6.Categoria = t4.CodigoCategoria

            DataTable dt = new DataTable();
            string error = "";
            Cursor.Current = Cursors.WaitCursor;
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if(dt.Rows.Count > 0)
                {
                    dgvRegencias.Rows.Clear();
                    dgvRubros.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        //txtCobrador.Text = row["cobradorRegente"].ToString();
                        txtCobrador.Text = "ND";
                        dgvRegencias.Rows.Add(false, row["COD_ESTABLE"].ToString(), row["ESTABLECIMIENTO"].ToString(), row["COD_CATEG"].ToString(), row["CATEGORÍA"].ToString(), row["UltMesCobro"].ToString() != "" ? DateTime.Parse(row["UltMesCobro"].ToString()).ToString("MM/yyyy") : "");
                    }
                    //dgvRubros.Columns["colPrecio"].DefaultCellStyle.Format = "c";
                    //dgvRubros.Columns["colPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dgvRubros.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    calcular();
                    //txtMeses.Text = "1";
                    //txtDescuento.Text = "0.00";
                    dgvRegencias.AutoResizeColumns();
                }
                else
                {
                    txtColegiado.Clear();
                    txtNumeroColegiado.Clear();
                    txtNombreColegiado.Clear();
                    txtCobrador.Clear();
                    dgvRegencias.Rows.Clear();
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
                //if ((bool)row.Cells["colSeleccionada"].Value)
                    total += decimal.Parse(row.Cells["colPrecio"].Value.ToString());
            }
            total = total * decimal.Parse(txtMeses.Text);
            return total;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvRegencias.AutoResizeColumns();
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
                    "where CLIENTE = '" + txtColegiado.Text + "' and CAST(FECHA_VENCE as  date) < CAST(GETDATE() as date) and SALDO > 0 and(TIPO = 'FAC' or(TIPO = 'O/D' and SUBTIPO = '176'))";

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

            if (dgvRegencias.RowCount == 0)
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
            int indiceArticulo = 0;
            DataTable dtArticulos = new DataTable();
            DateTime mesUltCobro = DateTime.Now;

            calcular();

            foreach (DataGridViewRow row in dgvRegencias.Rows)
            {
                if ((bool)row.Cells["colSeleccionada"].Value)
                {
                    string factura = "";
                    Consultas.sqlCon.iniciaTransaccion();

                    decimal desc = txtDescuento.Text != "" ? decimal.Parse(txtDescuento.Text) : 0;
                    //string sQuery = "select t2.CodigoArticulo as CODIGO, t3.DESCRIPCION, t4.PRECIO " +
                    string sQuery = "select t3.ARTICULO as CODIGO, t3.DESCRIPCION, t4.PRECIO, '" + txtMeses.Text + "' CANTIDAD, (t4.PRECIO * CONVERT(numeric(4,2),(" + desc + "/100.00))) DESCUENTO" +
                            " from  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t1" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART t2 on t2.CodigoCategoria = t1.CodigoCategoria" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".articulo t3 on t3.ARTICULO = t2.CodigoArticulo" +
                            " join " + Consultas.sqlCon.COMPAÑIA + ".articulo_precio t4 on t4.ARTICULO = t2.CodigoArticulo" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                            " where t1.NumeroColegiado = '" + txtColegiado.Text + "' and t1.CodigoEstablecimiento = '" + row.Cells["colCodEstable"].Value.ToString() + "' and t2.CodigoCategoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";
                    
                    OK = Consultas.fillDataTable(sQuery, ref dtArticulos, ref error);

                    if (OK)
                    {
                        if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
                        {
                            mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month - 1, 25);
                            //mesUltCobro = mesUltCobro.AddMonths(txtMeses.Text);
                            
                        }
                        else
                        {
                            mesUltCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                            //mesUltCobro = mesUltCobro.AddMonths(txtMeses.Text);
                        }
                    }

                    if (OK)
                        OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtColegiado.Text, ref error);

                    string observacion = row.Cells["colCodEstable"].Value.ToString() + "-" + row.Cells["colCategoria"].Value.ToString() + " HASTA " + mesUltCobro.AddMonths(int.Parse(txtMeses.Text)).ToString("MMMM yyyy").ToUpper();
                    if (OK)
                        //OK = controlerBD.FacturarSinPedido(dtArticulos, txtColegiado.Text, ref factura, calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), decimal.Parse(txtDescuento.Text), false, indiceArticulo, txtCobrador.Text, "ADEL", "FACTURAS", "REG", observacion, observacion, row.Cells["colCodEstable"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), ref error);
                        OK = controlerBD.crearPedidoRegencia(dtArticulos, txtColegiado.Text, row.Cells["colCodEstable"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), row.Cells["colCategoria"].Value.ToString(), int.Parse(txtMeses.Text), calcularDescuento(calcularTotal(decimal.Parse(txtMeses.Text))), decimal.Parse(txtDescuento.Text), txtCobrador.Text, "adelanto", mesUltCobro.ToString(), ref error);

                    ////if(OK)    
                    ////    OK = actualizarUltMesCobro(txtColegiado.Text, int.Parse(txtMeses.Text), ref error);
                    if (OK)
                        OK = guardarUltimoCobro(row, int.Parse(txtMeses.Text), ref error);

                    if (OK)
                    {
                        Consultas.sqlCon.Commit();
                        buscaRegente(txtNumeroColegiado.Valor);
                        MessageBox.Show("Se genero el adelanto exitosamente en el ERP.", "Adelanto de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Consultas.sqlCon.Rollback();
                        MessageBox.Show("Error generando el adelanto:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                     
                }
            }

           
            Cursor.Current = Cursors.Default;
        }

        private bool validarMarcadas()
        {
            bool OK = false;
            foreach (DataGridViewRow row in dgvRegencias.Rows)
            {
                if ((bool)row.Cells["colSeleccionada"].Value)
                {
                    OK = true;
                }

            }

            return OK;
        }

        private bool guardarUltimoCobro(DataGridViewRow row, int mesesAdelanto, ref string error)
        {
            Listado list = new Listado();
            List<string> parametros = new List<string>();
            bool lbOK = true;
            DateTime mesUltCobro = DateTime.Now;

            if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
            {
                mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month, 25);
                mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
            }
            else
            {
                mesUltCobro = DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
                mesUltCobro = mesUltCobro.AddMonths(mesesAdelanto);
            }

            if (fInternas.existeUltimoCobro(txtColegiado.Text, row.Cells["colCodEstable"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), string.Empty, "REG"))
            {
                fInternas.actualizarUltimoCobro(ref parametros, ref list, string.Empty, mesUltCobro, txtColegiado.Text, row.Cells["colCodEstable"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), "REG");

                if (lbOK)
                    lbOK = Consultas.actualizar(parametros, list, Constantes.ID_BIT_UPDATE_ULTIMO_COBRO, ref error);
            }
            else
            {
                fInternas.agregarUltimoCobro(ref parametros, ref list, string.Empty, mesUltCobro, txtColegiado.Text, row.Cells["colCodEstable"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), "REG");
                if (lbOK)
                    lbOK = Consultas.insertar(parametros, list, Constantes.ID_BIT_CREAR_ULTIMO_COBRO, ref error);
            }

            return lbOK;
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

        //private bool actualizarUltMesCobro(string colegiado, int mesesAdelanto, ref string error)
        //{
        //    bool OK = true;
        //    string sUpdate = "";
        //    string sSelect = "";
        //    string sInsert = "";
        //    string mes = "";
        //    DataTable dt = new DataTable();
        //    DateTime mesUltCobro = DateTime.Now;

        //    foreach (DataGridViewRow row in dgvRegencias.Rows)
        //    {
        //        if ((bool)row.Cells["colSeleccionada"].Value)
        //        {
        //            if (row.Cells["colUltimoCobro"].Value.ToString().Equals(""))
        //            {
        //                mesUltCobro = new DateTime(mesUltCobro.Year, mesUltCobro.Month-1, 25);
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

        //            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS where IdColegiado = '" + colegiado + "' and NumRegistro = '" + row.Cells["colCodEstable"].Value.ToString() + "' and Categoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

        //            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

        //            if (OK && dt.Rows.Count > 0)
        //            {
        //                //mes = "";
        //                //mes = mesUltCobro.ToString("yyyy-MM-ddTHH:mm:ss");
        //                sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS set MesUltimoCobro = '" + mes + "' where IdColegiado= '" + colegiado + "' and NumRegistro = '" + row.Cells["colCodEstable"].Value.ToString() + "' and Categoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

        //                OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //            }
        //            else
        //            {
        //                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS (IdColegiado,NumRegistro,Categoria,MesUltimoCobro) values ('" + colegiado + "', '" + row.Cells["colCodEstable"].Value.ToString() + "', '" + row.Cells["colCodCategoria"].Value.ToString() + "', '" + mes + "')";

        //                OK = Consultas.ejecutarSentencia(sInsert, ref error);
        //            }
        //            //sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS set MesUltimoCobro = '" + mes + "' where NumeroColegiado= '" + colegiado + "' and CodigoEstablecimiento = '" + row.Cells["colCodEstable"].Value.ToString() + "' and CodigoCategoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

        //            //OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //        }

        //    }


        //    return OK;
        //}

        private void activarTodos()
        {
            foreach (DataGridViewRow row in dgvRegencias.Rows)
            {
                row.Cells["colSeleccionada"].Value = true;
            }
            dgvRegencias.EndEdit();
            calcular();
        }

        private void desactivarTodos()
        {
            foreach (DataGridViewRow row in dgvRegencias.Rows)
            {
                row.Cells["colSeleccionada"].Value = false;
            }
            dgvRegencias.EndEdit();
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
            //string categoriasRubros = "";
            //string establesRubros = "";

            //if (dgvRegencias.CurrentCell.OwningColumn.Name == "colSeleccionada")
            //{
            //    if ((bool)dgvRegencias.Rows[e.RowIndex].Cells["colSeleccionada"].Value == false)
            //    {
            //        dgvRegencias.Rows[e.RowIndex].Cells["colSeleccionada"].Value = true;
            //    }
            //    else
            //        dgvRegencias.Rows[e.RowIndex].Cells["colSeleccionada"].Value = false;

            //    foreach (DataGridViewRow row in dgvRegencias.Rows)
            //    {
            //        if (!(bool)row.Cells["colSeleccionada"].Value)
            //        {
            //            todos = false;
            //        }
            //    }
            //    dgvRegencias.EndEdit();

            //    if (todos)
            //        chkSaseg1.Checked = true;
            //    else
            //        chkSaseg1.Checked = false;

            //    //obtenerDatosRubros(ref categoriasRubros,ref establesRubros);
            //    //if (!categoriasRubros.Equals("") && !establesRubros.Equals(""))
            //    //    agregarRubro(establesRubros, categoriasRubros);
            //    //else
            //    //    dgvRubros.Rows.Clear();

            //    calcular();
            //}

            if (dgvRegencias.CurrentCell.OwningColumn.Name == "colSeleccionada")
            {
                if ((bool)dgvRegencias.Rows[e.RowIndex].Cells["colSeleccionada"].Value == false)
                {
                    foreach (DataGridViewRow row in dgvRegencias.Rows)
                    {
                        if ((bool)row.Cells["colSeleccionada"].Value)
                        {
                            row.Cells["colSeleccionada"].Value = false;
                        }
                    }
                    dgvRegencias.Rows[e.RowIndex].Cells["colSeleccionada"].Value = true;

                    agregarRubro(dgvRegencias.Rows[e.RowIndex].Cells["colCodEstable"].Value.ToString(), dgvRegencias.Rows[e.RowIndex].Cells["colCodCategoria"].Value.ToString());
                }
                else
                {
                    dgvRegencias.Rows[e.RowIndex].Cells["colSeleccionada"].Value = false;
                    dgvRubros.Rows.Clear();
                }
                    

                dgvRegencias.EndEdit();
                
            }
        }
    }
}
