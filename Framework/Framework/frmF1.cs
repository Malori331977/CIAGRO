using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Collections;
using System.Text.RegularExpressions;

namespace Framework
{
    public partial class frmF1 : Form
    {
        protected DataTable dt = new DataTable();
        protected Listado listar = new Listado();
        protected string error = "";
        public OLVListItem item;

        public frmF1(Listado listar)
        {
            InitializeComponent();
            this.listar = listar;
            cbTipoFiltro.SelectedIndex = 0;
            this.Text = listar.TITULO_LISTADO;
            actualizar();
            
        }

        private void actualizar()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!Consultas.listarDatos(listar, ref dt, ref error))
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (dt.Rows.Count > 0)
                {
                    flvF1.DataSource = dt;
                    flvF1.AutoResizeColumns();
                    if (flvF1.Items.Count > 0)
                    {
                        flvF1.Items[0].Selected = true;
                        flvF1.Items[0].Focused = true;
                        flvF1.EnsureVisible(0);
                        flvF1.FilterMenuBuildStrategy.MaxObjectsToConsider = dt.Rows.Count;

                        ListView.ColumnHeaderCollection columns = flvF1.Columns;

                        for (int i = 0; i < columns.Count; i++)
                        {
                            for (int j = 0; j < listar.COLUMNAS_NUMERICAS.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_NUMERICAS[j])
                                {
                                    flvF1.GetColumn(i).AspectToStringConverter = delegate(object aspect) { return ((decimal)aspect).ToString("N2"); };
                                    columns[i].TextAlign = HorizontalAlignment.Right;
                                }
                            }

                            for (int j = 0; j < listar.COLUMNAS_OCULTAS.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_OCULTAS[j])
                                {
                                    flvF1.GetColumn(i).MinimumWidth = 0;
                                    flvF1.GetColumn(i).MaximumWidth = 0;

                                }
                            }
                        }
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(this.flvF1, ((TextBox)sender).Text, cbTipoFiltro.SelectedIndex);
        }

        public void TimedFilter(ObjectListView olv, string txt, int matchKind)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flvF1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            item = flvF1.SelectedItem;
            Close();
        }

        private void flvF1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                item = flvF1.SelectedItem;
                Close();
            }
        }

        private void btnColumnas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            flvF1.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }
    }
}
