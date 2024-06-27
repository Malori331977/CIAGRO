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
    public partial class frmMachotesEdicion : frmEdicion
    {
        private string oldValue = "";
        private FuncsInternas fInternas;
        private decimal totalPlantillaCobro = 0;

        public frmMachotesEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 15;
            txtNombre.Longitud = 100;
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Plantillas";
                lblPerfil.Text = "Perfil de Plantilla";

                listar.COLUMNAS = "CodigoPlantilla,NombrePlantilla,CodigoFrecuencia,AplicaClienteErp";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_MACHOTES";
                identificadorFormulario = "De Machotes";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoPlantilla");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                //insertar = Constantes.TT_INSERTAR;
                //editar = Constantes.TT_EDITAR;
                //borrar = Constantes.TT_BORRAR;
                //seleccionar = Constantes.TT_SELECCIONAR;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void cargarDatos()
        {
            try
            {
                tabControl.TabPages.Remove(tpAdjuntos);
                tabControl.TabPages.Remove(tpAdmin);
                tabControl.TabPages.Add(tpAdmin);

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["NombrePlantilla"].ToString();
                                txtCodigo.Valor = row["CodigoPlantilla"].ToString();
                                txtCodigo.ReadOnly = true;
                                cargarFrecuencia(row["CodigoFrecuencia"].ToString());
                                if (row["AplicaClienteErp"].ToString().Equals("S"))
                                {
                                    chkAplicaClienteERP.Checked = true;
                                }
                                cargarArticulos();
                                lblPerfil.Text = "Perfil de Plantilla: " + txtNombre.Valor;
                            }
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtCodigo.Valor);
            parametros.Add(txtNombre.Valor);
            if (!txtFrec.Valor.ToString().Equals(""))
                parametros.Add(txtFrec.Valor);
            else
                parametros.Add("null");
            if (chkAplicaClienteERP.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");
            return true;
        }

        private void cargarArticulos()
        {
            dgvArticulos.Rows.Clear();
            DataTable dt = new DataTable();
            //string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION, case when T2.COSTO_FISCAL = 'P' then T2.COSTO_PROM_LOC else T2.COSTO_STD_LOC end as 'Costo Local',case when T2.COSTO_FISCAL = 'P' then T2.COSTO_PROM_DOL else T2.COSTO_STD_DOL end as 'Costo Dólar' from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
            //  "ON T1.CodigoArticulo=T2.ARTICULO and T1.CodigoPlantilla='" + txtCodigo.Valor.Trim() + "' order by T1.CodigoArticulo";
            string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION,T3.PRECIO, t1.ArticuloFms from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
                "ON T1.CodigoArticulo=T2.ARTICULO JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T3 ON T1.CodigoArticulo=T3.ARTICULO " +
                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = T3.NIVEL_PRECIO AND t6.VERSION = T3.VERSION AND(CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                " where T1.CodigoPlantilla='" + txtCodigo.Valor.Trim() + "' order by T1.CodigoArticulo";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                //decimal costoLOC = 0;
                //decimal costoDOL = 0;
                decimal precio = 0;
                totalPlantillaCobro = 0;
                foreach (DataRow row in dt.Rows)
                {
                    //if (row["Costo Local"].ToString() != "")
                    //    costoLOC = decimal.Parse(row["Costo Local"].ToString());

                    //if (row["Costo Dólar"].ToString() != "")
                    //    costoDOL = decimal.Parse(row["Costo Dólar"].ToString());
                    if (row["PRECIO"].ToString() != "")
                            precio = decimal.Parse(row["PRECIO"].ToString());

                        //dgvArticulos.Rows.Add(row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(), costoLOC, costoDOL);
                        dgvArticulos.Rows.Add(row["ArticuloFms"].ToString() == "S" ? true : false, row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(),precio.ToString("N2"));
                    totalPlantillaCobro += precio;
                }
                lblTotalPlantilla.Text = totalPlantillaCobro.ToString("N2");
            }
            else
                MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para la Plantilla.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para la Plantilla.";
                txtNombre.Focus();
                return false;
            }

            if (validarAplicaCliente())
            {
                error = "Ya existe una Plantilla que aplica para ingresar a cliente.";
                chkAplicaClienteERP.Focus();
                return false;
            }

            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                if ((bool)row.Cells["colArticuloFms"].Value)
                {
                    if (validarFMS())
                    {
                        error = "Ya existe un articulo FMS.";
                        //chkAplicaClienteERP.Focus();
                        return false;
                    }
                }
            }

            

            return true;
        }

        protected override void limpiarFormulario()
        {
            totalPlantillaCobro = 0;
            lblTotalPlantilla.Text = totalPlantillaCobro.ToString("N2");
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            txtFrec.Clear();
            chkAplicaClienteERP.Checked = false;
            dgvArticulos.Rows.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Plantilla";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Plantilla: " + txtNombre.Valor;
        }

        protected override bool guardarDetalle(ref string error)
        {
            bool OK = true;
            DataTable dtFms = new DataTable();
            int marcadas = 0;

            string sSelect = "SELECT CodigoPlantilla,CodigoArticulo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART WHERE ArticuloFms = 'S'";

            OK = Consultas.fillDataTable(sSelect, ref dtFms, ref error);


            string sQuery1 = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART SET ArticuloFms = 'N'";
            
            if (OK)
            {
                string sQuery = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART SET ArticuloFms = @ArticuloFms WHERE CodigoPlantilla = @Plantilla AND CodigoArticulo = @Articulo";

                foreach (DataGridViewRow row in dgvArticulos.Rows)
                {
                    if ((bool)row.Cells["colArticuloFms"].Value)
                    {
                        marcadas++;
                        OK = Consultas.ejecutarSentencia(sQuery1, ref error);

                        parametros.Clear();
                        parametros.Add("@Plantilla," + txtCodigo.Valor);
                        parametros.Add("@Articulo," + row.Cells["colArticulo"].Value.ToString());
                        parametros.Add("@ArticuloFms," + "S");

                        OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);
                    }
                }

                if (dtFms.Rows.Count > 0)
                {
                    if (dtFms.Rows[0]["CodigoPlantilla"].ToString() == txtCodigo.Valor && marcadas == 0)
                    {
                        OK = Consultas.ejecutarSentencia(sQuery1, ref error);
                    }
                }

            }

            return OK;
        }

        private bool validarAplicaCliente()
        {
            bool OK = true;
            string sSelect = "";
            DataTable dtAplicaClie = new DataTable();

            if(chkAplicaClienteERP.Checked == true)
            {
                sSelect = "SELECT AplicaClienteErp,CodigoPlantilla FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES WHERE AplicaClienteErp = 'S'";
                OK = Consultas.fillDataTable(sSelect, ref dtAplicaClie, ref error);

                if (OK && dtAplicaClie.Rows.Count > 0 && dtAplicaClie.Rows[0]["CodigoPlantilla"].ToString() != txtCodigo.Valor)
                    return true;
            }
            
            return false;
        }

        private bool validarFMS()
        {
            bool OK = true;
            string sSelect = "";
            DataTable dtFms = new DataTable();

            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                
                sSelect = "SELECT ArticuloFms,CodigoPlantilla,CodigoArticulo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART WHERE ArticuloFms = 'S'";
                OK = Consultas.fillDataTable(sSelect, ref dtFms, ref error);

                if (OK && dtFms.Rows.Count > 0)
                {
                    if(dtFms.Rows[0]["CodigoPlantilla"].ToString() != txtCodigo.Valor)
                        return true;
                }
                 
            }
         
            return false;
        }

        private bool validarArticulo(string articulo)
        {
            foreach (DataGridViewRow r in dgvArticulos.Rows)
            {
                if (r.Cells["colArticulo"].Value.ToString().Equals(articulo))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PLANTILLAS_EDITAR))
            {
                if (valoresPk.Count == 0)
                {
                    MessageBox.Show("Primero debe guardar la Plantilla para agregar artículos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                listaArticulos();
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private bool InsertarDetalle(string articulo, ref string error)
        {
            bool OK = true;
            string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART (CodigoPlantilla,CodigoArticulo) " +
                    "VALUES (@Plantilla,@Articulo)";

            parametros.Clear();
            parametros.Add("@Plantilla," + txtCodigo.Valor);
            parametros.Add("@Articulo," + articulo);
            //parametros.Add("@ArticuloFms," + articulo);

            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

            return OK;
        }

        private bool EliminarDetalle(string art, ref string error)
        {
            bool OK = true;
            string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART WHERE CodigoPlantilla = @Plantilla and CodigoArticulo = @Articulo";

            parametros.Clear();
            parametros.Add("@Plantilla," + txtCodigo.Valor);
            parametros.Add("@Articulo," + art);

            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

            return OK;
        }

        private void btnEliminarCampo_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PLANTILLAS_BORRAR))
            {
                if (dgvArticulos.Rows.Count > 0)
                {
                    if (EliminarDetalle(dgvArticulos.Rows[dgvArticulos.SelectedRows[0].Index].Cells["colArticulo"].Value.ToString(), ref error))
                    {
                        dgvArticulos.Rows.RemoveAt(dgvArticulos.SelectedRows[0].Index);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error eliminando.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }
      
        private void listaArticulos()
        {
            Listado listP = new Listado();
            //listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción, case when COSTO_FISCAL = 'P' then COSTO_PROM_LOC else COSTO_STD_LOC END as 'Costo Local',case when COSTO_FISCAL = 'P' then COSTO_PROM_DOL else COSTO_STD_DOL END as 'Costo Dólar'";
            listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "ARTICULO";
            listP.ORDERBY = "order by ARTICULO";
            listP.FILTRO = "where ARTICULO like 'KOL-%' and TIPO = 'V'";
            listP.TITULO_LISTADO = "Artículos";
            //listP.COLUMNAS_NUMERICAS.Add("Costo Local");
            //listP.COLUMNAS_NUMERICAS.Add("Costo Dólar");

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                if (!validarArticulo(f1.item.SubItems[0].Text))
                {
                    MessageBox.Show("Ya existe un detalle con la misma información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (InsertarDetalle(f1.item.SubItems[0].Text, ref error))
                {
                    DataTable dt = new DataTable();

                    string sQuery = "SELECT PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO ARTICULO " +
                        " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = ARTICULO.NIVEL_PRECIO AND t6.VERSION = ARTICULO.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A'" +
                        " where ARTICULO='" + f1.item.SubItems[0].Text + "' ";

                    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                    {
                        decimal precio = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["PRECIO"].ToString() != "")
                                precio = decimal.Parse(row["PRECIO"].ToString());
                        }

                        dgvArticulos.Rows.Add(false,f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, precio.ToString("N2"));
                    }
                    else
                        MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //dgvArticulos.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, decimal.Parse(f1.item.SubItems[2].Text), decimal.Parse(f1.item.SubItems[3].Text));
                    //dgvArticulos.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error insertando.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cargarFrecuencia(string codigo)
        {

            DataTable dtFrec = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "CONDICION_PAGO , DESCRIPCION ";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CONDICION_PAGO";
            listP.FILTRO = "where CONDICION_PAGO='" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtFrec, ref error))
            {
                if (dtFrec.Rows.Count > 0)
                {
                    txtFrec.Valor = dtFrec.Rows[0]["CONDICION_PAGO"].ToString();
                    txtFrecDescripcion.Valor = dtFrec.Rows[0]["DESCRIPCION"].ToString();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buscaFrecuencia(string codigo)
        {

            if (txtFrec.Valor.Trim() == "")
            {
                txtFrecDescripcion.Clear();
                return;
            }

            DataTable dtFrec = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "CONDICION_PAGO , DESCRIPCION ";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CONDICION_PAGO";
            listP.COLUMNAS_NUMERICAS_INT.Add("Días");
            listP.FILTRO = "where CONDICION_PAGO='" + txtFrec.Valor + "'";

            if (Consultas.listarDatos(listP, ref dtFrec, ref error))
            {
                if (dtFrec.Rows.Count > 0)
                {
                    txtFrecDescripcion.Valor = dtFrec.Rows[0]["DESCRIPCION"].ToString();
                }
                else
                {
                    if (codigo != "")
                        MessageBox.Show("La frecuencia digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void listaFrecuencias()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CONDICION_PAGO as 'Código', DESCRIPCION as 'Frecuencia'";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "CONDICION_PAGO";
            listP.ORDERBY = "order by CONDICION_PAGO";
            listP.TITULO_LISTADO = "Frecuencias de Pago";
            listP.COLUMNAS_NUMERICAS_INT.Add("Días");


            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                txtFrec.Valor = f1.item.SubItems[0].Text;
                txtFrecDescripcion.Valor = f1.item.SubItems[1].Text;
            }
        }

        private void txtFrecuencia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaFrecuencias();
        }

        private void txtFrecuencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaFrecuencias();
        }

        private void txtFrecuencia_Leave(object sender, EventArgs e)
        {
            buscaFrecuencia(txtFrec.Valor);
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvArticulos.CurrentCell.OwningColumn.Name == "colArticuloFms")
                {
                    if ((bool)dgvArticulos.Rows[e.RowIndex].Cells["colArticuloFms"].Value == false)
                    {
                        foreach (DataGridViewRow row in dgvArticulos.Rows)
                        {
                            if ((bool)row.Cells["colArticuloFms"].Value)
                            {
                                row.Cells["colArticuloFms"].Value = false;
                            }
                        }
                        dgvArticulos.Rows[e.RowIndex].Cells["colArticuloFms"].Value = true;
                    }
                    else
                        dgvArticulos.Rows[e.RowIndex].Cells["colArticuloFms"].Value = false;

                    dgvArticulos.EndEdit();

                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;

                }
            }
                
        }

        private void frmMachotesEdicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //fInternas.actualizarMachotesColegiadosMasivo(txtCodigo.Valor,ref error);
            ////MessageBox.Show("Se esta cerrando la ventana", "Hola", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Cursor.Current = Cursors.Default;
        }
    }
}
