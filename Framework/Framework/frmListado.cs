using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BrightIdeasSoftware;
using System.Collections;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Framework
{
    public partial class frmListado : Form
    {
        protected DataTable dt = new DataTable();
        protected Listado listar = new Listado();
        protected string error = "";
        bool iniciando = true;
        protected bool filtro = false;
        private List<string> valoresFiltro = new List<string>();
        protected string listado = "", seleccionar = "", insertar = "", editar = "", borrar = "";

        public frmListado()
        {
            InitializeComponent();
            initInstance();
            cbTipoFiltro.SelectedIndex = 0;
            iniciando = false;
            
        }

        public List<string> Valores_Filtro
        {
            get { return valoresFiltro; }
            set { valoresFiltro = value; }
        }

        protected virtual void initInstance()
        {
            listar.COLUMNAS = "";
            listar.COMPAÑIA = ""; 
            listar.TABLA = "";
            this.Text = listar.TITULO_LISTADO;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, seleccionar))
            {
                actualizar();
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para listar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void actualizar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

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
                                    flvListado.GetColumn(i).AspectToStringConverter = delegate(object aspect)
                                    {
                                        if (aspect != System.DBNull.Value)
                                            return ((decimal)aspect).ToString("N2");
                                        else
                                            return "";
                                    };
                                    columns[i].TextAlign = HorizontalAlignment.Right;
                                }
                            }

                            for (int j = 0; j < listar.COLUMNAS_OCULTAS.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_OCULTAS[j])
                                {
                                    flvListado.GetColumn(i).MinimumWidth = 0;
                                    flvListado.GetColumn(i).MaximumWidth = 0;
                                }
                            }

                            for (int j = 0; j < listar.COLUMNAS_FECHAS.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_FECHAS[j])
                                {
                                    flvListado.GetColumn(i).AspectToStringConverter = delegate(object aspect)
                                    {
                                        if (aspect != System.DBNull.Value)
                                            return ((DateTime)aspect).ToString("dd/MM/yyyy");
                                        else
                                            return "";
                                    };
                                    //columns[i].TextAlign = HorizontalAlignment.Right;
                                }
                            }
                            for (int j = 0; j < listar.COLUMNAS_NUMERICAS_INT.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_NUMERICAS_INT[j])
                                {
                                    flvListado.GetColumn(i).AspectToStringConverter = delegate(object aspect)
                                    {
                                        if (aspect != System.DBNull.Value)
                                            return ((int)aspect).ToString("#,###,###");
                                        else
                                            return "";
                                    };
                                    columns[i].TextAlign = HorizontalAlignment.Right;
                                }
                            }

                        }
                    }
                    else
                    {
                        ListView.ColumnHeaderCollection columns = flvListado.Columns;
                        for (int i = 0; i < columns.Count; i++)
                        {
                            for (int j = 0; j < listar.COLUMNAS_OCULTAS.Count; j++)
                            {
                                if (columns[i].Name == listar.COLUMNAS_OCULTAS[j])
                                {
                                    flvListado.GetColumn(i).MinimumWidth = 0;
                                    flvListado.GetColumn(i).MaximumWidth = 0;
                                }
                            }
                        }
                    }
                    flvListado.AutoResizeColumns();
                    lblCantidad.Text = flvListado.Items.Count.ToString("N0");
                    lblCantidad.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error cargando los datos.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private  void btnExcel_Click(object sender, EventArgs e)
        {

           // bwProceso = new BackgroundWorker();

            // Seteamos al bw que sea de manera Async.
          //  bwProceso.DoWork += bwProceso_DoWork;

            // Seteamos al bw que sea de manera Async.
            //bwProceso.RunWorkerCompleted += bwProceso_RunWorkerCompleted;

          //  bwProceso.RunWorkerAsync();

           /* ThreadStart delegado = new ThreadStart(exportarExcel);
            Thread hilo = new Thread(delegado);
            hilo.Start(); */
            exportarExcel();
        }

        private void exportarExcel()
        {


            if (flvListado.Items.Count == 0)
            {
                MessageBox.Show("No existen datos para exportar a excel.", "Exportación a excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //DateTime tiempo1 = DateTime.Now;
                /*   Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                   Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
                   Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

                   //int i2 = 2;
                   DataTable dt = (DataTable)flvListado.DataSource;
                   int columnas = dt.Columns.Count;
                   int rows = dt.Rows.Count;

                       for (int col = 0; col < columnas; col++)
                       {
                         ws.Cells[1, col + 1] = dt.Columns[col].ColumnName;
                       }

                       for (int i = 0; i < rows; i++)
                       {
                           for (int j = 0; j < columnas; j++)
                           {
                               ws.Cells[i + 2, j + 1] = dt.Rows[i][j];
                           }
                       }

                       app.Visible = true;*/

                MSExcel.Application Excel = new MSExcel.Application();
                Excel.Workbooks.Add();

                // single worksheet
                MSExcel._Worksheet Worksheet = Excel.ActiveSheet;
                List<string> columns = new List<string>();

                for (int i = 0; i < flvListado.Columns.Count; i++)
                {
                    if (flvListado.Columns[i].Width > 0)
                        columns.Add(flvListado.Columns[i].Name);
                }



                /*    for (int i=0; i<columnas; i++)
                    {
                        for (int j = 0; j < listar.COLUMNAS_OCULTAS.Count; j++)
                        {
                            if (listar.COLUMNAS_OCULTAS[j] == columns[i])
                                columns.Remove(listar.COLUMNAS_OCULTAS[j]);
                        }
                    }*/
                int columnas = columns.Count;
                int rows = flvListado.VirtualListSize;
                object[] Header = new object[columnas];

                // column headings               
                for (int i = 0; i < columnas; i++)
                {
                    Header[i] = columns[i];
                }

                MSExcel.Range HeaderRange = Worksheet.get_Range((MSExcel.Range)(Worksheet.Cells[1, 1]), (MSExcel.Range)(Worksheet.Cells[1, columnas]));
                HeaderRange.Value = Header;
                HeaderRange.Font.Bold = true;
                HeaderRange.Interior.Color = ColorTranslator.ToOle(Color.Gainsboro);

                // DataCells

                object[,] Cells = new object[rows, columnas];
                bool fecha = false, numero=false;
                for (int j = 0; j < rows; j++)
                {
                    for (int i = 0; i < columnas; i++)
                    {

                        fecha = false;
                        for (int k = 0; k < listar.COLUMNAS_FECHAS.Count; k++)
                        {
                            if (columns[i] == listar.COLUMNAS_FECHAS[k])
                            {
                                if (flvListado.GetItem(j).GetSubItem(i).Text != "")
                                    Cells[j, i] = DateTime.Parse(flvListado.GetItem(j).GetSubItem(i).Text).ToString("yyyy-MM-dd");
                                else
                                    Cells[j, i] = "";
                                fecha = true;
                                break;
                            }
                        }

                        numero = false;
                        for (int k = 0; k < listar.COLUMNAS_NUMERICAS.Count; k++)
                        {
                            if (columns[i] == listar.COLUMNAS_NUMERICAS[k])
                            {
                                if (flvListado.GetItem(j).GetSubItem(i).Text != "")
                                    Cells[j, i] = flvListado.GetItem(j).GetSubItem(i).Text;
                                else
                                    Cells[j, i] = "";
                                numero = true;
                                break;
                            }
                        }

                        if (!fecha && !numero)
                            Cells[j, i] = "'"+flvListado.GetItem(j).GetSubItem(i).Text;
                    }
                }
                Worksheet.Name = listar.TITULO_LISTADO;
                Worksheet.get_Range((MSExcel.Range)(Worksheet.Cells[2, 1]), (MSExcel.Range)(Worksheet.Cells[rows + 1, columnas])).Value = Cells;
                Excel.Visible = true;
                // DateTime tiempo2 = DateTime.Now;
                // TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
                // MessageBox.Show("Duracion: " + total.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la exportación de datos a excel: " + ex.Message, "Exportación a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

      
        private void frmListado_Load(object sender, EventArgs e)
        {
            System.Reflection.PropertyInfo propiedadListView = typeof(FastDataListView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            propiedadListView.SetValue(flvListado, true, null);
            this.Text = listar.TITULO_LISTADO;
        }

        private void dgListado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Consultas.sqlCon.USUARIO.Equals("SA") || Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || Consultas.sqlCon.USUARIO.Contains("_admin"))
            {
                Cursor.Current = Cursors.WaitCursor;
                abrirEdicion();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                //if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, editar))
                if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, seleccionar))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    abrirEdicion();
                    Cursor.Current = Cursors.Default;
                }
                else
                    MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void abrirEdicion()
        {
         
        }

        private void dgListado_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (flvListado.Items.Count > 0)
            //    flvListado.SelectedColumn.DisplayIndex = 0;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
          // TimedFilter(this.flvListado, ((TextBox)sender).Text, cbTipoFiltro.SelectedIndex);
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

        private void dgListado_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && flvListado.SelectedItem != null && flvListado.Items.Count > 0)
            {
                if (Consultas.sqlCon.USUARIO.Equals("SA") || Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || Consultas.sqlCon.USUARIO.Contains("_admin"))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    abrirEdicion();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, editar))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        abrirEdicion();
                        Cursor.Current = Cursors.Default;
                    }
                    else
                        MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }

            if (e.Control == true && e.KeyCode == Keys.B)
            {
                e.Handled = true;
                txtFiltro.Focus();
            }


            //if (e.KeyCode == Keys.Back)
            //{
            //    if (lbltexto.Text.Length > 0)
            //    {
            //        lbltexto.Text = lbltexto.Text.Remove(lbltexto.Text.Length - 1);
            //    }
            //}
            //else
            //{

            //    lbltexto.Text = Regex.Replace(lbltexto.Text + (char)e.KeyValue, @"[^\w\.@-]", "");
            //    if (flvListado.Items.Count > 0)
            //        buscarSubitem();
            //    timer1.Start();
            //}
        }

        private void cbTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!iniciando)
            TimedFilter(this.flvListado, txtFiltro.Text, cbTipoFiltro.SelectedIndex);
        }

        private void dgListado_ColumnRightClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == -1)
                return;
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

        private void buscarSubitem()
        {
            flvListado.FindItemWithText(lbltexto.Text,true,0,true); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (flvListado.Items.Count == 0)
                return;

            if (Consultas.sqlCon.USUARIO.Equals("SA") || Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || Consultas.sqlCon.USUARIO.Contains("_admin"))
            {
                Cursor.Current = Cursors.WaitCursor;
                abrirEdicion();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, editar))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    abrirEdicion();
                    Cursor.Current = Cursors.Default;
                }
                else
                    MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (Consultas.sqlCon.USUARIO.Equals("SA") || Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || Consultas.sqlCon.USUARIO.Contains("_admin"))
            {
                eliminar();
            }
            else
            {
                if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, borrar))
                    eliminar();
                else
                    MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIOS Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Cursor.Current = Cursors.Default;
        }

        private void eliminar()
        {
            bool OK = true;
            try
            {
                
                ObtenerValoresPKListado();
                if (listar.VALORES_PK.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (listar.TABLA_ELIMINAR == "")
                            listar.TABLA_ELIMINAR = listar.TABLA;

                        Consultas.sqlCon.iniciaTransaccion();
                        OK = eliminarDetalle(ref error);
                        

                        if(OK)
                            OK = Consultas.eliminaRegistro(listar, listar.TITULO_LISTADO, ref error);

                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            actualizar();
                            listar.VALORES_PK.Clear();
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            manejoErroresEliminar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listar.VALORES_PK.Clear();
                MessageBox.Show("Ocurrió un error borrando el registro.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }


        protected virtual bool eliminarDetalle(ref string error)
        {
            return true;
        }

        protected virtual void manejoErroresEliminar()
        {
            if (error.Contains("PK"))
                error = "Ya existe un registro con el mismo código en la base de datos.";

           if (error.Contains("FK") || error.Contains("FOREIGN KEY"))
            {
                string tabla = error.Split('"')[5].Split('.')[1];
                string columna = error.Split('"')[6].Split('.')[0].Replace(", column ", "");
                error = "No se pudo eliminar este registro, existen datos dependientes con la tabla '" + tabla + "' Columna " + columna + "";
            }

            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Consultas.sqlCon.USUARIO.Equals("SA") || Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || Consultas.sqlCon.USUARIO.Contains("_admin"))
            {
                abrirEdicionNuevo();
            }
            else
            {
                if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, insertar))
                    abrirEdicionNuevo();
                else
                    MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        protected virtual void abrirEdicionNuevo()
        {
          
        }

        private void bwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            exportarExcel();
        }

       
        protected void ObtenerValoresPKListado()
        {
            if (flvListado.SelectedItem != null)
            {
                listar.VALORES_PK.Clear();
                ListView.ColumnHeaderCollection columns = flvListado.Columns;
                for (int i = 0; i < columns.Count; i++)
                {
                    int index = 0;
                    bool esColumnasPK = false;

                    for (int j = 0; j < listar.COLUMNAS_PK.Count; j++)
                    {
                        if (columns[i].Name == listar.COLUMNAS_ALIAS_PK[j])
                        {
                            esColumnasPK = !esColumnasPK;
                            index = columns[i].Index;
                            listar.VALORES_PK.Add(flvListado.SelectedItem.SubItems[index].Text);
                            break;
                        }
                    }

                    if (!esColumnasPK)
					{
                        for (int j = 0; j < listar.COLUMNAS_PK_FECHAS.Count; j++)
                        {
                            if (columns[i].Name == listar.COLUMNAS_PK_FECHAS[j])
                            {
                                index = columns[i].Index;
                                listar.VALORES_PK.Add(DateTime.Parse(flvListado.SelectedItem.SubItems[index].Text).ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            }
                        }
					}

                }
            }
        }

        private void btnBuscaRapida_Click(object sender, EventArgs e)
        {
            abrirFiltro();

            if(filtro)
            {
                btnBuscaRapida.Image = imageList1.Images[1];
            }
            else
            {
                btnBuscaRapida.Image = imageList1.Images[0];
            }
                
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                TimedFilter(this.flvListado, ((TextBox)sender).Text, cbTipoFiltro.SelectedIndex);
                Cursor.Current = Cursors.Default;

                if (txtFiltro.Text.Trim() != "")
                    label1.BackColor = Color.Yellow;
                else
                    label1.BackColor = Color.Transparent;
            }
        }

        protected virtual void abrirFiltro()
        {
             MessageBox.Show("No existen opciones de filtro en este listado.", "KOLEGIO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);  
        }

        private void btnColumnas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            flvListado.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            ayudaListado();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            lbltexto.Text = "";
            timer1.Stop();
        }

        private void flvListado_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            lblCantidad.Refresh();
            lblCantidad.Text = flvListado.registrosFiltrados.ToString("N0");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirReporte();
        }

        protected virtual void imprimirReporte()
        {

        }

        protected virtual void ayudaListado()
        {

        }

    }
}
