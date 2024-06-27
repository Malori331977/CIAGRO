using Framework;
using System;
using System.Data;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmFiltroColegiado : Form
	{
		protected string error = "";
		private Listado listRPT;
		private string rpt;
		private string titulo;
		//private int tipo;
		private string nombreReporte;
		private FuncsInternas fi;
		private string oldValue = "";

		public frmFiltroColegiado()
		{
			InitializeComponent();
			listaCondiciones();
			listaCategorias();
			listaCobradores();
			loadGenero();
			listRPT = new Listado();
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

			//if (rbGeneral.Checked)
			//{
			//    if (this.tipo.Equals("estable"))
			//    {
			//        listRPT.TABLA = "NV_FICHA_ESTABLECIMIENTOS";
			//        nombreReporte = "RPT_FichaEstablecimientos.rpt";
			//    }
			//    else
			//    {
			if (rbRegente2.Checked)
			{
				listRPT.TABLA = "NV_FICHA_COLEGIADOS col JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS reg ON reg.NumeroColegiado =  col.IdColegiado";
			}
			else if (rbPerito2.Checked)
			{
				listRPT.TABLA = "NV_FICHA_COLEGIADOS col JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS peri ON peri.IdColegiado =  col.IdColegiado";
			}
			else if (rbViaAerea2.Checked)
			{
				listRPT.TABLA = "NV_FICHA_COLEGIADOS col JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO aerea ON aerea.IdColegiado =  col.IdColegiado";
			}
			else if (rbPlagui2.Checked)
			{
				listRPT.TABLA = "NV_FICHA_COLEGIADOS col JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO plagui ON plagui.IdColegiado =  col.IdColegiado";
			}
			else if (rbVidaSilvestre2.Checked)
			{
				listRPT.TABLA = "NV_FICHA_COLEGIADOS col JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SILVESTRE silve ON silve.IdColegiado =  col.IdColegiado";
			}
			else if (rbEspecialistas2.Checked)
			{
				listRPT.TABLA = "NV_RPT_ESPECIALISTAS";

			}
			else if (rbBeneficiario2.Checked)
			{
				listRPT.TABLA = "NV_BENEFICIARIOS_POR_COLEGIADOS";
			}
			else
			{
				//listRPT.TABLA = "NV_FICHA_COLEGIADOS";
				listRPT.TABLA = "NV_FICHA_COLEGIADOS_ACADEMICOS";
			}

			if (rbBeneficiario2.Checked)
			{
				nombreReporte = "RPT_ColegiadosBeneficiarios.rpt";
			}
			else if (rbEspecialistas2.Checked)
			{
				nombreReporte = "RPT_ColegiadosEspecialidades.rpt";
			}
			else
			{
				//nombreReporte = "RPT_Colegiados2.rpt";
				nombreReporte = "RPT_ColegiadosAcademicos.rpt";
				//if(cmbGenero.SelectedValue != null)
				//{
				//	nombreReporte = "RPT_Colegiados2Genero.rpt";
				//}
				//else
				//{
				//nombreReporte = "RPT_Colegiados2.rpt";
				//}
			}
			//    }
			//}
			//else
			//{
			//    if (this.tipo.Equals("estable"))
			//    {
			//        listRPT.TABLA = "NV_FICHA_ESTABLECIMIENTOS";
			//        nombreReporte = "RPT_ListadoCategPorEstablecimiento.rpt";
			//    }
			//    else
			//        nombreReporte = "RPT_FichaConsultoras.rpt";
			//}

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

			if (this.cmbCategorias.SelectedValue != null)
			{
				if (sentencia.Equals("WHERE "))
					sentencia += "CodigoCategoriaCol = '" + cmbCategorias.SelectedValue + "' ";
				else
					sentencia += "and CodigoCategoriaCol = '" + cmbCategorias.SelectedValue + "' ";
			}

			if (this.cmbGenero.SelectedValue != null && !this.cmbGenero.SelectedValue.Equals("T"))
			{
				if (sentencia.Equals("WHERE "))
					sentencia += "Genero = '" + cmbGenero.SelectedValue + "' ";
				else
					sentencia += "and Genero = '" + cmbGenero.SelectedValue + "' ";
			}

			if (this.cmbCobrador.SelectedValue != null)
			{
				if (sentencia.Equals("WHERE "))
					sentencia += "CodigoCobrador = '" + cmbCobrador.SelectedValue + "' ";
				else
					sentencia += "and CodigoCobrador = '" + cmbCobrador.SelectedValue + "' ";
			}

			if (chkActivarRangoFechas2.Checked)
			{
				//if (tipo.Equals("estable"))
				//{
				if (sentencia.Equals("WHERE "))
					sentencia += "[Fecha Nacimiento] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
				else
					sentencia += "and [Fecha Nacimiento] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
				//}
				//else
				//{
				//    if (sentencia.Equals("WHERE "))
				//        sentencia = "[Fecha Aprobación] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
				//    else
				//        sentencia = "and [Fecha Aprobación] between '" + dtpPeriodoDesde.Value.ToString("yyyy-MM-dd") + " 00:00:00' and '" + dtpPeriodoHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
				//}
			}

			return sentencia == "WHERE " ? " " : sentencia;
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

		private void listaCategorias()
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
					cmbCategorias.DisplayMember = "DESCRIPCION";
					cmbCategorias.ValueMember = "CATEGORIA_CLIENTE";
					cmbCategorias.DataSource = dt;
					cmbCategorias.SelectedValue = "";
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void loadGenero()
		{
			DataTable dt = new DataTable();

			dt.Columns.Add("CODIGO", typeof(String));
			dt.Columns.Add("NOMBRE", typeof(String));

			dt.Rows.Add("F", "Femenino");
			dt.Rows.Add("M", "Masculino");
			dt.Rows.Add("T", "Todos");

			cmbGenero.DisplayMember = "NOMBRE";
			cmbGenero.ValueMember = "CODIGO";
			cmbGenero.DataSource = dt;
			cmbGenero.SelectedValue = "";

		}

		private void listaCobradores()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "COBRADOR, NOMBRE";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "COBRADOR";
			listA.ORDERBY = "order by COBRADOR";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					cmbCobrador.DisplayMember = "NOMBRE";
					cmbCobrador.ValueMember = "COBRADOR";
					cmbCobrador.DataSource = dt;
					cmbCobrador.SelectedValue = "";
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
			if (chkActivarRangoFechas2.Checked)
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
