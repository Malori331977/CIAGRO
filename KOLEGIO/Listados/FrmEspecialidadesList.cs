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
    public partial class FrmEspecialidadesList : frmListado
    {
        public FrmEspecialidadesList()
            : base()
        {
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "CodigoEspecialidad as Código, NombreEspecialidad as Nombre, DescripcionEspecialidad as Descripción";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_ESPECIALIDADES";
            listar.TITULO_LISTADO = "Lista de Especialidades";
            listar.ORDERBY = "order by CodigoEspecialidad";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("CodigoEspecialidad");
            listar.COLUMNAS_ALIAS_PK.Add("Código");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.ESPECIALIDADES_INSERTAR;
            editar = Constantes.ESPECIALIDADES_EDITAR;
            borrar = Constantes.ESPECIALIDADES_BORRAR;
            seleccionar = Constantes.ESPECIALIDADES_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmEspecialidadesEdicion"))
            {
                frmEspecialidadesEdicion frm = new frmEspecialidadesEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmEspecialidadesEdicion"))
            {
                ObtenerValoresPKListado();
                frmEspecialidadesEdicion frm = new frmEspecialidadesEdicion(listar.VALORES_PK);
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
                    listP.TABLA = "NV_ESPECIALIDADES";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "Reporte de Especialidades.rpt");
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
