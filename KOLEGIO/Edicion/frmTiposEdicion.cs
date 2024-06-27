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
    public partial class frmTiposEdicion : frmEdicion
    {
        public frmTiposEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 50;
            rtbDescripcion.Longitud = 1024;
            cargarDatos();


            cmbDiferenciador.SelectedValueChanged(new EventHandler(OnDiferenciadorValueChanged));
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Tipos";
                lblPerfil.Text = "Perfil de Tipo";

                listar.COLUMNAS = "CodigoTipo,Diferenciador,NombreTipo,DescripcionTipo,RequierePoliza,RequiereVidaSilvestre";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_TIPOS";
                identificadorFormulario = "De Tipos";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoTipo");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.TIPOS_INSERTAR;
                editar = Constantes.TIPOS_EDITAR;
                borrar = Constantes.TIPOS_BORRAR;
                seleccionar = Constantes.TIPOS_SELECCIONAR;

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

                cmbDiferenciador.agregarItems("CURSO");

                if (Globales.MANEJO_REGENCIAS.Equals("S"))
                    cmbDiferenciador.agregarItems("REGENTE");

                if (Globales.PERMITIR_PERITO.Equals("S"))
                    cmbDiferenciador.agregarItems("PERITO");

                cmbDiferenciador.Index = 0;

                chkPoliza.Enabled = false;
                chkVidaSilvestre.Enabled = false;

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["NombreTipo"].ToString();
                                txtCodigo.Valor = row["CodigoTipo"].ToString();
                                if (row["Diferenciador"].ToString() == "C")
                                    cmbDiferenciador.Index = 0;
                                else if (row["Diferenciador"].ToString() == "P")
                                    cmbDiferenciador.Index = 1;
                                else
                                    cmbDiferenciador.Index = 2;

                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionTipo"].ToString();
                                if (row["RequierePoliza"].ToString() == "S")
                                    chkPoliza.Checked = true;
                                else
                                    chkPoliza.Checked = false;
                                if (row["RequiereVidaSilvestre"].ToString() == "S")
                                    chkVidaSilvestre.Checked = true;
                                else
                                    chkVidaSilvestre.Checked = false;
                                lblPerfil.Text = "Perfil de Tipo: " + txtNombre.Valor;
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
            parametros.Add(cmbDiferenciador.Texto[0] + "");
            parametros.Add(txtNombre.Valor);
            parametros.Add(rtbDescripcion.Text);
            if (chkPoliza.Checked == true)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (chkVidaSilvestre.Checked == true)
                parametros.Add("S");
            else
                parametros.Add("N");
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para el Tipo.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Tipo.";
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
            chkPoliza.Checked = false;
            chkVidaSilvestre.Checked = false;
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Tipo";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Tipo: " + txtNombre.Valor;
        }

        private void OnDiferenciadorValueChanged(object sender, EventArgs e)
        {
            if (cmbDiferenciador.Index == 0)
			{
                chkPoliza.Enabled = false;
                chkVidaSilvestre.Enabled = false;
			} else
			{
                chkPoliza.Enabled = true;
                chkVidaSilvestre.Enabled = true;
            }
        }
    }
}
