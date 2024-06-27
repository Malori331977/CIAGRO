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
    public partial class frmCondicionesEdicion : frmEdicion
    {
        private string oldValue = "";

        public frmCondicionesEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 50;
            rtbDescripcion.Longitud = 1024;
            txtPlantilla.Longitud = 15;
            txtPlantilla.Mayusculas();
            dgvArticulosLevantamiento.Columns["colPrecioLev"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvArticulosLevantamiento.Columns["colPrecioLev"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvArticulos.Columns["colPrecio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvArticulos.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Condiciones Colegiado";
                lblPerfil.Text = "Perfil de Condición Colegiado";

                listar.COLUMNAS = "CodigoCondicion,NombreCondicion,DescripcionCondicion,CodigoPlantilla,GeneraCobro,RequiereRegresoCondicion,CondicionRegreso,CondicionFallecido,PermitePedConcepto,CondicionIncorporacion,RequiereLevantamiento,CondicionLevantamiento,RequiereCambioCondicionEdad,CondicionCambioEdad,EdadPorCambio";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_CONDICIONES";
                identificadorFormulario = "De Condiciones";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoCondicion");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.CONDICIONES_INSERTAR;
                editar = Constantes.CONDICIONES_EDITAR;
                borrar = Constantes.CONDICIONES_BORRAR;
                seleccionar = Constantes.CONDICIONES_SELECCIONAR;

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
                rbMensual.Checked = true;

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["NombreCondicion"].ToString();
                                txtCodigo.Valor = row["CodigoCondicion"].ToString();
                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionCondicion"].ToString();
                                txtCondicion.Valor = row["CondicionRegreso"].ToString();
                                cargarCondicion(txtCondicion.Valor,"condicionRegreso");
                                if (row["GeneraCobro"].ToString()=="MEN")
                                {
                                    rbMensual.Checked = true;
                                    rbAnual.Checked = false;
                                    rbNoGenera.Checked = false;

                                }

                                if (row["GeneraCobro"].ToString() == "ANU")
                                {
                                    rbMensual.Checked = false;
                                    rbAnual.Checked = true;
                                    rbNoGenera.Checked = false;
                                }

                                if (row["GeneraCobro"].ToString() == "NO")
                                {
                                    rbMensual.Checked = false;
                                    rbAnual.Checked = false;
                                    rbNoGenera.Checked = true;
                                }

                                if (row["RequiereRegresoCondicion"].ToString() == "S")
                                    chkRequiereRegresoCondicion.Checked = true;
                                else
                                    chkRequiereRegresoCondicion.Checked = false;

                                if (row["CondicionFallecido"].ToString() == "S")
                                    chkFallecido.Checked = true;
                                else
                                    chkFallecido.Checked = false;

                                if (row["PermitePedConcepto"].ToString() == "S")
                                    chkPedConcepto.Checked = true;
                                else
                                    chkPedConcepto.Checked = false;

                                if (row["CondicionIncorporacion"].ToString() == "S")
                                    chkIncorporacion.Checked = true;
                                else
                                    chkIncorporacion.Checked = false;

                                txtCondicionLev.Valor = row["CondicionLevantamiento"].ToString();
                                if (row["RequiereLevantamiento"].ToString() == "S")
                                {
                                    chkRequiereLevantamiento.Checked = true;
                                    btnAgregarArticulo.Enabled = true;
                                    btnEliminarArticulo.Enabled = true;
                                    txtCondicionLev.ReadOnly = false;
                                    cargarCondicion(txtCondicionLev.Valor, "condicionLevantamiento");
                                }
                                else
                                    chkRequiereLevantamiento.Checked = false;

                                if (row["RequiereCambioCondicionEdad"].ToString() == "S")
                                {
                                    chkRequiereCambioCondicionEdad.Checked = true;
                                    txtEdad.ReadOnly = false;
                                    txtCondicionEdad.ReadOnly = false;
                                    txtCondicionEdad.Valor = row["CondicionCambioEdad"].ToString();
                                    txtEdad.Valor = row["EdadPorCambio"].ToString();
                                    cargarCondicion(txtCondicionEdad.Valor, "cambioCondicionEdad");
                                }
                                else
                                    chkRequiereCambioCondicionEdad.Checked = false;

                                cargarPlantilla(row["CodigoPlantilla"].ToString());
                                cargarArticulos();
                                lblPerfil.Text = "Perfil de Condición Colegiado: " + txtNombre.Valor;
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
            parametros.Add(rtbDescripcion.Text);
            
            if (!txtPlantilla.Valor.Equals(""))
                parametros.Add(txtPlantilla.Valor);
            else
                parametros.Add("null");
            if (rbMensual.Checked)
                parametros.Add("MEN");

            if (rbAnual.Checked)
                parametros.Add("ANU");

            if (rbNoGenera.Checked)
                parametros.Add("NO");

            if (chkRequiereRegresoCondicion.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");
            
            if (!txtCondicion.Valor.Equals(""))
                parametros.Add(txtCondicion.Valor);
            else
                parametros.Add("null");

            if (chkFallecido.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (chkPedConcepto.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (chkIncorporacion.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (chkRequiereLevantamiento.Checked)
            {
                parametros.Add("S");
                if (!txtCondicionLev.Valor.Equals(""))
                    parametros.Add(txtCondicionLev.Valor);
            }
            else
            {
                parametros.Add("N");
                parametros.Add("null");
                //foreach (DataGridViewRow r in dgvArticulosLevantamiento.Rows)
                //{
                //    EliminarDetalle(r.Cells["colArticuloLev"].Value.ToString(),ref error);
                //}

            }

            if (chkRequiereCambioCondicionEdad.Checked)
            {
                parametros.Add("S");
                if (!txtCondicionEdad.Valor.Equals(""))
                    parametros.Add(txtCondicionEdad.Valor);

                if (!txtEdad.Valor.Equals(""))
                    parametros.Add(txtEdad.Valor);
            }
            else
            {
                parametros.Add("N");
                parametros.Add("null");
                parametros.Add("null");
            }

            //if (!txtCondicionLev.Valor.Equals(""))
            //    parametros.Add(txtCondicionLev.Valor);
            //else
            //    parametros.Add("null");

            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para la Condición Colegiado.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para la Condición Colegiado.";
                txtNombre.Focus();
                return false;
            }

            if (chkRequiereRegresoCondicion.Checked)
            {
                if (txtCondicion.Valor.Trim() == "")
                {
                    error = "Debe especificar una condicion de regreso.";
                    txtCondicion.Focus();
                    return false;
                }
            }

            if (chkRequiereCambioCondicionEdad.Checked)
            {
                if (txtCondicionEdad.Valor.Trim() == "")
                {
                    error = "Debe especificar una condicion de cambio por edad.";
                    txtCondicionEdad.Focus();
                    return false;
                }

                if (txtEdad.Valor.Trim() == "")
                {
                    error = "Debe especificar la edad.";
                    txtEdad.Focus();
                    return false;
                }
            }

            if (chkRequiereLevantamiento.Checked)
            {
                if (txtCondicionLev.Valor.Trim() == "")
                {
                    error = "Debe especificar una condicion de levantamiento.";
                    txtCondicion.Focus();
                    return false;
                }

                if (dgvArticulosLevantamiento.Rows.Count == 0)
                {
                    error = "Debe añadir minimo un articulo de levantamiento.";
                    tabControl.SelectedTab = tpConfigurables;
                    return false;
                }

            }

            //foreach (DataGridViewRow row in dgvArticulosLevantamiento.Rows)
            //{
            //    if ((bool)row.Cells["colFmsLev"].Value)
            //    {
            //        if (validarFMS())
            //        {
            //            error = "Ya existe un articulo FMS de Condicion.";
            //            tabControl.SelectedTab = tpConfigurables;
            //            return false;
            //        }
            //    }
            //}

            if (validarCondFallecido())
            {
                error = "Ya existe una Condicion para Fallecido.";
                chkFallecido.Focus();
                return false;
            }

            if (validarCondIncorporacion())
            {
                error = "Ya existe una Condicion para Incorporación.";
                chkIncorporacion.Focus();
                return false;
            }

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            chkFallecido.Checked = false;
            chkRequiereRegresoCondicion.Checked = false;
            txtCondicion.Clear();
            txtDescCondicion.Clear();
            chkRequiereCambioCondicionEdad.Checked = false;
            txtCondicionEdad.Clear();
            txtDescCondicionEdad.Clear();
            txtEdad.Clear();
            chkRequiereLevantamiento.Checked = false;
            chkIncorporacion.Checked = false;
            chkPedConcepto.Checked = false;
            rtbDescripcion.Clear();

            limpiarPlantilla();
            limpiarLevantamiento();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Condición Colegiado";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Condición Colegiado: " + txtNombre.Valor;
        }

        private bool validarCondIncorporacion()
        {
            bool OK = true;
            string sSelect = "";
            DataTable dt = new DataTable();

            if (chkIncorporacion.Checked == true)
            {
                sSelect = "SELECT CondicionIncorporacion,CodigoCondicion FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES WHERE CondicionIncorporacion = 'S'";
                OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

                if (OK && dt.Rows.Count > 0 && dt.Rows[0]["CodigoCondicion"].ToString() != txtCodigo.Valor)
                    return true;
            }

            return false;
        }

        //private bool validarFMS()
        //{
        //    bool OK = true;
        //    string sSelect = "";
        //    DataTable dtFms = new DataTable();

        //    foreach (DataGridViewRow row in dgvArticulosLevantamiento.Rows)
        //    {

        //        sSelect = "SELECT ArticuloFms,CodigoCondicion,CodigoArticulo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART WHERE ArticuloFms = 'S'";
        //        OK = Consultas.fillDataTable(sSelect, ref dtFms, ref error);

        //        if (OK && dtFms.Rows.Count > 0)
        //        {
        //            if (dtFms.Rows[0]["CodigoCondicion"].ToString() != txtCodigo.Valor)
        //                return true;
        //        }

        //    }

        //    return false;
        //}

        private bool validarArticulo(string articulo)
        {
            foreach (DataGridViewRow r in dgvArticulosLevantamiento.Rows)
            {
                if (r.Cells["colArticuloLev"].Value.ToString().Equals(articulo))
                {
                    return false;
                }
            }
            return true;
        }

        private bool validarCondFallecido()
        {
            bool OK = true;
            string sSelect = "";
            DataTable dt = new DataTable();

            if (chkFallecido.Checked == true)
            {
                sSelect = "SELECT Condicionfallecido,CodigoCondicion FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES WHERE CondicionFallecido= 'S'";
                OK = Consultas.fillDataTable(sSelect, ref dt, ref error);

                if (OK && dt.Rows.Count > 0 && dt.Rows[0]["CodigoCondicion"].ToString() != txtCodigo.Valor)
                    return true;
            }

            return false;
        }

        private void txtPlantilla_Enter(object sender, EventArgs e)
        {
            oldValue = txtPlantilla.Valor;
        }

        private void txtPlantilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtPlantilla.ReadOnly)
            {
                listaPlantillas();
            }
        }

        private void txtPlantilla_Leave(object sender, EventArgs e)
        {
            if (txtPlantilla.Valor.Trim().Equals(""))
            {
                txtPlantillaN.Clear();
                dgvArticulos.Rows.Clear();
            }
            else
            {
                if (oldValue != txtPlantilla.Valor)
                {
                    cargarPlantilla(txtPlantilla.Valor);
                    if (txtPlantilla.Valor.Trim() == "")
                        MessageBox.Show("La plantilla digitada no existe o no contiene artículos definidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtPlantilla_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtPlantilla.ReadOnly)
            {
                listaPlantillas();
            }
        }

        private void listaPlantillas()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoPlantilla as Código, NombrePlantilla  as Plantilla";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_MACHOTES";
            listP.ORDERBY = "order by CodigoPlantilla";
            listP.TITULO_LISTADO = "Plantillas";

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                dgvArticulos.Rows.Clear();
                txtPlantilla.Valor = f1.item.SubItems[0].Text;
                txtPlantillaN.Valor = f1.item.SubItems[1].Text;
                cargarPlantilla(txtPlantilla.Valor);
            }
        }

        private void cargarPlantilla(string plantilla)
        {
            DataTable dtTTs = new DataTable();
            //Listado listA = new Listado();
            //listA.COLUMNAS = "a.*,(SELECT NombrePlantilla from " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES where a.CodigoPlantilla = CodigoPlantilla) as Plantilla,(SELECT DESCRIPCION from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = a.CodigoArticulo) as DES," +
            //    "(SELECT case when COSTO_FISCAL = 'P' then COSTO_PROM_LOC else COSTO_STD_LOC end from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = a.CodigoArticulo) as 'Costo Local'," +
            //    "(SELECT case when COSTO_FISCAL = 'P' then COSTO_PROM_DOL else COSTO_STD_DOL end from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO where ARTICULO = a.CodigoArticulo) as 'Costo Dólar'";
            //listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            //listA.TABLA = "NV_MACHOTES_ART a";
            //listA.FILTRO = "where a.CodigoPlantilla = '" + plantilla + "'";
            string sQuery = "select t1.CodigoPlantilla, t1.NombrePlantilla,t2.CodigoArticulo,t3.DESCRIPCION as DES,t4.PRECIO from "+Consultas.sqlCon.COMPAÑIA+".NV_MACHOTES t1" +
            " join " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART t2 on t2.CodigoPlantilla = t1.CodigoPlantilla" +
            " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO t3 on t3.ARTICULO = t2.CodigoArticulo" +
            " join " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t4 on t4.ARTICULO = t2.CodigoArticulo" +
            " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t4.NIVEL_PRECIO AND t6.VERSION = t4.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
            " where t1.CodigoPlantilla = '" + plantilla + "'";

            //if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            if (Consultas.fillDataTable(sQuery, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    txtPlantilla.Valor = dtTTs.Rows[0]["CodigoPlantilla"].ToString();
                    txtPlantillaN.Valor = dtTTs.Rows[0]["NombrePlantilla"].ToString();
                    dgvArticulos.Rows.Clear();
                    foreach (DataRow r in dtTTs.Rows)
                    {
                        dgvArticulos.Rows.Add(r["CodigoArticulo"].ToString(), r["DES"].ToString(), decimal.Parse(r["PRECIO"].ToString()));
                    }
                }
                else
                {
                    limpiarPlantilla();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarPlantilla()
        {
            txtPlantilla.Clear();
            txtPlantillaN.Clear();
            dgvArticulos.Rows.Clear();
        }

        private void limpiarLevantamiento()
        {
            txtCondicionLev.Clear();
            txtDescCondicionLev.Clear();
            dgvArticulosLevantamiento.Rows.Clear();
        }

        private void cargarArticulos()
        {
            dgvArticulosLevantamiento.Rows.Clear();
            DataTable dt = new DataTable();

            string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION,T3.PRECIO,T1.ArticuloFms from " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
                "ON T1.CodigoArticulo=T2.ARTICULO JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T3 ON T1.CodigoArticulo=T3.ARTICULO " +
                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = T3.NIVEL_PRECIO AND t6.VERSION = T3.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                " where T1.CodigoCondicion='" + txtCodigo.Valor.Trim() + "' order by T1.CodigoArticulo";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                
                decimal precio = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["PRECIO"].ToString() != "")
                        precio = decimal.Parse(row["PRECIO"].ToString());
                    
                    dgvArticulosLevantamiento.Rows.Add(row["ArticuloFms"].ToString() == "S" ? true : false, row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(), precio.ToString("N2"));
                }
            }
            else
                MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkRequiereRegresoCondicion_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCondicion.ReadOnly)
                txtCondicion.ReadOnly = false;
            else
            {
                txtCondicion.ReadOnly = true;
                txtCondicion.Clear();
                txtDescCondicion.Clear();
            }
        }

        private void txtCondicion_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondicion.Valor;
        }

        private void txtCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondicion.ReadOnly)
            {
                listaCondiciones("condicionRegreso");
            }
        }

        private void txtCondicion_Leave(object sender, EventArgs e)
        {
            if (txtCondicion.Valor.Trim().Equals(""))
            {
                txtDescCondicion.Clear();
            }
            else
            {
                if (oldValue != txtCondicion.Valor)
                {
                    cargarCondicion(txtCondicion.Valor, "condicionRegreso");
                    if (txtCondicion.Valor.Trim() == "")
                        MessageBox.Show("La Condición digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCondicion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondicion.ReadOnly)
            {
                listaCondiciones("condicionRegreso");
            }
        }

        private void chkRequiereCambioCondicionEdad_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCondicionEdad.ReadOnly)
            {
                txtCondicionEdad.ReadOnly = false;
                txtEdad.ReadOnly = false;
            }
            else
            {
                txtCondicionEdad.ReadOnly = true;
                txtEdad.ReadOnly = true;
                txtCondicionEdad.Clear();
                txtDescCondicionEdad.Clear();
            }
        }

        private void txtCondicionEdad_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondicionEdad.Valor;
        }

        private void txtCondicionEdad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondicionEdad.ReadOnly)
            {
                listaCondiciones("cambioCondicionEdad");
            }
        }

        private void txtCondicionEdad_Leave(object sender, EventArgs e)
        {
            if (txtCondicionEdad.Valor.Trim().Equals(""))
            {
                txtDescCondicionEdad.Clear();
            }
            else
            {
                if (oldValue != txtCondicionEdad.Valor)
                {
                    cargarCondicion(txtCondicionEdad.Valor, "cambioCondicionEdad");
                    if (txtCondicionEdad.Valor.Trim() == "")
                        MessageBox.Show("La Condición digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCondicionEdad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondicionEdad.ReadOnly)
            {
                listaCondiciones("cambioCondicionEdad");
            }
        }

        private void listaArticulos()
        {
            Listado listP = new Listado();
            //listP.COLUMNAS = "t1.ARTICULO as Código,t1.DESCRIPCION as Descripción,(Select PRECIO from "+Consultas.sqlCon.COMPAÑIA+".ARTICULO_PRECIO where ARTICULO = t1.ARTICULO) as Precio";
            listP.COLUMNAS = "t1.ARTICULO as Código,t1.DESCRIPCION as Descripción,(Select t2.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO t2 join " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t2.NIVEL_PRECIO AND t6.VERSION = t2.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' where t2.ARTICULO = t1.ARTICULO) as Precio";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "ARTICULO t1";
            listP.TABLA_ELIMINAR = "ARTICULO";
            listP.ORDERBY = "order by t1.ARTICULO";
            listP.FILTRO = "where t1.ARTICULO like 'KOL-%' and t1.TIPO = 'V'";
            listP.TITULO_LISTADO = "Artículos";
            listP.COLUMNAS_NUMERICAS.Add("Precio");
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

                //if (InsertarDetalle(f1.item.SubItems[0].Text, ref error))
                //{
                    //DataTable dt = new DataTable();

                    //string sQuery = "SELECT PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO ARTICULO where ARTICULO='" + f1.item.SubItems[0].Text + "' ";

                    //if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                    //{
                    //    decimal precio = 0;
                    //    foreach (DataRow row in dt.Rows)
                    //    {
                        //    if (row["PRECIO"].ToString() != "")
                        //        precio = decimal.Parse(row["PRECIO"].ToString());
                        //}

                        dgvArticulosLevantamiento.Rows.Add(false,f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, f1.item.SubItems[2].Text/*precio.ToString("N2")*/);
                //}
                //else
                //    MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
                //else
                //{
                //    MessageBox.Show("Ocurrió un error insertando.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;

            }
        }

        private void listaCondiciones(string identificador)
        {
            Listado listD = new Listado();
            listD.COLUMNAS = "CodigoCondicion as Código,NombreCondicion as Condición,CodigoPlantilla";
            listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listD.TABLA = "NV_CONDICIONES";
            listD.TITULO_LISTADO = "Condiciones Colegiado";
            listD.COLUMNAS_OCULTAS.Add("CodigoPlantilla");

            frmF1 f1 = new frmF1(listD);
            f1.ShowDialog();
            if (f1.item != null)
            {
                if(identificador == "condicionRegreso")
                {
                    txtCondicion.Valor = f1.item.SubItems[0].Text;
                    txtDescCondicion.Valor = f1.item.SubItems[1].Text;
                } 
                else if (identificador == "cambioCondicionEdad")
                {
                    txtCondicionEdad.Valor = f1.item.SubItems[0].Text;
                    txtDescCondicionEdad.Valor = f1.item.SubItems[1].Text;
                }
                else
                {
                    txtCondicionLev.Valor = f1.item.SubItems[0].Text;
                    txtDescCondicionLev.Valor = f1.item.SubItems[1].Text;
                }
                
            }
        }

        private void cargarCondicion(string condicion, string identificador)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_CONDICIONES";
            listA.FILTRO = "where CodigoCondicion = '" + condicion + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    if (identificador == "condicionRegreso")
                    {
                        txtCondicion.Valor = dtTTs.Rows[0]["CodigoCondicion"].ToString();
                        txtDescCondicion.Valor = dtTTs.Rows[0]["NombreCondicion"].ToString();
                    } 
                    else if (identificador == "cambioCondicionEdad")
                    {
                        txtCondicionEdad.Valor = dtTTs.Rows[0]["CodigoCondicion"].ToString();
                        txtDescCondicionEdad.Valor = dtTTs.Rows[0]["NombreCondicion"].ToString();
                    }
                    else
                    {
                        txtCondicionLev.Valor = dtTTs.Rows[0]["CodigoCondicion"].ToString();
                        txtDescCondicionLev.Valor = dtTTs.Rows[0]["NombreCondicion"].ToString();
                    }
                    
                }
                else
                {
                    if (identificador == "condicionRegreso")
                    {
                        txtCondicion.Clear();
                        txtDescCondicion.Clear();
                    }
                    else if (identificador == "cambioCondicionEdad")
                    {
                        txtCondicionEdad.Clear();
                        txtDescCondicionEdad.Clear();
                    }
                    else
                    {
                        txtCondicionLev.Clear();
                        txtDescCondicionLev.Clear();
                    }
                   
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool InsertarDetalle(string articulo, bool fms, ref string error)
        {
            bool OK = true;
            string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART (CodigoCondicion,CodigoArticulo,ArticuloFms) " +
                    "VALUES (@Condicion,@Articulo,@ArticuloFms)";

            parametros.Clear();
            parametros.Add("@Condicion," + txtCodigo.Valor);
            parametros.Add("@Articulo," + articulo);
            if(fms)
                parametros.Add("@ArticuloFms," + "S");
            else
                parametros.Add("@ArticuloFms," + "N");

            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

            return OK;
        }

        private bool EliminarDetalle(ref string error)
        {
            bool OK = true;
            string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART WHERE CodigoCondicion = @Condicion";

            parametros.Clear();
            parametros.Add("@Condicion," + txtCodigo.Valor);

            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

            return OK;
        }

        //private bool EliminarDetalle(string art, ref string error)
        //{
        //    bool OK = true;
        //    string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + ".NV_CONDICIONES_LEVANTAMIENTO_ART WHERE CodigoCondicion = @Condicion and CodigoArticulo = @Articulo";
            
        //    parametros.Clear();
        //    parametros.Add("@Condicion," + txtCodigo.Valor);
        //    parametros.Add("@Articulo," + art);

        //    OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

        //    return OK;
        //}

        protected override bool guardarDetalle(ref string error)
        {
            bool OK = true;

            //DataTable dtFms = new DataTable();
            //int marcadas = 0;

            //string sSelect = "SELECT CodigoPlantilla,CodigoArticulo FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART WHERE ArticuloFms = 'S'";

            //OK = Consultas.fillDataTable(sSelect, ref dtFms, ref error);


            //string sQuery1 = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART SET ArticuloFms = 'N'";

            //if (OK)
            //{
            //    string sQuery = "UPDATE " + Consultas.sqlCon.COMPAÑIA + ".NV_MACHOTES_ART SET ArticuloFms = @ArticuloFms WHERE CodigoPlantilla = @Plantilla AND CodigoArticulo = @Articulo";

            //    foreach (DataGridViewRow row in dgvArticulos.Rows)
            //    {
            //        if ((bool)row.Cells["colArticuloFms"].Value)
            //        {
            //            marcadas++;
            //            OK = Consultas.ejecutarSentencia(sQuery1, ref error);

            //            parametros.Clear();
            //            parametros.Add("@Plantilla," + txtCodigo.Valor);
            //            parametros.Add("@Articulo," + row.Cells["colArticulo"].Value.ToString());
            //            parametros.Add("@ArticuloFms," + "S");

            //            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);
            //        }
            //    }

            //    if (dtFms.Rows.Count > 0)
            //    {
            //        if (dtFms.Rows[0]["CodigoPlantilla"].ToString() == txtCodigo.Valor && marcadas == 0)
            //        {
            //            OK = Consultas.ejecutarSentencia(sQuery1, ref error);
            //        }
            //    }

            //}

            if (dgvArticulosLevantamiento.Rows.Count > 0 && chkRequiereLevantamiento.Checked)
            {
                //foreach (DataGridViewRow r in dgvArticulosLevantamiento.Rows)
                //{
                    OK = EliminarDetalle(/*r.Cells["colArticuloLev"].Value.ToString(),*/ ref error);
                //}

                if (OK)
                {
                    foreach (DataGridViewRow r in dgvArticulosLevantamiento.Rows)
                    {
                        OK = InsertarDetalle(r.Cells["colArticuloLev"].Value.ToString(), (bool)r.Cells["colFmsLev"].Value, ref error);
                    }
                }
            }

            return OK;
        }
        
        private void chkRequiereLevantamiento_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkRequiereLevantamiento.Checked)
            {
                btnAgregarArticulo.Enabled = true;
                btnEliminarArticulo.Enabled = true;
                txtCondicionLev.ReadOnly = false;
            }
            else
            {
                btnAgregarArticulo.Enabled = false;
                btnEliminarArticulo.Enabled = false;
                txtCondicionLev.ReadOnly = true;
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            //if (valoresPk.Count == 0)
            //{
            //    MessageBox.Show("Primero debe guardar la Plantilla para agregar artículos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CONDICIONES_EDITAR))
            {
                listaArticulos();
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CONDICIONES_BORRAR))
            {
                if (dgvArticulosLevantamiento.Rows.Count > 0)
                {
                    dgvArticulosLevantamiento.Rows.RemoveAt(dgvArticulosLevantamiento.SelectedRows[0].Index);
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;

                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           
        }

        private void txtCondicionLev_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtCondicionLev.ReadOnly)
            {
                listaCondiciones("condicionLevantamiento");
            }
        }

        private void txtCondicionLev_Leave(object sender, EventArgs e)
        {
            if (txtCondicionLev.Valor.Trim().Equals(""))
            {
                txtDescCondicionLev.Clear();
            }
            else
            {
                if (oldValue != txtCondicionLev.Valor)
                {
                    cargarCondicion(txtCondicionLev.Valor,"condicionLevantamiento");
                    if (txtCondicionLev.Valor.Trim() == "")
                        MessageBox.Show("La Condición digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCondicionLev_Enter(object sender, EventArgs e)
        {
            oldValue = txtCondicionLev.Valor;
        }

        private void txtCondicionLev_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtCondicionLev.ReadOnly)
            {
                listaCondiciones("condicionLevantamiento");
            }
        }

        private void dgvArticulosLevantamiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticulosLevantamiento.Rows.Count > 0)
            {
                if (dgvArticulosLevantamiento.CurrentCell.OwningColumn.Name == "colFmsLev")
                {
                    if (e.RowIndex >= 0)
                    {
                        if ((bool)dgvArticulosLevantamiento.Rows[e.RowIndex].Cells["colFmsLev"].Value == false)
                        {
                            //foreach (DataGridViewRow row in dgvArticulosLevantamiento.Rows)
                            //{
                            //    if ((bool)row.Cells["colFmsLev"].Value)
                            //    {
                            //        row.Cells["colFmsLev"].Value = false;
                            //    }
                            //}
                            dgvArticulosLevantamiento.Rows[e.RowIndex].Cells["colFmsLev"].Value = true;
                        }
                        else
                            dgvArticulosLevantamiento.Rows[e.RowIndex].Cells["colFmsLev"].Value = false;

                        dgvArticulos.EndEdit();

                        btnGuardar.Enabled = true;
                        btnGuardarSalir.Enabled = true;
                    }
                }
            }
        }

		private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
		{
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// If you want, you can allow decimal (float) numbers
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
	}
}
