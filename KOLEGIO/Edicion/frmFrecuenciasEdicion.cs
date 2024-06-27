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
    public partial class frmFrecuenciasEdicion : frmEdicion
    {
        public frmFrecuenciasEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 50;
            txtDuracion.Right();
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Frecuencias de Pago";
                lblPerfil.Text = "Perfil de Frecuencia de Pago";

                listar.COLUMNAS = "CodigoFrecuencia,NombreFrecuencia,DuracionFrecuencia";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_FRECUENCIAS";
                identificadorFormulario = "De Frecuencias";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoFrecuencia");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                //insertar = Constantes.TT_INSERTAR;
                //editar = Constantes.TT_EDITAR;
                //borrar = Constantes.TT_BORRAR;
                //seleccionar = Constantes.TT_SELECCIONAR;

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
                                txtNombre.Valor = row["NombreFrecuencia"].ToString();
                                txtCodigo.Valor = row["CodigoFrecuencia"].ToString();
                                txtCodigo.ReadOnly = true;
                                txtDuracion.Valor = row["DuracionFrecuencia"].ToString();
                                lblPerfil.Text = "Perfil de Frecuencia de Pago: " + txtNombre.Valor;
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
            parametros.Add(txtDuracion.Valor);
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para la Frecuencia de Pago.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para la Frecuencia de Pago.";
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
            txtDuracion.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Frecuencia de Pago";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Frecuencia de Pago: " + txtNombre.Valor;
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
