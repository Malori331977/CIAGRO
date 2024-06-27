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
    public partial class frmListEstablecimientos : frmListado
    {
        string NumColegiado = "";
        public frmListEstablecimientos()
        {
            InitializeComponent();
        }

        public frmListEstablecimientos(string NumCole)
        {
            NumColegiado = NumCole;
            InitializeComponent();
        }

        protected override void initInstance()
        {
            listar.COLUMNAS = "t1.NumRegistro as Número,t1.Nombre,t1.Representante,t1.Telefono,"+
                "(select NOMBRE from "+Consultas.sqlCon.COMPAÑIA+ ".DIVISION_GEOGRAFICA1 where DIVISION_GEOGRAFICA1 = t1.Provincia) as Provincia,"+
                "(select NOMBRE from " + Consultas.sqlCon.COMPAÑIA + ".DIVISION_GEOGRAFICA2 where DIVISION_GEOGRAFICA1 = t1.Provincia and DIVISION_GEOGRAFICA2 = t1.Canton) as Canton," +
                "(select NOMBRE from " + Consultas.sqlCon.COMPAÑIA + ".DIVISION_GEOGRAFICA3 where DIVISION_GEOGRAFICA1 = t1.Provincia and DIVISION_GEOGRAFICA2 = t1.Canton and DIVISION_GEOGRAFICA3 = t1.Distrito) as Distrito," +
                "(select NombreEstado from " +Consultas.sqlCon.COMPAÑIA+".NV_ESTADOS where CodigoEstado = t1.Estado) as Estado";
            listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listar.TABLA = "NV_ESTABLECIMIENTOS t1";
            listar.TABLA_ELIMINAR = "NV_ESTABLECIMIENTOS";
            listar.TITULO_LISTADO = "Lista de Establecimientos";
            listar.ORDERBY = "order by NumRegistro";

            //COLUMNAS PRIMARY KEY
            listar.COLUMNAS_PK.Add("NumRegistro");
            listar.COLUMNAS_ALIAS_PK.Add("Número");

            listar.COLUMNAS_OCULTAS.Add("CodigoProvincia");

            //COLUMNAS QUE MUESTRAN FILTRO AGRUPADO
            //listar.COLUMNAS_UILFG.Add("TIPO");
            //COLUMNAS NUMERICAS (FORMAT 'N2')
            //listar.COLUMNAS_NUMERICAS.Add("MONTO");

            insertar = Constantes.ESTABLECIMIENTO_INSERTAR;
            editar = Constantes.ESTABLECIMIENTO_EDITAR;
            borrar = Constantes.ESTABLECIMIENTO_BORRAR;
            seleccionar = Constantes.ESTABLECIMIENTO_SELECCIONAR;
            actualizar();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmEstablecimientosEdicion"))
            {
                frmEstablecimientosEdicion frm = new frmEstablecimientosEdicion(new List<string>());
                frm.Show();
            }
        }

        protected override void abrirEdicion()
        {
            if (Utilitario.BuscaForm("frmEstablecimientosEdicion"))
            {
                ObtenerValoresPKListado();
                if (!NumColegiado.Equals("")) { 
                    frmEstablecimientosEdicion frm = new frmEstablecimientosEdicion(listar.VALORES_PK,NumColegiado);
                    frm.Show();
                }
                else
                {
                    frmEstablecimientosEdicion frm = new frmEstablecimientosEdicion(listar.VALORES_PK);
                    frm.Show();
                }
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
                    listP.TABLA = "NV_RPT_ESTABLECIMIENTOS";
                    Cursor.Current = Cursors.WaitCursor;
                    if (Consultas.listarDatos(listP, ref dtRptCarteraGeneral, ref error))
                    {
                        if (dtRptCarteraGeneral.Rows.Count > 0)
                        {

                            frmVisorRpt rptCG = new frmVisorRpt(dtRptCarteraGeneral, "RPT_Establecimientos.rpt");
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

    }
}
