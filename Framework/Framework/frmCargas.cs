﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Framework
{
    public partial class frmCargas : Form
    {
        public ManejoEventos evento = new ManejoEventos();
        public bool formEdited = new bool();
        protected Listado listar = new Listado();
        protected string error = "";
        protected DataTable dtDatos = new DataTable();
        protected List<string> valoresPk = new List<string>();
        protected List<string> parametros = new List<string>();
        protected string identificadorFormulario = "";

        public frmCargas()
        {
            InitializeComponent();
            initInstance();
        }

        public frmCargas(List<string> pk, string tipo = "")
        {
            InitializeComponent();
            this.valoresPk = pk;
            listar.VALORES_PK = pk;
            initInstance();
            if(pk.Count>0)
            cargarDatosAuditoria();
        }

        protected virtual void initInstance()
        {
            listar.COLUMNAS = "";
            listar.COMPAÑIA = "";
            listar.TABLA = "";
        }

        private void frmCargas_Load(object sender, EventArgs e)
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
            //btnGuardar.Enabled = true;
            //btnGuardarSalir.Enabled = true;
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
                        if (colsPKfechas > 1)
                        {
                            if (i + 1 < colsPKfechas)
                                listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + valoresPk[i] + "' AND ";
                            else
                                listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + valoresPk[i] + "'";
                        }
                        else
                            listar.FILTRO = listar.FILTRO + listar.COLUMNAS_PK_FECHAS[i] + "=" + "'" + valoresPk[i] + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error [armarFiltroPK].\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            //listar.TABLA = "VENCIMIENTOS";
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            limpiarAuditoria();
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
                    MessageBox.Show("Primero se debe guardar el registro para adjuntar archivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            frmAdjunto frm = new frmAdjunto(identificadorFormulario, llave);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminaAdjunto_Click(object sender, EventArgs e)
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            abrirArchivo();
        }

        protected virtual void abrirArchivo()
        {

        }

        protected virtual bool armarCodigoPeriodo()
        {
            return true;
        }

        protected virtual bool insertarDatosArchivo(ref string error,DataTable dt,string tipo,ref int progreso)
        {
            return true;
        }

        protected virtual bool insertarDatosSistema(ref string error,int indice,ref int progreso)
        {
            return true;
        }

        protected virtual void llenarListado()
        {
            
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            procesar(ref error);
        }

        protected virtual void procesar(ref string error)
        {
         
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Borrar", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Consultas.sqlCon.iniciaTransaccion();
                bool OK = true;
                
                OK = eliminarDetalle(ref error);
               
                if(OK)
                    OK = Consultas.eliminaRegistro(listar, identificadorFormulario, ref error);

                if (OK)
                {
                    Consultas.sqlCon.Commit();
                    listar.VALORES_PK.Clear();
                    limpiarFormulario();
                    txtFechaCreacion.Clear();
                    txtFechaModificacion.Clear();
                    txtNomUserCreacion.Clear();
                    txtNomUserModificacion.Clear();
                    txtUserCreacion.Clear();
                    txtUserModificacion.Clear();
                }
                else
                {
                    Consultas.sqlCon.Rollback();
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual bool eliminarDetalle(ref string error)
        {
            return true;
        }

        private void btnPlantillaPv_Click(object sender, EventArgs e)
        {
            plantillaPrivada();
        }

        protected virtual void plantillaPrivada()
        {

        }

        private void btnColumnas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            flvListado.AutoResizeColumns();
            Cursor.Current = Cursors.Default;
        }
    }
}
