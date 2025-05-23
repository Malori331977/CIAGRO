using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class frmEstablecimientosEdicion : frmEdicion
    {
        private FuncsInternas fInternas;
        private DateTimePicker dtp = new DateTimePicker();
        private string NumeroColeg = "";
        //private int AñoCobro = 0;
        //private int AñoCobroActualizado = 0;
        private bool estadoCerrado = false;
        bool crearHistorialCanon = false, validarFechas = false;
        private bool requiereRevisionEstado = false;
        private bool CambioEnCategorias = false;

        public frmEstablecimientosEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            dtpFecha.Value = DateTime.Now;
            dtpDesdeTemporal1.Value = DateTime.Now;
            dtpHastaTemporal1.Value = DateTime.Now.AddDays(1);
            dtpFechaCanon.Value = DateTime.Now;
            btnProcesar.Visible = true;
            listaEstados();
            //rbNo.Checked = true;
            if(cmbEstado.Count>0)
               cmbEstado.Index = 0;
            cargarDatos();
            cmbEstado.SelectedValueChanged(new EventHandler(OnEstadoChanged));
            validarFechas = true;
            if (Consultas.tienePrivilegios(Consultas.Usuario,Constantes.ELIMINAR_REG_ESTABLES))
            {
                btnEliminaCategoria.Visible = true;
                btnEliminaInforme.Visible = true;
                btnEliminarRegente.Visible = true;
                btnEliminaVisita.Visible = true;
            }
        }

        public frmEstablecimientosEdicion(List<string> valoresPk,string NumeroCole)
            : base(valoresPk)
        {
            NumeroColeg = NumeroCole;
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            dtpFecha.Value = DateTime.Now;
            dtpDesdeTemporal1.Value = DateTime.Now;
            dtpHastaTemporal1.Value = DateTime.Now.AddDays(1);
            dtpFechaCanon.Value = DateTime.Now;
            btnProcesar.Visible = true;
            listaEstados();
            //rbNo.Checked = true;
            if (cmbEstado.Count > 0)
                cmbEstado.Index = 0;
            cmbEstado.SelectedValueChanged(new EventHandler(OnEstadoChanged));
            cargarDatos();
            validarFechas = true;
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ELIMINAR_REG_ESTABLES))
            {
                btnEliminaCategoria.Visible = true;
                btnEliminaInforme.Visible = true;
                btnEliminarRegente.Visible = true;
                btnEliminaVisita.Visible = true;
            }
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Administración de Establecimientos";
                lblPerfil.Text = "Perfil de Establecimiento";

                listar.COLUMNAS = "CedulaJuridica,NumRegistro,NumInscripcion,Fecha,PagaCanon,Nombre,Representante,Actividades,Telefono,Fax," +
                    "Apartado,Email,EmailAdicional,Provincia,Canton,Distrito,Direccion,Estado,Cobrador,FechaCierre,SesionAprobacionCierre,FechaDesdeCierreTemp,FechaHastaCierreTemp,CoordenadaN,CoordenadaW,Cvo,VencimientoCvo,Pfms,VencimientoPfms,FechaCanon";

                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_ESTABLECIMIENTOS";

                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("NumRegistro");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);
                identificadorFormulario = "De Establecimientos";

                insertar = Constantes.ESTABLECIMIENTO_INSERTAR;
                editar = Constantes.ESTABLECIMIENTO_EDITAR;
                borrar = Constantes.ESTABLECIMIENTO_BORRAR;
                seleccionar = Constantes.ESTABLECIMIENTO_SELECCIONAR;
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

            txtCedulaJuridica.Valor = "ND";

            if (valoresPk.Count > 0)
            {
                if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        //if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.EDICION_NUM_ESTABLECIMIENTO))
                        //    txtNumRegistro.ReadOnly = false;
                        //else
                        //    txtNumRegistro.ReadOnly = true;

                        foreach (DataRow row in dtDatos.Rows)
                        {
                            if(!row["CedulaJuridica"].ToString().Equals(""))
                                txtCedulaJuridica.Valor = row["CedulaJuridica"].ToString();
                            txtNumRegistro.Valor = row["NumRegistro"].ToString();
                            txtNumInscripcion.Valor = row["NumInscripcion"].ToString();
                            if (!String.IsNullOrEmpty(row["Fecha"].ToString()))
                                dtpFecha.Value = DateTime.Parse(row["Fecha"].ToString());
                            txtNombre.Valor = row["Nombre"].ToString();
                            txtRepresentante.Valor = row["Representante"].ToString();
                            if (row["PagaCanon"].ToString() == "S")
                                rbSi.Checked = true;
                            else
                                rbNo.Checked = true;

                            // txtHorario.Valor = row["Horario"].ToString();
                            rtbActividades.Text = row["Actividades"].ToString();
                            txtTelefono.Valor = row["Telefono"].ToString();
                            txtFax.Valor = row["Fax"].ToString();
                            txtApartado.Valor = row["Apartado"].ToString();
                            txtEmail.Valor = row["Email"].ToString();
                            txtEmailAdicional.Valor = row["EmailAdicional"].ToString();
                            cmbEstado.Valor = row["Estado"].ToString();
                            if (!cmbEstado.Valor.Equals(""))
                            {
                                if (!string.IsNullOrEmpty(row["FechaDesdeCierreTemp"].ToString()))
                                    dtpDesdeTemporal1.Value = DateTime.Parse(row["FechaDesdeCierreTemp"].ToString());
                                if (!string.IsNullOrEmpty(row["FechaHastaCierreTemp"].ToString()))
                                    dtpHastaTemporal1.Value = DateTime.Parse(row["FechaHastaCierreTemp"].ToString());
                                //verificarConfigurablesEstado();
                            }
                                
                            txtProvincia.Valor = row["Provincia"].ToString();
                            if(txtProvincia.Valor!="")
                                buscaProvincia(txtProvincia.Valor);

                            txtCanton.Valor = row["Canton"].ToString();
                            if(txtCanton.Valor!="")
                                buscaCanton(txtCanton.Valor);

                            txtDistrito.Valor = row["Distrito"].ToString();
                            if(txtDistrito.Valor!="")
                                buscaDistrito(txtDistrito.Valor);

                            rtbDireccion.Text = row["Direccion"].ToString();

                            txtCobrador.Valor = row["Cobrador"].ToString();
                            if(txtCobrador.Valor!="")
                                buscaCobrador(txtCobrador.Valor);

                            if (!String.IsNullOrEmpty(row["SesionAprobacionCierre"].ToString()))
                            {
                                txtSesionCierre.Valor = row["SesionAprobacionCierre"].ToString();
                                //dtpFechaCierre.Value = DateTime.Parse(row["FechaCierre"].ToString());
                            }
                            if (!String.IsNullOrEmpty(row["FechaCierre"].ToString()))
                            {
                                //txtSesionCierre.Valor = row["SesionAprobacionCierre"].ToString();
                                dtpFechaCierre.Checked = true;
                                dtpFechaCierre.Value = DateTime.Parse(row["FechaCierre"].ToString());
                            }

                            txtCoordenadaN.Valor = row["CoordenadaN"].ToString();
                            txtCoordenadaW.Valor = row["CoordenadaW"].ToString();

                            if (!String.IsNullOrEmpty(row["Cvo"].ToString()))
                            {
                                txtCVO.Valor = row["Cvo"].ToString();
                            }
                            if (!String.IsNullOrEmpty(row["VencimientoCvo"].ToString()))
                            {
                                dtpVencimientoCVO.Checked = true;
                                dtpVencimientoCVO.Value = DateTime.Parse(row["VencimientoCvo"].ToString());
                            }

                            if (!String.IsNullOrEmpty(row["Pfms"].ToString()))
                            {
                                txtPFMS.Valor = row["Pfms"].ToString();
                            }
                            if (!String.IsNullOrEmpty(row["VencimientoPfms"].ToString()))
                            {
                                dtpVencimientoPFMS.Checked = true;
                                dtpVencimientoPFMS.Value = DateTime.Parse(row["VencimientoPfms"].ToString());
                            }

                            if (!String.IsNullOrEmpty(row["FechaCanon"].ToString()))
                                dtpFechaCanon.Value = DateTime.Parse(row["FechaCanon"].ToString());

                            if (requiereRevisionEstado)
                            {
                                revisarRegresoEstado();
                            }

                        }
                    }

                    verificarEstadoCanon();
                    //if (habilitarProceso)
                    //{
                    //    btnProcesar.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnProcesar.Enabled = false;
                    //}
                    deshabilitarLlave();
                    cargarHorarios();
                    cargarCategorias();
                    cargarRegentes();
                    cargarInformes();
                    cargarVisitasFiscalia();
                    verificarConfigurablesEstado();
                }
            }
        }

        private void cargarHorarios()
        {
            DataTable dt = new DataTable();
            string sQuery = "SELECT Id,Dia,HoraInicio,HoraFin from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_HORARIOS WHERE CodigoEstablecimiento='" + txtNumRegistro.Valor + "'";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                dgvHorarios.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string dia = "", horaInicio = "", minInicio = "", tipoInicio = "", horaFin = "", minFin = "", tipoFin = "";
                    if (row["Dia"].ToString() == "2")
                        dia = "Lunes";

                    if (row["Dia"].ToString() == "3")
                        dia = "Martes";

                    if (row["Dia"].ToString() == "4")
                        dia = "Miércoles";

                    if (row["Dia"].ToString() == "5")
                        dia = "Jueves";

                    if (row["Dia"].ToString() == "6")
                        dia = "Viernes";

                    if (row["Dia"].ToString() == "7")
                        dia = "Sábado";

                    if (row["Dia"].ToString() == "1")
                        dia = "Domingo";

                    string[] minutosIni = row["HoraInicio"].ToString().Split(' ');
                    string[] minutosFin = row["HoraFin"].ToString().Split(' ');

                    horaInicio = minutosIni[1].Split(':')[0];
                    minInicio = minutosIni[1].Split(':')[1];
                    tipoInicio = minutosIni[2];
                    tipoFin = minutosFin[2];

                    horaFin = minutosFin[1].Split(':')[0];
                    minFin = minutosFin[1].Split(':')[1];

                    string param = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern;
                    if (!param.Equals("hh:mm:ss tt"))
                    {
                        //Se comenta pues el formato requerido es hhmmss tt
                        if (int.Parse(horaInicio) < 10)
                            horaInicio = "0" + horaInicio;

                        if (int.Parse(horaFin) < 10)
                            horaFin = "0" + horaFin;
                    }

                    dgvHorarios.Rows.Add(row["Id"].ToString(), dia, horaInicio, minInicio, tipoInicio, horaFin, minFin, tipoFin);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarCategorias()
        {
            //string sQuery = "SELECT CodigoCategoria,NombreCategoria FROM " + Consultas.sqlCon.COMPAÑIA +
            //    ".NV_ESTABLECIMIENTOS_CATEGORIAS WHERE NumRegistroEstablecimiento='" + txtNumRegistro.Valor + "'";

            string sQuery = "SELECT t1.CodigoCategoria,t2.NombreCategoria, t1.Estado" +
                   " FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS t1" +
                   " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS t2 ON t1.CodigoCategoria = t2.CodigoCategoria" +
                   " WHERE t1.NumRegistroEstablecimiento = '" + txtNumRegistro.Valor + "'";

            DataTable dtCategorias = new DataTable();
            if (Consultas.fillDataTable(sQuery, ref dtCategorias, ref error))
            {
                foreach (DataRow row in dtCategorias.Rows)
                {
                    dgvCategorias.Rows.Add(row["CodigoCategoria"].ToString(), row["NombreCategoria"].ToString(), fInternas.obtenerEstado(row["Estado"].ToString()));
                }

                colorearFilasCategorias();
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void verificarEstadoCanon()
        {
            DataTable dtCliente = new DataTable();
            bool lbOk = true;
            int añoActual = DateTime.Now.Year;

            string sSelectCl = "select PedidoEstablecimiento from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION where Identificador = '" + txtNumRegistro.Valor + "' and Canon = 'estable'";

            lbOk = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);

            if (lbOk && dtCliente.Rows.Count > 0)
            {
                if (dtCliente.Rows[0]["PedidoEstablecimiento"].ToString() == "S")
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

        private void inactivarRegentes()
        {
            bool existeActivo = false;
            if (dgvRegentes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvRegentes.Rows)
                {
                    if (row.Cells["colEstado"].Value.Equals("Activo"))
                    {
                        existeActivo = true;
                        row.Cells["colEstado"].Value = "Inactivo";
                    }
                }

                if (existeActivo)
                {
                    MessageBox.Show("Se cambio el estado de los regentes a Inactivo, debido al estado del establecimiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
            }
        }

        private void activarRegentes()
        {
            if (dgvRegentes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvRegentes.Rows)
                {
                    row.Cells["colEstado"].Value = "Activo";
                }

                MessageBox.Show("Se cambio el estado de los regentes a Activo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void verificarConfigurablesEstado()
        {
            DataTable dt = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "RequiereRegresoEstado,EsEstadoCierre";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where CodigoEstado = '" + cmbEstado.Valor + "'";
            //listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["RequiereRegresoEstado"].ToString() == "S")
                    {
                        dtpDesdeTemporal1.Visible = true;
                        lblDesdeTemporal.Visible = true;
                        dtpHastaTemporal1.Visible = true;
                        lblHastaTemporal.Visible = true;
                        requiereRevisionEstado = true;
                        inactivarRegentes();
                        //revisarRegresoCondicion();
                    }
                    else
                    {
                        dtpDesdeTemporal1.Visible = false;
                        lblDesdeTemporal.Visible = false;
                        dtpHastaTemporal1.Visible = false;
                        lblHastaTemporal.Visible = false;
                    }

                    if (dt.Rows[0]["EsEstadoCierre"].ToString() == "S")
                    {
                        lblFechaCierre.Visible = true;
                        lblSesionCierre.Visible = true;
                        dtpFechaCierre.Visible = true;
                        txtSesionCierre.Visible = true;
                        estadoCerrado = true;
                        inactivarRegentes();
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

        private void revisarRegresoEstado()
        {
            bool OK = true;
            string estado = "";
            //DateTime fechaactual = DateTime.Now;
            ////DateTime FechDesde = new DateTime(dtpDesdeTemporal.Value.Year, dtpDesdeTemporal.Value.Month, dtpDesdeTemporal.Value.Day);
            //DateTime FechHasta = new DateTime(dtpHastaTemporal1.Value.Year, dtpHastaTemporal1.Value.Month, dtpHastaTemporal1.Value.Day);
            //fechaactual = new DateTime(fechaactual.Year, fechaactual.Month, fechaactual.Day);

            //int result = DateTime.Compare(FechHasta, fechaactual);
            int result = DateTime.Compare(dtpHastaTemporal1.Value.Date,DateTime.Today);
            if (result <= 0)
            {
                Consultas.sqlCon.iniciaTransaccion();
                DataTable dt = new DataTable();
                DataTable dtSelect = new DataTable();
                DataTable dtPlantilla = new DataTable();

                #region OBTENER_ESTADO_REGRESO
                string sQuery = "select EstadoRegreso from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTADOS WHERE CodigoEstado = '" + cmbEstado.Valor + "'";

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
                    parametros.Add("@NumReg," + txtNumRegistro.Valor);


                    OK = Consultas.ejecutarSentenciaParametros(sUpdate, parametros, ref error);

                }
                #endregion

                
                if (OK)
                {
                    dt = new DataTable();
                    sQuery = "select Estado from "+Consultas.sqlCon.COMPAÑIA+".NV_ESTABLECIMIENTOS where NumRegistro = '"+txtNumRegistro.Valor+"'";

                    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cmbEstado.Valor = dt.Rows[0]["Estado"].ToString();
                        }
                    }
                    else
                        OK = false;

                    dtpDesdeTemporal1.Value = DateTime.Now;
                    dtpDesdeTemporal1.Visible = false;
                    lblDesdeTemporal.Visible = false;
                    dtpHastaTemporal1.Value = DateTime.Now;
                    dtpHastaTemporal1.Visible = false;
                    lblHastaTemporal.Visible = false;
                }

                if (OK)
                {
                    Consultas.sqlCon.Commit();
                    MessageBox.Show("Se realizó el cambio de estado temporal del establecimiento", "Nota Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    Consultas.sqlCon.Rollback();

            }
        }

        protected override bool generarFacturas(ref string error)
        {
            decimal montoDesc = 0;
            int porcDescuento = 0, indiceArticulo = 0;
            bool pedidoPorConcepto = false, OK = true;
            string sQuery = "", factura = "", comentario = "";
            int AñoCobro = DateTime.Now.Year;
            DataTable dtArticulos = new DataTable();
            //int AñoCobro = DateTime.Now.AddYears(1).Year;
            if (DateTime.Now.Month >= 9 )//Si es octubre o mayor se cobra el siguiente año
                AñoCobro = DateTime.Now.AddYears(1).Year;

            sQuery = "SELECT TOP 1 t3.ARTICULO, t3.DESCRIPCION,t4.PRECIO, '1' as CANTIDAD, t1.NombreCategoria FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ESTABLE_ART t2 ON t2.CodigoCategoria = t1.CodigoCategoria" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                        " WHERE t1.NumRegistroEstablecimiento = '" + txtNumRegistro.Valor + "'" +
                        " AND t4.PRECIO = (SELECT MAX(PRECIO) FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS t1" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ESTABLE_ART t2 ON t2.CodigoCategoria = t1.CodigoCategoria" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t2.CodigoArticulo" +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                        " WHERE t1.NumRegistroEstablecimiento = '" + txtNumRegistro.Valor + "')";



            
            if (Consultas.fillDataTable(sQuery, ref dtArticulos, ref error))
            {
                if (dtArticulos.Rows.Count > 0)
                {
                    if (OK)
                        OK = fInternas.verificarAceptaDocElectronicoClienteERP(txtNumRegistro.Valor, ref error);

                    comentario = "Canon inscripción " + AñoCobro + "-" + dtArticulos.Rows[0]["NombreCategoria"].ToString() + "";
                    //string observacion = "Canon inscripción " + AñoCobro + "-" + dtArticulos.Rows[0]["NombreCategoria"].ToString();
                    if (OK)
                        OK = controlerBD.crearPedidoGenerico(dtArticulos, txtNumRegistro.Valor, ref factura /*pedido*/, montoDesc, porcDescuento, pedidoPorConcepto, indiceArticulo, txtCobrador.Valor, "C_A", "PEDIDOS", "EST", comentario, "", ref error);
                    //if (OK)
                    //    OK = controlerBD.FacturarSinPedido(dtArticulos, txtNumRegistro.Valor, ref factura, montoDesc, porcDescuento, true, indiceArticulo, txtCobrador.Valor, "C_A", "FACTURAS", "EST", observacion, string.Empty, string.Empty, string.Empty, ref error);

                }
                else
                {
                    OK = false;
                    error = "El establecimiento no tiene articulos para la generacion del pedido";
                }
            }
            else
                OK = false;
            


            if (OK)
            {
                //DateTime ultimoCobro = new DateTime(AñoCobroActualizado, 1, 1);
                //OK = actualizarUltAñoCobro(txtNumRegistro.Valor, ultimoCobro, ref error);
                
                if (crearHistorialCanon)
                {
                    string sUpdateCanones = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION (Identificador, Canon, PedidoEstablecimiento, NumeroEstablecimiento) VALUES ('"+txtNumRegistro.Valor+"', 'estable', 'S', '" + factura + "')";
                    
                    OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);
                }
                else
                {
                    string sUpdateCanones = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_INSCRIPCION SET PedidoEstablecimiento = 'S', NumeroEstablecimiento = '" + factura + "' WHERE Identificador = '" + txtNumRegistro.Valor + "' and Canon = 'estable'";

                    OK = Consultas.ejecutarSentencia(sUpdateCanones, ref error);
                }
            }

            return OK;
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

        //    sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + id + "' and Canon = 'ESTABLE'";

        //    OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

        //    if (OK && dt.Rows.Count > 0)
        //    {
        //        sUpdate = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES set AñoUltimoCobro = '" + año + "' where Identificador = '" + id + "' and Canon = 'ESTABLE'";

        //        OK = Consultas.ejecutarSentencia(sUpdate, ref error);
        //    }
        //    else
        //    {
        //        sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon, AñoUltimoCobro) values ('" + id + "', 'ESTABLE', '" + año + "')";

        //        OK = Consultas.ejecutarSentencia(sInsert, ref error);
        //    }

        //    return OK;
        //}

        private bool canonesAnuales(string id, ref string error)
        {
            bool OK = true;
            string sInsert = "";
            string sSelect = "";
            DateTime mesUltCobro = DateTime.Now;
            DataTable dt = new DataTable();

            
            sSelect = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES where Identificador = '" + id + "' and Canon = 'ESTABLE'";

            OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

            if (OK && dt.Rows.Count == 0)
            {
                sInsert = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_HISTORIAL_CANONES_ANUALES (Identificador, Canon) values ('" + id + "', 'ESTABLE')";

                OK = Consultas.ejecutarSentencia(sInsert, ref error);
            }

            return OK;
        }

        private bool validarEstado()
        {
            DataTable dtEstados = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "GeneraCobro";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where Diferenciador = 'E' and CodigoEstado = '"+cmbEstado.Valor+"'";
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

        protected override bool validarDatosPedidos(ref string error)
        {
            //bool OK = true;
            if (btnGuardar.Enabled)
            {
                error = "Debe guardar los cambios realizados.";
                return false;
            }

            if (!validarEstado())
            {
                error = "El estado actual no genera cobro.";
                return false;
            }
            
            if (!rbSi.Checked)
            {
                error = "Esta consultora no paga canon.";
                return false;
            }

            if (txtCedulaJuridica.Valor == "")
            {
                error = "Debe ingresar una cédula jurídica.";
                return false;
            }

            return true;
        }

        private void cargarRegentes()
        {
            dgvRegentes.Rows.Clear();
            //string sQuery = "SELECT T1.NumeroColegiado,T2.NumeroColegiado as NCole,T2.Nombre,T3.NombreCategoria,T3.CodigoCategoria,t1.Cobrador,t4.NOMBRE as NomCobrador,T1.FechaAprobacion,T1.SesionAprobacion,CASE T1.Estado WHEN 'A' THEN 'Activo' else 'Inactivo' END AS Estado FROM " + Consultas.sqlCon.COMPAÑIA +
            string sQuery = "SELECT T1.NumeroColegiado,T2.NumeroColegiado as NCole,T2.Nombre,T3.NombreCategoria,T3.CodigoCategoria,t1.Cobrador,t4.NOMBRE as NomCobrador,T1.FechaAprobacion,T1.SesionAprobacion,T1.Estado FROM " + Consultas.sqlCon.COMPAÑIA +
                ".NV_REGENTES_ESTABLECIMIENTOS T1 JOIN " +Consultas.sqlCon.COMPAÑIA+".NV_COLEGIADO T2 ON T1.NumeroColegiado=T2.IdColegiado "+
                "JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS T3 ON T1.CodigoCategoria=T3.CodigoCategoria LEFT JOIN "+Consultas.sqlCon.COMPAÑIA+".COBRADOR T4 ON T1.Cobrador=T4.COBRADOR WHERE T1.CodigoEstablecimiento='" + txtNumRegistro.Valor + "'";

            DataTable dtRegentes = new DataTable();
            if (Consultas.fillDataTable(sQuery, ref dtRegentes, ref error))
            {
                foreach (DataRow row in dtRegentes.Rows)
                {
                    
                    dgvRegentes.Rows.Add(row["NumeroColegiado"].ToString(), row["NCole"].ToString(), row["Nombre"].ToString(),
                        row["FechaAprobacion"].ToString()!=""? DateTime.Parse(row["FechaAprobacion"].ToString()).ToString("dd/MM/yyyy") : "",
                        row["SesionAprobacion"].ToString(), row["NombreCategoria"].ToString(), row["CodigoCategoria"].ToString(), row["Cobrador"].ToString(), row["NomCobrador"].ToString(), /*row["Estado"].ToString()*/fInternas.obtenerEstado(row["Estado"].ToString()));
                }
                
                if (!string.IsNullOrEmpty(NumeroColeg))
                    cargarRegentesDesdeColegiado();
                colorearFilas();
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarRegentesDesdeColegiado()
        {
            string sQuery = "SELECT IdColegiado,NumeroColegiado as NCole,Nombre FROM " + Consultas.sqlCon.COMPAÑIA +
                ".NV_COLEGIADO WHERE IdColegiado='" + NumeroColeg + "'";

            DataTable dtRegentes = new DataTable();
            if (Consultas.fillDataTable(sQuery, ref dtRegentes, ref error))
            {
                foreach (DataRow row in dtRegentes.Rows)
                {
                        dgvRegentes.Rows.Add(row["IdColegiado"].ToString(), row["NCole"].ToString(), row["Nombre"].ToString(), "", "", "", "");
                }

                
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarInformes()
        {
            StringBuilder errores = new StringBuilder();
            try
            {
                DataTable dt = new DataTable();
              
               string sQuery = "SELECT t1.Id,t1.NumeroColegiado,t2.NumeroColegiado as NumCole,t2.Nombre,t1.FechaInforme,t1.Observaciones FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES t1 "+
                    " JOIN "+Consultas.sqlCon.COMPAÑIA+".NV_COLEGIADO t2 ON t2.IdColegiado = t1.NumeroColegiado "+
                    " WHERE t1.CodigoEstablecimiento='" + txtNumRegistro.Valor + "' order by FechaInforme asc";

           

                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    dgvInformes.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvInformes.Rows.Add(row["Id"].ToString(), row["NumeroColegiado"].ToString(), row["NumCole"].ToString(), row["Nombre"].ToString(), DateTime.Parse(row["FechaInforme"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                    }
                }
                else
                    errores.AppendLine(error);

                if (errores.ToString() != "")
                {
                    MessageBox.Show("Ocurrieron los siguientes errores:\n" + errores.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarVisitasFiscalia()
        {
            StringBuilder errores = new StringBuilder();
            try
            {
                string sQuery = "SELECT t1.Id,t1.NumeroColegiado,t2.NumeroColegiado as NumCole,t2.Nombre,t1.FechaVisita,t1.Observaciones FROM " + Consultas.sqlCon.COMPAÑIA +
                    ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC t1" +
                    " JOIN " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO t2 ON t2.IdColegiado = t1.NumeroColegiado " +
                    " WHERE t1.CodigoEstablecimiento='" + txtNumRegistro.Valor + "' order by t1.FechaVisita asc";

                DataTable dt = new DataTable();

                if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                {
                    dgvVisitasFisc.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvVisitasFisc.Rows.Add(row["Id"].ToString(), row["NumeroColegiado"].ToString(), row["NumCole"].ToString(), row["Nombre"].ToString(), DateTime.Parse(row["FechaVisita"].ToString()).ToString("dd/MM/yyyy"), row["Observaciones"].ToString());
                    }
                }
                else
                    errores.AppendLine(error);

                if (errores.ToString() != "")
                {
                    MessageBox.Show("Ocurrieron los siguientes errores:\n" + errores.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool llenarParametros()
        {
            dgvRegentes.EndEdit();
            parametros.Clear();
            //string consecutivo = "";
            //if (valoresPk.Count == 0)
            //{
            //    consecutivo = this.fInternas.generarConsecutivo(Globales.CONSECUTIVO_ESTABLECIMIENTO, ref error);

            //    if (consecutivo == "")
            //    {
            //        MessageBox.Show("No se pudo generar el consecutivo del establecimiento, verifique que este definido correctamente en las globales del sistema.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return false;
            //    }

            //    if (!this.fInternas.actualizarConsecutivo(this.fInternas.sgtValor(consecutivo), Globales.CONSECUTIVO_ESTABLECIMIENTO, ref error))
            //    {
            //        MessageBox.Show("No se pudo actualizar el consecutivo del establecimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        return false;
            //    }

            //    txtNumRegistro.Valor = consecutivo;
            //}

            parametros.Add(txtCedulaJuridica.Valor);
            parametros.Add(txtNumRegistro.Valor);
            parametros.Add(txtNumInscripcion.Valor);
            parametros.Add(dtpFecha.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            if (rbSi.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");
            parametros.Add(txtNombre.Valor);
            parametros.Add(txtRepresentante.Valor);
            //parametros.Add(txtHorario.Valor);
            parametros.Add(rtbActividades.Text);
            parametros.Add(txtTelefono.Valor);
            parametros.Add(txtFax.Valor);
            parametros.Add(txtApartado.Valor);
            parametros.Add(txtEmail.Valor);
            parametros.Add(txtEmailAdicional.Valor);
            parametros.Add(txtProvincia.Valor);
            parametros.Add(txtCanton.Valor);
            parametros.Add(txtDistrito.Valor);
            parametros.Add(rtbDireccion.Text);
            if(!cmbEstado.Valor.Equals(""))
                parametros.Add(cmbEstado.Valor);
            else
                parametros.Add("null");

            parametros.Add(txtCobrador.Valor);

            if (dtpFechaCierre.Checked && estadoCerrado)
                parametros.Add(dtpFechaCierre.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (txtSesionCierre.Valor != "" && estadoCerrado)
                parametros.Add(txtSesionCierre.Valor);
            else
                parametros.Add("null");

            if (!dtpDesdeTemporal1.Equals("") && dtpDesdeTemporal1.Visible)
                parametros.Add(dtpDesdeTemporal1.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");
            if (!dtpHastaTemporal1.Equals("") && dtpHastaTemporal1.Visible)
                parametros.Add(dtpHastaTemporal1.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            parametros.Add(txtCoordenadaN.Valor);
            parametros.Add(txtCoordenadaW.Valor);

            if (txtCVO.Valor != "")
                parametros.Add(txtCVO.Valor);
            else
                parametros.Add("null");

            if (dtpVencimientoCVO.Checked)
                parametros.Add(dtpVencimientoCVO.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (txtPFMS.Valor != "")
                parametros.Add(txtPFMS.Valor);
            else
                parametros.Add("null");

            if (dtpVencimientoPFMS.Checked)
                parametros.Add(dtpVencimientoPFMS.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            parametros.Add(dtpFechaCanon.Value.ToString("yyyy-MM-ddTHH:mm:ss"));

            return true;
        }

        protected override bool guardarDetalle(ref string error)
        {

            bool lbOk = true;

            /*MARLON LORIA SOLANO 15/05/2025
              SE DEBE VALIDAR SI SE REALIZAN CAMBION EN LAS REGENCIAS ASOCIADOS A CATEGORIAS INACTIVAS PARA QUE EMITA 
              UNA ADVERTENCIA EN CASO QUE SE REQUIERA HABILITAR UNA REGENCIA PARA UNA CATEGORIA INACTIVA.
              ESTA VALIDACION SOLO SE REALIZA SI NO SE HAN MODIFICADO LAS CATEGORIAS.  SI LAS CATEGORIAS HAN SIDO MODIFICADAS
              LA PRIORIDAD ES EL CAMBIO DE ESTADO DE LA CATEGORIA*/

            if (!CambioEnCategorias)
                lbOk = VerificaEstadoRegenciasVrsCategorias(ref error);

            if (lbOk)
                lbOk = guardarCategorias(ref error);

            if (lbOk)
                lbOk = guardarHorarios(ref error);

            if (lbOk)
                lbOk = guardarInformes(ref error);

            

            if (lbOk)
                lbOk = guardarRegentes(ref error);

            if (lbOk)
                lbOk = guardarVisitasFiscalia(ref error);

            if (lbOk)
                lbOk = canonesAnuales(txtNumRegistro.Valor,ref error);

            if (lbOk)
                lbOk = clienteERP(ref error);

            /*MARLON LORIA SOLANO 15/05/2025*/
            if (lbOk)
                CambioEnCategorias = false;

            return lbOk;
            //Listado list = new Listado();
            //list.COLUMNAS = "NumRegistroEstablecimiento,CodigoCategoria,NombreCategoria";
            //list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //list.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
            //bool lbOk = true;
            //try
            //{
            //    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS WHERE NumRegistroEstablecimiento='" + txtNumRegistro.Valor + "'";

            //    lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

            //    if (lbOk)
            //    {
            //        foreach (DataGridViewRow row in dgvCategorias.Rows)
            //        {
            //            parametros.Clear();
            //            list.COLUMNAS_PK.Add("NumRegistroEstablecimiento");
            //            list.COLUMNAS_PK.Add("CodigoCategoria");
            //            parametros.Add(txtNumRegistro.Valor);
            //            parametros.Add(row.Cells["colCodigoCategoria"].Value.ToString());
            //            parametros.Add(row.Cells["colDescripcionCat"].Value.ToString());
            //            lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    error = ex.Message;
            //    return false;
            //}
            //return lbOk;

        }

        private bool guardarHorarios(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "Id,CodigoEstablecimiento,Dia,HoraInicio,HoraFin";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_ESTABLECIMIENTOS_HORARIOS";
            bool lbOk = true;
            try
            {
                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_HORARIOS WHERE CodigoEstablecimiento='" + txtNumRegistro.Valor + "'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvHorarios.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("Id");
                        list.COLUMNAS_PK.Add("NumeroColegiado");
                        list.COLUMNAS_PK.Add("CodigoEstablecimiento");
                        parametros.Add(row.Cells["colIdHorario"].Value.ToString());
                        parametros.Add(txtNumRegistro.Valor);
                        int dia = 0;

                        if (row.Cells["colDia"].Value.ToString() == "Lunes")
                            dia = 2;
                        else
                            if (row.Cells["colDia"].Value.ToString() == "Martes")
                            dia = 3;
                        else
                            if (row.Cells["colDia"].Value.ToString() == "Miércoles")
                            dia = 4;
                        else
                            if (row.Cells["colDia"].Value.ToString() == "Jueves")
                            dia = 5;
                        else
                            if (row.Cells["colDia"].Value.ToString() == "Viernes")
                            dia = 6;
                        else
                            if (row.Cells["colDia"].Value.ToString() == "Sábado")
                            dia = 7;
                        else
                            dia = 1;

                        parametros.Add(dia + "");

                        string horaInicio = "";
                        string horaFin = "";

                        horaInicio += DateTime.Now.ToString("yyyy-MM-ddT") + row.Cells["colHoraInicio"].Value.ToString() + ":" +
                            row.Cells["colMinInicio"].Value.ToString() + ":00.000 " + row.Cells["colTipoInicio"].Value.ToString();

                        horaFin += DateTime.Now.ToString("yyyy-MM-ddT") + row.Cells["colHoraFin"].Value.ToString() + ":" +
                            row.Cells["colMinFin"].Value.ToString() + ":00.000 " + row.Cells["colTipoFin"].Value.ToString();

                        parametros.Add(horaInicio);
                        parametros.Add(horaFin);
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

        private bool guardarCategorias(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumRegistroEstablecimiento,CodigoCategoria,NombreCategoria,Estado";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
            bool lbOk = true;
            try
            {
                /*marlon loria.  No se deben eliminar las categorias de los establecimientos*/
            //string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS_CATEGORIAS WHERE NumRegistroEstablecimiento='" + txtNumRegistro.Valor + "'";

            //lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

            //if (lbOk)
            //{
            foreach (DataGridViewRow row in dgvCategorias.Rows)
                {
                        
                    parametros.Clear();
                    list.COLUMNAS_PK.Clear();
                    list.COLUMNAS_PK.Add("NumRegistroEstablecimiento");
                    list.COLUMNAS_PK.Add("CodigoCategoria");

                    parametros.Add(txtNumRegistro.Valor);
                    parametros.Add(row.Cells["colCodigoCategoria"].Value.ToString());
                    parametros.Add(row.Cells["colDescripcionCat"].Value.ToString());

                    switch (row.Cells["colEstadoCat"].Value.ToString())
                    {
                        case "Inactivo":
                            parametros.Add("I");
                            break;
                        case "Activo":
                            parametros.Add("A");
                            break;
                        case "Sin Regente":
                            parametros.Add("N");
                            break;
                    }

                    parametros.Add(txtNumRegistro.Valor);
                    list.FILTRO = " WHERE NumRegistroEstablecimiento='" + txtNumRegistro.Valor + "' AND CodigoCategoria='" + row.Cells["colCodigoCategoria"].Value.ToString() + "'";
                    
                    if (!ExisteCategoria(row.Cells["colCodigoCategoria"].Value.ToString(), txtNumRegistro.Valor))
                    {
                        lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);
                    }
                    else{
                        lbOk = Consultas.actualizar(parametros, list, identificadorFormulario, ref error);
                    }

                    foreach (DataGridViewRow rowReg in dgvRegentes.Rows)
                    {
                        if (rowReg.Cells["colCodCategoria"].Value.ToString() == row.Cells["colCodigoCategoria"].Value.ToString() &&
                            row.Cells["colEstadoCat"].Value.ToString().Substring(0, 1).ToString() == "I")
                        {
                            rowReg.Cells["colEstado"].Value = "Inactivo";
                        }
                        else
                        {
                            if (rowReg.Cells["colCodCategoria"].Value.ToString() == row.Cells["colCodigoCategoria"].Value.ToString() &&
                            row.Cells["colEstadoCat"].Value.ToString().Substring(0, 1).ToString() == "S")
                            {
                                rowReg.Cells["colEstado"].Value = "Inactivo";
                            }
                        }
                    }
                    colorearFilas();
                }
                    
                //}
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        private bool VerificaEstadoRegenciasVrsCategorias(ref string error)
        {
            error = "";
            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                foreach (DataGridViewRow rowReg in dgvRegentes.Rows)
                {
                    if (rowReg.Cells["colCodCategoria"].Value.ToString() == row.Cells["colCodigoCategoria"].Value.ToString() &&
                        (row.Cells["colEstadoCat"].Value.ToString().Substring(0, 1).ToString() == "I" || row.Cells["colEstadoCat"].Value.ToString().Substring(0, 1).ToString() == "S") &&
                        rowReg.Cells["colEstado"].Value.ToString().Substring(0, 1).ToString() == "A")
                    {
                        error = $"Existe una regencia en la categoría {rowReg.Cells["colNombreCategoria"].Value.ToString()} con estado ACTIVO, sin embargo esta categoría se encuentra en estado INACTIVA o SIN REGENTE para el establecimiento.  Para poder guardar el registro se debe activar la categoría o inactivar la regencia para esa categoría.";
                        return false;
                    }
                }
            }
            return true;
        }


        private bool ExisteCategoria(string categoria, string establecimiento)
        {
            DataTable dtCatEst = new DataTable();
            string sSelectCl = $"select * from {Consultas.sqlCon.COMPAÑIA}.NV_ESTABLECIMIENTOS_CATEGORIAS where CodigoCategoria = '{categoria}' and NumRegistroEstablecimiento='{establecimiento}'";

            var lbOk = Consultas.fillDataTable(sSelectCl, ref dtCatEst, ref error);

            if (lbOk && dtCatEst.Rows.Count > 0)
                return true;

            return false;
        }

        private bool guardarInformes(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "Id,NumeroColegiado,CodigoEstablecimiento,FechaInforme,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS_INFORMES";
            bool lbOk = true;
            try
            {
                //string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES WHERE NumeroColegiado='" + txtNumColegiado.Valor +
                //  "' AND CodigoEstablecimiento='" + dgvEstablecimientos.CurrentCell.OwningRow.Cells["colCodigoEstablecimiento"].Value.ToString() + "'";
                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES WHERE CodigoEstablecimiento='" + txtNumRegistro.Valor + "'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvInformes.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("Id");
                        list.COLUMNAS_PK.Add("NumeroColegiado");
                        list.COLUMNAS_PK.Add("CodigoEstablecimiento");
                        parametros.Add(row.Cells["colIdInforme"].Value.ToString());
                        parametros.Add(row.Cells["colNumeroColeInformes"].Value.ToString());
                        parametros.Add(txtNumRegistro.Valor);
                        parametros.Add(DateTime.Parse(row.Cells["colFechaInf"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

                        parametros.Add(row.Cells["colObservacionInf"].Value.ToString());
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

        //private bool guardarRegentes(ref string error)
        //{
        //    Listado list = new Listado();
        //    list.COLUMNAS = "NumeroColegiado,CodigoEstablecimiento,SesionAprobacion,FechaAprobacion,Estado,CodigoCategoria,Cobrador";
        //    list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
        //    bool lbOk = true;
        //    try
        //    {
                

        //        if (lbOk)
        //        {
        //            foreach (DataGridViewRow row in dgvRegentes.Rows)
        //            {
        //                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado='" + row.Cells["colCodigoRegente"].Value.ToString() + "' AND CodigoEstablecimiento = '"+ txtNumRegistro.Valor + "' AND CodigoCategoria = '"+ row.Cells["colCodCategoria"].Value.ToString() + "'";

        //                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

        //                parametros.Clear();
        //                list.COLUMNAS_PK.Add("NumeroColegiado");
        //                parametros.Add(row.Cells["colCodigoRegente"].Value.ToString());
        //                parametros.Add(txtNumRegistro.Valor);
        //                if (row.Cells["colSesionAprobacion"].Value.ToString() != "")
        //                {
        //                    parametros.Add(row.Cells["colSesionAprobacion"].Value.ToString());
        //                    parametros.Add(DateTime.Parse(row.Cells["colFechaAprobacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss.fff"));
        //                }
        //                else
        //                {
        //                    parametros.Add("null");
        //                    parametros.Add("null");
        //                }

        //                parametros.Add(row.Cells["colEstado"].Value.ToString()[0] + "");
        //                parametros.Add(row.Cells["colCodCategoria"].Value.ToString());
        //                if (!row.Cells["colCodigoCobrador"].Value.ToString().Equals(""))
        //                    parametros.Add(row.Cells["colCodigoCobrador"].Value.ToString());
        //                else
        //                    parametros.Add("null");


        //                lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

        //                if (lbOk && !row.Cells["colCodigoCobrador"].Value.ToString().Equals(""))
        //                    lbOk = fInternas.cambiarCobrador_CC(row.Cells["colCodigoRegente"].Value.ToString(), txtNumRegistro.Valor, row.Cells["colCodCategoria"].Value.ToString(), "REG", row.Cells["colCodigoCobrador"].Value.ToString(), ref error);

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

        private bool guardarRegentes(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumeroColegiado,CodigoEstablecimiento,SesionAprobacion,FechaAprobacion,Estado,CodigoCategoria,Cobrador";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
            bool lbOk = true;
            try
            {
                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvRegentes.Rows)
                    {
                        lbOk = fInternas.insertarHistorialRegencias(row.Cells["colCodigoRegente"].Value.ToString(), txtNumRegistro.Valor, row.Cells["colCodCategoria"].Value.ToString(), row.Cells["colEstado"].Value.ToString()[0].ToString(), ref error);

                        if (lbOk)
                        {
                            string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS WHERE NumeroColegiado='" + row.Cells["colCodigoRegente"].Value.ToString() + "' AND CodigoEstablecimiento = '" + txtNumRegistro.Valor + "' AND CodigoCategoria = '" + row.Cells["colCodCategoria"].Value.ToString() + "'";

                            lbOk = Consultas.ejecutarSentencia(sQuery, ref error);
                        }

                        if (lbOk)
                        {
                            parametros.Clear(); 
                            list.COLUMNAS_PK.Clear();
                            list.COLUMNAS_PK.Add("NumeroColegiado");
                            parametros.Add(row.Cells["colCodigoRegente"].Value.ToString());
                            parametros.Add(txtNumRegistro.Valor);
                            if (row.Cells["colSesionAprobacion"].Value.ToString() != "")
                            {
                                parametros.Add(row.Cells["colSesionAprobacion"].Value.ToString());
                                parametros.Add(DateTime.Parse(row.Cells["colFechaAprobacion"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                            }
                            else
                            {
                                parametros.Add("null");
                                parametros.Add("null");
                            }

                            parametros.Add(row.Cells["colEstado"].Value.ToString()[0] + "");
                            parametros.Add(row.Cells["colCodCategoria"].Value.ToString());
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
        private bool guardarVisitasFiscalia(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "Id,NumeroColegiado,CodigoEstablecimiento,FechaVisita,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC";
            bool lbOk = true;
            try
            {
                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC WHERE CodigoEstablecimiento ='" + txtNumRegistro.Valor + "'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    int cont = 1;  //indicador de numero de registro  
                    foreach (DataGridViewRow row in dgvVisitasFisc.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("Id");
                        list.COLUMNAS_PK.Add("NumeroColegiado");
                        list.COLUMNAS_PK.Add("CodigoEstablecimiento");
                        //parametros.Add(row.Cells["colIdVisitas"].Value.ToString()); //se comenta para usar un nuevo consecutivo
                        parametros.Add(cont.ToString());
                        parametros.Add(row.Cells["colIdColeVisitas"].Value.ToString());
                        parametros.Add(txtNumRegistro.Valor);
                        parametros.Add(DateTime.Parse(row.Cells["colFechaFisc"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                        parametros.Add(row.Cells["colObservacionFisc"].Value.ToString());

                        lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);
                        cont++;
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

                sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NIT where NIT = '" + txtCedulaJuridica.Valor + "'";

                lbOk = Consultas.fillDataTable(sSelectCl, ref dtNit, ref error);

                if (lbOk && dtNit.Rows.Count == 0 )//Si no tiene nit lo crea
                    lbOk = fInternas.generarNit(txtCedulaJuridica.Valor, txtNumRegistro.Valor, ref dtCliente, "estable", ref error);

                if (lbOk)
                {
                    sSelectCl = "select * from " + Consultas.sqlCon.COMPAÑIA + ".CLIENTE where CLIENTE = '" + txtNumRegistro.Valor + "'";

                    lbOk = Consultas.fillDataTable(sSelectCl, ref dtCliente, ref error);
                }
                    

                if (lbOk && dtCliente.Rows.Count == 0)//Si no existe como cliente se crea
                {     
                    lbOk = fInternas.generarCliente(txtNumRegistro.Valor, ref dtCliente, "estable", "C_A", ref error);
                }
                else//Sino se actualiza
                {
                    dtCliente = new DataTable();

                    sSelectCl = "select NumRegistro idERP, Nombre, '' Alias, Direccion, Telefono Telefono1, '' Telefono2," +
                    " CedulaJuridica Contribuyente, 'CRI' Pais, '' UsaTarjeta, '' VencimientoTarjeta, Email," +
                    " Provincia, Canton, 'S' Activo, (select CategoriaEstable from " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES) Categoria from " + Consultas.sqlCon.COMPAÑIA + ".NV_ESTABLECIMIENTOS where NumRegistro = '" + txtNumRegistro.Valor + "'";

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

        protected override bool validarDatos(ref string errores)
        {
            dgvRegentes.EndEdit();
            if (txtNumRegistro.Valor.Equals("") || txtNumRegistro.Valor.Equals("ND"))
            {
                errores = "Debe digitar el Numero de Registro para el establecimiento.";
                txtNumRegistro.Focus();
                return false;
            }

            if (txtNombre.Valor == "")
            {
                errores = "Debe digitar un nombre para el establecimiento.";
                txtNombre.Focus();
                return false;
            }

            if (txtCobrador.Valor == "")
            {
                errores = "Debe digitar un cobrador para el establecimiento.";
                txtNombre.Focus();
                return false;
            }

            if (txtCedulaJuridica.Valor == "")
            {
                errores = "Debe digitar una cédula jurídica para el establecimiento.";
                txtNombre.Focus();
                return false;
            }

            if (cmbEstado.Valor == "")
            {
                errores = "Debe seleccionar un estado para el establecimiento.";
                return false;
            }
            else
            {
                if (estadoCerrado)
                {
                    if (!dtpFechaCierre.Checked)
                    {
                        errores = "Debe ingresar una fecha de cierre para el establecimiento.";
                        return false;
                    }

                    if (txtSesionCierre.Valor.Equals(""))
                    {
                        errores = "Debe agregar la sesión de cierre para el establecimeinto.";
                        return false;
                    }
                }
            }

            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                if (row.Cells["colCodigoRegente"].Value.ToString() == "")
                {
                    errores = "Debe definir un regente en la fila " + (row.Index + 1) + " de la tabla de regentes.";
                    tabControl.SelectedTab = tpRegentes;
                    return false;
                }

                if (row.Cells["colEstado"].Value == null)
                {
                    errores = "Debe definir un estado para el regente en la fila " + (row.Index + 1) + " de la tabla de regentes.";
                    tabControl.SelectedTab = tpRegentes;
                    return false;
                }

                if (row.Cells["colCodCategoria"].Value == null)
                {
                    errores = "Debe definir una categoria para el regente en la fila " + (row.Index + 1) + " de la tabla de regentes.";
                    tabControl.SelectedTab = tpRegentes;
                    return false;
                }
            }

            foreach (DataGridViewRow row in dgvInformes.Rows)
            {
                if (row.Cells["colNumeroColeInformes"].Value.ToString() == "")
                {
                    errores = "Debe definir un regente en la fila " + (row.Index + 1) + " de la tabla de informes.";
                    tabControl.SelectedTab = tpInformes;
                    return false;
                }

                if (row.Cells["colFechaInf"].Value.Equals(""))
                {
                    errores = "Debe definir una fecha en la fila " + (row.Index + 1) + " de la tabla de informes.";
                    tabControl.SelectedTab = tpInformes; 
                    return false;
                }
                
            }

            return true;
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtNumRegistro.Valor);
            txtNumRegistro.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Establecimiento: " + txtNombre.Valor;
        }

        protected override void limpiarFormulario()
        {
            txtNumRegistro.Valor = "ND";
            txtNumRegistro.ReadOnly = false;
            txtCedulaJuridica.Clear();
            txtNumInscripcion.Clear();
            txtNombre.Clear();
            txtRepresentante.Clear();
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
            rtbDireccion.Clear();
            rtbActividades.Clear();
            //txtHorario.Clear();
            txtCobrador.Clear();
            txtCobradorNombre.Clear();
            //txt.Clear();
            //txtSesionRenov.Clear();
            txtSesionCierre.Clear();
            //dtpFechaAprobacion.Value = DateTime.Now;
            dtpFecha.Value = DateTime.Now;
            dtpFechaCierre.Value = DateTime.Now;
            dtpFechaCierre.Checked = false;
            dtpDesdeTemporal1.Value = DateTime.Now;
            dtpHastaTemporal1.Value = DateTime.Now.AddDays(1);
            dtpFechaCanon.Value = DateTime.Now;

            dgvCategorias.Rows.Clear();
            dgvRegentes.Rows.Clear();
            dgvInformes.Rows.Clear();
            dgvVisitasFisc.Rows.Clear();
            lblPerfil.Text = "Perfil de Establecimiento";
        }

        private void btnNuevoHorario_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_EDITAR))
            {
                dgvHorarios.Rows.Add(dgvHorarios.RowCount + 1, "", "", "", "", "", "", "");
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_EDITAR))
            {
                dgvCategorias.Rows.Add("", "","Activo");
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void txtProvincia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaProvincias();
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

        private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaProvincias();
        }

        private void txtProvincia_Leave(object sender, EventArgs e)
        {
            buscaProvincia(txtProvincia.Valor);
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

        private void txtCanton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCantones();
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

        private void txtCanton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCantones();
        }

        private void txtCanton_Leave(object sender, EventArgs e)
        {
            buscaCanton(txtCanton.Valor);
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

        private void txtDistrito_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaDistritos();
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

        private void txtDistrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaDistritos();
        }

        private void txtDistrito_Leave(object sender, EventArgs e)
        {
            buscaDistrito(txtDistrito.Valor);
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

        private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCobradores("cobrador");
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
                if (identificador == "regentes")
                {
                    dgvRegentes.CurrentCell.Value = f1Cobrador.item.SubItems[1].Text;
                    dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoCobrador"].Value = f1Cobrador.item.SubItems[0].Text;
                    dgvRegentes.EndEdit();
                }
                else
                {
                    txtCobrador.Valor = f1Cobrador.item.SubItems[0].Text;
                    txtCobradorNombre.Valor = f1Cobrador.item.SubItems[1].Text;
                }
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCobradores("cobrador");
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

        private void dgvCategorias_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                if (dgvCategorias.CurrentCell.OwningColumn.Name == "colCodigoCategoria" && dgvCategorias.CurrentCell.Value.ToString().Equals(""))
                {
                    listaCategorias(false);
                }
            }
                
        }

        private void listaCategorias(bool entrarDgvRegentes)
        {
            //bool ok = true;
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoCategoria as Categoría,NombreCategoria as Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_CATEGORIAS";
            listP.ORDERBY = "order by CodigoCategoria";
            listP.TITULO_LISTADO = "Categorias";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (entrarDgvRegentes)
            {
                //int contCatePorEst = 0;
                if (f1Colegiado.item != null)
                {
                    //foreach (DataGridViewRow row in dgvRegentes.Rows)
                    //{
                        
                    //    if (f1Colegiado.item.SubItems[0].Text == "01" )
                    //    {
                    //        contCatePorEst++;
                    //        if (contCatePorEst == 2) { 
                    //        MessageBox.Show("Solo puede tener "+ f1Colegiado.item.SubItems[0].Text + " dos veces por regente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        dgvRegentes.EndEdit();
                    //        return;
                    //        }
                    //    }
                    //}
                    dgvRegentes.CurrentCell.Value = f1Colegiado.item.SubItems[1].Text;
                    dgvRegentes.CurrentCell.OwningRow.Cells["colCodCategoria"].Value = f1Colegiado.item.SubItems[0].Text;
                    dgvRegentes.EndEdit();
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
            }
            else { 
            if (f1Colegiado.item != null)
            {
                foreach(DataGridViewRow row in dgvCategorias.Rows)
                {
                    if(row.Cells["colCodigoCategoria"].Value.ToString()== f1Colegiado.item.SubItems[0].Text)
                    {
                        MessageBox.Show("La categoría ya fue agregada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvCategorias.EndEdit();
                        return;
                    }
                }
                dgvCategorias.CurrentCell.Value = f1Colegiado.item.SubItems[0].Text;
                dgvCategorias.CurrentCell.OwningRow.Cells["colDescripcionCat"].Value= f1Colegiado.item.SubItems[1].Text;
                dgvCategorias.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
            }
        }

        private void listaCategoriasRegencias()
        {
            //bool ok = true;
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoCategoria as Categoría,NombreCategoria as Nombre, Estado";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_ESTABLECIMIENTOS_CATEGORIAS";
            listP.ORDERBY = "order by CodigoCategoria";
            listP.FILTRO = "where NumRegistroEstablecimiento = '" + txtNumRegistro.Valor + "'";
            listP.TITULO_LISTADO = "Categorias";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
         
            if (f1Colegiado.item != null)
            {
                 
                dgvRegentes.CurrentCell.Value = f1Colegiado.item.SubItems[1].Text;
                dgvRegentes.CurrentCell.OwningRow.Cells["colCodCategoria"].Value = f1Colegiado.item.SubItems[0].Text;
                dgvRegentes.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
            
        }

        private void listaRegentes()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "(select NumeroColegiado from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as [Numero],(select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) as [Nombre de Regente],t1.NumeroColegiado as 'Num'";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_REGENTES t1";
            listP.FILTRO = "where AvaluoCursos = 'S'";
            listP.ORDERBY = "order by t1.NumeroColegiado";
            listP.COLUMNAS_PK.Add("NumeroColegiado");
            listP.COLUMNAS_ALIAS_PK.Add("Num");
            listP.COLUMNAS_OCULTAS.Add("Num");


            listP.TITULO_LISTADO = "Regentes";

            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                foreach (DataGridViewRow row in dgvRegentes.Rows)
                {
                    if (row.Cells["colCodigoRegente"].Value.ToString() == f1Colegiado.item.SubItems[2].Text )
                    {
                        MessageBox.Show("El regente ya fue agregado a esa categoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvRegentes.EndEdit();
                        return;
                    }
                }

                if (tieneSancion(f1Colegiado.item.SubItems[2].Text))
                {
                    MessageBox.Show("El regente esta sancionado, no se puede agregar regencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvRegentes.EndEdit();
                    return;
                }

                dgvRegentes.CurrentCell.Value = f1Colegiado.item.SubItems[0].Text;
                dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoRegente"].Value = f1Colegiado.item.SubItems[2].Text;
                dgvRegentes.CurrentCell.OwningRow.Cells["colNombreRegente"].Value = f1Colegiado.item.SubItems[1].Text;
                dgvRegentes.EndEdit();
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void listaRegentesEstablecimientos(string tipo)
        {
            //bool ok = true;
            Listado listP = new Listado();
            listP.COLUMNAS = "t1.NumeroColegiado [Id Colegiado], (select NumeroColegiado from "+Consultas.sqlCon.COMPAÑIA+ ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) [N° Colegiado], (select Nombre from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where IdColegiado = t1.NumeroColegiado) [Nombre]";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_REGENTES_ESTABLECIMIENTOS t1";
            listP.FILTRO = "where t1.CodigoEstablecimiento = '" + txtNumRegistro.Valor + "'";
            listP.TITULO_LISTADO = "Regentes Actuales";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();

            if (f1Colegiado.item != null)
            {
                if(tipo == "informes")
                {
                    dgvInformes.CurrentCell.Value = f1Colegiado.item.SubItems[1].Text;
                    dgvInformes.CurrentCell.OwningRow.Cells["colNombreColeInformes"].Value = f1Colegiado.item.SubItems[2].Text;
                    dgvInformes.CurrentCell.OwningRow.Cells["colNumeroColeInformes"].Value = f1Colegiado.item.SubItems[0].Text;
                    dgvInformes.EndEdit();
                }
                else
                {
                    dgvVisitasFisc.CurrentCell.Value = f1Colegiado.item.SubItems[1].Text;
                    dgvVisitasFisc.CurrentCell.OwningRow.Cells["colNombreColeVisitas"].Value = f1Colegiado.item.SubItems[2].Text;
                    dgvVisitasFisc.CurrentCell.OwningRow.Cells["colIdColeVisitas"].Value = f1Colegiado.item.SubItems[0].Text;
                    dgvVisitasFisc.EndEdit();
                }

                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }


        }

        private void dgvCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvCategorias.CurrentCell.OwningColumn.Name == "colCodigoCategoria" && e.KeyValue == (char)Keys.F1)
            {
                listaCategorias(false);
            }
        }

        private void btnEliminaHorario_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_BORRAR))
            {
                if (dgvHorarios.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_ESTABLECIMIENTOS_HORARIOS where CodigoEstablecimiento='" + txtNumRegistro.Valor + "' AND " +
                        "Id=" + dgvHorarios.CurrentCell.OwningRow.Cells["colIdHorario"].Value.ToString();

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvHorarios.Rows.Remove(dgvHorarios.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnEliminaCategoria_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_BORRAR))
            {
                if (dgvCategorias.RowCount > 0)
                {
                    //AJUSTES PARA INACTIVAR UNA CATEGORIA
                    if (MessageBox.Show("¿Está seguro que desea inactivar este registro?", "Actualizar", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sQuery = "UPDATE " + Consultas.sqlCon.COMPAÑIA +
                            ".NV_ESTABLECIMIENTOS_CATEGORIAS SET ESTADO='I' WHERE CodigoCategoria='"
                            + dgvCategorias.CurrentCell.OwningRow.Cells["colCodigoCategoria"].Value.ToString() + "' AND NumRegistroEstablecimiento = '" + txtNumRegistro.Valor + "'";

                        if (Consultas.ejecutarSentencia(sQuery, ref error))
                        {
                            dgvCategorias.CurrentCell.OwningRow.Cells["colEstadoCat"].Value = "Inactivo";
                            colorearFilasCategorias();
                            btnGuardar.Enabled = true;
                            btnGuardarSalir.Enabled = true;
                            CambioEnCategorias = true;
                        }
                        else
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void listaEstados()
        {
            DataTable dtEstados = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoEstado,NombreEstado";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where Diferenciador = 'E'";
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

        private void btnAjustarCol_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvRegentes.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private bool tieneSancion(string colegiado)
        {
            bool tiene = false;
            DataTable dt = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "Estado";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_REGENTES_ESTABLECIMIENTOS";
            listP.FILTRO = "where NumeroColegiado='" + colegiado + "'";

            if (Consultas.listarDatos(listP, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Estado"].ToString() == "S")
                            tiene = true;
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return tiene;
        }

        private bool tieneCategoria()
        {
            bool OK = false;
            string sQuery = "select * from "+Consultas.sqlCon.COMPAÑIA+".NV_ESTABLECIMIENTOS_CATEGORIAS"+
                " where NumRegistroEstablecimiento = '" + txtNumRegistro.Valor + "'";

            DataTable dt = new DataTable();
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                    OK = true;
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return OK;
        }

        private bool tieneRegente()
        {
            bool OK = false;
            string sQuery = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS" +
                " where CodigoEstablecimiento = '" + txtNumRegistro.Valor + "'";

            DataTable dt = new DataTable();
            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                    OK = true;
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return OK;
        }

        private void btnNuevoRegente_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_EDITAR))
            {
                if (txtNumRegistro.Valor.Equals(""))
                {

                    MessageBox.Show("Debe guardar previamente el establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!tieneCategoria())
                    {
                        MessageBox.Show("Debe guardar previamente la categoria del establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dgvRegentes.Rows.Add("", "", "", "", "", "", "", "", "");
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           
            
        }

        private void btnEliminarRegente_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_BORRAR))
            {
                if (dgvRegentes.RowCount == 0)
                    return;

                if (MessageBox.Show("Se borrará toda la información asociada al regente (Horario, Informes, Visitas Fiscalía), ¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Consultas.sqlCon.iniciaTransaccion();
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS_HORARIOS where NumeroColegiado='"
                        + dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoRegente"].Value.ToString() +
                        "' and CodigoEstablecimiento='" +
                        txtNumRegistro.Valor + "'";

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);

                    if (OK)
                    {
                        sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS_INFORMES where NumeroColegiado='"
                        + dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoRegente"].Value.ToString() +
                        "' and CodigoEstablecimiento='" +
                        txtNumRegistro.Valor + "'";

                        OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    }

                    if (OK)
                    {
                        sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS_VISITAS_FISC where NumeroColegiado='"
                        + dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoRegente"].Value.ToString() +
                        "' and CodigoEstablecimiento='" +
                        txtNumRegistro.Valor + "'";

                        OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    }

                    if (OK)
                    {
                        sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado='"
                        + dgvRegentes.CurrentCell.OwningRow.Cells["colCodigoRegente"].Value.ToString() +
                        "' and CodigoEstablecimiento='" +
                        txtNumRegistro.Valor + "'";

                        OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    }

                    if (OK)
                    {
                        Consultas.sqlCon.Commit();
                        dgvRegentes.Rows.Remove(dgvRegentes.CurrentRow);
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

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            dgvRegentes.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtpInf_OnTextChange(object sender, EventArgs e)
        {
            dgvInformes.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtpVist_OnTextChange(object sender, EventArgs e)
        {
            dgvVisitasFisc.CurrentCell.Value = dtp.Text.ToString();
        }

        void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void OnEstadoChanged(object sender, EventArgs e)
        {
            verificarConfigurablesEstado();
        }

        private void dgvRegentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (e.RowIndex != -1)
            {
                if ((dgvRegentes.CurrentCell.OwningColumn.Name == "colFechaAprobacion"))
                {

                    dtp = new DateTimePicker();
                    dgvRegentes.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvRegentes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvRegentes.CurrentCell.OwningColumn.Name == "colFechaAprobacion" && dgvRegentes.Rows[e.RowIndex].Cells["colFechaAprobacion"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvRegentes.Rows[e.RowIndex].Cells["colFechaAprobacion"].Value.ToString());

                    dtp.Visible = true;

                }
            }
            

            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;

        }

        private void dgvRegentes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvRegentes.CurrentRow != null)
            {
                if (dgvRegentes.CurrentCell.OwningColumn.Name == "colNumeroColegiado" /*&& dgvRegentes.CurrentCell.Value.ToString().Equals("")*/)
                {
                    listaRegentes();
                }

                if (dgvRegentes.CurrentCell.OwningColumn.Name == "colNombreCategoria" /*&& dgvRegentes.CurrentCell.Value.ToString().Equals("")*/)
                {
                    listaCategoriasRegencias();
                }

                if (dgvRegentes.CurrentCell.OwningColumn.Name == "colCobrador" /*&& dgvRegentes.CurrentCell.Value.ToString().Equals("")*/)
                {
                    listaCobradores("regentes");
                }
            }
        }

        private void dtpDesdeTemporal1_ValueChanged(object sender, EventArgs e)
        {
            //DateTime fecha_nac = DateTime.TryParse(txtNacimiento.Text);
            if (validarFechas)
            {
                //int result = DateTime.Compare(dtpDesdeTemporal1.Value.Date, DateTime.Today);

                //if (result < 0)
                //{
                //    MessageBox.Show("La fecha desde no puede ser menor a la actual.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    dtpDesdeTemporal1.Value = DateTime.Now;
                //}


                int result = DateTime.Compare(dtpDesdeTemporal1.Value.Date, dtpHastaTemporal1.Value.Date);

                if (result == 0)
                {
                    if (dtpHastaTemporal1.Value.Date == DateTime.Today)
                        dtpHastaTemporal1.Value = DateTime.Now.AddDays(1);
                    MessageBox.Show("Las fechas desde y hasta no pueden ser iguales.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dtpHastaTemporal1.Value = DateTime.Now.AddDays(1);
                    dtpDesdeTemporal1.Value = DateTime.Now;

                }


                else if (result > 0)
                {
                    MessageBox.Show("La fecha desde no puede ser superior a hasta.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpDesdeTemporal1.Value = DateTime.Now;
                }

                if (!btnGuardar.Enabled && !btnGuardarSalir.Enabled)
                {
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
            }
        }

        private void dtpHastaTemporal1_ValueChanged(object sender, EventArgs e)
        {
            if (validarFechas)
            {
                int result = DateTime.Compare(dtpHastaTemporal1.Value.Date, DateTime.Today);

                if (result < 0)
                {
                    MessageBox.Show("La fecha hasta no puede ser menor a la actual.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpHastaTemporal1.Value = dtpDesdeTemporal1.Value.AddDays(1);
                }


                result = DateTime.Compare(dtpHastaTemporal1.Value.Date, dtpDesdeTemporal1.Value.Date);

                if (result == 0)
                {
                    MessageBox.Show("Las fechas desde y hasta no pueden ser iguales.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpHastaTemporal1.Value = dtpDesdeTemporal1.Value.AddDays(1);
                    //dtpDesdeTemporal1.Value = DateTime.Now;
                }


                else if (result < 0)
                {
                    MessageBox.Show("La fecha hasta no puede ser menor que desde.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpHastaTemporal1.Value = dtpDesdeTemporal1.Value.AddDays(1);
                }

                if (!btnGuardar.Enabled && !btnGuardarSalir.Enabled)
                {
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
            }
            
        }
        
        private void btnNuevoInforme_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_EDITAR))
            {
                if (txtNumRegistro.Valor.Equals(""))
                {

                    MessageBox.Show("Debe guardar previamente el establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!tieneCategoria())
                    {

                        MessageBox.Show("Debe guardar previamente la categoria del establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!tieneRegente())
                        {

                            MessageBox.Show("Debe guardar previamente un regente al establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int idInformes = 0;
                            if (fInternas.obtenerUltimoIdInformes(ref idInformes))
                            {
                                dgvInformes.Rows.Add(idInformes + 1, "", "", "", "", "");
                                //btnGuardar.Enabled = true;
                                //btnGuardarSalir.Enabled = true;
                            }
                            //dgvInformes.Rows.Add(dgvInformes.RowCount + 1, "", "", "", "", "");
                        }
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }
        
        private void btnEliminaInforme_Click(object sender, EventArgs e)
        {
            
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_BORRAR))
            {
                if (dgvInformes.RowCount > 0)
                    dgvInformes.Rows.Remove(dgvInformes.CurrentRow);
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnNuevoVisita_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_EDITAR))
            {
                if (txtNumRegistro.Valor.Equals(""))
                {

                    MessageBox.Show("Debe guardar previamente el establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!tieneCategoria())
                    {

                        MessageBox.Show("Debe guardar previamente la categoria del establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!tieneRegente())
                        {

                            MessageBox.Show("Debe guardar previamente un regente al establecimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dgvVisitasFisc.Rows.Add(dgvVisitasFisc.RowCount + 1, "", "", "", "", "");
                        }
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }
        
        private void btnEliminaVisita_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.ESTABLECIMIENTO_BORRAR))
            {
                if (dgvVisitasFisc.RowCount > 0)
                    dgvVisitasFisc.Rows.Remove(dgvVisitasFisc.CurrentRow);
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           
        }

        private void dgvInformes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (e.RowIndex != -1)
            {
                if ((dgvInformes.CurrentCell.OwningColumn.Name == "colFechaInf"))
                {

                    dtp = new DateTimePicker();
                    dgvInformes.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvInformes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtpInf_OnTextChange);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvInformes.CurrentCell.OwningColumn.Name == "colFechaInf" && dgvInformes.Rows[e.RowIndex].Cells["colFechaInf"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvInformes.Rows[e.RowIndex].Cells["colFechaInf"].Value.ToString());

                    dtp.Visible = true;

                }
            }
            

            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void dgvInformes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInformes.IsCurrentCellDirty)
            {
                dgvInformes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvVisitasFisc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
            if (e.RowIndex != -1)
            {
                if ((dgvVisitasFisc.CurrentCell.OwningColumn.Name == "colFechaFisc"))
                {

                    dtp = new DateTimePicker();
                    dgvVisitasFisc.Controls.Add(dtp);
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    Rectangle Rectangle = dgvVisitasFisc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                    dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtpVist_OnTextChange);
                    dtp.LostFocus += new EventHandler(dtp_CloseUp);

                    if (dgvVisitasFisc.CurrentCell.OwningColumn.Name == "colFechaFisc" && dgvVisitasFisc.Rows[e.RowIndex].Cells["colFechaFisc"].Value.ToString() != string.Empty)
                        dtp.Value = DateTime.Parse(dgvVisitasFisc.Rows[e.RowIndex].Cells["colFechaFisc"].Value.ToString());

                    dtp.Visible = true;

                }
            }


            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void dgvVisitasFisc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVisitasFisc.IsCurrentCellDirty)
            {
                dgvVisitasFisc.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvRegentes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRegentes.IsCurrentCellDirty)
            {
                dgvRegentes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAjustarInf_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvInformes.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void btnAjustarVist_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvVisitasFisc.AutoResizeColumns();
            Cursor.Current = Cursors.Default; 
        }

        private void dgvInformes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvInformes.CurrentRow != null)
            {
                if (dgvInformes.CurrentCell.OwningColumn.Name == "colNumCole" && dgvInformes.CurrentCell.Value.ToString().Equals(""))
                {
                    listaRegentesEstablecimientos("informes");
                }
            }
                
        }

        private void colorearFilas()
        {
            foreach (DataGridViewRow row in dgvRegentes.Rows)
            {
                if (dgvRegentes.Rows[row.Index].Cells["colEstado"].Value.ToString() == "Inactivo")
                    dgvRegentes.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                else if (dgvRegentes.Rows[row.Index].Cells["colEstado"].Value.ToString() == "Sancionado")
                    dgvRegentes.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                else
                    dgvRegentes.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void colorearFilasCategorias()
        {
            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                switch (dgvCategorias.Rows[row.Index].Cells["colEstadoCat"].Value.ToString())
                {
                    case "Inactivo":
                        dgvCategorias.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
                        break;
                    case "Activo":
                        dgvCategorias.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
                        break;
                    case "Sin Regente":
                        dgvCategorias.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                }
                    
              
                    
            }
        }

        private void dgvRegentes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        /// <summary>
        /// Activa cambio de estado en datagrid de categorias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCategoria_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;

            if (dgvCombo != null)
            {
                //
                // se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
                // evitando asi que se ejecuten varias veces el evento
                //
                dgvCombo.SelectedIndexChanged -= new EventHandler(dgvComboCat_SelectedIndexChanged);

                dgvCombo.SelectedIndexChanged += new EventHandler(dgvComboCat_SelectedIndexChanged);
            }

        }

        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            DataGridViewRow row = dgvRegentes.CurrentRow;

            //DataGridViewCheckBoxCell cell = row.Cells["Seleccionado"] as DataGridViewCheckBoxCell;
            //cell.Value = true;
            //if (combo.SelectedItem.Equals("Inactivo"))
            //    row.DefaultCellStyle.BackColor = Color.Red;
            //else
            //    row.DefaultCellStyle.BackColor = Color.White;

            if (dgvRegentes.Rows.Count > 0 && validarExistencia(row.Cells["colCodigoRegente"].Value.ToString(), txtNumRegistro.Valor, row.Cells["colCodCategoria"].Value.ToString()))
            {
                if (row.Cells["colEstado"].Value != null && row.Cells["colEstado"].Value.ToString() != combo.SelectedItem.ToString())
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

                        //fInternas.insertarHistorialRegencias(row.Cells["colCodigoRegente"].Value.ToString(), txtNumRegistro.Valor, row.Cells["colCodCategoria"].Value.ToString(),
                        //row.Cells["colEstado"].Value.ToString(), row.Cells["colSesionAprobacion"].Value.ToString(),
                        //row.Cells["colFechaAprobacion"].Value.ToString(), ref error);
                    }
                    else
                    {
                        combo.SelectedItem = row.Cells["colEstado"].Value;
                    }

                }
            }
            
        }

         /*Marlon Loría Solano
         * 2025-05-12*/
        /// <summary>
        /// Ajuste para colorear estado inactivo de catagoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvComboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            DataGridViewRow row = dgvCategorias.CurrentRow;

            if (dgvRegentes.Rows.Count > 0 && ExisteCategoria(row.Cells["colCodigoCategoria"].Value.ToString(), txtNumRegistro.Valor))
            {
                if (row.Cells["colEstadoCat"].Value != null && row.Cells["colEstadoCat"].Value.ToString() != combo.SelectedItem.ToString())
                {
                    if (MessageBox.Show("¿Desea realizar el cambio de Estado de la Categoría?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (combo.SelectedItem.Equals("Inactivo"))
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.Cells["colEstadoCat"].Value = "Inactivo";
                        }
                        else
                        {
                            if (combo.SelectedItem.Equals("Activo"))
                            {
                                row.DefaultCellStyle.BackColor = Color.White;
                                row.Cells["colEstadoCat"].Value = "Activo";
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.LightGray;
                                row.Cells["colEstadoCat"].Value = "Sin Regente";
                            }
                        }
                        
                        CambioEnCategorias = true; 
                    }
                    else
                    {
                        combo.SelectedItem = row.Cells["colEstadoCat"].Value;
                    }

                }
                else
                {
                    
                    if (combo.SelectedItem.Equals("Inactivo"))
                        row.DefaultCellStyle.BackColor = Color.Red;
                    else
                    {
                        if (combo.SelectedItem.Equals("Activo"))
                            row.DefaultCellStyle.BackColor = Color.White;
                        else
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                        

                }
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }

        }

        private bool validarExistencia(string colegiado, string estable, string categ)
        {
            bool existe = true;
            string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_REGENTES_ESTABLECIMIENTOS where NumeroColegiado = '" + colegiado + "' and CodigoEstablecimiento = '" + estable + "' and CodigoCategoria = '" + categ + "'";
            DataTable dtEstablecimientos = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtEstablecimientos, ref error))
            {
                if (dtEstablecimientos.Rows.Count > 0)
                    existe = true;
                else
                    existe = false;
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return existe;
        }

        

        private void frmEstablecimientosEdicion_Load(object sender, EventArgs e)
        {
            headerCategorias.Location = new Point(3, 3);
            headerCategorias.Size = new Size(680, 21);

            gbCategorias.Location = new Point(43, 66);
            gbCategorias.Size = new Size(587, 479);

            headerRegentes.Location = new Point(3, 3);
            headerRegentes.Size = new Size(680, 21);

            gbRegentes.Location = new Point(30, 68);
            gbRegentes.Size = new Size(627, 472);

            headerInformes.Location = new Point(3, 3);
            headerInformes.Size = new Size(680, 21);

            gbInformes.Location = new Point(51, 70);
            gbInformes.Size = new Size(584, 474);

            headerVisitas.Location = new Point(3, 3);
            headerVisitas.Size = new Size(680, 21);

            gbVisitas.Location = new Point(8, 54);
            gbVisitas.Size = new Size(670, 511);

        }

        private void dgvVisitasFisc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvVisitasFisc.CurrentRow != null)
            {
                if (dgvVisitasFisc.CurrentCell.OwningColumn.Name == "colNumeroColeVisitas" && dgvVisitasFisc.CurrentCell.Value.ToString().Equals(""))
                {
                    listaRegentesEstablecimientos("visitas");
                }
            }

        }

    }
}
