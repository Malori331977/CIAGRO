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
    public partial class frmFiltroIndividualReg : Form
    {
        protected string error = "";
        private Listado listRPT;
        //private string rpt;
        //private string titulo;
        private string vista;
        private string reporte;
        private string tipo;
        private string nombreReporte;
        private FuncsInternas fi;
        private string oldValue = "";

        public frmFiltroIndividualReg(string tipo, string vista, string reporte)
        {
            InitializeComponent();
            listaCondiciones();
            listaCategoriasCole();
            listaEstados(tipo);
            listaCategorias();
            listRPT = new Listado();
            this.tipo = tipo;
            this.vista = vista;
            this.reporte = reporte;
        }

        public frmFiltroIndividualReg(string tipo)
        {
            InitializeComponent();
            listaCondiciones();
            listaCategoriasCole();
            listaEstados(tipo);
            listaCategorias();
            listRPT = new Listado();
            this.tipo = tipo;
            this.vista = "";
            this.reporte = "";
            cmbEstadosReg.Items.Add("Activa");
            cmbEstadosReg.Items.Add("Inactiva");
            cmbEstadosReg.Items.Add("Sancionada");
            cmbEstadosReg.SelectedIndex = -1;
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            nombreReporte = "";

            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            if (rbGeneral.Checked)
            {
                if (vista.Equals(""))
                    listRPT.TABLA = "NV_RPT_REGENTES_POR_ESTABLECIMIENTOS";
                else
                    listRPT.TABLA = vista;

                if (reporte.Equals(""))
                    nombreReporte = "RPT_RegentesPorEstable.rpt";
                else
                    nombreReporte = reporte;
            }
            else if (rbLinea.Checked)
            {
                if (vista.Equals(""))
                    listRPT.TABLA = "NV_RPT_REGENTES_POR_ESTABLECIMIENTOS";
                else
                    listRPT.TABLA = vista;

                if (reporte.Equals(""))
                    nombreReporte = "RPT_RegentesPorEstableEnLinea.rpt";
                else
                    nombreReporte = reporte;
            }
            else if (rbPorProvincia.Checked)
            {
                if (vista.Equals(""))
                    listRPT.TABLA = "NV_RPT_REGENTES_POR_ESTABLECIMIENTOS";
                else
                    listRPT.TABLA = vista;

                if (reporte.Equals(""))
                    nombreReporte = "RPT_RegentesPorEstableEnLinea2.rpt";
                else
                    nombreReporte = reporte;
            }



            listRPT.FILTRO = armaFiltro();
        }
        #endregion

        #region ARMAR_FILTRO
        private string armaFiltro()
        {
            string sentencia = "WHERE ";

            if (this.cmbCondiciones.SelectedValue != null)
            {
                sentencia += "CodigoCondicion = '" + cmbCondiciones.SelectedValue + "' ";
            }

            if (this.cmbCategoriasCole.SelectedValue != null)
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "CodigoCategoriaCol = '" + cmbCategoriasCole.SelectedValue + "' ";
                else
                    sentencia += "and CodigoCategoriaCol = '" + cmbCategoriasCole.SelectedValue + "' ";
            }

            //if (!txtCobrador.Text.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "CodigoCobrador = '" + txtCobrador.Text + "' ";
            //    else
            //        sentencia += "and CodigoCobrador = '" + txtCobrador.Text + "' ";
            //}

            //if (!txtProvincia.Valor.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "provincia = '" + txtProvinciaNombreF.Valor + "' ";
            //    else
            //        sentencia += "and provincia = '" + txtProvinciaNombreF.Valor + "' ";
            //}

            //if (!txtCanton.Valor.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "[Cantón] = '" + txtCantonNombreF.Valor + "' ";
            //    else
            //        sentencia += "and [Cantón] = '" + txtCantonNombreF.Valor + "' ";
            //}

            //if (!txtDistrito.Valor.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "distrito = '" + txtDistritoNombreF.Valor + "' ";
            //    else
            //        sentencia += "and distrito = '" + txtDistritoNombreF.Valor + "' ";
            //}

            if (chkActivarRangoFechas.Checked)
            {
                
                if (sentencia.Equals("WHERE "))
                    sentencia += "[Fecha Nacimiento] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                else
                    sentencia += "and [Fecha Nacimiento] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                
            }

            if (this.cmbCategorias.SelectedValue != null)
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "codigocategoria = '" + cmbCategorias.SelectedValue + "' ";
                else
                    sentencia += "and codigocategoria = '" + cmbCategorias.SelectedValue + "' ";
            }

            if (this.cmbEstados.SelectedValue != null)
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "Est = '" + cmbEstados.SelectedValue + "' ";
                else
                    sentencia += "and Est = '" + cmbEstados.SelectedValue + "' ";
            }

            if (this.cmbEstadosReg.SelectedItem != null)
            {
                if (sentencia.Equals("WHERE "))
                    sentencia += "Estado = '" + cmbEstadosReg.SelectedItem + "' ";
                else
                    sentencia += "and Estado = '" + cmbEstadosReg.SelectedItem + "' ";
            }

            if (chkActivarRangoFechasEst.Checked)
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

            if (sentencia == "WHERE ")
                sentencia = " ";
            else
                sentencia = sentencia + " order by provincia, Cantón, distrito";

            //return sentencia == "WHERE " ? " " : sentencia;
            return sentencia;
        }

        #endregion

        private void listaCondiciones()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoCondicion,NombreCondicion";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_CONDICIONES";
            listA.ORDERBY = "order by CodigoCondicion";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    cmbCondiciones.DisplayMember = "NombreCondicion";
                    cmbCondiciones.ValueMember = "CodigoCondicion";
                    cmbCondiciones.DataSource = dt;
                    cmbCondiciones.SelectedValue = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaCategoriasCole()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CATEGORIA_CLIENTE,DESCRIPCION";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "CATEGORIA_CLIENTE";
            listA.FILTRO = "where U_KOLEGIO='S'";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    cmbCategoriasCole.DisplayMember = "DESCRIPCION";
                    cmbCategoriasCole.ValueMember = "CATEGORIA_CLIENTE";
                    cmbCategoriasCole.DataSource = dt;
                    cmbCategoriasCole.SelectedValue = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaEstados(string tipo)
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoEstado,NombreEstado";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            if (tipo.Equals("estable"))
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

        private void btnLimpiarCmbCondi_Click(object sender, EventArgs e)
        {
            cmbCondiciones.SelectedIndex = -1;
        }

        private void btnLimpiarCmbEst_Click(object sender, EventArgs e)
        {
            cmbEstados.SelectedIndex = -1;
        }

        private void btnLimpiarCmbCateg_Click(object sender, EventArgs e)
        {
            cmbCategorias.SelectedIndex = -1;
        }

        private void btnLimpiarCmbCategCole_Click(object sender, EventArgs e)
        {
            cmbCategoriasCole.SelectedIndex = -1;
        }

		private void btnLimpiarEstadoReg_Click(object sender, EventArgs e)
		{
            cmbEstadosReg.SelectedIndex = -1;
        }
	}
}
