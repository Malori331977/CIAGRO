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
    public partial class FrmPuestosTrabajoList : frmListado
    {
        public FrmPuestosTrabajoList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoPuesto as Código, NombrePuesto as Nombre, DescripcionPuesto as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_PUESTOS";
            listar.TITULO_LISTADO = "Lista de Puestos de Trabajo";
            listar.ORDERBY = "order by CodigoPuesto";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoPuesto");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");
            insertar = Constantes.PUESTOS_TRABAJO_INSERTAR;
            editar = Constantes.PUESTOS_TRABAJO_EDITAR;
            borrar = Constantes.PUESTOS_TRABAJO_BORRAR;
            seleccionar = Constantes.PUESTOS_TRABAJO_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmPuestosTrabajoEdicion"))
            {
                frmPuestosTrabajoEdicion frm = new frmPuestosTrabajoEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmPuestosTrabajoEdicion"))
            {
                ObtenerValoresPKListado();
                frmPuestosTrabajoEdicion frm = new frmPuestosTrabajoEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
