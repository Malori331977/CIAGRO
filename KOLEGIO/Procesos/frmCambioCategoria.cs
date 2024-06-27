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
    public partial class frmCambioCategoria : Form
    {
        private string error = "";
        private string identificadorF1Ini = "CategoriaInicio";
        private string identificadorF1Fin = "CategoriaFin";
        private int totalRegistros = 0;
        private int marcados = 0;
        private string idCole = "";
        private bool desdeColegiado = false;
        private bool esSesionIncorporacion = false;
        private bool RequiereLevantamiento = false;
        //private string consecutivoColegiado = "";
        private DataTable dtArtLevantamiento = new DataTable();
        private DataTable dtDatosRefrescar = new DataTable();
        private DataTable dtRefrescar = new DataTable();
        private FuncsInternas fInternas;
        private BindingSource source1 = new BindingSource();

        //public frmCambioCategoria()
        //{
        //    InitializeComponent();
        //    this.fInternas = new FuncsInternas();
        //    dgvColegiados.Columns.Clear();
        //    dtRefrescar.Columns.Add("Aplicar", typeof(Boolean));
        //    dtRefrescar.Columns.Add("Id Colegiado", typeof(String));
        //    dtRefrescar.Columns.Add("Nº Colegiado", typeof(String));
        //    dtRefrescar.Columns.Add("Nombre", typeof(String));
        //    dtRefrescar.Columns.Add("Estado", typeof(Image));
        //    dtRefrescar.Columns.Add("Observaciones", typeof(String));
        //}

        public frmCambioCategoria(string IdColegiado, string categoriaActual)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            desdeColegiado = true;
            idCole = IdColegiado;
            dgvColegiados.Columns.Clear();
            dtRefrescar.Columns.Add("Aplicar", typeof(Boolean));
            dtRefrescar.Columns.Add("Id Colegiado", typeof(String));
            dtRefrescar.Columns.Add("Nº Colegiado", typeof(String));
            dtRefrescar.Columns.Add("Nombre", typeof(String));
            dtRefrescar.Columns.Add("Estado", typeof(Image));
            dtRefrescar.Columns.Add("Observaciones", typeof(String));
            cargarDatosColegiados(IdColegiado,categoriaActual);
            //verificarConfigurablesCondicion();
        }

        private void cargarDatosColegiados(string colegiado, string categoriaActual)
        {
            txtCategoriaIni.Text = categoriaActual;
            txtCategoriaIni.ReadOnly = true;
            buscaCategoria(txtCategoriaIni.Text,identificadorF1Ini);
            refrescarDatos(colegiado);
        }

        private void bwProceso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = e.ProgressPercentage;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            dgvColegiados.EndEdit();
            if (dgvColegiados.RowCount > 0)
            {
                marcados = 0;
                foreach (DataGridViewRow row in dgvColegiados.Rows)
                {
                    if ((bool)row.Cells["Aplicar"].Value)
                    {
                        marcados += 1;
                    }
                }
                
                if (validarDatos())
                {
                    
                    btnSalir.Enabled = false;
                    btnProcesar.Enabled = false;
                    fInternas.deshabilitarOrdenDgv(ref dgvColegiados);
                    CheckForIllegalCrossThreadCalls = false;
                    pbProceso.Minimum = 0;
                    //pbProceso.Maximum = dgvColegiados.RowCount + 1;
                    pbProceso.Maximum = marcados;
                    bwProceso = new BackgroundWorker();

                    // Seteamos al bw que sea de manera Async.
                    bwProceso.DoWork += bwProceso_DoWork;

                    // Seteamos al bw que sea de manera Async.
                    bwProceso.ProgressChanged += bwProceso_ProgressChanged;

                    // Seteamos al bw que sea de manera Async.
                    bwProceso.RunWorkerCompleted += bwProceso_RunWorkerCompleted;

                    // Necesitamos setear esta propiedad para reportar al bw los cambios.
                    bwProceso.WorkerReportsProgress = true;

                    bwProceso.RunWorkerAsync();
                }
            }
            else
                MessageBox.Show("No hay información para procesar.", "Cambio de Condición de Colegiados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            procesoCambioCondicion();
        }

        private void bwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSalir.Enabled = true;
            btnProcesar.Enabled = true;
            fInternas.habilitarOrdenDgv(ref dgvColegiados);
            pbProceso.Value = 0; 
        }
        
        //private void verificarConfigurablesCondicion()
        //{
        //    bool OK = true;
        //    DataTable dt = new DataTable();
        //    Listado listA = new Listado();
        //    //listA.COLUMNAS = "CondicionFallecido,PermitePedConcepto,RequiereLevantamiento";
        //    listA.COLUMNAS = "CondicionIncorporacion";
        //    listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listA.TABLA = "NV_CONDICIONES";
        //    listA.FILTRO = "where CodigoCondicion = '" + txtCategoriaIni.Text + "'";
        //    //listA.ORDERBY = "order by CodigoTipo";

        //    if (Consultas.listarDatos(listA, ref dt, ref error))
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (dt.Rows[0]["CondicionIncorporacion"].ToString() == "S")
        //                esSesionIncorporacion = true;
        //            else
        //                esSesionIncorporacion = false;
        //            //if (dt.Rows[0]["CondicionFallecido"].ToString() == "S")
        //            //{

        //            //}
        //            //else
        //            //{

        //            //}

        //            //if (dt.Rows[0]["PermitePedConcepto"].ToString() == "S")
        //            //{

        //            //}
        //            //else
        //            //{

        //            //}

        //            //if (dt.Rows[0]["RequiereLevantamiento"].ToString() == "S")
        //            //{
        //            //    RequiereLevantamiento = true;
        //            //    string sQuery = "select t1.CodigoArticulo AS ARTICULO, t2.DESCRIPCION as DESCRIPCION, t3.PRECIO as PRECIO, '1' AS CANTIDAD" +
        //            //                    " from "+Consultas.sqlCon.COMPAÑIA+".NV_CONDICIONES_LEVANTAMIENTO_ART t1"+
        //            //                    " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t2 on t2.ARTICULO = t1.CodigoArticulo" +
        //            //                    " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t3 on t3.ARTICULO = t1.CodigoArticulo" +
        //            //                    " where t1.CodigoCondicion = '"+txtCondicionIni.Text+"'";

        //            //    OK = Consultas.fillDataTable(sQuery, ref dtArtLevantamiento,ref error);

        //            //    if (OK)
        //            //    {
        //            //        DataTable dtCondiLev = new DataTable();

        //            //        string sQueryCondicion = "select CondicionLevantamiento FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES" +
        //            //                        " where CodigoCondicion = '" + txtCondicionIni.Text + "'";
        //            //        OK = Consultas.fillDataTable(sQueryCondicion, ref dtCondiLev, ref error);

        //            //        if(dtCondiLev.Rows.Count > 0)
        //            //        {
        //            //            CondicionLevantamiento = dtCondiLev.Rows[0]["CondicionLevantamiento"].ToString();
        //            //            txtCondicionFin.Text = CondicionLevantamiento;
        //            //            txtCondicionFin.ReadOnly = true;
        //            //            buscaCondicion(txtCondicionFin.Text, identificadorF1Fin);
        //            //        }
        //            //    }

        //            //    if(!OK)
        //            //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            //}
        //            //else
        //            //{
        //            //    RequiereLevantamiento = false;
        //            //    CondicionLevantamiento = "";
        //            //    if (txtCondicionFin.ReadOnly)
        //            //    {
        //            //        txtCondicionFin.ReadOnly = false;
        //            //        txtCondicionFin.Clear();
        //            //        txtDescCondicionFin.Clear();
        //            //    }
                        
        //            //    dtArtLevantamiento = new DataTable();
        //            //}
        //        }
        //    }
        //    else
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        private void procesoCambioCondicion()
        {
            string error = "";
            //string consecutivo = "";
            int progreso = 0;
            DataTable dtArticulos = new DataTable();


            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                bool OK = true;

                if ((bool)row.Cells["Aplicar"].Value)
                {
                    try
                    {
                        Consultas.sqlCon.iniciaTransaccion();


                        string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CAMBIO_CATEGORIA (IdColegiado,CategoriaPrevia,CategoriaActual,SesionAprobacion,FechaAprobacion) " +
                            "VALUES ('" + row.Cells["Id Colegiado"].Value.ToString() + "','" + txtCategoriaIni.Text + "','" + txtCategoriaFin.Text + "','" + txtSesionApro.Text + "','" + dtpFechaApro.Value.ToString("yyyy-MM-ddTHH:mm:ss") + "')";
                        
                        OK = Consultas.ejecutarSentencia(sQuery, ref error);

                        //if (OK)
                        //{
                        //    consecutivo = fInternas.generarConsecutivo(consecutivoColegiado, ref error);

                        //    if (consecutivo == "")
                        //    {
                        //        error = "No se pudo generar el consecutivo del colegiado.";
                        //        OK = false;
                        //    }
                        //}

                        //if (OK)
                        //{
                        //    if (!fInternas.actualizarConsecutivo(fInternas.sgtValor(consecutivo), consecutivoColegiado, ref error))
                        //    {
                        //        error = "No se pudo actualizar el consecutivo del colegiado.";
                        //        OK = false;
                        //    }
                        //}

                        if (OK)
                        {
                            DataTable dt = new DataTable();
                            string sQueryNumCole = "select * from " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO where NumeroColegiado = '"+txtNumeroColegiado.Text+"' and IdColegiado != '"+idCole+"'";
                            
                            if (Consultas.fillDataTable(sQueryNumCole, ref dt, ref error))
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    OK = false;
                                    error = "Ya existe el numero de colegiado ingresado.";
                                }
                                    
                            }
                        }

                        if (OK)
                            OK = cambioCategoria(row.Cells["Id Colegiado"].Value.ToString(), txtCategoriaFin.Text,/* consecutivo,*/ ref error);


                        if (OK)
                        {
                            Consultas.sqlCon.Commit();
                            row.Cells["Estado"].Value = iList.Images[2];
                            row.Cells["Observaciones"].Value = "¡Cambio de Categoría Exitoso!";
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            row.Cells["Estado"].Value = iList.Images[1];
                            row.Cells["Observaciones"].Value = error;
                        }

                    }
                    catch (Exception ex)
                    {
                        Consultas.sqlCon.Rollback();
                        row.Cells["Estado"].Value = iList.Images[1];
                        row.Cells["Observaciones"].Value = ex.Message;
                    }
                progreso += 1;
                bwProceso.ReportProgress(progreso);
                }
                     
            }

        }

        private bool cambioCategoria(string idColegiado, string categ, /*string consecutivo,*/ ref string error)
        {
            //string strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Categoria = '" + categ + "', NumeroColegiado = '" + consecutivo + "' where IdColegiado='" + idColegiado + "'";
            string strSQL = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO set Categoria = '" + categ + "', NumeroColegiado = '" + txtNumeroColegiado.Text + "'  where IdColegiado='" + idColegiado + "'";
            return Consultas.ejecutarSentencia(strSQL, ref error); 
        }
        
        private bool validarDatos()
        {
            string error = "";
            bool OK = true;
            if (marcados == 0)
            {
                error = "Debe marcar los registros que proceden al cambio de categoría o marcar la casilla de masivo";
                chkMasivo.Focus();
                OK = false;
            }

            if (!txtFiltro.Text.Equals(""))
            {
                error = "Debe borrar el filtro para procesar";
                txtFiltro.Focus();
                OK = false;
            }

            if (txtCategoriaIni.Text.Trim() == "")
            {
                error = "Debe digitar la categoría inicial.";
                txtCategoriaIni.Focus();
                OK = false;
            }

            if (txtCategoriaFin.Text.Trim() == "")
            {
                error = "Debe digitar la categoría final.";
                txtCategoriaFin.Focus();
                OK = false;
            }

            if (txtSesionApro.Text.Trim() == "")
            {
                error = "Debe digitar la sesion de aprobación.";
                txtSesionApro.Focus();
                OK = false;
            }

            if (txtCategoriaFin.Text == txtCategoriaIni.Text)
            {
                error = "La categoría incial y la categoría final deben ser diferentes";
                txtCategoriaFin.Focus();
                OK = false;
            }

            if (txtNumeroColegiado.Text.Equals(""))
            {
                error = "Debe digitar el nuevo numero de colegiado";
                txtNumeroColegiado.Focus();
                OK = false;
            }

            //if (consecutivoColegiado == "")
            //{
            //    error = "La categoría de colegiado seleccionada no posee un consecutivo definido para la creación del colegiado.";
            //    OK = false;
            //}


            if (!OK)
            {
                MessageBox.Show(error, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return OK;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if(!desdeColegiado)
                refrescarDatos();
            else
                refrescarDatos(idCole);
        }

        private void refrescarDatos()
        {
            
            string sQuery = "SELECT IdColegiado,NumeroColegiado,Nombre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE Categoria ='" + txtCategoriaIni.Text + "'";
            //dtDatosRefrescar = new DataTable();
            //dtRefrescar = new DataTable();
            string error = "";
            try
            {
                dtDatosRefrescar.Rows.Clear();

                if (Consultas.fillDataTable(sQuery, ref dtDatosRefrescar, ref error))
                {
                    //dgvColegiados.DataSource = dtIngresos;
                    
                    //dgvColegiados.Rows.Clear();
                    //dgvColegiados.Columns.Clear();
                    dtRefrescar.Rows.Clear();
                    
                    totalRegistros = 0;

                    
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataRow row in dtDatosRefrescar.Rows)
                    {
                        totalRegistros += 1;
                        dtRefrescar.Rows.Add(false, row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                            row["Nombre"].ToString(), iList.Images[0], "");
                        //dgvColegiados.Rows.Add(false,row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                        //    row["Nombre"].ToString(), iList.Images[0], "");
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
                    Cursor.Current = Cursors.Default;

                    
                    DataView view = new DataView(dtRefrescar);
                    source1.DataSource = view;
                    dgvColegiados.DataSource = view;
                    dgvColegiados.AutoResizeColumns();
                    dgvColegiados.Refresh();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refrescarDatos(string idColegiado)
        {
            string sQuery = "SELECT NumeroColegiado,Nombre FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO WHERE IdColegiado = '"+idColegiado+"' and Categoria='" + txtCategoriaIni.Text + "'";

            string error = "";
            try
            {
                dtDatosRefrescar.Rows.Clear();

                if (Consultas.fillDataTable(sQuery, ref dtDatosRefrescar, ref error))
                {
                    //dgvColegiados.DataSource = dtIngresos;

                    //dgvColegiados.Rows.Clear();
                    //dgvColegiados.Columns.Clear();
                    dtRefrescar.Rows.Clear();

                    totalRegistros = 0;


                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataRow row in dtDatosRefrescar.Rows)
                    {
                        totalRegistros += 1;
                        dtRefrescar.Rows.Add(true, idColegiado, row["NumeroColegiado"].ToString(),
                            row["Nombre"].ToString(), iList.Images[0], "");
                        //dgvColegiados.Rows.Add(false,row["IdColegiado"].ToString(), row["NumeroColegiado"].ToString(),
                        //    row["Nombre"].ToString(), iList.Images[0], "");
                    }
                    lblRegistrosCant.Text = totalRegistros.ToString();
                    
                    DataView view = new DataView(dtRefrescar);
                    source1.DataSource = view;
                    dgvColegiados.DataSource = view;
                    dgvColegiados.AutoResizeColumns();
                    dgvColegiados.Refresh();
                    chkMasivo.Checked = false;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvColegiados.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        private void txtCategoriaIni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCategoriaIni.ReadOnly)
                listaCategorias(identificadorF1Ini);
        }

        private void listaCategorias(string IdentificadorF1)
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CATEGORIA_CLIENTE as Categoría,DESCRIPCION as Descripción,U_CONSECUTIVO Consecutivo";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CATEGORIA_CLIENTE";
            //if (IdentificadorF1 == identificadorF1Ini)
            //    listP.FILTRO = "WHERE U_KOLEGIO='S'";
            //else
                listP.FILTRO = "WHERE U_KOLEGIO='S' and CATEGORIA_CLIENTE in ('AFI','ORD')";
            listP.ORDERBY = "order by CATEGORIA_CLIENTE";
            listP.TITULO_LISTADO = "Categorías";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
               
                    
                if (IdentificadorF1 == identificadorF1Ini)
                {
                    txtCategoriaIni.Text = f1.item.SubItems[0].Text;
                    txtDescCategoriaIni.Text = f1.item.SubItems[1].Text;
                    //cargarDatosColegiados(idCole, txtCategoriaIni.Text);
                    refrescarDatos();
                    //verificarConfigurablesCondicion();
                }

                if (IdentificadorF1 == identificadorF1Fin)
                {
                    txtCategoriaFin.Text = f1.item.SubItems[0].Text;
                    txtDescCategoriaFin.Text = f1.item.SubItems[1].Text;
                    //consecutivoColegiado = f1.item.SubItems[2].Text;
                    //refrescarDatos();


                }
                    
                   
                
            }
        }

        private void buscaCategoria(string categ, string IdentificadorF1)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CATEGORIA_CLIENTE,DESCRIPCION,U_CONSECUTIVO";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "CATEGORIA_CLIENTE";
            //if (IdentificadorF1 == identificadorF1Ini)
            //    listA.FILTRO = "where U_KOLEGIO='S' and CATEGORIA_CLIENTE = '" + categ + "'";
            //else
                listA.FILTRO = "where U_KOLEGIO='S' and CATEGORIA_CLIENTE = '" + categ + "' and CATEGORIA_CLIENTE in ('AFI','ORD')";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (IdentificadorF1 == identificadorF1Ini)
                    {
                        txtCategoriaIni.Text = dtTTs.Rows[0]["CATEGORIA_CLIENTE"].ToString();
                        txtDescCategoriaIni.Text = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                    }

                    if (IdentificadorF1 == identificadorF1Fin)
                    {
                        txtCategoriaFin.Text = dtTTs.Rows[0]["CATEGORIA_CLIENTE"].ToString();
                        txtDescCategoriaFin.Text = dtTTs.Rows[0]["DESCRIPCION"].ToString();
                        //consecutivoColegiado = dtTTs.Rows[0]["U_CONSECUTIVO"].ToString();
                    }
                    
                }
                
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiar()
        {
            if (dgvColegiados.Rows.Count > 0)
            {
                dgvColegiados.Rows.Clear();
            }

        }

        private void txtCategoriaIni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCategoriaIni.ReadOnly)
            {
                listaCategorias(identificadorF1Ini);
            }
        }

        private void txtCategoriaFin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCategoriaFin.ReadOnly)
            {
                listaCategorias(identificadorF1Fin);
            }
        }

        private void txtCategoriaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCategoriaFin.ReadOnly)
            {
                listaCategorias(identificadorF1Fin);
            }
        }
        
        private void chkMasivo_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkMasivo.Checked)
            {
                activarMasivo();
            }
            else
            {
                desactivarMasivo();
            }
             
        }

        private void activarMasivo()
        {
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                //row.Cells["colSeleccion"].Value = true;
                row.Cells["Aplicar"].Value = true;
                //row.Cells["colSeleccion"].ReadOnly = true;
            }
            dgvColegiados.EndEdit();
            //chkMasivo.Checked = true;
        }

        private void desactivarMasivo()
        {
            foreach (DataGridViewRow row in dgvColegiados.Rows)
            {
                //row.Cells["colSeleccion"].Value = false;
                row.Cells["Aplicar"].Value = false;
                //row.Cells["colSeleccion"].ReadOnly = false;
            }
            dgvColegiados.EndEdit();

            //chkMasivo.Checked = false;
        }

        private void frmCambioCategoria_Load(object sender, EventArgs e)
        {
            dtpFechaApro.Value = DateTime.Now;
            
        }

        private void dgvColegiados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvColegiados.Rows.Count > 0)
            {
                bool masivo = true;
                if (dgvColegiados.CurrentCell.OwningColumn.Name == "Aplicar")
                {
                    if (e.RowIndex >= 0)
                    {
                        if ((bool)dgvColegiados.Rows[e.RowIndex].Cells["Aplicar"].Value == false)
                        {
                            dgvColegiados.Rows[e.RowIndex].Cells["Aplicar"].Value = true;
                        }
                        else
                            dgvColegiados.Rows[e.RowIndex].Cells["Aplicar"].Value = false;

                        foreach (DataGridViewRow row in dgvColegiados.Rows)
                        {
                            if (!(bool)row.Cells["Aplicar"].Value)
                            {
                                masivo = false;
                            }
                        }
                        dgvColegiados.EndEdit();

                        if (masivo)
                            chkMasivo.Checked = true;
                        else
                            chkMasivo.Checked = false;
                    }
                }
            }
        }
       
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (!txtCategoriaIni.Text.Equals(""))
            {
                if (!txtFiltro.Text.Equals(""))
                {
                    source1.Filter = "[Nº Colegiado] like '%" + txtFiltro.Text + "%' or [Id Colegiado] like '%" + txtFiltro.Text + "%' or [Nombre] like '%" + txtFiltro.Text + "%'";

                }
                else
                {
                    //refrescarDatos();
                }
            }
            else
            {
                MessageBox.Show("No hay información para filtrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFiltro.Clear();
            }
        }
    }
}
