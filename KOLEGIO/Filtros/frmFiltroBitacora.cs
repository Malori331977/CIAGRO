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
    public partial class frmFiltroBitacora : Form
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

        public frmFiltroBitacora()
        {
            InitializeComponent();
            listaUsuarios();
            listRPT = new Listado();
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listRPT.TABLA = "NV_RPT_AUDITORIA";
            nombreReporte = "RPT_Bitacora.rpt";


            listRPT.FILTRO = armaFiltro();
        }
        #endregion

        #region ARMAR_FILTRO
        private string armaFiltro()
        {
            string sentencia = "WHERE ";

            if (this.cmbUsuarios.SelectedValue != null)
            {
                sentencia += "Usuario = '" + cmbUsuarios.SelectedValue + "' ";
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

        
        private void listaUsuarios()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoUsuario,PrimerNombreUsuario + ' ' + PrimerApellidoUsuario + ' ' + SegundoApellidoUsuario as Nombre";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_USUARIOS";
            

            listA.ORDERBY = "order by CodigoUsuario";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    cmbUsuarios.DisplayMember = "Nombre";
                    cmbUsuarios.ValueMember = "CodigoUsuario";
                    cmbUsuarios.DataSource = dt;
                    cmbUsuarios.SelectedValue = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void btnLimpiarCmb_Click(object sender, EventArgs e)
        {
            cmbUsuarios.SelectedIndex = -1;
        }

    }
}
