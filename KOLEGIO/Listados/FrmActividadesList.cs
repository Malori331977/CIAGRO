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
	public partial class FrmActividadesList : frmListado
    {
		public FrmActividadesList()
		{
			InitializeComponent();
		}


        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoActividad as Código, NombreActividad as Nombre, DescripcionActividad as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_ACTIVIDADES";
            listar.TITULO_LISTADO = "Lista de Actividades de Trabajo";
            listar.ORDERBY = "order by CodigoActividad";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoActividad");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

			////COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
			////listar.COLUMNAS_UILFG.Add("TIPO");
			////COLUMNAS NUMERICAS (FORMAT 'N2')
			////listar.COLUMNAS_NUMERICAS.Add("MONTO");
			insertar = Constantes.ACTIVIDAD_INSERTAR;
			editar = Constantes.ACTIVIDAD_EDITAR;
			borrar = Constantes.ACTIVIDAD_BORRAR;
			seleccionar = Constantes.ACTIVIDAD_SELECCIONAR;
			actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
			if (Utilitario.BuscaForm("frmActividadesEdicion"))
			{
                frmActividadesEdicion frm = new frmActividadesEdicion(new List<string>());
				frm.Show();
			}
		}

        protected override void abrirEdicion()
        {
			if (Utilitario.BuscaForm("frmActividadesEdicion"))
			{
				ObtenerValoresPKListado();
				frmActividadesEdicion frm = new frmActividadesEdicion(listar.VALORES_PK);
				frm.Show();
			}
		}
    }
}
