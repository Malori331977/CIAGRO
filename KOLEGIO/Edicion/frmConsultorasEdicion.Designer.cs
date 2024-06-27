namespace KOLEGIO
{
    partial class frmConsultorasEdicion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultorasEdicion));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCantonNombreF = new Framework.UserControls.txtNormal();
            this.txtProvinciaNombreF = new Framework.UserControls.txtNormal();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtProvincia = new Framework.UserControls.txtNormal();
            this.txtDistritoNombreF = new Framework.UserControls.txtNormal();
            this.txtDistrito = new Framework.UserControls.txtNormal();
            this.txtCanton = new Framework.UserControls.txtNormal();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmailAdicional = new Framework.UserControls.txtNormal();
            this.txtEmail = new Framework.UserControls.txtNormal();
            this.label17 = new System.Windows.Forms.Label();
            this.txtApartado = new Framework.UserControls.txtNormal();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFax = new Framework.UserControls.txtNormal();
            this.txtTelefono = new Framework.UserControls.txtNormal();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombre = new Framework.UserControls.txtNormal();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNo = new Framework.UserControls.rbSaseg();
            this.rbSi = new Framework.UserControls.rbSaseg();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCedulaJuridica = new Framework.UserControls.txtNormal();
            this.lblSesionCierre = new System.Windows.Forms.Label();
            this.txtSesionCierre = new Framework.UserControls.txtNormal();
            this.dtpFechaCierre = new Framework.UserControls.dtpSaseg();
            this.lblFechaCierre = new System.Windows.Forms.Label();
            this.rtbDireccion = new Framework.UserControls.rtbSaseg();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSesionAprobacion = new Framework.UserControls.txtNormal();
            this.dtpFechaAprobacion = new Framework.UserControls.dtpSaseg();
            this.label9 = new System.Windows.Forms.Label();
            this.tpCamposAccion = new System.Windows.Forms.TabPage();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dgvCamposAccion = new System.Windows.Forms.DataGridView();
            this.colCodigoCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcionCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.btnCampoAccion = new System.Windows.Forms.ToolStripButton();
            this.btnEliminaCampoAccion = new System.Windows.Forms.ToolStripButton();
            this.tpColegiados = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoColegiado = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarColegiado = new System.Windows.Forms.ToolStripButton();
            this.dgvColegiados = new System.Windows.Forms.DataGridView();
            this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSesionRenov = new Framework.UserControls.txtNormal();
            this.dtpFechaRenov = new Framework.UserControls.dtpSaseg();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbEstado = new Framework.UserControls.cmbSaseg();
            this.txtCobrador = new Framework.UserControls.txtNormal();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCobradorNombre = new Framework.UserControls.txtNormal();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpCamposAccion.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamposAccion)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.tpColegiados.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpCamposAccion);
            this.tabControl.Controls.Add(this.tpColegiados);
            this.tabControl.Size = new System.Drawing.Size(694, 583);
            this.tabControl.Controls.SetChildIndex(this.tpColegiados, 0);
            this.tabControl.Controls.SetChildIndex(this.tpCamposAccion, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
            this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.txtCobrador);
            this.tpBasicos.Controls.Add(this.label23);
            this.tpBasicos.Controls.Add(this.txtCobradorNombre);
            this.tpBasicos.Controls.Add(this.label20);
            this.tpBasicos.Controls.Add(this.cmbEstado);
            this.tpBasicos.Controls.Add(this.label13);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label11);
            this.tpBasicos.Controls.Add(this.txtSesionRenov);
            this.tpBasicos.Controls.Add(this.dtpFechaRenov);
            this.tpBasicos.Controls.Add(this.label12);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.txtSesionAprobacion);
            this.tpBasicos.Controls.Add(this.dtpFechaAprobacion);
            this.tpBasicos.Controls.Add(this.label9);
            this.tpBasicos.Controls.Add(this.lblSesionCierre);
            this.tpBasicos.Controls.Add(this.txtSesionCierre);
            this.tpBasicos.Controls.Add(this.dtpFechaCierre);
            this.tpBasicos.Controls.Add(this.lblFechaCierre);
            this.tpBasicos.Controls.Add(this.rtbDireccion);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.groupBox3);
            this.tpBasicos.Controls.Add(this.groupBox2);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.txtNombre);
            this.tpBasicos.Controls.Add(this.groupBox1);
            this.tpBasicos.Controls.Add(this.label7);
            this.tpBasicos.Controls.Add(this.txtCedulaJuridica);
            this.tpBasicos.Size = new System.Drawing.Size(686, 557);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCedulaJuridica, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox3, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbDireccion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.lblFechaCierre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpFechaCierre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionCierre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.lblSesionCierre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label9, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpFechaAprobacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionAprobacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label12, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpFechaRenov, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionRenov, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label13, 0);
            this.tpBasicos.Controls.SetChildIndex(this.cmbEstado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label20, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCobradorNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label23, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCobrador, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(686, 557);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(680, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(680, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(686, 557);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(680, 21);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCantonNombreF);
            this.groupBox3.Controls.Add(this.txtProvinciaNombreF);
            this.groupBox3.Controls.Add(this.label43);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.txtProvincia);
            this.groupBox3.Controls.Add(this.txtDistritoNombreF);
            this.groupBox3.Controls.Add(this.txtDistrito);
            this.groupBox3.Controls.Add(this.txtCanton);
            this.groupBox3.Location = new System.Drawing.Point(102, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(539, 100);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ubicación";
            // 
            // txtCantonNombreF
            // 
            this.txtCantonNombreF.FormatearNumero = false;
            this.txtCantonNombreF.Location = new System.Drawing.Point(239, 40);
            this.txtCantonNombreF.Longitud = 32767;
            this.txtCantonNombreF.Multilinea = false;
            this.txtCantonNombreF.Name = "txtCantonNombreF";
            this.txtCantonNombreF.Password = '\0';
            this.txtCantonNombreF.ReadOnly = true;
            this.txtCantonNombreF.Size = new System.Drawing.Size(179, 21);
            this.txtCantonNombreF.TabIndex = 275;
            this.txtCantonNombreF.Valor = "";
            // 
            // txtProvinciaNombreF
            // 
            this.txtProvinciaNombreF.FormatearNumero = false;
            this.txtProvinciaNombreF.Location = new System.Drawing.Point(239, 13);
            this.txtProvinciaNombreF.Longitud = 32767;
            this.txtProvinciaNombreF.Multilinea = false;
            this.txtProvinciaNombreF.Name = "txtProvinciaNombreF";
            this.txtProvinciaNombreF.Password = '\0';
            this.txtProvinciaNombreF.ReadOnly = true;
            this.txtProvinciaNombreF.Size = new System.Drawing.Size(179, 21);
            this.txtProvinciaNombreF.TabIndex = 274;
            this.txtProvinciaNombreF.Valor = "";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(121, 18);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(54, 13);
            this.label43.TabIndex = 271;
            this.label43.Text = "Provincia:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(131, 44);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 13);
            this.label44.TabIndex = 272;
            this.label44.Text = "Cantón:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(133, 72);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(42, 13);
            this.label45.TabIndex = 273;
            this.label45.Text = "Distrito:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.FormatearNumero = false;
            this.txtProvincia.Location = new System.Drawing.Point(181, 13);
            this.txtProvincia.Longitud = 2;
            this.txtProvincia.Multilinea = false;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Password = '\0';
            this.txtProvincia.ReadOnly = false;
            this.txtProvincia.Size = new System.Drawing.Size(59, 21);
            this.txtProvincia.TabIndex = 267;
            this.txtProvincia.Valor = "";
            this.txtProvincia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvincia_KeyDown);
            this.txtProvincia.Leave += new System.EventHandler(this.txtProvincia_Leave);
            this.txtProvincia.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtProvincia_MouseDoubleClick);
            // 
            // txtDistritoNombreF
            // 
            this.txtDistritoNombreF.FormatearNumero = false;
            this.txtDistritoNombreF.Location = new System.Drawing.Point(239, 67);
            this.txtDistritoNombreF.Longitud = 32767;
            this.txtDistritoNombreF.Multilinea = false;
            this.txtDistritoNombreF.Name = "txtDistritoNombreF";
            this.txtDistritoNombreF.Password = '\0';
            this.txtDistritoNombreF.ReadOnly = true;
            this.txtDistritoNombreF.Size = new System.Drawing.Size(179, 21);
            this.txtDistritoNombreF.TabIndex = 270;
            this.txtDistritoNombreF.Valor = "";
            // 
            // txtDistrito
            // 
            this.txtDistrito.FormatearNumero = false;
            this.txtDistrito.Location = new System.Drawing.Point(181, 67);
            this.txtDistrito.Longitud = 2;
            this.txtDistrito.Multilinea = false;
            this.txtDistrito.Name = "txtDistrito";
            this.txtDistrito.Password = '\0';
            this.txtDistrito.ReadOnly = false;
            this.txtDistrito.Size = new System.Drawing.Size(59, 21);
            this.txtDistrito.TabIndex = 269;
            this.txtDistrito.Valor = "";
            this.txtDistrito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDistrito_KeyDown);
            this.txtDistrito.Leave += new System.EventHandler(this.txtDistrito_Leave);
            this.txtDistrito.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDistrito_MouseDoubleClick);
            // 
            // txtCanton
            // 
            this.txtCanton.FormatearNumero = false;
            this.txtCanton.Location = new System.Drawing.Point(181, 40);
            this.txtCanton.Longitud = 2;
            this.txtCanton.Multilinea = false;
            this.txtCanton.Name = "txtCanton";
            this.txtCanton.Password = '\0';
            this.txtCanton.ReadOnly = false;
            this.txtCanton.Size = new System.Drawing.Size(59, 21);
            this.txtCanton.TabIndex = 268;
            this.txtCanton.Valor = "";
            this.txtCanton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCanton_KeyDown);
            this.txtCanton.Leave += new System.EventHandler(this.txtCanton_Leave);
            this.txtCanton.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCanton_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtEmailAdicional);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtApartado);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtFax);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Location = new System.Drawing.Point(102, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 133);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Localización";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 13);
            this.label19.TabIndex = 71;
            this.label19.Text = "Email Adicional:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(47, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Email:";
            // 
            // txtEmailAdicional
            // 
            this.txtEmailAdicional.FormatearNumero = false;
            this.txtEmailAdicional.Location = new System.Drawing.Point(88, 95);
            this.txtEmailAdicional.Longitud = 32767;
            this.txtEmailAdicional.Multilinea = false;
            this.txtEmailAdicional.Name = "txtEmailAdicional";
            this.txtEmailAdicional.Password = '\0';
            this.txtEmailAdicional.ReadOnly = false;
            this.txtEmailAdicional.Size = new System.Drawing.Size(417, 21);
            this.txtEmailAdicional.TabIndex = 70;
            this.txtEmailAdicional.Valor = "";
            // 
            // txtEmail
            // 
            this.txtEmail.FormatearNumero = false;
            this.txtEmail.Location = new System.Drawing.Point(88, 58);
            this.txtEmail.Longitud = 32767;
            this.txtEmail.Multilinea = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Password = '\0';
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(417, 21);
            this.txtEmail.TabIndex = 25;
            this.txtEmail.Valor = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(344, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Apartado:";
            // 
            // txtApartado
            // 
            this.txtApartado.FormatearNumero = false;
            this.txtApartado.Location = new System.Drawing.Point(403, 22);
            this.txtApartado.Longitud = 32767;
            this.txtApartado.Multilinea = false;
            this.txtApartado.Name = "txtApartado";
            this.txtApartado.Password = '\0';
            this.txtApartado.ReadOnly = false;
            this.txtApartado.Size = new System.Drawing.Size(102, 21);
            this.txtApartado.TabIndex = 23;
            this.txtApartado.Valor = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Fax:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Teléfono:";
            // 
            // txtFax
            // 
            this.txtFax.FormatearNumero = false;
            this.txtFax.Location = new System.Drawing.Point(229, 22);
            this.txtFax.Longitud = 32767;
            this.txtFax.Multilinea = false;
            this.txtFax.Name = "txtFax";
            this.txtFax.Password = '\0';
            this.txtFax.ReadOnly = false;
            this.txtFax.Size = new System.Drawing.Size(102, 21);
            this.txtFax.TabIndex = 21;
            this.txtFax.Valor = "";
            // 
            // txtTelefono
            // 
            this.txtTelefono.FormatearNumero = false;
            this.txtTelefono.Location = new System.Drawing.Point(88, 22);
            this.txtTelefono.Longitud = 32767;
            this.txtTelefono.Multilinea = false;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Password = '\0';
            this.txtTelefono.ReadOnly = false;
            this.txtTelefono.Size = new System.Drawing.Size(102, 21);
            this.txtTelefono.TabIndex = 19;
            this.txtTelefono.Valor = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.FormatearNumero = false;
            this.txtNombre.Location = new System.Drawing.Point(102, 99);
            this.txtNombre.Longitud = 32767;
            this.txtNombre.Multilinea = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Password = '\0';
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Size = new System.Drawing.Size(541, 21);
            this.txtNombre.TabIndex = 35;
            this.txtNombre.Valor = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Controls.Add(this.rbSi);
            this.groupBox1.Location = new System.Drawing.Point(527, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 46);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paga Canon";
            // 
            // rbNo
            // 
            this.rbNo.Checked = false;
            this.rbNo.Location = new System.Drawing.Point(65, 20);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(44, 18);
            this.rbNo.TabIndex = 1;
            this.rbNo.Texto = "No";
            // 
            // rbSi
            // 
            this.rbSi.Checked = false;
            this.rbSi.Location = new System.Drawing.Point(15, 19);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(44, 18);
            this.rbSi.TabIndex = 0;
            this.rbSi.Texto = "Si";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Cedula Juridica:";
            // 
            // txtCedulaJuridica
            // 
            this.txtCedulaJuridica.FormatearNumero = false;
            this.txtCedulaJuridica.Location = new System.Drawing.Point(304, 47);
            this.txtCedulaJuridica.Longitud = 32767;
            this.txtCedulaJuridica.Multilinea = false;
            this.txtCedulaJuridica.Name = "txtCedulaJuridica";
            this.txtCedulaJuridica.Password = '\0';
            this.txtCedulaJuridica.ReadOnly = false;
            this.txtCedulaJuridica.Size = new System.Drawing.Size(94, 21);
            this.txtCedulaJuridica.TabIndex = 28;
            this.txtCedulaJuridica.Valor = "";
            // 
            // lblSesionCierre
            // 
            this.lblSesionCierre.AutoSize = true;
            this.lblSesionCierre.Location = new System.Drawing.Point(258, 521);
            this.lblSesionCierre.Name = "lblSesionCierre";
            this.lblSesionCierre.Size = new System.Drawing.Size(72, 13);
            this.lblSesionCierre.TabIndex = 59;
            this.lblSesionCierre.Text = "Sesión Cierre:";
            // 
            // txtSesionCierre
            // 
            this.txtSesionCierre.FormatearNumero = false;
            this.txtSesionCierre.Location = new System.Drawing.Point(336, 517);
            this.txtSesionCierre.Longitud = 32767;
            this.txtSesionCierre.Multilinea = false;
            this.txtSesionCierre.Name = "txtSesionCierre";
            this.txtSesionCierre.Password = '\0';
            this.txtSesionCierre.ReadOnly = false;
            this.txtSesionCierre.Size = new System.Drawing.Size(306, 21);
            this.txtSesionCierre.TabIndex = 58;
            this.txtSesionCierre.Valor = "";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.Checked = false;
            this.dtpFechaCierre.Location = new System.Drawing.Point(102, 517);
            this.dtpFechaCierre.mostrarCheckBox = true;
            this.dtpFechaCierre.mostrarUpDown = false;
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(105, 22);
            this.dtpFechaCierre.TabIndex = 57;
            this.dtpFechaCierre.Value = new System.DateTime(2019, 1, 18, 11, 31, 42, 490);
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.AutoSize = true;
            this.lblFechaCierre.Location = new System.Drawing.Point(31, 521);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(70, 13);
            this.lblFechaCierre.TabIndex = 56;
            this.lblFechaCierre.Text = "Fecha Cierre:";
            // 
            // rtbDireccion
            // 
            this.rtbDireccion.Location = new System.Drawing.Point(103, 406);
            this.rtbDireccion.Longitud = 2147483647;
            this.rtbDireccion.Mayusculas = false;
            this.rtbDireccion.Name = "rtbDireccion";
            this.rtbDireccion.ReadOnly = false;
            this.rtbDireccion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbDireccion.Size = new System.Drawing.Size(539, 51);
            this.rtbDireccion.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 410);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Dirección:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 466);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Sesión Aprobación:";
            // 
            // txtSesionAprobacion
            // 
            this.txtSesionAprobacion.FormatearNumero = false;
            this.txtSesionAprobacion.Location = new System.Drawing.Point(336, 463);
            this.txtSesionAprobacion.Longitud = 32767;
            this.txtSesionAprobacion.Multilinea = false;
            this.txtSesionAprobacion.Name = "txtSesionAprobacion";
            this.txtSesionAprobacion.Password = '\0';
            this.txtSesionAprobacion.ReadOnly = false;
            this.txtSesionAprobacion.Size = new System.Drawing.Size(307, 21);
            this.txtSesionAprobacion.TabIndex = 62;
            this.txtSesionAprobacion.Valor = "";
            // 
            // dtpFechaAprobacion
            // 
            this.dtpFechaAprobacion.Checked = true;
            this.dtpFechaAprobacion.Location = new System.Drawing.Point(103, 463);
            this.dtpFechaAprobacion.mostrarCheckBox = false;
            this.dtpFechaAprobacion.mostrarUpDown = false;
            this.dtpFechaAprobacion.Name = "dtpFechaAprobacion";
            this.dtpFechaAprobacion.Size = new System.Drawing.Size(104, 22);
            this.dtpFechaAprobacion.TabIndex = 61;
            this.dtpFechaAprobacion.Value = new System.DateTime(2019, 1, 18, 11, 31, 42, 490);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 466);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Fecha Aprobación:";
            // 
            // tpCamposAccion
            // 
            this.tpCamposAccion.Controls.Add(this.panel13);
            this.tpCamposAccion.Location = new System.Drawing.Point(4, 22);
            this.tpCamposAccion.Name = "tpCamposAccion";
            this.tpCamposAccion.Padding = new System.Windows.Forms.Padding(3);
            this.tpCamposAccion.Size = new System.Drawing.Size(686, 557);
            this.tpCamposAccion.TabIndex = 3;
            this.tpCamposAccion.Text = "Campos de Acción";
            this.tpCamposAccion.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.Controls.Add(this.dgvCamposAccion);
            this.panel13.Controls.Add(this.toolStrip5);
            this.panel13.Location = new System.Drawing.Point(32, 44);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(617, 476);
            this.panel13.TabIndex = 253;
            // 
            // dgvCamposAccion
            // 
            this.dgvCamposAccion.AllowUserToAddRows = false;
            this.dgvCamposAccion.AllowUserToDeleteRows = false;
            this.dgvCamposAccion.AllowUserToResizeRows = false;
            this.dgvCamposAccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCamposAccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCamposAccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCamposAccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoCampo,
            this.colNombreCampo,
            this.colDescripcionCampo});
            this.dgvCamposAccion.Location = new System.Drawing.Point(3, 28);
            this.dgvCamposAccion.Name = "dgvCamposAccion";
            this.dgvCamposAccion.RowHeadersVisible = false;
            this.dgvCamposAccion.Size = new System.Drawing.Size(611, 445);
            this.dgvCamposAccion.TabIndex = 253;
            this.dgvCamposAccion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCamposAccion_MouseDoubleClick);
            // 
            // colCodigoCampo
            // 
            this.colCodigoCampo.FillWeight = 63.45178F;
            this.colCodigoCampo.HeaderText = "Código";
            this.colCodigoCampo.Name = "colCodigoCampo";
            this.colCodigoCampo.ReadOnly = true;
            // 
            // colNombreCampo
            // 
            this.colNombreCampo.FillWeight = 182.3327F;
            this.colNombreCampo.HeaderText = "Nombre";
            this.colNombreCampo.Name = "colNombreCampo";
            this.colNombreCampo.ReadOnly = true;
            // 
            // colDescripcionCampo
            // 
            this.colDescripcionCampo.HeaderText = "Descripción";
            this.colDescripcionCampo.Name = "colDescripcionCampo";
            this.colDescripcionCampo.ReadOnly = true;
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCampoAccion,
            this.btnEliminaCampoAccion});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(617, 25);
            this.toolStrip5.TabIndex = 252;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // btnCampoAccion
            // 
            this.btnCampoAccion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCampoAccion.Image = ((System.Drawing.Image)(resources.GetObject("btnCampoAccion.Image")));
            this.btnCampoAccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCampoAccion.Name = "btnCampoAccion";
            this.btnCampoAccion.Size = new System.Drawing.Size(23, 22);
            this.btnCampoAccion.Text = "Agregar Campos de Acción";
            this.btnCampoAccion.Click += new System.EventHandler(this.btnCampoAccion_Click);
            // 
            // btnEliminaCampoAccion
            // 
            this.btnEliminaCampoAccion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminaCampoAccion.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaCampoAccion.Image")));
            this.btnEliminaCampoAccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminaCampoAccion.Name = "btnEliminaCampoAccion";
            this.btnEliminaCampoAccion.Size = new System.Drawing.Size(23, 22);
            this.btnEliminaCampoAccion.Text = "Quitar Campo de Acción";
            this.btnEliminaCampoAccion.Click += new System.EventHandler(this.btnEliminaCampoAccion_Click);
            // 
            // tpColegiados
            // 
            this.tpColegiados.Controls.Add(this.groupBox13);
            this.tpColegiados.Location = new System.Drawing.Point(4, 22);
            this.tpColegiados.Name = "tpColegiados";
            this.tpColegiados.Size = new System.Drawing.Size(686, 557);
            this.tpColegiados.TabIndex = 4;
            this.tpColegiados.Text = "Profesionales Responsables";
            this.tpColegiados.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.toolStrip3);
            this.groupBox13.Controls.Add(this.dgvColegiados);
            this.groupBox13.Location = new System.Drawing.Point(29, 32);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(624, 500);
            this.groupBox13.TabIndex = 45;
            this.groupBox13.TabStop = false;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoColegiado,
            this.btnEliminarColegiado});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(618, 25);
            this.toolStrip3.TabIndex = 253;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnNuevoColegiado
            // 
            this.btnNuevoColegiado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoColegiado.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoColegiado.Image")));
            this.btnNuevoColegiado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoColegiado.Name = "btnNuevoColegiado";
            this.btnNuevoColegiado.Size = new System.Drawing.Size(23, 22);
            this.btnNuevoColegiado.Text = "Agregar Responsable";
            this.btnNuevoColegiado.Click += new System.EventHandler(this.btnNuevoColegiado_Click);
            // 
            // btnEliminarColegiado
            // 
            this.btnEliminarColegiado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarColegiado.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarColegiado.Image")));
            this.btnEliminarColegiado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarColegiado.Name = "btnEliminarColegiado";
            this.btnEliminarColegiado.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarColegiado.Text = "Quitar Responsable";
            this.btnEliminarColegiado.Click += new System.EventHandler(this.btnEliminarColegiado_Click);
            // 
            // dgvColegiados
            // 
            this.dgvColegiados.AllowUserToAddRows = false;
            this.dgvColegiados.AllowUserToDeleteRows = false;
            this.dgvColegiados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColegiados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColegiados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColegiados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroColegiado,
            this.colCodigoColegiado,
            this.colNombreColegiado});
            this.dgvColegiados.Location = new System.Drawing.Point(6, 41);
            this.dgvColegiados.Name = "dgvColegiados";
            this.dgvColegiados.RowHeadersVisible = false;
            this.dgvColegiados.Size = new System.Drawing.Size(618, 450);
            this.dgvColegiados.TabIndex = 43;
            this.dgvColegiados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvColegiados_MouseDoubleClick);
            // 
            // colNumeroColegiado
            // 
            this.colNumeroColegiado.HeaderText = "Nº Colegiado";
            this.colNumeroColegiado.Name = "colNumeroColegiado";
            this.colNumeroColegiado.ReadOnly = true;
            // 
            // colCodigoColegiado
            // 
            this.colCodigoColegiado.FillWeight = 76.14213F;
            this.colCodigoColegiado.HeaderText = "Cedula";
            this.colCodigoColegiado.Name = "colCodigoColegiado";
            this.colCodigoColegiado.ReadOnly = true;
            // 
            // colNombreColegiado
            // 
            this.colNombreColegiado.FillWeight = 166.913F;
            this.colNombreColegiado.HeaderText = "Nombre";
            this.colNombreColegiado.Name = "colNombreColegiado";
            this.colNombreColegiado.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 493);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Sesión Renovación:";
            // 
            // txtSesionRenov
            // 
            this.txtSesionRenov.FormatearNumero = false;
            this.txtSesionRenov.Location = new System.Drawing.Point(336, 490);
            this.txtSesionRenov.Longitud = 32767;
            this.txtSesionRenov.Multilinea = false;
            this.txtSesionRenov.Name = "txtSesionRenov";
            this.txtSesionRenov.Password = '\0';
            this.txtSesionRenov.ReadOnly = false;
            this.txtSesionRenov.Size = new System.Drawing.Size(306, 21);
            this.txtSesionRenov.TabIndex = 66;
            this.txtSesionRenov.Valor = "";
            // 
            // dtpFechaRenov
            // 
            this.dtpFechaRenov.Checked = false;
            this.dtpFechaRenov.Location = new System.Drawing.Point(102, 490);
            this.dtpFechaRenov.mostrarCheckBox = true;
            this.dtpFechaRenov.mostrarUpDown = false;
            this.dtpFechaRenov.Name = "dtpFechaRenov";
            this.dtpFechaRenov.Size = new System.Drawing.Size(105, 22);
            this.dtpFechaRenov.TabIndex = 65;
            this.dtpFechaRenov.Value = new System.DateTime(2019, 1, 18, 11, 31, 42, 490);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 493);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 64;
            this.label12.Text = "Fecha Renovación:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(102, 47);
            this.txtCodigo.Longitud = 32767;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(94, 21);
            this.txtCodigo.TabIndex = 68;
            this.txtCodigo.Valor = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(53, 78);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 71;
            this.label20.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Habilitar = true;
            this.cmbEstado.Index = -1;
            this.cmbEstado.Location = new System.Drawing.Point(102, 74);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(93, 22);
            this.cmbEstado.TabIndex = 70;
            this.cmbEstado.Texto = "";
            this.cmbEstado.Valor = "";
            // 
            // txtCobrador
            // 
            this.txtCobrador.FormatearNumero = false;
            this.txtCobrador.Location = new System.Drawing.Point(102, 371);
            this.txtCobrador.Longitud = 30;
            this.txtCobrador.Multilinea = false;
            this.txtCobrador.Name = "txtCobrador";
            this.txtCobrador.Password = '\0';
            this.txtCobrador.ReadOnly = false;
            this.txtCobrador.Size = new System.Drawing.Size(82, 21);
            this.txtCobrador.TabIndex = 74;
            this.txtCobrador.Valor = "";
            this.txtCobrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobrador_KeyDown);
            this.txtCobrador.Leave += new System.EventHandler(this.txtCobrador_Leave);
            this.txtCobrador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCobrador_MouseDoubleClick);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(43, 374);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 73;
            this.label23.Text = "Cobrador:";
            // 
            // txtCobradorNombre
            // 
            this.txtCobradorNombre.FormatearNumero = false;
            this.txtCobradorNombre.Location = new System.Drawing.Point(186, 371);
            this.txtCobradorNombre.Longitud = 30;
            this.txtCobradorNombre.Multilinea = false;
            this.txtCobradorNombre.Name = "txtCobradorNombre";
            this.txtCobradorNombre.Password = '\0';
            this.txtCobradorNombre.ReadOnly = true;
            this.txtCobradorNombre.Size = new System.Drawing.Size(457, 21);
            this.txtCobradorNombre.TabIndex = 72;
            this.txtCobradorNombre.Valor = "";
            // 
            // frmConsultorasEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 674);
            this.Name = "frmConsultorasEdicion";
            this.Text = "Consultoras";
            this.Load += new System.EventHandler(this.frmConsultorasEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpBasicos.ResumeLayout(false);
            this.tpBasicos.PerformLayout();
            this.tpAdmin.ResumeLayout(false);
            this.tpAdmin.PerformLayout();
            this.panelBasicos.ResumeLayout(false);
            this.panelBasicos.PerformLayout();
            this.tpAdjuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tpCamposAccion.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamposAccion)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tpColegiados.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Framework.UserControls.txtNormal txtCantonNombreF;
        private Framework.UserControls.txtNormal txtProvinciaNombreF;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private Framework.UserControls.txtNormal txtProvincia;
        private Framework.UserControls.txtNormal txtDistritoNombreF;
        private Framework.UserControls.txtNormal txtDistrito;
        private Framework.UserControls.txtNormal txtCanton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private Framework.UserControls.txtNormal txtEmail;
        private System.Windows.Forms.Label label17;
        private Framework.UserControls.txtNormal txtApartado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Framework.UserControls.txtNormal txtFax;
        private Framework.UserControls.txtNormal txtTelefono;
        private System.Windows.Forms.Label label10;
        private Framework.UserControls.txtNormal txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.UserControls.rbSaseg rbNo;
        private Framework.UserControls.rbSaseg rbSi;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtCedulaJuridica;
        private System.Windows.Forms.Label lblSesionCierre;
        private Framework.UserControls.txtNormal txtSesionCierre;
        private Framework.UserControls.dtpSaseg dtpFechaCierre;
        private System.Windows.Forms.Label lblFechaCierre;
        private Framework.UserControls.rtbSaseg rtbDireccion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtSesionAprobacion;
        private Framework.UserControls.dtpSaseg dtpFechaAprobacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tpCamposAccion;
        private System.Windows.Forms.TabPage tpColegiados;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.DataGridView dgvCamposAccion;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton btnCampoAccion;
        private System.Windows.Forms.ToolStripButton btnEliminaCampoAccion;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevoColegiado;
        private System.Windows.Forms.ToolStripButton btnEliminarColegiado;
        private System.Windows.Forms.DataGridView dgvColegiados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreColegiado;
        private System.Windows.Forms.Label label11;
        private Framework.UserControls.txtNormal txtSesionRenov;
        private Framework.UserControls.dtpSaseg dtpFechaRenov;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.txtNormal txtCodigo;
        private System.Windows.Forms.Label label19;
        private Framework.UserControls.txtNormal txtEmailAdicional;
        private System.Windows.Forms.Label label20;
        private Framework.UserControls.cmbSaseg cmbEstado;
        private Framework.UserControls.txtNormal txtCobrador;
        private System.Windows.Forms.Label label23;
        private Framework.UserControls.txtNormal txtCobradorNombre;
    }
}