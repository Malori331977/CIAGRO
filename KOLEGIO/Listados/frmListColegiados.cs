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
    public partial class frmListColegiados : frmListado
    {
        string Usuario = "";
        public frmListColegiados(string usuario = "")
              : base()
        {
            Usuario = usuario;
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "IdColegiado as 'Id Colegiado', [N° Colegiado], [Cédula], Nombre, [Fecha Nacimiento], [Fecha Ingreso], Condición, Teléfono, [Correo Electrónico], [Último Cobro]";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_COLEGIADO_INDEX";
            listar.TITULO_LISTADO = "Lista de Colegiados";
            listar.ORDERBY = "order by IdColegiado";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("IdColegiado");
            listar.COLUMNAS_ALIAS_PK.Add("Id Colegiado");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            listar.COLUMNAS_FECHAS.Add("Fecha Nacimiento");
            listar.COLUMNAS_FECHAS.Add("Fecha Ingreso");
            listar.COLUMNAS_FECHAS.Add("Último Cobro");

            insertar = Constantes.COLEGIADOS_INSERTAR;
            editar = Constantes.COLEGIADOS_EDITAR;
            borrar = Constantes.COLEGIADOS_BORRAR;
            seleccionar = Constantes.COLEGIADOS_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmColegiadosEdicion"))
            {
                frmColegiadosEdicion frm = new frmColegiadosEdicion(new List<string>(),Usuario);
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmColegiadosEdicion"))
            {
                ObtenerValoresPKListado();
                frmColegiadosEdicion frm = new frmColegiadosEdicion(listar.VALORES_PK,Usuario);
                frm.Show();
            }
        }
        
    }
}
