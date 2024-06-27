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
    public partial class frmFiltroPeritos : Form
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

        public frmFiltroPeritos()
        {
            InitializeComponent();
            //listaEstados(tipo);
            listaTipos();
            listRPT = new Listado();
            this.tipos = new ArrayList();
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            nombreReporte = "";

            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listRPT.TABLA = "NV_RPT_PERITOS";
            //nombreReporte = "RPT_Peritos.rpt";
            nombreReporte = "RPT_PeritosEnLinea.rpt";


            listRPT.FILTRO = armaFiltro();
        }
        #endregion

        #region ARMAR_FILTRO
        private string armaFiltro()
        {
            string sentencia = "WHERE ";

            //if (this.cmbEstados.SelectedValue != null)
            //{
            //    sentencia += "CodigoEstado = '" + cmbEstados.SelectedValue + "' ";
            //}
                        
            //if (!txtProvincia.Valor.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "provincia = '" + txtProvincia.Valor + "' ";
            //    else
            //        sentencia += "and provincia = '" + txtProvincia.Valor + "' ";
            //}

            //if (!txtCanton.Valor.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "canton = '" + txtCanton.Valor + "' ";
            //    else
            //        sentencia += "and canton = '" + txtCanton.Valor + "' ";
            //}

            //if (!txtDistrito.Valor.Equals(""))
            //{
            //    if (sentencia.Equals("WHERE "))
            //        sentencia += "distrito = '" + txtDistrito.Valor + "' ";
            //    else
            //        sentencia += "and distrito = '" + txtDistrito.Valor + "' ";
            //}

            //if (chkActivarRangoFechas.Checked)
            //{
            //    if (tipo.Equals("estable"))
            //    {
            //        if (sentencia.Equals("WHERE "))
            //            sentencia += "[Fecha Inscripción] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
            //        else
            //            sentencia += "and [Fecha Inscripción] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
            //    }
            //    else
            //    {
            //        if (sentencia.Equals("WHERE "))
            //            sentencia += "[Fecha Aprobacion] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
            //        else
            //            sentencia += "and [Fecha Aprobacion] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
            //    }
            //}

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

        private void listaTipos()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoTipo,NombreTipo";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_Tipos";
            listA.FILTRO = "where Diferenciador = 'P'";
            listA.ORDERBY = "order by CodigoTipo";
            
            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    ((ListBox)clbTipos).DataSource = dt;
                    ((ListBox)clbTipos).DisplayMember = "NombreTipo";
                    ((ListBox)clbTipos).ValueMember = "CodigoTipo";
                    ((ListBox)clbTipos).SelectedIndex = -1;
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaInstituciones()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoEmpresa,NombreEmpresa";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_EMPRESAS";
            listP.ORDERBY = "order by CodigoEmpresa";
            listP.TITULO_LISTADO = "Empresas";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                dgvInstituciones.CurrentCell.OwningRow.Cells["colCodigoInst"].Value = f1Colegiado.item.SubItems[0].Text;
                dgvInstituciones.CurrentCell.OwningRow.Cells["colNombreInst"].Value = f1Colegiado.item.SubItems[1].Text;
                dgvInstituciones.EndEdit();
            }
        }

        private void clbTipos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                //if (clbInstituciones.CheckedItems.Count == 5)
                //{
                //    MessageBox.Show("Esta permitido un máximo de 5 Instituciones para filtrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    e.NewValue = CheckState.Unchecked;
                //}
                //else
                //{
                DataRow r = ((DataRowView)this.clbTipos.Items[e.Index]).Row;
                tipos.Add(r["CodigoTipo"]);
                //}
            }
            else
            {
                e.NewValue = CheckState.Unchecked;
                DataRow r = ((DataRowView)this.clbTipos.Items[e.Index]).Row;
                tipos.Remove(r["CodigoTipo"]);
            }
        }

        private void btnNuevoEst_Click(object sender, EventArgs e)
        {
            dgvInstituciones.Rows.Add("","");
        }

        private void btnEliminaEst_Click(object sender, EventArgs e)
        {
            dgvInstituciones.Rows.Remove(dgvInstituciones.CurrentRow);
        }

        private void dgvInstituciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvInstituciones.CurrentRow != null)
            {
                if (dgvInstituciones.CurrentCell.OwningColumn.Name == "colCodigoInst" || dgvInstituciones.CurrentCell.OwningColumn.Name == "colNombreInst"/*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
                {
                    listaInstituciones();
                }
            }
        }
    }
}
