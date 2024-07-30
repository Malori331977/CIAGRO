using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;
using Framework;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Globalization;

namespace KOLEGIO
{
    public partial class FIngreso : Form
    {
        private FileVersionInfo fvi;

        public FIngreso()
        {
            InitializeComponent();
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text = fvi.ProductName + " v" + fvi.FileVersion;
            if (txtUsuario.Text != string.Empty)
                this.ActiveControl = txtContrasena;
            cargarCombo();

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\KOLEGIO.rar"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\KOLEGIO.rar");
            }

            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Modis"))
            {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Modis", true);
            }

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cargarCombo()
        {
            cbCompania.Items.Clear();
            string[] companias = System.Configuration.ConfigurationManager.AppSettings["Compania"].Split(',');
            for (int i = 0; i < companias.Length; i++) cbCompania.Items.Add(companias[i].ToUpper());
            cbCompania.SelectedIndex = 0;
        }

        private bool cargarConfigDescargarFTP(string path, string usuario, string clave)
        {
            bool OK = true;

            Configuration configurationFTP =
            ConfigurationManager.OpenExeConfiguration(path);
            //"D:\\DOCUMENTOS\\DESA_SEGUROS\\_KOLEGIO\\Fuentes\\KOLEGIO\\KOLEGIO\\bin\\Debug\\descargarFTP.exe"
            configurationFTP.AppSettings.Settings["UsuarioFtp"].Value = Utilitario.Encriptar(usuario);
            configurationFTP.AppSettings.Settings["ClaveFtp"].Value = Utilitario.Encriptar(clave);
            configurationFTP.Save(ConfigurationSaveMode.Minimal);
            //ConfigurationManager.RefreshSection("appSettings");

            return OK;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Contrasena = txtContrasena.Text;
            string Compania = cbCompania.Text;
            bool actualizar = false;
            if (!Usuario.ToUpper().Equals(Constantes.SA) && !Usuario.Contains(Constantes.SASEGDB_admin))
            {
                if (ConfigurationManager.AppSettings["DBHosting"] == "WN" && !Usuario.ToUpper().Equals(Constantes.ADMSASEG))
                {
                    Contrasena = Contrasena.ToUpper();
                }
                else
                {
                    if (ConfigurationManager.AppSettings["DBHosting"] != "WN")
                    {
                        Contrasena = Contrasena.ToUpper();
                    }
                }
            }
            try
            {
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    Conexion conexion;

                    if (Usuario.ToUpper().Equals(Constantes.SA) || Usuario.ToUpper().Equals(Constantes.ADMSASEG) || Usuario.Contains(Constantes.SASEGDB_admin))
                    {
                        if (Usuario.ToUpper().Equals(Constantes.SA) || Usuario.ToUpper().Equals(Constantes.ADMSASEG))
                            conexion = new Conexion(Usuario.ToUpper(), Contrasena, cbCompania.Text);
                        else
                            conexion = new Conexion(Usuario, Contrasena, cbCompania.Text);
                        conexion.getConexion();
                        conexion.Open();
                        Consultas.sqlCon = conexion;
                        if (Usuario.ToUpper().Equals(Constantes.SA) || Usuario.ToUpper().Equals(Constantes.ADMSASEG))
                            Consultas.Usuario = Usuario.ToUpper();
                        else
                            Consultas.Usuario = Usuario;
                    }
                    else
                    {
                        bool noPass = false;
                        if (!string.IsNullOrEmpty(txtContrasena.Text))
                        {
                            if (txtUsuario.Text.Equals(txtContrasena.Text.ToUpper()))
                                noPass = true;

                            if (ConfigurationManager.AppSettings["DBHosting"] != null)
                            {
                                if (ConfigurationManager.AppSettings["DBHosting"] == "WN")
                                {
                                    Usuario = Utilitario.DesEncriptar(ConfigurationManager.AppSettings["UsuarioWN"]);
                                    Contrasena = Utilitario.DesEncriptar(ConfigurationManager.AppSettings["Password"]);
                                }
                                else
                                    Contrasena = Contrasena + Constantes.PASSWORD;
                            }
                            else
                                Contrasena = Contrasena + Constantes.PASSWORD;

                            conexion = new Conexion(Usuario, Contrasena, cbCompania.Text);
                            conexion.getConexion();
                            conexion.Open();
                            Consultas.sqlCon = conexion;
                            Consultas.Usuario = txtUsuario.Text.ToUpper();
                            Consultas.sqlCon.USUARIO = txtUsuario.Text.ToUpper();
                            Consultas.Contraseña = txtContrasena.Text;
                            DataTable usuarioInfo = conexion.EjecutarConsultaDataTable("SELECT UsuarioActivo,UsuarioReqCambioClave,FrecCambioClaveUsuario,FechaUltimoCambioClaveUsuario,ClaveSistemaAdicionalUsuario from " + Consultas.sqlCon.COMPAÑIA + ".NV_USUARIOS where CodigoUsuario = '" + Consultas.Usuario + "'");
                            if (usuarioInfo.Rows.Count > 0)
                            {
                                if (!Boolean.Parse(usuarioInfo.Rows[0]["UsuarioActivo"].ToString()))
                                {
                                    MessageBox.Show("El usuario no está activo en el sistema.", "KOLEGIO©", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtUsuario.Clear();
                                    txtContrasena.Clear();
                                    return;
                                }
                                if (ConfigurationManager.AppSettings["DBHosting"] != null)
                                {
                                    if (ConfigurationManager.AppSettings["DBHosting"] == "WN")
                                    {
                                        if (txtContrasena.Text.ToUpper() != Utilitario.DesEncriptar(usuarioInfo.Rows[0]["ClaveSistemaAdicionalUsuario"].ToString()))
                                        {
                                            MessageBox.Show("¡Contraseña Incorrecta!", "KOLEGIO©", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                }
                                if (!usuarioInfo.Rows[0]["UsuarioReqCambioClave"].ToString().Equals(""))
                                    if (Boolean.Parse(usuarioInfo.Rows[0]["UsuarioReqCambioClave"].ToString()) || noPass)
                                    {
                                        int dias = int.Parse(usuarioInfo.Rows[0]["FrecCambioClaveUsuario"].ToString());
                                        DateTime ultimoCambio = DateTime.Parse(usuarioInfo.Rows[0]["FechaUltimoCambioClaveUsuario"].ToString());
                                        //ultimoCambio = ultimoCambio.AddDays(dias);
                                        if ((DateTime.Now - ultimoCambio).Days >= dias || noPass)
                                        {
                                            if (MessageBox.Show("Su clave actual ha expirado.\n" +
                                                   "Debe cambiar su clave de ingreso para continuar.", "KOLEGIO©", MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Information) == DialogResult.Yes)
                                            {
                                                frmCambioClave frmCC = new frmCambioClave(Consultas.Usuario, txtContrasena.Text, 1);
                                                frmCC.ShowDialog();
                                                txtContrasena.Clear();
                                                txtContrasena.Focus();
                                                return;
                                            }
                                            else
                                            {
                                                txtContrasena.Clear();
                                                txtContrasena.Focus();
                                                return;
                                            }
                                        }
                                    }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo Contraseña está vacío", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtContrasena.Focus();
                            return;
                        }
                    }
                    if (ConfigurationManager.AppSettings["Usuario"] != null)
                    {
                        Configuration configuration =
                        ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                        configuration.AppSettings.Settings["Usuario"].Value = txtUsuario.Text;
                        configuration.Save(ConfigurationSaveMode.Minimal);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    if (!actualizar)
                    {
                        //DataTable versionGlobal = conexion.EjecutarConsultaDataTable("SELECT VersionSistema from " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES");
                        DataTable versionGlobal = conexion.EjecutarConsultaDataTable("SELECT MAX(VERSION) from dbo.CONTROL_VERSIONES");
                        if (versionGlobal.Rows.Count > 0)
                        {
                            if (versionGlobal.Rows[0][0].ToString().Equals(""))
                            {
                                MessageBox.Show("No se pudo llevar a cabo la revisión de la versión actual del KOLEGIO.", "KOLEGIO©", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                int versionBase = int.Parse(versionGlobal.Rows[0][0].ToString().Split('.')[3]);
                                int versionActual = int.Parse(fvi.FileVersion.ToString().Split('.')[3]);
                                if (versionActual > versionBase)
                                {
                                    MessageBox.Show("La versión del sistema es mayor a la versión de la base de datos, se debe aplicar una actualización para evitar posibles errores.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // conexion.EjecutarNonQuery("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES set VersionActual = '8.0.0." + versionActual + "'");
                                }
                                else
                                {
                                    if (versionActual < versionBase)
                                    {
                                        if (MessageBox.Show("Se ha detectado que hay disponible una nueva versión del KOLEGIO.\nVersión " + versionGlobal.Rows[0][0].ToString() +
                                            "\n\n¿Desea actualizar a la nueva versión?", "KOLEGIO© ", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information) == DialogResult.Yes)
                                        {
                                            string path = AppDomain.CurrentDomain.BaseDirectory;

                                            if (File.Exists(path + "descargarFTP.exe"))
                                            {
                                                actualizar = true;
                                                btnIngresar.Enabled = false;
                                                Process proc = new Process();
                                                proc.StartInfo.FileName = path + "descargarFTP.exe";
                                                //if (ConfigurationManager.AppSettings["DBHosting"] == "WN")
                                                //{
                                                //    proc.StartInfo.Arguments = Utilitario.DesEncriptar(ConfigurationManager.AppSettings["UsuarioWN"]) + " "
                                                //        + Utilitario.DesEncriptar(ConfigurationManager.AppSettings["Password"]) + " "
                                                //        + ConfigurationManager.AppSettings["Servidor"] + " " + ConfigurationManager.AppSettings["BaseDatos"];
                                                //}
                                                //else
                                                proc.StartInfo.Arguments = Consultas.Usuario + " " + Consultas.sqlCon.PASSWORD + " " +
                                                ConfigurationManager.AppSettings["Servidor"] + " " + ConfigurationManager.AppSettings["BaseDatos"]/* + " " + Consultas.sqlCon.COMPAÑIA*/;

                                                proc.Start();
                                                Application.Exit();
                                            }
                                            else
                                                MessageBox.Show("No fue posible localizar el utilitario para la actualización del sistema.", "KOLEGIO©", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        bool errorFTPCon = false;

                                        //FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.site4now.net/");
                                        //ftpRequest.Credentials = new NetworkCredential("ftpKOLEGIO", "@AdmKOLEGIO#2013!");
                                        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://geotime.gsitcr.com");
                                        ftpRequest.Credentials = new NetworkCredential("agronomos", "Listo123@");
                                        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                                        FtpWebResponse ftpResponse = null;
                                        StreamReader streamReader = null;

                                        try
                                        {
                                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                                            streamReader = new StreamReader(ftpResponse.GetResponseStream());
                                        }
                                        catch (Exception ex)
                                        {
                                            errorFTPCon = true;
                                            MessageBox.Show("Error conexion FTP\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                        if (!errorFTPCon)
                                        {
                                            
                                            string line = streamReader.ReadLine();
                                            List<string> directories = new List<string>();


                                            int versionFTP = 0;
                                            //Obtiene el contenido y lo agrega al List<string>.
                                            while (!string.IsNullOrEmpty(line))
                                            {
                                                if (line.Contains(".txt"))
                                                {
                                                    line = line.Replace(".txt", "");
                                                    versionFTP = int.Parse(line.Split('.')[3].Trim());
                                                    if (versionActual < versionFTP)
                                                    {
                                                        if (MessageBox.Show("Se ha detectado que hay disponible una nueva versión del KOLEGIO.\nVersión " + line +
                                                           "\n\n¿Desea actualizar a la nueva versión?", "KOLEGIO© ", MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Information) == DialogResult.Yes)
                                                        {
                                                            string path = AppDomain.CurrentDomain.BaseDirectory;

                                                            if (File.Exists(path + "descargarFTP.exe"))
                                                            {
                                                                actualizar = true;
                                                                btnIngresar.Enabled = false;
                                                                Process proc = new Process();
                                                                proc.StartInfo.FileName = path + "descargarFTP.exe";
                                                                proc.StartInfo.Arguments = Usuario + " " + Consultas.sqlCon.PASSWORD + " " +
                                                                ConfigurationManager.AppSettings["Servidor"] + " " + ConfigurationManager.AppSettings["BaseDatos"]/* + " " + Consultas.sqlCon.COMPAÑIA*/;
                                                                proc.Start();
                                                                Application.Exit();
                                                            }
                                                            else
                                                                MessageBox.Show("No fue posible localizar el utilitario para la actualización del sistema.", "KOLEGIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                }
                                                line = streamReader.ReadLine();
                                            }
                                            streamReader.Close();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo llevar a cabo la revisión de la versión actual del KOLEGIO.", "KOLEGIO© ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        frmMenu frm;
                        if (Usuario.ToUpper().Equals(Constantes.SA) || Usuario.ToUpper().Equals(Constantes.ADMSASEG))
                        {
                            frm = new frmMenu(Usuario.ToUpper());
                        }
                        else
                        {
                            frm = new frmMenu(txtUsuario.Text);
                        }

                        this.Hide();
                        frm.Show(this);
                    }
            }
                else
                {
                    MessageBox.Show("El campo Usuario está vacío", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                btnIngresar_Click(sender, e);
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                btnIngresar_Click(sender, e);
            }
        }

        private void FIngreso_Load(object sender, EventArgs e)
        {
            try
            {
                string sentencia = "Se han identificado los siguientes problemas en su Configuración Regional:" + "\n" + "\n";
                string param = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator;
                if (!param.Equals(","))
                    sentencia += "- El Separador de Listas no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a ','." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol;
                if (!param.Equals("₡") && !param.Equals("¢"))
                    sentencia += "- El Símbolo Monetario no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a '¢'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                if (!param.Equals("."))
                    sentencia += "El Separador Decimal no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a '.'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
                if (!param.Equals(","))
                    sentencia += "- El Separador de Miles no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a ','." + "\n";

                string[] yyyy = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.Split('/');
                if (yyyy.Length > 0)
                {
                    if (!yyyy[0].Equals("yyyy"))
                        sentencia += "- El Formato de Año no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a 'yyyy'." + "\n";
                    if (yyyy.Length > 1)
                    {
                        if (!yyyy[1].Equals("yyyy"))
                            sentencia += "- El Formato de Año no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a 'yyyy'." + "\n";
                    }
                        
                }
                param = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (!param.Equals("dd/MM/yyyy"))
                    sentencia += "- El Formato de Fecha no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a 'dd/MM/yyyy'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern;
                if (!param.Equals("hh:mm:ss tt"))
                    sentencia += "- El Formato de Hora no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a 'hh:mm:ss tt'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.AMDesignator;
                if (!param.Equals("AM"))
                    sentencia += "El Símbolo AM no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a 'AM'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.PMDesignator;
                if (!param.Equals("PM"))
                    sentencia += "- El Símbolo PM no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a 'PM'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (!param.Equals("."))
                    sentencia += "- El Separador Decimal para valores monetarios no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a '.'." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator;
                if (!param.Equals(","))
                    sentencia += "- El Separador de Miles para valores monetarios no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a ','." + "\n";

                param = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

                if (!param.Equals("es-CR"))
                    sentencia += "- El Lenguaje no es el apropiado. A fin de evitar posibles problemas en el sistema se recomienda cambiarlo a Español (Costa Rica)." + "\n";

                if (ConfigurationManager.AppSettings["Usuario"] != null)
                {
                    if (ConfigurationManager.AppSettings["Usuario"] != string.Empty)
                    {
                        txtUsuario.Text = ConfigurationManager.AppSettings["Usuario"];
                        this.ActiveControl = txtContrasena;
                    }
                }

                if (sentencia != "Se han identificado los siguientes problemas en su Configuración Regional:" + "\n" + "\n")
                {
                    sentencia += "\n" + "ES RECOMENDABLE APLICAR LOS CAMBIOS INDICADOS EN LA CONFIGURACION REGIONAL DE SU ESTACION PARA NO TENER PROBLEMAS EN LOS FORMATOS DE FECHAS Y NUMEROS.";
                    //MessageBox.Show(sentencia, "KOLEGIO©  " + DateTime.Now.Year, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show(sentencia, "KOLEGIO© ", MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CultureInfo newCulture = new CultureInfo("es-CR");
                        newCulture.TextInfo.ListSeparator = ",";
                        newCulture.NumberFormat.CurrencySymbol = "₡";
                        newCulture.NumberFormat.CurrencyDecimalSeparator = ".";
                        newCulture.NumberFormat.CurrencyGroupSeparator = ",";
                        newCulture.DateTimeFormat.AMDesignator = "AM";
                        newCulture.DateTimeFormat.PMDesignator = "PM";
                        newCulture.NumberFormat.NumberDecimalSeparator = ".";
                        newCulture.NumberFormat.NumberGroupSeparator = ",";
                        newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                        newCulture.DateTimeFormat.LongTimePattern = "hh:mm:ss tt";
                        System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
                        //Console.WriteLine("es-CR" + " ---> " + DateTime.Now);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Atención");
            }
            
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
            cargarCombo();
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (!txtUsuario.Text.ToUpper().Equals(Constantes.SA) && !txtUsuario.Text.Contains(Constantes.SASEGDB_admin))
                txtUsuario.Text = txtUsuario.Text.ToUpper();
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (!txtUsuario.Text.Trim().Equals(""))
            {
                if (!txtUsuario.Text.ToUpper().Equals(Constantes.SA) && !txtUsuario.Text.Contains(Constantes.SASEGDB_admin))
                    if (ConfigurationManager.AppSettings["DBHosting"] == "WN" && !txtUsuario.Text.ToUpper().Equals(Constantes.ADMSASEG))
                    {

                        txtContrasena.Text = txtContrasena.Text.ToUpper();
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["DBHosting"] != "WN")
                        {
                            txtContrasena.Text = txtContrasena.Text.ToUpper();
                        }
                    }
            }
        }
    }
}
