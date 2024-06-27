using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmCursosColegiadosEdicion : Form
	{
		//string Nconsecutivo = "";

		public frmCursosColegiadosEdicion(List<string> valoresPk, string numColegiado = "")
		{
			//Nconsecutivo = numColegiado;
			//txtNumColegiado.Valor = row["IdColegiado"].ToString();
			//armarFiltroPK(valoresPk);
			InitializeComponent();
			//cargarDatos();
			if (valoresPk.Count > 0)
			{
				txtNumColegiado.Valor = valoresPk[0];
				txtNColegiado.Valor = numColegiado;
				txtNColegiado.ReadOnly = true;

				buscaColegiado(txtNumColegiado.Valor);
				cargarCursos();
			}
		}


		private void btnResize_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			dgvCursos.AutoResizeColumns();
			Cursor.Current = Cursors.Default;
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			guardarCursos();
			Cursor.Current = Cursors.Default;
		}

		private void btnGuardarSalir_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			guardarCursos();
			Cursor.Current = Cursors.Default;
			Close();
		}

		//protected override void initInstance()
		//{
		//    try
		//    {
		//        listar.TITULO_LISTADO = "Administración de Cursos";
		//        lblPerfil.Text = "Perfil de Curso por colegiado";

		//        //listar.COLUMNAS = "Id,IdColegiado,CodigoCurso";

		//        //listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
		//        //listar.TABLA = "NV_HISTORIAL_CURSOS";

		//        ////COLUMNAS PRIMARY KEY
		//        //listar.COLUMNAS_PK.Add("Id");
		//        ////listar.COLUMNAS_PK.Add("CodigoCurso");
		//        //listar.VALORES_PK = valoresPk;

		//        identificadorFormulario = "De Curso por colegiado";

		//        insertar = Constantes.REG_CURSOS_INSERTAR;
		//        editar = Constantes.REG_CURSOS_EDITAR;
		//        borrar = Constantes.REG_CURSOS_BORRAR;
		//        seleccionar = Constantes.REG_CURSOS_SELECCIONAR;
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("Ocurrió un error inicializando la instancia del formulario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//    }
		//}

		//protected override void cargarDatos()
		//{
		//tabControl.TabPages.Remove(tpAdjuntos);
		//tabControl.TabPages.Add(tpAdjuntos);
		//tabControl.TabPages.Remove(tpAdmin);
		//tabControl.TabPages.Add(tpAdmin);

		//cmbTipo.agregarItems("Forestal");
		//cmbTipo.agregarItems("Agropecuario");
		//cmbTipo.Index = 0;

		//if (valoresPk.Count > 0)
		//{
		//if (Consultas.listarDatos(listar, ref dtDatos, ref error))
		//{
		//    if (dtDatos.Rows.Count > 0)
		//    {
		//        foreach (DataRow row in dtDatos.Rows)
		//        {
		//            txtNColegiado.Valor = Nconsecutivo;
		//            txtNumColegiado.Valor = row["IdColegiado"].ToString();
		//            buscaColegiado(row["IdColegiado"].ToString());

		//            txtCurso.Valor = row["CodigoCurso"].ToString();
		//            buscaCurso(txtCurso.Valor);


		//        }

		//        deshabilitarLlave();
		//    }
		//}
		//cargarCursos();
		//}
		//}

		private void cargarCursos(/*ref string error*/)
		{
			string error = string.Empty;
			string sQuery = "SELECT IdColegiado, NumeroColegiado, [Nombre Colegiado], CodigoCurso, [Nombre Curso], Tipo, Nivel, Estado, Modalidad, DuracionHoras, Fecha FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CURSOS_POR_COLEGIADO where IdColegiado = '" + txtNumColegiado.Valor + "' order by CodigoCurso";
			DataTable dtCursos = new DataTable();

			if (Consultas.fillDataTable(sQuery, ref dtCursos, ref error))
			{

				foreach (DataRow row in dtCursos.Rows)
				{

					dgvCursos.Rows.Add(
						row["CodigoCurso"].ToString(),
						row["Nombre Curso"].ToString(),
						row["Tipo"].ToString(),
						row["Nivel"].ToString(),
						row["Estado"].ToString(),
						row["Modalidad"].ToString(),
						row["DuracionHoras"].ToString(),						
						DateTime.Parse(row["Fecha"].ToString()).ToString("dd/MM/yyyy")
					);
				}



				if (dgvCursos.RowCount > 0)
				{
					//colorearFilas();
					dgvCursos.CurrentCell = dgvCursos[0, 0];
					//cargarInfoEstablecimiento(dgvCursos[0, 0].Value.ToString());
					//deshabilitarEstadoRegente();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private bool guardarCursos()
		{
			string error = string.Empty;
			Listado list = new Listado();
			list.COLUMNAS = "IdColegiado,CodigoCurso";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_HISTORIAL_CURSOS";
			bool lbOk = true;
			try
			{

				if (lbOk)
				{
					string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CURSOS WHERE IdColegiado='" + txtNumColegiado.Valor + "'";

					lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
				}

				if (lbOk)
				{
					List<string> parametros = new List<string>();

					foreach (DataGridViewRow row in dgvCursos.Rows)
					{
						parametros.Clear();
						//list.COLUMNAS_PK.Add("NumeroColegiado");
						parametros.Add(txtNumColegiado.Valor);
						parametros.Add(row.Cells["colCodigo"].Value.ToString());

						lbOk = Consultas.insertar(parametros, list, "Cursos por colegiados", ref error);

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


		//      protected override bool validarDatos(ref string errores)
		//{
		//          dgvCursos.EndEdit();
		// //         if (txtNumColegiado.Valor == "")
		//	//{
		//	//	errores = "Debe seleccionar un Colegiado.";
		//	//	txtNumColegiado.Focus();
		//	//	return false;
		//	//}

		//	//if (txtCurso.Valor == "")
		//	//{
		//	//	errores = "Debe seleccionar un Curso.";
		//	//	txtCurso.Focus();
		//	//	return false;
		//	//}

		//	return true;
		//}

		//protected override bool llenarParametros()
		//{
		//    parametros.Clear();
		//    parametros.Add(txtNumColegiado.Valor.Trim());

		//    parametros.Add(txtCurso.Valor.Trim());


		//    return true;
		//}

		//protected override bool guardarDetalle(ref string error)
		//{
		//    return guardarCursos(ref error);
		//}

		//protected override void deshabilitarLlave()
		//{
		//    //listar.VALORES_PK.Clear();
		//    //listar.VALORES_PK.Add(txtNumColegiado.Valor);
		//    //listar.VALORES_PK.Add(txtCurso.Valor);
		//    //txtNumColegiado.ReadOnly = true;
		//    //txtNColegiado.ReadOnly = true;
		//    //txtCurso.ReadOnly = true;
		//    //armarFiltroPK(listar.VALORES_PK);
		//    lblPerfil.Text = "Perfil de Curso: " + txtNombreColegiado.Valor;
		//}

		//protected override void limpiarFormulario()
		//{
		//    //txtNumColegiado.Clear();
		//    //txtNColegiado.Clear();
		//    //txtNColegiado.ReadOnly = false;
		//    //txtNombreColegiado.Clear();
		//    //txtCurso.Clear();
		//    //txtCursoDesc.Clear();

		//    listar.VALORES_PK.Clear();
		//    lblPerfil.Text = "Perfil de Curso por Colegiado";
		//}



		private void txtNumColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtNColegiado.ReadOnly)
				listaColegiados();
		}

		private void txtNumColegiado_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtNColegiado.ReadOnly)
				listaColegiados();
		}

		private void txtNumColegiado_Leave(object sender, EventArgs e)
		{
			if (!txtNColegiado.ReadOnly)
				buscaColegiadoLeave(txtNColegiado.Valor);
		}

		private void listaColegiados()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "IdColegiado, NumeroColegiado as Colegiado, Nombre";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_COLEGIADO";
			listP.COLUMNAS_PK.Add("IdColegiado");
			listP.COLUMNAS_OCULTAS.Add("IdColegiado");

			listP.ORDERBY = "order by IdColegiado";
			listP.TITULO_LISTADO = "Colegiados";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();
			if (f1Colegiado.item != null)
			{
				txtNumColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
				txtNColegiado.Valor = f1Colegiado.item.SubItems[1].Text;
				txtNombreColegiado.Valor = f1Colegiado.item.SubItems[2].Text;
			}
			buscaColegiado(txtNumColegiado.Valor);
		}

		private void buscaColegiadoLeave(string codigo)
		{
			string error = string.Empty;

			if (txtNColegiado.Valor.Trim() == "")
			{
				txtNombreColegiado.Clear();
				return;
			}

			DataTable dtColegiado = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "IdColegiado,Nombre";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_COLEGIADO";
			listP.FILTRO = "where NumeroColegiado = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
			{
				if (dtColegiado.Rows.Count > 0)
				{
					txtNumColegiado.Valor = dtColegiado.Rows[0]["IdColegiado"].ToString();
					txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
				}
				else
				{
					if (codigo != "")
					{
						MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtNumColegiado.Clear();
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
			string error = string.Empty;

			if (txtNumColegiado.Valor.Trim() == "")
			{
				txtNombreColegiado.Clear();
				return;
			}

			DataTable dtColegiado = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "IdColegiado,Nombre,Cobrador";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_COLEGIADO";
			listP.FILTRO = "where IdColegiado = '" + codigo + "'";

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
						MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtNumColegiado.Clear();
						txtNColegiado.Clear();
						txtNombreColegiado.Clear();
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}



		private void listaCursos()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "Codigo as Código,Nombre as Curso,Tipo,Nivel,Estado,Modalidad,DuracionHoras,Fecha";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CURSOS";
			listP.ORDERBY = "order by Codigo";
			listP.TITULO_LISTADO = "Cursos";

			listP.COLUMNAS_OCULTAS.Add("Tipo");
			listP.COLUMNAS_OCULTAS.Add("Nivel");
			listP.COLUMNAS_OCULTAS.Add("Estado");
			listP.COLUMNAS_OCULTAS.Add("Modalidad");
			listP.COLUMNAS_OCULTAS.Add("DuracionHoras");
			listP.COLUMNAS_OCULTAS.Add("Fecha");

			frmF1 f1Institucion = new frmF1(listP);
			f1Institucion.ShowDialog();
			if (f1Institucion.item != null)
			{
				//txtCurso.Valor = f1Institucion.item.SubItems[0].Text;
				//txtCursoDesc.Valor = f1Institucion.item.SubItems[1].Text;

				dgvCursos.CurrentCell.Value = f1Institucion.item.SubItems[0].Text;
				dgvCursos.CurrentCell.OwningRow.Cells["colNombre"].Value = f1Institucion.item.SubItems[1].Text;


				if (f1Institucion.item.SubItems[2].Text == "AP")
					dgvCursos.CurrentCell.OwningRow.Cells["colTipo"].Value = "APROVECHAMIENTO";
				else
					dgvCursos.CurrentCell.OwningRow.Cells["colTipo"].Value = "ASISTENCIA";

				if (f1Institucion.item.SubItems[3].Text == "CO")
					dgvCursos.CurrentCell.OwningRow.Cells["colNivel"].Value = "CONGRESO";
				else if (f1Institucion.item.SubItems[3].Text == "SE")
					dgvCursos.CurrentCell.OwningRow.Cells["colNivel"].Value = "SEMINARIO";
				else if (f1Institucion.item.SubItems[3].Text == "TA")
					dgvCursos.CurrentCell.OwningRow.Cells["colNivel"].Value = "TALLER";
				else if (f1Institucion.item.SubItems[3].Text == "CU")
					dgvCursos.CurrentCell.OwningRow.Cells["colNivel"].Value = "CURSO";
				else
					dgvCursos.CurrentCell.OwningRow.Cells["colNivel"].Value = "CONFERENCIA";

				if (f1Institucion.item.SubItems[4].Text == "A")
					dgvCursos.CurrentCell.OwningRow.Cells["colEstado"].Value = "APROBADO";
				else if (f1Institucion.item.SubItems[4].Text == "R")
					dgvCursos.CurrentCell.OwningRow.Cells["colEstado"].Value = "REPROBADO";
				else
					dgvCursos.CurrentCell.OwningRow.Cells["colEstado"].Value = "PENDIENTE";

				if (f1Institucion.item.SubItems[5].Text == "P")
					dgvCursos.CurrentCell.OwningRow.Cells["colModalidad"].Value = "PRESENCIAL";
				else if (f1Institucion.item.SubItems[5].Text == "V")
					dgvCursos.CurrentCell.OwningRow.Cells["colModalidad"].Value = "VIRTUAL";
				else
					dgvCursos.CurrentCell.OwningRow.Cells["colModalidad"].Value = "MIXTO";

				dgvCursos.CurrentCell.OwningRow.Cells["colDuracionHoras"].Value = decimal.Parse(f1Institucion.item.SubItems[6].Text);
				dgvCursos.CurrentCell.OwningRow.Cells["colFecha"].Value = DateTime.Parse(f1Institucion.item.SubItems[7].Text).ToString("dd/MM/yyyy");
			}
		}

		private void btnNuevoCurso_Click(object sender, EventArgs e)
		{
			if (txtNColegiado.Valor == string.Empty)
			{
				MessageBox.Show("Favor ingrese primero un colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REG_CURSOS_EDITAR))
				{
					dgvCursos.Rows.Add("", "", "", "", "", "", "", "");
					btnGuardar.Enabled = true;
					btnGuardarSalir.Enabled = true;
				}
				else
					MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

			}

		}

		private void dgvCursos_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvCursos.CurrentCell.OwningColumn.Name == "colCodigo" /*|| dgvCursos.CurrentCell.OwningColumn.Name == "colNombre"*/ )
			{
				listaCursos();
			}
		}

		private void dgvCursos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvCursos.IsCurrentCellDirty)
			{
				dgvCursos.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}


	}
}
