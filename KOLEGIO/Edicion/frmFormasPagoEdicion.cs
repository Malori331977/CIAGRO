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
    public partial class frmFormasPagoEdicion : frmEdicion
    {
        public frmFormasPagoEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 15;
            txtNombre.Longitud = 50;
            txtCuenta.Longitud = 50;
            txtCuentaComision.Longitud = 50;
            txtComision.Right();
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Formas de Pago";
                lblPerfil.Text = "Perfil de Forma de Pago";

                listar.COLUMNAS = "CodigoForma,NombreForma,CreditoForma,Cuenta,Comision,CuentaComision";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_FORMAS_PAGO";
                identificadorFormulario = "De Formas";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoForma");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.FORMAS_PAGO_INSERTAR;
                editar = Constantes.FORMAS_PAGO_EDITAR;
                borrar = Constantes.FORMAS_PAGO_BORRAR;
                seleccionar = Constantes.FORMAS_PAGO_SELECCIONAR;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void cargarDatos()
        {
            try
            {
                tabControl.TabPages.Remove(tpAdjuntos);
                tabControl.TabPages.Remove(tpAdmin);
                tabControl.TabPages.Add(tpAdmin);

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["NombreForma"].ToString();
                                txtCodigo.Valor = row["CodigoForma"].ToString();
                                txtCodigo.ReadOnly = true;
                                txtCuenta.Valor = row["Cuenta"].ToString();
                                txtCuentaComision.Valor = row["CuentaComision"].ToString();
                                if (row["CreditoForma"].ToString().Equals("1"))
                                    chkCredito.Checked = true;
                                txtComision.Valor = decimal.Parse(row["Comision"].ToString()).ToString("N2");
                                lblPerfil.Text = "Perfil de Forma de Pago: " + txtNombre.Valor;
                            }
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtCodigo.Valor);
            parametros.Add(txtNombre.Valor);
            if (chkCredito.Checked)
                parametros.Add("1");
            else
                parametros.Add("0");
            parametros.Add(txtCuenta.Valor);
            parametros.Add(txtComision.Valor);
            parametros.Add(txtCuentaComision.Valor);
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para la Forma de Pago.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para la Forma de Pago.";
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            txtCuenta.Clear();
            txtCuentaComision.Clear();
            chkCredito.Checked = false;
            txtComision.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Forma de Pago";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Forma de Pago: " + txtNombre.Valor;
        }
    }
}
