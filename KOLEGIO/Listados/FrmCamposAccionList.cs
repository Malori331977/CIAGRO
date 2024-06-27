using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class FrmCamposAccionList : frmListado
    {
        public FrmCamposAccionList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoCampo as Código, NombreCampo as Nombre, DescripcionCampo as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CAMPOS_ACCION";
            listar.TITULO_LISTADO = "Lista de Campos de Acción (CIAS Consultoras)";
            listar.ORDERBY = "order by CodigoCampo";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoCampo");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.CAMPOS_ACCION_INSERTAR;
            editar = Constantes.CAMPOS_ACCION_EDITAR;
            borrar = Constantes.CAMPOS_ACCION_BORRAR;
            seleccionar = Constantes.CAMPOS_ACCION_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmCamposAccionEdicion"))
            {
                frmCamposAccionEdicion frm = new frmCamposAccionEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmCamposAccionEdicion"))
            {
                ObtenerValoresPKListado();
                frmCamposAccionEdicion frm = new frmCamposAccionEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }

        protected override void imprimirReporte()
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {
                //if (listar.VALORES_PK.Count > 0)
                //{
                    if (Utilitario.BuscaForm("frmVisorRpt"))
                    {
                        DataTable dtRptCarteraGeneral = new DataTable();
                        Listado listP = new Listado();
                        listP.COLUMNAS = "*";
                        listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                        listP.TABLA = "NV_CAMPOS_ACCION";
                        //listP.FILTRO = "where IdColegiado = '" + txtIdColegiado.Valor + "'";
                        Cursor.Current = Cursors.WaitCursor;
                        if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                        {
                            if (dtRptCarteraGeneral.Rows.Count > 0)
                            {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Campos de Accion para Empresa Consultoras.rpt");
                            //frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Campos de Accion para Empresa Consultoras.rpt",new List<string>(), new List<string>());
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
                //}
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "SASEG Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        //protected override void imprimirReporte()
        //{
        //    if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.TVW_REPORTE_GESTION_COBRO_KEY))
        //    {
        //        if (Utilitario.BuscaForm("frmFiltroPolizas"))
        //        {
        //            Listado listP = new Listado();
        //            listP.COLUMNAS = "Asegurado,[Póliza],[Fecha Gestión] as [Fecha Pago],[Hora Inicio] as [Enviado al INS],[Hora Final] as [Sellado por INS],Observaciones as Moneda,Agente";
        //            listP.COMPAÑIA = "dbo";
        //            listP.TABLA = "V_RPTHistoricoGC";
        //            listP.ORDERBY = "order by Asegurado,[Póliza],[Fecha Gestión]";
        //            frmFiltroPolizas frmReporte = new frmFiltroPolizas(listP, "RPTHistoricoCobro.rpt", "Reporte Gestiones de Cobro", 3, "[Fecha Gestión]");
        //            frmReporte.ShowDialog();
        //        }
        //    }
        //    else
        //        MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "SASEG Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //}
    }
}
