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
    public partial class FrmCentrosAcademicosList : frmListado
    {
        public FrmCentrosAcademicosList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoCentro as Código, NombreCentro as Universidad";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CENTROS";
            listar.TITULO_LISTADO = "Lista de Centros Académicos";
            listar.ORDERBY = "order by CodigoCentro";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoCentro");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");
            insertar = Constantes.CENTROS_ACADEMICOS_INSERTAR;
            editar = Constantes.CENTROS_ACADEMICOS_EDITAR;
            borrar = Constantes.CENTROS_ACADEMICOS_BORRAR;
            seleccionar = Constantes.CENTROS_ACADEMICOS_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmCentrosAcademicosEdicion"))
            {
                frmCentrosAcademicosEdicion frm = new frmCentrosAcademicosEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmCentrosAcademicosEdicion"))
            {
                ObtenerValoresPKListado();
                frmCentrosAcademicosEdicion frm = new frmCentrosAcademicosEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
