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
    public partial class FrmOrientacionesList : frmListado
    {
        public FrmOrientacionesList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoOrientacion as Código, NombreOrientacion as Nombre, DescripcionOrientacion as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_ORIENTACIONES";
            listar.TITULO_LISTADO = "Lista de Orientaciones";
            listar.ORDERBY = "order by CodigoOrientacion";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoOrientacion");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.ORIENTACIONES_INSERTAR;
            editar = Constantes.ORIENTACIONES_EDITAR;
            borrar = Constantes.ORIENTACIONES_BORRAR;
            seleccionar = Constantes.ORIENTACIONES_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmOrientacionesEdicion"))
            {
                frmOrientacionesEdicion frm = new frmOrientacionesEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmOrientacionesEdicion"))
            {
                ObtenerValoresPKListado();
                frmOrientacionesEdicion frm = new frmOrientacionesEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }

        protected override void imprimirReporte()
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            {

                if (Utilitario.BuscaForm("frmVisorRpt"))
                {
                    DataTable dtRptCarteraGeneral = new DataTable();
                    Listado listP = new Listado();
                    listP.COLUMNAS = "*";
                    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                    listP.TABLA = "NV_ORIENTACIONES";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Orientaciones Académicas.rpt");
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
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "SASEG Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
