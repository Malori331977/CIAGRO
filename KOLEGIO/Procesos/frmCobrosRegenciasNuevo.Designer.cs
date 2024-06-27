namespace KOLEGIO.Procesos
{
    partial class frmCobrosRegenciasNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrosRegenciasNuevo));
            this.dgvRegentes = new System.Windows.Forms.DataGridView();
            this.colIdRegente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreRegente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodiCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCobradorRegente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewImageColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescCategoria = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.bwProceso = new System.ComponentModel.BackgroundWorker();
            this.chkGenTotal = new Framework.UserControls.chkSaseg();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblRegistrosCant = new System.Windows.Forms.Label();
            this.lblExitososCant = new System.Windows.Forms.Label();
            this.lblExitosos = new System.Windows.Forms.Label();
            this.lblErroresCant = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.chkMasivo = new Framework.UserControls.chkSaseg();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegentes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRegentes
            // 
            this.dgvRegentes.AllowUserToAddRows = false;
            this.dgvRegentes.AllowUserToResizeRows = false;
            this.dgvRegentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegentes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRegentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdRegente,
            this.colIdColegiado,
            this.colNombreRegente,
            this.colNumEstablecimiento,
            this.colNombreEstablecimiento,
            this.colCodiCategoria,
            this.colCategoria,
            this.colUltimoCobro,
            this.colCobradorRegente,
            this.colResultado,
            this.colObservaciones});
            this.dgvRegentes.Location = new System.Drawing.Point(12, 80);
            this.dgvRegentes.Name = "dgvRegentes";
            this.dgvRegentes.RowHeadersVisible = false;
            this.dgvRegentes.Size = new System.Drawing.Size(1020, 410);
            this.dgvRegentes.TabIndex = 279;
            this.dgvRegentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegentes_CellClick);
            // 
            // colIdRegente
            // 
            this.colIdRegente.DataPropertyName = "IdRegente";
            this.colIdRegente.HeaderText = "Nº Colegiado";
            this.colIdRegente.Name = "colIdRegente";
            this.colIdRegente.ReadOnly = true;
            // 
            // colIdColegiado
            // 
            this.colIdColegiado.HeaderText = "idColegiado";
            this.colIdColegiado.Name = "colIdColegiado";
            this.colIdColegiado.Visible = false;
            // 
            // colNombreRegente
            // 
            this.colNombreRegente.DataPropertyName = "NombreRegente";
            this.colNombreRegente.HeaderText = "Nombre";
            this.colNombreRegente.MinimumWidth = 6;
            this.colNombreRegente.Name = "colNombreRegente";
            // 
            // colNumEstablecimiento
            // 
            this.colNumEstablecimiento.HeaderText = "Num Establecimiento";
            this.colNumEstablecimiento.Name = "colNumEstablecimiento";
            // 
            // colNombreEstablecimiento
            // 
            this.colNombreEstablecimiento.HeaderText = "Establecimiento";
            this.colNombreEstablecimiento.Name = "colNombreEstablecimiento";
            // 
            // colCodiCategoria
            // 
            this.colCodiCategoria.HeaderText = "Codigo Categoria";
            this.colCodiCategoria.Name = "colCodiCategoria";
            this.colCodiCategoria.Visible = false;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "colCategoria";
            // 
            // colUltimoCobro
            // 
            this.colUltimoCobro.HeaderText = "ÚltimoCobro";
            this.colUltimoCobro.Name = "colUltimoCobro";
            // 
            // colCobradorRegente
            // 
            this.colCobradorRegente.HeaderText = "Cobrador Regente";
            this.colCobradorRegente.Name = "colCobradorRegente";
            this.colCobradorRegente.Visible = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 283;
            this.label1.Text = "Este proceso genera un pedido al ERP de cobro de regencias.";
            // 
            // txtDescCategoria
            // 
            this.txtDescCategoria.Location = new System.Drawing.Point(172, 39);
            this.txtDescCategoria.Name = "txtDescCategoria";
            this.txtDescCategoria.ReadOnly = true;
            this.txtDescCategoria.Size = new System.Drawing.Size(212, 20);
            this.txtDescCategoria.TabIndex = 282;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(73, 39);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(93, 20);
            this.txtCategoria.TabIndex = 281;
            this.txtCategoria.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCategoria_MouseDoubleClick);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 42);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 280;
            this.label27.Text = "Categoria:";
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
            this.btnExcel,
            this.btnResize,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1044, 25);
            this.toolStrip1.TabIndex = 278;
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
            this.btnSalir.DoubleClick += new System.EventHandler(this.btnSalir_Click);
            // 
            // pbProceso
            // 
            this.pbProceso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProceso.Location = new System.Drawing.Point(12, 491);
            this.pbProceso.Name = "pbProceso";
            this.pbProceso.Size = new System.Drawing.Size(1020, 23);
            this.pbProceso.TabIndex = 284;
            // 
            // bwProceso
            // 
            this.bwProceso.WorkerReportsProgress = true;
            this.bwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProceso_DoWork);
            this.bwProceso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProceso_ProgressChanged);
            this.bwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProceso_RunWorkerCompleted);
            // 
            // chkGenTotal
            // 
            this.chkGenTotal.Checked = false;
            this.chkGenTotal.Location = new System.Drawing.Point(397, 42);
            this.chkGenTotal.Name = "chkGenTotal";
            this.chkGenTotal.Size = new System.Drawing.Size(122, 17);
            this.chkGenTotal.TabIndex = 285;
            this.chkGenTotal.Texto = "Generación Total";
            this.chkGenTotal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkGenTotal_MouseClick);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(922, 517);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(57, 13);
            this.lblRegistros.TabIndex = 286;
            this.lblRegistros.Text = "Registros: ";
            // 
            // lblRegistrosCant
            // 
            this.lblRegistrosCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosCant.AutoSize = true;
            this.lblRegistrosCant.Location = new System.Drawing.Point(975, 517);
            this.lblRegistrosCant.Name = "lblRegistrosCant";
            this.lblRegistrosCant.Size = new System.Drawing.Size(13, 13);
            this.lblRegistrosCant.TabIndex = 287;
            this.lblRegistrosCant.Text = "0";
            // 
            // lblExitososCant
            // 
            this.lblExitososCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExitososCant.AutoSize = true;
            this.lblExitososCant.Location = new System.Drawing.Point(848, 517);
            this.lblExitososCant.Name = "lblExitososCant";
            this.lblExitososCant.Size = new System.Drawing.Size(13, 13);
            this.lblExitososCant.TabIndex = 289;
            this.lblExitososCant.Text = "0";
            this.lblExitososCant.Visible = false;
            // 
            // lblExitosos
            // 
            this.lblExitosos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExitosos.AutoSize = true;
            this.lblExitosos.Location = new System.Drawing.Point(753, 517);
            this.lblExitosos.Name = "lblExitosos";
            this.lblExitosos.Size = new System.Drawing.Size(99, 13);
            this.lblExitosos.TabIndex = 288;
            this.lblExitosos.Text = "Registros Exitosos: ";
            this.lblExitosos.Visible = false;
            // 
            // lblErroresCant
            // 
            this.lblErroresCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErroresCant.AutoSize = true;
            this.lblErroresCant.Location = new System.Drawing.Point(681, 517);
            this.lblErroresCant.Name = "lblErroresCant";
            this.lblErroresCant.Size = new System.Drawing.Size(13, 13);
            this.lblErroresCant.TabIndex = 291;
            this.lblErroresCant.Text = "0";
            this.lblErroresCant.Visible = false;
            // 
            // lblErrores
            // 
            this.lblErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrores.AutoSize = true;
            this.lblErrores.Location = new System.Drawing.Point(583, 517);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(102, 13);
            this.lblErrores.TabIndex = 290;
            this.lblErrores.Text = "Registros Erróneos: ";
            this.lblErrores.Visible = false;
            // 
            // chkMasivo
            // 
            this.chkMasivo.Checked = false;
            this.chkMasivo.Location = new System.Drawing.Point(635, 42);
            this.chkMasivo.Name = "chkMasivo";
            this.chkMasivo.Size = new System.Drawing.Size(60, 17);
            this.chkMasivo.TabIndex = 292;
            this.chkMasivo.Texto = "Masivo";
            this.chkMasivo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkMasivo_MouseClick);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(939, 39);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(93, 20);
            this.txtFiltro.TabIndex = 302;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(880, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 301;
            this.label5.Text = "Filtrar por:";
            // 
            // frmCobrosRegenciasNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 537);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkMasivo);
            this.Controls.Add(this.dgvRegentes);
            this.Controls.Add(this.lblErroresCant);
            this.Controls.Add(this.lblErrores);
            this.Controls.Add(this.lblExitososCant);
            this.Controls.Add(this.lblExitosos);
            this.Controls.Add(this.lblRegistrosCant);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.chkGenTotal);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCobrosRegenciasNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de Regencias";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegentes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.Windows.Forms.ImageList iList;
        private System.ComponentModel.BackgroundWorker bwProceso;
        private Framework.UserControls.chkSaseg chkGenTotal;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblRegistrosCant;
        private System.Windows.Forms.Label lblExitososCant;
        private System.Windows.Forms.Label lblExitosos;
        private System.Windows.Forms.Label lblErroresCant;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRegente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreRegente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodiCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobradorRegente;
        private System.Windows.Forms.DataGridViewImageColumn colResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private Framework.UserControls.chkSaseg chkMasivo;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label5;
    }
}