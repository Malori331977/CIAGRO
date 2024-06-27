using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Framework
{
    public class ConexionNUBE
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataAdapter adaptador;
        //private SqlDataReader lector;
        private DataTable dt;
        private SqlTransaction transaccion;

        string xusuario,usuario, contraseña, compañia, servidor, baseDatos;

        public ConexionNUBE(string usuario,string contraseña,string compañia)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.compañia = compañia;
            this.servidor = "sql7003.site4now.net";
            this.baseDatos = "DB_A2D15F_PADRONCR";
        }

        public ConexionNUBE()
        {

        }

        public ConexionNUBE(string usuario, string xUsuario, string contraseña, string compañia)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.compañia = compañia;
            this.xusuario = xUsuario;
            this.servidor = "sql7003.site4now.net";
            this.baseDatos = "DB_A2D15F_PADRONCR";
        }

        public SqlConnection getConexion()
        {
            return conexion = new SqlConnection("Data Source=" + this.servidor + "; Initial Catalog=" + this.baseDatos + "; user id=" + this.usuario + ";password=" + this.contraseña);

        }

        public SqlConnection getConexionInicial(string usuarioGui, string contrasenaGui,string bd,string serv)
        {

            return conexion = new SqlConnection("Data Source=" + serv + "; Initial Catalog=" + bd + "; user id=" + usuarioGui + ";password=" + contrasenaGui);
        }

        public void Open()
        {
            try
            {
                conexion.Open();
            }
            catch(Exception ex)
            {
                throw new Exception("No fue posible abrir la conexion a la base de datos:\n" + ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible cerrar la conexion de la base de datos:\n" + ex.Message);
            }
        }

        public string USUARIO
        {
            get {return this.usuario;}
            set { this.usuario = value; }
        }

        public string COMPAÑIA
        {
            get { return this.compañia; }
            set { this.compañia = value; }
        }

        public string PASSWORD
        {
            get { return this.contraseña; }
            set { this.contraseña = value; }
        }

        public SqlCommand COMMAND
        {
            get { return this.comando; }
            set { comando = value; }
        }

        public SqlTransaction TRANSACCION
        {
            get { return this.transaccion; }
            set { transaccion = value; }
        }

        ///<summary>
        ///Abre una Transaccion, despues de abrirla todas las consultas que se hagan se hacen bajo esta transaccion
        ///
        ///</summary>
        public bool iniciaTransaccion()
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                this.transaccion = conexion.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error iniciando la transaccion:\n" + ex.Message);
            }
        }

        ///<summary>
        ///Se hace commit a la transaccion abierta
        ///en caso de no existir una abierta le manda el aviso al usuario
        ///</summary>
        public bool Commit()
        {
            try
            {
                if (transaccion != null)
                {
                    transaccion.Commit();
                    transaccion = null;
                    return true;
                }
                else
                {
                    throw new Exception("No existe ninguna transacción abierta para realizar un commit.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el commit de la transacción:\n" + ex.Message);
            }
        }

        ///<summary>
        ///Se hace rollback a la transaccion abierta
        ///en caso de no existir una abierta le manda el aviso al usuario
        ///</summary>
        public bool Rollback()
        {
            try
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                    transaccion = null;
                    return true;
                }
                else
                {
                    throw new Exception("No existe ninguna transacción abierta para realizar un Rollback.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el Rollback de la transacción:\n" + ex.Message);
            }
        }

        ///<summary>
        ///Ejecuta la sentencia pasada como parámetro junto con el command, asigna esta
        ///sentencia a un DataTable
        ///</summary>
        public DataTable EjecutarConsultaDataTable(string sentencia,SqlCommand command)
        {
            adaptador = null;
            dt = new DataTable();
            this.comando = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                command.Connection = conexion;
                command.CommandText = sentencia;
                adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.SelectCommand.Transaction = transaccion;
                adaptador.SelectCommand.CommandTimeout = 0;
                adaptador.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ejecutando la consulta de DataReader:\n"+ex.Message);
            }

            finally
            {
                this.adaptador.Dispose();
                this.adaptador = null;

            }
        }


        ///<summary>
        ///Ejecuta la sentencia pasada como parámetro, asigna esta
        ///sentencia a un DataTable
        ///</summary>
        public DataTable EjecutarConsultaDataTable(string sentencia)
        {
            adaptador = null;
            dt = new DataTable();
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                adaptador = new SqlDataAdapter(sentencia,this.conexion);
                adaptador.SelectCommand.Transaction = transaccion;
                adaptador.SelectCommand.CommandTimeout = 0;
                adaptador.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ejecutando la consulta de DataReader:\n" + ex.Message);
            }

            finally
            {
                this.adaptador.Dispose();
                this.adaptador = null;
            }
        }

        /// <summary>
        /// Ejecuta una sentencia que no consulta
        /// </summary>
        /// <returns>Entero indicando la cantidad de filas afectadas</returns>
        public int EjecutarNonQuery(string sentencia)
        {
            int filasModificadas = 0;
            this.comando = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                this.comando = new SqlCommand(sentencia, this.conexion, transaccion);
                filasModificadas = this.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ejecutando la consulta:\n" + ex.Message);
            }

            finally
            {
                this.comando.Dispose();
                this.comando = null;
            }

            return filasModificadas;
        }


        /// <summary>
        /// Ejecuta una sentencia que no consulta
        /// </summary>
        /// <returns>Entero indicando la cantidad de filas afectadas</returns>
        public int EjecutarNonQuery(string sentencia,SqlCommand command)
        {
            int filasModificadas = 0;
            this.comando = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                command.Connection = conexion;
                command.CommandText = sentencia;
                this.comando = command;
                this.comando.Transaction = transaccion;
                filasModificadas = this.comando.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error ejecutando la consulta:\n" + ex.Message);
            }

        /*    finally
            {
                this.comando.Dispose();
                this.comando = null;
            }*/

            return filasModificadas;
        }

        public object ExecuteEscalar(string sentencia)
        {
            object dato;
            this.comando = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                this.comando = new SqlCommand(sentencia, this.conexion, transaccion);
                dato = this.comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ejecutando la consulta:\n" + ex.Message);
            }

            finally
            {
                this.comando.Dispose();
                this.comando = null;
            }

            return dato;
        }
    }
}
