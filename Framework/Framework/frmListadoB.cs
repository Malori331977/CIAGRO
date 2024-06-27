using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Collections;

namespace Framework
{
    public partial class frmListadoB : Form
    {
        protected DataTable dt = new DataTable();
        protected Listado listar = new Listado();
        protected string error = "";
        bool iniciando = true;

        public frmListadoB()
        {
            InitializeComponent();
            initInstance();
            cbTipoFiltro.SelectedIndex = 0;
            iniciando = false;
        }

        protected virtual void initInstance()
        {
            listar.COLUMNAS = "";
            listar.COMPAÑIA = "";
            listar.TABLA = "";
            this.Text = listar.TITULO_LISTADO;
        }

        protected void actualizar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                listar.FILTRO = "WHERE FECHA_SOLICITUD BETWEEN '" + dtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + " 23:59:59'";
                if (!Consultas.listarDatos(listar, ref dt, ref error))
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = "";
                }
                else
                {
                    flvListado.DataSource = dt;
                    if (dt.Rows.Count > 0)
                    {
                        if (flvListado.GetItemCount() > 0)
                        {
                            flvListado.Items[0].Selected = true;
                            flvListado.Items[0].Focused = true;
                            flvListado.EnsureVisible(0);
                        }
                        flvListado.FilterMenuBuildStrategy.MaxObjectsToConsider = dt.Rows.Count;

                        ListView.ColumnHeaderCollection columns = flvListado.Columns;

                        for (int i = 0; i < columns.Count; i++)
                        {
                            for (int j = 0; j < listar.COLUMNAS_NUMERICAS.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_NUMERICAS[j])
                                {
                                    flvListado.GetColumn(i).AspectToStringConverter = delegate(object aspect) { return ((decimal)aspect).ToString("N2"); };
                                    columns[i].TextAlign = HorizontalAlignment.Right;
                                }
                            }
                        }
                    }
                    flvListado.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error cargando los datos.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportarExcel()
        {
            if (flvListado.DataSource == null)
            {
                MessageBox.Show("No existen datos para exportar a excel.", "Exportación a excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                int i2 = 2;

                for (int col = 0; col < flvListado.Columns.Count; col++)
                {
                    ws.Cells[1, col + 1] = flvListado.Columns[col].Text;
                }

                for (int i = 0; i < flvListado.VirtualListSize; i++)
                {
                    for (int j = 0; j < flvListado.Items[i].SubItems.Count; j++)
                    {
                        ws.Cells[i2, j + 1] = "'" + flvListado.Items[i].SubItems[j].Text;
                    }
                    i2++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la exportación de datos a excel: " + ex.Message, "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        private void frmListadoB_Load(object sender, EventArgs e)
        {
            System.Reflection.PropertyInfo propiedadListView = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            propiedadListView.SetValue(flvListado, true, null);
            this.Text = listar.TITULO_LISTADO;
        }

        private void flvListado_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            flvListado.SelectedColumn.DisplayIndex = 0;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(this.flvListado, ((TextBox)sender).Text, cbTipoFiltro.SelectedIndex);
        }

        public void TimedFilter(ObjectListView olv, string txt, int matchKind)
        {
            try
            {
                TextMatchFilter filter = null;
                if (!String.IsNullOrEmpty(txt))
                {
                    switch (matchKind)
                    {
                        case 0:
                        default:
                            filter = TextMatchFilter.Contains(olv, txt);
                            break;
                        case 1:
                            filter = TextMatchFilter.Prefix(olv, txt);
                            break;
                        case 2:
                            filter = TextMatchFilter.Regex(olv, txt);
                            break;
                    }
                }

                // Text highlighting requires at least a default renderer
                if (olv.DefaultRenderer == null)
                    olv.DefaultRenderer = new HighlightTextRenderer(filter);


                olv.AdditionalFilter = filter;
                //olv.Invalidate();

                IList objects = olv.Objects as IList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!iniciando)
                TimedFilter(this.flvListado, txtFiltro.Text, cbTipoFiltro.SelectedIndex);
        }

        private void flvListado_ColumnRightClick(object sender, ColumnClickEventArgs e)
        {
            flvListado.SelectedColumn = flvListado.GetColumn(e.Column);

            if (listar.COLUMNAS_UILFG.Count == 0)
                flvListado.SelectedColumn.UseInitialLetterForGroup = true;
            else
            {
                for (int i = 0; i < listar.COLUMNAS_UILFG.Count; i++)
                {
                    if (listar.COLUMNAS_UILFG[i] == flvListado.SelectedColumn.Name)
                    {
                        flvListado.SelectedColumn.UseInitialLetterForGroup = false;
                        break;
                    }
                    else
                        flvListado.SelectedColumn.UseInitialLetterForGroup = true;
                }
            }
            
        }
    }
}
