namespace KOLEGIO
{
    partial class frmCobrosCanonesAnuales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrosCanonesAnuales));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvCanones = new System.Windows.Forms.DataGridView();
            this.colIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedulaJuridica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewImageColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.bwProceso = new System.ComponentModel.BackgroundWorker();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.txtCultivo = new System.Windows.Forms.TextBox();
            this.txtDescCultivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.chkGenTotal = new Framework.UserControls.chkSaseg();
            this.lblErroresCant = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.lblExitososCant = new System.Windows.Forms.Label();
            this.lblExitosos = new System.Windows.Forms.Label();
            this.lblRegistrosCant = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProcesos = new Framework.UserControls.cmbSaseg();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanones)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefrescar,
            this.btnProcesar,
            this.btnExcel,
            this.btnResize,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(948, 25);
            this.toolStrip1.TabIndex = 2;
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
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
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
            // dgvCanones
            // 
            this.dgvCanones.AllowUserToAddRows = false;
            this.dgvCanones.AllowUserToResizeRows = false;
            this.dgvCanones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCanones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanones.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCanones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdentificador,
            this.colCedulaJuridica,
            this.colNumeroColegiado,
            this.colNombre,
            this.colEmail,
            this.colUltimoCobro,
            this.colCobrador,
            this.colResultado,
            this.colObservaciones});
            this.dgvCanones.Location = new System.Drawing.Point(12, 86);
            this.dgvCanones.Name = "dgvCanones";
            this.dgvCanones.RowHeadersVisible = false;
            this.dgvCanones.Size = new System.Drawing.Size(921, 390);
            this.dgvCanones.TabIndex = 3;
            // 
            // colIdentificador
            // 
            this.colIdentificador.DataPropertyName = "IdColegiado";
            this.colIdentificador.HeaderText = "Identificador";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.ReadOnly = true;
            // 
            // colCedulaJuridica
            // 
            this.colCedulaJuridica.HeaderText = "Cedula Juridica";
            this.colCedulaJuridica.Name = "colCedulaJuridica";
            this.colCedulaJuridica.Visible = false;
            // 
            // colNumeroColegiado
            // 
            this.colNumeroColegiado.DataPropertyName = "NumeroColegiado";
            this.colNumeroColegiado.HeaderText = "Nº Colegiado";
            this.colNumeroColegiado.MinimumWidth = 6;
            this.colNumeroColegiado.Name = "colNumeroColegiado";
            this.colNumeroColegiado.Visible = false;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // colUltimoCobro
            // 
            this.colUltimoCobro.HeaderText = "Último Cobro";
            this.colUltimoCobro.Name = "colUltimoCobro";
            // 
            // colCobrador
            // 
            this.colCobrador.HeaderText = "Cobrador";
            this.colCobrador.Name = "colCobrador";
            this.colCobrador.Visible = false;
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
            // pbProceso
            // 
            this.pbProceso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProceso.Location = new System.Drawing.Point(15, 481);
            this.pbProceso.Name = "pbProceso";
            this.pbProceso.Size = new System.Drawing.Size(921, 23);
            this.pbProceso.TabIndex = 9;
            // 
            // bwProceso
            // 
            this.bwProceso.WorkerReportsProgress = true;
            this.bwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProceso_DoWork);
            this.bwProceso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProceso_ProgressChanged);
            this.bwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProceso_RunWorkerCompleted);
            // 
            // iList
            // 
            this.iList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList.ImageStream")));
            this.iList.TransparentColor = System.Drawing.Color.Transparent;
            this.iList.Images.SetKeyName(0, "gris.png");
            this.iList.Images.SetKeyName(1, "rojo.png");
            this.iList.Images.SetKeyName(2, "verde.png");
            this.iList.Images.SetKeyName(3, "amarillo.png");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(486, 38);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 273;
            this.label27.Text = "Cultivo:";
            this.label27.Visible = false;
            // 
            // txtCultivo
            // 
            this.txtCultivo.Location = new System.Drawing.Point(534, 35);
            this.txtCultivo.Name = "txtCultivo";
            this.txtCultivo.Size = new System.Drawing.Size(63, 20);
            this.txtCultivo.TabIndex = 275;
            this.txtCultivo.Visible = false;
            // 
            // txtDescCultivo
            // 
            this.txtDescCultivo.Location = new System.Drawing.Point(603, 35);
            this.txtDescCultivo.Name = "txtDescCultivo";
            this.txtDescCultivo.ReadOnly = true;
            this.txtDescCultivo.Size = new System.Drawing.Size(260, 20);
            this.txtDescCultivo.TabIndex = 276;
            this.txtDescCultivo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 13);
            this.label1.TabIndex = 277;
            this.label1.Text = "Este proceso genera al ERP los pedidos del canon seleccionado.";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Detalle Carga";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 80;
            // 
            // chkGenTotal
            // 
            this.chkGenTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGenTotal.Checked = false;
            this.chkGenTotal.Location = new System.Drawing.Point(347, 42);
            this.chkGenTotal.Name = "chkGenTotal";
            this.chkGenTotal.Size = new System.Drawing.Size(122, 17);
            this.chkGenTotal.TabIndex = 278;
            this.chkGenTotal.Texto = "Generación Total";
            this.chkGenTotal.Visible = false;
            // 
            // lblErroresCant
            // 
            this.lblErroresCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErroresCant.AutoSize = true;
            this.lblErroresCant.Location = new System.Drawing.Point(584, 507);
            this.lblErroresCant.Name = "lblErroresCant";
            this.lblErroresCant.Size = new System.Drawing.Size(13, 13);
            this.lblErroresCant.TabIndex = 297;
            this.lblErroresCant.Text = "0";
            this.lblErroresCant.Visible = false;
            // 
            // lblErrores
            // 
            this.lblErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrores.AutoSize = true;
            this.lblErrores.Location = new System.Drawing.Point(476, 507);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(102, 13);
            this.lblErrores.TabIndex = 296;
            this.lblErrores.Text = "Registros Erróneos: ";
            this.lblErrores.Visible = false;
            // 
            // lblExitososCant
            // 
            this.lblExitososCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExitososCant.AutoSize = true;
            this.lblExitososCant.Location = new System.Drawing.Point(751, 507);
            this.lblExitososCant.Name = "lblExitososCant";
            this.lblExitososCant.Size = new System.Drawing.Size(13, 13);
            this.lblExitososCant.TabIndex = 295;
            this.lblExitososCant.Text = "0";
            this.lblExitososCant.Visible = false;
            // 
            // lblExitosos
            // 
            this.lblExitosos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExitosos.AutoSize = true;
            this.lblExitosos.Location = new System.Drawing.Point(646, 507);
            this.lblExitosos.Name = "lblExitosos";
            this.lblExitosos.Size = new System.Drawing.Size(99, 13);
            this.lblExitosos.TabIndex = 294;
            this.lblExitosos.Text = "Registros Exitosos: ";
            this.lblExitosos.Visible = false;
            // 
            // lblRegistrosCant
            // 
            this.lblRegistrosCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosCant.AutoSize = true;
            this.lblRegistrosCant.Location = new System.Drawing.Point(878, 507);
            this.lblRegistrosCant.Name = "lblRegistrosCant";
            this.lblRegistrosCant.Size = new System.Drawing.Size(13, 13);
            this.lblRegistrosCant.TabIndex = 293;
            this.lblRegistrosCant.Text = "0";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(815, 507);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(57, 13);
            this.lblRegistros.TabIndex = 292;
            this.lblRegistros.Text = "Registros: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 298;
            this.label2.Text = "Generar a:";
            // 
            // cmbProcesos
            // 
            this.cmbProcesos.Habilitar = true;
            this.cmbProcesos.Index = -1;
            this.cmbProcesos.Location = new System.Drawing.Point(90, 40);
            this.cmbProcesos.Name = "cmbProcesos";
            this.cmbProcesos.Size = new System.Drawing.Size(178, 27);
            this.cmbProcesos.TabIndex = 299;
            this.cmbProcesos.Texto = "";
            this.cmbProcesos.Valor = "";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.Location = new System.Drawing.Point(274, 37);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(32, 27);
            this.btnGenerar.TabIndex = 300;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // frmCobrosCanonesAnuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 529);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cmbProcesos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblErroresCant);
            this.Controls.Add(this.lblErrores);
            this.Controls.Add(this.lblExitososCant);
            this.Controls.Add(this.lblExitosos);
            this.Controls.Add(this.lblRegistrosCant);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.chkGenTotal);
            this.Controls.Add(this.dgvCanones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescCultivo);
            this.Controls.Add(this.txtCultivo);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCobrosCanonesAnuales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Cobros Canones Anuales";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.DataGridView dgvCanones;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.ComponentModel.BackgroundWorker bwProceso;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCultivo;
        private System.Windows.Forms.TextBox txtDescCultivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Framework.UserControls.chkSaseg chkGenTotal;
        private System.Windows.Forms.Label lblErroresCant;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Label lblExitososCant;
        private System.Windows.Forms.Label lblExitosos;
        private System.Windows.Forms.Label lblRegistrosCant;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label2;
        private Framework.UserControls.cmbSaseg cmbProcesos;
        private System.Windows.Forms.Button btnGenerar;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificador;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCedulaJuridica;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
		private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoCobro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCobrador;
		private System.Windows.Forms.DataGridViewImageColumn colResultado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
	}
}