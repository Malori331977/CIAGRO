namespace KOLEGIO
{
    partial class frmGenerarCobroMasivoCobrador
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarCobroMasivoCobrador));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabResumen = new System.Windows.Forms.TabPage();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lblCantTotal = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.chkEmparejarDatos = new Framework.UserControls.chkSaseg();
			this.chkConectividad = new Framework.UserControls.chkSaseg();
			this.lblErroresCant = new System.Windows.Forms.Label();
			this.lblErrores = new System.Windows.Forms.Label();
			this.lblExitososCant = new System.Windows.Forms.Label();
			this.lblExitosos = new System.Windows.Forms.Label();
			this.lblRegistrosCant = new System.Windows.Forms.Label();
			this.lblRegistros = new System.Windows.Forms.Label();
			this.pbProceso = new System.Windows.Forms.ProgressBar();
			this.chkMasivo = new Framework.UserControls.chkSaseg();
			this.dgvColegiados = new System.Windows.Forms.DataGridView();
			this.colSelecDetalle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colCedulaCobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMontoAdeudado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMontoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSumaSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colResultado = new System.Windows.Forms.DataGridViewImageColumn();
			this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtDescCobrador = new System.Windows.Forms.TextBox();
			this.txtCobrador = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.tabDetalle = new System.Windows.Forms.TabPage();
			this.lblCantTotalesSaldosDet = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCantRegistrosDet = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dgvDetalle = new System.Windows.Forms.DataGridView();
			this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAplicacionDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCedDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSaldoDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabResumenCarga = new System.Windows.Forms.TabPage();
			this.txtSubTipoDocNombre = new Framework.UserControls.txtNormal();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSubTipoDoc = new Framework.UserControls.txtNormal();
			this.dtpFechaDoc = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNumDocumentoCarga = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblCantTotalesSaldosCarga = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblCantRegistrosCarga = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvCarga = new System.Windows.Forms.DataGridView();
			this.iList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
			this.btnProcesar = new System.Windows.Forms.ToolStripButton();
			this.btnCargarArchivo = new System.Windows.Forms.ToolStripButton();
			this.btnExcel = new System.Windows.Forms.ToolStripButton();
			this.btnResize = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.bwProceso = new System.ComponentModel.BackgroundWorker();
			this.tabControl1.SuspendLayout();
			this.tabResumen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
			this.tabDetalle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
			this.tabResumenCarga.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarga)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabResumen);
			this.tabControl1.Controls.Add(this.tabDetalle);
			this.tabControl1.Controls.Add(this.tabResumenCarga);
			this.tabControl1.Location = new System.Drawing.Point(3, 28);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1022, 585);
			this.tabControl1.TabIndex = 0;
			// 
			// tabResumen
			// 
			this.tabResumen.Controls.Add(this.txtDesc);
			this.tabResumen.Controls.Add(this.txtCodigo);
			this.tabResumen.Controls.Add(this.label7);
			this.tabResumen.Controls.Add(this.lblCantTotal);
			this.tabResumen.Controls.Add(this.lblTotal);
			this.tabResumen.Controls.Add(this.chkEmparejarDatos);
			this.tabResumen.Controls.Add(this.chkConectividad);
			this.tabResumen.Controls.Add(this.lblErroresCant);
			this.tabResumen.Controls.Add(this.lblErrores);
			this.tabResumen.Controls.Add(this.lblExitososCant);
			this.tabResumen.Controls.Add(this.lblExitosos);
			this.tabResumen.Controls.Add(this.lblRegistrosCant);
			this.tabResumen.Controls.Add(this.lblRegistros);
			this.tabResumen.Controls.Add(this.pbProceso);
			this.tabResumen.Controls.Add(this.chkMasivo);
			this.tabResumen.Controls.Add(this.dgvColegiados);
			this.tabResumen.Controls.Add(this.txtDescCobrador);
			this.tabResumen.Controls.Add(this.txtCobrador);
			this.tabResumen.Controls.Add(this.label27);
			this.tabResumen.Location = new System.Drawing.Point(4, 22);
			this.tabResumen.Name = "tabResumen";
			this.tabResumen.Padding = new System.Windows.Forms.Padding(3);
			this.tabResumen.Size = new System.Drawing.Size(1014, 559);
			this.tabResumen.TabIndex = 0;
			this.tabResumen.Text = "Resumen";
			this.tabResumen.UseVisualStyleBackColor = true;
			// 
			// txtDesc
			// 
			this.txtDesc.Location = new System.Drawing.Point(156, 29);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ReadOnly = true;
			this.txtDesc.Size = new System.Drawing.Size(183, 20);
			this.txtDesc.TabIndex = 310;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(61, 29);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(89, 20);
			this.txtCodigo.TabIndex = 309;
			this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
			this.txtCodigo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCodigo_MouseDoubleClick);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 308;
			this.label7.Text = "Plantilla:";
			// 
			// lblCantTotal
			// 
			this.lblCantTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCantTotal.AutoSize = true;
			this.lblCantTotal.Location = new System.Drawing.Point(467, 537);
			this.lblCantTotal.Name = "lblCantTotal";
			this.lblCantTotal.Size = new System.Drawing.Size(28, 13);
			this.lblCantTotal.TabIndex = 307;
			this.lblCantTotal.Text = "0.00";
			// 
			// lblTotal
			// 
			this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point(378, 537);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(87, 13);
			this.lblTotal.TabIndex = 306;
			this.lblTotal.Text = "Total de Saldos: ";
			// 
			// chkEmparejarDatos
			// 
			this.chkEmparejarDatos.Checked = false;
			this.chkEmparejarDatos.Location = new System.Drawing.Point(535, 31);
			this.chkEmparejarDatos.Name = "chkEmparejarDatos";
			this.chkEmparejarDatos.Size = new System.Drawing.Size(183, 17);
			this.chkEmparejarDatos.TabIndex = 305;
			this.chkEmparejarDatos.Texto = "Mostrar Solo Registros en Carga";
			this.chkEmparejarDatos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkEmparejarDatos_MouseClick);
			// 
			// chkConectividad
			// 
			this.chkConectividad.Checked = false;
			this.chkConectividad.Location = new System.Drawing.Point(366, 31);
			this.chkConectividad.Name = "chkConectividad";
			this.chkConectividad.Size = new System.Drawing.Size(135, 17);
			this.chkConectividad.TabIndex = 304;
			this.chkConectividad.Texto = "Cobro Conectividad";
			this.chkConectividad.Visible = false;
			this.chkConectividad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkConectividad_MouseClick);
			// 
			// lblErroresCant
			// 
			this.lblErroresCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblErroresCant.AutoSize = true;
			this.lblErroresCant.Location = new System.Drawing.Point(651, 537);
			this.lblErroresCant.Name = "lblErroresCant";
			this.lblErroresCant.Size = new System.Drawing.Size(13, 13);
			this.lblErroresCant.TabIndex = 303;
			this.lblErroresCant.Text = "0";
			this.lblErroresCant.Visible = false;
			// 
			// lblErrores
			// 
			this.lblErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblErrores.AutoSize = true;
			this.lblErrores.Location = new System.Drawing.Point(546, 537);
			this.lblErrores.Name = "lblErrores";
			this.lblErrores.Size = new System.Drawing.Size(102, 13);
			this.lblErrores.TabIndex = 302;
			this.lblErrores.Text = "Registros Erróneos: ";
			this.lblErrores.Visible = false;
			// 
			// lblExitososCant
			// 
			this.lblExitososCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblExitososCant.AutoSize = true;
			this.lblExitososCant.Location = new System.Drawing.Point(818, 537);
			this.lblExitososCant.Name = "lblExitososCant";
			this.lblExitososCant.Size = new System.Drawing.Size(13, 13);
			this.lblExitososCant.TabIndex = 301;
			this.lblExitososCant.Text = "0";
			this.lblExitososCant.Visible = false;
			// 
			// lblExitosos
			// 
			this.lblExitosos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblExitosos.AutoSize = true;
			this.lblExitosos.Location = new System.Drawing.Point(716, 537);
			this.lblExitosos.Name = "lblExitosos";
			this.lblExitosos.Size = new System.Drawing.Size(99, 13);
			this.lblExitosos.TabIndex = 300;
			this.lblExitosos.Text = "Registros Exitosos: ";
			this.lblExitosos.Visible = false;
			// 
			// lblRegistrosCant
			// 
			this.lblRegistrosCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRegistrosCant.AutoSize = true;
			this.lblRegistrosCant.Location = new System.Drawing.Point(944, 537);
			this.lblRegistrosCant.Name = "lblRegistrosCant";
			this.lblRegistrosCant.Size = new System.Drawing.Size(13, 13);
			this.lblRegistrosCant.TabIndex = 299;
			this.lblRegistrosCant.Text = "0";
			// 
			// lblRegistros
			// 
			this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRegistros.AutoSize = true;
			this.lblRegistros.Location = new System.Drawing.Point(885, 537);
			this.lblRegistros.Name = "lblRegistros";
			this.lblRegistros.Size = new System.Drawing.Size(57, 13);
			this.lblRegistros.TabIndex = 298;
			this.lblRegistros.Text = "Registros: ";
			// 
			// pbProceso
			// 
			this.pbProceso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbProceso.Location = new System.Drawing.Point(5, 511);
			this.pbProceso.Name = "pbProceso";
			this.pbProceso.Size = new System.Drawing.Size(1001, 23);
			this.pbProceso.TabIndex = 296;
			// 
			// chkMasivo
			// 
			this.chkMasivo.Checked = false;
			this.chkMasivo.Location = new System.Drawing.Point(738, 31);
			this.chkMasivo.Name = "chkMasivo";
			this.chkMasivo.Size = new System.Drawing.Size(135, 17);
			this.chkMasivo.TabIndex = 295;
			this.chkMasivo.Texto = "Ver Detalle de Todos";
			this.chkMasivo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkMasivo_MouseClick);
			// 
			// dgvColegiados
			// 
			this.dgvColegiados.AllowUserToAddRows = false;
			this.dgvColegiados.AllowUserToResizeRows = false;
			this.dgvColegiados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvColegiados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvColegiados.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvColegiados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvColegiados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecDetalle,
            this.colCedulaCobrador,
            this.colNumeroColegiado,
            this.colNombreColegiado,
            this.colDoc,
            this.colCobrador,
            this.colMontoAdeudado,
            this.colMontoPagado,
            this.colSumaSaldo,
            this.colResultado,
            this.colObservaciones});
			this.dgvColegiados.Location = new System.Drawing.Point(6, 76);
			this.dgvColegiados.Name = "dgvColegiados";
			this.dgvColegiados.RowHeadersVisible = false;
			this.dgvColegiados.Size = new System.Drawing.Size(1000, 429);
			this.dgvColegiados.TabIndex = 286;
			this.dgvColegiados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColegiados_CellClick);
			// 
			// colSelecDetalle
			// 
			this.colSelecDetalle.HeaderText = "Ver Detalle";
			this.colSelecDetalle.Name = "colSelecDetalle";
			this.colSelecDetalle.ReadOnly = true;
			// 
			// colCedulaCobrador
			// 
			this.colCedulaCobrador.HeaderText = "Cédula";
			this.colCedulaCobrador.Name = "colCedulaCobrador";
			this.colCedulaCobrador.ReadOnly = true;
			// 
			// colNumeroColegiado
			// 
			this.colNumeroColegiado.HeaderText = "Nº Colegiado";
			this.colNumeroColegiado.MinimumWidth = 6;
			this.colNumeroColegiado.Name = "colNumeroColegiado";
			// 
			// colNombreColegiado
			// 
			this.colNombreColegiado.HeaderText = "Nombre";
			this.colNombreColegiado.Name = "colNombreColegiado";
			// 
			// colDoc
			// 
			this.colDoc.HeaderText = "Documento";
			this.colDoc.Name = "colDoc";
			this.colDoc.Visible = false;
			// 
			// colCobrador
			// 
			this.colCobrador.HeaderText = "Cobrador";
			this.colCobrador.Name = "colCobrador";
			this.colCobrador.Visible = false;
			// 
			// colMontoAdeudado
			// 
			this.colMontoAdeudado.HeaderText = "Monto Adeudado";
			this.colMontoAdeudado.Name = "colMontoAdeudado";
			// 
			// colMontoPagado
			// 
			this.colMontoPagado.HeaderText = "Monto Pagado";
			this.colMontoPagado.Name = "colMontoPagado";
			this.colMontoPagado.Visible = false;
			// 
			// colSumaSaldo
			// 
			this.colSumaSaldo.HeaderText = "Suma de Saldos";
			this.colSumaSaldo.Name = "colSumaSaldo";
			// 
			// colResultado
			// 
			this.colResultado.HeaderText = "Detalle Carga";
			this.colResultado.Image = ((System.Drawing.Image)(resources.GetObject("colResultado.Image")));
			this.colResultado.Name = "colResultado";
			// 
			// colObservaciones
			// 
			this.colObservaciones.HeaderText = "Observaciones";
			this.colObservaciones.Name = "colObservaciones";
			this.colObservaciones.ReadOnly = true;
			// 
			// txtDescCobrador
			// 
			this.txtDescCobrador.Location = new System.Drawing.Point(821, 50);
			this.txtDescCobrador.Name = "txtDescCobrador";
			this.txtDescCobrador.ReadOnly = true;
			this.txtDescCobrador.Size = new System.Drawing.Size(183, 20);
			this.txtDescCobrador.TabIndex = 285;
			this.txtDescCobrador.Visible = false;
			// 
			// txtCobrador
			// 
			this.txtCobrador.Location = new System.Drawing.Point(751, 50);
			this.txtCobrador.Name = "txtCobrador";
			this.txtCobrador.Size = new System.Drawing.Size(64, 20);
			this.txtCobrador.TabIndex = 284;
			this.txtCobrador.Visible = false;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(696, 53);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(53, 13);
			this.label27.TabIndex = 283;
			this.label27.Text = "Cobrador:";
			this.label27.Visible = false;
			// 
			// tabDetalle
			// 
			this.tabDetalle.Controls.Add(this.lblCantTotalesSaldosDet);
			this.tabDetalle.Controls.Add(this.label3);
			this.tabDetalle.Controls.Add(this.lblCantRegistrosDet);
			this.tabDetalle.Controls.Add(this.label6);
			this.tabDetalle.Controls.Add(this.dgvDetalle);
			this.tabDetalle.Location = new System.Drawing.Point(4, 22);
			this.tabDetalle.Name = "tabDetalle";
			this.tabDetalle.Size = new System.Drawing.Size(1014, 559);
			this.tabDetalle.TabIndex = 1;
			this.tabDetalle.Text = "Detalle";
			this.tabDetalle.UseVisualStyleBackColor = true;
			// 
			// lblCantTotalesSaldosDet
			// 
			this.lblCantTotalesSaldosDet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCantTotalesSaldosDet.AutoSize = true;
			this.lblCantTotalesSaldosDet.Location = new System.Drawing.Point(775, 528);
			this.lblCantTotalesSaldosDet.Name = "lblCantTotalesSaldosDet";
			this.lblCantTotalesSaldosDet.Size = new System.Drawing.Size(28, 13);
			this.lblCantTotalesSaldosDet.TabIndex = 313;
			this.lblCantTotalesSaldosDet.Text = "0.00";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(685, 528);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 312;
			this.label3.Text = "Total de Saldos: ";
			// 
			// lblCantRegistrosDet
			// 
			this.lblCantRegistrosDet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCantRegistrosDet.AutoSize = true;
			this.lblCantRegistrosDet.Location = new System.Drawing.Point(928, 528);
			this.lblCantRegistrosDet.Name = "lblCantRegistrosDet";
			this.lblCantRegistrosDet.Size = new System.Drawing.Size(13, 13);
			this.lblCantRegistrosDet.TabIndex = 311;
			this.lblCantRegistrosDet.Text = "0";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(868, 528);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 13);
			this.label6.TabIndex = 310;
			this.label6.Text = "Registros: ";
			// 
			// dgvDetalle
			// 
			this.dgvDetalle.AllowUserToAddRows = false;
			this.dgvDetalle.AllowUserToResizeRows = false;
			this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocumento,
            this.colAplicacionDetalle,
            this.colCedDetalle,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.colSaldoDetalle,
            this.colFecha,
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn8});
			this.dgvDetalle.Location = new System.Drawing.Point(3, 55);
			this.dgvDetalle.Name = "dgvDetalle";
			this.dgvDetalle.RowHeadersVisible = false;
			this.dgvDetalle.Size = new System.Drawing.Size(1008, 450);
			this.dgvDetalle.TabIndex = 287;
			// 
			// colDocumento
			// 
			this.colDocumento.HeaderText = "Documento";
			this.colDocumento.Name = "colDocumento";
			// 
			// colAplicacionDetalle
			// 
			this.colAplicacionDetalle.HeaderText = "Aplicacion";
			this.colAplicacionDetalle.Name = "colAplicacionDetalle";
			// 
			// colCedDetalle
			// 
			this.colCedDetalle.HeaderText = "Cédula";
			this.colCedDetalle.Name = "colCedDetalle";
			this.colCedDetalle.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Nº Colegiado";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "Monto Adeudado";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			// 
			// colSaldoDetalle
			// 
			this.colSaldoDetalle.HeaderText = "Saldo";
			this.colSaldoDetalle.Name = "colSaldoDetalle";
			// 
			// colFecha
			// 
			this.colFecha.HeaderText = "Fecha";
			this.colFecha.Name = "colFecha";
			// 
			// dataGridViewImageColumn2
			// 
			this.dataGridViewImageColumn2.HeaderText = "Detalle Carga";
			this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
			this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn2.Visible = false;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.HeaderText = "Observaciones";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Visible = false;
			// 
			// tabResumenCarga
			// 
			this.tabResumenCarga.Controls.Add(this.txtSubTipoDocNombre);
			this.tabResumenCarga.Controls.Add(this.label9);
			this.tabResumenCarga.Controls.Add(this.txtSubTipoDoc);
			this.tabResumenCarga.Controls.Add(this.dtpFechaDoc);
			this.tabResumenCarga.Controls.Add(this.label5);
			this.tabResumenCarga.Controls.Add(this.txtNumDocumentoCarga);
			this.tabResumenCarga.Controls.Add(this.label1);
			this.tabResumenCarga.Controls.Add(this.lblCantTotalesSaldosCarga);
			this.tabResumenCarga.Controls.Add(this.label4);
			this.tabResumenCarga.Controls.Add(this.lblCantRegistrosCarga);
			this.tabResumenCarga.Controls.Add(this.label2);
			this.tabResumenCarga.Controls.Add(this.dgvCarga);
			this.tabResumenCarga.Location = new System.Drawing.Point(4, 22);
			this.tabResumenCarga.Name = "tabResumenCarga";
			this.tabResumenCarga.Size = new System.Drawing.Size(1014, 559);
			this.tabResumenCarga.TabIndex = 2;
			this.tabResumenCarga.Text = "Resumen Carga";
			this.tabResumenCarga.UseVisualStyleBackColor = true;
			// 
			// txtSubTipoDocNombre
			// 
			this.txtSubTipoDocNombre.FormatearNumero = false;
			this.txtSubTipoDocNombre.Location = new System.Drawing.Point(640, 18);
			this.txtSubTipoDocNombre.Longitud = 32767;
			this.txtSubTipoDocNombre.Multilinea = false;
			this.txtSubTipoDocNombre.Name = "txtSubTipoDocNombre";
			this.txtSubTipoDocNombre.Password = '\0';
			this.txtSubTipoDocNombre.ReadOnly = true;
			this.txtSubTipoDocNombre.Size = new System.Drawing.Size(207, 21);
			this.txtSubTipoDocNombre.TabIndex = 316;
			this.txtSubTipoDocNombre.Valor = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(482, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(73, 13);
			this.label9.TabIndex = 315;
			this.label9.Text = "SubTipo Doc:";
			// 
			// txtSubTipoDoc
			// 
			this.txtSubTipoDoc.FormatearNumero = false;
			this.txtSubTipoDoc.Location = new System.Drawing.Point(562, 18);
			this.txtSubTipoDoc.Longitud = 32767;
			this.txtSubTipoDoc.Multilinea = false;
			this.txtSubTipoDoc.Name = "txtSubTipoDoc";
			this.txtSubTipoDoc.Password = '\0';
			this.txtSubTipoDoc.ReadOnly = true;
			this.txtSubTipoDoc.Size = new System.Drawing.Size(76, 21);
			this.txtSubTipoDoc.TabIndex = 314;
			this.txtSubTipoDoc.Valor = "";
			// 
			// dtpFechaDoc
			// 
			this.dtpFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaDoc.Location = new System.Drawing.Point(367, 19);
			this.dtpFechaDoc.Name = "dtpFechaDoc";
			this.dtpFechaDoc.Size = new System.Drawing.Size(100, 20);
			this.dtpFechaDoc.TabIndex = 313;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(264, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 13);
			this.label5.TabIndex = 312;
			this.label5.Text = "Fecha Documento:";
			// 
			// txtNumDocumentoCarga
			// 
			this.txtNumDocumentoCarga.Location = new System.Drawing.Point(128, 19);
			this.txtNumDocumentoCarga.Name = "txtNumDocumentoCarga";
			this.txtNumDocumentoCarga.Size = new System.Drawing.Size(117, 20);
			this.txtNumDocumentoCarga.TabIndex = 311;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 310;
			this.label1.Text = "N° Documento:";
			// 
			// lblCantTotalesSaldosCarga
			// 
			this.lblCantTotalesSaldosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCantTotalesSaldosCarga.AutoSize = true;
			this.lblCantTotalesSaldosCarga.Location = new System.Drawing.Point(761, 532);
			this.lblCantTotalesSaldosCarga.Name = "lblCantTotalesSaldosCarga";
			this.lblCantTotalesSaldosCarga.Size = new System.Drawing.Size(28, 13);
			this.lblCantTotalesSaldosCarga.TabIndex = 309;
			this.lblCantTotalesSaldosCarga.Text = "0.00";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(671, 532);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(87, 13);
			this.label4.TabIndex = 308;
			this.label4.Text = "Total de Saldos: ";
			// 
			// lblCantRegistrosCarga
			// 
			this.lblCantRegistrosCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCantRegistrosCarga.AutoSize = true;
			this.lblCantRegistrosCarga.Location = new System.Drawing.Point(914, 532);
			this.lblCantRegistrosCarga.Name = "lblCantRegistrosCarga";
			this.lblCantRegistrosCarga.Size = new System.Drawing.Size(13, 13);
			this.lblCantRegistrosCarga.TabIndex = 301;
			this.lblCantRegistrosCarga.Text = "0";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(854, 532);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 300;
			this.label2.Text = "Registros: ";
			// 
			// dgvCarga
			// 
			this.dgvCarga.AllowUserToAddRows = false;
			this.dgvCarga.AllowUserToResizeRows = false;
			this.dgvCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCarga.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCarga.Location = new System.Drawing.Point(44, 57);
			this.dgvCarga.Name = "dgvCarga";
			this.dgvCarga.RowHeadersVisible = false;
			this.dgvCarga.Size = new System.Drawing.Size(919, 466);
			this.dgvCarga.TabIndex = 288;
			// 
			// iList
			// 
			this.iList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList.ImageStream")));
			this.iList.TransparentColor = System.Drawing.Color.Transparent;
			this.iList.Images.SetKeyName(0, "gris.png");
			this.iList.Images.SetKeyName(1, "rojo.png");
			this.iList.Images.SetKeyName(2, "verde.png");
			this.iList.Images.SetKeyName(3, "amarillo.png");
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefrescar,
            this.btnProcesar,
            this.btnCargarArchivo,
            this.btnExcel,
            this.btnResize,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1025, 25);
			this.toolStrip1.TabIndex = 279;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnRefrescar
			// 
			this.btnRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
			this.btnRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(23, 22);
			this.btnRefrescar.Text = "Refrescar";
			// 
			// btnProcesar
			// 
			this.btnProcesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
			this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(23, 22);
			this.btnProcesar.Text = "Procesar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// btnCargarArchivo
			// 
			this.btnCargarArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnCargarArchivo.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarArchivo.Image")));
			this.btnCargarArchivo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCargarArchivo.Name = "btnCargarArchivo";
			this.btnCargarArchivo.Size = new System.Drawing.Size(23, 22);
			this.btnCargarArchivo.Text = "Cargar";
			this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
			// 
			// btnExcel
			// 
			this.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
			this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(23, 22);
			this.btnExcel.Text = "Exportar a Excel";
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnResize
			// 
			this.btnResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnResize.Image = ((System.Drawing.Image)(resources.GetObject("btnResize.Image")));
			this.btnResize.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnResize.Name = "btnResize";
			this.btnResize.Size = new System.Drawing.Size(23, 22);
			this.btnResize.Text = "Ajustar Tamaño de Columnas";
			this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
			// 
			// btnSalir
			// 
			this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(23, 22);
			this.btnSalir.Text = "Salir";
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// bwProceso
			// 
			this.bwProceso.WorkerReportsProgress = true;
			this.bwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProceso_DoWork);
			this.bwProceso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProceso_ProgressChanged);
			this.bwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProceso_RunWorkerCompleted);
			// 
			// frmGenerarCobroMasivoCobrador
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1025, 614);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmGenerarCobroMasivoCobrador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cobros Masivos por Cobrador";
			this.tabControl1.ResumeLayout(false);
			this.tabResumen.ResumeLayout(false);
			this.tabResumen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
			this.tabDetalle.ResumeLayout(false);
			this.tabDetalle.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
			this.tabResumenCarga.ResumeLayout(false);
			this.tabResumenCarga.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarga)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabResumen;
        private System.Windows.Forms.TextBox txtDescCobrador;
        private System.Windows.Forms.TextBox txtCobrador;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.DataGridView dgvColegiados;
        private System.Windows.Forms.TabPage tabDetalle;
        protected System.Windows.Forms.ToolStripButton btnCargarArchivo;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private Framework.UserControls.chkSaseg chkMasivo;
        private System.ComponentModel.BackgroundWorker bwProceso;
        private System.Windows.Forms.TabPage tabResumenCarga;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.DataGridView dgvCarga;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.Windows.Forms.Label lblErroresCant;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Label lblExitososCant;
        private System.Windows.Forms.Label lblExitosos;
        private System.Windows.Forms.Label lblRegistrosCant;
        private System.Windows.Forms.Label lblRegistros;
        private Framework.UserControls.chkSaseg chkConectividad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedulaCobrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoAdeudado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSumaSaldo;
        private System.Windows.Forms.DataGridViewImageColumn colResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private Framework.UserControls.chkSaseg chkEmparejarDatos;
        private System.Windows.Forms.Label lblCantTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCantTotalesSaldosCarga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCantRegistrosCarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCantTotalesSaldosDet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCantRegistrosDet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAplicacionDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox txtNumDocumentoCarga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaDoc;
        private System.Windows.Forms.Label label5;
        private Framework.UserControls.txtNormal txtSubTipoDocNombre;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtSubTipoDoc;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Label label7;
	}
}