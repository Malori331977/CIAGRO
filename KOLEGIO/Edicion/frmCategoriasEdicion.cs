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
    public partial class frmCategoriasEdicion : frmEdicion
    {
        public frmCategoriasEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 50;
            rtbDescripcion.Longitud = 1024;
            gbArticulos.Size = new Size(617, 256);
            grbArtEstable.Size = new Size(617, 256);
            cargarDatos();
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Categorías Regentes";
                lblPerfil.Text = "Perfil de Categoría Regente";

                listar.COLUMNAS = "CodigoCategoria,NombreCategoria,DescripcionCategoria";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_CATEGORIAS";
                identificadorFormulario = "De Categorías";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoCategoria");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.CATEGORIAS_REGENTES_INSERTAR;
                editar = Constantes.CATEGORIAS_REGENTES_EDITAR;
                borrar = Constantes.CATEGORIAS_REGENTES_BORRAR;
                seleccionar = Constantes.CATEGORIAS_REGENTES_SELECCIONAR;

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
                                txtNombre.Valor = row["NombreCategoria"].ToString();
                                txtCodigo.Valor = row["CodigoCategoria"].ToString();
                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionCategoria"].ToString();
                                lblPerfil.Text = "Perfil de Categoría Regente: " + txtNombre.Valor;
                            }
                        }
                        cargarArticulos();
                        cargarArticulosEstable();
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

        private bool InsertarDetalle(string articulo, string IdDgv, ref string error)
        {
            bool OK = true;
            string tabla = "";

            if (IdDgv == "estable")
                tabla = "NV_CATEGORIAS_ESTABLE_ART";
            else if (IdDgv == "reg")
                tabla = "NV_CATEGORIAS_ART";

            string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + "." + tabla + " (CodigoCategoria,CodigoArticulo) " +
                    "VALUES (@Categoria,@Articulo)";

            parametros.Clear();
            parametros.Add("@Categoria," + txtCodigo.Valor);
            parametros.Add("@Articulo," + articulo);

            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

            return OK;
        }

        private bool EliminarDetalle(string art, string IdDgv, ref string error)
        {
            bool OK = true;
            string tabla = "";

            if (IdDgv == "estable")
                tabla = "NV_CATEGORIAS_ESTABLE_ART";
            else if (IdDgv == "reg")
                tabla = "NV_CATEGORIAS_ART";

            string sQuery = "DELETE " + Consultas.sqlCon.COMPAÑIA + "." + tabla + " WHERE CodigoCategoria = @Categoria and CodigoArticulo = @Articulo";

            parametros.Clear();
            parametros.Add("@Categoria," + txtCodigo.Valor);
            parametros.Add("@Articulo," + art);

            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

            return OK;
        }

        private void cargarArticulosEstable()
        {
            dgvArtEstablecimiento.Rows.Clear();
            DataTable dt = new DataTable();
            //string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION, case when T2.COSTO_FISCAL = 'P' then T2.COSTO_PROM_LOC else T2.COSTO_STD_LOC end as 'Costo Local',case when T2.COSTO_FISCAL = 'P' then T2.COSTO_PROM_DOL else T2.COSTO_STD_DOL end as 'Costo Dólar' from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
            //   "ON T1.CodigoArticulo=T2.ARTICULO where T1.CodigoCategoria = '"+txtCodigo.Valor+"' order by T1.CodigoArticulo";
            string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION,T3.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ESTABLE_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
                "ON T1.CodigoArticulo=T2.ARTICULO JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T3 ON T1.CodigoArticulo=T3.ARTICULO " +
                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = t3.NIVEL_PRECIO AND t6.VERSION = t3.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                " where T1.CodigoCategoria = '" + txtCodigo.Valor + "' order by T1.CodigoArticulo";


            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                //decimal costoLOC = 0;
                //decimal costoDOL = 0;
                decimal precio = 0;
                foreach (DataRow row in dt.Rows)
                {
                    // if (row["Costo Local"].ToString() != "")
                    //   costoLOC = decimal.Parse(row["Costo Local"].ToString());

                    //if (row["Costo Dólar"].ToString() != "")
                    //   costoDOL = decimal.Parse(row["Costo Dólar"].ToString());
                    if (row["PRECIO"].ToString() != "")
                        precio = decimal.Parse(row["PRECIO"].ToString());

                    dgvArtEstablecimiento.Rows.Add(row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(), precio);

                    //dgvArticulos.Rows.Add(row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(), costoLOC, costoDOL);
                }
            }
            else
                MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cargarArticulos()
        {
            dgvArticulos.Rows.Clear();
            DataTable dt = new DataTable();
            //string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION, case when T2.COSTO_FISCAL = 'P' then T2.COSTO_PROM_LOC else T2.COSTO_STD_LOC end as 'Costo Local',case when T2.COSTO_FISCAL = 'P' then T2.COSTO_PROM_DOL else T2.COSTO_STD_DOL end as 'Costo Dólar' from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
             //   "ON T1.CodigoArticulo=T2.ARTICULO where T1.CodigoCategoria = '"+txtCodigo.Valor+"' order by T1.CodigoArticulo";
            string sQuery = "SELECT T1.CodigoArticulo,T2.DESCRIPCION,T3.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".NV_CATEGORIAS_ART T1 JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO T2 " +
                "ON T1.CodigoArticulo=T2.ARTICULO JOIN " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO T3 ON T1.CodigoArticulo=T3.ARTICULO " +
                " JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = T3.NIVEL_PRECIO AND t6.VERSION = T3.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' " +
                " where T1.CodigoCategoria = '" + txtCodigo.Valor + "' order by T1.CodigoArticulo";


            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                //decimal costoLOC = 0;
                //decimal costoDOL = 0;
                decimal precio = 0;
                foreach (DataRow row in dt.Rows)
                {
                    // if (row["Costo Local"].ToString() != "")
                    //   costoLOC = decimal.Parse(row["Costo Local"].ToString());

                    //if (row["Costo Dólar"].ToString() != "")
                    //   costoDOL = decimal.Parse(row["Costo Dólar"].ToString());
                    if (row["PRECIO"].ToString() != "")
                        precio = decimal.Parse(row["PRECIO"].ToString());

                    dgvArticulos.Rows.Add(row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(), precio);

                    //dgvArticulos.Rows.Add(row["CodigoArticulo"].ToString(), row["DESCRIPCION"].ToString(), costoLOC, costoDOL);
                }
            }
            else
                MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaArticulos()
        {
            Listado listP = new Listado();
            //listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción, case when COSTO_FISCAL = 'P' then COSTO_PROM_LOC else COSTO_STD_LOC END as 'Costo Local',case when COSTO_FISCAL = 'P' then COSTO_PROM_DOL else COSTO_STD_DOL END as 'Costo Dólar'";
            listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "ARTICULO";
            listP.ORDERBY = "order by ARTICULO";
            listP.FILTRO = "where ARTICULO like 'KOL-%' and TIPO = 'V' and CLASIFICACION_1 = 'REG'";
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

                if (InsertarDetalle(f1.item.SubItems[0].Text, "reg", ref error))
                {
                    DataTable dt = new DataTable();

                    string sQuery = "SELECT ARTICULO.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO ARTICULO JOIN " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = ARTICULO.NIVEL_PRECIO AND t6.VERSION = ARTICULO.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' where ARTICULO.ARTICULO='" + f1.item.SubItems[0].Text + "' ";

                    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                    {
                        decimal precio = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["PRECIO"].ToString() != "")
                                precio = decimal.Parse(row["PRECIO"].ToString());
                        }

                        dgvArticulos.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, precio);
                    }
                    else
                        MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //dgvArticulos.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, decimal.Parse(f1.item.SubItems[2].Text), decimal.Parse(f1.item.SubItems[3].Text));
                }
                else
                {
                    MessageBox.Show("Ocurrió un error insertando.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void listaArticulosEstable()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "ARTICULO";
            listP.ORDERBY = "order by ARTICULO";
            listP.FILTRO = "where ARTICULO like 'KOL-%' and TIPO = 'V' and CLASIFICACION_1 = 'CAN'";
            listP.TITULO_LISTADO = "Artículos";
            //listP.COLUMNAS_NUMERICAS.Add("Costo Local");
            //listP.COLUMNAS_NUMERICAS.Add("Costo Dólar");

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                if (!validarArticuloEstable(f1.item.SubItems[0].Text))
                {
                    MessageBox.Show("Ya existe un detalle con la misma información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (InsertarDetalle(f1.item.SubItems[0].Text, "estable", ref error))
                {
                    DataTable dt = new DataTable();

                    string sQuery = "SELECT ARTICULO.PRECIO from " + Consultas.sqlCon.COMPAÑIA + ".ARTICULO_PRECIO ARTICULO JOIN  " + Consultas.sqlCon.COMPAÑIA + ".VERSION_NIVEL t6 on t6.NIVEL_PRECIO = ARTICULO.NIVEL_PRECIO AND t6.VERSION = ARTICULO.VERSION AND (CAST(getdate() AS date) BETWEEN t6.FECHA_INICIO AND t6.FECHA_CORTE) AND t6.ESTADO = 'A' where ARTICULO.ARTICULO='" + f1.item.SubItems[0].Text + "' ";

                    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
                    {
                        decimal precio = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["PRECIO"].ToString() != "")
                                precio = decimal.Parse(row["PRECIO"].ToString());
                        }

                        dgvArtEstablecimiento.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, precio);
                    }
                    else
                        MessageBox.Show("Ocurrió un error cargando los artículos.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //dgvArticulos.Rows.Add(f1.item.SubItems[0].Text, f1.item.SubItems[1].Text, decimal.Parse(f1.item.SubItems[2].Text), decimal.Parse(f1.item.SubItems[3].Text));
                }
                else
                {
                    MessageBox.Show("Ocurrió un error insertando.\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtCodigo.Valor);
            parametros.Add(txtNombre.Valor);
            parametros.Add(rtbDescripcion.Text);
            return true;
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

        private bool validarArticuloEstable(string articulo)
        {
            foreach (DataGridViewRow r in dgvArtEstablecimiento.Rows)
            {
                if (r.Cells["colCodArtEstable"].Value.ToString().Equals(articulo))
                {
                    return false;
                }
            }
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para la Categoría Regente.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para la Categoría Regente.";
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CATEGORIAS_REGENTES_EDITAR))
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

        private void btnEliminarCampo_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CATEGORIAS_REGENTES_BORRAR))
            {
                if (dgvArticulos.Rows.Count > 0)
                {
                    if (EliminarDetalle(dgvArticulos.Rows[dgvArticulos.SelectedRows[0].Index].Cells["colArticulo"].Value.ToString(), "reg", ref error))
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

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            rtbDescripcion.Clear();
            dgvArticulos.Rows.Clear();
            dgvArtEstablecimiento.Rows.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Categoría Regente";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Categoría Regente: " + txtNombre.Valor;
        }

        private void btnNuevoArtEstable_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CATEGORIAS_REGENTES_EDITAR))
            {
                if (valoresPk.Count == 0)
                {
                    MessageBox.Show("Primero debe guardar la Plantilla para agregar artículos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                listaArticulosEstable();
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnEliminarArtEstable_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.CATEGORIAS_REGENTES_BORRAR))
            {
                if (dgvArtEstablecimiento.Rows.Count > 0)
                {
                    if (EliminarDetalle(dgvArtEstablecimiento.Rows[dgvArtEstablecimiento.SelectedRows[0].Index].Cells["colCodArtEstable"].Value.ToString(), "estable", ref error))
                    {
                        dgvArtEstablecimiento.Rows.RemoveAt(dgvArtEstablecimiento.SelectedRows[0].Index);
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
    }
}
