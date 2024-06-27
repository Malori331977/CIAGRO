using Framework;
using KOLEGIO.Edicion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOLEGIO.Listados
{
	public partial class FrmCursosList : frmListado
    {
		public FrmCursosList()
		{
			InitializeComponent();
		}


        protected override void initInstance()
        {
            listar.COLUMNAS = "Codigo as Código, Nombre, Fecha";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CURSOS";
            listar.TITULO_LISTADO = "Lista de Cursos";
            listar.ORDERBY = "order by Codigo";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("Codigo");
            listar.COLUMNAS_PK_FECHAS.Add("Fecha");
            listar.COLUMNAS_ALIAS_PK.Add("Código");
            listar.COLUMNAS_ALIAS_PK.Add("Fecha");

			listar.COLUMNAS_FECHAS.Add("Fecha");

			////COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
			////listar.COLUMNAS_UILFG.Add("TIPO");
			////COLUMNAS NUMERICAS (FORMAT 'N2')
			////listar.COLUMNAS_NUMERICAS.Add("MONTO");
			insertar = Constantes.CURSOS_INSERTAR;
			editar = Constantes.CURSOS_EDITAR;
			borrar = Constantes.CURSOS_BORRAR;
			seleccionar = Constantes.CURSOS_SELECCIONAR;
			actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
			if (Utilitario.BuscaForm("frmCursosEdicion"))
			{
                frmCursosEdicion frm = new frmCursosEdicion(new List<string>());
				frm.Show();
			}
		}

        protected override void abrirEdicion()
        {
			if (Utilitario.BuscaForm("frmCursosEdicion"))
			{
				ObtenerValoresPKListado();
				frmCursosEdicion frm = new frmCursosEdicion(listar.VALORES_PK);
				frm.Show();
			}
		}
    }
}
