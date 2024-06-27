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
    public partial class FrmZonasCobroList : frmListado
    {
        public FrmZonasCobroList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoZona as Código, NombreZona as Nombre, DescripcionZona as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_ZONAS_COBRO";
            listar.TITULO_LISTADO = "Lista de Zonas de Cobro";
            listar.ORDERBY = "order by CodigoZona";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoZona");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmZonasCobroEdicion"))
            {
                frmZonasCobroEdicion frm = new frmZonasCobroEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmZonasCobroEdicion"))
            {
                ObtenerValoresPKListado();
                frmZonasCobroEdicion frm = new frmZonasCobroEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
