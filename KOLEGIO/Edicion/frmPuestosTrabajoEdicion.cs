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
    public partial class frmPuestosTrabajoEdicion : frmEdicion
    {
        public frmPuestosTrabajoEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 200;
            rtbDescripcion.Longitud = 1024;
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Puestos de Trabajo";
                lblPerfil.Text = "Perfil de Puesto de Trabajo";

                listar.COLUMNAS = "CodigoPuesto,NombrePuesto,DescripcionPuesto";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_PUESTOS";
                identificadorFormulario = "De Puestos";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoPuesto");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.PUESTOS_TRABAJO_INSERTAR;
                editar = Constantes.PUESTOS_TRABAJO_EDITAR;
                borrar = Constantes.PUESTOS_TRABAJO_BORRAR;
                seleccionar = Constantes.PUESTOS_TRABAJO_SELECCIONAR;

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
                                txtNombre.Valor = row["NombrePuesto"].ToString();
                                txtCodigo.Valor = row["CodigoPuesto"].ToString();
                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionPuesto"].ToString();
                                lblPerfil.Text = "Perfil de Puesto de Trabajo: " + txtNombre.Valor;
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
            parametros.Add(rtbDescripcion.Text);
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para el Puesto de Trabajo.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Puesto de Trabajo.";
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
            rtbDescripcion.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Puesto de Trabajo";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Puesto de Trabajo: " + txtNombre.Valor;
        }
    }
}
