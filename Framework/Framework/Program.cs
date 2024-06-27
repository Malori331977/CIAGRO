using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;


namespace Framework
{
    static class Program
    {
        public static Conexion ConexionBD = null;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (args.Length > 0)
                {
                    String Usuario = args[0];
                    String Compania = string.Empty;
                    String Password = string.Empty;

                    if (args.Length > 1)
                    {
                        Password = args[1];
                    }

                    if (args.Length > 2)
                    {
                        Compania = args[2];
                    }

                 
                    if (Usuario.ToUpper().Equals("SA") || Usuario.ToUpper().Equals("ERPADMIN") || Usuario.ToUpper() == Compania.ToUpper())
                    {
                        //comprabar usuario sa
                        ConexionBD = new Conexion(Usuario, Usuario, Password, Compania);
                        ConexionBD.getConexion();
                        ConexionBD.Open();
                        Consultas.sqlCon = ConexionBD;
                    }
                    else
                    {
                        //ConexionBD = new Conexion(p.getXUser(), Usuario, p.getXPassword().ToString(), Compania);
                        //comprobar usuario no-sa
                        //ConexionBD.getConexionInicial(p.getXUser(), p.getXPassword().ToString(), Compania);
                       // ConexionBD.Open();
                       // Consultas.sqlCon = ConexionBD;
                    }
                    Application.Run(new frmPrincipal());
                }
                else
                {

                    //Application.Run(new FIngreso());
                }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la aplicación: " + ex.Message, "Sincronización Documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
