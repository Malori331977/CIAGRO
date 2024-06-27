using Framework;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ExcelInterop = Microsoft.Office.Interop.Excel;

namespace KOLEGIO
{
	public partial class frmGenerarCobroMasivoCobrador : Form
	{
		private string oldValue = "";
		//Instancia de la clase Leer
		FuncsInternas FuncionesInternas = new FuncsInternas();
		private BindingSource source1 = new BindingSource();
		DataTable dtRefrescarDatos = new DataTable();
		DataTable dtRefrescarDatosTemp = new DataTable();
		//Alamcena la ruta del archivo .txt
		public string rutaArchivo = "";
		private string tipoArchivo = "", tipoIdentificacionCarga = "";
		private decimal totalSaldosDetalle = 0, totalSaldosCarga = 0, totalSaldos = 0;
		private int totalRegistrosDetalle = 0, totalRegistrosCarga = 0, totalRegistros = 0, totalRegistrosExitosos = 0, totalRegistrosErroneos = 0;
		private bool esAplicacionPar = false, esAplicacionBac = false, esAplicacionConectividad = false, esPlantillaPredef = false;
		private string indicadorEmparejarDatos = "";
		private bool esCedula = false;
		private FuncsInternas fInternas;
		private string filtro = "";
		private string filtroDetalleId = "";
		private string filtroDetalleDocs = "";
		private string subtipoRec = "";
		private string ListadoPorFac = "", GenerarPor = "", SumarArreglo = "", ArregloPorDocumento = "",
			RubroColegiatura = "", RubroRegencia = "";

		OpenFileDialog openFileDialog1 = new OpenFileDialog();

		public frmGenerarCobroMasivoCobrador()
		{
			InitializeComponent();
			this.fInternas = new FuncsInternas();
			tipoArchivo = "";
			dgvColegiados.Columns.Clear();
			dtRefrescarDatosTemp.Columns.Add("Ver detalle", typeof(Boolean));
			dtRefrescarDatosTemp.Columns.Add("IdColegiado", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Cédula", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Nº Colegiado", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Nombre", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Documento", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Cobrador", typeof(String));
			//dtRefrescarDatosTemp.Columns.Add("Monto Adeudado", typeof(String));
			//dtRefrescarDatosTemp.Columns.Add("Monto Pagado", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Monto Adeudado", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Monto a Favor", typeof(String));
			dtRefrescarDatosTemp.Columns.Add("Estado", typeof(Image));
			dtRefrescarDatosTemp.Columns.Add("Observaciones", typeof(String));

			//string mon = fInternas.quitarCerosMontoInicio("0001221230");

			//crearClienteMasivo();
		}

		//public frmGenerarCobroMasivoCobrador()
		//{
		//    InitializeComponent();
		//    tipoArchivo = "";

		//}

		//private void limpiarCobrador()
		//{
		//	txtCobrador.Clear();
		//	txtDescCobrador.Clear();
		//}

		//private void listaCobradores()
		//{
		//	string error = "";
		//	Listado listD = new Listado();
		//	listD.COLUMNAS = "COBRADOR as Código,NOMBRE as Nombre";
		//	listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
		//	listD.TABLA = "COBRADOR";
		//	listD.TITULO_LISTADO = "Cobradores";

		//	frmF1 f1 = new frmF1(listD);
		//	f1.ShowDialog();
		//	if (f1.item != null)
		//	{
		//		txtCobrador.Text = f1.item.SubItems[0].Text;
		//		txtDescCobrador.Text = f1.item.SubItems[1].Text;
		//		Cursor.Current = Cursors.WaitCursor;
		//		verificarConfigurablesPlantillas(ref error);
		//		FuncsInternas.obtenerSubtipoRec(txtCobrador.Text, ref subtipoRec, ref error);

		//		refrescarDatos(false, true);
		//		//refrescarDatos();

		//		if (ListadoPorFac.Equals("S"))
		//		{
		//			if (dgvColegiados.Rows.Count > 0)
		//				dgvColegiados.Columns["Documento"].Visible = true;
		//		}
		//		else
		//		{
		//			if (dgvColegiados.Rows.Count > 0)
		//				dgvColegiados.Columns["Documento"].Visible = false;
		//		}

		//		Cursor.Current = Cursors.Default;
		//	}
		//}

		//private void cargarCobrador(string cobrador)
		//{
		//	DataTable dtTTs = new DataTable();
		//	Listado listA = new Listado();
		//	listA.COLUMNAS = "*";
		//	listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
		//	listA.TABLA = "COBRADOR";
		//	listA.FILTRO = "where COBRADOR = '" + cobrador + "'";
		//	string error = "";
		//	if (Consultas.listarDatos(listA, ref dtTTs, ref error))
		//	{
		//		if (dtTTs.Rows.Count > 0)
		//		{
		//			txtCobrador.Text = dtTTs.Rows[0]["COBRADOR"].ToString();
		//			txtDescCobrador.Text = dtTTs.Rows[0]["NOMBRE"].ToString();
		//			Cursor.Current = Cursors.WaitCursor;
		//			verificarConfigurablesPlantillas(ref error);

		//			refrescarDatos(false, true);
		//			//refrescarDatos();

		//			if (ListadoPorFac.Equals("S"))
		//			{
		//				if (dgvColegiados.Rows.Count > 0)
		//					dgvColegiados.Columns["Documento"].Visible = true;
		//			}
		//			else
		//			{
		//				if (dgvColegiados.Rows.Count > 0)
		//					dgvColegiados.Columns["Documento"].Visible = false;
		//			}

		//			Cursor.Current = Cursors.Default;
		//		}
		//		else
		//		{
		//			limpiarCobrador();
		//		}
		//	}
		//	else
		//		MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//}

		private void limpiarPlantilla()
		{
			txtCodigo.Clear();
			txtDesc.Clear();
		}

		private void listaPlantillas()
		{
			string error = "";
			Listado listD = new Listado();
			listD.COLUMNAS = "Codigo as Código, Nombre, Cobrador";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "NV_PLANTILLA_COBRADOR";
			listD.TITULO_LISTADO = "Plantillas";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtCodigo.Text = f1.item.SubItems[0].Text;
				txtDesc.Text = f1.item.SubItems[1].Text;
				txtCobrador.Text = f1.item.SubItems[2].Text;
				Cursor.Current = Cursors.WaitCursor;
				verificarConfigurablesPlantillas(ref error);
				FuncsInternas.obtenerSubtipoRec(txtCodigo.Text, ref subtipoRec, ref error);

				refrescarDatos(false, true);
				//refrescarDatos();

				if (ListadoPorFac.Equals("S"))
				{
					if (dgvColegiados.Rows.Count > 0)
						dgvColegiados.Columns["Documento"].Visible = true;
				}
				else
				{
					if (dgvColegiados.Rows.Count > 0)
						dgvColegiados.Columns["Documento"].Visible = false;
				}

				Cursor.Current = Cursors.Default;
			}
		}

		private void cargarPlantilla(string codigo)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_PLANTILLA_COBRADOR";
			listA.FILTRO = "where Codigo = '" + codigo + "'";
			string error = "";
			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCodigo.Text = dtTTs.Rows[0]["Codigo"].ToString();
					txtDesc.Text = dtTTs.Rows[0]["Nombre"].ToString();
					txtCobrador.Text = dtTTs.Rows[0]["Cobrador"].ToString();
					Cursor.Current = Cursors.WaitCursor;
					verificarConfigurablesPlantillas(ref error);

					refrescarDatos(false, true);
					//refrescarDatos();

					if (ListadoPorFac.Equals("S"))
					{
						if (dgvColegiados.Rows.Count > 0)
							dgvColegiados.Columns["Documento"].Visible = true;
					}
					else
					{
						if (dgvColegiados.Rows.Count > 0)
							dgvColegiados.Columns["Documento"].Visible = false;
					}

					Cursor.Current = Cursors.Default;
				}
				else
				{
					limpiarPlantilla();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void verificarConfigurablesPlantillas(ref string error)
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			//listA.COLUMNAS = "Conectividad,Par,Bac,PlantillaRespuesta,TipoIdentificacion";
			listA.COLUMNAS = "SumarArreglo,ArregloPorDocumento,RubroColegiatura,RubroRegencia,ListadoPorFac,GenerarPor,PlantillaRespuesta,TipoIdentificacion";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_PLANTILLA_COBRADOR";
			listA.FILTRO = "where Codigo = '" + txtCodigo.Text + "'";
			//listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					SumarArreglo = dt.Rows[0]["SumarArreglo"].ToString();
					ArregloPorDocumento = dt.Rows[0]["ArregloPorDocumento"].ToString();
					RubroColegiatura = dt.Rows[0]["RubroColegiatura"].ToString();
					RubroRegencia = dt.Rows[0]["RubroRegencia"].ToString();
					ListadoPorFac = dt.Rows[0]["ListadoPorFac"].ToString();
					GenerarPor = dt.Rows[0]["GenerarPor"].ToString();

					if (dt.Rows[0]["PlantillaRespuesta"].ToString() == "P")
					{
						esPlantillaPredef = true;
					}
					else
					{
						esPlantillaPredef = false;
					}

					if (dt.Rows[0]["TipoIdentificacion"].ToString() == "C")
					{
						tipoIdentificacionCarga = "C";
					}
					else if (dt.Rows[0]["TipoIdentificacion"].ToString() == "N")
					{
						tipoIdentificacionCarga = "N";
					}
					else
					{
						tipoIdentificacionCarga = "";
					}


				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void refrescarDatos(bool esEmparejar, bool borrarCarga)
		{
			string sQuery = "", error = "", CampoDoc = "", queryEmparejar = "";

			try
			{
				if (!esEmparejar)
					chkEmparejarDatos.Checked = false;

				if (ListadoPorFac.Equals("S"))
				{
					queryEmparejar = esEmparejar ? " JOIN ( select Colegiado, Documento, SUM(Saldo) Saldo from " + Consultas.sqlCon.COMPAÑIA + ".NV_ARCHIVO_CARGA_TEMP group by Colegiado, Documento" +
							" ) t5 ON (t5.Colegiado = t2.Cedula or t5.Colegiado = t2.NumeroColegiado) and SUBSTRING(t5.DOCUMENTO, PATINDEX('%[^0]%', t5.DOCUMENTO), LEN(t5.DOCUMENTO)) = SUBSTRING(t1.Documento, PATINDEX('%[^0]%', t1.Documento), LEN(t1.Documento)) " : "";
					sQuery = "SELECT t1.IdColegiado, t1.Cedula, t1.NumeroColegiado, t2.Nombre, t1.Documento, t1.FechaDocumento, t1.Monto" +
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado " +
						queryEmparejar +
						" WHERE t1.Cobrador = '" + txtCobrador.Text + "'";
				}
				else
				{
					queryEmparejar = esEmparejar ? " JOIN ( select Colegiado, Documento, SUM(Saldo) Saldo from " + Consultas.sqlCon.COMPAÑIA + ".NV_ARCHIVO_CARGA_TEMP group by Colegiado, Documento ) t5 on t5.colegiado = t2.NumeroColegiado or t5.colegiado = t2.Cedula " : "";
					sQuery = "SELECT t1.IdColegiado, t1.Cedula, t1.NumeroColegiado, t2.Nombre, SUM(t1.Monto) Monto" +
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.IdColegiado " +
						queryEmparejar +
						" WHERE t1.Cobrador = '" + txtCobrador.Text + "'" +
						" GROUP BY t1.IdColegiado, t1.Cedula, t1.NumeroColegiado, t2.Nombre";
				}

				dtRefrescarDatos.Rows.Clear();

				if (Consultas.fillDataTable(sQuery, ref dtRefrescarDatos, ref error))
				{
					if (dtRefrescarDatos.Rows.Count > 0)
					{
						dtRefrescarDatosTemp.Rows.Clear();
						if (borrarCarga)
						{
							dgvCarga.Columns.Clear();
							totalRegistrosCarga = 0;
							totalSaldosCarga = 0;
						}
						dgvDetalle.Rows.Clear();
						totalRegistros = 0;
						totalSaldos = 0;
						desactivarLabels();

						foreach (DataRow row in dtRefrescarDatos.Rows)
						{
							if (ListadoPorFac.Equals("S"))
								CampoDoc = row["Documento"].ToString().Trim();

							totalRegistros += 1;
							totalSaldos = totalSaldos + decimal.Parse(row["Monto"].ToString());
							//string monto = "0.00";
							string saldo = "0.00";
							//if (!string.IsNullOrEmpty(row["MONTO"].ToString()))
							//	monto = decimal.Parse(row["MONTO"].ToString()).ToString("N2");

							if (!string.IsNullOrEmpty(row["Monto"].ToString()))
								saldo = decimal.Parse(row["Monto"].ToString()).ToString("N2");
							dtRefrescarDatosTemp.Rows.Add(false, row["IdColegiado"].ToString().Trim(), row["Cedula"].ToString().Trim(), row["NumeroColegiado"].ToString().Trim(),
								row["Nombre"].ToString(), CampoDoc, string.Empty, /*monto, string.Empty,*/ saldo, string.Empty, iList.Images[0], "");
						}
						lblRegistrosCant.Text = totalRegistros.ToString();
						lblCantTotal.Text = totalSaldos.ToString("N2");
						lblCantRegistrosCarga.Text = totalRegistrosCarga.ToString();
						lblCantTotalesSaldosCarga.Text = totalSaldosCarga.ToString("N2");
						DataView view = new DataView(dtRefrescarDatosTemp);
						source1.DataSource = view;
						dgvColegiados.DataSource = view;
						//dgvColegiados.Columns["Monto Pagado"].Visible = false;
						dgvColegiados.Columns["IdColegiado"].Visible = false;
						dgvColegiados.Columns["Cobrador"].Visible = false;
						dgvColegiados.Columns["Monto a Favor"].Visible = false;
						dgvColegiados.AutoResizeColumns();
						dgvColegiados.Refresh();
					}
					else
					{
						MessageBox.Show("No hay facturas a cobrar asociadas a este cobrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//txtCobrador.Text = "";
						txtDescCobrador.Text = "";

						dgvColegiados.DataSource = null;
					}
				}
				else
				{
					MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void cargarSubTipo(string sub)
		{
			string error = "";
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "SUBTIPO,DESCRIPCION";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "SUBTIPO_DOC_CC";
			listA.FILTRO = "where TIPO = 'REC' and SUBTIPO = '" + sub + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtSubTipoDoc.Valor = dtTTs.Rows[0]["SUBTIPO"].ToString();
					txtSubTipoDocNombre.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
				}
				else
				{
					txtSubTipoDoc.Clear();
					txtSubTipoDocNombre.Clear();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void activarLabels()
		{
			lblErrores.Visible = true;
			lblExitosos.Visible = true;
			lblErroresCant.Visible = true;
			lblExitososCant.Visible = true;
			lblErroresCant.Text = totalRegistrosErroneos.ToString();
			lblExitososCant.Text = totalRegistrosExitosos.ToString();
		}

		private void desactivarLabels()
		{
			bwProceso = new BackgroundWorker();
			totalRegistrosErroneos = 0;
			totalRegistrosExitosos = 0;
			lblErrores.Visible = false;
			lblExitosos.Visible = false;
			lblErroresCant.Visible = false;
			lblExitososCant.Visible = false;
			lblErroresCant.Text = "0";
			lblExitososCant.Text = "0";
		}

		//private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
		//{
		//	listaCobradores();
		//}

		//private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.KeyValue == (char)Keys.F1 && !txtCobrador.ReadOnly)
		//		listaCobradores();
		//}

		//private void txtCobrador_Leave(object sender, EventArgs e)
		//{
		//	string error = "";
		//	if (txtCobrador.Text.Trim().Equals(""))
		//	{
		//		txtDescCobrador.Clear();
		//	}
		//	else
		//	{
		//		if (oldValue != txtCobrador.Text)
		//		{
		//			FuncsInternas.obtenerSubtipoRec(txtCobrador.Text, ref subtipoRec, ref error);
		//			cargarCobrador(txtCobrador.Text);
		//			if (txtCobrador.Text.Trim() == "")
		//				MessageBox.Show("El Cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//		}
		//	}
		//}

		private void txtCodigo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaPlantillas();
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCodigo.ReadOnly)
				listaPlantillas();
		}

		private void txtCodigo_Leave(object sender, EventArgs e)
		{

		}

		private void txtCodigo_Enter(object sender, EventArgs e)
		{
			oldValue = txtCodigo.Text;
		}

		public void cargarArchivo()
		{
			tipoArchivo = "";

			try
			{
				this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls;*.xlsx|Csv files (*.csv)|*.csv";
				this.openFileDialog1.ShowDialog();

				if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
				{
					string ext = Path.GetExtension(this.openFileDialog1.FileName);
					rutaArchivo = this.openFileDialog1.FileName;
					totalRegistrosCarga = 0;
					totalSaldosCarga = 0;

					Cursor.Current = Cursors.WaitCursor;
					if (esPlantillaPredef)
					{
						FuncionesInternas.lecturaArchivoPredeterminados(dgvCarga, ListadoPorFac, rutaArchivo, tipoIdentificacionCarga);
					}
					else
					{
						if (ext == ".txt")
						{
							tipoArchivo = "txt";
							//if (esPlantillaPredef)
							//    FuncionesInternas.lecturaArchivoTxt("777", dgvCarga, '-', rutaArchivo);
							//else
							FuncionesInternas.lecturaArchivoTxt(txtCobrador.Text, dgvCarga, '-', rutaArchivo);
						}
						else
						{
							if (ext == ".xls" || ext == ".xlsx")
							{
								tipoArchivo = "xls";
								//if (esPlantillaPredef)
								//    FuncionesInternas.lecturaArchivoXls(dgvCarga, "777", rutaArchivo);
								//else
								FuncionesInternas.lecturaArchivoXls(dgvCarga, txtCobrador.Text, rutaArchivo);
							}
							else
							{
								tipoArchivo = "csv";
								//if(esAplicacionBac)
								//    FuncionesInternas.lecturaArchivoCsv(txtCobrador.Text, dgvCarga, ',', rutaArchivo);
								//else
								//    FuncionesInternas.lecturaArchivoCsv(txtCobrador.Text, dgvCarga, ',', rutaArchivo);
								//if (esPlantillaPredef)
								//    FuncionesInternas.lecturaArchivoCsv("777", dgvCarga, ',', rutaArchivo);
								//else
								FuncionesInternas.lecturaArchivoCsv(txtCobrador.Text, dgvCarga, ',', rutaArchivo);
							}

						}
					}
					if (dgvCarga.Rows.Count > 0)
					{
						foreach (DataGridViewRow row in dgvCarga.Rows)
						{
							try
							{
								totalRegistrosCarga += 1;
								totalSaldosCarga = totalSaldosCarga + decimal.Parse(row.Cells["SALDO"].Value.ToString());
							}
							catch (Exception ex)
							{
								MessageBox.Show("Error: " + ex.ToString());
							}
						}
						lblCantRegistrosCarga.Text = totalRegistrosCarga.ToString();
						lblCantTotalesSaldosCarga.Text = totalSaldosCarga.ToString("N2");
					}
					cargarSubTipo(subtipoRec);
					Cursor.Current = Cursors.Default;

				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.ToString());
			}
		}

		private void activarMasivo()
		{
			int registros = 0;
			foreach (DataGridViewRow row in dgvColegiados.Rows)
			{
				registros = dgvColegiados.Rows.Count;
				row.Cells["Ver detalle"].Value = true;
				if (ListadoPorFac.Equals("S"))
					cargarDetalle(row.Cells["Cédula"].Value.ToString(), row.Cells["Documento"].Value.ToString());
				else
					cargarDetalle(row.Cells["Cédula"].Value.ToString(), string.Empty);
			}
			dgvColegiados.EndEdit();
			//cargarDetalleMasivo2();
			actualziarTotalesDetalle();
		}

		private void desactivarMasivo()
		{
			foreach (DataGridViewRow row in dgvColegiados.Rows)
			{
				//row.Cells["colSelecDetalle"].Value = false;
				row.Cells["Ver detalle"].Value = false;
				//row.Cells["colSeleccion"].ReadOnly = false;Ver detalle
			}
			dgvColegiados.EndEdit();
			dgvDetalle.Rows.Clear();
			actualziarTotalesDetalle();
			//chkMasivo.Checked = false;
		}

		private void cargarDetalle(string colegiado, string documento)
		{
			DataTable dt = new DataTable();
			string error = "";
			string queryDoc = "",  query = "";

			if (ListadoPorFac.Equals("S"))
			{
				queryDoc = "AND t1.Documento = '" + documento + "'";
			}

			query = "select t2.DOCUMENTO, t2.APLICACION, t1.Cedula AS CÉDULA, t1.NumeroColegiado as 'Nº COLEGIADO', t3.Nombre as NOMBRE, t2.MONTO AS MONTO, t1.Monto AS SALDO, t2.FECHA" +
					" from " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES t1" +
					" join " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 on t1.IdColegiado = t2.CLIENTE and t1.Documento = t2.DOCUMENTO" +
					" join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 on t1.IdColegiado = t3.IdColegiado" +
					" where t1.IdColegiado = '" + colegiado + "' and t1.Cobrador = '" + txtCobrador.Text + "' " + queryDoc;

			try
			{
				if (Consultas.fillDataTable(query, ref dt, ref error))
				{
					//dgvDetalle.Rows.Clear();
					foreach (DataRow row in dt.Rows)
					{
						dgvDetalle.Rows.Add(row["DOCUMENTO"].ToString(), row["APLICACION"].ToString(), row["CÉDULA"].ToString(), row["Nº COLEGIADO"].ToString(),
							row["NOMBRE"].ToString(), decimal.Parse(row["MONTO"].ToString()).ToString("N2"), decimal.Parse(row["SALDO"].ToString()).ToString("N2"), DateTime.Parse(row["FECHA"].ToString()));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string queryDocs(string colegiado, string documento)
		{
			string queryDoc = !string.IsNullOrEmpty(documento) ? "and t2.DOCUMENTO = '" + documento + "'" : "";
			string vendedor = "";

			if (RubroColegiatura.Equals("S") && RubroRegencia.Equals("S"))
				vendedor = "'ND','COL','REG'";
			else if (RubroColegiatura.Equals("S"))
				vendedor = "'ND','COL'";
			else if (RubroRegencia.Equals("S"))
				vendedor = "'REG'";


			string query = "select t1.Tipo 'TIPO', t1.Documento 'DOCUMENTO', t1.IdColegiado 'CLIENTE', t1.Monto 'SALDO', t1.FechaDocumento 'FECHA_DOCUMENTO', t1.PagosParciales 'PAGOS_PARCIALES'" +
					" from " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES t1" +
					" join " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 on t2.DOCUMENTO = t1.Documento" +
					" where (t1.IdColegiado = '" + colegiado + "' and t1.Cobrador = '" + txtCobrador.Text + "' and t1.Monto > 0 " + queryDoc +
					") and (t1.Tipo = 'FAC' and t1.Vendedor in (" + vendedor + ") or t1.Tipo = 'O/D') and t2.SALDO > 0";

			return query;
		}

		//private void txtCobrador_Enter(object sender, EventArgs e)
		//{
		//	oldValue = txtCobrador.Text;
		//}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnResize_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 0)
			{
				Cursor.Current = Cursors.WaitCursor;
				dgvColegiados.AutoResizeColumns();
				Cursor.Current = Cursors.Default;
			}

			if (tabControl1.SelectedIndex == 1)
			{
				Cursor.Current = Cursors.WaitCursor;
				dgvDetalle.AutoResizeColumns();
				Cursor.Current = Cursors.Default;
			}

			if (tabControl1.SelectedIndex == 2)
			{
				Cursor.Current = Cursors.WaitCursor;
				dgvCarga.AutoResizeColumns();
				Cursor.Current = Cursors.Default;
			}

		}

		private void btnProcesar_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("Se esta trabajando en este proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

			dgvColegiados.EndEdit();
			dgvDetalle.EndEdit();
			if (validarDatos())
			{

				btnSalir.Enabled = false;
				btnProcesar.Enabled = false;
				FuncionesInternas.deshabilitarOrdenDgv(ref dgvColegiados);
				CheckForIllegalCrossThreadCalls = false;
				pbProceso.Minimum = 0;
				pbProceso.Maximum = dgvColegiados.RowCount + 1;
				//pbProceso.Maximum = marcados;
				bwProceso = new BackgroundWorker();

				// Seteamos al bw que sea de manera Async.
				bwProceso.DoWork += bwProceso_DoWork;

				// Seteamos al bw que sea de manera Async.
				bwProceso.ProgressChanged += bwProceso_ProgressChanged;

				// Seteamos al bw que sea de manera Async.
				bwProceso.RunWorkerCompleted += bwProceso_RunWorkerCompleted;

				// Necesitamos setear esta propiedad para reportar al bw los cambios.
				bwProceso.WorkerReportsProgress = true;

				bwProceso.RunWorkerAsync();
			}

			dgvColegiados.EndEdit();
		}

		private void bwProceso_DoWork(object sender, DoWorkEventArgs e)
		{
			//procesoCobro();
			cobroMasivoCobrador();
		}

		private void bwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			btnSalir.Enabled = true;
			btnProcesar.Enabled = true;
			FuncionesInternas.habilitarOrdenDgv(ref dgvColegiados);
			pbProceso.Value = 0;
			activarLabels();
		}

		private void bwProceso_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbProceso.Value = e.ProgressPercentage;
		}

		private void obtenerIdentificadorArchivo(ref bool esCedula, ref bool esSaldo, ref bool esMonto)
		{
			bool OK = true;
			string error = "";
			DataTable dt = new DataTable();

			string sQueryOrden = "select Macro, Columna from " + Consultas.sqlCon.COMPAÑIA + ".NV_PLANTILLA_COBRADOR_DETALLE where Codigo = '" + txtCodigo.Text + "' and(Macro in ('MONTO', 'CARNET') OR Macro in ('MONTO', 'CEDULA') OR Macro in ('SALDO', 'CARNET') OR Macro in ('SALDO', 'CEDULA'))";

			OK = Consultas.fillDataTable(sQueryOrden, ref dt, ref error);

			if (OK)
			{
				foreach (DataRow linea in dt.Rows)
				{
					if (linea["Macro"].ToString() == "CEDULA")
					{
						esCedula = true;
					}
					//else
					//{
					//    esCedula = false;
					//}

					if (linea["Macro"].ToString() == "SALDO")
					{
						esSaldo = true;
					}
					//else
					//{
					//    esSaldo = false;
					//}

					if (linea["Macro"].ToString() == "MONTO")
					{
						esMonto = true;
					}
					//else
					//{
					//    esMonto = false;
					//}


				}
			}
		}

		private void obtenerIdentificadorArchivo(ref bool esCedula)
		{
			bool OK = true;
			string error = "";
			DataTable dt = new DataTable();

			string sQueryOrden = "select Macro, Columna from " + Consultas.sqlCon.COMPAÑIA + ".NV_PLANTILLA_COBRADOR_DETALLE where Codigo = '" + txtCodigo.Text + "' and (Macro = 'CARNET' OR Macro = 'CEDULA')";

			OK = Consultas.fillDataTable(sQueryOrden, ref dt, ref error);

			if (OK)
			{
				foreach (DataRow linea in dt.Rows)
				{
					if (linea["Macro"].ToString() == "CEDULA")
					{
						esCedula = true;
					}
					else
					{
						esCedula = false;
					}



				}
			}
		}

		private void cobroMasivoCobrador()
		{
			string error = "";
			int progreso = 0;
			//bool esCedula = false;
			bool esSaldo = false;
			bool esMonto = false;
			bool soloRecibo = false;
			decimal saldoFavor = 0;

			Cursor.Current = Cursors.WaitCursor;

			exportarDatos(true);

			dgvColegiados.Columns["Monto a Favor"].Visible = true;

			if (!esPlantillaPredef)//Ya se puede verificar desde antes con las nuevas config-CAMBIAR
				obtenerIdentificadorArchivo(ref esCedula, ref esSaldo, ref esMonto);//Averiguamos si el archivo de carga viene con cedula o con carnet

			foreach (DataGridViewRow row in dgvColegiados.Rows)
			{
				bool OK = true;
				decimal MontoArchivo = -1;
				string msj = "";
				//string identificadorArchivo = "";

				try
				{
					Consultas.sqlCon.iniciaTransaccion();

					DataTable dtDocumentosPorColegiado = new DataTable();

					string sQuery = queryDocs(row.Cells["IdColegiado"].Value.ToString(), row.Cells["Documento"].Value.ToString());

					OK = Consultas.fillDataTable(sQuery, ref dtDocumentosPorColegiado, ref error);

					if (OK)
					{
						if (dtDocumentosPorColegiado.Rows.Count == 0)
						{
							OK = false;
							error = "Actualmente no cuenta con documentos con saldo para aplicar, debe generar la plantilla nuevamente.";
						}
					}					

					#region MAPEAR_MONTO_CARGA
					if (OK)
					{
						foreach (DataGridViewRow dgv in dgvCarga.Rows)
						{
							if (esPlantillaPredef && dgvCarga.Columns.Count == 3)
							{
								//identificadorArchivo = dgv.Cells["IDENTIFICACION"].Value.ToString();
								if ((dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(row.Cells["Cédula"].Value.ToString(), StringComparison.OrdinalIgnoreCase) || dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(row.Cells["Nº Colegiado"].Value.ToString(), StringComparison.OrdinalIgnoreCase)) && fInternas.quitarCerosMontoInicio(dgv.Cells["NUMERO_FACTURA"].Value.ToString()) == fInternas.quitarCerosMontoInicio(row.Cells["Documento"].Value.ToString())/*row.Cells["colCedulaCobrador"].Value.ToString()*/)
								{
									if (MontoArchivo.Equals(-1))
										MontoArchivo = 0;

									MontoArchivo = MontoArchivo + decimal.Parse(dgv.Cells["SALDO"].Value.ToString());

									//break;
								}
							}
							else
							{
								//identificadorArchivo = dgv.Cells["IDENTIFICACION"].Value.ToString();
								if (esPlantillaPredef && dgvCarga.Columns.Count == 2)
								{
									if (dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(row.Cells["Cédula"].Value.ToString(), StringComparison.OrdinalIgnoreCase) || dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(row.Cells["Nº Colegiado"].Value.ToString(), StringComparison.OrdinalIgnoreCase))
									{
										if (MontoArchivo.Equals(-1))
											MontoArchivo = 0;

										MontoArchivo = MontoArchivo + decimal.Parse(dgv.Cells["SALDO"].Value.ToString());

										//break;
									}
								}
								else
								{
									if (esCedula)
									{
										//identificadorArchivo = dgv.Cells["CEDULA"].Value.ToString();
										if (dgv.Cells["CEDULA"].Value.ToString().Equals(row.Cells["Cédula"].Value.ToString(), StringComparison.OrdinalIgnoreCase)/*row.Cells["colCedulaCobrador"].Value.ToString()*/)
										{
											if (esSaldo)
											{
												if (MontoArchivo.Equals(-1))
													MontoArchivo = 0;

												MontoArchivo = MontoArchivo + decimal.Parse(dgv.Cells["SALDO"].Value.ToString());
											}
											else
											{
												if (esMonto)
												{
													if (MontoArchivo.Equals(-1))
														MontoArchivo = 0;

													MontoArchivo = MontoArchivo + decimal.Parse(dgv.Cells["MONTO"].Value.ToString());
												}
												else
												{
													OK = false;
													error = "La plantilla no posee una macro de monto o saldo";
												}
											}
											//break;
										}
									}
									else
									{
										//identificadorArchivo = dgv.Cells["CARNET"].Value.ToString();
										if (dgv.Cells["CARNET"].Value.ToString().Equals(row.Cells["Nº Colegiado"].Value.ToString(), StringComparison.OrdinalIgnoreCase)/*row.Cells["colNumeroColegiado"].Value.ToString()*/)
										{
											if (esSaldo)
											{
												if (MontoArchivo.Equals(-1))
													MontoArchivo = 0;

												MontoArchivo = MontoArchivo + decimal.Parse(dgv.Cells["SALDO"].Value.ToString());
											}
											else
											{
												if (esMonto)
												{
													if (MontoArchivo.Equals(-1))
														MontoArchivo = 0;

													MontoArchivo = MontoArchivo + decimal.Parse(dgv.Cells["MONTO"].Value.ToString());
												}
												else
												{
													OK = false;
													error = "La plantilla no posee una macro de monto o saldo";
												}
											}
											//break;
										}
									}
								}
							}

						}

						if (MontoArchivo == -1)
						{
							//soloRecibo = true;
							OK = false;
							//identificadorArchivo = obtenerIdColegiadoCarga(identificadorArchivo);
							error = "No se encontraron coincidencias entre la plantilla de carga y el resumen";
						}

						if (MontoArchivo == 0)
						{
							OK = false;
							error = "El monto cargado en el archivo es cero";
						}


					} 
					#endregion

					if (OK)
					{
						OK = controlerBD.cobrosCobrador(dtDocumentosPorColegiado, row.Cells["IdColegiado"].Value.ToString()/*row.Cells["colCedulaCobrador"].Value.ToString()*/, txtCobrador.Text, MontoArchivo, txtNumDocumentoCarga.Text, dtpFechaDoc.Value.Date, soloRecibo, subtipoRec, ref saldoFavor, ref error);
					}

					if (OK)
					{
						Consultas.sqlCon.Commit();
						totalRegistrosExitosos += 1;
						//row.Cells["colResultado"].Value = iList.Images[2];
						//row.Cells["colObservaciones"].Value = msj;
						row.Cells["Estado"].Value = iList.Images[2];
						row.Cells["Observaciones"].Value = "¡Proceso Exitoso!";
						row.Cells["Monto a Favor"].Value = saldoFavor;
					}
					else
					{
						Consultas.sqlCon.Rollback();
						totalRegistrosErroneos += 1;
						//row.Cells["colResultado"].Value = iList.Images[1];
						//row.Cells["colObservaciones"].Value = error;
						row.Cells["Estado"].Value = iList.Images[1];
						row.Cells["Observaciones"].Value = error;
						row.Cells["Monto a Favor"].Value = saldoFavor;
					}


				}
				catch (Exception ex)
				{
					Consultas.sqlCon.Rollback();
					totalRegistrosErroneos += 1;
					//row.Cells["colResultado"].Value = iList.Images[1];
					//row.Cells["colObservaciones"].Value = ex.Message;
					row.Cells["Estado"].Value = iList.Images[1];
					row.Cells["Observaciones"].Value = ex.Message;
					row.Cells["Monto a Favor"].Value = saldoFavor;
				}

				progreso += 1;
				bwProceso.ReportProgress(progreso);


			}

			#region INSERTAR_RECIBOS_SIN_FACTURAS
			if (esPlantillaPredef && dgvCarga.Columns.Count == 3)
			{
				foreach (DataGridViewRow row in dgvCarga.Rows)
				{
					bool OK = true;
					bool existe = false;
					try
					{

						foreach (DataGridViewRow dgv in dgvColegiados.Rows)
						{

							if ((row.Cells["IDENTIFICACION"].Value.ToString().Equals(dgv.Cells["Cédula"].Value.ToString(), StringComparison.OrdinalIgnoreCase) || row.Cells["IDENTIFICACION"].Value.ToString().Equals(dgv.Cells["Nº Colegiado"].Value.ToString(), StringComparison.OrdinalIgnoreCase)) && row.Cells["NUMERO_FACTURA"].Value.ToString() == fInternas.quitarCerosMontoInicio(dgv.Cells["Documento"].Value.ToString()))
							{
								existe = true;
								break;
							}
						}

						if (!existe)
						{
							Consultas.sqlCon.iniciaTransaccion();
							if (OK)
							{
								OK = controlerBD.cobrosCobrador(new DataTable(), row.Cells["IDENTIFICACION"].Value.ToString(), txtCobrador.Text, decimal.Parse(row.Cells["SALDO"].Value.ToString()), txtNumDocumentoCarga.Text, dtpFechaDoc.Value, true, subtipoRec, ref saldoFavor, ref error);
							}

							if (OK)
								Consultas.sqlCon.Commit();
							else
								Consultas.sqlCon.Rollback();

						}


					}
					catch (Exception ex)
					{
						Consultas.sqlCon.Rollback();
					}



				}
			}
			else
			{
				if (esPlantillaPredef && dgvCarga.Columns.Count == 2)
				{
					foreach (DataGridViewRow row in dgvCarga.Rows)
					{
						bool OK = true;
						bool existe = false;

						try
						{

							foreach (DataGridViewRow dgv in dgvColegiados.Rows)
							{

								if (row.Cells["IDENTIFICACION"].Value.ToString().Equals(dgv.Cells["Cédula"].Value.ToString(), StringComparison.OrdinalIgnoreCase) || row.Cells["IDENTIFICACION"].Value.ToString().Equals(dgv.Cells["Nº Colegiado"].Value.ToString(), StringComparison.OrdinalIgnoreCase))
								{
									existe = true;
									break;
								}
							}

							if (!existe)
							{
								Consultas.sqlCon.iniciaTransaccion();
								if (OK)
								{
									OK = controlerBD.cobrosCobrador(new DataTable(), row.Cells["IDENTIFICACION"].Value.ToString(), txtCobrador.Text, decimal.Parse(row.Cells["SALDO"].Value.ToString()), txtNumDocumentoCarga.Text, dtpFechaDoc.Value, true, subtipoRec, ref saldoFavor, ref error);
								}

								if (OK)
									Consultas.sqlCon.Commit();
								else
									Consultas.sqlCon.Rollback();

							}


						}
						catch (Exception ex)
						{
							Consultas.sqlCon.Rollback();
						}
					}
				}
			}
			#endregion


			Cursor.Current = Cursors.Default;
		}

		private void crearQueryDocumentos(DataGridViewRow row, ref string sQuery)
		{
			////sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
			////                        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			////                        " where t1.CLIENTE = '" + row.Cells["colCedulaCobrador"].Value.ToString() + "' and t1.COBRADOR = '" + txtCobrador.Text + "' and t1.SALDO > 0 and(t1.TIPO = 'FAC' or(t1.TIPO = 'O/D' and t1.SUBTIPO = '176'))" +
			////                        " order by t1.FECHA asc";

			//if (esAplicacionConectividad)
			//{
			//    //sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
			//    //        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			//    //        " where t1.DOCUMENTO = '" + /*row.Cells["colDoc"].Value.ToString()*/row.Cells["Documento"].Value.ToString() + "'  and t1.VENDEDOR = 'COL' and t1.SALDO > 0 and(t1.TIPO = 'FAC' or(t1.TIPO = 'O/D' and t1.SUBTIPO = '176'))" +
			//    //        " order by t1.FECHA asc";
			//    sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			//            " where t1.DOCUMENTO = '" + /*row.Cells["colDoc"].Value.ToString()*/row.Cells["Documento"].Value.ToString() + "'  and" +
			//            " (t1.SALDO > 0 AND t1.VENDEDOR = 'COL' AND t1.TIPO = 'FAC') or t1.DOCUMENTO = '" + /*row.Cells["colDoc"].Value.ToString()*/row.Cells["Documento"].Value.ToString() + "'  and" +
			//            " (t1.SALDO > 0 AND t1.TIPO = 'O/D' AND t1.SUBTIPO = '176')" +
			//            " order by t1.FECHA_DOCUMENTO asc";
			//}

			//if (esAplicacionPar)
			//{
			//    //sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
			//    //        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			//    //        " where t1.DOCUMENTO = '" + /*row.Cells["colDoc"].Value.ToString()*/row.Cells["Documento"].Value.ToString() + "'  and t1.VENDEDOR in ('REG','COL')  and t1.SALDO > 0 and(t1.TIPO = 'FAC' or(t1.TIPO = 'O/D' and t1.SUBTIPO = '176'))" +
			//    //        " order by t1.FECHA asc";
			//    sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			//            " where (t1.DOCUMENTO = '" + /*row.Cells["colDoc"].Value.ToString()*/row.Cells["Documento"].Value.ToString() + "' and t1.SALDO > 0 AND t1.VENDEDOR in ('REG','COL') AND t1.TIPO = 'FAC') or" +
			//            " (t1.DOCUMENTO = '" + /*row.Cells["colDoc"].Value.ToString()*/row.Cells["Documento"].Value.ToString() + "' and t1.SALDO > 0 AND t1.TIPO = 'O/D' AND t1.SUBTIPO = '176')" +
			//            " order by t1.FECHA_DOCUMENTO asc";
			//}

			//if (esAplicacionBac)
			//{
			//    //sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
			//    //        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			//    //        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_FACTURAS t3 on t3.CodigoDocumento = t1.DOCUMENTO" +
			//    //        " where t1.CLIENTE = '" + /*row.Cells["colCedulaCobrador"].Value.ToString()*/row.Cells["Cédula"].Value.ToString() + "' "+
			//    //        " t2.SALDO > 0 AND (t2.VENDEDOR = 'COL' AND t2.COBRADOR = '" + txtCobrador.Text + "' and t2.TIPO = 'FAC') or " +
			//    //        " (t2.TIPO = 'O/D' AND t2.SUBTIPO = '176' AND datepart(YYYY, t2.FECHA) = datepart(YYYY, GETDATE())" +
			//    //        " AND datepart(mm, t2.FECHA) = datepart(mm, GETDATE()))" +
			//    //        " order by t1.FECHA asc";
			//    sQuery = "SELECT * FROM ( SELECT  t2.* FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
			//        " WHERE t2.CLIENTE = '" + FuncsInternas.obtenerIdColegiado(row.Cells["Cédula"].Value.ToString()) + "' and(t2.SALDO > 0 AND t2.VENDEDOR in ('COL','REG') AND t1.COBRADOR = '" + txtCobrador.Text + "' and t2.TIPO = 'FAC')" +
			//        " union all SELECT t3.* FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
			//        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
			//        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t3 ON t3.CLIENTE = t1.IdColegiado and t3.TIPO = 'O/D' and t3.SUBTIPO = '176' and datepart(YYYY, t3.FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, t3.FECHA) = datepart(mm, t2.FECHA) and t2.CLIENTE = '" + /*row.Cells["colCedulaCobrador"].Value.ToString()*/FuncsInternas.obtenerIdColegiado(row.Cells["Cédula"].Value.ToString()) + "'" +
			//        " WHERE(t2.SALDO > 0 AND  t2.VENDEDOR in ('COL','REG') AND t1.COBRADOR = '" + txtCobrador.Text + "' AND t2.TIPO = 'FAC') ) tabla order by FECHA_DOCUMENTO asc";
			//}

			//if (!esAplicacionConectividad && !esAplicacionPar && !esAplicacionBac)
			//{
			//    //sQuery = "select t1.* from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
			//    //        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
			//    //        " where t1.CLIENTE = '" + /*row.Cells["colCedulaCobrador"].Value.ToString()*/row.Cells["Cédula"].Value.ToString() + "' " +
			//    //        " t2.SALDO > 0 AND(t2.VENDEDOR in ('REG', 'COL') AND t2.COBRADOR = '" + txtCobrador.Text + "' and t2.TIPO = 'FAC') or " +
			//    //        " (t2.TIPO = 'O/D' AND t2.SUBTIPO = '176' AND datepart(YYYY, t2.FECHA) = datepart(YYYY, GETDATE())" +
			//    //        " AND datepart(mm, t2.FECHA) = datepart(mm, GETDATE()))" +
			//    //        " order by t1.FECHA asc";
			//    sQuery = "SELECT * FROM ( SELECT  t2.* FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
			//        " WHERE t2.CLIENTE = '" + FuncsInternas.obtenerIdColegiado(row.Cells["Cédula"].Value.ToString()) + "' and(t2.SALDO > 0 AND t2.VENDEDOR in ('REG', 'COL') AND t1.COBRADOR = '" + txtCobrador.Text + "' and t2.TIPO = 'FAC')" +
			//        " union all SELECT t3.* FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
			//        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
			//        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t3 ON t3.CLIENTE = t1.IdColegiado and t3.TIPO = 'O/D' and t3.SUBTIPO = '176' and datepart(YYYY, t3.FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, t3.FECHA) = datepart(mm, t2.FECHA) and t2.CLIENTE = '" + /*row.Cells["colCedulaCobrador"].Value.ToString()*/FuncsInternas.obtenerIdColegiado(row.Cells["Cédula"].Value.ToString()) + "'" +
			//        " WHERE(t2.SALDO > 0 AND  t2.VENDEDOR in ('REG', 'COL') AND t1.COBRADOR = '" + txtCobrador.Text + "' AND t2.TIPO = 'FAC') ) tabla order by FECHA_DOCUMENTO asc";
			//}



		}

		private void limpiarDetalle(string colegiado)
		{
			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				if (colegiado == row.Cells["colCedDetalle"].Value.ToString())
				{
					dgvDetalle.Rows[row.Index].Selected = true;
				}
			}

			foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
			{
				if (colegiado == row.Cells["colCedDetalle"].Value.ToString())
				{
					dgvDetalle.Rows.Remove(row);
				}
			}
		}

		private void limpiarDetalle(string colegiado, string documento)
		{
			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				if (colegiado == row.Cells["colCedDetalle"].Value.ToString() && documento == row.Cells["colDocumento"].Value.ToString())
				{
					dgvDetalle.Rows[row.Index].Selected = true;
				}
			}

			foreach (DataGridViewRow row in dgvDetalle.SelectedRows)
			{
				if (colegiado == row.Cells["colCedDetalle"].Value.ToString() && documento == row.Cells["colDocumento"].Value.ToString())
				{
					dgvDetalle.Rows.Remove(row);
				}
			}
		}

		private bool validarDatos()
		{
			string error = "";
			bool OK = true;


			if (!chkEmparejarDatos.Checked)
			{
				error = "Debe emparejar los datos antes de procesar.";
				OK = false;
			}

			if (txtNumDocumentoCarga.Text.Trim() == "")
			{
				error = "Debe digitar el Numero del Documento de carga.";
				txtNumDocumentoCarga.Focus();
				OK = false;
			}

			if (dgvCarga.Rows.Count == 0)
			{
				error = "Debe cargar primero el archivo.";
				//txtCobrador.Focus();
				OK = false;
			}

			if (dgvColegiados.Rows.Count == 0)
			{
				error = "No hay informacion para procesar.";
				//txtCobrador.Focus();
				OK = false;
			}

			//if (txtCobrador.Text.Trim() == "")
			//{
			//	error = "Debe digitar el Cobrador.";
			//	txtCobrador.Focus();
			//	OK = false;
			//}

			if (txtCodigo.Text.Trim() == "")
			{
				error = "Debe digitar la plantilla.";
				txtCodigo.Focus();
				OK = false;
			}

			if (!OK)
			{
				MessageBox.Show(error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return OK;
		}

		private void btnCargarArchivo_Click(object sender, EventArgs e)
		{
			if (!txtCodigo.Text.Equals(""))
				cargarArchivo();
			else
				MessageBox.Show("Debe seleccionar primero la plantilla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void chkMasivo_MouseClick(object sender, MouseEventArgs e)
		{
			if (string.IsNullOrEmpty(txtCodigo.Text))
			{
				MessageBox.Show("Debe seleccionar primero la plantilla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				chkMasivo.Checked = false;
			}
			else
			{
				if (chkMasivo.Checked)
				{
					Cursor.Current = Cursors.WaitCursor;
					activarMasivo();
					Cursor.Current = Cursors.Default;
				}
				else
				{
					desactivarMasivo();
				}
			}

		}

		private void dgvColegiados_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool masivo = true;
			if (dgvColegiados.Rows.Count > 0)
			{
				if (dgvColegiados.CurrentCell.OwningColumn.Name == /*"colSelecDetalle"*/"Ver detalle")
				{
					if (e.RowIndex >= 0)
					{
						if ((bool)dgvColegiados.Rows[e.RowIndex].Cells[/*"colSelecDetalle"*/"Ver detalle"].Value == false)
						{
							dgvColegiados.Rows[e.RowIndex].Cells[/*"colSelecDetalle"*/ "Ver detalle"].Value = true;

							//if (esAplicacionConectividad || esAplicacionPar)
							//    cargarDetalle(dgvColegiados.Rows[e.RowIndex].Cells[/*"colCedulaCobrador"*/"Cédula"].Value.ToString(), dgvColegiados.Rows[e.RowIndex].Cells["Documento"].Value.ToString());
							//else
							//    cargarDetalle(dgvColegiados.Rows[e.RowIndex].Cells[/*"colCedulaCobrador"*/"Cédula"].Value.ToString());
							if (ListadoPorFac.Equals("S"))
								cargarDetalle(dgvColegiados.Rows[e.RowIndex].Cells["Cédula"].Value.ToString(), dgvColegiados.Rows[e.RowIndex].Cells["Documento"].Value.ToString());
							else
								cargarDetalle(dgvColegiados.Rows[e.RowIndex].Cells["Cédula"].Value.ToString(), string.Empty);
							actualziarTotalesDetalle();
						}
						else
						{
							dgvColegiados.Rows[e.RowIndex].Cells[/*"colSelecDetalle"*/ "Ver detalle"].Value = false;
							if (esAplicacionConectividad || esAplicacionPar)
								limpiarDetalle(dgvColegiados.Rows[e.RowIndex].Cells["Cédula"].Value.ToString(), dgvColegiados.Rows[e.RowIndex].Cells["Documento"].Value.ToString());
							else
								limpiarDetalle(dgvColegiados.Rows[e.RowIndex].Cells[/*"colCedulaCobrador"*/"Cédula"].Value.ToString());

							actualziarTotalesDetalle();
						}

						foreach (DataGridViewRow row in dgvColegiados.Rows)
						{
							if (!(bool)row.Cells[/*"colSelecDetalle"*/ "Ver detalle"].Value)
							{
								masivo = false;
								break;
							}
						}
						dgvColegiados.EndEdit();

						if (masivo)
							chkMasivo.Checked = true;
						else
							chkMasivo.Checked = false;
					}
				}
			}

		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (tabControl1.SelectedIndex == 1)
			//{
			//    if (chkMasivo.Checked)
			//    {
			//        cargarDetalleMasivo();
			//    }else
			//        if (dgvColegiados.RowCount > 0)
			//        {
			//            foreach (DataGridViewRow row in dgvColegiados.Rows)
			//            {
			//                if ((bool)row.Cells["colSelecDetalle"].Value)
			//                {
			//                    cargarDetalle(row.Cells["colCedulaCobrador"].Value.ToString());
			//                }
			//            }
			//        }
			//}
			//else
			//    dgvDetalle.Rows.Clear();

		}

		private void chkConectividad_MouseClick(object sender, MouseEventArgs e)
		{
			//if (chkConectividad.Checked)
			//{
			//    Cursor.Current = Cursors.WaitCursor;
			//    refrescarDatosConectividad();
			//    txtCobrador.Clear();
			//    txtDescCobrador.Clear();
			//    txtCobrador.ReadOnly = true;
			//    Cursor.Current = Cursors.Default;
			//}
			//else
			//{
			//    txtCobrador.ReadOnly = false;
			//    dgvColegiados.Rows.Clear();
			//    dgvDetalle.Rows.Clear();
			//}
		}

		private void chkEmparejarDatos_MouseClick(object sender, MouseEventArgs e)
		{
			string ident = "";
			string docs = "";
			int cont = 0;
			filtro = "";
			filtroDetalleId = "";
			filtroDetalleDocs = "";
			if (dgvCarga.Rows.Count > 0 && btnProcesar.Enabled)
			{
				#region EMPAREJAR CON DGV
				//if (chkEmparejarDatos.Checked)
				//{

				//    Cursor.Current = Cursors.WaitCursor;
				//    if (!esPlantillaPredef)
				//        obtenerIdentificadorArchivo(ref esCedula);
				//    //if (esCedula)
				//    //{
				//    //    foreach (DataGridViewRow row in dgvCarga.Rows)
				//    //    {
				//    //        if (cont == 0)
				//    //            ident += "'" + row.Cells["CEDULA"].Value.ToString() + "'";
				//    //        else
				//    //            ident += ",'" + row.Cells["CEDULA"].Value.ToString() + "'";

				//    //        if (esAplicacionConectividad || esAplicacionPar)
				//    //        {
				//    //            if (cont == 0)
				//    //                docs += "'" + row.Cells["NUMERO_FACTURA"].Value.ToString() + "'";
				//    //            else
				//    //                docs += ",'" + row.Cells["NUMERO_FACTURA"].Value.ToString() + "'";
				//    //        }

				//    //        cont++;
				//    //    }
				//    //    if (esAplicacionConectividad || esAplicacionPar)
				//    //        source1.Filter = "[Cédula] in (" + ident + ") and [Documento] in (" + docs + ")";
				//    //    else
				//    //        source1.Filter = "[Cédula] in (" + ident + ")";
				//    //}
				//    //else
				//    //{
				//    //    foreach (DataGridViewRow row in dgvCarga.Rows)
				//    //    {
				//    //        if (cont == 0)
				//    //            ident += "'" + row.Cells["CARNET"].Value.ToString() + "'";
				//    //        else
				//    //            ident += ",'" + row.Cells["CARNET"].Value.ToString() + "'";

				//    //        if (esAplicacionConectividad || esAplicacionPar)
				//    //        {
				//    //            if (cont == 0)
				//    //                docs += "'" + row.Cells["NUMERO_FACTURA"].Value.ToString() + "'";
				//    //            else
				//    //                docs += ",'" + row.Cells["NUMERO_FACTURA"].Value.ToString() + "'";
				//    //        }

				//    //        cont++;
				//    //    }
				//    //    if (esAplicacionConectividad || esAplicacionPar)
				//    //        source1.Filter = "[Nº Colegiado] in (" + ident + ") and [Documento] in (" + docs + ")";
				//    //    else
				//    //        source1.Filter = "[Nº Colegiado] in (" + ident + ")";
				//    //}
				//    foreach (DataGridViewRow dgv in dgvCarga.Rows)
				//    {
				//        if (esPlantillaPredef && (esAplicacionConectividad || esAplicacionPar))
				//        {
				//            //if ((dgv.Cells["IDENTIFICACION"].Value.ToString() == row.Cells["Cédula"].Value.ToString() || dgv.Cells["IDENTIFICACION"].Value.ToString() == row.Cells["Nº Colegiado"].Value.ToString()) && dgv.Cells["NUMERO_FACTURA"].Value.ToString() == row.Cells["Documento"].Value.ToString()/*row.Cells["colCedulaCobrador"].Value.ToString()*/)
				//            //{

				//            //    MontoArchivo = decimal.Parse(dgv.Cells["SALDO"].Value.ToString());

				//            //    break;
				//            //}
				//            if (cont == 0 && !dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(""))
				//                ident += "'" + dgv.Cells["IDENTIFICACION"].Value.ToString() + "'";
				//            else if (!dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(""))
				//                ident += ",'" + dgv.Cells["IDENTIFICACION"].Value.ToString() + "'";

				//            //if (cont == 0)//Prueba consulta in sql
				//            //    docs += "('" + dgv.Cells["NUMERO_FACTURA"].Value.ToString() + "')";
				//            //else
				//            //    docs += ",('" + dgv.Cells["NUMERO_FACTURA"].Value.ToString() + "')";

				//            if (cont == 0 && !dgv.Cells["NUMERO_FACTURA"].Value.ToString().Equals(""))
				//                docs += "'" + dgv.Cells["NUMERO_FACTURA"].Value.ToString() + "'";
				//            else if (!dgv.Cells["NUMERO_FACTURA"].Value.ToString().Equals(""))
				//                docs += ",'" + dgv.Cells["NUMERO_FACTURA"].Value.ToString() + "'";

				//            //filtro = "[Documento] in " + docs + " ";//Prueba consulta in sql

				//            filtro = "[Documento] in (" + docs + ") and ([Nº Colegiado] in (" + ident + ") or [Cédula] in (" + ident + "))";
				//            //filtro = "[Documento] in (" + docs + ") ";
				//            filtroDetalleId = "(" + ident + ")";
				//            filtroDetalleDocs = "(" + docs + ")";

				//            cont++;
				//        }
				//        else
				//        {
				//            if (esPlantillaPredef && (!esAplicacionConectividad || !esAplicacionPar))
				//            {
				//                //if (dgv.Cells["IDENTIFICACION"].Value.ToString() == row.Cells["Cédula"].Value.ToString() || dgv.Cells["IDENTIFICACION"].Value.ToString() == row.Cells["Nº Colegiado"].Value.ToString())
				//                //{

				//                //    MontoArchivo = decimal.Parse(dgv.Cells["SALDO"].Value.ToString());

				//                //    break;
				//                //}

				//                if (cont == 0 && !dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(""))
				//                    ident += "'" + dgv.Cells["IDENTIFICACION"].Value.ToString() + "'";
				//                else if (!dgv.Cells["IDENTIFICACION"].Value.ToString().Equals(""))
				//                    ident += ",'" + dgv.Cells["IDENTIFICACION"].Value.ToString() + "'";

				//                filtro = "[Nº Colegiado] in (" + ident + ") or [Cédula] in (" + ident + ")";
				//                filtroDetalleId = "(" + ident + ")";

				//                cont++;
				//            }
				//            else
				//            {
				//                if (esCedula)
				//                {
				//                    foreach (DataGridViewRow row in dgvCarga.Rows)
				//                    {
				//                        if (cont == 0 && !row.Cells["CEDULA"].Value.ToString().Equals(""))
				//                            ident += "'" + row.Cells["CEDULA"].Value.ToString() + "'";
				//                        else if (!row.Cells["CEDULA"].Value.ToString().Equals(""))
				//                            ident += ",'" + row.Cells["CEDULA"].Value.ToString() + "'";

				//                        cont++;
				//                    }

				//                    filtro = "[Cédula] in (" + ident + ")";
				//                    filtroDetalleId = " (" + ident + ")";
				//                }
				//                else
				//                {
				//                    foreach (DataGridViewRow row in dgvCarga.Rows)
				//                    {
				//                        if (cont == 0 && !row.Cells["CARNET"].Value.ToString().Equals(""))
				//                            ident += "'" + row.Cells["CARNET"].Value.ToString() + "'";
				//                        else if (!row.Cells["CARNET"].Value.ToString().Equals(""))
				//                            ident += ",'" + row.Cells["CARNET"].Value.ToString() + "'";

				//                        cont++;
				//                    }

				//                    filtro = "[Nº Colegiado] in (" + ident + ")";
				//                    filtroDetalleId = " (" + ident + ")";
				//                }
				//            }
				//        }
				//    }
				//    source1.Filter = filtro;
				//    actualziarTotalesResumen();
				//    Cursor.Current = Cursors.Default;
				//}
				//else
				//{
				//    source1.Filter = "";
				//    actualziarTotalesResumen();
				//    chkMasivo.Checked = false;
				//    desactivarMasivo();
				//}
				#endregion
				//if (chkEmparejarDatos.Checked)
				//{
				//    Cursor.Current = Cursors.WaitCursor;
				//    if (esAplicacionBac)
				//    {
				//        refrescarDatosBac(true,false);
				//    }else
				//    if (esAplicacionConectividad)
				//    {
				//        refrescarDatosConectividad(true, false);
				//    }else
				//    if (esAplicacionPar)
				//    {
				//        refrescarDatosPar(true, false);
				//    }
				//    else
				//    {
				//        refrescarDatos(true, false);
				//    }
				//    Cursor.Current = Cursors.Default;
				//}
				//else
				//{
				//    Cursor.Current = Cursors.WaitCursor;
				//    if (esAplicacionBac)
				//    {
				//        refrescarDatosBac(false, false);
				//    }
				//    else
				//    if (esAplicacionConectividad)
				//    {
				//        refrescarDatosConectividad(false, false);
				//    }
				//    else
				//    if (esAplicacionPar)
				//    {
				//        refrescarDatosPar(false, false);
				//    }
				//    else
				//    {
				//        refrescarDatos(false, false);
				//    }
				//    Cursor.Current = Cursors.Default;
				//}
				if (chkEmparejarDatos.Checked)
				{
					Cursor.Current = Cursors.WaitCursor;

					refrescarDatos(true, false);
					//refrescarDatos();

					Cursor.Current = Cursors.Default;
				}
				else
				{
					Cursor.Current = Cursors.WaitCursor;

					refrescarDatos(true, false);
					//refrescarDatos();

					Cursor.Current = Cursors.Default;
				}
			}
			else
			{
				if (chkEmparejarDatos.Checked)
					chkEmparejarDatos.Checked = false;
				MessageBox.Show("Debe cargar el archivo anteriormente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void actualziarTotalesDetalle()
		{
			decimal saldos = 0;
			//int reg = 0;
			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				//  reg += 1;
				saldos = saldos + decimal.Parse(row.Cells["colSaldoDetalle"].Value.ToString());
			}
			lblCantTotalesSaldosDet.Text = saldos.ToString("N2");
			//lblCantRegistrosDet.Text = reg.ToString();
			lblCantRegistrosDet.Text = dgvDetalle.Rows.Count.ToString();
		}

		private void actualziarTotalesResumen()
		{
			decimal saldos = 0;
			//int reg = 0;
			foreach (DataGridViewRow row in dgvColegiados.Rows)
			{
				//  reg += 1;
				saldos = saldos + decimal.Parse(row.Cells["Monto Adeudado"].Value.ToString());
			}
			lblCantTotal.Text = saldos.ToString("N2");
			//lblCantRegistrosDet.Text = reg.ToString();
			lblRegistrosCant.Text = dgvColegiados.Rows.Count.ToString();
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			if (dgvColegiados.RowCount == 0)
			{
				MessageBox.Show("No existen datos en el Resumen para exportar a excel.", "Exportación a excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			if (dgvCarga.RowCount == 0)
			{
				MessageBox.Show("No existen datos en el la Carga para exportar a excel.", "Exportación a excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			exportarDatos(false);
			Cursor.Current = Cursors.Default;
		}

		private void exportarDatos(bool guardar)
		{
			try
			{
				#region O
				//ExcelInterop.Application Excel = new ExcelInterop.Application();
				//Excel.Workbooks.Add();
				//// single worksheet
				//ExcelInterop._Worksheet Worksheet = Excel.ActiveSheet;

				////List<string> colFechas = new List<string>();

				////colFechas.Add("F. Pago");
				////colFechas.Add("Desde");
				////colFechas.Add("Hasta");

				////int columnaEstado = dgvColegiados.Columns.Count+1;
				//int columnas = dgvColegiados.Columns.Count;
				//int rows = dgvColegiados.RowCount;
				//object[] Header = new object[columnas-5];

				//int colHeader = 0;
				//// column headings               
				//for (int i = 0; i < columnas; i++)
				//{
				//    //if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga" && dgvPolizas.Columns[i].HeaderText != "F17")
				//    //if (i == columnas)
				//    //    Header[i] = "Estado";
				//    //else
				//    if (dgvColegiados.Columns[i].HeaderText != "Ver detalle" 
				//        && dgvColegiados.Columns[i].HeaderText != "Cobrador"
				//        && dgvColegiados.Columns[i].HeaderText != "Monto Pagado"
				//        && dgvColegiados.Columns[i].HeaderText != "Estado"
				//        && dgvColegiados.Columns[i].HeaderText != "Observaciones")
				//    {
				//        Header[colHeader] = dgvColegiados.Columns[i].HeaderText;
				//        colHeader++;
				//    }
				//}



				//ExcelInterop.Range HeaderRange = Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[1, 1]), (ExcelInterop.Range)(Worksheet.Cells[1, columnas-5]));
				//HeaderRange.Value = Header;
				//HeaderRange.Font.Bold = true;
				//HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

				//// DataCells

				//object[,] Cells = new object[rows, columnas-5];
				////bool fecha = false;
				//for (int j = 0; j < rows; j++)
				//{
				//    int col = 0;
				//    for (int i = 0; i < columnas; i++)
				//    {
				//        //fecha = false;
				//        //for (int k = 0; k < colFechas.Count; k++)
				//        //{
				//        //    if (dgvPolizas.Columns[i].HeaderText == colFechas[k])
				//        //    {
				//        //        if (dgvPolizas[i, j].Value.ToString() != "")
				//        //            Cells[j, i] = DateTime.Parse(dgvPolizas[i, j].Value.ToString()).ToString("yyyy-MM-dd");
				//        //        else
				//        //            Cells[j, i] = "";
				//        //        fecha = true;
				//        //        break;
				//        //    }
				//        //}
				//        //if (!fecha && (dgvPolizas.Columns[i].HeaderText != "Detalle Carga" && dgvPolizas.Columns[i].HeaderText != "F17"))
				//        if (dgvColegiados.Columns[i].HeaderText != "Ver detalle"
				//        && dgvColegiados.Columns[i].HeaderText != "Cobrador"
				//        && dgvColegiados.Columns[i].HeaderText != "Monto Pagado"
				//        && dgvColegiados.Columns[i].HeaderText != "Estado"
				//        && dgvColegiados.Columns[i].HeaderText != "Observaciones")
				//        {
				//            if (dgvColegiados[i, j].Value != null)
				//                Cells[j, col] = dgvColegiados[i, j].Value.ToString();
				//            else
				//                Cells[j, col] = "";
				//            col++;
				//        }

				//    }
				//    //string cel = dgvColegiados[columnas - 2, j].Value.ToString();
				//    //if (depurarCelular(ref cel))
				//    //    Cells[j, columnas] = "Correcto";
				//    //else
				//    //    Cells[j, columnas] = "Incorrecto";
				//}

				//Worksheet.Name = "Resumen_Proceso_Masivo";
				//Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[rows + 1, columnas-5])).Value = Cells;
				//Worksheet.Columns.AutoFit();
				//Excel.Visible = true;
				//// DateTime tiempo2 = DateTime.Now;
				//// TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
				//// MessageBox.Show("Duracion: " + total.ToString());
				#endregion

				ExcelInterop.Application Excel = new ExcelInterop.Application();
				ExcelInterop.Workbook oBook = Excel.Workbooks.Add();
				// single worksheet
				ExcelInterop._Worksheet Worksheet = Excel.ActiveSheet;


				int columnasResumen = dgvColegiados.Columns.Count;
				int columnasCarga = dgvCarga.Columns.Count;
				int rowsResumen = dgvColegiados.RowCount;
				int rowsCarga = dgvCarga.RowCount;
				int columnas = 8;
				object[] Header = new object[columnas];

				if (rowsResumen > rowsCarga)
				{
					Header[0] = "Cédula";
					Header[1] = "Nº Colegiado";
					Header[2] = "Nombre";
					Header[3] = "Documento";
					Header[4] = "Monto Adeudado";
					Header[5] = "Identificador Carga";
					Header[6] = "Documento Carga";
					Header[7] = "Monto Carga";
				}
				else
				{

					Header[0] = "Identificador Carga";
					Header[1] = "Documento Carga";
					Header[2] = "Monto Carga";
					Header[3] = "Cédula";
					Header[4] = "Nº Colegiado";
					Header[5] = "Nombre";
					Header[6] = "Documento";
					Header[7] = "Monto Adeudado";
				}
				//Header[7] = "Observaciones";

				ExcelInterop.Range HeaderRange = Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[1, 1]), (ExcelInterop.Range)(Worksheet.Cells[1, columnas]));
				HeaderRange.Value = Header;
				HeaderRange.Font.Bold = true;
				HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

				// DataCells
				int rows = rowsResumen > rowsCarga ? rowsResumen : rowsCarga;
				int columns = columnasResumen + columnasCarga;
				object[,] Cells = new object[rows, columnas];


				for (int j = 0; j < rows; j++)
				{
					if (rowsResumen > rowsCarga)
					{

						string identificadorCarga = "", documentoCarga = "", saldoCarga = "";
						//Agregamos celdas del resumen
						for (int i = 0; i < columnasResumen; i++)
						{
							if (dgvColegiados.Columns[i].HeaderText.Equals("Cédula"))
							{
								if (dgvColegiados[i, j].Value != null)
									Cells[j, 0] = dgvColegiados[i, j].Value.ToString();
								else
									Cells[j, 0] = "";
							}

							if (dgvColegiados.Columns[i].HeaderText.Equals("Nº Colegiado"))
							{
								if (dgvColegiados[i, j].Value != null)
									Cells[j, 1] = dgvColegiados[i, j].Value.ToString();
								else
									Cells[j, 1] = "";
							}

							if (dgvColegiados.Columns[i].HeaderText.Equals("Nombre"))
							{
								if (dgvColegiados[i, j].Value != null)
									Cells[j, 2] = dgvColegiados[i, j].Value.ToString();
								else
									Cells[j, 2] = "";
							}

							if (dgvColegiados.Columns[i].HeaderText.Equals("Documento"))
							{
								if (dgvColegiados[i, j].Value != null)
									Cells[j, 3] = dgvColegiados[i, j].Value.ToString();
								else
									Cells[j, 3] = "";
							}

							if (dgvColegiados.Columns[i].HeaderText.Equals("Monto Adeudado"))
							{
								if (dgvColegiados[i, j].Value != null)
									Cells[j, 4] = dgvColegiados[i, j].Value.ToString();
								else
									Cells[j, 4] = "";
							}
						}
						//Agragamos celdas de la carga
						buscarCarga(Cells[j, 0].ToString(), Cells[j, 1].ToString(), Cells[j, 3].ToString(), ref identificadorCarga, ref documentoCarga, ref saldoCarga);

						Cells[j, 5] = identificadorCarga;
						Cells[j, 6] = documentoCarga;
						Cells[j, 7] = saldoCarga;

					}
					else
					{
						string cedula = "", numCole = "", nombre = "", documentos = "", saldo = "";
						bool noDoc = true;
						//Agregamos celdas de la carga
						for (int i = 0; i < columnasCarga; i++)
						{

							if (dgvCarga.Columns[i].Name.Equals("IDENTIFICACION"))
							{
								if (dgvCarga[i, j].Value != null)
									Cells[j, 0] = dgvCarga[i, j].Value.ToString();
								else
									Cells[j, 0] = "";
							}

							if (dgvCarga.Columns[i].Name.Equals("NUMERO_FACTURA"))
							{
								noDoc = false;
								if (dgvCarga[i, j].Value != null)
									Cells[j, 1] = dgvCarga[i, j].Value.ToString();
								else
									Cells[j, 1] = "";
							}

							if (dgvCarga.Columns[i].Name.Equals("SALDO"))
							{
								if (dgvCarga[i, j].Value != null)
									Cells[j, 2] = dgvCarga[i, j].Value.ToString();
								else
									Cells[j, 2] = "";
							}

						}

						if (noDoc)
							Cells[j, 1] = "";
						//Agragamos celdas del resumen
						buscarResumen(Cells[j, 0].ToString(), Cells[j, 1].ToString(), ref cedula, ref nombre, ref numCole, ref documentos, ref saldo);

						Cells[j, 3] = cedula;
						Cells[j, 4] = numCole;
						Cells[j, 5] = nombre;
						Cells[j, 6] = documentos;
						Cells[j, 7] = saldo;
					}
				}

				if (guardar)
				{
					string ruta = AppDomain.CurrentDomain.BaseDirectory + "BITACORA_PROCESOS";
					if (!Directory.Exists(ruta))
					{
						Directory.CreateDirectory(ruta);
					}
					string nombreArch = ruta + "\\" + txtDescCobrador.Text + "_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".xlsx";
					Worksheet.Name = "Bitacora_Proceso_Masivo";
					Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[rows + 1, columnas])).Value = Cells;
					Worksheet.Columns.AutoFit();
					oBook.SaveAs(nombreArch);
					oBook.Close();
					Excel.Quit();
				}
				else
				{
					Worksheet.Name = "Resumen_Proceso_Masivo";
					Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[rows + 1, columnas])).Value = Cells;
					Worksheet.Columns.AutoFit();
					Excel.Visible = true;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un error en la exportación de datos a excel: " + ex.Message, "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buscarCarga(string cedula, string numero, string documento, ref string identificadorCarga, ref string documentoCarga, ref string saldoCarga)
		{
			foreach (DataGridViewRow row in dgvCarga.Rows)
			{
				if (documento.Equals(""))
				{
					if (row.Cells["IDENTIFICACION"].Value.ToString() == cedula || row.Cells["IDENTIFICACION"].Value.ToString() == numero)
					{
						identificadorCarga = row.Cells["IDENTIFICACION"].Value.ToString();
						saldoCarga = row.Cells["SALDO"].Value.ToString();
						break;
					}
				}
				else
				{
					if ((row.Cells["IDENTIFICACION"].Value.ToString() == cedula || row.Cells["IDENTIFICACION"].Value.ToString() == numero) && row.Cells["NUMERO_FACTURA"].Value.ToString() == fInternas.quitarCerosMontoInicio(documento))
					{
						identificadorCarga = row.Cells["IDENTIFICACION"].Value.ToString();
						documentoCarga = row.Cells["NUMERO_FACTURA"].Value.ToString();
						saldoCarga = row.Cells["SALDO"].Value.ToString();
						break;
					}
				}

			}
		}

		private void buscarResumen(string identificador, string documento, ref string cedula, ref string nombre, ref string numCole, ref string documentos, ref string saldo)
		{
			foreach (DataGridViewRow row in dgvColegiados.Rows)
			{
				if (row.Cells["Documento"].Value.ToString().Equals(""))
				{
					if (row.Cells["Cédula"].Value.ToString() == identificador || row.Cells["Nº Colegiado"].Value.ToString() == identificador)
					{
						cedula = row.Cells["Cédula"].Value.ToString();
						numCole = row.Cells["Nº Colegiado"].Value.ToString();
						nombre = row.Cells["Nombre"].Value.ToString();
						saldo = row.Cells["Monto Adeudado"].Value.ToString();
						break;
					}
				}
				else
				{
					if ((row.Cells["Cédula"].Value.ToString() == identificador || row.Cells["Nº Colegiado"].Value.ToString() == identificador) && fInternas.quitarCerosMontoInicio(row.Cells["Documento"].Value.ToString()) == fInternas.quitarCerosMontoInicio(documento))
					{
						cedula = row.Cells["Cédula"].Value.ToString();
						numCole = row.Cells["Nº Colegiado"].Value.ToString();
						nombre = row.Cells["Nombre"].Value.ToString();

						documento = row.Cells["Documento"].Value.ToString();
						saldo = row.Cells["Monto Adeudado"].Value.ToString();
						break;
					}
				}

			}
		}
	}
}
