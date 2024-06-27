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
    public partial class FrmTiposList : frmListado
    {
        public FrmTiposList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoTipo as Código, CASE Diferenciador WHEN 'C' THEN 'CURSO' WHEN 'P' THEN 'PERITO' ELSE 'REGENTE' END AS [Tipo de], NombreTipo as Nombre, DescripcionTipo as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_TIPOS";
            listar.TITULO_LISTADO = "Lista de Tipos";
            listar.ORDERBY = "order by CodigoTipo";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoTipo");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.TIPOS_INSERTAR;
            editar = Constantes.TIPOS_EDITAR;
            borrar = Constantes.TIPOS_BORRAR;
            seleccionar = Constantes.TIPOS_SELECCIONAR;
            actualizar();
        }

         protected override void abrirEdicionNuevo()
         {
             if (Utilitario.BuscaForm("frmTiposEdicion"))
             {
                frmTiposEdicion frm = new frmTiposEdicion(new List<string>());
                 frm.Show();
             }
         }

         protected override void abrirEdicion()
         {
             if (Utilitario.BuscaForm("frmTiposEdicion"))
             {
                 ObtenerValoresPKListado();
                frmTiposEdicion frm = new frmTiposEdicion(listar.VALORES_PK);
                 frm.Show();
             }
         }
    }
}
