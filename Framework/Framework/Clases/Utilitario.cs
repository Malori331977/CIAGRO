using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Framework
{
	public class Utilitario
    {
        public static Boolean BuscaForm(String nombreForm)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == nombreForm)
                {
                    frm.Activate();
                    return false;
                }
            }
            return true;
        }


        public static Boolean FilaRepetidaGrid(ref DataGridView _dgv,String columnaBusqueda, String valorBusqueda,ref int fila)
        {
            bool repetido=false;
            try
            {
                for (int i = 0; i < _dgv.RowCount; i++)
                {
                    if (_dgv[columnaBusqueda, i].Value.ToString() != "")
                    {
                        if (_dgv[columnaBusqueda, i].Value.ToString() == valorBusqueda)
                        {
                            repetido = true;
                            fila = i + 1;
                        }
                    }
                }
                  
            }
            catch (Exception)
            {
                throw new Exception("[FilaRepetidaGrid] No fue posible evaluar datos duplicados en la tabla.");
            }

            return repetido;
        }

        public static bool EsNumero(string n)
        {
            bool _continuar = true;

            decimal v = 0;
            if (!decimal.TryParse(n, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out v))
            {
                _continuar = false;
            }
            return _continuar;
        }

        ///<summary>
        /// Validador numerico de string
        /// </summary>
        /// <param name="n">String a Validar</param>
        /// <para>El sistema validar sin String ingresado es número y mayor a cero,  caso contrario retornara zero</para>
        /// <remarks>
        /// Verifica si es numero
        /// </remarks>
        /// <returns>Boolean</returns>
        public static bool EsNumeroMayorCero(string n)
        {
            bool _continuar = true;

            decimal v = 0;
            if (!decimal.TryParse(n, out v))
            {
                _continuar = false;
            }

            if (_continuar == true)
            {
                if (v <= 0)
                {
                    _continuar = false;
                }
            }

            return _continuar;
        }

        /// <summary>
        /// JVG: 07-5-2015
        /// Valida si el string es una fecha
        /// </summary>
        /// <param name="n">string de fecha a validar</param>
        /// <returns>Boolean</returns>
        public static bool EsFecha(string n)
        {
            bool _continuar = true;
            DateTime v = new DateTime(1900, 1, 1);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            if (!DateTime.TryParse(n, out v))
            {
                _continuar = false;
            }
            return _continuar;
        }

        public static bool EsFechaValida(string n)
        {
            DateTime v = new DateTime(1900, 1, 1);
            /*
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            */

            if (!n.Contains('/'))
                return false;
            else
            {
                string fecha = n.Split('/')[2] + n.Split('/')[1] + n.Split('/')[0];
                if (!DateTime.TryParse(n, out v))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// JVG
        /// Valida un string como mail valido
        /// </summary>
        /// <param name="email">string a validar</param>
        /// <returns>Boolean</returns>
        public static Boolean esMailCorrecto(String email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return (true);
            else
                return (false);
        }

        /// <summary>
        /// JVG
        /// Formato celda
        /// </summary>
        /// <remarks>Formatea una celda estilo edición / lectura-escritura</remarks>
        /// <param name="dc">Celda</param>
        /// <param name="habilitado">Estado de edicion</param>
        public static void HabilitarCeldaGrid(DataGridViewCell dc, Boolean habilitado)
        {
            //toggle read-only state
            dc.ReadOnly = !habilitado;
            if (habilitado)
            {
                //Restaura el color normal de celda, lectura - escritura
                dc.Style.BackColor = dc.OwningColumn.DefaultCellStyle.BackColor;
                dc.Style.ForeColor = dc.OwningColumn.DefaultCellStyle.ForeColor;
                dc.ReadOnly = false;
            }
            else
            {
                //formato de celda, estilo read-only
                dc.Style.BackColor = System.Drawing.Color.LightGray;
                dc.Style.ForeColor = System.Drawing.Color.DarkGray;
                dc.ReadOnly = true;
                dc.Value = "";
            }
        }

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        public static Process GetExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
        {
            int id;
            GetWindowThreadProcessId(excelApp.Hwnd, out id);
            return Process.GetProcessById(id);
        }

        public static string getVolumeSerial()
        {
            string drive = "";
            foreach (DriveInfo compDrive in DriveInfo.GetDrives())
            {
                if (compDrive.IsReady)
                {
                    drive = compDrive.RootDirectory.ToString();
                    break;
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            string cpuID = getCPUID();
            disk.Dispose();

            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private static string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }


        private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 20, 11, 20, 02, 13, 02, 20, 14 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 20,11, 20, 02, 13, 02, 20, 14 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public static string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public static string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        public static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static bool comprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = @"\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    if (sEmailAComprobar.Split('@')[0].Contains("ñ") || sEmailAComprobar.Contains("í") || sEmailAComprobar.Contains("é") || sEmailAComprobar.Contains("ú") || sEmailAComprobar.Contains("á") || sEmailAComprobar.Contains("ó"))
                        return false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool validarExpresionRegular(string valor,string expresion)
        {
            if (Regex.IsMatch(valor, expresion))
            {
                if (Regex.Replace(valor, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
