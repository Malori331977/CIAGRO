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
    public partial class FrmEmpresasList : frmListado
    {
        public FrmEmpresasList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoEmpresa as Código, NombreEmpresa as Empresa, case TipoEmpresa when 'A' then 'Privada' when 'U' then 'Pública' when 'N' then 'No Definido' else 'No Definido' end as Tipo, ContactoEmpresa as Contacto, TelefonosEmpresa as Teléfono, DireccionEmpresa as Dirección";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_EMPRESAS";
            listar.TITULO_LISTADO = "Lista de Empresas";
            listar.ORDERBY = "order by CodigoEmpresa";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoEmpresa");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            listar.COLUMNAS_UILFG.Add("Tipo");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.EMPRESAS_INSERTAR;
            editar = Constantes.EMPRESAS_EDITAR;
            borrar = Constantes.EMPRESAS_BORRAR;
            seleccionar = Constantes.EMPRESAS_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmEmpresasEdicion"))
            {
                frmEmpresasEdicion frm = new frmEmpresasEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmEmpresasEdicion"))
            {
                ObtenerValoresPKListado();
                frmEmpresasEdicion frm = new frmEmpresasEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
