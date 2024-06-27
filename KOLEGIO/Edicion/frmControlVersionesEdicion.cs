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
    public partial class frmControlVersionesEdicion : frmEdicion
    {
        public frmControlVersionesEdicion(List<string> valoresPk)
          : base(valoresPk)
        {
            InitializeComponent();
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 16;
            cargarDatos();
        }


        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Control Versiones";
                lblPerfil.Text = "Perfil de Control Versión";

                listar.COLUMNAS = "Version,Cia,Fecha,Detalle";
                listar.COMPAÑIA = "dbo";
                listar.TABLA = "CONTROL_VERSIONES";
                identificadorFormulario = "De Control Versiones";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("Version");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

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
                                txtCodigo.Valor = row["Version"].ToString();
                                txtCia.Valor = row["Cia"].ToString();
                                dtpFecha.Value = DateTime.Parse(row["Fecha"].ToString());
                                rtbDescripcion.Text = row["Detalle"].ToString();
                                lblPerfil.Text = "Perfil de Control Versión: " + txtCodigo.Valor;
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
            /*  parametros.Clear();
              parametros.Add(txtCodigo.Valor);
              parametros.Add(dtpFecha.Value.ToString("yyyy-MM-dd"));
              parametros.Add(rtbDescripcion.Text);*/
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            return true;
        }

        protected override void limpiarFormulario()
        {

        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Versión KOLEGIO: " + txtCodigo.Valor;
        }

    }
}
