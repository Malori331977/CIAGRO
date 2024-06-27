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
    public partial class FrmFrecuenciasList : frmListado
    {
        public FrmFrecuenciasList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoFrecuencia as Código, NombreFrecuencia as Nombre, DuracionFrecuencia as Duración";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_FRECUENCIAS";
            listar.TITULO_LISTADO = "Lista de Frecuencias de Pago";
            listar.ORDERBY = "order by CodigoFrecuencia";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoFrecuencia");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            listar.COLUMNAS_UILFG.Add("Duración");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            listar.COLUMNAS_NUMERICAS_INT.Add("Duración");
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmFrecuenciasEdicion"))
            {
                frmFrecuenciasEdicion frm = new frmFrecuenciasEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmFrecuenciasEdicion"))
            {
                ObtenerValoresPKListado();
                frmFrecuenciasEdicion frm = new frmFrecuenciasEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
