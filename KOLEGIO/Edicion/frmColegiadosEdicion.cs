using Framework;
using KOLEGIO.Edicion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmColegiadosEdicion : frmEdicion
	{
		private FuncsInternas fInternas;
		private byte[] Foto;
		private string oldValue = "";
		private bool onChanged = true;
		private decimal totalPlantillaCobro = 0;
		//private string PagoMutualidad = "";
		//private string Titulo = "";
		//private string Mutualidad = "";
		private DateTimePicker dtp = new DateTimePicker();
		private string Plantilla = "";
		//private DataGridViewUtilidades _dgvPlantillaUtil;
		//private string consecutivoColegiado = "";
		private string Usu = "";
		//private string fechVenciTarjeta = "";
		private bool requiereRevisionCondicion = false;
		private bool requiereDatosFallecidos = false;
		private bool esIncorporacion = false;
		private bool imagenPredeterminada = true;


		public frmColegiadosEdicion(List<string> valoresPk, string usuario)
			: base(valoresPk)
		{
			InitializeComponent();
			//btnProcesar.Visible = true;
			//EventoPlantillaMayusculas();
			this.fInternas = new FuncsInternas();
			Usu = usuario;
			dtpFechaIngreso.Value = DateTime.Now;
			dtpFechaNac.Value = DateTime.Now;
			dtpFechaSesionAprob.Value = DateTime.Now;
			dtpEmpresaDesde.Value = DateTime.Now;
			dtpEmpresaHasta.Value = DateTime.Now;
			dtpFechaSesionCond.Value = DateTime.Now;
			dtpFechaTitulo.Value = DateTime.Now;
			dtpFechaGradu.Value = DateTime.Now;
			dtpFechaModEmail.Value = DateTime.Now;
			dtpFechaModCelular.Value = DateTime.Now;
			dtpFechaModDireccion.Value = DateTime.Now;
			dtpTarjetaVencimiento.Format("MM/yyyy");
			dtpTarjetaVencimiento.Value = DateTime.Now;
			dtpRegresoCondicion.Value = DateTime.Now.AddDays(1);
			dtpFechaIngreso.ValueChanged(new EventHandler(OnNacimientoChanged));
			dtpFechaNac.ValueChanged(new EventHandler(OnNacimientoChanged));
			//cmbFormaPago.SelectedValueChanged(new EventHandler(OnFormaPagoChanged));
			cmbTipoTarjeta.SelectedValueChanged(new EventHandler(OnTipoTarjetaChanged));
			//DateTime fechVenc = DateTime.Now;
			//mtbVenciminetoTerjeta.Text = fechVenc.ToString("MM/yyyy");
			btnActualizar.Visible = true;

			//dtpTarjetaVencimiento.Value = DateTime.Now;
			//dtpTarjetaVencimiento.Format("MM/yyyy");
			//dtpTarjetaVencimiento.mostrarUpDown = true;
			Grados();
			Tarjetas();
			// cargarCondicion("I");//temp
			listaTiposPeritos();
			if (cmbTipoPerito.Count > 0)
				cmbTipoPerito.Index = 0;

			listaTiposRegentes();
			if (cmbTipoRegente.Count > 0)
				cmbTipoRegente.Index = 0;
			cmbTipoRegente.SelectedValueChanged(new EventHandler(OnTipoRegenteChanged));

			cargarDatos();
			//fInternas.actualizarMachotesColegiados(txtIdColegiado.Valor, txtCondicion.Valor, ref error);//Se actualiza por cualquier cambio de articulos realizado en las plantillas
			//cargarPlantilla();
			if (esIncorporacion && chkRenuncia.Checked)
				quitarArticuloFmsPlantilla();

			if (fInternas.registroDeshabilitado(txtIdColegiado.Valor, ref error))
			{
				btnGuardar.Visible = false;
				btnGuardarSalir.Visible = false;
				btnProcesar.Visible = false;
				toolStripSeparator4.Visible = false;
			}
			else
			{
				btnProcesar.Visible = true;
			}

            if (txtNumeColegiado.Valor == "ND")
            {
                btnSuspension.Visible = false;
                dgvSuspensiones.Visible = false;
            }
        }

		private void Grados()
		{
			DataTable dtCarreras = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoGrado,NombreGrado";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_GRADOS";
			listP.ORDERBY = "order by NombreGrado";

			if (Consultas.listarDatos(listP, ref dtCarreras, ref error))
			{
				if (dtCarreras.Rows.Count > 0)
				{
					clbGrados.DataSource(dtCarreras, "CodigoGrado", "NombreGrado");
					clbGrados.Index = -1;
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void Tarjetas()
		{
			DataTable dtGrados = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "TIPO_TARJETA";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "TIPO_TARJETA";
			listP.ORDERBY = "order by TIPO_TARJETA";

			if (Consultas.listarDatos(listP, ref dtGrados, ref error))
			{
				if (dtGrados.Rows.Count > 0)
				{
					cmbTipoTarjeta.DataSource(dtGrados, "TIPO_TARJETA", "TIPO_TARJETA");
					cmbTipoTarjeta.Valor = "VISA";
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void OnNacimientoChanged(object sender, EventArgs e)
		{
			//if (chkRenuncia.Checked)
			//{
			//    rtbRazon.ReadOnly = false;
			//    rtbRazon.BackColor = Color.Transparent;
			//    rtbRazon.Text = "Debe digitar la razón de la renuncia...";
			//    txtCalculoMutualidad.Valor = "0.00";
			//    txtCalculoMutualidadMontoRenunciar.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error).ToString();
			//    txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
			//    rtbRazon.Focus();
			//    rtbRazon.SelectText();
			//}
			//else
			//{
			//    rtbRazon.ReadOnly = true;
			//    rtbRazon.BackColor = Color.Gainsboro;
			//    rtbRazon.Clear();
			//    if (!txtEdad.Valor.Trim().Equals("") && !dtpFechaIngreso.Value.Equals(""))
			//        if (int.Parse(txtEdad.Valor) >= 25)
			//        {
			//            txtCalculoMutualidad.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error);
			//            txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
			//            txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
			//        }
			//        else
			//        {
			//            txtCalculoMutualidad.Valor = "0.00";
			//            txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
			//            txtCalculoMutualidadMeses.Valor = "0";
			//        }
			//}
		}


		private void OnFormaPagoChanged(object sender, EventArgs e)
		{
			//if (onChanged)
			//{
			//    if (cmbFormaPago.Texto == "Tarjeta")
			//    {
			//        txtEntidadFinanciera.ReadOnly = false;
			//        txtDescEntidadFinanciera.ReadOnly = false;
			//        txtTarjeta.ReadOnly = false;
			//        cmbTipoTarjeta.Enabled = true;
			//        dtpTarjetaVencimiento.Enabled = true;
			//        mtbVenciminetoTerjeta.Enabled = true;
			//        txtCobrador.ReadOnly = true;
			//        txtDescCobrador.ReadOnly = true;
			//    }
			//    else if(cmbFormaPago.Texto=="Planilla")
			//    {
			//        txtCobrador.ReadOnly = false;
			//        txtDescCobrador.ReadOnly = false;
			//        txtTarjeta.ReadOnly = true;
			//        cmbTipoTarjeta.Enabled = false;
			//        dtpTarjetaVencimiento.Enabled = false;
			//        mtbVenciminetoTerjeta.Enabled = false;
			//        txtEntidadFinanciera.ReadOnly = true;
			//        txtDescEntidadFinanciera.ReadOnly = true;
			//    }
			//    else
			//    {
			//        txtTarjeta.ReadOnly = true;
			//        cmbTipoTarjeta.Enabled = false;
			//        dtpTarjetaVencimiento.Enabled = false;
			//        mtbVenciminetoTerjeta.Enabled = false;
			//        txtEntidadFinanciera.ReadOnly = true;
			//        txtDescEntidadFinanciera.ReadOnly = true;
			//        txtCobrador.ReadOnly = true;
			//        txtDescCobrador.ReadOnly = true;
			//    }
			//}
		}

		private void OnTipoTarjetaChanged(object sender, EventArgs e)
		{
			if (onChanged)
			{
				if (cmbTipoTarjeta.Texto.Equals("AMEX"))
				{
					mtbTarjeta.Mask = "0000-000000-00000";
				}
				else
				{
					mtbTarjeta.Mask = "0000-0000-0000-0000";
				}

			}
		}

		protected override void imprimirReporte()
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
			{
				if (valoresPk.Count > 0)
				{
					if (Utilitario.BuscaForm("frmVisorRpt"))
					{
						DataTable dtRptCarteraGeneral = new DataTable();
						Listado listP = new Listado();
						listP.COLUMNAS = "*";
						listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
						listP.TABLA = "NV_INCORPORACION";
						listP.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";
						Cursor.Current = Cursors.WaitCursor;
						if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
						{
							if (dtRptCarteraGeneral.Rows.Count > 0)
							{

								frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "RPTIncorporacion.rpt", "Incorporación de Colegiado", Globales.NOMBRE_COMPAÑIA, new List<string>(), new List<string>());
								Cursor.Current = Cursors.Default;
								rptCG.ShowDialog();
							}
							else
							{
								error = "No hay información para generar el reporte.";
								MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}


		protected override void initInstance()
		{
			try
			{
				listar.TITULO_LISTADO = "Administración de Colegiados";
				lblPerfil.Text = "Perfil de Colegiado";

				//listar.COLUMNAS = "NumeroColegiado,Cedula,Nombre,FechaNacimiento,Condicion,Sexo,NumeroTarjeta,VencimientoTarjeta," +
				// "TipoTarjeta,Telefono1,Telefono2,Email1,Email2,Pais,Provincia,Canton,Distrito,Apartado,Direccion,FormaPago" +
				//",Cobrador,Categoria,SesionAprob,FechaSesionAprob,FechaIngreso,FondoMutualidad,RenunciaFondo,Razon,PagoMutualidad,PresentaTitulo,MontoTitulo,FechaPresentacion";
				//listar.COLUMNAS = "IdColegiado,NumeroColegiado,Cedula,Nombre,FechaNacimiento,Condicion,Sexo,NumeroTarjeta,VencimientoTarjeta," +
				// "TipoTarjeta,TelefonoCelular,TelefonoHabitacion,TelefonoOficina,Email,EmailAdicional,Pais,Provincia,Canton,Distrito,Apartado,Direccion" +
				//",Cobrador,Categoria,SesionAprob,FechaSesionAprob,SesionAprobIncorp,FechaIngreso,FondoMutualidad,RenunciaFondo,Razon,PresentaTitulo,MontoTitulo,FechaPresentacion";

				listar.COLUMNAS = "IdColegiado,NumeroColegiado,Cedula,Nombre,FechaNacimiento,Condicion,Sexo,NumeroTarjeta,VencimientoTarjeta," +
				 "TipoTarjeta,TelefonoCelular,TelefonoHabitacion,TelefonoOficina,Email,EmailAdicional,Pais,Provincia,Canton,Distrito,Apartado,Direccion,FormaPago" +
				",Cobrador,EntidadFinanciera,Categoria,SesionAprob,SesionIngreso,FechaSesionAprob,FechaIngreso,FondoMutualidad,RenunciaFondo,Razon,PresentaTitulo,MontoTitulo,FechaPresentacion,FechaRegresoCondicion,FechaFallecimiento,ChequeFallecimiento,ChequeBeneficiario,PagaCanonAerea,PagaCanonPlagui,PagaCanonSilve";
				listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
				listar.TABLA = "NV_COLEGIADO";

				//COLUMNAS PRIMARY KEY
				listar.COLUMNAS_PK.Add("IdColegiado");
				listar.VALORES_PK = valoresPk;
				armarFiltroPK(valoresPk);
				identificadorFormulario = "De Colegiados";

				insertar = Constantes.COLEGIADOS_INSERTAR;
				editar = Constantes.COLEGIADOS_EDITAR;
				borrar = Constantes.COLEGIADOS_BORRAR;
				seleccionar = Constantes.COLEGIADOS_SELECCIONAR;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un error inicializando la instancia del formulario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected override void actualizar()
		{
			Cursor.Current = Cursors.WaitCursor;
			cargarDatos();
			//cargarPlantilla();
			Cursor.Current = Cursors.Default;
		}

		protected override void cargarDatos()
		{
			tabControl.TabPages.Remove(tpAdjuntos);
			tabControl.TabPages.Add(tpAdjuntos);
			tabControl.TabPages.Remove(tpAdmin);
			tabControl.TabPages.Add(tpAdmin);

			txtIdColegiado.Valor = "ND";
			txtNumeColegiado.Valor = "ND";
			cmbSexo.agregarItems("Masculino");
			cmbSexo.agregarItems("Femenino");
			cmbSexo.Index = 0;

			//cmbFormaPago.agregarItems("Tarjeta");
			//cmbFormaPago.agregarItems("Planilla");
			//cmbFormaPago.agregarItems("Plataforma");
			//cmbFormaPago.Index = 2;

			dtpFechaIngreso.Enabled = false;
			dtpFechaModEmail.Enabled = false;
			dtpFechaModCelular.Enabled = false;
			dtpFechaModDireccion.Enabled = false;


			if (valoresPk.Count > 0)
			{
				if (Consultas.listarDatos(listar, ref dtDatos, ref error))
				{
					if (dtDatos.Rows.Count > 0)
					{
						//if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.EDICION_NUM_COLEGIADO))
						//    txtNumeColegiado.ReadOnly = false;
						//else
						//    txtNumeColegiado.ReadOnly = true;

						foreach (DataRow row in dtDatos.Rows)
						{
							//txtNumColegiado.Valor = row["IdColegiado"].ToString();
							txtNumeColegiado.Valor = row["NumeroColegiado"].ToString();
							txtIdColegiado.Valor = row["IdColegiado"].ToString();
							txtCedula.Valor = row["Cedula"].ToString();
							txtNombre.Valor = row["Nombre"].ToString();
							onChanged = false;
							if (!string.IsNullOrEmpty(row["FechaNacimiento"].ToString()))
							{
								dtpFechaNac.Value = DateTime.Parse(row["FechaNacimiento"].ToString());
								if (dtpFechaNac.Value >= DateTime.Now)
									txtEdad.Valor = "0";
								else
									txtEdad.Valor = "" + (int)((DateTime.Now - dtpFechaNac.Value).TotalDays / 365.242199);
							}
							onChanged = true;

							//if (row["FormaPago"].ToString() == "T")
							//	cmbFormaPago.Index = 0;
							//else
							//if (row["FormaPago"].ToString() == "P")
							//	cmbFormaPago.Index = 1;
							//else
							//	cmbFormaPago.Index = 2;

							if (!row["Condicion"].ToString().Equals(""))
							{
								cargarCondicion(row["Condicion"].ToString());
								if (!string.IsNullOrEmpty(row["FechaRegresoCondicion"].ToString()))
									dtpRegresoCondicion.Value = DateTime.Parse(row["FechaRegresoCondicion"].ToString());
								verificarConfigurablesCondicion();
							}
							//cargarPlantilla();//Ya la carga en el metodo cargarCondicion-joseArias

							if (row["Sexo"].ToString() == "M")
								cmbSexo.Index = 0;
							else
								cmbSexo.Index = 1;

							//txtTarjeta.Valor = row["NumeroTarjeta"].ToString();
							mtbTarjeta.Text = row["NumeroTarjeta"].ToString();
							cmbTipoTarjeta.Valor = row["TipoTarjeta"].ToString();
							//if (!row["VencimientoTarjeta"].ToString().Equals(""))
							//    dtpTarjetaVencimiento.Value = DateTime.Parse(row["VencimientoTarjeta"].ToString());
							///fechVenciTarjeta = DateTime.Parse(row["VencimientoTarjeta"].ToString()).ToString("MM/yyyy");
							if (!row["VencimientoTarjeta"].ToString().Equals(""))
							{
								//dtpTarjetaVencimiento.Value = DateTime.Parse(row["VencimientoTarjeta"].ToString());
								//dtpTarjetaVencimiento.Checked = true;
								mtbVenciminetoTerjeta.Text = DateTime.Parse(row["VencimientoTarjeta"].ToString()).ToString("MM/yyyy");
							}


							//mtbVenciminetoTerjeta.Text = row["VencimientoTarjeta"].ToString();

							txtTelefono1.Valor = row["TelefonoCelular"].ToString();
							txtTelefono2.Valor = row["TelefonoHabitacion"].ToString();
							txtTelefono3.Valor = row["TelefonoOficina"].ToString();
							txtEmail1.Valor = row["Email"].ToString();
							txtEmail2.Valor = row["EmailAdicional"].ToString();

							txtPais.Valor = row["Pais"].ToString();
							txtProvincia.Valor = row["Provincia"].ToString();
							txtCanton.Valor = row["Canton"].ToString();
							txtDistrito.Valor = row["Distrito"].ToString();

							txtApartado.Valor = row["Apartado"].ToString();
							rtbDireccion.Text = row["Direccion"].ToString();
							if (!row["Cobrador"].ToString().Equals(""))
							{
								cargarCobrador(row["Cobrador"].ToString());
								//lblCobrador.Visible = true;
								//txtCobrador.Visible = true;
								//txtDescCobrador.Visible = true;
								//cmbFormaPago.Index = 1;//Quitar cuando se tenga registrado todos los colegiado con su forma de pago
							}
							if (!row["EntidadFinanciera"].ToString().Equals(""))
							{
								cargarEntidad(row["EntidadFinanciera"].ToString());
								//lblEntidadFinan.Visible = true;
								//txtEntidadFinanciera.Visible = true;
								//txtDescEntidadFinanciera.Visible = true;
								//cmbFormaPago.Index = 0;//Quitar cuando se tenga registrado todos los colegiado con su forma de pago
							}
							cargarCategoria(row["Categoria"].ToString());
							//txtCategoria.ReadOnly = true;
							txtSesionCond.Valor = row["SesionAprob"].ToString();
							if (!string.IsNullOrEmpty(row["FechaSesionAprob"].ToString()))
								dtpFechaSesionCond.Value = DateTime.Parse(row["FechaSesionAprob"].ToString());

							//txtCodigoSesionIncorporacion.Valor = row["SesionAprobIncorp"].ToString();
							txtCodigoSesionIncorporacion.Valor = row["SesionIngreso"].ToString();
							if (!string.IsNullOrEmpty(row["FechaIngreso"].ToString()))
								dtpFechaIngreso.Value = DateTime.Parse(row["FechaIngreso"].ToString());


							buscaPais(txtPais.Valor, "P");
							buscaProvincia(txtProvincia.Valor);
							buscaCanton(txtCanton.Valor);
							buscaDistrito(txtDistrito.Valor);
							// //buscaFrecuencia(txtFrecuencia.Valor);
							// //if (row["FondoMutualidad"].ToString().Equals(""))
							// //{
							//     //if (!row["FechaIngreso"].ToString().Equals("") && !row["FechaNacimiento"].ToString().Equals(""))
							//     //    txtCalculoMutualidad.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value,ref error);
							//     //else
							//     //    txtCalculoMutualidad.Valor = decimal.Parse(row["FondoMutualidad"].ToString()).ToString("N2");
							// //}
							// //else { 
							// //    txtCalculoMutualidad.Valor = decimal.Parse(row["FondoMutualidad"].ToString()).ToString("N2");
							// //}

							if (row["RenunciaFondo"].ToString().Equals("S"))
							{
								chkRenuncia.Checked = true;
								rtbRazon.Text = row["Razon"].ToString();
								//txtCalculoMutualidad.Valor = "0.00";
								//if (!row["FechaIngreso"].ToString().Equals("") && !row["FechaNacimiento"].ToString().Equals(""))
								//{
								//	txtCalculoMutualidadMontoRenunciar.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error).ToString();
								//	txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
								//}
							}
							//else
							//{
							//	if (!row["FechaIngreso"].ToString().Equals("") && !row["FechaNacimiento"].ToString().Equals(""))
							//	{
							//		txtCalculoMutualidad.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error);
							//		txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
							//		txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
							//	}
							//}
							///* PagoMutualidad = row["PagoMutualidad"].ToString();
							// if (PagoMutualidad == "S")
							//     chkRenuncia.Enabled = false;*/

							if (row["PresentaTitulo"].ToString().Equals("N"))
							{
								rbSiTitulo.Checked = false;
								rbNoTitulo.Checked = true;
							}

							if (row["MontoTitulo"].ToString().Equals(""))
								txtCalculoTitulo.Valor = row["MontoTitulo"].ToString();
							else
								txtCalculoTitulo.Valor = decimal.Parse(row["MontoTitulo"].ToString()).ToString("N2");

							if (!string.IsNullOrEmpty(row["FechaPresentacion"].ToString()))
								dtpFechaTitulo.Value = DateTime.Parse(row["FechaPresentacion"].ToString());

							if (!string.IsNullOrEmpty(row["FechaFallecimiento"].ToString()))
								dtpFallecimiento.Value = DateTime.Parse(row["FechaFallecimiento"].ToString());

							txtCheque.Valor = row["ChequeFallecimiento"].ToString();


							txtBeneficiarioCheque.Valor = row["ChequeBeneficiario"].ToString();
							cargarBeneficiario(txtBeneficiarioCheque.Valor);

							if (row["PagaCanonAerea"].ToString() == "S")
								rbPagCanAereaSI.Checked = true;
							else
								rbPagCanAereaNO.Checked = true;

							if (row["PagaCanonPlagui"].ToString() == "S")
								rbPagCanPlaguiSI.Checked = true;
							else
								rbPagCanPlaguiNO.Checked = true;

							if (row["PagaCanonSilve"].ToString() == "S")
								rbPagCanSilveSI.Checked = true;
							else
								rbPagCanSilveNO.Checked = true;

							if (requiereRevisionCondicion)
							{
								revisarRegresoCondicion();
							}

							//grbTituloObligatorio.Enabled = false;
							txtCondicion.ReadOnly = true;
							txtCategoria.ReadOnly = true;
							lblPerfil.Text = "Perfil de Colegiado: " + txtNumeColegiado.Valor.Trim() + "-" + txtNombre.Valor;
						}
						//dtpFechaIngreso.Enabled = false;
						//txtCodigoSesionIncorporacion.ReadOnly = true;
						cargarFechaModBasicos();
						cargarFoto();
						cargarBeneficiarios();
						cargarHistorialAcademico();
						cargarHistorialLaboral();
						cargarViaAerea();
						cargarPlaguicidas();
						cargarVidaSilvestre();
						cargarGestionCobro();
						cargarPeritajes();
						cargarRegencias();
						cargarEspecialidades();
						cargarCamposEspecialidad();
						cargarHistorialCambioCondicion();
						cargarVidaSilvestreR();
						verificarCanones();

						if (txtNumeColegiado.Valor == "ND")
						{
                            btnSuspension.Visible = false;
                            dgvSuspensiones.Visible = false;
                        }
						else
						{
							btnSuspension.Visible = true;
							dgvSuspensiones.Visible = true;
                            cargarSuspensiones();
                        }
						

                    }
				}
				else
				{
					MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void cargarVidaSilvestreR()
		{
			string sQuery = "select t1.CodigoSilvestre, t2.NombreSilvestre, t2.DescripcionSilvestre from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SILVESTRE t1 " +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_VIDA_SILVESTRE t2 on t2.CodigoSilvestre = t1.CodigoSilvestre where t1.IdColegiado = '" + txtIdColegiado.Valor + "'";

			DataTable dt = new DataTable();

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				dgvVidaSilvestreR.Rows.Clear();
				foreach (DataRow row in dt.Rows)
				{
					dgvVidaSilvestreR.Rows.Add(row["CodigoSilvestre"].ToString(), row["NombreSilvestre"].ToString(), row["DescripcionSilvestre"].ToString());
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarPeritajes()
		{
			DataTable dt = new DataTable();
			string sQuery = "SELECT t1.Tipo,T1.CodigoEmpresa,(select NombreEmpresa from " + Consultas.sqlCon.COMPAÑIA + ".NV_EMPRESAS where CodigoEmpresa = T1.CodigoEmpresa) as NombreEmpresa,T1.Cobrador,T2.NOMBRE,T1.CursoAvaluosPeritaje,T1.NumSesionAprobacion," +
							" T1.FechaSesionAprobacion,T1.NumSesionRenovacion,T1.FechaSesionRenovacion,T1.NumSesionPerdida,T1.FechaSesionPerdida,T1.Observaciones FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS T1" +
							" JOIN " + Consultas.sqlCon.COMPAÑIA + ".COBRADOR T2 ON T1.Cobrador = T2.COBRADOR" +
							// " LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_EMPRESAS T3 ON T1.CodigoEmpresa = T3.CodigoEmpresa" +
							" WHERE IdColegiado = '" + txtIdColegiado.Valor + "'";

			//cmbTipoPerito.agregarItems("Forestal");
			//cmbTipoPerito.agregarItems("Agropecuario");
			//cmbTipoPerito.Index = 0;

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{

					foreach (DataRow row in dt.Rows)
					{

						//if (row["Tipo"].ToString() == "F")
						//    cmbTipoPerito.Index = 0;
						//else
						//    cmbTipoPerito.Index = 1;

						cmbTipoPerito.Valor = row["Tipo"].ToString();

						txtInstitucion.Valor = row["CodigoEmpresa"].ToString();
						txtNombreInstitucion.Valor = row["NombreEmpresa"].ToString();
						//buscaInstitucion(txtInstitucion.Valor);

						txtCobradorPeritaje.Valor = row["Cobrador"].ToString();
						txtCobradorPeritajeNombre.Valor = row["NOMBRE"].ToString();
						//buscaCobrador(txtCobrador.Valor);
						if (row["CursoAvaluosPeritaje"].ToString() == "S")
						{
							chkCursoPeritaje.Checked = true;
							habilitarValoresPeritaje();
						}
						else
							chkCursoPeritaje.Checked = false;

						txtSesionAprobPeritaje.Valor = row["NumSesionAprobacion"].ToString();
						if (row["FechaSesionAprobacion"].ToString() != "")
							dtpSesionAprobPeritaje.Value = DateTime.Parse(row["FechaSesionAprobacion"].ToString());

						txtSesionRenov.Valor = row["NumSesionRenovacion"].ToString();
						if (row["FechaSesionRenovacion"].ToString() != "")
						{
							dtpRenovacion.Checked = true;
							dtpRenovacion.Value = DateTime.Parse(row["FechaSesionRenovacion"].ToString());
						}

						txtSesionPerdidaPeritaje.Valor = row["NumSesionPerdida"].ToString();
						if (row["FechaSesionPerdida"].ToString() != "")
						{
							dtpSesionPerdidaPeritaje.Checked = true;
							dtpSesionPerdidaPeritaje.Value = DateTime.Parse(row["FechaSesionPerdida"].ToString());
						}

						rtbObservaciones.Text = row["Observaciones"].ToString();
					}
					//chkCursoPeritaje.Enabled = false;
				}
				//else
				//    btnNuevoPerito.Enabled = true;
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarRegencias()
		{
			DataTable dt = new DataTable();
			string sQuery = "SELECT T1.AvaluoCursos,T1.Cobrador,T2.NOMBRE,T1.SesionAprobacion,T1.FechaSesionAprobacion,T1.SesionPerdida," +
				"T1.FechaSesionPerdida, t1.Tipo, t1.NumeroPoliza,t1.FechaPoliza,t1.MontoPoliza,t1.FechaVencimientoPoliza FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".COBRADOR T2 " +
				"ON T1.Cobrador=T2.COBRADOR WHERE T1.NumeroColegiado='" + txtIdColegiado.Valor + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					//btnAsignarEstablecimiento.Enabled = true;
					foreach (DataRow row in dt.Rows)
					{
						txtCobradorRegente.Valor = row["Cobrador"].ToString();
						txtCobradorNombre.Valor = row["Nombre"].ToString();
						txtSesionAprobacion.Valor = row["SesionAprobacion"].ToString();
						txtSesionPerdida.Valor = row["SesionPerdida"].ToString();
						if (row["AvaluoCursos"].ToString() == "S")
						{
							chkCurso.Checked = true;
							habilitarValoresRegente();
						}
						else
							chkCurso.Checked = false;

						if (row["FechaSesionAprobacion"].ToString() != "")
							dtpAprobacion.Value = DateTime.Parse(row["FechaSesionAprobacion"].ToString());

						if (row["FechaSesionPerdida"].ToString() != "")
						{
							dtpPerdida.Checked = true;
							dtpPerdida.Value = DateTime.Parse(row["FechaSesionPerdida"].ToString());
						}

						cmbTipoRegente.Valor = row["Tipo"].ToString();

						verificarSiRequierePoliza();

						txtNPoliza.Valor = row["NumeroPoliza"].ToString();
						if (!row["MontoPoliza"].ToString().Equals(""))
							txtMonto.Valor = decimal.Parse(row["MontoPoliza"].ToString()).ToString("N2");

						if (row["FechaPoliza"].ToString() != "")
							dtpFecha.Value = DateTime.Parse(row["FechaPoliza"].ToString());
						if (row["FechaVencimientoPoliza"].ToString() != "")
							dtpVencimiento.Value = DateTime.Parse(row["FechaVencimientoPoliza"].ToString());
					}

					//sQuery = "SELECT T1.CodigoEstablecimiento,T2.Nombre,T1.CodigoCategoria,T3.NombreCategoria,T1.Cobrador,t4.NOMBRE as NomCobrador,T1.FechaAprobacion,T1.SesionAprobacion,CASE T1.Estado WHEN 'A' THEN 'Activo' else 'Inactivo' END AS Estado FROM " + Consultas.sqlCon.COMPAÑIA +
					sQuery = "SELECT T1.CodigoEstablecimiento,T2.Nombre,T1.CodigoCategoria,T3.NombreCategoria,T1.Cobrador,t4.NOMBRE as NomCobrador,T1.FechaAprobacion,T1.SesionAprobacion,T1.Estado FROM " + Consultas.sqlCon.COMPAÑIA +
					   ".NV_REGENTES_ESTABLECIMIENTOS T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS T2 ON T1.CodigoEstablecimiento=T2.NumRegistro " +
					   "JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS T3 ON T1.CodigoCategoria=T3.CodigoCategoria LEFT JOIN " + Consultas.sqlCon.COMPAÑIA + ".COBRADOR T4 ON T1.Cobrador=T4.COBRADOR " +
					   "WHERE T1.NumeroColegiado='" + txtIdColegiado.Valor + "'";

					DataTable dtRegentes = new DataTable();
					if (Consultas.fillDataTable(sQuery, ref dtRegentes, ref error))
					{
						dgvEstablecimientos.Rows.Clear();
						if (dtRegentes.Rows.Count > 0)
						{
							foreach (DataRow row in dtRegentes.Rows)
							{

								dgvEstablecimientos.Rows.Add(row["CodigoEstablecimiento"].ToString(), row["Nombre"].ToString(),
									row["CodigoCategoria"].ToString(), row["NombreCategoria"].ToString(), row["Cobrador"].ToString(), row["NomCobrador"].ToString(), /*row["Estado"].ToString()*/fInternas.obtenerEstado(row["Estado"].ToString()),
									row["SesionAprobacion"].ToString(), row["FechaAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaAprobacion"].ToString()).ToString("dd/MM/yyyy") : "");
							}
							//deshabilitarEstadoRegente();
							colorearInactivos();
						} //else
						  //btnAsignarEstablecimiento.Enabled = true;
					}
					else
						MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//chkCurso.Enabled = false;
				}
				//else
				//{
				//    btnNuevoRegente.Enabled = true;
				//}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void colorearInactivos()
		{
			foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
			{
				if (dgvEstablecimientos.Rows[row.Index].Cells["colEstadoEst"].Value.ToString() == "Inactivo")
					dgvEstablecimientos.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
				else
					dgvEstablecimientos.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
			}
		}

		private void deshabilitarEstadoRegente()
		{
			foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
			{
				bool requiereDeshabilitarEstado = false;

				verificarEstadoEstablecimiento(row.Cells["colCodigoEstablecimiento"].Value.ToString(), ref requiereDeshabilitarEstado);

				if (requiereDeshabilitarEstado)
				{
					row.Cells["colEstadoEst"].ReadOnly = true;
				}
			}
		}

		private void verificarEstadoEstablecimiento(string estable, ref bool flat)
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "RequiereRegresoEstado,EsEstadoCierre";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_ESTADOS";
			listA.FILTRO = "where CodigoEstado = (select Estado from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = '" + estable + "')";
			//listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					if (dt.Rows[0]["RequiereRegresoEstado"].ToString() == "S" || dt.Rows[0]["EsEstadoCierre"].ToString() == "S")
						flat = true;
					else
						flat = false;
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarPlaguicidas()
		{
			DataTable dt = new DataTable();
			string sQuery = "select T1.CodigoCampo,T1.PagaCanon,T1.NumSesionAprobacion,T1.FechaSesionAprobacion,T1.NumSesionRenovacion,T1.FechaSesionRenovacion,T1.NumSesionPerdida,T1.FechaSesionPerdida,T1.Observaciones,T1.Activo,(select NombreCampo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMPOS_INVESTIGACION where CodigoCampo = T1.CodigoCampo) as Nombre " +
							"from " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO T1 where T1.IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{

					DataTable dtPlagui = new DataTable();
					if (Consultas.fillDataTable(sQuery, ref dtPlagui, ref error))
					{
						dgvInvestigacionPlaguicidas.Rows.Clear();
						if (dtPlagui.Rows.Count > 0)
						{
							foreach (DataRow row in dtPlagui.Rows)
							{

								dgvInvestigacionPlaguicidas.Rows.Add(row["CodigoCampo"].ToString(), row["Nombre"].ToString(),
									row["PagaCanon"].ToString() == "S" ? "Si" : "No", row["NumSesionAprobacion"].ToString(),
									row["FechaSesionAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaSesionAprobacion"].ToString()).ToString("dd/MM/yyyy") : "",
									row["NumSesionRenovacion"].ToString(),
									row["FechaSesionRenovacion"].ToString() != "" ? DateTime.Parse(row["FechaSesionRenovacion"].ToString()).ToString("dd/MM/yyyy") : "",
									row["NumSesionPerdida"].ToString(),
									row["FechaSesionPerdida"].ToString() != "" ? DateTime.Parse(row["FechaSesionPerdida"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString(), bool.Parse(row["Activo"].ToString()));
							}

							if (dgvInvestigacionPlaguicidas.RowCount > 0)
							{
								dgvInvestigacionPlaguicidas.CurrentCell = dgvInvestigacionPlaguicidas[0, 0];
								if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
									deshabilitarActivoPlagui();
								//cargarInfoEstablecimiento(dgvEstablecimientos[0, 0].Value.ToString());
							}
						}
					}
					else
						MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}

			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarViaAerea()
		{
			DataTable dt = new DataTable();
			string sQuery = "select T1.CodigoCultivo,T1.PagaCanon,T1.NumSesionAprobacion,T1.FechaSesionAprobacion,T1.NumSesionRenovacion,T1.FechaSesionRenovacion,T1.NumSesionPerdida,T1.FechaSesionPerdida,T1.Observaciones,T1.Activo,(select NombreCultivo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CULTIVOS_RECETAS where CodigoCultivo = T1.CodigoCultivo) as Nombre " +
							"from " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO T1 where T1.IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{

					DataTable dtAerea = new DataTable();
					if (Consultas.fillDataTable(sQuery, ref dtAerea, ref error))
					{
						dgvViaAerea.Rows.Clear();
						if (dtAerea.Rows.Count > 0)
						{
							foreach (DataRow row in dtAerea.Rows)
							{

								dgvViaAerea.Rows.Add(row["CodigoCultivo"].ToString(), row["Nombre"].ToString(),
									row["Observaciones"].ToString(), row["PagaCanon"].ToString() == "S" ? "Si" : "No", row["NumSesionAprobacion"].ToString(),
									row["FechaSesionAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaSesionAprobacion"].ToString()).ToString("dd/MM/yyyy") : "",
									row["NumSesionRenovacion"].ToString(),
									row["FechaSesionRenovacion"].ToString() != "" ? DateTime.Parse(row["FechaSesionRenovacion"].ToString()).ToString("dd/MM/yyyy") : "",
									row["NumSesionPerdida"].ToString(),
									row["FechaSesionPerdida"].ToString() != "" ? DateTime.Parse(row["FechaSesionPerdida"].ToString()).ToString("dd/MM/yyyy") : "", bool.Parse(row["Activo"].ToString()));
							}

							if (dgvViaAerea.RowCount > 0)
							{
								dgvViaAerea.CurrentCell = dgvViaAerea[0, 0];
								if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
									deshabilitarActivoViaAerea();
								//cargarInfoEstablecimiento(dgvEstablecimientos[0, 0].Value.ToString());
							}
						}
					}
					else
						MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}

			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarVidaSilvestre()
		{
			DataTable dt = new DataTable();
			string sQuery = "select T1.CodigoSilvestre,T1.PagaCanon,T1.NumSesionAprobacion,T1.FechaSesionAprobacion,T1.NumSesionRenovacion,T1.FechaSesionRenovacion,T1.NumSesionPerdida,T1.FechaSesionPerdida,T1.Observaciones,T1.Activo,(select NombreSilvestre from " + Consultas.sqlCon.COMPAÑIA + ".NV_VIDA_SILVESTRE where CodigoSilvestre = T1.CodigoSilvestre) as Nombre " +
							"from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SILVESTRE T1 where T1.IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{

					DataTable dtSilve = new DataTable();
					if (Consultas.fillDataTable(sQuery, ref dtSilve, ref error))
					{
						dgvVidaSilvestre.Rows.Clear();
						if (dtSilve.Rows.Count > 0)
						{
							foreach (DataRow row in dtSilve.Rows)
							{

								dgvVidaSilvestre.Rows.Add(row["CodigoSilvestre"].ToString(), row["Nombre"].ToString(),
									row["PagaCanon"].ToString() == "S" ? "Si" : "No", row["NumSesionAprobacion"].ToString(),
									row["FechaSesionAprobacion"].ToString() != "" ? DateTime.Parse(row["FechaSesionAprobacion"].ToString()).ToString("dd/MM/yyyy") : "",
									row["NumSesionRenovacion"].ToString(),
									row["FechaSesionRenovacion"].ToString() != "" ? DateTime.Parse(row["FechaSesionRenovacion"].ToString()).ToString("dd/MM/yyyy") : "",
									row["NumSesionPerdida"].ToString(),
									row["FechaSesionPerdida"].ToString() != "" ? DateTime.Parse(row["FechaSesionPerdida"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString(), bool.Parse(row["Activo"].ToString()));
							}

							if (dgvVidaSilvestre.RowCount > 0)
							{
								dgvVidaSilvestre.CurrentCell = dgvVidaSilvestre[0, 0];
								if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
									deshabilitarActivoSilvestre();
								//cargarInfoEstablecimiento(dgvEstablecimientos[0, 0].Value.ToString());
							}
						}
					}
					else
						MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}

			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void deshabilitarActivoViaAerea()
		{
			foreach (DataGridViewRow row in dgvViaAerea.Rows)
			{
				row.Cells[10].ReadOnly = true;
			}
		}

		private void deshabilitarActivoPlagui()
		{
			foreach (DataGridViewRow row in dgvInvestigacionPlaguicidas.Rows)
			{
				row.Cells[10].ReadOnly = true;
			}
		}

		private void deshabilitarActivoSilvestre()
		{
			foreach (DataGridViewRow row in dgvVidaSilvestre.Rows)
			{
				row.Cells[10].ReadOnly = true;
			}
		}

		protected override bool validarDatos(ref string errores)
		{

			if (txtCedula.Valor.Trim() == "")
			{
				errores = "Debe digitar el número de cédula del colegiado.";
				txtCedula.Focus();
				return false;
			}

			if (txtNumeColegiado.Valor.Trim() == "")
			{
				errores = "Debe digitar el número de colegiado para colegiado.";
				txtNumeColegiado.Focus();
				return false;
			}

			if (txtCedula.Valor.Trim() == "ND" || txtCedula.Valor.Trim() == "nd")
			{
				errores = "El número de cédula del colegiado no puede ser ND.";
				txtCedula.Focus();
				return false;
			}

			if (txtNumeColegiado.Valor.Trim() == "ND" || txtNumeColegiado.Valor.Trim() == "nd")
			{
				errores = "El número de colegiado no pueder ser ND.";
				txtNumeColegiado.Focus();
				return false;
			}

			if (txtNombre.Valor.Trim() == "")
			{
				errores = "Debe digitar el nombre del colegiado.";
				txtNombre.Focus();
				return false;
			}

			if (txtPais.Valor.Trim() == "")
			{
				errores = "Debe especificar el país del colegiado.";
				txtPais.Focus();
				return false;
			}

			if (txtCategoria.Valor.Trim() == "")
			{
				errores = "Debe especificar la categoría del colegiado.";
				txtCategoria.Focus();
				return false;
			}

			if (txtCondicion.Valor.Trim() == "")
			{
				errores = "Debe especificar la condición del colegiado.";
				txtCondicion.Focus();
				return false;
			}

			if (string.IsNullOrEmpty(txtCobrador.Valor.Trim()))
			{
				errores = "Debe especificar el cobrador del colegiado.";
				txtCobrador.Focus();
				return false;
			}
			
			string tarjetaSinGUiones = mtbTarjeta.Text.Replace("-", "");
			tarjetaSinGUiones = tarjetaSinGUiones.Trim();

			if (!mtbTarjeta.MaskFull && tarjetaSinGUiones.Length > 0)
			{
				errores = "Debe completar el número de la tarjeta.";
				mtbTarjeta.Focus();
				return false;
			}

			if (mtbTarjeta.MaskFull)
			{
				if (!mtbVenciminetoTerjeta.MaskFull)
				{
					errores = "Debe especificar la fecha de vencimiento de la tarjeta.";
					mtbVenciminetoTerjeta.Focus();
					return false;
				}
			}

			//if (chkCursoPeritaje.Checked)
			//{
			//    return validarPeritaje(ref errores);
			//}
			//if(mtbVenciminetoTerjeta.Text.Length > 6) { 
			//    fechVenciTarjeta = "01/" + mtbVenciminetoTerjeta.Text;
			//    if (!DateTime.TryParse(fechVenciTarjeta, out DateTime fecha))
			//    {
			//        errores = "La fecha de vencimiento de la tarjeta es incorrecta.";
			//        mtbVenciminetoTerjeta.Focus();
			//        return false;
			//    }
			//}
			//else
			//{
			//    //errores = "La fecha de vencimiento de la tarjeta es incorrecta.";
			//    //mtbVenciminetoTerjeta.Focus();
			//    //return false;
			//}

			//if (dgvHistorialAcademico.Rows.Count == 0)
			//{
			//    errores = "Debe registrar al menos un historial académico para el colegiado.";
			//    txtCategoria.Focus();
			//    return false;
			//}

			if (txtCategoria.Valor.Trim() == "")
			{
				errores = "Debe especificar la categoría del colegiado.";
				txtCategoria.Focus();
				return false;
			}

			foreach (DataGridViewRow row in dgvGestionCobro2.Rows)
			{
				if (row.Cells["colEstado"].Value == null || string.IsNullOrEmpty(row.Cells["colEstado"].Value.ToString()))
				{
					tabControl.SelectedTab = tpGestionCobro;
					errores = "Debe seleccionar un estado para gestion de cobro en la fila " + (row.Index + 1) + ".";
					return false;
				}
				//if (!Convert.ToBoolean(row.Cells["colActivoArticulo"].Value) && (row.Cells["colDesdeArticulo"].Value.ToString() == string.Empty || row.Cells["colHastaArticulo"].Value.ToString() == string.Empty))
				//{
				//	tabControl.SelectedTab = tpPlantilla;
				//	errores = "Debe especificar el rango de fechas si el concepto se encuentra inactivo.";
				//	if (row.Cells["colDesdeArticulo"].Value.ToString() == string.Empty)
				//		dgvPlantilla.Rows[row.Index].Cells["colDesdeArticulo"].Selected = true;
				//	else
				//		dgvPlantilla.Rows[row.Index].Cells["colHastaArticulo"].Selected = true;
				//	return false;
				//}

				//if (!Convert.ToBoolean(row.Cells["colActivoArticulo"].Value) && (DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()) > DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString()) || DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()) > DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString())))
				//{
				//	tabControl.SelectedTab = tpPlantilla;
				//	errores = "El rango de fechas debe tener un formato ascendente.";
				//	if (DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()) > DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString()))
				//		dgvPlantilla.Rows[row.Index].Cells["colDesdeArticulo"].Selected = true;
				//	else
				//		dgvPlantilla.Rows[row.Index].Cells["colHastaArticulo"].Selected = true;
				//	return false;
				//}

			}

			//if (txtEmail1.Valor.Trim() != "")
			//{
			//    if (!Utilitario.comprobarFormatoEmail(txtEmail1.Valor.Trim()))
			//    {
			//        error = "El formato del correo eléctronico no es válido.";
			//        txtEmail1.Focus();
			//        return false;
			//    }
			//}
			//else
			//{
			//    error = "Debe especificar una cuenta de correo electrónico.";
			//    txtEmail1.Focus();
			//    return false;
			//}

			//if (txtEmail2.Valor.Trim() != "")
			//{
			//    if (!Utilitario.comprobarFormatoEmail(txtEmail2.Valor.Trim()))
			//    {
			//        error = "El formato del correo eléctronico adicional no es válido.";
			//        txtEmail2.Focus();
			//        return false;
			//    }
			//}
			//else
			//{
			//    error = "Debe especificar una cuenta de correo electrónico adicional.";
			//    txtEmail2.Focus();
			//    return false;
			//}

			// onChanged = false;
			//// _dgvPlantillaUtil.CellEndEdit(ref dgvPlantilla);
			// onChanged = true;
			// if(dgvPlantilla.Rows.Count == 0)
			// {
			//     tabControl.SelectedTab = tpPlantilla;
			//     errores = "No existe una plantilla de cobro para la condición actual.";
			//     return false;
			// }
			//foreach (DataGridViewRow row in dgvPlantilla.Rows)
			//{
			//    if (!Convert.ToBoolean(row.Cells["colActivoArticulo"].Value) && (row.Cells["colDesdeArticulo"].Value.ToString() == string.Empty || row.Cells["colHastaArticulo"].Value.ToString() == string.Empty))
			//    {
			//        tabControl.SelectedTab = tpPlantilla;
			//        errores = "Debe especificar el rango de fechas si el concepto se encuentra inactivo.";
			//        if (row.Cells["colDesdeArticulo"].Value.ToString() == string.Empty)
			//            dgvPlantilla.Rows[row.Index].Cells["colDesdeArticulo"].Selected = true;
			//        else
			//            dgvPlantilla.Rows[row.Index].Cells["colHastaArticulo"].Selected = true;
			//        return false;
			//    }

			//    if (!Convert.ToBoolean(row.Cells["colActivoArticulo"].Value) && (DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()) > DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString()) || DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()) > DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString())))
			//    {
			//        tabControl.SelectedTab = tpPlantilla;
			//        errores = "El rango de fechas debe tener un formato ascendente.";
			//        if (DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()) > DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString()))
			//            dgvPlantilla.Rows[row.Index].Cells["colDesdeArticulo"].Selected = true;
			//        else
			//            dgvPlantilla.Rows[row.Index].Cells["colHastaArticulo"].Selected = true;
			//        return false;
			//    }

			//}
			return true;
		}

		protected override bool validarDatosPedidos(ref string errores)
		{
			bool OK = true;

			if (btnGuardar.Enabled)
			{
				errores = "Debe guardar los cambios realizados.";
				OK = false;
			}

			if (OK && tabControl.SelectedTab.Name == "tpViaAerea")
			{
				if (!rbPagCanAereaSI.Checked)
				{
					errores = "Este colegiado no paga canon de vía aérea.";
					OK = false;
				}
			}

			if (OK && tabControl.SelectedTab.Name == "tpPlaguicidas")
			{
				if (!rbPagCanPlaguiSI.Checked)
				{
					errores = "Este colegiado no paga canon de plaguicidas.";
					OK = false;
				}
			}

			if (OK && tabControl.SelectedTab.Name == "tpSilvestre")
			{
				if (!rbPagCanSilveSI.Checked)
				{
					errores = "Este colegiado no paga canon de vida silvestre.";
					OK = false;
				}
			}

			//string sQuery = "Select FechaIngreso,FechaNacimiento from "+Consultas.sqlCon.COMPAÑIA+".NV_COLEGIADO where IdColegiado = '"+txtIdColegiado.Valor+"'";
			//DataTable dt = new DataTable();
			//if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			//{
			//    if (dt.Rows[0]["FechaIngreso"].ToString().Equals(""))
			//    {
			//        errores = "El colegiado no tiene fecha de ingreso para el calculo del ajuste del fondo.";
			//        tabControl.SelectedTab = tpBasicos;
			//        return false;
			//    }

			//    if (dt.Rows[0]["FechaNacimiento"].ToString().Equals(""))
			//    {
			//        errores = "El colegiado no tiene fecha de nacimiento para el calculo del ajuste del fondo.";
			//        tabControl.SelectedTab = tpBasicos;
			//        return false;
			//    }

			//}
			if(OK)
				OK = validarFechaIngreso_Nacimiento(ref errores);

			return OK;
		}

		private bool validarFechaIngreso_Nacimiento(ref string errores)
		{
			string sQuery = "Select FechaIngreso,FechaNacimiento from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = '" + txtIdColegiado.Valor + "'";
			DataTable dt = new DataTable();
			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows[0]["FechaIngreso"].ToString().Equals(""))
				{
					errores = "El colegiado no tiene fecha de ingreso para el calculo del ajuste del fondo.";
					tabControl.SelectedTab = tpBasicos;
					return false;
				}

				if (dt.Rows[0]["FechaNacimiento"].ToString().Equals(""))
				{
					errores = "El colegiado no tiene fecha de nacimiento para el calculo del ajuste del fondo.";
					tabControl.SelectedTab = tpBasicos;
					return false;
				}

			}
			return true;
		}

		//protected override bool eliminarDetalle(ref string errores)
		//{
		//    bool lbOk = true;
		//    //if (valoresPk.Count > 0)
		//    //{

		//    //    string sQuery = "DELETE FROM "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado ='" + txtIdColegiado.Valor + "'";

		//    //    lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
		//    //}
		//    return lbOk;
		//}

		private void dgvEstablecimientos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dtp.Visible = false;
			if (e.RowIndex != -1)
			{
				if ((dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colFechAproba"))
				{

					dtp = new DateTimePicker();
					dgvEstablecimientos.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvEstablecimientos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChange);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colFechAproba" && !string.IsNullOrEmpty(dgvEstablecimientos.Rows[e.RowIndex].Cells["colFechAproba"].Value?.ToString()))
						dtp.Value = DateTime.Parse(dgvEstablecimientos.Rows[e.RowIndex].Cells["colFechAproba"].Value.ToString());

					dtp.Visible = true;

				}
			}

			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
			////if (dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() != "")
			////    cargarInfoEstablecimiento(dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString());
		}

		//private bool crearConsecutivo(ref string consecutivo)
		// {
		//     if (consecutivoColegiado == "")
		//     {
		//         MessageBox.Show("La categoría de colegiado seleccionada no posee un consecutivo definido para la creación del colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//         return false;
		//     }

		//     consecutivo = this.fInternas.generarConsecutivo(consecutivoColegiado, ref error);

		//     if (consecutivo == "")
		//     {
		//         MessageBox.Show("No se pudo generar el consecutivo del colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		//         return false;
		//     }

		//     if (!this.fInternas.actualizarConsecutivo(this.fInternas.sgtValor(consecutivo), consecutivoColegiado, ref error))
		//     {
		//         MessageBox.Show("No se pudo actualizar el consecutivo del colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		//         return false;
		//     }

		//     txtNumeColegiado.Valor = consecutivo;

		//     return true;
		// }

		protected override bool llenarParametros()
		{
			parametros.Clear();
			//string consecutivo = "";
			//if (valoresPk.Count == 0)
			//{
			//    //if (consecutivoColegiado == "")
			//    //{
			//    //    MessageBox.Show("La categoría de colegiado seleccionada no posee un consecutivo definido para la creación del colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//    //    return false;
			//    //}

			//    //consecutivo = this.fInternas.generarConsecutivo(consecutivoColegiado,ref error);

			//    //if (consecutivo == "")
			//    //{
			//    //    MessageBox.Show("No se pudo generar el consecutivo del colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//    //    return false;
			//    //}

			//    //if (!this.fInternas.actualizarConsecutivo(this.fInternas.sgtValor(consecutivo),consecutivoColegiado, ref error))
			//    //{
			//    //    MessageBox.Show("No se pudo actualizar el consecutivo del colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//    //    return false;
			//    //}

			//    if (!crearConsecutivo(ref consecutivo))
			//        return false;

			//    //txtNumeColegiado.Valor = consecutivo;
			//    //txtIdColegiado.Valor = consecutivo;
			//}
			//else
			//{
			//    consecutivo = txtNumeColegiado.Valor;
			//    //consecutivo = txtIdColegiado.Valor;
			//}

			//txtIdColegiado.Valor = txtCedula.Valor;
			if (string.IsNullOrEmpty(txtIdColegiado.Valor) || txtIdColegiado.Valor.Equals("ND"))
			{
				parametros.Add(txtCedula.Valor);
				txtIdColegiado.Valor = txtCedula.Valor;
			}
			else
				parametros.Add(txtIdColegiado.Valor);

			//parametros.Add(consecutivo);
			parametros.Add(txtNumeColegiado.Valor);
			parametros.Add(txtCedula.Valor);
			parametros.Add(txtNombre.Valor);
			parametros.Add(dtpFechaNac.Value.ToString("yyyy-MM-ddTHH:mm:ss"));


			if (!txtCondicion.Valor.Equals(""))
				parametros.Add(txtCondicion.Valor);
			else
				parametros.Add("null");
			parametros.Add(cmbSexo.Texto[0] + "");
			//parametros.Add(txtTarjeta.Valor);
			string tarjetaSinGUiones = mtbTarjeta.Text.Replace("-", "");
			parametros.Add(tarjetaSinGUiones);

			////dtpTarjetaVencimiento.Value = Dat(fechVenciTarjeta);
			////if (!fechVenciTarjeta.Equals(""))
			////    parametros.Add(DateTime.Parse(fechVenciTarjeta).ToString("yyyy-MM-ddTHH:mm:ss"));
			////else
			////    parametros.Add("null");
			//if (dtpTarjetaVencimiento.Checked)
			//    parametros.Add(dtpTarjetaVencimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
			//else
			//    parametros.Add("null");
			if (mtbVenciminetoTerjeta.MaskFull)
			{
				DateTime fechaTemp = DateTime.Now;
				IsCreditCardInfoValid(mtbVenciminetoTerjeta.Text, ref fechaTemp);
				parametros.Add(fechaTemp.ToString("yyyy-MM-ddTHH:mm:ss"));
				//else
				//	parametros.Add("null");

			}
			else
				parametros.Add("null");

			parametros.Add(cmbTipoTarjeta.Valor);
			parametros.Add(txtTelefono1.Valor);
			parametros.Add(txtTelefono2.Valor);
			parametros.Add(txtTelefono3.Valor);
			parametros.Add(txtEmail1.Valor);
			parametros.Add(txtEmail2.Valor);
			parametros.Add(txtPais.Valor);
			if (!txtProvincia.Valor.Equals(""))
				parametros.Add(txtProvincia.Valor);
			else
				parametros.Add("null");

			if (!txtCanton.Valor.Equals(""))
				parametros.Add(txtCanton.Valor);
			else
				parametros.Add("null");

			if (!txtDistrito.Valor.Equals(""))
				parametros.Add(txtDistrito.Valor);
			else
				parametros.Add("null");

			parametros.Add(txtApartado.Valor);
			parametros.Add(rtbDireccion.Text);
			//if (cmbFormaPago.Texto == "Tarjeta")
			//	parametros.Add("T");
			//else
			//if (cmbFormaPago.Texto == "Planilla")
			//	parametros.Add("P");
			//else
			//	parametros.Add("F");
			parametros.Add("null");//forma de pago-ya no se usa


			if (!txtCobrador.Valor.Equals(""))
				parametros.Add(txtCobrador.Valor);
			else
				parametros.Add("null");

			if (!txtEntidadFinanciera.Valor.Equals(""))
				parametros.Add(txtEntidadFinanciera.Valor);
			else
				parametros.Add("null");

			if (!txtCategoria.Valor.Equals(""))
				parametros.Add(txtCategoria.Valor);
			else
				parametros.Add("null");

			parametros.Add(txtSesionCond.Valor);
			parametros.Add(txtCodigoSesionIncorporacion.Valor);
			parametros.Add(dtpFechaSesionCond.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
			//parametros.Add(txtCodigoSesionIncorporacion.Valor);
			parametros.Add(dtpFechaIngreso.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
			parametros.Add(txtCalculoMutualidad.Valor);
			if (chkRenuncia.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");
			parametros.Add(rtbRazon.Text);
			//  parametros.Add("S");
			/*  if(!chkRenuncia.Checked)
                  parametros.Add("S");
              else
                  parametros.Add("N");*/

			if (rbSiTitulo.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");
			parametros.Add(txtCalculoTitulo.Valor);
			parametros.Add(dtpFechaTitulo.Value.ToString("yyyy-MM-ddTHH:mm:ss"));

			if (!dtpRegresoCondicion.Equals("") && dtpRegresoCondicion.Visible)
				parametros.Add(dtpRegresoCondicion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
			else
				parametros.Add("null");

			if (requiereDatosFallecidos)
			{
				if (!dtpFallecimiento.Equals(""))
					parametros.Add(dtpFallecimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				else
					parametros.Add("null");

				parametros.Add(txtCheque.Valor);

				parametros.Add(txtBeneficiarioCheque.Valor);
			}
			else
			{
				parametros.Add("null");
				parametros.Add("null");
				parametros.Add("null");
			}

			if (rbPagCanAereaSI.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");
			if (rbPagCanPlaguiSI.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");
			if (rbPagCanSilveSI.Checked)
				parametros.Add("S");
			else
				parametros.Add("N");

			return true;
		}

		protected override void deshabilitarLlave()
		{
			listar.VALORES_PK.Clear();
			listar.VALORES_PK.Add(txtIdColegiado.Valor);
			//if (chkCursoPeritaje.Checked) { 
			//    chkCursoPeritaje.Enabled = false;
			//    deshabilitarValoresPeritaje();
			//}
			//if (chkCurso.Checked) { 
			//    chkCurso.Enabled = false;
			//    deshabilitarValoresRegente();
			//}
			//txtCategoria.ReadOnly = true;
			armarFiltroPK(listar.VALORES_PK);
			lblPerfil.Text = "Perfil de Colegiado: " + txtNumeColegiado.Valor.Trim() + "-" + txtNombre.Valor;
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.EDICION_NUM_COLEGIADO))
				txtNumeColegiado.ReadOnly = false;
			else
				txtNumeColegiado.ReadOnly = true;
			//txtNumeColegiado.ReadOnly = true;
		}

		protected override void limpiarFormulario()
		{
			totalPlantillaCobro = 0;
			lblCantTotalPlantillaCobro.Text = totalPlantillaCobro.ToString("N2");
			txtNumeColegiado.Valor = "ND";
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.EDICION_NUM_COLEGIADO))
				txtNumeColegiado.ReadOnly = false;
			else
				txtNumeColegiado.ReadOnly = true;
			//txtNumeColegiado.ReadOnly = true;
			txtIdColegiado.Valor = "ND";
			txtNombre.Clear();
			listar.VALORES_PK.Clear();
			txtCedula.Clear();
			txtPais.Clear();
			dtpEmpresaHasta.Checked = false;
			dtpFechaIngreso.Value = DateTime.Now;
			dtpFechaIngreso.Enabled = false;
			dtpFechaNac.Value = DateTime.Now;
			txtDescripcionPais.Clear();
			txtProvincia.Clear();
			txtProvinciaNombreF.Clear();
			txtCanton.Clear();
			txtCantonNombreF.Clear();
			txtDistrito.Clear();
			txtDistritoNombreF.Clear();
			txtApartado.Clear();
			txtEdad.Clear();
			txtEmail1.Clear();
			txtEmail2.Clear();
			txtTelefono1.Clear();
			txtTelefono2.Clear();
			txtTelefono3.Clear();
			txtEmpresa.Clear();
			rtbDireccion.Clear();
			txtCategoria.Clear();
			txtDescCategoria.Clear();
			txtTarjeta.Clear();
			mtbTarjeta.Clear();
			txtCobrador.Clear();
			txtEntidadFinanciera.Clear();
			txtFrecu.Clear();
			txtFrecuDescripcion.Clear();
			txtFrecuDias.Clear();
			txtDescCobrador.Clear();
			txtEntidadFinanciera.Clear();
			txtDescEntidadFinanciera.Clear();
			txtCalculoMutualidad.Clear();
			txtSesionCond.Clear();
			chkRenuncia.Checked = false;
			rtbRazon.Clear();
			txtCalculoTitulo.Clear();
			txtCobradorPeritaje.Clear();
			txtCobradorPeritajeNombre.Clear();
			txtCobradorRegente.Clear();
			txtCobradorNombre.Clear();
			txtSesionPerdida.Clear();
			txtSesionAprobacion.Clear();
			txtCodigoSesionIncorporacion.Clear();
			txtCodigoSesionIncorporacion.ReadOnly = false;
			txtCondicion.Clear();
			txtCondicion.ReadOnly = false;
			txtCategoria.ReadOnly = false;
			txtDescCondicion.Clear();
			dtpRegresoCondicion.Value = DateTime.Now;
			dtpFallecimiento.Value = DateTime.Now;
			txtCheque.Clear();
			txtBeneficiarioCheque.Clear();
			txtPlantilla.Clear();
			txtPlantillaN.Clear();
			txtMonto.Clear();
			txtNPoliza.Clear();
			dtpVencimiento.Value = DateTime.Now;
			dtpFecha.Value = DateTime.Now;
			txtInstitucion.Clear();
			txtNombreInstitucion.Clear();
			txtCobradorPeritaje.Clear();
			txtCobradorPeritajeNombre.Clear();
			rtbObservaciones.Clear();
			txtSesionAprobPeritaje.Clear();
			dtpSesionAprobPeritaje.Value = DateTime.Now;
			txtSesionRenov.Clear();
			dtpRenovacion.Value = DateTime.Now;
			txtSesionPerdidaPeritaje.Clear();
			dtpSesionPerdidaPeritaje.Value = DateTime.Now;
			chkCursoPeritaje.Checked = false;
			deshabilitarValoresPeritaje();
			chkCurso.Checked = false;
			deshabilitarValoresRegente();
			cmbTipoRegente.Index = 0;
			cmbTipoTarjeta.Valor = "VISA";
			deshabilitarPolizaRegente();
			pcbFoto.Image = Properties.Resources._default;
			Foto = null;


			chkPedConcepto.Checked = false;
			mtbVenciminetoTerjeta.Clear();
			dtpTarjetaVencimiento.Value = DateTime.Now;
			dtpTarjetaVencimiento.Checked = false;
			dgvEstablecimientos.Rows.Clear();
			dgvHistorialAcademico.Rows.Clear();
			dgvHistorialLaboral.Rows.Clear();
			dgvInvestigacionPlaguicidas.Rows.Clear();
			dgvViaAerea.Rows.Clear();
			dgvPlantilla.Rows.Clear();
			dgvGestionCobro.Rows.Clear();
			dgvGestionCobro2.Rows.Clear();
			dgvEspecialidades.Rows.Clear();
			dgvCamposEspecialidad.Rows.Clear();
			dlvBeneficiarios.Clear();
			lblPerfil.Text = "Perfil de Colegiado";
		}

		private bool HistorialAcademico(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ACADEMICO WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ACADEMICO WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ACADEMICO (NumeroColegiado,CodigoCentro,CodigoCarrera,CodigoGrado,Pais,Enfasis,FechaGraduacion) " +
					"VALUES (@Colegiado,@Centro,@Carrera,@Grado,@Pais,@Enfasis,@FechaGradu)";

				foreach (DataGridViewRow row in dgvHistorialAcademico.Rows)
				{
					parametros.Clear();
					parametros.Add("@Colegiado," + txtIdColegiado.Valor);
					//parametros.Add("@Colegiado," + txtCedula.Valor);
					parametros.Add("@Centro," + row.Cells["colCodigoCentro"].Value.ToString());
					parametros.Add("@Carrera," + row.Cells["colCodigoTitulo"].Value.ToString());
					parametros.Add("@Grado," + row.Cells["colCodigoGrado"].Value.ToString());
					parametros.Add("@Pais," + row.Cells["colCodigoPais"].Value.ToString());
					if (!row.Cells["colCodigoEnfasis"].Value.ToString().Equals(""))
						parametros.Add("@Enfasis," + row.Cells["colCodigoEnfasis"].Value.ToString());
					else
						parametros.Add("@Enfasis," + "null");
					parametros.Add("@FechaGradu," + DateTime.Parse(row.Cells["colFechaGradu"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

					OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					if (!OK)
						break;
				}
			}
			return OK;
		}

		private bool HistorialLaboral(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_LABORAL WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_LABORAL WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_LABORAL (NumeroColegiado,Empresa,Puesto,TelefonoEmpresa,CorreoEmpresa,DireccionEmpresa,RangoDesde,RangoHasta) " +
					"VALUES (@Colegiado,@Empresa,@Puesto,@TelefonoEmpresa,@CorreoEmpresa,@DireccionEmpresa,@Desde,@Hasta)";

				foreach (DataGridViewRow row in dgvHistorialLaboral.Rows)
				{
					parametros.Clear();
					parametros.Add("@Colegiado," + txtIdColegiado.Valor);
					//parametros.Add("@Colegiado," + txtCedula.Valor);
					parametros.Add("@Empresa," + row.Cells["colNombreEmpresa"].Value.ToString());
					//parametros.Add("@Puesto," + row.Cells["colCodigoPuesto"].Value.ToString());
					parametros.Add("@Puesto," + row.Cells["colPuesto"].Value.ToString());
					parametros.Add("@TelefonoEmpresa," + row.Cells["colTelefono"].Value.ToString());
					parametros.Add("@CorreoEmpresa," + row.Cells["colCorreoEmpresa"].Value.ToString());
					parametros.Add("@DireccionEmpresa," + row.Cells["colDireccionEmpresa"].Value.ToString());
					parametros.Add("@Desde," + DateTime.Parse(row.Cells["colEmpresaDesde"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
					if (!row.Cells["colEmpresaHasta"].Value.ToString().Equals(""))
						parametros.Add("@Hasta," + DateTime.Parse(row.Cells["colEmpresaHasta"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
					else
						parametros.Add("@Hasta,null");

					OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					if (!OK)
						break;
				}
			}
			return OK;
		}

		private bool Especialidades(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ESPECIALIDAD WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ESPECIALIDAD WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ESPECIALIDAD (NumeroColegiado,CodigoEspecialidad,SesionAprob,Fecha) " +
					"VALUES (@Colegiado,@Especialidad,@Sesion,@Fecha)";

				foreach (DataGridViewRow row in dgvEspecialidades.Rows)
				{
					parametros.Clear();
					//parametros.Add("@Colegiado," + txtNumColegiado.Valor);
					parametros.Add("@Colegiado," + txtIdColegiado.Valor);
					parametros.Add("@Especialidad," + row.Cells["colCodigoEspecialidad"].Value.ToString());
					parametros.Add("@Sesion," + row.Cells["colCodigoSesionAprob"].Value.ToString());
					parametros.Add("@Fecha," + DateTime.Parse(row.Cells["colFechaEspecialidad"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

					OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					if (!OK)
						break;
				}
			}
			return OK;
		}

		private bool CamposEspecialidad(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CAMPO_ESPECIALIDAD WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CAMPO_ESPECIALIDAD WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CAMPO_ESPECIALIDAD (NumeroColegiado,CodigoCampo) " +
					"VALUES (@Colegiado,@Campo)";

				foreach (DataGridViewRow row in dgvCamposEspecialidad.Rows)
				{
					parametros.Clear();
					//parametros.Add("@Colegiado," + txtNumColegiado.Valor);
					parametros.Add("@Colegiado," + txtIdColegiado.Valor);
					parametros.Add("@Campo," + row.Cells["colCodigoCampoEspecialidad"].Value.ToString());

					OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					if (!OK)
						break;
				}
			}
			return OK;
		}

		private bool guardarGestionCobro(ref string error)
		{
			Listado list = new Listado();
			list.COLUMNAS = "Id,IdColegiado,Medio,FechaGestion,Compromiso,FechaCompromiso,Observaciones,Estado";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_GESTION_COBRO";
			bool lbOk = true;
			try
			{
				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				if (lbOk)
				{


					foreach (DataGridViewRow row in dgvGestionCobro2.Rows)
					{
						//string sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO (IdColegiado,Medio,FechaGestion,Compromiso,FechaCompromiso,Observaciones)" +
						//" VALUES ('" + txtIdColegiado.Valor + "', '" + row.Cells["colMedio"].Value.ToString() + "', '" + DateTime.Parse(row.Cells["colFecha"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss") + "', '" + row.Cells["colCompromiso"].Value.ToString() + "','" + DateTime.Parse(row.Cells["colFechaCompromiso"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss") + "', '" + row.Cells["colObservacion"].Value.ToString() + "')";

						//lbOk = Consultas.ejecutarSentencia(sInsert, ref error);
						parametros.Clear();
						list.COLUMNAS_PK.Clear();
						list.COLUMNAS_PK.Add("Id");
						list.COLUMNAS_PK.Add("IdColegiado");
						parametros.Add(row.Cells["colId"].Value.ToString());
						parametros.Add(txtIdColegiado.Valor);
						parametros.Add(row.Cells["colMedio"].Value.ToString());
						if (row.Cells["colFecha"].Value.ToString() != "")
							parametros.Add(DateTime.Parse(row.Cells["colFecha"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("null");
						parametros.Add(row.Cells["colCompromiso"].Value.ToString());
						if (row.Cells["colFechaCompromiso"].Value.ToString() != "")
							parametros.Add(DateTime.Parse(row.Cells["colFechaCompromiso"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("null");
						if (row.Cells["colObservacion"].Value.ToString() != "")
							parametros.Add(row.Cells["colObservacion"].Value.ToString());
						else
							parametros.Add("null");
						parametros.Add(row.Cells["colEstado"].Value.ToString()[0].ToString());


						lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

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

		private bool guardarPlaguicidas(ref string error)
		{
			Listado list = new Listado();
			list.COLUMNAS = "IdColegiado,CodigoCampo,PagaCanon,NumSesionAprobacion,FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO";
			bool lbOk = true;
			try
			{
				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				if (lbOk)
				{
					foreach (DataGridViewRow row in dgvInvestigacionPlaguicidas.Rows)
					{
						parametros.Clear();
						list.COLUMNAS_PK.Clear();
						list.COLUMNAS_PK.Add("IdColegiado");
						list.COLUMNAS_PK.Add("CodigoCampo");
						parametros.Add("@IdColegiado," + txtIdColegiado.Valor);
						parametros.Add("@CodigoCampo," + row.Cells["colCodigoCampo"].Value.ToString());
						//parametros.Add("@PagaCanon," + row.Cells["colPagaCanon"].Value.ToString()[0] + "");
						parametros.Add("@PagaCanon," + "N");
						parametros.Add("@Observaciones," + row.Cells["colObservaciones"].Value.ToString());
						if (row.Cells["colSesionAprobacion"].Value.ToString() != "")
						{
							parametros.Add("@NumSesionAprobacion," + row.Cells["colSesionAprobacion"].Value.ToString());
							parametros.Add("@FechaSesionAprobacion," + DateTime.Parse(row.Cells["colFechaAprobacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

						}
						else
						{
							parametros.Add("@NumSesionAprobacion," + "null");
							parametros.Add("@FechaSesionAprobacion," + "null");
						}
						if (row.Cells["colSesionRenovacion"].Value.ToString() != "")
						{
							parametros.Add("@NumSesionRenovacion," + row.Cells["colSesionRenovacion"].Value.ToString());
							parametros.Add("@FechaSesionRenovacion," + DateTime.Parse(row.Cells["colFechaRenovacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

						}
						else
						{
							parametros.Add("@NumSesionRenovacion," + "null");
							parametros.Add("@FechaSesionRenovacion," + "null");
						}
						if (row.Cells["colSesionPerdidaP"].Value.ToString() != "")
						{
							parametros.Add("@NumSesionPerdida," + row.Cells["colSesionPerdidaP"].Value.ToString());
							parametros.Add("@FechaSesionPerdida," + DateTime.Parse(row.Cells["colFechaPerdidaP"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

						}
						else
						{
							parametros.Add("@NumSesionPerdida," + "null");
							parametros.Add("@FechaSesionPerdida," + "null");
						}


						lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

					}
				}

				//if (lbOk)
				//{
				//    string sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon) values ('" + txtIdColegiado.Valor + "', 'PLAGUI')";

				//    lbOk = Consultas.ejecutarSentencia(sInsert, ref error);
				//}
			}
			catch (Exception ex)
			{
				error = ex.Message;
				return false;
			}
			return lbOk;
		}

		//private bool guardarEstablecimientos(ref string error)
		//{
		//    Listado list = new Listado();
		//    list.COLUMNAS = "NumeroColegiado,CodigoEstablecimiento,SesionAprobacion,FechaAprobacion,Estado,CodigoCategoria,Cobrador";
		//    list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
		//    list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
		//    bool lbOk = true;
		//    try
		//    {
		//        string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";

		//        lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

		//        if (lbOk && dgvEstablecimientos.Rows.Count > 0)
		//        {
		//            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
		//            {
		//                parametros.Clear();
		//                list.COLUMNAS_PK.Add("NumeroColegiado");
		//                parametros.Add(txtIdColegiado.Valor);
		//                parametros.Add(row.Cells["colCodigoEstablecimiento"].Value.ToString());
		//                if (row.Cells["colSesionApEst"].Value.ToString() != "")
		//                {
		//                    parametros.Add(row.Cells["colSesionApEst"].Value.ToString());
		//                    parametros.Add(DateTime.Parse(row.Cells["colFechAproba"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
		//                }
		//                else
		//                {
		//                    parametros.Add("null");
		//                    parametros.Add("null");
		//                }

		//                parametros.Add(row.Cells["colEstadoEst"].Value.ToString()[0]+"");
		//                parametros.Add(row.Cells["colCodigoCategoria"].Value.ToString());
		//                if(!row.Cells["colCodigoCobrador"].Value.ToString().Equals(""))
		//                    parametros.Add(row.Cells["colCodigoCobrador"].Value.ToString());
		//                else
		//                    parametros.Add("null");

		//                lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

		//            }
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        error = ex.Message;
		//        return false;
		//    }
		//    return lbOk;
		//}

		private bool guardarEstablecimientos(ref string error)
		{
			Listado list = new Listado();
			list.COLUMNAS = "NumeroColegiado,CodigoEstablecimiento,SesionAprobacion,FechaAprobacion,Estado,CodigoCategoria,Cobrador";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
			bool lbOk = true;
			try
			{
				if (dgvEstablecimientos.Rows.Count > 0)
				{
                    lbOk = VerificaEstadoRegenciasVrsCategorias(ref error);

                    if (lbOk)
					{
                        foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
                        {
                            lbOk = fInternas.insertarHistorialRegencias(txtIdColegiado.Valor, row.Cells["colCodigoEstablecimiento"].Value.ToString(), row.Cells["colCodigoCategoria"].Value.ToString(), row.Cells["colEstadoEst"].Value.ToString()[0].ToString(), ref error);
                        }
                    }
                        

					if (lbOk)
					{
						string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";

						lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
					}

					if (lbOk)
					{
						foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
						{

							parametros.Clear();
							list.COLUMNAS_PK.Clear();
							list.COLUMNAS_PK.Add("NumeroColegiado");
							parametros.Add(txtIdColegiado.Valor);
							parametros.Add(row.Cells["colCodigoEstablecimiento"].Value.ToString());
							if (row.Cells["colSesionApEst"].Value.ToString() != "")
							{
								parametros.Add(row.Cells["colSesionApEst"].Value.ToString());
								parametros.Add(DateTime.Parse(row.Cells["colFechAproba"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
							}
							else
							{
								parametros.Add("null");
								parametros.Add("null");
							}

							parametros.Add(row.Cells["colEstadoEst"].Value.ToString()[0] + "");
							parametros.Add(row.Cells["colCodigoCategoria"].Value.ToString());
							if (!row.Cells["colCodigoCobrador"].Value.ToString().Equals(""))
								parametros.Add(row.Cells["colCodigoCobrador"].Value.ToString());
							else
								parametros.Add("null");

							lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);
						}
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

		private bool CamposInvestigacionPlaguicidas(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			string sSelect = "";
			DataTable dt = new DataTable();
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "'";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CAMPO_ESPECIALIDAD WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO (IdColegiado,CodigoCampo,NumSesionAprobacion," +
					"FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones,Activo) " +
					"VALUES (@IdColegiado,@CodigoCampo,@NumSesionAprobacion,@FechaSesionAprobacion,@NumSesionRenovacion,@FechaSesionRenovacion,@NumSesionPerdida,@FechaSesionPerdida,@Observaciones,@Activo)";

				foreach (DataGridViewRow row in dgvInvestigacionPlaguicidas.Rows)
				{

					sSelect = "SELECT IdColegiado,CodigoCampo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "' and CodigoCampo = '" + row.Cells["colCodigoCampo"].Value.ToString() + "'";
					OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

					if (OK && dt.Rows.Count > 0)
					{
						OK = false;
						error = "Ya existe un Campo de Investigación igual para este Colegiado";
						tabControl.SelectedTab = tpPlaguicidas;
						//MessageBox.Show("Ya existe un Campos de Investigación igual para este Colegiado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{

						parametros.Clear();
						parametros.Add("@IdColegiado," + txtIdColegiado.Valor);
						parametros.Add("@CodigoCampo," + row.Cells["colCodigoCampo"].Value.ToString());
						//parametros.Add("@PagaCanon," + row.Cells["colPagaCanon"].Value.ToString()[0] + "");
						parametros.Add("@Observaciones," + row.Cells["colObservaciones"].Value.ToString());

						if (row.Cells["colSesionAprobacion"].Value.ToString() != "")
							parametros.Add("@NumSesionAprobacion," + row.Cells["colSesionAprobacion"].Value.ToString());
						else
							parametros.Add("@NumSesionAprobacion," + "null");

						if (row.Cells["colFechaAprobacion"].Value.ToString() != "")
							parametros.Add("@FechaSesionAprobacion," + DateTime.Parse(row.Cells["colFechaAprobacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionAprobacion," + "null");


						if (row.Cells["colSesionRenovacion"].Value.ToString() != "")
							parametros.Add("@NumSesionRenovacion," + row.Cells["colSesionRenovacion"].Value.ToString());
						else
							parametros.Add("@NumSesionRenovacion," + "null");

						if (row.Cells["colFechaRenovacion"].Value.ToString() != "")
							parametros.Add("@FechaSesionRenovacion," + DateTime.Parse(row.Cells["colFechaRenovacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionRenovacion," + "null");


						if (row.Cells["colSesionPerdidaP"].Value.ToString() != "")
							parametros.Add("@NumSesionPerdida," + row.Cells["colSesionPerdidaP"].Value.ToString());
						else
							parametros.Add("@NumSesionPerdida," + "null");

						if (row.Cells["colFechaPerdidaP"].Value.ToString() != "")
							parametros.Add("@FechaSesionPerdida," + DateTime.Parse(row.Cells["colFechaPerdidaP"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionPerdida," + "null");

						if (bool.Parse(row.Cells["colActivoPlagui"].Value.ToString()) == true)
							parametros.Add("@Activo," + "1");
						else
							parametros.Add("@Activo," + "0");
					}

					if (OK)
						OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					if (OK)
					{
						DataTable dtVerificar = new DataTable();
						string sVerificar = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

						if (OK = Consultas.fillDataTable(sVerificar, ref dtVerificar, ref error))
						{
							if (dtVerificar.Rows.Count > 0)
							{
								OK = canonesAnuales(txtIdColegiado.Valor, "PLAGUI", ref error);
							}
						}
					}

					if (!OK)
						break;
				}
			}
			return OK;
		}

		private bool ViaAerea(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			string sSelect = "";
			DataTable dt = new DataTable();
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "'";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CAMPO_ESPECIALIDAD WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO (IdColegiado,CodigoCultivo,PagaCanon,NumSesionAprobacion," +
					"FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones,Activo) " +
					"VALUES (@IdColegiado,@CodigoCultivo,@PagaCanon,@NumSesionAprobacion,@FechaSesionAprobacion,@NumSesionRenovacion,@FechaSesionRenovacion,@NumSesionPerdida,@FechaSesionPerdida,@Observaciones,@Activo)";

				foreach (DataGridViewRow row in dgvViaAerea.Rows)
				{

					sSelect = "SELECT IdColegiado,CodigoCultivo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "' and CodigoCultivo = '" + row.Cells["colCodigoAerea"].Value.ToString() + "'";
					OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

					if (OK && dt.Rows.Count > 0)
					{
						OK = false;
						error = "El colegiado ya esta autorizado para recetar el cultivo";
						tabControl.SelectedTab = tpViaAerea;
						//MessageBox.Show("Ya existe un Campos de Investigación igual para este Colegiado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						parametros.Clear();
						parametros.Add("@IdColegiado," + txtIdColegiado.Valor);
						parametros.Add("@CodigoCultivo," + row.Cells["colCodigoAerea"].Value.ToString());
						//parametros.Add("@PagaCanon," + row.Cells["colPagaCanonAerea"].Value.ToString()[0] + "");
						parametros.Add("@PagaCanon," + "N");
						parametros.Add("@Observaciones," + row.Cells["colObservacionesAerea"].Value.ToString());

						if (row.Cells["colSesionAproAerea"].Value.ToString() != "")
							parametros.Add("@NumSesionAprobacion," + row.Cells["colSesionAproAerea"].Value.ToString());
						else
							parametros.Add("@NumSesionAprobacion," + "null");

						if (row.Cells["colFechaAproAerea"].Value.ToString() != "")
							parametros.Add("@FechaSesionAprobacion," + DateTime.Parse(row.Cells["colFechaAproAerea"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionAprobacion," + "null");


						if (row.Cells["colSesionRenovAerea"].Value.ToString() != "")
							parametros.Add("@NumSesionRenovacion," + row.Cells["colSesionRenovAerea"].Value.ToString());
						else
							parametros.Add("@NumSesionRenovacion," + "null");


						if (row.Cells["colFechaRenovAerea"].Value.ToString() != "")
							parametros.Add("@FechaSesionRenovacion," + DateTime.Parse(row.Cells["colFechaRenovAerea"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionRenovacion," + "null");


						if (row.Cells["colSesionPerdAerea"].Value.ToString() != "")
							parametros.Add("@NumSesionPerdida," + row.Cells["colSesionPerdAerea"].Value.ToString());
						else
							parametros.Add("@NumSesionPerdida," + "null");

						if (row.Cells["colFechaPerdAerea"].Value.ToString() != "")
							parametros.Add("@FechaSesionPerdida," + DateTime.Parse(row.Cells["colFechaPerdAerea"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionPerdida," + "null");


						if (bool.Parse(row.Cells["colActivoViaAerea"].Value.ToString()) == true)
							parametros.Add("@Activo," + "1");
						else
							parametros.Add("@Activo," + "0");

						OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					}

					if (OK)
					{
						DataTable dtVerificar = new DataTable();
						string sVerificar = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

						if (OK = Consultas.fillDataTable(sVerificar, ref dtVerificar, ref error))
						{
							if (dtVerificar.Rows.Count > 0)
							{
								OK = canonesAnuales(txtIdColegiado.Valor, "AEREA", ref error);
							}
						}
					}


					if (!OK)
						break;
				}
			}

			//if (OK)
			//{
			//    string sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon) values ('" + txtIdColegiado.Valor + "', 'AEREA')";

			//    OK = Consultas.ejecutarSentencia(sInsert, ref error);
			//}

			return OK;
		}

		private bool VidaSilvestre(ref string error)
		{
			bool OK = true;
			string sQuery = "";
			string sSelect = "";
			DataTable dt = new DataTable();
			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SILVESTRE WHERE IdColegiado='" + txtIdColegiado.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SILVESTRE (IdColegiado,CodigoSilvestre,NumSesionAprobacion," +
					"FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones,Activo) " +
					"VALUES (@IdColegiado,@CodigoSilvestre,@NumSesionAprobacion,@FechaSesionAprobacion,@NumSesionRenovacion,@FechaSesionRenovacion,@NumSesionPerdida,@FechaSesionPerdida,@Observaciones,@Activo)";

				foreach (DataGridViewRow row in dgvVidaSilvestre.Rows)
				{

					sSelect = "SELECT IdColegiado,CodigoSilvestre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SILVESTRE WHERE IdColegiado='" + txtIdColegiado.Valor + "' and CodigoSilvestre = '" + row.Cells["colCodigoSilvestre"].Value.ToString() + "'";
					OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

					if (OK && dt.Rows.Count > 0)
					{
						OK = false;
						error = "Ya existe un vida silvestre igual para este Colegiado";
						tabControl.SelectedTab = tpSilvestre;
					}
					else
					{

						parametros.Clear();
						parametros.Add("@IdColegiado," + txtIdColegiado.Valor);
						parametros.Add("@CodigoSilvestre," + row.Cells["colCodigoSilvestre"].Value.ToString());
						//parametros.Add("@PagaCanon," + row.Cells["colPagaCanon"].Value.ToString()[0] + "");
						parametros.Add("@Observaciones," + row.Cells["colObservacionesSilve"].Value.ToString());

						if (row.Cells["colSesionAprobacionSilve"].Value.ToString() != "")
							parametros.Add("@NumSesionAprobacion," + row.Cells["colSesionAprobacionSilve"].Value.ToString());
						else
							parametros.Add("@NumSesionAprobacion," + "null");

						if (row.Cells["colFechaAprobacionSilve"].Value.ToString() != "")
							parametros.Add("@FechaSesionAprobacion," + DateTime.Parse(row.Cells["colFechaAprobacionSilve"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionAprobacion," + "null");


						if (row.Cells["colSesionRenovacionSilve"].Value.ToString() != "")
							parametros.Add("@NumSesionRenovacion," + row.Cells["colSesionRenovacionSilve"].Value.ToString());
						else
							parametros.Add("@NumSesionRenovacion," + "null");

						if (row.Cells["colFechaRenovacionSilve"].Value.ToString() != "")
							parametros.Add("@FechaSesionRenovacion," + DateTime.Parse(row.Cells["colFechaRenovacionSilve"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionRenovacion," + "null");


						if (row.Cells["colSesionPerdidaSilve"].Value.ToString() != "")
							parametros.Add("@NumSesionPerdida," + row.Cells["colSesionPerdidaSilve"].Value.ToString());
						else
							parametros.Add("@NumSesionPerdida," + "null");

						if (row.Cells["colFechaPerdidaSilve"].Value.ToString() != "")
							parametros.Add("@FechaSesionPerdida," + DateTime.Parse(row.Cells["colFechaPerdidaSilve"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
						else
							parametros.Add("@FechaSesionPerdida," + "null");

						if (bool.Parse(row.Cells["colActivoSilvestre"].Value.ToString()) == true)
							parametros.Add("@Activo," + "1");
						else
							parametros.Add("@Activo," + "0");

					}

					if (OK)
						OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

					if (OK)
					{
						DataTable dtVerificar = new DataTable();
						string sVerificar = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SILVESTRE WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

						if (OK = Consultas.fillDataTable(sVerificar, ref dtVerificar, ref error))
						{
							if (dtVerificar.Rows.Count > 0)
							{
								OK = canonesAnuales(txtIdColegiado.Valor, "SILVE", ref error);
							}
						}
					}

					if (!OK)
						break;
				}
			}
			return OK;
		}

		private bool Orientaciones(ref string error)
		{
			bool OK = true;
			//string sQuery = "";
			//sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ORIENTACION WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";
			////sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ORIENTACION WHERE NumeroColegiado='" + txtCedula.Valor + "'";
			//OK = Consultas.ejecutarSentencia(sQuery, ref error);

			//if (OK)
			//{
			//    sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_ORIENTACION (NumeroColegiado,CodigoOrientacion) " +
			//        "VALUES (@Colegiado,@Orientacion)";

			//    foreach (DataGridViewRow row in dgvOrientaciones.Rows)
			//    {
			//        parametros.Clear();
			//        //parametros.Add("@Colegiado," + txtNumColegiado.Valor);
			//        parametros.Add("@Colegiado," + txtCedula.Valor);
			//        parametros.Add("@Orientacion," + row.Cells["colCodigoOrientacion"].Value.ToString());

			//        OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

			//        if (!OK)
			//            break;
			//    }
			//}
			return OK;
		}

		private bool Peritajes(ref string error)
		{
			bool OK = true;
			string sQuery = "";

			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS WHERE IdColegiado='" + txtIdColegiado.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS (IdColegiado,Tipo,CodigoEmpresa,Cobrador,CursoAvaluosPeritaje,NumSesionAprobacion," +
					"FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones) " +
					"VALUES (@IdColegiado,@Tipo,@CodigoEmpresa,@Cobrador,@CursoAvaluosPeritaje,@NumSesionAprobacion,@FechaSesionAprobacion,@NumSesionRenovacion,@FechaSesionRenovacion,@NumSesionPerdida,@FechaSesionPerdida,@Observaciones)";

				parametros.Clear();
				parametros.Add("@IdColegiado," + txtIdColegiado.Valor);
				//parametros.Add("@Tipo," + cmbTipoPerito.Texto[0] + "");
				if (!cmbTipoPerito.Valor.Equals(""))
					parametros.Add("@Tipo," + cmbTipoPerito.Valor);
				else
					parametros.Add("@Tipo," + "null");

				if (txtInstitucion.Valor.Equals(""))
					parametros.Add("@CodigoEmpresa," + "null");
				else
					parametros.Add("@CodigoEmpresa," + txtInstitucion.Valor);
				if (txtCobradorPeritaje.Valor.Equals(""))
					parametros.Add("@Cobrador," + "null");
				else
					parametros.Add("@Cobrador," + txtCobradorPeritaje.Valor);

				if (chkCursoPeritaje.Checked)
					parametros.Add("@CursoAvaluosPeritaje," + "S");
				else
					parametros.Add("@CursoAvaluosPeritaje," + "N");
				if (txtSesionAprobPeritaje.Valor.Trim() != "")
				{
					parametros.Add("@NumSesionAprobacion," + txtSesionAprobPeritaje.Valor.Trim());
					parametros.Add("@FechaSesionAprobacion," + dtpSesionAprobPeritaje.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				}
				else
				{
					parametros.Add("@NumSesionAprobacion," + "null");
					parametros.Add("@FechaSesionAprobacion," + "null");
				}

				if (txtSesionRenov.Valor.Trim() != "")
					parametros.Add("@NumSesionRenovacion," + txtSesionRenov.Valor.Trim());
				else
					parametros.Add("@NumSesionRenovacion," + "null");

				if (dtpRenovacion.Checked)
					parametros.Add("@FechaSesionRenovacion," + dtpRenovacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				else
					parametros.Add("@FechaSesionRenovacion," + "null");

				if (txtSesionPerdidaPeritaje.Valor.Trim() != "")
					parametros.Add("@NumSesionPerdida," + txtSesionPerdidaPeritaje.Valor.Trim());
				else
					parametros.Add("@NumSesionPerdida," + "null");

				if (dtpSesionPerdidaPeritaje.Checked)
					parametros.Add("@FechaSesionPerdida," + dtpSesionPerdidaPeritaje.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				else
					parametros.Add("@FechaSesionPerdida," + "null");

				if (!rtbObservaciones.Text.Equals(""))
					parametros.Add("@Observaciones," + rtbObservaciones.Text);
				else
					parametros.Add("@Observaciones," + "null");

				OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

			}

			if (OK)
			{
				DataTable dtVerificar = new DataTable();
				string sVerificar = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

				if (OK = Consultas.fillDataTable(sVerificar, ref dtVerificar, ref error))
				{
					if (dtVerificar.Rows.Count > 0)
					{
						OK = canonesAnuales(txtIdColegiado.Valor, "PER", ref error);
					}
				}
			}


			return OK;
		}

		private bool Regencias(ref string error)
		{
			bool OK = true;
			string sQuery = "";

			sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES WHERE NumeroColegiado='" + txtIdColegiado.Valor + "'";
			OK = Consultas.ejecutarSentencia(sQuery, ref error);

			if (OK)
			{
				sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES (NumeroColegiado,Cobrador,AvaluoCursos,SesionAprobacion," +
					"FechaSesionAprobacion,SesionPerdida,FechaSesionPerdida,Tipo,NumeroPoliza,FechaPoliza,MontoPoliza,FechaVencimientoPoliza) " +
					"VALUES (@NumeroColegiado,@Cobrador,@AvaluoCursos,@SesionAprobacion,@FechaSesionAprobacion,@SesionPerdida,@FechaSesionPerdida,@Tipo,@NumeroPoliza,@FechaPoliza,@MontoPoliza,@FechaVencimientoPoliza)";

				parametros.Clear();
				parametros.Add("@NumeroColegiado," + txtIdColegiado.Valor);
				parametros.Add("@Cobrador," + txtCobradorRegente.Valor);
				if (chkCurso.Checked)
					parametros.Add("@AvaluoCursos," + "S");
				else
					parametros.Add("@AvaluoCursos," + "N");

				if (txtSesionAprobacion.Valor.Trim() != "")
				{
					parametros.Add("@SesionAprobacion," + txtSesionAprobacion.Valor.Trim());
					parametros.Add("@FechaSesionAprobacion," + dtpAprobacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				}
				else
				{
					parametros.Add("@SesionAprobacion," + "null");
					parametros.Add("@FechaSesionAprobacion," + "null");
				}

				if (txtSesionPerdida.Valor.Trim() != "")
					parametros.Add("@SesionPerdida," + txtSesionPerdida.Valor.Trim());
				else
					parametros.Add("@SesionPerdida," + "null");

				if (dtpPerdida.Checked)
					parametros.Add("@FechaSesionPerdida," + dtpPerdida.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				else
					parametros.Add("@FechaSesionPerdida," + "null");

				if (!cmbTipoRegente.Valor.Equals(""))
					parametros.Add("@Tipo," + cmbTipoRegente.Valor);
				else
					parametros.Add("@Tipo," + "null");

				if (!txtNPoliza.Valor.Equals(""))
				{
					parametros.Add("@NumeroPoliza," + txtNPoliza.Valor);
					parametros.Add("@FechaPoliza," + dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
					if (!txtMonto.Valor.Equals(""))
						parametros.Add("MontoPoliza," + decimal.Parse(txtMonto.Valor).ToString());
					else
						parametros.Add("MontoPoliza," + "null");
					parametros.Add("FechaVencimientoPoliza," + dtpVencimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
				}
				else
				{
					parametros.Add("@NumeroPoliza," + "null");
					parametros.Add("@FechaPoliza," + "null");
					parametros.Add("MontoPoliza," + "null");
					parametros.Add("FechaVencimientoPoliza," + "null");
				}

				OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

				if (OK)
				{
					OK = guardarEstablecimientos(ref error);
				}

			}
			return OK;
		}

		private bool guardarPlantilla(ref string error)
		{
			bool OK = true;
			//string pedidoConcepto = "";
			//string mesUltimoCobro = "";

			//DataTable infoPlantilla = new DataTable();
			//DataTable dtSelect = new DataTable();

			//string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Monto,CodigoFrecuencia,PedidoPorConcepto) " +
			//    "VALUES (@NumeroColegiado,@CodigoCondicion,@CodigoArticulo,@CodigoPlantilla,@Monto,@CodigoFrecuencia,@PedidoPorConcepto)";

			//string sDelete = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado = @NumeroColegiado";


			//Obtenemos estos datos porque son genericos y se necesitan para los procesos // Ya se paso el campo mesultimo cobro a la tabla historialcolegiaturas
			//#region OBTENER_PEDIDOCONCEPTO_ULTIMOCOBRO
			//if (OK)
			//{

			//    string sSelectP_M = "select PedidoPorConcepto, MesUltimoCobro from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO" +
			//        " where NumeroColegiado = '" + txtIdColegiado.Valor + "'";

			//    if (Consultas.fillDataTable(sSelectP_M, ref dtSelect, ref error))
			//    {
			//        if (dtSelect.Rows.Count > 0)
			//        {
			//            pedidoConcepto = dtSelect.Rows[0]["PedidoPorConcepto"].ToString();
			//            mesUltimoCobro = dtSelect.Rows[0]["MesUltimoCobro"].ToString();
			//        }
			//        OK = true;
			//    }
			//    else
			//    {
			//        OK = false;
			//        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    }
			//}
			//#endregion


			//Eliminamos los registros de la condicion anterior en machotes colegiados
			//    #region ELIMINAR_MACHOTESCOLEGIADOS
			//if (OK)
			//{
			//    List<string> parametros = new List<string>();

			//    parametros.Add("@NumeroColegiado," + txtIdColegiado.Valor);

			//    OK = Consultas.ejecutarSentenciaParametros(sDelete, parametros, ref error);
			//}
			//#endregion

			//foreach (DataGridViewRow row in dgvPlantilla.Rows)
			//{
			//    parametros.Clear();
			//    parametros.Add("@NumeroColegiado," + txtIdColegiado.Valor);
			//    parametros.Add("@CodigoCondicion," + txtCondicion.Valor);
			//    parametros.Add("@CodigoArticulo," + row.Cells["colCodigoArticulo"].Value.ToString());
			//    string txt = txtPlantilla.Valor;
			//    if (row.Cells["colPlantilla"].Value.ToString().Equals(""))
			//        parametros.Add("@CodigoPlantilla,null");
			//    else
			//        parametros.Add("@CodigoPlantilla," + row.Cells["colPlantilla"].Value.ToString());
			//    parametros.Add("@Monto," + row.Cells["colMontoArticulo"].Value.ToString());
			//    parametros.Add("@CodigoFrecuencia," + txtFrecu.Valor);
			//    if (chkPedConcepto.Checked)
			//        parametros.Add("@PedidoPorConcepto," + "S");
			//    else
			//        parametros.Add("@PedidoPorConcepto," + "N");

			//    OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);
			//}



			return OK;
		}

		//private bool guardarPlantilla(ref string error)
		//{
		//    bool OK = true;
		//    DataTable infoPlantilla = new DataTable();

		//    //Comentado por ecambios en pantalla de planilla de colum frecuencias
		//    //sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Activo,RangoDesde,RangoHasta,Monto,CodigoForma,CodigoFrecuencia) " +
		//    //  "VALUES (@NumeroColegiado,@CodigoCondicion,@CodigoArticulo,@CodigoPlantilla,@Activo,@Desde,@Hasta,@Monto,@CodigoForma,@CodigoFrecuencia)";
		//    string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO (NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,Monto,CodigoFrecuencia,PedidoPorConcepto) " +
		//        "VALUES (@NumeroColegiado,@CodigoCondicion,@CodigoArticulo,@CodigoPlantilla,@Monto,@CodigoFrecuencia,@PedidoPorConcepto)";//Le ingreso valor N quemado por mientras se quita el campo en bd --Josedavid

		//    //sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO set Activo = @Activo,Desde = @Desde,Hasta = @Hasta,Monto = @Monto,CodigoForma = @CodigoForma,CodigoFrecuencia = @CodigoFrecuencia " +
		//    //  "WHERE NumeroColegiado = @NumeroColegiado and CodigoCondicion = @CodigoCondicion and CodigoArticulo = @CodigoArticulo and CodigoPlantilla = @CodigoPlantilla";
		//    string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO set Monto = @Monto,CodigoFrecuencia = @CodigoFrecuencia,PedidoPorConcepto = @PedidoPorConcepto " +
		//                        "WHERE NumeroColegiado = @NumeroColegiado and CodigoCondicion = @CodigoCondicion and CodigoArticulo = @CodigoArticulo and CodigoPlantilla = @CodigoPlantilla";


		//    foreach (DataGridViewRow row in dgvPlantilla.Rows)
		//    {
		//        parametros.Clear();
		//        //parametros.Add("@NumeroColegiado," + txtCedula.Valor);
		//        //if(txtIdColegiado.Valor.Equals("ND") || string.IsNullOrEmpty(txtIdColegiado.Valor))
		//        //  parametros.Add("@NumeroColegiado," + txtCedula.Valor);
		//        //else
		//        parametros.Add("@NumeroColegiado," + txtIdColegiado.Valor);
		//        //parametros.Add("@CodigoCondicion," + row.Cells["colCondicion"].Value.ToString());
		//        parametros.Add("@CodigoCondicion," + txtCondicion.Valor);
		//        parametros.Add("@CodigoArticulo," + row.Cells["colCodigoArticulo"].Value.ToString());
		//        string txt = txtPlantilla.Valor;
		//        if (row.Cells["colPlantilla"].Value.ToString().Equals(""))
		//            parametros.Add("@CodigoPlantilla,null");
		//        else
		//            parametros.Add("@CodigoPlantilla," + row.Cells["colPlantilla"].Value.ToString());
		//        /*if (Convert.ToBoolean(row.Cells["colActivoArticulo"].Value))
		//        {
		//            parametros.Add("@Activo,S");
		//            parametros.Add("@Desde,null");
		//            parametros.Add("@Hasta,null");
		//        }
		//        else
		//        {
		//            parametros.Add("@Activo,N");
		//            parametros.Add("@Desde," + DateTime.Parse(row.Cells["colDesdeArticulo"].Value.ToString()).ToString("yyyyMMdd"));
		//            parametros.Add("@Hasta," + DateTime.Parse(row.Cells["colHastaArticulo"].Value.ToString()).ToString("yyyyMMdd"));
		//        }*/
		//        parametros.Add("@Monto," + row.Cells["colMontoArticulo"].Value.ToString());
		//        parametros.Add("@CodigoFrecuencia," + txtFrecu.Valor);
		//        if (chkPedConcepto.Checked)
		//            parametros.Add("@PedidoPorConcepto," + "S");
		//        else
		//            parametros.Add("@PedidoPorConcepto," + "N");
		//        /*if (row.Cells["colFormaPagoArticulo"].Value.ToString().Equals(""))
		//            parametros.Add("@CodigoForma,null");
		//        else*/
		//        //parametros.Add("@CodigoForma," + row.Cells["colFormaPagoArticulo"].Value.ToString());
		//        /* if (row.Cells["colFrecuenciaArticulo"].Value.ToString().Equals(""))
		//             parametros.Add("@CodigoFrecuencia,null");
		//         else
		//             parametros.Add("@CodigoFrecuencia," + row.Cells["colFrecuenciaArticulo"].Value.ToString());*/
		//        //sSelect = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado='" + txtNumColegiado.Valor + "' and CodigoCondicion = '" + row.Cells["colCondicion"].Value.ToString() + "' and CodigoArticulo = '" + row.Cells["colCodigoArticulo"].Value.ToString() + "' and CodigoPlantilla = NULLIF('" + row.Cells["colPlantilla"].Value.ToString() + "','')";
		//        string sSelect = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado='" + txtIdColegiado.Valor + "' and CodigoCondicion = '" + row.Cells["colCondicion"].Value.ToString() + "' and CodigoArticulo = '" + row.Cells["colCodigoArticulo"].Value.ToString() + "' and CodigoPlantilla = NULLIF('" + row.Cells["colPlantilla"].Value.ToString() + "','')";
		//        OK = Consultas.fillDataTable(sSelect, ref infoPlantilla, ref error);

		//        if (OK && infoPlantilla.Rows.Count > 0)
		//            OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

		//        if (OK && infoPlantilla.Rows.Count == 0)
		//            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

		//        if (!OK)
		//            break;
		//    }
		//    return OK;
		//}

		protected override bool guardarDetalle(ref string error)
		{
			bool OK = true;

			if (imagenPredeterminada)
			{
				OK = Consultas.quitarFoto(txtIdColegiado.Valor, ref error);

			}
			else
			{
				if (Foto != null)
				{
					OK = Consultas.insertarFoto(txtIdColegiado.Valor, Foto, ref error);
				}
			}

			//if (OK)
			//{
			//    OK = guardarPlantilla(ref error);
			//}

			if (OK)
			{
				OK = guardarGestionCobro(ref error);
			}

			if (OK)
			{
				OK = HistorialAcademico(ref error);
			}

			if (OK)
			{
				OK = HistorialLaboral(ref error);
			}

			if (OK)
			{
				OK = Especialidades(ref error);
			}

			if (OK)
			{
				OK = CamposEspecialidad(ref error);
			}

			if (OK)
			{
				OK = CamposInvestigacionPlaguicidas(ref error);
				//OK = guardarPlaguicidas(ref error);
			}

			if (OK)
			{
				OK = ViaAerea(ref error);
			}

			if (OK)
			{
				OK = VidaSilvestre(ref error);
			}

			//if (OK)
			//{
			//    OK = Orientaciones(ref error);
			//}

			if (OK && chkCursoPeritaje.Checked)
			{
				OK = Peritajes(ref error);
			}

			if (OK && chkCurso.Checked)
			{
				OK = Regencias(ref error);
			}

			if (OK)
			{
				OK = canonesInscripcion(ref error);
			}

			if (OK)
				OK = InsertarVidaSilvestre(ref error);

			if (OK)
				OK = clienteERP(ref error);

			return OK;
		}

		private bool InsertarVidaSilvestre(ref string error)
		{

			Listado list = new Listado();
			list.COLUMNAS = "IdColegiado,CodigoSilvestre";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_REGENTES_SILVESTRE";
			bool lbOk = true;
			try
			{
				string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_SILVESTRE WHERE IdColegiado='" + txtIdColegiado.Valor + "'";

				lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

				if (lbOk)
				{
					foreach (DataGridViewRow row in dgvVidaSilvestreR.Rows)
					{
						parametros.Clear();
						list.COLUMNAS_PK.Clear();
						list.COLUMNAS_PK.Add("IdColegiado");
						list.COLUMNAS_PK.Add("CodigoSilvestre");
						parametros.Add(txtIdColegiado.Valor);
						parametros.Add(row.Cells["colCodigoSilvestreR"].Value.ToString());

						lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

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

		private bool clienteERP(ref string error)
		{
			DataTable dtCliente = new DataTable();
			DataTable dtNit = new DataTable();

			string sSelectCl = "";
			bool lbOk = true;
			try
			{
				//sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NIT where NIT = '" + txtIdColegiado.Valor + "'";
				sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NIT where NIT = '" + txtCedula.Valor + "'";

				lbOk = Consultas.fillDataTable(sSelectCl, ref dtNit, ref error);

				if (lbOk && dtNit.Rows.Count == 0 && !requiereDatosFallecidos)//Si no tiene nit lo crea, solo si no esta fallecido
					lbOk = fInternas.generarNit(txtCedula.Valor, txtIdColegiado.Valor, ref dtCliente, "colegiado", ref error);
				//lbOk = fInternas.generarNit(txtIdColegiado.Valor, txtIdColegiado.Valor, ref dtCliente, "colegiado", ref error);

				if (lbOk && !requiereDatosFallecidos)
				{
					//sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + txtIdColegiado.Valor + "'";
					sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + txtIdColegiado.Valor + "'";

					lbOk = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);
				}

				if (lbOk && dtCliente.Rows.Count == 0 && !requiereDatosFallecidos)
				{
					lbOk = fInternas.generarCliente(txtIdColegiado.Valor, ref dtCliente, "colegiado", "C", ref error);
					//lbOk = fInternas.generarCliente(txtIdColegiado.Valor, ref dtCliente, "colegiado", "C", ref error);
				}
				else
				{
					dtCliente = new DataTable();
					string activoCli = "S";
					if (requiereDatosFallecidos)
						activoCli = "N";

					sSelectCl = "select IdColegiado idERP, Nombre, NumeroColegiado Alias, Direccion, TelefonoCelular Telefono1, TelefonoHabitacion Telefono2," +
					" Cedula Contribuyente, Pais, case when NumeroTarjeta != '' then 'S' else 'N' end UsaTarjeta, VencimientoTarjeta, Email," +
					" Provincia, Canton, '" + activoCli + "' Activo, Categoria from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = '" + txtIdColegiado.Valor + "'";

					lbOk = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

					if (lbOk)
						lbOk = controlerBD.actualizarCliente(dtCliente, ref error);
				}

			}
			catch (Exception ex)
			{
				error = ex.Message;
				return false;
			}
			return lbOk;
		}

		private bool canonesInscripcion(ref string error)
		{
			bool lbOk = true;

			DataTable dtVerificar = new DataTable();
			string sVerificar = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

			if (Consultas.fillDataTable(sVerificar, ref dtVerificar, ref error))
			{
				if (dtVerificar.Rows.Count == 0)
				{
					string sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION (Identificador,Canon,PedidoViaAerea,PedidoPlaguicidas,PedidoPeritajes,PedidoEstablecimiento,PedidoConsultora) " +
					"VALUES (@IdColegiado,@Canon,@PedidoViaAerea,@PedidoPlaguicidas,@PedidoPeritajes,@PedidoEstablecimiento,@PedidoConsultora)";

					parametros.Clear();
					parametros.Add("@IdColegiado," + txtIdColegiado.Valor);
					parametros.Add("@Canon,colegiado");
					parametros.Add("@PedidoViaAerea,N");
					parametros.Add("@PedidoPlaguicidas,N");
					parametros.Add("@PedidoPeritajes,N");
					parametros.Add("@PedidoEstablecimiento,N");
					parametros.Add("@PedidoConsultora,N");

					lbOk = Consultas.ejecutarSentenciaParametros(sInsert, parametros, ref error);
				}

			}
			else
				lbOk = false;

			return lbOk;
		}

		private bool canonesAnuales(string id, string idCanon, ref string error)
		{
			bool lbOk = true;

			string sInsert = "";
			string sSelect = "";
			DataTable dt = new DataTable();



			sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + id + "'  and Canon = '" + idCanon + "'";

			lbOk = Consultas.fillDataTable(sSelect, ref dt, ref error);

			if (lbOk && dt.Rows.Count == 0)
			{
				sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon) values ('" + id + "', '" + idCanon + "')";

				lbOk = Consultas.ejecutarSentencia(sInsert, ref error);
			}

			return lbOk;
		}

		protected override bool generarFacturas(ref string error)
		{
			bool OK = true;
			decimal montoDesc = 0;
			int porcDescuento = 0, indiceArticulo = 0;
			string ultimoCobro = "";
			//string sUpdate = "";
			//string sInsert = "";
			//DataTable dtMesCobro = new DataTable();
			DataTable dtAplicaClie = new DataTable();
			DataTable dtCliente = new DataTable();
			//DateTime mesUltCobro = DateTime.Now;
			//DateTime fechaActu = DateTime.Now;


			if (btnProcesar.Enabled)
			{
				if (tabControl.SelectedTab.Name == "tpPlantilla")
				{
					string sSelect = "select AplicaClienteErp from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = '" + txtPlantilla.Valor + "' and AplicaClienteErp = 'S'";
					OK = Consultas.fillDataTable(sSelect, ref dtAplicaClie, ref error);
				
					if (OK)
					{
						string sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + txtIdColegiado.Valor + "'";
						OK = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);
					}


					#region CREAR_NIT-CLIENTE

					if (OK && dtAplicaClie.Rows.Count > 0 && dtCliente.Rows.Count == 0)
					{

						OK = fInternas.generarNit(txtCedula.Valor, txtIdColegiado.Valor, ref dtCliente, "colegiado", ref error);

						if (OK)
							OK = fInternas.generarCliente(txtIdColegiado.Valor, ref dtCliente, "colegiado", "C", ref error);

					}

					#endregion

					if (OK)
					{
						int meses = 0; 
						
						OK = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref meses, ref error);

						string sQuery = "SELECT t4.ARTICULO, t4.DESCRIPCION, t5.PRECIO, CASE WHEN t4.ARTICULO = (SELECT CodigoArticulo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART WHERE ArticuloFms = 'S') THEN '" + meses + "' ELSE '1' END AS CANTIDAD   FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1" +
										" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
										" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t3 ON t3.CodigoPlantilla = t2.CodigoPlantilla" +
										" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t3.CodigoArticulo" +
										" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t3.CodigoArticulo" +
										" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t5.NIVEL_PRECIO AND t6.VERSION = t5.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
										" WHERE t1.IdColegiado = '" + txtIdColegiado.Valor + "'";

						DataTable dtArticulos = new DataTable();

						if (OK && Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
						{

							if (dtArticulos.Rows.Count > 0)
							{
								#region OBTENER_ARTICULOS_INCORPORACION

								if (chkRenuncia.Checked || int.Parse(txtEdad.Valor) < 25)//Si renuncia al fondo o es menor de 25 no se le cobra el FMS y se quita del dtArticulos
								{
									string sArt = "select CodigoArticulo from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART where ArticuloFms = 'S'";

									DataTable dtArticuloFms = new DataTable();

									OK = Consultas.fillDataTable(sArt, ref dtArticuloFms, ref error);

									if (OK)
									{
										if (dtArticuloFms.Rows.Count > 0)
										{
											foreach (DataRow row in dtArticulos.Rows)
											{
												if (dtArticuloFms.Rows[0][0].ToString() == row["ARTICULO"].ToString())
												{
													row.Delete();
												}
											}
											dtArticulos.AcceptChanges();
										}
										else
										{
											error = "Debe especificar el articulo FMS";
											OK = false;
										}
									}

								}
								
								#endregion

								#region GENERAR_PEDIDO

								if (OK)
									OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtIdColegiado.Valor, ref error);

								if (OK)
								{
									string factura = "";
									//if (chkPedConcepto.Checked)
									//{
									foreach (DataRow row in dtArticulos.Rows)
									{
										///OK = controlerBD.crearPedido(dtArticulos, txtIdColegiado.Valor, cantidad, montoDesc, porcDescuento, "cobro", chkPedConcepto.Checked, indiceArticulo, txtCobrador.Valor, ultimoCobro, ref error);
										///OK = controlerBD.crearPedidoGenerico(dtArticulos,txtIdColegiado.Valor,ref pedido, montoDesc, porcDescuento,chkPedConcepto.Checked,indiceArticulo,txtCobrador.Valor,"C","PEDIDOS", "COL","Incorporación-KOLEGIO "+ ultimoCobro + "", "Incorporación-KOLEGIO", ref error);
										OK = controlerBD.crearPedidoGenerico(dtArticulos, txtIdColegiado.Valor, ref factura/*pedido*/, montoDesc, porcDescuento, true, indiceArticulo, txtCobrador.Valor, "C", "PEDIDOS", "COL", "Incorporación-KOLEGIO " + ultimoCobro + "", "Incorporación-KOLEGIO", ref error);
										//string observacion = "Incorporación-KOLEGIO " + ultimoCobro + "";
										//OK = controlerBD.FacturarSinPedido(dtArticulos, txtIdColegiado.Valor, ref factura, montoDesc, porcDescuento, true, indiceArticulo, txtCobrador.Valor, "C", "FACTURAS", "COL", observacion, "Incorporación-KOLEGIO", string.Empty, string.Empty, ref error);
										indiceArticulo++;
										if (!OK)
											break;
									}
									//}
									//else
									//    OK = controlerBD.crearPedidoGenerico(dtArticulos, txtIdColegiado.Valor, ref pedido, montoDesc, porcDescuento, chkPedConcepto.Checked, indiceArticulo, txtCobrador.Valor, "C", "PEDIDOS", "COL", "Incorporación-KOLEGIO " + ultimoCobro + "", "Incorporación-KOLEGIO", ref error);
									//OK = controlerBD.crearPedido(dtArticulos, txtIdColegiado.Valor, cantidad, montoDesc, porcDescuento, "cobro", chkPedConcepto.Checked, indiceArticulo, txtCobrador.Valor, ultimoCobro, ref error);
								}

								#endregion
							}
							else
							{
								MessageBox.Show("El colegiado no tiene artículos asociados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								OK = false;
							}

						}
						else
							OK = false;

					}

				}

				if (tabControl.SelectedTab.Name == "tpViaAerea")
				{
					int indiceArt = 0;
					decimal montoDescuento = 0, porcentajeDescuento = 0;
					string factura = "";
					//DataTable dtVerificar = new DataTable();
					DataTable dtAerea = new DataTable();

					//string sSelect = "select PedidoViaAerea from "+Consultas.sqlCon.COMPAÑIA+".NV_HISTORIAL_CANONES where IdColegiado = '"+txtIdColegiado.Valor+"'";

					//OK = Consultas.fillDataTable(sSelect, ref dtVerificar, ref error);

					//if (OK)
					//{
					//if (dtVerificar.Rows.Count > 0)
					//{
					//    if (dtVerificar.Rows[0]["PedidoViaAerea"].ToString() == "N")
					//    {
					string sAerea = "SELECT t1.ARTICULO, t1.DESCRIPCION,t2.PRECIO, '1' as CANTIDAD FROM " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 on t2.ARTICULO = t1.ARTICULO" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
						" WHERE t1.ARTICULO = '" + Globales.ARTICULO_COBRO_VIA_AEREA + "'";

					OK = Consultas.fillDataTable(sAerea, ref dtAerea, ref error);

					if (OK)
						OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtIdColegiado.Valor, ref error);

					if (OK)
						OK = controlerBD.crearPedidoGenerico(dtAerea, txtIdColegiado.Valor, ref factura/*pedido*/, montoDescuento, porcentajeDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "PEDIDOS", "VIA", "Autorizados Recetar Vía Aérea-KOLEGIO", "", ref error);
					//string observacion = "Incorporación-KOLEGIO " + ultimoCobro + "";
					//OK = controlerBD.FacturarSinPedido(dtAerea, txtIdColegiado.Valor, ref factura, montoDesc, porcDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "FACTURAS", "VIA", "Autorizados Recetar Vía Aérea-KOLEGIO", string.Empty, string.Empty, string.Empty, ref error);


					string sUpdateCanones = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION SET PedidoViaAerea = 'S', NumeroViaAerea = '" + factura + "' WHERE Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

					if (OK)
						OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);

					//string sUpdatePedido = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO SET Pedido = '" + pedido + "', EstadoPedido = 'N' WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoCultivo = '" + row.Cells["colCodigoAerea"].Value.ToString() + "'";

					//if (OK)
					//    OK = Consultas.ejecutarSentencia(sUpdatePedido, ref error);
					//    }
					//}
					//else
					//{
					//    error = "El colegiado no tiene registro de canones";
					//    OK = false;
					//}
					//}
				}

				if (tabControl.SelectedTab.Name == "tpPlaguicidas")
				{
					int indiceArt = 0;
					decimal montoDescuento = 0, porcentajeDescuento = 0;
					string factura = "";
					DataTable dtVerificar = new DataTable();
					DataTable dtPlagui = new DataTable();

					//string sSelect = "select PedidoPlaguicidas from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES where IdColegiado = '" + txtIdColegiado.Valor + "'";

					//OK = Consultas.fillDataTable(sSelect, ref dtVerificar, ref error);

					//if (OK)
					//{
					//if (dtVerificar.Rows.Count > 0)
					//{
					//    if (dtVerificar.Rows[0]["PedidoPlaguicidas"].ToString() == "N")
					//    {
					string sPlagui = "SELECT t1.ARTICULO, t1.DESCRIPCION,t2.PRECIO, '1' as CANTIDAD FROM " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 on t2.ARTICULO = t1.ARTICULO" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
						" WHERE t1.ARTICULO = '" + Globales.ARTICULO_COBRO_PLAGUICIDAS + "'";

					OK = Consultas.fillDataTable(sPlagui, ref dtPlagui, ref error);

					if (OK)
						OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtIdColegiado.Valor, ref error);

					if (OK)
						OK = controlerBD.crearPedidoGenerico(dtPlagui, txtIdColegiado.Valor, ref factura/*pedido*/, montoDescuento, porcentajeDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "PEDIDOS", "IDO", "Investigación de Plaguicidas-KOLEGIO", string.Empty, ref error);
					//OK = controlerBD.FacturarSinPedido(dtPlagui, txtIdColegiado.Valor, ref factura, montoDesc, porcDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "FACTURAS", "IDO", "Investigación de Plaguicidas-KOLEGIO", string.Empty, string.Empty, string.Empty, ref error);

					string sUpdateCanones = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION SET PedidoPlaguicidas = 'S', NumeroPlaguicidas = '" + factura + "' WHERE Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

					if (OK)
						OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);


					//string sUpdatePedido = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO SET Pedido = '" + pedido + "', EstadoPedido = 'N' WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoCultivo = '" + row.Cells["colCodigoAerea"].Value.ToString() + "'";

					//if (OK)
					//    OK = Consultas.ejecutarSentencia(sUpdatePedido, ref error);
					//    }
					//}
					//else
					//{
					//    error = "El colegiado no tiene registro de canones";
					//    OK = false;
					//}
					//}
				}

				if (tabControl.SelectedTab.Name == "tpSilvestre")
				{
					int indiceArt = 0;
					decimal montoDescuento = 0, porcentajeDescuento = 0;
					string factura = "";
					DataTable dtVerificar = new DataTable();
					DataTable dtSilve = new DataTable();

					//string sSelect = "select PedidoPlaguicidas from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES where IdColegiado = '" + txtIdColegiado.Valor + "'";

					//OK = Consultas.fillDataTable(sSelect, ref dtVerificar, ref error);

					//if (OK)
					//{
					//if (dtVerificar.Rows.Count > 0)
					//{
					//    if (dtVerificar.Rows[0]["PedidoPlaguicidas"].ToString() == "N")
					//    {
					string sSilve = "SELECT t1.ARTICULO, t1.DESCRIPCION,t2.PRECIO, '1' as CANTIDAD FROM " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 on t2.ARTICULO = t1.ARTICULO" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
						" WHERE t1.ARTICULO = '" + Globales.ARTICULO_COBRO_SILVESTRE + "'";

					OK = Consultas.fillDataTable(sSilve, ref dtSilve, ref error);

					if (OK)
						OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtIdColegiado.Valor, ref error);

					if (OK)
						OK = controlerBD.crearPedidoGenerico(dtSilve, txtIdColegiado.Valor, ref factura /*pedido*/, montoDescuento, porcentajeDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "PEDIDOS", "SILV", "Vida Silvestre-KOLEGIO", "", ref error);
					//OK = controlerBD.FacturarSinPedido(dtSilve, txtIdColegiado.Valor, ref factura, montoDesc, porcDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "FACTURAS", "SILV", "Vida Silvestre-KOLEGIO", string.Empty, string.Empty, string.Empty, ref error);

					string sUpdateCanones = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION SET PedidoSilvestre = 'S', NumeroSilvestre = '" + factura + "' WHERE Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

					if (OK)
						OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);


					//string sUpdatePedido = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO SET Pedido = '" + pedido + "', EstadoPedido = 'N' WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoCultivo = '" + row.Cells["colCodigoAerea"].Value.ToString() + "'";

					//if (OK)
					//    OK = Consultas.ejecutarSentencia(sUpdatePedido, ref error);
					//    }
					//}
					//else
					//{
					//    error = "El colegiado no tiene registro de canones";
					//    OK = false;
					//}
					//}
				}

				if (tabControl.SelectedTab.Name == "tpPeritajes")
				{
					int indiceArt = 0;
					decimal montoDescuento = 0, porcentajeDescuento = 0;
					string factura = "";
					DataTable dtVerificar = new DataTable();
					DataTable dtPeri = new DataTable();

					//string sSelect = "select PedidoPeritajes from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES where IdColegiado = '" + txtIdColegiado.Valor + "'";

					//OK = Consultas.fillDataTable(sSelect, ref dtVerificar, ref error);

					//if (OK)
					//{
					//    if (dtVerificar.Rows.Count > 0)
					//    {
					//        if (dtVerificar.Rows[0]["PedidoPeritajes"].ToString() == "N")
					//        {
					string sAerea = "SELECT t1.ARTICULO, t1.DESCRIPCION,t2.PRECIO, '1' as CANTIDAD FROM " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t1" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 on t2.ARTICULO = t1.ARTICULO" +
						" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
						" WHERE t1.ARTICULO = 'KOL-018'";

					OK = Consultas.fillDataTable(sAerea, ref dtPeri, ref error);

					if (OK)
						OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtIdColegiado.Valor, ref error);

					if (OK)
						OK = controlerBD.crearPedidoGenerico(dtPeri, txtIdColegiado.Valor, ref factura /*pedido*/, montoDescuento, porcentajeDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "PEDIDOS", "PER", "Peritos y Valuadores-KOLEGIO", "", ref error);
					//OK = controlerBD.FacturarSinPedido(dtPeri, txtIdColegiado.Valor, ref factura, montoDesc, porcDescuento, false, indiceArt, txtCobrador.Valor, "ADEL", "FACTURAS", "PER", "Peritos y Valuadores-KOLEGIO", string.Empty, string.Empty, string.Empty, ref error);

					string sUpdateCanones = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION SET PedidoPeritajes = 'S', NumeroPeritajes = '" + factura + "' WHERE Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

					if (OK)
						OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);

					//string sUpdatePedido = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_VIA_AEREA_COLEGIADO SET Pedido = '" + pedido + "', EstadoPedido = 'N' WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoCultivo = '" + row.Cells["colCodigoAerea"].Value.ToString() + "'";

					//if (OK)
					//    OK = Consultas.ejecutarSentencia(sUpdatePedido, ref error);
					//        }
					//    }
					//    else
					//    {
					//        error = "El colegiado no tiene registro de canones";
					//        OK = false;
					//    }
					//}
				}

				//if (tabControl.SelectedTab.Name == "tpRegencias")
				//{

				//}


			}

			return OK;
		}

		private void verificarCanones()
		{
			string facturadoAerea = "";
			//string pagoAerea = "";
			string facturadoPlagui = "";
			//string pagoPlagui = "";
			string facturadoPeri = "";
			//string pagoPeri = "";
			string facturadoSilve = "";

			#region CANON_AEREA
			if (dgvViaAerea.Rows.Count > 0)
			{
				DataTable dtVerificarPedido = new DataTable();
				string sVerificarPedido = "select PedidoViaAerea from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

				if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
				{
					if (dtVerificarPedido.Rows.Count > 0)
					{
						if (dtVerificarPedido.Rows[0]["PedidoViaAerea"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
						{
							rbViaProcSI.Checked = true;
							rbViaProcNO.Checked = false;
						}
						else
						{
							rbViaProcSI.Checked = false;
							rbViaProcNO.Checked = true;
						}
					}
				}

				DataTable dtPedido = new DataTable();
				string sPedido = "select NumeroViaAerea from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

				if (Consultas.fillDataTable(sPedido, ref dtPedido, ref error))
				{
					if (dtPedido.Rows.Count > 0)
					{
						fInternas.seguimientoCanones(dtPedido.Rows[0]["NumeroViaAerea"].ToString(), ref facturadoAerea, ref error);
					}
				}

			}

			if (facturadoAerea == "S")
			{
				rbViaFacSI.Checked = true;
				rbViaFacNO.Checked = false;
			}
			else
			{
				rbViaFacSI.Checked = false;
				rbViaFacNO.Checked = true;
			}

			//if (pagoAerea == "S")
			//{
			//    rbViaPagoSI.Checked = true;
			//    rbViaPagoNO.Checked = false;
			//}
			//else
			//{
			//    rbViaPagoSI.Checked = false;
			//    rbViaPagoNO.Checked = true;
			//}

			#endregion

			#region CANON_PLAGUICIDA
			if (dgvInvestigacionPlaguicidas.Rows.Count > 0)
			{
				DataTable dtVerificarPedido = new DataTable();
				string sVerificarPedido = "select PedidoPlaguicidas from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

				if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
				{
					if (dtVerificarPedido.Rows.Count > 0)
					{
						if (dtVerificarPedido.Rows[0]["PedidoPlaguicidas"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
						{
							rbPlaguiProcSI.Checked = true;
							rbPlaguiProcNO.Checked = false;
						}
						else
						{
							rbPlaguiProcSI.Checked = false;
							rbPlaguiProcNO.Checked = true;
						}
					}
				}

				DataTable dtPedido = new DataTable();
				string sPedido = "select NumeroPlaguicidas from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

				if (Consultas.fillDataTable(sPedido, ref dtPedido, ref error))
				{
					if (dtPedido.Rows.Count > 0)
					{
						fInternas.seguimientoCanones(dtPedido.Rows[0]["NumeroPlaguicidas"].ToString(), ref facturadoPlagui, ref error);
					}
				}

			}

			if (facturadoPlagui == "S")
			{
				rbPlaguiFacSI.Checked = true;
				rbPlaguiFacNO.Checked = false;
			}
			else
			{
				rbPlaguiFacSI.Checked = false;
				rbPlaguiFacNO.Checked = true;
			}

			//if (pagoPlagui == "S")
			//{
			//    rbPlaguiPagoSI.Checked = true;
			//    rbPlaguiPagoNO.Checked = false;
			//}
			//else
			//{
			//    rbPlaguiPagoSI.Checked = false;
			//    rbPlaguiPagoNO.Checked = true;
			//}

			#endregion

			#region CANON_SILVESTRE
			if (dgvVidaSilvestre.Rows.Count > 0)
			{
				DataTable dtVerificarPedido = new DataTable();
				string sVerificarPedido = "select PedidoSilvestre from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

				if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
				{
					if (dtVerificarPedido.Rows.Count > 0)
					{
						if (dtVerificarPedido.Rows[0]["PedidoSilvestre"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
						{
							rbSilveProcSI.Checked = true;
							rbSilveProcNO.Checked = false;
						}
						else
						{
							rbSilveProcSI.Checked = false;
							rbSilveProcNO.Checked = true;
						}
					}
				}

				DataTable dtPedido = new DataTable();
				string sPedido = "select NumeroSilvestre from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

				if (Consultas.fillDataTable(sPedido, ref dtPedido, ref error))
				{
					if (dtPedido.Rows.Count > 0)
					{
						fInternas.seguimientoCanones(dtPedido.Rows[0]["NumeroSilvestre"].ToString(), ref facturadoSilve, ref error);
					}
				}

			}

			if (facturadoSilve == "S")
			{
				rbSilveFacSI.Checked = true;
				rbSilveFacNO.Checked = false;
			}
			else
			{
				rbSilveFacSI.Checked = false;
				rbSilveFacNO.Checked = true;
			}

			//if (pagoPlagui == "S")
			//{
			//    rbPlaguiPagoSI.Checked = true;
			//    rbPlaguiPagoNO.Checked = false;
			//}
			//else
			//{
			//    rbPlaguiPagoSI.Checked = false;
			//    rbPlaguiPagoNO.Checked = true;
			//}

			#endregion

			#region CANON_PERITAJE
			DataTable dtVerificarPerito = new DataTable();
			string sVerificarPerito = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS where IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.fillDataTable(sVerificarPerito, ref dtVerificarPerito, ref error))
			{
				if (dtVerificarPerito.Rows.Count > 0)
				{
					DataTable dtVerificarPedido = new DataTable();
					string sVerificarPedido = "select PedidoPeritajes from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

					if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
					{
						if (dtVerificarPedido.Rows.Count > 0)
						{
							if (dtVerificarPedido.Rows[0]["PedidoPeritajes"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
							{
								rbPerProcSI.Checked = true;
								rbPerProcNO.Checked = false;
							}
							else
							{
								rbPerProcSI.Checked = false;
								rbPerProcNO.Checked = true;
							}
						}
					}

					DataTable dtPedido = new DataTable();
					string sPedido = "select NumeroPeritajes from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

					if (Consultas.fillDataTable(sPedido, ref dtPedido, ref error))
					{
						if (dtPedido.Rows.Count > 0)
						{
							fInternas.seguimientoCanones(dtPedido.Rows[0]["NumeroPeritajes"].ToString(), ref facturadoAerea, ref error);
						}
					}

					if (facturadoPeri == "S")
					{
						rbPerFacSI.Checked = true;
						rbPerFacNO.Checked = false;
					}
					else
					{
						rbPerFacSI.Checked = false;
						rbPerFacNO.Checked = true;
					}

					//if (pagoPeri == "S")
					//{
					//    rbPerPagoSI.Checked = true;
					//    rbPerPagoNO.Checked = false;
					//}
					//else
					//{
					//    rbPerPagoSI.Checked = false;
					//    rbPerPagoNO.Checked = true;
					//}

				}
			}

			#endregion
		}

		private void cargarFechaModBasicos()
		{
			DataTable dtFechaModEmail = new DataTable();
			string sFechaModEmail = "SELECT TOP 1 Fechahora FROM dbo.AUDITORIA WHERE Opcion = 'Email' and Registro = '" + txtIdColegiado.Valor + "' ORDER BY FechaHora DESC";

			if (Consultas.fillDataTable(sFechaModEmail, ref dtFechaModEmail, ref error))
			{
				if (dtFechaModEmail.Rows.Count > 0)
				{
					dtpFechaModEmail.Value = DateTime.Parse(dtFechaModEmail.Rows[0]["Fechahora"].ToString());
				} else
				{
					dtpFechaModEmail.Visible = false;
				}
			}

			DataTable dtFechaModCel = new DataTable();
			string sFechaModCel = "SELECT TOP 1 Fechahora FROM dbo.AUDITORIA WHERE Opcion = 'TelefonoCelular' and Registro = '" + txtIdColegiado.Valor + "' ORDER BY FechaHora DESC";
				
			if (Consultas.fillDataTable(sFechaModCel, ref dtFechaModCel, ref error))
			{
				if (dtFechaModCel.Rows.Count > 0)
				{
					dtpFechaModCelular.Value = DateTime.Parse(dtFechaModCel.Rows[0]["Fechahora"].ToString());
				}
				else
				{
					dtpFechaModCelular.Visible = false;
				}
			}

			DataTable dtFechaModDireccion = new DataTable();
			string sFechaModDireccion = "SELECT TOP 1 Fechahora FROM dbo.AUDITORIA WHERE Opcion = 'Direccion' and Registro = '" + txtIdColegiado.Valor + "' ORDER BY FechaHora DESC";

			if (Consultas.fillDataTable(sFechaModDireccion, ref dtFechaModDireccion, ref error))
			{
				if (dtFechaModDireccion.Rows.Count > 0)
				{
                    lblModificaDireccion.Visible = true;
                    dtpFechaModDireccion.Value = DateTime.Parse(dtFechaModDireccion.Rows[0]["Fechahora"].ToString());
				}
				else
				{
					lblModificaDireccion.Visible = false;
					dtpFechaModDireccion.Visible = false;
				}
			}
		}

		private void listaCategorias()
		{
			Listado listP = new Listado();
			//listP.COLUMNAS = "CATEGORIA_CLIENTE as Categoría,DESCRIPCION as Descripción,U_CONSECUTIVO Consecutivo";
			listP.COLUMNAS = "CATEGORIA_CLIENTE as Categoría,DESCRIPCION as Descripción";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "CATEGORIA_CLIENTE";
			listP.FILTRO = "WHERE U_KOLEGIO='S'";
			listP.ORDERBY = "order by CATEGORIA_CLIENTE";
			listP.TITULO_LISTADO = "Categorías";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				string cons = "";
				txtCategoria.Valor = f1.item.SubItems[0].Text;
				txtDescCategoria.Valor = f1.item.SubItems[1].Text;
				//consecutivoColegiado = f1.item.SubItems[2].Text;
				////if(oldValue != txtCategoria.Valor)
				////{
				////    crearConsecutivo(ref cons);
				////    oldValue = txtCategoria.Valor;
				////}
			}
		}

		private void listaCategoriasRegente()
		{
			//bool ok = true;
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoCategoria as Categoría,NombreCategoria as Nombre";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
			listP.ORDERBY = "order by CodigoCategoria";
			listP.FILTRO = "where NumRegistroEstablecimiento = '" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value + "'";
			listP.TITULO_LISTADO = "Categorias";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();

			if (f1Colegiado.item != null)
			{

				dgvEstablecimientos.CurrentCell.Value = f1Colegiado.item.SubItems[1].Text;
				dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoCategoria"].Value = f1Colegiado.item.SubItems[0].Text;
				dgvEstablecimientos.EndEdit();
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}


		}

		private void buscaEntidad(string codigo)
		{

			if (txtEntidadFinanciera.Valor.Trim() == "")
			{
				txtDescEntidadFinanciera.Clear();
				return;
			}

			DataTable dt = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "ENTIDAD_FINANCIERA,DESCRIPCION";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "ENTIDAD_FINANCIERA";
			listP.FILTRO = "where ENTIDAD_FINANCIERA = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					txtDescEntidadFinanciera.Valor = dt.Rows[0]["DESCRIPCION"].ToString();
				}
				else
				{
					if (codigo != "")
					{
						MessageBox.Show("El código de la entidad financiera digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtEntidadFinanciera.Clear();
						txtDescEntidadFinanciera.Clear();
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaCobrador(string codigo, string identificador)
		{

			if (txtCobrador.Valor.Trim() == "")
			{
				txtDescCobrador.Clear();
				return;
			}

			DataTable dtCobrador = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "Cobrador,Nombre";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "COBRADOR";
			listP.FILTRO = "where Cobrador = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtCobrador, ref error))
			{
				if (dtCobrador.Rows.Count > 0)
				{
					if (identificador == "C")
						txtDescCobrador.Valor = dtCobrador.Rows[0]["Nombre"].ToString();

					if (identificador == "P")
						txtCobradorPeritajeNombre.Valor = dtCobrador.Rows[0]["Nombre"].ToString();

					if (identificador == "R")
						txtCobradorNombre.Valor = dtCobrador.Rows[0]["Nombre"].ToString();
				}
				else
				{
					if (codigo != "")
					{
						MessageBox.Show("El código de cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						if (identificador == "C")
						{
							txtCobrador.Clear();
							txtDescCobrador.Clear();
						}

						if (identificador == "P")
						{
							txtCobradorPeritaje.Clear();
							txtCobradorPeritajeNombre.Clear();
						}

						if (identificador == "R")
						{
							txtCobradorRegente.Clear();
							txtCobradorNombre.Clear();
						}
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void cargarCategoria(string categoria)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "CATEGORIA_CLIENTE";
			listA.FILTRO = "where CATEGORIA_CLIENTE = '" + categoria + "' AND U_KOLEGIO='S'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCategoria.Valor = dtTTs.Rows[0]["CATEGORIA_CLIENTE"].ToString();
					txtDescCategoria.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
					//consecutivoColegiado = dtTTs.Rows[0]["U_CONSECUTIVO"].ToString();
				}
				else
				{
					limpiarCategoria();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarCategoria()
		{
			txtCategoria.Clear();
			txtDescCategoria.Clear();
			//consecutivoColegiado = "";
		}

		private void listaCondiciones()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición,CodigoPlantilla";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "NV_CONDICIONES";
			listD.TITULO_LISTADO = "Condiciones Colegiado";
			listD.COLUMNAS_OCULTAS.Add("CodigoPlantilla");

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtCondicion.Valor = f1.item.SubItems[0].Text;
				txtDescCondicion.Valor = f1.item.SubItems[1].Text;
				Plantilla = f1.item.SubItems[2].Text;
				cargarPlantilla();
			}
		}

		private void cargarHistorialAcademico()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "t1.CodigoCentro,(select NombreCentro from " + Consultas.sqlCon.COMPAÑIA + ".NV_CENTROS where CodigoCentro = t1.CodigoCentro) as NomCentro, t1.CodigoCarrera,(select NombreCarrera from " + Consultas.sqlCon.COMPAÑIA + ".NV_CARRERAS where CodigoCarrera = t1.CodigoCarrera) as NomCarrera,t1.CodigoGrado, (select NombreGrado from " + Consultas.sqlCon.COMPAÑIA + ".NV_GRADOS where Codigogrado = t1.CodigoGrado) as NomGrado, t1.Enfasis,(select NombreOrientacion from " + Consultas.sqlCon.COMPAÑIA + ".NV_ORIENTACIONES where CodigoOrientacion = t1.Enfasis) as NomEnfasis,t1.Pais,(select NOMBRE from " + Consultas.sqlCon.COMPAÑIA + ".PAIS where PAIS = t1.Pais) as NomPais, t1.FechaGraduacion";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_HISTORIAL_ACADEMICO t1";
			listA.FILTRO = "where NumeroColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvHistorialAcademico.Rows.Clear();
					foreach (DataRow r in dt.Rows)
					{
						dgvHistorialAcademico.Rows.Add(r["CodigoCentro"].ToString(), r["NomCentro"].ToString(), r["CodigoCarrera"].ToString(), r["NomCarrera"].ToString(), r["CodigoGrado"].ToString(), r["NomGrado"].ToString(), r["Pais"].ToString(), r["NomPais"].ToString(), r["Enfasis"].ToString(), r["NomEnfasis"].ToString(), DateTime.Parse(r["FechaGraduacion"].ToString()).ToString("dd/MM/yyyy"));
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarHistorialLaboral()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			//listA.COLUMNAS = "t1.Empresa,t1.CodigoPuesto,t1.RangoDesde,t1.RangoHasta,t1.TelefonoEmpresa,(select NombrePuesto from " + Consultas.sqlCon.COMPAÑIA + ".NV_PUESTOS where CodigoPuesto = t1.CodigoPuesto) as NomPuesto, t1.CorreoEmpresa, t1.DireccionEmpresa";
			listA.COLUMNAS = "t1.Empresa,t1.Puesto,t1.RangoDesde,t1.RangoHasta,t1.TelefonoEmpresa,t1.CorreoEmpresa, t1.DireccionEmpresa";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_HISTORIAL_LABORAL t1";
			listA.FILTRO = "where NumeroColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvHistorialLaboral.Rows.Clear();
					foreach (DataRow r in dt.Rows)
					{
						dgvHistorialLaboral.Rows.Add(r["Empresa"].ToString(), string.Empty/*r["CodigoPuesto"].ToString()*/, r["Puesto"].ToString(), r["TelefonoEmpresa"].ToString(), r["CorreoEmpresa"].ToString(), DateTime.Parse(r["RangoDesde"].ToString()).ToString("dd/MM/yyyy"), r["RangoHasta"].ToString() != "" ? DateTime.Parse(r["RangoHasta"].ToString()).ToString("dd/MM/yyyy") : "", r["DireccionEmpresa"].ToString());
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarHistorialCambioCondicion()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_HISTORIAL_CAMBIO_COND_POR_COLEGIADO";
			listA.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvHistorialSesiones.Rows.Clear();
					foreach (DataRow r in dt.Rows)
					{
						dgvHistorialSesiones.Rows.Add(r["SesionAprobacion"].ToString(), DateTime.Parse(r["FechaAprobacion"].ToString()).ToString("dd/MM/yyyy"), r["Condición Pevia"].ToString(), r["Condición Nueva"].ToString());
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}


		private void cargarGestionCobro()
		{
			DataTable dt = new DataTable();

			string sQuery = "select Id, Medio, FechaGestion, Compromiso, FechaCompromiso, Observaciones, Estado from " + Consultas.sqlCon.COMPAÑIA + ".NV_GESTION_COBRO where IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvGestionCobro2.Rows.Clear();
					foreach (DataRow row in dt.Rows)
					{
						dgvGestionCobro2.Rows.Add(row["Id"].ToString(), row["Medio"].ToString(), row["FechaGestion"].ToString() != "" ? DateTime.Parse(row["FechaGestion"].ToString()).ToString("dd/MM/yyyy") : "", row["Compromiso"].ToString(), row["FechaCompromiso"].ToString() != "" ? DateTime.Parse(row["FechaCompromiso"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString(), fInternas.obtenerEstadoGestionCobro(row["Estado"].ToString()));
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			string sQueryAdelantos = "select 'Colegiatura' as Tipo,'N/A' as Nombre,'N/A' as NombreCategoria,MesUltimoCobro from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_COLEGIATURAS where IdColegiado = '" + txtIdColegiado.Valor + "'" +
								" union all" +
								" select 'Regencia' as Tipo, t2.Nombre, t3.NombreCategoria, t1.MesUltimoCobro from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_REGENCIAS t1" +
								" join " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS t2 on t2.NumRegistro = t1.NumRegistro" +
								" join " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t3 on t3.CodigoCategoria = t1.Categoria where t1.IdColegiado = '" + txtIdColegiado.Valor + "'";

			dt = new DataTable();

			if (Consultas.fillDataTable(sQueryAdelantos, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvGestionCobroAdel.Rows.Clear();
					foreach (DataRow row in dt.Rows)
					{
						dgvGestionCobroAdel.Rows.Add(row["Tipo"].ToString(), row["Nombre"].ToString(), row["NombreCategoria"].ToString(), row["MesUltimoCobro"].ToString() != "" ? DateTime.Parse(row["MesUltimoCobro"].ToString()).ToString("MM/yyyy") : "");
					}
				}

			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			string sQueryDetalle = "select t1.DOCUMENTO,APLICACION,FECHA,MONTO,SALDO from " + Consultas.sqlCon.COMPAÑIA + ".DOCUMENTOS_CC t1" +
						" join " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 on t2.IdColegiado = t1.CLIENTE" +
						" where t1.CLIENTE = '" + txtIdColegiado.Valor + "' and t1.SALDO > 0 and (t1.TIPO = 'FAC' or t1.TIPO = 'O/D')";

			dt = new DataTable();

			if (Consultas.fillDataTable(sQueryDetalle, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvGestionCobro.Rows.Clear();
					foreach (DataRow row in dt.Rows)
					{
						dgvGestionCobro.Rows.Add(row["DOCUMENTO"].ToString(), row["APLICACION"].ToString(), row["FECHA"].ToString() != "" ? DateTime.Parse(row["FECHA"].ToString()).ToString("dd/MM/yyyy") : "", decimal.Parse(row["MONTO"].ToString()).ToString("N2"), decimal.Parse(row["SALDO"].ToString()).ToString("N2"));
					}
				}

			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarCondicion(string condicion)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_CONDICIONES";
			listA.FILTRO = "where CodigoCondicion = '" + condicion + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCondicion.Valor = dtTTs.Rows[0]["CodigoCondicion"].ToString();
					txtDescCondicion.Valor = dtTTs.Rows[0]["NombreCondicion"].ToString();
					Plantilla = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
					cargarPlantilla();
				}
				else
				{
					limpiarCondicion();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void buscaCondicion(string condicion, ref string plantilla)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_CONDICIONES";
			listA.FILTRO = "where CodigoCondicion = '" + condicion + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCondicion.Valor = dtTTs.Rows[0]["CodigoCondicion"].ToString();
					txtDescCondicion.Valor = dtTTs.Rows[0]["NombreCondicion"].ToString();
					plantilla = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
					//cargarPlantilla();
				}
				else
				{
					limpiarCondicion();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarBeneficiario(string benef)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "Cedula,(select Nombre+' '+PrimerApellido+' '+SegundoApellido from " + Consultas.sqlCon.COMPAÑIA + ".NV_BENEFICIARIOS where NumeroColegiado = '" + txtIdColegiado.Valor + "' and Cedula = '" + benef + "') NombreBene";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_BENEFICIARIOS";
			listA.FILTRO = "where NumeroColegiado = '" + txtIdColegiado.Valor + "' and Cedula = '" + benef + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtBeneficiarioCheque.Valor = dtTTs.Rows[0]["Cedula"].ToString();
					txtBeneChequeNombre.Valor = dtTTs.Rows[0]["NombreBene"].ToString();
				}
				else
				{

				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarCondicion()
		{
			txtCondicion.Clear();
			txtDescCondicion.Clear();
		}

		private void listaCobradores(string identificador)
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "COBRADOR as Código,NOMBRE as Nombre";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "COBRADOR";
			listD.TITULO_LISTADO = "Cobradores";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				if (identificador == "C")
				{
					txtCobrador.Valor = f1.item.SubItems[0].Text;
					txtDescCobrador.Valor = f1.item.SubItems[1].Text;
				}

				if (identificador == "P")
				{
					txtCobradorPeritaje.Valor = f1.item.SubItems[0].Text;
					txtCobradorPeritajeNombre.Valor = f1.item.SubItems[1].Text;
				}

				if (identificador == "R")
				{
					txtCobradorRegente.Valor = f1.item.SubItems[0].Text;
					txtCobradorNombre.Valor = f1.item.SubItems[1].Text;

				}

				if (identificador == "ESTABLE")
				{
					dgvEstablecimientos.CurrentCell.Value = f1.item.SubItems[1].Text;
					dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoCobrador"].Value = f1.item.SubItems[0].Text;
					dgvEstablecimientos.EndEdit();

				}

			}
		}

		private void listaEntidadesFinancieras()
		{
			Listado listD = new Listado();
			listD.COLUMNAS = "ENTIDAD_FINANCIERA as Código,DESCRIPCION as Nombre";
			listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listD.TABLA = "ENTIDAD_FINANCIERA";
			listD.TITULO_LISTADO = "Entidades Financieras";

			frmF1 f1 = new frmF1(listD);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtEntidadFinanciera.Valor = f1.item.SubItems[0].Text;
				txtDescEntidadFinanciera.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarEntidad(string codigo)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "ENTIDAD_FINANCIERA,DESCRIPCION";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "ENTIDAD_FINANCIERA";
			listA.FILTRO = "where ENTIDAD_FINANCIERA = '" + codigo + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtEntidadFinanciera.Valor = dtTTs.Rows[0]["ENTIDAD_FINANCIERA"].ToString();
					txtDescEntidadFinanciera.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
				}
				else
				{
					txtEntidadFinanciera.Clear();
					txtDescEntidadFinanciera.Clear();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarCobrador(string cobrador)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "COBRADOR";
			listA.FILTRO = "where COBRADOR = '" + cobrador + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCobrador.Valor = dtTTs.Rows[0]["COBRADOR"].ToString();
					txtDescCobrador.Valor = dtTTs.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					limpiarCobrador();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarCobrador()
		{
			txtCobrador.Clear();
			txtDescCobrador.Clear();
		}



		private void listaCentros()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoCentro as Código,NombreCentro as 'Centro Académico'";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CENTROS";
			listP.ORDERBY = "order by CodigoCentro";
			listP.TITULO_LISTADO = "Centros Académicos";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtCentroAcademico.Valor = f1.item.SubItems[0].Text;
				txtCentroAcademicoN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarCentro(string centro)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_CENTROS";
			listA.FILTRO = "where CodigoCentro = '" + centro + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCentroAcademico.Valor = dtTTs.Rows[0]["CodigoCentro"].ToString();
					txtCentroAcademicoN.Valor = dtTTs.Rows[0]["NombreCentro"].ToString();
				}
				else
				{
					limpiarCategoria();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarCentro()
		{
			txtCentroAcademico.Clear();
			txtCentroAcademicoN.Clear();
		}

		private void listaTitulos()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoCarrera as Código,NombreCarrera as Título";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CARRERAS";
			listP.ORDERBY = "order by CodigoCarrera";
			listP.TITULO_LISTADO = "Títulos Académicos";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtTituloAcademico.Valor = f1.item.SubItems[0].Text;
				txtTituloAcademicoN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarTitulo(string titulo)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_CARRERAS";
			listA.FILTRO = "where CodigoCarrera = '" + titulo + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtTituloAcademico.Valor = dtTTs.Rows[0]["CodigoCarrera"].ToString();
					txtTituloAcademicoN.Valor = dtTTs.Rows[0]["NombreCarrera"].ToString();
				}
				else
				{
					limpiarTitulo();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarTitulo()
		{
			txtTituloAcademico.Clear();
			txtTituloAcademicoN.Clear();
		}

		private void listaEmpresas()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoEmpresa as Código,NombreEmpresa as Empresa";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_EMPRESAS";
			listP.ORDERBY = "order by CodigoEmpresa";
			listP.TITULO_LISTADO = "Empresas";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtEmpresa.Valor = f1.item.SubItems[0].Text;
				txtEmpresaN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void listaPuestos()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoPuesto as Código,NombrePuesto as Puesto";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_PUESTOS";
			listP.ORDERBY = "order by CodigoPuesto";
			listP.TITULO_LISTADO = "Puestos";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtPuesto.Valor = f1.item.SubItems[0].Text;
				txtDescPuesto.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void listaBeneficiarios()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "Cedula Cédula,Nombre+' '+PrimerApellido+' '+SegundoApellido [Nombre Beneficiario]";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_BENEFICIARIOS";
			listP.ORDERBY = "order by Nombre";
			listP.FILTRO = "WHERE NumeroColegiado = '" + txtIdColegiado.Valor + "'";
			listP.TITULO_LISTADO = "Beneficiarios";



			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtBeneficiarioCheque.Valor = f1.item.SubItems[0].Text;
				txtBeneChequeNombre.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void listaInstituciones()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoEmpresa as Código,NombreEmpresa as Empresa";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_EMPRESAS";
			listP.ORDERBY = "order by CodigoEmpresa";
			listP.TITULO_LISTADO = "Empresas";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtInstitucion.Valor = f1.item.SubItems[0].Text;
				txtNombreInstitucion.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void listaEstablecimientos()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "NumRegistro as [Numero de Registro],NumInscripcion as [Numero de Inscripción], Nombre, Representante";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ESTABLECIMIENTOS";
			listP.ORDERBY = "order by Nombre";
			listP.TITULO_LISTADO = "Establecimientos";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtEmpresa.Valor = f1.item.SubItems[0].Text;
				txtEmpresaN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void listaEstablecimientosRegentes()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "NumRegistro as Código,Nombre";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ESTABLECIMIENTOS ";
			listP.ORDERBY = "order by NumRegistro";
			listP.TITULO_LISTADO = "Establecimientos";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();
			if (f1Colegiado.item != null)
			{
				//foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
				//{
				//    if (row.Cells["colCodigoEstablecimiento"].Value.ToString() == f1Colegiado.item.SubItems[0].Text)
				//    {
				//        MessageBox.Show("Este establecimiento ya fue agregado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				//        dgvEstablecimientos.EndEdit();
				//        return;
				//    }
				//}
				dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value = f1Colegiado.item.SubItems[0].Text;
				dgvEstablecimientos.CurrentCell.OwningRow.Cells["colNombreEstablecimiento"].Value = f1Colegiado.item.SubItems[1].Text;
				dgvEstablecimientos.EndEdit();
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}
		}

		private void cargarEmpresa(string titulo)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_EMPRESAS";
			listA.FILTRO = "where CodigoEmpresa = '" + titulo + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtEmpresa.Valor = dtTTs.Rows[0]["CodigoEmpresa"].ToString();
					txtEmpresaN.Valor = dtTTs.Rows[0]["NombreEmpresa"].ToString();
				}
				else
				{
					limpiarEmpresa();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarPuesto(string puesto)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_PUESTOS";
			listA.FILTRO = "where CodigoPuesto = '" + puesto + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtPuesto.Valor = dtTTs.Rows[0]["CodigoPuesto"].ToString();
					txtDescPuesto.Valor = dtTTs.Rows[0]["NombrePuesto"].ToString();
				}
				else
				{
					limpiarPuesto();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarInstitucion(string titulo)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_EMPRESAS";
			listA.FILTRO = "where CodigoEmpresa = '" + titulo + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtInstitucion.Valor = dtTTs.Rows[0]["CodigoEmpresa"].ToString();
					txtNombreInstitucion.Valor = dtTTs.Rows[0]["NombreEmpresa"].ToString();
				}
				else
				{
					txtInstitucion.Clear();
					txtNombreInstitucion.Clear();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarEmpresa()
		{
			txtEmpresa.Clear();
			txtEmpresaN.Clear();
		}

		private void limpiarPuesto()
		{
			txtPuesto.Clear();
			txtDescPuesto.Clear();
		}

		private void listaEspecialidades()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoEspecialidad as Código,NombreEspecialidad as Especialidad";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ESPECIALIDADES";
			listP.ORDERBY = "order by CodigoEspecialidad";
			listP.TITULO_LISTADO = "Especialidades";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtEspecialidad.Valor = f1.item.SubItems[0].Text;
				txtEspecialidadN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarEspecialidad(string especialidad)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_ESPECIALIDADES";
			listA.FILTRO = "where CodigoEspecialidad = '" + especialidad + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtEspecialidad.Valor = dtTTs.Rows[0]["CodigoEspecialidad"].ToString();
					txtEspecialidadN.Valor = dtTTs.Rows[0]["NombreEspecialidad"].ToString();
				}
				else
				{
					limpiarEspecialidad();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarEspecialidad()
		{
			txtEspecialidad.Clear();
			txtEspecialidadN.Clear();
		}

		private void listaCamposEspecialidad()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoCampo as Código,NombreCampo as 'Campo Especialidad'";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CAMPOS_ESPECIALIDAD";
			listP.ORDERBY = "order by CodigoCampo";
			listP.TITULO_LISTADO = "Campos Especialidad";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtCampoEspecialidad.Valor = f1.item.SubItems[0].Text;
				txtCampoEspecialidadN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarCampoEspecialidad(string campo)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_CAMPOS_ESPECIALIDAD";
			listA.FILTRO = "where CodigoCampo = '" + campo + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtCampoEspecialidad.Valor = dtTTs.Rows[0]["CodigoCampo"].ToString();
					txtCampoEspecialidadN.Valor = dtTTs.Rows[0]["NombreCampo"].ToString();
				}
				else
				{
					limpiarCampo();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarCampo()
		{
			txtCampoEspecialidad.Clear();
			txtCampoEspecialidadN.Clear();
		}

		private void listaTiposPeritos()
		{
			DataTable dtTpos = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "CodigoTipo,NombreTipo";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_TIPOS";
			listA.FILTRO = "where Diferenciador = 'P'";
			listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dtTpos, ref error))
			{
				if (dtTpos.Rows.Count > 0)
				{
					cmbTipoPerito.DataSource(dtTpos, "CodigoTipo", "NombreTipo");
					cmbTipoPerito.Valor = "";
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void listaTiposRegentes()
		{
			DataTable dtTpos = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "CodigoTipo,NombreTipo";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_TIPOS";
			listA.FILTRO = "where Diferenciador = 'R'";
			listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dtTpos, ref error))
			{
				if (dtTpos.Rows.Count > 0)
				{
					cmbTipoRegente.DataSource(dtTpos, "CodigoTipo", "NombreTipo");
					cmbTipoRegente.Valor = "";
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void listaOrientaciones()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoOrientacion as Código,NombreOrientacion as Orientación";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_ORIENTACIONES";
			listP.ORDERBY = "order by CodigoOrientacion";
			listP.TITULO_LISTADO = "Énfasis";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				txtEnfasis.Valor = f1.item.SubItems[0].Text;
				txtEnfasisN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarOrientacion(string orientacion)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_ORIENTACIONES";
			listA.FILTRO = "where CodigoOrientacion = '" + orientacion + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					txtEnfasis.Valor = dtTTs.Rows[0]["CodigoOrientacion"].ToString();
					txtEnfasisN.Valor = dtTTs.Rows[0]["NombreOrientacion"].ToString();
				}
				else
				{
					limpiarOrientacion();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void limpiarOrientacion()
		{
			//txtOrientacion.Clear();
			//txtOrientacionN.Clear();
			txtEnfasisN.Clear();
			txtEnfasis.Clear();
		}

		private void listaPlantillas()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "DISTINCT a.CodigoPlantilla as Código,(SELECT NombrePlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where a.CodigoPlantilla = CodigoPlantilla) as Plantilla";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_MACHOTES_ART a";
			listP.ORDERBY = "order by a.CodigoPlantilla";
			listP.TITULO_LISTADO = "Plantillas";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				dgvPlantilla.Rows.Clear();
				txtPlantilla.Valor = f1.item.SubItems[0].Text;
				txtPlantillaN.Valor = f1.item.SubItems[1].Text;
			}
		}

		private void cargarPlantilla()
		{
			DataTable dt = new DataTable();
			string sQuery = "";
			//sQuery = "select t1.CodigoPlantilla, t4.NombrePlantilla, t1.CodigoCondicion, t1.CodigoArticulo, t2.DESCRIPCION as DesArticulo, t3.PRECIO, t4.CodigoFrecuencia, t5.DESCRIPCION as DesFrecuencia, t5.DIAS_NETO, t1.PedidoPorConcepto from "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES_COLEGIADO t1" +
			//" join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t2 on t1.CodigoArticulo = t2.ARTICULO" +
			//" join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t3 on t1.CodigoArticulo = t3.ARTICULO" +
			//" join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t4 on t1.CodigoPlantilla = t4.CodigoPlantilla" +
			//" left join " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO t5 on t5.CONDICION_PAGO = t4.CodigoFrecuencia" +
			//" where NumeroColegiado = '" + txtIdColegiado.Valor + "' and CodigoCondicion = '" + txtCondicion.Valor + "'";
			sQuery = "SELECT t6.CodigoPlantilla, t6.NombrePlantilla, t1.Condicion as CodigoCondicion, t4.ARTICULO as CodigoArticulo, t4.DESCRIPCION as DesArticulo, t5.PRECIO FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t1 " +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES t2 ON t2.CodigoCondicion = t1.Condicion" +
					" join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t6 on t6.CodigoPlantilla = t2.CodigoPlantilla" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t3 ON t3.CodigoPlantilla = t6.CodigoPlantilla" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t4 on t4.ARTICULO = t3.CodigoArticulo" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t5 on t5.ARTICULO = t3.CodigoArticulo" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t7 on t7.NIVEL_PRECIO = t5.NIVEL_PRECIO AND t7.VERSION = t5.VERSION AND (CAST(getdate() AS date) BETWEEN t7.FECHA_INICIO AND t7.FECHA_CORTE) AND t7.ESTADO = 'A'" +
					" WHERE t1.IdColegiado = '" + txtIdColegiado.Valor + "'";

			// Listado listA = new Listado();
			//listA.COLUMNAS = "*,(SELECT CodigoFrecuencia from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO.CodigoPlantilla) as CodFrecuencia,(SELECT NombrePlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where CodigoPlantilla = " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO.CodigoPlantilla) as DESPLANTILLA,(SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = CodigoArticulo) as DES,(SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO = CodigoFrecuencia) as DESCRIPCION,(SELECT DIAS_NETO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO where CONDICION_PAGO = CodigoFrecuencia) as DIAS_NETO";
			//listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			//listA.TABLA = "NV_MACHOTES_COLEGIADO";
			// listA.FILTRO = "where NumeroColegiado = '" + txtNumeColegiado.Valor + "' and CodigoCondicion = '" + txtCondicion.Valor + "'";

			//if (Consultas.listarDatos(listA, ref dt, ref error))
			if (Consultas.fillDataTable(sQuery, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvPlantilla.Rows.Clear();
					totalPlantillaCobro = 0;
					foreach (DataRow row in dt.Rows)
					{
						//txtPlantilla.ReadOnly = false;
						//dgvPlantilla.Rows.Add(r["CodigoPlantilla"].ToString(), r["CodigoCondicion"].ToString(), r["CodigoArticulo"].ToString(), r["DES"].ToString()/*, r["Activo"].ToString() == "S" ? true : false, r["Desde"].ToString() != "" ? DateTime.Parse(r["Desde"].ToString()).ToString("dd/MM/yyyy") : string.Empty, r["Hasta"].ToString() != "" ? DateTime.Parse(r["Hasta"].ToString()).ToString("dd/MM/yyyy") : string.Empty*/, decimal.Parse(r["Monto"].ToString())/*, r["CodigoForma"].ToString(), r["CodigoFrecuencia"].ToString(), r["DESCRIPCION"].ToString(), r["DIAS_NETO"].ToString()*/);
						//txtPlantilla.Valor = r["CodigoPlantilla"].ToString();
						//txtPlantillaN.Valor = r["DESPLANTILLA"].ToString();
						//txtFrecu.Valor = r["CodFrecuencia"].ToString();
						//txtFrecuDescripcion.Valor = r["DESCRIPCION"].ToString();
						//txtFrecuDias.Valor = r["DIAS_NETO"].ToString();
						dgvPlantilla.Rows.Add(row["CodigoPlantilla"].ToString(), row["CodigoCondicion"].ToString(), row["CodigoArticulo"].ToString(), row["DesArticulo"].ToString(), decimal.Parse(row["PRECIO"].ToString()));
						txtPlantilla.Valor = row["CodigoPlantilla"].ToString();
						txtPlantillaN.Valor = row["NombrePlantilla"].ToString();
						totalPlantillaCobro += decimal.Parse(row["PRECIO"].ToString());
						//txtFrecu.Valor = row["CodigoFrecuencia"].ToString();
						//txtFrecuDescripcion.Valor = row["DesFrecuencia"].ToString();
						//txtFrecuDias.Valor = row["DIAS_NETO"].ToString();
						//if (row["PedidoPorConcepto"].ToString() == "S")
						//    chkPedConcepto.Checked = true;
						//else
						//    chkPedConcepto.Checked = false;

						/*if(r["Activo"].ToString() == "N")
                        {
                            dgvPlantilla.Rows[dt.Rows.IndexOf(r)].Cells["colDesdeArticulo"].Style.BackColor = Color.White;
                            dgvPlantilla.Rows[dt.Rows.IndexOf(r)].Cells["colHastaArticulo"].Style.BackColor = Color.White;
                        }*/
					}
					lblCantTotalPlantillaCobro.Text = totalPlantillaCobro.ToString("N2");
				}
				else
				{
					puntoPartida();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void puntoPartida()
		{
			//DataTable dtTTs = new DataTable();
			//Listado listA = new Listado();

			//listA.COLUMNAS = "art.*,(SELECT NombrePlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where art.CodigoPlantilla = CodigoPlantilla) as Plantilla,(SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = art.CodigoArticulo) as DES," +
			//    "(SELECT case when COSTO_FISCAL = 'P' then COSTO_PROM_LOC else COSTO_STD_LOC end from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = art.CodigoArticulo) as 'Costo Local'," +
			//    "(SELECT case when COSTO_FISCAL = 'P' then COSTO_PROM_DOL else COSTO_STD_DOL end from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = art.CodigoArticulo) as 'Costo Dólar'" +
			//    ",(SELECT CodigoFrecuencia from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES  WHERE art.CodigoPlantilla = CodigoPlantilla) as Cod," + 
			//    "(SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES machote on art.CodigoPlantilla = machote.CodigoPlantilla where CONDICION_PAGO = machote.CodigoFrecuencia) as DESCRIPCION," + 
			//    "(SELECT DIAS_NETO from " + Consultas.sqlCon.COMPAÑIA + ".CONDICION_PAGO join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES machote on art.CodigoPlantilla = machote.CodigoPlantilla where CONDICION_PAGO = machote.CodigoFrecuencia) as DIAS_NETO";
			//listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			//listA.TABLA = "NV_MACHOTES_ART art ";
			//listA.FILTRO = "where art.CodigoPlantilla = '" + Plantilla + "'";

			DataTable dtTTs = new DataTable();
			string sQuery = "";
			//sQuery = "select art.CodigoPlantilla,art.CodigoArticulo,(SELECT NombrePlantilla from "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES where art.CodigoPlantilla = CodigoPlantilla) as Plantilla," +
			//        " (SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = art.CodigoArticulo) as DesArticulo," +
			//        " (SELECT PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO  where ARTICULO = art.CodigoArticulo) as 'PRECIO'" +
			//        " from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART art" +
			//        " where art.CodigoPlantilla = '" + Plantilla + "'";

			sQuery = "select t1.CodigoPlantilla,t1.CodigoArticulo,t2.NombrePlantilla as Plantilla,t3.DESCRIPCION as DesArticulo,t4.PRECIO as 'PRECIO'" +
					" from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t1" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES t2 on t2.CodigoPlantilla = t1.CodigoPlantilla" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t1.CodigoArticulo" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t1.CodigoArticulo" +
					" JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND(CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
					" where t1.CodigoPlantilla = '" + Plantilla + "'";


			if (Consultas.fillDataTable(sQuery, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					//dgvPlantilla.Rows.Clear();
					//txtPlantilla.Valor = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
					//txtPlantillaN.Valor = dtTTs.Rows[0]["Plantilla"].ToString();
					//txtFrecu.Valor = dtTTs.Rows[0]["Cod"].ToString();
					//txtFrecuDescripcion.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
					//txtFrecuDias.Valor = dtTTs.Rows[0]["DIAS_NETO"].ToString();
					//dgvPlantilla.Rows.Clear();
					//foreach (DataRow r in dtTTs.Rows)
					//{
					//    dgvPlantilla.Rows.Add(txtPlantilla.Valor, txtCondicion.Valor, r["CodigoArticulo"].ToString(), r["DES"].ToString(), /*true,*/ /*string.Empty, string.Empty,*/ decimal.Parse(r["Costo Local"].ToString())/*, r["Cod"].ToString(), r["DESCRIPCION"].ToString(), r["DIAS_NETO"].ToString()*/);
					//}
					dgvPlantilla.Rows.Clear();
					foreach (DataRow r in dtTTs.Rows)
					{

						//dgvPlantilla.Rows.Add(txtPlantilla.Valor, txtCondicion.Valor, r["CodigoArticulo"].ToString(), r["DES"].ToString(), /*true,*/ /*string.Empty, string.Empty,*/ decimal.Parse(r["Costo Local"].ToString())/*, r["Cod"].ToString(), r["DESCRIPCION"].ToString(), r["DIAS_NETO"].ToString()*/);
						dgvPlantilla.Rows.Add(txtPlantilla.Valor, txtCondicion.Valor, r["CodigoArticulo"].ToString(), r["DesArticulo"].ToString(), decimal.Parse(r["PRECIO"].ToString()));
					}

					txtPlantilla.Valor = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
					txtPlantillaN.Valor = dtTTs.Rows[0]["Plantilla"].ToString();
					//txtFrecu.Valor = dtTTs.Rows[0]["CodigoFrecuencia"].ToString();
					//txtFrecuDescripcion.Valor = dtTTs.Rows[0]["DesFrecuencia"].ToString();
					//txtFrecuDias.Valor = dtTTs.Rows[0]["DIAS_NETO"].ToString();
					//if (dtTTs.Rows[0]["PedidoPorConcepto"].ToString() == "S")
					//    chkPedConcepto.Checked = true;
					//else
					//    chkPedConcepto.Checked = false;

				}
				else
				{
					buscaPlantilla(Plantilla);//Si no tiene articulos la plantilla de la condicion que me cargue el codigo y nombre de la plantilla limpiando el dgv o si no tiene plantilla se limpiarn los campos
					dgvPlantilla.Rows.Clear();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void listaPaises(string identificador)
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "PAIS as Código,NOMBRE as Nombre";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "PAIS";
			listP.ORDERBY = "order by NOMBRE";
			listP.TITULO_LISTADO = "Países";
			frmF1 f1Paises = new frmF1(listP);
			f1Paises.ShowDialog();
			if (f1Paises.item != null)
			{
				if (identificador == "P")
				{
					txtPais.Valor = f1Paises.item.SubItems[0].Text;
					txtDescripcionPais.Valor = f1Paises.item.SubItems[1].Text;
				}
				else
				{
					txtPaisTitulo.Valor = f1Paises.item.SubItems[0].Text;
					txtNombrePaisTitulo.Valor = f1Paises.item.SubItems[1].Text;
				}

			}
		}

		private void listaProvincias()
		{

			Listado listP = new Listado();
			listP.COLUMNAS = "DIVISION_GEOGRAFICA1 as Código,NOMBRE as Provincia";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "DIVISION_GEOGRAFICA1";
			listP.ORDERBY = "order by DIVISION_GEOGRAFICA1";
			listP.TITULO_LISTADO = "Provincias";
			frmF1 f1Provincias = new frmF1(listP);
			f1Provincias.ShowDialog();
			if (f1Provincias.item != null)
			{
				txtProvincia.Valor = f1Provincias.item.SubItems[0].Text;
				this.txtProvinciaNombreF.Valor = f1Provincias.item.SubItems[1].Text;
				txtCanton.Clear();
				txtDistrito.Clear();
				txtCantonNombreF.Clear();
				txtDistritoNombreF.Clear();
			}
		}

		private void listaCantones()
		{
			if (txtProvincia.Valor.Trim() == "")
			{
				MessageBox.Show("Primero debe especificar alguna provincia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtProvincia.Focus();
				return;
			}

			Listado listP = new Listado();
			listP.COLUMNAS = "DIVISION_GEOGRAFICA2 as Código,NOMBRE as Cantón";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "DIVISION_GEOGRAFICA2";
			listP.FILTRO = "WHERE DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "'";
			listP.ORDERBY = "order by DIVISION_GEOGRAFICA2";
			listP.TITULO_LISTADO = "Cantones";
			frmF1 f1Canton = new frmF1(listP);
			f1Canton.ShowDialog();
			if (f1Canton.item != null)
			{
				txtCanton.Valor = f1Canton.item.SubItems[0].Text;
				this.txtCantonNombreF.Valor = f1Canton.item.SubItems[1].Text;
				txtDistrito.Clear();
				txtDistritoNombreF.Clear();
			}
		}

		private void listaDistritos()
		{
			if (txtProvincia.Valor.Trim() == "")
			{
				MessageBox.Show("Primero debe especificar alguna provincia.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtProvincia.Focus();
				return;
			}

			if (txtCanton.Valor.Trim() == "")
			{
				MessageBox.Show("Primero debe especificar algún cantón.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtProvincia.Focus();
				return;
			}

			Listado listP = new Listado();
			listP.COLUMNAS = "DIVISION_GEOGRAFICA3 as Código,NOMBRE as Distrito";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "DIVISION_GEOGRAFICA3";
			listP.FILTRO = "WHERE DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "' AND DIVISION_GEOGRAFICA2='" + txtCanton.Valor + "'";
			listP.ORDERBY = "order by DIVISION_GEOGRAFICA3";
			listP.TITULO_LISTADO = "Distritos";
			frmF1 f1Distrito = new frmF1(listP);
			f1Distrito.ShowDialog();
			if (f1Distrito.item != null)
			{
				txtDistrito.Valor = f1Distrito.item.SubItems[0].Text;
				this.txtDistritoNombreF.Valor = f1Distrito.item.SubItems[1].Text;
			}
		}

		private void buscaPais(string codigo, string identificador)
		{

			if (identificador == "P")
			{
				if (txtPais.Valor.Trim() == "")
				{
					txtDescripcionPais.Clear();
					return;
				}
			}

			if (identificador == "PT")
			{
				if (txtPaisTitulo.Valor.Trim() == "")
				{
					txtNombrePaisTitulo.Clear();
					return;
				}
			}

			DataTable dtPais = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "PAIS,NOMBRE";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "PAIS";
			listP.FILTRO = "where PAIS = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtPais, ref error))
			{
				if (dtPais.Rows.Count > 0)
				{
					if (identificador == "P")
						txtDescripcionPais.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
					else
						txtNombrePaisTitulo.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					if (codigo != "")
						MessageBox.Show("El País digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaPlantilla(string codigo)
		{

			DataTable dtPais = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoPlantilla,NombrePlantilla";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_MACHOTES";
			listP.FILTRO = "where CodigoPlantilla = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtPais, ref error))
			{
				if (dtPais.Rows.Count > 0)
				{
					txtPlantilla.Valor = dtPais.Rows[0]["CodigoPlantilla"].ToString();
					txtPlantillaN.Valor = dtPais.Rows[0]["NombrePlantilla"].ToString();
				}
				else
				{
					txtPlantilla.Clear();
					txtPlantillaN.Clear();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaBeneficiario(string codigo)
		{

			DataTable dt = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "Cedula,Nombre+' '+PrimerApellido+' '+SegundoApellido [NombreBeneficiario]";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_BENEFICIARIOS";
			listP.FILTRO = "where NumeroColegiado = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					txtBeneficiarioCheque.Valor = dt.Rows[0]["Cedula"].ToString();
					txtBeneChequeNombre.Valor = dt.Rows[0]["NombreBeneficiario"].ToString();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaProvincia(string codigo)
		{

			if (txtProvincia.Valor.Trim() == "")
			{
				txtProvinciaNombreF.Clear();
				txtCanton.Clear();
				txtCantonNombreF.Clear();
				txtDistrito.Clear();
				txtDistritoNombreF.Clear();
				return;
			}

			DataTable dtPais = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "DIVISION_GEOGRAFICA1,NOMBRE";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "DIVISION_GEOGRAFICA1";
			listP.FILTRO = "where DIVISION_GEOGRAFICA1 = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtPais, ref error))
			{
				if (dtPais.Rows.Count > 0)
				{
					this.txtProvinciaNombreF.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					if (codigo != "")
						MessageBox.Show("La Provincia digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaCanton(string codigo)
		{

			if (txtCanton.Valor.Trim() == "")
			{
				txtCantonNombreF.Clear();
				txtDistrito.Clear();
				txtDistritoNombreF.Clear();
				return;
			}


			if (txtProvincia.Valor.Trim() == "")
			{
				MessageBox.Show("Primero debe elegir una provincia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DataTable dtPais = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "DIVISION_GEOGRAFICA2,NOMBRE";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "DIVISION_GEOGRAFICA2";
			listP.FILTRO = "where DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "' AND DIVISION_GEOGRAFICA2 = '" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtPais, ref error))
			{
				if (dtPais.Rows.Count > 0)
				{
					this.txtCantonNombreF.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					if (codigo != "")
						MessageBox.Show("El Cantón digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void buscaDistrito(string codigo)
		{

			if (txtDistrito.Valor.Trim() == "")
			{
				txtDistritoNombreF.Clear();
				return;
			}


			if (txtProvincia.Valor.Trim() == "")
			{
				MessageBox.Show("Primero debe elegir una provincia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (txtCanton.Valor.Trim() == "")
			{
				MessageBox.Show("Primero debe elegir un cantón.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DataTable dtPais = new DataTable();
			Listado listP = new Listado();
			listP.COLUMNAS = "DIVISION_GEOGRAFICA3,NOMBRE";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "DIVISION_GEOGRAFICA3";
			listP.FILTRO = "where DIVISION_GEOGRAFICA1='" + txtProvincia.Valor + "' AND DIVISION_GEOGRAFICA2 = '" + txtCanton.Valor + "' AND DIVISION_GEOGRAFICA3='" + codigo + "'";

			if (Consultas.listarDatos(listP, ref dtPais, ref error))
			{
				if (dtPais.Rows.Count > 0)
				{
					txtDistritoNombreF.Valor = dtPais.Rows[0]["NOMBRE"].ToString();
				}
				else
				{
					if (codigo != "")
						MessageBox.Show("El Distrito digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

		private void habilitarPolizaRegente()
		{
			lblNPoliza.Visible = true;
			lblMonto.Visible = true;
			LblFecha.Visible = true;
			lblVencimiento.Visible = true;
			txtNPoliza.Visible = true;
			txtMonto.Visible = true;
			dtpFecha.Visible = true;
			dtpVencimiento.Visible = true;
		}

		private void deshabilitarPolizaRegente()
		{
			lblNPoliza.Visible = false;
			lblMonto.Visible = false;
			LblFecha.Visible = false;
			lblVencimiento.Visible = false;
			txtNPoliza.Visible = false;
			txtMonto.Visible = false;
			dtpFecha.Visible = false;
			dtpVencimiento.Visible = false;
		}

		private void OnTipoRegenteChanged(object sender, EventArgs e)
		{
			verificarSiRequierePoliza();
		}

		private void verificarSiRequierePoliza()
		{
			DataTable dtTpos = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "RequierePoliza,RequiereVidaSilvestre";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_TIPOS";
			listA.FILTRO = "where Diferenciador = 'R' and CodigoTipo = '" + cmbTipoRegente.Valor + "'";
			//listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dtTpos, ref error))
			{
				if (dtTpos.Rows.Count > 0)
				{
					if (dtTpos.Rows[0][0].ToString() == "S")
					{
						habilitarPolizaRegente();
					}
					else
					{
						deshabilitarPolizaRegente();
						txtNPoliza.Clear();
						txtMonto.Clear();
						dtpFecha.Value = DateTime.Now;
						dtpVencimiento.Value = DateTime.Now;
					}
					if (dtTpos.Rows[0]["RequiereVidaSilvestre"].ToString() == "S")
					{
						habilitarSilvestre();
					}
					else
					{
						deshabilitarSilvestre();
						limpiarSilvestre();
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		}


		private void verificarConfigurablesCondicion()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "RequiereRegresoCondicion,CondicionFallecido,PermitePedConcepto,CondicionIncorporacion";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_CONDICIONES";
			listA.FILTRO = "where CodigoCondicion = '" + txtCondicion.Valor + "'";
			//listA.ORDERBY = "order by CodigoTipo";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					if (dt.Rows[0]["RequiereRegresoCondicion"].ToString() == "S")
					{
						dtpRegresoCondicion.Visible = true;
						lblRegresoCondi.Visible = true;
						requiereRevisionCondicion = true;
						//revisarRegresoCondicion();
					}
					else
					{
						dtpRegresoCondicion.Visible = false;
						lblRegresoCondi.Visible = false;
					}

					if (dt.Rows[0]["CondicionFallecido"].ToString() == "S")
					{
						dtpFallecimiento.Visible = true;
						lblDtpFallec.Visible = true;
						txtCheque.Visible = true;
						lblCheque.Visible = true;
						lblBenef.Visible = true;
						txtBeneficiarioCheque.Visible = true;
						txtBeneChequeNombre.Visible = true;
						requiereDatosFallecidos = true;
					}
					else
					{
						dtpFallecimiento.Visible = false;
						lblDtpFallec.Visible = false;
						txtCheque.Visible = false;
						lblCheque.Visible = false;
						lblBenef.Visible = false;
						txtBeneficiarioCheque.Visible = false;
						txtBeneChequeNombre.Visible = false;
					}

					if (dt.Rows[0]["PermitePedConcepto"].ToString() == "S")
					{
						chkPedConcepto.Visible = true;
					}
					else
					{
						chkPedConcepto.Visible = false;
					}

					if (dt.Rows[0]["CondicionIncorporacion"].ToString() == "S")
					{
						esIncorporacion = true;
					}
					else
					{
						esIncorporacion = false;
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void revisarRegresoCondicion()
		{
			bool OK = true;
			string condicion = "";
			string pedidoConcepto = "";
			//string mesUltimoCobro = "";
			string plantillaC = "";

			int result = DateTime.Compare(dtpRegresoCondicion.Value.Date, DateTime.Today);
			if (result <= 0)
			{
				Consultas.sqlCon.iniciaTransaccion();
				DataTable dt = new DataTable();
				DataTable dtSelect = new DataTable();
				DataTable dtPlantilla = new DataTable();

				#region OBTENER_CONDICION_REGRESO
				string sQuery = "select CondicionRegreso from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES WHERE CodigoCondicion = '" + txtCondicion.Valor + "'";

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

				//Obtenemos estos datos porque son genericos y se necesitan para los procesos //No se utiliza porque se paso MesUltimoCobro para historialCoelgiaturas
				//#region OBTENER_PEDIDOCONCEPTO_ULTIMOCOBRO
				//if (OK)
				//{

				//    string sSelect = "select PedidoPorConcepto, MesUltimoCobro from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO" +
				//        " where NumeroColegiado = '" + txtIdColegiado.Valor + "' and CodigoCondicion = '" + txtCondicion.Valor + "'";

				//    if (Consultas.fillDataTable(sSelect, ref dtSelect, ref error))
				//    {
				//        if (dtSelect.Rows.Count > 0)
				//        {
				//            pedidoConcepto = dtSelect.Rows[0]["PedidoPorConcepto"].ToString();
				//            mesUltimoCobro = dtSelect.Rows[0]["MesUltimoCobro"].ToString();
				//        }
				//        OK = true;
				//    }
				//    else
				//    {
				//        OK = false;
				//        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//    }
				//}
				//#endregion

				//Se actualizan los datos en la tabla colegiados

				#region INSERTAR_HISTORIAL

				//string sQueryhist = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CONDICION (IdColegiado,CondicionPrevia,CondicionActual,SesionAprobacion,FechaAprobacion) " +
				//            "VALUES ('" + txtIdColegiado.Valor + "','" + txtCondicion.Valor + "','" + condicion + "','AUTO','" + DateTime.Now.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "')";

				//if (OK)
				//    OK = Consultas.ejecutarSentencia(sQueryhist, ref error);
				if (OK)
					OK = insertarEnHistorialCondicion(txtIdColegiado.Valor, condicion, ref error);
				#endregion

				#region ACTUALIZAR_CONDICION_FECHA_COLEGIADO
				if (OK)
				{
					List<string> parametros = new List<string>();
					string sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Condicion = @Condicion, FechaRegresoCondicion = @FechaRegresoCondicion" +
									 " WHERE IdColegiado = @IdColegiado";
					parametros.Add("@Condicion," + condicion);
					parametros.Add("@FechaRegresoCondicion," + "null");
					parametros.Add("@IdColegiado," + txtIdColegiado.Valor);


					OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

				}
				#endregion

				//Eliminamos los registros de la condicion anterior en machotes colegiados
				//#region ELIMINAR_MACHOTESCOLEGIADOS
				//if (OK)
				//{
				//    List<string> parametros = new List<string>();
				//    string sDelete = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_COLEGIADO WHERE NumeroColegiado = @NumeroColegiado and CodigoCondicion = @CodigoCondicion";
				//    parametros.Add("@CodigoCondicion," + txtCondicion.Valor);
				//    parametros.Add("@NumeroColegiado," + txtIdColegiado.Valor);

				//    OK = Consultas.ejecutarSentenciaParametros(sDelete, parametros, ref error);
				//}
				//#endregion

				//Obtenemos la plantilla y actualizamos f1 de condicion y obtenemos la plantilla
				if (OK)
				{
					buscaCondicion(condicion, ref plantillaC);
				}

				//Insertamos los nuevos registros de machotes colegiados con su nueva plantilla
				#region INSERTAR_NUEVA_PLANTILLAS_MACHOTESCOLEGIADOS
				//if (OK)
				//{
				//    List<string> parametros = new List<string>();
				//    string sInsert = "insert into "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES_COLEGIADO(NumeroColegiado,CodigoCondicion,CodigoArticulo,CodigoPlantilla,PedidoPorConcepto)"+
				//                     " values(@NumeroColegiado, @CodigoCondicion, @CodigoArticulo, @CodigoPlantilla, @PedidoPorConcepto)";

				//    string sQueryPlantilla = "select art.CodigoPlantilla,art.CodigoArticulo,"+
				//    " (SELECT PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO where ARTICULO = art.CodigoArticulo) as 'PRECIO'" +
				//    " from "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES_ART art"+
				//    " where art.CodigoPlantilla = '" + plantillaC + "'";

				//    if (Consultas.fillDataTable(sQueryPlantilla, ref dtPlantilla, ref error))
				//    {
				//        if (dtPlantilla.Rows.Count > 0)
				//        {
				//            foreach (DataRow row in dtPlantilla.Rows)
				//            {
				//                parametros.Clear();

				//                parametros.Add("@NumeroColegiado," + txtIdColegiado.Valor);
				//                parametros.Add("@CodigoCondicion," + condicion);
				//                parametros.Add("@CodigoArticulo," + row["CodigoArticulo"].ToString());
				//                parametros.Add("@CodigoPlantilla," + row["CodigoPlantilla"].ToString());
				//                parametros.Add("@PedidoPorConcepto," + pedidoConcepto);

				//                OK = Consultas.ejecutarSentenciaParametros(sInsert, parametros, ref error);

				//                if (!OK)
				//                    break;

				//            }
				//            OK = true;
				//        }
				//    }
				//    else
				//    {
				//        OK = false;
				//        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//    }

				//}
				#endregion

				//Cargamos la plantilla nueva en la vista y desactivamos los campos de fecha regreso 
				if (OK)
				{
					cargarPlantilla();
					dtpRegresoCondicion.Value = DateTime.Now;
					dtpRegresoCondicion.Visible = false;
					lblRegresoCondi.Visible = false;
				}


				if (OK)
				{
					Consultas.sqlCon.Commit();
					MessageBox.Show("Se realizó el cambio de condición del colegiado", "Nota Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
					Consultas.sqlCon.Rollback();

			}
		}

		//private void buscaFrecuencia(string codigo)
		//{

		//    if (txtFrecuencia.Valor.Trim() == "")
		//    {
		//        txtFrecDescripcion.Clear();
		//        txtFrecDias.Clear();
		//        return;
		//    }

		//    DataTable dtFrec = new DataTable();
		//    Listado listP = new Listado();
		//    listP.COLUMNAS = "CONDICION_PAGO , DESCRIPCION ,DIAS_NETO ";
		//    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
		//    listP.TABLA = "CONDICION_PAGO";
		//    listP.COLUMNAS_NUMERICAS_INT.Add("Días");
		//    listP.FILTRO = "where CONDICION_PAGO='" + txtFrecuencia.Valor + "'";

		//    if (Consultas.listarDatos(listP, ref dtFrec, ref error))
		//    {
		//        if (dtFrec.Rows.Count > 0)
		//        {
		//            txtFrecDescripcion.Valor = dtFrec.Rows[0]["DESCRIPCION"].ToString();
		//            txtFrecDias.Valor = dtFrec.Rows[0]["DIAS_NETO"].ToString();
		//        }
		//        else
		//        {
		//            if (codigo != "")
		//                MessageBox.Show("La frecuencia digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//        }
		//    }
		//    else
		//        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		//}

		private bool insertarEnHistorialCondicion(string colegiado, string condicionNueva, ref string error)
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
				list.COLUMNAS_PK.Clear();
				//list.COLUMNAS_PK.Add("Id");
				list.COLUMNAS_PK.Add("IdColegiado");
				//parametros.Add(row.Cells["colId"].Value.ToString());
				parametros.Add(colegiado);
				parametros.Add(txtCondicion.Valor);
				parametros.Add(condicionNueva);
				parametros.Add("AUTO");
				parametros.Add(DateTime.Now.Date.ToString("yyyy-MM-ddTHH:mm:ss"));


				lbOk = Consultas.insertar(parametros, list, Constantes.ID_BIT_REGRESO_CONDICION, ref error);

			}
			catch (Exception ex)
			{
				error = ex.Message;
				return false;
			}
			return lbOk;
		}


		private void txtPais_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaPaises("P");
		}

		private void txtPais_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
				listaPaises("P");
		}

		private void txtProvincia_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaProvincias();
		}

		private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
				listaProvincias();
		}

		private void txtCanton_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaCantones();
		}

		private void txtCanton_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
				listaCantones();
		}

		private void txtDistrito_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaDistritos();
		}

		private void txtDistrito_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
				listaDistritos();
		}

		//private void txtFrecuencia_MouseDoubleClick(object sender, MouseEventArgs e)
		//{
		//    listaFrecuencias();
		//}

		//private void txtFrecuencia_KeyDown(object sender, KeyEventArgs e)
		//{
		//    if (e.KeyValue == (char)Keys.F1)
		//        listaFrecuencias();
		//}

		private void txtPais_Leave(object sender, EventArgs e)
		{
			buscaPais(txtPais.Valor, "P");
		}

		private void txtProvincia_Leave(object sender, EventArgs e)
		{
			buscaProvincia(txtProvincia.Valor);
		}

		private void txtCanton_Leave(object sender, EventArgs e)
		{
			buscaCanton(txtCanton.Valor);
		}

		private void txtDistrito_Leave(object sender, EventArgs e)
		{
			buscaDistrito(txtDistrito.Valor);
		}

		//private void txtFrecuencia_Leave(object sender, EventArgs e)
		//{
		//    buscaFrecuencia(txtFrecuencia.Valor);
		//}

		private void btnNuevaEspecialidad_Click(object sender, EventArgs e)
		{
			frmEspecialidadesEdicion frm = new frmEspecialidadesEdicion(new List<string>());
			frm.ShowDialog();
		}

		private void btnEditarEspecialidad_Click(object sender, EventArgs e)
		{
			//List<string> pk = new List<string>();
			//pk.Add(dgvEspecialidades.CurrentCell.OwningRow.Cells["colCodigoEspecialidad"].Value.ToString());
			//frmEspecialidadesEdicion frm = new frmEspecialidadesEdicion(pk);
			//frm.ShowDialog();
		}

		private void cargarEspecialidades()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "t1.CodigoEspecialidad,t1.SesionAprob,t1.Fecha,(select NombreEspecialidad from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESPECIALIDADES where CodigoEspecialidad = t1.CodigoEspecialidad) as NomEspecialidad";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_HISTORIAL_ESPECIALIDAD t1";
			listA.FILTRO = "where NumeroColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvEspecialidades.Rows.Clear();
					foreach (DataRow r in dt.Rows)
					{
						dgvEspecialidades.Rows.Add(r["CodigoEspecialidad"].ToString(), r["NomEspecialidad"].ToString(), r["SesionAprob"].ToString(), DateTime.Parse(r["Fecha"].ToString()).ToString("dd/MM/yyyy"));
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void cargarCamposEspecialidad()
		{
			DataTable dt = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "t1.CodigoCampo,(select NombreCampo from " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMPOS_ESPECIALIDAD where CodigoCampo = t1.CodigoCampo) as NomCampo";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_HISTORIAL_CAMPO_ESPECIALIDAD t1";
			listA.FILTRO = "where NumeroColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.listarDatos(listA, ref dt, ref error))
			{
				if (dt.Rows.Count > 0)
				{
					dgvCamposEspecialidad.Rows.Clear();
					foreach (DataRow r in dt.Rows)
					{
						dgvCamposEspecialidad.Rows.Add(r["CodigoCampo"].ToString(), r["NomCampo"].ToString());
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnRefrescarEspecialidad_Click(object sender, EventArgs e)
		{
			cargarEspecialidades();
		}

		private void frmColegiadosEdicion_Load(object sender, EventArgs e)
		{
			cmbFormaPago.Visible = false;
			lblFormaPago.Visible = false;
			chkPedConcepto.Visible = false;
			btnProcesar.Enabled = false;
			txtCedula.Longitud = 20;
			txtHistPuesto.Longitud = 200;
			rtbDireccion.Mayuscula = true;
			txtCondicion.Mayusculas();
			txtCategoria.Mayusculas();
			txtPais.Mayusculas();
			txtProvincia.Mayusculas();
			txtCanton.Mayusculas();
			txtDistrito.Mayusculas();
			txtCobrador.Mayusculas();
			txtSesionAprob.Mayusculas();
			txtSesionCond.Mayusculas();
			txtCentroAcademico.Mayusculas();
			txtTituloAcademico.Mayusculas();
			txtEmpresa.Mayusculas();
			txtHistEmpresa.Longitud = 200;
			txtEspecialidad.Mayusculas();
			txtCampoEspecialidad.Mayusculas();
			//txtOrientacion.Mayusculas();
			txtPlantilla.Mayusculas();
			//dgvEspecialidades.Size = new Size(924, 456);
			//dgvEspecialidades.Size = new Size(925, 232);
			//dgvPlaguicidas.Size = new Size(921, 455);
			lblTotalPlantillaCobro.Location = new Point(827, 540);
			lblCantTotalPlantillaCobro.Location = new Point(861, 540);
			dlvBeneficiarios.Size = new Size(991, 478);
			panel11.Size = new Size(567, 25);
			//panel12.Size = new Size(494, 21);
			panel3.Size = new Size(991, 21);
			panel5.Size = new Size(991, 21);
			panel9.Size = new Size(991, 21);
			panel15.Size = new Size(991, 21);
			panel16.Size = new Size(991, 21);
			panel2.Size = new Size(991, 21);
			panel10.Size = new Size(991, 21);
			panel18.Size = new Size(991, 21);
			panel8.Size = new Size(991, 21);
			panel7.Size = new Size(991, 21);
			panel6.Size = new Size(991, 21);

			groupBox8.Size = new Size(992, 503);

			grbPlantilla.Size = new Size(981, 481);
			grbPlantilla.Location = new Point(8, 52);
			dgvPlantilla.Location = new Point(82, 93);
			dgvPlantilla.Size = new Size(824, 364);
			dgvPlantilla.Columns["colMontoArticulo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			txtPlantillaN.Size = new Size(368, 21);
			txtFrecuDescripcion.Size = new Size(350, 21);
			txtFrecuDias.Size = new Size(87, 21);
			grbHistorialSesiones.Size = new Size(983, 497);

			grbSesionEspecialidad.Size = new Size(436, 52);
			grbSesionEspecialidad.Location = new Point(507, 30);

			dgvHistorialAcademico.Size = new Size(891, 328);
			gbGradoAcade.Location = new Point(644, 79);
			dtpFechaGradu.Location = new Point(839, 50);
			lblFechaGradu.Location = new Point(725, 54);

			dgvHistorialLaboral.Size = new Size(896, 267);
			grbRangoLaboral.Location = new Point(687, 57);
			grbRangoLaboral.Size = new Size(272, 79);
			txtHistTelEmpresa.Location = new Point(786, 142);
			label60.Location = new Point(684, 146);

			grbPagoMut.Size = new Size(892, 132);
			grbPagoMut.Location = new Point(51, 92);
			grbMutualidad.Location = new Point(153, 292); //153; 292
			grbMutualidad.Size = new Size(676, 216); //676; 216
													 //grbSesionCond.Location = new Point(542, 288);
													 //grbSesionCond.Size = new Size(401, 66);
													 //grbTituloObligatorio.Location = new Point(551, 411);
			grbTituloObligatorio.Location = new Point(542, 288);
			grbTituloObligatorio.Size = new Size(392, 95);

			dgvEspecialidades.Size = new Size(869, 339);
			dgvCamposEspecialidad.Location = new Point(263, 387);
			dgvCamposEspecialidad.Size = new Size(567, 140);
			txtCampoEspecialidad.Size = new Size(62, 25);
			txtCampoEspecialidadN.Size = new Size(248, 25);
			//dgvOrientaciones.Size = new Size(416, 128);

			//txtOrientacionN.Size = new Size(285, 21);
			panel4.Size = new Size(782, 434);

			grbPagaCanonPlagui.Location = new Point(14, 15);
			grbEstadoCanonPlagui.Location = new Point(701, 7);
			panelPlagui.Size = new Size(979, 458);
			panelPlagui.Location = new Point(12, 68);
			dgvInvestigacionPlaguicidas.Size = new Size(971, 458);
			grbPagaCanonAerea.Location = new Point(14, 15);
			grbEstadoCanonAerea.Location = new Point(701, 7);
			panelAerea.Size = new Size(979, 458);
			panelAerea.Location = new Point(12, 68);
			dgvViaAerea.Size = new Size(971, 458);
			grbPagaCanonSilve.Location = new Point(14, 15);
			grbEstadoCanonSilve.Location = new Point(701, 7);
			panelSilve.Size = new Size(979, 458);
			panelSilve.Location = new Point(12, 68);
			dgvVidaSilvestre.Size = new Size(971, 458);

			grbEstableRegencias.Size = new Size(977, 258);
			grbEstableRegencias.Location = new Point(12, 269);

			panelGestionCobro.Location = new Point(12, 30);
			panelGestionCobro.Size = new Size(977, 185);
			grbAdelantos.Location = new Point(12, 221);
			grbAdelantos.Size = new Size(974, 155);
			grbPendientes.Location = new Point(12, 382);
			grbPendientes.Size = new Size(974, 178);

			gbVidaSilvestreR.Location = new Point(573, 46);
			gbVidaSilvestreR.Size = new Size(386, 200);
			dgvVidaSilvestreR.Size = new Size(380, 151);


			txtCalculoMutualidad.Right();
			txtCalculoMutualidadMeses.Right();
			txtCalculoMutualidadMontoRenunciar.Right();
			txtCalculoTitulo.Right();
			txtEdad.Right();

			if (Globales.FONDO_MUTUALIDAD == "N")
				grbMutualidad.Visible = false;
			if (Globales.TITULO_OBLIGATORIO == "N")
				grbTituloObligatorio.Visible = false;
			if (Globales.MANEJO_BENEFICIARIOS == "N")
				tabControl.TabPages.Remove(tpBeneficiarios);
			if (Globales.MANEJO_ESPECIALIDADES == "N")
				tabControl.TabPages.Remove(tpEspecialidades);
			if (Globales.MANEJO_PLAGUICIDAS == "N")
				tabControl.TabPages.Remove(tpPlaguicidas);
			if (Globales.MANEJO_VIA_AEREA == "N")
				tabControl.TabPages.Remove(tpViaAerea);
			if (Globales.MANEJO_VIDA_SILVESTRE == "N")
				tabControl.TabPages.Remove(tpSilvestre);
			if (Globales.MANEJO_REGENCIAS == "N")
				tabControl.TabPages.Remove(tpRegencias);
			if (Globales.PERMITIR_PERITO == "N")
				tabControl.TabPages.Remove(tpPeritajes);

			if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_HISTORIAL_CAMBIO_CONDICION))
				tabControl.TabPages.Remove(tpHistorial);

			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PROCESO_CAMBIO_CONDICION))
				btnCambioCondicion.Visible = true;
			//btnCambioCondicion.Enabled = true;

			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PROCESO_CAMBIO_CATEGORIA))
				btnCambioCategoria.Visible = true;
			//btnCambioCategoria.Enabled = true;

			if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ELIMINAR_REG_COLEGIADOS))
			{
				btnEliminarAerea.Visible = false;
				btnEliminaPlagui.Visible = false;
				btnEliminarSilvestre.Visible = false;
			}

			//dtpTarjetaVencimiento.Format("MM/yyyy");
			//dtpTarjetaVencimiento.Value = DateTime.Now;

		}

		private void txtCobrador_Enter(object sender, EventArgs e)
		{
			oldValue = txtCobrador.Valor;
		}

		private void txtCobrador_Leave(object sender, EventArgs e)
		{
			buscaCobrador(txtCobrador.Valor, "C");
		}

		private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCobrador.ReadOnly)
			{
				listaCobradores("C");
			}
		}

		private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCobrador.ReadOnly)
			{
				listaCobradores("C");
			}
		}

		private void txtCobradorPeritaje_Enter(object sender, EventArgs e)
		{
			oldValue = txtCobradorPeritaje.Valor;
		}

		private void txtCobradorPeritaje_Leave(object sender, EventArgs e)
		{
			buscaCobrador(txtCobradorPeritaje.Valor, "P");
		}

		private void txtCobradorPeritaje_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCobradorPeritaje.ReadOnly)
			{
				listaCobradores("P");
			}
		}

		private void txtCobradorPeritaje_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCobradorPeritaje.ReadOnly)
			{
				listaCobradores("P");
			}
		}

		private void txtCobradorRegente_Enter(object sender, EventArgs e)
		{
			oldValue = txtCobradorRegente.Valor;
		}

		private void txtCobradorRegente_Leave(object sender, EventArgs e)
		{
			buscaCobrador(txtCobradorRegente.Valor, "R");
		}

		private void txtCobradorRegente_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCobradorRegente.ReadOnly)
			{
				listaCobradores("R");
			}
		}

		private void txtCobradorRegente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCobradorRegente.ReadOnly)
			{
				listaCobradores("R");
			}
		}

		private void txtCondicion_Enter(object sender, EventArgs e)
		{
			//oldValue = txtCondicion.Valor;
		}

		private void txtCondicion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCondicion.ReadOnly)
			{
				listaCondiciones();
				verificarConfigurablesCondicion();
			}
		}

		private void txtCondicion_Leave(object sender, EventArgs e)
		{
			if (txtCondicion.Valor.Trim().Equals(""))
			{
				txtDescCondicion.Clear();
			}
			else
			{
				if (oldValue != txtCondicion.Valor)
				{
					cargarCondicion(txtCondicion.Valor);
					if (txtCondicion.Valor.Trim() == "")
					{
						MessageBox.Show("La Condición digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						verificarConfigurablesCondicion();
					}
				}
			}
		}

		private void txtCondicion_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCondicion.ReadOnly)
			{
				listaCondiciones();
				verificarConfigurablesCondicion();
			}
		}

		private void txtCategoria_Enter(object sender, EventArgs e)
		{
			oldValue = txtCategoria.Valor;
		}

		private void txtCategoria_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCategoria.ReadOnly)
			{
				listaCategorias();
			}
		}

		private void txtCategoria_Leave(object sender, EventArgs e)
		{
			if (txtCategoria.Valor.Trim().Equals(""))
			{
				txtDescCategoria.Clear();
			}
			else
			{
				if (oldValue != txtCategoria.Valor)
				{
					cargarCategoria(txtCategoria.Valor);
					if (txtCategoria.Valor.Trim() == "")
						MessageBox.Show("La Categoría digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtCategoria_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCategoria.ReadOnly)
			{
				listaCategorias();
			}
		}

		private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = (e.KeyChar == (char)Keys.Space);
		}

		private void txtCedula_Leave(object sender, EventArgs e)
		{
			txtCedula.WhiteSpaces();
			string nombre = "";
			//int sexo = 0;
			if (!txtCedula.ReadOnly && !txtCedula.Valor.Equals(""))
			{
				Cursor.Current = Cursors.WaitCursor;
				//this.fInternas.infoPadronNacional(txtCedula.Valor, false, ref nombre, ref sexo, ref error);
				this.fInternas.ConsultaNombreHacienda(txtCedula.Valor, ref nombre, ref error);
				Cursor.Current = Cursors.Default;
				if (error != "")
				{
					MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtNombre.Focus();
				}
				else
				{
					txtNombre.Valor = nombre;
					//cmbSexo.Index = sexo;
				}
			}
		}

		private void txtCentroAcademico_Enter(object sender, EventArgs e)
		{
			oldValue = txtCentroAcademico.Valor;
		}

		private void txtCentroAcademico_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCentroAcademico.ReadOnly)
			{
				listaCentros();
			}
		}

		private void txtCentroAcademico_Leave(object sender, EventArgs e)
		{
			if (txtCentroAcademico.Valor.Trim().Equals(""))
			{
				txtCentroAcademicoN.Clear();
			}
			else
			{
				if (oldValue != txtCentroAcademico.Valor)
				{
					cargarCentro(txtCentroAcademico.Valor);
					if (txtCentroAcademico.Valor.Trim() == "")
						MessageBox.Show("El Centro Académico digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtCentroAcademico_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCentroAcademico.ReadOnly)
			{
				listaCentros();
			}
		}

		private void txtTituloAcademico_Enter(object sender, EventArgs e)
		{
			oldValue = txtTituloAcademico.Valor;
		}

		private void txtTituloAcademico_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtTituloAcademico.ReadOnly)
			{
				listaTitulos();
			}
		}

		private void txtTituloAcademico_Leave(object sender, EventArgs e)
		{
			if (txtTituloAcademico.Valor.Trim().Equals(""))
			{
				txtTituloAcademicoN.Clear();
			}
			else
			{
				if (oldValue != txtTituloAcademico.Valor)
				{
					cargarTitulo(txtTituloAcademico.Valor);
					if (txtTituloAcademico.Valor.Trim() == "")
						MessageBox.Show("El Título Académico digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtTituloAcademico_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtTituloAcademico.ReadOnly)
			{
				listaTitulos();
			}
		}

		private void btnNuevaFormacion_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (txtCentroAcademico.Valor.Trim() == "")
				{
					MessageBox.Show("Para agregar la formación debe especificar el centro académico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCentroAcademico.Focus();
					return;
				}
				if (txtTituloAcademico.Valor.Trim() == "")
				{
					MessageBox.Show("Para agregar la formación debe especificar el título académico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCentroAcademico.Focus();
					return;
				}
				if (txtPaisTitulo.Valor.Trim() == "")
				{
					MessageBox.Show("Para agregar la formación debe especificar el País del título académico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCentroAcademico.Focus();
					return;
				}
				if (clbGrados.Index == -1)
				{
					MessageBox.Show("Para agregar la formación debe selecionar el grado académico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					clbGrados.Focus();
					return;
				}
				DataRow r = ((DataRowView)clbGrados.CheckedItems[0]).Row;
				if (!validarHistorialAcademico(txtCentroAcademico.Valor, txtTituloAcademico.Valor, clbGrados.ValueMember(r)))
				{
					MessageBox.Show("Ya existe una formación académica con la misma información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCentroAcademico.Focus();
					return;
				}
				dgvHistorialAcademico.Rows.Add(txtCentroAcademico.Valor, txtCentroAcademicoN.Valor, txtTituloAcademico.Valor, txtTituloAcademicoN.Valor, clbGrados.ValueMember(r), clbGrados.DisplayMember(r), txtPaisTitulo.Valor, txtNombrePaisTitulo.Valor, txtEnfasis.Valor, txtEnfasisN.Valor, dtpFechaGradu.Value.ToString("dd/MM/yyyy"));

			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnEliminarFormacion_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvHistorialAcademico.Rows.Count > 0)
				{
					dgvHistorialAcademico.Rows.RemoveAt(dgvHistorialAcademico.SelectedRows[0].Index);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private bool validarHistorialAcademico(string centro, string titulo, string grado)
		{
			foreach (DataGridViewRow r in dgvHistorialAcademico.Rows)
			{
				if (r.Cells["colCodigoCentro"].Value.ToString().Equals(centro) && r.Cells["colCodigoTitulo"].Value.ToString().Equals(titulo) && r.Cells["colCodigoGrado"].Value.ToString().Equals(grado))
				{
					return false;
				}
			}
			return true;
		}

		//private static int GetMonthDifference(DateTime startDate, DateTime endDate)
		//{
		//    int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
		//    return Math.Abs(monthsApart);
		//}


		private void quitarArticuloFmsPlantilla()
		{
			DataTable dtTTs = new DataTable();
			string sQuery = "";
			sQuery = "select art.CodigoPlantilla,art.CodigoArticulo,(SELECT NombrePlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where art.CodigoPlantilla = CodigoPlantilla) as Plantilla," +
					" (SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = art.CodigoArticulo) as DesArticulo," +
					" (SELECT PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t1.NIVEL_PRECIO AND t6.VERSION = t1.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' where ARTICULO = art.CodigoArticulo) as 'PRECIO'" +
					" from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART art" +
					" where art.CodigoPlantilla = '" + Plantilla + "' and art.ArticuloFms = 'N'";


			if (Consultas.fillDataTable(sQuery, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					dgvPlantilla.Rows.Clear();
					foreach (DataRow r in dtTTs.Rows)
					{
						dgvPlantilla.Rows.Add(txtPlantilla.Valor, txtCondicion.Valor, r["CodigoArticulo"].ToString(), r["DesArticulo"].ToString(), decimal.Parse(r["PRECIO"].ToString()));
					}

					txtPlantilla.Valor = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
					txtPlantillaN.Valor = dtTTs.Rows[0]["Plantilla"].ToString();

				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void chkRenuncia_MouseClick(object sender, MouseEventArgs e)
		{
			if (valoresPk.Count > 0)
			{
				if (chkRenuncia.Checked)
				{
					rtbRazon.ReadOnly = false;
					rtbRazon.BackColor = Color.Transparent;
					//rtbRazon.Text = "Debe digitar la razón de la renuncia...";
					txtCalculoMutualidad.Valor = "0.00";
					txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
					if (validarFechaIngreso_Nacimiento(ref error))
						txtCalculoMutualidadMontoRenunciar.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error);
					rtbRazon.Focus();
					rtbRazon.SelectText();
					if (esIncorporacion)
						quitarArticuloFmsPlantilla();

					totalPlantillaCobro = 0;
					foreach (DataGridViewRow row in dgvPlantilla.Rows)
					{
						totalPlantillaCobro += decimal.Parse(row.Cells["colMontoArticulo"].Value.ToString());
					}
					lblCantTotalPlantillaCobro.Text = totalPlantillaCobro.ToString("N2");

				}
				else
				{
					rtbRazon.ReadOnly = true;
					rtbRazon.BackColor = Color.Gainsboro;
					//rtbRazon.Clear();
					cargarPlantilla();
					if (validarFechaIngreso_Nacimiento(ref error))
					{
						if (int.Parse(txtEdad.Valor) >= 25)
						{
							//int meses = GetMonthDifference(DateTime.Now, dtpFechaNac.Value.AddYears(25));
							//txtCalculoMutualidad.Valor = (1900 * meses).ToString("N2");
							txtCalculoMutualidad.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error);
							txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
							txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
						}
						else
						{
							txtCalculoMutualidad.Valor = "0.00";
							txtCalculoMutualidadMeses.Valor = "0";
							txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
						}
					}
					else
					{
						MessageBox.Show(error, "Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

				}
			}
			else
			{
				chkRenuncia.Checked = false;
				MessageBox.Show("Debe guardar previamente el registro para realizar el calculo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void txtPuesto_Enter(object sender, EventArgs e)
		{
			oldValue = txtPuesto.Valor;
		}

		private void txtPuesto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtPuesto.ReadOnly)
			{
				listaPuestos();
			}
		}

		private void txtPuesto_Leave(object sender, EventArgs e)
		{
			if (txtPuesto.Valor.Trim().Equals(""))
			{
				txtDescPuesto.Clear();
			}
			else
			{
				if (oldValue != txtPuesto.Valor)
				{
					cargarPuesto(txtPuesto.Valor);
					if (txtPuesto.Valor.Trim() == "")
						MessageBox.Show("La Empresa digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtPuesto_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtPuesto.ReadOnly)
			{
				listaPuestos();
			}
		}

		private void txtEmpresa_Enter(object sender, EventArgs e)
		{
			oldValue = txtPuesto.Valor;
		}

		private void txtEmpresa_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtEmpresa.ReadOnly)
			{
				listaEmpresas();
			}
		}

		private void txtEmpresa_Leave(object sender, EventArgs e)
		{
			if (txtEmpresa.Valor.Trim().Equals(""))
			{
				txtEmpresaN.Clear();
			}
			else
			{
				if (oldValue != txtEmpresa.Valor)
				{
					cargarEmpresa(txtEmpresa.Valor);
					if (txtEmpresa.Valor.Trim() == "")
						MessageBox.Show("La Empresa digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtEmpresa_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtEmpresa.ReadOnly)
			{
				listaEmpresas();
			}
		}

		private void btnNuevaEmpresa_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				bool existeEnRango = false;
				if (txtHistEmpresa.Valor.Trim() == "")
				{
					MessageBox.Show("Para agregar el historial laboral debe especificar la empresa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtEmpresa.Focus();
					return;
				}
				if (dtpEmpresaHasta.Checked)
				{
					if (dtpEmpresaDesde.Value.Date > dtpEmpresaHasta.Value.Date || dtpEmpresaDesde.Value.Date == dtpEmpresaHasta.Value.Date)
					{
						MessageBox.Show("El rango laboral debe tener un formato ascendente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					//fInternas.validarFechasLaboral(dtpEmpresaDesde.Value, dtpEmpresaHasta.Value, txtIdColegiado.Valor,ref existeEnRango, ref error);
					//if (existeEnRango)
					//{
					//    MessageBox.Show("Rango de fechas invalido, ya existe un registro en ese rango.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//    return;
					//}
					if (!ValidarFechaslaborales(dtpEmpresaDesde.Value, dtpEmpresaHasta.Value, ref error))
					{
						MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				if (dtpEmpresaHasta.Checked)
					dgvHistorialLaboral.Rows.Add(txtHistEmpresa.Valor, "", txtHistPuesto.Valor, txtHistTelEmpresa.Valor, txtCorreoLaboral.Valor, dtpEmpresaDesde.Value.ToString("dd/MM/yyyy"), dtpEmpresaHasta.Value.ToString("dd/MM/yyyy"), rtbDireccionLaboral.Text);
				else
					dgvHistorialLaboral.Rows.Add(txtHistEmpresa.Valor, "", txtHistPuesto.Valor, txtHistTelEmpresa.Valor, txtCorreoLaboral.Valor, dtpEmpresaDesde.Value.ToString("dd/MM/yyyy"), "", rtbDireccionLaboral.Text);
				//if(dtpEmpresaHasta.Checked)
				//    dgvHistorialLaboral.Rows.Add(txtHistEmpresa.Valor,txtPuesto.Valor,txtDescPuesto.Valor, txtHistTelEmpresa.Valor,txtCorreoLaboral.Valor, dtpEmpresaDesde.Value.ToString("dd/MM/yyyy"), dtpEmpresaHasta.Value.ToString("dd/MM/yyyy"),rtbDireccionLaboral.Text);
				//else
				//    dgvHistorialLaboral.Rows.Add(txtHistEmpresa.Valor, txtPuesto.Valor, txtDescPuesto.Valor, txtHistTelEmpresa.Valor, txtCorreoLaboral.Valor, dtpEmpresaDesde.Value.ToString("dd/MM/yyyy"), "", rtbDireccionLaboral.Text);

			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnEliminarEmpresa_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvHistorialLaboral.Rows.Count > 0)
				{
					dgvHistorialLaboral.Rows.RemoveAt(dgvHistorialLaboral.SelectedRows[0].Index);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void txtEspecialidad_Enter(object sender, EventArgs e)
		{
			oldValue = txtEspecialidad.Valor;
		}

		private void txtEspecialidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCampoEspecialidad.ReadOnly)
			{
				listaEspecialidades();
			}
		}

		private void txtEspecialidad_Leave(object sender, EventArgs e)
		{
			if (txtEspecialidad.Valor.Trim().Equals(""))
			{
				txtEspecialidadN.Clear();
			}
			else
			{
				if (oldValue != txtEspecialidad.Valor)
				{
					cargarEspecialidad(txtEspecialidad.Valor);
					if (txtEspecialidad.Valor.Trim() == "")
						MessageBox.Show("La Especialidad digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtEspecialidad_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtEspecialidad.ReadOnly)
			{
				listaEspecialidades();
			}
		}

		private void txtCampoEspecialidad_Enter(object sender, EventArgs e)
		{
			oldValue = txtCampoEspecialidad.Valor;
		}

		private void txtCampoEspecialidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtCampoEspecialidad.ReadOnly)
			{
				listaCamposEspecialidad();
			}
		}

		private void txtCampoEspecialidad_Leave(object sender, EventArgs e)
		{
			if (txtCampoEspecialidad.Valor.Trim().Equals(""))
			{
				txtCampoEspecialidadN.Clear();
			}
			else
			{
				if (oldValue != txtCampoEspecialidad.Valor)
				{
					cargarCampoEspecialidad(txtCampoEspecialidad.Valor);
					if (txtCampoEspecialidad.Valor.Trim() == "")
						MessageBox.Show("El Campo de Especialidad digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtCampoEspecialidad_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtCampoEspecialidad.ReadOnly)
			{
				listaCamposEspecialidad();
			}
		}

		private void txtOrientacion_Enter(object sender, EventArgs e)
		{
			// oldValue = txtOrientacion.Valor;
			oldValue = txtEnfasis.Valor;
		}

		private void txtOrientacion_KeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyValue == (char)Keys.F1 && !txtOrientacion.ReadOnly)
			//{
			//    listaOrientaciones();
			//}
			if (e.KeyValue == (char)Keys.F1 && !txtEnfasis.ReadOnly)
			{
				listaOrientaciones();
			}
		}

		private void txtOrientacion_Leave(object sender, EventArgs e)
		{
			//if (txtOrientacion.Valor.Trim().Equals(""))
			//{
			//    txtOrientacionN.Clear();
			//}
			//else
			//{
			//    if (oldValue != txtOrientacion.Valor)
			//    {
			//        cargarOrientacion(txtOrientacion.Valor);
			//        if (txtOrientacion.Valor.Trim() == "")
			//            MessageBox.Show("La Orientación digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//    }
			//}
			if (txtEnfasis.Valor.Trim().Equals(""))
			{
				txtEnfasisN.Clear();
			}
			else
			{
				if (oldValue != txtEnfasis.Valor)
				{
					cargarOrientacion(txtEnfasis.Valor);
					if (txtEnfasis.Valor.Trim() == "")
						MessageBox.Show("El énfasis de la carrera digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtOrientacion_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			//if (!txtOrientacion.ReadOnly)
			//{
			//    listaOrientaciones();
			//}
			if (!txtEnfasis.ReadOnly)
			{
				listaOrientaciones();
			}
		}

		private void btnAgregarEspecialidad_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (txtEspecialidad.Valor.Trim() == "")
				{
					MessageBox.Show("Para agregar el historial debe especificar la especialidad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtEmpresa.Focus();
					return;
				}
				if (txtSesionAprob.Valor.Trim().Equals(""))
				{
					MessageBox.Show("Para agregar el historial debe especificar el código de sesión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtSesionAprob.Focus();
					return;
				}
				dgvEspecialidades.Rows.Add(txtEspecialidad.Valor, txtEspecialidadN.Valor, txtSesionAprob.Valor, dtpFechaSesionAprob.Value.ToString("dd/MM/yyyy"));
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnEliminarEspecialidad_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvEspecialidades.Rows.Count > 0)
				{
					dgvEspecialidades.Rows.RemoveAt(dgvEspecialidades.SelectedRows[0].Index);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnAgregarCampo_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (txtCampoEspecialidad.Valor.Trim() == "")
				{
					MessageBox.Show("Para agregar el historial debe especificar el campo especialidad.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCampoEspecialidad.Focus();
					return;
				}
				dgvCamposEspecialidad.Rows.Add(txtCampoEspecialidad.Valor, txtCampoEspecialidadN.Valor);
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnEliminarCampo_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvCamposEspecialidad.Rows.Count > 0)
				{
					dgvCamposEspecialidad.Rows.RemoveAt(dgvCamposEspecialidad.SelectedRows[0].Index);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnAgregarOrientacion_Click(object sender, EventArgs e)
		{
			//if (txtOrientacion.Valor.Trim() == "")
			//{
			//    MessageBox.Show("Para agregar el historial debe especificar la orientación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//    txtOrientacion.Focus();
			//    return;
			//}
			//dgvOrientaciones.Rows.Add(txtOrientacion.Valor, txtOrientacionN.Valor);
		}

		private void btnEliminarOrientacion_Click(object sender, EventArgs e)
		{
			//if (dgvOrientaciones.Rows.Count > 0)
			//{
			//    dgvOrientaciones.Rows.RemoveAt(dgvOrientaciones.SelectedRows[0].Index);
			//}
		}

		private void rbNoTitulo_MouseClick(object sender, MouseEventArgs e)
		{
			if (rbNoTitulo.Checked)
			{
				txtCalculoTitulo.Valor = (10000).ToString("N2");
				dtpFechaTitulo.Enabled = true;
			}
		}

		private void rbSiTitulo_MouseClick(object sender, MouseEventArgs e)
		{
			if (rbSiTitulo.Checked)
			{
				txtCalculoTitulo.Valor = (0).ToString("N2");
				dtpFechaTitulo.Value = DateTime.Now;
				dtpFechaTitulo.Enabled = false;
			}
		}

		private void rbSiTitulo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (rbSiTitulo.Checked)
			{
				txtCalculoTitulo.Valor = (0).ToString("N2");
				dtpFechaTitulo.Value = DateTime.Now;
				dtpFechaTitulo.Enabled = false;
			}
		}

		private void rbNoTitulo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (rbNoTitulo.Checked)
			{
				txtCalculoTitulo.Valor = (10000).ToString("N2");
				dtpFechaTitulo.Enabled = true;
			}
		}

		private void txtPlantilla_Enter(object sender, EventArgs e)
		{
			//oldValue = txtPlantilla.Valor;
		}

		private void txtPlantilla_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtPlantilla.ReadOnly)
			{
				listaPlantillas();
			}
		}

		private void txtPlantilla_Leave(object sender, EventArgs e)
		{
			//if (txtPlantilla.Valor.Trim().Equals(""))
			//{
			//    txtPlantillaN.Clear();
			//    dgvPlantilla.Rows.Clear();
			//}
			//else
			//{
			//    if (oldValue != txtPlantilla.Valor)
			//    {
			//        cargarPlantilla();
			//        if (txtPlantilla.Valor.Trim() == "")
			//            MessageBox.Show("La plantilla digitada no existe o no contiene artículos definidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//    }
			//}
		}

		private void txtPlantilla_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtPlantilla.ReadOnly)
			{
				listaPlantillas();
			}
		}

		//private void dgvPlantilla_CellClick(object sender, DataGridViewCellEventArgs e)
		//{
		//    dtp.Visible = false;
		//    if ((e.ColumnIndex == 5 || e.ColumnIndex == 6) && e.RowIndex != -1)
		//    {
		//        if (dgvPlantilla.Rows[e.RowIndex].Cells["colActivoArticulo"].Value.Equals(false))
		//        {
		//            dtp = new DateTimePicker();
		//            dgvPlantilla.Controls.Add(dtp);
		//            dtp.Format = DateTimePickerFormat.Custom;
		//            dtp.CustomFormat = "dd/MM/yyyy";
		//            Rectangle Rectangle = dgvPlantilla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
		//            dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
		//            dtp.Location = new Point(Rectangle.X, Rectangle.Y);

		//            dtp.CloseUp += new EventHandler(dtp_CloseUp);
		//            dtp.TextChanged += new EventHandler(dtp_OnTextChange);
		//            dtp.LostFocus += new EventHandler(dtp_CloseUp);

		//            if (e.ColumnIndex == 5 && dgvPlantilla.Rows[e.RowIndex].Cells["colDesdeArticulo"].Value.ToString() != string.Empty)
		//                dtp.Value = DateTime.Parse(dgvPlantilla.Rows[e.RowIndex].Cells["colDesdeArticulo"].Value.ToString());

		//            if (e.ColumnIndex == 6 && dgvPlantilla.Rows[e.RowIndex].Cells["colHastaArticulo"].Value.ToString() != string.Empty)
		//                dtp.Value = DateTime.Parse(dgvPlantilla.Rows[e.RowIndex].Cells["colHastaArticulo"].Value.ToString());

		//            dtp.Visible = true;
		//        }
		//    }
		//}

		//private void dtp_OnTextChange(object sender, EventArgs e)
		//{
		//    dgvPlantilla.CurrentCell.Value = dtp.Text.ToString();
		//}

		private void dtp_OnTextChange(object sender, EventArgs e)
		{
			dgvEstablecimientos.CurrentCell.Value = dtp.Text.ToString();
		}

		private void dtp_OnTextChangePlaguicidas(object sender, EventArgs e)
		{
			dgvInvestigacionPlaguicidas.CurrentCell.Value = dtp.Text.ToString();
		}

		private void dtp_OnTextChangeSilvestre(object sender, EventArgs e)
		{
			dgvVidaSilvestre.CurrentCell.Value = dtp.Text.ToString();
		}

		private void dtp_OnTextChangeAerea(object sender, EventArgs e)
		{
			dgvViaAerea.CurrentCell.Value = dtp.Text.ToString();
		}

		private void dtp_OnTextChangeGestion(object sender, EventArgs e)
		{
			dgvGestionCobro2.CurrentCell.Value = dtp.Text.ToString();
		}

		void dtp_CloseUp(object sender, EventArgs e)
		{
			dtp.Visible = false;
		}


		private void btnAdicional_Click(object sender, EventArgs e)
		{
			listaArticulos();
		}

		private void btnAdicionalD_Click(object sender, EventArgs e)
		{
			if (dgvPlantilla.Rows.Count > 0)
			{
				//agregar delete

				if (dgvPlantilla.Rows[dgvPlantilla.SelectedCells[0].RowIndex].Cells["colPlantilla"].Value.ToString() == string.Empty)
					dgvPlantilla.Rows.RemoveAt(dgvPlantilla.SelectedCells[0].RowIndex);
				else
					MessageBox.Show("Solo es posible eliminar artículos adicionales.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void listaArticulos()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción, case when COSTO_FISCAL = 'P' then COSTO_PROM_LOC else COSTO_STD_LOC END as 'Costo Local',case when COSTO_FISCAL = 'P' then COSTO_PROM_DOL else COSTO_STD_DOL END as 'Costo Dólar'";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "ARTICULO";
			listP.ORDERBY = "order by ARTICULO";
			listP.FILTRO = "where ARTICULO like 'KOL-%' and TIPO = 'V'";
			listP.TITULO_LISTADO = "Artículos";
			listP.COLUMNAS_NUMERICAS.Add("Costo Local");
			listP.COLUMNAS_NUMERICAS.Add("Costo Dólar");

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				if (!validarArticulo(f1.item.SubItems[0].Text))
				{
					MessageBox.Show("Ya existe un detalle con la misma información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
					//txtArticulo.Focus();
					return;
				}

				dgvPlantilla.Rows.Add(string.Empty, txtCondicion.Valor, f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, true, string.Empty, string.Empty, decimal.Parse(f1.item.SubItems[2].Text), string.Empty, string.Empty, string.Empty);
			}
		}

		private bool validarArticulo(string articulo)
		{
			foreach (DataGridViewRow r in dgvPlantilla.Rows)
			{
				if (r.Cells["colCodigoArticulo"].Value.ToString().Equals(articulo))
				{
					return false;
				}
			}
			return true;
		}

		private bool validarPeritaje(ref string errores)
		{
			if (txtInstitucion.Valor.Trim() == "")
			{
				errores = "Debe digitar la Institución para peritaje.";
				txtInstitucion.Focus();
				return false;
			}

			//if (txtSesionAprobPeritaje.Valor.Trim() == "")
			//{
			//    errores = "Debe digitar un numero de sesion aprobación.";
			//    txtSesionAprobPeritaje.Focus();
			//    tabControl.SelectedTab = tpPeritajes;
			//    return false;
			//}
			return true;
		}

		private void listaFormas(int rowIndex, int columnIndex)
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoForma as 'Forma Pago', NombreForma as 'Nombre',Cuenta";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_FORMAS_PAGO";
			listP.ORDERBY = "order by CodigoForma";
			listP.TITULO_LISTADO = "Formas de Pago";

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				dgvPlantilla.Rows[rowIndex].Cells[columnIndex].Value = f1.item.SubItems[0].Text;
				dgvPlantilla.RefreshEdit();
			}
		}

		private void cargarForma(string forma, int rowIndex, int columnIndex)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "NV_FORMAS_PAGO";
			listA.FILTRO = "where CodigoForma = '" + forma + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex].Value = dtTTs.Rows[0]["CodigoForma"].ToString();
				}
				else
				{
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex].Value = string.Empty;
					if (forma.Trim() != "")
						MessageBox.Show("La forma de pago digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		//Metodo usado cuando estaba en planilla de cobro
		private void listaFrecuencias(int rowIndex, int columnIndex)
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CONDICION_PAGO as 'Código', DESCRIPCION as 'Frecuencia',DIAS_NETO as 'Días'";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "CONDICION_PAGO";
			listP.ORDERBY = "order by CONDICION_PAGO";
			listP.TITULO_LISTADO = "Frecuencias de Pago";
			listP.COLUMNAS_NUMERICAS_INT.Add("Días");

			frmF1 f1 = new frmF1(listP);
			f1.ShowDialog();
			if (f1.item != null)
			{
				dgvPlantilla.Rows[rowIndex].Cells[columnIndex].Value = f1.item.SubItems[0].Text;
				dgvPlantilla.Rows[rowIndex].Cells[columnIndex + 1].Value = f1.item.SubItems[1].Text;
				dgvPlantilla.Rows[rowIndex].Cells[columnIndex + 2].Value = int.Parse(f1.item.SubItems[2].Text);
				dgvPlantilla.RefreshEdit();
			}
		}

		/* private void listaFrecuencias()
		 {
			 Listado listP = new Listado();
			 listP.COLUMNAS = "CONDICION_PAGO as 'Código', DESCRIPCION as 'Frecuencia',DIAS_NETO as 'Días'";
			 listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			 listP.TABLA = "CONDICION_PAGO";
			 listP.ORDERBY = "order by CONDICION_PAGO";
			 listP.TITULO_LISTADO = "Frecuencias de Pago";
			 listP.COLUMNAS_NUMERICAS_INT.Add("Días");


			 frmF1 f1 = new frmF1(listP);
			 f1.ShowDialog();
			 if (f1.item != null)
			 {
				 txtFrecuencia.Valor = f1.item.SubItems[0].Text;
				 txtFrecDescripcion.Valor = f1.item.SubItems[1].Text;
				 txtFrecDias.Valor = f1.item.SubItems[2].Text;
			 }
		 }*/

		private void cargarFrecuencia(string frec, int rowIndex, int columnIndex)
		{
			DataTable dtTTs = new DataTable();
			Listado listA = new Listado();
			listA.COLUMNAS = "*";
			listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listA.TABLA = "CONDICION_PAGO";
			listA.FILTRO = "where CONDICION_PAGO = '" + frec + "'";

			if (Consultas.listarDatos(listA, ref dtTTs, ref error))
			{
				if (dtTTs.Rows.Count > 0)
				{
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex].Value = dtTTs.Rows[0]["CONDICION_PAGO"].ToString();
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex + 1].Value = dtTTs.Rows[0]["DESCRIPCION"].ToString();
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex + 2].Value = int.Parse(dtTTs.Rows[0]["DIAS_NETO"].ToString());
				}
				else
				{
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex].Value = string.Empty;
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex + 1].Value = string.Empty;
					dgvPlantilla.Rows[rowIndex].Cells[columnIndex + 2].Value = string.Empty;
					if (frec.Trim() != "")
						MessageBox.Show("La frecuencia de pago digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void dgvPlantilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex != -1)
			{
				if (e.ColumnIndex == 8)
					listaFormas(e.RowIndex, e.ColumnIndex);
				else
					listaFrecuencias(e.RowIndex, e.ColumnIndex);
			}
		}

		//private void EventoPlantillaMayusculas()
		//{
		//    //Indica cuales columnas del datagridiview desea convertir a mayuscula
		//    var lstColumnas = new List<String>();
		//    lstColumnas.Add("colFormaPagoArticulo");
		//    lstColumnas.Add("colFrecuenciaArticulo");
		//    this._dgvPlantillaUtil = new DataGridViewUtilidades(ref dgvPlantilla, lstColumnas);
		//    this._dgvPlantillaUtil.ListaColumnasOblitarias = lstColumnas;
		//}

		private void dgvPlantilla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (onChanged)
				if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex != -1)
				{
					if (dgvPlantilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
						if (e.ColumnIndex == 8)
							cargarForma(dgvPlantilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), e.RowIndex, e.ColumnIndex);
						else
							cargarFrecuencia(dgvPlantilla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), e.RowIndex, e.ColumnIndex);
				}
		}

		//private void dgvPlantilla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		//{
		//    if (dgvPlantilla.Columns[e.ColumnIndex].Name == "colActivoArticulo" && e.RowIndex != -1)
		//    {
		//        var isChecked = dgvPlantilla[e.ColumnIndex, e.RowIndex].Value as bool? ?? false;
		//        if (isChecked)
		//        {
		//            dgvPlantilla.Rows[e.RowIndex].Cells["colDesdeArticulo"].Value = string.Empty;
		//            dgvPlantilla.Rows[e.RowIndex].Cells["colHastaArticulo"].Value = string.Empty;
		//            dgvPlantilla.Rows[e.RowIndex].Cells["colDesdeArticulo"].Style.BackColor = dgvPlantilla.Columns[e.RowIndex].DefaultCellStyle.BackColor;
		//            dgvPlantilla.Rows[e.RowIndex].Cells["colHastaArticulo"].Style.BackColor = dgvPlantilla.Columns[e.RowIndex].DefaultCellStyle.BackColor;
		//        }
		//        else
		//        {
		//            dgvPlantilla.Rows[e.RowIndex].Cells["colDesdeArticulo"].Style.BackColor = Color.White;
		//            dgvPlantilla.Rows[e.RowIndex].Cells["colHastaArticulo"].Style.BackColor = Color.White;
		//        }
		//    }
		//}

		private void dgvPlantilla_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvPlantilla.IsCurrentCellDirty)
			{
				dgvPlantilla.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void cargarBeneficiarios()
		{
			DataTable dtDependientes = new DataTable();
			Listado listP = new Listado();
			//listP.COLUMNAS = "Cedula Cédula,Nombre+' '+PrimerApellido+' '+SegundoApellido [Nombre Beneficiario],Cast(Cast(Porcentaje as decimal(18,2)) as varchar(5)) + ' %' as Porcentaje,CASE Sexo WHEN 'M' THEN 'Masculino' when 'F' THEN 'Femenino' end as Sexo,CASE RenunciaAjusteFondo WHEN 'S' THEN 'Si' when 'N' THEN 'No' end [Renuncia Ajuste Fondo],FechaNacimiento [Fecha Inclusión],Parentesco";
			//listP.COMPAÑIA = "dbo";
			listP.COLUMNAS = "Cedula Cédula,Nombre [Nombre Beneficiario],Cast(Cast(Porcentaje as decimal(18,2)) as varchar(6)) + ' %' as Porcentaje,CASE Sexo WHEN 'M' THEN 'Masculino' when 'F' THEN 'Femenino' end as Género, FechaNacimiento [Fecha Inclusión],Parentesco";
			//listP.COLUMNAS = "Cedula Cédula,Nombre [Nombre Beneficiario],Cast(Cast(Porcentaje as decimal(18,2)) as varchar(6)) + ' %' as Porcentaje,CASE Sexo WHEN 'M' THEN 'Masculino' when 'F' THEN 'Femenino' end as Género,CASE RenunciaAjusteFondo WHEN 'S' THEN 'Si' when 'N' THEN 'No' end [Renuncia Ajuste Fondo],FechaNacimiento [Fecha Inclusión],Parentesco";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_BENEFICIARIOS";
			listP.FILTRO = "WHERE NumeroColegiado = '" + txtIdColegiado.Valor + "'";
			listP.ORDERBY = "order by Nombre";
			listP.COLUMNAS_FECHAS.Add("Fecha Nacimiento");
			if (Consultas.listarDatos(listP, ref dtDependientes, ref error))
			{
				if (dtDependientes.Rows.Count > 0)
				{
					dlvBeneficiarios.DataSource = dtDependientes;

					ListView.ColumnHeaderCollection columns = dlvBeneficiarios.Columns;

					for (int i = 0; i < columns.Count; i++)
					{
						for (int j = 0; j < listP.COLUMNAS_NUMERICAS_INT.Count; j++)
						{
							if (columns[i].Name == listP.COLUMNAS_NUMERICAS_INT[j])
							{
								dlvBeneficiarios.GetColumn(i).AspectToStringConverter = delegate (object aspect)
								{
									if (aspect != System.DBNull.Value)
										return ((int)aspect).ToString("N0");
									else
										return "";
								};
								columns[i].TextAlign = HorizontalAlignment.Right;
							}
						}

						/*   for (int j = 0; j < listP.COLUMNAS_OCULTAS.Count; j++)
                           {
                               if (columns[i].Name == listP.COLUMNAS_OCULTAS[j])
                               {
                                   dlvPolizasHijas.GetColumn(i).MinimumWidth = 0;
                                   dlvPolizasHijas.GetColumn(i).MaximumWidth = 0;

                               }
                           }*/
						for (int j = 0; j < listP.COLUMNAS_FECHAS.Count; j++)
						{
							if (columns[i].Name == listP.COLUMNAS_FECHAS[j])
							{
								dlvBeneficiarios.GetColumn(i).AspectToStringConverter = delegate (object aspect)
								{
									if (aspect != System.DBNull.Value)
										return ((DateTime)aspect).ToString("dd/MM/yyyy");
									else
										return "";
								};
								//columns[i].TextAlign = HorizontalAlignment.Right;
							}
						}

					}
					//lblDependientes.Text = dlvBeneficiarios.Items.Count.ToString("N0");
					//lblDependientes.Refresh();

					dlvBeneficiarios.AutoResizeColumns();
				}
				else
				{
					dlvBeneficiarios.DataSource = null;
					dlvBeneficiarios.Reset();
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnNuevoBeneficiario_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (valoresPk.Count == 0)
				{
					MessageBox.Show("Primero debe guardar el Colegiado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				frmBeneficiariosEdicion frm = new frmBeneficiariosEdicion(new List<string>(), txtIdColegiado.Valor);
				frm.ShowDialog();
				cargarBeneficiarios();
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnEliminarBeneficiario_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dlvBeneficiarios.Items.Count > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
							  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_BENEFICIARIOS WHERE Cedula='" + dlvBeneficiarios.SelectedItem.SubItems[dlvBeneficiarios.GetColumn("Cédula").Index].Text + "' AND NumeroColegiado ='" + txtIdColegiado.Valor + "'";
						if (Consultas.ejecutarSentencia(sQuery, ref error))
						{
							cargarBeneficiarios();
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnModificarBeneficiario_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (dlvBeneficiarios.SelectedItem != null)
				{
					List<string> pk = new List<string>();
					pk.Add(dlvBeneficiarios.SelectedItem.SubItems[dlvBeneficiarios.GetColumn("Cédula").Index].Text);
					pk.Add(txtIdColegiado.Valor);
					frmBeneficiariosEdicion frm = new frmBeneficiariosEdicion(pk, "");
					frm.ShowDialog();
					cargarBeneficiarios();
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void btnRefrescarBeneficiarios_Click(object sender, EventArgs e)
		{
			cargarBeneficiarios();
		}

		private void dlvBeneficiarios_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dlvBeneficiarios.Items.Count > 0)
			{
				List<string> valores = new List<string>();
				valores.Add(dlvBeneficiarios.SelectedItem.SubItems[dlvBeneficiarios.GetColumn("Cédula").Index].Text);
				valores.Add(txtIdColegiado.Valor);
				frmBeneficiariosEdicion frm = new frmBeneficiariosEdicion(valores, "");
				frm.ShowDialog();
				cargarBeneficiarios();
			}
		}


		private void btnCargarEstablecimientos_Click(object sender, EventArgs e)
		{
			cargarRegencias();
		}

		private void btnAjustarCol_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			dgvEstablecimientos.AutoResizeColumns();
			Cursor.Current = Cursors.Default;
		}

		private void dtpFechaNac_Leave_1(object sender, EventArgs e)
		{
			if (dtpFechaNac.Value >= DateTime.Now)
				txtEdad.Valor = "0";
			else
				txtEdad.Valor = "" + (int)((DateTime.Now - dtpFechaNac.Value).TotalDays / 365.242199);
		}

		private void dgvEstablecimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			List<string> pk = new List<string>();
			pk.Add(txtNumeColegiado.Valor);
			frmRegentesEdicion frm = new frmRegentesEdicion(pk);
			frm.ShowDialog();
			cargarRegencias();
		}

		private void dgvEstablecimientos_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvEstablecimientos.CurrentRow != null)
			{
				if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colCodigoEstablecimiento" || dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colNombreEstablecimiento"/*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
				{
					listaEstablecimientosRegentes();
				}
				if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colCategoria" /*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
				{
					listaCategoriasRegente();
				}
				if (dgvEstablecimientos.CurrentCell.OwningColumn.Name == "colCobrador" /*&& dgvEstablecimientos.CurrentCell.OwningColumn.Equals("")*/ )
				{
					listaCobradores("ESTABLE");
				}
			}

		}

		private void txtCodigoSesionIncorporacion_KeyUp(object sender, KeyEventArgs e)
		{
			if (txtCodigoSesionIncorporacion.ReadOnly == false && txtCodigoSesionIncorporacion.Count() > 0)
				dtpFechaIngreso.Enabled = true;
			else
				dtpFechaIngreso.Enabled = false;
		}

		private void btnNuevoPerito_Click(object sender, EventArgs e)
		{


			if (Utilitario.BuscaForm("frmPeritosEdicion"))
			{
				frmPeritosEdicion frm = new frmPeritosEdicion(new List<string>(), txtNumeColegiado.Valor);
				frm.Show();
			}
		}

		private void btnNuevoRegente_Click(object sender, EventArgs e)
		{
			if (Utilitario.BuscaForm("frmRegentesEdicion"))
			{
				frmRegentesEdicion frm = new frmRegentesEdicion(new List<string>(), txtNumeColegiado.Valor);
				frm.Show();
			}
		}

		private void btnAsignarEstablecimiento_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Usu, Constantes.ESTABLECIMIENTO))
			{
				if (Utilitario.BuscaForm("frmListEstablecimientos"))
				{
					frmListEstablecimientos frm = new frmListEstablecimientos(txtIdColegiado.Valor);
					frm.Show();
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void chkCursoPeritaje_MouseClick(object sender, MouseEventArgs e)
		{
			if (chkCursoPeritaje.Checked)
			{
				habilitarValoresPeritaje();
				//txtCobradorPeritaje.Valor = txtCobrador.Valor;
				//txtCobradorPeritajeNombre.Valor = txtDescCobrador.Valor;
			}
			else
			{
				deshabilitarValoresPeritaje();
				//limpiarCamposPeritaje();
			}
		}

		private void chkCurso_MouseClick(object sender, MouseEventArgs e)
		{
			if (chkCurso.Checked)
			{
				habilitarValoresRegente();
				verificarSiRequierePoliza();
				//txtCobradorRegente.Valor = txtCobrador.Valor;
				//txtCobradorNombre.Valor = txtDescCobrador.Valor;
			}
			else
			{
				deshabilitarValoresRegente();
				//limpiarCamposRegente();
			}
		}

		private void habilitarValoresRegente()
		{
			txtCobradorRegente.ReadOnly = false;
			txtSesionAprobacion.ReadOnly = false;
			txtSesionPerdida.ReadOnly = false;
			dtpAprobacion.Enabled = true;
			dtpPerdida.Enabled = true;
			txtNPoliza.ReadOnly = false;
			txtMonto.ReadOnly = false;
			dtpFecha.Enabled = true;
			dtpVencimiento.Enabled = true;
			cmbTipoRegente.Enabled = true;
		}

		private void deshabilitarValoresRegente()
		{
			txtCobradorRegente.ReadOnly = true;
			txtSesionAprobacion.ReadOnly = true;
			txtSesionPerdida.ReadOnly = true;
			dtpAprobacion.Enabled = false;
			dtpPerdida.Enabled = false;
			txtNPoliza.ReadOnly = true;
			txtMonto.ReadOnly = true;
			dtpFecha.Enabled = false;
			dtpVencimiento.Enabled = false;
			cmbTipoRegente.Enabled = false;
		}

		private void habilitarValoresPeritaje()
		{
			txtInstitucion.ReadOnly = false;
			txtCobradorPeritaje.ReadOnly = false;
			rtbObservaciones.ReadOnly = false;
			cmbTipoPerito.Enabled = true;
			txtSesionAprobPeritaje.ReadOnly = false;
			txtSesionRenov.ReadOnly = false;
			txtSesionPerdidaPeritaje.ReadOnly = false;
			dtpSesionAprobPeritaje.Enabled = true;
			dtpRenovacion.Enabled = true;
			dtpSesionPerdidaPeritaje.Enabled = true;
		}

		private void deshabilitarValoresPeritaje()
		{
			txtInstitucion.ReadOnly = true;
			txtCobradorPeritaje.ReadOnly = true;
			rtbObservaciones.ReadOnly = true;
			cmbTipoPerito.Enabled = false;
			txtSesionAprobPeritaje.ReadOnly = true;
			txtSesionRenov.ReadOnly = true;
			txtSesionPerdidaPeritaje.ReadOnly = true;
			dtpSesionAprobPeritaje.Enabled = false;
			dtpRenovacion.Enabled = false;
			dtpSesionPerdidaPeritaje.Enabled = false;
		}

		private void limpiarCamposPeritaje()
		{
			txtInstitucion.Clear();
			txtNombreInstitucion.Clear();
			txtCobradorPeritaje.Clear();
			txtCobradorPeritajeNombre.Clear();
			rtbObservaciones.Clear();
			cmbTipoPerito.Valor = "";
			txtSesionAprobPeritaje.Clear();
			txtSesionRenov.Clear();
			txtSesionPerdidaPeritaje.Clear();
			dtpSesionAprobPeritaje.Value = DateTime.Now;
			dtpRenovacion.Value = DateTime.Now;
			dtpSesionPerdidaPeritaje.Value = DateTime.Now;
		}

		private void limpiarCamposRegente()
		{
			txtCobradorRegente.Clear();
			txtCobradorNombre.Clear();
			txtSesionAprobacion.Clear();
			txtSesionPerdida.Clear();
			dtpAprobacion.Value = DateTime.Now;
			dtpPerdida.Value = DateTime.Now;
			cmbTipoRegente.Valor = "";
			txtNPoliza.Clear();
			txtMonto.Clear();
			dtpFecha.Value = DateTime.Now;
			dtpVencimiento.Value = DateTime.Now;
		}

		private void txtInstitucion_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!txtInstitucion.ReadOnly)
			{
				listaInstituciones();
			}
		}

		private void txtInstitucion_Leave(object sender, EventArgs e)
		{
			if (txtInstitucion.Valor.Trim().Equals(""))
			{
				txtNombreInstitucion.Clear();
			}
			else
			{
				if (oldValue != txtInstitucion.Valor)
				{
					cargarInstitucion(txtInstitucion.Valor);
					if (txtInstitucion.Valor.Trim() == "")
						MessageBox.Show("La Empresa digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void txtInstitucion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtInstitucion.ReadOnly)
			{
				listaInstituciones();
			}
		}

		private void txtInstitucion_Enter(object sender, EventArgs e)
		{
			oldValue = txtInstitucion.Valor;
		}

		private void btnNuevoEst_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				DataTable dtTTs = new DataTable();
				Listado listA = new Listado();
				listA.COLUMNAS = "*";
				listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
				listA.TABLA = "NV_REGENTES";
				listA.FILTRO = "where NumeroColegiado = '" + txtIdColegiado.Valor + "'";

				if (Consultas.listarDatos(listA, ref dtTTs, ref error))
				{
					if (dtTTs.Rows.Count > 0)
					{
						if (!tieneSancion())
						{
							dgvEstablecimientos.Rows.Add("", "", "", "", "Activo", "", "");
						}
						else
						{
							MessageBox.Show("El regente esta sancionado, no se puede agregar ninguna regencia.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}

					}
					else
					{
						MessageBox.Show("Debe asignar el colegiado como regente antes de asignarle un establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
					MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnEliminaEst_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvEstablecimientos.RowCount == 0)
					return;

				if (MessageBox.Show("Se borrará toda la información asociada al establecimiento (Horario, Informes, Visitas Fiscalía), ¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
							  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
				{
					Consultas.sqlCon.iniciaTransaccion();
					bool OK = true;
					string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
						".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS where NumeroColegiado='"
						+ txtIdColegiado.Valor +
						"' and CodigoEstablecimiento='" +
						dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

					OK = Consultas.ejecutarSentencia(sQuery, ref error);

					if (OK)
					{
						sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
						".NV_REGENTES_ESTABLECIMIENTOS_INFORMES where NumeroColegiado='"
						+ txtIdColegiado.Valor +
						"' and CodigoEstablecimiento='" +
						dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

						OK = Consultas.ejecutarSentencia(sQuery, ref error);
					}

					if (OK)
					{
						sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
						".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC where NumeroColegiado='"
						+ txtIdColegiado.Valor +
						"' and CodigoEstablecimiento='" +
						dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

						OK = Consultas.ejecutarSentencia(sQuery, ref error);
					}

					if (OK)
					{
						sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
						".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado='"
						+ txtIdColegiado.Valor +
						"' and CodigoEstablecimiento='" +
						dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";

						OK = Consultas.ejecutarSentencia(sQuery, ref error);
					}

					if (OK)
					{
						Consultas.sqlCon.Commit();
						dgvEstablecimientos.Rows.Remove(dgvEstablecimientos.CurrentRow);
					}
					else
					{
						Consultas.sqlCon.Rollback();
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnNuevoPlaguicida_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				dgvInvestigacionPlaguicidas.Rows.Add("", "", "", "", "", "", "", "", "", "");
				if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
					deshabilitarActivoPlagui();
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnNuevoSilvestre_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				dgvVidaSilvestre.Rows.Add("", "", "", "", "", "", "", "", "", "");
				if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
					deshabilitarActivoSilvestre();
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void dgvInvestigacionPlaguicidas_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvInvestigacionPlaguicidas.CurrentRow != null)
				if ((dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colCodigoCampo" || dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colNombreCampo") && dgvInvestigacionPlaguicidas.CurrentCell.Value.ToString().Equals(""))
				{
					listaCamposInvestigacion();
				}
		}

		private void dgvVidaSilvestre_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvVidaSilvestre.CurrentRow != null)
				if ((dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colCodigoSilvestre" || dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colNombreSilvestre") && dgvVidaSilvestre.CurrentCell.Value.ToString().Equals(""))
				{
					listaVidaSilvestre();
				}
		}

		private void listaCamposInvestigacion()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoCampo as Codigo,NombreCampo as Nombre, DescripcionCampo as Descripción";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CAMPOS_INVESTIGACION";
			listP.ORDERBY = "order by CodigoCampo";
			listP.TITULO_LISTADO = "Campos de Investigación";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();

			if (f1Colegiado.item != null)
			{

				dgvInvestigacionPlaguicidas.CurrentCell.OwningRow.Cells["colCodigoCampo"].Value = f1Colegiado.item.SubItems[0].Text;
				dgvInvestigacionPlaguicidas.CurrentCell.OwningRow.Cells["colNombreCampo"].Value = f1Colegiado.item.SubItems[1].Text;
				dgvInvestigacionPlaguicidas.EndEdit();
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}
		}

		private void listaCultivosRecetas()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoCultivo as Codigo,NombreCultivo as Nombre, DescripcionCultivo as Descripción";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_CULTIVOS_RECETAS";
			listP.ORDERBY = "order by CodigoCultivo";
			listP.TITULO_LISTADO = "Cultivos para Recetar";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();

			if (f1Colegiado.item != null)
			{

				dgvViaAerea.CurrentCell.OwningRow.Cells["colCodigoAerea"].Value = f1Colegiado.item.SubItems[0].Text;
				dgvViaAerea.CurrentCell.OwningRow.Cells["colNombreAerea"].Value = f1Colegiado.item.SubItems[1].Text;
				dgvViaAerea.EndEdit();
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}
		}

		private void listaVidaSilvestre()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoSilvestre as Codigo,NombreSilvestre as Nombre, DescripcionSilvestre as Descripción";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_VIDA_SILVESTRE";
			listP.ORDERBY = "order by CodigoSilvestre";
			listP.TITULO_LISTADO = "Vida Silvestre";
			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();

			if (f1Colegiado.item != null)
			{

				dgvVidaSilvestre.CurrentCell.OwningRow.Cells["colCodigoSilvestre"].Value = f1Colegiado.item.SubItems[0].Text;
				dgvVidaSilvestre.CurrentCell.OwningRow.Cells["colNombreSilvestre"].Value = f1Colegiado.item.SubItems[1].Text;
				dgvVidaSilvestre.EndEdit();
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}
		}

		private void dgvInvestigacionPlaguicidas_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			dtp.Visible = false;
			if (e.RowIndex != -1)
			{
				if ((dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colFechaAprobacion"))
				{

					dtp = new DateTimePicker();
					dgvInvestigacionPlaguicidas.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvInvestigacionPlaguicidas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangePlaguicidas);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colFechaAprobacion" && dgvInvestigacionPlaguicidas.Rows[e.RowIndex].Cells["colFechaAprobacion"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvInvestigacionPlaguicidas.Rows[e.RowIndex].Cells["colFechaAprobacion"].Value.ToString());

					dtp.Visible = true;

				}

				if ((dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colFechaRenovacion"))
				{

					dtp = new DateTimePicker();
					dgvInvestigacionPlaguicidas.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvInvestigacionPlaguicidas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangePlaguicidas);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colFechaRenovacion" && dgvInvestigacionPlaguicidas.Rows[e.RowIndex].Cells["colFechaRenovacion"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvInvestigacionPlaguicidas.Rows[e.RowIndex].Cells["colFechaRenovacion"].Value.ToString());

					dtp.Visible = true;

				}

				if ((dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colFechaPerdidaP"))
				{

					dtp = new DateTimePicker();
					dgvInvestigacionPlaguicidas.Controls.Add(dtp);
					//dtp.ShowCheckBox = true;
					//dtp.Checked = false;
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvInvestigacionPlaguicidas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangePlaguicidas);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colFechaPerdidaP" && dgvInvestigacionPlaguicidas.Rows[e.RowIndex].Cells["colFechaPerdidaP"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvInvestigacionPlaguicidas.Rows[e.RowIndex].Cells["colFechaPerdidaP"].Value.ToString());

					dtp.Visible = true;

				}

				if (dgvInvestigacionPlaguicidas.CurrentCell.OwningColumn.Name == "colActivoPlagui")
				{
					if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
						MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}

			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void dgvVidaSilvestre_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			dtp.Visible = false;
			if (e.RowIndex != -1)
			{
				if ((dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colFechaAprobacionSilve"))
				{

					dtp = new DateTimePicker();
					dgvVidaSilvestre.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvVidaSilvestre.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeSilvestre);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colFechaAprobacionSilve" && dgvVidaSilvestre.Rows[e.RowIndex].Cells["colFechaAprobacionSilve"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvVidaSilvestre.Rows[e.RowIndex].Cells["colFechaAprobacionSilve"].Value.ToString());

					dtp.Visible = true;

				}

				if ((dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colFechaRenovacionSilve"))
				{

					dtp = new DateTimePicker();
					dgvVidaSilvestre.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvVidaSilvestre.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeSilvestre);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colFechaRenovacionSilve" && dgvVidaSilvestre.Rows[e.RowIndex].Cells["colFechaRenovacionSilve"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvVidaSilvestre.Rows[e.RowIndex].Cells["colFechaRenovacionSilve"].Value.ToString());

					dtp.Visible = true;

				}

				if ((dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colFechaPerdidaSilve"))
				{

					dtp = new DateTimePicker();
					dgvVidaSilvestre.Controls.Add(dtp);
					//dtp.ShowCheckBox = true;
					//dtp.Checked = false;
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvVidaSilvestre.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeSilvestre);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colFechaPerdidaSilve" && dgvVidaSilvestre.Rows[e.RowIndex].Cells["colFechaPerdidaSilve"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvVidaSilvestre.Rows[e.RowIndex].Cells["colFechaPerdidaSilve"].Value.ToString());

					dtp.Visible = true;

				}

				if (dgvVidaSilvestre.CurrentCell.OwningColumn.Name == "colActivoSilvestre")
				{
					if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
						MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}

			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void btnNuevoAerea_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				dgvViaAerea.Rows.Add("", "", "", "", "", "", "", "", "", "");
				if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
					deshabilitarActivoViaAerea();
				//dgvViaAerea.CurrentRow.Cells["colObservacionesAerea"] .ReadOnly = false;
				//dgvViaAerea.CurrentRow.Cells["colPagaCanonAerea"].ReadOnly = false;
				//dgvViaAerea.CurrentRow.Cells["colSesionAproAerea"].ReadOnly = false;
				//dgvViaAerea.CurrentRow.Cells["colSesionRenovAerea"].ReadOnly = false;
				//dgvViaAerea.CurrentRow.Cells["colSesionPerdAerea"].ReadOnly = false;
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void dgvViaAerea_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			dtp.Visible = false;
			if (e.RowIndex != -1)
			{
				if ((dgvViaAerea.CurrentCell.OwningColumn.Name == "colFechaAproAerea"))
				{

					dtp = new DateTimePicker();
					dgvViaAerea.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvViaAerea.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeAerea);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvViaAerea.CurrentCell.OwningColumn.Name == "colFechaAproAerea" && dgvViaAerea.Rows[e.RowIndex].Cells["colFechaAproAerea"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvViaAerea.Rows[e.RowIndex].Cells["colFechaAproAerea"].Value.ToString());

					dtp.Visible = true;

				}

				if ((dgvViaAerea.CurrentCell.OwningColumn.Name == "colFechaRenovAerea"))
				{

					dtp = new DateTimePicker();
					dgvViaAerea.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvViaAerea.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeAerea);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvViaAerea.CurrentCell.OwningColumn.Name == "colFechaRenovAerea" && dgvViaAerea.Rows[e.RowIndex].Cells["colFechaRenovAerea"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvViaAerea.Rows[e.RowIndex].Cells["colFechaRenovAerea"].Value.ToString());

					dtp.Visible = true;

				}

				if ((dgvViaAerea.CurrentCell.OwningColumn.Name == "colFechaPerdAerea"))
				{

					dtp = new DateTimePicker();
					dgvViaAerea.Controls.Add(dtp);
					//dtp.ShowCheckBox = true;
					//dtp.Checked = false;
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvViaAerea.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeAerea);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvViaAerea.CurrentCell.OwningColumn.Name == "colFechaPerdAerea" && dgvViaAerea.Rows[e.RowIndex].Cells["colFechaPerdAerea"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvViaAerea.Rows[e.RowIndex].Cells["colFechaPerdAerea"].Value.ToString());

					dtp.Visible = true;

				}

				if (dgvViaAerea.CurrentCell.OwningColumn.Name == "colActivoViaAerea")
				{
					if (!Consultas.tienePrivilegios(Consultas.Usuario, Constantes.MODIFICAR_ACTIVO_REGISTROS))
						MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}



			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void dgvViaAerea_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvViaAerea.CurrentRow != null)
			{
				if ((dgvViaAerea.CurrentCell.OwningColumn.Name == "colCodigoAerea" || dgvViaAerea.CurrentCell.OwningColumn.Name == "colNombreAerea") && dgvViaAerea.CurrentCell.Value.ToString().Equals(""))
				{
					listaCultivosRecetas();
				}
			}

		}

		private void btnEliminaPlagui_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvInvestigacionPlaguicidas.RowCount > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
								  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
							".NV_INVESTIGACION_PLAGUICIDAS_COLEGIADO WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoCampo = '"
							+ dgvInvestigacionPlaguicidas.CurrentCell.OwningRow.Cells["colCodigoCampo"].Value.ToString() + "'";

						if (Consultas.ejecutarSentencia(sQuery, ref error))
						{
							dgvInvestigacionPlaguicidas.Rows.Remove(dgvInvestigacionPlaguicidas.CurrentCell.OwningRow);
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnEliminarAerea_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvViaAerea.RowCount > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
								  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
							".NV_VIA_AEREA_COLEGIADO WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoCultivo = '"
							+ dgvViaAerea.CurrentCell.OwningRow.Cells["colCodigoAerea"].Value.ToString() + "'";

						if (Consultas.ejecutarSentencia(sQuery, ref error))
						{
							dgvViaAerea.Rows.Remove(dgvViaAerea.CurrentCell.OwningRow);
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void txtEntidadFinanciera_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaEntidadesFinancieras();
		}

		private void txtEntidadFinanciera_Enter(object sender, EventArgs e)
		{
			oldValue = txtEntidadFinanciera.Valor;
		}

		private void txtEntidadFinanciera_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtEntidadFinanciera.ReadOnly)
			{
				listaEntidadesFinancieras();
			}
		}

		private void txtEntidadFinanciera_Leave(object sender, EventArgs e)
		{
			buscaEntidad(txtEntidadFinanciera.Valor);
		}

		private void txtBeneficiarioCheque_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaBeneficiarios();
		}

		private void txtBeneficiarioCheque_Leave(object sender, EventArgs e)
		{
			buscaBeneficiario(txtBeneficiarioCheque.Valor);
		}

		private void txtBeneficiarioCheque_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1 && !txtBeneficiarioCheque.ReadOnly)
			{
				listaBeneficiarios();
			}
		}

		private void txtBeneficiarioCheque_Enter(object sender, EventArgs e)
		{
			oldValue = txtBeneficiarioCheque.Valor;
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl.SelectedTab.Name == "tpPago_Mutualidad")
			{
				if (chkRenuncia.Checked)
				{
					rtbRazon.ReadOnly = false;
					rtbRazon.BackColor = Color.Transparent;
					rtbRazon.Text = "Debe digitar la razón de la renuncia...";
					txtCalculoMutualidad.Valor = "0.00";
					txtCalculoMutualidadMontoRenunciar.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error).ToString();
					txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
					rtbRazon.Focus();
					rtbRazon.SelectText();
				}
				else
				{
					rtbRazon.ReadOnly = true;
					rtbRazon.BackColor = Color.Gainsboro;
					rtbRazon.Clear();
					if (!txtEdad.Valor.Trim().Equals("") && !dtpFechaIngreso.Value.Equals(""))
						if (int.Parse(txtEdad.Valor) >= 25)
						{
							txtCalculoMutualidad.Valor = fInternas.CalculoMutualidad(dtpFechaIngreso.Value, dtpFechaNac.Value, ref error);
							txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
							txtCalculoMutualidadMeses.Valor = fInternas.GetMonthDifference(dtpFechaIngreso.Value, dtpFechaNac.Value.AddYears(25), ref error).ToString();
						}
						else
						{
							txtCalculoMutualidad.Valor = "0.00";
							txtCalculoMutualidadMontoRenunciar.Valor = "0.00";
							txtCalculoMutualidadMeses.Valor = "0";
						}
				}
			}

			if (tabControl.SelectedTab.Name == "tpPlantilla")
			{
				if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.GENERAR_PED_INCORPORACION))
				{
					if (esIncorporacion)//Obtenemos el dato al verificar las configurables de condiciones
						btnProcesar.Enabled = true;
					else
						btnProcesar.Enabled = false;
				}

			}
			else
			{
				if (tabControl.SelectedTab.Name == "tpViaAerea")
				{
					if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.GENERAR_PED_CANON_AEREA) && rbPagCanAereaSI.Checked)
					{

						DataTable dtVerificarPedido = new DataTable();
						string sVerificarPedido = "select PedidoViaAerea from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador= '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

						if (dgvViaAerea.Rows.Count > 0)//Verificamos que tenga registros de via aerea
						{
							if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
							{
								if (dtVerificarPedido.Rows.Count > 0)
								{
									if (dtVerificarPedido.Rows[0]["PedidoViaAerea"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
										btnProcesar.Enabled = false;
									else
										btnProcesar.Enabled = true;
								}
								else
									btnProcesar.Enabled = false;
							}
							else
								btnProcesar.Enabled = false;
						}
						else
							btnProcesar.Enabled = false;
					}
					else
						btnProcesar.Enabled = false;

				}
				else
				{
					if (tabControl.SelectedTab.Name == "tpPlaguicidas")
					{
						if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.GENERAR_PED_CANON_PLAGUI) && rbPagCanPlaguiSI.Checked)
						{

							DataTable dtVerificarPedido = new DataTable();
							string sVerificarPedido = "select PedidoPlaguicidas from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

							if (dgvInvestigacionPlaguicidas.Rows.Count > 0)//Verificamos que tenga registros de plaguicidas
							{
								if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
								{
									if (dtVerificarPedido.Rows.Count > 0)
									{
										if (dtVerificarPedido.Rows[0]["PedidoPlaguicidas"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
											btnProcesar.Enabled = false;
										else
											btnProcesar.Enabled = true;
									}
									else
										btnProcesar.Enabled = false;
								}
								else
									btnProcesar.Enabled = false;
							}
							else
								btnProcesar.Enabled = false;
						}
						else
							btnProcesar.Enabled = false;

					}
					else
					{
						if (tabControl.SelectedTab.Name == "tpSilvestre")
						{
							if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.GENERAR_PED_CANON_SILVESTRE) && rbPagCanSilveSI.Checked)
							{

								DataTable dtVerificarPedido = new DataTable();
								string sVerificarPedido = "select PedidoSilvestre from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

								if (dgvVidaSilvestre.Rows.Count > 0)//Verificamos que tenga registros 
								{
									if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
									{
										if (dtVerificarPedido.Rows.Count > 0)
										{
											if (dtVerificarPedido.Rows[0]["PedidoSilvestre"].ToString() == "S")//Verificamos que no se le haya cobrado 
												btnProcesar.Enabled = false;
											else
												btnProcesar.Enabled = true;
										}
										else
											btnProcesar.Enabled = false;
									}
									else
										btnProcesar.Enabled = false;
								}
								else
									btnProcesar.Enabled = false;
							}
							else
								btnProcesar.Enabled = false;

						}
						else
						{
							if (tabControl.SelectedTab.Name == "tpPeritajes")
							{
								if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.GENERAR_PED_CANON_PERITAJES))
								{
									DataTable dtVerificarPerito = new DataTable();
									string sVerificarPerito = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS where IdColegiado = '" + txtIdColegiado.Valor + "'";

									DataTable dtVerificarPedido = new DataTable();
									string sVerificarPedido = "select PedidoPeritajes from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtIdColegiado.Valor + "' and Canon = 'colegiado'";

									if (Consultas.fillDataTable(sVerificarPerito, ref dtVerificarPerito, ref error))
									{
										if (dtVerificarPerito.Rows.Count > 0)//Verificamos que tenga registros de plaguicidas
										{
											if (Consultas.fillDataTable(sVerificarPedido, ref dtVerificarPedido, ref error))
											{
												if (dtVerificarPedido.Rows.Count > 0)
												{
													if (dtVerificarPedido.Rows[0]["PedidoPeritajes"].ToString() == "S")//Verificamos que no se le haya cobrado viaaerea
														btnProcesar.Enabled = false;
													else
														btnProcesar.Enabled = true;
												}
												else
													btnProcesar.Enabled = false;
											}
											else
												btnProcesar.Enabled = false;
										}
										else
											btnProcesar.Enabled = false;
									}
									else
										btnProcesar.Enabled = false;
								}
								else
									btnProcesar.Enabled = false;

							}
							else
							{
								btnProcesar.Enabled = false;
							}
						}

					}
				}
				//if (tabControl.SelectedTab.Name == "tpRegencias")
				//{
				//    if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PROCESO_COBRO_REGENCIAS))
				//    {
				//        if (dgvEstablecimientos.Rows.Count > 0)//Validamos que este asociado a un establecimiento
				//            btnProcesar.Enabled = true;
				//    }


				//}
				//else
				//{
				//    btnProcesar.Enabled = false;
				//}
			}

			//if (tabControl.SelectedTab.Name == "tpPeritajes")
			//{

			//}


		}

		private void btnNuevaGestion_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				DateTime fechaRegistro = DateTime.Now;
				dgvGestionCobro2.Rows.Add(dgvGestionCobro2.RowCount + 1, "", fechaRegistro.ToString("dd/MM/yyyy"), "", "", "");
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnEliminarGestion_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvGestionCobro2.RowCount > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
								  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
							".NV_GESTION_COBRO WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND Id = '"
							+ dgvGestionCobro2.CurrentCell.OwningRow.Cells["colId"].Value.ToString() + "'";

						if (Consultas.ejecutarSentencia(sQuery, ref error))
						{
							dgvGestionCobro2.Rows.Remove(dgvGestionCobro2.CurrentCell.OwningRow);
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void dgvGestionCobro2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dtp.Visible = false;
			if (e.RowIndex != -1)
			{
				if ((dgvGestionCobro2.CurrentCell.OwningColumn.Name == "colFechaCompromiso"))
				{

					dtp = new DateTimePicker();
					dgvGestionCobro2.Controls.Add(dtp);
					dtp.Format = DateTimePickerFormat.Custom;
					dtp.CustomFormat = "dd/MM/yyyy";
					Rectangle Rectangle = dgvGestionCobro2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
					dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
					dtp.Location = new Point(Rectangle.X, Rectangle.Y);

					dtp.CloseUp += new EventHandler(dtp_CloseUp);
					dtp.TextChanged += new EventHandler(dtp_OnTextChangeGestion);
					dtp.LostFocus += new EventHandler(dtp_CloseUp);

					if (dgvGestionCobro2.CurrentCell.OwningColumn.Name == "colFechaCompromiso" && dgvGestionCobro2.Rows[e.RowIndex].Cells["colFechaCompromiso"].Value.ToString() != string.Empty)
						dtp.Value = DateTime.Parse(dgvGestionCobro2.Rows[e.RowIndex].Cells["colFechaCompromiso"].Value.ToString());

					dtp.Visible = true;

				}
			}

			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void txtPaisTitulo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			listaPaises("PT");
		}

		private void txtPaisTitulo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == (char)Keys.F1)
				listaPaises("PT");
		}

		private void txtPaisTitulo_Leave(object sender, EventArgs e)
		{
			buscaPais(txtPais.Valor, "PT");
		}

		private void btnCambioCondicion_MouseClick(object sender, MouseEventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (Utilitario.BuscaForm("frmCambioCondicion"))
				{
					frmCambioCondicion frm = new frmCambioCondicion(txtIdColegiado.Valor, txtCondicion.Valor);
					frm.Show();
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void dgvGestionCobro2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvGestionCobro2.IsCurrentCellDirty)
			{
				dgvGestionCobro2.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void dgvInvestigacionPlaguicidas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvInvestigacionPlaguicidas.IsCurrentCellDirty)
			{
				dgvInvestigacionPlaguicidas.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void dgvEstablecimientos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvEstablecimientos.IsCurrentCellDirty)
			{
				dgvEstablecimientos.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void dgvViaAerea_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvViaAerea.IsCurrentCellDirty)
			{
				dgvViaAerea.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void dgvVidaSilvestre_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvVidaSilvestre.IsCurrentCellDirty)
			{
				dgvVidaSilvestre.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void btnRPTMutualidad_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
			{
				if (valoresPk.Count > 0)
				{
					if (Utilitario.BuscaForm("frmVisorRpt"))
					{
						DataTable dtRptCarteraGeneral = new DataTable();
						Listado listP = new Listado();
						listP.COLUMNAS = "*";
						listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
						listP.TABLA = "NV_INCORPORACION";
						listP.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";
						Cursor.Current = Cursors.WaitCursor;
						if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
						{
							if (dtRptCarteraGeneral.Rows.Count > 0)
							{

								frmVisorRpt rptCG;
								if (!chkRenuncia.Checked)
									rptCG = new frmVisorRpt(dtRptCarteraGeneral, "RPTNoMutualidad.rpt", "Renuncia al Ajuste de Fondo", Globales.NOMBRE_COMPAÑIA, new List<string>(), new List<string>());
								else
									rptCG = new frmVisorRpt(dtRptCarteraGeneral, "RPTMutualidad.rpt", "Cálculo Fondo de Mutualidad y Subsidios", Globales.NOMBRE_COMPAÑIA, new List<string>(), new List<string>());
								Cursor.Current = Cursors.Default;
								rptCG.ShowDialog();
							}
							else
							{
								error = "No hay información para generar el reporte.";
								MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void cargarFoto()
		{
			Listado list = new Listado();
			list.COLUMNAS = "Foto";
			list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			list.TABLA = "NV_COLEGIADO";
			list.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";

			if (Consultas.listarDatos(list, ref dtDatos, ref error))
			{
				if (dtDatos.Rows.Count > 0)
				{
					foreach (DataRow row in dtDatos.Rows)
					{
						if (!string.IsNullOrEmpty(row["Foto"].ToString()))
						{
							imagenPredeterminada = false;
							MemoryStream mStream = new MemoryStream();
							byte[] pData = (byte[])row["Foto"];
							mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
							Bitmap bm = new Bitmap(mStream);
							mStream.Dispose();
							pcbFoto.Image = bm;

						}
					}
				}
			}
			else
				MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnImagen_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.CheckFileExists = true;
				fileDialog.Multiselect = false;
				fileDialog.Filter = "Image File (*.png;*.jpeg;*.jpg;*.bmp;*.gif)|*.png;*.jpeg;*.jpg;*.bmp;*.gif";
				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = @Path.GetFullPath(fileDialog.FileName);
					Foto = Consultas.GetArchivoAdjunto(filePath);
					pcbFoto.Image = new Bitmap(filePath);
					btnGuardar.Enabled = true;
					btnGuardarSalir.Enabled = true;
					imagenPredeterminada = false;
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnQuitarImagen_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (!imagenPredeterminada)
				{
					pcbFoto.Image = Properties.Resources._default;
					Foto = null;
					imagenPredeterminada = true;
					btnGuardar.Enabled = true;
					btnGuardarSalir.Enabled = true;
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnPagoCouta_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
			{
				if (valoresPk.Count > 0)
				{
					if (Utilitario.BuscaForm("frmVisorRpt"))
					{
						DataTable dtRptCarteraGeneral = new DataTable();
						Listado listP = new Listado();
						listP.COLUMNAS = "*";
						listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
						listP.TABLA = "NV_INCORPORACION";
						listP.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";
						Cursor.Current = Cursors.WaitCursor;
						if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
						{
							if (dtRptCarteraGeneral.Rows.Count > 0)
							{

								frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "RPTPagoCouta.rpt", "Indicaciones para el Pago de Couta", Globales.NOMBRE_COMPAÑIA, new List<string>(), new List<string>());
								Cursor.Current = Cursors.Default;
								rptCG.ShowDialog();
							}
							else
							{
								error = "No hay información para generar el reporte.";
								MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
		}

		private void mtbVenciminetoTerjeta_KeyUp(object sender, KeyEventArgs e)
		{
			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void btnRPTFichaColegiado_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
			{
				if (valoresPk.Count > 0)
				{
					if (Utilitario.BuscaForm("frmVisorRpt"))
					{
						DataTable dtRptCarteraGeneral = new DataTable();
						Listado listP = new Listado();
						listP.COLUMNAS = "*";
						listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
						listP.TABLA = "NV_FICHA_DEL_COLEGIADO";
						listP.FILTRO = "where [Número Colegiado] = '" + txtNumeColegiado.Valor + "'";
						Cursor.Current = Cursors.WaitCursor;
						if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
						{
							if (dtRptCarteraGeneral.Rows.Count > 0)
							{

								frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Ficha del Colegiado Encabezado.rpt");
								Cursor.Current = Cursors.Default;
								rptCG.ShowDialog();
							}
							else
							{
								error = "No hay información para generar el reporte.";
								MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private bool ValidarFechaslaborales(DateTime dtpDesde, DateTime dtpHasta, ref string error)
		{
			foreach (DataGridViewRow row in dgvHistorialLaboral.Rows)
			{
				DateTime fechDesde = DateTime.Parse(row.Cells["colEmpresaDesde"].Value.ToString());
				DateTime fechHasta = DateTime.Parse(row.Cells["colEmpresaHasta"].Value.ToString());

				if ((dtpDesde.Date >= fechDesde.Date || dtpDesde.Date <= fechHasta.Date) && (dtpHasta.Date >= fechDesde.Date || dtpHasta.Date <= fechHasta.Date))
				{
					error = "Fecha insertada entre el rango";
					return false;
				}



				if ((fechDesde.Date >= dtpDesde.Date || fechDesde.Date <= dtpHasta.Date) && (fechHasta.Date <= dtpDesde.Date || fechHasta.Date <= dtpHasta.Date))
				{
					error = "Fecha insertada entre el rango mayor";
					return false;
				}

			}
			return true;
		}

		private void btnCambioCategoria_MouseClick(object sender, MouseEventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (Utilitario.BuscaForm("frmCambioCategoria"))
				{
					frmCambioCategoria frm = new frmCambioCategoria(txtIdColegiado.Valor, txtCategoria.Valor);
					frm.Show();
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void dgvEstablecimientos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if ((e.ColumnIndex == dgvEstablecimientos.Columns["colEstadoEst"].Index) && e.RowIndex != -1)
			{
				DataGridViewCell cell = dgvEstablecimientos.Rows[e.RowIndex].Cells[e.ColumnIndex];
				if (dgvEstablecimientos.CurrentCell.ReadOnly)
					cell.ToolTipText = "Deshabilitado por Estado del Establecimiento";
				else
					cell.ToolTipText = "";
			}
		}

		private void btnEliminarSilvestre_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_BORRAR))
			{
				if (dgvVidaSilvestre.RowCount > 0)
				{
					if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
								  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
					{
						string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
							".NV_COLEGIADO_SILVESTRE WHERE IdColegiado = '" + txtIdColegiado.Valor + "' AND CodigoSilvestre = '"
							+ dgvVidaSilvestre.CurrentCell.OwningRow.Cells["colCodigoSilvestre"].Value.ToString() + "'";

						if (Consultas.ejecutarSentencia(sQuery, ref error))
						{
							dgvVidaSilvestre.Rows.Remove(dgvVidaSilvestre.CurrentCell.OwningRow);
						}
						else
							MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnModificarAcademico_Click(object sender, EventArgs e)
		{
			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (dgvHistorialAcademico.RowCount > 0)
				{
					cargarCentro(dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colCodigoCentro"].Value.ToString());
					cargarTitulo(dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colCodigoTitulo"].Value.ToString());
					cargarOrientacion(dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colCodigoEnfasis"].Value.ToString());
					buscaPais(txtPaisTitulo.Valor = dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colCodigoPais"].Value.ToString(), "PT");
					if (!dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colFechaGradu"].Value.ToString().Equals(""))
						dtpFechaGradu.Value = DateTime.Parse(dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colFechaGradu"].Value.ToString());
					int indexItem = 0;
					int indexItemSelect = 0;
					foreach (var item in clbGrados.Items)
					{
						var row = (item as DataRowView).Row;
						if (row["CodigoGrado"].ToString() == dgvHistorialAcademico.CurrentCell.OwningRow.Cells["colCodigoGrado"].Value.ToString())
							indexItemSelect = indexItem;
						indexItem++;
					}
					clbGrados.SetItemChecked(indexItemSelect, true);

					dgvHistorialAcademico.Rows.Remove(dgvHistorialAcademico.CurrentCell.OwningRow);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

		}

		private void btnModificarlaboral_Click(object sender, EventArgs e)
		{

			if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
			{
				if (dgvHistorialLaboral.RowCount > 0)
				{
					//cargarPuesto(dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colCodigoPuesto"].Value.ToString());
					txtHistPuesto.Valor = dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colPuesto"].Value.ToString();
					txtHistEmpresa.Valor = dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colNombreEmpresa"].Value.ToString();
					txtHistTelEmpresa.Valor = dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colTelefono"].Value.ToString();
					txtCorreoLaboral.Valor = dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colCorreoEmpresa"].Value.ToString();
					rtbDireccionLaboral.Text = dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colDireccionEmpresa"].Value.ToString();
					if (!dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colEmpresaDesde"].Value.ToString().Equals(""))
						dtpEmpresaDesde.Value = DateTime.Parse(dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colEmpresaDesde"].Value.ToString());
					if (!dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colEmpresaHasta"].Value.ToString().Equals(""))
						dtpEmpresaHasta.Value = DateTime.Parse(dgvHistorialLaboral.CurrentCell.OwningRow.Cells["colEmpresaHasta"].Value.ToString());

					dgvHistorialLaboral.Rows.Remove(dgvHistorialLaboral.CurrentCell.OwningRow);
				}
			}
			else
				MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void dgvEstablecimientos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;

			if (dgvCombo != null)
			{
				//
				// se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
				// evitando asi que se ejecuten varias veces el evento
				//
				dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);

				dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
			}

		}

		private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = sender as ComboBox;

			DataGridViewRow row = dgvEstablecimientos.CurrentRow;

			//DataGridViewCheckBoxCell cell = row.Cells["Seleccionado"] as DataGridViewCheckBoxCell;
			//cell.Value = true;
			//if (combo.SelectedItem.Equals("Inactivo"))
			//    row.DefaultCellStyle.BackColor = Color.Red;
			//else
			//    row.DefaultCellStyle.BackColor = Color.White;
			if (row.Cells["colEstadoEst"].Value.ToString() != combo.SelectedItem.ToString())
			{
				if (MessageBox.Show("¿Desea realizar el cambio de Estado? Al continuar el proceso, se hará una insercion al historial de regencias", "Validación", MessageBoxButtons.YesNo,
						  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
				{
					if (combo.SelectedItem.Equals("Inactivo"))
						row.DefaultCellStyle.BackColor = Color.Red;
					else if (combo.SelectedItem.Equals("Sancionado"))
						row.DefaultCellStyle.BackColor = Color.Yellow;
					else
						row.DefaultCellStyle.BackColor = Color.White;

					//fInternas.insertarHistorialRegencias(txtIdColegiado.Valor, row.Cells["colCodigoEstablecimiento"].Value.ToString(), row.Cells["colCodigoCategoria"].Value.ToString(),
					//row.Cells["colEstadoEst"].Value.ToString(), row.Cells["colSesionApEst"].Value.ToString(),
					//row.Cells["colFechAproba"].Value.ToString(), ref error);
				}
				else
				{
					combo.SelectedItem = row.Cells["colEstadoEst"].Value;
				}

			}
		}

		private bool tieneSancion()
		{
			bool tiene = false;

			foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
			{
				if (row.Cells["colEstadoEst"].Value.ToString() == "Sancionado")
					tiene = true;
			}

			return tiene;
		}

		private void mtbTarjeta_KeyUp(object sender, KeyEventArgs e)
		{
			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void listaSilvestre()
		{
			Listado listP = new Listado();
			listP.COLUMNAS = "CodigoSilvestre as Código, NombreSilvestre as Nombre , DescripcionSilvestre as Descripción";
			listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
			listP.TABLA = "NV_VIDA_SILVESTRE";
			listP.ORDERBY = "order by CodigoSilvestre";
			listP.TITULO_LISTADO = "Vida Silvestre";

			frmF1 f1Colegiado = new frmF1(listP);
			f1Colegiado.ShowDialog();

			if (f1Colegiado.item != null)
			{

				dgvVidaSilvestreR.CurrentCell.Value = f1Colegiado.item.SubItems[0].Text;
				dgvVidaSilvestreR.CurrentCell.OwningRow.Cells["colNombreSilvestreR"].Value = f1Colegiado.item.SubItems[1].Text;
				dgvVidaSilvestreR.CurrentCell.OwningRow.Cells["colDescripcionSilvestreR"].Value = f1Colegiado.item.SubItems[2].Text;
				dgvVidaSilvestreR.EndEdit();
				btnGuardar.Enabled = true;
				btnGuardarSalir.Enabled = true;
			}
		}

		private void habilitarSilvestre()
		{
			gbVidaSilvestreR.Visible = true;
		}

		private void deshabilitarSilvestre()
		{
			gbVidaSilvestreR.Visible = false;
		}

		private void limpiarSilvestre()
		{
			dgvVidaSilvestreR.Rows.Clear();
		}

		private void btnAgregarSilvestre_Click(object sender, EventArgs e)
		{
			dgvVidaSilvestreR.Rows.Add("", "", "");
		}

		private void btnEliminaSilvestre_Click(object sender, EventArgs e)
		{
			dgvVidaSilvestreR.Rows.Remove(dgvVidaSilvestreR.CurrentRow);
			btnGuardar.Enabled = true;
			btnGuardarSalir.Enabled = true;
		}

		private void mtbVenciminetoTerjeta_Leave(object sender, EventArgs e)
		{
			if (mtbVenciminetoTerjeta.MaskFull)
			{
				DateTime refDate = DateTime.Now;
				if (!IsCreditCardInfoValid(mtbVenciminetoTerjeta.Text, ref refDate))
				{
					mtbVenciminetoTerjeta.Clear();
					MessageBox.Show("Fecha de vencimiento invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private bool IsCreditCardInfoValid(/*string cardNo, */string expiryDate/*, string cvv*/, ref DateTime cardExpiry)
		{
			//var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
			var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");//Permite primer digito 0 o 1 y el segundo con 0 y 1 al 9 o 1 con 1 al 2 
			var yearCheck = new Regex(@"^20[0-9]{2}$");//Empieza con 20 y permite 2 digitos mas del 0-9
													   //var cvvCheck = new Regex(@"^\d{3}$");

			//if (!cardCheck.IsMatch(cardNo)) // <1>check card number is valid
			//	return false;
			//if (!cvvCheck.IsMatch(cvv)) // <2>check cvv is valid as "999"
			//	return false;

			var dateParts = expiryDate.Split('/'); //expiry date in from MM/yyyy            
			if (!monthCheck.IsMatch(dateParts[0]) || !yearCheck.IsMatch(dateParts[1])) // <3 - 6>
				return false; // ^ check date format is valid as "MM/yyyy"

			var year = int.Parse(dateParts[1]);
			var month = int.Parse(dateParts[0]);
			var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
			/*var*/
			cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

			//check expiry greater than today & within next 6 years <7, 8>>
			return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
		}

		private void dgvVidaSilvestreR_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvVidaSilvestreR.CurrentRow != null)
				if ((dgvVidaSilvestreR.CurrentCell.OwningColumn.Name == "colCodigoSilvestreR"))
				{
					listaSilvestre();
				}
		}

        private void btnSuspension_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.COLEGIADOS_EDITAR))
            {
                if (Utilitario.BuscaForm("frmSuspension"))
                {
                    frmSuspension frm = new frmSuspension(txtIdColegiado.Valor, Usu);
                    frm.ShowDialog();
					cargarSuspensiones();

                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void cargarSuspensiones()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "IdRegsitro, IdColegiado, TipoSuspension, NumeroResolucion, FechaInicio, FechaFinal, UsuarioCreacionAdmin, FechaCreacionAdmin";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_COLEGIADO_SUSPENSIONES";
            listA.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    dgvSuspensiones.Rows.Clear();
                    foreach (DataRow r in dt.Rows)
                    {
                        dgvSuspensiones.Rows.Add(
							r["TipoSuspension"].ToString(), 
							r["NumeroResolucion"].ToString(), 
							DateTime.Parse(r["FechaInicio"].ToString()).ToString("dd/MM/yyyy"), 
							DateTime.Parse(r["FechaFinal"].ToString()).ToString("dd/MM/yyyy"), 
							r["UsuarioCreacionAdmin"].ToString(), 
							DateTime.Parse(r["FechaCreacionAdmin"].ToString()).ToString("dd/MM/yyyy"));
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool VerificaEstadoRegenciasVrsCategorias(ref string error)
        {
            error = "";
            bool lbOk = true;

            foreach (DataGridViewRow row in dgvEstablecimientos.Rows)
            {
                if (row.Cells["colEstadoEst"].Value.ToString()[0].ToString() == "A")
                {
                    if (!ExisteCategoriaActiva(row.Cells["colCodigoCategoria"].Value.ToString(), row.Cells["colCodigoEstablecimiento"].Value.ToString()))
                    {
                        if (MessageBox.Show($"La categoria {row.Cells["colCategoria"].Value.ToString()} para el establecimiento {row.Cells["colCodigoEstablecimiento"].Value.ToString()} {row.Cells["colNombreEstablecimiento"].Value.ToString()} se encuentra INACTIVA.¿Desea activar el Estado de la Categoría para el establecimiento?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            lbOk = ActivaCategoriaRegenciaEstablecimento(row.Cells["colCodigoEstablecimiento"].Value.ToString(),
                                                                         row.Cells["colCodigoCategoria"].Value.ToString(),
                                                                         row.Cells["colCategoria"].Value.ToString(),
                                                                         ref error);
                        }
                        else
                        {
                            error = $"Mientras la categoria  {row.Cells["colCategoria"].Value.ToString()} se encuentre INACTIVA no se podrá realizar el cambio de estado para el establecimiento {row.Cells["colCodigoEstablecimiento"].Value.ToString()} {row.Cells["colNombreEstablecimiento"].Value.ToString()}.";
                            lbOk = false;
                            return lbOk;
                        }


                    }
                }
            }
            return lbOk;
        }

        private bool ExisteCategoriaActiva(string categoria, string establecimiento)
        {
            DataTable dtCatEst = new DataTable();
            string sSelectCl = $"select * from {Consultas.sqlCon.COMPAÑIA}.NV_ESTABLECIMIENTOS_CATEGORIAS where CodigoCategoria = '{categoria}' and NumRegistroEstablecimiento='{establecimiento}' and Estado='A'";

            var lbOk = Consultas.fillDataTable(sSelectCl, ref dtCatEst, ref error);

            if (lbOk && dtCatEst.Rows.Count > 0)
                return true;

            return false;
        }

        private bool ActivaCategoriaRegenciaEstablecimento(string establecimiento, string categoria, string nombreCategoria, ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumRegistroEstablecimiento,CodigoCategoria,NombreCategoria,Estado";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
            bool lbOk = true;
            try
            {
                parametros.Clear();
                list.COLUMNAS_PK.Clear();
                list.COLUMNAS_PK.Add("NumRegistroEstablecimiento");
                list.COLUMNAS_PK.Add("CodigoCategoria");
                parametros.Add(establecimiento);
                parametros.Add(categoria);
                parametros.Add(nombreCategoria);
                parametros.Add("A");
                parametros.Add(establecimiento);
                list.FILTRO = " WHERE NumRegistroEstablecimiento='" + establecimiento + "' AND CodigoCategoria='" + categoria + "'";

                lbOk = Consultas.actualizar(parametros, list, identificadorFormulario, ref error);

            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }


    }
}
