using Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace KOLEGIO
{
	class controlerBD
	{
		public controlerBD()
		{

		}

		public static bool crearCliente(DataTable dtCliente, string idCondPAgo, string idCreacionCliente, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			bool OK = true;
			string condicionPago = "";

			OK = obtenerCondicionPago(idCondPAgo, ref condicionPago, ref error);

			if (OK)
			{
				#region INSERT
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE (CLIENTE,NOMBRE,ALIAS,CONTACTO,FAX,CARGO,");
				sQuery.AppendLine("DIRECCION,DIR_EMB_DEFAULT,TELEFONO1,TELEFONO2,CONTRIBUYENTE,FECHA_INGRESO,MULTIMONEDA,MONEDA,");
				sQuery.AppendLine("SALDO,SALDO_LOCAL,SALDO_DOLAR,SALDO_CREDITO,SALDO_NOCARGOS,EXCEDER_LIMITE,TASA_INTERES,");
				sQuery.AppendLine("TASA_INTERES_MORA,FECHA_ULT_MORA,FECHA_ULT_MOV,CONDICION_PAGO,NIVEL_PRECIO,DESCUENTO,");
				sQuery.AppendLine("MONEDA_NIVEL,ACEPTA_BACKORDER,PAIS,ZONA,RUTA,VENDEDOR,COBRADOR,ACEPTA_FRACCIONES,ACTIVO,EXENTO_IMPUESTOS,");
				sQuery.AppendLine("EXENCION_IMP1,EXENCION_IMP2,COBRO_JUDICIAL,CATEGORIA_CLIENTE,CLASE_ABC,DIAS_ABASTECIMIEN,USA_TARJETA,");
				sQuery.AppendLine("FECHA_VENCE_TARJ,E_MAIL,REQUIERE_OC,ES_CORPORACION,REGISTRARDOCSACORP,USAR_DIREMB_CORP,APLICAC_ABIERTAS,");
				sQuery.AppendLine("VERIF_LIMCRED_CORP,USAR_DESC_CORP,DOC_A_GENERAR,TIENE_CONVENIO,DIAS_PROMED_ATRASO,ASOCOBLIGCONTFACT,");
				sQuery.AppendLine("USAR_PRECIOS_CORP,USAR_EXENCIMP_CORP,AJUSTE_FECHA_COBRO,CLASE_DOCUMENTO,LOCAL,TIPO_CONTRIBUYENTE,");
				sQuery.AppendLine("ACEPTA_DOC_ELECTRONICO,CONFIRMA_DOC_ELECTRONICO,ACEPTA_DOC_EDI,NOTIFICAR_ERROR_EDI,DIVISION_GEOGRAFICA1,");
				sQuery.AppendLine("DIVISION_GEOGRAFICA2,MOROSO,MODIF_NOMB_EN_FAC,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,");
				sQuery.AppendLine("PERMITE_DOC_GP,PARTICIPA_FLUJOCAJA,USUARIO_CREACION,FECHA_HORA_CREACION,USUARIO_ULT_MOD,FCH_HORA_ULT_MOD,DETALLAR_KITS,");
				sQuery.AppendLine("TIPO_IMPUESTO,TIPO_TARIFA,PORC_TARIFA,TIPIFICACION_CLIENTE,AFECTACION_IVA)");

				sQuery.AppendLine("VALUES (@CLIENTE,@NOMBRE,@ALIAS,'ND','ND','ND',@DIRECCION,");
				sQuery.AppendLine("'ND',@TELEFONO1,@TELEFONO2,@CONTRIBUYENTE,CAST(GETDATE() AS DATE),'N','CRC',0,");
				sQuery.AppendLine("0,0,0,0,'N',0,0,'1980-01-01',CAST(GETDATE() AS DATE),");
				//sQuery.AppendLine("(SELECT COND_PAGO_CONTAD FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),");
				sQuery.AppendLine("@CONDICION_PAGO,");
				sQuery.AppendLine("(SELECT NIVEL_PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),0,");
				sQuery.AppendLine("(SELECT MONEDA_NIVEL FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),");
				sQuery.AppendLine("'N',@PAIS,'ND','ND','ND','ND','N','S','N',0,0,'N',");
				//sQuery.AppendLine("(SELECT CATEGORIA_CLIENTE FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),");
				sQuery.AppendLine("@CATEGORIA_CLIENTE,");
				sQuery.AppendLine("'A',0,@USA_TARJETA,@FECHA_VENCE_TARJ,@E_MAIL,'N','N','N','N','N',");
				sQuery.AppendLine("'N','N','F','N',0,'N','N','N','A','N','L','F','N','N','N','N',");
				sQuery.AppendLine("@DIVISION_GEOGRAFICA1,@DIVISION_GEOGRAFICA2,'N','N',0,0,0,'N','N','KOLEGIO'");
				sQuery.AppendLine(",GETDATE(),'KOLEGIO',getdate(),'N'");
				sQuery.AppendLine(",'01','01',0,'05','03')");
				#endregion


				#region PARAMETROS
				List<string> parametros = new List<string>();
				//parametros.Add("@CLIENTE," +dtCliente.Rows[0]["NumeroColegiado"].ToString());//Se cambio de numero colegiado a Id colegiado
				if (idCreacionCliente == "colegiado")
					parametros.Add("@CLIENTE," + dtCliente.Rows[0]["IdColegiado"].ToString());
				if (idCreacionCliente == "estable")
					parametros.Add("@CLIENTE," + dtCliente.Rows[0]["NumRegistro"].ToString());
				if (idCreacionCliente == "consultora")
					parametros.Add("@CLIENTE," + dtCliente.Rows[0]["Codigo"].ToString());

				//if (idCreacionCliente == "colegiado")
				parametros.Add("@CATEGORIA_CLIENTE," + dtCliente.Rows[0]["Categoria"].ToString());
				//if (idCreacionCliente == "estable")
				//    parametros.Add("@CATEGORIA_CLIENTE," + dtCliente.Rows[0]["CategoriaEstable"].ToString());
				//if (idCreacionCliente == "consultora")
				//    parametros.Add("@CATEGORIA_CLIENTE," + dtCliente.Rows[0]["CategoriaConsul"].ToString());

				parametros.Add("@NOMBRE," + dtCliente.Rows[0]["Nombre"].ToString());

				if (idCreacionCliente == "colegiado")
					parametros.Add("@ALIAS," + dtCliente.Rows[0]["NumeroColegiado"].ToString());
				else
					parametros.Add("@ALIAS," + "");
				parametros.Add("@DIRECCION," + dtCliente.Rows[0]["Direccion"].ToString());

				if (idCreacionCliente == "colegiado")
				{
					parametros.Add("@TELEFONO1," + dtCliente.Rows[0]["TelefonoCelular"].ToString());
					parametros.Add("@TELEFONO2," + dtCliente.Rows[0]["TelefonoHabitacion"].ToString());
				}
				else
				{
					parametros.Add("@TELEFONO1," + dtCliente.Rows[0]["Telefono"].ToString());
					parametros.Add("@TELEFONO2," + "");
				}

				if (idCreacionCliente == "colegiado")
					parametros.Add("@CONTRIBUYENTE," + dtCliente.Rows[0]["Cedula"].ToString());
				else
					parametros.Add("@CONTRIBUYENTE," + dtCliente.Rows[0]["CedulaJuridica"].ToString());

				if (idCreacionCliente == "colegiado")
				{
					if (!dtCliente.Rows[0]["Pais"].ToString().Equals(""))
						parametros.Add("@PAIS," + dtCliente.Rows[0]["Pais"].ToString());
					else
						parametros.Add("@PAIS," + "CRI");
				}
				else
					parametros.Add("@PAIS," + "CRI");

				if (idCreacionCliente == "colegiado")
				{
					if (dtCliente.Rows[0]["NumeroTarjeta"].ToString() != "")
						parametros.Add("@USA_TARJETA,S");
					else
						parametros.Add("@USA_TARJETA,N");
				}
				else
					parametros.Add("@USA_TARJETA,N");

				if (idCreacionCliente == "colegiado")
					parametros.Add("@FECHA_VENCE_TARJ," + DateTime.Parse(dtCliente.Rows[0]["VencimientoTarjeta"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
				else
					parametros.Add("@FECHA_VENCE_TARJ," + "");
				parametros.Add("@E_MAIL," + dtCliente.Rows[0]["Email"].ToString());
				parametros.Add("@DIVISION_GEOGRAFICA1," + dtCliente.Rows[0]["Provincia"].ToString());
				parametros.Add("@DIVISION_GEOGRAFICA2," + dtCliente.Rows[0]["Canton"].ToString());
				parametros.Add("@CONDICION_PAGO," + condicionPago);
				#endregion


				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

			}

			if (OK)
			{
				string cli = "";
				if (idCreacionCliente == "colegiado")
					cli = dtCliente.Rows[0]["IdColegiado"].ToString();
				if (idCreacionCliente == "estable")
					cli = dtCliente.Rows[0]["NumRegistro"].ToString();
				if (idCreacionCliente == "consultora")
					cli = dtCliente.Rows[0]["Codigo"].ToString();

				OK = insertarDireccionEmbarque(cli, ref error);
			}


			return OK;
		}

		public static bool insertarDireccionEmbarque(string cliente, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			bool OK = true;

			if (OK)
			{
				#region INSERT
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DIRECC_EMBARQUE (CLIENTE,DIRECCION,DESCRIPCION,DETALLE_DIRECCION)");
				sQuery.AppendLine("VALUES (@CLIENTE,'ND','',@DETALLE_DIRECCION)");
				#endregion


				#region PARAMETROS
				List<string> parametros = new List<string>();

				parametros.Add("@CLIENTE," + cliente);
				parametros.Add("@DETALLE_DIRECCION,null");
				#endregion


				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

			}


			return OK;
		}

		public static bool actualizarAceptaDocElectronicoClienteERP(string clienteERP, string aceptaDoc, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			bool OK = true;

			if (OK)
			{
				#region UPDATE
				sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE");
				sQuery.AppendLine("SET ACEPTA_DOC_ELECTRONICO = @ACEPTA_DOC_ELECTRONICO");
				sQuery.AppendLine("WHERE CLIENTE = @CLIENTE");

				#endregion


				#region PARAMETROS
				List<string> parametros = new List<string>();
				parametros.Add("@CLIENTE," + clienteERP);

				parametros.Add("@ACEPTA_DOC_ELECTRONICO," + aceptaDoc);
				#endregion


				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

			}


			return OK;
		}

		public static bool actualizarCliente(DataTable dtCliente, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			bool OK = true;

			if (OK)
			{
				#region INSERT
				sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE");
				sQuery.AppendLine("SET NOMBRE = @NOMBRE, ALIAS = @ALIAS, DIRECCION = @DIRECCION, ACTIVO = @ACTIVO, CATEGORIA_CLIENTE = @CATEGORIA_CLIENTE,");
				sQuery.AppendLine("TELEFONO1 = @TELEFONO1, TELEFONO2 = @TELEFONO2, CONTRIBUYENTE = @CONTRIBUYENTE,");
				sQuery.AppendLine("PAIS = @PAIS, USA_TARJETA = @USA_TARJETA, FECHA_VENCE_TARJ = @FECHA_VENCE_TARJ,");
				sQuery.AppendLine("E_MAIL = @E_MAIL, DIVISION_GEOGRAFICA1 = @DIVISION_GEOGRAFICA1, DIVISION_GEOGRAFICA2 = @DIVISION_GEOGRAFICA2");
				sQuery.AppendLine("WHERE CLIENTE = @CLIENTE");

				#endregion


				#region PARAMETROS
				List<string> parametros = new List<string>();
				parametros.Add("@CLIENTE," + dtCliente.Rows[0]["idERP"].ToString());

				parametros.Add("@NOMBRE," + dtCliente.Rows[0]["Nombre"].ToString());

				parametros.Add("@CATEGORIA_CLIENTE," + dtCliente.Rows[0]["Categoria"].ToString());
				parametros.Add("@ALIAS," + dtCliente.Rows[0]["Alias"].ToString());
				parametros.Add("@DIRECCION," + dtCliente.Rows[0]["Direccion"].ToString());
				parametros.Add("@ACTIVO," + dtCliente.Rows[0]["Activo"].ToString());
				parametros.Add("@TELEFONO1," + dtCliente.Rows[0]["Telefono1"].ToString());
				parametros.Add("@TELEFONO2," + dtCliente.Rows[0]["Telefono2"].ToString());

				parametros.Add("@CONTRIBUYENTE," + dtCliente.Rows[0]["Contribuyente"].ToString());

				parametros.Add("@PAIS," + dtCliente.Rows[0]["Pais"].ToString());

				parametros.Add("@USA_TARJETA," + dtCliente.Rows[0]["UsaTarjeta"].ToString());

				if (!dtCliente.Rows[0]["VencimientoTarjeta"].ToString().Equals(""))
					parametros.Add("@FECHA_VENCE_TARJ," + DateTime.Parse(dtCliente.Rows[0]["VencimientoTarjeta"].ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
				else
					parametros.Add("@FECHA_VENCE_TARJ,null");

				parametros.Add("@E_MAIL," + dtCliente.Rows[0]["Email"].ToString());
				parametros.Add("@DIVISION_GEOGRAFICA1," + dtCliente.Rows[0]["Provincia"].ToString());
				parametros.Add("@DIVISION_GEOGRAFICA2," + dtCliente.Rows[0]["Canton"].ToString());
				#endregion


				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

			}


			return OK;
		}

		public static bool crearNit(DataTable dtCliente, string identificador, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			List<string> parametrosQuery = new List<string>();


			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NIT (NIT,RAZON_SOCIAL,ALIAS,TIPO,ORIGEN,ACTIVO)");
			sQuery.AppendLine("VALUES (@CLIENTE,@NOMBRE,@ALIAS,'01','O','S')");

			#region PARAMETROS

			//parametros.Add("@CLIENTE," +dtCliente.Rows[0]["NumeroColegiado"].ToString());//Se cambio de numero colegiado a Id colegiado

			if (identificador.Equals("colegiado"))
			{
				parametrosQuery.Add("@CLIENTE," + dtCliente.Rows[0]["Cedula"].ToString());
				parametrosQuery.Add("@NOMBRE," + dtCliente.Rows[0]["Nombre"].ToString());
				parametrosQuery.Add("@ALIAS," + dtCliente.Rows[0]["NumeroColegiado"].ToString());
			}
			else if (identificador.Equals("estable"))
			{
				parametrosQuery.Add("@CLIENTE," + dtCliente.Rows[0]["CedulaJuridica"].ToString());
				parametrosQuery.Add("@NOMBRE," + dtCliente.Rows[0]["Nombre"].ToString());
				parametrosQuery.Add("@ALIAS," + dtCliente.Rows[0]["NumRegistro"].ToString());
			}
			else
			{
				parametrosQuery.Add("@CLIENTE," + dtCliente.Rows[0]["CedulaJuridica"].ToString());
				parametrosQuery.Add("@NOMBRE," + dtCliente.Rows[0]["Nombre"].ToString());
				parametrosQuery.Add("@ALIAS," + dtCliente.Rows[0]["Codigo"].ToString());
			}

			#endregion

			if (Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametrosQuery, ref error))
				return true;
			else
				return false;

		}

		//Este no se esta utilizando
		public static bool CancelacionFacturasCobrador(DataTable dtDocPorColegiado, string numColegiado, decimal MontoAPagar, string escenario,/*bool tieneSaldoFavor,*/ ref string error)
		{

			bool OK = true;
			string moneda = "", condicionPago = "", cobrador = "";
			decimal tipoCambio = 1;
			string documentoRecibo = "";
			decimal montoACancelarPorFactura = 0;
			//decimal montoAFavor = 0;
			//bool requiereDebito = false;

			StringBuilder sQuery = new StringBuilder();
			List<string> parametros = new List<string>();
			DataTable dtDatosCliente = new DataTable();

			sQuery.AppendLine("SELECT MONEDA,CONDICION_PAGO,COBRADOR,");
			sQuery.AppendLine("(select top 1 MONTO from " + Consultas.sqlCon.COMPAÑIA + ".TIPO_CAMBIO_HIST where TIPO_CAMBIO = 'TCOM' and FECHA <=getdate() order by CreateDate desc) TIPO_CAMBIO ");
			sQuery.AppendLine("FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE=@CLIENTE");

			parametros.Add("@CLIENTE," + numColegiado);

			OK = Consultas.fillDataTableParametros(sQuery.ToString(), parametros, ref dtDatosCliente, ref error);

			if (OK)
			{
				if (dtDatosCliente.Rows.Count > 0)
				{
					moneda = dtDatosCliente.Rows[0]["MONEDA"].ToString();
					cobrador = dtDatosCliente.Rows[0]["COBRADOR"].ToString();
					condicionPago = dtDatosCliente.Rows[0]["CONDICION_PAGO"].ToString();
					tipoCambio = decimal.Parse(dtDatosCliente.Rows[0]["TIPO_CAMBIO"].ToString());
				}
			}

			foreach (DataRow row in dtDocPorColegiado.Rows)
			{

				decimal monto = decimal.Parse(row["SALDO"].ToString());
				decimal montoRecibo = 0;
				montoACancelarPorFactura = decimal.Parse(row["SALDO"].ToString());

				#region INSERT_RECIBO
				sQuery.Clear();
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC (DOCUMENTO,TIPO,APLICACION,");
				sQuery.AppendLine("FECHA_DOCUMENTO,FECHA,MONTO,SALDO,MONTO_LOCAL,SALDO_LOCAL,MONTO_DOLAR,SALDO_DOLAR,MONTO_CLIENTE,");
				sQuery.AppendLine("SALDO_CLIENTE,TIPO_CAMBIO_MONEDA,TIPO_CAMBIO_DOLAR,TIPO_CAMBIO_CLIENT,TIPO_CAMB_ACT_LOC,");
				sQuery.AppendLine("TIPO_CAMB_ACT_DOL,TIPO_CAMB_ACT_CLI,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO1,RUBRO2,MONTO_RETENCION,");
				sQuery.AppendLine("SALDO_RETENCION,DEPENDIENTE,FECHA_ULT_CREDITO,CARGADO_DE_FACT,APROBADO,ASIENTO_PENDIENTE,FECHA_ULT_MOD,");
				sQuery.AppendLine("CLASE_DOCUMENTO,FECHA_VENCE,NUM_PARCIALIDADES,COBRADOR,USUARIO_ULT_MOD,CONDICION_PAGO,MONEDA,CLIENTE_REPORTE,CLIENTE_ORIGEN,");
				sQuery.AppendLine("CLIENTE,SUBTIPO,PORC_INTCTE,USUARIO_APROBACION,FECHA_APROBACION,ANULADO,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,SALDO_TRANS_CLI,FACTURADO,GENERA_DOC_FE)");

				sQuery.AppendLine("VALUES (@DOCUMENTO,'REC','Pago mensualidad KOLEGIO',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),@MONTO,@SALDO,@MONTO_LOCAL,");
				sQuery.AppendLine("@SALDO_LOCAL,@MONTO_DOLAR,@SALDO_DOLAR,@MONTO_CLIENTE,@SALDO_CLIENTE,@TIPO_CAMBIO_MONEDA,");
				sQuery.AppendLine("@TIPO_CAMBIO_DOLAR,@TIPO_CAMBIO_CLIENT,@TIPO_CAMB_ACT_LOC,@TIPO_CAMB_ACT_DOL,@TIPO_CAMB_ACT_CLI,");
				sQuery.AppendLine("@SUBTOTAL,0,0,0,0,0,0,0,'N','1980-01-01','N','S','N','1980-01-01','N',CAST(GETDATE() AS DATE),0,@COBRADOR,'" + Consultas.sqlCon.USUARIO + "',");
				sQuery.AppendLine("@CONDICION_PAGO,@MONEDA,@CLIENTE,@CLIENTE,@CLIENTE,@SUBTIPO,0,'" + Consultas.sqlCon.USUARIO + "',CAST(GETDATE() AS DATE),'N',");
				sQuery.AppendLine("@SALDO_TRANS,@SALDO_TRANS_LOCAL,@SALDO_TRANS_DOLAR,@SALDO_TRANS_CLI,'N','N')");

				#endregion


				parametros = new List<string>();

				OK = obtenerConsecutivo("RECIBOS", ref documentoRecibo, ref error);

				if (OK)
				{
					#region PARAMETROS_RECIBO

					string prefix = Regex.Match(documentoRecibo, "^\\D+").Value;
					string number = Regex.Replace(documentoRecibo, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					documentoRecibo = prefix + numberMasUno.ToString(new string('0', number.Length));
					//Asignamos el valor del monto del recibo de acuerdo al monto a pagar si es menor se calcula 
					//y si es mayor o igual se realiza el recibo con la misma cantidad de la factura para cancelarla
					if (MontoAPagar >= monto)
					{
						montoRecibo = monto;
					}
					else
						montoRecibo = MontoAPagar;


					parametros.Add("@DOCUMENTO," + documentoRecibo);
					parametros.Add("@MONTO," + montoRecibo);
					parametros.Add("@SALDO," + montoRecibo);
					if (moneda == "CRC")
					{
						parametros.Add("@MONTO_LOCAL," + montoRecibo);
						parametros.Add("@SALDO_LOCAL," + montoRecibo);
						parametros.Add("@SALDO_TRANS_LOCAL," + montoRecibo);
						parametros.Add("@SALDO_TRANS_DOLAR," + Math.Round(montoRecibo / tipoCambio, 2));
						parametros.Add("@MONTO_DOLAR," + Math.Round(montoRecibo / tipoCambio, 2));
						parametros.Add("@SALDO_DOLAR," + Math.Round(montoRecibo / tipoCambio, 2));

						parametros.Add("@TIPO_CAMBIO_MONEDA," + 1);
						parametros.Add("@TIPO_CAMBIO_CLIENT," + 1);
						parametros.Add("@TIPO_CAMB_ACT_LOC," + 1);
						parametros.Add("@TIPO_CAMB_ACT_CLI," + 1);

					}
					else
					{
						parametros.Add("@MONTO_LOCAL," + Math.Round(montoRecibo * tipoCambio, 2));
						parametros.Add("@SALDO_LOCAL," + Math.Round(montoRecibo * tipoCambio, 2));
						parametros.Add("@SALDO_TRANS_LOCAL," + Math.Round(montoRecibo * tipoCambio, 2));
						parametros.Add("@SALDO_TRANS_DOLAR," + montoRecibo);
						parametros.Add("@MONTO_DOLAR," + montoRecibo);
						parametros.Add("@SALDO_DOLAR," + montoRecibo);
						parametros.Add("@TIPO_CAMBIO_MONEDA," + tipoCambio);
						parametros.Add("@TIPO_CAMBIO_CLIENT," + tipoCambio);
						parametros.Add("@TIPO_CAMB_ACT_LOC," + tipoCambio);
						parametros.Add("@TIPO_CAMB_ACT_CLI," + tipoCambio);
					}
					parametros.Add("@MONTO_CLIENTE," + montoRecibo);
					parametros.Add("@SALDO_CLIENTE," + montoRecibo);
					parametros.Add("@SUBTOTAL," + montoRecibo);

					parametros.Add("@SALDO_TRANS," + montoRecibo);
					parametros.Add("@SALDO_TRANS_CLI," + montoRecibo);

					parametros.Add("@TIPO_CAMBIO_DOLAR," + tipoCambio);
					parametros.Add("@TIPO_CAMB_ACT_DOL," + tipoCambio);

					parametros.Add("@COBRADOR," + cobrador);
					parametros.Add("@CONDICION_PAGO," + condicionPago);
					parametros.Add("@MONEDA," + moneda);
					parametros.Add("@CLIENTE," + numColegiado);
					parametros.Add("@SUBTIPO," + 0);///Cambiar por el que kolegio tenga que usar

					#endregion

					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}

				if (OK)
					OK = actualizarConsecutivo("RECIBOS", documentoRecibo, ref error);

				if (OK && MontoAPagar >= decimal.Parse(row["SALDO"].ToString()))
				{
					#region INSERT_AUXILIAR_CC
					sQuery.Clear();
					sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_CC (TIPO_CREDITO,TIPO_DEBITO,");
					sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
					sQuery.AppendLine("ASIENTO,TIPO_DOCPPAGO,DOCUMENTO_DOCPPAGO,MONTO_CLI_DEBITO,MONEDA_CREDITO,MONEDA_DEBITO,");
					sQuery.AppendLine("CLI_REPORTE_CREDIT,CLI_REPORTE_DEBITO,CLI_DOC_CREDIT,CLI_DOC_DEBITO,TIPO_DOCINTCTE,DOC_DOCINTCTE,FOLIOSAT_DEBITO,FOLIOSAT_CREDITO,TIPO_CAMBIO_APLICA)");

					sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
					sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@ASIENTO,@TIPO_DOCPPAGO,@DOCUMENTO_DOCPPAGO,@MONTO_CLI_DEBITO,'CRC',");
					sQuery.AppendLine("'CRC',@CLI_REPORTE_CREDIT,@CLI_REPORTE_DEBITO,@CLI_DOC_CREDIT,@CLI_DOC_DEBITO,@TIPO_DOCINTCTE,@DOC_DOCINTCTE,");
					sQuery.AppendLine("@FOLIOSAT_DEBITO,@FOLIOSAT_CREDITO,@TIPO_CAMBIO_APLICA)");
					#endregion

					parametros = new List<string>();

					#region PARAMETROS_AUXILIAR_CC

					parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
					parametros.Add("@CREDITO," + documentoRecibo);
					parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());

					parametros.Add("@MONTO_DEBITO," + row["MONTO"].ToString());
					parametros.Add("@MONTO_CREDITO," + montoRecibo);
					parametros.Add("@MONTO_LOCAL," + monto);
					parametros.Add("@MONTO_DOLAR," + Math.Round(monto / tipoCambio, 2));
					parametros.Add("@MONTO_CLI_CREDITO," + montoRecibo);

					parametros.Add("@ASIENTO," + "null");
					parametros.Add("@TIPO_DOCPPAGO," + "null");
					parametros.Add("@DOCUMENTO_DOCPPAGO," + "null");
					parametros.Add("@MONTO_CLI_DEBITO," + row["MONTO"].ToString());
					parametros.Add("@CLI_REPORTE_CREDIT," + numColegiado);
					parametros.Add("@CLI_REPORTE_DEBITO," + row["CLIENTE"].ToString());
					parametros.Add("@CLI_DOC_CREDIT," + numColegiado);
					parametros.Add("@CLI_DOC_DEBITO," + row["CLIENTE"].ToString());

					parametros.Add("@TIPO_DOCINTCTE," + "null");
					parametros.Add("@DOC_DOCINTCTE," + "null");
					parametros.Add("@FOLIOSAT_DEBITO," + "null");
					parametros.Add("@FOLIOSAT_CREDITO," + "null");
					parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
					#endregion

					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}

				//Actualizamos saldos de la factura pendiente 
				if (OK)
				{
					sQuery.Clear();
					sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
					sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
					sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
					sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");

					parametros = new List<string>();

					parametros.Add("@DOCUMENTO," + row["DOCUMENTO"].ToString());

					if (escenario == "Igual")
					{
						parametros.Add("@SALDO," + 0);
						parametros.Add("@SALDO_LOCAL," + 0);
						parametros.Add("@SALDO_CLIENTE," + 0);
					}

					if (escenario == "Menor")
					{

						if (MontoAPagar > decimal.Parse(row["SALDO"].ToString()))
						{
							parametros.Add("@SALDO," + 0);
							parametros.Add("@SALDO_LOCAL," + 0);
							parametros.Add("@SALDO_CLIENTE," + 0);
						}
						else
						{
							decimal sald = decimal.Parse(row["SALDO"].ToString()) - MontoAPagar;
							parametros.Add("@SALDO," + sald);
							parametros.Add("@SALDO_LOCAL," + sald);
							parametros.Add("@SALDO_CLIENTE," + sald);
						}

					}

					if (escenario == "Mayor")
					{
						if (MontoAPagar > decimal.Parse(row["SALDO"].ToString()))
						{
							parametros.Add("@SALDO," + 0);
							parametros.Add("@SALDO_LOCAL," + 0);
							parametros.Add("@SALDO_CLIENTE," + 0);
						}
					}

					parametros.Add("@FECHA_ULT_MOD," + DateTime.Now);

					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}

				//if (OK)
				//{
				//    sQuery.Clear();
				//    sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
				//    sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
				//    sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
				//    sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");


				//    parametros = new List<string>();
				//    parametros.Add("@DOCUMENTO," + documentoRecibo);

				//    if (escenario == "Igual")
				//    {
				//        parametros.Add("@SALDO," + 0);
				//        parametros.Add("@SALDO_LOCAL," + 0);
				//        parametros.Add("@SALDO_CLIENTE," + 0);
				//    }

				//    if (escenario == "Menor")
				//    {

				//        if (MontoAPagar > decimal.Parse(row["SALDO"].ToString()))
				//        {
				//            parametros.Add("@SALDO," + 0);
				//            parametros.Add("@SALDO_LOCAL," + 0);
				//            parametros.Add("@SALDO_CLIENTE," + 0);
				//        }
				//        else
				//        {
				//            decimal sald = decimal.Parse(row["SALDO"].ToString()) - MontoAPagar;
				//            parametros.Add("@SALDO," + sald);
				//            parametros.Add("@SALDO_LOCAL," + sald);
				//            parametros.Add("@SALDO_CLIENTE," + sald);
				//        }

				//    }

				//    if (escenario == "Mayor")
				//    {
				//        //requiereDebito = true;
				//        if (MontoAPagar > decimal.Parse(row["SALDO"].ToString()))
				//        {
				//            parametros.Add("@SALDO," + 0);
				//            parametros.Add("@SALDO_LOCAL," + 0);
				//            parametros.Add("@SALDO_CLIENTE," + 0);
				//        }
				//        //montoAFavor = decimal.Parse(row["SALDO"].ToString()) - MontoAPagar;


				//    }

				//    parametros.Add("@FECHA_ULT_MOD," + DateTime.Now);

				//    OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				//}

				MontoAPagar = MontoAPagar - decimal.Parse(row["SALDO"].ToString());

				if (!OK || MontoAPagar <= 0)
					break;

			}

			//if (tieneSaldoFavor)//Actualizamos saldo a 0 del credito a favor si fue utilizado
			//{
			//    sQuery.Clear();
			//    sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
			//    sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
			//    sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
			//    sQuery.AppendLine("WHERE DOCUMENTO = 'O/C' AND CLIENTE = '"+numColegiado+"'");

			//    parametros = new List<string>();

			//    parametros.Add("@SALDO," + 0);
			//    parametros.Add("@SALDO_LOCAL," + 0);
			//    parametros.Add("@SALDO_CLIENTE," + 0);
			//    parametros.Add("@FECHA_ULT_MOD," + DateTime.Now);

			//    OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
			//}


			if (escenario == "Mayor")//Siempre que quede saldo se inserta un credito
			{
				#region INSERT_CREDITO-MONTO_FAVOR
				sQuery.Clear();
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC (DOCUMENTO,TIPO,APLICACION,");
				sQuery.AppendLine("FECHA_DOCUMENTO,FECHA,MONTO,SALDO,MONTO_LOCAL,SALDO_LOCAL,MONTO_DOLAR,SALDO_DOLAR,MONTO_CLIENTE,");
				sQuery.AppendLine("SALDO_CLIENTE,TIPO_CAMBIO_MONEDA,TIPO_CAMBIO_DOLAR,TIPO_CAMBIO_CLIENT,TIPO_CAMB_ACT_LOC,");
				sQuery.AppendLine("TIPO_CAMB_ACT_DOL,TIPO_CAMB_ACT_CLI,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO1,RUBRO2,MONTO_RETENCION,");
				sQuery.AppendLine("SALDO_RETENCION,DEPENDIENTE,FECHA_ULT_CREDITO,CARGADO_DE_FACT,APROBADO,ASIENTO_PENDIENTE,FECHA_ULT_MOD,");
				sQuery.AppendLine("CLASE_DOCUMENTO,FECHA_VENCE,NUM_PARCIALIDADES,COBRADOR,USUARIO_ULT_MOD,CONDICION_PAGO,MONEDA,CLIENTE_REPORTE,CLIENTE_ORIGEN,");
				sQuery.AppendLine("CLIENTE,SUBTIPO,PORC_INTCTE,USUARIO_APROBACION,FECHA_APROBACION,ANULADO,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,SALDO_TRANS_CLI,FACTURADO,GENERA_DOC_FE)");

				sQuery.AppendLine("VALUES (@DOCUMENTO,'O/C','Saldo a Favor del Colegiado KOLEGIO',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),@MONTO,@SALDO,@MONTO_LOCAL,");
				sQuery.AppendLine("@SALDO_LOCAL,@MONTO_DOLAR,@SALDO_DOLAR,@MONTO_CLIENTE,@SALDO_CLIENTE,@TIPO_CAMBIO_MONEDA,");
				sQuery.AppendLine("@TIPO_CAMBIO_DOLAR,@TIPO_CAMBIO_CLIENT,@TIPO_CAMB_ACT_LOC,@TIPO_CAMB_ACT_DOL,@TIPO_CAMB_ACT_CLI,");
				sQuery.AppendLine("@SUBTOTAL,0,0,0,0,0,0,0,'N','1980-01-01','N','S','N','1980-01-01','N',CAST(GETDATE() AS DATE),0,@COBRADOR,'" + Consultas.sqlCon.USUARIO + "',");
				sQuery.AppendLine("@CONDICION_PAGO,@MONEDA,@CLIENTE,@CLIENTE,@CLIENTE,@SUBTIPO,0,'" + Consultas.sqlCon.USUARIO + "',CAST(GETDATE() AS DATE),'N',");
				sQuery.AppendLine("@SALDO_TRANS,@SALDO_TRANS_LOCAL,@SALDO_TRANS_DOLAR,@SALDO_TRANS_CLI,'N','N')");

				#endregion


				parametros = new List<string>();

				OK = obtenerConsecutivo("RECIBOS", ref documentoRecibo, ref error);//Cambiar consecutivo

				if (OK)
				{
					#region PARAMETROS_CREDITO-MONTO_FAVOR

					string prefix = Regex.Match(documentoRecibo, "^\\D+").Value;
					string number = Regex.Replace(documentoRecibo, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					documentoRecibo = prefix + numberMasUno.ToString(new string('0', number.Length));


					parametros.Add("@DOCUMENTO," + documentoRecibo);
					parametros.Add("@MONTO," + MontoAPagar);
					parametros.Add("@SALDO," + MontoAPagar);
					if (moneda == "CRC")
					{
						parametros.Add("@MONTO_LOCAL," + MontoAPagar);
						parametros.Add("@SALDO_LOCAL," + MontoAPagar);
						parametros.Add("@SALDO_TRANS_LOCAL," + MontoAPagar);
						parametros.Add("@SALDO_TRANS_DOLAR," + Math.Round(MontoAPagar / tipoCambio, 2));
						parametros.Add("@MONTO_DOLAR," + Math.Round(MontoAPagar / tipoCambio, 2));
						parametros.Add("@SALDO_DOLAR," + Math.Round(MontoAPagar / tipoCambio, 2));

						parametros.Add("@TIPO_CAMBIO_MONEDA," + 1);
						parametros.Add("@TIPO_CAMBIO_CLIENT," + 1);
						parametros.Add("@TIPO_CAMB_ACT_LOC," + 1);
						parametros.Add("@TIPO_CAMB_ACT_CLI," + 1);

					}
					else
					{
						parametros.Add("@MONTO_LOCAL," + Math.Round(MontoAPagar * tipoCambio, 2));
						parametros.Add("@SALDO_LOCAL," + Math.Round(MontoAPagar * tipoCambio, 2));
						parametros.Add("@SALDO_TRANS_LOCAL," + Math.Round(MontoAPagar * tipoCambio, 2));
						parametros.Add("@SALDO_TRANS_DOLAR," + MontoAPagar);
						parametros.Add("@MONTO_DOLAR," + MontoAPagar);
						parametros.Add("@SALDO_DOLAR," + MontoAPagar);
						parametros.Add("@TIPO_CAMBIO_MONEDA," + tipoCambio);
						parametros.Add("@TIPO_CAMBIO_CLIENT," + tipoCambio);
						parametros.Add("@TIPO_CAMB_ACT_LOC," + tipoCambio);
						parametros.Add("@TIPO_CAMB_ACT_CLI," + tipoCambio);
					}
					parametros.Add("@MONTO_CLIENTE," + MontoAPagar);
					parametros.Add("@SALDO_CLIENTE," + MontoAPagar);
					parametros.Add("@SUBTOTAL," + MontoAPagar);

					parametros.Add("@SALDO_TRANS," + MontoAPagar);
					parametros.Add("@SALDO_TRANS_CLI," + MontoAPagar);

					parametros.Add("@TIPO_CAMBIO_DOLAR," + tipoCambio);
					parametros.Add("@TIPO_CAMB_ACT_DOL," + tipoCambio);

					parametros.Add("@COBRADOR," + cobrador);
					parametros.Add("@CONDICION_PAGO," + condicionPago);
					parametros.Add("@MONEDA," + moneda);
					parametros.Add("@CLIENTE," + numColegiado);
					parametros.Add("@SUBTIPO," + 0);///Cambiar por el que kolegio tenga que usar

					#endregion

					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}

				if (OK)
					OK = actualizarConsecutivo("RECIBOS", documentoRecibo, ref error);
			}

			return OK;
		}

		//Todavia tiene la condicion de pago del CLIENTE
		//public static bool cobrosCobrador(DataTable dtDocPorColegiado, string numColegiado, string cobradorColegiado, decimal MontoArchivo, string documentosCarga, DateTime fechaDoc, bool soloRecibo, ref decimal montoRecibo, ref string error)
		//{

		//	bool OK = true;
		//	string moneda = "", condicionPago = "", cobrador = "", nombreCobrador = "", docPorParcialidad = "";
		//	decimal tipoCambio = 1;
		//	string documentoRecibo = "";
		//	string subtipoRec = "", actividadComercial = "";
		//	decimal saldoDocumento = 0, saldoRecibo = 0, saldoDocumentoPadre;
		//	decimal saldoAplicacion = 0, totalSaldoAplicadoParc = 0;
		//	int parcMaxPorDoc = 0;
		//	numColegiado = FuncsInternas.obtenerIdColegiado(numColegiado);


		//	StringBuilder sQuery = new StringBuilder();
		//	List<string> parametros = new List<string>();
		//	DataTable dtDatosCliente = new DataTable();

		//	#region OBTENER_DATOS_CLIENTE
		//	sQuery.AppendLine("SELECT MONEDA,CONDICION_PAGO,COBRADOR,");
		//	sQuery.AppendLine("(select top 1 MONTO from " + Consultas.sqlCon.COMPAÑIA + ".TIPO_CAMBIO_HIST where TIPO_CAMBIO = 'TCOM' and FECHA <=getdate() order by CreateDate desc) TIPO_CAMBIO ");
		//	sQuery.AppendLine("FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE=@CLIENTE");

		//	parametros.Add("@CLIENTE," + numColegiado);

		//	OK = Consultas.fillDataTableParametros(sQuery.ToString(), parametros, ref dtDatosCliente, ref error);

		//	if (OK)
		//	{
		//		cobrador = cobradorColegiado;
		//		if (dtDatosCliente.Rows.Count > 0)
		//		{
		//			moneda = dtDatosCliente.Rows[0]["MONEDA"].ToString();
		//			//cobrador = dtDatosCliente.Rows[0]["COBRADOR"].ToString();                    
		//			condicionPago = dtDatosCliente.Rows[0]["CONDICION_PAGO"].ToString();
		//			tipoCambio = decimal.Parse(dtDatosCliente.Rows[0]["TIPO_CAMBIO"].ToString());
		//		}
		//	}
		//	#endregion


		//	#region CREAR_RECIBO

		//	#region INSERT_RECIBO
		//	sQuery.Clear();
		//	sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC (DOCUMENTO,TIPO,APLICACION,");
		//	sQuery.AppendLine("FECHA_DOCUMENTO,FECHA,MONTO,SALDO,MONTO_LOCAL,SALDO_LOCAL,MONTO_DOLAR,SALDO_DOLAR,MONTO_CLIENTE,");
		//	sQuery.AppendLine("SALDO_CLIENTE,TIPO_CAMBIO_MONEDA,TIPO_CAMBIO_DOLAR,TIPO_CAMBIO_CLIENT,TIPO_CAMB_ACT_LOC,");
		//	sQuery.AppendLine("TIPO_CAMB_ACT_DOL,TIPO_CAMB_ACT_CLI,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO1,RUBRO2,MONTO_RETENCION,");
		//	sQuery.AppendLine("SALDO_RETENCION,DEPENDIENTE,FECHA_ULT_CREDITO,CARGADO_DE_FACT,APROBADO,ASIENTO_PENDIENTE,FECHA_ULT_MOD,");
		//	sQuery.AppendLine("CLASE_DOCUMENTO,FECHA_VENCE,NUM_PARCIALIDADES,COBRADOR,USUARIO_ULT_MOD,CONDICION_PAGO,VENDEDOR,MONEDA,CLIENTE_REPORTE,CLIENTE_ORIGEN,");
		//	sQuery.AppendLine("CLIENTE,SUBTIPO,PORC_INTCTE,USUARIO_APROBACION,FECHA_APROBACION,ANULADO,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,SALDO_TRANS_CLI,FACTURADO,GENERA_DOC_FE,TIPO_IMPUESTO1,TIPO_TARIFA1,ACTIVIDAD_COMERCIAL)");

		//	sQuery.AppendLine("VALUES (@DOCUMENTO,'REC',@APLICACION,@FECHA_DOCUMENTO,CAST(GETDATE() AS DATE),@MONTO,@SALDO,@MONTO_LOCAL,");
		//	sQuery.AppendLine("@SALDO_LOCAL,@MONTO_DOLAR,@SALDO_DOLAR,@MONTO_CLIENTE,@SALDO_CLIENTE,@TIPO_CAMBIO_MONEDA,");
		//	sQuery.AppendLine("@TIPO_CAMBIO_DOLAR,@TIPO_CAMBIO_CLIENT,@TIPO_CAMB_ACT_LOC,@TIPO_CAMB_ACT_DOL,@TIPO_CAMB_ACT_CLI,");
		//	sQuery.AppendLine("@SUBTOTAL,0,0,0,0,0,0,0,'N','1980-01-01','N','S','N','1980-01-01','N',CAST(GETDATE() AS DATE),0,@COBRADOR,'KOLEGIO',");
		//	sQuery.AppendLine("@CONDICION_PAGO,'ND',@MONEDA,@CLIENTE,@CLIENTE,@CLIENTE,@SUBTIPO,0,'KOLEGIO',CAST(GETDATE() AS DATE),'N',");
		//	sQuery.AppendLine("@SALDO_TRANS,@SALDO_TRANS_LOCAL,@SALDO_TRANS_DOLAR,@SALDO_TRANS_CLI,'N','N','01','01',@ACTIVIDAD_COMERCIAL)");

		//	#endregion

		//	if (OK)
		//		OK = obtenerConsecutivo("RECIBOS", ref documentoRecibo, ref error);

		//	if (OK)
		//		OK = FuncsInternas.obtenerSubtipoRec(cobrador, ref subtipoRec, ref error);

		//	if (OK)
		//		OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

		//	if (OK)
		//		OK = FuncsInternas.obtenerNombreCobrador(cobrador, ref nombreCobrador, ref error);

		//	if (OK)
		//	{
		//		#region PARAMETROS_RECIBO

		//		string prefix = Regex.Match(documentoRecibo, "^\\D+").Value;
		//		string number = Regex.Replace(documentoRecibo, "^\\D+", "");
		//		int numberMasUno = int.Parse(number) + 1;
		//		documentoRecibo = prefix + numberMasUno.ToString(new string('0', number.Length));

		//		parametros = new List<string>();

		//		parametros.Add("@DOCUMENTO," + documentoRecibo);
		//		parametros.Add("@APLICACION," + documentosCarga + " /RECIBO /" + nombreCobrador);
		//		parametros.Add("@MONTO," + MontoArchivo);
		//		parametros.Add("@SALDO," + MontoArchivo);
		//		//parametros.Add("@FECHA_DOCUMENTO," + fechaDoc.ToString("yyyy-MM-ddTHH:mm:ss"));
		//		parametros.Add("@FECHA_DOCUMENTO," + fechaDoc.ToString("yyyy-MM-dd"));
		//		if (moneda == "CRC")
		//		{
		//			parametros.Add("@MONTO_LOCAL," + MontoArchivo);
		//			parametros.Add("@SALDO_LOCAL," + MontoArchivo);
		//			parametros.Add("@SALDO_TRANS_LOCAL," + MontoArchivo);
		//			parametros.Add("@SALDO_TRANS_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));
		//			parametros.Add("@MONTO_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));
		//			parametros.Add("@SALDO_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));

		//			parametros.Add("@TIPO_CAMBIO_MONEDA," + 1);
		//			parametros.Add("@TIPO_CAMBIO_CLIENT," + 1);
		//			parametros.Add("@TIPO_CAMB_ACT_LOC," + 1);
		//			parametros.Add("@TIPO_CAMB_ACT_CLI," + 1);

		//		}
		//		else
		//		{
		//			parametros.Add("@MONTO_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
		//			parametros.Add("@SALDO_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
		//			parametros.Add("@SALDO_TRANS_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
		//			parametros.Add("@SALDO_TRANS_DOLAR," + MontoArchivo);
		//			parametros.Add("@MONTO_DOLAR," + MontoArchivo);
		//			parametros.Add("@SALDO_DOLAR," + MontoArchivo);
		//			parametros.Add("@TIPO_CAMBIO_MONEDA," + tipoCambio);
		//			parametros.Add("@TIPO_CAMBIO_CLIENT," + tipoCambio);
		//			parametros.Add("@TIPO_CAMB_ACT_LOC," + tipoCambio);
		//			parametros.Add("@TIPO_CAMB_ACT_CLI," + tipoCambio);
		//		}
		//		parametros.Add("@MONTO_CLIENTE," + MontoArchivo);
		//		parametros.Add("@SALDO_CLIENTE," + MontoArchivo);
		//		parametros.Add("@SUBTOTAL," + MontoArchivo);

		//		parametros.Add("@SALDO_TRANS," + MontoArchivo);
		//		parametros.Add("@SALDO_TRANS_CLI," + MontoArchivo);

		//		parametros.Add("@TIPO_CAMBIO_DOLAR," + tipoCambio);
		//		parametros.Add("@TIPO_CAMB_ACT_DOL," + tipoCambio);

		//		parametros.Add("@COBRADOR," + cobrador);
		//		parametros.Add("@CONDICION_PAGO," + condicionPago);
		//		if (!moneda.Equals(""))
		//			parametros.Add("@MONEDA," + moneda);
		//		else
		//			parametros.Add("@MONEDA," + "ND");
		//		parametros.Add("@CLIENTE," + numColegiado);
		//		parametros.Add("@SUBTIPO," + subtipoRec);
		//		parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);

		//		#endregion

		//		OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
		//	}

		//	if (OK)
		//		OK = actualizarConsecutivo("RECIBOS", documentoRecibo, ref error);


		//	#endregion


		//	if (OK && !soloRecibo)
		//	{
		//		foreach (DataRow row in dtDocPorColegiado.Rows)
		//		{
		//			DataTable dtSaldoRecibo = new DataTable();

		//			string sSaldo = "select SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where DOCUMENTO = '" + documentoRecibo + "' ";

		//			OK = Consultas.fillDataTable(sSaldo, ref dtSaldoRecibo, ref error);

		//			if (OK)
		//			{
		//				if (dtSaldoRecibo.Rows.Count > 0)
		//					saldoRecibo = decimal.Parse(dtSaldoRecibo.Rows[0]["SALDO"].ToString());

		//				saldoDocumento = decimal.Parse(row["SALDO"].ToString());

		//				if (saldoDocumento == saldoRecibo)//Obtenemos el saldo de aplicacion a la factura-siempre se aplica el saldo menor
		//				{
		//					saldoAplicacion = saldoDocumento;
		//					saldoRecibo = 0;
		//					saldoDocumento = 0;
		//				}
		//				else
		//				{
		//					if (saldoDocumento < saldoRecibo)
		//					{
		//						saldoAplicacion = saldoDocumento;
		//						saldoRecibo = saldoRecibo - saldoAplicacion;
		//						saldoDocumento = 0;
		//					}
		//					else
		//					{
		//						saldoAplicacion = saldoRecibo;
		//						saldoRecibo = 0;
		//						saldoDocumento = saldoDocumento - saldoAplicacion;
		//					}
		//				}

		//				if (int.Parse(row["NUM_PARCIALIDADES"].ToString()) > 2)
		//				{
		//					totalSaldoAplicadoParc += saldoAplicacion;

		//					if (parcMaxPorDoc == 0)
		//					{
		//						foreach (DataRow item in dtDocPorColegiado.Rows)
		//						{
		//							if (item["DOCUMENTO"].ToString().Equals(row["DOCUMENTO"].ToString()))
		//							{
		//								if (parcMaxPorDoc < int.Parse(item["PARCIALIDAD"].ToString()))
		//									parcMaxPorDoc = int.Parse(item["PARCIALIDAD"].ToString());
		//							}
		//						}
		//					}

		//					//docPorParcialidad = row["DOCUMENTO"].ToString();
		//				}
		//				else
		//				{
		//					//docPorParcialidad = string.Empty;
		//					totalSaldoAplicadoParc = 0;
		//					parcMaxPorDoc = 0;
		//				}
		//			}

		//			#region ACRUALIZAR_SALDO_PARCIALIDAD

		//			if (OK && int.Parse(row["NUM_PARCIALIDADES"].ToString()) > 2)
		//			{
		//				sQuery.Clear();
		//				sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC ");
		//				sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
		//				sQuery.AppendLine("SALDO_DOLAR = @SALDO_DOLAR, SALDO_AMORTIZA = @SALDO_AMORTIZA, SALDO_AMORTIZA_LOC = @SALDO_AMORTIZA_LOC, SALDO_AMORTIZA_DOL = @SALDO_AMORTIZA_DOL");
		//				sQuery.AppendLine("WHERE DOCUMENTO_ORIGEN = @DOCUMENTO_ORIGEN AND PARCIALIDAD = @PARCIALIDAD");

		//				parametros = new List<string>();

		//				parametros.Add("@DOCUMENTO_ORIGEN," + row["DOCUMENTO"].ToString());
		//				parametros.Add("@PARCIALIDAD," + row["PARCIALIDAD"].ToString());


		//				parametros.Add("@SALDO," + saldoDocumento);
		//				parametros.Add("@SALDO_LOCAL," + saldoDocumento);
		//				parametros.Add("@SALDO_DOLAR," + Math.Round(saldoDocumento / tipoCambio, 2));
		//				parametros.Add("@SALDO_AMORTIZA," + saldoAplicacion);
		//				parametros.Add("@SALDO_AMORTIZA_LOC," + saldoAplicacion);
		//				parametros.Add("@SALDO_AMORTIZA_DOL," + Math.Round(saldoAplicacion / tipoCambio, 2));

		//				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
		//			}
		//			#endregion

		//			#region ACRUALIZAR_SALDO_FACTURA

		//			if (OK)
		//			{
		//				sQuery.Clear();
		//				sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
		//				sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
		//				sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
		//				sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");

		//				parametros = new List<string>();

		//				parametros.Add("@DOCUMENTO," + row["DOCUMENTO"].ToString());

		//				if (int.Parse(row["NUM_PARCIALIDADES"].ToString()) > 2)
		//				{
		//					DataTable dtSaldoTotalFac = new DataTable();
		//					string sSaldoTotalFac = "select SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where DOCUMENTO = '" + row["DOCUMENTO"].ToString() + "' ";

		//					OK = Consultas.fillDataTable(sSaldoTotalFac, ref dtSaldoTotalFac, ref error);

		//					var saldo = decimal.Parse(dtSaldoTotalFac.Rows[0]["SALDO"].ToString());

		//					parametros.Add("@SALDO," + (saldo - saldoAplicacion));
		//					parametros.Add("@SALDO_LOCAL," + (saldo - saldoAplicacion));
		//					parametros.Add("@SALDO_CLIENTE," + (saldo - saldoAplicacion));
		//				}
		//				else
		//				{
		//					parametros.Add("@SALDO," + saldoDocumento);
		//					parametros.Add("@SALDO_LOCAL," + saldoDocumento);
		//					parametros.Add("@SALDO_CLIENTE," + saldoDocumento);
		//				}

		//				parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

		//				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
		//			}
		//			#endregion

		//			#region ACRUALIZAR_SALDO_RECIBO

		//			if (OK)
		//			{
		//				sQuery.Clear();
		//				sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
		//				sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
		//				sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
		//				sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");


		//				parametros = new List<string>();
		//				parametros.Add("@DOCUMENTO," + documentoRecibo);

		//				parametros.Add("@SALDO," + saldoRecibo);
		//				parametros.Add("@SALDO_LOCAL," + saldoRecibo);
		//				parametros.Add("@SALDO_CLIENTE," + saldoRecibo);

		//				parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

		//				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
		//			}
		//			#endregion

		//			#region ACTUALIZAR_AUXILIAR_PARC_CC
		//			if (OK && int.Parse(row["NUM_PARCIALIDADES"].ToString()) > 2)//Si tiene parcialidades
		//			{
		//				#region INSERT_AUXILIAR_CC
		//				sQuery.Clear();
		//				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_PARC_CC (TIPO_CREDITO,TIPO_DEBITO,PARCIALIDAD,");
		//				sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
		//				sQuery.AppendLine("MONTO_CLI_DEBITO,TIPO_CAMBIO_APLICA,MONTO_CUOTA,MONTO_CUOTA_LOC,MONTO_CUOTA_DOL,MONTO_AMORTIZA,MONTO_AMORTIZA_LOC,MONTO_AMORTIZA_DOL)");

		//				sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,@PARCIALIDAD,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
		//				sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@MONTO_CLI_DEBITO,@TIPO_CAMBIO_APLICA,@MONTO_CUOTA,@MONTO_CUOTA_LOC,@MONTO_CUOTA_DOL,@MONTO_AMORTIZA,@MONTO_AMORTIZA_LOC,@MONTO_AMORTIZA_DOL)");
		//				#endregion

		//				parametros = new List<string>();

		//				#region PARAMETROS_AUXILIAR_CC

		//				parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
		//				parametros.Add("@CREDITO," + documentoRecibo);
		//				parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());
		//				parametros.Add("@PARCIALIDAD," + row["PARCIALIDAD"].ToString());

		//				parametros.Add("@MONTO_DEBITO," + saldoAplicacion);
		//				parametros.Add("@MONTO_CREDITO," + saldoAplicacion);
		//				parametros.Add("@MONTO_LOCAL," + saldoAplicacion);
		//				parametros.Add("@MONTO_DOLAR," + Math.Round(saldoAplicacion / tipoCambio, 2));
		//				//parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
		//				parametros.Add("@MONTO_CLI_CREDITO," + saldoAplicacion);

		//				parametros.Add("@MONTO_CLI_DEBITO," + saldoAplicacion);
		//				parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
		//				parametros.Add("@MONTO_CUOTA," + saldoAplicacion);
		//				parametros.Add("@MONTO_CUOTA_LOC," + saldoAplicacion);
		//				parametros.Add("@MONTO_CUOTA_DOL," + Math.Round(saldoAplicacion / tipoCambio, 2));
		//				parametros.Add("@MONTO_AMORTIZA," + saldoAplicacion);
		//				parametros.Add("@MONTO_AMORTIZA_LOC," + saldoAplicacion);
		//				parametros.Add("@MONTO_AMORTIZA_DOL," + Math.Round(saldoAplicacion / tipoCambio, 2));
		//				#endregion

		//				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
		//			}
		//			#endregion

		//			#region ACTUALIZAR_AUXILIAR_CC
		//			//if (OK && saldoFactura == 0)
		//			if (OK)
		//			{
		//				if(int.Parse(row["NUM_PARCIALIDADES"].ToString()) < 2)
		//				{
		//					#region INSERT_AUXILIAR_CC
		//					sQuery.Clear();
		//					sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_CC (TIPO_CREDITO,TIPO_DEBITO,");
		//					sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
		//					sQuery.AppendLine("ASIENTO,TIPO_DOCPPAGO,DOCUMENTO_DOCPPAGO,MONTO_CLI_DEBITO,MONEDA_CREDITO,MONEDA_DEBITO,");
		//					sQuery.AppendLine("CLI_REPORTE_CREDIT,CLI_REPORTE_DEBITO,CLI_DOC_CREDIT,CLI_DOC_DEBITO,TIPO_DOCINTCTE,DOC_DOCINTCTE,FOLIOSAT_DEBITO,FOLIOSAT_CREDITO,TIPO_CAMBIO_APLICA)");

		//					sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
		//					sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@ASIENTO,@TIPO_DOCPPAGO,@DOCUMENTO_DOCPPAGO,@MONTO_CLI_DEBITO,'CRC',");
		//					sQuery.AppendLine("'CRC',@CLI_REPORTE_CREDIT,@CLI_REPORTE_DEBITO,@CLI_DOC_CREDIT,@CLI_DOC_DEBITO,@TIPO_DOCINTCTE,@DOC_DOCINTCTE,");
		//					sQuery.AppendLine("@FOLIOSAT_DEBITO,@FOLIOSAT_CREDITO,@TIPO_CAMBIO_APLICA)");
		//					#endregion

		//					parametros = new List<string>();

		//					#region PARAMETROS_AUXILIAR_CC

		//					parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
		//					parametros.Add("@CREDITO," + documentoRecibo);
		//					parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());

		//					parametros.Add("@MONTO_DEBITO," + saldoAplicacion);
		//					parametros.Add("@MONTO_CREDITO," + saldoAplicacion);
		//					parametros.Add("@MONTO_LOCAL," + saldoAplicacion);
		//					parametros.Add("@MONTO_DOLAR," + Math.Round(saldoAplicacion / tipoCambio, 2));
		//					//parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
		//					parametros.Add("@MONTO_CLI_CREDITO," + saldoAplicacion);

		//					parametros.Add("@ASIENTO," + "null");
		//					parametros.Add("@TIPO_DOCPPAGO," + "null");
		//					parametros.Add("@DOCUMENTO_DOCPPAGO," + "null");
		//					parametros.Add("@MONTO_CLI_DEBITO," + saldoAplicacion);
		//					parametros.Add("@CLI_REPORTE_CREDIT," + numColegiado);
		//					parametros.Add("@CLI_REPORTE_DEBITO," + row["CLIENTE"].ToString());
		//					parametros.Add("@CLI_DOC_CREDIT," + numColegiado);
		//					parametros.Add("@CLI_DOC_DEBITO," + row["CLIENTE"].ToString());

		//					parametros.Add("@TIPO_DOCINTCTE," + "null");
		//					parametros.Add("@DOC_DOCINTCTE," + "null");
		//					parametros.Add("@FOLIOSAT_DEBITO," + "null");
		//					parametros.Add("@FOLIOSAT_CREDITO," + "null");
		//					parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
		//					#endregion

		//					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
		//				}
		//			}
		//			#endregion

		//			#region ACTUALIZAR_AUXILIAR_CC PARA FAC CON PARCIALIDAD
		//			//if (OK && saldoFactura == 0)
		//			if (OK && parcMaxPorDoc != 0 && parcMaxPorDoc == int.Parse(row["PARCIALIDAD"].ToString()))
		//			{
						
		//				#region INSERT_AUXILIAR_CC
		//				sQuery.Clear();
		//				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_CC (TIPO_CREDITO,TIPO_DEBITO,");
		//				sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
		//				sQuery.AppendLine("ASIENTO,TIPO_DOCPPAGO,DOCUMENTO_DOCPPAGO,MONTO_CLI_DEBITO,MONEDA_CREDITO,MONEDA_DEBITO,");
		//				sQuery.AppendLine("CLI_REPORTE_CREDIT,CLI_REPORTE_DEBITO,CLI_DOC_CREDIT,CLI_DOC_DEBITO,TIPO_DOCINTCTE,DOC_DOCINTCTE,FOLIOSAT_DEBITO,FOLIOSAT_CREDITO,TIPO_CAMBIO_APLICA)");

		//				sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
		//				sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@ASIENTO,@TIPO_DOCPPAGO,@DOCUMENTO_DOCPPAGO,@MONTO_CLI_DEBITO,'CRC',");
		//				sQuery.AppendLine("'CRC',@CLI_REPORTE_CREDIT,@CLI_REPORTE_DEBITO,@CLI_DOC_CREDIT,@CLI_DOC_DEBITO,@TIPO_DOCINTCTE,@DOC_DOCINTCTE,");
		//				sQuery.AppendLine("@FOLIOSAT_DEBITO,@FOLIOSAT_CREDITO,@TIPO_CAMBIO_APLICA)");
		//				#endregion

		//				parametros = new List<string>();

		//				#region PARAMETROS_AUXILIAR_CC

		//				parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
		//				parametros.Add("@CREDITO," + documentoRecibo);
		//				parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());

		//				parametros.Add("@MONTO_DEBITO," + totalSaldoAplicadoParc);
		//				parametros.Add("@MONTO_CREDITO," + totalSaldoAplicadoParc);
		//				parametros.Add("@MONTO_LOCAL," + totalSaldoAplicadoParc);
		//				parametros.Add("@MONTO_DOLAR," + Math.Round(totalSaldoAplicadoParc / tipoCambio, 2));
		//				//parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
		//				parametros.Add("@MONTO_CLI_CREDITO," + totalSaldoAplicadoParc);

		//				parametros.Add("@ASIENTO," + "null");
		//				parametros.Add("@TIPO_DOCPPAGO," + "null");
		//				parametros.Add("@DOCUMENTO_DOCPPAGO," + "null");
		//				parametros.Add("@MONTO_CLI_DEBITO," + totalSaldoAplicadoParc);
		//				parametros.Add("@CLI_REPORTE_CREDIT," + numColegiado);
		//				parametros.Add("@CLI_REPORTE_DEBITO," + row["CLIENTE"].ToString());
		//				parametros.Add("@CLI_DOC_CREDIT," + numColegiado);
		//				parametros.Add("@CLI_DOC_DEBITO," + row["CLIENTE"].ToString());

		//				parametros.Add("@TIPO_DOCINTCTE," + "null");
		//				parametros.Add("@DOC_DOCINTCTE," + "null");
		//				parametros.Add("@FOLIOSAT_DEBITO," + "null");
		//				parametros.Add("@FOLIOSAT_CREDITO," + "null");
		//				parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
		//				#endregion

		//				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

		//				//docPorParcialidad = string.Empty;
		//				totalSaldoAplicadoParc = 0;
		//				parcMaxPorDoc = 0;
		//			}
		//			#endregion

		//			if (!OK || saldoRecibo == 0)
		//				break;

		//		}
		//	}

		//	montoRecibo = saldoRecibo;

		//	return OK;
		//}

		public static bool cobrosCobrador(DataTable dtDocPorColegiado, string numColegiado, string cobradorColegiado, decimal MontoArchivo, string documentosCarga, DateTime fechaDoc, bool soloRecibo, string subtipoRec, ref decimal montoRecibo, ref string error)
		{

			bool OK = true;
			string moneda = "", condicionPago = "", cobrador = "", nombreCobrador = "", docPorParcialidad = "";
			decimal tipoCambio = 1;
			string documentoRecibo = "";
			string /*subtipoRec = "",*/ actividadComercial = "";
			decimal saldoDocumento = 0, saldoRecibo = 0, saldoDocumentoParcialidad = 0;
			decimal saldoAplicacion = 0, totalSaldoAplicadoParc = 0;
			
			//numColegiado = FuncsInternas.obtenerIdColegiado(numColegiado);


			StringBuilder sQuery = new StringBuilder();
			List<string> parametros = new List<string>();
			DataTable dtDatosCliente = new DataTable();

			#region OBTENER_DATOS_CLIENTE
			sQuery.AppendLine("SELECT MONEDA,CONDICION_PAGO,COBRADOR,");
			sQuery.AppendLine("(select top 1 MONTO from " + Consultas.sqlCon.COMPAÑIA + ".TIPO_CAMBIO_HIST where TIPO_CAMBIO = 'TCOM' and FECHA <=getdate() order by CreateDate desc) TIPO_CAMBIO ");
			sQuery.AppendLine("FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE=@CLIENTE");

			parametros.Add("@CLIENTE," + numColegiado);

			OK = Consultas.fillDataTableParametros(sQuery.ToString(), parametros, ref dtDatosCliente, ref error);

			if (OK)
			{
				cobrador = cobradorColegiado;
				if (dtDatosCliente.Rows.Count > 0)
				{
					moneda = dtDatosCliente.Rows[0]["MONEDA"].ToString();
					//cobrador = dtDatosCliente.Rows[0]["COBRADOR"].ToString();                    
					condicionPago = dtDatosCliente.Rows[0]["CONDICION_PAGO"].ToString();
					tipoCambio = decimal.Parse(dtDatosCliente.Rows[0]["TIPO_CAMBIO"].ToString());
				}
			}
			#endregion


			#region CREAR_RECIBO

			#region INSERT_RECIBO
			sQuery.Clear();
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC (DOCUMENTO,TIPO,APLICACION,");
			sQuery.AppendLine("FECHA_DOCUMENTO,FECHA,MONTO,SALDO,MONTO_LOCAL,SALDO_LOCAL,MONTO_DOLAR,SALDO_DOLAR,MONTO_CLIENTE,");
			sQuery.AppendLine("SALDO_CLIENTE,TIPO_CAMBIO_MONEDA,TIPO_CAMBIO_DOLAR,TIPO_CAMBIO_CLIENT,TIPO_CAMB_ACT_LOC,");
			sQuery.AppendLine("TIPO_CAMB_ACT_DOL,TIPO_CAMB_ACT_CLI,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO1,RUBRO2,MONTO_RETENCION,");
			sQuery.AppendLine("SALDO_RETENCION,DEPENDIENTE,FECHA_ULT_CREDITO,CARGADO_DE_FACT,APROBADO,ASIENTO_PENDIENTE,FECHA_ULT_MOD,");
			sQuery.AppendLine("CLASE_DOCUMENTO,FECHA_VENCE,NUM_PARCIALIDADES,COBRADOR,USUARIO_ULT_MOD,CONDICION_PAGO,VENDEDOR,MONEDA,CLIENTE_REPORTE,CLIENTE_ORIGEN,");
			sQuery.AppendLine("CLIENTE,SUBTIPO,PORC_INTCTE,USUARIO_APROBACION,FECHA_APROBACION,ANULADO,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,SALDO_TRANS_CLI,FACTURADO,GENERA_DOC_FE,TIPO_IMPUESTO1,TIPO_TARIFA1,ACTIVIDAD_COMERCIAL)");

			sQuery.AppendLine("VALUES (@DOCUMENTO,'REC',@APLICACION,@FECHA_DOCUMENTO,CAST(GETDATE() AS DATE),@MONTO,@SALDO,@MONTO_LOCAL,");
			sQuery.AppendLine("@SALDO_LOCAL,@MONTO_DOLAR,@SALDO_DOLAR,@MONTO_CLIENTE,@SALDO_CLIENTE,@TIPO_CAMBIO_MONEDA,");
			sQuery.AppendLine("@TIPO_CAMBIO_DOLAR,@TIPO_CAMBIO_CLIENT,@TIPO_CAMB_ACT_LOC,@TIPO_CAMB_ACT_DOL,@TIPO_CAMB_ACT_CLI,");
			sQuery.AppendLine("@SUBTOTAL,0,0,0,0,0,0,0,'N','1980-01-01','N','S','N','1980-01-01','N',CAST(GETDATE() AS DATE),0,@COBRADOR,'KOLEGIO',");
			sQuery.AppendLine("@CONDICION_PAGO,'ND',@MONEDA,@CLIENTE,@CLIENTE,@CLIENTE,@SUBTIPO,0,'KOLEGIO',CAST(GETDATE() AS DATE),'N',");
			sQuery.AppendLine("@SALDO_TRANS,@SALDO_TRANS_LOCAL,@SALDO_TRANS_DOLAR,@SALDO_TRANS_CLI,'N','N','01','01',@ACTIVIDAD_COMERCIAL)");

			#endregion

			if (OK)
				OK = obtenerConsecutivo("RECIBOS", ref documentoRecibo, ref error);

			//if (OK)
			//	OK = FuncsInternas.obtenerSubtipoRec(cobrador, ref subtipoRec, ref error);

			if (OK)
				OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

			if (OK)
				OK = FuncsInternas.obtenerNombreCobrador(cobrador, ref nombreCobrador, ref error);

			if (OK)
			{
				#region PARAMETROS_RECIBO

				string prefix = Regex.Match(documentoRecibo, "^\\D+").Value;
				string number = Regex.Replace(documentoRecibo, "^\\D+", "");
				int numberMasUno = int.Parse(number) + 1;
				documentoRecibo = prefix + numberMasUno.ToString(new string('0', number.Length));

				parametros = new List<string>();

				parametros.Add("@DOCUMENTO," + documentoRecibo);
				parametros.Add("@APLICACION," + documentosCarga + " /RECIBO /" + nombreCobrador);
				parametros.Add("@MONTO," + MontoArchivo);
				parametros.Add("@SALDO," + MontoArchivo);
				//parametros.Add("@FECHA_DOCUMENTO," + fechaDoc.ToString("yyyy-MM-ddTHH:mm:ss"));
				parametros.Add("@FECHA_DOCUMENTO," + fechaDoc.ToString("yyyy-MM-dd"));
				if (moneda == "CRC")
				{
					parametros.Add("@MONTO_LOCAL," + MontoArchivo);
					parametros.Add("@SALDO_LOCAL," + MontoArchivo);
					parametros.Add("@SALDO_TRANS_LOCAL," + MontoArchivo);
					parametros.Add("@SALDO_TRANS_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));
					parametros.Add("@MONTO_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));
					parametros.Add("@SALDO_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));

					parametros.Add("@TIPO_CAMBIO_MONEDA," + 1);
					parametros.Add("@TIPO_CAMBIO_CLIENT," + 1);
					parametros.Add("@TIPO_CAMB_ACT_LOC," + 1);
					parametros.Add("@TIPO_CAMB_ACT_CLI," + 1);

				}
				else
				{
					parametros.Add("@MONTO_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
					parametros.Add("@SALDO_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
					parametros.Add("@SALDO_TRANS_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
					parametros.Add("@SALDO_TRANS_DOLAR," + MontoArchivo);
					parametros.Add("@MONTO_DOLAR," + MontoArchivo);
					parametros.Add("@SALDO_DOLAR," + MontoArchivo);
					parametros.Add("@TIPO_CAMBIO_MONEDA," + tipoCambio);
					parametros.Add("@TIPO_CAMBIO_CLIENT," + tipoCambio);
					parametros.Add("@TIPO_CAMB_ACT_LOC," + tipoCambio);
					parametros.Add("@TIPO_CAMB_ACT_CLI," + tipoCambio);
				}
				parametros.Add("@MONTO_CLIENTE," + MontoArchivo);
				parametros.Add("@SALDO_CLIENTE," + MontoArchivo);
				parametros.Add("@SUBTOTAL," + MontoArchivo);

				parametros.Add("@SALDO_TRANS," + MontoArchivo);
				parametros.Add("@SALDO_TRANS_CLI," + MontoArchivo);

				parametros.Add("@TIPO_CAMBIO_DOLAR," + tipoCambio);
				parametros.Add("@TIPO_CAMB_ACT_DOL," + tipoCambio);

				parametros.Add("@COBRADOR," + cobrador);
				parametros.Add("@CONDICION_PAGO," + condicionPago);
				if (!moneda.Equals(""))
					parametros.Add("@MONEDA," + moneda);
				else
					parametros.Add("@MONEDA," + "ND");
				parametros.Add("@CLIENTE," + numColegiado);
				parametros.Add("@SUBTIPO," + subtipoRec);
				parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);

				#endregion

				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
			}

			if (OK)
				OK = actualizarConsecutivo("RECIBOS", documentoRecibo, ref error);


			#endregion


			if (OK && !soloRecibo)
			{
				foreach (DataRow row in dtDocPorColegiado.Rows)
				{
					totalSaldoAplicadoParc = 0;
					DataTable dtSaldoRecibo = new DataTable();

					string sSaldo = "select SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where DOCUMENTO = '" + documentoRecibo + "' ";

					OK = Consultas.fillDataTable(sSaldo, ref dtSaldoRecibo, ref error);

					if (OK)
					{
						if (dtSaldoRecibo.Rows.Count > 0)
							saldoRecibo = decimal.Parse(dtSaldoRecibo.Rows[0]["SALDO"].ToString());

						saldoDocumento = decimal.Parse(row["SALDO"].ToString());

						if (!row["PAGOS_PARCIALES"].ToString().Equals("S"))
						{
							if (saldoDocumento == saldoRecibo)//Obtenemos el saldo de aplicacion a la factura-siempre se aplica el saldo menor
							{
								saldoAplicacion = saldoDocumento;
								saldoRecibo = 0;
								saldoDocumento = 0;
							}
							else
							{
								if (saldoDocumento < saldoRecibo)
								{
									saldoAplicacion = saldoDocumento;
									saldoRecibo = saldoRecibo - saldoAplicacion;
									saldoDocumento = 0;
								}
								else
								{
									saldoAplicacion = saldoRecibo;
									saldoRecibo = 0;
									saldoDocumento = saldoDocumento - saldoAplicacion;
								}
							}
						}
					}

					#region FACTURA NORMAL

					if (!row["PAGOS_PARCIALES"].ToString().Equals("S"))
					{

						#region ACRUALIZAR_SALDO_FACTURA

						if (OK)
						{
							sQuery.Clear();
							sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
							sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
							sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
							sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");

							parametros = new List<string>();

							parametros.Add("@DOCUMENTO," + row["DOCUMENTO"].ToString());
							parametros.Add("@SALDO," + saldoDocumento);
							parametros.Add("@SALDO_LOCAL," + saldoDocumento);
							parametros.Add("@SALDO_CLIENTE," + saldoDocumento);
							parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

							OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
						}
						#endregion

						#region ACTUALIZAR_AUXILIAR_CC
						
						if (OK)
						{
								#region INSERT_AUXILIAR_CC
								sQuery.Clear();
								sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_CC (TIPO_CREDITO,TIPO_DEBITO,");
								sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
								sQuery.AppendLine("ASIENTO,TIPO_DOCPPAGO,DOCUMENTO_DOCPPAGO,MONTO_CLI_DEBITO,MONEDA_CREDITO,MONEDA_DEBITO,");
								sQuery.AppendLine("CLI_REPORTE_CREDIT,CLI_REPORTE_DEBITO,CLI_DOC_CREDIT,CLI_DOC_DEBITO,TIPO_DOCINTCTE,DOC_DOCINTCTE,FOLIOSAT_DEBITO,FOLIOSAT_CREDITO,TIPO_CAMBIO_APLICA)");

								sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
								sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@ASIENTO,@TIPO_DOCPPAGO,@DOCUMENTO_DOCPPAGO,@MONTO_CLI_DEBITO,'CRC',");
								sQuery.AppendLine("'CRC',@CLI_REPORTE_CREDIT,@CLI_REPORTE_DEBITO,@CLI_DOC_CREDIT,@CLI_DOC_DEBITO,@TIPO_DOCINTCTE,@DOC_DOCINTCTE,");
								sQuery.AppendLine("@FOLIOSAT_DEBITO,@FOLIOSAT_CREDITO,@TIPO_CAMBIO_APLICA)");
								#endregion

								parametros = new List<string>();

								#region PARAMETROS_AUXILIAR_CC

								parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
								parametros.Add("@CREDITO," + documentoRecibo);
								parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());

								parametros.Add("@MONTO_DEBITO," + saldoAplicacion);
								parametros.Add("@MONTO_CREDITO," + saldoAplicacion);
								parametros.Add("@MONTO_LOCAL," + saldoAplicacion);
								parametros.Add("@MONTO_DOLAR," + Math.Round(saldoAplicacion / tipoCambio, 2));
								//parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
								parametros.Add("@MONTO_CLI_CREDITO," + saldoAplicacion);

								parametros.Add("@ASIENTO," + "null");
								parametros.Add("@TIPO_DOCPPAGO," + "null");
								parametros.Add("@DOCUMENTO_DOCPPAGO," + "null");
								parametros.Add("@MONTO_CLI_DEBITO," + saldoAplicacion);
								parametros.Add("@CLI_REPORTE_CREDIT," + numColegiado);
								parametros.Add("@CLI_REPORTE_DEBITO," + row["CLIENTE"].ToString());
								parametros.Add("@CLI_DOC_CREDIT," + numColegiado);
								parametros.Add("@CLI_DOC_DEBITO," + row["CLIENTE"].ToString());

								parametros.Add("@TIPO_DOCINTCTE," + "null");
								parametros.Add("@DOC_DOCINTCTE," + "null");
								parametros.Add("@FOLIOSAT_DEBITO," + "null");
								parametros.Add("@FOLIOSAT_CREDITO," + "null");
								parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
								#endregion

								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
							
						}

						#endregion
					}

					#endregion

					#region FACTURA CON PARCIALIDAD

					if (row["PAGOS_PARCIALES"].ToString().Equals("S"))
					{
						string queryParc = "select Tipo 'TIPO', Documento 'DOCUMENTO', IdColegiado 'CLIENTE', Monto 'SALDO', FechaDocumento 'FECHA_DOCUMENTO', Parcialidad 'PARCIALIDAD'" +
									" from " + Consultas.sqlCon.COMPAÑIA + ".NV_APLICACIONES_PARC" +
									" where Documento = '" + row["DOCUMENTO"].ToString() + "' and cobrador = '" + cobrador + "'" +
									" order by Parcialidad";

						DataTable dtParc = new DataTable();
						
						OK = Consultas.fillDataTable(queryParc, ref dtParc, ref error);

						if (OK)
						{
							foreach (DataRow rowParc in dtParc.Rows)
							{
								saldoDocumentoParcialidad = decimal.Parse(rowParc["SALDO"].ToString());

								if (saldoDocumentoParcialidad == saldoRecibo)
								{
									saldoAplicacion = saldoDocumentoParcialidad;
									saldoRecibo = 0;
									saldoDocumentoParcialidad = 0;
								}
								else
								{
									if (saldoDocumentoParcialidad < saldoRecibo)
									{
										saldoAplicacion = saldoDocumentoParcialidad;
										saldoRecibo = saldoRecibo - saldoAplicacion;
										saldoDocumentoParcialidad = 0;
									}
									else
									{
										saldoAplicacion = saldoRecibo;
										saldoRecibo = 0;
										saldoDocumentoParcialidad = saldoDocumentoParcialidad - saldoAplicacion;
									}
								}

								#region ACRUALIZAR_SALDO_PARCIALIDAD

								sQuery.Clear();
								sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".PARCIALIDADES_CC ");
								sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
								sQuery.AppendLine("SALDO_DOLAR = @SALDO_DOLAR, SALDO_AMORTIZA = @SALDO_AMORTIZA, SALDO_AMORTIZA_LOC = @SALDO_AMORTIZA_LOC, SALDO_AMORTIZA_DOL = @SALDO_AMORTIZA_DOL");
								sQuery.AppendLine("WHERE DOCUMENTO_ORIGEN = @DOCUMENTO_ORIGEN AND PARCIALIDAD = @PARCIALIDAD");

								parametros = new List<string>();

								parametros.Add("@DOCUMENTO_ORIGEN," + row["DOCUMENTO"].ToString());
								parametros.Add("@PARCIALIDAD," + rowParc["PARCIALIDAD"].ToString());
								parametros.Add("@SALDO," + saldoDocumentoParcialidad);
								parametros.Add("@SALDO_LOCAL," + saldoDocumentoParcialidad);
								parametros.Add("@SALDO_DOLAR," + Math.Round(saldoDocumentoParcialidad / tipoCambio, 2));
								parametros.Add("@SALDO_AMORTIZA," + saldoAplicacion);
								parametros.Add("@SALDO_AMORTIZA_LOC," + saldoAplicacion);
								parametros.Add("@SALDO_AMORTIZA_DOL," + Math.Round(saldoAplicacion / tipoCambio, 2));

								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
								
								#endregion

								#region ACTUALIZAR_AUXILIAR_PARC_CC
								
								#region INSERT_AUXILIAR_CC
								sQuery.Clear();
								sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_PARC_CC (TIPO_CREDITO,TIPO_DEBITO,PARCIALIDAD,");
								sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
								sQuery.AppendLine("MONTO_CLI_DEBITO,TIPO_CAMBIO_APLICA,MONTO_CUOTA,MONTO_CUOTA_LOC,MONTO_CUOTA_DOL,MONTO_AMORTIZA,MONTO_AMORTIZA_LOC,MONTO_AMORTIZA_DOL)");

								sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,@PARCIALIDAD,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
								sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@MONTO_CLI_DEBITO,@TIPO_CAMBIO_APLICA,@MONTO_CUOTA,@MONTO_CUOTA_LOC,@MONTO_CUOTA_DOL,@MONTO_AMORTIZA,@MONTO_AMORTIZA_LOC,@MONTO_AMORTIZA_DOL)");
								#endregion

								parametros = new List<string>();

								#region PARAMETROS_AUXILIAR_CC

								parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
								parametros.Add("@CREDITO," + documentoRecibo);
								parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());
								parametros.Add("@PARCIALIDAD," + rowParc["PARCIALIDAD"].ToString());

								parametros.Add("@MONTO_DEBITO," + saldoAplicacion);
								parametros.Add("@MONTO_CREDITO," + saldoAplicacion);
								parametros.Add("@MONTO_LOCAL," + saldoAplicacion);
								parametros.Add("@MONTO_DOLAR," + Math.Round(saldoAplicacion / tipoCambio, 2));
								//parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
								parametros.Add("@MONTO_CLI_CREDITO," + saldoAplicacion);

								parametros.Add("@MONTO_CLI_DEBITO," + saldoAplicacion);
								parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
								parametros.Add("@MONTO_CUOTA," + saldoAplicacion);
								parametros.Add("@MONTO_CUOTA_LOC," + saldoAplicacion);
								parametros.Add("@MONTO_CUOTA_DOL," + Math.Round(saldoAplicacion / tipoCambio, 2));
								parametros.Add("@MONTO_AMORTIZA," + saldoAplicacion);
								parametros.Add("@MONTO_AMORTIZA_LOC," + saldoAplicacion);
								parametros.Add("@MONTO_AMORTIZA_DOL," + Math.Round(saldoAplicacion / tipoCambio, 2));
								#endregion

								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

								#endregion

								totalSaldoAplicadoParc += saldoAplicacion;
							}
						}

						#region ACRUALIZAR_SALDO_FACTURA

						if (OK)
						{
							var saldo = decimal.Parse(row["SALDO"].ToString());

							sQuery.Clear();
							sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
							sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
							sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
							sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");

							parametros = new List<string>();

							parametros.Add("@DOCUMENTO," + row["DOCUMENTO"].ToString());
							//parametros.Add("@SALDO," + (saldo - saldoAplicacion));
							//parametros.Add("@SALDO_LOCAL," + (saldo - saldoAplicacion));
							//parametros.Add("@SALDO_CLIENTE," + (saldo - saldoAplicacion));
							parametros.Add("@SALDO," + (saldo - totalSaldoAplicadoParc));
							parametros.Add("@SALDO_LOCAL," + (saldo - totalSaldoAplicadoParc));
							parametros.Add("@SALDO_CLIENTE," + (saldo - totalSaldoAplicadoParc));

							parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

							OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
						}
						#endregion

						#region ACTUALIZAR_AUXILIAR_CC PARA FAC CON PARCIALIDAD
					
						if (OK)
						{

							#region INSERT_AUXILIAR_CC
							sQuery.Clear();
							sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_CC (TIPO_CREDITO,TIPO_DEBITO,");
							sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
							sQuery.AppendLine("ASIENTO,TIPO_DOCPPAGO,DOCUMENTO_DOCPPAGO,MONTO_CLI_DEBITO,MONEDA_CREDITO,MONEDA_DEBITO,");
							sQuery.AppendLine("CLI_REPORTE_CREDIT,CLI_REPORTE_DEBITO,CLI_DOC_CREDIT,CLI_DOC_DEBITO,TIPO_DOCINTCTE,DOC_DOCINTCTE,FOLIOSAT_DEBITO,FOLIOSAT_CREDITO,TIPO_CAMBIO_APLICA)");

							sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
							sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@ASIENTO,@TIPO_DOCPPAGO,@DOCUMENTO_DOCPPAGO,@MONTO_CLI_DEBITO,'CRC',");
							sQuery.AppendLine("'CRC',@CLI_REPORTE_CREDIT,@CLI_REPORTE_DEBITO,@CLI_DOC_CREDIT,@CLI_DOC_DEBITO,@TIPO_DOCINTCTE,@DOC_DOCINTCTE,");
							sQuery.AppendLine("@FOLIOSAT_DEBITO,@FOLIOSAT_CREDITO,@TIPO_CAMBIO_APLICA)");
							#endregion

							parametros = new List<string>();

							#region PARAMETROS_AUXILIAR_CC

							parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
							parametros.Add("@CREDITO," + documentoRecibo);
							parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());

							parametros.Add("@MONTO_DEBITO," + totalSaldoAplicadoParc);
							parametros.Add("@MONTO_CREDITO," + totalSaldoAplicadoParc);
							parametros.Add("@MONTO_LOCAL," + totalSaldoAplicadoParc);
							parametros.Add("@MONTO_DOLAR," + Math.Round(totalSaldoAplicadoParc / tipoCambio, 2));
							//parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
							parametros.Add("@MONTO_CLI_CREDITO," + totalSaldoAplicadoParc);

							parametros.Add("@ASIENTO," + "null");
							parametros.Add("@TIPO_DOCPPAGO," + "null");
							parametros.Add("@DOCUMENTO_DOCPPAGO," + "null");
							parametros.Add("@MONTO_CLI_DEBITO," + totalSaldoAplicadoParc);
							parametros.Add("@CLI_REPORTE_CREDIT," + numColegiado);
							parametros.Add("@CLI_REPORTE_DEBITO," + row["CLIENTE"].ToString());
							parametros.Add("@CLI_DOC_CREDIT," + numColegiado);
							parametros.Add("@CLI_DOC_DEBITO," + row["CLIENTE"].ToString());

							parametros.Add("@TIPO_DOCINTCTE," + "null");
							parametros.Add("@DOC_DOCINTCTE," + "null");
							parametros.Add("@FOLIOSAT_DEBITO," + "null");
							parametros.Add("@FOLIOSAT_CREDITO," + "null");
							parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
							#endregion

							OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

						}
						#endregion
					}

					#endregion

					#region ACRUALIZAR_SALDO_RECIBO

					if (OK)
					{
						sQuery.Clear();
						sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
						sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
						sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
						sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");


						parametros = new List<string>();
						parametros.Add("@DOCUMENTO," + documentoRecibo);

						parametros.Add("@SALDO," + saldoRecibo);
						parametros.Add("@SALDO_LOCAL," + saldoRecibo);
						parametros.Add("@SALDO_CLIENTE," + saldoRecibo);

						parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}
					#endregion


					if (!OK || saldoRecibo == 0)
						break;

				}
			}

			montoRecibo = saldoRecibo;

			return OK;
		}

		public static bool cobrosCobradorArregloPago(DataTable dtDocPorColegiado, string numColegiado, string cobradorColegiado, decimal MontoArchivo, ref string error)
		{

			bool OK = true;
			string moneda = "", condicionPago = "", cobrador = "";
			decimal tipoCambio = 1;
			string documentoRecibo = "";
			decimal saldoFactura = 0, saldoRecibo = 0;
			decimal saldoAplicacion = 0;


			StringBuilder sQuery = new StringBuilder();
			List<string> parametros = new List<string>();
			DataTable dtDatosCliente = new DataTable();

			#region OBTENER_DATOS_CLIENTE
			sQuery.AppendLine("SELECT MONEDA,CONDICION_PAGO,COBRADOR,");
			sQuery.AppendLine("(select top 1 MONTO from " + Consultas.sqlCon.COMPAÑIA + ".TIPO_CAMBIO_HIST where TIPO_CAMBIO = 'TCOM' and FECHA <=getdate() order by CreateDate desc) TIPO_CAMBIO ");
			sQuery.AppendLine("FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE=@CLIENTE");

			parametros.Add("@CLIENTE," + numColegiado);

			OK = Consultas.fillDataTableParametros(sQuery.ToString(), parametros, ref dtDatosCliente, ref error);

			if (OK)
			{
				if (dtDatosCliente.Rows.Count > 0)
				{
					moneda = dtDatosCliente.Rows[0]["MONEDA"].ToString();
					//cobrador = dtDatosCliente.Rows[0]["COBRADOR"].ToString();
					cobrador = cobradorColegiado;
					condicionPago = dtDatosCliente.Rows[0]["CONDICION_PAGO"].ToString();
					tipoCambio = decimal.Parse(dtDatosCliente.Rows[0]["TIPO_CAMBIO"].ToString());
				}
			}
			#endregion


			#region CREAR_RECIBO

			#region INSERT_RECIBO
			sQuery.Clear();
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC (DOCUMENTO,TIPO,APLICACION,");
			sQuery.AppendLine("FECHA_DOCUMENTO,FECHA,MONTO,SALDO,MONTO_LOCAL,SALDO_LOCAL,MONTO_DOLAR,SALDO_DOLAR,MONTO_CLIENTE,");
			sQuery.AppendLine("SALDO_CLIENTE,TIPO_CAMBIO_MONEDA,TIPO_CAMBIO_DOLAR,TIPO_CAMBIO_CLIENT,TIPO_CAMB_ACT_LOC,");
			sQuery.AppendLine("TIPO_CAMB_ACT_DOL,TIPO_CAMB_ACT_CLI,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO1,RUBRO2,MONTO_RETENCION,");
			sQuery.AppendLine("SALDO_RETENCION,DEPENDIENTE,FECHA_ULT_CREDITO,CARGADO_DE_FACT,APROBADO,ASIENTO_PENDIENTE,FECHA_ULT_MOD,");
			sQuery.AppendLine("CLASE_DOCUMENTO,FECHA_VENCE,NUM_PARCIALIDADES,COBRADOR,USUARIO_ULT_MOD,CONDICION_PAGO,MONEDA,CLIENTE_REPORTE,CLIENTE_ORIGEN,");
			sQuery.AppendLine("CLIENTE,SUBTIPO,PORC_INTCTE,USUARIO_APROBACION,FECHA_APROBACION,ANULADO,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,SALDO_TRANS_CLI,FACTURADO,GENERA_DOC_FE)");

			sQuery.AppendLine("VALUES (@DOCUMENTO,'REC','Recibo-KOLEGIO',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),@MONTO,@SALDO,@MONTO_LOCAL,");
			sQuery.AppendLine("@SALDO_LOCAL,@MONTO_DOLAR,@SALDO_DOLAR,@MONTO_CLIENTE,@SALDO_CLIENTE,@TIPO_CAMBIO_MONEDA,");
			sQuery.AppendLine("@TIPO_CAMBIO_DOLAR,@TIPO_CAMBIO_CLIENT,@TIPO_CAMB_ACT_LOC,@TIPO_CAMB_ACT_DOL,@TIPO_CAMB_ACT_CLI,");
			sQuery.AppendLine("@SUBTOTAL,0,0,0,0,0,0,0,'N','1980-01-01','N','S','N','1980-01-01','N',CAST(GETDATE() AS DATE),0,@COBRADOR,'KOLEGIO',");
			sQuery.AppendLine("@CONDICION_PAGO,@MONEDA,@CLIENTE,@CLIENTE,@CLIENTE,@SUBTIPO,0,'KOLEGIO',CAST(GETDATE() AS DATE),'N',");
			sQuery.AppendLine("@SALDO_TRANS,@SALDO_TRANS_LOCAL,@SALDO_TRANS_DOLAR,@SALDO_TRANS_CLI,'N','N')");

			#endregion

			if (OK)
				OK = obtenerConsecutivo("RECIBOS", ref documentoRecibo, ref error);

			if (OK)
			{
				#region PARAMETROS_RECIBO

				string prefix = Regex.Match(documentoRecibo, "^\\D+").Value;
				string number = Regex.Replace(documentoRecibo, "^\\D+", "");
				int numberMasUno = int.Parse(number) + 1;
				documentoRecibo = prefix + numberMasUno.ToString(new string('0', number.Length));

				parametros = new List<string>();

				parametros.Add("@DOCUMENTO," + documentoRecibo);
				parametros.Add("@MONTO," + MontoArchivo);
				parametros.Add("@SALDO," + MontoArchivo);
				if (moneda == "CRC")
				{
					parametros.Add("@MONTO_LOCAL," + MontoArchivo);
					parametros.Add("@SALDO_LOCAL," + MontoArchivo);
					parametros.Add("@SALDO_TRANS_LOCAL," + MontoArchivo);
					parametros.Add("@SALDO_TRANS_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));
					parametros.Add("@MONTO_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));
					parametros.Add("@SALDO_DOLAR," + Math.Round(MontoArchivo / tipoCambio, 2));

					parametros.Add("@TIPO_CAMBIO_MONEDA," + 1);
					parametros.Add("@TIPO_CAMBIO_CLIENT," + 1);
					parametros.Add("@TIPO_CAMB_ACT_LOC," + 1);
					parametros.Add("@TIPO_CAMB_ACT_CLI," + 1);

				}
				else
				{
					parametros.Add("@MONTO_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
					parametros.Add("@SALDO_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
					parametros.Add("@SALDO_TRANS_LOCAL," + Math.Round(MontoArchivo * tipoCambio, 2));
					parametros.Add("@SALDO_TRANS_DOLAR," + MontoArchivo);
					parametros.Add("@MONTO_DOLAR," + MontoArchivo);
					parametros.Add("@SALDO_DOLAR," + MontoArchivo);
					parametros.Add("@TIPO_CAMBIO_MONEDA," + tipoCambio);
					parametros.Add("@TIPO_CAMBIO_CLIENT," + tipoCambio);
					parametros.Add("@TIPO_CAMB_ACT_LOC," + tipoCambio);
					parametros.Add("@TIPO_CAMB_ACT_CLI," + tipoCambio);
				}
				parametros.Add("@MONTO_CLIENTE," + MontoArchivo);
				parametros.Add("@SALDO_CLIENTE," + MontoArchivo);
				parametros.Add("@SUBTOTAL," + MontoArchivo);

				parametros.Add("@SALDO_TRANS," + MontoArchivo);
				parametros.Add("@SALDO_TRANS_CLI," + MontoArchivo);

				parametros.Add("@TIPO_CAMBIO_DOLAR," + tipoCambio);
				parametros.Add("@TIPO_CAMB_ACT_DOL," + tipoCambio);

				parametros.Add("@COBRADOR," + cobrador);
				parametros.Add("@CONDICION_PAGO," + condicionPago);
				parametros.Add("@MONEDA," + moneda);
				parametros.Add("@CLIENTE," + numColegiado);
				parametros.Add("@SUBTIPO," + 0);

				#endregion

				OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
			}

			if (OK)
				OK = actualizarConsecutivo("RECIBOS", documentoRecibo, ref error);


			#endregion


			if (OK)
			{
				foreach (DataRow row in dtDocPorColegiado.Rows)
				{
					DataTable dtSaldoRecibo = new DataTable();

					string sSaldo = "select SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC where DOCUMENTO = '" + documentoRecibo + "' ";

					OK = Consultas.fillDataTable(sSaldo, ref dtSaldoRecibo, ref error);

					if (OK)
					{
						if (dtSaldoRecibo.Rows.Count > 0)
							saldoRecibo = decimal.Parse(dtSaldoRecibo.Rows[0]["SALDO"].ToString());

						saldoFactura = decimal.Parse(row["SALDO"].ToString());

						saldoAplicacion = saldoFactura;
						saldoRecibo = 0;
						saldoFactura = 0;

					}



					if (OK && saldoFactura == 0)
					{
						#region INSERT_AUXILIAR_CC
						sQuery.Clear();
						sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".AUXILIAR_CC (TIPO_CREDITO,TIPO_DEBITO,");
						sQuery.AppendLine("FECHA,CREDITO,DEBITO,MONTO_DEBITO,MONTO_CREDITO,MONTO_LOCAL,MONTO_DOLAR,MONTO_CLI_CREDITO,");
						sQuery.AppendLine("ASIENTO,TIPO_DOCPPAGO,DOCUMENTO_DOCPPAGO,MONTO_CLI_DEBITO,MONEDA_CREDITO,MONEDA_DEBITO,");
						sQuery.AppendLine("CLI_REPORTE_CREDIT,CLI_REPORTE_DEBITO,CLI_DOC_CREDIT,CLI_DOC_DEBITO,TIPO_DOCINTCTE,DOC_DOCINTCTE,FOLIOSAT_DEBITO,FOLIOSAT_CREDITO,TIPO_CAMBIO_APLICA)");

						sQuery.AppendLine("VALUES ('REC',@TIPO_DEBITO,CAST(GETDATE() AS DATE),@CREDITO,@DEBITO,@MONTO_DEBITO,@MONTO_CREDITO,@MONTO_LOCAL,");
						sQuery.AppendLine("@MONTO_DOLAR,@MONTO_CLI_CREDITO,@ASIENTO,@TIPO_DOCPPAGO,@DOCUMENTO_DOCPPAGO,@MONTO_CLI_DEBITO,'CRC',");
						sQuery.AppendLine("'CRC',@CLI_REPORTE_CREDIT,@CLI_REPORTE_DEBITO,@CLI_DOC_CREDIT,@CLI_DOC_DEBITO,@TIPO_DOCINTCTE,@DOC_DOCINTCTE,");
						sQuery.AppendLine("@FOLIOSAT_DEBITO,@FOLIOSAT_CREDITO,@TIPO_CAMBIO_APLICA)");
						#endregion

						parametros = new List<string>();

						#region PARAMETROS_AUXILIAR_CC

						parametros.Add("@TIPO_DEBITO," + row["TIPO"].ToString());
						parametros.Add("@CREDITO," + documentoRecibo);
						parametros.Add("@DEBITO," + row["DOCUMENTO"].ToString());

						parametros.Add("@MONTO_DEBITO," + row["MONTO"].ToString());
						parametros.Add("@MONTO_CREDITO," + saldoAplicacion);
						parametros.Add("@MONTO_LOCAL," + row["MONTO"].ToString());
						parametros.Add("@MONTO_DOLAR," + Math.Round(decimal.Parse(row["MONTO"].ToString()) / tipoCambio, 2));
						parametros.Add("@MONTO_CLI_CREDITO," + saldoAplicacion);

						parametros.Add("@ASIENTO," + "null");
						parametros.Add("@TIPO_DOCPPAGO," + "null");
						parametros.Add("@DOCUMENTO_DOCPPAGO," + "null");
						parametros.Add("@MONTO_CLI_DEBITO," + row["MONTO"].ToString());
						parametros.Add("@CLI_REPORTE_CREDIT," + numColegiado);
						parametros.Add("@CLI_REPORTE_DEBITO," + row["CLIENTE"].ToString());
						parametros.Add("@CLI_DOC_CREDIT," + numColegiado);
						parametros.Add("@CLI_DOC_DEBITO," + row["CLIENTE"].ToString());

						parametros.Add("@TIPO_DOCINTCTE," + "null");
						parametros.Add("@DOC_DOCINTCTE," + "null");
						parametros.Add("@FOLIOSAT_DEBITO," + "null");
						parametros.Add("@FOLIOSAT_CREDITO," + "null");
						parametros.Add("@TIPO_CAMBIO_APLICA," + 1);
						#endregion

						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}

					#region ACRUALIZAR_SALDO_ARREGLO

					if (OK)
					{
						sQuery.Clear();
						sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
						sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
						sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
						sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");

						parametros = new List<string>();

						parametros.Add("@DOCUMENTO," + row["DOCUMENTO"].ToString());


						parametros.Add("@SALDO," + saldoFactura);
						parametros.Add("@SALDO_LOCAL," + saldoFactura);
						parametros.Add("@SALDO_CLIENTE," + saldoFactura);


						parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}
					#endregion

					#region ACRUALIZAR_SALDO_RECIBO

					if (OK)
					{
						sQuery.Clear();
						sQuery.AppendLine("UPDATE " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC ");
						sQuery.AppendLine("SET SALDO = @SALDO, SALDO_LOCAL = @SALDO_LOCAL,");
						sQuery.AppendLine("SALDO_CLIENTE = @SALDO_CLIENTE, FECHA_ULT_MOD = @FECHA_ULT_MOD");
						sQuery.AppendLine("WHERE DOCUMENTO = @DOCUMENTO");


						parametros = new List<string>();
						parametros.Add("@DOCUMENTO," + documentoRecibo);

						parametros.Add("@SALDO," + saldoRecibo);
						parametros.Add("@SALDO_LOCAL," + saldoRecibo);
						parametros.Add("@SALDO_CLIENTE," + saldoRecibo);

						parametros.Add("@FECHA_ULT_MOD," + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}
					#endregion

					if (!OK || saldoRecibo == 0)
						break;

				}
			}


			return OK;
		}

		//Este no se esta utilizando
		public static bool crearDocumentosAdelantos(string numColegiado, decimal monto, int meses, decimal descuento, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			bool OK = true;
			string moneda = "", condicionPago = "";
			decimal tipoCambio = 1;
			DataTable dtDatosCliente = new DataTable();

			#region OBTENER_DATOS_CLIENTE
			sQuery.AppendLine("SELECT MONEDA,CONDICION_PAGO,");
			sQuery.AppendLine("(select top 1 MONTO from " + Consultas.sqlCon.COMPAÑIA + ".TIPO_CAMBIO_HIST where TIPO_CAMBIO = 'TCOM' and FECHA <=getdate() order by CreateDate desc) TIPO_CAMBIO ");
			sQuery.AppendLine("FROM " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE WHERE CLIENTE=@CLIENTE");

			List<string> parametros = new List<string>();
			parametros.Add("@CLIENTE," + numColegiado);

			OK = Consultas.fillDataTableParametros(sQuery.ToString(), parametros, ref dtDatosCliente, ref error);

			if (OK)
			{
				if (dtDatosCliente.Rows.Count > 0)
				{
					moneda = dtDatosCliente.Rows[0]["MONEDA"].ToString();
					condicionPago = dtDatosCliente.Rows[0]["CONDICION_PAGO"].ToString();
					tipoCambio = decimal.Parse(dtDatosCliente.Rows[0]["TIPO_CAMBIO"].ToString());
				}
			}

			#endregion

			if (OK)
			{
				#region INSERT
				//sQuery.Clear();
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC (DOCUMENTO,TIPO,APLICACION,");
				sQuery.AppendLine("FECHA_DOCUMENTO,FECHA,MONTO,SALDO,MONTO_LOCAL,SALDO_LOCAL,MONTO_DOLAR,SALDO_DOLAR,MONTO_CLIENTE,");
				sQuery.AppendLine("SALDO_CLIENTE,TIPO_CAMBIO_MONEDA,TIPO_CAMBIO_DOLAR,TIPO_CAMBIO_CLIENT,TIPO_CAMB_ACT_LOC,");
				sQuery.AppendLine("TIPO_CAMB_ACT_DOL,TIPO_CAMB_ACT_CLI,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO1,RUBRO2,MONTO_RETENCION,");
				sQuery.AppendLine("SALDO_RETENCION,DEPENDIENTE,FECHA_ULT_CREDITO,CARGADO_DE_FACT,APROBADO,ASIENTO_PENDIENTE,FECHA_ULT_MOD,");
				sQuery.AppendLine("CLASE_DOCUMENTO,FECHA_VENCE,NUM_PARCIALIDADES,USUARIO_ULT_MOD,CONDICION_PAGO,MONEDA,CLIENTE_REPORTE,CLIENTE_ORIGEN,");
				sQuery.AppendLine("CLIENTE,PORC_INTCTE,ANULADO,SALDO_TRANS,SALDO_TRANS_LOCAL,SALDO_TRANS_DOLAR,SALDO_TRANS_CLI,FACTURADO,GENERA_DOC_FE)");

				sQuery.AppendLine("VALUES (@DOCUMENTO,'O/C','Cobro Generado desde KOLEGIO (Adelantos)',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),@MONTO,@SALDO,@MONTO_LOCAL,");
				sQuery.AppendLine("@SALDO_LOCAL,@MONTO_DOLAR,@SALDO_DOLAR,@MONTO_CLIENTE,@SALDO_CLIENTE,@TIPO_CAMBIO_MONEDA,");
				sQuery.AppendLine("@TIPO_CAMBIO_DOLAR,@TIPO_CAMBIO_CLIENT,@TIPO_CAMB_ACT_LOC,@TIPO_CAMB_ACT_DOL,@TIPO_CAMB_ACT_CLI,");
				sQuery.AppendLine("@SUBTOTAL,@DESCUENTO,0,0,0,0,0,0,'N','1980-01-01','N','S','N','1980-01-01','N',CAST(GETDATE() AS DATE),0,'" + Consultas.sqlCon.USUARIO + "',");
				sQuery.AppendLine("@CONDICION_PAGO,@MONEDA,@CLIENTE,@CLIENTE,@CLIENTE,0,'N',");
				sQuery.AppendLine("@SALDO_TRANS,@SALDO_TRANS_LOCAL,@SALDO_TRANS_DOLAR,@SALDO_TRANS_CLI,'N','N')");

				#endregion

				string documento = "";


				for (int i = 0; i < meses; i++)
				{
					parametros = new List<string>();

					OK = obtenerConsecutivo("ADELANTOS", ref documento, ref error);

					if (OK)
					{
						string prefix = Regex.Match(documento, "^\\D+").Value;
						string number = Regex.Replace(documento, "^\\D+", "");
						int numberMasUno = int.Parse(number) + 1;
						documento = prefix + numberMasUno.ToString(new string('0', number.Length));

						#region PARAMETROS

						parametros.Add("@DOCUMENTO," + documento);
						parametros.Add("@MONTO," + monto);
						parametros.Add("@SALDO," + monto);
						if (moneda == "CRC")
						{
							parametros.Add("@MONTO_LOCAL," + monto);
							parametros.Add("@SALDO_LOCAL," + monto);
							parametros.Add("@SALDO_TRANS_LOCAL," + monto);
							parametros.Add("@SALDO_TRANS_DOLAR," + Math.Round(monto / tipoCambio, 2));
							parametros.Add("@MONTO_DOLAR," + Math.Round(monto / tipoCambio, 2));
							parametros.Add("@SALDO_DOLAR," + Math.Round(monto / tipoCambio, 2));

							parametros.Add("@TIPO_CAMBIO_MONEDA," + 1);
							parametros.Add("@TIPO_CAMBIO_CLIENT," + 1);
							parametros.Add("@TIPO_CAMB_ACT_LOC," + 1);
							parametros.Add("@TIPO_CAMB_ACT_CLI," + 1);

						}
						else
						{
							parametros.Add("@MONTO_LOCAL," + Math.Round(monto * tipoCambio, 2));
							parametros.Add("@SALDO_LOCAL," + Math.Round(monto * tipoCambio, 2));
							parametros.Add("@SALDO_TRANS_LOCAL," + Math.Round(monto * tipoCambio, 2));
							parametros.Add("@SALDO_TRANS_DOLAR," + monto);
							parametros.Add("@MONTO_DOLAR," + monto);
							parametros.Add("@SALDO_DOLAR," + monto);
							parametros.Add("@TIPO_CAMBIO_MONEDA," + tipoCambio);
							parametros.Add("@TIPO_CAMBIO_CLIENT," + tipoCambio);
							parametros.Add("@TIPO_CAMB_ACT_LOC," + tipoCambio);
							parametros.Add("@TIPO_CAMB_ACT_CLI," + tipoCambio);
						}
						parametros.Add("@MONTO_CLIENTE," + monto);
						parametros.Add("@SALDO_CLIENTE," + monto);
						parametros.Add("@SUBTOTAL," + monto);
						parametros.Add("@DESCUENTO," + descuento);
						parametros.Add("@SALDO_TRANS," + monto);
						parametros.Add("@SALDO_TRANS_CLI," + monto);



						parametros.Add("@TIPO_CAMBIO_DOLAR," + tipoCambio);
						parametros.Add("@TIPO_CAMB_ACT_DOL," + tipoCambio);

						parametros.Add("@CONDICION_PAGO," + condicionPago);
						parametros.Add("@MONEDA," + moneda);
						parametros.Add("@CLIENTE," + numColegiado);

						#endregion

						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}

					if (OK)
						OK = actualizarConsecutivo("ADELANTOS", documento, ref error);

					if (!OK)
						break;
				}
			}
			return OK;
		}

		public static bool crearPedidoRegencia(DataTable dtArticulos, string NumColegiado, string codEstable, string codCategoria, string categoria, int cantidad, decimal montoDescuento, decimal porcDescuento, string cobradorRegente, string identificador, string ultimoCobro, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			DataTable dtCliente = new DataTable();
			bool OK = true;
			int cantidadLineas = 0;
			decimal total = 0;
			string encabezadoAdelantoPedido = "", actividadComercial = "", versionnivel = "";
			List<string> parametros = new List<string>();
			try
			{
				#region INSERT
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO (PEDIDO,ESTADO,FECHA_PEDIDO,FECHA_PROMETIDA,FECHA_PROX_EMBARQU,");
				sQuery.AppendLine("FECHA_ULT_EMBARQUE,FECHA_ULT_CANCELAC,FECHA_ORDEN,TARJETA_CREDITO,EMBARCAR_A,DIREC_EMBARQUE,DIRECCION_FACTURA,");
				sQuery.AppendLine("OBSERVACIONES,COMENTARIO_CXC,TOTAL_MERCADERIA,MONTO_ANTICIPO,MONTO_FLETE,MONTO_SEGURO,MONTO_DOCUMENTACIO,");
				sQuery.AppendLine("TIPO_DESCUENTO1,TIPO_DESCUENTO2,MONTO_DESCUENTO1,MONTO_DESCUENTO2,PORC_DESCUENTO1,PORC_DESCUENTO2,");
				sQuery.AppendLine("TOTAL_IMPUESTO1,TOTAL_IMPUESTO2,TOTAL_A_FACTURAR,PORC_COMI_VENDEDOR,PORC_COMI_COBRADOR,TOTAL_CANCELADO,");
				sQuery.AppendLine("TOTAL_UNIDADES,IMPRESO,FECHA_HORA,DESCUENTO_VOLUMEN,TIPO_PEDIDO,MONEDA_PEDIDO,VERSION_NP,AUTORIZADO,");
				sQuery.AppendLine("DOC_A_GENERAR,CLASE_PEDIDO,MONEDA,NIVEL_PRECIO,COBRADOR,RUTA,USUARIO,CONDICION_PAGO,BODEGA,ZONA,VENDEDOR,CLIENTE,");
				sQuery.AppendLine("CLIENTE_DIRECCION,CLIENTE_CORPORAC,CLIENTE_ORIGEN,PAIS,SUBTIPO_DOC_CXC,TIPO_DOC_CXC,BACKORDER,PORC_INTCTE,");
				sQuery.AppendLine("DESCUENTO_CASCADA,FIJAR_TIPO_CAMBIO,ORIGEN_PEDIDO,NOMBRE_CLIENTE,FECHA_PROYECTADA,TIPO_DOCUMENTO,ACTIVIDAD_COMERCIAL,U_ESTABLE_KOL,U_CATEG_KOL)");
				sQuery.AppendLine("VALUES (@PEDIDO,'N',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),");
				sQuery.AppendLine("'19800101',CAST(GETDATE() AS DATE),'',@CLIENTE,'ND',@DIRECCION_FACTURA,@OBSERVACIONES,@COMENTARIO_CXC,0,0,0,0,0,");
				sQuery.AppendLine("'P','P',0,0,0,0,0,0,0,0,0,0,0,'N',GETDATE(),0,'N',@MONEDA_NIVEL,@VERSION_NP,'N',");
				sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,@BODEGA,'ND','REG',@CLIENTE,");
				sQuery.AppendLine("@CLIENTE,@CLIENTE,@CLIENTE,@PAIS,0,'FAC','N',0,");
				//sQuery.AppendLine("'N','N','F',@NOMBRE_CLIENTE,CAST(GETDATE() AS DATE),'P',@ACTIVIDAD_COMERCIAL)");
				sQuery.AppendLine("'N','N','F',@NOMBRE_CLIENTE,CAST(GETDATE() AS DATE),'P',@ACTIVIDAD_COMERCIAL,@U_ESTABLE_KOL,@U_CATEG_KOL)");
				#endregion

				string pedido = "";
				string condicionPago = "";

				if (identificador == "cobro")
					OK = obtenerCondicionPago("R", ref condicionPago, ref error);
				else
					OK = obtenerCondicionPago("ADEL", ref condicionPago, ref error);

				if (OK)
					OK = obtenerConsecutivo("PEDIDOS", ref pedido, ref error);

				if (OK)
					OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

				if (OK)
					OK = FuncsInternas.obtenerVersionNivelPrecio(ref versionnivel, ref error);

				if (OK)
				{
					string prefix = Regex.Match(pedido, "^\\D+").Value;
					string number = Regex.Replace(pedido, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					pedido = prefix + numberMasUno.ToString(new string('0', number.Length));
				}

				if (OK)
					OK = obtenerInfoCliente(ref dtCliente, NumColegiado, ref error);

				if (OK)
				{
					if (dtCliente.Rows.Count > 0)
					{
						#region PARAMETROS

						parametros.Add("@PEDIDO," + pedido);
						parametros.Add("@CLIENTE," + dtCliente.Rows[0]["CLIENTE"].ToString());
						parametros.Add("@NIVEL_PRECIO," + dtCliente.Rows[0]["NIVEL_PRECIO"].ToString());
						//parametros.Add("@COBRADOR," + dtCliente.Rows[0]["COBRADOR"].ToString());
						if (!cobradorRegente.Equals(""))
							parametros.Add("@COBRADOR," + cobradorRegente);
						else
							parametros.Add("@COBRADOR," + "ND");
						parametros.Add("@NOMBRE_CLIENTE," + dtCliente.Rows[0]["NOMBRE"].ToString());
						parametros.Add("@PAIS," + dtCliente.Rows[0]["PAIS"].ToString());
						parametros.Add("@CONDICION_PAGO," + condicionPago);
						if (!dtCliente.Rows[0]["DIRECCION"].ToString().Equals(""))
							parametros.Add("@DIRECCION_FACTURA," + dtCliente.Rows[0]["DIRECCION"].ToString());
						else
							parametros.Add("@DIRECCION_FACTURA,ND");

						if (identificador == "cobro")
						{
							string comentario = codEstable + "-" + categoria + "-" + DateTime.Parse(ultimoCobro).ToString("MMMM yyyy").ToUpper();

							if (comentario.Length > 40)//comentariocxc no permite mayor a 40
								comentario = comentario.Substring(0, 39);

							parametros.Add("@OBSERVACIONES," + codEstable + "-" + categoria + "-" + DateTime.Parse(ultimoCobro).ToString("MMMM yyyy").ToUpper());
							parametros.Add("@COMENTARIO_CXC," + "" + comentario + "");
						}
						else
						{
							parametros.Add("@OBSERVACIONES," + "Adelanto Regencia-KOLEGIO ");//Estos se cambian en la actualizacion abajo para verificar la cantidad de caracteres
							parametros.Add("@COMENTARIO_CXC," + "Adelanto Regencia-KOLEGIO ");
						}
						parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
						parametros.Add("@MONEDA_NIVEL," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
						parametros.Add("@MONEDA," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
						parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);
						parametros.Add("@VERSION_NP," + versionnivel);
						parametros.Add("@U_ESTABLE_KOL," + codEstable);
						parametros.Add("@U_CATEG_KOL," + codCategoria);
						#endregion
						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}
					else
					{
						OK = false;
						error = "El colegiado no existe como cliente en el ERP.";
					}
				}

				if (OK)
				{
					DataTable dtImpuesto = new DataTable();
					if (dtArticulos.Rows.Count > 0)
					{
						sQuery.Clear();
						sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO_LINEA(PEDIDO,PEDIDO_LINEA,");
						//sQuery.AppendLine("BODEGA,LOTE,LOCALIZACION,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("BODEGA,LOTE,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("CANTIDAD_PEDIDA,CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,CANTIDAD_RESERVADA,CANTIDAD_BONIFICAD,");
						sQuery.AppendLine("CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,TIPO_IMPUESTO1,TIPO_TARIFA1,PORC_EXONERACION,MONTO_EXONERACION,PORC_IMPUESTO1,PORC_IMPUESTO2,DESCRIPCION,COMENTARIO,");
						sQuery.AppendLine("FECHA_PROMETIDA)");

						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("@LINEA_USUARIO,@PRECIO,@CANTIDAD,@CANTIDAD,0,0,0,0,'P',0,0,@TIPO_IMPUESTO1,@TIPO_TARIFA1,0,0,@PORC_IMPUESTO1,@PORC_IMPUESTO2,@DESCRIPCION,@COMENTARIO,CAST(GETDATE() AS DATE))");
						int linea = 1;
						//int contador = 0;
						foreach (DataRow row in dtArticulos.Rows)
						{

							parametros.Clear();
							parametros.Add("@PEDIDO," + pedido);
							parametros.Add("@PEDIDO_LINEA," + linea);
							parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
							parametros.Add("@LOTE,ND");
							//parametros.Add("@LOCALIZACION,GEN");
							//parametros.Add("@ARTICULO," + row["CodigoArticulo"].ToString());
							parametros.Add("@LINEA_USUARIO," + (linea - 1));
							//parametros.Add("@PRECIO," + row["Monto"].ToString());
							parametros.Add("@CANTIDAD," + cantidad);
							//parametros.Add("@CANTIDAD," + 1);
							//parametros.Add("@DESCRIPCION," + "Cobro Regencia");
							//parametros.Add("@COMENTARIO," + "Del establecimiento: " + row["nombreEstablecimiento"].ToString() + "");
							//parametros.Add("@COMENTARIO,ND");
							if (identificador == "cobro")
							{
								OK = obtenerImpuestoArticulo(ref dtImpuesto, row["CodigoArticulo"].ToString(), ref error);

								parametros.Add("@ARTICULO," + row["CodigoArticulo"].ToString());
								parametros.Add("@PRECIO," + row["Monto"].ToString());
								parametros.Add("@DESCRIPCION," + row["descripcion"].ToString());
								parametros.Add("@COMENTARIO, Regencia-KOLEGIO");
							}
							else
							{
								OK = obtenerImpuestoArticulo(ref dtImpuesto, row["CODIGO"].ToString(), ref error);

								parametros.Add("@ARTICULO," + row["CODIGO"].ToString());
								parametros.Add("@PRECIO," + row["PRECIO"].ToString());
								parametros.Add("@DESCRIPCION," + row["DESCRIPCION"].ToString());
								parametros.Add("@COMENTARIO, Adelanto Regencia-KOLEGIO ");

							}

							if (OK)
							{
								parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
								parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());
								parametros.Add("@PORC_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
								parametros.Add("@PORC_IMPUESTO2," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
							}

							if (OK)
							{
								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

								linea += 1;
								cantidadLineas = linea - 1;
								if (identificador == "cobro")
									total += decimal.Parse(row["Monto"].ToString());
								else
									total += decimal.Parse(row["PRECIO"].ToString());
							}


							//total += decimal.Parse(row["Monto"].ToString());
							if (!OK)
								break;
						}
						//total = (total * cantidad) - montoDescuento;
						total = total * cantidad;
					}
					else
					{
						OK = false;
						error = "El colegiado no tiene artículos definidos para el cobro.";
					}
				}

				if (OK)
				{
					if (identificador != "cobro")
					{
						encabezadoAdelantoPedido += codEstable + "-" + categoria + " HASTA " + DateTime.Parse(ultimoCobro).AddMonths(cantidad).ToString("MMMM yyyy").ToUpper();
						OK = actualizarPedido(cantidadLineas, pedido, total, montoDescuento, porcDescuento, encabezadoAdelantoPedido, ref error);
					}
					else
						OK = actualizarPedido(cantidadLineas, pedido, total, montoDescuento, porcDescuento, ref error);
				}

				if (OK)
				{
					OK = actualizarConsecutivo("PEDIDOS", pedido, ref error);
				}

			}

			catch (Exception ex)
			{
				OK = false;
				error = ex.Message;
			}

			return OK;
		}

		public static bool crearPedido(DataTable dtArticulos, string NumColegiado, int cantidad, decimal montoDescuento, decimal porcDescuento, string identificador, bool pedidoPorConcepto, int indiceArt, string cobradorColegiado, string ultimoCobro, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			DataTable dtCliente = new DataTable();
			bool OK = true;
			int cantidadLineas = 0;
			decimal total = 0;
			string encabezado = "", actividadComercial = "", versionnivel = "";
			string condicion = "";
			List<string> parametros = new List<string>();
			try
			{
				#region INSERT
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO (PEDIDO,ESTADO,FECHA_PEDIDO,FECHA_PROMETIDA,FECHA_PROX_EMBARQU,");
				sQuery.AppendLine("FECHA_ULT_EMBARQUE,FECHA_ULT_CANCELAC,FECHA_ORDEN,TARJETA_CREDITO,EMBARCAR_A,DIREC_EMBARQUE,DIRECCION_FACTURA,");
				sQuery.AppendLine("OBSERVACIONES,COMENTARIO_CXC,TOTAL_MERCADERIA,MONTO_ANTICIPO,MONTO_FLETE,MONTO_SEGURO,MONTO_DOCUMENTACIO,");
				sQuery.AppendLine("TIPO_DESCUENTO1,TIPO_DESCUENTO2,MONTO_DESCUENTO1,MONTO_DESCUENTO2,PORC_DESCUENTO1,PORC_DESCUENTO2,");
				sQuery.AppendLine("TOTAL_IMPUESTO1,TOTAL_IMPUESTO2,TOTAL_A_FACTURAR,PORC_COMI_VENDEDOR,PORC_COMI_COBRADOR,TOTAL_CANCELADO,");
				sQuery.AppendLine("TOTAL_UNIDADES,IMPRESO,FECHA_HORA,DESCUENTO_VOLUMEN,TIPO_PEDIDO,MONEDA_PEDIDO,VERSION_NP,AUTORIZADO,");
				sQuery.AppendLine("DOC_A_GENERAR,CLASE_PEDIDO,MONEDA,NIVEL_PRECIO,COBRADOR,RUTA,USUARIO,CONDICION_PAGO,BODEGA,ZONA,VENDEDOR,CLIENTE,");
				sQuery.AppendLine("CLIENTE_DIRECCION,CLIENTE_CORPORAC,CLIENTE_ORIGEN,PAIS,SUBTIPO_DOC_CXC,TIPO_DOC_CXC,BACKORDER,PORC_INTCTE,");
				sQuery.AppendLine("DESCUENTO_CASCADA,FIJAR_TIPO_CAMBIO,ORIGEN_PEDIDO,NOMBRE_CLIENTE,FECHA_PROYECTADA,TIPO_DOCUMENTO,ACTIVIDAD_COMERCIAL)");
				sQuery.AppendLine("VALUES (@PEDIDO,'N',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),");
				sQuery.AppendLine("'19800101',CAST(GETDATE() AS DATE),'',@CLIENTE,'ND',@DIRECCION_FACTURA,@OBSERVACIONES,@COMENTARIO_CXC,0,0,0,0,0,");
				sQuery.AppendLine("'P','P',0,0,0,0,0,0,0,0,0,0,0,'N',GETDATE(),0,'N',@MONEDA_NIVEL,1,'N',");
				sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,@BODEGA,'ND','COL',@CLIENTE,");
				//sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,(SELECT BODEGA_DEFAULT FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),'ND','COL',@CLIENTE,");
				sQuery.AppendLine("@CLIENTE,@CLIENTE,@CLIENTE,@PAIS,0,'FAC','N',0,");
				sQuery.AppendLine("'N','N','F',@NOMBRE_CLIENTE,CAST(GETDATE() AS DATE),'P',@ACTIVIDAD_COMERCIAL)");
				#endregion

				string pedido = "";
				string condicionPago = "";

				if (identificador == "cobro")
					OK = obtenerCondicionPago("C", ref condicionPago, ref error);
				else
					OK = obtenerCondicionPago("ADEL", ref condicionPago, ref error);

				if (OK)
					OK = obtenerConsecutivo("PEDIDOS", ref pedido, ref error);

				if (OK)
					OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

				if (OK)
					OK = FuncsInternas.obtenerVersionNivelPrecio(ref versionnivel, ref error);

				if (OK)
				{
					string prefix = Regex.Match(pedido, "^\\D+").Value;
					string number = Regex.Replace(pedido, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					pedido = prefix + numberMasUno.ToString(new string('0', number.Length));
				}

				if (OK)
					OK = obtenerInfoCliente(ref dtCliente, NumColegiado, ref error);

				if (OK && dtCliente.Rows.Count > 0)
				{
					#region PARAMETROS

					parametros.Add("@PEDIDO," + pedido);
					parametros.Add("@CLIENTE," + dtCliente.Rows[0]["CLIENTE"].ToString());
					parametros.Add("@NIVEL_PRECIO," + dtCliente.Rows[0]["NIVEL_PRECIO"].ToString());
					if (!cobradorColegiado.Equals(""))
						parametros.Add("@COBRADOR," + cobradorColegiado);
					else
						parametros.Add("@COBRADOR," + "ND");
					parametros.Add("@NOMBRE_CLIENTE," + dtCliente.Rows[0]["NOMBRE"].ToString());
					parametros.Add("@PAIS," + dtCliente.Rows[0]["PAIS"].ToString());

					//if (identificador == "cobro")
					//    parametros.Add("@CONDICION_PAGO," + dtCliente.Rows[0]["CONDICION_PAGO"].ToString());
					//else
					//    parametros.Add("@CONDICION_PAGO," + "0");//Si es adelanto la condicion es de contado
					parametros.Add("@CONDICION_PAGO," + condicionPago);
					if (!dtCliente.Rows[0]["DIRECCION"].ToString().Equals(""))
						parametros.Add("@DIRECCION_FACTURA," + dtCliente.Rows[0]["DIRECCION"].ToString());
					else
						parametros.Add("@DIRECCION_FACTURA,ND");
					// if (referenciaCobro == "regencia") { 
					//   parametros.Add("@OBSERVACIONES," + "Cobro de Regencia");
					//}
					//else { 
					//   if (referenciaCobro == "colegiatura")
					//      parametros.Add("@OBSERVACIONES," + "Cobro de Colegiatura");
					// else
					//   parametros.Add("@OBSERVACIONES," + "ND");
					// }
					if (identificador == "cobro")
					{
						encabezado = "COLEGIATURA " + DateTime.Parse(ultimoCobro).ToString("MMMM yyyy").ToUpper() + "";
						parametros.Add("@OBSERVACIONES," + "" + encabezado + "");
						parametros.Add("@COMENTARIO_CXC," + "" + encabezado + "");
					}
					else
					{

						encabezado = "COLEGIATURA HASTA " + DateTime.Parse(ultimoCobro).AddMonths(cantidad).ToString("MMMM yyyy").ToUpper() + "";
						parametros.Add("@OBSERVACIONES," + "Adelanto Colegiatura-KOLEGIO");
						parametros.Add("@COMENTARIO_CXC," + "Adelanto Colegiatura-KOLEGIO");
						//parametros.Add("@OBSERVACIONES," + "Adelanto Colegiatura-KOLEGIO - " + ultimoCobro + "");
						//parametros.Add("@COMENTARIO_CXC," + "Adelanto Colegiatura-KOLEGIO - " + ultimoCobro + "");

					}
					parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
					parametros.Add("@MONEDA_NIVEL," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
					parametros.Add("@MONEDA," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
					parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);
					parametros.Add("@VERSION_NP," + versionnivel);
					#endregion
					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}
				else
				{
					OK = false;
					error = "El colegiado no existe como cliente en el ERP.";
				}

				if (OK)
				{
					DataTable dtImpuesto = new DataTable();

					if (dtArticulos.Rows.Count > 0)
					{
						sQuery.Clear();
						sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO_LINEA(PEDIDO,PEDIDO_LINEA,");
						//sQuery.AppendLine("BODEGA,LOTE,LOCALIZACION,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("BODEGA,LOTE,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("CANTIDAD_PEDIDA,CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,CANTIDAD_RESERVADA,CANTIDAD_BONIFICAD,");
						sQuery.AppendLine("CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,TIPO_IMPUESTO1,TIPO_TARIFA1,PORC_IMPUESTO1,PORC_IMPUESTO2,DESCRIPCION,COMENTARIO,");
						sQuery.AppendLine("FECHA_PROMETIDA)");
						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,(SELECT BODEGA_DEFAULT FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("@LINEA_USUARIO,@PRECIO,@CANTIDAD,@CANTIDAD,0,0,0,0,'P',0,0,@TIPO_IMPUESTO1,@TIPO_TARIFA1,@PORC_IMPUESTO1,0,@DESCRIPCION,@COMENTARIO,CAST(GETDATE() AS DATE))");
						int linea = 1;

						if (!pedidoPorConcepto)
						{
							foreach (DataRow row in dtArticulos.Rows)
							{



								parametros.Clear();
								parametros.Add("@PEDIDO," + pedido);
								parametros.Add("@PEDIDO_LINEA," + linea);
								parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
								parametros.Add("@LOTE,ND");
								//parametros.Add("@LOCALIZACION,GEN");
								//parametros.Add("@ARTICULO," + row["CodigoArticulo"].ToString()); 
								parametros.Add("@LINEA_USUARIO," + (linea - 1));
								//parametros.Add("@PRECIO," + row["Monto"].ToString());
								parametros.Add("@CANTIDAD," + cantidad);

								//parametros.Add("@CANTIDAD," + 1);
								//if (referenciaCobro == "regencia")
								//{
								//    parametros.Add("@DESCRIPCION," + "Cobro Regencia");
								//    parametros.Add("@COMENTARIO," + "Del establecimiento: " + row["nombreEstablecimiento"].ToString() + "");
								//}
								//else
								//{
								//    if (referenciaCobro == "colegiatura") { 
								//parametros.Add("@DESCRIPCION," + "Cobro Colegiatura");
								//parametros.Add("@COMENTARIO," + "De la condicion: " + row["NombreCondicion"].ToString() + "");
								//    }
								//    else { 
								//        parametros.Add("@DESCRIPCION," + "ND");
								//        parametros.Add("@COMENTARIO," + "ND");
								//    }
								//}
								if (identificador == "cobro")
								{
									OK = obtenerImpuestoArticulo(ref dtImpuesto, row["CodigoArticulo"].ToString(), ref error);

									parametros.Add("@ARTICULO," + row["CodigoArticulo"].ToString());
									parametros.Add("@PRECIO," + row["Monto"].ToString());
									parametros.Add("@DESCRIPCION," + row["descripcion"].ToString());
									parametros.Add("@COMENTARIO," + "Condicion: " + row["NombreCondicion"].ToString() + "");
									condicion = "" + row["NombreCondicion"].ToString() + "";
								}
								else
								{
									OK = obtenerImpuestoArticulo(ref dtImpuesto, row["CODIGO"].ToString(), ref error);

									parametros.Add("@ARTICULO," + row["CODIGO"].ToString());
									parametros.Add("@PRECIO," + row["PRECIO"].ToString());
									parametros.Add("@DESCRIPCION," + row["DESCRIPCION"].ToString());
									parametros.Add("@COMENTARIO," + "Adelanto Colegiatura-KOLEGIO");
								}

								if (OK)
								{
									parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
									parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());
									parametros.Add("@PORC_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
								}

								if (OK)
								{
									OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

									linea += 1;
									cantidadLineas = linea - 1;
									if (identificador == "cobro")
										total += decimal.Parse(row["Monto"].ToString());
									else
										total += decimal.Parse(row["PRECIO"].ToString());
								}


								if (!OK)
									break;
							}
						}
						else
						{



							parametros.Clear();
							parametros.Add("@PEDIDO," + pedido);
							parametros.Add("@PEDIDO_LINEA," + linea);
							parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
							parametros.Add("@LOTE,ND");
							//parametros.Add("@LOCALIZACION,GEN");
							parametros.Add("@LINEA_USUARIO," + (linea - 1));
							parametros.Add("@CANTIDAD," + cantidad);


							if (identificador == "cobro")
							{
								OK = obtenerImpuestoArticulo(ref dtImpuesto, dtArticulos.Rows[indiceArt]["CodigoArticulo"].ToString(), ref error);

								parametros.Add("@ARTICULO," + dtArticulos.Rows[indiceArt]["CodigoArticulo"].ToString());
								parametros.Add("@PRECIO," + dtArticulos.Rows[indiceArt]["Monto"].ToString());
								parametros.Add("@DESCRIPCION," + dtArticulos.Rows[indiceArt]["descripcion"].ToString());
								parametros.Add("@COMENTARIO," + "De la condicion: " + dtArticulos.Rows[indiceArt]["NombreCondicion"].ToString() + "");
								condicion = "" + dtArticulos.Rows[indiceArt]["NombreCondicion"].ToString() + "";
							}
							else
							{
								OK = obtenerImpuestoArticulo(ref dtImpuesto, dtArticulos.Rows[indiceArt]["CODIGO"].ToString(), ref error);

								parametros.Add("@ARTICULO," + dtArticulos.Rows[indiceArt]["CODIGO"].ToString());
								parametros.Add("@PRECIO," + dtArticulos.Rows[indiceArt]["PRECIO"].ToString());
								parametros.Add("@DESCRIPCION," + dtArticulos.Rows[indiceArt]["DESCRIPCION"].ToString());
								parametros.Add("@COMENTARIO," + "Adelanto Colegiatura-KOLEGIO");
							}

							if (OK)
							{
								parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
								parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());
								parametros.Add("@PORC_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
							}

							if (OK)
							{
								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

								linea += 1;
								cantidadLineas = linea - 1;
								if (identificador == "cobro")
									total += decimal.Parse(dtArticulos.Rows[indiceArt]["Monto"].ToString());
								else
									total += decimal.Parse(dtArticulos.Rows[indiceArt]["PRECIO"].ToString());
							}


						}

						//total = (total * cantidad) - montoDescuento;
						total = (total * cantidad);
					}
					else
					{
						OK = false;
						error = "El colegiado no tiene artículos definidos para el cobro.";
					}
				}

				if (OK)
				{
					if (identificador == "cobro")
						encabezado += " " + condicion.ToUpper() + "";
					OK = actualizarPedido(cantidadLineas, pedido, total, montoDescuento, porcDescuento, encabezado, ref error);
				}

				if (OK)
				{
					OK = actualizarConsecutivo("PEDIDOS", pedido, ref error);
				}


			}

			catch (Exception ex)
			{
				OK = false;
				error = ex.Message;
			}

			return OK;
		}

		public static bool crearPedidoCambioCondicion(DataTable dtArticulos, string NumColegiado, string cobradorColegiado, string condicionIni, string condicionFin, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			DataTable dtCliente = new DataTable();
			bool OK = true;
			int cantidadLineas = 0;
			decimal total = 0;
			string encabezado = "", actividadComercial = "", versionnivel = "";
			List<string> parametros = new List<string>();
			try
			{
				#region INSERT
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO (PEDIDO,ESTADO,FECHA_PEDIDO,FECHA_PROMETIDA,FECHA_PROX_EMBARQU,");
				sQuery.AppendLine("FECHA_ULT_EMBARQUE,FECHA_ULT_CANCELAC,FECHA_ORDEN,TARJETA_CREDITO,EMBARCAR_A,DIREC_EMBARQUE,DIRECCION_FACTURA,");
				sQuery.AppendLine("OBSERVACIONES,COMENTARIO_CXC,TOTAL_MERCADERIA,MONTO_ANTICIPO,MONTO_FLETE,MONTO_SEGURO,MONTO_DOCUMENTACIO,");
				sQuery.AppendLine("TIPO_DESCUENTO1,TIPO_DESCUENTO2,MONTO_DESCUENTO1,MONTO_DESCUENTO2,PORC_DESCUENTO1,PORC_DESCUENTO2,");
				sQuery.AppendLine("TOTAL_IMPUESTO1,TOTAL_IMPUESTO2,TOTAL_A_FACTURAR,PORC_COMI_VENDEDOR,PORC_COMI_COBRADOR,TOTAL_CANCELADO,");
				sQuery.AppendLine("TOTAL_UNIDADES,IMPRESO,FECHA_HORA,DESCUENTO_VOLUMEN,TIPO_PEDIDO,MONEDA_PEDIDO,VERSION_NP,AUTORIZADO,");
				sQuery.AppendLine("DOC_A_GENERAR,CLASE_PEDIDO,MONEDA,NIVEL_PRECIO,COBRADOR,RUTA,USUARIO,CONDICION_PAGO,BODEGA,ZONA,VENDEDOR,CLIENTE,");
				sQuery.AppendLine("CLIENTE_DIRECCION,CLIENTE_CORPORAC,CLIENTE_ORIGEN,PAIS,SUBTIPO_DOC_CXC,TIPO_DOC_CXC,BACKORDER,PORC_INTCTE,");
				sQuery.AppendLine("DESCUENTO_CASCADA,FIJAR_TIPO_CAMBIO,ORIGEN_PEDIDO,NOMBRE_CLIENTE,FECHA_PROYECTADA,TIPO_DOCUMENTO,ACTIVIDAD_COMERCIAL)");
				sQuery.AppendLine("VALUES (@PEDIDO,'N',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),");
				sQuery.AppendLine("'19800101',CAST(GETDATE() AS DATE),'',@CLIENTE,'ND',@DIRECCION_FACTURA,@OBSERVACIONES,@COMENTARIO_CXC,0,0,0,0,0,");
				sQuery.AppendLine("'P','P',0,0,0,0,0,0,0,0,0,0,0,'N',GETDATE(),0,'N',@MONEDA_NIVEL,@VERSION_NP,'N',");
				//sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,(SELECT BODEGA_DEFAULT FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),'ND','COL',@CLIENTE,");
				sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,@BODEGA,'ND','COL',@CLIENTE,");
				sQuery.AppendLine("@CLIENTE,@CLIENTE,@CLIENTE,@PAIS,0,'FAC','N',0,");
				sQuery.AppendLine("'N','N','F',@NOMBRE_CLIENTE,CAST(GETDATE() AS DATE),'P',@ACTIVIDAD_COMERCIAL)");
				#endregion

				string pedido = "";
				string condicionPago = "";

				OK = obtenerCondicionPago("ADEL", ref condicionPago, ref error);

				if (OK)
					OK = obtenerConsecutivo("PEDIDOS", ref pedido, ref error);

				if (OK)
					OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

				if (OK)
					OK = FuncsInternas.obtenerVersionNivelPrecio(ref versionnivel, ref error);

				if (OK)
				{
					string prefix = Regex.Match(pedido, "^\\D+").Value;
					string number = Regex.Replace(pedido, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					pedido = prefix + numberMasUno.ToString(new string('0', number.Length));
				}

				if (OK)
					OK = obtenerInfoCliente(ref dtCliente, NumColegiado, ref error);

				if (OK && dtCliente.Rows.Count > 0)
				{
					#region PARAMETROS

					parametros.Add("@PEDIDO," + pedido);
					parametros.Add("@CLIENTE," + dtCliente.Rows[0]["CLIENTE"].ToString());
					parametros.Add("@NIVEL_PRECIO," + dtCliente.Rows[0]["NIVEL_PRECIO"].ToString());
					if (!cobradorColegiado.Equals(""))
						parametros.Add("@COBRADOR," + cobradorColegiado);
					else
						parametros.Add("@COBRADOR," + "ND");
					parametros.Add("@NOMBRE_CLIENTE," + dtCliente.Rows[0]["NOMBRE"].ToString());
					parametros.Add("@PAIS," + dtCliente.Rows[0]["PAIS"].ToString());
					parametros.Add("@CONDICION_PAGO," + condicionPago);
					//parametros.Add("@CONDICION_PAGO," + dtCliente.Rows[0]["CONDICION_PAGO"].ToString());
					if (!dtCliente.Rows[0]["DIRECCION"].ToString().Equals(""))
						parametros.Add("@DIRECCION_FACTURA," + dtCliente.Rows[0]["DIRECCION"].ToString());
					else
						parametros.Add("@DIRECCION_FACTURA,ND");

					encabezado = "Levantamiento Condición - " + DateTime.Now.ToString("dd/MM/yyyy") + "";
					parametros.Add("@OBSERVACIONES," + "" + encabezado + "");
					parametros.Add("@COMENTARIO_CXC," + "" + encabezado + "");

					parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
					parametros.Add("@MONEDA_NIVEL," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
					parametros.Add("@MONEDA," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
					parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);
					parametros.Add("@VERSION_NP," + versionnivel);
					#endregion
					OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}
				else
				{
					OK = false;
					error = "El colegiado no existe como cliente en el ERP.";
				}

				if (OK)
				{
					DataTable dtImpuesto = new DataTable();

					if (dtArticulos.Rows.Count > 0)
					{
						sQuery.Clear();
						sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO_LINEA(PEDIDO,PEDIDO_LINEA,");
						//sQuery.AppendLine("BODEGA,LOTE,LOCALIZACION,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("BODEGA,LOTE,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("CANTIDAD_PEDIDA,CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,CANTIDAD_RESERVADA,CANTIDAD_BONIFICAD,");
						sQuery.AppendLine("CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,TIPO_IMPUESTO1,TIPO_TARIFA1,PORC_IMPUESTO1,PORC_IMPUESTO2,DESCRIPCION,COMENTARIO,");
						sQuery.AppendLine("FECHA_PROMETIDA)");

						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,(SELECT BODEGA_DEFAULT FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("@LINEA_USUARIO,@PRECIO,@CANTIDAD,@CANTIDAD,0,0,0,0,'P',0,0,@TIPO_IMPUESTO1,@TIPO_TARIFA1,@PORC_IMPUESTO1,0,@DESCRIPCION,@COMENTARIO,CAST(GETDATE() AS DATE))");
						int linea = 1;


						foreach (DataRow row in dtArticulos.Rows)
						{
							OK = obtenerImpuestoArticulo(ref dtImpuesto, row["CodigoArticulo"].ToString(), ref error);

							if (OK)
							{
								parametros.Clear();
								parametros.Add("@PEDIDO," + pedido);
								parametros.Add("@PEDIDO_LINEA," + linea);
								parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
								parametros.Add("@LOTE,ND");
								//parametros.Add("@LOCALIZACION,GEN");
								parametros.Add("@LINEA_USUARIO," + (linea - 1));

								parametros.Add("@CANTIDAD," + 1);
								parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
								parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());
								parametros.Add("@PORC_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());

								parametros.Add("@ARTICULO," + row["CodigoArticulo"].ToString());
								parametros.Add("@PRECIO," + row["Precio"].ToString());
								parametros.Add("@DESCRIPCION," + row["descripcion"].ToString());
								parametros.Add("@COMENTARIO," + "Condicion: " + condicionIni + "" + "Condicion Actual: " + condicionFin + "");
								//condicion = "" + row["NombreCondicion"].ToString() + "";
							}

							if (OK)
							{
								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

								linea += 1;
								cantidadLineas = linea - 1;

								total += decimal.Parse(row["Precio"].ToString());
							}

							if (!OK)
								break;
						}

					}
					else
					{
						OK = false;
						error = "El colegiado no tiene artículos definidos para el cobro.";
					}
				}

				if (OK)
				{
					encabezado += " " + condicionIni + "-" + condicionFin + "";
					OK = actualizarPedido(cantidadLineas, pedido, total, 0, 0, encabezado, ref error);
				}

				if (OK)
				{
					OK = actualizarConsecutivo("PEDIDOS", pedido, ref error);
				}


			}

			catch (Exception ex)
			{
				OK = false;
				error = ex.Message;
			}

			return OK;
		}

		public static bool crearPedidoGenerico(DataTable dtArticulos, string clienteERP,
			ref string pedido, decimal montoDescuento, decimal porcDescuento, bool pedidoPorConcepto,
			int indiceArt, string cobradorColegiado, string idCondPAgo, string idConsecutivo, string idVendedor,
			string observacionPedido, string comentarioLinea, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			DataTable dtCliente = new DataTable();
			bool OK = true;
			int cantidadLineas = 0;
			decimal total = 0;
			string comentario_cxc = observacionPedido, actividadComercial = "", versionnivel = "";

			if (comentario_cxc.Length > 40)
				comentario_cxc = comentario_cxc.Substring(0, 40);

			List<string> parametros = new List<string>();
			try
			{
				#region INSERT
				sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO (PEDIDO,ESTADO,FECHA_PEDIDO,FECHA_PROMETIDA,FECHA_PROX_EMBARQU,");
				sQuery.AppendLine("FECHA_ULT_EMBARQUE,FECHA_ULT_CANCELAC,FECHA_ORDEN,TARJETA_CREDITO,EMBARCAR_A,DIREC_EMBARQUE,DIRECCION_FACTURA,");
				sQuery.AppendLine("OBSERVACIONES,COMENTARIO_CXC,TOTAL_MERCADERIA,MONTO_ANTICIPO,MONTO_FLETE,MONTO_SEGURO,MONTO_DOCUMENTACIO,");
				sQuery.AppendLine("TIPO_DESCUENTO1,TIPO_DESCUENTO2,MONTO_DESCUENTO1,MONTO_DESCUENTO2,PORC_DESCUENTO1,PORC_DESCUENTO2,");
				sQuery.AppendLine("TOTAL_IMPUESTO1,TOTAL_IMPUESTO2,TOTAL_A_FACTURAR,PORC_COMI_VENDEDOR,PORC_COMI_COBRADOR,TOTAL_CANCELADO,");
				sQuery.AppendLine("TOTAL_UNIDADES,IMPRESO,FECHA_HORA,DESCUENTO_VOLUMEN,TIPO_PEDIDO,MONEDA_PEDIDO,VERSION_NP,AUTORIZADO,");
				sQuery.AppendLine("DOC_A_GENERAR,CLASE_PEDIDO,MONEDA,NIVEL_PRECIO,COBRADOR,RUTA,USUARIO,CONDICION_PAGO,BODEGA,ZONA,VENDEDOR,CLIENTE,");
				sQuery.AppendLine("CLIENTE_DIRECCION,CLIENTE_CORPORAC,CLIENTE_ORIGEN,PAIS,SUBTIPO_DOC_CXC,TIPO_DOC_CXC,BACKORDER,PORC_INTCTE,");
				sQuery.AppendLine("DESCUENTO_CASCADA,FIJAR_TIPO_CAMBIO,ORIGEN_PEDIDO,NOMBRE_CLIENTE,FECHA_PROYECTADA,TIPO_DOCUMENTO,ACTIVIDAD_COMERCIAL)");
				sQuery.AppendLine("VALUES (@PEDIDO,'N',CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),CAST(GETDATE() AS DATE),");
				sQuery.AppendLine("'19800101',CAST(GETDATE() AS DATE),'',@CLIENTE,'ND',@DIRECCION_FACTURA,@OBSERVACIONES,@COMENTARIO_CXC,0,0,0,0,0,");
				sQuery.AppendLine("'P','P',0,0,0,0,0,0,0,0,0,0,0,'N',GETDATE(),0,'N',@MONEDA_NIVEL,@VERSION_NP,'N',");
				sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,@BODEGA,'ND','" + idVendedor + "',@CLIENTE,");
				//sQuery.AppendLine("'F','N',@MONEDA,@NIVEL_PRECIO,@COBRADOR,'ND','KOLEGIO',@CONDICION_PAGO,(SELECT BODEGA_DEFAULT FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),'ND','" + idVendedor + "',@CLIENTE,");
				sQuery.AppendLine("@CLIENTE,@CLIENTE,@CLIENTE,@PAIS,0,'FAC','N',0,");
				sQuery.AppendLine("'N','N','F',@NOMBRE_CLIENTE,CAST(GETDATE() AS DATE),'P',@ACTIVIDAD_COMERCIAL)");
				#endregion

				//string pedido = "";
				string condicionPago = "";

				OK = obtenerCondicionPago(idCondPAgo, ref condicionPago, ref error);

				if (OK)
					OK = obtenerConsecutivo(idConsecutivo, ref pedido, ref error);

				if (OK)
					OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

				if (OK)
					OK = FuncsInternas.obtenerVersionNivelPrecio(ref versionnivel, ref error);

				if (OK)
				{
					string prefix = Regex.Match(pedido, "^\\D+").Value;
					string number = Regex.Replace(pedido, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					pedido = prefix + numberMasUno.ToString(new string('0', number.Length));
				}

				if (OK)
					OK = obtenerInfoCliente(ref dtCliente, clienteERP, ref error);

				if (OK)
				{
					if (dtCliente.Rows.Count > 0)
					{
						#region PARAMETROS

						parametros.Add("@PEDIDO," + pedido);
						parametros.Add("@CLIENTE," + dtCliente.Rows[0]["CLIENTE"].ToString());
						parametros.Add("@NIVEL_PRECIO," + dtCliente.Rows[0]["NIVEL_PRECIO"].ToString());
						if (!cobradorColegiado.Equals(""))
							parametros.Add("@COBRADOR," + cobradorColegiado);
						else
							parametros.Add("@COBRADOR," + "ND");
						parametros.Add("@NOMBRE_CLIENTE," + dtCliente.Rows[0]["NOMBRE"].ToString());
						parametros.Add("@PAIS," + dtCliente.Rows[0]["PAIS"].ToString());

						parametros.Add("@CONDICION_PAGO," + condicionPago);
						if (!dtCliente.Rows[0]["DIRECCION"].ToString().Equals(""))
							parametros.Add("@DIRECCION_FACTURA," + dtCliente.Rows[0]["DIRECCION"].ToString());
						else
							parametros.Add("@DIRECCION_FACTURA,ND");

						parametros.Add("@OBSERVACIONES," + "" + observacionPedido + "");
						parametros.Add("@COMENTARIO_CXC," + "" + comentario_cxc + "");

						parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
						parametros.Add("@MONEDA_NIVEL," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
						parametros.Add("@MONEDA," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
						parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);
						parametros.Add("@VERSION_NP," + versionnivel);
						#endregion
						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
					}
					else
					{
						OK = false;
						error = "El registro no existe como cliente en el ERP.";
					}
				}

				if (OK)
				{
					DataTable dtImpuesto = new DataTable();

					if (dtArticulos.Rows.Count > 0)
					{
						sQuery.Clear();
						sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO_LINEA(PEDIDO,PEDIDO_LINEA,");
						//sQuery.AppendLine("BODEGA,LOTE,LOCALIZACION,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("BODEGA,LOTE,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,PRECIO_UNITARIO,");
						sQuery.AppendLine("CANTIDAD_PEDIDA,CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,CANTIDAD_RESERVADA,CANTIDAD_BONIFICAD,");
						sQuery.AppendLine("CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,TIPO_IMPUESTO1,TIPO_TARIFA1,PORC_IMPUESTO1,PORC_IMPUESTO2,DESCRIPCION,COMENTARIO,");
						sQuery.AppendLine("FECHA_PROMETIDA)");

						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,(SELECT BODEGA_DEFAULT FROM " + Consultas.sqlCon.COMPAÑIA + ".GLOBALES_FA),@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						//sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@LOCALIZACION,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("VALUES (@PEDIDO,@PEDIDO_LINEA,@BODEGA,@LOTE,@ARTICULO,'N',CAST(GETDATE() AS DATE),");
						sQuery.AppendLine("@LINEA_USUARIO,@PRECIO,@CANTIDAD,@CANTIDAD,0,0,0,0,'P',0,0,@TIPO_IMPUESTO1,@TIPO_TARIFA1,@PORC_IMPUESTO1,0,@DESCRIPCION,@COMENTARIO,CAST(GETDATE() AS DATE))");
						int linea = 1;

						if (!pedidoPorConcepto)
						{
							foreach (DataRow row in dtArticulos.Rows)
							{
								OK = obtenerImpuestoArticulo(ref dtImpuesto, row["ARTICULO"].ToString(), ref error);

								if (OK)
								{
									parametros.Clear();
									parametros.Add("@PEDIDO," + pedido);
									parametros.Add("@PEDIDO_LINEA," + linea);
									parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
									parametros.Add("@LOTE,ND");
									//parametros.Add("@LOCALIZACION,GEN");
									parametros.Add("@LINEA_USUARIO," + (linea - 1));
									parametros.Add("@CANTIDAD," + row["CANTIDAD"].ToString());
									parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
									parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());
									parametros.Add("@PORC_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
									parametros.Add("@ARTICULO," + row["ARTICULO"].ToString());
									parametros.Add("@PRECIO," + row["PRECIO"].ToString());
									parametros.Add("@DESCRIPCION," + row["DESCRIPCION"].ToString());
									parametros.Add("@COMENTARIO," + comentarioLinea);
								}

								if (OK)
								{
									OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

									linea += 1;
									cantidadLineas = linea - 1;

									total += decimal.Parse(row["PRECIO"].ToString()) * decimal.Parse(row["CANTIDAD"].ToString());
								}

								if (!OK)
									break;
							}
						}
						else
						{
							OK = obtenerImpuestoArticulo(ref dtImpuesto, dtArticulos.Rows[indiceArt]["ARTICULO"].ToString(), ref error);

							if (OK)
							{
								parametros.Clear();
								parametros.Add("@PEDIDO," + pedido);
								parametros.Add("@PEDIDO_LINEA," + linea);
								parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
								parametros.Add("@LOTE,ND");
								//parametros.Add("@LOCALIZACION,GEN");
								parametros.Add("@LINEA_USUARIO," + (linea - 1));
								parametros.Add("@CANTIDAD," + dtArticulos.Rows[indiceArt]["CANTIDAD"].ToString());
								parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
								parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());
								parametros.Add("@PORC_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
								parametros.Add("@ARTICULO," + dtArticulos.Rows[indiceArt]["ARTICULO"].ToString());
								parametros.Add("@PRECIO," + dtArticulos.Rows[indiceArt]["PRECIO"].ToString());
								parametros.Add("@DESCRIPCION," + dtArticulos.Rows[indiceArt]["DESCRIPCION"].ToString());
								parametros.Add("@COMENTARIO," + comentarioLinea);
							}


							if (OK)
							{
								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

								linea += 1;
								cantidadLineas = linea - 1;

								total += decimal.Parse(dtArticulos.Rows[indiceArt]["PRECIO"].ToString()) * decimal.Parse(dtArticulos.Rows[indiceArt]["CANTIDAD"].ToString());

							}

						}

						//total = total - montoDescuento;
					}
					else
					{
						OK = false;
						error = "El colegiado no tiene artículos definidos para el cobro.";
					}
				}

				if (OK)
				{
					//encabezado += " " + condicion + "";
					//OK = actualizarPedido(cantidadLineas, pedido, total, montoDescuento, porcDescuento, encabezado, ref error);
					OK = actualizarPedido(cantidadLineas, pedido, total, montoDescuento, porcDescuento, ref error);
				}

				if (OK)
				{
					OK = actualizarConsecutivo(idConsecutivo, pedido, ref error);
				}


			}

			catch (Exception ex)
			{
				OK = false;
				error = ex.Message;
			}

			return OK;
		}

		public static bool obtenerConsecutivo(string tipo, ref string valor, ref string error)
		{
			DataTable dtConsecutivo = new DataTable();
			bool OK = true;
			valor = "";
			error = "";
			string strSQL = "";
			#region MANEJO ERROR
			if (tipo == "FACTURAS")
			{
				if (Globales.CONSECUTIVO_FACTURA == "")
				{
					error = "El consecutivo para facturas no esta definido en las globales del sistema.";
					return false;
				}
			}
			else
			{
				if (tipo == "PEDIDOS")
				{
					if (Globales.CONSECUTIVO_PEDIDO == "")
					{
						error = "El consecutivo para pedidos no esta definido en las globales del sistema.";
						return false;
					}
				}
				else
				{
					if (tipo == "ADELANTOS")
					{
						if (Globales.CONSECUTIVO_ADELANTOS == "")
						{
							error = "El consecutivo para adelantos no esta definido en las globales del sistema.";
							return false;
						}
					}
					else
					{
						if (tipo == "RECIBOS")
						{
							if (Globales.CONSECUTIVO_RECIBOS == "")
							{
								error = "El consecutivo para recibos no esta definido en las globales del sistema.";
								return false;
							}
						}
					}
				}

			}
			#endregion


			try
			{

				if (tipo == "FACTURAS")
				{
					strSQL = "select VALOR_CONSECUTIVO CONSECUTIVO from " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO_FA where CODIGO_CONSECUTIVO='" + Globales.CONSECUTIVO_FACTURA + "'";
				}
				else
				{
					if (tipo == "PEDIDOS")
					{
						strSQL = "select VALOR_CONSECUTIVO CONSECUTIVO from " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO_FA where CODIGO_CONSECUTIVO='" + Globales.CONSECUTIVO_PEDIDO + "'";
					}
					else
					{
						if (tipo == "RECIBOS")
						{
							strSQL = "SELECT ULTIMO_VALOR FROM " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO WHERE CONSECUTIVO='" + Globales.CONSECUTIVO_RECIBOS + "'";
						}
						else
						{
							if (tipo == "ADELANTOS")
							{
								strSQL = "SELECT ULTIMO_VALOR FROM " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO WHERE CONSECUTIVO='" + Globales.CONSECUTIVO_ADELANTOS + "'";
							}
						}
					}

				}

				if (Consultas.fillDataTable(strSQL, ref dtConsecutivo, ref error))
				{
					if (dtConsecutivo.Rows.Count > 0)
						valor = dtConsecutivo.Rows[0][0].ToString();
					else
					{
						if (tipo == "FACTURAS")
						{
							error = "No se encontró el consecutivo para facturas en el erp.";
						}
						else
						{
							if (tipo == "PEDIDOS")
							{
								error = "No se encontró el consecutivo para pedidos en el erp.";
							}
							else
							{
								if (tipo == "RECIBOS")
								{
									error = "No se encontró el consecutivo para recibos en el erp.";
								}
								else
								{
									if (tipo == "ADELANTOS")
									{
										error = "No se encontró el consecutivo para adelantos en el erp.";
									}
								}
							}

						}


						OK = false;
					}
				}
				else
					OK = false;


			}
			catch (Exception ex)
			{
				if (tipo == "FACTURAS")
				{
					error = "Error obteniendo el consecutivo de '" + Globales.CONSECUTIVO_FACTURA + "' desde el erp\n" + ex.Message;
				}
				else
				{
					if (tipo == "PEDIDOS")
					{
						error = "Error obteniendo el consecutivo de '" + Globales.CONSECUTIVO_PEDIDO + "' desde el erp\n" + ex.Message;
					}
					else
					{
						if (tipo == "RECIBOS")
						{
							error = "Error obteniendo el consecutivo de '" + Globales.CONSECUTIVO_RECIBOS + "' desde el erp\n" + ex.Message;
						}
						else
						{
							if (tipo == "ADELANTOS")
							{

								error = "Error obteniendo el consecutivo de '" + Globales.CONSECUTIVO_ADELANTOS + "' desde el erp\n" + ex.Message;
							}
						}
					}

				}


				OK = false;
			}

			return OK;
		}

		public static bool obtenerCondicionPago(string tipo, ref string valor, ref string error)
		{
			DataTable dt = new DataTable();
			bool OK = true;
			valor = "";
			error = "";
			string strSQL = "";

			if (tipo == "C")
			{
				if (Globales.CONDICION_PAGO_COLEGIATURAS == "")
				{
					error = "La condición de pago para colegiaturas no esta definido en las globales del sistema.";
					return false;
				}
			}
			else
			{
				if (tipo == "R")
				{
					if (Globales.CONDICION_PAGO_REGENCIAS == "")
					{
						error = "La condición de pago para regencias no esta definido en las globales del sistema.";
						return false;
					}
				}
				else
				{
					if (tipo == "C_A")
					{
						if (Globales.CONDICION_PAGO_CANONES_ANUALES == "")
						{
							error = "La condición de pago para canones anuales no esta definido en las globales del sistema.";
							return false;
						}
					}
					else
					{
						if (tipo == "ADEL")
						{
							if (Globales.CONDICION_PAGO_ADELANTOS == "")
							{
								error = "La condición de pago para adelantos no esta definido en las globales del sistema.";
								return false;
							}
						}
					}
				}

			}



			try
			{
				if (tipo == "C")
				{
					strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_COLEGIATURAS + "'";
				}
				else
				{
					if (tipo == "R")
					{
						strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_REGENCIAS + "'";
					}
					else
					{
						if (tipo == "C_A")
						{
							strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_CANONES_ANUALES + "'";
						}
						else
						{
							if (tipo == "ADEL")
							{
								strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_ADELANTOS + "'";
							}
						}
					}

				}


				if (Consultas.fillDataTable(strSQL, ref dt, ref error))
				{
					if (dt.Rows.Count > 0)
						valor = dt.Rows[0][0].ToString();
					else
					{

						if (tipo == "C")
						{
							error = "No se encontró la condicion de pago para colegiaturas en el erp.";
						}
						else
						{
							if (tipo == "R")
							{
								error = "No se encontró la condicion de pago para regencias en el erp.";
							}
							else
							{
								if (tipo == "C_A")
								{
									error = "No se encontró la condicion de pago para canones anuales en el erp.";
								}
								else
								{
									if (tipo == "ADEL")
									{
										error = "No se encontró la condicion de pago para adelantos en el erp.";
									}
								}
							}

						}


						OK = false;
					}
				}
				else
					OK = false;


			}
			catch (Exception ex)
			{

				if (tipo == "C")
				{
					error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_COLEGIATURAS + "' desde el erp\n" + ex.Message;
				}
				else
				{
					if (tipo == "R")
					{
						error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_REGENCIAS + "' desde el erp\n" + ex.Message;
					}
					else
					{
						if (tipo == "C_A")
						{
							error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_CANONES_ANUALES + "' desde el erp\n" + ex.Message;
						}
						else
						{
							if (tipo == "ADEL")
							{
								error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_ADELANTOS + "' desde el erp\n" + ex.Message;
							}
						}
					}

				}

				OK = false;
			}

			return OK;
		}

		public static bool actualizarConsecutivo(string tipo, string valor, ref string error)
		{
			DataTable dtConsecutivo = new DataTable();
			bool OK = true;
			error = "";
			string strSQL = "";
			try
			{


				if (tipo == "FACTURAS")
				{
					strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO_FA set VALOR_CONSECUTIVO='" + valor + "' where CODIGO_CONSECUTIVO='" + Globales.CONSECUTIVO_FACTURA + "'";
				}
				else
				{
					if (tipo == "PEDIDOS")
					{
						strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO_FA set VALOR_CONSECUTIVO='" + valor + "' where CODIGO_CONSECUTIVO='" + Globales.CONSECUTIVO_PEDIDO + "'";
					}
					else
					{
						if (tipo == "RECIBOS")
						{
							strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO set ULTIMO_VALOR='" + valor + "' where CONSECUTIVO='" + Globales.CONSECUTIVO_RECIBOS + "'";
						}
						else
						{
							if (tipo == "ADELANTOS")
							{
								strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO set ULTIMO_VALOR='" + valor + "' where CONSECUTIVO='" + Globales.CONSECUTIVO_ADELANTOS + "'";
							}
						}
					}


				}

				Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				if (tipo == "FACTURAS")
				{
					error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_FACTURA + "' desde el erp\n" + ex.Message;
				}
				else
				{
					if (tipo == "RECIBOS")
					{
						error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_RECIBOS + "' desde el erp\n" + ex.Message;
					}
					else
					{
						if (tipo == "PEDIDOS")
						{
							error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_PEDIDO + "' desde el erp\n" + ex.Message;
						}
						else
						{
							if (tipo == "ADELANTOS")
							{
								error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_ADELANTOS + "' desde el erp\n" + ex.Message;
							}
						}
					}


				}

				OK = false;
			}

			return OK;
		}

		//public static bool actualizarConsecutivoF(string tipo, string valor, ref string error)
		//{
		//    DataTable dtConsecutivo = new DataTable();
		//    bool OK = true;
		//    error = "";
		//    string strSQL = "";
		//    try
		//    {


		//        if (tipo == "FACTURAS")
		//            strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO_FA set VALOR_CONSECUTIVO='" + valor + "' where CODIGO_CONSECUTIVO='" + Globales.CONSECUTIVO_FACTURA + "'";
		//        else
		//        {
		//            if (tipo == "RECIBOS")
		//                strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO set ULTIMO_VALOR='" + valor + "' where CONSECUTIVO='" + Globales.CONSECUTIVO_RECIBOS + "'";
		//            else
		//                strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".CONSECUTIVO set ULTIMO_VALOR='" + valor + "' where CONSECUTIVO='" + Globales.CONSECUTIVO_ADELANTOS + "'";

		//        }

		//        Consultas.ejecutarSentencia(strSQL, ref error);
		//    }
		//    catch (Exception ex)
		//    {
		//        if (tipo == "RECIBOS")
		//            error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_RECIBOS + "' desde el erp\n" + ex.Message;
		//        else
		//        {
		//            if (tipo == "FACTURAS")
		//                error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_FACTURA + "' desde el erp\n" + ex.Message;
		//            else
		//                error = "Error actualizando el consecutivo de '" + Globales.CONSECUTIVO_ADELANTOS + "' desde el erp\n" + ex.Message;

		//        }

		//        OK = false;
		//    }

		//    return OK;
		//}

		public static bool actualizarPedido(int cantLineas, string pedido, decimal total, decimal montoDesc, decimal porcentajeDesc, ref string error)
		{
			bool OK = true;
			error = "";
			string strSQL = "";
			decimal totalConDesc = 0;
			try
			{
				totalConDesc = total - montoDesc;

				strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO set TOTAL_MERCADERIA='" + total + "', " +
				"TOTAL_A_FACTURAR = '" + totalConDesc + "', TOTAL_UNIDADES = '" + cantLineas + "', MONTO_DESCUENTO1 = '" + montoDesc + "', PORC_DESCUENTO1 = '" + porcentajeDesc + "'" +
				" where PEDIDO='" + pedido + "'";

				Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "Error al actualizar totales de pedido \n" + ex.Message;
				OK = false;
			}

			return OK;
		}

		public static bool actualizarFactura(int cantLineas, string factura, decimal total, decimal montoDesc, decimal porcentajeDesc, ref string error)
		{
			bool OK = true;
			error = "";
			string strSQL = "";
			decimal totalConDesc = 0;
			try
			{
				totalConDesc = total - montoDesc;

				strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".FACTURA set TOTAL_FACTURA='" + totalConDesc + "', TOTAL_MERCADERIA='" + total + "', " +
				"TOTAL_UNIDADES = '" + cantLineas + "', MONTO_DESCUENTO1 = '" + montoDesc + "', PORC_DESCUENTO1 = '" + porcentajeDesc + "'" +
				" where FACTURA='" + factura + "'";

				Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "Error al actualizar totales de factura \n" + ex.Message;
				OK = false;
			}

			return OK;
		}

		public static bool actualizarTotalesFacturacion(int cantLineas, string factura, decimal total, decimal montoDesc, decimal porcentajeDesc, ref string error)
		{
			bool OK = true;
			error = "";
			string strSQL = "";
			decimal totalConDesc = 0;

			totalConDesc = total - montoDesc;

			try
			{
				//totalConDesc = total - montoDesc;

				strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".FACTURA set TOTAL_FACTURA='" + totalConDesc + "', TOTAL_MERCADERIA='" + total + "', " +
				"TOTAL_UNIDADES = '" + cantLineas + "', MONTO_DESCUENTO1 = '" + montoDesc + "', PORC_DESCUENTO1 = '" + porcentajeDesc + "'" +
				" where FACTURA='" + factura + "'";

				Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "Error al actualizar totales de la factura \n" + ex.Message;
				OK = false;
			}

			//try
			//{
			//    strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".FACTURA_LINEA set PRECIO_TOTAL='" + totalConDesc + "', DESC_TOT_GENERAL = '" + montoDesc + "'" +
			//    " where FACTURA='" + factura + "'";

			//    Consultas.ejecutarSentencia(strSQL, ref error);
			//}
			//catch (Exception ex)
			//{
			//    error = "Error al actualizar totales de la factura_linea \n" + ex.Message;
			//    OK = false;
			//}

			//try
			//{
			//    strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".FACTURA_LINEA set PRECIO_TOTAL='" + totalConDesc + "', DESC_TOT_GENERAL = '" + montoDesc + "'" +
			//    " where FACTURA='" + factura + "'";

			//    Consultas.ejecutarSentencia(strSQL, ref error);
			//}
			//catch (Exception ex)
			//{
			//    error = "Error al actualizar totales de la factura_linea \n" + ex.Message;
			//    OK = false;
			//}

			return OK;
		}

		//public static bool obtenerActividadComercial(string tipo, ref string valor, ref string error)
		//{
		//    DataTable dt = new DataTable();
		//    bool OK = true;
		//    valor = "";
		//    error = "";
		//    string strSQL = "";

		//    if (tipo == "C")
		//    {
		//        if (Globales.CONDICION_PAGO_COLEGIATURAS == "")
		//        {
		//            error = "La condición de pago para colegiaturas no esta definido en las globales del sistema.";
		//            return false;
		//        }
		//    }
		//    else
		//    {
		//        if (tipo == "R")
		//        {
		//            if (Globales.CONDICION_PAGO_REGENCIAS == "")
		//            {
		//                error = "La condición de pago para regencias no esta definido en las globales del sistema.";
		//                return false;
		//            }
		//        }
		//        else
		//        {
		//            if (tipo == "C_A")
		//            {
		//                if (Globales.CONDICION_PAGO_CANONES_ANUALES == "")
		//                {
		//                    error = "La condición de pago para canones anuales no esta definido en las globales del sistema.";
		//                    return false;
		//                }
		//            }
		//            else
		//            {
		//                if (tipo == "ADEL")
		//                {
		//                    if (Globales.CONDICION_PAGO_ADELANTOS == "")
		//                    {
		//                        error = "La condición de pago para adelantos no esta definido en las globales del sistema.";
		//                        return false;
		//                    }
		//                }
		//            }
		//        }

		//    }



		//    try
		//    {
		//        if (tipo == "C")
		//        {
		//            strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_COLEGIATURAS + "'";
		//        }
		//        else
		//        {
		//            if (tipo == "R")
		//            {
		//                strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_REGENCIAS + "'";
		//            }
		//            else
		//            {
		//                if (tipo == "C_A")
		//                {
		//                    strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_CANONES_ANUALES + "'";
		//                }
		//                else
		//                {
		//                    if (tipo == "ADEL")
		//                    {
		//                        strSQL = "select CONDICION_PAGO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO ='" + Globales.CONDICION_PAGO_ADELANTOS + "'";
		//                    }
		//                }
		//            }

		//        }


		//        if (Consultas.fillDataTable(strSQL, ref dt, ref error))
		//        {
		//            if (dt.Rows.Count > 0)
		//                valor = dt.Rows[0][0].ToString();
		//            else
		//            {

		//                if (tipo == "C")
		//                {
		//                    error = "No se encontró la condicion de pago para colegiaturas en el erp.";
		//                }
		//                else
		//                {
		//                    if (tipo == "R")
		//                    {
		//                        error = "No se encontró la condicion de pago para regencias en el erp.";
		//                    }
		//                    else
		//                    {
		//                        if (tipo == "C_A")
		//                        {
		//                            error = "No se encontró la condicion de pago para canones anuales en el erp.";
		//                        }
		//                        else
		//                        {
		//                            if (tipo == "ADEL")
		//                            {
		//                                error = "No se encontró la condicion de pago para adelantos en el erp.";
		//                            }
		//                        }
		//                    }

		//                }


		//                OK = false;
		//            }
		//        }
		//        else
		//            OK = false;


		//    }
		//    catch (Exception ex)
		//    {

		//        if (tipo == "C")
		//        {
		//            error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_COLEGIATURAS + "' desde el erp\n" + ex.Message;
		//        }
		//        else
		//        {
		//            if (tipo == "R")
		//            {
		//                error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_REGENCIAS + "' desde el erp\n" + ex.Message;
		//            }
		//            else
		//            {
		//                if (tipo == "C_A")
		//                {
		//                    error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_CANONES_ANUALES + "' desde el erp\n" + ex.Message;
		//                }
		//                else
		//                {
		//                    if (tipo == "ADEL")
		//                    {
		//                        error = "Error obteniendo la condición de pago de '" + Globales.CONDICION_PAGO_ADELANTOS + "' desde el erp\n" + ex.Message;
		//                    }
		//                }
		//            }

		//        }

		//        OK = false;
		//    }

		//    return OK;
		//}

		public static bool actualizarPedido(int cantLineas, string pedido, decimal total, decimal montoDesc, decimal porcentajeDesc, string encabezado, ref string error)
		{
			bool OK = true;
			error = "";
			string strSQL = "";
			string encabezadoCxc = "";
			decimal totalConDesc = 0;
			try
			{
				if (encabezado.Length > 40)
					encabezadoCxc = encabezado.Substring(0, 40);
				else
					encabezadoCxc = encabezado;

				totalConDesc = total - montoDesc;

				strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".PEDIDO set TOTAL_MERCADERIA='" + total + "', " +
				"TOTAL_A_FACTURAR = '" + totalConDesc + "', TOTAL_UNIDADES = '" + cantLineas + "', MONTO_DESCUENTO1 = '" + montoDesc + "', PORC_DESCUENTO1 = '" + porcentajeDesc + "', OBSERVACIONES = '" + encabezado + "', COMENTARIO_CXC = '" + encabezadoCxc + "'" +
				" where PEDIDO='" + pedido + "'";


				Consultas.ejecutarSentencia(strSQL, ref error);
			}
			catch (Exception ex)
			{
				error = "Error al actualizar totales de pedido \n" + ex.Message;
				OK = false;
			}

			return OK;
		}

		public static bool obtenerInfoCliente(ref DataTable dtCliente, string cliente, ref string error)
		{
			bool OK = true;
			error = "";
			string strSQL = "";
			try
			{

				strSQL = "select *,(select top 1 MONTO from " + Consultas.sqlCon.COMPAÑIA + ".TIPO_CAMBIO_HIST where TIPO_CAMBIO = 'TCOM' and FECHA <=getdate() order by CreateDate desc) TIPO_CAMBIO from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE='" + cliente + "'";

				if (Consultas.fillDataTable(strSQL, ref dtCliente, ref error))
					OK = true;

				else
					OK = false;
			}
			catch (Exception ex)
			{
				error = "Error obteniendo la información del cliente desde el erp\n" + ex.Message;
				OK = false;
			}

			return OK;
		}

		public static bool obtenerImpuestoArticulo(ref DataTable dtImpuesto, string articulo, ref string error)
		{
			bool OK = true;
			error = "";
			string strSQL = "";
			try
			{
				//strSQL = "select* from " + Consultas.sqlCon.COMPAÑIA + ".IMPUESTO where IMPUESTO = (select IMPUESTO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = '" + articulo + "')";
				//strSQL = "select * from " + Consultas.sqlCon.COMPAÑIA + ".IMPUESTO where IMPUESTO = '" + impuesto + "'";
				strSQL = "select * from " + Consultas.sqlCon.COMPAÑIA + ".V_TARIFA_IVA" +
				" where TIPO_IMPUESTO = (select TIPO_IMPUESTO1 from " + Consultas.sqlCon.COMPAÑIA + ".IMPUESTO where IMPUESTO =" +
				" (select IMPUESTO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = '" + articulo + "')) " +
				" and TIPO_TARIFA = (select TIPO_TARIFA1 from " + Consultas.sqlCon.COMPAÑIA + ".IMPUESTO where IMPUESTO =" +
				" (select IMPUESTO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = '" + articulo + "'))";

				if (Consultas.fillDataTable(strSQL, ref dtImpuesto, ref error))
				{
					if (dtImpuesto.Rows.Count > 0)
						OK = true;
					else
					{
						error = "La información tipo_impuesto/tipo_tarifa del impuesto del articulo es nula";
						OK = false;
					}
				}
				else
				{
					OK = false;
				}
			}
			catch (Exception ex)
			{
				error = "Error obteniendo la información del impuesto del articulo\n" + ex.Message;
				OK = false;
			}

			return OK;
		}

		public bool sincronizarLineaPedido(DataTable linea, string pedido, ref string error)
		{
			bool ok = true;
			List<string> plParams = new List<string>();
			#region Insert sQuery
			StringBuilder sQuery = new StringBuilder();
			sQuery.AppendLine("Insert into " + Consultas.sqlCon.COMPAÑIA + " . PEDIDO_LINEA (PEDIDO,PEDIDO_LINEA,BODEGA,LOTE,LOCALIZACION,ARTICULO, ");
			sQuery.AppendLine("ESTADO, FECHA_ENTREGA,LINEA_USUARIO, PRECIO_UNITARIO, CANTIDAD_PEDIDA, CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,");
			sQuery.AppendLine("CANTIDAD_RESERVADA,CANTIDAD_BONIFICAD,CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,DESCRIPCION,");
			sQuery.AppendLine("COMENTARIO,FECHA_PROMETIDA,TIPO_DESC,PEDIDO_LINEA_BONIF) ");
			sQuery.AppendLine("values (@pedido,@linea,@bodega,@lote, @localizacion,");
			sQuery.AppendLine("@articulo,@estado,convert(varchar,getdate(),112),@linea_usuario,@precio_unitario,@cantidad_pedida,@cant_a_fac,@cant_facturada,@cant_reservada,");
			sQuery.AppendLine("@cant_bonif,@cant_cancelada,@tipo_descuento,@monto_descuento,@porc_descuento,@descripcion,@comentario,convert(varchar,getdate(),112),");
			sQuery.AppendLine("@tipo_desc,@linea_bonif)");
			#endregion

			try
			{
				#region parametros
				int numLinea = 1;
				foreach (DataRow row in linea.Rows)
				{
					plParams = new List<string>();
					plParams.Add("@pedido," + pedido);
					plParams.Add("@linea," + (numLinea));
					plParams.Add("@bodega, 001");
					plParams.Add("@lote," + DBNull.Value);
					plParams.Add("@localizacion," + DBNull.Value);


					plParams.Add("@articulo," + row["Articulo"].ToString());
					plParams.Add("@estado,N");
					plParams.Add("@linea_usuario," + (numLinea));
					plParams.Add("@precio_unitario," + decimal.Parse(row["Precio"].ToString()));
					plParams.Add("@cantidad_pedida,1");
					plParams.Add("@cant_a_fac,1");
					plParams.Add("@cant_facturada, 0");
					plParams.Add("@cant_reservada, 0");
					plParams.Add("@cant_bonif,0");
					plParams.Add("@cant_cancelada, 0");
					plParams.Add("@tipo_descuento,P");
					plParams.Add("@monto_descuento,0");
					plParams.Add("@porc_descuento,0");
					plParams.Add("@descripcion,");
					plParams.Add("@comentario,");
					plParams.Add("@tipo_desc,0");
					plParams.Add("@linea_bonif,");
					#endregion

					ok = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), plParams, ref error);

					if (!ok)
						break;
				}
			}

			catch (Exception ex)
			{
				ok = false;
				error = ex.Message;

			}

			return ok;
		}

		#region GENERAR_FACTURAS

		public static bool FacturarSinPedido(DataTable dtArticulos, string clienteERP,
			ref string factura, decimal montoDescuento, decimal porcDescuento, bool pedidoPorConcepto,
			int indiceArt, string cobrador, string idCondPAgo, string idConsecutivo, string idVendedor,
			string observacion, string comentarioLinea, /*string tipoRegistro,*/string codEstable, string categoria, ref string error)
		{
			StringBuilder sQuery = new StringBuilder();
			List<string> parametros = new List<string>();
			DataTable dtCliente = new DataTable();
			bool OK = true;
			int cantidadLineas = 0;
			decimal total = 0;
			string comentario_cxc = observacion, actividadComercial = "", condicionPago = "", vesionnivel = "";
			var audit = new object();

			if (comentario_cxc.Length > 40)
				comentario_cxc = comentario_cxc.Substring(0, 40);


			try
			{

				OK = obtenerCondicionPago(idCondPAgo, ref condicionPago, ref error);

				if (OK)
					OK = obtenerConsecutivo(idConsecutivo, ref factura, ref error);

				if (OK)
					OK = FuncsInternas.obtenerActividadComercial(ref actividadComercial, ref error);

				if (OK)
					OK = FuncsInternas.obtenerVersionNivelPrecio(ref vesionnivel, ref error);

				if (OK)
				{
					string prefix = Regex.Match(factura, "^\\D+").Value;
					string number = Regex.Replace(factura, "^\\D+", "");
					int numberMasUno = int.Parse(number) + 1;
					factura = prefix + numberMasUno.ToString(new string('0', number.Length));
				}

				if (OK)
				{
					OK = obtenerInfoCliente(ref dtCliente, clienteERP, ref error);

					if (dtCliente.Rows.Count == 0)
					{
						OK = false;
						error = "El registro no existe como cliente en el ERP.";
					}
				}


				if (dtArticulos.Rows.Count == 0)
				{
					OK = false;
					error = "El colegiado no tiene artículos definidos para el cobro.";
				}

				#region INSERT AUDIT_TRANS_INV TRANSACCION_INV

				if (OK)
				{
					OK = queryInsertarAuditTransInv(ref parametros, ref sQuery, factura, clienteERP);

					if (OK)
						OK = Consultas.ejecutarSentenciaEscalarParametros(sQuery.ToString(), parametros, ref audit, ref error);
				}

				if (OK)
				{
					int linea = 1;
					if (!pedidoPorConcepto)
					{
						foreach (DataRow row in dtArticulos.Rows)
						{
							OK = queryInsertarTransacionInv(ref parametros, ref sQuery, audit, row["ARTICULO"].ToString(), linea, dtCliente.Rows[0]["CONTRIBUYENTE"].ToString(),
								row["CANTIDAD"].ToString(), decimal.Parse(dtCliente.Rows[0]["TIPO_CAMBIO"].ToString()), decimal.Parse(row["PRECIO"].ToString()));

							if (OK)
							{
								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
								linea += 1;
							}

							if (!OK)
								break;
						}
					}
					else
					{
						if (OK)
							OK = queryInsertarTransacionInv(ref parametros, ref sQuery, audit, dtArticulos.Rows[indiceArt]["ARTICULO"].ToString(), linea, dtCliente.Rows[0]["CONTRIBUYENTE"].ToString(),
								dtArticulos.Rows[indiceArt]["CANTIDAD"].ToString(), decimal.Parse(dtCliente.Rows[0]["TIPO_CAMBIO"].ToString()), decimal.Parse(dtArticulos.Rows[indiceArt]["PRECIO"].ToString()));

						if (OK)
						{
							OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
							linea += 1;
						}
					}
				}
				#endregion

				#region INSERT FACTURA FACTURA_LINEA

				if (OK)
				{
					OK = queryInsertarFactura(ref parametros, ref sQuery, dtCliente, factura, audit, observacion,
							 cobrador, condicionPago, idVendedor, /*idConsecutivo,*/ comentario_cxc, codEstable, categoria, actividadComercial, vesionnivel);
					if (OK)
						OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);
				}

				if (OK)
				{
					DataTable dtImpuesto = new DataTable();
					int linea = 1;

					if (!pedidoPorConcepto)
					{
						foreach (DataRow row in dtArticulos.Rows)
						{
							OK = obtenerImpuestoArticulo(ref dtImpuesto, row["ARTICULO"].ToString(), ref error);

							if (OK)
								OK = queryInsertarFacturaLinea(ref parametros, ref sQuery, dtImpuesto, linea, factura, row["ARTICULO"].ToString(), row["CANTIDAD"].ToString(),
									row["PRECIO"].ToString(), row["DESCRIPCION"].ToString(), comentarioLinea, dtArticulos.Rows[indiceArt]["DESCUENTO"].ToString());

							if (OK)
							{
								OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

								linea += 1;
								cantidadLineas = linea - 1;

								total += decimal.Parse(row["PRECIO"].ToString()) * decimal.Parse(row["CANTIDAD"].ToString());
							}

							if (!OK)
								break;
						}
					}
					else
					{
						OK = obtenerImpuestoArticulo(ref dtImpuesto, dtArticulos.Rows[indiceArt]["ARTICULO"].ToString(), ref error);

						if (OK)
							OK = queryInsertarFacturaLinea(ref parametros, ref sQuery, dtImpuesto, linea, factura, dtArticulos.Rows[indiceArt]["ARTICULO"].ToString(), dtArticulos.Rows[indiceArt]["CANTIDAD"].ToString(),
								dtArticulos.Rows[indiceArt]["PRECIO"].ToString(), dtArticulos.Rows[indiceArt]["DESCRIPCION"].ToString(), comentarioLinea, dtArticulos.Rows[indiceArt]["DESCUENTO"].ToString());

						if (OK)
						{
							OK = Consultas.ejecutarSentenciaParametros(sQuery.ToString(), parametros, ref error);

							linea += 1;
							cantidadLineas = linea - 1;

							total += decimal.Parse(dtArticulos.Rows[indiceArt]["PRECIO"].ToString()) * decimal.Parse(dtArticulos.Rows[indiceArt]["CANTIDAD"].ToString());

						}

					}

				}
				#endregion

				if (OK)
					OK = actualizarFactura(cantidadLineas, factura, total, montoDescuento, porcDescuento, ref error);

				if (OK)
					OK = actualizarConsecutivo(idConsecutivo, factura, ref error);

			}

			catch (Exception ex)
			{
				OK = false;
				error = ex.Message;
			}

			return OK;
		}

		public static bool queryInsertarAuditTransInv(ref List<string> parametros, ref StringBuilder sQuery, string consecutivoFAC, string cliente)
		{
			bool OK = true;

			#region INSERT

			sQuery.Clear();
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".audit_trans_inv (usuario, fecha_hora,modulo_origen,aplicacion,");
			sQuery.AppendLine("referencia, asiento) VALUES (@usuario,getdate(),@modulo_origen,");
			sQuery.AppendLine("@aplicacion,@referencia,@asiento) SELECT SCOPE_IDENTITY()");

			#endregion

			#region PARAMETROS

			parametros.Add("@usuario," + "KOLEGIO");
			parametros.Add("@modulo_origen," + "FA");
			parametros.Add("@aplicacion," + "FAC#" + consecutivoFAC);
			parametros.Add("@referencia," + "Cliente: " + cliente);
			parametros.Add("@asiento,null");
			parametros.Add("@AUDIT," + 0);

			#endregion

			return OK;
		}

		public static bool queryInsertarTransacionInv(ref List<string> parametros, ref StringBuilder sQuery, object audit, string articulo,
			int linea, string contribuyente, string cantidad, decimal tipoCambio, decimal precio)
		{
			bool OK = true;
			decimal total = precio * int.Parse(cantidad);

			#region INSERT
			sQuery.Clear();
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".transaccion_inv (audit_trans_inv, consecutivo,nit, articulo, bodega,");
			sQuery.AppendLine(" tipo, subtipo, subsubtipo, naturaleza, cantidad, costo_tot_fisc_loc, costo_tot_fisc_dol,");
			sQuery.AppendLine("costo_tot_comp_loc, costo_tot_comp_dol, precio_total_local, precio_total_dolar, contabilizada, fecha,");
			sQuery.AppendLine(" ajuste_config, fecha_hora_transac)");

			sQuery.AppendLine("VALUES (@audit_trans_inv, @consecutivo,@nit, @articulo, @bodega,");
			sQuery.AppendLine("@tipo, @subtipo, @subsubtipo, @naturaleza, @cantidad, @costo_tot_fisc_loc, @costo_tot_fisc_dol,");
			sQuery.AppendLine("@costo_tot_comp_loc, @costo_tot_comp_dol, @precio_total_local, @precio_total_dolar, @contabilizada, GETDATE(),");
			sQuery.AppendLine(" @ajuste_config, getdate())");
			#endregion

			#region PARAMETROS
			parametros.Clear();
			parametros.Add("@audit_trans_inv," + audit);
			parametros.Add("@consecutivo," + linea);
			parametros.Add("@nit," + contribuyente);
			parametros.Add("@articulo," + articulo);
			parametros.Add("@bodega," + Globales.BODEGA_PEDIDOS);
			parametros.Add("@tipo," + "V");
			parametros.Add("@subtipo," + "D");
			parametros.Add("@subsubtipo," + "L");
			parametros.Add("@naturaleza," + "S");
			parametros.Add("@cantidad," + cantidad);
			parametros.Add("@costo_tot_fisc_loc," + 0);
			parametros.Add("@costo_tot_fisc_dol," + 0);
			parametros.Add("@costo_tot_comp_loc," + 0);
			parametros.Add("@costo_tot_comp_dol," + 0);
			parametros.Add("@precio_total_local," + total);
			parametros.Add("@precio_total_dolar," + Math.Round(total / tipoCambio, 2));
			parametros.Add("@contabilizada," + "N");
			parametros.Add("@ajuste_config," + "~VV~");
			#endregion

			return OK;
		}

		public static bool queryInsertarFactura(ref List<string> parametros, ref StringBuilder sQuery, DataTable dtCliente, string factura, object audit,
			string observaciones, string cobrador, string condicionPago, string vendedor, /*string consecutivo,*/ string comentario_cxc, string estable, string categoria, string actividadComercial, string versionnivel)
		{
			bool OK = true;


			#region INSERT

			sQuery.Clear();
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".FACTURA(TIPO_DOCUMENTO, FACTURA, AUDIT_TRANS_INV, ESTA_DESPACHADO, EN_INVESTIGACION");
			sQuery.AppendLine(", TRANS_ADICIONALES, ESTADO_REMISION, ASIENTO_DOCUMENTO, DESCUENTO_VOLUMEN, MONEDA_FACTURA, COMENTARIO_CXC");
			sQuery.AppendLine(", FECHA_DESPACHO, CLASE_DOCUMENTO, FECHA_RECIBIDO, PEDIDO, FACTURA_ORIGINAL, TIPO_ORIGINAL, COMISION_COBRADOR");
			sQuery.AppendLine(", TARJETA_CREDITO, TOTAL_VOLUMEN, TOTAL_PESO, MONTO_COBRADO, TOTAL_IMPUESTO1, FECHA, FECHA_ENTREGA, TOTAL_IMPUESTO2");
			sQuery.AppendLine(", PORC_DESCUENTO2, MONTO_FLETE, MONTO_SEGURO, MONTO_DOCUMENTACIO, TIPO_DESCUENTO1, TIPO_DESCUENTO2, MONTO_DESCUENTO1");
			sQuery.AppendLine(", MONTO_DESCUENTO2, PORC_DESCUENTO1, TOTAL_FACTURA, FECHA_PEDIDO, FECHA_ORDEN, TOTAL_MERCADERIA, COMISION_VENDEDOR");
			sQuery.AppendLine(", FECHA_HORA, TOTAL_UNIDADES, NUMERO_PAGINAS, TIPO_CAMBIO, ANULADA, MODULO, CARGADO_CG, CARGADO_CXC, EMBARCAR_A");
			sQuery.AppendLine(", DIREC_EMBARQUE, DIRECCION_FACTURA, MULTIPLICADOR_EV, OBSERVACIONES, VERSION_NP, MONEDA, NIVEL_PRECIO, COBRADOR");
			sQuery.AppendLine(", RUTA, USUARIO, CONDICION_PAGO, ZONA, VENDEDOR, CLIENTE_DIRECCION, CLIENTE_CORPORAC, CLIENTE_ORIGEN");
			sQuery.AppendLine(", CLIENTE, PAIS, SUBTIPO_DOC_CXC, TIPO_DOC_CXC, MONTO_ANTICIPO, TOTAL_PESO_NETO, FECHA_RIGE");
			sQuery.AppendLine(", PORC_INTCTE, USA_DESPACHOS, COBRADA, DESCUENTO_CASCADA, CONSECUTIVO, REIMPRESO, DIVISION_GEOGRAFICA1, DIVISION_GEOGRAFICA2, BASE_IMPUESTO1, BASE_IMPUESTO2");
			sQuery.AppendLine(", NOMBRE_CLIENTE, NOMBREMAQUINA, GENERA_DOC_FE,TASA_IMPOSITIVA_PORC,TASA_CREE1_PORC,TASA_CREE2_PORC,TASA_GAN_OCASIONAL_PORC, AJUSTE_REDONDEO, ACTIVIDAD_COMERCIAL, MONTO_OTRO_CARGO, MONTO_TOTAL_IVA_DEVUELTO, U_ESTABLE_KOL, U_CATEG_KOL)");
			sQuery.AppendLine("VALUES('F', @FACTURA, @AUDIT_TRANS_INV, 'N', 'N'");
			sQuery.AppendLine(", 'N', 'N', null, 0, @MONEDA_FACTURA, @COMENTARIO_CXC");
			sQuery.AppendLine(", GETDATE(), 'N', GETDATE(), null, null, null, 0");
			sQuery.AppendLine(", '', 0, 0, 0, 0, GETDATE(), CAST(GETDATE() AS DATE), 0");
			sQuery.AppendLine(", 0, 0, 0, 0, 'P', 'P', 0");
			sQuery.AppendLine(", 0, 0, 0, CAST(GETDATE() AS DATE), CAST(GETDATE() AS DATE), 0, 0");
			sQuery.AppendLine(", CAST(GETDATE() AS DATE), 1, 1, @TIPO_CAMBIO, 'N', 'FA', 'N', 'N', @CLIENTE");
			sQuery.AppendLine(", 'ND', @DIRECCION_FACTURA, 1, @OBSERVACIONES, @VERSION_NP, @MONEDA, @NIVEL_PRECIO, @COBRADOR");
			sQuery.AppendLine(", 'ND', 'KOLEGIO', @CONDICION_PAGO, 'ND', @VENDEDOR, @CLIENTE, @CLIENTE, @CLIENTE");
			sQuery.AppendLine(", @CLIENTE, @PAIS, @SUBTIPO_DOC_CXC, @TIPO_DOC_CXC, 0, 0, CAST(GETDATE() AS DATE)");
			sQuery.AppendLine(", 0, 'N', 'S', 'N', @CONSECUTIVO, 0, @DIVISION_GEOGRAFICA1, @DIVISION_GEOGRAFICA2, 0, 0");
			sQuery.AppendLine(", @NOMBRE_CLIENTE, @NOMBREMAQUINA, 'N', 0, 0, 0, 0, 0, @ACTIVIDAD_COMERCIAL, 0, 0, @U_ESTABLE_KOL, @U_CATEG_KOL)");
			#endregion

			#region PARAMETROS

			parametros.Clear();
			parametros.Add("@FACTURA," + factura);
			parametros.Add("@AUDIT_TRANS_INV," + audit);
			//if (dtCliente.Rows[0]["MONEDA_NIVEL"].ToString().Equals("CRC"))
			//    parametros.Add("@MONEDA_FACTURA," + "L");
			//else
			//    parametros.Add("@MONEDA_FACTURA," + "D");
			parametros.Add("@MONEDA_FACTURA," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
			parametros.Add("@COMENTARIO_CXC," + comentario_cxc);
			parametros.Add("@TIPO_CAMBIO," + decimal.Parse(dtCliente.Rows[0]["TIPO_CAMBIO"].ToString()));
			parametros.Add("@CLIENTE," + dtCliente.Rows[0]["CLIENTE"].ToString());
			if (!dtCliente.Rows[0]["DIRECCION"].ToString().Equals(""))
				parametros.Add("@DIRECCION_FACTURA," + dtCliente.Rows[0]["DIRECCION"].ToString());
			else
				parametros.Add("@DIRECCION_FACTURA,ND");
			parametros.Add("@OBSERVACIONES," + observaciones);
			//if (dtCliente.Rows[0]["MONEDA_NIVEL"].ToString().Equals("CRC"))
			//    parametros.Add("@MONEDA," + "L");
			//else
			//    parametros.Add("@MONEDA," + "D");
			parametros.Add("@MONEDA," + dtCliente.Rows[0]["MONEDA_NIVEL"].ToString());
			parametros.Add("@NIVEL_PRECIO," + dtCliente.Rows[0]["NIVEL_PRECIO"].ToString());
			if (!cobrador.Equals(""))
				parametros.Add("@COBRADOR," + cobrador);
			else
				parametros.Add("@COBRADOR," + "ND");
			parametros.Add("@CONDICION_PAGO," + condicionPago);
			parametros.Add("@VENDEDOR," + vendedor);
			parametros.Add("@PAIS," + dtCliente.Rows[0]["PAIS"].ToString());
			parametros.Add("@SUBTIPO_DOC_CXC," + 0);
			parametros.Add("@TIPO_DOC_CXC," + "FAC");
			parametros.Add("@CONSECUTIVO," + Globales.CONSECUTIVO_FACTURA);//revisar que consecutivo manda
			parametros.Add("@DIVISION_GEOGRAFICA1," + dtCliente.Rows[0]["DIVISION_GEOGRAFICA1"].ToString());
			parametros.Add("@DIVISION_GEOGRAFICA2," + dtCliente.Rows[0]["DIVISION_GEOGRAFICA2"].ToString());
			parametros.Add("@NOMBRE_CLIENTE," + dtCliente.Rows[0]["NOMBRE"].ToString());
			parametros.Add("@NOMBREMAQUINA," + Environment.MachineName);
			parametros.Add("@ACTIVIDAD_COMERCIAL," + actividadComercial);
			parametros.Add("@VERSION_NP," + versionnivel);
			if (!estable.Equals(""))
				parametros.Add("@U_ESTABLE_KOL," + estable);
			else
				parametros.Add("@U_ESTABLE_KOL,null");
			if (!categoria.Equals(""))
				parametros.Add("@U_CATEG_KOL," + categoria);
			else
				parametros.Add("@U_CATEG_KOL,null");

			#endregion


			return OK;
		}

		public static bool queryInsertarFacturaLinea(ref List<string> parametros, ref StringBuilder sQuery, DataTable dtImpuesto, int linea,
			string factura, string articulo, string cantidad, string precio, string descripcionArt, string comentarioLinea, string descuento)
		{
			bool OK = true;
			decimal total = decimal.Parse(precio) * int.Parse(cantidad);

			#region INSERT
			sQuery.Clear();
			sQuery.AppendLine("INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".FACTURA_LINEA(FACTURA, TIPO_DOCUMENTO, LINEA, BODEGA, COSTO_TOTAL_DOLAR");
			//sQuery.AppendLine(", ARTICULO, LOCALIZACION, LOTE, ANULADA, FECHA_FACTURA, CANTIDAD, PRECIO_UNITARIO, TOTAL_IMPUESTO1");
			sQuery.AppendLine(", ARTICULO, LOTE, ANULADA, FECHA_FACTURA, CANTIDAD, PRECIO_UNITARIO, TOTAL_IMPUESTO1");
			sQuery.AppendLine(", TOTAL_IMPUESTO2, DESC_TOT_LINEA, DESC_TOT_GENERAL, COSTO_TOTAL, PRECIO_TOTAL, DESCRIPCION, COMENTARIO");
			sQuery.AppendLine(", CANTIDAD_DEVUELT, DESCUENTO_VOLUMEN, TIPO_LINEA, CANTIDAD_ACEPTADA, CANT_NO_ENTREGADA, COSTO_TOTAL_LOCAL");
			sQuery.AppendLine(", PEDIDO_LINEA, MULTIPLICADOR_EV, LINEA_ORIGEN, CANT_DESPACHADA, COSTO_ESTIM_LOCAL, COSTO_ESTIM_DOLAR");
			sQuery.AppendLine(", CANT_ANUL_PORDESPA, MONTO_RETENCION, BASE_IMPUESTO1, BASE_IMPUESTO2, COSTO_TOTAL_COMP, COSTO_TOTAL_COMP_LOCAL");
			sQuery.AppendLine(", COSTO_TOTAL_COMP_DOLAR, COSTO_ESTIM_COMP_LOCAL, COSTO_ESTIM_COMP_DOLAR, CANT_DEV_PROCESO, TIPO_IMPUESTO1");
			sQuery.AppendLine(", TIPO_TARIFA1, PORC_EXONERACION, ES_SERVICIO_MEDICO, MONTO_DEVUELTO_IVA)");

			sQuery.AppendLine("VALUES(@FACTURA, @TIPO_DOCUMENTO, @LINEA, @BODEGA, @COSTO_TOTAL_DOLAR");
			//sQuery.AppendLine(", @ARTICULO, @LOCALIZACION, @LOTE, 'N', CAST(GETDATE() AS DATE), @CANTIDAD, @PRECIO_UNITARIO, @TOTAL_IMPUESTO1");
			sQuery.AppendLine(", @ARTICULO, @LOTE, 'N', CAST(GETDATE() AS DATE), @CANTIDAD, @PRECIO_UNITARIO, @TOTAL_IMPUESTO1");
			sQuery.AppendLine(", 0, 0, @DESC_TOT_GENERAL, 0, @PRECIO_TOTAL, @DESCRIPCION, @COMENTARIO");
			sQuery.AppendLine(", 0, 0, 'N', 0, 0, 0");
			sQuery.AppendLine(", @PEDIDO_LINEA, 1, 0, 0, 0, 0");
			sQuery.AppendLine(", 0, 0, 0, 0, 0, 0");
			sQuery.AppendLine(", 0, 0, 0, 0, @TIPO_IMPUESTO1");
			sQuery.AppendLine(", @TIPO_TARIFA1, 0, 'N', 0)");
			#endregion

			#region PARAMETROS
			parametros.Clear();
			parametros.Add("@FACTURA," + factura);
			parametros.Add("@TIPO_DOCUMENTO," + "F");
			parametros.Add("@LINEA," + (linea - 1));
			parametros.Add("@BODEGA," + Globales.BODEGA_PEDIDOS);
			parametros.Add("@COSTO_TOTAL_DOLAR," + 0);
			parametros.Add("@ARTICULO," + articulo);
			//parametros.Add("@LOCALIZACION,null");
			parametros.Add("@LOTE,ND");
			parametros.Add("@CANTIDAD," + cantidad);
			parametros.Add("@PRECIO_UNITARIO," + precio);
			parametros.Add("@TOTAL_IMPUESTO1," + dtImpuesto.Rows[0]["PORCENTAJE"].ToString());
			parametros.Add("@DESC_TOT_GENERAL," + descuento);
			parametros.Add("@PRECIO_TOTAL," + total);
			parametros.Add("@DESCRIPCION," + descripcionArt);

			if (comentarioLinea.Length > 100)//comentario factura linea no permite mayor a 100
				comentarioLinea = comentarioLinea.Substring(0, 99);

			parametros.Add("@COMENTARIO," + comentarioLinea);
			parametros.Add("@PEDIDO_LINEA," + linea);
			parametros.Add("@TIPO_IMPUESTO1," + dtImpuesto.Rows[0]["TIPO_IMPUESTO"].ToString());
			parametros.Add("@TIPO_TARIFA1," + dtImpuesto.Rows[0]["TIPO_TARIFA"].ToString());

			#endregion


			return OK;
		}

		#endregion

		
	}
}
