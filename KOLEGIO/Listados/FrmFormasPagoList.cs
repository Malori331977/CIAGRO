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
    public partial class FrmFormasPagoList : frmListado
    {
        public FrmFormasPagoList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoForma as Código, NombreForma as Nombre, case CreditoForma when '1' then 'Si' when '0' then 'No' else 'No Definido' end as Crédito, Cuenta,Comision as Comisión,CuentaComision as 'Cuenta Comisión'";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_FORMAS_PAGO";
            listar.TITULO_LISTADO = "Lista de Formas de Pago";
            listar.ORDERBY = "order by CodigoForma";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoForma");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            listar.COLUMNAS_UILFG.Add("Crédito");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            listar.COLUMNAS_NUMERICAS.Add("Comisión");

            insertar = Constantes.FORMAS_PAGO_INSERTAR;
            editar = Constantes.FORMAS_PAGO_EDITAR;
            borrar = Constantes.FORMAS_PAGO_BORRAR;
            seleccionar = Constantes.FORMAS_PAGO_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmFormasPagoEdicion"))
            {
                frmFormasPagoEdicion frm = new frmFormasPagoEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmFormasPagoEdicion"))
            {
                ObtenerValoresPKListado();
                frmFormasPagoEdicion frm = new frmFormasPagoEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }
    }
}
