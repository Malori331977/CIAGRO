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
    public partial class frmPeritosList : frmListado
    {
        public frmPeritosList():base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {

            listar.COLUMNAS = "(select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.IdColegiado) as [N° Colegiado], (select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.IdColegiado) as Nombre, (select NombreTipo from " + Consultas.sqlCon.COMPAÑIA + ".NV_TIPOS where CodigoTipo = t1.Tipo) as Tipo, t1.CodigoEmpresa as [Codigo Institución], (select NombreEmpresa from " + Consultas.sqlCon.COMPAÑIA + ".NV_EMPRESAS where CodigoEmpresa = t1.CodigoEmpresa) as Institución, (select NOMBRE from " + Consultas.sqlCon.COMPAÑIA + ".COBRADOR where COBRADOR = t1.Cobrador) as 'Nombre Cobrador',t1.IdColegiado as 'Id Colegiado'";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_PERITOS t1";
            listar.TABLA_ELIMINAR = "NV_PERITOS";
            listar.TITULO_LISTADO = "Lista de Peritos";
            listar.ORDERBY = "order by t1.IdColegiado";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("IdColegiado");
            listar.COLUMNAS_ALIAS_PK.Add("Id Colegiado");
            
            listar.COLUMNAS_OCULTAS.Add("Id Colegiado");
            listar.COLUMNAS_UILFG.Add("N° Colegiado");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.PERITAJES_INSERTAR;
            editar = Constantes.PERITAJES_EDITAR;
            borrar = Constantes.PERITAJES_BORRAR;
            seleccionar = Constantes.PERITAJES_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmPeritosEdicion"))
            {
                frmPeritosEdicion frm = new frmPeritosEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmPeritosEdicion"))
            {
                ObtenerValoresPKListado();
                string NumeroColegiado = "";
                NumeroColegiado = flvListado.SelectedItem.SubItems[flvListado.GetColumn("N° Colegiado").Index].Text;
                frmPeritosEdicion frm = new frmPeritosEdicion(listar.VALORES_PK,NumeroColegiado);
                frm.Show();
            }
        }
    }
}
