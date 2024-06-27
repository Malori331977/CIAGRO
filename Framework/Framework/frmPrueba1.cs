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
    public partial class frmPrueba1 : frmListado
    {
   
        public frmPrueba1()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CLIENTE,NOMBRE,CONTRIBUYENTE,MONEDA";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "CLIENTE";
            listar.ORDERBY = "CLIENTE";
            listar.TITULO_LISTADO = "Mantenimiento 2";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CLIENTE");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            listar.COLUMNAS_UILFG.Add("MONEDA");
        }

        private void frmPrueba1_Load(object sender, EventArgs e)
        {

        }
    }
}
