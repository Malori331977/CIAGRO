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
    public partial class FrmCategoriasList : frmListado
    {
        public FrmCategoriasList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoCategoria as Código, NombreCategoria as Nombre, DescripcionCategoria as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CATEGORIAS";
            listar.TITULO_LISTADO = "Lista de Categorías Regentes";
            listar.ORDERBY = "order by CodigoCategoria";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoCategoria");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.CATEGORIAS_REGENTES_INSERTAR;
            editar = Constantes.CATEGORIAS_REGENTES_EDITAR;
            borrar = Constantes.CATEGORIAS_REGENTES_BORRAR;
            seleccionar = Constantes.CATEGORIAS_REGENTES_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmCategoriasEdicion"))
            {
                frmCategoriasEdicion frm = new frmCategoriasEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmCategoriasEdicion"))
            {
                ObtenerValoresPKListado();
                frmCategoriasEdicion frm = new frmCategoriasEdicion(listar.VALORES_PK);
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
                    listP.TABLA = "NV_CATEGORIAS";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Categoría para Regentes.rpt");
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
