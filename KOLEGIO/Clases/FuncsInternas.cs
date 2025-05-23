using Excel;
using Framework;
using KOLEGIO.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;

//using EL = ExcelLibrary.SpreadSheet;

namespace KOLEGIO
{
	public class FuncsInternas
	{
		OleDbConnection conn;
		OleDbDataAdapter MyDataAdapter;
		DataTable dt;

		public bool insertarLogin(string login, string password, string database, bool seguridadExtendida, ref string error)
		{
			try
			{
				string strSQL = "";
				if (seguridadExtendida)
					strSQL = "CREATE LOGIN " + login + " WITH PASSWORD = '" + password + "', CHECK_POLICY = OFF, DEFAULT_DATABASE = [" + database + "]";
				else
					strSQL = "EXEC SP_ADDLOGIN " + login + ", " + password + "', " + database;

				return Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "[insertarLogin] Ocurrió un error al insertar los datos:\n" + ex.Message;
				return false;
			}
		}

		public bool createUser(string login, ref string error)
		{
			try
			{
				string strSQL = "CREATE USER [" + login + "] for login [" + login + "]";
				return Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "[createUser] Ocurrió un error al insertar los datos:\n" + ex.Message;
				return false;
			}
		}

		public string buscaNombreUsuario(string codigo)
		{
			string error = "";
			DataTable dtUsuario = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "PrimerNombreUsuario + ' ' + PrimerApellidoUsuario as NombreUsuario";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_USUARIOS";
			listP.FILTRO = "where CodigoUsuario = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtUsuario, ref error))
			{
				if (dtUsuario.Rows.Count > 0)
				{
					return dtUsuario.Rows[0]["NombreUsuario"].ToString();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return "Administrador del Sistema";
		}

		public bool spDBAAccess(string login, ref string error)
		{
			try
			{
				string strSQL = "exec sp_grantdbaccess " + login;
				Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "[spDBAAccess] Ocurrió un error al insertar los datos:\n" + ex.Message;
				return false;
			}
			return true;
		}

		public bool spDBOwner(string login, ref string error)
		{
			try
			{
				string strSQL = "exec sp_addrolemember db_owner, " + login;
				return Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "[spDBOwner] Ocurrió un error al insertar los datos:\n" + ex.Message;
				return false;
			}
		}

		public bool spDBsysadmin(string login, ref string error)
		{
			try
			{
				string strSQL = "exec sp_addsrvrolemember " + login + ",'sysadmin'";
				return Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "[spDBsysadmin] Ocurrió un error al insertar los datos:\n" + ex.Message;
				return false;
			}
		}

		public void cambiarContrasenna(string login, string passAnterior, string passActual, bool modo, ref string error)
		{
			try
			{
				bool lbOk = true;
				string strSQL = "";
				if (modo)
				{
					strSQL = "exec " + ConfigurationManager.AppSettings["Compania"] + ".sp_regen_login_ex";
					lbOk = Consultas.ejecutarSentencia(strSQL, ref error);
					strSQL = "exec sp_password Null," + passActual + ", " + login;
				}
				else
				{
					if (login.Equals(Constantes.SA) || login.Equals(Constantes.ADMSASEG) || login.Contains(Constantes.SASEGDB_admin))
						strSQL = "exec sp_password Null," + passActual + ", " + login;
					else
						strSQL = "exec sp_password " + passAnterior + ", " + passActual;
				}
				lbOk = Consultas.ejecutarSentencia(strSQL, ref error);
				if (lbOk)
				{
					strSQL = "UPDATE " + ConfigurationManager.AppSettings["Compania"] + ".NV_USUARIOS set FechaUltimoCambioClaveUsuario = '" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "' where CodigoUsuario = '" + login + "'";
					lbOk = Consultas.ejecutarSentencia(strSQL, ref error);
				}
				//return lbOk;

				if (!lbOk)
					throw new Exception(error);
			}
			catch (Exception ex)
			{
				error = "No tiene permisos para reiniciar la Contraseña.";
				throw new Exception(error);
				//return false;
			}
		}

		public void reciboMasivo(string agente, string talonario, string inicio, string fin, ref string error)
		{
			try
			{
				string primero = inicio;
				for (int i = int.Parse(inicio); i <= int.Parse(fin); i++)
				{
					string recibo = "";
					if (i == int.Parse(inicio))
					{
						recibo = inicio;
					}
					else
					{
						primero = sgtValor(primero);
						recibo = primero;
					}

					string strSQL = "INSERT INTO " + ConfigurationManager.AppSettings["Compania"] + ".AGENTES_TALONARIOS_RECIBOS (AgenteTalonarioRecibo,FechaInclusionTalonarioRecibo,CodigoTalonario,CodigoReciboTalonario,NotasReciboTalonario,ReciboTalonarioAnulado,ReciboTalonarioAsignado,UsuarioCreacionAdmin,FechaCreacionAdmin,UsuarioUltModificacionAdmin,FechaUltModificacionAdmin) values ('" + agente + "',getdate(),'" + talonario + "','" + recibo + "','',0,0, '" + Consultas.Usuario + "',getdate(),'" + Consultas.Usuario + "',getdate())";
					Consultas.ejecutarSentencia(strSQL, ref error);
				}
			}
			catch (Exception ex)
			{
				error = "[recibosMasivos] Ocurrió un error en la creación de recibos masivos:\n" + ex.Message;
			}
		}

		public string generarConsecutivo(string nombreConsecutivo, ref string error)
		{
			string consecutivo = "";
			try
			{
				string sQuery = "SELECT ULTIMO_VALOR FROM " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO WHERE CONSECUTIVO='" + nombreConsecutivo + "'";
				DataTable dtConsecutivo = new DataTable();
				if (Consultas.fillDataTable(sQuery, ref dtConsecutivo, ref error))
				{
					if (dtConsecutivo.Rows.Count > 0)
					{
						consecutivo = dtConsecutivo.Rows[0][0].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				error = "[generarConsecutivo] Ocurrió un error creando el consecutivo:\n" + ex.Message;
			}
			return consecutivo;
		}

		public bool actualizarConsecutivo(string cons, string nombreConsecutivo, ref string error)
		{
			bool OK = true;
			try
			{
				string sQuery = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO SET ULTIMO_VALOR = '" + cons + "' WHERE CONSECUTIVO='" + nombreConsecutivo + "'";
				OK = Consultas.ejecutarSentencia(sQuery, ref error);
			}
			catch (Exception ex)
			{
				error = "[generarConsecutivo] Ocurrió un error actualizando el consecutivo:\n" + ex.Message;
				return false;
			}
			return true;
		}

		public string sgtValor(string valor)
		{
			string nValor = string.Empty;
			string txt = string.Empty;
			int sgt = 0;

			//entera
			Regex entera = new Regex(@"\d+");
			Match mEntera = entera.Match(valor);
			//text
			Regex texto = new Regex(@"([A-Za-z\-]+)");
			Match mTexto = texto.Match(valor);

			txt = mTexto.Value;
			sgt = int.Parse(mEntera.Value) + 1;
			nValor = txt + sgt.ToString().PadLeft(mEntera.Length, '0');

			return (nValor);
		}

		public DataTable cargarGlobales(ref string error)
		{
			DataTable dtGlobales = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "*";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "GLOBALES";

			if (Consultas.listarDatos(listP, ref dtGlobales, ref error))
			{
				if (dtGlobales.Rows.Count > 0)
				{
					return dtGlobales;
				}
			}
			return null;
		}

		public String nombreAgencia(ref string error)
		{
			DataTable dtGlobales = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "NombreAgencia,ManejarPolizasSuspenso,ManejarGestores,MostrarInfoVencimiento,DiasInfoVencimiento,AfectarPrimaPorPago," +
				"SolicitarVigenciasPagos,ServidorSMTP,UsuarioServidorSMTP,ClaveUsuario,ValidarDatosVehiculo,ConsolidarPrimasMontosPolizaFlotilla," +
				"ExisteSeguridadExtendida,ListarPolizasHija,MargenMontoError,CorreoControl,ValidarReciboINS,VerColoresRebajoAutomatico,CodigoAseguradora," +
				"TipoSistema,FormatoLlave,PuerdoSalidaSMTP,PuertoModemCOM,RutaEnlace,PermitirTalonariosGenerales,CantidadAño,VersionSistema,SoloMayusculas," +
				"ConComas,EncabezadoCorreo,NotaCorreo,PieCorreo,DatosObligatoriosClientes,ValoresPersonalizados,PasswordComplejidad,ActualizarVigenciasMensuales," +
				"PermitirVariosCorredores,CorreoCopiaSoporte";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "GLOBALES";

			if (Consultas.listarDatos(listP, ref dtGlobales, ref error))
			{
				if (dtGlobales.Rows.Count > 0)
				{
					return dtGlobales.Rows[0][0].ToString();
				}
			}
			return string.Empty;
		}

		public bool tienePrivilegios(string usuario, string identificador)
		{
			return true;
		}

		//public bool tienePrivilegios(string usuario, string privilegio)
		//{
		//    if (usuario.Equals("SA") || usuario.Equals("ADMSASEG") || usuario.Contains("_admin"))
		//        return true;
		//    bool pase = false;
		//    string sQuery = "SELECT PrivilegiosUsuario from " + Consultas.sqlCon.COMPAÑIA + ".NV_USUARIOS where CodigoUsuario='" + usuario + "'";
		//    //" UNION SELECT PrivilegiosGrupo from " + Consultas.sqlCon.COMPAÑIA + ".NV_GRUPOS where MembresiasGrupo like '%" + usuario + "%'";
		//    DataTable dtPrivilegios = new DataTable();
		//    dtPrivilegios = Consultas.sqlCon.EjecutarConsultaDataTable(sQuery);

		//    if (dtPrivilegios.Rows.Count > 0)
		//    {
		//        for (int i = 0; i < dtPrivilegios.Rows.Count; i++)
		//        {
		//            if (dtPrivilegios.Rows[i][0].ToString().Contains(privilegio))
		//                pase = true;
		//        }
		//    }

		//    return pase;
		//}

		public bool actualizaClaveUsuarioVirtual(string usuario, string contraseña, ref string error)
		{
			error = "";
			string strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_USUARIOS set ClaveSistemaAdicionalUsuario = '" + contraseña + "',FechaUltimoCambioClaveUsuario=GETDATE() where CodigoUsuario = '" + usuario + "'";
			bool lbOk = true;
			lbOk = Consultas.ejecutarSentencia(strSQL, ref error);

			if (!lbOk)
				throw new Exception(error);

			return lbOk;
		}

		public void infoPadronNacional(string cedula, bool comas, ref string nombre, ref int sexo, ref string error)
		{
			try
			{
				ConexionNUBE conNUBE = new ConexionNUBE("DB_A2D15F_PADRONCR_admin", "dssd@2013", "dbo");
				conNUBE.getConexion();
				conNUBE.Open();
				ConsultasNUBE.sqlCon = conNUBE;
				ConsultasNUBE.Usuario = "DB_A2D15F_PADRONCR_admin";
				ConsultasNUBE.sqlCon.USUARIO = "DB_A2D15F_PADRONCR_admin";
				//Consultas.UsuarioADMIN = this.fInternas.buscaUsuarioADMIN(Consultas.Usuario);
				ConsultasNUBE.Contraseña = "dssd@2013";
				DataTable infoPadron = new DataTable();
				ConsultasNUBE.fillDataTable("select Nombre, PrimerApellido, SegundoApellido, Sexo from [dbo].[PADRON] where cedula = '" + cedula + "'", ref infoPadron, ref error);
				if (infoPadron.Rows.Count > 0)
				{
					if (!comas)
						nombre = infoPadron.Rows[0]["PrimerApellido"].ToString() + " " + infoPadron.Rows[0]["SegundoApellido"].ToString() + " " + infoPadron.Rows[0]["Nombre"].ToString();
					else
						nombre = infoPadron.Rows[0]["PrimerApellido"].ToString() + "," + infoPadron.Rows[0]["SegundoApellido"].ToString() + "," + infoPadron.Rows[0]["Nombre"].ToString();
					if (infoPadron.Rows[0]["Sexo"].ToString().Equals("2"))
						sexo = 1;
					else
						sexo = 0;
				}
				conNUBE.Close();
			}
			catch (Exception ex)
			{
				if (ConfigurationManager.AppSettings["Debug"].ToUpper() == "NO")
					error = "Error obteniendo el nombre completo del Padrón Nacional, favor digitarlo de forma manual.";
				else
					error = "Error obteniendo el nombre completo del Padrón Nacional, favor digitarlo de forma manual.\n\n" + ex;

			}
		}


		public void ConsultaNombreHacienda(string cedula, ref string nombre, ref string error)
		{
			string jsonRespuesta = string.Empty;

			try
			{
				HttpClient http = new HttpClient();

				var taskAsync = Task.Run(() =>
				{
					HttpResponseMessage response = http.GetAsync("https://api.hacienda.go.cr/fe/ae?identificacion=" + cedula).Result;
					return response;
				});

				taskAsync.Wait();

				var httpResp = taskAsync.Result;

				var statusCode = httpResp.StatusCode;

				//HttpResponseMessage response = http.GetAsync(this.location).Result;
				//string res = await response.Content.ReadAsStringAsync();
				//obtener jsonRespuesta 
				//jsonRespuesta = httpResp.Content.ReadAsStringAsync().ToString();
				var taskAsyncTwo = Task.Run(() =>
				{
					var res = httpResp.Content.ReadAsStringAsync();
					return res;
				});

				taskAsyncTwo.Wait();

				jsonRespuesta = taskAsyncTwo.Result;

				PerfilHacienda PF = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilHacienda>(taskAsyncTwo.Result);

				if (PF != null)
				{
					if (PF.nombre != null)
					{
						var nombreTemp = PF.nombre.Split(' ');
						if (nombreTemp.Length > 3)
							nombre = nombreTemp[2] + " " + nombreTemp[3] + " " + nombreTemp[0] + " " + nombreTemp[1];
						else
							nombre = nombreTemp[2] + " " + nombreTemp[0] + " " + nombreTemp[1];
					}
					else
					{
						error = "No se encontro el nombre de la cédula digitada.";
					}
				}
				else
				{
					error = "No se encontro la cédula digitada.";
				}

			}
			catch (Exception ex)
			{
				//if (ex is WebException)
				//{
				//    error = @"Error consultando recepción de factura en api de Hacienda: {0}\r{1}";
				//    using (StreamReader rd = new StreamReader(((WebException)ex).Response.GetResponseStream()))
				//    {
				//        string soapResult = rd.ReadToEnd();
				//        error = string.Format(error, ex.Message, soapResult);
				//    }
				//}
				error = "Error al obtener nombre: " + ex.Message;
				//return "";
				//throw ex;
			}
		}

		public static bool obtenerSubtipoRec(string codigo, ref string subtipoRec, ref string error)
		{
			bool ok = true;
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "SubtipoRec";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_PLANTILLA_COBRADOR";
			listA.FILTRO = "where Codigo = '" + codigo + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					subtipoRec = dtTTs.Rows[0]["SubtipoRec"].ToString();
				}
				else
				{
					error = "La plantilla de cobro no tiene registrado el subtipo";
					ok = false;
				}
			}
			else
			{
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ok = false;
			}
			return ok;
		}

		public static bool obtenerActividadComercial(ref string actividadComercial, ref string error)
		{
			bool ok = true;
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "TOP 1 CODIGO";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "ACTIVIDAD_COMERCIAL";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					actividadComercial = dtTTs.Rows[0]["CODIGO"].ToString();
				}
				else
				{
					error = "No existe actividad comercial";
					ok = false;
				}
			}
			else
			{
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ok = false;
			}
			return ok;
		}

		public static bool obtenerVersionNivelPrecio(ref string versionNivel, ref string error)
		{
			bool ok = true;
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "VERSION";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "VERSION_NIVEL";
			listA.FILTRO = "where (CAST(getdate() AS date) BETWEEN FECHA_INICIO AND FECHA_CORTE) AND ESTADO = 'A'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					versionNivel = dtTTs.Rows[0]["VERSION"].ToString();
				}
				else
				{
					error = "No existe version de nivel de precios";
					ok = false;
				}
			}
			else
			{
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ok = false;
			}
			return ok;
		}

		public static bool obtenerNombreCobrador(string cobrador, ref string nombre, ref string error)
		{
			bool ok = true;
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "NOMBRE";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "COBRADOR";
			listA.FILTRO = " where COBRADOR = '" + cobrador + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					nombre = dtTTs.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					error = "No existe el cobrador";
					ok = false;
				}
			}
			else
			{
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ok = false;
			}
			return ok;
		}

		public int GetMonthDifference(DateTime startDate, DateTime endDate, ref string error)
		{
			int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
			return Math.Abs(monthsApart);
		}

		public bool GetMonthDifference(DateTime startDate, DateTime endDate, ref int result, ref string error)
		{
			try
			{

				int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
				result = Math.Abs(monthsApart);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public string CalculoMutualidad(DateTime fechaIncorporacion, DateTime fechaNacimiento, ref string error)
		{
			string totalMutualidad = "0";
			/*string error = "";*/
			string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART where ArticuloFms = 'S'";

			DataTable dtArticuloFms = new DataTable();

			if (Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error))
			{
				if (dtArticuloFms.Rows.Count > 0)
				{
					string sPrecio = "select t1.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t1.NIVEL_PRECIO AND t6.VERSION = t1.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' where t1.ARTICULO = '" + dtArticuloFms.Rows[0][0].ToString() + "'";

					DataTable dtPrecio = new DataTable();

					if (Consultas.fillDataTable(sPrecio, ref dtPrecio, ref error))
					{
						if (dtPrecio.Rows.Count > 0)
						{
							int meses = GetMonthDifference(fechaIncorporacion, fechaNacimiento.AddYears(25), ref error);
							totalMutualidad = (decimal.Parse(dtPrecio.Rows[0][0].ToString()) * meses).ToString("N2");
						}
						else
						{
							error = "No se pudo obtener el precio para el calculo de mutualidad";
						}
					}

				}
				else
				{
					error = "No hay articulo asociado al FMS";
				}

			}


			return totalMutualidad;
		}

		public string CalculoMutualidadLevantamiento(DateTime fechaIncorporacion, DateTime fechaNacimiento, string condicion, ref string error)
		{
			string totalMutualidad = "0";
			/*string error = "";*/
			string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART where CodigoCondicion = '" + condicion + "' and ArticuloFms = 'S'";

			DataTable dtArticuloFms = new DataTable();

			if (Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error))
			{
				if (dtArticuloFms.Rows.Count > 0)
				{
					string sPrecio = "select t1.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t1.NIVEL_PRECIO AND t6.VERSION = t1.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'  where t1.ARTICULO = '" + dtArticuloFms.Rows[0][0].ToString() + "'";

					DataTable dtPrecio = new DataTable();

					if (Consultas.fillDataTable(sPrecio, ref dtPrecio, ref error))
					{
						//int meses = GetMonthDifference(fechaIncorporacion, fechaNacimiento.AddYears(25), ref error);
						int meses = GetMonthDifference(fechaIncorporacion, fechaNacimiento, ref error);
						totalMutualidad = (decimal.Parse(dtPrecio.Rows[0][0].ToString()) * meses).ToString("N2");
					}
				}
				else
				{
					error = "No hay articulo asociado al FMS";
				}

			}


			return totalMutualidad;
		}

		public void lecturaArchivoTxt(string cobrador, DataGridView tabla, char caracter, string ruta)
		{


			StreamReader objReader = new StreamReader(ruta);
			DataTable dtFormatos = new DataTable();
			string sLine = "";
			string fila = "";
			string error = "";

			tabla.Columns.Clear();

			string sQuery = "SELECT Columna,Orden,Caracteres,TamColumna,Detalle,Macro,Formato FROM " + Consultas.sqlCon.COMPAÑIA +
						".NV_PLANTILLA_COBRADOR_DETALLE WHERE Cobrador='" + cobrador + "' order by Columna,Orden";

			if (Consultas.fillDataTable(sQuery, ref dtFormatos, ref error))
			{
				tabla.ColumnCount = dtFormatos.Rows.Count;
				tabla.ColumnHeadersVisible = true;

				int col = 0;
				foreach (DataRow row in dtFormatos.Rows)
				{
					//fila += 
					tabla.Columns[col].HeaderText = row["Detalle"].ToString();
					tabla.Columns[col].Name = row["Macro"].ToString();
					col++;

				}
				tabla.AllowUserToAddRows = false;
			}


			do
			{
				sLine = objReader.ReadLine();
				if ((sLine != null))
				{
					int count = 0;
					fila = "";
					foreach (DataRow row in dtFormatos.Rows)
					{
						int caracteres = int.Parse(row["Caracteres"].ToString());

						if (row["Macro"].ToString() == "MONTO" || row["Macro"].ToString() == "SALDO")
						{
							string monto = sLine.Substring(count, caracteres);

							if (monto.Contains("."))
								caracteres += 1;/*+1 del punto decimal*/

							monto = sLine.Substring(count + quitarCerosMonto(monto), caracteres - quitarCerosMonto(monto));

							if (row["Orden"].ToString() == "1")
								fila += monto;
							else
								fila += "-" + monto;

							if (monto.Contains("."))
								count += 1;
						}
						else
						{
							if (row["Macro"].ToString() == "NUMERO_FACTURA")
							{
								string fact = sLine.Substring(count, caracteres);
								fact = sLine.Substring(count + quitarEspaciosInicio(fact), caracteres - quitarEspaciosInicio(fact));

								if (row["Orden"].ToString() == "1")
									fila += fact;
								else
									fila += "-" + fact;
							}
							else
							{
								if (row["Macro"].ToString() == "CARNET")
								{
									string carnet = sLine.Substring(count, caracteres);
									carnet = carnet.Trim(' ');

									if (row["Orden"].ToString() == "1")
										fila += carnet;
									else
										fila += "-" + carnet;
								}
								else
								{
									if (row["Orden"].ToString() == "1")
										fila += sLine.Substring(count, caracteres);
									else
										fila += "-" + sLine.Substring(count, caracteres);
								}
							}
							////if (row["TamColumna"].ToString() == "")
							////{
							//    if (row["Orden"].ToString() == "1")
							//        fila += sLine.Substring(count, int.Parse(row["Caracteres"].ToString()));
							//    else
							//        fila += "-" + sLine.Substring(count, int.Parse(row["Caracteres"].ToString()));
							////}
							////else
							////{

							////    if (row["Orden"].ToString() == "1")
							////        fila += sLine.Substring(count, int.Parse(row["TamColumna"].ToString()));
							////    else
							////        fila += "-" + sLine.Substring(count, int.Parse(row["TamColumna"].ToString()));
							////}


						}


						if (row["TamColumna"].ToString() == "")
							count += caracteres;
						else
							count += int.Parse(row["TamColumna"].ToString());
					}

					agregarFilaDatagridview(tabla, fila, caracter);
				}
			}
			while (!(sLine == null));

			objReader.Close();

			//StreamReader objReader = new StreamReader(ruta);
			//string sLine = "";

			//tabla.Rows.Clear();
			//tabla.AllowUserToAddRows = false;

			//do
			//{
			//    sLine = objReader.ReadLine();
			//    if ((sLine != null))
			//    {
			//        DataTable dtFormatos = new DataTable();
			//        string error = "";
			//        string linea = "";
			//        int count = 0;

			//        int indiceIniCedula = 0, caracteresCedula = 0;
			//        int indiceIniMonto = 0, caracteresMonto = 0;

			//        string sQuery = "SELECT Columna,Orden,Caracteres,TamColumna,Detalle,Macro,Formato FROM " + Consultas.sqlCon.COMPAÑIA +
			//            ".NV_PLANTILLA_COBRADOR_DETALLE WHERE Cobrador='" + cobrador + "' order by Columna,Orden";

			//        if (Consultas.fillDataTable(sQuery, ref dtFormatos, ref error))
			//        {

			//            foreach (DataRow row in dtFormatos.Rows)
			//            {


			//                if (row["Macro"].ToString() == "CEDULA")
			//                {
			//                    caracteresCedula += int.Parse(row["Caracteres"].ToString());//9
			//                    indiceIniCedula = count;    
			//                }

			//                if (row["Macro"].ToString() == "MONTO")
			//                {
			//                    caracteresMonto += int.Parse(row["Caracteres"].ToString());//9
			//                    indiceIniMonto = count;
			//                }
			//                //int difEspacios = int.Parse(row["TamColumna"].ToString()) - int.Parse(row["Caracteres"].ToString());
			//                //int cantCaracteres = int.Parse(row["Caracteres"].ToString()) + difEspacios;

			//                if(row["TamColumna"].ToString() == "")
			//                    count += int.Parse(row["Caracteres"].ToString());
			//                else
			//                    count += int.Parse(row["TamColumna"].ToString());
			//            }
			//        }
			//        string cedula = sLine.Substring(indiceIniCedula, caracteresCedula);
			//        string monto = sLine.Substring(indiceIniMonto, caracteresMonto);

			//        monto = sLine.Substring(indiceIniMonto + quitarCerosMonto(monto), caracteresMonto - quitarCerosMonto(monto));

			//        linea += cedula+" "+monto; 
			//        agregarFilaDatagridview(tabla, linea, caracter);

			//    }
			//}

			//while (!(sLine == null));
			//objReader.Close();
		}

		public void lecturaArchivoXls(DataGridView dgvCarga, string cobrador, string rutaArchivo)
		{
			FileStream stream = File.Open(rutaArchivo, FileMode.Open, FileAccess.Read);
			IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
			excelReader.IsFirstRowAsColumnNames = true;
			DataSet dataset = excelReader.AsDataSet();
			DataTable dtDatos = new DataTable();
			DataTable dtFormatos = new DataTable();
			bool existeHoja = false;
			string error = "";

			foreach (DataTable table in dataset.Tables)
			{
				if (table.TableName.ToUpper() == "PLANTILLA_KOLEGIO")
				{
					table.TableName = "PLANTILLA_KOLEGIO";
					existeHoja = true;
					break;
				}

			}

			if (!existeHoja)
			{
				MessageBox.Show("El archivo excel que intenta cargar debe tener la hoja llamada 'PLANTILLA_KOLEGIO', favor verifique.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//if (dgvCarga.Columns.Count > 0)
			//{
			//    dgvCarga.Columns["colCedula"].Visible = false;
			//    dgvCarga.Columns["colMontoCarga"].Visible = false;
			//}

			//dgvCarga.Columns.Clear();

			dtDatos = dataset.Tables["PLANTILLA_KOLEGIO"];

			dgvCarga.DataSource = dtDatos;


			string sQuery = "SELECT Columna,Orden,Caracteres,Detalle,Macro,Formato FROM " + Consultas.sqlCon.COMPAÑIA +
				".NV_PLANTILLA_COBRADOR_DETALLE WHERE Cobrador='" + cobrador + "' order by Columna,Orden";


			if (Consultas.fillDataTable(sQuery, ref dtFormatos, ref error))
			{
				//dgvCarga.ColumnCount = dtFormatos.Rows.Count;
				//dgvCarga.ColumnHeadersVisible = true;

				int col = 0;
				foreach (DataRow row in dtFormatos.Rows)
				{

					dgvCarga.Columns[col].HeaderText = row["Detalle"].ToString();
					dgvCarga.Columns[col].Name = row["Macro"].ToString();
					col++;

				}
				//dgvCarga.AllowUserToAddRows = false;
			}



			//dgvCarga.Columns[0].DisplayIndex = dgvCarga.Columns.Count - 1;
			//dgvCarga.Columns[1].DisplayIndex = dgvCarga.Columns.Count - 2;
			MessageBox.Show("Información fue cargada Exitosamente, ya puede procesar la información", " ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


			Cursor.Current = Cursors.WaitCursor;

		}

		public void lecturaArchivoCsv(string cobrador, DataGridView tabla, char caracter, string ruta)
		{
			StreamReader objReader = new StreamReader(ruta);
			DataTable dtFormatos = new DataTable();
			string sLine = "";
			string error = "";

			tabla.Columns.Clear();

			string sQuery = "SELECT Columna,Orden,Caracteres,Detalle,Macro,Formato FROM " + Consultas.sqlCon.COMPAÑIA +
						".NV_PLANTILLA_COBRADOR_DETALLE WHERE Cobrador='" + cobrador + "' order by Columna,Orden";

			if (Consultas.fillDataTable(sQuery, ref dtFormatos, ref error))
			{
				tabla.ColumnCount = dtFormatos.Rows.Count;
				tabla.ColumnHeadersVisible = true;

				int col = 0;
				foreach (DataRow row in dtFormatos.Rows)
				{

					tabla.Columns[col].HeaderText = row["Detalle"].ToString();
					tabla.Columns[col].Name = row["Macro"].ToString();
					col++;

				}
				tabla.AllowUserToAddRows = false;
			}


			do
			{
				sLine = objReader.ReadLine();
				if ((sLine != null))
				{
					agregarFilaDatagridview(tabla, sLine, caracter);
				}
			}
			while (!(sLine == null));

			objReader.Close();
		}

		public void lecturaArchivoPredeterminados(DataGridView dgvCarga, string listadoPorFac, string rutaArchivo, string tipoIdent)
		{
			FileStream stream = File.Open(rutaArchivo, FileMode.Open, FileAccess.Read);
			Excel.IExcelDataReader excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(stream);
			excelReader.IsFirstRowAsColumnNames = true;
			DataSet dataset = excelReader.AsDataSet();
			DataTable dtDatos = new DataTable();
			DataTable dtFormatos = new DataTable();
			bool existeHoja = false;
			bool requiereFac = false;
			string error = "";

			foreach (DataTable table in dataset.Tables)
			{
				if (table.TableName.ToUpper() == "PLANTILLA_KOLEGIO")
				{
					table.TableName = "PLANTILLA_KOLEGIO";
					existeHoja = true;
					break;
				}

			}

			if (!existeHoja)
			{
				MessageBox.Show("El archivo excel que intenta cargar debe tener la hoja llamada 'PLANTILLA_KOLEGIO', favor verifique.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//if (dgvCarga.Columns.Count > 0)
			//{
			//    dgvCarga.Columns["colCedula"].Visible = false;
			//    dgvCarga.Columns["colMontoCarga"].Visible = false;
			//}

			//dgvCarga.Columns.Clear();

			dtDatos = dataset.Tables["PLANTILLA_KOLEGIO"];

			dgvCarga.DataSource = dtDatos;

			if (listadoPorFac.Equals("S"))
			{
				dgvCarga.Columns[0].HeaderText = "Identificacion";
				dgvCarga.Columns[0].Name = "IDENTIFICACION";

				dgvCarga.Columns[1].HeaderText = "Factura";
				dgvCarga.Columns[1].Name = "NUMERO_FACTURA";

				dgvCarga.Columns[2].HeaderText = "Saldo";
				dgvCarga.Columns[2].Name = "SALDO";
				requiereFac = true;
			}
			else
			{
				dgvCarga.Columns[0].HeaderText = "Identificacion";
				dgvCarga.Columns[0].Name = "IDENTIFICACION";

				dgvCarga.Columns[1].HeaderText = "Saldo";
				dgvCarga.Columns[1].Name = "SALDO";
			}

			//limpiarFilasVaciasDgv(ref dgvCarga);

			try
			{
				foreach (DataGridViewRow row in dgvCarga.Rows)
				{
					string iden = row.Cells["IDENTIFICACION"].Value.ToString().Trim();
					if (tipoIdent.Equals("C"))
					{
						if (iden.Substring(0, 1) == "0")
							iden = quitarCerosInicio(iden);

					}

					row.Cells["IDENTIFICACION"].Value = iden;

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error eliminando ceros a identificación.\n " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if (guardarDatosCargadosTemp(dgvCarga, requiereFac, ref error))
			{
				MessageBox.Show("Información fue cargada Exitosamente, ya puede procesar la información", " ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Error Guardando Datos de Carga. " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


			Cursor.Current = Cursors.WaitCursor;

		}

		private bool guardarDatosCargadosTemp(DataGridView dgv, bool requiereFac, ref string error)
		{
			List<string> parametros = new List<string>();
			Listado list = new Listado();
			if (requiereFac)
				list.COLUMNAS = "Colegiado,Documento,Saldo";
			else
				list.COLUMNAS = "Colegiado,Saldo";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_ARCHIVO_CARGA_TEMP";
			bool lbOk = true;
			try
			{
				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ARCHIVO_CARGA_TEMP";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				if (lbOk)
				{


					foreach (DataGridViewRow row in dgv.Rows)
					{
						//string sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO (IdColegiado,Medio,FechaGestion,Compromiso,FechaCompromiso,Observaciones)" +
						//" VALUES ('" + txtIdColegiado.Valor + "', '" + row.Cells["colMedio"].Value.ToString() + "', '" + DateTime.Parse(row.Cells["colFecha"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss") + "', '" + row.Cells["colCompromiso"].Value.ToString() + "','" + DateTime.Parse(row.Cells["colFechaCompromiso"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss") + "', '" + row.Cells["colObservacion"].Value.ToString() + "')";

						//lbOk = Consultas.ejecutarSentencia(sInsert, ref error);
						parametros.Clear();
						if (row.Cells["IDENTIFICACION"].Value.ToString() != "")
							parametros.Add(row.Cells["IDENTIFICACION"].Value.ToString());
						else
							parametros.Add("null");

						if (requiereFac)
						{
							if (row.Cells["NUMERO_FACTURA"].Value.ToString() != "")
								parametros.Add(row.Cells["NUMERO_FACTURA"].Value.ToString());
							else
								parametros.Add("null");
						}

						if (row.Cells["SALDO"].Value.ToString() != "")
							parametros.Add(row.Cells["SALDO"].Value.ToString());
						else
							parametros.Add("null");


						lbOk = Consultas.insertar(parametros, list, Constantes.ID_BIT_CREAR_DATOS_CARGA_TEMP, ref error, "no");

					}
				}
			}
			catch (Exception ex)
			{
				error = ex.Message;
				return false;
			}
			return lbOk;
		}

		private int quitarCerosMonto(string monto)
		{
			int ceros = 0;
			if (monto.Substring(0, 1) == "0")
			{
				int i = 0;
				while (monto.Substring(i, 1) == "0")
				{
					ceros++;
					i++;
				}
			}
			return ceros;
		}

		public string quitarCerosMontoInicio(string monto)
		{
			int ceros = 0;
			if (monto.Substring(0, 1) == "0")
			{
				int i = 0;
				while (monto.Substring(i, 1) == "0")
				{
					ceros++;
					i++;
				}
			}
			int tam = monto.Length;
			monto = monto.Substring(ceros, tam - ceros);
			return monto;
		}

		public string quitarCerosInicio(string clave)
		{
			int ceros = 0;
			if (clave.Substring(0, 1) == "0")
			{
				int i = 0;
				while (clave.Substring(i, 1) == "0")
				{
					ceros++;
					i++;
				}
			}
			int tam = clave.Length;
			clave = clave.Substring(ceros, tam - ceros);
			return clave;
		}

		private int quitarEspaciosInicio(string fact)
		{
			int espacios = 0;
			if (fact.Substring(0, 1) == " ")
			{
				int i = 0;
				while (fact.Substring(i, 1) == " ")
				{
					espacios++;
					i++;
				}
			}
			return espacios;
		}

		private int quitarEspacios(string cadena, string caracteres, string tamColumna)
		{
			int ceros = 0;
			if (cadena.Substring(0, 1) == "0")
			{
				int i = 0;
				while (cadena.Substring(i, 1) == "0")
				{
					ceros++;
					i++;
				}
			}
			return ceros;
		}

		public void importarExcel(DataGridView dgv, String nombreHoja)
		{
			String ruta = "";
			try
			{
				OpenFileDialog openfile1 = new OpenFileDialog();
				openfile1.Filter = "Excel Files |*.xlsx";
				openfile1.Title = "Seleccione el archivo de Excel";
				if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					if (openfile1.FileName.Equals("") == false)
					{
						ruta = openfile1.FileName;
					}
				}

				conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
				MyDataAdapter = new OleDbDataAdapter("Select * from [" + nombreHoja + "$]", conn);
				dt = new DataTable();
				MyDataAdapter.Fill(dt);
				dgv.DataSource = dt;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		//Agrega una fila por cada linea de Bloc de notas :D'
		public static void agregarFilaDatagridview(DataGridView tabla, string linea, char caracter)
		{

			string[] arreglo = linea.Split(caracter);

			tabla.Rows.Add(arreglo);
		}

		public bool generarNit(string cedulas, string idBusqueda, ref DataTable dtCliente, string idCreacionCliente, ref string error)
		{
			bool OK = true;
			string sQuery = "";
			#region Antiguo
			//string sQueryNit = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NIT WHERE NIT='" + idColegiado + "'";
			//DataTable dtNit = new DataTable();

			//if (Consultas.fillDataTable(sQueryNit, ref dtNit, ref error))
			//{
			//    string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idColegiado + "'";
			//    dtCliente = new DataTable();

			//    if (Consultas.fillDataTable(sQuery, ref dtCliente, ref error))
			//    {
			//        if (dtNit.Rows.Count > 0)
			//        {
			//            if (dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() != dtCliente.Rows[0]["Nombre"].ToString().ToUpper())
			//            {
			//                return controlerBD.crearNit(dtCliente, ref error);
			//            }
			//            else//Si es igual ya existe y no se crea pero se sigue con la transaccion
			//            {
			//                error = "Ya existe una razón social '" + dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() + "' asociado al NIT '" + dtNit.Rows[0]["NIT"].ToString() + "'";
			//                return false;
			//            }
			//        }
			//        else
			//            return controlerBD.crearNit(dtCliente, ref error);
			//    }
			//    else
			//        return false;
			//}
			//else
			//{
			//    return false;
			//}
			#endregion

			//string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idColegiado + "'";

			if (idCreacionCliente.Equals("colegiado"))
				sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idBusqueda + "'";
			else if (idCreacionCliente.Equals("estable"))
				sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS WHERE NumRegistro='" + idBusqueda + "'";
			else
				sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS WHERE Codigo='" + idBusqueda + "'";

			dtCliente = new DataTable();

			if (Consultas.fillDataTable(sQuery, ref dtCliente, ref error))
			{
				string sNit = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NIT WHERE NIT='" + cedulas + "' AND RAZON_SOCIAL='" + dtCliente.Rows[0]["Nombre"].ToString().ToUpper() + "'";
				DataTable dtNit = new DataTable();

				if (Consultas.fillDataTable(sNit, ref dtNit, ref error))
				{
					if (dtNit.Rows.Count > 0)
					{
						OK = true;
					}
					else
					{
						string sNit2 = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NIT WHERE NIT='" + cedulas + "'";
						dtNit = new DataTable();

						if (Consultas.fillDataTable(sNit2, ref dtNit, ref error))
						{
							if (dtNit.Rows.Count > 0)
							{
								if (dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() != dtCliente.Rows[0]["Nombre"].ToString().ToUpper())
								{
									error = "Ya existe un NIT '" + dtNit.Rows[0]["NIT"].ToString() + "' con la razón social '" + dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() + "'";
									OK = false;//Se cancela el proceso porque ya existe un nit con la razon social diferente y se le informa al usuario
								}
							}
							else
							{
								OK = controlerBD.crearNit(dtCliente, idCreacionCliente, ref error);
								//string sNit3 = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NIT WHERE RAZON_SOCIAL='" + dtCliente.Rows[0]["Nombre"].ToString().ToUpper() + "'";
								//dtNit = new DataTable();

								//if (Consultas.fillDataTable(sNit3, ref dtNit, ref error))
								//{
								//    if (dtNit.Rows.Count > 0)
								//    {
								//        bool nitIgual = false;
								//        foreach (DataRow r in dtNit.Rows)
								//        {
								//            if (dtNit.Rows[0]["NIT"].ToString() == idColegiado)
								//            {
								//                nitIgual = true;
								//            }
								//        }
								//        if (!nitIgual)
								//        {
								//            error = "Ya existe una razón social '" + dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() + "' asociado al NIT '" + dtNit.Rows[0]["NIT"].ToString() + "'";
								//            OK = false;//Se cancela el proceso porque ya existe una razon social con un nit diferente y se le informa al usuario
								//        }
								//    }
								//    else
								//    {
								//        OK = controlerBD.crearNit(dtCliente, ref error);
								//    }
								//}
							}
						}
					}
					//string sRazonS = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NIT WHERE RAZON_SOCIAL='" + dtCliente.Rows[0]["Nombre"].ToString().ToUpper() + "'";
					//DataTable dtRazon = new DataTable();

					//if (Consultas.fillDataTable(sRazonS, ref dtRazon, ref error))
					//{
					//    if (dtRazon.Rows.Count > 0 && dtNit.Rows.Count > 0)
					//    {
					//        if (dtRazon.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() == dtCliente.Rows[0]["Nombre"].ToString().ToUpper() && dtRazon.Rows[0]["NIT"].ToString() != idColegiado)
					//        {
					//            error = "Ya existe una razón social '" + dtRazon.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() + "' asociado al NIT '" + dtRazon.Rows[0]["NIT"].ToString() + "'";
					//            OK = false;//Se cancela el proceso porque ya existe una razon social con un nit diferente y se le informa al usuario
					//        }
					//        else
					//        {
					//            if (dtNit.Rows[0]["NIT"].ToString() == idColegiado && dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() != dtCliente.Rows[0]["Nombre"].ToString().ToUpper())
					//            {
					//                error = "Ya existe un NIT '" + dtNit.Rows[0]["NIT"].ToString() + "' con la razón social '" + dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() + "'";
					//                OK = false;//Se cancela el proceso porque ya existe un nit con la razon social diferente y se le informa al usuario
					//            }
					//            else
					//            {
					//                if ((dtRazon.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() == dtCliente.Rows[0]["Nombre"].ToString().ToUpper() && dtRazon.Rows[0]["NIT"].ToString() == idColegiado) && (dtNit.Rows[0]["NIT"].ToString() == idColegiado && dtNit.Rows[0]["RAZON_SOCIAL"].ToString().ToUpper() == dtCliente.Rows[0]["Nombre"].ToString().ToUpper()))
					//                {
					//                    OK = true;//Se continua el proceso pero no se registra el nit xq ya existe
					//                }
					//            }
					//        }
					//    }
					//    else
					//    {
					//        OK = controlerBD.crearNit(dtCliente, ref error);
					//    }
					//}
					//else
					//{
					//    OK = false;
					//}
				}
				else
				{
					OK = false;
				}
			}
			else
				OK = false;

			return OK;
		}

		public bool generarCliente(string idColegiado, ref DataTable dtCliente, string idCreacionCliente, string idCondPAgo, ref string error)
		{
			//string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idColegiado + "'";
			string sQuery = "";

			if (idCreacionCliente.Equals("colegiado"))
				sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado='" + idColegiado + "'";
			else if (idCreacionCliente.Equals("estable"))
				sQuery = "SELECT *, (select CategoriaEstable from " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES) Categoria FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS WHERE NumRegistro='" + idColegiado + "'";
			else
				sQuery = "SELECT *, (select CategoriaConsul from " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES) Categoria FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS WHERE Codigo='" + idColegiado + "'";


			dtCliente = new DataTable();

			if (Consultas.fillDataTable(sQuery, ref dtCliente, ref error))
				return controlerBD.crearCliente(dtCliente, idCondPAgo, idCreacionCliente, ref error);
			else
				return false;
		}

		public bool verificarAceptaDocElectronicoClienteERP(string clienteERP, ref string error)
		{
			bool OK = true;
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "ACEPTA_DOC_ELECTRONICO";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "CLIENTE";
			listA.FILTRO = "where CLIENTE = '" + clienteERP + "'";
			//listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					if (dt.Rows[0]["ACEPTA_DOC_ELECTRONICO"].ToString() == "S")
					{
						OK = controlerBD.actualizarAceptaDocElectronicoClienteERP(clienteERP, "N", ref error);
					}
				}
			}
			else
			{
				OK = false;
			}


			return OK;
		}

		//public bool actualizarMachotesColegiados(string idColegiado, string condicion, ref string error)
		//{
		//    bool OK = true;

		//    OK = EliminarDetalleMachotes(idColegiado, ref error);

		//    if (OK)
		//        OK = InsertarDetalleMachotes(idColegiado, condicion, ref error);

		//    return OK;

		//}

		//private bool EliminarDetalleMachotes(string idColegiado, ref string error)
		//{
		//    string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado = '" + idColegiado + "'";

		//    return Consultas.ejecutarSentencia(sQuery, ref error);
		//}

		//private bool InsertarDetalleMachotes(string idColegiado, string condicion, ref string error)
		//{
		//    bool OK = true;
		//    DataTable dt = new DataTable();
		//    DataTable dtCambioCondicion = new DataTable();
		//    string sSelect = "select t2.CodigoArticulo, t1.CodigoPlantilla, t3.CodigoFrecuencia,t5.PRECIO as Precio from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t2 on t2.CodigoPlantilla = t1.CodigoPlantilla" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 on t3.CodigoPlantilla = t1.CodigoPlantilla" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t2.CodigoArticulo" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t2.CodigoArticulo" +
		//                     " where t1.CodigoCondicion = '" + condicion + "'";

		//    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

		//    if (OK)
		//    {
		//        foreach (DataRow row in dt.Rows)
		//        {
		//            string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Monto,CodigoFrecuencia) " +
		//            "VALUES ('" + idColegiado + "','" + condicion + "','" + row["CodigoArticulo"].ToString() + "','" + row["CodigoPlantilla"].ToString() + "','" + row["Precio"].ToString() + "','" + row["CodigoFrecuencia"].ToString() + "')";

		//            OK = Consultas.ejecutarSentencia(sQuery, ref error);

		//            if (!OK)
		//                break;
		//        }
		//    }

		//    return OK;

		//}

		public void deshabilitarOrdenDgv(ref DataGridView dgv)
		{
			foreach (DataGridViewColumn column in dgv.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		public void habilitarOrdenDgv(ref DataGridView dgv)
		{
			foreach (DataGridViewColumn column in dgv.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.Automatic;
			}
		}

		public void limpiarFilasVaciasDgv(ref DataGridView dgv)
		{
			foreach (DataGridViewRow row in dgv.Rows)
			{
				bool rowEmpty = false;
				foreach (DataGridViewCell cell in row.Cells)
				{

					if (string.IsNullOrEmpty(cell.Value.ToString()) || cell.Value.Equals(""))
					{
						rowEmpty = true;
					}
					else
					{
						rowEmpty = false;
					}
				}
				if (rowEmpty)
				{
					dgv.Rows[row.Index].Selected = true;
				}
			}

			foreach (DataGridViewRow row in dgv.SelectedRows)
			{

				dgv.Rows.Remove(row);

			}
		}

		//public bool actualizarMachotesColegiados(string condicion, ref string error)
		//{
		//    bool OK = true;

		//    OK = EliminarDetalleMachotes(idColegiado, ref error);

		//    if (OK)
		//        OK = InsertarDetalleMachotes(idColegiado, condicion, ref error);

		//    return OK;

		//}

		//private bool EliminarDetalleMachotesMasivo(string condicion, ref string error)
		//{
		//    string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE Condicion = '" + idColegiado + "'";

		//    return Consultas.ejecutarSentencia(sQuery, ref error);
		//}

		//private bool InsertarDetalleMachotes(string idColegiado, string condicion, ref string error)
		//{
		//    bool OK = true;
		//    DataTable dt = new DataTable();
		//    DataTable dtCambioCondicion = new DataTable();
		//    string sSelect = "select t2.CodigoArticulo, t1.CodigoPlantilla, t3.CodigoFrecuencia,t5.PRECIO as Precio from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t1" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t2 on t2.CodigoPlantilla = t1.CodigoPlantilla" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t3 on t3.CodigoPlantilla = t1.CodigoPlantilla" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t2.CodigoArticulo" +
		//                     " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t2.CodigoArticulo" +
		//                     " where t1.CodigoCondicion = '" + condicion + "'";

		//    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

		//    if (OK)
		//    {
		//        foreach (DataRow row in dt.Rows)
		//        {
		//            string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Monto,CodigoFrecuencia) " +
		//            "VALUES ('" + idColegiado + "','" + condicion + "','" + row["CodigoArticulo"].ToString() + "','" + row["CodigoPlantilla"].ToString() + "','" + row["Precio"].ToString() + "','" + row["CodigoFrecuencia"].ToString() + "')";

		//            OK = Consultas.ejecutarSentencia(sQuery, ref error);

		//            if (!OK)
		//                break;
		//        }
		//    }

		//    return OK;

		//}

		public void seguimientoCanones(string pedido, ref string facturado, ref string error)
		{
			bool OK = true;
			string sSelect = "", NumFactura = "";
			DataTable dt = new DataTable();

			#region VERIFICAR_ESTADO_PEDIDO

			sSelect = "SELECT ESTADO FROM " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO WHERE PEDIDO = '" + pedido + "'";

			OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

			if (OK)
			{
				if (dt.Rows.Count > 0)
				{
					if (dt.Rows[0][0].ToString() == "F")//Si se facturo el pedido
					{
						//facturado = "S";

						#region OBTENER_FACTURA

						sSelect = "SELECT FACTURA FROM " + Consultas.sqlCon.COMPAÑIA + ".FACTURA WHERE PEDIDO = '" + pedido + "'";

						OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

						if (OK)
						{
							if (dt.Rows.Count > 0)//Si esta facturado, obtenemos el numero de factura
							{
								NumFactura = dt.Rows[0][0].ToString();
								facturado = "S";
							}
						}

						#endregion

						//if (!NumFactura.Equals(""))
						//{
						//    #region VERIFICAR_CxC

						//    sSelect = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC WHERE DOCUMENTO = '" + NumFactura + "'";

						//    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

						//    if (OK)
						//    {
						//        if (dt.Rows.Count > 0)//Verificamos si esta en CC
						//        {
						//            if (decimal.Parse(dt.Rows[0]["SALDO"].ToString()) == 0)//Si tiene saldo no esta pago y sino ya se pago
						//            {
						//                pago = "S";
						//            }
						//            else
						//            {
						//                pago = "N";
						//            }
						//        }
						//        else//Si no esta en CC, es que se pago a contado
						//        {
						//            pago = "S";
						//        }
						//    }

						//    #endregion
						//}
						//else
						//{
						//    OK = false;
						//    error = "[Seguimiento Canones] Error obteniendo el numero de factura.";
						//}

					}
					//else//Si no se facturo el pedido, no esta facturado ni esta pago
					//{
					//    facturado = "N";
					//    //pago = "N";
					//}
				}
			}

			#endregion

			if (!OK)
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		public static string obtenerIdColegiado(string id)
		{
			bool OK = true;
			string error = "";
			string idcolegiado = "";
			DataTable dt = new DataTable();

			string sQueryOrden = "select IdColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where TRIM(Cedula) = '" + id + "' OR TRIM(NumeroColegiado) = '" + id + "'";

			OK = Consultas.fillDataTable(sQueryOrden, ref dt, ref error);

			if (OK)
			{
				foreach (DataRow linea in dt.Rows)
				{
					if (dt.Rows.Count > 0)
						idcolegiado = linea["IdColegiado"].ToString();
				}
			}
			return idcolegiado;
		}

		//public bool actualizarMachotesColegiadosMasivo(string machote, ref string error)
		//{
		//    bool OK = true;

		//    Consultas.sqlCon.iniciaTransaccion();
		//    OK = EliminarDetalleMachotesMasivo(machote, ref error);

		//    if (OK)
		//        OK = InsertarDetalleMachotesMasivo(machote, ref error);

		//    if (OK)
		//        Consultas.sqlCon.Commit();
		//    else
		//    {
		//        Consultas.sqlCon.Rollback();
		//        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//    }

		//    return OK;

		//}

		//private bool EliminarDetalleMachotesMasivo(string machote, ref string error)
		//{
		//    string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE CodigoPlantilla = '" + machote + "'";

		//    return Consultas.ejecutarSentencia(sQuery, ref error);
		//}

		//private bool InsertarDetalleMachotesMasivo(string machote, ref string error)
		//{
		//    bool OK = true;
		//    DataTable dtCole = new DataTable();
		//    DataTable dtCondicion = new DataTable();
		//    DataTable dtMachote = new DataTable();
		//    DataTable dtCambioCondicion = new DataTable();

		//    string sSelectCondi = "select CodigoCondicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES where CodigoPlantilla in ('" + machote + "')";

		//    OK = Consultas.fillDataTable(sSelectCondi, ref dtCondicion, ref error);

		//    if (OK)
		//    {
		//        if (dtCondicion.Rows.Count > 0)
		//        {
		//            foreach (DataRow rowCondi in dtCondicion.Rows)//Y le insertamos la plantilla debida
		//            {
		//                string sSelectCole = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where Condicion = '" + rowCondi["CodigoCondicion"].ToString() + "'";

		//                OK = Consultas.fillDataTable(sSelectCole, ref dtCole, ref error);//Obtenemos los colegiados con esa condicion

		//                if (OK)
		//                {
		//                    if (dtCole.Rows.Count > 0)
		//                    {
		//                        string sSelect = "select t2.CodigoArticulo, t1.CodigoPlantilla, t1.CodigoFrecuencia,t5.PRECIO as Precio from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t1" +
		//                                        " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t2 on t2.CodigoPlantilla = t1.CodigoPlantilla" +
		//                                        " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t2.CodigoArticulo" +
		//                                        " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t2.CodigoArticulo" +
		//                                        " where t1.CodigoPlantilla = '" + machote + "'";

		//                        OK = Consultas.fillDataTable(sSelect, ref dtMachote, ref error);//Obtenemos la plantilla que hay que asignarle a cada uno de los colegiados con esa condicion

		//                        if (OK)
		//                        {
		//                            if (dtMachote.Rows.Count > 0)//Si tiene detalles(articulos) la plantilla
		//                            {
		//                                foreach (DataRow rowCole in dtCole.Rows)//Recorro cada uno de los colegiados
		//                                {
		//                                    foreach (DataRow rowMachote in dtMachote.Rows)//Y le insertamos la plantilla debida
		//                                    {
		//                                        string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Monto,CodigoFrecuencia) " +
		//                                        "VALUES ('" + rowCole["IdColegiado"].ToString() + "','" + rowCondi["CodigoCondicion"].ToString() + "','" + rowMachote["CodigoArticulo"].ToString() + "','" + machote + "','" + rowMachote["Precio"].ToString() + "','" + rowMachote["CodigoFrecuencia"].ToString() + "')";

		//                                        OK = Consultas.ejecutarSentencia(sQuery, ref error);

		//                                        if (!OK)
		//                                            break;
		//                                    }
		//                                }
		//                            }
		//                        }

		//                    }

		//                }
		//            }
		//        }
		//    }

		//    return OK;

		//}

		public bool validarFechasLaboral(DateTime fechaIni, DateTime fechaFin, string colegiado, ref bool existe, ref string error)
		{
			bool OK = true;
			DataTable dt = new DataTable();
			DateTime rangoD = DateTime.Now;
			DateTime rangoH = DateTime.Now;

			string sSelect = "SELECT RangoDesde, RangoHasta FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_LABORAL WHERE NumeroColegiado = '" + colegiado + "'";

			OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

			if (OK && dt.Rows.Count > 0)
			{
				foreach (DataRow row in dt.Rows)
				{
					rangoD = DateTime.Parse(dt.Rows[0]["RangoDesde"].ToString());
					rangoH = DateTime.Parse(dt.Rows[0]["RangoHasta"].ToString());
					if (fechaIni >= rangoD && fechaIni <= rangoH || fechaFin >= rangoD && fechaFin <= rangoH)
					{
						existe = true;
					}
					else if (rangoD >= fechaIni && rangoD <= fechaFin || rangoH >= fechaIni && rangoH <= fechaFin)
					{
						existe = true;
					}
				}
			}

			return OK;
		}

		//public bool revisarRegresoEstadoEstablecimiento(DateTimePicker dtpHastaTemporal1, DateTimePicker dtpDesdeTemporal1, Label lblHastaTemporal, Label lblDesdeTemporal, string codEstado, string numRegistroEstable)
		public bool revisarRegresoEstadoEstablecimiento(DateTime dtpHastaTemporal1, string codEstado, string numRegistroEstable)
		{
			bool OK = true;
			string error = "";
			string estado = "";
			//DateTime fechaactual = DateTime.Now;
			////DateTime FechDesde = new DateTime(dtpDesdeTemporal.Value.Year, dtpDesdeTemporal.Value.Month, dtpDesdeTemporal.Value.Day);
			//DateTime FechHasta = new DateTime(dtpHastaTemporal1.Value.Year, dtpHastaTemporal1.Value.Month, dtpHastaTemporal1.Value.Day);
			//fechaactual = new DateTime(fechaactual.Year, fechaactual.Month, fechaactual.Day);

			//int result = DateTime.Compare(FechHasta, fechaactual);
			int result = DateTime.Compare(dtpHastaTemporal1.Date, DateTime.Today);
			//if (result <= 0)
			//{
			Consultas.sqlCon.iniciaTransaccion();
			DataTable dt = new DataTable();
			DataTable dtSelect = new DataTable();
			DataTable dtPlantilla = new DataTable();

			#region OBTENER_ESTADO_REGRESO
			string sQuery = "select EstadoRegreso from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS WHERE CodigoEstado = '" + codEstado + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					estado = dt.Rows[0][0].ToString();
				}
				OK = true;
			}
			else
			{
				OK = false;
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			#endregion



			//Se actualizan los datos en la tabla establecimientos
			#region ACTUALIZAR_ESTADO_ESTABLECIMIENTO
			if (OK)
			{
				List<string> parametros = new List<string>();
				string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS set Estado = @Estado, FechaDesdeCierreTemp = @FechaDesdeCierreTemp, FechaHastaCierreTemp = @FechaHastaCierreTemp" +
								 " WHERE NumRegistro = @NumReg";
				parametros.Add("@Estado," + estado);
				parametros.Add("@FechaDesdeCierreTemp," + "null");
				parametros.Add("@FechaHastaCierreTemp," + "null");
				parametros.Add("@NumReg," + numRegistroEstable);


				OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

			}
			#endregion


			if (OK)
			{
				dt = new DataTable();
				sQuery = "select Estado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = '" + numRegistroEstable + "'";

				if (Consultas.fillDataTable(sQuery, ref dt, ref error))
				{
					if (dt.Rows.Count > 0)
					{
						codEstado = dt.Rows[0]["Estado"].ToString();
					}
				}
				else
					OK = false;

				//dtpDesdeTemporal1 = DateTime.Now;
				//dtpDesdeTemporal1.Visible = false;
				//lblDesdeTemporal.Visible = false;
				//dtpHastaTemporal1.Value = DateTime.Now;
				//dtpHastaTemporal1.Visible = false;
				//lblHastaTemporal.Visible = false;
			}

			if (OK)
			{
				Consultas.sqlCon.Commit();
				MessageBox.Show("Se realizó el cambio del estado temporal del establecimiento", "Nota Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
				Consultas.sqlCon.Rollback();

			//}

			return OK;
		}

		public bool regresoRegenciasSancionados(string Id, DateTime dtpHastaTemporal1, string colegiado, string numRegistroEstable, string categoria, string sesionApro, string fechaApro)
		{
			bool OK = true;
			string error = "";

			string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado = '" + colegiado + "' and CodigoEstablecimiento = '" + numRegistroEstable + "' and CodigoCategoria = '" + categoria + "'";
			DataTable dt = new DataTable();

			Consultas.fillDataTable(sQuery, ref dt, ref error);
			if (dt.Rows.Count > 0)
			{

				int result = DateTime.Compare(dtpHastaTemporal1.Date, DateTime.Today);
				if (result <= 0)
				{
					Consultas.sqlCon.iniciaTransaccion();
					//DataTable dt = new DataTable();

					//Se actualizan los datos en la tabla establecimientos
					#region ACTUALIZAR_ESTADO_REGENCIA
					if (OK)
					{
						List<string> parametros = new List<string>();
						string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS set Estado = 'I' " +
							"WHERE NumeroColegiado = @NumeroColegiado and CodigoEstablecimiento = @CodigoEstablecimiento and CodigoCategoria = @CodigoCategoria";

						parametros.Add("@NumeroColegiado," + colegiado);
						parametros.Add("@CodigoEstablecimiento," + numRegistroEstable);
						parametros.Add("@CodigoCategoria," + categoria);


						OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

					}
					#endregion

					#region INGRESAR_HISTORIAL_REGENCIA
					//insertarHistorialRegencias(colegiado, numRegistroEstable, categoria, "S", "I", sesionApro, fechaApro, ref error);
					insertarHistorialRegencias(colegiado, numRegistroEstable, categoria, "S", sesionApro, fechaApro, ref error);
					#endregion

					#region CHECKEAR_FECHAHASTA_SANCION
					if (OK)
					{
						List<string> parametros = new List<string>();
						string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SANCIONES set CheckFechaHasta = 'S' WHERE Id = @Id";

						parametros.Add("@Id," + Id);


						OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

					}
					#endregion

					if (OK)
					{
						Consultas.sqlCon.Commit();
						//MessageBox.Show("Se realizó el cambio del estado a las Regencias Sancionadas", "Nota Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
						Consultas.sqlCon.Rollback();

				}
			}

			return OK;
		}

		public bool revisarRegresoCondicion(string idColegiado, DateTime fechaRegresoCondicion, string condicionActual, string identificadorForm, ref string error)
		{
			bool OK = true;
			string condicion = "";

			int result = DateTime.Compare(fechaRegresoCondicion.Date, DateTime.Today);
			if (result <= 0)
			{
				Consultas.sqlCon.iniciaTransaccion();
				DataTable dt = new DataTable();

				#region OBTENER_CONDICION_REGRESO
				string sQuery = "select CondicionRegreso from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES WHERE CodigoCondicion = '" + condicionActual + "'";

				if (Consultas.fillDataTable(sQuery, ref dt, ref error))
				{
					if (dt.Rows.Count > 0)
					{
						condicion = dt.Rows[0][0].ToString();
					}
					OK = true;
				}
				else
				{
					OK = false;
					MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				#endregion

				#region INSERTAR_HISTORIAL

				if (OK)
					OK = insertarEnHistorialCondicion(idColegiado, condicionActual, condicion, identificadorForm, ref error);
				#endregion

				#region ACTUALIZAR_CONDICION_FECHA_COLEGIADO
				if (OK)
				{
					List<string> parametros = new List<string>();
					string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Condicion = @Condicion, FechaRegresoCondicion = @FechaRegresoCondicion" +
									 " WHERE IdColegiado = @IdColegiado";
					parametros.Add("@Condicion," + condicion);
					parametros.Add("@FechaRegresoCondicion," + "null");
					parametros.Add("@IdColegiado," + idColegiado);


					OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

				}
				#endregion

				if (OK)
				{
					Consultas.sqlCon.Commit();
					//MessageBox.Show("Se realizó el cambio de condición del colegiado", "Nota Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
					Consultas.sqlCon.Rollback();
			}

			return OK;
		}

		public bool realizarCambioCondicionEdad(string idColegiado, string condicionActual, string identificadorForm, ref string error)
		{
			bool OK = true;
			string condicion = "";

			Consultas.sqlCon.iniciaTransaccion();
			DataTable dt = new DataTable();

			#region OBTENER_CONDICION_CAMBIO
			string sQuery = "select CondicionCambioEdad from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES WHERE CodigoCondicion = '" + condicionActual + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					condicion = dt.Rows[0][0].ToString();
				}
				OK = true;
			}
			else
			{
				OK = false;
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			#endregion

			#region ACTUALIZAR_CONDICION_COLEGIADO
			if (OK)
			{
				List<string> parametros = new List<string>();
				string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Condicion = @Condicion" +
								 " WHERE IdColegiado = @IdColegiado";
				parametros.Add("@Condicion," + condicion);
				parametros.Add("@IdColegiado," + idColegiado);


				OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

			}
			#endregion

			#region INSERTAR_HISTORIAL

			if (OK)
				OK = insertarEnHistorialCondicion(idColegiado, condicionActual, condicion, identificadorForm, ref error);
			#endregion

			if (OK)
			{
				Consultas.sqlCon.Commit();
				//MessageBox.Show("Se realizó el cambio de condición del colegiado", "Nota Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
				Consultas.sqlCon.Rollback();


			return OK;
		}

		private bool insertarEnHistorialCondicion(string colegiado, string condicionActual, string condicionNueva, string identificadorForm, ref string error)
		{
			List<string> parametros = new List<string>();
			Listado list = new Listado();
			list.COLUMNAS = "IdColegiado,CondicionPrevia,CondicionActual,SesionAprobacion,FechaAprobacion";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_CAMBIO_CONDICION";
			bool lbOk = true;
			try
			{

				parametros.Clear();
				list.COLUMNAS_PK.Add("IdColegiado");
				parametros.Add(colegiado);
				parametros.Add(condicionActual);
				parametros.Add(condicionNueva);
				parametros.Add("AUTO");
				parametros.Add(DateTime.Now.Date.ToString("yyyy-MM-ddTHH:mm:ss"));


				lbOk = Consultas.insertar(parametros, list, identificadorForm, ref error);

			}
			catch (Exception ex)
			{
				error = ex.Message;
				return false;
			}
			return lbOk;
		}


		public string obtenerEstado(string estado)
		{
			if (estado.Equals("A"))
				estado = "Activo";
			else if (estado.Equals("I"))
				estado = "Inactivo";
			else if (estado.Equals("S"))
				estado = "Sancionado";
            else if (estado.Equals("N"))
                estado = "Sin Regente";

            return estado;
		}

		public string obtenerEstadoGestionCobro(string estado)
		{
			if (estado.Equals("A"))
				estado = "Abierto";
			else if (estado.Equals("C"))
				estado = "Cerrado";

			return estado;
		}

		public bool insertarHistorialRegencias(string colegiado, string NumRegistro, string CodigoCategoria, string Estado, ref string error)
		{
			string qSelect = "";
			bool OK = true;
			StringBuilder sQuery = new StringBuilder();
			List<string> parametrosQuery = new List<string>();
			qSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado = '" + colegiado + "' and  CodigoEstablecimiento = '" + NumRegistro + "' and CodigoCategoria = '" + CodigoCategoria + "'";

			DataTable dt = new DataTable();

			Consultas.fillDataTable(qSelect, ref dt, ref error);


			if (dt.Rows.Count > 0)
			{
				if (!dt.Rows[0]["Estado"].ToString().Equals(Estado[0]))
				{
					sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_DE_REGENCIA (IdColegiado,NumRegistro,CodigoCategoria,Estado,SesionAprobacion,FechaAprobacion)");
					sQuery.AppendLine("VALUES (@IdColegiado,@NumRegistro,@CodigoCategoria,@Estado,@SesionAprobacion,@FechaAprobacion)");

					#region PARAMETROS

					parametrosQuery.Add("@IdColegiado," + colegiado);
					parametrosQuery.Add("@NumRegistro," + NumRegistro);
					parametrosQuery.Add("@CodigoCategoria," + CodigoCategoria);
					parametrosQuery.Add("@Estado," + dt.Rows[0]["Estado"].ToString());
					parametrosQuery.Add("@SesionAprobacion," + dt.Rows[0]["SesionAprobacion"].ToString());
					if (!dt.Rows[0]["FechaAprobacion"].ToString().Equals(""))
						parametrosQuery.Add("@FechaAprobacion," + DateTime.Parse(dt.Rows[0]["FechaAprobacion"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
					else
						parametrosQuery.Add("@FechaAprobacion,null");

					#endregion

					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametrosQuery, ref error);

				}
			}

			return OK;
		}

		public bool insertarHistorialRegencias(string colegiado, string NumRegistro, string CodigoCategoria, string Estado, string SesionAprobacion, string FechaAprobacion, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			List<string> parametrosQuery = new List<string>();


			//sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_REGENCIA (IdColegiado,NumRegistro,CodigoCategoria,EstadoPrevio,EstadoActual,SesionAprobacion,FechaAprobacion)");
			//sQuery.AppendLine("VALUES (@IdColegiado,@NumRegistro,@CodigoCategoria,@EstadoPrevio,@EstadoActual,@SesionAprobacion,@FechaAprobacion)");
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_DE_REGENCIA (IdColegiado,NumRegistro,CodigoCategoria,Estado,SesionAprobacion,FechaAprobacion)");
			sQuery.AppendLine("VALUES (@IdColegiado,@NumRegistro,@CodigoCategoria,@Estado,@SesionAprobacion,@FechaAprobacion)");

			#region PARAMETROS

			//parametrosQuery.Add("@IdColegiado," + colegiado);
			//parametrosQuery.Add("@NumRegistro," + NumRegistro);
			//parametrosQuery.Add("@CodigoCategoria," + CodigoCategoria);
			//parametrosQuery.Add("@EstadoPrevio," + EstadoPrevio[0] + "");
			//parametrosQuery.Add("@EstadoActual," + EstadoActual[0] + "");
			//parametrosQuery.Add("@SesionAprobacion," + SesionAprobacion);
			//if (!FechaAprobacion.Equals(""))
			//    parametrosQuery.Add("@FechaAprobacion," + DateTime.Parse(FechaAprobacion).ToString("yyyy-MM-ddTHH:mm:ss"));
			//else
			//    parametrosQuery.Add("@FechaAprobacion,null");
			parametrosQuery.Add("@IdColegiado," + colegiado);
			parametrosQuery.Add("@NumRegistro," + NumRegistro);
			parametrosQuery.Add("@CodigoCategoria," + CodigoCategoria);
			parametrosQuery.Add("@Estado," + Estado[0] + "");
			parametrosQuery.Add("@SesionAprobacion," + SesionAprobacion);
			if (!FechaAprobacion.Equals(""))
				parametrosQuery.Add("@FechaAprobacion," + DateTime.Parse(FechaAprobacion).ToString("yyyy-MM-ddTHH:mm:ss"));
			else
				parametrosQuery.Add("@FechaAprobacion,null");

			#endregion

			if (Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametrosQuery, ref error))
				return true;
			else
				return false;

		}

		public bool obtenerUltimoIdInformes(ref int id)
		{
			bool OK = true;
			string error = "";

			string sQuery = "SELECT Max(id) as ultimoId FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES";
			DataTable dt = new DataTable();

			Consultas.fillDataTable(sQuery, ref dt, ref error);
			if (dt.Rows.Count > 0)
			{

				id = int.Parse(dt.Rows[0]["ultimoId"].ToString());

			}

			return OK;
		}

		public bool registroDeshabilitado(string colegiado, ref string error)
		{
			bool OK = false;
			try
			{
				string sQuery = "select t1.Condicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
								" where IdColegiado = '" + colegiado + "' and t2.CondicionFallecido = 'S'";
				DataTable dt = new DataTable();
				if (Consultas.fillDataTable(sQuery, ref dt, ref error))
				{
					if (dt.Rows.Count > 0)
						OK = true;
					else
						OK = false;
				}
			}
			catch (Exception ex)
			{
				error = "[registroDeshabilitado] Ocurrió un error creando el consecutivo:\n" + ex.Message;
			}

			return OK;
		}

		public static void WriteToExcel(DataTable dt)
		{
            MSExcel.Application XlObj = new MSExcel.Application();
			XlObj.Visible = false;
            MSExcel._Workbook WbObj = (MSExcel.Workbook)(XlObj.Workbooks.Add(""));
            MSExcel._Worksheet WsObj = (MSExcel.Worksheet)WbObj.ActiveSheet;
			object misValue = System.Reflection.Missing.Value;


			try
			{
				int row = 1; int col = 1;
				foreach (DataColumn column in dt.Columns)
				{
					//adding columns
					WsObj.Cells[row, col] = column.ColumnName;
					col++;
				}
				//reset column and row variables
				col = 1;
				row++;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					//adding data
					foreach (var cell in dt.Rows[i].ItemArray)
					{
						WsObj.Cells[row, col] = cell;
						col++;
					}
					col = 1;
					row++;
				}
				WbObj.SaveAs("GEN", MSExcel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, MSExcel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				WbObj.Close(true, misValue, misValue);
			}
		}

		public bool cambiarCobradorEnFac_Reg(ref string error)
		{
			bool OK = false;
			//try
			//{
			//    string sQuery = "select t1.Condicion from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 join " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 on t2.CodigoCondicion = t1.Condicion" +
			//                    " where IdColegiado = '" + colegiado + "' and t2.CondicionFallecido = 'S'";
			//    DataTable dt = new DataTable();
			//    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			//    {
			//        if (dt.Rows.Count > 0)
			//            OK = true;
			//        else
			//            OK = false;
			//    }
			//}
			//catch (Exception ex)
			//{
			//    error = "[cambiarCobradorEnFac_Reg] Ocurrió un error:\n" + ex.Message;
			//}

			return OK;
		}

		public void actualizarUltimoCobro(ref List<string> parametros, ref Listado list, string tipoCanon, DateTime ultimoCobro, string identificador, string numRegistro, string categoria, string tipoRegistro)
		{
			string colegiatura = "COL", regencia = "REG", canon = "CANON";

			if (tipoRegistro.Equals(colegiatura) || tipoRegistro.Equals(regencia))
				list.COLUMNAS = "MesUltimoCobro";
			//else if()
			//    list.COLUMNAS = "MesUltimoCobro";
			else if (tipoRegistro.Equals(canon))
				list.COLUMNAS = "AñoUltimoCobro";

			if (tipoRegistro.Equals(colegiatura))
				list.TABLA = "NV_HISTORIAL_COLEGIATURAS";
			else if (tipoRegistro.Equals(regencia))
				list.TABLA = "NV_HISTORIAL_REGENCIAS";
			else if (tipoRegistro.Equals(canon))
				list.TABLA = "NV_HISTORIAL_CANONES_ANUALES";

			if (tipoRegistro.Equals(colegiatura))
				list.FILTRO = " WHERE IdColegiado = '" + identificador + "'";
			else if (tipoRegistro.Equals(regencia))
				list.FILTRO = " WHERE IdColegiado = '" + identificador + "' and NumRegistro = '" + numRegistro + "' and Categoria = '" + categoria + "'";
			else if (tipoRegistro.Equals(canon))
				list.FILTRO = " WHERE Identificador = '" + identificador + "' and Canon = '" + tipoCanon + "'";

			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			//list.COLUMNAS_PK.Add("CodigoCliente");

			parametros.Clear();
			parametros.Add(ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss"));

		}

		public void agregarUltimoCobro(ref List<string> parametros, ref Listado list, string tipoCanon, DateTime ultimoCobro, string identificador, string numRegistro, string categoria, string tipoRegistro)
		{
			string colegiatura = "COL", regencia = "REG", canon = "CANON";

			if (tipoRegistro.Equals(colegiatura))
				list.COLUMNAS = "IdColegiado,MesUltimoCobro";
			else if (tipoRegistro.Equals(regencia))
				list.COLUMNAS = "IdColegiado,NumRegistro,Categoria,MesUltimoCobro";
			else if (tipoRegistro.Equals(canon))
				list.COLUMNAS = "AñoUltimoCobro";

			if (tipoRegistro.Equals(colegiatura))
				list.TABLA = "NV_HISTORIAL_COLEGIATURAS";
			else if (tipoRegistro.Equals(regencia))
				list.TABLA = "NV_HISTORIAL_REGENCIAS";
			else if (tipoRegistro.Equals(canon))
				list.TABLA = "NV_HISTORIAL_CANONES_ANUALES";

			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;

			parametros.Clear();
			parametros.Add(identificador);
			if (tipoRegistro.Equals(regencia))
			{
				parametros.Add(numRegistro);
				parametros.Add(categoria);
			}
			parametros.Add(ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss"));
		}

		public bool existeUltimoCobro(string identificador, string numregistro, string categoria, string tipoCanon, string tipoRegistro)
		{
			string sQuery = "", error = "";
			string colegiatura = "COL", regencia = "REG", canon = "CANON";
			DataTable dt = new DataTable();
			bool existe = true;

			if (tipoRegistro.Equals(colegiatura))
			{
				sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + identificador + "'";
			}

			if (tipoRegistro.Equals(regencia))
			{
				sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS where IdColegiado = '" + identificador + "' and NumRegistro = '" + numregistro + "' and Categoria = '" + categoria + "' ";
			}

			if (tipoRegistro.Equals(canon))
			{
				sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + identificador + "' and Canon = '" + tipoCanon + "'";
			}

			try
			{
				if (Consultas.fillDataTable(sQuery, ref dt, ref error))
				{
					if (dt.Rows.Count > 0)
					{
						existe = true;
					}
					else
					{
						existe = false;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return existe;
		}

		public bool cambiarCobrador_CC(string identificador, string numregistro, string categoria, string tipoRegistro, string nuevoCobrador, ref string error)
		{

			if (nuevoCobrador.Equals(""))
				return true;

			string sQuery = "", colegiatura = "COL", regencia = "REG";
			DataTable dt = new DataTable();
			bool OK = true;

			if (tipoRegistro.Equals(colegiatura))
			{
				sQuery = "SELECT DOCUMENTO,COBRADOR FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC WHERE CLIENTE = '" + identificador + "' AND VENDEDOR = 'COL' AND SALDO > 0";
			}
			else if (tipoRegistro.Equals(regencia))
			{
				sQuery = "SELECT T1.DOCUMENTO,T1.COBRADOR FROM " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC T1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".FACTURA T2 ON T2.FACTURA = T1.DOCUMENTO" +
						" WHERE T1.CLIENTE = '" + identificador + "' AND T2.U_ESTABLE_KOL = '" + numregistro + "' AND T2.U_CATEG_KOL = '" + categoria + "'" +
						" AND T1.VENDEDOR = 'REG' AND T1.SALDO > 0";
			}

			try
			{
				if (Consultas.fillDataTable(sQuery, ref dt, ref error))
				{
					if (dt.Rows.Count > 0)
					{
						foreach (DataRow row in dt.Rows)
						{
							//if (!actualizarCobrador_CC(nuevoCobrador, row["DOCUMENTO"].ToString(), ref error))
							//    break;
							if (!nuevoCobrador.Equals(row["COBRADOR"].ToString()))
								OK = actualizarCobrador_CC(nuevoCobrador, row["DOCUMENTO"].ToString(), ref error);

							if (!OK)
								break;
						}

					}
					//else
					//{
					//    error = "No se encontraron registros para actualizar";
					//    OK = false;
					//}
				}
			}
			catch (Exception ex)
			{
				error = "[cambiarCobrador_CC] Ocurrió un error al obtener registros para actualizar cobrador:\n" + ex.Message;
				OK = false;
			}

			return OK;
		}

		private bool actualizarCobrador_CC(string cobrador, string documento, ref string error)
		{
			//bool OK = true;
			List<string> parametros = new List<string>();

			try
			{
				string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC set COBRADOR = @COBRADOR" +
								 " WHERE DOCUMENTO = @DOCUMENTO";
				parametros.Add("@COBRADOR," + cobrador);
				parametros.Add("@DOCUMENTO," + documento);


				return Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

			}
			catch (Exception ex)
			{
				error = "[actualizarCobradorRegencias_CC] Ocurrió un error al actualizar el cobrador los datos:\n" + ex.Message;
				return false;
			}


			//return OK;

		}

	}
}
