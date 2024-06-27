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
    public partial class FrmCamposEspecialidadList : frmListado
    {
        public FrmCamposEspecialidadList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoCampo as Código, NombreCampo as Nombre, DescripcionCampo as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CAMPOS_ESPECIALIDAD";
            listar.TITULO_LISTADO = "Lista de Campos de Especialidad";
            listar.ORDERBY = "order by CodigoCampo";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoCampo");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.CAMPOS_ESPECIALIDAD_INSERTAR;
            editar = Constantes.CAMPOS_ESPECIALIDAD_EDITAR;
            borrar = Constantes.CAMPOS_ESPECIALIDAD_BORRAR;
            seleccionar = Constantes.CAMPOS_ESPECIALIDAD_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmCamposEspecialidadEdicion"))
            {
                frmCamposEspecialidadEdicion frm = new frmCamposEspecialidadEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmCamposEspecialidadEdicion"))
            {
                ObtenerValoresPKListado();
                frmCamposEspecialidadEdicion frm = new frmCamposEspecialidadEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
