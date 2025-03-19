using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.UserControls;
using System.IO;
using System.IO.Compression;

namespace Framework
{
    public partial class frmEdicion : Form
    {

        public ManejoEventos evento = new ManejoEventos();
        public bool formEdited = new bool();
        protected Listado listar = new Listado();
        protected string error = "";
        protected DataTable dtDatos = new DataTable();
        protected List<string> valoresPk = new List<string>();
        protected List<string> parametros = new List<string>();
        protected string identificadorFormulario = "";
       // private int seguridad = -1;
        protected int identity = -1;
        protected string listado="",seleccionar="",insertar="",editar="",borrar="";
        protected bool cerrar = false;
        public frmEdicion()
        {
            InitializeComponent();
            initInstance();
        }


        public frmEdicion(List<string> pk,string tipo="")
        {
            InitializeComponent();
            this.valoresPk = pk;
            listar.VALORES_PK = pk;
            initInstance();
            if (pk.Count > 0)
            {
                btnEliminar.Enabled = true;
                btnProcesar.Enabled = true;
                cargarDatosAuditoria();
            }
        }

        protected virtual void initInstance()
        {
            listar.COLUMNAS = "";
            listar.COMPAÑIA = "";
            listar.TABLA = "";
        }


        private void frmEdicion_Load(object sender, EventArgs e)
        {
            evento.FormEditedEvent += new FormEditedEventHandler(OnFormEditedEvent);
            this.Text = listar.TITULO_LISTADO;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnFormEditedEvent(object sender, EditedEventArgument e)
        {
            modificacion(e);
        }

        private void modificacion(EditedEventArgument e)
        {
            formEdited = e.formEdited;
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        protected virtual void cargarDatos()
        {
            if (!Consultas.listarDatos(listar, ref dtDatos, ref error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = "";
            }
        }

        private void cargarDatosAuditoria()
        {
          /*  if (listar.TABLA.Contains(","))
            {
                listar.TABLA = listar.TABLA.Split(',')[0];
            }*/

            if (Consultas.listarDatosAuditoria(listar, ref dtDatos, ref error))
            {
                if (dtDatos.Rows.Count > 0)
                {
                    txtUserCreacion.Text = dtDatos.Rows[0]["UsuarioCreacionAdmin"].ToString();
                    txtFechaCreacion.Text = dtDatos.Rows[0]["FechaCreacionAdmin"].ToString();
                    txtUserModificacion.Text = dtDatos.Rows[0]["UsuarioUltModificacionAdmin"].ToString();
                    txtFechaModificacion.Text = dtDatos.Rows[0]["FechaUltModificacionAdmin"].ToString();

                    if (txtUserCreacion.Text == "SA")
                        txtNomUserCreacion.Text = "Administrador del Sistema";
                    else
                        txtNomUserCreacion.Text = dtDatos.Rows[0]["NombreUsuarioCreacion"].ToString();

                    if (txtUserModificacion.Text == "SA")
                        txtNomUserModificacion.Text = "Administrador del Sistema";
                    else
                        txtNomUserModificacion.Text = dtDatos.Rows[0]["NombreUsuarioModificacion"].ToString();
                }
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = "";
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            guardarDatos();
            Cursor.Current = Cursors.Default;
        }

        protected bool guardarDatos()
        {
            bool OK = true;
             try
            {
                if (!Consultas.sqlCon.USUARIO.Equals("SA") || !Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || !Consultas.sqlCon.USUARIO.Contains("_admin"))
                {
                    if (valoresPk.Count == 0)
                    {
                        if (!Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, insertar))
                        {
                            MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        if (!Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, editar))
                        {
                            MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                string errores = "";
                if (validarDatos(ref errores))
                {
                    if (!llenarParametros())
                        return false;
                    Consultas.sqlCon.iniciaTransaccion();

                    if (!guardarDetallePrevio(ref error))
                    {
                        Consultas.sqlCon.Rollback();
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (valoresPk.Count == 0)
                    {
                        if (Consultas.insertar(parametros, listar, identificadorFormulario, ref error))
                        {
                            // MessageBox.Show("Se insertó el nuevo registro con éxito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            if (guardarDetalle(ref error))
                            {
                                deshabilitarLlave();
                                /* txtUserModificacion.Text = Consultas.sqlCon.USUARIO;
                                 txtFechaModificacion.Text = DateTime.Now.ToString("dd/MM/yyyyThh:mm:ss tt");
                                 txtUserCreacion.Text = Consultas.sqlCon.USUARIO;
                                 txtFechaCreacion.Text = txtFechaModificacion.Text;*/
                                btnGuardar.Enabled = false;
                                btnGuardarSalir.Enabled = false;
                                Consultas.sqlCon.Commit();
                                btnEliminar.Enabled = true;
                            }
                            else
                            {
                                Consultas.sqlCon.Rollback();
                                manejoErrores();
                                OK = false;
                            }

                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            manejoErrores();
                            OK = false;
                        }
                    }
                    else
                    {
                        if (Consultas.actualizar(parametros, listar, identificadorFormulario, ref error))
                        {
                            if (guardarDetalle(ref error))
                            {
                                //txtUserModificacion.Text = Consultas.sqlCon.USUARIO;
                                //txtFechaModificacion.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                                // MessageBox.Show("Se actualizó el registro con éxito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                deshabilitarLlave();
                                btnGuardar.Enabled = false;
                                btnGuardarSalir.Enabled = false;
                                Consultas.sqlCon.Commit();
                            }
                            else
                            {
                                Consultas.sqlCon.Rollback();
                                manejoErrores();
                                OK = false;
                            }
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            manejoErrores();
                            OK = false;
                        }
                    }
                    cargarDatosAuditoria();
                }
                else
                {
                    if (errores != "")
                        MessageBox.Show(errores, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //errores = "";
                    OK = false;
                }
            }
            catch (Exception ex)
            {
                if(Consultas.sqlCon.TRANSACCION!=null)
                    Consultas.sqlCon.Rollback();

                MessageBox.Show("Error al guardar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = "";
                OK = false;
            }

             return OK;
        }

        protected bool procesarPedido()
        {
            bool OK = true;
            try
            {
                if (!Consultas.sqlCon.USUARIO.Equals("SA") || !Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || !Consultas.sqlCon.USUARIO.Contains("_admin"))
                {
                    if (valoresPk.Count == 0)
                    {
                        //Revisar privilegios
                        if (!Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, insertar))
                        {
                            MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        if (!Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, editar))
                        {
                            MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                string errores = "";
                if (validarDatosPedidos(ref errores))
                {
                    Consultas.sqlCon.iniciaTransaccion();
                    
                    if (valoresPk.Count == 0)
                    {
                        MessageBox.Show("El colegiado debe estar registrado en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        if (generarFacturas(ref error))
                        {
                            //deshabilitarLlave();
                            btnProcesar.Enabled = false;
                            //btnGuardarSalir.Enabled = false;
                            Consultas.sqlCon.Commit();
                            MessageBox.Show("Se facturo con éxito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            
                        }
                        else
                        {
                            Consultas.sqlCon.Rollback();
                            manejoErrores();
                            OK = false;
                        }
                    }
                    //cargarDatosAuditoria();
                }
                else
                {
                    if (errores != "")
                        MessageBox.Show(errores, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //errores = "";
                    OK = false;
                }
            }
            catch (Exception ex)
            {
                if (Consultas.sqlCon.TRANSACCION != null)
                    Consultas.sqlCon.Rollback();

                MessageBox.Show("Error al generar el pedido.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = "";
                OK = false;
            }

            return OK;
        }

        protected virtual bool llenarParametros()
        {
            return true;
        }

        protected virtual bool salir()
        {
            return true;
        }  

        protected virtual bool guardarDetallePrevio(ref string error)
        {
            error = "";
            return true;
        }   

        protected virtual bool guardarDetalle(ref string error)
        {
            error = "";
            return true;
        }

        protected virtual bool actualizarDetalle(ref string error)
        {
            error = "";
            return true;
        }

        protected virtual bool validarDatos(ref string error)
        {
            return true;
        }

        protected virtual bool validarDatosPedidos(ref string error)
        {
            return true;
        }

        protected virtual bool generarPedidos(ref string error)
        {
            error = "";
            return true;
        }

        protected virtual bool generarFacturas(ref string error)
        {
            error = "";
            return true;
        }

        protected void armarFiltroPK(List<string> valoresPK)
        {
            try
            {
                int colsPK = listar.COLUMNAS_PK.Count;
                int colsPKfechas = listar.COLUMNAS_PK_FECHAS.Count;
                if (valoresPk.Count > 0)
                {
                    listar.FILTRO = " WHERE ";
                    for (int i = 0; i < colsPK; i++)
                    {
                        if (colsPK > 1)
                        {
                            if (i + 1 < colsPK)
                                listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK[i] + "=" + "'" + valoresPk[i] + "' AND ";
                            else
                                listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK[i] + "=" + "'" + valoresPk[i] + "'";
                        }
                        else
                            listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK[i] + "=" + "'" + valoresPk[i] + "'";
                    }

                    for (int i = 0; i < colsPKfechas; i++)
                    {
                        //if (colsPKfechas > 1)
                        //{
                        //    if (i + 1 < colsPKfechas)
                        //        listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + valoresPk[i] + "' AND ";
                        //    else
                        //        listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + valoresPk[i] + "'";
                        //}
                        //else
                        //    listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + valoresPk[i] + "'";
                        if (colsPK > 0)
                        {
                            if (colsPKfechas > 1)
                            {
                                if (i + 1 < colsPKfechas)
                                    listar.FILTRO += " AND " + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + listar.VALORES_PK[i + 1] + "' AND ";
                                else
                                    listar.FILTRO += " AND " + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + listar.VALORES_PK[i + 1] + "'";
                            }
                            else
                                listar.FILTRO += " AND " + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + listar.VALORES_PK[i + 1] + "'";
                        }
                        else
                        {
                            if (colsPKfechas > 1)
                            {
                                if (i + 1 < colsPKfechas)
                                    listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + listar.VALORES_PK[i] + "' AND ";
                                else
                                    listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + listar.VALORES_PK[i] + "'";
                            }
                            else
                                listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + listar.VALORES_PK[i] + "'";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error [armarFiltroPK].\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Consultas.sqlCon.USUARIO.Equals("SA") || Consultas.sqlCon.USUARIO.Equals("ADMSASEG") || Consultas.sqlCon.USUARIO.Contains("_admin"))
            {
                limpiarFormulario();
                limpiarAuditoria();
            }
            else
            {
                if (Consultas.tienePrivilegios(Consultas.sqlCon.USUARIO, insertar))
                {
                    limpiarFormulario();
                    limpiarAuditoria();
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
                    MessageBox.Show("No tiene privilegios suficientes para ejecutar esta opción del sistema.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Cursor.Current = Cursors.Default;
        }

        private void eliminar()
        {
            if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Consultas.sqlCon.iniciaTransaccion();
                    bool OK = true;
                    OK = eliminarDetalle(ref error);

                    if (OK)
                        OK = Consultas.eliminaRegistro(listar, identificadorFormulario, ref error);

                    if (OK)
                    {
                        eliminarAfter(ref error);
                        Consultas.sqlCon.Commit();
                        listar.VALORES_PK.Clear();
                        limpiarFormulario();
                        txtFechaCreacion.Clear();
                        txtFechaModificacion.Clear();
                        txtNomUserCreacion.Clear();
                        txtNomUserModificacion.Clear();
                        txtUserCreacion.Clear();
                        txtUserModificacion.Clear();
                        btnGuardar.Enabled = false;
                        btnGuardarSalir.Enabled = false;
                    }
                    else
                    {
                        Consultas.sqlCon.Rollback();
                        manejoErrores();
                    }
                }
                catch (Exception ex)
                {
                    if (Consultas.sqlCon.TRANSACCION != null)
                        Consultas.sqlCon.Rollback();

                    MessageBox.Show("Ocurrió un error eliminando el registro.\n\n"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual void eliminarAfter(ref string error)
        {
        }

        protected virtual bool eliminarDetalle(ref string error)
        {
            return true;
        }

        protected virtual void manejoErrores()
        {
            if (error.Contains("PK") )
                error = "Ya existe un registro con el mismo código en la base de datos.";

            if (error.Contains("unique"))
            {
                char[] separador = { '(', ')' };
                string[] codigo = error.Split(separador);
                error = "Ya existe un registro con el codigo "+ codigo[1]+ " en la base de datos.";
            }
                
            if (error.Contains("FK") || error.Contains("FOREIGN KEY"))
            {
                string tabla = error.Split('"')[5].Split('.')[1];
                string columna = error.Split('"')[6].Split('.')[0].Replace(", column ", "");
                error = "No se pudo completar el proceso, existen datos dependientes con la tabla '"+tabla+"' Columna "+columna+ $" {error}";
            }
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = "";
        }

        protected virtual void limpiarFormulario()
        {

        }

        protected virtual void deshabilitarLlave()
        {

        }

        private void limpiarAuditoria()
        {
            txtUserCreacion.Clear();
            txtNomUserCreacion.Clear();
            txtFechaCreacion.Clear();

            txtUserModificacion.Clear();
            txtNomUserModificacion.Clear();
            txtFechaModificacion.Clear();

            btnGuardar.Enabled = false;
            btnGuardarSalir.Enabled = false;
        }

        private void frmEdicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool salir = this.salir();
            if (!cerrar)
            {
                if (btnGuardar.Enabled && btnGuardar.Visible)
                {
                    if (MessageBox.Show("¿Existen modificaciones sin guardar, está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        e.Cancel = false;
                    else
                        e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
            else
            {
                if (salir)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void btnGuardarSalir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            guardarDatos();
            Cursor.Current = Cursors.Default;
            Close();
        }

        private void btnNuevoAdjunto_Click(object sender, EventArgs e)
        {
            string llave = "";

            if (valoresPk.Count > 1)
            {
                for (int i = 0; i < valoresPk.Count; i++)
                {
                    llave += valoresPk[i] + "|";
                }

                llave = llave.Remove(llave.Length - 1);
            }
            else
                if (valoresPk.Count == 1)
                    llave = valoresPk[0];
                else
                {
                    MessageBox.Show("Primero se debe guardar el registro para adjuntar archivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            frmAdjunto frm = new frmAdjunto(identificadorFormulario,llave);
            frm.ShowDialog();
            listadoArchivos();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tpAdjuntos")
                listadoArchivos();
            
        }

        private void btnActualizaAdjunto_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            listadoArchivos();
            Cursor.Current = Cursors.Default;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void listadoArchivos()
        {
            try
            {
                string llave = armarLlaveAdjunto();

                DataTable dt = new DataTable();
                if (Consultas.listadoAdjuntos(llave, this.identificadorFormulario, ref dt, ref error))
                {
                    flvListado.DataSource = dt;
                    flvListado.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string consecutivo = flvListado.SelectedItem.SubItems[2].Text;
                string nombreDoc = flvListado.SelectedItem.SubItems[1].Text;
                string llave = armarLlaveAdjunto();
                string archivoEnBD = flvListado.SelectedItem.SubItems[3].Text;
                byte[] archivo = null;

                if (archivoEnBD == "S")
                {
                    if (Consultas.obtenerAdjunto(llave, this.identificadorFormulario, consecutivo, ref archivo, ref error))
                    {
                        string tempDirectory = Path.GetTempPath();
                        string ruta = tempDirectory + nombreDoc;

                        using (GZipStream stream = new GZipStream(new MemoryStream(archivo),
                               CompressionMode.Decompress))
                        {
                            const int size = 4096;
                            byte[] buffer = new byte[size];
                            using (MemoryStream memory = new MemoryStream())
                            {
                                int count = 0;
                                do
                                {
                                    count = stream.Read(buffer, 0, size);
                                    if (count > 0)
                                    {
                                        memory.Write(buffer, 0, count);
                                    }
                                }
                                while (count > 0);
                                memory.ToArray();
                                File.WriteAllBytes(ruta, memory.ToArray());
                                System.Diagnostics.Process.Start(ruta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = "";
                    }
                }
                else
                {
                    if (archivoEnBD == "N")
                    {
                        string sQuery = "SELECT RutaAlmacenamientoAdjuntos FROM "+Consultas.sqlCon.COMPAÑIA+".NV_GLOBALES";
                        DataTable dt = new DataTable();
                        if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                string ruta = dt.Rows[0][0].ToString();
                                System.Diagnostics.Process.Start(ruta + nombreDoc);
                            }
                        }
                    }
                    else
                    {
                        string sQuery = "SELECT NombreArchivo from "+Consultas.sqlCon.COMPAÑIA+".NV_ARCHIVO_ADJUNTO where origen='" + identificadorFormulario + "' and llaveOrigen='" + llave + "' and consecutivo=" + consecutivo;
                        DataTable dt = new DataTable();
                        if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                string nombreArchivo = dt.Rows[0][0].ToString();
                                System.Diagnostics.Process.Start(nombreArchivo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminaAdjunto_Click(object sender, EventArgs e)
        {
            if (flvListado.Items.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro que desea borrar este archivo?", "KOLEGIO", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    string consecutivo = flvListado.SelectedItem.SubItems[2].Text;
                    try
                    {
                        string llave = armarLlaveAdjunto();
                        if (Consultas.eliminaAdjunto(llave, identificadorFormulario, consecutivo, ref error))
                        {
                            listadoArchivos();
                        }
                        else
                        {
                            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            error = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            procesarPedido();
            Cursor.Current = Cursors.Default;
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

        private string armarLlaveAdjunto()
        {
            string llave = "";
            if (valoresPk.Count > 1)
            {
                for (int i = 0; i < valoresPk.Count; i++)
                {
                    llave += valoresPk[i] + "|";
                }

                llave = llave.Remove(llave.Length - 1);
            }
            else
                if (valoresPk.Count == 1)
                    llave = valoresPk[0];

            return llave;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirReporte();
        }

        protected virtual void imprimirReporte()
        {

        }

        private void btnColumnas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            flvListado.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }

        protected virtual void actualizar()
        {
          
        }

    }
}
