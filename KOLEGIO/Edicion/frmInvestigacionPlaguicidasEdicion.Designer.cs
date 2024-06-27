namespace KOLEGIO.Edicion
{
    partial class frmInvestigacionPlaguicidasEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvestigacionPlaguicidasEdicion));
            this.txtNColegiado = new Framework.UserControls.txtNormal();
            this.chkPagaCanon = new Framework.UserControls.chkSaseg();
            this.label17 = new System.Windows.Forms.Label();
            this.rtbObservaciones = new Framework.UserControls.rtbSaseg();
            this.dtpPerdida = new Framework.UserControls.dtpSaseg();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSesionPerdida = new Framework.UserControls.txtNormal();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpRenovacion = new Framework.UserControls.dtpSaseg();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSesionRenov = new Framework.UserControls.txtNormal();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpAprobacion = new Framework.UserControls.dtpSaseg();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSesionAprob = new Framework.UserControls.txtNormal();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCampoInvestigacion = new Framework.UserControls.txtNormal();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCampoInvestigacionNombre = new Framework.UserControls.txtNormal();
            this.txtNumColegiado = new Framework.UserControls.txtNormal();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreColegiado = new Framework.UserControls.txtNormal();
            this.tpCamposInvest = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.btnAgregarCampo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarCampo = new System.Windows.Forms.ToolStripButton();
            this.dgvCampoInvestigacion = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.tpCamposInvest.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampoInvestigacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpCamposInvest);
            this.tabControl.Size = new System.Drawing.Size(800, 359);
            this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
            this.tabControl.Controls.SetChildIndex(this.tpCamposInvest, 0);
            this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.txtNColegiado);
            this.tpBasicos.Controls.Add(this.chkPagaCanon);
            this.tpBasicos.Controls.Add(this.label17);
            this.tpBasicos.Controls.Add(this.rtbObservaciones);
            this.tpBasicos.Controls.Add(this.dtpPerdida);
            this.tpBasicos.Controls.Add(this.label15);
            this.tpBasicos.Controls.Add(this.txtSesionPerdida);
            this.tpBasicos.Controls.Add(this.label16);
            this.tpBasicos.Controls.Add(this.dtpRenovacion);
            this.tpBasicos.Controls.Add(this.label13);
            this.tpBasicos.Controls.Add(this.txtSesionRenov);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.dtpAprobacion);
            this.tpBasicos.Controls.Add(this.label12);
            this.tpBasicos.Controls.Add(this.txtSesionAprob);
            this.tpBasicos.Controls.Add(this.label11);
            this.tpBasicos.Controls.Add(this.txtCampoInvestigacion);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.txtCampoInvestigacionNombre);
            this.tpBasicos.Controls.Add(this.txtNumColegiado);
            this.tpBasicos.Controls.Add(this.label7);
            this.tpBasicos.Controls.Add(this.txtNombreColegiado);
            this.tpBasicos.Size = new System.Drawing.Size(792, 333);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombreColegiado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNumColegiado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCampoInvestigacionNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCampoInvestigacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionAprob, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label12, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpAprobacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionRenov, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label13, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpRenovacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label16, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionPerdida, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label15, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpPerdida, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbObservaciones, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label17, 0);
            this.tpBasicos.Controls.SetChildIndex(this.chkPagaCanon, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNColegiado, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(792, 333);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(786, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(786, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(792, 333);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(786, 21);
            // 
            // flvListado
            // 
            this.flvListado.Size = new System.Drawing.Size(772, 259);
            // 
            // txtNColegiado
            // 
            this.txtNColegiado.FormatearNumero = false;
            this.txtNColegiado.Location = new System.Drawing.Point(245, 88);
            this.txtNColegiado.Longitud = 30;
            this.txtNColegiado.Multilinea = false;
            this.txtNColegiado.Name = "txtNColegiado";
            this.txtNColegiado.Password = '\0';
            this.txtNColegiado.ReadOnly = false;
            this.txtNColegiado.Size = new System.Drawing.Size(112, 21);
            this.txtNColegiado.TabIndex = 58;
            this.txtNColegiado.Valor = "";
            // 
            // chkPagaCanon
            // 
            this.chkPagaCanon.Checked = false;
            this.chkPagaCanon.Location = new System.Drawing.Point(520, 145);
            this.chkPagaCanon.Name = "chkPagaCanon";
            this.chkPagaCanon.Size = new System.Drawing.Size(139, 17);
            this.chkPagaCanon.TabIndex = 57;
            this.chkPagaCanon.Texto = "Paga Canon";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(158, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 56;
            this.label17.Text = "Observaciones:";
            // 
            // rtbObservaciones
            // 
            this.rtbObservaciones.Location = new System.Drawing.Point(245, 223);
            this.rtbObservaciones.Longitud = 2147483647;
            this.rtbObservaciones.Mayusculas = false;
            this.rtbObservaciones.Name = "rtbObservaciones";
            this.rtbObservaciones.ReadOnly = false;
            this.rtbObservaciones.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbObservaciones.Size = new System.Drawing.Size(414, 66);
            this.rtbObservaciones.TabIndex = 55;
            // 
            // dtpPerdida
            // 
            this.dtpPerdida.Checked = true;
            this.dtpPerdida.Location = new System.Drawing.Point(409, 196);
            this.dtpPerdida.mostrarCheckBox = false;
            this.dtpPerdida.mostrarUpDown = false;
            this.dtpPerdida.Name = "dtpPerdida";
            this.dtpPerdida.Size = new System.Drawing.Size(96, 22);
            this.dtpPerdida.TabIndex = 54;
            this.dtpPerdida.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(363, 199);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "Fecha:";
            // 
            // txtSesionPerdida
            // 
            this.txtSesionPerdida.FormatearNumero = false;
            this.txtSesionPerdida.Location = new System.Drawing.Point(245, 196);
            this.txtSesionPerdida.Longitud = 30;
            this.txtSesionPerdida.Multilinea = false;
            this.txtSesionPerdida.Name = "txtSesionPerdida";
            this.txtSesionPerdida.Password = '\0';
            this.txtSesionPerdida.ReadOnly = false;
            this.txtSesionPerdida.Size = new System.Drawing.Size(112, 21);
            this.txtSesionPerdida.TabIndex = 52;
            this.txtSesionPerdida.Valor = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(118, 199);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Número Sesión Perdida:";
            // 
            // dtpRenovacion
            // 
            this.dtpRenovacion.Checked = true;
            this.dtpRenovacion.Location = new System.Drawing.Point(409, 169);
            this.dtpRenovacion.mostrarCheckBox = false;
            this.dtpRenovacion.mostrarUpDown = false;
            this.dtpRenovacion.Name = "dtpRenovacion";
            this.dtpRenovacion.Size = new System.Drawing.Size(96, 22);
            this.dtpRenovacion.TabIndex = 50;
            this.dtpRenovacion.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(363, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "Fecha:";
            // 
            // txtSesionRenov
            // 
            this.txtSesionRenov.FormatearNumero = false;
            this.txtSesionRenov.Location = new System.Drawing.Point(245, 169);
            this.txtSesionRenov.Longitud = 30;
            this.txtSesionRenov.Multilinea = false;
            this.txtSesionRenov.Name = "txtSesionRenov";
            this.txtSesionRenov.Password = '\0';
            this.txtSesionRenov.ReadOnly = false;
            this.txtSesionRenov.Size = new System.Drawing.Size(112, 21);
            this.txtSesionRenov.TabIndex = 48;
            this.txtSesionRenov.Valor = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(96, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Número Sesión Renovación:";
            // 
            // dtpAprobacion
            // 
            this.dtpAprobacion.Checked = true;
            this.dtpAprobacion.Location = new System.Drawing.Point(409, 142);
            this.dtpAprobacion.mostrarCheckBox = false;
            this.dtpAprobacion.mostrarUpDown = false;
            this.dtpAprobacion.Name = "dtpAprobacion";
            this.dtpAprobacion.Size = new System.Drawing.Size(96, 22);
            this.dtpAprobacion.TabIndex = 46;
            this.dtpAprobacion.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(363, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Fecha:";
            // 
            // txtSesionAprob
            // 
            this.txtSesionAprob.FormatearNumero = false;
            this.txtSesionAprob.Location = new System.Drawing.Point(245, 142);
            this.txtSesionAprob.Longitud = 30;
            this.txtSesionAprob.Multilinea = false;
            this.txtSesionAprob.Name = "txtSesionAprob";
            this.txtSesionAprob.Password = '\0';
            this.txtSesionAprob.ReadOnly = false;
            this.txtSesionAprob.Size = new System.Drawing.Size(112, 21);
            this.txtSesionAprob.TabIndex = 44;
            this.txtSesionAprob.Valor = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Número Sesión Aprobación:";
            // 
            // txtCampoInvestigacion
            // 
            this.txtCampoInvestigacion.FormatearNumero = false;
            this.txtCampoInvestigacion.Location = new System.Drawing.Point(245, 115);
            this.txtCampoInvestigacion.Longitud = 30;
            this.txtCampoInvestigacion.Multilinea = false;
            this.txtCampoInvestigacion.Name = "txtCampoInvestigacion";
            this.txtCampoInvestigacion.Password = '\0';
            this.txtCampoInvestigacion.ReadOnly = false;
            this.txtCampoInvestigacion.Size = new System.Drawing.Size(112, 21);
            this.txtCampoInvestigacion.TabIndex = 42;
            this.txtCampoInvestigacion.Valor = "";
            this.txtCampoInvestigacion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNumColegiado_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(92, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Campo de Investigación:";
            // 
            // txtCampoInvestigacionNombre
            // 
            this.txtCampoInvestigacionNombre.FormatearNumero = false;
            this.txtCampoInvestigacionNombre.Location = new System.Drawing.Point(359, 116);
            this.txtCampoInvestigacionNombre.Longitud = 30;
            this.txtCampoInvestigacionNombre.Multilinea = false;
            this.txtCampoInvestigacionNombre.Name = "txtCampoInvestigacionNombre";
            this.txtCampoInvestigacionNombre.Password = '\0';
            this.txtCampoInvestigacionNombre.ReadOnly = true;
            this.txtCampoInvestigacionNombre.Size = new System.Drawing.Size(300, 21);
            this.txtCampoInvestigacionNombre.TabIndex = 40;
            this.txtCampoInvestigacionNombre.Valor = "";
            // 
            // txtNumColegiado
            // 
            this.txtNumColegiado.FormatearNumero = false;
            this.txtNumColegiado.Location = new System.Drawing.Point(245, 61);
            this.txtNumColegiado.Longitud = 30;
            this.txtNumColegiado.Multilinea = false;
            this.txtNumColegiado.Name = "txtNumColegiado";
            this.txtNumColegiado.Password = '\0';
            this.txtNumColegiado.ReadOnly = false;
            this.txtNumColegiado.Size = new System.Drawing.Size(112, 21);
            this.txtNumColegiado.TabIndex = 34;
            this.txtNumColegiado.Valor = "";
            this.txtNumColegiado.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(154, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Nº Colegiado:";
            // 
            // txtNombreColegiado
            // 
            this.txtNombreColegiado.FormatearNumero = false;
            this.txtNombreColegiado.Location = new System.Drawing.Point(359, 88);
            this.txtNombreColegiado.Longitud = 30;
            this.txtNombreColegiado.Multilinea = false;
            this.txtNombreColegiado.Name = "txtNombreColegiado";
            this.txtNombreColegiado.Password = '\0';
            this.txtNombreColegiado.ReadOnly = true;
            this.txtNombreColegiado.Size = new System.Drawing.Size(300, 21);
            this.txtNombreColegiado.TabIndex = 32;
            this.txtNombreColegiado.Valor = "";
            // 
            // tpCamposInvest
            // 
            this.tpCamposInvest.Controls.Add(this.panel10);
            this.tpCamposInvest.Controls.Add(this.groupBox1);
            this.tpCamposInvest.Location = new System.Drawing.Point(4, 22);
            this.tpCamposInvest.Name = "tpCamposInvest";
            this.tpCamposInvest.Size = new System.Drawing.Size(792, 333);
            this.tpCamposInvest.TabIndex = 3;
            this.tpCamposInvest.Text = "Campos Investigación";
            this.tpCamposInvest.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DarkGray;
            this.panel10.Controls.Add(this.label35);
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(786, 22);
            this.panel10.TabIndex = 314;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label35.Location = new System.Drawing.Point(3, 4);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(231, 14);
            this.label35.TabIndex = 0;
            this.label35.Text = "Información de Campos de Investigación";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.toolStrip8);
            this.groupBox1.Controls.Add(this.dgvCampoInvestigacion);
            this.groupBox1.Location = new System.Drawing.Point(41, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 351);
            this.groupBox1.TabIndex = 312;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Campo Investigación";
            // 
            // toolStrip8
            // 
            this.toolStrip8.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarCampo,
            this.btnEliminarCampo});
            this.toolStrip8.Location = new System.Drawing.Point(3, 15);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(58, 25);
            this.toolStrip8.TabIndex = 306;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // btnAgregarCampo
            // 
            this.btnAgregarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCampo.Image")));
            this.btnAgregarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarCampo.Name = "btnAgregarCampo";
            this.btnAgregarCampo.Size = new System.Drawing.Size(23, 22);
            this.btnAgregarCampo.Text = "Agregar Campo Investigación";
            this.btnAgregarCampo.Click += new System.EventHandler(this.btnAgregarCampo_Click);
            // 
            // btnEliminarCampo
            // 
            this.btnEliminarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCampo.Image")));
            this.btnEliminarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarCampo.Name = "btnEliminarCampo";
            this.btnEliminarCampo.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarCampo.Text = "Eliminar";
            // 
            // dgvCampoInvestigacion
            // 
            this.dgvCampoInvestigacion.AllowUserToAddRows = false;
            this.dgvCampoInvestigacion.AllowUserToDeleteRows = false;
            this.dgvCampoInvestigacion.AllowUserToResizeRows = false;
            this.dgvCampoInvestigacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCampoInvestigacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCampoInvestigacion.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCampoInvestigacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampoInvestigacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCampo,
            this.colDescripcion});
            this.dgvCampoInvestigacion.Location = new System.Drawing.Point(3, 43);
            this.dgvCampoInvestigacion.MultiSelect = false;
            this.dgvCampoInvestigacion.Name = "dgvCampoInvestigacion";
            this.dgvCampoInvestigacion.RowHeadersVisible = false;
            this.dgvCampoInvestigacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCampoInvestigacion.Size = new System.Drawing.Size(465, 304);
            this.dgvCampoInvestigacion.TabIndex = 310;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            // 
            // colCampo
            // 
            this.colCampo.HeaderText = "Nombre";
            this.colCampo.Name = "colCampo";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            // 
            // frmInvestigacionPlaguicidasEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmInvestigacionPlaguicidasEdicion";
            this.Text = "frmInvestigacionPlaguicidasEdicion";
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
            this.tpCamposInvest.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampoInvestigacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.UserControls.txtNormal txtNColegiado;
        private Framework.UserControls.chkSaseg chkPagaCanon;
        private System.Windows.Forms.Label label17;
        private Framework.UserControls.rtbSaseg rtbObservaciones;
        private Framework.UserControls.dtpSaseg dtpPerdida;
        private System.Windows.Forms.Label label15;
        private Framework.UserControls.txtNormal txtSesionPerdida;
        private System.Windows.Forms.Label label16;
        private Framework.UserControls.dtpSaseg dtpRenovacion;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.txtNormal txtSesionRenov;
        private System.Windows.Forms.Label label14;
        private Framework.UserControls.dtpSaseg dtpAprobacion;
        private System.Windows.Forms.Label label12;
        private Framework.UserControls.txtNormal txtSesionAprob;
        private System.Windows.Forms.Label label11;
        private Framework.UserControls.txtNormal txtCampoInvestigacion;
        private System.Windows.Forms.Label label10;
        private Framework.UserControls.txtNormal txtCampoInvestigacionNombre;
        private Framework.UserControls.txtNormal txtNumColegiado;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtNombreColegiado;
        private System.Windows.Forms.TabPage tpCamposInvest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnAgregarCampo;
        private System.Windows.Forms.ToolStripButton btnEliminarCampo;
        private System.Windows.Forms.DataGridView dgvCampoInvestigacion;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
    }
}