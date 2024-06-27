using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Configuration;

namespace Framework
{
    public partial class frmAdjunto : Form
    {
        string formulario = "";
        string llave = "";
        string rutaArchivo = "";
        string error = "";

        public frmAdjunto(string formulario,string llave)
        {
            InitializeComponent();
            this.formulario = formulario;
            this.llave = llave;
            string destino = listaGlobal();
            if (destino != null)
            {
                if (destino.Equals("0"))
                {
                    rbServidor.Checked = true;
                }
                else
                {
                    rbArchivoDigital.Checked = true;
                }
            }

            if (ConfigurationManager.AppSettings["DBHosting"] != null)
            {
                if(ConfigurationManager.AppSettings["DBHosting"]=="WN")
                {
                    rbBD.Visible = false;
                    rbServidor.Visible = false;
                }
            }
        }

        private string listaGlobal()
        {
            DataTable dtGlobal = new DataTable();

            if (Consultas.fillDataTable("SELECT AdjuntoEnBaseDatos from "+Consultas.sqlCon.COMPAÑIA+".NV_GLOBALES", ref dtGlobal, ref error))
            {
                if (dtGlobal.Rows.Count > 0)
                {
                    return dtGlobal.Rows[0][0].ToString();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void btnCargar_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.btnCargar, "Seleccionar Archivo");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            DialogResult result = dialogo.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                txtNombreArchivo.Text = dialogo.SafeFileName;
                rutaArchivo = dialogo.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            byte[] file = null;
            string error="";
            string tipo="BD";
            string ruta = "";
            string nombreArchivo = txtNombreArchivo.Text;
            if (rbServidor.Checked)
                tipo="SERVIDOR";

            if (rbArchivoDigital.Checked)
                tipo = "DIGITAL";

            //if(bd)
            try
            {
                file = Consultas.GetArchivoAdjunto(rutaArchivo);

                if (tipo=="SERVIDOR")
                {
                    string sQuery = "SELECT RutaAlmacenamientoAdjuntos FROM "+Consultas.sqlCon.COMPAÑIA+".NV_GLOBALES";
                    DataTable dt = new DataTable();
                    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            ruta = dt.Rows[0][0].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (ruta == "")
                    {
                        MessageBox.Show("No se ha definido la ruta para el almacenamiento de archivos en el módulo de globales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        File.WriteAllBytes(ruta + txtNombreArchivo.Text, file);
                }
                else
                    if (tipo == "DIGITAL")
                        nombreArchivo = rutaArchivo;
                    

                //Comprimir 
                using (MemoryStream memory = new MemoryStream())
                {
                    using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Compress, true))
                    {
                        if (tipo=="BD")
                            gzip.Write(file, 0, file.Length);
                    }

                    if (Consultas.insertarAdjunto(formulario, llave, nombreArchivo, memory.ToArray(), txtDescripcion.Text, tipo, ref error))
                    {
                        MessageBox.Show("Se adjuntó el archivo con éxito", "Adjuntos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Close();
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el adjunto:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
