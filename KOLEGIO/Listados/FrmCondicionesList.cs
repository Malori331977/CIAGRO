using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class FrmCondicionesList : frmListado
    {
        public FrmCondicionesList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "a.CodigoCondicion as Código, a.NombreCondicion as Nombre, a.DescripcionCondicion as Descripción, ISNULL((SELECT NombrePlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where a.CodigoPlantilla = CodigoPlantilla),'Vacía') as Plantilla";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CONDICIONES a";
            listar.TABLA_ELIMINAR = "NV_CONDICIONES";
            listar.TITULO_LISTADO = "Lista de Condiciones Colegiado";
            listar.ORDERBY = "order by a.CodigoCondicion";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoCondicion");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.CONDICIONES_INSERTAR;
            editar = Constantes.CONDICIONES_EDITAR;
            borrar = Constantes.CONDICIONES_BORRAR;
            seleccionar = Constantes.CONDICIONES_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmCondicionesEdicion"))
            {
                frmCondicionesEdicion frm = new frmCondicionesEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmCondicionesEdicion"))
            {
                ObtenerValoresPKListado();
                frmCondicionesEdicion frm = new frmCondicionesEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
