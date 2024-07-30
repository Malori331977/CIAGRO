using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelInterop = Microsoft.Office.Interop.Excel;

namespace KOLEGIO
{
	public partial class frmGenerarCelNotificacionPorMes : Form
	{
		private string error = "";
		private int totalRegistros = 0;
		private int totalRegistrosArchivo = 0;
		private DataTable dtDatosRefrescar = new DataTable();
		private DataTable dtRefrescar = new DataTable();
		private FuncsInternas fInternas;
		private BindingSource source1 = new BindingSource();
		private Size smallSizeMorosidades = new Size(1156, 389);
		private Size bigSizeMorosidades = new Size(1156, 649);

		public frmGenerarCelNotificacionPorMes()
		{
			InitializeComponent();
			this.fInternas = new FuncsInternas();
			dgvColegiados.Columns.Clear();

			dtRefrescar.Columns.Add("Id Colegiado", typeof(String));
			dtRefrescar.Columns.Add("Nº Colegiado", typeof(String));
			//dtRefrescar.Columns.Add("N° Registro", typeof(String));
			dtRefrescar.Columns.Add("Código", typeof(String));
			dtRefrescar.Columns.Add("Cédula Jurídica", typeof(String));
			dtRefrescar.Columns.Add("Nombre", typeof(String));
			dtRefrescar.Columns.Add("Email", typeof(String));
			dtRefrescar.Columns.Add("Teléfono", typeof(String));
			dtRefrescar.Columns.Add("Meses", typeof(String));
			dtRefrescar.Columns.Add("Monto", typeof(String));
			dtRefrescar.Columns.Add("Compromiso", typeof(String));
            dtRefrescar.Columns.Add("Condicion", typeof(String));
        }


		private void btnProcesar_Click(object sender, EventArgs e)
		{
			string extension = ".csv";
			string nombreArchivo = "";

			dgvColegiados.EndEdit();

			try
			{
				if (dgvColegiados.RowCount > 0)
				{

					if (validarDatos())
					{
						btnSalir.Enabled = false;
						btnProcesar.Enabled = false;
						fInternas.deshabilitarOrdenDgv(ref dgvColegiados);
						totalRegistrosArchivo = 0;

						if (txtMeses.Text.Equals(""))
							nombreArchivo = "Celulares todos los meses" + extension;
						else
							nombreArchivo = "Celulares " + txtMeses.Text + " Meses" + extension;


						StringBuilder texto = new StringBuilder();
						SaveFileDialog savefile = new SaveFileDialog();
						// set a default file name
						savefile.FileName = nombreArchivo;
						// set filters - this can be done in properties as well


						savefile.Filter = "Csv files (*.csv)|*.csv";

						if (savefile.ShowDialog() == DialogResult.OK)
						{

							Cursor.Current = Cursors.WaitCursor;

							if (!File.Exists(savefile.FileName))
								File.Delete(savefile.FileName);


							foreach (DataGridViewRow row in dgvColegiados.Rows)
							{

								string fila = "";
								string celular = row.Cells["Teléfono"].Value.ToString();

								if (depurarCelular(ref celular))
								{
									fila += celular;

									File.AppendAllText(savefile.FileName, fila + Environment.NewLine);
									totalRegistrosArchivo += 1;
								}


							}

							Cursor.Current = Cursors.Default;

						}



						MessageBox.Show("Se generó el archivo exitosamente!", "Generación Plantilla", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

						btnSalir.Enabled = true;
						btnProcesar.Enabled = true;
						fInternas.habilitarOrdenDgv(ref dgvColegiados);
						lblTotalRegArchivo.Text = totalRegistrosArchivo.ToString();
					}
				}
				else
					MessageBox.Show("No hay información para procesar.", "Generación de Archivo de celulares", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				btnSalir.Enabled = true;
				btnProcesar.Enabled = true;
				fInternas.habilitarOrdenDgv(ref dgvColegiados);
				lblTotalRegArchivo.Text = totalRegistrosArchivo.ToString();
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool depurarCelular(ref string celular)
		{
			bool depurado = false;

			if (!celular.Equals("0"))
			{
				celular = celular.Replace(" ", "");
				celular = celular.Replace("-", "");

				if (celular.Length == 8)
					depurado = true;
			}


			return depurado;
		}

		private bool validarDatos()
		{
			string error = "";
			bool OK = true;


			if (!txtFiltro.Text.Equals(""))
			{
				error = "Debe borrar el filtro para procesar";
				txtFiltro.Focus();
				OK = false;
			}

			if (!OK)
			{
				MessageBox.Show(error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return OK;
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			if (!chkGenTotal.Checked)
			{
				if (!txtMeses.Text.Equals(""))
					refrescarDatos();
				else
					dtRefrescar.Clear();
			}
			else
				refrescarDatosTotal();
		}

		private void refrescarDatos()
		{

            /*Marlon Loria Solano*/
            /*23-07-2024*/
            /*agregar filtro a la consulta para que no muestre debitos*/
            /*t1.TIPO in ('FAC','I/C','INT','L/C','N/D','O/D')*/

			string sQueryColegiados = " SELECT t1.IdColegiado, t1.NumeroColegiado, t1.Nombre, t1.Email, t1.TelefonoCelular, t2.MESES , t2.SALDO, CASE WHEN t3.Estado = 'A' THEN 'Si' ELSE 'No' END Compromiso, t4.NombreCondicion as Condicion" +
							" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
							" JOIN MESES t2 ON t2.CLIENTE = t1.IdColegiado" +
							" LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO t3 ON t3.IdColegiado = t1.IdColegiado AND t3.Estado = 'A'" +
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t4 on t4.CodigoCondicion=t1.Condicion" +
							" WHERE t2.MESES >= " + txtMeses.Text + "";
			string sQueryEstables = " SELECT t1.NumRegistro 'Codigo', t1.CedulaJuridica, t1.Nombre, t1.Email, t1.Telefono, t2.MESES , t2.SALDO" +
									" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t1" +
									" JOIN MESES t2 ON t2.CLIENTE = t1.NumRegistro" +
									" WHERE t2.MESES >= " + txtMeses.Text + "";
			string sQueryConsul = " SELECT t1.Codigo, t1.CedulaJuridica, t1.Nombre, t1.Email, t1.Telefono, t2.MESES , t2.SALDO" +
									" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS t1" +
									" JOIN MESES t2 ON t2.CLIENTE = t1.Codigo" +
									" WHERE t2.MESES >= " + txtMeses.Text + "";
			string sQuery = " WITH MESES AS" +
							" (select COUNT(*) AS 'MESES', SUM(SALDO) SALDO, CLIENTE  from(" +
							"select CLIENTE, cast(year(FECHA) as varchar(4)) + '-' + cast(month(FECHA) as varchar(2)) as MES, SUM(SALDO) SALDO" +
							"	from(select t1.CLIENTE, cast(year(t1.FECHA) as varchar(4)) + '-' + cast(month(t1.FECHA) as varchar(2)) + '-1' as FECHA, SUM(t1.SALDO) SALDO" +
							"	from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1 left join (" +
							"	select DOCUMENTO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where NUM_PARCIALIDADES > 2" +
							"	) t2 on t2.DOCUMENTO = t1.DOCUMENTO" +
							"	where t2.DOCUMENTO is null and t1.SALDO > 0  AND t1.VENDEDOR in (" + filtroVendedor() + ") AND t1.FECHA <= GETDATE() and t1.TIPO in ('FAC','I/C','INT','L/C','N/D','O/D')" +
							"	group by YEAR(t1.FECHA), MONTH(t1.FECHA), t1.CLIENTE union " +
							"	select t1.CLIENTE, cast(year(t2.FECHA_RIGE) as varchar(4)) + '-' + cast(month(t2.FECHA_RIGE) as varchar(2)) + '-1' as FECHA, SUM(t2.SALDO) SALDO" +
							"	from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
							"	join " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t2 on t2.DOCUMENTO_ORIGEN = t1.DOCUMENTO" +
							"	where t1.SALDO > 0  AND t1.VENDEDOR in (" + filtroVendedor() + ") AND t2.FECHA_RIGE <= GETDATE() AND t2.SALDO > 0 and NUM_PARCIALIDADES > 2  AND t1.TIPO in ('FAC','I/C','INT','L/C','N/D','O/D')" +
							"	group by YEAR(t2.FECHA_RIGE), MONTH(t2.FECHA_RIGE), t1.CLIENTE" +
							"	) tbMese group by YEAR(FECHA), MONTH(FECHA), CLIENTE) as tb group by CLIENTE )";

			if (chkEST.Checked)
				sQuery += sQueryEstables;
			else if (chkCONSUL.Checked)
				sQuery += sQueryConsul;
			else
				sQuery += sQueryColegiados;

			string error = "";
			try
			{
				dtDatosRefrescar.Rows.Clear();
				Cursor.Current = Cursors.WaitCursor;
				if (Consultas.fillDataTable(sQuery, ref dtDatosRefrescar, ref error))
				{
					dtRefrescar.Rows.Clear();

					totalRegistros = 0;

					foreach (DataRow row in dtDatosRefrescar.Rows)
					{
						totalRegistros += 1;
						if (chkEST.Checked || chkCONSUL.Checked)
						{
							dtRefrescar.Rows.Add(string.Empty, string.Empty, row["Codigo"].ToString(), row["CedulaJuridica"].ToString(),
							row["Nombre"].ToString(), row["Email"].ToString(), row["Telefono"].ToString(), row["MESES"].ToString(), decimal.Parse(row["SALDO"].ToString()).ToString("N2"));
						}
						else
						{
							dtRefrescar.Rows.Add(row["IdColegiado"].ToString(), 
								                 row["NumeroColegiado"].ToString(), 
												 string.Empty, 
												 string.Empty,
												 row["Nombre"].ToString(), 
												 row["Email"].ToString(), 
												 row["TelefonoCelular"].ToString(), 
												 row["MESES"].ToString(), 
												 decimal.Parse(row["SALDO"].ToString()).ToString("N2"), 
												 row["Compromiso"].ToString(),
                                                 row["Condicion"].ToString());
										         
						}


                    }
					lblRegistrosCant.Text = totalRegistros.ToString();

					actualizarColumnsGrids();

				}
				Cursor.Current = Cursors.Default;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void refrescarDatosTotal()
		{

			//////string sQuery = "select t1.IdColegiado,t1.NumeroColegiado,t1.Nombre,t1.TelefonoCelular, COUNT(t2.DOCUMENTO) Meses from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
			//////        " join " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 on t2.CLIENTE = t1.IdColegiado" +
			//////        " where t2.SALDO > 0 and(t2.TIPO = 'FAC' or(t2.TIPO = 'O/D' and t2.SUBTIPO = '176'))" +
			//////        " group by t1.IdColegiado,t1.NumeroColegiado,t1.Nombre,t1.TelefonoCelular";

			////string sQuery = "select t1.IdColegiado,t1.NumeroColegiado,t1.Nombre,t1.TelefonoCelular," +
			////        " (select  COUNT(*) from(" +
			////        " select YEAR(FECHA_DOCUMENTO) año, MONTH(FECHA_DOCUMENTO) mes from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC" +
			////        " where CLIENTE = t1.IdColegiado and SALDO > 0 and(TIPO = 'FAC' or(TIPO = 'O/D' and SUBTIPO = '176')) and CONVERT(date, FECHA) <= CONVERT(date, GETDATE())" +
			////        " group by YEAR(FECHA_DOCUMENTO), MONTH(FECHA_DOCUMENTO)" +
			////        " ) as tabla_meses) Meses" +
			////        " from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 on t2.CLIENTE = t1.IdColegiado" +
			////        " where t2.SALDO > 0 and(t2.TIPO = 'FAC' or(t2.TIPO = 'O/D' and t2.SUBTIPO = '176'))" +
			////        " group by t1.IdColegiado,t1.NumeroColegiado,t1.Nombre,t1.TelefonoCelular";
			//string sQuery = " WITH MESES AS" +
			//				" (select COUNT(*) AS 'MESES', SUM(SALDO) SALDO, CLIENTE  from(" +
			//				"     select CLIENTE, cast(year(FECHA) as varchar(4)) + '-' + cast(month(FECHA) as varchar(2)) as MES, SUM(SALDO) SALDO" +
			//				"     from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC" +
			//				"     where SALDO > 0  AND VENDEDOR in (" + filtroVendedor() + ") AND FECHA <= GETDATE()" +
			//				"     group by YEAR(fecha), MONTH(fecha), CLIENTE) as tb group by CLIENTE" +
			//				" )" +
			//				" SELECT t1.IdColegiado, t1.NumeroColegiado, t1.Nombre, t1.Email, t1.TelefonoCelular, t2.MESES , t2.SALDO" +
			//				" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
			//				" JOIN MESES t2 ON t2.CLIENTE = t1.IdColegiado";
			string sQueryColegiados = " SELECT t1.IdColegiado, t1.NumeroColegiado, t1.Nombre, t1.Email, t1.TelefonoCelular, t2.MESES , t2.SALDO, CASE WHEN t3.Estado = 'A' THEN 'Si' ELSE 'No' END Compromiso, t4.NombreCondicion as Condicion" +
							" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
							" JOIN MESES t2 ON t2.CLIENTE = t1.IdColegiado" +
							" LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO t3 ON t3.IdColegiado = t1.IdColegiado AND t3.Estado = 'A'" + 
							" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t4 on t4.CodigoCondicion=t1.Condicion";

			string fltVendedor = filtroVendedor() == "" ? "" : " AND t1.VENDEDOR in (" + filtroVendedor() + ")";


            string sQueryEstables = " SELECT t1.NumRegistro 'Codigo', t1.CedulaJuridica, t1.Nombre, t1.Email, t1.Telefono, t2.MESES , t2.SALDO" +
									" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t1" +
									" JOIN MESES t2 ON t2.CLIENTE = t1.NumRegistro";
			string sQueryConsul = " SELECT t1.Codigo, t1.CedulaJuridica, t1.Nombre, t1.Email, t1.Telefono, t2.MESES , t2.SALDO" +
								" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS t1" +
								" JOIN MESES t2 ON t2.CLIENTE = t1.Codigo";
			string sQuery = " WITH MESES AS" +
							  " (select COUNT(*) AS 'MESES', SUM(SALDO) SALDO, CLIENTE  from (" +
							//"     select CLIENTE, cast(year(FECHA) as varchar(4)) + '-' + cast(month(FECHA) as varchar(2)) as MES, SUM(SALDO) SALDO" +
							//"     from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC" +
							//"     where SALDO > 0  AND VENDEDOR in (" + filtroVendedor() + ") AND FECHA <= GETDATE()" +
							//"     group by YEAR(fecha), MONTH(fecha), CLIENTE) as tb group by CLIENTE" +
							//" )";
							"select CLIENTE, cast(year(FECHA) as varchar(4)) + '-' + cast(month(FECHA) as varchar(2)) as MES, SUM(SALDO) SALDO" +
							"	from(select t1.CLIENTE, cast(year(t1.FECHA) as varchar(4)) + '-' + cast(month(t1.FECHA) as varchar(2)) + '-1' as FECHA, SUM(t1.SALDO) SALDO" +
							"	from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1 left join (" +
							"	select DOCUMENTO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where NUM_PARCIALIDADES > 2" +
							"	) t2 on t2.DOCUMENTO = t1.DOCUMENTO" +
                            "	where t2.DOCUMENTO is null and t1.SALDO > 0 " + fltVendedor +
							"   AND t1.FECHA <= GETDATE() and t1.TIPO in ('FAC','I/C','INT','L/C','N/D','O/D')" +
							"	group by YEAR(t1.FECHA), MONTH(t1.FECHA), t1.CLIENTE union " +
							"	select t1.CLIENTE, cast(year(t2.FECHA_RIGE) as varchar(4)) + '-' + cast(month(t2.FECHA_RIGE) as varchar(2)) + '-1' as FECHA, SUM(t2.SALDO) SALDO" +
							"	from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
							"	join " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t2 on t2.DOCUMENTO_ORIGEN = t1.DOCUMENTO" +
							"	where t1.SALDO > 0" + fltVendedor + 
							"   AND t2.FECHA_RIGE <= GETDATE() AND t2.SALDO > 0 and NUM_PARCIALIDADES > 2 and t1.TIPO in ('FAC','I/C','INT','L/C','N/D','O/D')" +
							"	group by YEAR(t2.FECHA_RIGE), MONTH(t2.FECHA_RIGE), t1.CLIENTE" +
							"	) tbMese group by YEAR(FECHA), MONTH(FECHA), CLIENTE) as tb group by CLIENTE )";

			if (chkEST.Checked)
				sQuery += sQueryEstables;
			else if (chkCONSUL.Checked)
				sQuery += sQueryConsul;
			else
				sQuery += sQueryColegiados;

			string error = "";
			try
			{
				dtDatosRefrescar.Rows.Clear();
				Cursor.Current = Cursors.WaitCursor;
				if (Consultas.fillDataTable(sQuery, ref dtDatosRefrescar, ref error))
				{
					//dgvColegiados.DataSource = dtIngresos;

					//dgvColegiados.Rows.Clear();
					//dgvColegiados.Columns.Clear();
					dtRefrescar.Rows.Clear();

					totalRegistros = 0;



					foreach (DataRow row in dtDatosRefrescar.Rows)
					{
						totalRegistros += 1;
						//dtRefrescar.Rows.Add(row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
						//	row["Nombre"].ToString(), row["Email"].ToString(), row["TelefonoCelular"].ToString(), row["MESES"].ToString(), decimal.Parse(row["SALDO"].ToString()).ToString("N2"));
						////dgvColegiados.Rows.Add(false,row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
						////    row["Nombre"].ToString(), iList.Images[0], "");
						///if (chkEST.Checked)
						if (chkEST.Checked || chkCONSUL.Checked)
						{
							dtRefrescar.Rows.Add(string.Empty, string.Empty, row["Codigo"].ToString(), row["CedulaJuridica"].ToString(),
							row["Nombre"].ToString(), row["Email"].ToString(), row["Telefono"].ToString(), row["MESES"].ToString(), decimal.Parse(row["SALDO"].ToString()).ToString("N2"));
						}
						else
						{
							dtRefrescar.Rows.Add(row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(), string.Empty, string.Empty,
							row["Nombre"].ToString(), row["Email"].ToString(), row["TelefonoCelular"].ToString(), row["MESES"].ToString(), decimal.Parse(row["SALDO"].ToString()).ToString("N2"), row["COMPROMISO"].ToString(), row["CONDICION"].ToString());
						}
					}
					lblRegistrosCant.Text = totalRegistros.ToString();



					DataView view = new DataView(dtRefrescar);
					source1.DataSource = view;
					dgvColegiados.DataSource = view;
					if (chkEST.Checked || chkCONSUL.Checked)
					{
						dgvColegiados.Columns["Id Colegiado"].Visible = false;
						dgvColegiados.Columns["Nº Colegiado"].Visible = false;
						dgvColegiados.Columns["Compromiso"].Visible = false;
						dgvColegiados.Columns["Cédula Jurídica"].Visible = true;
						dgvColegiados.Columns["Código"].Visible = true;
                        //dgvColegiados.Columns["Condicion"].Visible = false;
                    }
					else
					{
						dgvColegiados.Columns["Cédula Jurídica"].Visible = false;
						dgvColegiados.Columns["Código"].Visible = false;
						dgvColegiados.Columns["Id Colegiado"].Visible = true;
						dgvColegiados.Columns["Nº Colegiado"].Visible = true;
						dgvColegiados.Columns["Compromiso"].Visible = true;
                        dgvColegiados.Columns["Condicion"].Visible = true;
                        
                    }
					dgvColegiados.AutoResizeColumns();
					dgvColegiados.Refresh();

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor.Current = Cursors.Default;
		}

		private void actualizarColumnsGrids()
		{
			DataView view = new DataView(dtRefrescar);
			source1.DataSource = view;
			dgvColegiados.DataSource = view;
			if (chkEST.Checked || chkCONSUL.Checked)
			{
				panelGestionCobro.Visible = false;
				panelMorosidades.Size = bigSizeMorosidades;

				dgvColegiados.Columns["Id Colegiado"].Visible = false;
				dgvColegiados.Columns["Nº Colegiado"].Visible = false;
				dgvColegiados.Columns["Compromiso"].Visible = false;
				dgvColegiados.Columns["Cédula Jurídica"].Visible = true;
				dgvColegiados.Columns["Código"].Visible = true;
                dgvColegiados.Columns["Condicion"].Visible = false;
            }
			else
			{
				panelGestionCobro.Visible = true;
				panelMorosidades.Size = smallSizeMorosidades;

				dgvColegiados.Columns["Cédula Jurídica"].Visible = false;
				dgvColegiados.Columns["Código"].Visible = false;
				dgvColegiados.Columns["Id Colegiado"].Visible = true;
				dgvColegiados.Columns["Nº Colegiado"].Visible = true;
				dgvColegiados.Columns["Compromiso"].Visible = true;
                dgvColegiados.Columns["Condicion"].Visible = true;
            }
			//dgvColegiados.AutoResizeColumns();
			dgvColegiados.Refresh();

		}

		private string filtroVendedor()
		{
			string result = "";

			if (chkCOL.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result = "'COL','ND'";
				else
					result = ",'COL','ND'";
			}

			if (chkREG.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result += "'REG'";
				else
					result += ",'REG'";
			}

			if (chkPER.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result += "'PER'";
				else
					result += ",'PER'";
			}

			if (chkAEREA.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result += "'VIA'";
				else
					result += ",'VIA'";
			}

			if (chkPLAGUI.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result += "'IDO'";
				else
					result += ",'IDO'";
			}

			if (chkEST.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result += "'EST'";
				else
					result += ",'EST'";
			}

			if (chkCONSUL.Checked)
			{
				if (string.IsNullOrEmpty(result))
					result += "'CIA'";
				else
					result += ",'CIA'";
			}

			return result;
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnResize_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			dgvColegiados.AutoResizeColumns();
			dgvGestionCobro2.AutoResizeColumns();
			Cursor.Current = Cursors.Default;
		}

		private void txtFiltro_TextChanged(object sender, EventArgs e)
		{
			if (dgvColegiados.Rows.Count > 0)
			{
				if (!txtFiltro.Text.Equals(""))
				{
					source1.Filter = "[Nº Colegiado] like '%" + txtFiltro.Text + "%' or [Id Colegiado] like '%" + txtFiltro.Text + "%' or [Nombre] like '%" + txtFiltro.Text + "%' or [Teléfono] like '%" + txtFiltro.Text + "%' or [Meses] like '%" + txtFiltro.Text + "%'";
					//lblRegistrosCant.Text = dgvColegiados.Rows.Count.ToString();
				}
				else
				{
					source1.Filter = null;
					//lblRegistrosCant.Text = dgvColegiados.Rows.Count.ToString();
					//refrescarDatos();
				}
				lblRegistrosCant.Text = dgvColegiados.Rows.Count.ToString();
			}
			else
			{
				if (!string.IsNullOrEmpty(txtFiltro.Text))
				{
					MessageBox.Show("No hay información para filtrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtFiltro.Clear();
				}
			}
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			if (!chkCOL.Checked && !chkREG.Checked && !chkAEREA.Checked && !chkPER.Checked && !chkPLAGUI.Checked && !chkEST.Checked && !chkCONSUL.Checked)
			{
				MessageBox.Show("Seleccione al menos un registro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if ((chkCOL.Checked || chkREG.Checked || chkAEREA.Checked || chkPER.Checked || chkPLAGUI.Checked) && (chkEST.Checked || chkCONSUL.Checked))
			{
				MessageBox.Show("Solo se puede seleccionar Colegiado o Empresa.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (!txtMeses.Text.Equals(""))
				refrescarDatos();
			else
				dtRefrescar.Clear();
		}

		private void chkGenTotal_MouseClick(object sender, MouseEventArgs e)
		{
			if (chkGenTotal.Checked)
			{
				refrescarDatosTotal();
				txtMeses.ReadOnly = true;
				txtMeses.Clear();
				txtFiltro.Clear();
			}
			else
			{
				dtRefrescar.Clear();
				txtMeses.ReadOnly = false;
			}
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			if (dgvColegiados.RowCount == 0)
			{
				MessageBox.Show("No existen datos para exportar a excel.", "Exportación a excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			try
			{
				ExcelInterop.Application Excel = new ExcelInterop.Application();
				Excel.Workbooks.Add();
				// single worksheet
				ExcelInterop._Worksheet Worksheet = Excel.ActiveSheet;

				//List<string> colFechas = new List<string>();

				////colFechas.Add("F. Pago");
				//colFechas.Add("Fecha compromiso");
				//colFechas.Add("Fecha");

				//int columnaEstado = dgvColegiados.Columns.Count+1;
				int columnas = dgvColegiados.Columns.Count;
				int rows = dgvColegiados.RowCount;
				object[] Header = new object[columnas + 1];

				// column headings               
				for (int i = 0; i < columnas + 1; i++)
				{
					//if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga" && dgvPolizas.Columns[i].HeaderText != "F17")
					if (i == columnas)
						Header[i] = "Formato celular";
					else
						Header[i] = dgvColegiados.Columns[i].HeaderText;
				}



				ExcelInterop.Range HeaderRange = Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[1, 1]), (ExcelInterop.Range)(Worksheet.Cells[1, columnas + 1]));
				HeaderRange.Value = Header;
				HeaderRange.Font.Bold = true;
				HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

				// DataCells

				object[,] Cells = new object[rows, columnas + 1];
				//bool fecha = false;
				for (int j = 0; j < rows; j++)
				{
					for (int i = 0; i < columnas; i++)
					{

						//fecha = false;
						//for (int k = 0; k < colFechas.Count; k++)
						//{
						//    if (dgvPolizas.Columns[i].HeaderText == colFechas[k])
						//    {
						//        if (dgvPolizas[i, j].Value.ToString() != "")
						//            Cells[j, i] = DateTime.Parse(dgvPolizas[i, j].Value.ToString()).ToString("yyyy-MM-dd");
						//        else
						//            Cells[j, i] = "";
						//        fecha = true;
						//        break;
						//    }
						//}
						//if (!fecha && (dgvPolizas.Columns[i].HeaderText != "Detalle Carga" && dgvPolizas.Columns[i].HeaderText != "F17"))

						if (dgvColegiados[i, j].Value != null)
						{
							if (i == columnas - 3)//Columna de telefono
							{
								string newPhone = dgvColegiados[i, j].Value.ToString();
								if (depurarCelular(ref newPhone))
									Cells[j, i] = newPhone;
								else
									Cells[j, i] = dgvColegiados[i, j].Value.ToString();
							}
							else
							{
								Cells[j, i] = dgvColegiados[i, j].Value.ToString();
							}
						}
						else
							Cells[j, i] = "";


					}
					string cel = dgvColegiados[columnas - 3, j].Value.ToString();
					if (depurarCelular(ref cel))
						Cells[j, columnas] = "Correcto";
					else
						Cells[j, columnas] = "Incorrecto";
				}

				Worksheet.Name = "Celulares Colegiados Pendientes";
				Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[rows + 1, columnas + 1])).Value = Cells;
				Worksheet.Columns.AutoFit();

				//Segundo tab/

				if (!chkEST.Checked && !chkCONSUL.Checked)
				{
					ExcelInterop._Worksheet Worksheet2 = Excel.Sheets.Add(After: Excel.Sheets[Excel.Sheets.Count]);

					int columnas2 = dgvGestionCobro2.Columns.Count;
					int rows2 = dgvGestionCobro2.RowCount;
					object[] Header2 = new object[columnas2];

					List<int> ColumnasNoVisibles = new List<int>();
					List<string> colFechas = new List<string>();

					colFechas.Add("colFechaCompromiso");
					colFechas.Add("colFecha");

					// column headings               
					for (int i = 0; i < columnas2; i++)
					{
						////if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga" && dgvPolizas.Columns[i].HeaderText != "F17")
						//if (i == columnas2)
						//	Header[i] = "Formato celular";
						//else
						//Header2[i] = dgvGestionCobro2.Columns[i].HeaderText;

						if (dgvGestionCobro2.Columns[i].Visible == true)
							Header2[i] = dgvGestionCobro2.Columns[i].HeaderText;
						else
							ColumnasNoVisibles.Add(i + 1);
					}


					ExcelInterop.Range HeaderRange2 = Worksheet2.get_Range((ExcelInterop.Range)(Worksheet2.Cells[1, 1]), (ExcelInterop.Range)(Worksheet2.Cells[1, columnas2]));
					HeaderRange2.Value = Header2;
					HeaderRange2.Font.Bold = true;
					HeaderRange2.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

					// DataCells

					object[,] Cells2 = new object[rows2, columnas2];
					bool fecha = false;
					for (int j = 0; j < rows2; j++)
					{
						for (int i = 0; i < columnas2; i++)
						{

							fecha = false;
							for (int k = 0; k < colFechas.Count; k++)
							{
								if (dgvGestionCobro2.Columns[i].HeaderText == colFechas[k])
								{
									if (dgvGestionCobro2[i, j].Value.ToString() != "")
										Cells2[j, i] = DateTime.Parse(dgvGestionCobro2[i, j].Value.ToString()).ToString("yyyy-MM-dd");
									else
										Cells2[j, i] = "";
									fecha = true;
									break;
								}
							}

							if (!fecha && dgvGestionCobro2.Columns[i].Visible == true)
							{
								if (dgvGestionCobro2[i, j].Value != null)
									Cells2[j, i] = dgvGestionCobro2[i, j].Value.ToString();
								else
									Cells2[j, i] = "";
							}

						}
						//string cel = dgvColegiados[columnas - 3, j].Value.ToString();
						//if (depurarCelular(ref cel))
						//	Cells[j, columnas] = "Correcto";
						//else
						//	Cells[j, columnas] = "Incorrecto";
					}


					Worksheet2.Name = "Gestion de cobro";
					Worksheet2.get_Range((ExcelInterop.Range)(Worksheet2.Cells[2, 1]), (ExcelInterop.Range)(Worksheet2.Cells[rows2 + 1, columnas2])).Value = Cells2;
					Worksheet2.Columns.AutoFit();

					//Eliminar columnas que no estan visibles en el dgv
					int cont = 0;
					foreach (int column in ColumnasNoVisibles)
					{
						if (cont == 0)
							Worksheet2.Columns[column].Delete();
						else
							Worksheet2.Columns[column - cont].Delete();
						cont++;
					}
				}

				Excel.Visible = true;
				// DateTime tiempo2 = DateTime.Now;
				// TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
				// MessageBox.Show("Duracion: " + total.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un error en la exportación de datos a excel: " + ex.Message, "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			Cursor.Current = Cursors.Default;
		}

		private void dgvColegiados_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//bool masivo = true;
			//if (dgvColegiados.Rows.Count > 0 && !chkEST.Checked)
			//{
			//	if (dgvColegiados.CurrentCell.OwningColumn.Name == "Compromiso")
			//	{
			//		if (e.RowIndex >= 0)
			//		{
			//			if (dgvColegiados.Rows[e.RowIndex].Cells["Compromiso"].Value.ToString() == "Si")
			//			{
			//				//dgvColegiados.Rows[e.RowIndex].Cells["Ver detalle"].Value = true;

			//				cargarDetalle(dgvColegiados.Rows[e.RowIndex].Cells["Id Colegiado"].Value.ToString());
			//			}
			//			else
			//			{
			//				//dgvColegiados.Rows[e.RowIndex].Cells[/*"colSelecDetalle"*/
           // "Ver detalle"].Value = false;
							
			//				limpiarDetalle(dgvColegiados.Rows[e.RowIndex].Cells["Id Colegiado"].Value.ToString());
			//			}

			//			//foreach (DataGridViewRow row in dgvColegiados.Rows)
			//			//{
			//			//	if (!(bool)row.Cells[/*"colSelecDetalle"*/ "Ver detalle"].Value)
			//			//	{
			//			//		masivo = false;
			//			//		break;
			//			//	}
			//			//}
			//			//dgvColegiados.EndEdit();
			//		}
			//	}
			//}
		}

		private void cargarDetalle(string colegiado)
		{
			DataTable dt = new DataTable();
			string error = "";
			string query = "";

			query = "select Id, IdColegiado, Medio, FechaGestion, Compromiso, FechaCompromiso, Observaciones, Estado from " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO where IdColegiado = '" + colegiado + "'";

			try
			{
				if (Consultas.fillDataTable(query, ref dt, ref error))
				{
					//dgvDetalle.Rows.Clear();
					foreach (DataRow row in dt.Rows)
					{
						dgvGestionCobro2.Rows.Add(row["Id"].ToString(), row["IdColegiado"].ToString(), row["Medio"].ToString(), row["FechaGestion"].ToString() != "" ? DateTime.Parse(row["FechaGestion"].ToString()).ToString("dd/MM/yyyy") : "", row["Compromiso"].ToString(), row["FechaCompromiso"].ToString() != "" ? DateTime.Parse(row["FechaCompromiso"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString(), fInternas.obtenerEstadoGestionCobro(row["Estado"].ToString()));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void frmGenerarCelNotificacionPorMes_Load(object sender, EventArgs e)
		{
			panelGestionCobro.Visible = false;
			panelMorosidades.Size = bigSizeMorosidades;
		}

		private void dgvColegiados_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvColegiados.Rows.Count > 0 && (!chkEST.Checked || !chkCONSUL.Checked))
			{
				var selectedRows = dgvColegiados.SelectedRows
								   .OfType<DataGridViewRow>()
								   .Where(row => row.Cells["Compromiso"].Value.ToString() == "Si")
								   .ToArray();

				//limpiarDetalle("");
				dgvGestionCobro2.Rows.Clear();


				foreach (DataGridViewRow row in dgvColegiados.SelectedRows)
				{
					//limpiarDetalle(dgvColegiados.Rows[row.Index].Cells["Id Colegiado"].Value.ToString());

					if (dgvColegiados.Rows[row.Index].Cells["Compromiso"].Value.ToString() == "Si")
					{
						cargarDetalle(dgvColegiados.Rows[row.Index].Cells["Id Colegiado"].Value.ToString());
					}
					//else
					//{
					//	limpiarDetalle(dgvColegiados.Rows[row.Index].Cells["Id Colegiado"].Value.ToString());
					//}
				}
			}
		}
	}
}
