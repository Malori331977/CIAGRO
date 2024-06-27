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
    public partial class FrmUsuariosList : frmListado
    {
        private FuncsInternas fInternas;

        public FrmUsuariosList()
            : base()
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "PrimerApellidoUsuario + ', ' + PrimerNombreUsuario as Nombre, CodigoUsuario as Código, CASE UsuarioActivo WHEN 0 THEN 'No' WHEN 1 THEN 'Si' ELSE 'No' END as Activo";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_USUARIOS";
            listar.TITULO_LISTADO = "Lista de Usuarios";
            listar.ORDERBY = "order by Nombre";
            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoUsuario");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            insertar = Constantes.USUARIOS_INSERTAR;
            editar = Constantes.USUARIOS_EDITAR;
            borrar = Constantes.USUARIOS_BORRAR;
            seleccionar = Constantes.USUARIOS_SELECCIONAR;

            actualizar();
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmEdicionUsuarios"))
            {
                ObtenerValoresPKListado();
                frmEdicionUsuarios frm = new frmEdicionUsuarios(listar.VALORES_PK);
                frm.Show();
            }
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmEdicionUsuarios"))
            {
                frmEdicionUsuarios frm = new frmEdicionUsuarios(new List<string>());
                frm.Show();
            }
        }
    }
}
