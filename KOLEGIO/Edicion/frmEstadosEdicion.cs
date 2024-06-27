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
    public partial class frmEstadosEdicion : frmEdicion
    {
        private string oldValue = "";

        public frmEstadosEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 4;
            txtNombre.Longitud = 50;
            rtbDescripcion.Longitud = 1024;
            cargarDatos();
            cmbDiferenciador.SelectedValueChanged(new EventHandler(OnDiferenciadorChanged));
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Estados";
                lblPerfil.Text = "Perfil de Estado";

                listar.COLUMNAS = "CodigoEstado,Diferenciador,NombreEstado,DescripcionEstado,GeneraCobro,RequiereRegresoEstado,EstadoRegreso,EsEstadoCierre";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_ESTADOS";
                identificadorFormulario = "De Estados";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoEstado");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.ESTADOS_ESTABLECIMIENTO_INSERTAR;
                editar = Constantes.ESTADOS_ESTABLECIMIENTO_EDITAR;
                borrar = Constantes.ESTADOS_ESTABLECIMIENTO_BORRAR;
                seleccionar = Constantes.ESTADOS_ESTABLECIMIENTO_SELECCIONAR;

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
                cmbDiferenciador.agregarItems("Establecimiento");
                cmbDiferenciador.agregarItems("Consultora");
                cmbDiferenciador.Index = 0;

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["NombreEstado"].ToString();
                                txtCodigo.Valor = row["CodigoEstado"].ToString();
                                if (row["Diferenciador"].ToString() == "E")
                                    cmbDiferenciador.Index = 0;
                                else
                                    cmbDiferenciador.Index = 1;

                                if (row["GeneraCobro"].ToString() == "S")
                                    chkGeneraCobro.Checked = true;
                                else
                                    chkGeneraCobro.Checked = false;

                                if (row["RequiereRegresoEstado"].ToString() == "S")
                                {
                                    txtEstado.ReadOnly = false;
                                    chkRegresoEstado.Checked = true;
                                }
                                else
                                    chkRegresoEstado.Checked = false;

                                if (!row["EstadoRegreso"].ToString().Equals(""))
                                {
                                    txtEstado.Valor = row["EstadoRegreso"].ToString();
                                    cargarEstado(txtEstado.Valor);
                                }

                                if (row["EsEstadoCierre"].ToString() == "S")
                                    chkCierre.Checked = true;
                                else
                                    chkCierre.Checked = false;

                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionEstado"].ToString();
                                lblPerfil.Text = "Perfil de Estado: " + txtNombre.Valor;
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
            parametros.Add(cmbDiferenciador.Texto[0] + "");
            parametros.Add(txtNombre.Valor);
            parametros.Add(rtbDescripcion.Text);
            if (chkGeneraCobro.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (chkRegresoEstado.Checked)
            {
                parametros.Add("S");
                parametros.Add(txtEstado.Valor);
            }
            else
            {
                parametros.Add("N");
                parametros.Add("null");
            }

            if (chkCierre.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para el Estado.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Estado.";
                txtNombre.Focus();
                return false;
            }

            if (chkRegresoEstado.Checked)
            {
                if (txtEstado.Valor.Trim() == "")
                {
                    error = "Debe especificar el Estado de Regreso.";
                    txtEstado.Focus();
                    return false;
                }
            }

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            rtbDescripcion.Clear();
            chkGeneraCobro.Checked = false;
            chkRegresoEstado.Checked = false;
            chkCierre.Checked = false;
            txtEstado.Clear();
            txtDescEstado.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Estado";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Estado: " + txtNombre.Valor;
        }

        private void listaEstados()
        {
            string diferenciador = "";
            if (cmbDiferenciador.Texto == "Establecimiento")
                diferenciador = "E";
            else
                diferenciador = "C";

            Listado listD = new Listado();
            listD.COLUMNAS = "CodigoEstado as Código,NombreEstado as Estado";
            listD.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listD.TABLA = "NV_ESTADOS";
            listD.FILTRO = "where Diferenciador = '"+diferenciador+"'";
            listD.TITULO_LISTADO = "Estados";
            listD.COLUMNAS_OCULTAS.Add("CodigoPlantilla");

            frmF1 f1 = new frmF1(listD);
            f1.ShowDialog();
            if (f1.item != null)
            {
               
                    txtEstado.Valor = f1.item.SubItems[0].Text;
                    txtDescEstado.Valor = f1.item.SubItems[1].Text;
                

            }
        }

        private void cargarEstado(string estado)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_ESTADOS";
            listA.FILTRO = "where CodigoEstado = '" + estado + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {

                    txtEstado.Valor = dtTTs.Rows[0]["CodigoEstado"].ToString();
                    txtDescEstado.Valor = dtTTs.Rows[0]["NombreEstado"].ToString();
                    
                }
                else
                {
                    
                    txtEstado.Clear();
                    txtDescEstado.Clear();
                    
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnDiferenciadorChanged(object sender, EventArgs e)
        {
            txtEstado.Clear();
            txtDescEstado.Clear();
        }

        private void txtEstado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!txtEstado.ReadOnly)
            {
                listaEstados();
            }
        }

        private void chkRegresoEstado_Click(object sender, EventArgs e)
        {
            
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1 && !txtEstado.ReadOnly)
            {
                listaEstados();
            }
        }

        private void txtEstado_Leave(object sender, EventArgs e)
        {
            if (txtEstado.Valor.Trim().Equals(""))
            {
                txtDescEstado.Clear();
            }
            else
            {
                if (oldValue != txtEstado.Valor)
                {
                    cargarEstado(txtEstado.Valor);
                    if (txtEstado.Valor.Trim() == "")
                        MessageBox.Show("La Condición digitada no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void chkRegresoEstado_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkRegresoEstado.Checked)
                txtEstado.ReadOnly = false;
            else
                txtEstado.ReadOnly = true;
        }
    }
}
