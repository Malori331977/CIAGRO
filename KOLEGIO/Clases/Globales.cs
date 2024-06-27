using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using System.Data;

namespace KOLEGIO
{
    class Globales
    {
        public static string NOMBRE_COMPAÑIA { set; get; }
        public static string FONDO_MUTUALIDAD { set; get; }
        public static string TITULO_OBLIGATORIO { set; get; }
        public static string TITULO_ARTICULO { set; get; }
        public static string PERMITIR_CREDITO { set; get; }
        public static string PERMITIR_PERITO { set; get; }
        public static string MANEJO_BENEFICIARIOS { set; get; }
        public static string MANEJO_ESPECIALIDADES { set; get; }
        public static string MANEJO_PLAGUICIDAS { set; get; }
        public static string MANEJO_VIA_AEREA { set; get; }
        public static string MANEJO_VIDA_SILVESTRE { set; get; }
        public static string MANEJO_REGENCIAS { set; get; }
        public static string MANEJO_GENE_ARCHIVO_CELULARES { set; get; }
        public static string SERVIDOR_SMTP { set; get; }
        public static string USUARIO_SERVIDOR_SMTP { set; get; }
        public static string CLAVE_USUARIO { set; get; }
        public static string CORREO_CONTROL { set; get; }
        public static string PUERTO_SALIDA_SMTP { set; get; }
        public static string VERSION_SISTEMA { set; get; }
        public static string CORREO_COPIA_SOPORTE { set; get; }
        public static string RUTA_ALMACENAMIENTO_ADJUNTOS { set; get; }
        public static string HABILITAR_SSL { set; get; }
        public static string CONSECUTIVO_PEDIDO { set; get; }
        public static string CONSECUTIVO_FACTURA { set; get; }
        public static string CONSECUTIVO_COLEGIADO { set; get; }
        public static string CONSECUTIVO_ESTABLECIMIENTO { set; get; }
        public static string CONSECUTIVO_ADELANTOS { set; get; }
        public static string CONSECUTIVO_RECIBOS { set; get; }
        public static string CONDICION_PAGO_COLEGIATURAS { set; get; }
        public static string CONDICION_PAGO_REGENCIAS { set; get; }
        public static string CONDICION_PAGO_CANONES_ANUALES { set; get; }
        public static string CONDICION_PAGO_ADELANTOS { set; get; }
        public static string ARTICULO_COBRO_PERITAJES { set; get; }
        public static string ARTICULO_COBRO_PLAGUICIDAS { set; get; }
        public static string ARTICULO_COBRO_VIA_AEREA { set; get; }
        public static string ARTICULO_COBRO_SILVESTRE { set; get; }
        public static string ARTICULO_COBRO_CONSULTORAS { set; get; }
        public static string CATEGORIA_CLIENTE_ESTABLE { set; get; }
        public static string CATEGORIA_CLIENTE_CONSUL { set; get; }
        public static string BODEGA_PEDIDOS { set; get; }
        public static string SUBTIPO_CUENTA_CONECTIVIDAD { set; get; }

        public static bool cargarGlobales(ref string error)
        {
            string sQuery = "SELECT * FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_GLOBALES";
            DataTable dtGlobales = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtGlobales, ref error))
            {
                if (dtGlobales.Rows.Count > 0)
                {
                    NOMBRE_COMPAÑIA = dtGlobales.Rows[0]["NombreCompañia"].ToString();
                    FONDO_MUTUALIDAD = dtGlobales.Rows[0]["FondoMutualidad"].ToString();
                    TITULO_OBLIGATORIO = dtGlobales.Rows[0]["TituloObligatorio"].ToString();
                    TITULO_ARTICULO = dtGlobales.Rows[0]["TituloArticulo"].ToString();
                    PERMITIR_CREDITO = dtGlobales.Rows[0]["PermitirCredito"].ToString();
                    PERMITIR_PERITO = dtGlobales.Rows[0]["PermitirPerito"].ToString();
                    MANEJO_BENEFICIARIOS = dtGlobales.Rows[0]["ManejoBeneficiarios"].ToString();
                    MANEJO_ESPECIALIDADES = dtGlobales.Rows[0]["ManejoEspecialidades"].ToString();
                    MANEJO_PLAGUICIDAS = dtGlobales.Rows[0]["ManejoPlaguicidas"].ToString();
                    MANEJO_VIA_AEREA = dtGlobales.Rows[0]["ManejoViaAerea"].ToString();
                    MANEJO_VIDA_SILVESTRE = dtGlobales.Rows[0]["ManejoVidaSilvestre"].ToString();
                    MANEJO_REGENCIAS = dtGlobales.Rows[0]["ManejoRegencias"].ToString();
                    MANEJO_GENE_ARCHIVO_CELULARES = dtGlobales.Rows[0]["ManejoGenArchivoCel"].ToString();
                    SERVIDOR_SMTP = dtGlobales.Rows[0]["ServidorSMTP"].ToString();
                    USUARIO_SERVIDOR_SMTP = dtGlobales.Rows[0]["UsuarioServidorSMTP"].ToString();
                    CLAVE_USUARIO = dtGlobales.Rows[0]["ClaveUsuario"].ToString();
                    CORREO_CONTROL = dtGlobales.Rows[0]["CorreoControl"].ToString();
                    PUERTO_SALIDA_SMTP = dtGlobales.Rows[0]["PuertoSalidaSMTP"].ToString();
                    VERSION_SISTEMA = dtGlobales.Rows[0]["VersionSistema"].ToString();
                    CORREO_COPIA_SOPORTE = dtGlobales.Rows[0]["CorreoCopiaSoporte"].ToString();
                    RUTA_ALMACENAMIENTO_ADJUNTOS = dtGlobales.Rows[0]["RutaAlmacenamientoAdjuntos"].ToString();
                    HABILITAR_SSL = dtGlobales.Rows[0]["HabilitarSSL"].ToString();
                    CONSECUTIVO_PEDIDO = dtGlobales.Rows[0]["ConsecutivoPedido"].ToString();
                    CONSECUTIVO_FACTURA = dtGlobales.Rows[0]["ConsecutivoFacturas"].ToString();
                    CONSECUTIVO_COLEGIADO = dtGlobales.Rows[0]["ConsecutivoColegiado"].ToString();
                    CONSECUTIVO_ESTABLECIMIENTO = dtGlobales.Rows[0]["ConsecutivoEstablecimiento"].ToString();
                    CONSECUTIVO_ADELANTOS = dtGlobales.Rows[0]["ConsecutivoAdelantos"].ToString();
                    CONSECUTIVO_RECIBOS = dtGlobales.Rows[0]["ConsecutivoRecibos"].ToString();
                    CONDICION_PAGO_COLEGIATURAS = dtGlobales.Rows[0]["CondPagoColegiaturas"].ToString();
                    CONDICION_PAGO_REGENCIAS = dtGlobales.Rows[0]["CondPagoRegencias"].ToString();
                    CONDICION_PAGO_CANONES_ANUALES = dtGlobales.Rows[0]["CondPagoCanonesAnuales"].ToString();
                    CONDICION_PAGO_ADELANTOS = dtGlobales.Rows[0]["CondPagoAdelantos"].ToString();
                    ARTICULO_COBRO_PERITAJES = dtGlobales.Rows[0]["CodArtCobroPeritajes"].ToString();
                    ARTICULO_COBRO_PLAGUICIDAS = dtGlobales.Rows[0]["CodArtCobroPlaguicidas"].ToString();
                    ARTICULO_COBRO_VIA_AEREA = dtGlobales.Rows[0]["CodArtCobroViaAerea"].ToString();
                    ARTICULO_COBRO_SILVESTRE = dtGlobales.Rows[0]["CodArtCobroSilvestre"].ToString();
                    ARTICULO_COBRO_CONSULTORAS = dtGlobales.Rows[0]["CodArtCobroConsultoras"].ToString();
                    CATEGORIA_CLIENTE_ESTABLE = dtGlobales.Rows[0]["CategoriaEstable"].ToString();
                    CATEGORIA_CLIENTE_CONSUL = dtGlobales.Rows[0]["CategoriaConsul"].ToString();
                    BODEGA_PEDIDOS = dtGlobales.Rows[0]["BodegaPedidos"].ToString();
                    SUBTIPO_CUENTA_CONECTIVIDAD = dtGlobales.Rows[0]["SubtipoCuentaConectivdad"].ToString();

                    return true;
                }
                else
                {
                    error = "No existen parámetros globales en el sistema.";
                    return false;
                }

            }
            else
                return false;
        }
    }
}
