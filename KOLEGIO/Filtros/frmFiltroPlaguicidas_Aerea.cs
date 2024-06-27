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
    public partial class frmFiltroPlaguicidas_Aerea : Form
    {
        protected string error = "";
        private Listado listRPT;
        private string rpt;
        private string titulo;
        private string tipo;
        private string vista;
        private string oldValueRb;
        private FuncsInternas fi;
        private string oldValue = "";
        private string nombreReporte = "";

        public frmFiltroPlaguicidas_Aerea()
        {
            InitializeComponent();
            //this.tipo = tipo;
            //this.vista = vista;
            //this.reporte = reporte;
            rbPlagui.Checked = true;
            oldValueRb = "P";
            listRPT = new Listado();
        }

        #region ARMAR_TABLA
        private void armarTablaRpt()
        {
            nombreReporte = "";

            listRPT.COLUMNAS = "*";
            listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            if (rbPlagui.Checked)
            {
                listRPT.TABLA = "NV_RPT_PLAGUICIDAS";
                nombreReporte = "Rpt_PlaguicidasPorColegiadoLinea.rpt";
            }
            else
            {
                listRPT.TABLA = "NV_RPT_AEREAS";
                nombreReporte = "Rpt_AereasPorColegiadoLinea.rpt";
            }


            listRPT.FILTRO = armaFiltro();
        }
        #endregion

        #region ARMAR_FILTRO
        private string armaFiltro()
        {
            int cont = 0;
            string colegiados = "";
            string sentencia = "WHERE ";

            if (dgvColegiados.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvColegiados.Rows)
                {
                    if (cont == 0)
                        colegiados += "'" + row.Cells["colIdColegiado"].Value.ToString() + "'";
                    else 
                        colegiados += ",'" + row.Cells["colIdColegiado"].Value.ToString() + "'";

                    cont++;
                }

                sentencia += "IdColegiado in (" + colegiados + ")";
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

        private void buscaColegiadoLeave(string codigo)
        {

            if (txtNColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = " distinct t1.IdColegiado, t2.Nombre, t2.Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            if (rbAerea.Checked)
                listP.TABLA = "NV_VIA_AEREA_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.IdColegiado";
            else
                listP.TABLA = "NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.IdColegiado";
            listP.FILTRO = "where t2.NumeroColegiado = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtIdColegiado.Valor = dtColegiado.Rows[0]["IdColegiado"].ToString();
                    txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
                    //txtCobrador.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    //buscaCobrador(txtCobrador.Valor);
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdColegiado.Clear();
                        txtNColegiado.Clear();
                        txtNombreColegiado.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buscaColegiado(string codigo)
        {

            if (txtIdColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = " distinct t1.IdColegiado, (select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.IdColegiado) as Colegiado, (select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.IdColegiado) as Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            if (rbAerea.Checked)
                listP.TABLA = "NV_VIA_AEREA_COLEGIADO t1";
            else
                listP.TABLA = "NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t1";
            listP.FILTRO = "where t1.IdColegiado = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
                    //txtCobrador.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    //buscaCobrador(txtCobrador.Valor);
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe o no tiene registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdColegiado.Clear();
                        txtNColegiado.Clear();
                        txtNombreColegiado.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listaColegiados()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = " distinct t1.IdColegiado, (select NumeroColegiado from "+Consultas.sqlCon.COMPAÑIA+ ".NV_COLEGIADO where IdColegiado = t1.IdColegiado) as Colegiado, (select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.IdColegiado) as Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            if(rbAerea.Checked)
                listP.TABLA = "NV_VIA_AEREA_COLEGIADO t1";
            else
                listP.TABLA = "NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t1";
            listP.COLUMNAS_PK.Add("t1.IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("t1.IdColegiado");

            listP.ORDERBY = "order by t1.IdColegiado";
            listP.TITULO_LISTADO = "Colegiados";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                txtIdColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
                txtNColegiado.Valor = f1Colegiado.item.SubItems[1].Text;
                txtNombreColegiado.Valor = f1Colegiado.item.SubItems[2].Text;
            }
            buscaColegiado(txtIdColegiado.Valor);
        }

        private void txtNColegiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtIdColegiado.ReadOnly)
                listaColegiados();
        }

        private void txtNColegiado_Leave(object sender, EventArgs e)
        {
            buscaColegiadoLeave(txtNColegiado.Valor);
        }

        private void txtNColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtIdColegiado.ReadOnly)
            {
                listaColegiados();
            }
        }

        private void btnNuevoEst_Click(object sender, EventArgs e)
        {
            if (!txtIdColegiado.Valor.Equals(""))
            {
                dgvColegiados.Rows.Add(txtIdColegiado.Valor, txtNColegiado.Valor, txtNombreColegiado.Valor);
                txtIdColegiado.Clear();
                txtNColegiado.Clear();
                txtNombreColegiado.Clear();
            }
        }

        private void btnEliminaEst_Click(object sender, EventArgs e)
        {
            if (dgvColegiados.Rows.Count > 0)
            {
                dgvColegiados.Rows.Remove(dgvColegiados.CurrentRow);
            }
        }

        private void rbAerea_MouseClick(object sender, MouseEventArgs e)
        {
            if (!oldValueRb.Equals("A"))
                dgvColegiados.Rows.Clear();

            oldValueRb = "A";
        }

        private void rbPlagui_MouseClick(object sender, MouseEventArgs e)
        {
            if (!oldValueRb.Equals("P"))
                dgvColegiados.Rows.Clear();

            oldValueRb = "P";
        }
    }
}
