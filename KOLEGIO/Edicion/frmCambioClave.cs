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
using System.Configuration;

namespace KOLEGIO
{
    public partial class frmCambioClave : Form
    {
        protected string error = "",claveVieja="";
        private int tipo = 0;
        public frmCambioClave(string usuario, string claveVieja,int tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            txtUsuario.Valor = usuario;
            txtClaveActual.Password = '•';
            txtNuevaClave.Password = '•';
            txtConfirmacion.Password = '•';
            txtUsuario.Mayusculas();
            txtClaveActual.Mayusculas();
            txtNuevaClave.Mayusculas();
            this.claveVieja = claveVieja;
            txtConfirmacion.Mayusculas();
            this.ActiveControl = txtClaveActual;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtClaveActual.Valor.Trim().Equals(""))
            {
                MessageBox.Show("La clave Actual es un campo requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClaveActual.Focus();
                return;
            }
            if (txtNuevaClave.Valor.Trim().Equals(""))
            {
                MessageBox.Show("La Nueva Clave es un campo requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNuevaClave.Focus();
                return;
            }
            if (txtClaveActual.Valor.Equals(txtNuevaClave.Valor))
            {
                MessageBox.Show("La Nueva Clave debe ser diferente de la Actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNuevaClave.Focus();
                return;
            }
            if (!txtConfirmacion.Valor.Equals(txtNuevaClave.Valor))
            {
                MessageBox.Show("La Confirmación de la clave no coincide.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmacion.Focus();
                return;
            }
            if (Char.IsDigit(txtNuevaClave.Valor[0]))
            {
                MessageBox.Show("La Nueva Clave no debe iniciar con un valor númerico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmacion.Focus();
                return;
            }
            error = "";
            string Usuario = txtUsuario.Valor.ToUpper();
            string Contrasena = txtClaveActual.Valor;
            if (!Usuario.Equals(Constantes.SA) && !Usuario.Contains(Constantes.SASEGDB_admin))
                Contrasena = Contrasena.ToUpper();
            FuncsInternas fInternas = new FuncsInternas();
            try
            {
               
                if (txtClaveActual.Valor.ToUpper() != claveVieja.ToUpper())
                    throw new Exception("La clave Actual es incorrecta.");

                if (ConfigurationManager.AppSettings["DBHosting"] == "WN")
                    fInternas.actualizaClaveUsuarioVirtual(txtUsuario.Valor, Utilitario.Encriptar(txtNuevaClave.Valor),ref error);
                else
                    fInternas.cambiarContrasenna(txtUsuario.Valor, txtClaveActual.Valor + Constantes.PASSWORD, txtNuevaClave.Valor + Constantes.PASSWORD, false, ref error);
                MessageBox.Show("Se cambió la clave correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (tipo == 1)
                {
                    this.Close();
                }
                txtClaveActual.Valor = string.Empty;
                txtNuevaClave.Valor = string.Empty;
                txtConfirmacion.Valor = string.Empty;
                this.ActiveControl = txtClaveActual;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCambioClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e);
            }
        }

        private void frmCambioClave_Load(object sender, EventArgs e)
        {
        }
    }
}
