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
    public partial class frmBeneficiariosEdicion : frmEdicion
    {
        private FuncsInternas fInternas;
        private string Colegiado = "";
        private bool onChanged = true;

        public frmBeneficiariosEdicion(List<string> valoresPk, string colegiado)
            : base(valoresPk)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            dtpFechaNacimiento.ValueChanged(new EventHandler(OnNacimientoChanged));
            this.Colegiado = colegiado;
            cargarDatos();
        }

        private void OnNacimientoChanged(object sender, EventArgs e)
        {
            if (onChanged)
            {
                if (dtpFechaNacimiento.Value >= DateTime.Now)
                    txtEdad.Valor = "0";
                else
                {
                    txtEdad.Valor = "" + (int)((DateTime.Now - dtpFechaNacimiento.Value).TotalDays / 365.242199);
                }
            }
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Beneficiarios";
                lblPerfil.Text = "Perfil de Beneficiario";

                //listar.COLUMNAS = "Cedula,NumeroColegiado,Nombre,PrimerApellido,SegundoApellido,Sexo,RenunciaAjusteFondo,FechaNacimiento,Parentesco,Porcentaje,NumeroDocumento,MontoDocumento,FechaEmisionDocumento,FechaEntregaFondo";
                listar.COLUMNAS = "Consecutivo,NumeroColegiado,Cedula,Nombre,Sexo,RenunciaAjusteFondo,FechaNacimiento,Parentesco,Porcentaje,NumeroDocumento,MontoDocumento,FechaEmisionDocumento,FechaEntregaFondo,Observaciones";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_BENEFICIARIOS";

                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("Consecutivo");
                listar.COLUMNAS_PK.Add("NumeroColegiado");
                //listar.COLUMNAS_PK.Add("Cedula");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);
                identificadorFormulario = "De Beneficiarios";

                //insertar = Constantes.BENEFICIARIOS_INSERTAR;
                //editar = Constantes.BENEFICIARIOS_EDITAR;
                //borrar = Constantes.BENEFICIARIOS_BORRAR;
                //seleccionar = Constantes.BENEFICIARIOS_SELECCIONAR;
                insertar = Constantes.COLEGIADOS_INSERTAR;
                editar = Constantes.COLEGIADOS_EDITAR;
                borrar = Constantes.COLEGIADOS_BORRAR;
                seleccionar = Constantes.COLEGIADOS_SELECCIONAR;
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

                cmbSexo.agregarItems("Masculino");
                cmbSexo.agregarItems("Femenino");
                cmbSexo.Index = 0;

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtCedula.Valor = row["Cedula"].ToString();
                                txtConsecutivo.Valor = row["Consecutivo"].ToString();
                                Colegiado = row["NumeroColegiado"].ToString();
                                txtNombre.Valor = row["Nombre"].ToString();
                                //txt1Apellido.Valor = row["PrimerApellido"].ToString();
                                //txt2Apellido.Valor = row["PrimerApellido"].ToString();
                              
                                txtParentesco.Valor = row["Parentesco"].ToString();

                                if (row["Sexo"].ToString() == "M")
                                    cmbSexo.Index = 0;
                                else
                                    cmbSexo.Index = 1;

                                if (row["RenunciaAjusteFondo"].ToString().Equals("S"))
                                {
                                    chkRenunciaAjusteFondo.Checked = true;
                                }

                                onChanged = false;
                                if(!row["FechaNacimiento"].ToString().Equals(""))
                                    dtpFechaNacimiento.Value = DateTime.Parse(row["FechaNacimiento"].ToString());

                                if (dtpFechaNacimiento.Value >= DateTime.Now)
                                    txtEdad.Valor = "0";
                                else
                                    txtEdad.Valor = "" + (int)((DateTime.Now - dtpFechaNacimiento.Value).TotalDays / 365.242199);
                                onChanged = true;
                                txtPorcentaje.Valor = decimal.Parse(row["Porcentaje"].ToString()).ToString("N2");

                                txtDocumento.Valor = row["NumeroDocumento"].ToString();
                                if(!row["MontoDocumento"].ToString().Equals(""))
                                    txtMonto.Valor = decimal.Parse(row["MontoDocumento"].ToString()).ToString("N2");

                                if (!row["FechaEmisionDocumento"].ToString().Equals(""))
                                {
                                    dtpEmision.Value = DateTime.Parse(row["FechaEmisionDocumento"].ToString());
                                    dtpEmision.Checked = true;
                                }

                                if (!row["FechaEntregaFondo"].ToString().Equals(""))
                                {
                                    dtpEntrega.Value = DateTime.Parse(row["FechaEntregaFondo"].ToString());
                                    dtpEntrega.Checked = true;
                                }

                                rtbObservaciones.Text = row["Observaciones"].ToString();


                                lblPerfil.Text = "Perfil de Beneficiario: " + txtNombre.Valor + " " + txt1Apellido.Valor + " " + txt2Apellido.Valor;
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
            //parametros.Add(txtCedula.Valor);
            if(string.IsNullOrEmpty(txtConsecutivo.Valor))
			{
                int sigConsectivo = obtenerSigConsecutivo();
                txtConsecutivo.Valor = sigConsectivo.ToString();
            }
            parametros.Add(txtConsecutivo.Valor);
            parametros.Add(Colegiado);
            parametros.Add(txtCedula.Valor);
            parametros.Add(txtNombre.Valor);
            //parametros.Add(txt1Apellido.Valor);
            //parametros.Add(txt2Apellido.Valor);
            if (cmbSexo.Index == 0)
                parametros.Add("M");
            else
                parametros.Add("F");

            if (chkRenunciaAjusteFondo.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");
            parametros.Add(dtpFechaNacimiento.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            parametros.Add(txtParentesco.Valor);
            parametros.Add(txtPorcentaje.Valor);

            parametros.Add(txtDocumento.Valor);
            if(!txtMonto.Valor.Equals(""))
                parametros.Add(decimal.Parse(txtMonto.Valor).ToString());
            else
                parametros.Add("null");

            if (dtpEmision.Checked)
                parametros.Add(dtpEmision.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (dtpEntrega.Checked)
                parametros.Add(dtpEntrega.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            parametros.Add(rtbObservaciones.Text);

            return true;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCedula.Valor.Trim() == "")
            {
                error = "Debe especificar un número de cédula para el Beneficiario.";
                txtCedula.Focus();
                return false;
            }

            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Beneficiario.";
                txtNombre.Focus();
                return false;
            }

            //if (txt1Apellido.Valor == "")
            //{
            //    error = "Debe especificar un apellido para el Beneficiario.";
            //    txt1Apellido.Focus();
            //    return false;
            //}

            if (txtEdad.Valor.Trim() == "")
            {
                error = "Debe especificar la fecha de inclusión del Beneficiario.";
                dtpFechaNacimiento.Focus();
                return false;
            }
            else
            {
                if (!Utilitario.EsNumero(txtEdad.Valor))
                {
                    error = "La edad del Beneficiario debe ser un valor númerico.";
                    dtpFechaNacimiento.Focus();
                    return false;
                }
            }

            if (txtParentesco.Valor == "")
            {
                error = "Debe especificar un parentesco para el Beneficiario.";
                txtParentesco.Focus();
                return false;
            }

            //if (!txtPorcentaje.Valor.Equals(""))
            //{
            //    if(decimal.Parse(txtPorcentaje.Valor) > 100)
            //    {
            //        error = "El porcentaje no puede ser mayor a 100.";
            //        txtPorcentaje.Focus();
            //        return false;
            //    }
            //}


            return true;
        }

        protected override void limpiarFormulario()
        {
            txtConsecutivo.Clear();
            txtCedula.Clear();
            txtNombre.Clear();
            txt1Apellido.Clear();
            txt2Apellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            txtParentesco.Clear();
            cmbSexo.Index = 0;
            txtEdad.Clear();
            txtPorcentaje.Clear();
            txtDocumento.Clear();
            txtMonto.Clear();
            rtbObservaciones.Clear();
            dtpEmision.Value = DateTime.Now;
            dtpEntrega.Value = DateTime.Now;
            dtpEntrega.Checked = false;
            dtpEmision.Checked = false;

            txtCedula.ReadOnly = false;
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Beneficiario";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            //listar.VALORES_PK.Add(txtCedula.Valor);
            listar.VALORES_PK.Add(Colegiado);
            listar.VALORES_PK.Add(txtConsecutivo.Valor);
            txtCedula.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Beneficiario: " + txtNombre.Valor + " " + txt1Apellido.Valor + " " + txt2Apellido.Valor;
        }

        private int obtenerSigConsecutivo()
        {
            DataTable dt = new DataTable();
            int result = 0;
            string sQuery = "SELECT MAX(Consecutivo) AS 'ULT_CONSECUTIVO' FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_BENEFICIARIOS" +
                            " WHERE NumeroColegiado = '" + Colegiado + "'";

            if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            {
                if (dt.Rows.Count > 0)
                {
                    if(!string.IsNullOrEmpty(dt.Rows[0]["ULT_CONSECUTIVO"].ToString()))
                        result = int.Parse(dt.Rows[0]["ULT_CONSECUTIVO"].ToString());
                }
            }

            if (result == 0)
                result = 1;
            else
                result++;

            return result;
        }

        private void frmDependientesEdicion_Load(object sender, EventArgs e)
        {
            txtNombre.Mayusculas();
            txt1Apellido.Mayusculas();
            txt2Apellido.Mayusculas();
            txtNombre.Focus();
            txtCedula.Longitud = 20;
            txtNombre.Longitud = 100;
            txt1Apellido.Longitud = 20;
            txt2Apellido.Longitud = 20;
            txtParentesco.Longitud = 50;
            txtDocumento.Longitud = 50;
            txtPorcentaje.Longitud = 5;
            txtEdad.Right();
            txtPorcentaje.Right();
            txtMonto.Right();
        }

        private void btnEdad_Click(object sender, EventArgs e)
        {
            txtEdad.Valor=DateTime.Today.AddTicks(-dtpFechaNacimiento.Value.Ticks).Year - 1+"";
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            txtCedula.WhiteSpaces();
            string nombre = "";
            //int sexo = 0;
            if (!txtCedula.ReadOnly && !txtCedula.Valor.Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                //this.fInternas.infoPadronNacional(txtCedula.Valor, false, ref nombre, ref sexo, ref error);
                this.fInternas.ConsultaNombreHacienda(txtCedula.Valor, ref nombre, ref error);
                Cursor.Current = Cursors.Default;
                if (error != "")
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                }
                else
                {
                    if (!string.IsNullOrEmpty(nombre)) {
                        txtNombre.Valor = nombre;
                        //txtNombre.Valor = nombre.Split(',')[0];
                        //txt1Apellido.Valor = nombre.Split(',')[1];
                        //txt2Apellido.Valor = nombre.Split(',')[2];
                        //cmbSexo.Index = sexo;
                    }
                    else
                    {
                        MessageBox.Show("El numero de cedula ingresado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
