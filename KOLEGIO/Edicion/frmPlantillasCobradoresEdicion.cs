using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmPlantillasCobradoresEdicion : frmEdicion
	{
		private string oldValue = "";

		public frmPlantillasCobradoresEdicion(List<string> valoresPk)
			 : base(valoresPk)
		{
			InitializeComponent();
			cargarDatos();
		}

		protected override void initInstance()
		{
			try
			{
				listar.TITULO_LISTADO = "Plantillas Cobradores";
				lblPerfil.Text = "Perfil de Plantilla";

				//listar.COLUMNAS = "Nombre,Cobrador,Tipo,AsignacionCobro,Conectividad,Par";
				//listar.COLUMNAS = "Nombre,Cobrador,Tipo,Conectividad,Par,Bac,PlantillaRespuesta,SubtipoRec";
				//listar.COLUMNAS = "Nombre,Cobrador,Tipo,Conectividad,Par,Bac,PlantillaRespuesta,SubtipoRec,CerosEnMonto";
				listar.COLUMNAS = "Codigo,Nombre,Cobrador,Tipo,PlantillaRespuesta,SubtipoRec,CerosEnMonto,SumarArreglo,ArregloPorDocumento,RubroColegiatura,RubroRegencia,TipoIdentificacion,Proyeccion,ListadoPorFac,GenerarPor,ConTab,SeparadorCsv,FormatoInicioLinea,RubroPerito,RubroAerea,RubroPlaguicida,TotalRegistro,TotalMonto,CeroInicialCedula,ConEncabezado, NombreArchivo, CodigoEntidad";
				listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
				listar.TABLA = "NV_PLANTILLA_COBRADOR";

				//COLUMNAS PRIMARY KEY
				listar.COLUMNAS_PK.Add("Codigo");
				listar.COLUMNAS_IDENTITY_PK.Add("Codigo");
				listar.VALORES_PK = valoresPk;
				armarFiltroPK(valoresPk);
				identificadorFormulario = "De Plantillas Cobrador";

				insertar = Constantes.PLANTILLA_COBRADORES_INSERTAR;
				editar = Constantes.PLANTILLA_CCOBRADORES_EDITAR;
				borrar = Constantes.PLANTILLA_COBRADORES_BORRAR;
				seleccionar = Constantes.PLANTILLA_COBRADORES_SELECCIONAR;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un error inicializando la instancia.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected override void cargarDatos()
		{
			try
			{
				tabControl.TabPages.Remove(tpAdjuntos);
				tabControl.TabPages.Remove(tpAdmin);
				tabControl.TabPages.Add(tpAdmin);

				txtCodigo.ReadOnly = true;
				rbXLS.Checked = true;
				//rbAMBAS.Checked = true;

				if (valoresPk.Count > 0)
				{
					if (Consultas.listarDatos(listar, ref dtDatos, ref error))
					{
						if (dtDatos.Rows.Count > 0)
						{
							foreach (DataRow row in dtDatos.Rows)
							{
								txtCodigo.Valor = row["Codigo"].ToString();
								txtNombre.Valor = row["Nombre"].ToString();
								txtCobrador.Valor = row["Cobrador"].ToString();
								cargarCobrador(txtCobrador.Valor);
								txtSubTipoDoc.Valor = row["SubtipoRec"].ToString();
								cargarSubTipo(txtSubTipoDoc.Valor);
								if (row["Tipo"].ToString() == "XLS")
								{
									rbXLS.Checked = true;
									rbTXT.Checked = false;
									rbCSV.Checked = false;
								}
								else
								{
									if (row["Tipo"].ToString() == "TXT")
									{
										rbTXT.Checked = true;
										rbXLS.Checked = false;
										rbCSV.Checked = false;
										dgvPlantilla.Columns["colCaracteres"].Visible = true;
										dgvPlantilla.Columns["colColumna"].Visible = true;
										dgvPlantilla.Columns["colTamColumna"].Visible = true;
									}
									else
									{
										rbCSV.Checked = true;
										rbTXT.Checked = false;
										rbXLS.Checked = false;
									}

								}

								//if (row["AsignacionCobro"].ToString() == "C")
								//{
								//    rbCOL.Checked = true;
								//    rbREG.Checked = false;
								//    rbAMBAS.Checked = false;
								//}
								//else
								//{
								//    if (row["AsignacionCobro"].ToString() == "R")
								//    {
								//        rbREG.Checked = true;
								//        rbCOL.Checked = false;
								//        rbAMBAS.Checked = false;
								//    }
								//    else
								//    {
								//        rbAMBAS.Checked = true;
								//        rbCOL.Checked = false;
								//        rbREG.Checked = false;
								//    }

								//}

								//if (row["Conectividad"].ToString() == "S")
								//    chkConectividad.Checked = true;

								//if (row["Par"].ToString() == "S")
								//    chkPar.Checked = true;

								//if (row["Bac"].ToString() == "S")
								//    chkBac.Checked = true;

								if (row["PlantillaRespuesta"].ToString() == "I")
								{
									rbIGUAL.Checked = true;
									rbPREDEF.Checked = false;
								}
								else
								{
									rbPREDEF.Checked = true;
									rbIGUAL.Checked = false;
								}

								if (row["CerosEnMonto"].ToString() == "S")
									chkIngresaCerosAdelante.Checked = true;

								if (row["SumarArreglo"].ToString() == "S")
								{
									rbAPagoSumar.Checked = true;
									rbAPagoPorDoc.Checked = false;
								}
								else if (row["ArregloPorDocumento"].ToString() == "S")
								{
									rbAPagoPorDoc.Checked = true;
									rbAPagoSumar.Checked = false;
								}

								if (row["RubroColegiatura"].ToString() == "S")
									chkRubroCOL.Checked = true;

								if (row["RubroRegencia"].ToString() == "S")
									chkRubroREG.Checked = true;

								if (row["RubroPerito"].ToString() == "S")
									chkRubroPER.Checked = true;

								if (row["RubroAerea"].ToString() == "S")
									chkRubroAEREA.Checked = true;

								if (row["RubroPlaguicida"].ToString() == "S")
									chkRubroPLAGUI.Checked = true;

								if (row["TipoIdentificacion"].ToString() == "C")
								{
									rbRespCedula.Checked = true;
									rbRespNumCole.Checked = false;
								}
								else if (row["TipoIdentificacion"].ToString() == "N")
								{
									rbRespNumCole.Checked = true;
									rbRespCedula.Checked = false;
								}

								if (rbPREDEF.Checked)
								{
									grbTipoIdentificacion.Visible = true;
								}

								if (row["Proyeccion"].ToString() == "S")
									chkProyeccion.Checked = true;

								if (row["ListadoPorFac"].ToString() == "S")
									chkListadoArchFactura.Checked = true;

								if (row["GenerarPor"].ToString() == "T")
								{
									rbTotal.Checked = true;
									rbCobrador.Checked = false;
								}
								else
								{
									rbCobrador.Checked = true;
									rbTotal.Checked = false;
								}

								if (row["ConTab"].ToString() == "S")
									chkConTab.Checked = true;

								if (rbCSV.Checked)
									grbSeparadorCsv.Visible = true;

								if (row["TotalRegistro"].ToString() == "S")
									chkTotalReg.Checked = true;

								if (row["TotalMonto"].ToString() == "S")
									chkTotalMonto.Checked = true;

								if (row["CeroInicialCedula"].ToString() == "S")
									chkCeroCedula.Checked = true;

								if (row["ConEncabezado"].ToString() == "S")
									chkDetEncabezado.Checked = true;

								rbSeparadorComa.Checked = row["SeparadorCsv"].ToString().Equals(",") ? true : false;

								rbSeparadorPuntoComa.Checked = row["SeparadorCsv"].ToString().Equals(";") ? true : false;

								txtFormatoInicioLinea.Valor = row["FormatoInicioLinea"].ToString();
                                txtNombreArchivo.Valor = row["NombreArchivo"].ToString();
                                txtCodigoEntidad.Valor = row["CodigoEntidad"].ToString();

                                deshabilitarLlave();
								cargarDetalle();
							}
						}
					}
					else
						MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected override bool llenarParametros()
		{
			dgvPlantilla.EndEdit();
			parametros.Clear();
			//parametros.Add(txtCodigo.Valor);
			parametros.Add(txtNombre.Valor);
			parametros.Add(txtCobrador.Valor);
			if (rbXLS.Checked)
			{
				parametros.Add("XLS");
			}
			else
			{
				if (rbTXT.Checked)
				{
					parametros.Add("TXT");
				}
				else
				{
					parametros.Add("CSV");
				}
			}

			//if (rbCOL.Checked)
			//{
			//    parametros.Add("C");
			//}
			//else
			//{
			//    if (rbREG.Checked)
			//    {
			//        parametros.Add("R");
			//    }
			//    else
			//    {
			//        parametros.Add("A");
			//    }
			//}

			//if (chkConectividad.Checked)
			//    parametros.Add("S");
			//else
			//    parametros.Add("N");

			//if (chkPar.Checked)
			//    parametros.Add("S");
			//else
			//    parametros.Add("N");

			//if (chkBac.Checked)
			//    parametros.Add("S");
			//else
			//    parametros.Add("N");

			if (rbIGUAL.Checked)
				parametros.Add("I");
			else
				parametros.Add("P");

			parametros.Add(txtSubTipoDoc.Valor);

			if (chkIngresaCerosAdelante.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (rbAPagoSumar.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (rbAPagoPorDoc.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkRubroCOL.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkRubroREG.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (rbRespCedula.Checked)
				parametros.Add("C");
			else if (rbRespNumCole.Checked)
				parametros.Add("N");
			else
				parametros.Add("null");

			if (chkProyeccion.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkListadoArchFactura.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (rbTotal.Checked)
				parametros.Add("T");
			else if (rbCobrador.Checked)
				parametros.Add("C");
			else
				parametros.Add("null");

			if (chkConTab.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			parametros.Add(rbSeparadorComa.Checked ? "," : ";");

			parametros.Add(txtFormatoInicioLinea.Valor);

			if (chkRubroPER.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkRubroAEREA.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkRubroPLAGUI.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkTotalReg.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkTotalMonto.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkCeroCedula.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			if (chkDetEncabezado.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

            parametros.Add(txtNombreArchivo.Valor);
            parametros.Add(txtCodigoEntidad.Valor);

            return true;
		}

		protected override bool validarDatos(ref string error)
		{
			if (txtNombre.Valor.Trim() == "")
			{
				error = "Debe especificar un Nombre para la plantilla del cobrador.";
				txtNombre.Focus();
				return false;
			}

			if (txtCobrador.Valor.Trim() == "")
			{
				error = "Debe especificar un cobrador para la plantilla.";
				txtNombre.Focus();
				return false;
			}

			if (txtSubTipoDoc.Valor.Trim() == "")
			{
				error = "Debe especificar un subtipo de recibo para la plantilla.";
				txtSubTipoDoc.Focus();
				return false;
			}

			if (!rbAPagoSumar.Checked && !rbAPagoPorDoc.Checked)
			{
				error = "Debe especificar la forma de generar el arreglo de pago.";
				//txtSubTipoDoc.Focus();
				return false;
			}

			if (!chkRubroCOL.Checked && !chkRubroREG.Checked && !chkRubroAEREA.Checked && !chkRubroPER.Checked && !chkRubroPLAGUI.Checked)
			{
				error = "Debe especificar el rubro para la generación.";
				//txtSubTipoDoc.Focus();
				return false;
			}

			foreach (DataGridViewRow row in dgvPlantilla.Rows)
			{
				//if(row.Cells["colColumna"].Value.ToString()=="")
				//{
				//    error = "El campo Columna en la fila " + (row.Index + 1) + " no puede ser vacío.";
				//    return false;
				//}

				//if (row.Cells["colCaracteres"].Value.ToString() == "")
				//{
				//    error = "El campo Caracteres en la fila " + (row.Index + 1) + " no puede ser vacío.";
				//    return false;
				//}

				if (row.Cells["colMacro"].Value.ToString() == "FECHA")
				{
					if (validarDetalle(row.Cells["colDetalle"].Value.ToString()))
					{
						error = "El nombre del detalle de la Macro Fecha no puede ser igual.";
						return false;
					}
				}

				if ((row.Cells["colMacro"].Value.ToString() == "NUMERO_FACTURA"
					|| row.Cells["colMacro"].Value.ToString() == "APLICACION"
					|| row.Cells["colMacro"].Value.ToString() == "FECHA_FACTURA"
					|| row.Cells["colMacro"].Value.ToString() == "VENCIMIENTO_FACTURA") && !chkListadoArchFactura.Checked)
				{
					error = "Debe activar la opcion de listado por factura, debido a que se agrego un dato de factura a la plantilla.";
					return false;
				}

				if (rbTXT.Checked)
				{
					if (row.Cells["colCaracteres"].Value.ToString() == "")
					{
						error = "El campo Caracteres en la fila " + (row.Index + 1) + " no puede ser vacío.";
						return false;
					}

					//if (string.IsNullOrEmpty(row.Cells["colTamColumna"].Value.ToString()))
					//{
					//    error = "El campo Tamaño de columna en la fila " + (row.Index + 1) + " no puede ser vacío.";
					//    return false;
					//}

					if (!CeldaEsNull(row.Cells["colTamColumna"]))
					{
						if (!row.Cells["colTamColumna"].Value.ToString().Equals(""))
						{
							if (int.Parse(row.Cells["colTamColumna"].Value.ToString()) < int.Parse(row.Cells["colCaracteres"].Value.ToString()))
							{
								MessageBox.Show("El valor del tamaño de la columna debe ser mayor al de los caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return false;
								//dgvPlantilla.CurrentCell.Value = int.Parse(dgvPlantilla.Rows[e.RowIndex].Cells["colCaracteres"].Value.ToString()) + 1;
							}
						}
					}


				}

				if (row.Cells["colOrden"].Value.ToString() == "")
				{
					error = "El campo Orden en la fila " + (row.Index + 1) + " no puede ser vacío.";
					return false;
				}
				if (row.Cells["colFormato"].Value == null)
				{
					if (row.Cells["colMacro"].Value.ToString() != "CONSTANTE")
					{
						error = "El campo Formato en la fila " + (row.Index + 1) + " no puede ser vacío.";
						return false;
					}
				}
				else
				{
					if (row.Cells["colFormato"].Value.Equals("") && row.Cells["colMacro"].Value.ToString() != "CONSTANTE")
					{
						error = "El campo Formato en la fila " + (row.Index + 1) + " no puede ser vacío.";
						return false;
					}
				}

			}

			return true;
		}

		private bool validarDetalle(string detalle)
		{
			int duplicados = 0;
			foreach (DataGridViewRow r in dgvPlantilla.Rows)
			{
				if (r.Cells["colDetalle"].Value.ToString().Equals(detalle))
				{
					duplicados++;
				}
			}

			if (duplicados > 1)
				return true;
			else
				return false;
		}

		protected override void limpiarFormulario()
		{

			txtCodigo.Clear();
			txtNombre.Clear();
			txtCobrador.Clear();
			txtCobrador.ReadOnly = false;
			txtCobradorNombre.Clear();
			txtSubTipoDoc.Clear();
			txtSubTipoDocNombre.Clear();
			dgvPlantilla.Rows.Clear();
			rbXLS.Checked = true;
			rbTXT.Checked = false;
			rbCSV.Checked = false;
			rbIGUAL.Checked = true;
			rbPREDEF.Checked = false;
			rbAPagoSumar.Checked = true;
			rbAPagoPorDoc.Checked = false;
			chkRubroCOL.Checked = false;
			chkRubroREG.Checked = false;
			grbTipoIdentificacion.Visible = false;
			rbRespCedula.Checked = false;
			rbRespNumCole.Checked = false;
			chkProyeccion.Checked = false;
			chkListadoArchFactura.Checked = false;
			chkTotalReg.Checked = false;
			chkTotalMonto.Checked = false;
			chkCeroCedula.Checked = false;
			chkDetEncabezado.Checked = false;
			listar.VALORES_PK.Clear();
			lblPerfil.Text = "Perfil de Plantilla";
		}

		protected override void deshabilitarLlave()
		{
			listar.VALORES_PK.Clear();
			listar.VALORES_PK.Add(txtCodigo.Valor);
			txtCodigo.ReadOnly = true;
			armarFiltroPK(listar.VALORES_PK);
			lblPerfil.Text = "Perfil de Plantilla: " + txtNombre.Valor;
		}

		private void btnNuevaFila_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PLANTILLA_COBRADORES))
			{
				if (rbCSV.Checked == true)
					dgvPlantilla.Rows.Add("", "", "", "", "", "", "");
				else
					dgvPlantilla.Rows.Add("", "", "", "", "", "", "");
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnEliminarFila_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PLANTILLA_COBRADORES_BORRAR))
			{
				if (dgvPlantilla.RowCount > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
							  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						dgvPlantilla.Rows.Remove(dgvPlantilla.CurrentCell.OwningRow);
						btnGuardar.Enabled = true;
						btnGuardarSalir.Enabled = true;
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		protected override bool guardarDetalle(ref string error)
		{
			Listado list = new Listado();
			list.COLUMNAS = "Codigo,Columna,Orden,Caracteres,TamColumna,Detalle,Macro,Formato";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_PLANTILLA_COBRADOR_DETALLE";
			bool lbOk = true;
			try
			{
				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_PLANTILLA_COBRADOR_DETALLE WHERE Codigo='" + txtCodigo.Valor + "'";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				if (lbOk)
				{
					foreach (DataGridViewRow row in dgvPlantilla.Rows)
					{
						parametros.Clear();
						list.COLUMNAS_PK.Clear();
						list.COLUMNAS_PK.Add("Codigo");
						list.COLUMNAS_PK.Add("Orden");
						parametros.Add(txtCodigo.Valor);

						if (rbTXT.Checked && row.Cells["colColumna"].Value.ToString() != "")
							parametros.Add(int.Parse(row.Cells["colColumna"].Value.ToString()) + "");
						else
							parametros.Add("null");

						parametros.Add(int.Parse(row.Cells["colOrden"].Value.ToString()) + "");

						if (rbTXT.Checked && row.Cells["colCaracteres"].Value.ToString() != "")
							parametros.Add(int.Parse(row.Cells["colCaracteres"].Value.ToString()) + "");
						else
							parametros.Add("null");

						if (rbTXT.Checked && !CeldaEsNull(row.Cells["colTamColumna"]))
						{
							if (rbTXT.Checked && row.Cells["colTamColumna"].Value.ToString() != "")
								parametros.Add(int.Parse(row.Cells["colTamColumna"].Value.ToString()) + "");
							else
								parametros.Add("null");
						}
						else
							parametros.Add("null");



						parametros.Add(row.Cells["colDetalle"].Value.ToString());
						parametros.Add(row.Cells["colMacro"].Value.ToString());
						if (row.Cells["colFormato"].Value == null)
							parametros.Add("");
						else
							parametros.Add(row.Cells["colFormato"].Value.ToString());
						lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

					}
				}
			}
			catch (Exception ex)
			{
				error = ex.Message;
				return false;
			}
			return lbOk;

		}

		protected override bool eliminarDetalle(ref string error)
		{
			bool lbOk = true;
			if (valoresPk.Count > 0)
			{

				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_PLANTILLA_COBRADOR_DETALLE WHERE Codigo ='" + txtCodigo.Text + "'";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
			}
			return lbOk;
		}

		private void cargarDetalle()
		{
			string sQuery = "SELECT Columna,Orden,Caracteres,TamColumna,Detalle,Macro,Formato FROM " + Consultas.sqlCon.COMPAÑIA +
				".NV_PLANTILLA_COBRADOR_DETALLE WHERE Codigo='" + txtCodigo.Valor + "' order by orden";

			DataTable dtDetalle = new DataTable();
			if (Consultas.fillDataTable(sQuery, ref dtDetalle, ref error))
			{
				foreach (DataRow row in dtDetalle.Rows)
				{
					dgvPlantilla.Rows.Add(int.Parse(row["Orden"].ToString()), row["Columna"].ToString() != "" ? row["Columna"].ToString() : "",
						row["Caracteres"].ToString() != "" ? row["Caracteres"].ToString() : "", row["TamColumna"].ToString() != "" ? row["TamColumna"].ToString() : "", row["Detalle"].ToString(), row["Macro"].ToString(), row["Formato"].ToString());
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private bool CeldaEsNull(DataGridViewCell celda)
		{
			return celda.Value == null || celda.Value == DBNull.Value || String.IsNullOrWhiteSpace(celda.Value.ToString());
		}

		private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCobrador.ReadOnly)
			{
				listaCobradores();
			}
		}

		private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCobrador.ReadOnly)
			{
				listaCobradores();
			}
		}

		private void txtCobrador_Enter(object sender, EventArgs e)
		{
			oldValue = txtCobrador.Valor;
		}

		private void txtCobrador_Leave(object sender, EventArgs e)
		{
			if (txtCobrador.Valor.Trim().Equals(""))
			{
				txtCobradorNombre.Clear();
			}
			else
			{
				if (oldValue != txtCobrador.Valor)
				{
					cargarCobrador(txtCobrador.Valor);
					if (txtCobrador.Valor.Trim() == "")
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
				txtCobrador.Valor = f1.item.SubItems[0].Text;
				txtCobradorNombre.Valor = f1.item.SubItems[1].Text;
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

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCobrador.Valor = dtTTs.Rows[0]["COBRADOR"].ToString();
					txtCobradorNombre.Valor = dtTTs.Rows[0]["NOMBRE"].ToString();
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
			txtCobradorNombre.Clear();
		}

		private void listaSubtipos()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "SUBTIPO as Código,DESCRIPCION as Descripcion";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "SUBTIPO_DOC_CC";
			listD.FILTRO = "where TIPO = 'REC'";
			listD.TITULO_LISTADO = "Subtipos de Recibo";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtSubTipoDoc.Valor = f1.item.SubItems[0].Text;
				txtSubTipoDocNombre.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarSubTipo(string sub)
		{
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
					limpiarSubTipo();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarSubTipo()
		{
			txtSubTipoDoc.Clear();
			txtSubTipoDocNombre.Clear();
		}

		private void rbCSV_MouseClick(object sender, MouseEventArgs e)
		{
			//foreach (DataGridViewRow row in dgvPlantilla.Rows)
			//{
			//    row.Cells["colColumna"].Value = "";
			//    row.Cells["colCaracteres"].Value = "";
			//    row.Cells["colTamColumna"].Value = "";
			//}
			dgvPlantilla.Columns["colCaracteres"].Visible = false;
			dgvPlantilla.Columns["colColumna"].Visible = false;
			dgvPlantilla.Columns["colTamColumna"].Visible = false;
		}

		private void rbXLS_MouseClick(object sender, MouseEventArgs e)
		{
			//foreach (DataGridViewRow row in dgvPlantilla.Rows)
			//{
			//    row.Cells["colColumna"].Value = "";
			//    row.Cells["colCaracteres"].Value = "";
			//    row.Cells["colTamColumna"].Value = "";
			//}
			dgvPlantilla.Columns["colCaracteres"].Visible = false;
			dgvPlantilla.Columns["colColumna"].Visible = false;
			dgvPlantilla.Columns["colTamColumna"].Visible = false;
		}

		private void rbTXT_MouseClick(object sender, MouseEventArgs e)
		{
			dgvPlantilla.Columns["colCaracteres"].Visible = true;
			dgvPlantilla.Columns["colColumna"].Visible = true;
			dgvPlantilla.Columns["colTamColumna"].Visible = true;
		}

		private bool validarFormatoFecha(string formato, string macro)
		{
			if (macro == "VENCIMIENTO_TARJETA")
			{
				if (formato == "MM/yyyy")
					return true;

				if (formato == "MMyyyy")
					return true;

				if (formato == "MM-yyyy")
					return true;
			}

			if (macro == "VENCIMIENTO_FACTURA")
			{
				if (formato == "dd/MM/yyyy" || formato == "yyyy/MM/dd")
					return true;

				if (formato == "ddMMyyyy" || formato == "yyyyMMdd")
					return true;

				if (formato == "dd-MM-yyyy" || formato == "yyyy-MM-dd")
					return true;
			}

			if (macro == "FECHA")
			{
				if (formato == "dd/MM/yyyy" || formato == "15/MM/yyyy")
					return true;

				if (formato == "dd-MM-yyyy" || formato == "yyyy-MM-dd" || formato == "15-MM-yyyy")
					return true;

				if (formato == "ddMMyyyy" || formato == "15MMyyyy")
					return true;

				if (formato == "yyyyMMdd" || formato == "yyyyMM15")
					return true;

				if (formato == "MM/yyyy")
					return true;

				if (formato == "yyyyMM")
					return true;
			}

			if (macro == "FECHA_INICIO_MES")
			{
				if (formato == "dd/MM/yyyy" || formato == "dd-MM-yyyy")
					return true;

				if (formato == "ddMMyyyy")
					return true;

				if (formato == "yyyyMMdd")
					return true;

				if (formato == "yyyy/MM/dd" || formato == "yyyy-MM-dd")
					return true;
			}

			if (macro == "FECHA_FIN_MES")
			{
				if (formato == "dd/MM/yyyy" || formato == "dd-MM-yyyy")
					return true;

				if (formato == "ddMMyyyy")
					return true;

				if (formato == "yyyyMMdd")
					return true;

				if (formato == "yyyy/MM/dd" || formato == "yyyy-MM-dd")
					return true;
			}

			return false;
		}

		private void dgvPlantilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvPlantilla.CurrentCell.OwningColumn.Name == "colFormato")
			{
				if (dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString() == "VENCIMIENTO_TARJETA")
				{
					if (!validarFormatoFecha(dgvPlantilla.CurrentCell.Value.ToString(), dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString()))
					{
						MessageBox.Show("Los formatos permitidos son [MM/yyyy--MM-yyyy--MMyyyy].", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvPlantilla.CurrentCell.Value = "";
					}
				}

				if (dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString() == "VENCIMIENTO_FACTURA")
				{
					if (!validarFormatoFecha(dgvPlantilla.CurrentCell.Value.ToString(), dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString()))
					{
						MessageBox.Show("Los formatos permitidos son [dd/MM/yyyy--dd-MM-yyyy--ddMMyyyy--yyyy-MM-dd--yyyy/MM/dd--yyyyMMdd].", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvPlantilla.CurrentCell.Value = "";
					}
				}

				if (dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString() == "FECHA")
				{
					if (!validarFormatoFecha(dgvPlantilla.CurrentCell.Value.ToString(), dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString()))
					{
						MessageBox.Show("Los formatos permitidos son [dd/MM/yyyy--dd-MM-yyyy--ddMMyyyy--yyyyMMdd--15/MM/yyyy--15-MM-yyyy--15MMyyyy--yyyyMM15--MM/yyyy--yyyyMM].", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvPlantilla.CurrentCell.Value = "";
					}
				}

				if (dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString() == "FECHA_INICIO_MES")
				{
					if (!validarFormatoFecha(dgvPlantilla.CurrentCell.Value.ToString(), dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString()))
					{
						MessageBox.Show("Los formatos permitidos son [dd/MM/yyyy--dd-MM-yyyy--ddMMyyyy--yyyyMMdd--yyyy-MM-dd--yyyy/MM/dd].", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvPlantilla.CurrentCell.Value = "";
					}
				}

				if (dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString() == "FECHA_FIN_MES")
				{
					if (!validarFormatoFecha(dgvPlantilla.CurrentCell.Value.ToString(), dgvPlantilla.Rows[e.RowIndex].Cells["colMacro"].Value.ToString()))
					{
						MessageBox.Show("Los formatos permitidos son [dd/MM/yyyy--dd-MM-yyyy--ddMMyyyy--yyyyMMdd--yyyy-MM-dd--yyyy/MM/dd].", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvPlantilla.CurrentCell.Value = "";
					}
				}
			}

			//if (dgvPlantilla.CurrentCell.OwningColumn.Name == "colTamColumna")
			//{
			//    if (dgvPlantilla.CurrentCell.Value.ToString() != "")
			//    {
			//        if (int.Parse(dgvPlantilla.CurrentCell.Value.ToString()) < int.Parse(dgvPlantilla.Rows[e.RowIndex].Cells["colCaracteres"].Value.ToString()))
			//        {
			//            MessageBox.Show("El valor del tamaño de la columna debe ser mayor al de los caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//            dgvPlantilla.CurrentCell.Value = int.Parse(dgvPlantilla.Rows[e.RowIndex].Cells["colCaracteres"].Value.ToString()) + 1;
			//        }
			//    }
			//}

			//    if (dgvPlantilla.CurrentCell.Value == null)
			//        dgvPlantilla.CurrentCell.Value = "";

			//    if (dgvPlantilla.CurrentCell.OwningColumn.Name == "colCaracteres")
			//    {
			//        if (!Utilitario.EsNumeroMayorCero(dgvPlantilla.CurrentCell.Value.ToString()))
			//        {
			//            MessageBox.Show("La cantidad de caracteres debe ser un valor númerico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//            dgvPlantilla.CurrentCell.Value = 1;
			//        }
			//    }

			//    if (dgvPlantilla.CurrentCell.OwningColumn.Name == "colOrden")
			//    {
			//        string columna = "";
			//        foreach(DataGridViewRow row in dgvPlantilla.Rows)
			//        {

			//        }
			//    }


			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void dgvPlantilla_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvPlantilla.IsCurrentCellDirty)
			{
				dgvPlantilla.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void txtSubTipoDoc_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtSubTipoDoc.ReadOnly)
			{
				listaSubtipos();
			}
		}

		private void txtSubTipoDoc_Leave(object sender, EventArgs e)
		{
			if (txtSubTipoDoc.Valor.Trim().Equals(""))
			{
				txtSubTipoDocNombre.Clear();
			}
			else
			{
				if (oldValue != txtSubTipoDoc.Valor)
				{
					cargarSubTipo(txtSubTipoDoc.Valor);
					if (txtSubTipoDoc.Valor.Trim() == "")
						MessageBox.Show("El Subtipo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtSubTipoDoc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtSubTipoDoc.ReadOnly)
			{
				listaSubtipos();
			}
		}

		private void txtSubTipoDoc_Enter(object sender, EventArgs e)
		{
			oldValue = txtSubTipoDoc.Valor;
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void chkIngresaCerosAdelante_Load(object sender, EventArgs e)
		{

		}

		private void rbPREDEF_MouseClick(object sender, MouseEventArgs e)
		{
			if (rbPREDEF.Checked)
				grbTipoIdentificacion.Visible = true;
			//else
			//    grbTipoIdentificacion.Visible = false;
		}

		private void rbIGUAL_MouseClick(object sender, MouseEventArgs e)
		{
			if (rbIGUAL.Checked)
				grbTipoIdentificacion.Visible = false;
			//else
			//    grbTipoIdentificacion.Visible = true;
		}

		private void rbCSV_Click(object sender, EventArgs e)
		{
			if (rbCSV.Checked)
			{
				grbSeparadorCsv.Visible = true;
			}
			else
			{
				grbSeparadorCsv.Visible = false;
			}
		}
	}
}
