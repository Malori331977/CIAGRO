using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmCambioUltimoCobro : Form
	{
		private int totalRegistros = 0;
		private int totalRegistrosExitosos = 0;
		private int totalRegistrosErroneos = 0;
		private string canon = "", tipoRegistro = "";
		private bool esPeritaje = false, esColegiatura = false, esRegencia = false, esViaAerea = false, esPlaguicida = false, esEstable= false, esConsultora = false;
		private FuncsInternas fInternas;
		private DateTimePicker dtp = new DateTimePicker();
		List<string> parametros = new List<string>();

		public frmCambioUltimoCobro()
		{
			InitializeComponent();
			this.fInternas = new FuncsInternas();


			cmbProcesos.agregarItems("Colegiaturas");
			cmbProcesos.agregarItems("Regencias");
			cmbProcesos.agregarItems("Peritajes");
			cmbProcesos.agregarItems("Idóneos Recetar Vía Aérea");
			cmbProcesos.agregarItems("Idóneos Investigación Plaguicidas");
			cmbProcesos.agregarItems("Establecimientos");
			cmbProcesos.agregarItems("Consultoras");
			//cmbProcesos.Index = 0;

			cmbProcesos.SelectedValueChanged(new EventHandler(OnProcesosChanged));
		}

		private void btnProcesar_Click(object sender, EventArgs e)
		{
			string error = "";
			if (guardarUltimoCobro(canon, ref error))
			{
				MessageBox.Show("Se guardaron los registros correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private bool guardarUltimoCobro(string canon, ref string error)
		{
			Listado list = new Listado();
			bool lbOK = true;

			if (dgvCanones.Rows.Count > 0)
			{
				foreach (DataGridViewRow row in dgvCanones.Rows)
				{
					DateTime mesUltCobro = row.Cells["colUltimoCobro"].Value.ToString().Equals("")
										? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25)
										: DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString());
					//if (existeRegistro(row.Cells["colNumRegistro"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString()))
					//{
					//    actualizar(ref list,row);

					//    if (lbOK)
					//        lbOK = Consultas.actualizar(parametros, list, string.Empty, ref error);
					//    else
					//        break;
					//}
					//else
					//{
					//    agregar(ref list, row);
					//    if (lbOK)
					//        lbOK = Consultas.insertar(parametros, list, string.Empty, ref error);
					//    else
					//        break;
					//}
					if (fInternas.existeUltimoCobro(txtColegiado.Text, row.Cells["colNumRegistro"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), canon, tipoRegistro))
					{
						fInternas.actualizarUltimoCobro(ref parametros, ref list, canon, mesUltCobro, row.Cells["colIdColegiado"].Value.ToString(), row.Cells["colNumRegistro"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), tipoRegistro);

						if (lbOK)
							lbOK = Consultas.actualizar(parametros, list, Constantes.ID_BIT_UPDATE_ULTIMO_COBRO, ref error);
						else
							break;
					}
					else
					{
						fInternas.agregarUltimoCobro(ref parametros, ref list, canon, mesUltCobro, row.Cells["colIdColegiado"].Value.ToString(), row.Cells["colNumRegistro"].Value.ToString(), row.Cells["colCodCategoria"].Value.ToString(), tipoRegistro);
						
						if (lbOK)
							lbOK = Consultas.insertar(parametros, list, Constantes.ID_BIT_CREAR_ULTIMO_COBRO, ref error);
						else
							break;
					}
				}
			}

			return lbOK;

		}

		//private void actualizar(ref Listado list, DataGridViewRow row)
		//{

		//    if (esColegiatura || esRegencia)
		//        list.COLUMNAS = "MesUltimoCobro";
		//    //else if()
		//    //    list.COLUMNAS = "MesUltimoCobro";
		//    else
		//        list.COLUMNAS = "AñoUltimoCobro";

		//    if (esColegiatura)
		//        list.TABLA = "NV_HISTORIAL_COLEGIATURAS";
		//    else if (esRegencia)
		//        list.TABLA = "NV_HISTORIAL_REGENCIAS";
		//    else
		//        list.TABLA = "NV_HISTORIAL_CANONES_ANUALES";

		//    if (esColegiatura)
		//        list.FILTRO = " WHERE IdColegiado = '" + row.Cells["colIdColegiado"].Value.ToString() + "'";
		//    else if (esRegencia)
		//        list.FILTRO = " WHERE IdColegiado = '" + row.Cells["colIdColegiado"].Value.ToString() + "' and NumRegistro = '" + row.Cells["colNumRegistro"].Value.ToString() + "' and Categoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";
		//    else
		//        list.FILTRO = " WHERE Identificador = '" + row.Cells["colIdColegiado"].Value.ToString() + "' and Canon = '" + canon + "'";

		//    list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
		//    //list.COLUMNAS_PK.Add("CodigoCliente");

		//    parametros.Clear();
		//    parametros.Add(DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

		//}

		//private void agregar(ref Listado list, DataGridViewRow row)
		//{
		//    if (esColegiatura)
		//        list.COLUMNAS = "IdColegiado,MesUltimoCobro";
		//    else if(esRegencia)
		//        list.COLUMNAS = "IdColegiado,NumRegistro,Categoria,MesUltimoCobro";
		//    else
		//        list.COLUMNAS = "AñoUltimoCobro";

		//    if (esColegiatura)
		//        list.TABLA = "NV_HISTORIAL_COLEGIATURAS";
		//    else if (esRegencia)
		//        list.TABLA = "NV_HISTORIAL_REGENCIAS";
		//    else
		//        list.TABLA = "NV_HISTORIAL_CANONES_ANUALES";

		//    list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;

		//    parametros.Clear();
		//    parametros.Add(txtColegiado.Text);
		//    if (esRegencia)
		//    {
		//        parametros.Add(row.Cells["colNumRegistro"].Value.ToString());
		//        parametros.Add(row.Cells["colCodCategoria"].Value.ToString());
		//    }
		//    parametros.Add(DateTime.Parse(row.Cells["colUltimoCobro"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
		//}

		//private bool existeRegistro(string numregistro, string categoria)
		//{
		//    string sQuery = "", error = "";
		//    DataTable dt = new DataTable();
		//    bool existe = true;

		//    if (esColegiatura)
		//    {
		//        sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + txtColegiado.Text + "'";
		//    }

		//    if (esRegencia)
		//    {
		//        sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS where IdColegiado = '" + txtColegiado.Text + "' and NumRegistro = '"+numregistro+ "' and Categoria = '" + categoria + "' ";
		//    }

		//    try
		//    {
		//        if (Consultas.fillDataTable(sQuery, ref dt, ref error))
		//        {
		//            if (dt.Rows.Count > 0)
		//            {
		//                existe = true;
		//            }
		//            else
		//            {
		//                existe = false;
		//            }
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//    }

		//    return existe;
		//}

		private void OnProcesosChanged(object sender, EventArgs e)
		{
			limpiarRegistro();
			limpiar();
			revisarCmb();
		}

		private void revisarCmb()
		{
			if (cmbProcesos.Texto == "Peritajes")
			{
				esPeritaje = true;
				esPlaguicida = false;
				esViaAerea = false;
				esColegiatura = false;
				esRegencia = false;
				esEstable = false;
				esConsultora = false;
				canon = "PER";
				tipoRegistro = "CANON";
			}
			
			if (cmbProcesos.Texto == "Idóneos Investigación Plaguicidas")
			{
				esPeritaje = false;
				esPlaguicida = true;
				esViaAerea = false;
				esColegiatura = false;
				esRegencia = false;
				esEstable = false;
				esConsultora = false;
				canon = "PLAGUI";
				tipoRegistro = "CANON";
			}
			
			if (cmbProcesos.Texto == "Idóneos Recetar Vía Aérea")
			{
				esPeritaje = false;
				esPlaguicida = false;
				esViaAerea = true;
				esColegiatura = false;
				esRegencia = false;
				esEstable = false;
				esConsultora = false;
				canon = "AEREA";
				tipoRegistro = "CANON";
			}
			
			if (cmbProcesos.Texto == "Colegiaturas")
			{
				esPeritaje = false;
				esPlaguicida = false;
				esViaAerea = false;
				esColegiatura = true;
				esRegencia = false;
				esEstable = false;
				esConsultora = false;
				tipoRegistro = "COL";
			}

			if (cmbProcesos.Texto == "Regencias")
			{
				esPeritaje = false;
				esPlaguicida = false;
				esViaAerea = false;
				esColegiatura = false;
				esEstable = false;
				esConsultora = false;
				esRegencia = true;
				tipoRegistro = "REG";
			}

			if (cmbProcesos.Texto == "Establecimientos")
			{
				esPeritaje = false;
				esPlaguicida = false;
				esViaAerea = false;
				esColegiatura = false;
				esRegencia = false;
				esConsultora = false;
				esEstable = true;
				canon = "ESTABLE";
				tipoRegistro = "CANON";
			}

			if (cmbProcesos.Texto == "Consultoras")
			{
				esPeritaje = false;
				esPlaguicida = false;
				esViaAerea = false;
				esColegiatura = false;
				esRegencia = false;
				esEstable = false;
				esConsultora = true;
				canon = "CONSUL";
				tipoRegistro = "CANON";
			}
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			refrescarDatos();
		}

		private void refrescarDatos()
		{
			string sQuery = "";
			#region REAL
			if (esPeritaje)
			{
				sQuery = "select t1.Identificador, t2.NumeroColegiado, t2.Nombre, t1.AñoUltimoCobro as UltimoCobro" +
						" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t1" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.Identificador" +
						" where t1.Canon = 'PER' and t1.Identificador = '" + txtColegiado.Text + "'";
			}

			if (esPlaguicida)
			{
				sQuery = "select t1.Identificador, t2.NumeroColegiado, t2.Nombre, t1.AñoUltimoCobro as UltimoCobro" +
						" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t1" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.Identificador" +
						" where t1.Canon = 'PLAGUI' and t1.Identificador = '" + txtColegiado.Text + "'";
			}

			if (esViaAerea)
			{
				sQuery = "select t1.Identificador, t2.NumeroColegiado, t2.Nombre, t1.AñoUltimoCobro as UltimoCobro" +
						" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t1" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.Identificador" +
						" where t1.Canon = 'AEREA' and t1.Identificador = '" + txtColegiado.Text + "'";
			}

			if (esColegiatura)
			{
				sQuery = "select t2.IdColegiado as Identificador, t2.NumeroColegiado, t2.Nombre, t1.MesUltimoCobro as UltimoCobro" +
							" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS t1" +
							" right join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.IdColegiado" +
							" where t2.IdColegiado = '" + txtColegiado.Text + "'";
			}

			if (esRegencia)
			{
				sQuery = "select t2.NumeroColegiado as Identificador,t3.NumeroColegiado, t3.Nombre, t2.CodigoEstablecimiento as NumRegistro, t4.Nombre 'Estable',  t2.CodigoCategoria as Categoria, t5.NombreCategoria, t1.MesUltimoCobro as UltimoCobro" +
						" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t1" +
						" right join " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS t2 on t2.NumeroColegiado = t1.IdColegiado and t2.CodigoEstablecimiento = t1.NumRegistro and t2.CodigoCategoria = t1.Categoria" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t3 on t3.IdColegiado = t2.NumeroColegiado" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t4 on t4.NumRegistro = t2.CodigoEstablecimiento" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t5 on t5.CodigoCategoria = t2.CodigoCategoria" +
						" where t2.NumeroColegiado = '" + txtColegiado.Text + "'";
			}

			if (esEstable)
			{
				sQuery = "select t1.Identificador, t2.NumRegistro, t2.Nombre, t1.AñoUltimoCobro as UltimoCobro" +
						" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t1" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t2 on t2.NumRegistro = t1.Identificador" +
						" where t1.Canon = 'ESTABLE' and t1.Identificador = '" + txtColegiado.Text + "'";
			}

			if (esConsultora)
			{
				sQuery = "select t1.Identificador, t2.Codigo, t2.Nombre, t1.AñoUltimoCobro as UltimoCobro" +
						" from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES t1" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS t2 on t2.Codigo = t1.Identificador" +
						" where t1.Canon = 'CONSUL' and t1.Identificador = '" + txtColegiado.Text + "'";
			}
			#endregion
			DataTable dtIngresos = new DataTable();

			string error = "";
			try
			{
				if (Consultas.fillDataTable(sQuery, ref dtIngresos, ref error))
				{
					//dgvColegiados.DataSource = dtIngresos;
					dgvCanones.Rows.Clear();
					totalRegistros = 0;

					foreach (DataRow row in dtIngresos.Rows)
					{
						if (dtIngresos.Rows.Count > 0)
						{
							if (esPeritaje || esPlaguicida || esViaAerea || esColegiatura)
							{
								totalRegistros += 1;
								dgvCanones.Rows.Add(row["Identificador"].ToString(), row["NumeroColegiado"].ToString(), row["Nombre"].ToString(),
									string.Empty, string.Empty, string.Empty, string.Empty,
									row["UltimoCobro"].ToString() != "" ? DateTime.Parse(row["UltimoCobro"].ToString()).ToString("dd/MM/yyyy") : "");
								dgvCanones.Columns["colNumRegistro"].Visible = false;
								dgvCanones.Columns["colEstable"].Visible = false;
								dgvCanones.Columns["colCategoria"].Visible = false;
							}

							if (esRegencia)
							{
								totalRegistros += 1;
								dgvCanones.Rows.Add(row["Identificador"].ToString(), row["NumeroColegiado"].ToString(), row["Nombre"].ToString(),
									row["NumRegistro"].ToString(), row["Estable"].ToString(), row["Categoria"].ToString(), row["NombreCategoria"].ToString(),
									row["UltimoCobro"].ToString() != "" ? DateTime.Parse(row["UltimoCobro"].ToString()).ToString("dd/MM/yyyy") : "");
								dgvCanones.Columns["colNumRegistro"].Visible = true;
								dgvCanones.Columns["colEstable"].Visible = true;
								dgvCanones.Columns["colCategoria"].Visible = true;
							}

							if (esEstable || esConsultora)
							{
								totalRegistros += 1;
								dgvCanones.Rows.Add(row["Identificador"].ToString(), row["Identificador"].ToString(), row["Nombre"].ToString(),
									string.Empty, string.Empty, string.Empty, string.Empty,
									row["UltimoCobro"].ToString() != "" ? DateTime.Parse(row["UltimoCobro"].ToString()).ToString("dd/MM/yyyy") : "");
								dgvCanones.Columns["colNumRegistro"].Visible = false;
								dgvCanones.Columns["colEstable"].Visible = false;
								dgvCanones.Columns["colCategoria"].Visible = false;
							}
						}
						else
						{
							MessageBox.Show("No se encontraron registros para el colegiado.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnResize_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			dgvCanones.AutoResizeColumns();
			Cursor.Current = Cursors.Default;
		}

		private void btnGenerar_Click(object sender, EventArgs e)
		{
			refrescarDatos();
		}

		private void dgvCanones_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dtp.Visible = false;
			if (e.RowIndex != -1)
			{
				if ((dgvCanones.CurrentCell.OwningColumn.Name == "colUltimoCobro"))
				{

					dtp = new DateTimePicker();
					dgvCanones.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvCanones.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChange);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvCanones.CurrentCell.OwningColumn.Name == "colUltimoCobro" && !string.IsNullOrEmpty(dgvCanones.Rows[e.RowIndex].Cells["colUltimoCobro"].Value.ToString()))
						dtp.Value = DateTime.Parse(dgvCanones.Rows[e.RowIndex].Cells["colUltimoCobro"].Value.ToString());

					dtp.Visible = true;

				}
			}

		}

		private void dtp_OnTextChange(object sender, EventArgs e)
		{
			dgvCanones.CurrentCell.Value = dtp.Text.ToString();
		}

		void dtp_CloseUp(object sender, EventArgs e)
		{
			dtp.Visible = false;
		}

		private void dgvCanones_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvCanones.IsCurrentCellDirty)
			{
				dgvCanones.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void limpiar()
		{
			if (dgvCanones.Rows.Count > 0)
			{
				dgvCanones.Rows.Clear();
			}

		}

		private void limpiarRegistro()
		{
			txtColegiado.Clear();
			txtNombreColegiado.Clear();
			txtNumeroColegiado.Clear();
		}

		private void txtColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (cmbProcesos.Texto == "Establecimientos")
			{
				listaEstablecimientos();
			}
			else if (cmbProcesos.Texto == "Consultoras")
			{
				listaConsultoras();
			}
			else
			{
				listaColegiados();
			}
		}

		private void listaColegiados()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "IdColegiado, NumeroColegiado as Colegiado, Nombre, Condicion, (select t1.NombreCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1 where t1.CodigoCondicion = Condicion) as Condición";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_COLEGIADO";
			listP.COLUMNAS_PK.Add("IdColegiado");
			listP.COLUMNAS_OCULTAS.Add("IdColegiado");
			listP.COLUMNAS_OCULTAS.Add("Condicion");

			listP.ORDERBY = "order by IdColegiado";
			listP.TITULO_LISTADO = "Colegiados";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();
			if (f1Colegiado.item != null)
			{
				txtColegiado.Text = f1Colegiado.item.SubItems[0].Text;
				txtNumeroColegiado.Valor = f1Colegiado.item.SubItems[1].Text;
				txtNombreColegiado.Text = f1Colegiado.item.SubItems[2].Text;
			}
		}

		private void listaEstablecimientos()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "NumRegistro as Código, Nombre, (select t1.NombreEstado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t1 where t1.CodigoEstado = Estado) as Estado";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ESTABLECIMIENTOS";
			listP.COLUMNAS_PK.Add("NumRegistro");
			//listP.COLUMNAS_OCULTAS.Add("IdColegiado");
			//listP.COLUMNAS_OCULTAS.Add("Condicion");

			listP.ORDERBY = "order by NumRegistro";
			listP.TITULO_LISTADO = "Establecimientos";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();
			if (f1Colegiado.item != null)
			{
				txtColegiado.Text = f1Colegiado.item.SubItems[0].Text;
				txtNumeroColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
				txtNombreColegiado.Text = f1Colegiado.item.SubItems[1].Text;
			}
		}

		private void listaConsultoras()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "Codigo, Nombre, (select t1.NombreEstado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t1 where t1.CodigoEstado = Estado) as Estado";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CONSULTORAS";
			listP.COLUMNAS_PK.Add("Codigo");
			//listP.COLUMNAS_OCULTAS.Add("IdColegiado");
			//listP.COLUMNAS_OCULTAS.Add("Condicion");

			listP.ORDERBY = "order by Codigo";
			listP.TITULO_LISTADO = "Consultoras";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();
			if (f1Colegiado.item != null)
			{
				txtColegiado.Text = f1Colegiado.item.SubItems[0].Text;
				txtNumeroColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
				txtNombreColegiado.Text = f1Colegiado.item.SubItems[1].Text;
			}
		}

		private void buscaColegiado(string codigo)
		{

			if (txtNumeroColegiado.Valor.Trim() == "")
			{
				txtNombreColegiado.Clear();
				return;
			}

			DataTable dtColegiado = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "IdColegiado,NumeroColegiado,Nombre, Condicion, (select t1.NombreCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1 where t1.CodigoCondicion = Condicion) as NombreCondicion";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_COLEGIADO";
			listP.FILTRO = "where NumeroColegiado = '" + codigo + "'";
			string error = "";
			if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
			{
				if (dtColegiado.Rows.Count > 0)
				{
					txtNombreColegiado.Text = dtColegiado.Rows[0]["Nombre"].ToString();
					txtColegiado.Text = dtColegiado.Rows[0]["IdColegiado"].ToString();
					txtNumeroColegiado.Valor = dtColegiado.Rows[0]["NumeroColegiado"].ToString();
				}
				else
				{
					if (codigo != "")
					{
						MessageBox.Show("El Número de colegiado digitado no existe o no pertenece a una condición de levantamiento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarRegistro();
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaEstablecimiento(string codigo)
		{

			if (txtNumeroColegiado.Valor.Trim() == "")
			{
				txtNombreColegiado.Clear();
				return;
			}

			DataTable dtColegiado = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "NumRegistro as Código, Nombre, (select t1.NombreEstado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t1 where t1.CodigoEstado = Estado) as Estado"; listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ESTABLECIMIENTOS";
			listP.FILTRO = "where NumRegistro = '" + codigo + "'";
			string error = "";
			if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
			{
				if (dtColegiado.Rows.Count > 0)
				{
					txtNombreColegiado.Text = dtColegiado.Rows[0]["Nombre"].ToString();
					txtColegiado.Text = dtColegiado.Rows[0]["Código"].ToString();
					txtNumeroColegiado.Valor = dtColegiado.Rows[0]["Código"].ToString();
				}
				else
				{
					if (codigo != "")
					{
						MessageBox.Show("El Número de establecimientos digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarRegistro();
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaConsultoras(string codigo)
		{

			if (txtNumeroColegiado.Valor.Trim() == "")
			{
				txtNombreColegiado.Clear();
				return;
			}

			DataTable dtColegiado = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "Codigo, Nombre, (select t1.NombreEstado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS t1 where t1.CodigoEstado = Estado) as Estado"; listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CONSULTORAS";
			listP.FILTRO = "where Codigo = '" + codigo + "'";
			string error = "";
			if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
			{
				if (dtColegiado.Rows.Count > 0)
				{
					txtNombreColegiado.Text = dtColegiado.Rows[0]["Nombre"].ToString();
					txtColegiado.Text = dtColegiado.Rows[0]["Codigo"].ToString();
					txtNumeroColegiado.Valor = dtColegiado.Rows[0]["Codigo"].ToString();
				}
				else
				{
					if (codigo != "")
					{
						MessageBox.Show("El Número de consultora digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						limpiarRegistro();
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void txtColegiado_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
			{
				if (cmbProcesos.Texto == "Establecimientos")
				{
					listaEstablecimientos();
				}
				else if (cmbProcesos.Texto == "Consultoras")
				{
					listaConsultoras();
				}
				else
				{
					listaColegiados();
				}
			}
		}

		private void txtColegiado_Leave(object sender, EventArgs e)
		{
			if (cmbProcesos.Texto == "Establecimientos")
			{
				buscaEstablecimiento(txtNumeroColegiado.Valor);
			} 
			else if (cmbProcesos.Texto == "Consultoras")
			{
				buscaConsultoras(txtNumeroColegiado.Valor);
			} 
			else
			{
				buscaColegiado(txtNumeroColegiado.Valor);
			}
		}

	}
}
