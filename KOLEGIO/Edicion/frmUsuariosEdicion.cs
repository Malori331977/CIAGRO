using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class frmEdicionUsuarios : frmEdicion
    {
        private string privilegio = "";
        private FuncsInternas fInternas;
        private bool onChanged = true;

        public frmEdicionUsuarios(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            this.fInternas = new FuncsInternas();
            dtpFechaCambio.Value = DateTime.Now;
            chkCambioClave.CheckedChanged(new EventHandler(OnCambioClaveChanged));
            cargarDatos();
            treeViewPrivilegios.ExpandAll();
            Size size = new Size(384, 292);
            treeViewPrivilegios.Location = new Point(137, 56);
            treeViewPrivilegios.Size = size;
        }

        private void OnCambioClaveChanged(object sender, EventArgs e)
        {
            if (onChanged)
            {
                if (chkCambioClave.Checked)
                {
                    txtCambioClave.ReadOnly = false;
                }
                else
                {
                    txtCambioClave.Clear();
                    txtCambioClave.ReadOnly = true;
                    dtpFechaCambio.Value = DateTime.Now;
                }
            }
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Usuarios";
                lblPerfil.Text = "Perfil de Usuario";
                if (valoresPk.Count == 0)
                    listar.COLUMNAS = "CodigoUsuario,PrimerNombreUsuario,SegundoNombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,UsuarioActivo,UsuarioReqCambioClave,FrecCambioClaveUsuario,FechaUltimoCambioClaveUsuario" +
                                          ",PrivilegiosUsuario,UsuarioPrivilegiosAdministrador,CorreoElectronicoUsuario,ClaveCorreo,TelefonoUsuario1,TelefonoUsuario2,CelularUsuario,FaxUsuario,ClaveSistemaAdicionalUsuario";
                else
                    listar.COLUMNAS = "CodigoUsuario,PrimerNombreUsuario,SegundoNombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,UsuarioActivo,UsuarioReqCambioClave,FrecCambioClaveUsuario,FechaUltimoCambioClaveUsuario" +
                                 ",PrivilegiosUsuario,UsuarioPrivilegiosAdministrador,CorreoElectronicoUsuario,ClaveCorreo,TelefonoUsuario1,TelefonoUsuario2,CelularUsuario,FaxUsuario";

                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_USUARIOS";
                identificadorFormulario = "De Usuarios";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoUsuario");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.USUARIOS_INSERTAR;
                editar = Constantes.USUARIOS_EDITAR;
                borrar = Constantes.USUARIOS_BORRAR;
                seleccionar = Constantes.USUARIOS_SELECCIONAR;

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
                //tabControl.TabPages.Remove(tpPrivilegios);
                //tabControl.TabPages.Remove(tpAuditoria);
                tabControl.TabPages.Add(tpAdmin);


                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtCodigo.Valor = row["CodigoUsuario"].ToString();
                                txtCodigo.ReadOnly = true;
                                //cargarAuditoria(txtCodigo.Valor);
                                txt1Nombre.Valor = row["PrimerNombreUsuario"].ToString();
                                txt2Nombre.Valor = row["SegundoNombreUsuario"].ToString();
                                txt1Apellido.Valor = row["PrimerApellidoUsuario"].ToString();
                                txt2Apellido.Valor = row["SegundoApellidoUsuario"].ToString();
                                string what = row["UsuarioActivo"].ToString();
                                if (row["UsuarioActivo"].ToString().Equals("True"))
                                    chkActivo.Checked = true;
                                else
                                    chkActivo.Checked = false;
                                onChanged = false;
                                if (row["UsuarioReqCambioClave"].ToString().Equals("True"))
                                {
                                    chkCambioClave.Checked = true;
                                    txtCambioClave.ReadOnly = false;
                                }
                                else
                                {
                                    chkCambioClave.Checked = false;
                                }
                                txtCambioClave.Valor = row["FrecCambioClaveUsuario"].ToString();
                                if (!row["FechaUltimoCambioClaveUsuario"].ToString().Equals(""))
                                    dtpFechaCambio.Value = DateTime.Parse(row["FechaUltimoCambioClaveUsuario"].ToString());

                                string[] privilegios = row["PrivilegiosUsuario"].ToString().Split(',');
                                if (privilegios[0].Equals(treeViewPrivilegios.Nodes[0].ToolTipText))
                                {
                                    treeViewPrivilegios.Nodes[0].Checked = true;
                                    for (int i = 1; i < privilegios.Length; i++)
                                    {
                                        FindByText(privilegios[i]);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < privilegios.Length; i++)
                                    {
                                        FindByText(privilegios[i]);
                                    }
                                }
                                onChanged = true;
                                if (row["UsuarioPrivilegiosAdministrador"].ToString().Equals("True"))
                                    chkAdministrador.Checked = true;
                                txtCorreoElectronico.Valor = row["CorreoElectronicoUsuario"].ToString();
                                txtClaveUsuario.Valor = row["ClaveCorreo"].ToString();
                                txt1Oficina.Valor = row["TelefonoUsuario1"].ToString();
                                txt2Oficina.Valor = row["TelefonoUsuario2"].ToString();
                                txtCelular.Valor = row["CelularUsuario"].ToString();
                                txtFax.Valor = row["FaxUsuario"].ToString();
                                lblPerfil.Text = "Perfil de Usuario: " + txt1Nombre.Valor;
                                if (txt2Nombre.Valor != "")
                                    lblPerfil.Text += " " + txt2Nombre.Valor;
                                lblPerfil.Text += " " + txt1Apellido.Valor;
                                if (txt2Apellido.Valor != "")
                                    lblPerfil.Text += " " + txt2Apellido.Valor;
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

        private void FindByText(string nodeText)
        {
            TreeNodeCollection nodes = treeViewPrivilegios.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n, nodeText);
            }
        }

        private void FindRecursive(TreeNode treeNode, string nodeText)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                // if the text properties match, color the item
                if (tn.ToolTipText == nodeText)
                {
                    tn.Checked = true;
                    //TreeNode nod = new TreeNode();
                    //nod.Name = "Prueba";
                    //nod.Text = "Prueba";
                    //nod.Tag = "Prueba";
                    //tvConsumo.SelectedNode.Nodes.Add(nod);
                    //tn.BackColor = Color.Yellow;
                }
                FindRecursive(tn, nodeText);
            }
        }

        private void FindChecked(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    privilegio += node.ToolTipText + ",";
                }
                FindChecked(node.Nodes);
            }
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtCodigo.Valor.Trim());
            parametros.Add(txt1Nombre.Valor.Trim());
            parametros.Add(txt2Nombre.Valor.Trim());
            parametros.Add(txt1Apellido.Valor.Trim());
            parametros.Add(txt2Apellido.Valor.Trim());
            if (chkActivo.Checked)
                parametros.Add("1");
            else
                parametros.Add("0");
            if (chkCambioClave.Checked)
                parametros.Add("1");
            else
                parametros.Add("0");
           
            parametros.Add(txtCambioClave.Valor);
            parametros.Add(dtpFechaCambio.Value.ToString("yyyy-MM-ddTHH:mm:ss"));

            TreeNode tn = treeViewPrivilegios.Nodes[0];
            if (tn.Checked)
                privilegio = treeViewPrivilegios.Nodes[0].ToolTipText + ",";
            FindChecked(treeViewPrivilegios.Nodes);
            if (privilegio.Contains(','))
                privilegio = privilegio.Remove(privilegio.Length - 1);
            parametros.Add(privilegio);
            privilegio = "";

            if (chkAdministrador.Checked)
                parametros.Add("1");
            else
                parametros.Add("0");
            parametros.Add(txtCorreoElectronico.Valor.Trim());
            parametros.Add(txtClaveUsuario.Valor.Trim());
            parametros.Add(txt1Oficina.Valor.Trim());
            parametros.Add(txt2Oficina.Valor.Trim());
            parametros.Add(txtCelular.Valor.Trim());
            parametros.Add(txtFax.Valor.Trim());
            if (valoresPk.Count == 0)
                parametros.Add(Utilitario.Encriptar(txtCodigo.Valor.Trim()));
            return true;
        }

        protected override bool guardarDetallePrevio(ref string error)
        {
            bool lbOk = true;
            if (ConfigurationManager.AppSettings["DBHosting"] != "WN")
            {
                if (listar.VALORES_PK.Count == 0)
                {
                    fInternas.insertarLogin(txtCodigo.Valor, txtCodigo.Valor + Constantes.PASSWORD, ConfigurationManager.AppSettings["BaseDatos"], true, ref error);
                    if (lbOk)
                        lbOk = fInternas.createUser(txtCodigo.Valor, ref error);
                    if (lbOk)
                        lbOk = fInternas.spDBAAccess(txtCodigo.Valor, ref error);
                    if (lbOk)
                        lbOk = fInternas.spDBOwner(txtCodigo.Valor, ref error);
                    if (lbOk)
                        lbOk = fInternas.spDBsysadmin(txtCodigo.Valor, ref error);
                }
            }
            return lbOk;
        }

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para el Usuario.";
                txtCodigo.Focus();
                return false;
            }

            if (txt1Nombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Usuario.";
                txt1Nombre.Focus();
                return false;
            }

            if (txt1Apellido.Valor.Trim() == "")
            {
                error = "Debe especificar un apellido para el Usuario.";
                txt1Nombre.Focus();
                return false;
            }

            if (chkCambioClave.Checked && txtCambioClave.Valor.Trim().Equals(""))
            {
                error = "Debe especificar la frecuencia de días para el cambio de clave.";
                txtCambioClave.Focus();
                return false;
            }

            if (chkCambioClave.Checked && !txtCambioClave.Valor.Trim().Equals(""))
            {
                if (decimal.Parse(txtCambioClave.Valor) == 0)
                {
                    error = "Debe especificar una frecuencia de días mayor que cero.";
                    txtCambioClave.Focus();
                    return false;
                }
            }

            //if (txtCorreoElectronico.Valor.Trim() != "")
            //{
            //    if (!Utilitario.comprobarFormatoEmail(txtCorreoElectronico.Valor.Trim()))
            //    {
            //        error = "El formato del correo eléctronico no es válido.";
            //        txtCorreoElectronico.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    error = "Debe especificar una cuenta de correo electrónico válida.";
            //    txtCorreoElectronico.Focus();
            //    return false;
            //}

            //if (txtClaveUsuario.Valor.Trim() == "")
            //{
            //    error = "Debe especificar la clave del correo electrónico.";
            //    txtClaveUsuario.Focus();
            //    return false;
            //}

            //if (txtCelular.Valor.Trim() != "")
            //{
            //    if (!Utilitario.comprobarFormatoTel(txtCelular.Valor))
            //    {
            //        error = "El formato del celular no es válido (8 dígitos).";
            //        txtCelular.Focus();
            //        return false;
            //    }
            //}

            //if (txt1Oficina.Valor.Trim() != "")
            //{
            //    if (!Utilitario.comprobarFormatoTel(txt1Oficina.Valor))
            //    {
            //        error = "El formato del teléfono no es válido (8 dígitos).";
            //        txt1Oficina.Focus();
            //        return false;
            //    }
            //}

            //if (txt2Oficina.Valor.Trim() != "")
            //{
            //    if (!Utilitario.comprobarFormatoTel(txt2Oficina.Valor))
            //    {
            //        error = "El formato del teléfono no es válido (8 dígitos).";
            //        txt2Oficina.Focus();
            //        return false;
            //    }
            //}

            //if (txtFax.Valor.Trim() != "")
            //{
            //    if (!Utilitario.comprobarFormatoTel(txtFax.Valor))
            //    {
            //        error = "El formato del fax no es válido (8 dígitos).";
            //        txtFax.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtCodigo.ReadOnly = false;
            txt1Nombre.Clear();
            txt2Nombre.Clear();
            txt1Apellido.Clear();
            txt2Apellido.Clear();
            chkActivo.Checked = true;
            privilegio = "";
            chkAdministrador.Checked = false;
            chkCambioClave.Checked = false;
            txtCambioClave.Clear();
            txtCambioClave.ReadOnly = true;
            dtpFechaCambio.Value = DateTime.Now;
            txtCorreoElectronico.Clear();
            txtCelular.Clear();
            txt1Oficina.Clear();
            txt2Oficina.Clear();
            txtFax.Clear();
            txtClaveUsuario.Clear();
            UncheckAllNodes(treeViewPrivilegios.Nodes);
            listar.VALORES_PK.Clear();        
            lblPerfil.Text = "Perfil de Usuario";
            listar.COLUMNAS = "CodigoUsuario,PrimerNombreUsuario,SegundoNombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,UsuarioActivo,UsuarioReqCambioClave,FrecCambioClaveUsuario,FechaUltimoCambioClaveUsuario" +
                                  ",PrivilegiosUsuario,UsuarioPrivilegiosAdministrador,CorreoElectronicoUsuario,ClaveCorreo,TelefonoUsuario1,TelefonoUsuario2,CelularUsuario,FaxUsuario,ClaveSistemaAdicionalUsuario,CodigoADMIN";
        }

        protected override void deshabilitarLlave()
        {
            if (valoresPk.Count == 0)
                MessageBox.Show("Se ha creado el usuario correctamente." + "\n" +
                  "Contraseña: " + txtCodigo.Valor + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            listar.COLUMNAS = "CodigoUsuario,PrimerNombreUsuario,SegundoNombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,UsuarioActivo,UsuarioReqCambioClave,FrecCambioClaveUsuario,FechaUltimoCambioClaveUsuario" +
             ",PrivilegiosUsuario,UsuarioPrivilegiosAdministrador,CorreoElectronicoUsuario,ClaveCorreo,TelefonoUsuario1,TelefonoUsuario2,CelularUsuario,FaxUsuario";
            lblPerfil.Text = "Perfil de Usuario: " + txt1Nombre.Valor;
            if (txt2Nombre.Valor != "")
                lblPerfil.Text += " " + txt2Nombre.Valor;
            lblPerfil.Text += " " + txt1Apellido.Valor;
            if (txt2Apellido.Valor != "")
                lblPerfil.Text += " " + txt2Apellido.Valor;
        }

        public void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        public void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void CheckAllChildren(TreeNode node)
        {
            if (onChanged)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    child.Checked = true;
                    CheckAllChildren(child);
                }
            }
        }

        private void UnCheckAllChildren(TreeNode node)
        {
            if (onChanged)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    child.Checked = false;
                    UnCheckAllChildren(child);
                }
            }
        }

        private void treeViewPrivilegios_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (onChanged)
            {
                if (!e.Node.Checked)
                    CheckAllChildren(e.Node);
                else
                    UnCheckAllChildren(e.Node);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (ConfigurationManager.AppSettings["DBHosting"] == "WN")
                    fInternas.actualizaClaveUsuarioVirtual(txtCodigo.Valor, Utilitario.Encriptar(txtCodigo.Valor),ref error);
                else
                    fInternas.cambiarContrasenna(txtCodigo.Valor, "", txtCodigo.Valor + Constantes.PASSWORD, true, ref error);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Se reinició la contraseña correctamente." + "\n" +
                   "Nueva Contraseña: " + txtCodigo.Valor + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeViewPrivilegios_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (onChanged)
            {
                btnGuardar.Enabled = true;
                btnGuardarSalir.Enabled = true;
            }
        }

        private void frmUsuariosEdicion_Load(object sender, EventArgs e)
        {
            txtCodigo.Mayusculas();
            txt1Nombre.Mayusculas();
            txt2Nombre.Mayusculas();
            txt1Apellido.Mayusculas();
            txt2Apellido.Mayusculas();
            txtCodigo.Longitud = 10;
            txt1Nombre.Longitud = 15;
            txt2Nombre.Longitud = 15;
            txt1Apellido.Longitud = 26;
            txt2Apellido.Longitud = 26;
            txtCorreoElectronico.Longitud = 50;
            txtCelular.Longitud = 8;
            txt1Oficina.Longitud = 8;
            txt2Oficina.Longitud = 8;
            txtFax.Longitud = 8;
            txtClaveUsuario.Longitud = 50;
            txtClaveUsuario.Password = '•';
            txtCambioClave.Right();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCodigo.ReadOnly && tabControl.SelectedIndex == 3)
            //{
            //    cargarAuditoria(txtCodigo.Valor);
            //}
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    string sQuery = "SELECT ServidorSMTP,PuerdoSalidaSMTP,HabilitarSSL from dbo.GLOBALES";
            //    DataTable dt = new DataTable();

            //    if (Consultas.fillDataTable(sQuery, ref dt, ref error))
            //    {
            //        if (dt.Rows.Count > 0)
            //        {
            //            Mail.smtpHostServer = dt.Rows[0]["ServidorSMTP"].ToString();
            //            Mail.port = int.Parse(dt.Rows[0]["PuerdoSalidaSMTP"].ToString());
            //            if (dt.Rows[0]["HabilitarSSL"].ToString() == "S")
            //                Mail.isSslEnable = true;
            //            else
            //                Mail.isSslEnable = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("No hay parámetros globales definidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    Mail.mailFrom = txtCorreoElectronico.Valor.Trim();
            //    Mail.mailTo = txtCorreoElectronico.Valor.Trim();
            //    Mail.mailSubject = "Correo Prueba KOLEGIO8";
            //    Mail.mailBody = "Esto es un correo de prueba";
            //    Mail.IsHtmlFormat = false;
            //    Mail.credentialUserName = txtCorreoElectronico.Valor.Trim();
            //    Mail.credentialUserPassword = txtClaveUsuario.Valor;

            //    if (Mail.SendMail(ref error))
            //        MessageBox.Show("Correo de prueba envíado con éxito.", "Test de Correo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    else
            //        MessageBox.Show("Fallo el envío del correo.\n" + error, "Test de Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    Mail.limpiar();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error realizando la prueba de envío de correo.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //Cursor.Current = Cursors.Default;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
        }

        private void txtCorreoElectronico_Leave(object sender, EventArgs e)
        {
        }

        private void txtClaveUsuario_Leave(object sender, EventArgs e)
        {
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            txtCelular.Valor = txtCelular.Valor.Trim();
        }

        private void txt1Oficina_Leave(object sender, EventArgs e)
        {
        }

        private void txt2Oficina_Leave(object sender, EventArgs e)
        {
        }

        private void txtFax_Leave(object sender, EventArgs e)
        {
        }

        private void txt1Nombre_Leave(object sender, EventArgs e)
        {
            txt1Nombre.Valor = txt1Nombre.Valor.Trim();
        }

        private void txt2Nombre_Leave(object sender, EventArgs e)
        {
            txt2Nombre.Valor = txt2Nombre.Valor.Trim();
        }

        private void txt1Apellido_Leave(object sender, EventArgs e)
        {
            txt1Apellido.Valor = txt1Apellido.Valor.Trim();
        }

        private void txt2Apellido_Leave(object sender, EventArgs e)
        {
            txt2Apellido.Valor = txt2Apellido.Valor.Trim();
        }
    }
}
