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
    public partial class FrmMachotesList : frmListado
    {
        public FrmMachotesList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoPlantilla as Código, NombrePlantilla as Plantilla";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_MACHOTES";
            listar.TITULO_LISTADO = "Lista de Plantillas";
            listar.ORDERBY = "order by CodigoPlantilla";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoPlantilla");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.PLANTILLAS_INSERTAR;
            editar = Constantes.PLANTILLAS_EDITAR;
            borrar = Constantes.PLANTILLAS_BORRAR;
            seleccionar = Constantes.PLANTILLAS_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmMachotesEdicion"))
            {
                frmMachotesEdicion frm = new frmMachotesEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmMachotesEdicion"))
            {
                ObtenerValoresPKListado();
                frmMachotesEdicion frm = new frmMachotesEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
