using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace KOLEGIO
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
            leerDatos();
            rtbCompanias.KeyPress += new KeyPressEventHandler(rtbCompanias_KeyPress); 
        }

        private void leerDatos()
        {
            rtbCompanias.Text = ConfigurationManager.AppSettings["Companias"];
            txtServidor.Text = ConfigurationManager.AppSettings["Servidor"];
            txtBaseDatos.Text = ConfigurationManager.AppSettings["BaseDatos"];
        }

        private void rtbCompanias_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

     
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

                config.AppSettings.Settings["Servidor"].Value = txtServidor.Text;
                config.AppSettings.Settings["BaseDatos"].Value = txtBaseDatos.Text;
                config.AppSettings.Settings["Compania"].Value = rtbCompanias.Text;
             

                config.Save(ConfigurationSaveMode.Minimal);
                ConfigurationManager.RefreshSection("appSettings");
                MessageBox.Show("Configuración guardada.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
      
    }
}
