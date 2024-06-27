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
    public partial class FrmControlVersionesList : frmListado
    {
        public FrmControlVersionesList()
        {
            InitializeComponent();
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "Version as Versión,Cia as Compañia,convert(varchar, Fecha, 103) as Fecha";
            listar.COMPAÑIA = "dbo";
            listar.TABLA = "CONTROL_VERSIONES";
            listar.TITULO_LISTADO = "Lista de Control de Versiones";
            listar.ORDERBY = "order by Version desc";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("Version");
            listar.COLUMNAS_ALIAS_PK.Add("Versión");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");

            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");
            actualizar();
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmControlVersionesEdicion"))
            {
                ObtenerValoresPKListado();
                frmControlVersionesEdicion frm = new frmControlVersionesEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmControlVersionesEdicion"))
            {
                frmControlVersionesEdicion frm = new frmControlVersionesEdicion(new List<string>());
                frm.Show();
            }
        }
    }
}
