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
    public partial class FrmCarrerasList : frmListado
    {
        public FrmCarrerasList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoCarrera as Código, NombreCarrera as 'Título Académico'";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_CARRERAS";
            listar.TITULO_LISTADO = "Lista de Títulos Académicos";
            listar.ORDERBY = "order by CodigoCarrera";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoCarrera");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.TITULOS_ACADEMICOS_INSERTAR;
            editar = Constantes.TITULOS_ACADEMICOS_EDITAR;
            borrar = Constantes.TITULOS_ACADEMICOS_BORRAR;
            seleccionar = Constantes.TITULOS_ACADEMICOS_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmCarrerasEdicion"))
            {
                frmCarrerasEdicion frm = new frmCarrerasEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmCarrerasEdicion"))
            {
                ObtenerValoresPKListado();
                frmCarrerasEdicion frm = new frmCarrerasEdicion(listar.VALORES_PK);
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
                    listP.TABLA = "NV_CARRERAS";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Títulos Académicos.rpt");
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
