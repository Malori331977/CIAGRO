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
    public partial class frmFiltroEstables_Consul : Form
    {
        protected string error = "";
        private Listado listRPT;
        private string rpt;
        private string titulo;
        private string tipo;
        private FuncsInternas fi;
        private string oldValue = "";
        private string nombreReporte = "";

        public frmFiltroEstables_Consul(string tipo)
        {
            InitializeComponent();
            listaEstados(tipo);
            listaCategorias();
            this.tipo = tipo;
            listRPT = new Listado();
			if (!this.tipo.Equals("estable"))
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
			}
            //if (tipo == 1)
            //{
            //    grbMoneda.Visible = true;
            //    grbMoneda.BringToFront();
            //    grbMontos.Visible = true;
            //    grbMontos.BringToFront();
            //}
            //if (tipo == 2)
            //{
            //    groupBox1.Visible = true;
            //    groupBox1.BringToFront();
            //    groupBox3.Visible = false;
            //}
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            nombreReporte = "";

            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            
            if (rbGeneral.Checked)
            {
                if (this.tipo.Equals("estable"))
                {
                    listRPT.TABLA = "NV_FICHA_ESTABLECIMIENTOS";
                    nombreReporte = "RPT_FichaEstablecimientos.rpt";
                }
                else
                {
                    listRPT.TABLA = "NV_FICHA_CONSULTORAS";
                    nombreReporte = "RPT_FichaConsultoras.rpt";
                }
            }
            else
            {
                if (this.tipo.Equals("estable"))
                {
                    listRPT.TABLA = "NV_FICHA_ESTABLECIMIENTOS";
                    nombreReporte = "RPT_ListadoCategPorEstablecimiento.rpt";
                }
                else
                {
                    listRPT.TABLA = "NV_FICHA_CONSULTORAS";
                    nombreReporte = "RPT_ListadoCamposPorConsultoras.rpt";
                }
            }

            listRPT.FILTRO = armaFiltro();
        }
        #endregion

        #region ARMAR_FILTRO
        private string armaFiltro()
        {
            string sentencia = "WHERE ";

            if (this.cmbEstados.SelectedValue != null)
            {
                sentencia += "CodigoEstado = '" + cmbEstados.SelectedValue + "' ";
            }

            if (this.cmbCategorias.SelectedValue != null)
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "CodigoCategoria = '" + cmbCategorias.SelectedValue + "' ";
                else
                    sentencia += "and CodigoCategoria = '" + cmbCategorias.SelectedValue + "' ";
            }

            //if (!txtCobrador.Text.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "CodigoCobrador = '" + txtCobrador.Text + "' ";
            //    else
            //        sentencia += "and CodigoCobrador = '" + txtCobrador.Text + "' ";
            //}

            if (!txtProvincia.Valor.Equals(""))
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "provincia = '" + txtProvinciaNombreF.Valor + "' ";
                else
                    sentencia += "and provincia = '" + txtProvinciaNombreF.Valor + "' ";
            }

            if (!txtCanton.Valor.Equals(""))
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "[Cantón] = '" + txtCantonNombreF.Valor + "' ";
                else
                    sentencia += "and [Cantón] = '" + txtCantonNombreF.Valor + "' ";
            }

            if (!txtDistrito.Valor.Equals(""))
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "distrito = '" + txtDistritoNombreF.Valor + "' ";
                else
                    sentencia += "and distrito = '" + txtDistritoNombreF.Valor + "' ";
            }

            if (chkActivarRangoFechas.Checked)
            {
                if (tipo.Equals("estable"))
                {
                    if (sentencia.Equals("WHERE "))
                        sentencia += "[Fecha Inscripción] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                    else
                        sentencia += "and [Fecha Inscripción] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                }
                else
                {
                    if (sentencia.Equals("WHERE "))
                        sentencia += "[Fecha Aprobacion] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                    else
                        sentencia += "and [Fecha Aprobacion] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                }
            }

            return sentencia == "WHERE " ? " " : sentencia;
        }

        #endregion

        #region BOTON_BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            if (Utilitario.BuscaForm("frmVisorRpt"))
            {
                DataTable dtRpt = new DataTable();
                armarTablaRpt();
                Cursor.Current = Cursors.WaitCursor;
                if (Consultas.listarDatos(listRPT, ref dtRpt, ref error))
                {
                    if (dtRpt.Rows.Count > 0)
                    {
                        frmVisorRpt rptCG = new frmVisorRpt(dtRpt, nombreReporte);
                        Cursor.Current = Cursors.Default;
                        rptCG.ShowDialog();
                    }
                    else
                    {
                        error = "No hay información para generar el reporte.";
                        MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //private void listaCobradores()
        //{
        //    Listado listP = new Listado();
        //    listP.COLUMNAS = "Cobrador,Nombre";
        //    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listP.TABLA = "COBRADOR";
        //    listP.ORDERBY = "order by Cobrador";
        //    listP.TITULO_LISTADO = "Cobradores";
        //    frmF1 f1Cobrador = new frmF1(listP);
        //    f1Cobrador.ShowDialog();
        //    if (f1Cobrador.item != null)
        //    {
        //        txtCobrador.Text = f1Cobrador.item.SubItems[0].Text;
        //        txtCobradorDesc.Text = f1Cobrador.item.SubItems[1].Text;
                
        //    }
        //}

        //private void buscaCobrador(string codigo)
        //{

        //    if (txtCobrador.Text.Trim() == "")
        //    {
        //        txtCobradorDesc.Clear();
        //        return;
        //    }

        //    DataTable dtCobrador = new DataTable();
        //    Listado listP = new Listado();
        //    listP.COLUMNAS = "Cobrador,Nombre";
        //    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listP.TABLA = "COBRADOR";
        //    listP.FILTRO = "where Cobrador = '" + codigo + "'";

        //    if (Consultas.listarDatos(listP, ref dtCobrador, ref error))
        //    {
        //        if (dtCobrador.Rows.Count > 0)
        //        {
        //            txtCobradorDesc.Text = dtCobrador.Rows[0]["Nombre"].ToString();
        //        }
        //        else
        //        {
        //            if (codigo != "")
        //            {
        //                MessageBox.Show("El código de cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                txtCobrador.Clear();
        //                txtCobradorDesc.Clear();
        //            }
        //        }
        //    }
        //    else
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}

        private void listaEstados(string tipo)
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoEstado,NombreEstado";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            if(tipo.Equals("estable"))
                listA.FILTRO = "where Diferenciador = 'E'";
            else
                listA.FILTRO = "where Diferenciador = 'C'";

            listA.ORDERBY = "order by CodigoEstado";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    cmbEstados.DisplayMember = "NombreEstado";
                    cmbEstados.ValueMember = "CodigoEstado";
                    cmbEstados.DataSource = dt;
                    cmbEstados.SelectedValue = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaCategorias()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoCategoria,NombreCategoria";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_CATEGORIAS";
            //listA.FILTRO = "where U_KOLEGIO='S'";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    cmbCategorias.DisplayMember = "NombreCategoria";
                    cmbCategorias.ValueMember = "CodigoCategoria";
                    cmbCategorias.DataSource = dt;
                    cmbCategorias.SelectedValue = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //private void listaCondicion()
        //{
        //    DataTable dt = new DataTable();
        //    Listado listA = new Listado();
        //    listA.COLUMNAS = "CodigoCategoria,NombreCategoria";
        //    listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listA.TABLA = "NV_CATEGORIAS";
        //    //listA.FILTRO = "where U_KOLEGIO='S'";

        //    if (Consultas.listarDatos(listA, ref dt, ref error))
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            cmbCondicion.DisplayMember = "NombreCategoria";
        //            cmbCondicion.ValueMember = "CodigoCategoria";
        //            cmbCondicion.DataSource = dt;
        //            cmbCondicion.SelectedValue = "";
        //        }
        //    }
        //    else
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        private void buscaProvincia(string codigo)
        {

            if (txtProvincia.Valor.Trim() == "")
            {
                txtProvinciaNombreF.Clear();
                txtCanton.Clear();
                txtCantonNombreF.Clear();
                txtDistrito.Clear();
                txtDistritoNombreF.Clear();
                return;
            }

            DataTable dtPais = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "DIVISION_GEOGRAFICA1,NOMBRE";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "DIVISION_GEOGRAFICA1";
            listP.FILTRO = "where DIVISION_GEOGRAFICA1 = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtPais, ref error))
            {
                if (dtPais.Rows.Count > 0)
                {
                    this.txtProvinciaNombreF.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
                }
                else
                {
                    if (codigo != "")
                        MessageBox.Show("La Provincia digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listaProvincias()
        {

            Listado listP = new Listado();
            listP.COLUMNAS = "DIVISION_GEOGRAFICA1 as Código,NOMBRE as Provincia";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "DIVISION_GEOGRAFICA1";
            listP.ORDERBY = "order by DIVISION_GEOGRAFICA1";
            listP.TITULO_LISTADO = "Provincias";
            frmF1 f1Provincias = new frmF1(listP);
            f1Provincias.ShowDialog();
            if (f1Provincias.item != null)
            {
                txtProvincia.Valor = f1Provincias.item.SubItems[0].Text;
                this.txtProvinciaNombreF.Valor = f1Provincias.item.SubItems[1].Text;
                txtCanton.Clear();
                txtDistrito.Clear();
                txtCantonNombreF.Clear();
                txtDistritoNombreF.Clear();
            }
        }

        private void listaCantones()
        {
            if (txtProvincia.Valor.Trim() == "")
            {
                MessageBox.Show("Primero debe especificar alguna provincia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtProvincia.Focus();
                return;
            }

            Listado listP = new Listado();
            listP.COLUMNAS = "DIVISION_GEOGRAFICA2 as Código,NOMBRE as Cantón";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "DIVISION_GEOGRAFICA2";
            listP.FILTRO = "WHERE DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "'";
            listP.ORDERBY = "order by DIVISION_GEOGRAFICA2";
            listP.TITULO_LISTADO = "Cantones";
            frmF1 f1Canton = new frmF1(listP);
            f1Canton.ShowDialog();
            if (f1Canton.item != null)
            {
                txtCanton.Valor = f1Canton.item.SubItems[0].Text;
                this.txtCantonNombreF.Valor = f1Canton.item.SubItems[1].Text;
                txtDistrito.Clear();
                txtDistritoNombreF.Clear();
            }
        }

        private void buscaCanton(string codigo)
        {

            if (txtCanton.Valor.Trim() == "")
            {
                txtCantonNombreF.Clear();
                txtDistrito.Clear();
                txtDistritoNombreF.Clear();
                return;
            }


            if (txtProvincia.Valor.Trim() == "")
            {
                MessageBox.Show("Primero debe elegir una provincia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtPais = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "DIVISION_GEOGRAFICA2,NOMBRE";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "DIVISION_GEOGRAFICA2";
            listP.FILTRO = "where DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "' AND DIVISION_GEOGRAFICA2 = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtPais, ref error))
            {
                if (dtPais.Rows.Count > 0)
                {
                    this.txtCantonNombreF.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
                }
                else
                {
                    if (codigo != "")
                        MessageBox.Show("El Cantón digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listaDistritos()
        {
            if (txtProvincia.Valor.Trim() == "")
            {
                MessageBox.Show("Primero debe especificar alguna provincia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtProvincia.Focus();
                return;
            }

            if (txtCanton.Valor.Trim() == "")
            {
                MessageBox.Show("Primero debe especificar algún cantón.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtProvincia.Focus();
                return;
            }

            Listado listP = new Listado();
            listP.COLUMNAS = "DIVISION_GEOGRAFICA3 as Código,NOMBRE as Distrito";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "DIVISION_GEOGRAFICA3";
            listP.FILTRO = "WHERE DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "' AND DIVISION_GEOGRAFICA2='" + txtCanton.Valor + "'";
            listP.ORDERBY = "order by DIVISION_GEOGRAFICA3";
            listP.TITULO_LISTADO = "Distritos";
            frmF1 f1Distrito = new frmF1(listP);
            f1Distrito.ShowDialog();
            if (f1Distrito.item != null)
            {
                txtDistrito.Valor = f1Distrito.item.SubItems[0].Text;
                this.txtDistritoNombreF.Valor = f1Distrito.item.SubItems[1].Text;
            }
        }

        private void buscaDistrito(string codigo)
        {

            if (txtDistrito.Valor.Trim() == "")
            {
                txtDistritoNombreF.Clear();
                return;
            }


            if (txtProvincia.Valor.Trim() == "")
            {
                MessageBox.Show("Primero debe elegir una provincia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtCanton.Valor.Trim() == "")
            {
                MessageBox.Show("Primero debe elegir un cantón.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtPais = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "DIVISION_GEOGRAFICA3,NOMBRE";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "DIVISION_GEOGRAFICA3";
            listP.FILTRO = "where DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "' AND DIVISION_GEOGRAFICA2 = '" + txtCanton.Valor + "' AND DIVISION_GEOGRAFICA3='" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtPais, ref error))
            {
                if (dtPais.Rows.Count > 0)
                {
                    txtDistritoNombreF.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
                }
                else
                {
                    if (codigo != "")
                        MessageBox.Show("El Distrito digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
             
        //private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == (char)Keys.F1)
        //        listaCobradores();
        //}

        //private void txtCobrador_Leave(object sender, EventArgs e)
        //{
        //    buscaCobrador(txtCobrador.Text);
        //}

        //private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    listaCobradores();
        //}

        //private void txtCobrador_Enter(object sender, EventArgs e)
        //{
        //    oldValue = txtCobrador.Text;
        //}

        private void txtProvincia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaProvincias();
        }

        private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaProvincias();
        }

        private void txtProvincia_Leave(object sender, EventArgs e)
        {
            buscaProvincia(txtProvincia.Valor);
        }

        private void txtCanton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCantones();
        }

        private void txtCanton_Leave(object sender, EventArgs e)
        {
            buscaCanton(txtCanton.Valor);
        }

        private void txtCanton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCantones();
        }

        private void txtDistrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaDistritos();
        }

        private void txtDistrito_Leave(object sender, EventArgs e)
        {
            buscaDistrito(txtDistrito.Valor);
        }

        private void txtDistrito_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaDistritos();
        }

        private void btnLimpiarCmb_Click(object sender, EventArgs e)
        {
            cmbEstados.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbCategorias.SelectedIndex = -1;
        }

        private void chkActivarRangoFechas_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkActivarRangoFechas.Checked)
            {
                dtpPeriodoDesde.Enabled = true;
                dtpPeriodoHasta.Enabled = true;
            }
            else
            {
                dtpPeriodoDesde.Enabled = false;
                dtpPeriodoHasta.Enabled = false;
            }

        }

        
    }
}
