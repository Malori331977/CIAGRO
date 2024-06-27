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
    public partial class frmRegentesList : frmListado
    {
        public frmRegentesList() : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {

            listar.COLUMNAS = "(select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as [N° Colegiado], (select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as [Nombre Colegiado], (select NOMBRE from " + Consultas.sqlCon.COMPAÑIA + ".COBRADOR where COBRADOR = t1.Cobrador) as 'Nombre Cobrador',(select NombreTipo from "+Consultas.sqlCon.COMPAÑIA+".NV_TIPOS where CodigoTipo = t1.Tipo) as Tipo, t1.SesionAprobacion,t1.FechaSesionAprobacion as 'Fecha Sesión Aprobación',t1.NumeroColegiado as 'NumCole',t1.Cobrador";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_REGENTES t1";
            listar.TABLA_ELIMINAR = "NV_REGENTES";
            listar.TITULO_LISTADO = "Lista de Regentes";
            listar.ORDERBY = "order by t1.NumeroColegiado";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("NumeroColegiado");
            listar.COLUMNAS_ALIAS_PK.Add("NumCole");
            
            listar.COLUMNAS_FECHAS.Add("FechaSesionAprobacion");
            listar.COLUMNAS_OCULTAS.Add("NumCole");
            listar.COLUMNAS_OCULTAS.Add("Cobrador");

            listar.COLUMNAS_UILFG.Add("N° Colegiado");



            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.REGENCIAS_INSERTAR;
            editar = Constantes.REGENCIAS_EDITAR;
            borrar = Constantes.REGENCIAS_BORRAR;
            seleccionar = Constantes.REGENCIAS_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmRegentesEdicion"))
            {
                frmRegentesEdicion frm = new frmRegentesEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmRegentesEdicion"))
            {
                ObtenerValoresPKListado();
                string NumeroColegiado = "";
                NumeroColegiado = flvListado.SelectedItem.SubItems[flvListado.GetColumn("N° Colegiado").Index].Text;
                frmRegentesEdicion frm = new frmRegentesEdicion(listar.VALORES_PK, NumeroColegiado);
                frm.Show();
            }
        }
    }
}
