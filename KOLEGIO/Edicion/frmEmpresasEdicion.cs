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
    public partial class frmEmpresasEdicion : frmEdicion
    {
        private string oldValue = "";

        public frmEmpresasEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            rtbDireccion.Mayuscula = true;
            txtCodigo.Longitud = 15;
            txtNombre.Longitud = 100;
            txtContacto.Longitud = 100;
            txtTelefonos.Longitud = 50;
            //Tipos();
            TiposEmp();
            cargarDatos();
        }

        private void Tipos()
        {
            DataTable dtTI = new DataTable();
            dtTI.Columns.Add("Codigo", typeof(string));
            dtTI.Columns.Add("Tipo", typeof(string));
            dtTI.Rows.Add("A", "Privada");
            dtTI.Rows.Add("U", "Pública");
            dtTI.Rows.Add("N", "No Definido");

            cmbTipo.DataSource(dtTI, "Codigo", "Tipo");
            cmbTipo.Valor = "";
        }

        private void TiposEmp()
        {
            DataTable dtTI = new DataTable();
            dtTI.Columns.Add("Codigo", typeof(string));
            dtTI.Columns.Add("Tipo", typeof(string));
            dtTI.Rows.Add("N", "No Definido");
            dtTI.Rows.Add("A", "Privada");
            dtTI.Rows.Add("U", "Pública");
            

            this.cmbTipoEmp.DataSource = dtTI;
            this.cmbTipoEmp.DisplayMember = "Tipo";
            this.cmbTipoEmp.ValueMember = "Codigo";
            //this.cmbTipoEmp.SelectedValue = "";
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Empresas";
                lblPerfil.Text = "Perfil de Empresa";

                //listar.COLUMNAS = "CodigoEmpresa,NombreEmpresa,TipoEmpresa,ContactoEmpresa,TelefonosEmpresa,DireccionEmpresa,PagaCanon,CodigoArticulo";
                listar.COLUMNAS = "CodigoEmpresa,NombreEmpresa,TipoEmpresa,ContactoEmpresa,TelefonosEmpresa,DireccionEmpresa,PagaCanon";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_EMPRESAS";
                identificadorFormulario = "De Empresas";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoEmpresa");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.EMPRESAS_INSERTAR;
                editar = Constantes.EMPRESAS_EDITAR;
                borrar = Constantes.EMPRESAS_BORRAR;
                seleccionar = Constantes.EMPRESAS_SELECCIONAR;

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
                                txtNombre.Valor = row["NombreEmpresa"].ToString();
                                txtCodigo.Valor = row["CodigoEmpresa"].ToString();
                                txtCodigo.ReadOnly = true;
                                //cmbTipo.Valor = row["TipoEmpresa"].ToString();
                                cmbTipoEmp.SelectedValue = row["TipoEmpresa"].ToString();
                                txtContacto.Valor = row["ContactoEmpresa"].ToString();
                                txtTelefonos.Valor = row["TelefonosEmpresa"].ToString();
                                lblPerfil.Text = "Perfil de Empresa: " + txtNombre.Valor;
                                if (row["PagaCanon"].ToString() == "S")
                                    chkPagaCanon.Checked = true;
                                //txtCodigoArticulo.Valor = row["CodigoArticulo"].ToString();
                                //if(!string.IsNullOrEmpty(txtCodigoArticulo.Valor))
                                //    cargarArticulo(txtCodigoArticulo.Valor);

                                rtbDireccion.Text = row["DireccionEmpresa"].ToString();
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
            //parametros.Add(cmbTipo.Valor);
            parametros.Add(cmbTipoEmp.SelectedValue.ToString());
            parametros.Add(txtContacto.Valor);
            parametros.Add(txtTelefonos.Valor);
            parametros.Add(rtbDireccion.Text);
            if (chkPagaCanon.Checked)
            {
                parametros.Add("S");
                //parametros.Add(txtCodigoArticulo.Valor);
            }
            else
            {
                parametros.Add("N");
                //parametros.Add("null");
            }

            
            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para la Empresa.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para la Empresa.";
                txtNombre.Focus();
                return false;
            }
            if (cmbTipoEmp.SelectedValue.ToString() == "")
            {
                error = "Debe especificar un tipo para la Empresa.";
                txtNombre.Focus();
                return false;
            }
            //if (cmbTipoEmp.SelectedValue.ToString() == "A")
            //{
            //    if (txtCodigoArticulo.Valor.Trim() == "")
            //    {
            //        error = "Debe especificar el artículo para la empresa privada.";
            //        txtCodigo.Focus();
            //        return false;
            //    }
            //}

            return true;
        }

        private void listaArticulos()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción, case when COSTO_FISCAL = 'P' then COSTO_PROM_LOC else COSTO_STD_LOC END as 'Costo Local',case when COSTO_FISCAL = 'P' then COSTO_PROM_DOL else COSTO_STD_DOL END as 'Costo Dólar'";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "ARTICULO";
            listP.ORDERBY = "order by ARTICULO";
            listP.FILTRO = "where ARTICULO like 'KOL-%' and TIPO = 'V'";
            listP.TITULO_LISTADO = "Artículos";
            listP.COLUMNAS_NUMERICAS.Add("Costo Local");
            listP.COLUMNAS_NUMERICAS.Add("Costo Dólar");

            frmF1 f1 = new frmF1(listP);
            f1.ShowDialog();
            if (f1.item != null)
            {
                txtCodigoArticulo.Valor = f1.item.SubItems[0].Text;
                txtArticuloDescripcion.Valor = f1.item.SubItems[1].Text;
     
            }
        }

        private void cargarArticulo(string codigoArticulo)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "ARTICULO as Código,DESCRIPCION as Descripción";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "ARTICULO";
            listA.FILTRO = "where ARTICULO = '" + codigoArticulo + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    txtArticuloDescripcion.Valor = dtTTs.Rows[0]["Descripción"].ToString();
                }
                else
                {
                    txtArticuloDescripcion.Clear();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            txtContacto.Clear();
            txtTelefonos.Clear();
            cmbTipo.Valor = "";
            txtCodigoArticulo.Clear();
            txtArticuloDescripcion.Clear();
            rtbDireccion.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Empresa";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Empresa: " + txtNombre.Valor;
        }


        private void cmbTipoEmp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbTipoEmp.SelectedValue.ToString())) {
                if (cmbTipoEmp.SelectedValue.ToString() == "A")
                {
                    chkPagaCanon.Checked = true;
                    //lblArticulo.Visible = true;//Se paso a globales
                    //txtCodigoArticulo.Enabled = true;
                    //txtCodigoArticulo.Visible = true;
                    //txtArticuloDescripcion.Enabled = true;
                    //txtArticuloDescripcion.Visible = true;
                }
                else { 
                    chkPagaCanon.Checked = false;
                    //lblArticulo.Visible = false;
                    //txtCodigoArticulo.Enabled = false;
                    //txtCodigoArticulo.Visible = false;
                    //txtArticuloDescripcion.Enabled = false;
                    //txtArticuloDescripcion.Visible = false;
                }
            }
        }

        private void txtCodigoArticulo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //listaArticulos();
        }

        private void txtCodigoArticulo_Leave(object sender, EventArgs e)
        {
            //if (txtCodigoArticulo.Valor.Trim().Equals(""))
            //{
            //    txtArticuloDescripcion.Clear();
            //}
            //else
            //{
            //    if (oldValue != txtCodigoArticulo.Valor)
            //    {
            //        cargarArticulo(txtCodigoArticulo.Valor);
            //        if (txtCodigoArticulo.Valor.Trim() == "")
            //            MessageBox.Show("La Categoría digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void txtCodigoArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == (char)Keys.F1 && !txtCodigoArticulo.ReadOnly)
            //{
            //    listaArticulos();
            //}
        }

        private void txtCodigoArticulo_Enter(object sender, EventArgs e)
        {
            //oldValue = txtCodigoArticulo.Valor;
        }
    }
}
