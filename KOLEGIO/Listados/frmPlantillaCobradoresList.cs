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
    public partial class frmPlantillaCobradoresList : frmListado
    {
        //string error = "";
        public frmPlantillaCobradoresList():base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "Codigo, Nombre, Cobrador, Tipo";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_PLANTILLA_COBRADOR";
            listar.TITULO_LISTADO = "Lista de Plantillas de Cobradores";
            listar.ORDERBY = "order by Cobrador";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("Codigo");
            listar.COLUMNAS_ALIAS_PK.Add("Codigo");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");
            insertar = Constantes.PLANTILLA_COBRADORES_INSERTAR;
            editar = Constantes.PLANTILLA_CCOBRADORES_EDITAR;
            borrar = Constantes.PLANTILLA_COBRADORES_BORRAR;
            seleccionar = Constantes.PLANTILLA_COBRADORES_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmPlantillasCobradoresEdicion"))
            {
                frmPlantillasCobradoresEdicion frm = new frmPlantillasCobradoresEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmPlantillasCobradoresEdicion"))
            {
                ObtenerValoresPKListado();
                frmPlantillasCobradoresEdicion frm = new frmPlantillasCobradoresEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }

        protected override bool eliminarDetalle(ref string error)
        {
            bool lbOk = true;

            if (flvListado.SelectedItem != null)
            {
                string sQuery = "";

                sQuery = "DELETE FROM "+Consultas.sqlCon.COMPAÑIA+ ".NV_PLANTILLA_COBRADOR_DETALLE WHERE Codigo ='" + flvListado.SelectedItem.SubItems[flvListado.GetColumn("Codigo").Index].Text + "'";
               
                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
            }

            return lbOk;
        }

    }
}
