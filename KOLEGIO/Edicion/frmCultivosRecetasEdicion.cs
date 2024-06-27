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
    public partial class frmCultivosRecetasEdicion : frmEdicion
    {
        public frmCultivosRecetasEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 50;
            rtbDescripcion.Longitud = 1024;
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Maantenimiento de Cultivos para Recetas Vía Aérea";
                lblPerfil.Text = "Perfil de Cultivo Receta";

                listar.COLUMNAS = "CodigoCultivo,NombreCultivo,DescripcionCultivo";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_CULTIVOS_RECETAS";
                identificadorFormulario = "De Cultivos Recetas";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoCultivo");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.CULTIVOS_RECETAS_INSERTAR;
                editar = Constantes.CULTIVOS_RECETAS_EDITAR;
                borrar = Constantes.CULTIVOS_RECETAS_BORRAR;
                seleccionar = Constantes.CULTIVOS_RECETAS_SELECCIONAR;

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
                                txtNombre.Valor = row["NombreCultivo"].ToString();
                                txtCodigo.Valor = row["CodigoCultivo"].ToString();
                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionCultivo"].ToString();
                                lblPerfil.Text = "Perfil de Cultivo Receta: " + txtNombre.Valor;
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
                error = "Debe especificar un código para el Cultivo de Receta.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Cultivo de Receta.";
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
            lblPerfil.Text = "Perfil de Cultivo Receta";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Cultivo Receta: " + txtNombre.Valor;
        }
    }
}
