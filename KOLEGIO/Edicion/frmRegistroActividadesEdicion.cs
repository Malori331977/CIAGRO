using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ExcelInterop = Microsoft.Office.Interop.Excel;

namespace KOLEGIO.Edicion
{
	public partial class frmRegistroActividadesEdicion : Form
	{
		private DataTable dtData = new DataTable();
		private BindingSource source = new BindingSource();

		public frmRegistroActividadesEdicion()
		{
			InitializeComponent();
			//dgvColegiados.Columns.Clear();
			//dtData.Columns.Add("Id", typeof(String));
			//dtData.Columns.Add("Codigo registro", typeof(String));
			//dtData.Columns.Add("Registro", typeof(String));
			//dtData.Columns.Add("Codigo actividad", typeof(String));
			//dtData.Columns.Add("Actividad", typeof(String));
			//dtData.Columns.Add("Duración", typeof(DateTime));
			//dtData.Columns.Add("Fecha", typeof(DateTime));
			//dtData.Columns.Add("Observaciones", typeof(String));
			cargarActividades();
		}

		private void frmRegistroActividadesEdicion_Load(object sender, EventArgs e)
		{
			dtpDuracion.Format = DateTimePickerFormat.Custom;
			dtpDuracion.CustomFormat = "HH:mm";
			dtpDuracion.Value = DateTime.Now.Date;

			rbColegiado.Checked = true;
		}


		#region Eventos
		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			limpiarData();
			cargarActividades();
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
				generarExcel();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un error en la exportación de datos a excel: " + ex.Message, "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			Cursor.Current = Cursors.Default;
		}

		private void btnResize_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			dgvColegiados.AutoResizeColumns();
			Cursor.Current = Cursors.Default;
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtIdentificacion_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (rbColegiado.Checked)
			{
				listaColegiados();
			}

			if (rbEstablecimiento.Checked)
			{
				listaEstablecimiento();
			}

			if (rbConsultora.Checked)
			{
				listaConsultoras();
			}
		}

		private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtIdentificacion.ReadOnly)
			{
				if (rbColegiado.Checked)
				{
					listaColegiados();
				}

				if (rbEstablecimiento.Checked)
				{
					listaEstablecimiento();
				}

				if (rbConsultora.Checked)
				{
					listaConsultoras();
				}
			}
		}

		private void txtActividad_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtActividad.ReadOnly)
			{
				listaActividades();
			}
		}

		private void txtActividad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtActividad.ReadOnly)
			{
				listaActividades();
			}
		}

		private void txtFiltro_TextChanged(object sender, EventArgs e)
		{
			if (dgvColegiados.Rows.Count > 0)
			{
				if (!txtFiltro.Text.Equals(""))
				{
					//BindingSource bs = new BindingSource();
					//bs.DataSource = dgvColegiados.DataSource;
					//bs.Filter = dgvColegiados.Columns[1].HeaderText.ToString() + " like '%" + txtFiltro.Text + "%' or " + dgvColegiados.Columns[2].HeaderText.ToString() + " like '%" + txtFiltro.Text + "%' or " + dgvColegiados.Columns[3].HeaderText.ToString() + " like '%" + txtFiltro.Text + "%' or " + dgvColegiados.Columns[4].HeaderText.ToString() + " like '%" + txtFiltro.Text + "%' or " + dgvColegiados.Columns[7].HeaderText.ToString() + " like '%" + txtFiltro.Text + "%'";
					//dgvColegiados.DataSource = bs;
					foreach (DataGridViewRow r in dgvColegiados.Rows)
					{
						if (
							(r.Cells[1].Value).ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
							(r.Cells[2].Value).ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
							(r.Cells[3].Value).ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
							(r.Cells[4].Value).ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
							(r.Cells[7].Value).ToString().ToUpper().Contains(txtFiltro.Text.ToUpper())
							)
						{
							dgvColegiados.Rows[r.Index].Visible = true;
							//dgvColegiados.Rows[r.Index].Selected = true;
						}
						else
						{
							dgvColegiados.CurrentCell = null;
							dgvColegiados.Rows[r.Index].Visible = false;
						}
					}
				}
				else
				{
					foreach (DataGridViewRow r in dgvColegiados.Rows)
					{
						dgvColegiados.Rows[r.Index].Visible = true;
					}
				}
			}
			else
			{
				MessageBox.Show("No hay información para filtrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtFiltro.Clear();
			}
		}

		private void btnAgregarActividad_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, Constantes.REG_ACTIVIDADES_INSERTAR))
			{
				string error = "";

			dgvColegiados.Rows.Add(dgvColegiados.RowCount + 1, txtIdentificacion.Text, txtIdentificacionDesc.Text, 
				txtActividad.Text, txtActividadDesc.Text, dtpDuracion.Value.ToString("HH:mm"), dtpFecha.Value.ToString("dd/MM/yyyy"), rtbObservacion.Text);


			guardarActividades(ref error);

			limpiarData();

			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnEliminarActividades_Click(object sender, EventArgs e)
		{
			string error = string.Empty;
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REG_ACTIVIDADES_BORRAR))
			{
				if (dgvColegiados.Rows.Count > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
							  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ACTIVIDADES WHERE Id ='" + dgvColegiados.CurrentCell.OwningRow.Cells["colId"].Value.ToString() + "'";
						if (Consultas.ejecutarSentencia(sQuery, ref error))
						{
							cargarActividades();
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnEditarActividades_Click(object sender, EventArgs e)
		{

			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REG_ACTIVIDADES_EDITAR))
			{
				if (dgvColegiados.RowCount > 0)
				{
					//cargarPuesto(dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colCodigoPuesto"].Value.ToString());
					txtIdentificacion.Text = dgvColegiados.CurrentCell.OwningRow.Cells["colIdRegistro"].Value.ToString();
					txtIdentificacionDesc.Text = dgvColegiados.CurrentCell.OwningRow.Cells["colRegistro"].Value.ToString();
					txtActividad.Text = dgvColegiados.CurrentCell.OwningRow.Cells["colIdActividad"].Value.ToString();
					txtActividadDesc.Text = dgvColegiados.CurrentCell.OwningRow.Cells["colActividad"].Value.ToString();
					rtbObservacion.Text = dgvColegiados.CurrentCell.OwningRow.Cells["colObservaciones"].Value.ToString();
					if (!dgvColegiados.CurrentCell.OwningRow.Cells["colDuracion"].Value.ToString().Equals(""))
						dtpDuracion.Value = DateTime.Parse(dgvColegiados.CurrentCell.OwningRow.Cells["colDuracion"].Value.ToString());
					if (!dgvColegiados.CurrentCell.OwningRow.Cells["colFecha"].Value.ToString().Equals(""))
						dtpFecha.Value = DateTime.Parse(dgvColegiados.CurrentCell.OwningRow.Cells["colFecha"].Value.ToString());

					dgvColegiados.Rows.Remove(dgvColegiados.CurrentCell.OwningRow);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		#endregion

		#region Cargar combos
		private void listaColegiados()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "IdColegiado, NumeroColegiado as Código, Nombre";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "NV_COLEGIADO";
			listD.TITULO_LISTADO = "Colegiados";
			listD.COLUMNAS_OCULTAS.Add("IdColegiado");

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtIdentificacion.Text = f1.item.SubItems[0].Text;
				txtIdentificacionDesc.Text = f1.item.SubItems[1].Text;
			}
		}

		private void listaConsultoras()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "Codigo as Código, Nombre";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "NV_CONSULTORAS";
			listD.TITULO_LISTADO = "Consultoras";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtIdentificacion.Text = f1.item.SubItems[0].Text;
				txtIdentificacionDesc.Text = f1.item.SubItems[1].Text;
			}
		}

		private void listaEstablecimiento()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "NumRegistro as Código, Nombre";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "NV_ESTABLECIMIENTOS";
			listD.TITULO_LISTADO = "Establecimientos";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtIdentificacion.Text = f1.item.SubItems[0].Text;
				txtIdentificacionDesc.Text = f1.item.SubItems[1].Text;
			}
		}

		private void listaActividades()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "CodigoActividad as Código, NombreActividad as Actividad";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "NV_ACTIVIDADES";
			listD.TITULO_LISTADO = "Actividades";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtActividad.Text = f1.item.SubItems[0].Text;
				txtActividadDesc.Text = f1.item.SubItems[1].Text;
				//refrescarDatos();
				//verificarConfigurablesCondicion(true);
			}
		}
		#endregion

		#region Metodos
		private void limpiarData()
		{
			txtIdentificacion.Clear();
			txtIdentificacionDesc.Clear();
			txtActividad.Clear();
			txtActividadDesc.Clear();
			dtpDuracion.Value = DateTime.Now.Date;
			dtpFecha.Value = DateTime.Now;
			rtbObservacion.Clear();
		}

		private void cargarActividades()
		{
			string usuario = Consultas.sqlCon.USUARIO;
			string error = "";
			string filtroUsuario = "";

			if (!usuario.Equals("SA"))
				filtroUsuario = " where t1.UsuarioCreacionAdmin = '" + usuario + "'";

			string sQuery = "select t1.Id, t1.IdRegistro, CASE WHEN t3.IdColegiado IS NOT NULL THEN t3.Nombre" +
							" WHEN t4.NumRegistro IS NOT NULL THEN t4.Nombre WHEN t5.Codigo IS NOT NULL THEN t5.Nombre" +
							" END 'Registro', t1.CodigoActividad, t2.DescripcionActividad 'Actividad', t1.Duracion, t1.Fecha, t1.Observaciones" +
							" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ACTIVIDADES t1" +
							" join " + Consultas.sqlCon.COMPAÑIA + ".NV_ACTIVIDADES t2 on t2.CodigoActividad = t1.CodigoActividad" +
							" left join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 on t3.IdColegiado = t1.IdRegistro" +
							" left join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t4 on t4.NumRegistro = t1.IdRegistro" +
							" left join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS t5 on t5.Codigo = t1.IdRegistro" + filtroUsuario;

			DataTable dtAct = new DataTable();

			if (Consultas.fillDataTable(sQuery, ref dtAct, ref error))
			{
				dgvColegiados.Rows.Clear();
				//dtData.Rows.Clear();
				foreach (DataRow row in dtAct.Rows)
				{
					dgvColegiados.Rows.Add(row["Id"].ToString(), row["IdRegistro"].ToString(), row["Registro"].ToString(), row["CodigoActividad"].ToString(), row["Actividad"].ToString(),
						row["Duracion"].ToString() != "" ? DateTime.Parse(row["Duracion"].ToString()).ToString("HH:mm") : "", row["Fecha"].ToString() != "" ? DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString().Trim());
				}

				//DataView view = new DataView(dtData);
				//source.DataSource = view;
				//dgvColegiados.DataSource = view;
				//dgvColegiados.AutoResizeColumns();
				//dgvColegiados.Refresh();
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private bool guardarActividades(ref string error)
		{
			Listado list = new Listado();
			DataTable dtTemp = new DataTable();
			list.COLUMNAS = "Id,IdRegistro,CodigoActividad,Duracion,Fecha,Observaciones";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_HISTORIAL_ACTIVIDADES";
			bool lbOk = true;
			List<string> parametros = new List<string>();

			try
			{

				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ACTIVIDADES";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				if (lbOk)
				{
					foreach (DataGridViewRow row in dgvColegiados.Rows)
					{
						//if (esSancionNueva(dtTemp, txtNumColegiado.Valor, row.Cells["colCodigoEstable"].Value.ToString(), row.Cells["colCodigoCategoriaS"].Value.ToString()))
						//{
						parametros.Clear();
						list.COLUMNAS_PK.Clear();
						list.COLUMNAS_PK.Add("Id");
						parametros.Add(row.Cells["colId"].Value.ToString());
						parametros.Add(row.Cells["colIdRegistro"].Value.ToString());
						parametros.Add(row.Cells["colIdActividad"].Value.ToString());
						parametros.Add(DateTime.Parse(row.Cells["colDuracion"].Value.ToString()).ToString("HH:mm:ss"));
						parametros.Add(DateTime.Parse(row.Cells["colFecha"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

						parametros.Add(row.Cells["colObservaciones"].Value.ToString());
						lbOk = Consultas.insertar(parametros, list, Constantes.ID_BIT_CREAR_ACTIVIDAD, ref error);
						//}
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

		private void generarExcel()
		{
			ExcelInterop.Application Excel = new ExcelInterop.Application();
			Excel.Workbooks.Add();
			// single worksheet
			ExcelInterop._Worksheet Worksheet = Excel.ActiveSheet;

			List<int> ColumnasNoVisibles = new List<int>();
			List<string> colFechas = new List<string>();

			colFechas.Add("colDuracion");
			colFechas.Add("colFecha");

			int columnas = dgvColegiados.ColumnCount;
			int rows = dgvColegiados.RowCount;
			object[] Header = new object[columnas];

			// column headings               
			for (int i = 0; i < columnas; i++)
			{
				//if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga")
				//    Header[i] = dgvColegiados.Columns[i].HeaderText;
				//if (dgvColegiados.Columns[i].HeaderText != "Detalle Carga")
				//{
				if (dgvColegiados.Columns[i].Visible == true)
					Header[i] = dgvColegiados.Columns[i].HeaderText;
				else
					ColumnasNoVisibles.Add(i + 1);
				//}
			}



			ExcelInterop.Range HeaderRange = Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[1, 1]), (ExcelInterop.Range)(Worksheet.Cells[1, columnas]));
			HeaderRange.Value = Header;
			HeaderRange.Font.Bold = true;
			HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

			// DataCells

			object[,] Cells = new object[rows, columnas];
			bool fecha = false;
			for (int j = 0; j < rows; j++)
			{
				for (int i = 0; i < columnas; i++)
				{

					fecha = false;
					for (int k = 0; k < colFechas.Count; k++)
					{
						if (dgvColegiados.Columns[i].HeaderText == colFechas[k])
						{
							if (dgvColegiados[i, j].Value.ToString() != "")
								Cells[j, i] = DateTime.Parse(dgvColegiados[i, j].Value.ToString()).ToString("yyyy-MM-dd");
							else
								Cells[j, i] = "";
							fecha = true;
							break;
						}
					}

					if (!fecha && dgvColegiados.Columns[i].Visible == true)
					{
						if (dgvColegiados[i, j].Value != null)
							Cells[j, i] = dgvColegiados[i, j].Value.ToString();
						else
							Cells[j, i] = "";
					}


				}

			}

			Worksheet.Name = "Registro de actividades";
			Worksheet.get_Range((ExcelInterop.Range)(Worksheet.Cells[2, 1]), (ExcelInterop.Range)(Worksheet.Cells[rows + 1, columnas])).Value = Cells;
			Worksheet.Columns.AutoFit();
			//Eliminar columnas que no estan visibles en el dgv
			int cont = 0;
			foreach (int column in ColumnasNoVisibles)
			{
				if (cont == 0)
					Worksheet.Columns[column].Delete();
				else
					Worksheet.Columns[column - cont].Delete();
				cont++;
			}
			Excel.Visible = true;
			// DateTime tiempo2 = DateTime.Now;
			// TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
			// MessageBox.Show("Duracion: " + total.ToString());
		}
		#endregion
	}
}
