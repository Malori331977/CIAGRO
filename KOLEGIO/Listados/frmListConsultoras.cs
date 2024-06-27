using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOLEGIO
{
    public partial class frmListConsultoras : frmListado
    {
        public frmListConsultoras()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "t1.Codigo as Código,t1.CedulaJuridica as [Cedula Juridica],t1.Nombre,t1.Telefono,(select NOMBRE from " + Consultas.sqlCon.COMPAÑIA + ".DIVISION_GEOGRAFICA1 where DIVISION_GEOGRAFICA1 = t1.Provincia) as Provincia,(select NombreEstado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS where CodigoEstado = t1.Estado) as Estado";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CONSULTORAS t1";
            listar.TABLA_ELIMINAR = "NV_CONSULTORAS";
            listar.TITULO_LISTADO = "Lista de Compañias Consultoras";
            listar.ORDERBY = "order by Codigo";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("Codigo");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            listar.COLUMNAS_OCULTAS.Add("CodigoProvincia");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.CONSULTORA_INSERTAR;
            editar = Constantes.CONSULTORA_EDITAR;
            borrar = Constantes.CONSULTORA_BORRAR;
            seleccionar = Constantes.CONSULTORA_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmConsultorasEdicion"))
            {

                frmConsultorasEdicion frm = new frmConsultorasEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmConsultorasEdicion"))
            {
                ObtenerValoresPKListado();
               
                    frmConsultorasEdicion frm = new frmConsultorasEdicion(listar.VALORES_PK);
                    frm.Show();
                
            }
        }
    }
}
