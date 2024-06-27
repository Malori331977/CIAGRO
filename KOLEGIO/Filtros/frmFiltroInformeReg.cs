using System;
using System.Collections;
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
    public partial class frmFiltroInformeReg : Form
    {
        protected string error = "";
        private Listado listRPT;
        private string rpt;
        private string titulo;
        private string tipo;
        private FuncsInternas fi;
        private string oldValue = "";
        private string nombreReporte = "";
        private ArrayList tipos;

        public frmFiltroInformeReg()
        {
            InitializeComponent();
            listRPT = new Listado();
            this.tipos = new ArrayList();
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            nombreReporte = "";

            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listRPT.TABLA = "NV_RPT_INFORME_REGENCIA";
            nombreReporte = "RPT_InformesRegencias.rpt";


            listRPT.FILTRO = armaFiltro();
        }
        #endregion

        #region ARMAR_FILTRO
        private string armaFiltro()
        {
            string sentencia = "WHERE ";
            string estados = "";

            if (chkActivarRangoFechas.Checked)
            {
                
                if (sentencia.Equals("WHERE "))
                    sentencia += "FechaUltimoInforme between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                else
                    sentencia += "and FechaUltimoInforme between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                    
            }

            if (chkActivo.Checked)
                estados += "'A'";

            if (chkInactivo.Checked && !estados.Equals(""))
                estados += ",'I'";
            else
                if (chkInactivo.Checked && estados.Equals(""))
                estados += "'I'";

            if (chkSuspendido.Checked && !estados.Equals(""))
                estados += ",'S'";
            else
                if (chkSuspendido.Checked && estados.Equals(""))
                estados += "'S'";

            if (chkActivo.Checked || chkInactivo.Checked || chkSuspendido.Checked)
            {

                if (sentencia.Equals("WHERE "))
                    sentencia += "EstadoRegencia in ("+estados+")";
                else
                    sentencia += "and EstadoRegencia in (" + estados + ")";
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
