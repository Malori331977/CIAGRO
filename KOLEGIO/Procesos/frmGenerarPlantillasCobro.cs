using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excell = Microsoft.Office.Interop.Excel;

namespace KOLEGIO
{
	public partial class frmGenerarPlantillasCobro : Form
	{
		private string oldValue = "";
		private FuncsInternas fInternas;

		public frmGenerarPlantillasCobro()
		{
			InitializeComponent();
			this.fInternas = new FuncsInternas();
		}

		private void btnProcesar_Click(object sender, EventArgs e)
		{
			if (txtCodigo.Text == "")
			{
				MessageBox.Show("Primero debe seleccionar la plantilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DataTable dtInfo = new DataTable();
			string sQuery = "SELECT Nombre,Tipo,Conectividad,Par,Bac,CerosEnMonto,SumarArreglo,ArregloPorDocumento,RubroColegiatura,RubroRegencia,Proyeccion,ListadoPorFac,GenerarPor,SeparadorCsv,FormatoInicioLinea,RubroPerito,RubroAerea,RubroPlaguicida,TotalRegistro,TotalMonto,CeroInicialCedula,ConEncabezado from " + Consultas.sqlCon.COMPAÑIA + ".NV_PLANTILLA_COBRADOR WHERE Codigo='" + txtCodigo.Text + "'";
			string error = "", extension = "", nombreArchivo = "", indicadorConectividad = "", indicadorPar = "", indicadorBac = "", cerosEnMonto = "", SumarArreglo = "", ArregloPorDocumento = "", RubroColegiatura = "", RubroRegencia = "", proyeccion = "", GenerarPor = "", ListadoPorFac = "", SeparadorCsv = "", FormatoInicioLinea = "", RubroPerito = "", RubroAerea = "", RubroPlaguicida = "", TotalRegistro = "", TotalMonto = "", CeroCedula = "", ConEncabezado = "";
			bool OK = true;


			string select = "SELECT ", selectParc = "SELECT ", selectUnion = "SELECT ", selectUnionParcialidad = "SELECT ", groupBy = "GROUP BY ", groupByParcialidad = "GROUP BY ", query = "";
			string selectPersistencia = "SELECT ", selectUnionPersistencia = "SELECT ", selectUnionParcialidadPersistencia = "SELECT ", groupByPersistencia = "GROUP BY ", groupByParcialidadPersistencia = "GROUP BY ", queryPersistencia = "", queryParcPersistencia = "";
			int cantFormatos = 0;
			bool esVencimientofactura = false, esFechafactura = false, esNumfactura = false;
			DataTable dtDatos = new DataTable();
			DataTable dtDatosPersistencia = new DataTable();
			DataTable dtDatosParcPersistencia = new DataTable();

			try
			{
				//Consultas.sqlCon.iniciaTransaccion();

				OK = Consultas.fillDataTable(sQuery, ref dtInfo, ref error);

				if (OK)
				{
					if (dtInfo.Rows.Count > 0)
					{
						extension = dtInfo.Rows[0]["Tipo"].ToString() == "TXT" ? ".txt" : dtInfo.Rows[0]["Tipo"].ToString() == "XLS" ? ".xlsx" : ".csv";
						
						string fecha = string.Format("{0:MMMM yyyy}", DateTime.Now);
						nombreArchivo = dtInfo.Rows[0]["Nombre"].ToString() + " " + fecha + extension;
						cerosEnMonto = dtInfo.Rows[0]["CerosEnMonto"].ToString();
						SumarArreglo = dtInfo.Rows[0]["SumarArreglo"].ToString();
						ArregloPorDocumento = dtInfo.Rows[0]["ArregloPorDocumento"].ToString();
						RubroColegiatura = dtInfo.Rows[0]["RubroColegiatura"].ToString();
						RubroRegencia = dtInfo.Rows[0]["RubroRegencia"].ToString();
						proyeccion = dtInfo.Rows[0]["Proyeccion"].ToString();
						ListadoPorFac = dtInfo.Rows[0]["ListadoPorFac"].ToString();
						GenerarPor = dtInfo.Rows[0]["GenerarPor"].ToString();
						SeparadorCsv = dtInfo.Rows[0]["SeparadorCsv"].ToString();
						FormatoInicioLinea = dtInfo.Rows[0]["FormatoInicioLinea"].ToString();
						RubroPerito = dtInfo.Rows[0]["RubroPerito"].ToString();
						RubroAerea = dtInfo.Rows[0]["RubroAerea"].ToString();
						RubroPlaguicida = dtInfo.Rows[0]["RubroPlaguicida"].ToString();
						TotalRegistro = dtInfo.Rows[0]["TotalRegistro"].ToString();
						TotalMonto = dtInfo.Rows[0]["TotalMonto"].ToString();
						CeroCedula = dtInfo.Rows[0]["CeroInicialCedula"].ToString();
						ConEncabezado = dtInfo.Rows[0]["ConEncabezado"].ToString();

						DataTable dtFormatos = new DataTable();
						sQuery = "SELECT Columna,Orden,Caracteres,TamColumna,Detalle,Macro,Formato FROM " + Consultas.sqlCon.COMPAÑIA +
							".NV_PLANTILLA_COBRADOR_DETALLE WHERE Codigo='" + txtCodigo.Text + "' order by Columna,Orden";
						
						OK = Consultas.fillDataTable(sQuery, ref dtFormatos, ref error);

						if (OK)
						{
							if (dtFormatos.Rows.Count > 0)
							{
								StringBuilder texto = new StringBuilder();
								SaveFileDialog savefile = new SaveFileDialog();
								// set a default file name
								savefile.FileName = nombreArchivo;
								// set filters - this can be done in properties as well

								savefile.Filter = extension == ".txt" ? "Text files (*.txt)|*.txt" : extension == ".xlsx" ? "Excel files (*.xlsx)|*.xlsx" : "Csv files (*.csv)|*.csv";

								if (savefile.ShowDialog() == DialogResult.OK)
								{
									Cursor.Current = Cursors.WaitCursor;

									#region CREAR_SELECT_NUEVO

									crearSelect(ref select, ref selectUnion, ref selectUnionParcialidad, ref groupBy, ref groupByParcialidad, ref dtFormatos, ref cantFormatos, ref esNumfactura, ref esFechafactura, ref esVencimientofactura, ListadoPorFac);

									crearQuery(ref query, ref queryParcPersistencia, select, selectParc, selectUnion, selectUnionParcialidad, groupBy, groupByParcialidad, ListadoPorFac, GenerarPor, SumarArreglo, ArregloPorDocumento, RubroColegiatura, RubroRegencia, RubroPerito, RubroAerea, RubroPlaguicida);

									crearSelectPersistencia(ref selectPersistencia, ref selectParc, ref selectUnionPersistencia, ref selectUnionParcialidadPersistencia, ref groupByPersistencia, ref groupByParcialidadPersistencia, "S");
									//crearSelectPersistencia(ref selectPersistencia, ref selectUnionPersistencia, ref selectUnionParcialidadPersistencia, ref groupByPersistencia, ref groupByParcialidadPersistencia, ListadoPorFac);

									crearQueryPersistencia(ref queryPersistencia, ref queryParcPersistencia, selectPersistencia, selectParc, groupByPersistencia, groupByParcialidadPersistencia, GenerarPor, ArregloPorDocumento, RubroColegiatura, RubroRegencia, RubroPerito, RubroAerea, RubroPlaguicida);
									//crearQuery(ref queryPersistencia, selectPersistencia, selectUnionPersistencia, selectUnionParcialidadPersistencia, groupByPersistencia, groupByParcialidadPersistencia, ListadoPorFac, GenerarPor, SumarArreglo, ArregloPorDocumento, RubroColegiatura, RubroRegencia);

									#endregion

									OK = Consultas.fillDataTable(query, ref dtDatos, ref error);

									if (OK)
										OK = Consultas.fillDataTable(queryPersistencia, ref dtDatosPersistencia, ref error);

									if (OK && !string.IsNullOrEmpty(queryParcPersistencia))
										OK = Consultas.fillDataTable(queryParcPersistencia, ref dtDatosParcPersistencia, ref error);

									if (OK)
									{
										if (dtDatos.Rows.Count > 0)
										{
											OK = insertarAplicaciones(dtDatosPersistencia, dtDatosParcPersistencia, txtCobrador.Text, true, ref error);
											//OK = insertarAplicaciones(dtDatosPersistencia, txtCobrador.Text, esNumfactura, ref error);

											if (OK) 
											{
												//if (extension == ".xls" || extension == ".xlsx")
												//{
												//Excell.Application oApp = new Excell.Application();
												//Excell.Worksheet oSheet = new Excell.Worksheet();
												//Excell.Workbook oBook = oApp.Workbooks.Add();
												//}
												Excell.Application Excel = new Excell.Application();
												Excell.Workbook oBook = Excel.Workbooks.Add();
												Excell._Worksheet Worksheet = Excel.ActiveSheet;
												int indexHeader = 0;
												object[] Header = new object[dtFormatos.Rows.Count];
												object[,] Cells = new object[dtDatos.Rows.Count, dtFormatos.Rows.Count];

												if (extension == ".xls" || extension == ".xlsx")
												{
													foreach (DataRow row in dtFormatos.Rows)
													{
														if (indexHeader <= cantFormatos)
														{
															Header[indexHeader] = row["Detalle"].ToString();

															indexHeader += 1;
														}
													}
												}

												Excell.Range HeaderRange = Worksheet.get_Range((Excell.Range)(Worksheet.Cells[1, 1]), (Excell.Range)(Worksheet.Cells[1, dtFormatos.Rows.Count]));
												HeaderRange.Value = Header;
												HeaderRange.Font.Bold = true;

												if (!File.Exists(savefile.FileName))
													File.Delete(savefile.FileName);

												decimal montoTotal = 0;
												//int rowIndex = 0;
												int rowIndex = 1;
												int rowIndexExcel = 0;
												bool montoMayorACaracteres = false;


												if (ConEncabezado.Equals("S") && extension == ".txt" || extension == ".csv")
												{
													string fila = "";

													foreach (DataRow row in dtFormatos.Rows)
													{
														if (row["Orden"].ToString() == "1")
														{
															fila += row["Detalle"].ToString();
														}
														else
															fila += (extension == ".csv" ? SeparadorCsv : "") + row["Detalle"].ToString();
													}

													File.AppendAllText(savefile.FileName, fila + Environment.NewLine, Encoding.Default);
												}

												foreach (DataRow rowDatos in dtDatos.Rows)
												{
													rowIndex += 1;

													if (extension == ".txt")
													{
														#region TXT
														string fila = "";
														int i = 0;
														foreach (DataRow row in dtFormatos.Rows)
														{
															if (i <= cantFormatos)
															{
																if (i == 1)
																	fila += FormatoInicioLinea;

																string formato = dtFormatos.Rows[i]["Formato"].ToString();

																if (dtFormatos.Rows[i]["Macro"].ToString() == "CARNET")
																{
																	if (rowDatos["NumeroColegiado"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																	{
																		fila += rowDatos["NumeroColegiado"].ToString();
																		int espacios = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - rowDatos["NumeroColegiado"].ToString().Length;

																		for (int j = 0; j < espacios; j++)
																			fila += "0";
																	}
																	else
																		fila += rowDatos["NumeroColegiado"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		//int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - rowDatos["NumeroColegiado"].ToString().Length;

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}

																}

																//if (dtFormatos.Rows[i]["Macro"].ToString() == "CARNET")
																//    oSheet.Cells[rowIndex, int.Parse(row["Orden"].ToString())] = rowDatos["NumeroColegiado"].ToString();


																if (dtFormatos.Rows[i]["Macro"].ToString() == "CEDULA")
																{
																	if (CeroCedula.Equals("S"))
																		fila += "0";

																	if (rowDatos["Cedula"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																	{
																		fila += rowDatos["Cedula"].ToString().Trim();

																		int espacios = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - rowDatos["Cedula"].ToString().Length;

																		for (int j = 0; j < espacios; j++)
																			fila += "0";
																	}
																	else
																		fila += rowDatos["Cedula"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																	
																	//fila += rowDatos["Cedula"].ToString().Trim();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		//int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - rowDatos["Cedula"].ToString().Length;

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "NOMBRE")
																{
																	if (rowDatos["Nombre"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																	{
																		fila += rowDatos["Nombre"].ToString();
																		int espacios = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - rowDatos["Nombre"].ToString().Length;

																		for (int j = 0; j < espacios; j++)
																			fila += " ";
																	}
																	else
																		fila += rowDatos["Nombre"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "APLICACION")
																{
																	if (rowDatos["Aplicacion"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																	{
																		fila += rowDatos["Aplicacion"].ToString();
																		int espacios = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - rowDatos["Aplicacion"].ToString().Length;

																		for (int j = 0; j < espacios; j++)
																			fila += " ";
																	}
																	else
																		fila += rowDatos["Aplicacion"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "CORREO")
																{
																	if (rowDatos["Email"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																	{
																		fila += rowDatos["Email"].ToString();
																		int espacios = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - rowDatos["Email"].ToString().Length;

																		for (int j = 0; j < espacios; j++)
																			fila += " ";
																	}
																	else
																		fila += rowDatos["Email"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "MONTO")
																{
																	int decimales = 0;
																	string monto = "";
																	int tamaño = 0;
																	//int ceros = 0;
																	int espaciosPorTamañoSaldo = 0;
																	if (dtFormatos.Rows[i]["Formato"].ToString().Contains("."))
																	{

																		//monto = obtenerMontoArreglo(rowDatos["Email"].ToString());

																		decimales = dtFormatos.Rows[i]["Formato"].ToString().Split('.')[1].Length;

																		monto += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0] + ".";

																		for (int j = 0; j < decimales; j++)
																		{
																			monto += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[1][j];
																		}

																		//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																		//    monto = decimal.Parse(monto) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";

																		//tamaño = monto.ToString().Length - 1;
																		tamaño = monto.ToString().Length - 1;
																		if (tamaño <= int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																			espaciosPorTamañoSaldo = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - tamaño;
																		else
																		{
																			if (!dtDatos.Columns.Contains("Nombre"))
																				MessageBox.Show("Error de formato del monto, tiene más caracteres de los configurados en la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
																			else
																				MessageBox.Show("Error de formato, el monto del colegiado " + rowDatos["Nombre"].ToString() + " tiene más caracteres de los configurados en la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
																			return;
																		}

																		//for (int j = 0; j < ceros; j++)
																		//    fila += "0";
																		if (cerosEnMonto.Equals("S"))
																		{
																			for (int j = 0; j < espaciosPorTamañoSaldo; j++)
																				fila += "0";
																		}
																	}
																	else
																	{
																		monto = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0];
																		tamaño = monto.ToString().Length;
																		//if (tamaño <= int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																		//    ceros = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - tamaño;
																		//else
																		//    montoMayorACaracteres = true;

																		//for (int j = 0; j < ceros; j++)
																		//fila += "0";

																		if (rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Contains("."))
																		{
																			if (montoMayorACaracteres)
																				monto = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0].Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																			else
																				monto = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0];
																		}
																		else
																		{
																			if (montoMayorACaracteres)
																				monto = decimal.Parse(rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))) + "";
																			else
																				monto = decimal.Parse(rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString()) + "";
																		}

																		//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																		//    monto = decimal.Parse(monto) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";

																	}

																	fila += monto;

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		//int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																		//int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - tamaño;
																		int espaciosColumna = (int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString())) + espaciosPorTamañoSaldo;
																		espaciosColumna += espaciosPorTamañoSaldo;

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "SALDO")
																{
																	int decimales = 0;
																	string saldo = "";
																	int tamaño = 0;
																	//int ceros = 0;
																	int espaciosPorTamañoSaldo = 0;
																	if (dtFormatos.Rows[i]["Formato"].ToString().Contains("."))
																	{
																		decimales = dtFormatos.Rows[i]["Formato"].ToString().Split('.')[1].Length;

																		saldo = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0] + ".";

																		for (int j = 0; j < decimales; j++)
																		{
																			saldo += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[1][j];
																		}

																		//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																		//    saldo = decimal.Parse(saldo) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";

																		//tamaño = saldo.ToString().Length - 1;
																		tamaño = saldo.ToString().Length;
																		if (tamaño <= int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																			espaciosPorTamañoSaldo = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - tamaño;
																		else
																		{
																			if (!dtDatos.Columns.Contains("Nombre"))
																				MessageBox.Show("Error de formato del monto, tiene más caracteres de los configurados en la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
																			else
																				MessageBox.Show("Error de formato, el monto del colegiado " + rowDatos["Nombre"].ToString() + " tiene más caracteres de los configurados en la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
																			return;
																		}

																		if (cerosEnMonto.Equals("S"))
																		{
																			for (int j = 0; j < espaciosPorTamañoSaldo; j++)
																				fila += "0";
																		}
																	}
																	else
																	{
																		saldo = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0];
																		tamaño = saldo.ToString().Length;

																		//if (tamaño <= int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																		//    //ceros = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - tamaño;
																		//else
																		//    montoMayorACaracteres = true;

																		//for (int j = 0; j < ceros; j++)
																		//    fila += "0";

																		if (rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Contains("."))
																		{
																			if (montoMayorACaracteres)
																				saldo = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0].Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																			else
																				saldo = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0];
																		}
																		else
																		{
																			if (montoMayorACaracteres)
																				saldo = decimal.Parse(rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))) + "";
																			else
																				saldo = decimal.Parse(rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString()) + "";
																		}

																		if (tamaño <= int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																			espaciosPorTamañoSaldo = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - tamaño;

																		if (cerosEnMonto.Equals("S"))
																		{
																			for (int j = 0; j < espaciosPorTamañoSaldo; j++)
																				fila += "0";
																		}
																		//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																		//    saldo = decimal.Parse(saldo) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";
																	}

																	fila += saldo;
																	montoTotal += decimal.Parse(saldo);

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		//int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																		int espaciosColumna = (int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString())) + espaciosPorTamañoSaldo;
																		//espaciosColumna -= espaciosPorTamañoSaldo; 
																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "DECIMALES")
																{
																	fila += dtFormatos.Rows[i]["Formato"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																//if (dtFormatos.Rows[i]["Macro"].ToString() == "DECIMALES")
																//{
																//    int total = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																//    string monto = "";
																//    monto = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																//    if (monto.Contains("."))
																//    {
																//        if (monto.Split('.')[1].Length >= total)
																//            fila += monto.Split('.')[1].Substring(0, total);
																//        else
																//            fila += monto.Split('.')[1];

																//        int falta = total - monto.Split('.')[1].Length;

																//        for (int j = 0; j < falta; j++)
																//            fila += "0";

																//    }
																//    else
																//    {
																//        fila += ".";
																//        for (int j = 0; j < total; j++)
																//            fila += "0";

																//    }

																//    if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																//    {
																//        int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																//        for (int j = 0; j < espaciosColumna; j++)
																//            fila += " ";
																//    }
																//}


																if (dtFormatos.Rows[i]["Macro"].ToString() == "AÑO")
																{
																	int total = rowDatos["AÑO"].ToString().Length;
																	int totalCaracteres = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																	if (totalCaracteres > 4)
																	{
																		MessageBox.Show("Error de formato,el año en la fila del colegiado " + rowDatos["Nombre"].ToString() + " tiene más caracteres que del formato de un año.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
																		return;
																	}

																	if (total == 4 && totalCaracteres == 2)
																		fila += rowDatos["AÑO"].ToString().Remove(0, 2);
																	else
																		if (total == 4 && totalCaracteres == 4)
																		fila += rowDatos["AÑO"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}


																if (dtFormatos.Rows[i]["Macro"].ToString() == "MES")
																{
																	fila += rowDatos["MES"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "CONSTANTE")
																{
																	fila += dtFormatos.Rows[i]["Formato"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "TARJETA")
																{
																	fila += rowDatos["NumeroTarjeta"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "CONSECUTIVO")
																{
																	fila += rowDatos["contador"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "VENCIMIENTO_TARJETA")
																{
																	fila += rowDatos["venc_tarjeta"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "NUMERO_FACTURA")
																{
																	//fila += rowDatos["numFactura"].ToString();

																	//if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	//{
																	//    int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																	//    for (int j = 0; j < espaciosColumna; j++)
																	//        fila += " ";
																	//}

																	if (int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) > rowDatos["numFactura"].ToString().Length)
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()) - rowDatos["numFactura"].ToString().Length;

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}

																	fila += rowDatos["numFactura"].ToString();
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA")
																{

																	fila += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA_FACTURA")
																{

																	fila += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "VENCIMIENTO_FACTURA")
																{

																	fila += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA_INICIO_MES")
																{
																	fila += rowDatos["mesIni"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA_FIN_MES")
																{
																	fila += rowDatos["mesFin"].ToString();

																	if (dtFormatos.Rows[i]["TamColumna"].ToString() != "")
																	{
																		int espaciosColumna = int.Parse(dtFormatos.Rows[i]["TamColumna"].ToString()) - int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());

																		for (int j = 0; j < espaciosColumna; j++)
																			fila += " ";
																	}
																}

																i += 1;
															}
														}

														File.AppendAllText(savefile.FileName, fila + Environment.NewLine, Encoding.Default);
														#endregion
													}
													else
													{
														if (extension == ".xls" || extension == ".xlsx")
														{
															#region XLS
															int i = 0;

															int iCol = 0;

															foreach (DataColumn dc in dtDatos.Columns)
															{
																if (dtFormatos.Rows[iCol]["Macro"].ToString() == "CEDULA")
																{
																	string dataColumn = "";

																	if (CeroCedula.Equals("S"))
																		dataColumn = "0"; 
																	
																	dataColumn += "'" + dtFormatos.Rows[i]["Orden"].ToString() == "1" ? FormatoInicioLinea : "" + rowDatos[dc].ToString();

																	Cells[rowIndexExcel, iCol] = dataColumn;
																}
																else
																{
																	if (dtFormatos.Rows[i]["Macro"].ToString() == "NUMERO_FACTURA")
																	{
																		Cells[rowIndexExcel, iCol] = "'" + dtFormatos.Rows[i]["Orden"].ToString() == "1" ? FormatoInicioLinea : "" + fInternas.quitarCerosMontoInicio(rowDatos[dc].ToString());
																	}
																	else
																	{
																		if (dtFormatos.Rows[i]["Macro"].ToString() == "SALDO")
																		{
																			Cells[rowIndexExcel, iCol] = dtFormatos.Rows[i]["Orden"].ToString() == "1" ? FormatoInicioLinea : "" + decimal.Parse(rowDatos[dc].ToString());
																		}
																		else
																		{
																			if (dtFormatos.Rows[i]["Macro"].ToString() == "MONTO")
																			{
																				Cells[rowIndexExcel, iCol] = dtFormatos.Rows[i]["Orden"].ToString() == "1" ? FormatoInicioLinea : "" + decimal.Parse(rowDatos[dc].ToString());
																			}
																			else
																				Cells[rowIndexExcel, iCol] = iCol == 0 ? FormatoInicioLinea + rowDatos[dc].ToString() : "" + rowDatos[dc].ToString();
																		}
																	}
																}

																iCol++;
															}

															#endregion
														}
														else
														{
															if (extension == ".csv")
															{
																#region CSV

																string fila = "";
																int i = 0;
																foreach (DataRow row in dtFormatos.Rows)
																{
																	if (i <= cantFormatos)
																	{
																		string formato = dtFormatos.Rows[i]["Formato"].ToString();

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "CARNET")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["NumeroColegiado"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["NumeroColegiado"].ToString();
																			//if (rowDatos["NumeroColegiado"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																			//{
																			//    if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			//    {
																			//        fila += rowDatos["NumeroColegiado"].ToString();

																			//    }
																			//    else
																			//        fila += SeparadorCsv + rowDatos["NumeroColegiado"].ToString();

																			//}
																			//else
																			//{
																			//    if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			//    {
																			//        fila += rowDatos["NumeroColegiado"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));

																			//    }
																			//    else
																			//        fila += SeparadorCsv + rowDatos["NumeroColegiado"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																			//}
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "CEDULA")
																		{

																			if (CeroCedula.Equals("S"))
																				fila += "0";

																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["Cedula"].ToString().Trim();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["Cedula"].ToString().Trim();

																			//if (rowDatos["Cedula"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																			//{
																			//    if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			//    {
																			//        fila += rowDatos["Cedula"].ToString();

																			//    }
																			//    else
																			//        fila += SeparadorCsv + rowDatos["Cedula"].ToString();

																			//}
																			//else
																			//{
																			//    if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			//    {
																			//        fila += rowDatos["Cedula"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));

																			//    }
																			//    else
																			//        fila += SeparadorCsv + rowDatos["Cedula"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																			//}
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "NOMBRE")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["Nombre"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["Nombre"].ToString();

																			//if (rowDatos["Nombre"].ToString().Length < int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()))
																			//{
																			//    if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			//    {
																			//        fila += rowDatos["Nombre"].ToString();
																			//    }
																			//    else
																			//        fila += SeparadorCsv + rowDatos["Nombre"].ToString();

																			//}
																			//else
																			//{
																			//    if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			//    {
																			//        fila += rowDatos["Nombre"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																			//    }
																			//    else
																			//        fila += SeparadorCsv + rowDatos["Nombre"].ToString().Substring(0, int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString()));
																			//}

																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "APLICACION")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["Aplicacion"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["Aplicacion"].ToString();

																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "CORREO")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["Email"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["Email"].ToString();

																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "MONTO")
																		{
																			int decimales = 0;
																			string monto = "";
																			//int tamaño = 0;
																			//int ceros = 0;
																			if (dtFormatos.Rows[i]["Formato"].ToString().Contains("."))
																			{
																				decimales = dtFormatos.Rows[i]["Formato"].ToString().Split('.')[1].Length;

																				monto = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0] + ".";

																				for (int j = 0; j < decimales; j++)
																				{
																					monto += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[1][j];
																				}

																				//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																				//    monto = decimal.Parse(monto) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";

																			}
																			else
																			{

																				if (rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Contains("."))
																					monto = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0];
																				else
																					monto = decimal.Parse(rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString()) + "";

																				//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																				//    monto = decimal.Parse(monto) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";
																			}

																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + monto;
																			}
																			else
																				fila += SeparadorCsv + monto;
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "SALDO")
																		{
																			int decimales = 0;
																			string saldo = "";
																			//int tamaño = 0;
																			//int ceros = 0;
																			if (dtFormatos.Rows[i]["Formato"].ToString().Contains("."))
																			{
																				decimales = dtFormatos.Rows[i]["Formato"].ToString().Split('.')[1].Length;

																				saldo = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0] + ".";

																				for (int j = 0; j < decimales; j++)
																				{
																					saldo += rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[1][j];
																				}

																				//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																				//    saldo = decimal.Parse(saldo) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";

																			}
																			else
																			{

																				if (rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Contains("."))
																					saldo = rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString().Split('.')[0];
																				else
																					saldo = decimal.Parse(rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString()) + "";

																				//if (esNumfactura && !rowDatos["montoArreglo"].ToString().Equals(""))
																				//    saldo = decimal.Parse(saldo) + decimal.Parse(rowDatos["montoArreglo"].ToString().Split('.')[0]) + "";
																			}


																			montoTotal += decimal.Parse(saldo);

																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + saldo;
																			}
																			else
																				fila += SeparadorCsv + saldo;
																		}

																		//if (dtFormatos.Rows[i]["Macro"].ToString() == "DECIMALES")
																		//{
																		//    int total = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																		//    string monto = "";
																		//    monto = rowDatos["Monto"].ToString();
																		//    if (monto.Contains("."))
																		//    {
																		//        if (monto.Split('.')[1].Length >= total)
																		//            fila += monto.Split('.')[1].Substring(0, total);
																		//        else
																		//            fila += monto.Split('.')[1];

																		//        int falta = total - monto.Split('.')[1].Length;

																		//        for (int j = 0; j < falta; j++)
																		//            fila += "0";

																		//    }
																		//    else
																		//    {
																		//        fila += ".";
																		//        for (int j = 0; j < total; j++)
																		//            fila += "0";

																		//    }
																		//}


																		if (dtFormatos.Rows[i]["Macro"].ToString() == "AÑO")
																		{
																			int total = rowDatos["AÑO"].ToString().Length;
																			int totalCaracteres = int.Parse(dtFormatos.Rows[i]["Caracteres"].ToString());
																			if (totalCaracteres > 4)
																			{
																				MessageBox.Show("Error de formato,el año en la fila del colegiado " + rowDatos["Nombre"].ToString() + " tiene más caracteres que del formato de un año.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
																				return;
																			}

																			if (total == 4 && totalCaracteres == 2)
																			{
																				if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																				{
																					fila += FormatoInicioLinea + rowDatos["AÑO"].ToString().Remove(0, 2);
																				}
																				else
																					fila += SeparadorCsv + rowDatos["AÑO"].ToString().Remove(0, 2);
																			}
																			else
																			{
																				if (total == 4 && totalCaracteres == 4)
																				{
																					if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																					{
																						fila += FormatoInicioLinea + rowDatos["AÑO"].ToString();
																					}
																					else
																						fila += SeparadorCsv + rowDatos["AÑO"].ToString();
																				}
																			}

																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "CONTADOR")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["contador"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["contador"].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "MES")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["MES"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["MES"].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "CONSTANTE")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + dtFormatos.Rows[i]["Formato"].ToString();
																			}
																			else
																				fila += SeparadorCsv + dtFormatos.Rows[i]["Formato"].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "TARJETA")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["NumeroTarjeta"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["NumeroTarjeta"].ToString();

																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "VENCIMIENTO_TARJETA")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["venc_tarjeta"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["venc_tarjeta"].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "NUMERO_FACTURA")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["numFactura"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["numFactura"].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA_FACTURA")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "VENCIMIENTO_FACTURA")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["" + dtFormatos.Rows[i]["Detalle"].ToString() + ""].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA_INICIO_MES")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["mesIni"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["mesIni"].ToString();
																		}

																		if (dtFormatos.Rows[i]["Macro"].ToString() == "FECHA_FIN_MES")
																		{
																			if (dtFormatos.Rows[i]["Orden"].ToString() == "1")
																			{
																				fila += FormatoInicioLinea + rowDatos["mesFin"].ToString();
																			}
																			else
																				fila += SeparadorCsv + rowDatos["mesFin"].ToString();
																		}


																		i += 1;
																	}
																}
																
																File.AppendAllText(savefile.FileName, fila + Environment.NewLine);
																#endregion
															}
														}
													}
													rowIndexExcel += 1;
												}

												
												if (extension == ".txt")
												{
													string fila = "";
													if (TotalRegistro.Equals("S"))
													{
														fila = "TotalRegistros:" + (rowIndex - 1).ToString();
														File.AppendAllText(savefile.FileName, fila + Environment.NewLine, Encoding.Default);
													}

													if (TotalMonto.Equals("S"))
													{
														fila = "TotalCuota:" + montoTotal.ToString();
														File.AppendAllText(savefile.FileName, fila + Environment.NewLine, Encoding.Default);
													}
												}
																									
												if (extension == ".csv")
												{
													string fila = "";
													if (TotalRegistro.Equals("S"))
													{
														fila = "TotalRegistros:" + (rowIndex - 1).ToString();
														File.AppendAllText(savefile.FileName, fila + Environment.NewLine);
													}

													if (TotalMonto.Equals("S"))
													{
														fila = "TotalCuota:" + montoTotal.ToString();
														File.AppendAllText(savefile.FileName, fila + Environment.NewLine);
													}
												}
													
												if (extension == ".xls" || extension == ".xlsx")
												{
													//oSheet.Name = "PLANTILLA_KOLEGIO";
													//oSheet.Columns.AutoFit();


													Worksheet.Name = "PLANTILLA_KOLEGIO";
													Worksheet.get_Range((Excell.Range)(Worksheet.Cells[2, 1]), (Excell.Range)(Worksheet.Cells[dtDatos.Rows.Count + 1, dtFormatos.Rows.Count])).Value = Cells;
													Worksheet.Columns.AutoFit();
													oBook.SaveAs(savefile.FileName);
													oBook.Close();
													Excel.Quit();
												}

												if (!montoMayorACaracteres)
												{
													MessageBox.Show("Se generó el archivo exitosamente!", "Generación Plantilla", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
												}
												else
												{
													MessageBox.Show("Se generó el archivo con algunos montos menores ya que el monto era mayor a los caracteres de la plantilla!", "Generación Plantilla", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
													
												}
											}
										}
										else
											MessageBox.Show("No hay facturas a cobrar asociadas a este cobrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
										

									}
									
									Cursor.Current = Cursors.Default;

								}
								
							}
							else
								MessageBox.Show("La plantilla del cobrador seleccionado no tiene formatos definidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							
						}
					}
					else
						MessageBox.Show("El cobrador seleccionado no tiene una plantilla de cobro definida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					

				}


				if(!OK)
				{
					MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
			catch (Exception ex)
			{
				//Consultas.sqlCon.Rollback();
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool insertarDetalle(string Doc, string Fecha, ref string error)
		{
			List<string> parametros = new List<string>();
			Listado list = new Listado();
			list.COLUMNAS = "CodigoDocumento,FechaAplicacion";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_HISTORIAL_FACTURAS";
			bool lbOk = true;
			try
			{
				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_FACTURAS WHERE CodigoDocumento='" + Doc + "'";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				//if (lbOk)
				//{
				//foreach (DataGridViewRow row in dgvPlantilla.Rows)
				//{
				parametros.Clear();
				list.COLUMNAS_PK.Clear();
				list.COLUMNAS_PK.Add("CodigoDocumento");
				parametros.Add(Doc);
				parametros.Add(DateTime.Parse(Fecha).ToString("yyyy-MM-ddTHH:mm:ss"));

				lbOk = Consultas.insertar(parametros, list, "De Generacion Plantillas", ref error);

				//}
				//}
			}
			catch (Exception ex)
			{
				lbOk = false;
				error = ex.Message;
				return lbOk;
			}

			return lbOk;

		}

		private void crearSelectPersistencia(ref string sQuery, ref string sQueryParc, ref string sQueryUnion, ref string sQueryUnionParcialidad, ref string groupBy, ref string groupByParcialidad, string listadoFac)
		{
			string fragmentQuery = string.Empty, fragmentQueryUnion = string.Empty, fragmentQueryUnionParcialidad = string.Empty;

			//IdColegiado
			fragmentQuery = "t1.IdColegiado";
					
			sQuery += fragmentQuery;
			sQueryUnion += fragmentQuery;
			sQueryUnionParcialidad += fragmentQuery;
			sQueryParc += fragmentQuery;

			groupBy += "t1.IdColegiado";
			groupByParcialidad += "t1.IdColegiado";

			//Cedula
			fragmentQuery = "t1.Cedula";

			sQuery += "," + fragmentQuery; ;
			sQueryUnion += "," + fragmentQuery; ;
			sQueryUnionParcialidad += "," + fragmentQuery;
			sQueryParc += "," + fragmentQuery; ;

			groupBy += ", t1.Cedula";
			groupByParcialidad += ", t1.Cedula";

			//Numero Colegiado
			fragmentQuery = "t1.NumeroColegiado";
				
			sQuery += "," + fragmentQuery;
			sQueryUnion += "," + fragmentQuery;
			sQueryUnionParcialidad += "," + fragmentQuery;
			sQueryParc += "," + fragmentQuery;

			groupBy += ", t1.NumeroColegiado";
			groupByParcialidad += ", t1.NumeroColegiado";

			if (listadoFac.Equals("S"))
			{
				//TipoDoc
				fragmentQuery = "t2.TIPO";

				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQuery;
				sQueryUnionParcialidad += "," + fragmentQuery;
				sQueryParc += "," + fragmentQuery;

				groupBy += ", t2.TIPO";
				groupByParcialidad += ", t2.TIPO";

				//NumFactura
				fragmentQuery = "t2.DOCUMENTO";

				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQuery;
				sQueryUnionParcialidad += "," + fragmentQuery;
				sQueryParc += "," + fragmentQuery;

				groupBy += ", t2.DOCUMENTO";
				groupByParcialidad += ", t2.DOCUMENTO";

				//NumParcialidades
				fragmentQuery = "t2.NUM_PARCIALIDADES";

				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQuery;
				sQueryUnionParcialidad += "," + fragmentQuery;
				sQueryParc += "," + fragmentQuery;

				groupBy += ", t2.NUM_PARCIALIDADES";
				groupByParcialidad += ", t2.NUM_PARCIALIDADES";

				//Fecha Doc
				fragmentQuery = "t2.FECHA_DOCUMENTO";

				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQuery;
				sQueryUnionParcialidad += "," + fragmentQuery;
				sQueryParc += "," + fragmentQuery;

				groupBy += ", t2.FECHA_DOCUMENTO";
				groupByParcialidad += ", t2.FECHA_DOCUMENTO";

				//Parcialidad
				fragmentQuery = "t2.PARCIALIDAD";

				sQueryParc += "," + fragmentQuery;

				groupByParcialidad += ", t2.PARCIALIDAD";

				//Vendedor
				fragmentQuery = "t2.VENDEDOR";

				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQuery;
				sQueryUnionParcialidad += "," + fragmentQuery;
				sQueryParc += "," + fragmentQuery;

				groupBy += ", t2.VENDEDOR";
				groupByParcialidad += ", t2.VENDEDOR";
			}				

			//Saldo
			if (listadoFac.Equals("S"))
			{
				fragmentQuery = "t2.SALDO";
				fragmentQueryUnion = " (t2.SALDO+t3.SALDO) 'SALDO'";
				fragmentQueryUnionParcialidad = " SUM(t2.SALDO+t3.SALDO) 'SALDO'";

				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQueryUnion;
				sQueryUnionParcialidad += "," + fragmentQueryUnionParcialidad;
				sQueryParc += "," + fragmentQuery;

				groupBy += ", t2.SALDO";
				//groupByParcialidad += ", t2.SALDO";
			}
			else
			{
				fragmentQuery = "SUM(t2.SALDO) 'SALDO'";
				fragmentQueryUnion = " SUM(t2.SALDO+t3.SALDO) 'SALDO'";
					
				sQuery += "," + fragmentQuery;
				sQueryUnion += "," + fragmentQueryUnion;
				sQueryUnionParcialidad += "," + fragmentQueryUnion;
				sQueryParc += "," + fragmentQuery;
			}

			//Pagos parciales
			fragmentQuery = "t10.PAGOS_PARCIALES AS TIPO_DOC_KOLEGIO";

			sQuery += "," + fragmentQuery;
			sQueryUnion += "," + fragmentQuery;
			sQueryUnionParcialidad += "," + fragmentQuery;
			sQueryParc += "," + fragmentQuery;

			groupBy += ", t10.PAGOS_PARCIALES";
			groupByParcialidad += ", t10.PAGOS_PARCIALES";

		}

		private void crearSelect(ref string sQuery, ref string sQueryUnion, ref string sQueryUnionParcialidad, ref string groupBy, ref string groupByParcialidad, ref DataTable dtFormatos, ref int cantFormatos, ref bool esNumfactura, ref bool esFechafactura, ref bool esVencimientofactura, string listadoFac)
		{
			foreach (DataRow row in dtFormatos.Rows)
			{
				string fragmentQuery = string.Empty, fragmentQueryUnion = string.Empty, fragmentQueryUnionParcialidad = string.Empty;


				if (row["Macro"].ToString() == "APLICACION")
				{
					fragmentQuery = "t2.APLICACION Aplicacion";

					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t2.APLICACION";
						groupByParcialidad += ", t2.APLICACION";
					}
					else
					{
						groupBy += "t2.APLICACION";
						groupByParcialidad += "t2.APLICACION";
					}
				}

				if (row["Macro"].ToString() == "CEDULA")
				{
					fragmentQuery = "t1.Cedula";
					if (sQuery == "SELECT ")
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}
					else
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t1.Cedula";
						groupByParcialidad += ", t1.Cedula";
					}
					else
					{
						groupBy += "t1.Cedula";
						groupByParcialidad += "t1.Cedula";
					}
				}

				if (row["Macro"].ToString() == "CORREO")
				{
					fragmentQuery = "t1.Email";
					//if (sQuery == "SELECT DISTINCT ")
					if (sQuery == "SELECT ")
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}
					else
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t1.Email";
						groupByParcialidad += ", t1.Email";
					}
					else
					{
						groupBy += "t1.Email";
						groupByParcialidad += "t1.Email";
					}
				}

				if (row["Macro"].ToString() == "NOMBRE")
				{
					fragmentQuery = "t1.Nombre";
					//if (sQuery == "SELECT DISTINCT ")
					if (sQuery == "SELECT ")
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}
					else
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", T1.Nombre";
						groupByParcialidad += ", T1.Nombre";
					}
					else
					{
						groupBy += "T1.Nombre";
						groupByParcialidad += "T1.Nombre";
					}
				}

				if (row["Macro"].ToString() == "CONSTANTE")
				{
					fragmentQuery = " '" + row["Formato"].ToString() + "'";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				if (row["Macro"].ToString() == "DECIMALES")
				{
					fragmentQuery = "'" + row["Formato"].ToString() + "'";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				if (row["Macro"].ToString() == "AÑO")
				{
					fragmentQuery = "'" + DateTime.Now.Year + "' AÑO";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}
				}

				if (row["Macro"].ToString() == "MES")
				{
					string mes = "";
					if (DateTime.Now.Month < 10)
						mes = "0" + DateTime.Now.Month;
					else
						mes = DateTime.Now.Month + "";

					fragmentQuery = "'" + mes + "' MES";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				if (row["Macro"].ToString() == "SALDO")
				{
					if (listadoFac.Equals("S"))
					{
						fragmentQuery = "t2.SALDO '" + row["Detalle"].ToString() + "'";
						fragmentQueryUnion = " (t2.SALDO+t3.SALDO) '" + row["Detalle"].ToString() + "'";
						fragmentQueryUnionParcialidad = " SUM(t2.SALDO+t3.SALDO) '" + row["Detalle"].ToString() + "'";
						
						if (sQuery != "SELECT ")
						{
							sQuery += "," + fragmentQuery;
							sQueryUnion += "," + fragmentQueryUnion;
							sQueryUnionParcialidad += "," + fragmentQueryUnionParcialidad;
						}
						else
						{
							sQuery += fragmentQuery;
							sQueryUnion += fragmentQueryUnion;
							sQueryUnionParcialidad += sQueryUnionParcialidad;
						}

						if (groupBy != "GROUP BY ")
							groupBy += ", t2.SALDO";
						else
							groupBy += "t2.SALDO";
					}
					else
					{
						fragmentQuery = "SUM(t2.SALDO) '" + row["Detalle"].ToString() + "'";
						fragmentQueryUnion = " SUM(t2.SALDO+t3.SALDO) '" + row["Detalle"].ToString() + "'";
						if (sQuery != "SELECT ")
						{
							sQuery += "," + fragmentQuery;
							sQueryUnion += "," + fragmentQueryUnion;
							sQueryUnionParcialidad += "," + fragmentQueryUnion;
						}
						else
						{
							sQuery += fragmentQuery;
							sQueryUnion += fragmentQueryUnion;
							sQueryUnionParcialidad += fragmentQueryUnion;
						}

					}
					//if (groupBy != "GROUP BY ")
					//    groupBy += ", t2.SALDO";
					//else
					//    groupBy += "t2.SALDO";
					//if (sQueryUnion != "SELECT ")
					//    sQueryUnion += ", (select distinct SALDO from "+Consultas.sqlCon.COMPAÑIA+".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ) '" + row["Detalle"].ToString() + "'";
					//else
					//    sQueryUnion += " (select distinct SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ) '" + row["Detalle"].ToString() + "'";
				}

				if (row["Macro"].ToString() == "MONTO")
				{
					fragmentQuery = "t2.MONTO '" + row["Detalle"].ToString() + "'";
					fragmentQueryUnion = " (t2.MONTO+t3.MONTO) '" + row["Detalle"].ToString() + "'";
					fragmentQueryUnionParcialidad = " SUM(t2.MONTO+t3.MONTO) '" + row["Detalle"].ToString() + "'";
					//if (sQuery != "SELECT DISTINCT ")
					if (listadoFac.Equals("S"))
					{
						if (sQuery != "SELECT ")
						{
							sQuery += "," + fragmentQuery;
							sQueryUnion += "," + fragmentQueryUnion;
							sQueryUnionParcialidad += "," + fragmentQueryUnionParcialidad;
						}
						else
						{
							sQuery += fragmentQuery;
							sQueryUnion += fragmentQueryUnion;
							sQueryUnionParcialidad += sQueryUnionParcialidad;
						}

						if (groupBy != "GROUP BY ")
							groupBy += ", t2.MONTO";
						else
							groupBy += "t2.MONTO";
					}
					else
					{
						fragmentQuery = "SUM(t2.MONTO) '" + row["Detalle"].ToString() + "'";
						fragmentQueryUnion = " SUM(t2.MONTO+t3.MONTO) '" + row["Detalle"].ToString() + "'";
						if (sQuery != "SELECT ")
						{
							sQuery += "," + fragmentQuery;
							sQueryUnion += "," + fragmentQueryUnion;
							sQueryUnionParcialidad += "," + fragmentQueryUnion;
						}
						else
						{
							sQuery += fragmentQuery;
							sQueryUnion += fragmentQueryUnion;
							sQueryUnionParcialidad += fragmentQueryUnion;
						}

					}
				}

				if (row["Macro"].ToString() == "CARNET")
				{
					fragmentQuery = "t1.NumeroColegiado";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t1.NumeroColegiado";
						groupByParcialidad += ", t1.NumeroColegiado";
					}
					else
					{
						groupBy += "t1.NumeroColegiado";
						groupByParcialidad += "t1.NumeroColegiado";
					}
				}

				if (row["Macro"].ToString() == "NUMERO_FACTURA")
				{
					fragmentQuery = "t2.DOCUMENTO numFactura";
					esNumfactura = true;
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery; 
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t2.DOCUMENTO";
						groupByParcialidad += ", t2.DOCUMENTO";
					}
					else
					{
						groupBy += "t2.DOCUMENTO";
						groupByParcialidad += "t2.DOCUMENTO";
					}
					//if (sQueryUnion != "SELECT ")
					//    sQueryUnion += ", (select distinct DOCUMENTO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ) numFactura";
					//else
					//    sQueryUnion += "(select distinct DOCUMENTO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ) numFactura";
				}

				if (row["Macro"].ToString() == "TARJETA")
				{
					fragmentQuery = "t1.NumeroTarjeta";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t1.NumeroTarjeta";
						groupByParcialidad += ", t1.NumeroTarjeta";
					}
					else
					{
						groupBy += "t1.NumeroTarjeta";
						groupByParcialidad += "t1.NumeroTarjeta";
					}
				}

				if (row["Macro"].ToString() == "VENCIMIENTO_TARJETA")
				{
					fragmentQuery = "FORMAT(t1.VencimientoTarjeta,'MMyyyy') venc_tarjeta";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t1.VencimientoTarjeta";
						groupByParcialidad += ", t1.VencimientoTarjeta";
					}
					else
					{
						groupBy += "t1.VencimientoTarjeta";
						groupByParcialidad += "t1.VencimientoTarjeta";
					}
				}

				if (row["Macro"].ToString() == "FECHA")
				{
					fragmentQuery = "FORMAT(GETDATE(),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				if (row["Macro"].ToString() == "FECHA_INICIO_MES")
				{
					fragmentQuery = "FORMAT(DATEADD(s,0,DATEADD(mm, DATEDIFF(m,0,GETDATE()),0)), '" + row["Formato"].ToString() + "') as mesIni";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				if (row["Macro"].ToString() == "FECHA_FIN_MES")
				{
					fragmentQuery = "FORMAT(DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE())+1,0)), '" + row["Formato"].ToString() + "') as mesFin";
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				if (row["Macro"].ToString() == "FECHA_FACTURA")
				{
					fragmentQuery = "FORMAT(t2.FECHA_DOCUMENTO,'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
					esFechafactura = true;
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						//fragmentQuery = "FORMAT(GETDATE(),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						//fragmentQuery = "FORMAT(GETDATE(),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
						groupBy += ", t2.FECHA_DOCUMENTO";
					else
						groupBy += "t2.FECHA_DOCUMENTO";
					//if (sQueryUnion != "SELECT ")
					//    sQueryUnion += ", FORMAT((select distinct FECHA from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
					//else
					//    sQueryUnion += "FORMAT((select distinct FECHA from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
				}

				if (row["Macro"].ToString() == "VENCIMIENTO_FACTURA")
				{
					fragmentQuery = "FORMAT(t2.FECHA_VENCE,'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
					esVencimientofactura = true;
					//if (sQuery != "SELECT DISTINCT ")
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

					if (groupBy != "GROUP BY ")
					{
						groupBy += ", t2.FECHA_VENCE";
						groupByParcialidad += ", t2.FECHA_VENCE";
					}
					else
					{
						groupBy += "t2.FECHA_VENCE";
						groupByParcialidad += "t2.FECHA_VENCE";
					}
					//if (sQueryUnion != "SELECT ")
					//    sQueryUnion += ", FORMAT((select distinct FECHA from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
					//else
					//    sQueryUnion += "FORMAT((select distinct FECHA from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA) and CLIENTE = t1.IdColegiado ),'" + row["Formato"].ToString() + "') '" + row["Detalle"].ToString() + "'";
				}

				if (row["Macro"].ToString() == "CONTADOR")
				{
					fragmentQuery = "ROW_NUMBER() over(order by T1.Cedula) as contador";
					if (sQuery != "SELECT ")
					{
						sQuery += "," + fragmentQuery;
						sQueryUnion += "," + fragmentQuery;
						sQueryUnionParcialidad += "," + fragmentQuery;
					}
					else
					{
						sQuery += fragmentQuery;
						sQueryUnion += fragmentQuery;
						sQueryUnionParcialidad += fragmentQuery;
					}

				}

				cantFormatos += 1;
			}

			//if(esNumfactura)
			//    sQuery += ",(select distinct SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D'" +
			//        " and SUBTIPO = '176' and datepart(YYYY, FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, FECHA) = datepart(mm, t2.FECHA)" +
			//        " and CLIENTE = t1.IdColegiado) montoArreglo";
		}

		private void crearQuery(ref string query, ref string queryParc, string select, string selectParc, string selectUnion, string selectUnionParcialidad, string groupBy, string groupByParc, string ListadoPorFac, string GenerarPor, string SumarArreglo, string ArregloPorDocumento, string RubroColegiatura, string RubroRegencia, string RubroPerito, string RubroAerea, string RubroPlaguicida)
		{

			string queryTotalCOL = "", queryTotalREG = "", queryTotalPER = "", queryTotalVIA = "", queryTotalIDO = "", queryTotalArreglo = "", queryCOLTotalArreglo = "", queryTotalParcialidad = "", queryCOLTotalParcialidad = "", whereArreglo = "", cobradorCOL = "", cobradorREG = "";
			if (ListadoPorFac.Equals("S"))//SE LISTA POR FACTURA
			{
				if (GenerarPor.Equals("C"))
				{
					cobradorCOL = "AND t1.COBRADOR = '" + txtCobrador.Text + "'";
					cobradorREG = "AND t4.COBRADOR = '" + txtCobrador.Text + "'";
				}

				if (SumarArreglo.Equals("S"))
				{
					queryCOLTotalArreglo = "LEFT JOIN ( SELECT DISTINCT t2.DOCUMENTO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado  AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC'" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t3 ON t3.CLIENTE = t1.IdColegiado and t3.TIPO = 'O/D' and t3.SUBTIPO = '176'" +
						" and datepart(YYYY, t3.FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, t3.FECHA) = datepart(mm, t2.FECHA)" +
						" WHERE t2.SALDO > 0 AND t3.SALDO > 0 " + cobradorCOL + " ) t3 on t3.DOCUMENTO = t2.DOCUMENTO";
					queryCOLTotalParcialidad = "LEFT JOIN ( SELECT DISTINCT t2.DOCUMENTO" +
						"    FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						"    JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC' AND t2.SALDO > 0 AND t2.NUM_PARCIALIDADES < 2" +
						"    JOIN( SELECT  t2.CLIENTE, t2.DOCUMENTO, t3.FECHA_RIGE, t3.FECHA_VENCE, t3.SALDO" +
						"        FROM  " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2" +
						"        JOIN " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t3 on t3.DOCUMENTO_ORIGEN = t2.DOCUMENTO" +
						"        WHERE t2.NUM_PARCIALIDADES > 1 AND t2.SALDO > 0 AND t3.SALDO > 0" +
						"    ) t3 ON t3.CLIENTE = t1.IdColegiado and datepart(YYYY, t3.FECHA_RIGE) = datepart(YYYY, t2.FECHA) and datepart(mm, t3.FECHA_RIGE) = datepart(mm, t2.FECHA)" +
						"    WHERE t2.SALDO > 0 AND t3.SALDO > 0 " + cobradorCOL + " ) t4 on t4.DOCUMENTO = t2.DOCUMENTO ";

					whereArreglo = "t3.DOCUMENTO IS NULL AND t4.DOCUMENTO IS NULL AND";

					queryTotalArreglo = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado  AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC'" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t3 ON t3.CLIENTE = t1.IdColegiado and t3.TIPO = 'O/D' and t3.SUBTIPO = '176'" +
						" and datepart(YYYY, t3.FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, t3.FECHA) = datepart(mm, t2.FECHA)" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t3.SALDO > 0 " + cobradorCOL;
					queryTotalParcialidad = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC' AND t2.SALDO > 0 AND t2.NUM_PARCIALIDADES < 2" +
						" JOIN(" +
						"     SELECT  t2.CLIENTE, t2.DOCUMENTO, YEAR(t3.FECHA_RIGE) 'ANO', MONTH(t3.FECHA_RIGE) 'MES', SUM(t3.SALDO) 'SALDO'" +
						"     FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2" +
						"     JOIN " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t3 on t3.DOCUMENTO_ORIGEN = t2.DOCUMENTO" +
						"    WHERE t2.NUM_PARCIALIDADES > 1 AND t2.SALDO > 0 AND t3.SALDO > 0 " +
						"     GROUP BY t2.CLIENTE, t2.DOCUMENTO, YEAR(t3.FECHA_RIGE), MONTH(t3.FECHA_RIGE)" +
						" ) t3 ON t3.CLIENTE = t1.IdColegiado and t3.ANO = datepart(YYYY, t2.FECHA) and t3.MES = datepart(mm, t2.FECHA)" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t3.SALDO > 0 " + cobradorCOL + " " +
						" " + groupBy;
						//" GROUP BY T1.Cedula, T1.Nombre, t1.NumeroColegiado, t2.FECHA_DOCUMENTO, t2.FECHA_VENCE, t2.DOCUMENTO";
				}
				else if (ArregloPorDocumento.Equals("S"))
				{
					queryTotalArreglo = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado and t2.TIPO = 'O/D' and t2.SUBTIPO = '176'" +
						" AND datepart(YYYY, t2.FECHA) <= datepart(YYYY, GETDATE()) and datepart(mm, t2.FECHA) <= datepart(mm, GETDATE())" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 " + cobradorCOL;
					queryTotalParcialidad = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
						" JOIN( SELECT  t2.CLIENTE, t2.DOCUMENTO, t2.CONDICION_PAGO, t3.FECHA_RIGE 'FECHA_DOCUMENTO', t2.FECHA_VENCE, t3.SALDO, t3.TIPO_DOC_ORIGEN, t3.PARCIALIDAD, t2.APLICACION, t2.TIPO, t2.NUM_PARCIALIDADES" +
						" 	FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 JOIN " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t3 on t3.DOCUMENTO_ORIGEN = t2.DOCUMENTO" +
						"	WHERE t2.NUM_PARCIALIDADES > 1 AND t2.SALDO > 0 AND t3.SALDO > 0" +
						" ) t2 ON t2.CLIENTE = t1.IdColegiado and datepart(YYYY, t2.FECHA_DOCUMENTO) <= datepart(YYYY, GETDATE()) and datepart(mm, t2.FECHA_DOCUMENTO) <= datepart(mm, GETDATE())" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 " + cobradorCOL + " " +
						" " + groupByParc;
				}

				if (RubroColegiatura.Equals("S"))
				{
					queryTotalCOL = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado AND t2.NUM_PARCIALIDADES < 2" +
						" " + queryCOLTotalArreglo +
						" " + queryCOLTotalParcialidad +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE " + whereArreglo + " t2.SALDO > 0 AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}

				if (RubroRegencia.Equals("S"))
				{
					//queryTotalREG = " FROM  " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					//	" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
					//	" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".FACTURA t3 ON t3.FACTURA = t2.DOCUMENTO" +
					//	" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t4 ON t4.NumeroColegiado = t1.IdColegiado and t4.CodigoEstablecimiento = t3.U_ESTABLE_KOL and t4.CodigoCategoria = t3.U_CATEG_KOL" +
					//	" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					//	" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'REG' AND t2.TIPO = 'FAC' " + cobradorREG;
					queryTotalREG = " FROM  " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						//" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".FACTURA t3 ON t3.FACTURA = t2.DOCUMENTO" +
						" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t4 ON t4.NumeroColegiado = t1.IdColegiado and t4.CodigoEstablecimiento = t2.U_ESTABLE_KOL and t4.CodigoCategoria = t2.U_CATEG_KOL" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'REG' AND t2.TIPO = 'FAC' " + cobradorREG;
				}

				if (RubroPerito.Equals("S"))
				{
					queryTotalPER = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS t3 ON t3.IdColegiado = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'PER' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}

				if (RubroAerea.Equals("S"))
				{
					queryTotalVIA = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO t3 ON t3.IdColegiado = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'VIA' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}

				if (RubroPlaguicida.Equals("S"))
				{
					queryTotalIDO = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t3 ON t3.IdColegiado = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'IDO' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}

				if (RubroRegencia.Equals("S"))
				{
					//if (RubroColegiatura.Equals("S"))
					//	query += " union all ";
					query = select;
					query += queryTotalREG;
				}

				if (RubroColegiatura.Equals("S"))
				{
					if (RubroRegencia.Equals("S"))
						query += " union all ";

					query += select;
					query += queryTotalCOL;
					query += " union all ";
					if (SumarArreglo.Equals("S"))
						query += selectUnion;
					else
						query += select;
					query += queryTotalArreglo;
					queryParc = selectParc.Replace("t2.SALDO", "SUM(t2.SALDO) SALDO");//Para obtener la consulta de las parcialidad en persistencia
					queryParc += queryTotalParcialidad;
						query += " union all ";
					if (SumarArreglo.Equals("S"))
						query += selectUnionParcialidad;
					else
					{
						select = select.Replace("t2.FECHA_DOCUMENTO", "GETDATE()"); 
						select = select.Replace("t2.SALDO", "SUM(t2.SALDO)");
						query += select;
					}
					query += queryTotalParcialidad;

				}


				if (RubroPerito.Equals("S"))
				{
					if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S"))
						query += " union all ";

					query += select;
					query += queryTotalPER;
					//query += " union all ";
				}

				if (RubroAerea.Equals("S"))
				{
					if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S") || RubroPerito.Equals("S"))
						query += " union all ";

					query += select;
					query += queryTotalVIA;
					//query += " union all ";
				}

				if (RubroPlaguicida.Equals("S"))
				{
					if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S") || RubroPerito.Equals("S") || RubroAerea.Equals("S"))
						query += " union all ";

					query += select;
					query += queryTotalIDO;
					//query += " union all ";
				}

			}
			else//SE LISTA SUMA POR COLEGIADO
			{
				if (GenerarPor.Equals("C"))
				{
					cobradorCOL = "AND t1.COBRADOR = '" + txtCobrador.Text + "'";
					cobradorREG = "AND t4.COBRADOR = '" + txtCobrador.Text + "'";
				}

				if (SumarArreglo.Equals("S"))
				{//SE SUMA EL ARREGLO A LA COLEGIATURA QUE SE VAYA A COBRAR
					queryTotalArreglo = "SELECT  IdColegiado, SUM(t3.SALDO) 'saldo'" +
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t3 ON t3.CLIENTE = t1.IdColegiado and t3.TIPO = 'O/D' and t3.SUBTIPO = '176' and datepart(YYYY, t3.FECHA) = datepart(YYYY, t2.FECHA) and datepart(mm, t3.FECHA) = datepart(mm, t2.FECHA)" +
						" WHERE t2.SALDO > 0 AND t2.TIPO = 'FAC' AND t2.VENDEDOR = 'COL' " + cobradorCOL + " " +
						" GROUP BY t1.IdColegiado ";
					queryTotalParcialidad = "SELECT  IdColegiado, SUM(t3.SALDO) 'saldo'" +
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC' AND t2.SALDO > 0 AND t2.NUM_PARCIALIDADES < 2" +
						" JOIN(" +
						"     SELECT  t2.CLIENTE, t2.DOCUMENTO, YEAR(t3.FECHA_RIGE) 'ANO', MONTH(t3.FECHA_RIGE) 'MES', SUM(t3.SALDO) 'SALDO'" +
						"     FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2" +
						"     JOIN " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t3 on t3.DOCUMENTO_ORIGEN = t2.DOCUMENTO" +
						"    WHERE t2.NUM_PARCIALIDADES > 1 AND t2.SALDO > 0 AND t3.SALDO > 0 " +
						"     GROUP BY t2.CLIENTE, t2.DOCUMENTO, YEAR(t3.FECHA_RIGE), MONTH(t3.FECHA_RIGE)" +
						" ) t3 ON t3.CLIENTE = t1.IdColegiado and t3.ANO = datepart(YYYY, t2.FECHA) and t3.MES = datepart(mm, t2.FECHA)" +
						" WHERE t2.SALDO > 0 AND t3.SALDO > 0 " + cobradorCOL + " " +
						" GROUP BY t1.IdColegiado ";
				}
				else if (ArregloPorDocumento.Equals("S"))
				{//SE COBRA LOS ARREGLOS HASTA LA FECHA ACTUAL 
					queryTotalArreglo = "SELECT  IdColegiado, SUM(t3.SALDO) 'saldo'" +
					 " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					 " JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t3 ON t3.CLIENTE = t1.IdColegiado and t3.TIPO = 'O/D' and t3.SUBTIPO = '176' and datepart(YYYY, t3.FECHA) <= datepart(YYYY, GETDATE()) and datepart(mm, t3.FECHA) <= datepart(mm, GETDATE())" +
					 " WHERE t3.SALDO > 0" + cobradorCOL +
					 " GROUP BY t1.IdColegiado";
					queryTotalParcialidad = "SELECT t1.IdColegiado, SUM(t2.SALDO) 'saldo'" +
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN(" +
						" 	SELECT  t2.CLIENTE, t2.DOCUMENTO, t3.FECHA_RIGE 'FECHA_DOCUMENTO', t3.FECHA_VENCE, t3.SALDO, t3.TIPO_DOC_ORIGEN, t3.PARCIALIDAD, t2.APLICACION, t2.TIPO, t2.NUM_PARCIALIDADES" +
						" 	FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2" +
						" 	JOIN " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t3 on t3.DOCUMENTO_ORIGEN = t2.DOCUMENTO" +
						" 	WHERE t2.NUM_PARCIALIDADES > 1 AND t2.SALDO > 0 AND t3.SALDO > 0" +
						" ) t2 ON t2.CLIENTE = t1.IdColegiado and datepart(YYYY, t2.FECHA_DOCUMENTO) <= datepart(YYYY, GETDATE()) and datepart(mm, t2.FECHA_DOCUMENTO) <= datepart(mm, GETDATE())" +
						" WHERE t2.SALDO > 0" + cobradorCOL +
						" GROUP BY t1.IdColegiado";
				}

				if (RubroColegiatura.Equals("S"))
				{
					queryTotalCOL = "SELECT IdColegiado, SUM(t2.SALDO) 'saldo'" +
						" FROM  " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 JOIN  " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" WHERE t2.SALDO > 0 AND t2.TIPO = 'FAC' AND t2.VENDEDOR = 'COL' " + cobradorCOL + " AND t2.NUM_PARCIALIDADES < 2" +
						" GROUP BY t1.IdColegiado ";
				}

				if (RubroRegencia.Equals("S"))
				{
					//queryTotalREG = "SELECT IdColegiado, SUM(t2.SALDO) 'saldo'" +
					//	" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					//	" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
					//	" JOIN " + Consultas.sqlCon.COMPAÑIA + ".FACTURA t3 ON t3.FACTURA = t2.DOCUMENTO" +
					//	" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t4 ON t4.NumeroColegiado = t1.IdColegiado and t4.CodigoEstablecimiento = t3.U_ESTABLE_KOL and t4.CodigoCategoria = t3.U_CATEG_KOL" +
					//	" WHERE t2.SALDO > 0 AND t2.TIPO = 'FAC' AND t2.VENDEDOR = 'REG' " + cobradorREG +
					//	" GROUP BY t1.IdColegiado";
					queryTotalREG = "SELECT IdColegiado, SUM(t2.SALDO) 'saldo'" +
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						//" JOIN " + Consultas.sqlCon.COMPAÑIA + ".FACTURA t3 ON t3.FACTURA = t2.DOCUMENTO" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t4 ON t4.NumeroColegiado = t1.IdColegiado and t4.CodigoEstablecimiento = t2.U_ESTABLE_KOL and t4.CodigoCategoria = t2.U_CATEG_KOL" +
						" WHERE t2.SALDO > 0 AND t2.TIPO = 'FAC' AND t2.VENDEDOR = 'REG' " + cobradorREG +
						" GROUP BY t1.IdColegiado";
				}

				if (RubroPerito.Equals("S"))
				{
					queryTotalPER = "SELECT t3.IdColegiado, SUM(t2.SALDO) 'saldo'" + 
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS t3 ON t3.IdColegiado = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'PER' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}

				if (RubroAerea.Equals("S"))
				{
					queryTotalVIA = "SELECT t3.IdColegiado, SUM(t2.SALDO) 'saldo'" + 
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO t3 ON t3.IdColegiado = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'IVA' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}

				if (RubroPlaguicida.Equals("S"))
				{
					queryTotalIDO = "SELECT t3.IdColegiado, SUM(t2.SALDO) 'saldo'" + 
						" FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t3 ON t3.IdColegiado = t1.IdColegiado" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
						" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'IDO' AND t2.TIPO = 'FAC' " + cobradorCOL;
				}


				query += select;
				query += " FROM ( ";

				if (RubroColegiatura.Equals("S"))
				{
					query += queryTotalCOL;
					query += " union all ";
					query += queryTotalArreglo;
					query += " union all ";
					query += queryTotalParcialidad;
				}

				if (RubroRegencia.Equals("S"))
				{
					if (RubroColegiatura.Equals("S"))
						query += " union all ";

					query += queryTotalREG;
				}

				if (RubroPerito.Equals("S"))
				{
					if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S"))
						query += " union all ";

					query += queryTotalPER;
				}

				if (RubroAerea.Equals("S"))
				{
					if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S") || RubroPerito.Equals("S"))
						query += " union all ";

					query += queryTotalVIA;
				}

				if (RubroPlaguicida.Equals("S"))
				{
					if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S") || RubroPerito.Equals("S") || RubroAerea.Equals("S"))
						query += " union all ";

					query += queryTotalIDO;
				}

				query += " ) t2 JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 ON t1.IdColegiado = t2.IdColegiado ";
				query += groupBy;

			}
		}

		private void crearQueryPersistencia(ref string query, ref string queryParc, string select, string selectParc, string groupBy, string groupByParc, string GenerarPor, string ArregloPorDocumento, string RubroColegiatura, string RubroRegencia, string RubroPerito, string RubroAerea, string RubroPlaguicida)
		{

			string queryTotalCOL = "", queryTotalREG = "", queryTotalPER = "", queryTotalVIA = "", queryTotalIDO = "", queryTotalArreglo = "", queryCOLTotalArreglo = "", queryTotalParcialidad = "", queryCOLTotalParcialidad = "", whereArreglo = "", cobradorCOL = "", cobradorREG = "";
			
			if (GenerarPor.Equals("C"))
			{
				cobradorCOL = "AND t1.COBRADOR = '" + txtCobrador.Text + "'";
				cobradorREG = "AND t4.COBRADOR = '" + txtCobrador.Text + "'";
			}

			//if (ArregloPorDocumento.Equals("S"))
			//{
				queryTotalArreglo = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado and t2.TIPO = 'O/D' and t2.SUBTIPO = '176'" +
					" AND datepart(YYYY, t2.FECHA) <= datepart(YYYY, GETDATE()) and datepart(mm, t2.FECHA) <= datepart(mm, GETDATE())" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE t2.SALDO > 0 " + cobradorCOL;
				queryTotalParcialidad = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
					" JOIN( SELECT  t2.CLIENTE, t2.DOCUMENTO, t2.CONDICION_PAGO, t3.FECHA_RIGE 'FECHA_DOCUMENTO', t2.FECHA_VENCE, t3.SALDO, t3.TIPO_DOC_ORIGEN, t3.PARCIALIDAD, t2.APLICACION, t2.TIPO, t2.NUM_PARCIALIDADES, t2.VENDEDOR " +
					" 	FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 JOIN " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC t3 on t3.DOCUMENTO_ORIGEN = t2.DOCUMENTO" +
					"	WHERE t2.NUM_PARCIALIDADES > 1 AND t2.SALDO > 0 AND t3.SALDO > 0" +
					" ) t2 ON t2.CLIENTE = t1.IdColegiado and datepart(YYYY, t2.FECHA_DOCUMENTO) <= datepart(YYYY, GETDATE()) and datepart(mm, t2.FECHA_DOCUMENTO) <= datepart(mm, GETDATE())" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE t2.SALDO > 0 " + cobradorCOL + " ";// +
					//" " + groupByParc;
			//}

			if (RubroColegiatura.Equals("S"))
			{
				queryTotalCOL = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado AND t2.NUM_PARCIALIDADES < 2" +
					" " + queryCOLTotalArreglo +
					" " + queryCOLTotalParcialidad +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE " + whereArreglo + " t2.SALDO > 0 AND t2.VENDEDOR = 'COL' AND t2.TIPO = 'FAC' " + cobradorCOL;
			}

			if (RubroRegencia.Equals("S"))
			{
				//queryTotalREG = " FROM  " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
				//	" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
				//	" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".FACTURA t3 ON t3.FACTURA = t2.DOCUMENTO" +
				//	" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t4 ON t4.NumeroColegiado = t1.IdColegiado and t4.CodigoEstablecimiento = t3.U_ESTABLE_KOL and t4.CodigoCategoria = t3.U_CATEG_KOL" +
				//	" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
				//	" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'REG' AND t2.TIPO = 'FAC' " + cobradorREG;
				queryTotalREG = " FROM  " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
					//" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".FACTURA t3 ON t3.FACTURA = t2.DOCUMENTO" +
					" JOIN  " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t4 ON t4.NumeroColegiado = t1.IdColegiado and t4.CodigoEstablecimiento = t2.U_ESTABLE_KOL and t4.CodigoCategoria = t2.U_CATEG_KOL" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'REG' AND t2.TIPO = 'FAC' " + cobradorREG;
			}

			if (RubroPerito.Equals("S"))
			{
				queryTotalPER = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS t3 ON t3.IdColegiado = t1.IdColegiado" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'PER' AND t2.TIPO = 'FAC' " + cobradorCOL;
			}

			if (RubroAerea.Equals("S"))
			{
				queryTotalVIA = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO t3 ON t3.IdColegiado = t1.IdColegiado" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'IVA' AND t2.TIPO = 'FAC' " + cobradorCOL;
			}

			if (RubroPlaguicida.Equals("S"))
			{
				queryTotalIDO = " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t2 ON t2.CLIENTE = t1.IdColegiado" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO t3 ON t3.IdColegiado = t1.IdColegiado" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t10 ON t2.CONDICION_PAGO = t10.CONDICION_PAGO" +
					" WHERE t2.SALDO > 0 AND t2.VENDEDOR = 'IDO' AND t2.TIPO = 'FAC' " + cobradorCOL;
			}

			if (RubroRegencia.Equals("S"))
			{
				//if (RubroColegiatura.Equals("S"))
				//	query += " union all ";
				query = select;
				query += queryTotalREG;
			}

			if (RubroColegiatura.Equals("S"))
			{
				if (RubroRegencia.Equals("S"))
					query += " union all ";

				query += select;
				query += queryTotalCOL;
				query += " union all ";
				//if (SumarArreglo.Equals("S"))
				//	query += selectUnion;
				//else
					query += select;
				query += queryTotalArreglo;
				queryParc = selectParc.Replace("t2.SALDO", "SUM(t2.SALDO) SALDO");//Para obtener la consulta de las parcialidad en persistencia
				queryParc += queryTotalParcialidad;
				queryParc += groupByParc;
				query += " union all ";
				//if (SumarArreglo.Equals("S"))
				//	query += selectUnionParcialidad;
				//else
				//{
					select = select.Replace("t2.FECHA_DOCUMENTO", "GETDATE()");
					select = select.Replace("t2.SALDO", "SUM(t2.SALDO)");
					query += select;
				//}
				query += queryTotalParcialidad;
				query += groupBy;
			}

			if (RubroPerito.Equals("S"))
			{
				if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S"))
					query += " union all ";

				query += select;
				query += queryTotalPER;
				query += groupBy;
			}

			if (RubroAerea.Equals("S"))
			{
				if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S") || RubroPerito.Equals("S"))
					query += " union all ";

				query += select;
				query += queryTotalVIA;
				query += groupBy;
			}

			if (RubroPlaguicida.Equals("S"))
			{
				if (RubroRegencia.Equals("S") || RubroColegiatura.Equals("S") || RubroPerito.Equals("S") || RubroAerea.Equals("S"))
					query += " union all ";

				query += select;
				query += queryTotalIDO;
				query += groupBy;
			}

		}


		private string obtenerMontoArreglo(string cliente)
		{
			string error = "";
			string montoArreglo = "";
			DataTable dt = new DataTable();

			string sQuery = "select SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where TIPO = 'O/D' and CLIENTE = '" + cliente + "' and datepart(YYYY, FECHA) = datepart(YYYY, getdate()) and datepart(mm, FECHA) = datepart(mm, getdate())";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					montoArreglo = dt.Rows[0]["SALDO"].ToString();
				}
				else
				{
					montoArreglo = "0";
				}
			}

			return montoArreglo;
		}

		private void txtCobrador_DoubleClick(object sender, EventArgs e)
		{
			listaCobradores();
		}

		private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCobrador.ReadOnly)
				listaCobradores();
		}

		private void txtCobrador_Leave(object sender, EventArgs e)
		{
			if (txtCobrador.Text.Trim().Equals(""))
			{
				txtNombreCobrador.Clear();
			}
			else
			{
				if (oldValue != txtCobrador.Text)
				{
					cargarCobrador(txtCobrador.Text);
					if (txtCobrador.Text.Trim() == "")
						MessageBox.Show("El Cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void listaCobradores()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "COBRADOR as Código,NOMBRE as Nombre";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "COBRADOR";
			listD.TITULO_LISTADO = "Cobradores";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtCobrador.Text = f1.item.SubItems[0].Text;
				txtNombreCobrador.Text = f1.item.SubItems[1].Text;
			}
		}

		private void cargarCobrador(string cobrador)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "COBRADOR";
			listA.FILTRO = "where COBRADOR = '" + cobrador + "'";
			string error = "";
			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCobrador.Text = dtTTs.Rows[0]["COBRADOR"].ToString();
					txtNombreCobrador.Text = dtTTs.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					limpiarCobrador();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarCobrador()
		{
			txtCobrador.Clear();
			txtNombreCobrador.Clear();
		}

		private void txtCobrador_Enter(object sender, EventArgs e)
		{
			oldValue = txtCobrador.Text;
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}


		private bool insertarAplicaciones(DataTable dataTable, DataTable dataTableParc, string cobrador, bool esPorfactura, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			List<string> parametros = new List<string>();
			StringBuilder sQueryParc = new StringBuilder();
			List<string> parametrosParc = new List<string>();
			DataTable dtValid = new DataTable();
			bool OK = true;

			string deleteQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES WHERE Cobrador='" + cobrador + "'";

			OK = Consultas.ejecutarSentencia(deleteQuery, ref error);

			if (OK)
			{
				string deleteQueryParc = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES_PARC WHERE Cobrador='" + cobrador + "'";

				OK = Consultas.ejecutarSentencia(deleteQueryParc, ref error);
			}

			foreach (DataRow row in dataTable.Rows)
			{
				//string validQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES WHERE IdColegiado='" + row["IdColegiado"].ToString() + "' and Cobrador='" + cobrador + "'";

				//if (esPorfactura)
				//	validQuery += " and Documento = '" + row["Documento"].ToString() + "'";

				//OK = Consultas.fillDataTable(validQuery, ref dtValid, ref error);

				//if (OK && dtValid.Rows.Count > 0)
				//{
				//	string deleteQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES WHERE IdColegiado='" + row["IdColegiado"].ToString() + "' and Cobrador='" + cobrador + "'";

				//	if (esPorfactura)
				//		deleteQuery += " and Documento = '" + row["Documento"].ToString() + "'";

				//	OK = Consultas.ejecutarSentencia(deleteQuery, ref error);

				//	if (OK)
				//	{
				//		string deleteParcQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES_PARC WHERE IdColegiado='" + row["IdColegiado"].ToString() + "' and Cobrador='" + cobrador + "' and Documento = '" + row["Documento"].ToString() + "'";

				//		OK = Consultas.ejecutarSentencia(deleteParcQuery, ref error);

				//	}
				//}

				if (OK)
				{
					//foreach (DataRow row in dataTable.Rows)
					//{
					sQuery.Clear();
					parametros.Clear();

					sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES(IdColegiado,Cedula,NumeroColegiado,Cobrador,Monto");
					if (esPorfactura)
						sQuery.AppendLine(",Tipo,Documento,PagosParciales,FechaDocumento,Vendedor)");
					else
						sQuery.AppendLine(")");

					if (esPorfactura)
						sQuery.AppendLine("VALUES (@IdColegiado,@Cedula,@NumeroColegiado,@Cobrador,@Monto,@Tipo,@Documento,@PagosParciales,@FechaDocumento,@Vendedor)");
					else
						sQuery.AppendLine("VALUES (@IdColegiado,@Cedula,@NumeroColegiado,@Cobrador,@Monto)");

					//parametros.Add("@IdColegiado," + idColegiado);
					//parametros.Add("@Cedula," + cedula);
					//parametros.Add("@NumeroColegiado," + numColegiado);
					//parametros.Add("@Cobrador," + cobrador);

					//if (esPorfactura)
					//{
					//	parametros.Add("@Tipo," + tipo);
					//	parametros.Add("@Documento," + documento);
					//	parametros.Add("@NumParcialidades," + numParcialidades);
					//	parametros.Add("@FechaDocumento," + DateTime.Parse(fechaDoc).ToString("yyyy-MM-ddTHH:mm:ss"));
					//}

					//parametros.Add("@Monto," + decimal.Parse(monto));
					parametros.Add("@IdColegiado," + row["IdColegiado"].ToString());
					parametros.Add("@Cedula," + row["Cedula"].ToString());
					parametros.Add("@NumeroColegiado," + row["NumeroColegiado"].ToString());
					parametros.Add("@Cobrador," + cobrador);

					if (esPorfactura)
					{
						parametros.Add("@Tipo," + row["TIPO"].ToString());
						parametros.Add("@Documento," + row["DOCUMENTO"].ToString());
						parametros.Add("@PagosParciales," + row["TIPO_DOC_KOLEGIO"].ToString());
						parametros.Add("@FechaDocumento," + DateTime.Parse(row["FECHA_DOCUMENTO"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						parametros.Add("@Vendedor," + row["VENDEDOR"].ToString());
					}

					parametros.Add("@Monto," + row["SALDO"].ToString());


					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					//}
				}

				if (OK && row["TIPO_DOC_KOLEGIO"].ToString().Equals("S"))
				{
					foreach (DataRow rowParc in dataTableParc.Rows)
					{
						if (row["IdColegiado"].ToString() == rowParc["IdColegiado"].ToString())
						{
							sQueryParc.Clear();
							parametrosParc.Clear();

							sQueryParc.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES_PARC(IdColegiado,Cobrador,Tipo,Documento,Parcialidad,FechaDocumento,Monto)");

							sQueryParc.AppendLine("VALUES (@IdColegiado,@Cobrador,@Tipo,@Documento,@Parcialidad,@FechaDocumento,@Monto)");

							parametrosParc.Add("@IdColegiado," + rowParc["IdColegiado"].ToString());
							parametrosParc.Add("@Cobrador," + cobrador);
							parametrosParc.Add("@Tipo," + rowParc["TIPO"].ToString());
							parametrosParc.Add("@Documento," + rowParc["DOCUMENTO"].ToString());
							parametrosParc.Add("@Parcialidad," + rowParc["PARCIALIDAD"].ToString());
							parametrosParc.Add("@FechaDocumento," + DateTime.Parse(rowParc["FECHA_DOCUMENTO"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
							parametrosParc.Add("@Monto," + rowParc["SALDO"].ToString());


							OK = Consultas.ejecutarSentenciaParametros(sQueryParc.ToString(), parametrosParc, ref error);
						}
					}
				}

				if (!OK)
					break;
			}

			return OK;
		}


		private void txtCodigo_DoubleClick(object sender, EventArgs e)
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
			if (txtCodigo.Text.Trim().Equals(""))
			{
				txtDesc.Clear();
			}
			else
			{
				if (oldValue != txtCodigo.Text)
				{
					cargarPlantilla(txtCodigo.Text);
					if (txtCodigo.Text.Trim() == "")
						MessageBox.Show("La plantilla digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void listaPlantillas()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "Codigo as Código,Nombre,Cobrador";
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
				}
				else
				{
					limpiarPlantillas();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarPlantillas()
		{
			txtCodigo.Clear();
			txtDesc.Clear();
			txtCobrador.Clear();
		}

		private void txtCodigo_Enter(object sender, EventArgs e)
		{
			oldValue = txtCodigo.Text;
		}
	}
}
