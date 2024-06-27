using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework
{
    public partial class frmPrueba : frmListado
    {
       
        public frmPrueba()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "TIPO,DOCUMENTO,PROVEEDOR,MONTO";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "DOCUMENTOS_CP";
            listar.TITULO_LISTADO = "Mantenimiento 1";
            listar.ORDERBY = "DOCUMENTO";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("DOCUMENTO");
            listar.COLUMNAS_PK.Add("TIPO");
            listar.COLUMNAS_PK.Add("PROVEEDOR");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            listar.COLUMNAS_UILFG.Add("TIPO");

            //COLUMNAS NUMERICAS (FORMAT 'N2')
            listar.COLUMNAS_NUMERICAS.Add("MONTO");
        }

        private void frmPrueba_Load(object sender, EventArgs e)
        {

        }
        
    }
}
