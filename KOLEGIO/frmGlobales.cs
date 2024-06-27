using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class frmGlobales : Form
    {
        protected string error = "";
        private string oldValue = "";
        private frmMenu menu;

        public frmGlobales()
        {
            this.menu = new frmMenu(Consultas.Usuario);
            InitializeComponent();
            cargarGlobales();
            
        }

        private void cargarGlobales()
        {
            txtCompannia.Valor = Globales.NOMBRE_COMPAÑIA;
            txtCorreosEnvio.Valor = Globales.CORREO_CONTROL;
            txtCorreosSoporte.Valor = Globales.CORREO_COPIA_SOPORTE;
            txtRutaAdjuntos.Valor = Globales.RUTA_ALMACENAMIENTO_ADJUNTOS;

            if (Globales.PERMITIR_CREDITO == "S")
                chkPermitirCredito.Checked = true;
            if (Globales.FONDO_MUTUALIDAD == "S")
                chkFondoMutualidad.Checked = true;
            if (Globales.TITULO_OBLIGATORIO == "S")
                chkTituloObligatorio.Checked = true;
            if (Globales.PERMITIR_PERITO == "S")
            {
                chkPermitirPerito.Checked = true;
                txtCondPagoCanonesAnuales.ReadOnly = false;
                txtArtPeritajes.ReadOnly = false;
            }
                

            if (Globales.MANEJO_BENEFICIARIOS == "S")
                chkManejoBeneficiarios.Checked = true;
            if (Globales.MANEJO_ESPECIALIDADES == "S")
                chkManejoEspecialidades.Checked = true;
            if (Globales.MANEJO_PLAGUICIDAS == "S")
            {
                chkManejoPlaguicidas.Checked = true;
                txtArtPlaguicidas.ReadOnly = false;
            }

            if (Globales.MANEJO_VIA_AEREA == "S")
            {
                chkManejoViaAerea.Checked = true;
                txtArtViaAerea.ReadOnly = false;
            }

            if (Globales.MANEJO_VIDA_SILVESTRE == "S")
            {
                chkManejoSilvestre.Checked = true;
                txtArtSilvestre.ReadOnly = false;
            }

            if (Globales.MANEJO_REGENCIAS == "S")
            {
                chkManejoRegencias.Checked = true;
                txtCondPagoRegencia.ReadOnly = false;
            }

            if (Globales.MANEJO_GENE_ARCHIVO_CELULARES == "S")
                chkGenArchivoCel.Checked = true;


            txtServidorSMTP.Valor = Globales.SERVIDOR_SMTP;
            txtPuertoSalida.Valor = Globales.PUERTO_SALIDA_SMTP;
            if (Globales.HABILITAR_SSL == "S")
                chkSSL.Checked = true;
            else
                chkSSL.Checked = false;

            if (Globales.CONSECUTIVO_PEDIDO != "")
                cargarConsecutivoFA(Globales.CONSECUTIVO_PEDIDO,"P");

            if (Globales.CONSECUTIVO_FACTURA != "")
                cargarConsecutivoFA(Globales.CONSECUTIVO_FACTURA,"F");

            if (Globales.CONSECUTIVO_COLEGIADO != "")
                cargarConsecutivo(Globales.CONSECUTIVO_COLEGIADO,"C");

            if (Globales.CONSECUTIVO_ESTABLECIMIENTO != "")
                cargarConsecutivo(Globales.CONSECUTIVO_ESTABLECIMIENTO, "E");

            if (Globales.CONSECUTIVO_ADELANTOS != "")
                cargarConsecutivo(Globales.CONSECUTIVO_ADELANTOS, "A");

            if (Globales.CONSECUTIVO_RECIBOS != "")
                cargarConsecutivo(Globales.CONSECUTIVO_RECIBOS, "R");

            if (Globales.CONDICION_PAGO_COLEGIATURAS != "")
                cargarCondPago(Globales.CONDICION_PAGO_COLEGIATURAS, "C");

            if (Globales.CONDICION_PAGO_REGENCIAS != "")
                cargarCondPago(Globales.CONDICION_PAGO_REGENCIAS, "R");

            if (Globales.CONDICION_PAGO_CANONES_ANUALES != "")
                cargarCondPago(Globales.CONDICION_PAGO_CANONES_ANUALES, "C_A");

            if (Globales.CONDICION_PAGO_ADELANTOS != "")
                cargarCondPago(Globales.CONDICION_PAGO_ADELANTOS, "ADEL");

            if (Globales.ARTICULO_COBRO_PERITAJES != "")
                cargarArtCobro(Globales.ARTICULO_COBRO_PERITAJES, "PER");

            if (Globales.ARTICULO_COBRO_PLAGUICIDAS != "")
                cargarArtCobro(Globales.ARTICULO_COBRO_PLAGUICIDAS, "PLAGUI");

            if (Globales.ARTICULO_COBRO_VIA_AEREA != "")
                cargarArtCobro(Globales.ARTICULO_COBRO_VIA_AEREA, "AEREA");

            if (Globales.ARTICULO_COBRO_SILVESTRE != "")
                cargarArtCobro(Globales.ARTICULO_COBRO_SILVESTRE, "SILVESTRE");

            if (Globales.ARTICULO_COBRO_CONSULTORAS != "")
                cargarArtCobro(Globales.ARTICULO_COBRO_CONSULTORAS, "CONSUL");

            if (Globales.CATEGORIA_CLIENTE_ESTABLE != "")
                cargarCategoriaCli(Globales.CATEGORIA_CLIENTE_ESTABLE, "Estable");

            if (Globales.CATEGORIA_CLIENTE_CONSUL!= "")
                cargarCategoriaCli(Globales.CATEGORIA_CLIENTE_CONSUL, "Consul");

            if (Globales.BODEGA_PEDIDOS != "")
                cargarBodega(Globales.BODEGA_PEDIDOS);


            if (Globales.SUBTIPO_CUENTA_CONECTIVIDAD != "")
                cargarSubTipo(Globales.SUBTIPO_CUENTA_CONECTIVIDAD);

        }

        private void txtDiasVigencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            
            if (validarGlobales(ref error))
            {
                string sentencia = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES set " +
               "NombreCompañia = '" + txtCompannia.Valor + "'";

                if (!txtPedido.Valor.Trim().Equals(""))
                    sentencia += ",ConsecutivoPedido = '" + txtPedido.Valor + "'";
                else
                    sentencia += ",ConsecutivoPedido = null";

                if (!txtFactura.Valor.Trim().Equals(""))
                    sentencia += ",ConsecutivoFacturas = '" + txtFactura.Valor + "'";
                else
                    sentencia += ",ConsecutivoFacturas = null";

                /*if (!txtColegiado.Valor.Trim().Equals(""))
                    sentencia += ",ConsecutivoColegiado = '" + txtColegiado.Valor + "'";
                else
                    sentencia += ",ConsecutivoColegiado = null";*/

                if (!txtConsecutivoEst.Valor.Trim().Equals(""))
                    sentencia += ",ConsecutivoEstablecimiento = '" + txtConsecutivoEst.Valor + "'";
                else
                    sentencia += ",ConsecutivoEstablecimiento = null";

                if (!txtConsecutivoAde.Valor.Trim().Equals(""))
                    sentencia += ",ConsecutivoAdelantos = '" + txtConsecutivoAde.Valor + "'";
                else
                    sentencia += ",ConsecutivoAdelantos = null";

                if (!txtConsRecibos.Valor.Trim().Equals(""))
                    sentencia += ",ConsecutivoRecibos = '" + txtConsRecibos.Valor + "'";
                else
                    sentencia += ",ConsecutivoRecibos = null";

                if (!txtCondPagoColegiaturas.Valor.Trim().Equals(""))
                    sentencia += ",CondPagoColegiaturas = '" + txtCondPagoColegiaturas.Valor + "'";
                else
                    sentencia += ",CondPagoColegiaturas = null";

                if (!txtCondPagoRegencia.Valor.Trim().Equals(""))
                    sentencia += ",CondPagoRegencias = '" + txtCondPagoRegencia.Valor + "'";
                else
                    sentencia += ",CondPagoRegencias = null";

                if (!txtCondPagoCanonesAnuales.Valor.Trim().Equals(""))
                    sentencia += ",CondPagoCanonesAnuales = '" + txtCondPagoCanonesAnuales.Valor + "'";
                else
                    sentencia += ",CondPagoCanonesAnuales = null";

                if (!txtCondPagoAdelantos.Valor.Trim().Equals(""))
                    sentencia += ",CondPagoAdelantos = '" + txtCondPagoAdelantos.Valor + "'";
                else
                    sentencia += ",CondPagoAdelantos = null";

                if (!txtArtPeritajes.Valor.Trim().Equals("") && chkPermitirPerito.Checked)
                    sentencia += ",CodArtCobroPeritajes = '" + txtArtPeritajes.Valor + "'";
                else
                    sentencia += ",CodArtCobroPeritajes = null";

                if (!txtArtPlaguicidas.Valor.Trim().Equals("") && chkManejoPlaguicidas.Checked)
                    sentencia += ",CodArtCobroPlaguicidas = '" + txtArtPlaguicidas.Valor + "'";
                else
                    sentencia += ",CodArtCobroPlaguicidas = null";

                if (!txtArtViaAerea.Valor.Trim().Equals("") && chkManejoViaAerea.Checked)
                    sentencia += ",CodArtCobroViaAerea= '" + txtArtViaAerea.Valor + "'";
                else
                    sentencia += ",CodArtCobroViaAerea = null";

                if (!txtArtSilvestre.Valor.Trim().Equals("") && chkManejoSilvestre.Checked)
                    sentencia += ",CodArtCobroSilvestre= '" + txtArtSilvestre.Valor + "'";
                else
                    sentencia += ",CodArtCobroSilvestre = null";

                if (!txtArtConsultoras.Valor.Trim().Equals(""))
                    sentencia += ",CodArtCobroConsultoras= '" + txtArtConsultoras.Valor + "'";
                else
                    sentencia += ",CodArtCobroConsultoras = null";

                if (!txtCatEstables.Valor.Trim().Equals(""))
                    sentencia += ",CategoriaEstable= '" + txtCatEstables.Valor + "'";
                else
                    sentencia += ",CategoriaEstable = null";

                if (!txtCatConsul.Valor.Trim().Equals(""))
                    sentencia += ",CategoriaConsul= '" + txtCatConsul.Valor + "'";
                else
                    sentencia += ",CategoriaConsul = null";

                if (!txtBodega.Valor.Trim().Equals(""))
                    sentencia += ",BodegaPedidos= '" + txtBodega.Valor + "'";
                else
                    sentencia += ",BodegaPedidos = null";

                if (chkPermitirCredito.Checked)
                    sentencia += ",PermitirCredito = 'S'";
                else
                    sentencia += ",PermitirCredito = 'N'";

                if (chkPermitirPerito.Checked)
                    sentencia += ",PermitirPerito = 'S'";
                else
                    sentencia += ",PermitirPerito = 'N'";

                if (chkManejoViaAerea.Checked)
                    sentencia += ",ManejoViaAerea = 'S'";
                else
                    sentencia += ",ManejoViaAerea = 'N'";

                if (chkFondoMutualidad.Checked)
                    sentencia += ",FondoMutualidad = 'S'";
                else
                    sentencia += ",FondoMutualidad = 'N'";

                if (chkTituloObligatorio.Checked)
                    sentencia += ",TituloObligatorio = 'S'";
                else
                    sentencia += ",TituloObligatorio = 'N'";

                if (chkManejoBeneficiarios.Checked)
                    sentencia += ",ManejoBeneficiarios = 'S'";
                else
                    sentencia += ",ManejoBeneficiarios = 'N'";

                if (chkManejoEspecialidades.Checked)
                    sentencia += ",ManejoEspecialidades = 'S'";
                else
                    sentencia += ",ManejoEspecialidades = 'N'";

                if (chkManejoPlaguicidas.Checked)
                    sentencia += ",ManejoPlaguicidas = 'S'";
                else
                    sentencia += ",ManejoPlaguicidas = 'N'";

                if (chkManejoSilvestre.Checked)
                    sentencia += ",ManejoVidaSilvestre = 'S'";
                else
                    sentencia += ",ManejoVidaSilvestre = 'N'";

                if (chkManejoRegencias.Checked)
                    sentencia += ",ManejoRegencias = 'S'";
                else
                    sentencia += ",ManejoRegencias = 'N'";

                if (chkGenArchivoCel.Checked)
                    sentencia += ",ManejoGenArchivoCel = 'S'";
                else
                    sentencia += ",ManejoGenArchivoCel = 'N'";

                if (!txtSubTipoDoc.Valor.Trim().Equals(""))
                    sentencia += ",SubtipoCuentaConectivdad = '" + txtSubTipoDoc.Valor + "'";
                else
                    sentencia += ",SubtipoCuentaConectivdad = null";

                sentencia += ",ServidorSMTP = '" + txtServidorSMTP.Valor + "'";
                sentencia += ",CorreoControl = '" + txtCorreosEnvio.Valor + "'";
                sentencia += ",CorreoCopiaSoporte = '" + txtCorreosSoporte.Valor + "'";

                int puerto = -1;
                if (int.TryParse(txtPuertoSalida.Valor, out puerto) && txtPuertoSalida.Valor != "")
                    sentencia += ",PuertoSalidaSMTP = '" + txtPuertoSalida.Valor + "'";
                else
                {
                    MessageBox.Show("El puerto SMTP debe ser un valor númerico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string rutaAdjs = txtRutaAdjuntos.Valor;
                if (rutaAdjs != "")
                {
                    if (rutaAdjs[rutaAdjs.Length - 1].ToString().Equals(@"\"))
                    {
                        sentencia += ",RutaAlmacenamientoAdjuntos = '" + txtRutaAdjuntos.Valor + "'";
                    }
                    else
                    {
                        sentencia += ",RutaAlmacenamientoAdjuntos = '" + txtRutaAdjuntos.Valor + @"\'";
                    }
                }
                int i = 1;


                if (chkSSL.Checked)
                    sentencia += ",HabilitarSSL='S'";
                else
                    sentencia += ",HabilitarSSL='N'";

                if (Consultas.ejecutarSentencia(sentencia, ref error))
                {
                    if (Globales.cargarGlobales(ref error))
                    {
                        
                        //if (Globales.MANEJO_PLAGUICIDAS.Equals("S") || Globales.MANEJO_VIA_AEREA.Equals("S") || Globales.PERMITIR_PERITO.Equals("S"))
                        //    menu.btnProcesoCobrosAnuales.Visible = true;
                        //else
                        //    menu.btnProcesoCobrosAnuales.Visible = false;

                        this.Close();
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarGlobales(ref string error)
        {
            bool OK = true;

            if (chkPermitirPerito.Checked && txtArtPeritajes.Valor.Trim().Equals(""))
            {
                error = "Debe definir un artículo de cobro para peritajes.";
                txtArtPeritajes.Focus();
                OK = false;
            }

            if (chkManejoPlaguicidas.Checked && txtArtPlaguicidas.Valor.Trim().Equals(""))
            {
                error = "Debe definir un artículo de cobro para plaguicidas.";
                txtArtPlaguicidas.Focus();
                OK = false;
            }

            if (chkManejoViaAerea.Checked && txtArtViaAerea.Valor.Trim().Equals(""))
            {
                error = "Debe definir un artículo de cobro para vía aérea.";
                txtArtViaAerea.Focus();
                OK = false;
            }

            if (chkManejoSilvestre.Checked && txtArtSilvestre.Valor.Trim().Equals(""))
            {
                error = "Debe definir un artículo de cobro para vida silvestre.";
                txtArtSilvestre.Focus();
                OK = false;
            }

            if (txtArtConsultoras.Valor.Trim().Equals(""))
            {
                error = "Debe definir un artículo de cobro para las consultoras.";
                txtArtConsultoras.Focus();
                OK = false;
            }

            if (txtCatConsul.Valor.Trim().Equals(""))
            {
                error = "Debe definir la categoria cliente para las consultoras.";
                txtCatConsul.Focus();
                OK = false;
            }

            if (txtCatEstables.Valor.Trim().Equals(""))
            {
                error = "Debe definir la categoria cliente para los establecimientos.";
                txtCatEstables.Focus();
                OK = false;
            }

            if (txtBodega.Valor.Trim().Equals(""))
            {
                error = "Debe definir la bodega para la generacion de pedidos.";
                txtBodega.Focus();
                OK = false;
            }


            if (txtSubTipoDoc.Valor.Trim().Equals(""))
            {
                error = "Debe definir el subtipo de cuenta contable para conectividad en linea.";
                txtSubTipoDoc.Focus();
                OK = false;
            }

            return OK;
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int puerto = -1;
            string error = "";
            Mail.smtpHostServer = txtServidorSMTP.Valor;
            if (int.TryParse(txtPuertoSalida.Valor, out puerto))
                Mail.port = puerto;
            else
            {
                MessageBox.Show("El valor del puerto SMTP debe ser númerico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuertoSalida.Focus();
                return;
            }
            if (chkSSL.Checked)
                Mail.isSslEnable = true;
            else
                Mail.isSslEnable = false;
            Mail.mailFrom = txtEmailFrom.Text.Replace(";", ",");
            Mail.mailTo = txtEmailTo.Text.Replace(";", ",");
            Mail.mailSubject = "Correo Prueba KOLEGIO8";
            Mail.mailBody = "Esto es un correo de prueba";
            Mail.IsHtmlFormat = false;
            //if (chkUsuarioCredencial.Checked)
            //    Mail.credentialUserName = txtEmailFrom.Text.Split('@')[0];
            //else
            Mail.credentialUserName = txtEmailFrom.Text;
            Mail.credentialUserPassword = txtPassEmail.Text;

            if (Mail.SendMail(ref error))
                MessageBox.Show("Correo de prueba envíado con éxito.", "Test de Correo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("Fallo el envío del correo.\n" + error, "Test de Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Mail.limpiar();
            Cursor.Current = Cursors.Default;
        }

        private async void btnEnviarSMS_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //SMS.cola = txtColaSMS.Valor;
            //SMS.ipSMS = txtipSMS.Valor;
            //SMS.prioridad = "2";
            //SMS.mensaje = "Mensaje de texto prueba KOLEGIO8";
            //SMS.toNumber = txtCelPrueba.Text;

            //if (SMS.ipSMS.Trim() == "")
            //{
            //    MessageBox.Show("Debe definir la ip de configuración de SMS.", "Test SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //try
            //{

            //    if (SMS.cola != "")
            //    {
            //        bool result = await SMS.SendSMS2();
            //        if (result)
            //        {
            //            MessageBox.Show("Mensaje de prueba enviado con éxito.", "Test SMS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //            SMS.limpiar();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error enviando el sms.", "Test SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            error = "";
            //        }
            //    }
            //    else
            //    {
            //        SMS.prioridad = "1";
            //        if (SMS.SendSMS1(ref error))
            //        {
            //            MessageBox.Show("Mensaje de prueba enviado con éxito.", "Test SMS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        }
            //        else
            //        {
            //            MessageBox.Show(error, "Test SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            error = "";
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Test SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //        Cursor.Current = Cursors.Default;
        }

        private void frmGlobales_Load(object sender, EventArgs e)
        {
            txtCompannia.Longitud = 50;
            txtCorreosEnvio.Longitud = 512;
            txtCorreosSoporte.Longitud = 512;
            txtRutaAdjuntos.Longitud = 1024;
            txtCondPagoColegiaturas.Longitud = 4;
            txtCondPagoRegencia.Longitud = 4;
            txtCondPagoCanonesAnuales.Longitud = 4;

            txtServidorSMTP.Longitud = 50;
            txtPuertoSalida.Right();
            txtPedido.Mayusculas();
            txtFactura.Mayusculas();
            // txtipSMS.Longitud = 150;
            //txtColaSMS.Longitud = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //SmtpClient sMail = new SmtpClient(txtServidorSMTP.Valor);//exchange or smtp server goes here.
                //sMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                //sMail.UseDefaultCredentials = true;
                //sMail.Credentials = new NetworkCredential(txtEmailFrom.Text, txtPassEmail.Text,"redbridge");//this line most likely wont be needed if you are already an         authenticated user.
                //sMail.Send(txtEmailFrom.Text, txtEmailTo.Text, "Prueba", "Correo de Prueba");

                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential("cobros", txtPassEmail.Text, "redbridge");
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(txtEmailFrom.Text);

                // setup up the host, increase the timeout to 5 minutes
                smtpClient.Host = txtServidorSMTP.Valor;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.Timeout = (60 * 5 * 1000);
                smtpClient.Port = int.Parse(txtPuertoSalida.Valor);
                message.From = fromAddress;
                message.Subject = "Prueba - " + DateTime.Now.Date.ToString().Split(' ')[0];
                message.IsBodyHtml = true;
                message.Body = "Correo de Prueba";
                message.To.Add(txtEmailTo.Text);

                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo el envío del correo.\n" + ex.Message + "\n Inner: " + ex.InnerException + " HResult:" + ex.HResult, "Test de Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listaBodegas()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "BODEGA as Bodega,NOMBRE as Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "BODEGA";
            listP.ORDERBY = "order by BODEGA";
            listP.TITULO_LISTADO = "Bodegas";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                txtBodega.Valor = f1.item.SubItems[0].Text;
                txtBodegaDesc.Valor = f1.item.SubItems[1].Text;
            }
        }

        private void listaConsecutivosFA(string tipo)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CODIGO_CONSECUTIVO as Consecutivo,DESCRIPCION as Descripción";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CONSECUTIVO_FA";
            listP.ORDERBY = "order by CODIGO_CONSECUTIVO";
            listP.TITULO_LISTADO = "Consecutivos FA";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                if (tipo.Equals("P"))
                {
                    txtPedido.Valor = f1.item.SubItems[0].Text;
                    txtPedidoN.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo.Equals("F"))
                {
                    txtFactura.Valor = f1.item.SubItems[0].Text;
                    txtFacturaN.Valor = f1.item.SubItems[1].Text;
                }
            }
        }

        private void cargarConsecutivoFA(string cons, string tipo)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "CONSECUTIVO_FA";
            listA.FILTRO = "where CODIGO_CONSECUTIVO = '" + cons + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (tipo.Equals("P"))
                    {
                        txtPedido.Valor = dtTTs.Rows[0]["CODIGO_CONSECUTIVO"].ToString();
                        txtPedidoN.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }else if (tipo.Equals("F"))
                    {
                        txtFactura.Valor = dtTTs.Rows[0]["CODIGO_CONSECUTIVO"].ToString();
                        txtFacturaN.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    limpiarConsecutivoFA(tipo);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarConsecutivoFA(string tipo)
        {
            if (tipo.Equals("P"))
            {
                txtPedido.Clear();
                txtPedidoN.Clear();
            }
            else if (tipo.Equals("F"))
            {
                txtFactura.Clear();
                txtFacturaN.Clear();
            }
        }

        private void listaConsecutivos(string tipo)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CONSECUTIVO as Consecutivo,DESCRIPCION as Descripción";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CONSECUTIVO";
            listP.ORDERBY = "order by CONSECUTIVO";
            listP.TITULO_LISTADO = "Consecutivos";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                //if (tipo == "C")
                //{
                  //  txtColegiado.Valor = f1.item.SubItems[0].Text;
                    //txtColegiadoN.Valor = f1.item.SubItems[1].Text;
                //}
                //else 
                if(tipo=="E")
                {
                    txtConsecutivoEst.Valor= f1.item.SubItems[0].Text;
                    txtConsecutivoEstNombre.Valor= f1.item.SubItems[1].Text;
                }
                else if (tipo == "A")
                {
                    txtConsecutivoAde.Valor = f1.item.SubItems[0].Text;
                    txtDescConsecutivoAde.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "R")
                {
                    txtConsRecibos.Valor = f1.item.SubItems[0].Text;
                    txtDescConsRecibos.Valor = f1.item.SubItems[1].Text;
                }
            }
        }

        private void cargarConsecutivo(string cons,string tipo)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "CONSECUTIVO";
            listA.FILTRO = "where CONSECUTIVO = '" + cons + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (tipo == "C")
                    {
                       //txtColegiado.Valor = dtTTs.Rows[0]["CONSECUTIVO"].ToString();
                        //txtColegiadoN.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else
                    if(tipo=="E")
                    {
                        txtConsecutivoEst.Valor = dtTTs.Rows[0]["CONSECUTIVO"].ToString();
                        txtConsecutivoEstNombre.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else
                    if (tipo == "A")
                    {
                    txtConsecutivoAde.Valor= dtTTs.Rows[0]["CONSECUTIVO"].ToString();
                    txtDescConsecutivoAde.Valor= dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else
                    if (tipo == "R")
                    {
                        txtConsRecibos.Valor = dtTTs.Rows[0]["CONSECUTIVO"].ToString();
                        txtDescConsRecibos.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    limpiarConsecutivo(tipo);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarConsecutivo(string tipo)
        {
            if (tipo == "C")
            {
              //  txtColegiado.Clear();
                //txtColegiadoN.Clear();
            }
            else if(tipo=="E")
            {
                txtConsecutivoEst.Clear();
                txtConsecutivoEstNombre.Clear();
            }
            else
            if (tipo == "A")
            {
                txtDescConsecutivoAde.Clear();
                txtConsecutivoAde.Clear();
            }
            else
            if (tipo == "R")
            {
                txtConsRecibos.Clear();
                txtDescConsRecibos.Clear();
            }
        }

        private void listaCondPago(string tipo)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CONDICION_PAGO, DESCRIPCION";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CONDICION_PAGO";
            listP.ORDERBY = "order by CONDICION_PAGO";
            listP.TITULO_LISTADO = "Condiciones de Pago";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                
                if (tipo == "C")
                {
                    txtCondPagoColegiaturas.Valor = f1.item.SubItems[0].Text;
                    txtDescCondPagoColegiaturas.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "R")
                {
                    txtCondPagoRegencia.Valor = f1.item.SubItems[0].Text;
                    txtDescCondPagoRegencia.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "C_A")
                {
                    txtCondPagoCanonesAnuales.Valor = f1.item.SubItems[0].Text;
                    txtDescCondPagoCanonesAnuales.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "ADEL")
                {
                    txtCondPagoAdelantos.Valor = f1.item.SubItems[0].Text;
                    txtDescCondPagoAdelantos.Valor = f1.item.SubItems[1].Text;
                }
            }
        }

        private void listaArtCobro(string tipo)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "ARTICULO, DESCRIPCION";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "ARTICULO";
            listP.FILTRO = "where ARTICULO like 'KOL%'";
            listP.ORDERBY = "order by ARTICULO";
            listP.TITULO_LISTADO = "Artículos";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {

                if (tipo == "PER")
                {
                    txtArtPeritajes.Valor = f1.item.SubItems[0].Text;
                    txtDescArtPeritajes.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "PLAGUI")
                {
                    txtArtPlaguicidas.Valor = f1.item.SubItems[0].Text;
                    txtDescArtPlaguicidas.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "AEREA")
                {
                    txtArtViaAerea.Valor = f1.item.SubItems[0].Text;
                    txtDescArtViaAerea.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "CONSUL")
                {
                    txtArtConsultoras.Valor = f1.item.SubItems[0].Text;
                    txtDescArtConsultoras.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "SILVESTRE")
                {
                    txtArtSilvestre.Valor = f1.item.SubItems[0].Text;
                    txtArtDescSilvestre.Valor = f1.item.SubItems[1].Text;
                }
            }
        }

        private void listaCategoriaCli(string tipo)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CATEGORIA_CLIENTE, DESCRIPCION";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CATEGORIA_CLIENTE";
            //listP.FILTRO = "where CATEGORIA_CLIENTE like 'KOL%'";
            //listP.ORDERBY = "order by ARTICULO";
            listP.TITULO_LISTADO = "Categorias";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {

                if (tipo == "Estable")
                {
                    txtCatEstables.Valor = f1.item.SubItems[0].Text;
                    txtCatEstablesDescrip.Valor = f1.item.SubItems[1].Text;
                }
                else if (tipo == "Consul")
                {
                    txtCatConsul.Valor = f1.item.SubItems[0].Text;
                    txtCatConsulDescrip.Valor = f1.item.SubItems[1].Text;
                }
            }
        }

        private void cargarCondPago(string cond, string tipo)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "CONDICION_PAGO";
            listA.FILTRO = "where CONDICION_PAGO = '" + cond + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (tipo == "C")
                    {
                        txtCondPagoColegiaturas.Valor = dtTTs.Rows[0]["CONDICION_PAGO"].ToString();
                        txtDescCondPagoColegiaturas.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "R")
                    {
                        txtCondPagoRegencia.Valor = dtTTs.Rows[0]["CONDICION_PAGO"].ToString();
                        txtDescCondPagoRegencia.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "C_A")
                    {
                        txtCondPagoCanonesAnuales.Valor = dtTTs.Rows[0]["CONDICION_PAGO"].ToString();
                        txtDescCondPagoCanonesAnuales.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "ADEL")
                    {
                        txtCondPagoAdelantos.Valor = dtTTs.Rows[0]["CONDICION_PAGO"].ToString();
                        txtDescCondPagoAdelantos.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    limpiarCondPago(tipo);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarArtCobro(string art, string tipo)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "ARTICULO";
            listA.FILTRO = "where ARTICULO = '" + art + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (tipo == "PER")
                    {
                        txtArtPeritajes.Valor = dtTTs.Rows[0]["ARTICULO"].ToString();
                        txtDescArtPeritajes.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "PLAGUI")
                    {
                        txtArtPlaguicidas.Valor = dtTTs.Rows[0]["ARTICULO"].ToString();
                        txtDescArtPlaguicidas.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "AEREA")
                    {
                        txtArtViaAerea.Valor = dtTTs.Rows[0]["ARTICULO"].ToString();
                        txtDescArtViaAerea.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "CONSUL")
                    {
                        txtArtConsultoras.Valor = dtTTs.Rows[0]["ARTICULO"].ToString();
                        txtDescArtConsultoras.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "SILVESTRE")
                    {
                        txtArtSilvestre.Valor = dtTTs.Rows[0]["ARTICULO"].ToString();
                        txtArtDescSilvestre.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    limpiarArtCobro(tipo);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarCategoriaCli(string cat, string tipo)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "CATEGORIA_CLIENTE";
            listA.FILTRO = "where CATEGORIA_CLIENTE = '" + cat + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (tipo == "Estable")
                    {
                        txtCatEstables.Valor = dtTTs.Rows[0]["CATEGORIA_CLIENTE"].ToString();
                        txtCatEstablesDescrip.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                    else if (tipo == "Consul")
                    {
                        txtCatConsul.Valor = dtTTs.Rows[0]["CATEGORIA_CLIENTE"].ToString();
                        txtCatConsulDescrip.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }
                }
                else
                {
                    limpiarCat(tipo);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarBodega(string bodega)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "BODEGA";
            listA.FILTRO = "where BODEGA = '" + bodega + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {

                    txtBodega.Valor = dtTTs.Rows[0]["BODEGA"].ToString();
                    txtBodegaDesc.Valor = dtTTs.Rows[0]["NOMBRE"].ToString();
                }
                else
                {
                    txtBodega.Clear();
                    txtBodegaDesc.Clear();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarCondPago(string tipo)
        {
            if (tipo == "C")
            {
                txtCondPagoColegiaturas.Clear();
                txtDescCondPagoColegiaturas.Clear();
            }
            else if (tipo == "R")
            {
                txtCondPagoRegencia.Clear();
                txtDescCondPagoRegencia.Clear();
            }
            else
            if (tipo == "C_A")
            {
                txtCondPagoCanonesAnuales.Clear();
                txtDescCondPagoCanonesAnuales.Clear();
            }
            else if (tipo == "ADEL")
            {
                txtCondPagoAdelantos.Clear();
                txtDescCondPagoAdelantos.Clear();
            }
        }

        private void limpiarArtCobro(string tipo)
        {
            if (tipo == "PER")
            {
                txtArtPeritajes.Clear();
                txtDescArtPeritajes.Clear();
            }
            else if (tipo == "PLAGUI")
            {
                txtArtPlaguicidas.Clear();
                txtDescArtPlaguicidas.Clear();
            }
            else
            if (tipo == "AEREA")
            {
                txtArtViaAerea.Clear();
                txtDescArtViaAerea.Clear();
            }
            else if (tipo == "CONSUL")
            {
                txtArtConsultoras.Clear();
                txtDescArtConsultoras.Clear();
            }
            else if (tipo == "SILVESTRE")
            {
                txtArtSilvestre.Clear();
                txtArtDescSilvestre.Clear();
            }
        }

        private void limpiarCat(string tipo)
        {
            if (tipo == "Estable")
            {
                txtCatEstables.Clear();
                txtCatEstablesDescrip.Clear();
            }
            else if (tipo == "Consul")
            {
                txtCatConsul.Clear();
                txtCatConsulDescrip.Clear();
            }
        }

        private void txtPedido_Enter(object sender, EventArgs e)
        {
            oldValue = txtPedido.Valor;
        }

        private void txtPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtPedido.ReadOnly)
            {
                listaConsecutivosFA("P");
            }
        }

        private void txtPedido_Leave(object sender, EventArgs e)
        {
            if (txtPedido.Valor.Trim().Equals(""))
            {
                txtPedidoN.Clear();
            }
            else
            {
                if (oldValue != txtPedido.Valor)
                {
                    cargarConsecutivoFA(txtPedido.Valor,"P");
                    if (txtPedido.Valor.Trim() == "")
                        MessageBox.Show("El consecutivo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtPedido_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtPedido.ReadOnly)
            {
                listaConsecutivosFA("P");
            }
        }

        private void txtFactura_Enter(object sender, EventArgs e)
        {
            oldValue = txtFactura.Valor;
        }

        private void txtFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtFactura.ReadOnly)
            {
                listaConsecutivosFA("F");
            }
        }

        private void txtFactura_Leave(object sender, EventArgs e)
        {
            if (txtFactura.Valor.Trim().Equals(""))
            {
                txtFacturaN.Clear();
            }
            else
            {
                if (oldValue != txtFactura.Valor)
                {
                    cargarConsecutivoFA(txtFactura.Valor, "F");
                    if (txtFactura.Valor.Trim() == "")
                        MessageBox.Show("El consecutivo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtFactura_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtFactura.ReadOnly)
            {
                listaConsecutivosFA("F");
            }
        }

        private void txtColegiado_KeyDown(object sender, KeyEventArgs e)
        {
          /*  if (e.KeyValue == (char)Keys.F1 && !txtColegiado.ReadOnly)
            {
                listaConsecutivos("C");
            }*/
        }

        private void txtColegiado_Enter(object sender, EventArgs e)
        {
           // oldValue = txtColegiado.Valor;
        }

        private void txtColegiado_Leave(object sender, EventArgs e)
        {
           /* if (txtColegiado.Valor.Trim().Equals(""))
            {
                txtColegiadoN.Clear();
            }
            else
            {
                if (oldValue != txtColegiado.Valor)
                {
                    cargarConsecutivo(txtColegiado.Valor,"C");
                    if (txtColegiado.Valor.Trim() == "")
                        MessageBox.Show("El consecutivo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }*/
        }

        private void txtColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           /* if (!txtColegiado.ReadOnly)
            {
                listaConsecutivos("C");
            }*/
        }

        private void txtConsecutivoEst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtPedido.ReadOnly)
                listaConsecutivos("E");
            
        }

        private void txtConsecutivoEst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtConsecutivoEst.ReadOnly)
                listaConsecutivos("E");
        }

        private void txtConsecutivoEst_Leave(object sender, EventArgs e)
        {
            if (txtConsecutivoEst.Valor.Trim().Equals(""))
            {
                txtConsecutivoEstNombre.Clear();
            }
            else
            {
                if (oldValue != txtConsecutivoEst.Valor)
                {
                    cargarConsecutivo(txtConsecutivoEst.Valor,"E");
                    if (txtConsecutivoEst.Valor.Trim() == "")
                        MessageBox.Show("El consecutivo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtConsecutivoEst_Enter(object sender, EventArgs e)
        {
            oldValue = txtConsecutivoEst.Valor;
        }

        private void txtConsecutivoAde_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtConsecutivoAde.ReadOnly)
                listaConsecutivos("A");
        }

        private void txtConsecutivoAde_Enter(object sender, EventArgs e)
        {
            oldValue = txtConsecutivoEst.Valor;
        }

        private void txtConsecutivoAde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtConsecutivoAde.ReadOnly)
                listaConsecutivos("A");
        }

        private void txtConsecutivoAde_Leave(object sender, EventArgs e)
        {
            if (txtConsecutivoAde.Valor.Trim().Equals(""))
            {
                txtDescConsecutivoAde.Clear();
            }
            else
            {
                if (oldValue != txtConsecutivoAde.Valor)
                {
                    cargarConsecutivo(txtConsecutivoAde.Valor, "A");
                    if (txtConsecutivoAde.Valor.Trim() == "")
                        MessageBox.Show("El consecutivo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtConsRecibos_Enter(object sender, EventArgs e)
        {
            oldValue = txtConsRecibos.Valor;
        }

        private void txtConsRecibos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtConsRecibos.ReadOnly)
                listaConsecutivos("R");
        }

        private void txtConsRecibos_Leave(object sender, EventArgs e)
        {
            if (txtConsRecibos.Valor.Trim().Equals(""))
            {
                txtDescConsRecibos.Clear();
            }
            else
            {
                if (oldValue != txtConsRecibos.Valor)
                {
                    cargarConsecutivo(txtConsRecibos.Valor, "R");
                    if (txtConsRecibos.Valor.Trim() == "")
                        MessageBox.Show("El consecutivo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtConsRecibos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtConsRecibos.ReadOnly)
                listaConsecutivos("R");
        }

        private void txtCondPagoColegiaturas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCondPago("C");
        }

        private void txtCondPagoColegiaturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondPagoColegiaturas.ReadOnly)
                listaCondPago("C");
        }

        private void txtCondPagoColegiaturas_Leave(object sender, EventArgs e)
        {
            if (txtCondPagoColegiaturas.Valor.Trim().Equals(""))
            {
                txtDescCondPagoColegiaturas.Clear();
            }
            else
            {
                if (oldValue != txtCondPagoColegiaturas.Valor)
                {
                    cargarCondPago(txtCondPagoColegiaturas.Valor, "C");
                    if (txtCondPagoColegiaturas.Valor.Trim() == "")
                        MessageBox.Show("La condición de pago digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCondPagoColegiaturas_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondPagoColegiaturas.Valor;
        }

        private void txtCondPagoRegencia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondPagoRegencia.ReadOnly)
                listaCondPago("R");
        }

        private void txtCondPagoRegencia_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondPagoRegencia.Valor;
        }

        private void txtCondPagoRegencia_Leave(object sender, EventArgs e)
        {
            if (txtCondPagoRegencia.Valor.Trim().Equals(""))
            {
                txtDescCondPagoRegencia.Clear();
            }
            else
            {
                if (oldValue != txtCondPagoRegencia.Valor)
                {
                    cargarCondPago(txtCondPagoRegencia.Valor, "R");
                    if (txtCondPagoRegencia.Valor.Trim() == "")
                        MessageBox.Show("La condición de pago digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCondPagoRegencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondPagoRegencia.ReadOnly)
                listaCondPago("R");
        }

        private void txtCondPagoPeritaje_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondPagoCanonesAnuales.ReadOnly)
                listaCondPago("C_A");
        }

        private void txtCondPagoPeritaje_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondPagoCanonesAnuales.Valor;
        }

        private void txtCondPagoPeritaje_Leave(object sender, EventArgs e)
        {
            if (txtCondPagoCanonesAnuales.Valor.Trim().Equals(""))
            {
                txtDescCondPagoCanonesAnuales.Clear();
            }
            else
            {
                if (oldValue != txtCondPagoCanonesAnuales.Valor)
                {
                    cargarCondPago(txtCondPagoCanonesAnuales.Valor, "C_A");
                    if (txtCondPagoCanonesAnuales.Valor.Trim() == "")
                        MessageBox.Show("La condición de pago digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCondPagoPeritaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondPagoCanonesAnuales.ReadOnly)
                listaCondPago("C_A");
        }

        private void chkManejoRegencias_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkManejoRegencias.Checked)
                txtCondPagoRegencia.ReadOnly = false;
            else
            {
                txtCondPagoRegencia.ReadOnly = true;
                txtCondPagoRegencia.Clear();
                txtDescCondPagoRegencia.Clear();
            }
        }

        private void chkPermitirPerito_MouseClick(object sender, MouseEventArgs e)
        {

		}

		private void txtAdeCondPagoColegiaturas_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondPagoAdelantos.Valor;
        }

        private void txtAdeCondPagoColegiaturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondPagoAdelantos.ReadOnly)
                listaCondPago("ADEL");
        }

        private void txtAdeCondPagoColegiaturas_Leave(object sender, EventArgs e)
        {
            if (txtCondPagoAdelantos.Valor.Trim().Equals(""))
            {
                txtDescCondPagoAdelantos.Clear();
            }
            else
            {
                if (oldValue != txtCondPagoAdelantos.Valor)
                {
                    cargarCondPago(txtCondPagoAdelantos.Valor, "ADEL");
                    if (txtCondPagoAdelantos.Valor.Trim() == "")
                        MessageBox.Show("La condición de pago digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtAdeCondPagoColegiaturas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondPagoAdelantos.ReadOnly)
                listaCondPago("ADEL");
        }

        private void txtArtPeritajes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtArtPeritajes.ReadOnly)
                listaArtCobro("PER");
        }

        private void txtArtPlaguicidas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtArtPlaguicidas.ReadOnly)
                listaArtCobro("PLAGUI");
        }

        private void txtArtConsultoras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtArtConsultoras.ReadOnly)
                listaArtCobro("CONSUL");
        }

        private void txtArtViaAerea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtArtViaAerea.ReadOnly)
                listaArtCobro("AEREA");
        }

        private void txtArtSilvestre_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtArtSilvestre.ReadOnly)
                listaArtCobro("SILVESTRE");
        }

        private void txtArtPeritajes_Enter(object sender, EventArgs e)
        {
            oldValue = txtArtPeritajes.Valor;
        }

        private void txtArtPlaguicidas_Enter(object sender, EventArgs e)
        {
            oldValue = txtArtPlaguicidas.Valor;
        }

        private void txtArtViaAerea_Enter(object sender, EventArgs e)
        {
            oldValue = txtArtViaAerea.Valor;
        }

        private void txtArtSilvestre_Enter(object sender, EventArgs e)
        {
            oldValue = txtArtSilvestre.Valor;
        }

        private void txtArtConsultoras_Enter(object sender, EventArgs e)
        {
            oldValue = txtArtConsultoras.Valor;
        }

        private void txtArtPeritajes_Leave(object sender, EventArgs e)
        {
            if (txtArtPeritajes.Valor.Trim().Equals(""))
            {
                txtDescArtPeritajes.Clear();
            }
            else
            {
                if (oldValue != txtArtPeritajes.Valor)
                {
                    cargarArtCobro(txtArtPeritajes.Valor, "PER");
                    if (txtArtPeritajes.Valor.Trim() == "")
                        MessageBox.Show("El codigo de articulo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtArtPlaguicidas_Leave(object sender, EventArgs e)
        {
            if (txtArtPlaguicidas.Valor.Trim().Equals(""))
            {
                txtDescArtPlaguicidas.Clear();
            }
            else
            {
                if (oldValue != txtArtPlaguicidas.Valor)
                {
                    cargarArtCobro(txtArtPlaguicidas.Valor, "PLAGUI");
                    if (txtArtPlaguicidas.Valor.Trim() == "")
                        MessageBox.Show("El codigo de articulo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtArtViaAerea_Leave(object sender, EventArgs e)
        {
            if (txtArtViaAerea.Valor.Trim().Equals(""))
            {
                txtDescArtViaAerea.Clear();
            }
            else
            {
                if (oldValue != txtArtViaAerea.Valor)
                {
                    cargarArtCobro(txtArtViaAerea.Valor, "AEREA");
                    if (txtArtViaAerea.Valor.Trim() == "")
                        MessageBox.Show("El codigo de articulo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtArtSilvestre_Leave(object sender, EventArgs e)
        {
            if (txtArtSilvestre.Valor.Trim().Equals(""))
            {
                txtArtDescSilvestre.Clear();
            }
            else
            {
                if (oldValue != txtArtSilvestre.Valor)
                {
                    cargarArtCobro(txtArtSilvestre.Valor, "SILVESTRE");
                    if (txtArtSilvestre.Valor.Trim() == "")
                        MessageBox.Show("El codigo de articulo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtArtConsultoras_Leave(object sender, EventArgs e)
        {
            if (txtArtConsultoras.Valor.Trim().Equals(""))
            {
                txtDescArtConsultoras.Clear();
            }
            else
            {
                if (oldValue != txtArtConsultoras.Valor)
                {
                    cargarArtCobro(txtArtConsultoras.Valor, "CONSUL");
                    if (txtArtConsultoras.Valor.Trim() == "")
                        MessageBox.Show("El codigo de articulo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtArtPeritajes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtArtPeritajes.ReadOnly)
                listaArtCobro("PER");
        }

        private void txtArtPlaguicidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtArtPlaguicidas.ReadOnly)
                listaArtCobro("PLAGUI");
        }

        private void txtArtViaAerea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtArtViaAerea.ReadOnly)
                listaArtCobro("AEREA");
        }

        private void txtArtSilvestre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtArtSilvestre.ReadOnly)
                listaArtCobro("SILVESTRE");
        }

        private void txtArtConsultoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtArtConsultoras.ReadOnly)
                listaArtCobro("CONSUL");
        }
        
        private void chkPermitirPerito_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (chkPermitirPerito.Checked)
            {
                txtArtPeritajes.ReadOnly = false;
            }
            else
            {
                txtArtPeritajes.ReadOnly = true;
            }
        }

        private void chkManejoPlaguicidas_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkManejoPlaguicidas.Checked)
            {
                txtArtPlaguicidas.ReadOnly = false;
            }
            else
            {
                txtArtPlaguicidas.ReadOnly = true;
            }
        }

        private void chkManejoViaAerea_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkManejoViaAerea.Checked)
            {
                txtArtViaAerea.ReadOnly = false;
            }
            else
            {
                txtArtViaAerea.ReadOnly = true;
            }
        }

        private void chkManejoSilvestre_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkManejoSilvestre.Checked)
            {
                txtArtSilvestre.ReadOnly = false;
            }
            else
            {
                txtArtSilvestre.ReadOnly = true;
            }
        }

        private void txtCatEstables_Enter(object sender, EventArgs e)
        {
            oldValue = txtCatEstables.Valor;
        }

        private void txtCatEstables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCatEstables.ReadOnly)
                listaCategoriaCli("Estable");
        }

        private void txtCatEstables_Leave(object sender, EventArgs e)
        {
            if (txtCatEstables.Valor.Trim().Equals(""))
            {
                txtCatEstablesDescrip.Clear();
            }
            else
            {
                if (oldValue != txtCatEstables.Valor)
                {
                    cargarCategoriaCli(txtCatEstables.Valor, "Estable");
                    if (txtCatEstables.Valor.Trim() == "")
                        MessageBox.Show("El codigo de categoria digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCatEstables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCatEstables.ReadOnly)
                listaCategoriaCli("Estable");
        }

        private void txtCatConsul_Enter(object sender, EventArgs e)
        {
            oldValue = txtCatConsul.Valor;
        }

        private void txtCatConsul_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCatConsul.ReadOnly)
                listaCategoriaCli("Consul");
        }

        private void txtCatConsul_Leave(object sender, EventArgs e)
        {
            if (txtCatConsul.Valor.Trim().Equals(""))
            {
                txtCatConsulDescrip.Clear();
            }
            else
            {
                if (oldValue != txtCatConsul.Valor)
                {
                    cargarCategoriaCli(txtCatConsul.Valor, "Consul");
                    if (txtCatConsul.Valor.Trim() == "")
                        MessageBox.Show("El codigo de categoria digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCatConsul_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCatConsul.ReadOnly)
                listaCategoriaCli("Consul");
        }

        private void txtBodega_Enter(object sender, EventArgs e)
        {
            oldValue = txtBodega.Valor;
        }

        private void txtBodega_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtBodega.ReadOnly)
                listaBodegas();
        }

        private void txtBodega_Leave(object sender, EventArgs e)
        {
            if (txtBodega.Valor.Trim().Equals(""))
            {
                txtBodegaDesc.Clear();
            }
            else
            {
                if (oldValue != txtBodega.Valor)
                {
                    cargarBodega(txtBodega.Valor);
                    if (txtBodega.Valor.Trim() == "")
                        MessageBox.Show("El codigo de la bodega digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtBodega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtBodega.ReadOnly)
                listaBodegas();
        }

        private void listaSubtipos()
        {
            Listado listD = new Listado();
            listD.COLUMNAS = "SUBTIPO as Código,DESCRIPCION as Descripcion";
            listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listD.TABLA = "SUBTIPO_DOC_CC";
            listD.FILTRO = "where TIPO = 'REC'";
            listD.TITULO_LISTADO = "Subtipos de Recibo";

            frmF1 f1 = new frmF1(listD);
            f1.ShowDialog();
            if (f1.item != null)
            {
                txtSubTipoDoc.Valor = f1.item.SubItems[0].Text;
                txtSubTipoDocNombre.Valor = f1.item.SubItems[1].Text;
            }
        }

        private void cargarSubTipo(string sub)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "SUBTIPO,DESCRIPCION";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "SUBTIPO_DOC_CC";
            listA.FILTRO = "where TIPO = 'REC' and SUBTIPO = '" + sub + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    txtSubTipoDoc.Valor = dtTTs.Rows[0]["SUBTIPO"].ToString();
                    txtSubTipoDocNombre.Valor = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                }
                else
                {
                    limpiarSubTipo();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarSubTipo()
        {
            txtSubTipoDoc.Clear();
            txtSubTipoDocNombre.Clear();
        }


        private void txtSubTipoDoc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtSubTipoDoc.ReadOnly)
            {
                listaSubtipos();
            }
        }

        private void txtSubTipoDoc_Leave(object sender, EventArgs e)
        {
            if (txtSubTipoDoc.Valor.Trim().Equals(""))
            {
                txtSubTipoDocNombre.Clear();
            }
            else
            {
                if (oldValue != txtSubTipoDoc.Valor)
                {
                    cargarSubTipo(txtSubTipoDoc.Valor);
                    if (txtSubTipoDoc.Valor.Trim() == "")
                        MessageBox.Show("El Subtipo digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtSubTipoDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtSubTipoDoc.ReadOnly)
            {
                listaSubtipos();
            }
        }

        private void txtSubTipoDoc_Enter(object sender, EventArgs e)
        {
            oldValue = txtSubTipoDoc.Valor;
        }
    }
}
