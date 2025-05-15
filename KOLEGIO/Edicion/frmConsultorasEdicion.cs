using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOLEGIO
{
    public partial class frmConsultorasEdicion : frmEdicion
    {
        private FuncsInternas fInternas;
        private DateTimePicker dtp = new DateTimePicker();
        private string NumeroColeg = "";
        private bool crearHistorialCanon = false;
        private bool estadoCerrado = false;
        //int AñoCobro = 0;
        //int AñoCobroActualizado = 0;
        public frmConsultorasEdicion()
        {
            InitializeComponent();
        }

        
        public frmConsultorasEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            //dtpFecha.Value = DateTime.Now;
            listaEstados();
            //rbNo.Checked = true;
            if (cmbEstado.Count > 0)
                cmbEstado.Index = 0;
            //verificarEstadoCanon();
            cargarDatos();
            cmbEstado.SelectedValueChanged(new EventHandler(OnEstadoChanged));
        }

        public frmConsultorasEdicion(List<string> valoresPk, string NumeroCole)
            : base(valoresPk)
        {
            NumeroColeg = NumeroCole;
            InitializeComponent();
            //this.fInternas = new FuncsInternas();
            //dtpFecha.Value = DateTime.Now;
            //listaEstados();
            //rbNo.Checked = true;
            //if (cmbEstado.Count > 0)
            //    cmbEstado.Index = 0;
            //verificarEstadoCanon();
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Administración de Compañias Consultoras";
                lblPerfil.Text = "Perfil de Consultora";

                listar.COLUMNAS = "Codigo,CedulaJuridica,Nombre,PagaCanon,Telefono,Fax," +
                    "Apartado,Email,EmailAdicional,Estado,Provincia,Canton,Distrito,Direccion,FechaAprobacion,SesionAprobacion,FechaRenovacion,SesionRenovacion,FechaCierre,SesionCierre,Cobrador";

                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_CONSULTORAS";

                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("Codigo");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);
                identificadorFormulario = "De Consultoras";

                insertar = Constantes.CONSULTORA_INSERTAR;
                editar = Constantes.CONSULTORA_EDITAR;
                borrar = Constantes.CONSULTORA_BORRAR;
                seleccionar = Constantes.CONSULTORA_SELECCIONAR;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia del formulario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void cargarDatos()
        {
            tabControl.TabPages.Remove(tpAdjuntos);
            tabControl.TabPages.Add(tpAdjuntos);
            tabControl.TabPages.Remove(tpAdmin);
            tabControl.TabPages.Add(tpAdmin);

            txtCodigo.Valor = "ND";
            txtCedulaJuridica.Valor = "ND";
            //listaEstados();

            //if (cmbEstado.Count > 0)
            //    cmbEstado.Index = 0;

            if (valoresPk.Count > 0)
            {
                if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDatos.Rows)
                        {
                            txtCodigo.Valor = row["Codigo"].ToString();
                            if (!row["CedulaJuridica"].ToString().Equals(""))
                                txtCedulaJuridica.Valor = row["CedulaJuridica"].ToString();
                            txtNombre.Valor = row["Nombre"].ToString();
                            if (row["PagaCanon"].ToString() == "S")
                                rbSi.Checked = true;
                            else
                                rbNo.Checked = true;
                            
                            txtTelefono.Valor = row["Telefono"].ToString();
                            txtFax.Valor = row["Fax"].ToString();
                            txtApartado.Valor = row["Apartado"].ToString();
                            txtEmail.Valor = row["Email"].ToString();
                            txtEmailAdicional.Valor = row["EmailAdicional"].ToString();
                            cmbEstado.Valor = row["Estado"].ToString();
                            if (!cmbEstado.Valor.Equals(""))
                            {
                                verificarConfigurablesEstado();
                            }
                            txtProvincia.Valor = row["Provincia"].ToString();
                            if (txtProvincia.Valor != "")
                                buscaProvincia(txtProvincia.Valor);

                            txtCanton.Valor = row["Canton"].ToString();
                            if (txtCanton.Valor != "")
                                buscaCanton(txtCanton.Valor);

                            txtDistrito.Valor = row["Distrito"].ToString();
                            if (txtDistrito.Valor != "")
                                buscaDistrito(txtDistrito.Valor);

                            txtCobrador.Valor = row["Cobrador"].ToString();
                            if (txtCobrador.Valor != "")
                                buscaCobrador(txtCobrador.Valor);

                            rtbDireccion.Text = row["Direccion"].ToString();

                            if (!String.IsNullOrEmpty(row["FechaAprobacion"].ToString()))
                            {
                                dtpFechaAprobacion.Value = DateTime.Parse(row["FechaAprobacion"].ToString());
                                //dtpFechaCierre.Value = DateTime.Parse(row["FechaCierre"].ToString());
                            }
                            if (!String.IsNullOrEmpty(row["SesionAprobacion"].ToString()))
                            {
                                //txtSesionCierre.Valor = row["SesionAprobacionCierre"].ToString();
                                txtSesionAprobacion.Valor = row["SesionAprobacion"].ToString();
                            }

                            if (!String.IsNullOrEmpty(row["FechaRenovacion"].ToString()))
                            {
                                dtpFechaRenov.Checked = true;
                                dtpFechaRenov.Value = DateTime.Parse(row["FechaRenovacion"].ToString());
                                //dtpFechaCierre.Value = DateTime.Parse(row["FechaCierre"].ToString());
                            }

                            if (!String.IsNullOrEmpty(row["SesionRenovacion"].ToString()))
                            {
                                //txtSesionCierre.Valor = row["SesionAprobacionCierre"].ToString();
                                txtSesionRenov.Valor = row["SesionRenovacion"].ToString();
                            }

                            if (!String.IsNullOrEmpty(row["FechaCierre"].ToString()))
                            {
                                //txtSesionCierre.Valor = row["SesionAprobacionCierre"].ToString();
                                dtpFechaCierre.Checked = true;
                                dtpFechaCierre.Value = DateTime.Parse(row["FechaCierre"].ToString());
                            }

                            if (!String.IsNullOrEmpty(row["SesionCierre"].ToString()))
                            {
                                txtSesionCierre.Valor = row["SesionCierre"].ToString();
                                //dtpFechaCierre.Value = DateTime.Parse(row["FechaCierre"].ToString());
                            }
                        }
                    }

                    deshabilitarLlave();
                    verificarEstadoCanon();
                    //if (habilitarProceso)
                    //{
                    //    btnProcesar.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnProcesar.Enabled = false;
                    //}

                    cargarCamposAccion(ref error);
                    cargarColegiados(ref error);

                }
            }
        }

        protected override bool llenarParametros()
        {
            dgvCamposAccion.EndEdit();
            parametros.Clear();

            if(valoresPk.Count == 0)
                txtCodigo.Valor = txtCedulaJuridica.Valor;
            
            parametros.Add(txtCodigo.Valor);
            parametros.Add(txtCedulaJuridica.Valor);
            parametros.Add(txtNombre.Valor);
            if (rbSi.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");
            parametros.Add(txtTelefono.Valor);
            parametros.Add(txtFax.Valor);
            parametros.Add(txtApartado.Valor);
            parametros.Add(txtEmail.Valor);
            parametros.Add(txtEmailAdicional.Valor);
            parametros.Add(cmbEstado.Valor);
            parametros.Add(txtProvincia.Valor);
            parametros.Add(txtCanton.Valor);
            parametros.Add(txtDistrito.Valor);
            parametros.Add(rtbDireccion.Text);
            if (txtSesionAprobacion.Valor != "")
            {
                parametros.Add(dtpFechaAprobacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                parametros.Add(txtSesionAprobacion.Valor);
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
            }

            if (dtpFechaRenov.Checked)
                parametros.Add(dtpFechaRenov.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (txtSesionRenov.Valor != "")
                parametros.Add(txtSesionRenov.Valor);
            else
                parametros.Add("null");
            
            if (dtpFechaCierre.Checked && estadoCerrado)
                parametros.Add(dtpFechaCierre.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (txtSesionCierre.Valor != "" && estadoCerrado)
                parametros.Add(txtSesionCierre.Valor);
            else
                parametros.Add("null");

            if (!txtCobrador.Valor.Equals(""))
                parametros.Add(txtCobrador.Valor);
            else
                parametros.Add("ND");

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Valor = "ND";
            txtCedulaJuridica.Valor = "ND";
            txtNombre.Clear();
            listar.VALORES_PK.Clear();

            txtTelefono.Clear();
            txtFax.Clear();
            txtApartado.Clear();
            txtEmail.Clear();
            txtEmailAdicional.Clear();
            txtProvincia.Clear();
            txtProvinciaNombreF.Clear();
            txtCanton.Clear();
            txtCantonNombreF.Clear();
            txtDistrito.Clear();
            txtDistritoNombreF.Clear();
            rtbDireccion.Clear();
            rbSi.Checked = false;
            rbNo.Checked = false;
            txtSesionAprobacion.Clear();
            txtSesionRenov.Clear();
            txtSesionCierre.Clear();
            dtpFechaAprobacion.Value = DateTime.Now;
            dtpFechaRenov.Value = DateTime.Now;
            dtpFechaRenov.Checked = false;
            dtpFechaCierre.Value = DateTime.Now;
            dtpFechaCierre.Checked = false;
            txtCobrador.Clear();
            txtCobradorNombre.Clear();

            dgvCamposAccion.Rows.Clear();
            dgvColegiados.Rows.Clear();
            lblPerfil.Text = "Perfil de Consultora";
        }

        private bool canonesAnuales(string id, ref string error)
        {
            bool OK = true;
            string sInsert = "";
            string sSelect = "";
            DateTime mesUltCobro = DateTime.Now;
            DataTable dt = new DataTable();


            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + id + "' and Canon = 'CONSUL'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count == 0)
            {
                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon) values ('" + id + "', 'CONSUL')";

                OK = Consultas.ejecutarSentencia(sInsert, ref error);
            }

            return OK;
        }

        private void OnEstadoChanged(object sender, EventArgs e)
        {
            verificarConfigurablesEstado();
        }

        private void verificarConfigurablesEstado()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "EsEstadoCierre";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where CodigoEstado = '" + cmbEstado.Valor + "'";
            //listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows[0]["EsEstadoCierre"].ToString() == "S")
                    {
                        lblFechaCierre.Visible = true;
                        lblSesionCierre.Visible = true;
                        dtpFechaCierre.Visible = true;
                        txtSesionCierre.Visible = true;
                        estadoCerrado = true;
                    }
                    else
                    {
                        estadoCerrado = false;
                        lblFechaCierre.Visible = false;
                        lblSesionCierre.Visible = false;
                        dtpFechaCierre.Visible = false;
                        txtSesionCierre.Visible = false;
                    }

                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void verificarEstadoCanon()
        {
            DataTable dtCliente = new DataTable();
            bool lbOk = true;
            int añoActual = DateTime.Now.Year;

            string sSelectCl = "select pedidoConsultora from "+Consultas.sqlCon.COMPAÑIA+ ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtCodigo.Valor+ "' and Canon = 'consul'";

            lbOk = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

            if (lbOk && dtCliente.Rows.Count > 0)
            {
                if (dtCliente.Rows[0]["pedidoConsultora"].ToString() == "S")
                    btnProcesar.Enabled = false;
                else
                    btnProcesar.Enabled = true;
                //if (!dtCliente.Rows[0]["AñoUltimoCobro"].ToString().Equals(""))
                //{
                //    AñoCobro = DateTime.Parse(dtCliente.Rows[0]["AñoUltimoCobro"].ToString()).Year;
                //    AñoCobroActualizado = AñoCobro + 1;
                //}
                //else
                //{
                //    AñoCobro = añoActual;
                //    AñoCobroActualizado = AñoCobro;
                //}

                //if (AñoCobro >= añoActual)
                //    habilitarProceso = false;
                //else
                //    habilitarProceso = true;
            }
            else
            {
                crearHistorialCanon = true;
                btnProcesar.Enabled = true;
            }
        }

        protected override bool validarDatosPedidos(ref string error)
        {
            bool OK = true;

            if (!validarEstado())
            {
                error = "El estado actual no genera cobro.";
                OK = false;
            }

            if (btnGuardar.Enabled)
            {
                error = "Debe guardar los cambios realizados.";
                OK = false;
            }

            if (!rbSi.Checked)
            {
                error = "Esta consultora no paga canon.";
                OK = false;
            }

            if (txtCedulaJuridica.Valor == "")
            {
                error = "Debe ingresar una cédula jurídica.";
                return false;
            }

            return OK;
        }

        protected override bool validarDatos(ref string errores)
        {
            //dgvRegentes.EndEdit();
            if (txtCodigo.Valor == "")
            {
                errores = "Debe digitar el Codigo para la consultora.";
                txtCodigo.Focus();
                return false;
            }

            if (txtNombre.Valor == "")
            {
                errores = "Debe digitar un nombre para la consultora.";
                txtNombre.Focus();
                return false;
            }

            if (txtCedulaJuridica.Valor == "")
            {
                errores = "Debe digitar la cedula juridica de la consultora.";
                txtCedulaJuridica.Focus();
                return false;
            }

            if (cmbEstado.Valor == "")
            {
                errores = "Debe seleccionar un estado para la consultora.";
                return false;
            }
            else
            {
                if (estadoCerrado)
                {
                    if (!dtpFechaCierre.Checked)
                    {
                        errores = "Debe ingresar una fecha de cierre para la consultora.";
                        return false;
                    }

                    if (txtSesionCierre.Valor.Equals(""))
                    {
                        errores = "Debe agregar la sesión de cierre para la consultora.";
                        return false;
                    }
                }
            }

            if (txtProvincia.Valor == "")
            {
                errores = "Debe seleccionar la provincia de la consultora.";
                return false;
            }

            //foreach (DataGridViewRow row in dgvRegentes.Rows)
            //{
            //    if (row.Cells["colCodigoRegente"].Value.ToString() == "")
            //    {
            //        errores = "Debe definir un regente en la fila " + (row.Index + 1) + " de la tabla de regentes.";
            //        return false;
            //    }

            //    if (row.Cells["colEstado"].Value == null)
            //    {
            //        errores = "Debe definir un estado para el regente en la fila " + (row.Index + 1) + " de la tabla de regentes.";
            //        return false;
            //    }
            //}

            return true;
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            //txtNumRegistro.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Consultora: " + txtNombre.Valor;
        }

        protected override bool guardarDetalle(ref string error)
        {
            bool OK = true;

            OK = CamposAccion(ref error);
      
            if (OK)
                OK = Colegiados(ref error);

            if (OK)
                OK = canonesAnuales(txtCodigo.Valor, ref error);

            if (OK)
                OK = clienteERP(ref error);


            return OK;
        }

        protected override bool generarFacturas(ref string error)
        {
            decimal montoDesc = 0;
            int porcDescuento = 0, indiceArticulo = 0;
            bool pedidoPorConcepto = false, OK = true;
            string sQuery = "", factura = "", comentario = "";
            DataTable dtArticulos = new DataTable();
            int AñoCobro = DateTime.Now.Year;

            if (DateTime.Now.Month >= 9)//Si es octubre o mayor se cobra el siguiente año
                AñoCobro = DateTime.Now.AddYears(1).Year;

            if (!Globales.ARTICULO_COBRO_CONSULTORAS.Equals(""))
            {
                sQuery = "SELECT t1.ARTICULO, t1.DESCRIPCION,t2.PRECIO, '1' as CANTIDAD FROM " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 on t2.ARTICULO = t1.ARTICULO" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                        " WHERE t1.ARTICULO = '" + Globales.ARTICULO_COBRO_CONSULTORAS + "'";
            }
            else
            {
                error = "No se pudo obtener el artículo para la generación del pedido";
                OK = false;
            }



            if (OK)
            {
                if (Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
                {
                    if (OK)
                        OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtCodigo.Valor, ref error);

                    comentario = "Canon inscripción " + AñoCobro + "-" + txtNombre.Valor + "";
                    //string observacion = "Canon inscripción " + AñoCobro + "-" + txtNombre.Valor;
                    if (OK)
                        OK = controlerBD.crearPedidoGenerico(dtArticulos, txtCodigo.Valor, ref factura/*pedido*/, montoDesc, porcDescuento, pedidoPorConcepto, indiceArticulo, txtCobrador.Valor, "C_A", "PEDIDOS", "CIA", comentario, "", ref error);
                    //if (OK)
                    //    OK = controlerBD.FacturarSinPedido(dtArticulos, txtCodigo.Valor, ref factura, montoDesc, porcDescuento, true, indiceArticulo, txtCobrador.Valor, "C_A", "FACTURAS", "CIA", observacion, string.Empty, string.Empty, string.Empty, ref error);

                }
                else
                    OK = false;
            }


            if (OK)
            {
                //DateTime ultimoCobro = new DateTime(AñoCobroActualizado, 1,1);
                //OK = actualizarUltAñoCobro(txtCodigo.Valor, ultimoCobro, ref error);
                if (crearHistorialCanon)
                {
                    string sUpdateCanones = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION (Identificador, Canon, PedidoConsultora, NumeroConsultora) VALUES ('" + txtCodigo.Valor + "', 'consul', 'S', '" + factura + "')";

                    OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);
                }
                else
                {
                    string sUpdateCanones = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION SET PedidoConsultora = 'S', NumeroConsultora = '" + factura + "' WHERE Identificador = '" + txtCodigo.Valor + "' and Canon = 'consul'";

                    OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);
                }
            }

            return OK;
        }

        private bool clienteERP(ref string error)
        {
            DataTable dtCliente = new DataTable();
            DataTable dtNit = new DataTable();

            string sSelectCl = "";
            bool lbOk = true;
            try
            {
                sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NIT where NIT = '" + txtCedulaJuridica.Valor + "'";

                lbOk = Consultas.fillDataTable(sSelectCl, ref dtNit, ref error);

                if (lbOk && dtNit.Rows.Count == 0)//Si no tiene nit lo crea
                    lbOk = fInternas.generarNit(txtCedulaJuridica.Valor, txtCodigo.Valor, ref dtCliente, "consultora", ref error);

                if (lbOk)
                {
                    sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + txtCodigo.Valor + "'";

                    lbOk = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);
                }
                

                if (lbOk && dtCliente.Rows.Count == 0)//Si no existe como cliente se crea
                {       
                    lbOk = fInternas.generarCliente(txtCodigo.Valor, ref dtCliente, "consultora", "C_A", ref error);
                }
                else//Sino se actualiza
                {
                    dtCliente = new DataTable();

                    sSelectCl = "select Codigo idERP, Nombre, '' Alias, Direccion, Telefono Telefono1, '' Telefono2,"+ 
                    " CedulaJuridica Contribuyente, 'CRI' Pais, '' UsaTarjeta, '' VencimientoTarjeta, Email,"+
                    " Provincia, Canton, 'S' Activo, (select CategoriaConsul from " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES) Categoria from " + Consultas.sqlCon.COMPAÑIA+".NV_CONSULTORAS where Codigo = '"+txtCodigo.Valor+"'";

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

        //private bool actualizarUltAñoCobro(string id, DateTime ultimoCobro, ref string error)
        //{
        //    bool OK = true;
        //    string sUpdate = "";
        //    string sInsert = "";
        //    string sSelect = "";
        //    DateTime mesUltCobro = DateTime.Now;
        //    DataTable dt = new DataTable();
            

        //    string año = "";
        //    año = ultimoCobro.ToString("yyyy-MM-ddTHH:mm:ss");

        //    sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + id + "'  and Canon = 'CONSUL'";

        //    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

        //    if (OK && dt.Rows.Count > 0)
        //    {
        //        sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES set AñoUltimoCobro = '" + año + "' where Identificador = '" + id + "'  and Canon = 'CONSUL'";

        //        OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //    }
        //    else
        //    {
        //        sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon, AñoUltimoCobro) values ('" + id + "', 'CONSUL', '" + año + "')";

        //        OK = Consultas.ejecutarSentencia(sInsert, ref error);
        //    }

        //    return OK;
        //}

        private void listaEstados()
        {
            DataTable dtEstados = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoEstado,NombreEstado,GeneraCobro";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where Diferenciador != 'E'";
            listA.ORDERBY = "order by CodigoEstado";

            if (Consultas.listarDatos(listA, ref dtEstados, ref error))
            {
                if (dtEstados.Rows.Count > 0)
                {
                    cmbEstado.DataSource(dtEstados, "CodigoEstado", "NombreEstado");
                    cmbEstado.Valor = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validarEstado()
        {
            DataTable dtEstados = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "GeneraCobro";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where Diferenciador = 'C' and CodigoEstado = '" + cmbEstado.Valor + "'";
            listA.ORDERBY = "order by CodigoEstado";

            if (Consultas.listarDatos(listA, ref dtEstados, ref error))
            {
                if (dtEstados.Rows.Count > 0)
                {
                    if (dtEstados.Rows[0]["GeneraCobro"].ToString() == "S")
                        return true;
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private bool CamposAccion(ref string error)
        {
            bool OK = true;
            string sQuery = "";
            string sSelect = "";
            DataTable dt = new DataTable();
            sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS_CAMPOS_ACCION WHERE CodigoConsultora='" + txtCodigo.Valor + "'";

            OK = Consultas.ejecutarSentencia(sQuery, ref error);

            if (OK)
            {
                sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS_CAMPOS_ACCION (CodigoConsultora,CodigoCampo) " +
                    "VALUES (@CodigoConsultora,@CodigoCampo)";

                foreach (DataGridViewRow row in dgvCamposAccion.Rows)
                {

                    sSelect = "SELECT CodigoConsultora,CodigoCampo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS_CAMPOS_ACCION WHERE CodigoConsultora='" + txtCodigo.Valor + "' and CodigoCampo = '" + row.Cells["colCodigoCampo"].Value.ToString() + "'";
                    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

                    if (OK && dt.Rows.Count > 0)
                    {
                        OK = false;
                        error = "El campo de accion ya existe en la consultora";
                    }
                    else
                    {
                        parametros.Clear();
                        parametros.Add("@CodigoConsultora," + txtCodigo.Valor);
                        parametros.Add("@CodigoCampo," + row.Cells["colCodigoCampo"].Value.ToString());
                       

                        OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

                    }

                    if (!OK)
                        break;
                }
            }
            return OK;
        }

        private bool Colegiados(ref string error)
        {
            bool OK = true;
            string sQuery = "";
            string sSelect = "";
            DataTable dt = new DataTable();
            sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS_COLEGIADO WHERE CodigoConsultora='" + txtCodigo.Valor + "'";

            OK = Consultas.ejecutarSentencia(sQuery, ref error);

            if (OK)
            {
                sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS_COLEGIADO (CodigoConsultora,IdColegiado) " +
                    "VALUES (@CodigoConsultora,@IdColegiado)";

                foreach (DataGridViewRow row in dgvColegiados.Rows)
                {

                    sSelect = "SELECT CodigoConsultora,IdColegiado FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONSULTORAS_COLEGIADO WHERE CodigoConsultora='" + txtCodigo.Valor + "' and IdColegiado = '" + row.Cells["colCodigoColegiado"].Value.ToString() + "'";
                    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

                    if (OK && dt.Rows.Count > 0)
                    {
                        OK = false;
                        error = "El colegiado ya es responsable de esta consultora";
                    }
                    else
                    {
                        parametros.Clear();
                        parametros.Add("@CodigoConsultora," + txtCodigo.Valor);
                        parametros.Add("@IdColegiado," + row.Cells["colCodigoColegiado"].Value.ToString());


                        OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

                    }

                    if (!OK)
                        break;
                }
            }
            return OK;
        }

        private void cargarCamposAccion(ref string error)
        {
            DataTable dtCamposAccion = new DataTable();
            string sQuery = "SELECT T1.CodigoCampo, T2.NombreCampo, T2.DescripcionCampo FROM "+Consultas.sqlCon.COMPAÑIA+".NV_CONSULTORAS_CAMPOS_ACCION T1"+
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMPOS_ACCION T2 ON T2.CodigoCampo = T1.CodigoCampo" +
                            " WHERE T1.CodigoConsultora = '" + txtCodigo.Valor + "'";
            

       
                    if (Consultas.fillDataTable(sQuery, ref dtCamposAccion, ref error))
                    {
                        dgvCamposAccion.Rows.Clear();
                        if (dtCamposAccion.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtCamposAccion.Rows)
                            {

                                dgvCamposAccion.Rows.Add(row["CodigoCampo"].ToString(), row["NombreCampo"].ToString(),
                                            row["DescripcionCampo"].ToString());
                            }

                            if (dgvCamposAccion.RowCount > 0)
                            {
                                dgvCamposAccion.CurrentCell = dgvCamposAccion[0, 0];
                                //cargarInfoEstablecimiento(dgvEstablecimientos[0, 0].Value.ToString());
                            }
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void cargarColegiados(ref string error)
        {
            DataTable dtColegiados = new DataTable();
            string sQuery = "SELECT T1.IdColegiado, T2.Nombre, T2.NumeroColegiado FROM "+Consultas.sqlCon.COMPAÑIA+".NV_CONSULTORAS_COLEGIADO T1"+
                            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO T2 ON T2.IdColegiado = T1.IdColegiado" +
                            " WHERE T1.CodigoConsultora = '" + txtCodigo.Valor + "'";



            if (Consultas.fillDataTable(sQuery, ref dtColegiados, ref error))
            {
                dgvColegiados.Rows.Clear();
                if (dtColegiados.Rows.Count > 0)
                {
                    foreach (DataRow row in dtColegiados.Rows)
                    {

                        dgvColegiados.Rows.Add(row["NumeroColegiado"].ToString(), row["IdColegiado"].ToString(),
                                    row["Nombre"].ToString());
                    }

                    if (dgvColegiados.RowCount > 0)
                    {
                        dgvColegiados.CurrentCell = dgvColegiados[0, 0];
                        //cargarInfoEstablecimiento(dgvEstablecimientos[0, 0].Value.ToString());
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listaCamposAccion()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoCampo as Codigo, NombreCampo as Nombre, DescripcionCampo as Descripcion";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_CAMPOS_ACCION";
            listP.COLUMNAS_PK.Add("CodigoCampo");

            listP.ORDERBY = "order by CodigoCampo";
            listP.TITULO_LISTADO = "Campos de Acción";
            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                dgvCamposAccion.CurrentCell.OwningRow.Cells["colCodigoCampo"].Value = f1.item.SubItems[0].Text;
                dgvCamposAccion.CurrentCell.OwningRow.Cells["colNombreCampo"].Value = f1.item.SubItems[1].Text;
                dgvCamposAccion.CurrentCell.OwningRow.Cells["colDescripcionCampo"].Value = f1.item.SubItems[2].Text;
                dgvCamposAccion.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void listaColegiados()
        {
            Listado listP = new Listado();
            //listP.COLUMNAS = "(select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as NumCole,(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as NomColegiado,t1.NumeroColegiado as 'Num'";
            //listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //listP.TABLA = "NV_COLEGIADO t1";
            //listP.FILTRO = "where AvaluoCursos = 'S'";
            //listP.ORDERBY = "order by t1.NumeroColegiado";
            //listP.COLUMNAS_PK.Add("NumeroColegiado");
            //listP.COLUMNAS_ALIAS_PK.Add("Num");
            //listP.COLUMNAS_OCULTAS.Add("Num");
            listP.COLUMNAS = "NumeroColegiado as [Numero Colegiado], Nombre, IdColegiado as 'Num'";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO ";
            listP.FILTRO = "where Condicion not in (select CodigoCondicion from "+ Consultas.sqlCon.COMPAÑIA +".NV_CONDICIONES where GeneraCobro = 'NO')";
            listP.ORDERBY = "order by NumeroColegiado";
            listP.COLUMNAS_PK.Add("NumeroColegiado");
            listP.COLUMNAS_ALIAS_PK.Add("Num");
            listP.COLUMNAS_OCULTAS.Add("Num");


            listP.TITULO_LISTADO = "Profesionales Responsables";

            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
              
                dgvColegiados.CurrentCell.OwningRow.Cells["colNumeroColegiado"].Value = f1Colegiado.item.SubItems[0].Text;
                dgvColegiados.CurrentCell.OwningRow.Cells["colCodigoColegiado"].Value = f1Colegiado.item.SubItems[2].Text;
                dgvColegiados.CurrentCell.OwningRow.Cells["colNombreColegiado"].Value = f1Colegiado.item.SubItems[1].Text;
                dgvColegiados.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
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

        private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaProvincias();
        }

        private void txtProvincia_Leave(object sender, EventArgs e)
        {
            buscaProvincia(txtProvincia.Valor);
        }

        private void txtProvincia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaProvincias();
        }

        private void txtDistrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaDistritos();
        }

        private void txtDistrito_Leave(object sender, EventArgs e)
        {
            buscaDistrito(txtDistrito.Valor);
        }

        private void txtDistrito_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaDistritos();
        }

        private void txtCanton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCantones();
        }

        private void txtCanton_Leave(object sender, EventArgs e)
        {
            buscaCanton(txtCanton.Valor);
        }

        private void txtCanton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCantones();
        }

        private void frmConsultorasEdicion_Load(object sender, EventArgs e)
        {
            rtbDireccion.Mayuscula = true;
            txtNombre.Mayusculas();
            btnProcesar.Visible = true;
            //btnProcesar.Enabled = false;
        }

        private void btnCampoAccion_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CONSULTORA_EDITAR))
            {
                dgvCamposAccion.Rows.Add("", "", "");
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void dgvCamposAccion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvCamposAccion.CurrentRow != null)
            {
                if (dgvCamposAccion.CurrentCell.Value.ToString().Equals("") && (dgvCamposAccion.CurrentCell.OwningColumn.Name == "colCodigoCampo" || dgvCamposAccion.CurrentCell.OwningColumn.Name == "colNombreCampo"))
                {
                    listaCamposAccion();
                }
            }
                
        }

        private void dgvColegiados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvColegiados.CurrentRow != null)
            {
                if (dgvColegiados.CurrentCell.Value.ToString().Equals("") && (dgvColegiados.CurrentCell.OwningColumn.Name == "colNumeroColegiado" || dgvColegiados.CurrentCell.OwningColumn.Name == "colCodigoColegiado" || dgvColegiados.CurrentCell.OwningColumn.Name == "colNombreColegiado"))
                {
                    listaColegiados();
                }
            }
                
        }

        private void btnNuevoColegiado_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CONSULTORA_EDITAR))
            {
                dgvColegiados.Rows.Add("", "", "");
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnEliminaCampoAccion_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CONSULTORA_BORRAR))
            {
                if (dgvCamposAccion.RowCount > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_CONSULTORAS_CAMPOS_ACCION WHERE CodigoConsultora = '" + txtCodigo.Valor + "' AND CodigoCampo = '"
                            + dgvCamposAccion.CurrentCell.OwningRow.Cells["colCodigoCampo"].Value.ToString() + "'";

                        if (Consultas.ejecutarSentencia(sQuery, ref error))
                        {
                            dgvCamposAccion.Rows.Remove(dgvCamposAccion.CurrentCell.OwningRow);
                        }
                        else
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnEliminarColegiado_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CONSULTORA_BORRAR))
            {
                if (dgvColegiados.RowCount > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_CONSULTORAS_COLEGIADO WHERE CodigoConsultora = '" + txtCodigo.Valor + "' AND IdColegiado = '"
                            + dgvColegiados.CurrentCell.OwningRow.Cells["colCodigoColegiado"].Value.ToString() + "'";

                        if (Consultas.ejecutarSentencia(sQuery, ref error))
                        {
                            dgvColegiados.Rows.Remove(dgvColegiados.CurrentCell.OwningRow);
                        }
                        else
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void listaCobradores(string identificador)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "Cobrador,Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "COBRADOR";
            listP.ORDERBY = "order by Cobrador";
            listP.TITULO_LISTADO = "Cobradores";
            frmF1 f1Cobrador = new frmF1(listP);
            f1Cobrador.ShowDialog();
            if (f1Cobrador.item != null)
            {
                //if (identificador == "regentes")
                //{
                //    dgvRegentes.CurrentCell.Value = f1Cobrador.item.SubItems[1].Text;
                //    dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoCobrador"].Value = f1Cobrador.item.SubItems[0].Text;
                //    dgvRegentes.EndEdit();
                //}
                //else
                //{
                    txtCobrador.Valor = f1Cobrador.item.SubItems[0].Text;
                    txtCobradorNombre.Valor = f1Cobrador.item.SubItems[1].Text;
                //}
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void buscaCobrador(string codigo)
        {

            if (txtCobrador.Valor.Trim() == "")
            {
                txtCobradorNombre.Clear();
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
                    txtCobradorNombre.Valor = dtCobrador.Rows[0]["Nombre"].ToString();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El código de cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCobrador.Clear();
                        txtCobradorNombre.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtCobrador_Leave(object sender, EventArgs e)
        {
            buscaCobrador(txtCobrador.Valor);
        }

        private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCobradores("cobrador");
        }

        private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCobradores("cobrador");
        }
    }
}
