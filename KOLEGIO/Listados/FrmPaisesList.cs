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
    public partial class FrmPaisesList : frmListado
    {
        public FrmPaisesList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "PAIS as Código, NOMBRE as Nombre";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "PAIS";
            listar.TITULO_LISTADO = "Lista de Países";
            listar.ORDERBY = "order by PAIS";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("PAIS");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("Nacionalidad");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmPaisesEdicion"))
            {
                frmPaisesEdicion frm = new frmPaisesEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmPaisesEdicion"))
            {
                ObtenerValoresPKListado();
                frmPaisesEdicion frm = new frmPaisesEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
