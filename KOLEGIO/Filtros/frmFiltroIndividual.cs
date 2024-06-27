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
    public partial class frmFiltroIndividual : Form
    {
        protected string error = "";
        private Listado listRPT;
        private string rpt;
        private string titulo;
        private string tipo;
        private string vista;
        private string reporte;
        private FuncsInternas fi;
        private string oldValue = "";
        private string nombreReporte = "";

        public frmFiltroIndividual(string tipo, string vista, string reporte)
        {
            InitializeComponent();
            listaEstados(tipo);
            this.tipo = tipo;
            this.vista = vista;
            this.reporte = reporte;
            listRPT = new Listado();
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            nombreReporte = "";

            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listRPT.TABLA = vista;
            nombreReporte = reporte;


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
                        
            if (!txtProvincia.Valor.Equals(""))
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "provincia = '" + txtProvincia.Valor + "' ";
                else
                    sentencia += "and provincia = '" + txtProvincia.Valor + "' ";
            }

            if (!txtCanton.Valor.Equals(""))
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "canton = '" + txtCanton.Valor + "' ";
                else
                    sentencia += "and canton = '" + txtCanton.Valor + "' ";
            }

            if (!txtDistrito.Valor.Equals(""))
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "distrito = '" + txtDistrito.Valor + "' ";
                else
                    sentencia += "and distrito = '" + txtDistrito.Valor + "' ";
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
