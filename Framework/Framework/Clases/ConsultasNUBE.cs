using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace Framework
{
    public class ConsultasNUBE
    {
        public static ConexionNUBE sqlCon;
        public static string Usuario,Contraseña,UsuarioADMIN;

        public static bool listarDatos(Listado listar,ref DataTable dt, ref string error)
        {
            if (listar.COLUMNAS == "")
                return true;

            dt = new DataTable();
            error = "";
            try
            {
                string strSQL = " SELECT "+listar.COLUMNAS+" FROM "+listar.COMPAÑIA+"."+listar.TABLA+" "+listar.FILTRO+" "+listar.ORDERBY;
                dt = sqlCon.EjecutarConsultaDataTable(strSQL);
            }
            catch (Exception ex)
            {
                error = "[listarDatos] Ocurrió un error al tratar de listar los datos: \n\n" + ex.Message;
                return false;
            }
            return true;
        }

        public static bool listarDatosAuditoria(Listado listar, ref DataTable dt, ref string error)
        {
            dt = new DataTable();
            error = "";
            try
            {
                string strSQL = " SELECT T1.UsuarioCreacionAdmin,T1.FechaCreacionAdmin,T1.UsuarioUltModificacionAdmin,"+
                    "T1.FechaUltModificacionAdmin,(SELECT PrimerNombreUsuario + ' '+ PrimerApellidoUsuario + ' ' + SegundoApellidoUsuario FROM "+
                    "DBO.USUARIOS WHERE T1.UsuarioCreacionAdmin=CodigoUsuario) NombreUsuarioCreacion,"+
                    "(SELECT PrimerNombreUsuario + ' '+ PrimerApellidoUsuario + ' ' + SegundoApellidoUsuario FROM " +
                    "DBO.USUARIOS WHERE T1.UsuarioUltModificacionAdmin=CodigoUsuario) NombreUsuarioModificacion FROM "
                    + listar.COMPAÑIA + "." + listar.TABLA + " T1 " +listar.FILTRO;
                dt = sqlCon.EjecutarConsultaDataTable(strSQL);
            }
            catch (Exception ex)
            {
                error = "[listarDatosAuditoria] Ocurrió un error al tratar de listar los datos de auditoría: \n\n" + ex.Message;
                return false;
            }
            return true;
        }

        public static bool fillDataTable(string sentencia, ref DataTable dt, ref string error)
        {
            dt = new DataTable();
            error = "";
            try
            {
                dt = sqlCon.EjecutarConsultaDataTable(sentencia);
            }
            catch (Exception ex)
            {
                error = "[fillDataTable] Ocurrió un error al obtener los datos: \n\n" + ex.Message;
                return false;
            }
            return true;
        }

        public static bool fillDataTableParametros(string sentencia,List<string>parametros, ref DataTable dt, ref string error)
        {
            dt = new DataTable();
            sqlCon.COMMAND = new SqlCommand();
            for (int i=0; i<parametros.Count; i++)
            {
                sqlCon.COMMAND.Parameters.AddWithValue(parametros[i].Split(',')[0], parametros[i].Split(',')[1]);
            }
            error = "";
            try
            {
                dt = sqlCon.EjecutarConsultaDataTable(sentencia,sqlCon.COMMAND);
            }
            catch (Exception ex)
            {
                error = "[fillDataTable] Ocurrió un error al obtener los datos: \n\n" + ex.Message;
                return false;
            }
            return true;
        }

        public static bool eliminaRegistro(Listado listar,string identificadorFormulario, ref string error)
        {
            bool lbOk = true;
            string where = " WHERE ";
            int colsPK=listar.COLUMNAS_PK.Count;
            try
            {
                for (int i = 0; i < colsPK; i++)
                {
                    if (colsPK > 1)
                    {
                        if (i + 1 < colsPK)
                            where = where + listar.COLUMNAS_PK[i] + "=" + "'" + listar.VALORES_PK[i] + "' AND ";
                        else
                            where = where + listar.COLUMNAS_PK[i] + "=" + "'" + listar.VALORES_PK[i] + "'";
                    }
                    else
                        where = where + listar.COLUMNAS_PK[i] + "=" + "'" + listar.VALORES_PK[i] + "'";
                }

                if (listar.TABLA_ELIMINAR == "")
                    listar.TABLA_ELIMINAR = listar.TABLA;

                string sentencia = "DELETE FROM " + listar.COMPAÑIA + "." + listar.TABLA_ELIMINAR + where;

                if (sqlCon.EjecutarNonQuery(sentencia) > 0)
                    lbOk = true;
                else
                    lbOk = false;
                //    auditoriaDesdeEliminar(DateTime.Now, identificadorFormulario, listar, ref error);
                

                
            }
            catch (Exception ex)
            {
                error = "[eliminaRegistro] Ocurrió un error eliminando el registro:\n" + ex.Message;
                lbOk = false;
            }
            return lbOk;
        }

        public static bool insertar(List<string> valoresParametros, Listado listar, string identificadorFormulario, ref string error, string auditoria = "si")
        {
            string[] parametros;
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                parametros = listar.COLUMNAS.Split(',');
                string strSQL = "INSERT INTO " + listar.COMPAÑIA + "." + listar.TABLA + " (" + listar.COLUMNAS + ") VALUES (";

                for (int i = 0; i < parametros.Length; i++)
                {
                    strSQL += "@" + parametros[i].Trim() + ",";

                    if (valoresParametros[i] != "null")
                        sqlCon.COMMAND.Parameters.AddWithValue("@" + parametros[i].Trim(), valoresParametros[i]);
                    else
                        sqlCon.COMMAND.Parameters.AddWithValue("@" + parametros[i].Trim(), System.DBNull.Value);
                }

                strSQL = strSQL.Remove(strSQL.Length - 1);
                strSQL += ")";
                //sqlCon.COMMAND.Parameters.AddWithValue("@UsuarioCreacion", sqlCon.USUARIO);
                //sqlCon.COMMAND.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //sqlCon.COMMAND.Parameters.AddWithValue("@UsuarioModificacion", sqlCon.USUARIO);
                //sqlCon.COMMAND.Parameters.AddWithValue("@FechaModificacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);

                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;

                //if (auditoria == "si")
                //    return auditoriaDesdeInsert(parametros, DateTime.Now, identificadorFormulario, valoresParametros, listar, ref error);
                //else
                    return true;
            }
            catch (Exception ex)
            {
                error = "[insertar] Ocurrió un error al insertar los datos:\n" + ex.Message;
                return false;
            }
        }

        private static bool auditoriaDesdeInsert(string[] columnas,DateTime fecha,string origen, List<string> valoresParametros, 
            Listado listar,ref string error)
        {
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                string registro = "";
                for (int i = 0; i < listar.COLUMNAS_PK.Count; i++)
                {
                    for (int j = 0; j < columnas.Length; j++)
                    {
                        if (listar.COLUMNAS_PK[i] == columnas[j].Trim())
                            registro = registro + valoresParametros[j] + "|";
                    }  
                }

                registro = registro.Remove(registro.Length - 1);

                    for (int i = 0; i < columnas.Length; i++)
                    {
                        string strSQL = "INSERT INTO dbo.AUDITORIA (Usuario,FechaHora,Origen,Registro,Opcion,ValorActual) " +
                           " VALUES (@Usuario,@FechaHora,@Origen,@Registro,@Opcion,@ValorActual)";
                        
                        sqlCon.COMMAND.Parameters.Clear();
                        sqlCon.COMMAND.Parameters.AddWithValue("@Usuario", sqlCon.USUARIO);
                        sqlCon.COMMAND.Parameters.AddWithValue("@FechaHora", fecha.ToString("yyyyMMdd HH:mm:ss"));
                        sqlCon.COMMAND.Parameters.AddWithValue("@Origen", origen);
                        sqlCon.COMMAND.Parameters.AddWithValue("@Registro", registro);
                        sqlCon.COMMAND.Parameters.AddWithValue("@Opcion", columnas[i].Trim());
                        sqlCon.COMMAND.Parameters.AddWithValue("@ValorActual", valoresParametros[i]);
                        sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);

                        
                    }
                    sqlCon.COMMAND.Dispose();
                    sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[auditoriaDesdeInsert] Ocurrió un error al insertar los datos:\n" + ex.Message;
                return false;
            }
        }


        private static bool auditoriaDesdeUpdate(string[] columnas, DateTime fecha, string origen, List<string> valoresParametros,
           Listado listar,DataTable dt, ref string error)
        {
            
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                string registro = "";
                for (int i = 0; i < listar.COLUMNAS_PK.Count; i++)
                {
                    for (int j = 0; j < columnas.Length; j++)
                    {
                        if (listar.COLUMNAS_PK[i] == columnas[j].Trim())
                            registro = registro + valoresParametros[j] + "|";
                    }
                }

                if (registro != "")
                {
                    registro = registro.Remove(registro.Length - 1);

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < columnas.Length; i++)
                            {
                                if (valoresParametros[i] == "null" || valoresParametros[i] == null)
                                    valoresParametros[i] = "";

                                if (valoresParametros[i] == "0" && row[columnas[i].Trim()].ToString() == "False")
                                    valoresParametros[i] = "False";

                                if (valoresParametros[i] == "1" && row[columnas[i].Trim()].ToString() == "True")
                                    valoresParametros[i] = "True";

                                if (row[columnas[i].Trim()].ToString() != valoresParametros[i])
                                {
                                    string strSQL = "INSERT INTO dbo.AUDITORIA (Usuario,FechaHora,Origen,Registro,Opcion,ValorPrevio,ValorActual) " +
                             " VALUES (@Usuario,@FechaHora,@Origen,@Registro,@Opcion,@ValorPrevio,@ValorActual)";

                                    sqlCon.COMMAND.Parameters.Clear();
                                    sqlCon.COMMAND.Parameters.AddWithValue("@Usuario", sqlCon.USUARIO);
                                    sqlCon.COMMAND.Parameters.AddWithValue("@FechaHora", fecha.ToString("yyyyMMdd HH:mm:ss"));
                                    sqlCon.COMMAND.Parameters.AddWithValue("@Origen", origen);
                                    sqlCon.COMMAND.Parameters.AddWithValue("@Registro", registro);
                                    sqlCon.COMMAND.Parameters.AddWithValue("@Opcion", columnas[i].Trim());
                                    sqlCon.COMMAND.Parameters.AddWithValue("@ValorPrevio", row[columnas[i].Trim()].ToString());
                                    sqlCon.COMMAND.Parameters.AddWithValue("@ValorActual", valoresParametros[i]);
                                    sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                                }
                            }
                        }
                    }
                }
              
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[auditoriaDesdeUpdate] Ocurrió un error al insertar los datos:\n" + ex.Message;
                return false;
            }
        }


        private static bool auditoriaDesdeEliminar(DateTime fecha, string origen,
          Listado listar, ref string error)
        {

            sqlCon.COMMAND = new SqlCommand();
            try
            {
                string registro = "";
                for (int i = 0; i < listar.COLUMNAS_PK.Count; i++)
                {
                    registro = registro + listar.VALORES_PK[i] + "|";
                }

                registro = registro.Remove(registro.Length - 1);

                
                        string strSQL = "INSERT INTO dbo.AUDITORIA (Usuario,FechaHora,Origen,Registro,Opcion,ValorPrevio,ValorActual) " +
                         " VALUES (@Usuario,@FechaHora,@Origen,@Registro,@Opcion,@ValorPrevio,@ValorActual)";

                                sqlCon.COMMAND.Parameters.Clear();
                                sqlCon.COMMAND.Parameters.AddWithValue("@Usuario", sqlCon.USUARIO);
                                sqlCon.COMMAND.Parameters.AddWithValue("@FechaHora", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                                sqlCon.COMMAND.Parameters.AddWithValue("@Origen", origen);
                                sqlCon.COMMAND.Parameters.AddWithValue("@Registro", registro);
                                sqlCon.COMMAND.Parameters.AddWithValue("@Opcion", "UsuarioCreacionAdmin");
                                sqlCon.COMMAND.Parameters.AddWithValue("@ValorPrevio", sqlCon.USUARIO);
                                sqlCon.COMMAND.Parameters.AddWithValue("@ValorActual", "-BORRADO-");
                                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                    
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[auditoriaDesdeEliminar] Ocurrió un error al insertar los datos:\n" + ex.Message;
                return false;
            }
        }

        public static bool ejecutarSentencia(string strSQL, ref string error)
        {
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                sqlCon.COMMAND.CommandTimeout = 0;
                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[ejecutarSentencia] Ocurrió un error al ejecutar la sentencia:\n" + ex.Message;
                if (ex.Message.Contains("PK"))
                    error = "Ya existe un registro con el mismo código en la base de datos.";

                if (ex.Message.Contains("FK") || error.Contains("FOREIGN KEY"))
                {
                    string tabla = error.Split('"')[5].Split('.')[1];
                    string columna = error.Split('"')[6].Split('.')[0].Replace(", column ", "");
                    error = "No se pudo completar el proceso, existen datos dependientes con la tabla '" + tabla + "' Columna " + columna + "";
                }
                return false;
            }
        }

        public static bool ejecutarSentencia(string strSQL, ref string error, ref int filasModificadas)
        {
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                sqlCon.COMMAND.CommandTimeout = 0;
                filasModificadas = sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                filasModificadas = 0;
                error = "[ejecutarSentencia] Ocurrió un error al ejecutar la sentencia:\n" + ex.Message;
                if (ex.Message.Contains("PK"))
                    error = "Ya existe un registro con el mismo código en la base de datos.";

                if (ex.Message.Contains("FK") || error.Contains("FOREIGN KEY"))
                {
                    string tabla = error.Split('"')[5].Split('.')[1];
                    string columna = error.Split('"')[6].Split('.')[0].Replace(", column ", "");
                    error = "No se pudo completar el proceso, existen datos dependientes con la tabla '" + tabla + "' Columna " + columna + "";
                }
                return false;
            }
        }

        public static bool ejecutarSentenciaParametros(string strSQL, List<string> parametros, ref string error)
        {
            sqlCon.COMMAND = new SqlCommand();

            for (int i = 0; i < parametros.Count; i++)
                sqlCon.COMMAND.Parameters.AddWithValue(parametros[i].Split(',')[0], parametros[i].Split(',')[1]);

            try
            {
                sqlCon.COMMAND.CommandTimeout = 0;
                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[ejecutarSentencia] Ocurrió un error al ejecutar la sentencia:\n" + ex.Message;
                if (ex.Message.Contains("PK"))
                    error = "Ya existe un registro con el mismo código en la base de datos.";

                if (ex.Message.Contains("FK") || error.Contains("FOREIGN KEY"))
                {
                    string tabla = error.Split('"')[5].Split('.')[1];
                    string columna = error.Split('"')[6].Split('.')[0].Replace(", column ", "");
                    error = "No se pudo completar el proceso, existen datos dependientes con la tabla '" + tabla + "' Columna " + columna + "";
                }

                return false;
            }
        }

        public static bool insertarAdjunto(string formularioOrigen, string llave,string nombreArchivo,byte[] archivo,
                                           string descripcion,string tipo,ref string error)
        {
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                string strSQL = "INSERT INTO "+sqlCon.COMPAÑIA+".NV_ARCHIVO_ADJUNTO (Origen,LlaveOrigen,NombreArchivo,DescripcionArchivo,ArchivoEnBaseDatos,";
                if (tipo=="BD")
                    strSQL += "Contenido,";
               
                    strSQL+="UsuarioCreacionAdmin,FechaCreacionAdmin,UsuarioUltModificacionAdmin,FechaUltModificacionAdmin) VALUES (" +
                    "@Origen,@LlaveOrigen,@NombreArchivo,@DescripcionArchivo,@ArchivoEnBaseDatos,";
                    
                if(tipo=="BD")
                   strSQL+="@Contenido,";

                strSQL+="@UsuarioCreacion,@FechaCreacion,@UsuarioModificacion,@FechaModificacion)";

                sqlCon.COMMAND.Parameters.AddWithValue("@Origen", formularioOrigen);
                sqlCon.COMMAND.Parameters.AddWithValue("@LlaveOrigen", llave);
                sqlCon.COMMAND.Parameters.AddWithValue("@NombreArchivo", nombreArchivo);
                sqlCon.COMMAND.Parameters.AddWithValue("@DescripcionArchivo", descripcion);
                sqlCon.COMMAND.Parameters.AddWithValue("@Contenido", archivo);
                sqlCon.COMMAND.Parameters.AddWithValue("@UsuarioCreacion", sqlCon.USUARIO);
                sqlCon.COMMAND.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sqlCon.COMMAND.Parameters.AddWithValue("@UsuarioModificacion", sqlCon.USUARIO);
                sqlCon.COMMAND.Parameters.AddWithValue("@FechaModificacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if(tipo=="BD")
                    sqlCon.COMMAND.Parameters.AddWithValue("@ArchivoEnBaseDatos","S");
                if(tipo=="SERVIDOR")
                    sqlCon.COMMAND.Parameters.AddWithValue("@ArchivoEnBaseDatos", "N");

                if(tipo=="DIGITAL")
                    sqlCon.COMMAND.Parameters.AddWithValue("@ArchivoEnBaseDatos", "D");

                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[insertarAdjunto] Ocurrió un error guardando el archivo adjunto:\n" + ex.Message;
                return false;
            }
        }

        public static bool insertarLogo(string empresa, byte[] archivo, ref string error)
        {
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                string strSQL = "UPDATE dbo.EMPRESAS set Logo = @Contenido WHERE CodigoEmpresa = '" + empresa + "' and Usuario = '" + Usuario + "'";

                sqlCon.COMMAND.Parameters.AddWithValue("@Contenido", archivo);
                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[insertarLogo] Ocurrió un error guardando el logo:\n" + ex.Message;
                return false;
            }
        }

         public static bool insertarPDFProductos(string producto,string columnaPDF, byte[] archivo, ref string error)
         {
            sqlCon.COMMAND = new SqlCommand();
            try
            {
                string strSQL = "UPDATE dbo.PRODUCTOS set "+columnaPDF+"= @Contenido WHERE RegistroProducto = @producto";
                
                sqlCon.COMMAND.Parameters.Add("@Contenido", SqlDbType.VarBinary, archivo.Length).Value = archivo;
                sqlCon.COMMAND.Parameters.AddWithValue("@producto", producto);
                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);
                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;
                return true;
            }
            catch (Exception ex)
            {
                error = "[insertarPDFProducto] Ocurrió un error guardando los pdfs de notificaciones del producto\n" + ex.Message;
                return false;
            }
        }

        public static bool listadoAdjuntos(string llave,string formularioOrigen,ref DataTable dt,ref string error)
        {
            dt = new DataTable();
            error = "";
            string sQuery = "SELECT NombreArchivo,DescripcionArchivo,Consecutivo,ArchivoEnBaseDatos from "+sqlCon.COMPAÑIA+".NV_ARCHIVO_ADJUNTO where origen='"+formularioOrigen+"' and llaveOrigen='"+llave+"'";
           
            try
            {
                dt = sqlCon.EjecutarConsultaDataTable(sQuery);
            }
            catch (Exception ex)
            {
                error = "[fillDataTable] Ocurrió un error al obtener los datos: \n\n" + ex.Message;
                return false;
            }

            return true;
        }

        public static bool obtenerAdjunto(string llave, string formularioOrigen, string consecutivo,ref byte[] archivo, ref string error)
        {
           
            error = "";
            string sQuery = "SELECT CONTENIDO from "+sqlCon.COMPAÑIA+".NV_ARCHIVO_ADJUNTO where origen='" + formularioOrigen + "' and llaveOrigen='" + llave + "' and consecutivo="+consecutivo;

            try
            {
                archivo = (byte[])sqlCon.ExecuteEscalar(sQuery);
            }
            catch (Exception ex)
            {
                error = "[obtenerAdjunto] Ocurrió un error obteniendo el archivo adjunto: \n\n" + ex.Message;
                return false;
            }

            return true;
        }

        public static bool eliminaAdjunto(string llave,string formulario,string consecutivo,ref string error)
        {
            bool lbOk = true;
         
            try
            {
                string sentencia = "DELETE FROM "+sqlCon.COMPAÑIA+".NV_ARCHIVO_ADJUNTO WHERE LlaveOrigen='"+llave+"' and origen='"+formulario+"' and consecutivo="+consecutivo;
                sqlCon.EjecutarNonQuery(sentencia);
            }
            catch (Exception ex)
            {
                error = "[eliminaAdjunto] Ocurrió un error eliminando el adjunto:\n" + ex.Message;
                lbOk = false;
            }
            return lbOk;
        }


        public static byte[] GetArchivoAdjunto(string filePath)
        {
            FileStream fs = null;
            BinaryReader br = null;
            byte[] file;

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                file = br.ReadBytes((int)fs.Length);
            }
            finally
            {
                if (br != null)
                {
                    br.Close();
                    br.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

            return file;
        }

        public static bool actualizar(List<string> valoresParametros,Listado listar,string identificadorFormulario,ref string error)
        {
            string[] parametros;
            sqlCon.COMMAND = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                parametros = listar.COLUMNAS.Split(',');
                
                string strSQL = "SELECT " + listar.COLUMNAS + " FROM " + listar.COMPAÑIA + "." + listar.TABLA + " " + listar.FILTRO;
                dt = sqlCon.EjecutarConsultaDataTable(strSQL);

                strSQL = "UPDATE " + listar.COMPAÑIA + "." + listar.TABLA + " SET ";
                for (int i = 0; i < parametros.Length; i++)
                {
                    if (!listar.CAMBIAR_PK)
                    {
                        if (!listar.COLUMNAS_PK.Contains(parametros[i].Trim()))
                        {
                            strSQL += parametros[i].Trim() + " = @" + parametros[i].Trim() + ",";

                            if (valoresParametros[i] != "null")
                                sqlCon.COMMAND.Parameters.AddWithValue("@" + parametros[i].Trim(), valoresParametros[i]);
                            else
                                sqlCon.COMMAND.Parameters.AddWithValue("@" + parametros[i].Trim(), System.DBNull.Value);
                        }
                    }
                    else
                    {
                        strSQL += parametros[i].Trim() + " = @" + parametros[i].Trim() + ",";

                        if (valoresParametros[i] != "null")
                            sqlCon.COMMAND.Parameters.AddWithValue("@" + parametros[i].Trim(), valoresParametros[i]);
                        else
                            sqlCon.COMMAND.Parameters.AddWithValue("@" + parametros[i].Trim(), System.DBNull.Value);
                    }
                }
                //strSQL += "UsuarioUltModificacionAdmin=@UsuarioModificacion,FechaUltModificacionAdmin=@fechaModificacion ";
                //sqlCon.COMMAND.Parameters.AddWithValue("@UsuarioModificacion", sqlCon.USUARIO);
                //sqlCon.COMMAND.Parameters.AddWithValue("@FechaModificacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                strSQL = strSQL.Remove(strSQL.Length - 1);
                strSQL += " " + listar.FILTRO;
                sqlCon.EjecutarNonQuery(strSQL, sqlCon.COMMAND);

                sqlCon.COMMAND.Dispose();
                sqlCon.COMMAND = null;

             /*   if (listar.CAMBIAR_PK)
                {
                    if (valoresParametros[2]=="F")
                    strSQL = "UPDATE CLIENTES_FISICOS SET CodigoCliente='" + valoresParametros[0] + "' WHERE CodigoCliente='" +
                        listar.VALORES_PK[0] + "';";

                    if (valoresParametros[2] == "J")
                    strSQL = "UPDATE CLIENTES_JURIDICOS SET CodigoCliente='" + valoresParametros[0] + "' WHERE CodigoCliente='" +
                       listar.VALORES_PK[0] + "';";

                    if (valoresParametros[2] == "C")
                    strSQL = "UPDATE CLIENTES_CORPORACION SET CodigoCliente='" + valoresParametros[0] + "' WHERE CodigoCliente='" +
                       listar.VALORES_PK[0] + "';";

                    strSQL+="UPDATE POLIZAS SET CodigoAseguradoPoliza='"+valoresParametros[0]+"' WHERE CodigoAseguradoPoliza='"+
                        listar.VALORES_PK[0] + "';";

                    strSQL += "UPDATE OFERTAS SET CodigoAseguradoOferta='" + valoresParametros[0] + "' WHERE CodigoAseguradoOferta='" +
                        listar.VALORES_PK[0] + "';";

                    strSQL += "UPDATE PAGOS SET NombreAseguradoDepositoPago='" + valoresParametros[0] + "' WHERE NombreAseguradoDepositoPago='" +
                       listar.VALORES_PK[0] + "';";

                    strSQL += "UPDATE RECIBOS SET CodigoCliente='" + valoresParametros[0] + "' WHERE CodigoCliente='" +
                       listar.VALORES_PK[0] + "';";

                   // strSQL += "UPDATE ACCIONISTAS SET CodigoCliente='" + valoresParametros[0] + "' WHERE CodigoCliente='" +
                    //   listar.VALORES_PK[0] + "';";

                    sqlCon.EjecutarNonQuery(strSQL);
                }*/

                //return auditoriaDesdeUpdate(parametros,DateTime.Now,identificadorFormulario,valoresParametros,listar,dt,ref error);
                return true;
            }
            catch (Exception ex)
            {
                error = "[actualizar] Ocurrió un error al actualizar los datos:\n" + ex.Message;
                return false;
            } 
        }

        public static bool tienePrivilegios(string usuario, string privilegio)
        {
            if (usuario.Equals("SA") || usuario.Equals("ADMSASEG") || usuario.Contains("_admin"))
                return true;
            bool pase = false;
            string sQuery = "SELECT PrivilegiosUsuario from dbo.USUARIOS where CodigoUsuario='" + usuario + "'" +
                " UNION SELECT PrivilegiosGrupo from dbo.GRUPOS where MembresiasGrupo like '%" + usuario + "%'";
            DataTable dtPrivilegios = new DataTable();
            dtPrivilegios = sqlCon.EjecutarConsultaDataTable(sQuery);
            
            if (dtPrivilegios.Rows.Count > 0)
            {
                for (int i = 0; i < dtPrivilegios.Rows.Count; i++)
                {
                    if (dtPrivilegios.Rows[i][0].ToString().Contains(privilegio))
                        pase = true;
                }
            }

            return pase;
        }

        public static bool cargarGlobales(ref DataTable dt, ref string error)
        {
            string sQuery = "SELECT [NombreAgencia],[ManejarPolizasSuspenso],[ManejarGestores],[MostrarInfoVencimiento]" +
                            ",[DiasInfoVencimiento],[AfectarPrimaPorPago],[SolicitarVigenciasPagos],[ServidorSMTP]," +
            "[UsuarioServidorSMTP],[ClaveUsuario],[ValidarDatosVehiculo],[ConsolidarPrimasMontosPolizaFlotilla]" +
            ",[ExisteSeguridadExtendida],[ListarPolizasHija],[MargenMontoError],[FechaActualizacionGlobal],[CorreoControl]" +
            ",[ValidarReciboINS],[VerColoresRebajoAutomatico],[CodigoAseguradora],[TipoSistema],[FormatoLlave],[PuerdoSalidaSMTP]" +
            ",[PuertoModemCOM] ,[RutaEnlace] ,[PermitirTalonariosGenerales] ,[CantidadAño],[VersionSistema],[SoloMayusculas]" +
            ",[ConComas],[EncabezadoCorreo],[NotaCorreo],[PieCorreo],[DatosObligatoriosClientes],[ValoresPersonalizados]" +
            ",[PasswordComplejidad],[ActualizarVigenciasMensuales] ,[PermitirVariosCorredores],[CorreoCopiaSoporte],[RutaAlmacenamientoAdjuntos], "+
            "HabilitarSSL FROM DBO.GLOBALES";

            try
            {
                dt = sqlCon.EjecutarConsultaDataTable(sQuery);
            }
            catch (Exception ex)
            {
                error = "Error cargando las globales\n." + ex.Message;
                return false;
            }

            return true;
        }
    }
}