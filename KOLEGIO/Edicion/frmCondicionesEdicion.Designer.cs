namespace KOLEGIO
{
    partial class frmCondicionesEdicion
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondicionesEdicion));
			this.panel = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.txtCodigo = new Framework.UserControls.txtNormal();
			this.rtbDescripcion = new Framework.UserControls.rtbSaseg();
			this.txtNombre = new Framework.UserControls.txtNormal();
			this.tpPlantilla = new System.Windows.Forms.TabPage();
			this.dgvArticulos = new System.Windows.Forms.DataGridView();
			this.colArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtPlantillaN = new Framework.UserControls.txtNormal();
			this.txtPlantilla = new Framework.UserControls.txtNormal();
			this.label59 = new System.Windows.Forms.Label();
			this.panel16 = new System.Windows.Forms.Panel();
			this.label65 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbNoGenera = new Framework.UserControls.rbSaseg();
			this.rbAnual = new Framework.UserControls.rbSaseg();
			this.rbMensual = new Framework.UserControls.rbSaseg();
			this.tpConfigurables = new System.Windows.Forms.TabPage();
			this.chkGenerarCobroProcesos = new Framework.UserControls.chkSaseg();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDescCondicionLev = new Framework.UserControls.txtNormal();
			this.txtCondicionLev = new Framework.UserControls.txtNormal();
			this.dgvArticulosLevantamiento = new System.Windows.Forms.DataGridView();
			this.colFmsLev = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colArticuloLev = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcionLev = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPrecioLev = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip8 = new System.Windows.Forms.ToolStrip();
			this.btnAgregarArticulo = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarArticulo = new System.Windows.Forms.ToolStripButton();
			this.chkIncorporacion = new Framework.UserControls.chkSaseg();
			this.chkRequiereLevantamiento = new Framework.UserControls.chkSaseg();
			this.chkPedConcepto = new Framework.UserControls.chkSaseg();
			this.txtDescCondicion = new Framework.UserControls.txtNormal();
			this.txtCondicion = new Framework.UserControls.txtNormal();
			this.label27 = new System.Windows.Forms.Label();
			this.chkRequiereRegresoCondicion = new Framework.UserControls.chkSaseg();
			this.chkFallecido = new Framework.UserControls.chkSaseg();
			this.txtDescCondicionEdad = new Framework.UserControls.txtNormal();
			this.txtCondicionEdad = new Framework.UserControls.txtNormal();
			this.chkRequiereCambioCondicionEdad = new Framework.UserControls.chkSaseg();
			this.txtEdad = new Framework.UserControls.txtNormal();
			this.lblEdad = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			this.tpPlantilla.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
			this.panel16.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tpConfigurables.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulosLevantamiento)).BeginInit();
			this.toolStrip8.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpPlantilla);
			this.tabControl.Controls.Add(this.tpConfigurables);
			this.tabControl.Size = new System.Drawing.Size(653, 360);
			this.tabControl.Controls.SetChildIndex(this.tpConfigurables, 0);
			this.tabControl.Controls.SetChildIndex(this.tpPlantilla, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
			this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.groupBox1);
			this.tpBasicos.Controls.Add(this.rtbDescripcion);
			this.tpBasicos.Controls.Add(this.txtNombre);
			this.tpBasicos.Controls.Add(this.txtCodigo);
			this.tpBasicos.Controls.Add(this.label14);
			this.tpBasicos.Controls.Add(this.label10);
			this.tpBasicos.Controls.Add(this.label8);
			this.tpBasicos.Controls.Add(this.panel);
			this.tpBasicos.Size = new System.Drawing.Size(645, 334);
			this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.rtbDescripcion, 0);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			this.tpBasicos.Controls.SetChildIndex(this.groupBox1, 0);
			// 
			// tpAdmin
			// 
			this.tpAdmin.Size = new System.Drawing.Size(645, 334);
			// 
			// panelAdmin
			// 
			this.panelAdmin.Size = new System.Drawing.Size(639, 21);
			// 
			// panelBasicos
			// 
			this.panelBasicos.Size = new System.Drawing.Size(639, 21);
			// 
			// tpAdjuntos
			// 
			this.tpAdjuntos.Size = new System.Drawing.Size(645, 334);
			// 
			// panelAdjuntos
			// 
			this.panelAdjuntos.Size = new System.Drawing.Size(639, 21);
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.panel.Location = new System.Drawing.Point(3, 3);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(665, 21);
			this.panel.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label6.Location = new System.Drawing.Point(3, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(184, 14);
			this.label6.TabIndex = 0;
			this.label6.Text = "Datos del Criterio de Evaluación";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(98, 60);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Código:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(94, 89);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 13);
			this.label10.TabIndex = 5;
			this.label10.Text = "Nombre:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(82, 115);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(66, 13);
			this.label14.TabIndex = 9;
			this.label14.Text = "Descripción:";
			// 
			// txtCodigo
			// 
			this.txtCodigo.FormatearNumero = false;
			this.txtCodigo.Location = new System.Drawing.Point(154, 57);
			this.txtCodigo.Longitud = 4;
			this.txtCodigo.Multilinea = false;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Password = '\0';
			this.txtCodigo.ReadOnly = false;
			this.txtCodigo.Size = new System.Drawing.Size(124, 21);
			this.txtCodigo.TabIndex = 1;
			this.txtCodigo.Valor = "";
			// 
			// rtbDescripcion
			// 
			this.rtbDescripcion.Location = new System.Drawing.Point(154, 112);
			this.rtbDescripcion.Longitud = 500;
			this.rtbDescripcion.Mayusculas = false;
			this.rtbDescripcion.Name = "rtbDescripcion";
			this.rtbDescripcion.ReadOnly = false;
			this.rtbDescripcion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.18362}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbDescripcion.Size = new System.Drawing.Size(343, 76);
			this.rtbDescripcion.TabIndex = 3;
			// 
			// txtNombre
			// 
			this.txtNombre.FormatearNumero = false;
			this.txtNombre.Location = new System.Drawing.Point(154, 85);
			this.txtNombre.Longitud = 50;
			this.txtNombre.Multilinea = false;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Password = '\0';
			this.txtNombre.ReadOnly = false;
			this.txtNombre.Size = new System.Drawing.Size(343, 21);
			this.txtNombre.TabIndex = 2;
			this.txtNombre.Valor = "";
			// 
			// tpPlantilla
			// 
			this.tpPlantilla.Controls.Add(this.dgvArticulos);
			this.tpPlantilla.Controls.Add(this.txtPlantillaN);
			this.tpPlantilla.Controls.Add(this.txtPlantilla);
			this.tpPlantilla.Controls.Add(this.label59);
			this.tpPlantilla.Controls.Add(this.panel16);
			this.tpPlantilla.Location = new System.Drawing.Point(4, 22);
			this.tpPlantilla.Name = "tpPlantilla";
			this.tpPlantilla.Size = new System.Drawing.Size(645, 334);
			this.tpPlantilla.TabIndex = 3;
			this.tpPlantilla.Text = "Plantilla";
			this.tpPlantilla.UseVisualStyleBackColor = true;
			// 
			// dgvArticulos
			// 
			this.dgvArticulos.AllowUserToAddRows = false;
			this.dgvArticulos.AllowUserToDeleteRows = false;
			this.dgvArticulos.AllowUserToResizeRows = false;
			this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvArticulos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArticulo,
            this.colDescripcion,
            this.colPrecio});
			this.dgvArticulos.Location = new System.Drawing.Point(12, 93);
			this.dgvArticulos.MultiSelect = false;
			this.dgvArticulos.Name = "dgvArticulos";
			this.dgvArticulos.ReadOnly = true;
			this.dgvArticulos.RowHeadersVisible = false;
			this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvArticulos.Size = new System.Drawing.Size(594, 182);
			this.dgvArticulos.TabIndex = 314;
			// 
			// colArticulo
			// 
			this.colArticulo.HeaderText = "Código";
			this.colArticulo.Name = "colArticulo";
			this.colArticulo.ReadOnly = true;
			// 
			// colDescripcion
			// 
			this.colDescripcion.FillWeight = 137.0558F;
			this.colDescripcion.HeaderText = "Descripción";
			this.colDescripcion.Name = "colDescripcion";
			this.colDescripcion.ReadOnly = true;
			// 
			// colPrecio
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N2";
			this.colPrecio.DefaultCellStyle = dataGridViewCellStyle5;
			this.colPrecio.HeaderText = "Precio";
			this.colPrecio.Name = "colPrecio";
			this.colPrecio.ReadOnly = true;
			// 
			// txtPlantillaN
			// 
			this.txtPlantillaN.FormatearNumero = false;
			this.txtPlantillaN.Location = new System.Drawing.Point(259, 55);
			this.txtPlantillaN.Longitud = 32767;
			this.txtPlantillaN.Multilinea = false;
			this.txtPlantillaN.Name = "txtPlantillaN";
			this.txtPlantillaN.Password = '\0';
			this.txtPlantillaN.ReadOnly = true;
			this.txtPlantillaN.Size = new System.Drawing.Size(253, 21);
			this.txtPlantillaN.TabIndex = 313;
			this.txtPlantillaN.Valor = "";
			// 
			// txtPlantilla
			// 
			this.txtPlantilla.FormatearNumero = false;
			this.txtPlantilla.Location = new System.Drawing.Point(165, 55);
			this.txtPlantilla.Longitud = 30;
			this.txtPlantilla.Multilinea = false;
			this.txtPlantilla.Name = "txtPlantilla";
			this.txtPlantilla.Password = '\0';
			this.txtPlantilla.ReadOnly = false;
			this.txtPlantilla.Size = new System.Drawing.Size(95, 21);
			this.txtPlantilla.TabIndex = 312;
			this.txtPlantilla.Valor = "";
			this.txtPlantilla.Enter += new System.EventHandler(this.txtPlantilla_Enter);
			this.txtPlantilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlantilla_KeyDown);
			this.txtPlantilla.Leave += new System.EventHandler(this.txtPlantilla_Leave);
			this.txtPlantilla.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPlantilla_MouseDoubleClick);
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label59.Location = new System.Drawing.Point(113, 59);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(46, 13);
			this.label59.TabIndex = 311;
			this.label59.Text = "Plantilla:";
			// 
			// panel16
			// 
			this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel16.BackColor = System.Drawing.Color.DarkGray;
			this.panel16.Controls.Add(this.label65);
			this.panel16.Location = new System.Drawing.Point(3, 3);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(1463, 21);
			this.panel16.TabIndex = 39;
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label65.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label65.Location = new System.Drawing.Point(3, 4);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(125, 14);
			this.label65.TabIndex = 0;
			this.label65.Text = "Información Plantilla";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbNoGenera);
			this.groupBox1.Controls.Add(this.rbAnual);
			this.groupBox1.Controls.Add(this.rbMensual);
			this.groupBox1.Location = new System.Drawing.Point(154, 194);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(343, 60);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Genera Cobro";
			// 
			// rbNoGenera
			// 
			this.rbNoGenera.Checked = false;
			this.rbNoGenera.Location = new System.Drawing.Point(230, 25);
			this.rbNoGenera.Name = "rbNoGenera";
			this.rbNoGenera.Size = new System.Drawing.Size(79, 18);
			this.rbNoGenera.TabIndex = 2;
			this.rbNoGenera.Texto = "No Genera";
			// 
			// rbAnual
			// 
			this.rbAnual.Checked = false;
			this.rbAnual.Location = new System.Drawing.Point(146, 25);
			this.rbAnual.Name = "rbAnual";
			this.rbAnual.Size = new System.Drawing.Size(69, 18);
			this.rbAnual.TabIndex = 1;
			this.rbAnual.Texto = "Anual";
			// 
			// rbMensual
			// 
			this.rbMensual.Checked = false;
			this.rbMensual.Location = new System.Drawing.Point(55, 25);
			this.rbMensual.Name = "rbMensual";
			this.rbMensual.Size = new System.Drawing.Size(69, 18);
			this.rbMensual.TabIndex = 0;
			this.rbMensual.Texto = "Mensual";
			// 
			// tpConfigurables
			// 
			this.tpConfigurables.Controls.Add(this.lblEdad);
			this.tpConfigurables.Controls.Add(this.txtEdad);
			this.tpConfigurables.Controls.Add(this.txtDescCondicionEdad);
			this.tpConfigurables.Controls.Add(this.txtCondicionEdad);
			this.tpConfigurables.Controls.Add(this.chkRequiereCambioCondicionEdad);
			this.tpConfigurables.Controls.Add(this.chkGenerarCobroProcesos);
			this.tpConfigurables.Controls.Add(this.panel2);
			this.tpConfigurables.Controls.Add(this.panel3);
			this.tpConfigurables.Controls.Add(this.chkIncorporacion);
			this.tpConfigurables.Controls.Add(this.chkRequiereLevantamiento);
			this.tpConfigurables.Controls.Add(this.chkPedConcepto);
			this.tpConfigurables.Controls.Add(this.txtDescCondicion);
			this.tpConfigurables.Controls.Add(this.txtCondicion);
			this.tpConfigurables.Controls.Add(this.label27);
			this.tpConfigurables.Controls.Add(this.chkRequiereRegresoCondicion);
			this.tpConfigurables.Controls.Add(this.chkFallecido);
			this.tpConfigurables.Location = new System.Drawing.Point(4, 22);
			this.tpConfigurables.Name = "tpConfigurables";
			this.tpConfigurables.Size = new System.Drawing.Size(645, 334);
			this.tpConfigurables.TabIndex = 4;
			this.tpConfigurables.Text = "Configurables";
			this.tpConfigurables.UseVisualStyleBackColor = true;
			// 
			// chkGenerarCobroProcesos
			// 
			this.chkGenerarCobroProcesos.Checked = false;
			this.chkGenerarCobroProcesos.Location = new System.Drawing.Point(315, 271);
			this.chkGenerarCobroProcesos.Name = "chkGenerarCobroProcesos";
			this.chkGenerarCobroProcesos.Size = new System.Drawing.Size(114, 17);
			this.chkGenerarCobroProcesos.TabIndex = 286;
			this.chkGenerarCobroProcesos.Texto = "Genera Cobro";
			this.chkGenerarCobroProcesos.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.DarkGray;
			this.panel2.Controls.Add(this.label7);
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(697, 21);
			this.panel2.TabIndex = 285;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label7.Location = new System.Drawing.Point(3, 4);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(156, 14);
			this.label7.TabIndex = 0;
			this.label7.Text = "Información Configurables";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.txtDescCondicionLev);
			this.panel3.Controls.Add(this.txtCondicionLev);
			this.panel3.Controls.Add(this.dgvArticulosLevantamiento);
			this.panel3.Controls.Add(this.toolStrip8);
			this.panel3.Location = new System.Drawing.Point(262, 68);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(380, 161);
			this.panel3.TabIndex = 284;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(110, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(57, 13);
			this.label9.TabIndex = 285;
			this.label9.Text = "Condición:";
			this.label9.Visible = false;
			// 
			// txtDescCondicionLev
			// 
			this.txtDescCondicionLev.FormatearNumero = false;
			this.txtDescCondicionLev.Location = new System.Drawing.Point(235, 4);
			this.txtDescCondicionLev.Longitud = 32767;
			this.txtDescCondicionLev.Multilinea = false;
			this.txtDescCondicionLev.Name = "txtDescCondicionLev";
			this.txtDescCondicionLev.Password = '\0';
			this.txtDescCondicionLev.ReadOnly = true;
			this.txtDescCondicionLev.Size = new System.Drawing.Size(140, 21);
			this.txtDescCondicionLev.TabIndex = 286;
			this.txtDescCondicionLev.Valor = "";
			// 
			// txtCondicionLev
			// 
			this.txtCondicionLev.FormatearNumero = false;
			this.txtCondicionLev.Location = new System.Drawing.Point(173, 4);
			this.txtCondicionLev.Longitud = 4;
			this.txtCondicionLev.Multilinea = false;
			this.txtCondicionLev.Name = "txtCondicionLev";
			this.txtCondicionLev.Password = '\0';
			this.txtCondicionLev.ReadOnly = true;
			this.txtCondicionLev.Size = new System.Drawing.Size(59, 21);
			this.txtCondicionLev.TabIndex = 285;
			this.txtCondicionLev.Valor = "";
			this.txtCondicionLev.Enter += new System.EventHandler(this.txtCondicionLev_Enter);
			this.txtCondicionLev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicionLev_KeyDown);
			this.txtCondicionLev.Leave += new System.EventHandler(this.txtCondicionLev_Leave);
			this.txtCondicionLev.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicionLev_MouseDoubleClick);
			// 
			// dgvArticulosLevantamiento
			// 
			this.dgvArticulosLevantamiento.AllowUserToAddRows = false;
			this.dgvArticulosLevantamiento.AllowUserToDeleteRows = false;
			this.dgvArticulosLevantamiento.AllowUserToResizeRows = false;
			this.dgvArticulosLevantamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvArticulosLevantamiento.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvArticulosLevantamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvArticulosLevantamiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFmsLev,
            this.colArticuloLev,
            this.colDescripcionLev,
            this.colPrecioLev});
			this.dgvArticulosLevantamiento.Location = new System.Drawing.Point(3, 28);
			this.dgvArticulosLevantamiento.MultiSelect = false;
			this.dgvArticulosLevantamiento.Name = "dgvArticulosLevantamiento";
			this.dgvArticulosLevantamiento.RowHeadersVisible = false;
			this.dgvArticulosLevantamiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvArticulosLevantamiento.Size = new System.Drawing.Size(374, 133);
			this.dgvArticulosLevantamiento.TabIndex = 312;
			this.dgvArticulosLevantamiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulosLevantamiento_CellClick);
			// 
			// colFmsLev
			// 
			this.colFmsLev.HeaderText = "FMS";
			this.colFmsLev.Name = "colFmsLev";
			this.colFmsLev.ReadOnly = true;
			this.colFmsLev.Width = 40;
			// 
			// colArticuloLev
			// 
			this.colArticuloLev.HeaderText = "Código";
			this.colArticuloLev.Name = "colArticuloLev";
			this.colArticuloLev.ReadOnly = true;
			this.colArticuloLev.Width = 55;
			// 
			// colDescripcionLev
			// 
			this.colDescripcionLev.HeaderText = "Descripción";
			this.colDescripcionLev.Name = "colDescripcionLev";
			this.colDescripcionLev.ReadOnly = true;
			this.colDescripcionLev.Width = 235;
			// 
			// colPrecioLev
			// 
			this.colPrecioLev.HeaderText = "Precio";
			this.colPrecioLev.Name = "colPrecioLev";
			this.colPrecioLev.Width = 80;
			// 
			// toolStrip8
			// 
			this.toolStrip8.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarArticulo,
            this.btnEliminarArticulo});
			this.toolStrip8.Location = new System.Drawing.Point(3, 0);
			this.toolStrip8.Name = "toolStrip8";
			this.toolStrip8.Size = new System.Drawing.Size(58, 25);
			this.toolStrip8.TabIndex = 311;
			this.toolStrip8.Text = "toolStrip8";
			// 
			// btnAgregarArticulo
			// 
			this.btnAgregarArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAgregarArticulo.Enabled = false;
			this.btnAgregarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarArticulo.Image")));
			this.btnAgregarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregarArticulo.Name = "btnAgregarArticulo";
			this.btnAgregarArticulo.Size = new System.Drawing.Size(23, 22);
			this.btnAgregarArticulo.Text = "Agregar";
			this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
			// 
			// btnEliminarArticulo
			// 
			this.btnEliminarArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarArticulo.Enabled = false;
			this.btnEliminarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarArticulo.Image")));
			this.btnEliminarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarArticulo.Name = "btnEliminarArticulo";
			this.btnEliminarArticulo.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarArticulo.Text = "Quitar";
			this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
			// 
			// chkIncorporacion
			// 
			this.chkIncorporacion.Checked = false;
			this.chkIncorporacion.Location = new System.Drawing.Point(27, 140);
			this.chkIncorporacion.Name = "chkIncorporacion";
			this.chkIncorporacion.Size = new System.Drawing.Size(148, 17);
			this.chkIncorporacion.TabIndex = 283;
			this.chkIncorporacion.Texto = "Condición Incorporación";
			// 
			// chkRequiereLevantamiento
			// 
			this.chkRequiereLevantamiento.Checked = false;
			this.chkRequiereLevantamiento.Location = new System.Drawing.Point(262, 45);
			this.chkRequiereLevantamiento.Name = "chkRequiereLevantamiento";
			this.chkRequiereLevantamiento.Size = new System.Drawing.Size(219, 17);
			this.chkRequiereLevantamiento.TabIndex = 282;
			this.chkRequiereLevantamiento.Texto = "Requiere Levantamiento de Condición";
			this.chkRequiereLevantamiento.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkRequiereLevantamiento_MouseClick);
			// 
			// chkPedConcepto
			// 
			this.chkPedConcepto.Checked = false;
			this.chkPedConcepto.Location = new System.Drawing.Point(27, 46);
			this.chkPedConcepto.Name = "chkPedConcepto";
			this.chkPedConcepto.Size = new System.Drawing.Size(168, 17);
			this.chkPedConcepto.TabIndex = 281;
			this.chkPedConcepto.Texto = "Permite Pedido por Concepto";
			// 
			// txtDescCondicion
			// 
			this.txtDescCondicion.FormatearNumero = false;
			this.txtDescCondicion.Location = new System.Drawing.Point(89, 208);
			this.txtDescCondicion.Longitud = 32767;
			this.txtDescCondicion.Multilinea = false;
			this.txtDescCondicion.Name = "txtDescCondicion";
			this.txtDescCondicion.Password = '\0';
			this.txtDescCondicion.ReadOnly = true;
			this.txtDescCondicion.Size = new System.Drawing.Size(140, 21);
			this.txtDescCondicion.TabIndex = 280;
			this.txtDescCondicion.Valor = "";
			// 
			// txtCondicion
			// 
			this.txtCondicion.FormatearNumero = false;
			this.txtCondicion.Location = new System.Drawing.Point(27, 208);
			this.txtCondicion.Longitud = 4;
			this.txtCondicion.Multilinea = false;
			this.txtCondicion.Name = "txtCondicion";
			this.txtCondicion.Password = '\0';
			this.txtCondicion.ReadOnly = true;
			this.txtCondicion.Size = new System.Drawing.Size(59, 21);
			this.txtCondicion.TabIndex = 278;
			this.txtCondicion.Valor = "";
			this.txtCondicion.Enter += new System.EventHandler(this.txtCondicion_Enter);
			this.txtCondicion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicion_KeyDown);
			this.txtCondicion.Leave += new System.EventHandler(this.txtCondicion_Leave);
			this.txtCondicion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicion_MouseDoubleClick);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(190, 169);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(57, 13);
			this.label27.TabIndex = 279;
			this.label27.Text = "Condición:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label27.Visible = false;
			// 
			// chkRequiereRegresoCondicion
			// 
			this.chkRequiereRegresoCondicion.Checked = false;
			this.chkRequiereRegresoCondicion.Location = new System.Drawing.Point(27, 185);
			this.chkRequiereRegresoCondicion.Name = "chkRequiereRegresoCondicion";
			this.chkRequiereRegresoCondicion.Size = new System.Drawing.Size(135, 17);
			this.chkRequiereRegresoCondicion.TabIndex = 277;
			this.chkRequiereRegresoCondicion.Texto = "Regreso de Condición";
			this.chkRequiereRegresoCondicion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkRequiereRegresoCondicion_MouseClick);
			// 
			// chkFallecido
			// 
			this.chkFallecido.Checked = false;
			this.chkFallecido.Location = new System.Drawing.Point(27, 93);
			this.chkFallecido.Name = "chkFallecido";
			this.chkFallecido.Size = new System.Drawing.Size(135, 17);
			this.chkFallecido.TabIndex = 276;
			this.chkFallecido.Texto = "Condición Fallecido";
			// 
			// txtDescCondicionEdad
			// 
			this.txtDescCondicionEdad.FormatearNumero = false;
			this.txtDescCondicionEdad.Location = new System.Drawing.Point(89, 271);
			this.txtDescCondicionEdad.Longitud = 32767;
			this.txtDescCondicionEdad.Multilinea = false;
			this.txtDescCondicionEdad.Name = "txtDescCondicionEdad";
			this.txtDescCondicionEdad.Password = '\0';
			this.txtDescCondicionEdad.ReadOnly = true;
			this.txtDescCondicionEdad.Size = new System.Drawing.Size(140, 21);
			this.txtDescCondicionEdad.TabIndex = 289;
			this.txtDescCondicionEdad.Valor = "";
			// 
			// txtCondicionEdad
			// 
			this.txtCondicionEdad.FormatearNumero = false;
			this.txtCondicionEdad.Location = new System.Drawing.Point(27, 271);
			this.txtCondicionEdad.Longitud = 4;
			this.txtCondicionEdad.Multilinea = false;
			this.txtCondicionEdad.Name = "txtCondicionEdad";
			this.txtCondicionEdad.Password = '\0';
			this.txtCondicionEdad.ReadOnly = true;
			this.txtCondicionEdad.Size = new System.Drawing.Size(59, 21);
			this.txtCondicionEdad.TabIndex = 288;
			this.txtCondicionEdad.Valor = "";
			this.txtCondicionEdad.Enter += new System.EventHandler(this.txtCondicionEdad_Enter);
			this.txtCondicionEdad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicionEdad_KeyDown);
			this.txtCondicionEdad.Leave += new System.EventHandler(this.txtCondicionEdad_Leave);
			this.txtCondicionEdad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicionEdad_MouseDoubleClick);
			// 
			// chkRequiereCambioCondicionEdad
			// 
			this.chkRequiereCambioCondicionEdad.Checked = false;
			this.chkRequiereCambioCondicionEdad.Location = new System.Drawing.Point(27, 248);
			this.chkRequiereCambioCondicionEdad.Name = "chkRequiereCambioCondicionEdad";
			this.chkRequiereCambioCondicionEdad.Size = new System.Drawing.Size(182, 17);
			this.chkRequiereCambioCondicionEdad.TabIndex = 287;
			this.chkRequiereCambioCondicionEdad.Texto = "Cambio de Condición por Edad";
			this.chkRequiereCambioCondicionEdad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkRequiereCambioCondicionEdad_MouseClick);
			// 
			// txtEdad
			// 
			this.txtEdad.FormatearNumero = false;
			this.txtEdad.Location = new System.Drawing.Point(65, 298);
			this.txtEdad.Longitud = 4;
			this.txtEdad.Multilinea = false;
			this.txtEdad.Name = "txtEdad";
			this.txtEdad.Password = '\0';
			this.txtEdad.ReadOnly = true;
			this.txtEdad.Size = new System.Drawing.Size(59, 21);
			this.txtEdad.TabIndex = 290;
			this.txtEdad.Valor = "";
			this.txtEdad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEdad_KeyPress);
			// 
			// lblEdad
			// 
			this.lblEdad.AutoSize = true;
			this.lblEdad.Location = new System.Drawing.Point(24, 303);
			this.lblEdad.Name = "lblEdad";
			this.lblEdad.Size = new System.Drawing.Size(35, 13);
			this.lblEdad.TabIndex = 291;
			this.lblEdad.Text = "Edad:";
			this.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmCondicionesEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 452);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCondicionesEdicion";
			this.Text = "frmEstadosTramiteEdicion";
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
			this.tpPlantilla.ResumeLayout(false);
			this.tpPlantilla.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
			this.panel16.ResumeLayout(false);
			this.panel16.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tpConfigurables.ResumeLayout(false);
			this.tpConfigurables.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulosLevantamiento)).EndInit();
			this.toolStrip8.ResumeLayout(false);
			this.toolStrip8.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtCodigo;
        private Framework.UserControls.rtbSaseg rtbDescripcion;
        private Framework.UserControls.txtNormal txtNombre;
        private System.Windows.Forms.TabPage tpPlantilla;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private Framework.UserControls.txtNormal txtPlantillaN;
        private Framework.UserControls.txtNormal txtPlantilla;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.UserControls.rbSaseg rbNoGenera;
        private Framework.UserControls.rbSaseg rbAnual;
        private Framework.UserControls.rbSaseg rbMensual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.TabPage tpConfigurables;
        private Framework.UserControls.txtNormal txtDescCondicion;
        private Framework.UserControls.txtNormal txtCondicion;
        private System.Windows.Forms.Label label27;
        private Framework.UserControls.chkSaseg chkRequiereRegresoCondicion;
        private Framework.UserControls.chkSaseg chkFallecido;
        private Framework.UserControls.chkSaseg chkPedConcepto;
        private Framework.UserControls.chkSaseg chkIncorporacion;
        private Framework.UserControls.chkSaseg chkRequiereLevantamiento;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvArticulosLevantamiento;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnAgregarArticulo;
        private System.Windows.Forms.ToolStripButton btnEliminarArticulo;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtDescCondicionLev;
        private Framework.UserControls.txtNormal txtCondicionLev;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFmsLev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticuloLev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionLev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioLev;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.chkSaseg chkGenerarCobroProcesos;
		private Framework.UserControls.txtNormal txtEdad;
		private Framework.UserControls.txtNormal txtDescCondicionEdad;
		private Framework.UserControls.txtNormal txtCondicionEdad;
		private Framework.UserControls.chkSaseg chkRequiereCambioCondicionEdad;
		private System.Windows.Forms.Label lblEdad;
	}
}