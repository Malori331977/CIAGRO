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
    public partial class FrmVidaSilvestreList : frmListado
    {
        public FrmVidaSilvestreList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoSilvestre as Código, NombreSilvestre as Nombre, DescripcionSilvestre as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_VIDA_SILVESTRE";
            listar.TITULO_LISTADO = "Vida Silvestre";
            listar.ORDERBY = "order by CodigoSilvestre";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoSilvestre");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.VIDA_SILVESTRE_INSERTAR;
            editar = Constantes.VIDA_SILVESTRE_EDITAR;
            borrar = Constantes.VIDA_SILVESTRE_BORRAR;
            seleccionar = Constantes.VIDA_SILVESTRE_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmVidaSilvestreEdicion"))
            {
                frmVidaSilvestreEdicion frm = new frmVidaSilvestreEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmVidaSilvestreEdicion"))
            {
                ObtenerValoresPKListado();
                frmVidaSilvestreEdicion frm = new frmVidaSilvestreEdicion(listar.VALORES_PK);
                frm.Show();
            }
        }

        protected override void imprimirReporte()
        {
            //if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.REPORTES))
            //{

            //    if (Utilitario.BuscaForm("frmVisorRpt"))
            //    {
            //        DataTable dtRptCarteraGeneral = new DataTable();
            //        Listado listP = new Listado();
            //        listP.COLUMNAS = "*";
            //        listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //        listP.TABLA = "NV_CULTIVOS_RECETAS";
            //        Cursor.Current = Cursors.WaitCursor;
            //        if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
            //        {
            //            if (dtRptCarteraGeneral.Rows.Count > 0)
            //            {

            //                frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Cultivos Via Aérea.rpt");
            //                Cursor.Current = Cursors.Default;
            //                rptCG.ShowDialog();
            //            }
            //            else
            //            {
            //                error = "No hay información para generar el reporte.";
            //                MessageBox.Show(error, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else
            //    MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

    }
}
