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
    public partial class FrmEstadosList : frmListado
    {
        public FrmEstadosList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoEstado as Código, CASE Diferenciador WHEN 'E' THEN 'ESTABLECIMIENTO' else 'CONSULTORA' END AS [Estado de], NombreEstado as Nombre, DescripcionEstado as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_ESTADOS";
            listar.TITULO_LISTADO = "Lista de Estados Establecimiento";
            listar.ORDERBY = "order by CodigoEstado";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoEstado");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.ESTADOS_ESTABLECIMIENTO_INSERTAR;
            editar = Constantes.ESTADOS_ESTABLECIMIENTO_EDITAR;
            borrar = Constantes.ESTADOS_ESTABLECIMIENTO_BORRAR;
            seleccionar = Constantes.ESTADOS_ESTABLECIMIENTO_SELECCIONAR;
            actualizar();
        }

         protected override void abrirEdicionNuevo()
         {
             if (Utilitario.BuscaForm("frmEstadosEdicion"))
             {
                 frmEstadosEdicion frm = new frmEstadosEdicion(new List<string>());
                 frm.Show();
             }
         }

         protected override void abrirEdicion()
         {
             if (Utilitario.BuscaForm("frmEstadosTramiteEdicion"))
             {
                 ObtenerValoresPKListado();
                 frmEstadosEdicion frm = new frmEstadosEdicion(listar.VALORES_PK);
                 frm.Show();
             }
         }
    }
}
