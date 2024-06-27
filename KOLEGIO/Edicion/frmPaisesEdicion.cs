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
    public partial class frmPaisesEdicion : frmEdicion
    {
        public frmPaisesEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 55;
            txtNacionalidad.Longitud = 55;
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Países";
                lblPerfil.Text = "Perfil de País";

                listar.COLUMNAS = "PAIS,NOMBRE";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "PAIS";
                identificadorFormulario = "De Países";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("PAIS");
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
                                txtNombre.Valor = row["NOMBRE"].ToString();
                                txtCodigo.Valor = row["PAIS"].ToString();
                                txtCodigo.ReadOnly = true;
                                //txtNacionalidad.Valor = row["Nacionalidad"].ToString();
                                lblPerfil.Text = "Perfil de País: " + txtNombre.Valor;
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
            //parametros.Add(txtNacionalidad.Valor);
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para el País.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el País.";
                txtNombre.Focus();
                return false;
            }
            //if (txtNacionalidad.Valor.Trim() == "")
            //{
            //    error = "Debe especificar una nacionalidad para el País.";
            //    txtNombre.Focus();
            //    return false;
            //}

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            //txtNacionalidad.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de País";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de País: " + txtNombre.Valor;
        }
    }
}
