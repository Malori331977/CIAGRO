using Framework;
using System.Collections.Generic;

namespace KOLEGIO.Listados
{
	public partial class FrmCursosColegiadosList : frmListado
	{
		public FrmCursosColegiadosList() : base()
		{
			InitializeComponent();
		}

		protected override void initInstance()
		{

			listar.COLUMNAS = "IdColegiado as 'Id Colegiado', [N° Colegiado], [Cédula], Nombre, CodigoCurso as 'Código Curso', [Nombre Curso], [Fecha Curso]";
			listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listar.TABLA = "NV_CURSOS_INDEX";
			listar.TITULO_LISTADO = "Lista de Colegiados con cursos";
			listar.ORDERBY = "order by IdColegiado";

			//COLUMNAS PRIMARY KEY
			listar.COLUMNAS_PK.Add("IdColegiado");
			listar.COLUMNAS_ALIAS_PK.Add("Id Colegiado");
			listar.COLUMNAS_FECHAS.Add("Fecha Curso");


			insertar = Constantes.REG_CURSOS_INSERTAR;
			editar = Constantes.REG_CURSOS_EDITAR;
			borrar = Constantes.REG_CURSOS_BORRAR;
			seleccionar = Constantes.REG_CURSOS_SELECCIONAR;
			actualizar();
		}

		protected override void abrirEdicionNuevo()
		{
			if (Utilitario.BuscaForm("frmCursosColegiadosEdicion"))
			{
				frmCursosColegiadosEdicion frm = new frmCursosColegiadosEdicion(new List<string>());
				frm.Show();
			}
		}

		protected override void abrirEdicion()
		{
			if (Utilitario.BuscaForm("frmCursosColegiadosEdicion"))
			{
				ObtenerValoresPKListado();
				string NumeroColegiado = "";
				NumeroColegiado = flvListado.SelectedItem.SubItems[flvListado.GetColumn("N° Colegiado").Index].Text;
				frmCursosColegiadosEdicion frm = new frmCursosColegiadosEdicion(listar.VALORES_PK, NumeroColegiado);
				frm.Show();
			}
		}
	}
}
