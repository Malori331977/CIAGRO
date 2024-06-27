using Framework;
using System;
using System.Data;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmFiltroActividades : Form
	{
		protected string error = "";
		private Listado listRPT;
		private string nombreReporte;
		private FuncsInternas fi;
		private string oldValue = "";

		public frmFiltroActividades()
		{
			InitializeComponent();
			listaActividades();
			listRPT = new Listado();
		}

		#region ARMAR_TABLA
		private void armarTablaRpt()
		{
			nombreReporte = "";

			listRPT.COLUMNAS = "*";
			listRPT.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;

			listRPT.TABLA = "NV_RPT_ACTIVIDADES";

			nombreReporte = "RPT_Actividades.rpt";

			listRPT.FILTRO = armaFiltro();
		}
		#endregion

		#region ARMAR_FILTRO
		private string armaFiltro()
		{
			string sentencia = "WHERE ";

			if (this.cmbActividades.SelectedValue != null)
			{
				sentencia += "CodigoActividad = '" + cmbActividades.SelectedValue + "' ";
			}

			if (chkActivarRangoFechas.Checked)
			{
				if (sentencia.Equals("WHERE "))
					sentencia += "Fecha between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
				else
					sentencia += "and Fecha between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
			}

			return sentencia == "WHERE " ? " " : sentencia;
		}

		#endregion


		private void listaActividades()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "CodigoActividad,NombreActividad";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_ACTIVIDADES";
			listA.ORDERBY = "order by CodigoActividad";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					cmbActividades.DisplayMember = "NombreActividad";
					cmbActividades.ValueMember = "CodigoActividad";
					cmbActividades.DataSource = dt;
					cmbActividades.SelectedValue = "";
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

	}
}
