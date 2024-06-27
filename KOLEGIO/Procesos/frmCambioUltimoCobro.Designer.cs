namespace KOLEGIO
{
    partial class frmCambioUltimoCobro
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioUltimoCobro));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
			this.btnProcesar = new System.Windows.Forms.ToolStripButton();
			this.btnExcel = new System.Windows.Forms.ToolStripButton();
			this.btnResize = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.dgvCanones = new System.Windows.Forms.DataGridView();
			this.bwProceso = new System.ComponentModel.BackgroundWorker();
			this.iList = new System.Windows.Forms.ImageList(this.components);
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbProcesos = new Framework.UserControls.cmbSaseg();
			this.btnGenerar = new System.Windows.Forms.Button();
			this.txtColegiado = new System.Windows.Forms.TextBox();
			this.txtNumeroColegiado = new Framework.UserControls.txtNormal();
			this.txtNombreColegiado = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.colIdColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colUltimoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.toolStrip1.Size = new System.Drawing.Size(862, 25);
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
            this.colIdColegiado,
            this.colNumeroColegiado,
            this.colColegiado,
            this.colNumRegistro,
            this.colEstable,
            this.colCodCategoria,
            this.colCategoria,
            this.colUltimoCobro});
			this.dgvCanones.Location = new System.Drawing.Point(12, 86);
			this.dgvCanones.Name = "dgvCanones";
			this.dgvCanones.RowHeadersVisible = false;
			this.dgvCanones.Size = new System.Drawing.Size(835, 215);
			this.dgvCanones.TabIndex = 3;
			this.dgvCanones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCanones_CellClick);
			this.dgvCanones.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCanones_CurrentCellDirtyStateChanged);
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
			// dataGridViewImageColumn1
			// 
			this.dataGridViewImageColumn1.HeaderText = "Detalle Carga";
			this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.Width = 80;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(35, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 298;
			this.label2.Text = "Tipo:";
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
			this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
			this.btnGenerar.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
			this.btnGenerar.Location = new System.Drawing.Point(816, 38);
			this.btnGenerar.Name = "btnGenerar";
			this.btnGenerar.Size = new System.Drawing.Size(31, 24);
			this.btnGenerar.TabIndex = 300;
			this.btnGenerar.UseVisualStyleBackColor = false;
			this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
			// 
			// txtColegiado
			// 
			this.txtColegiado.Location = new System.Drawing.Point(336, 12);
			this.txtColegiado.Name = "txtColegiado";
			this.txtColegiado.Size = new System.Drawing.Size(88, 20);
			this.txtColegiado.TabIndex = 311;
			this.txtColegiado.Visible = false;
			// 
			// txtNumeroColegiado
			// 
			this.txtNumeroColegiado.FormatearNumero = false;
			this.txtNumeroColegiado.Location = new System.Drawing.Point(336, 40);
			this.txtNumeroColegiado.Longitud = 32767;
			this.txtNumeroColegiado.Multilinea = false;
			this.txtNumeroColegiado.Name = "txtNumeroColegiado";
			this.txtNumeroColegiado.Password = '\0';
			this.txtNumeroColegiado.ReadOnly = false;
			this.txtNumeroColegiado.Size = new System.Drawing.Size(88, 21);
			this.txtNumeroColegiado.TabIndex = 310;
			this.txtNumeroColegiado.Valor = "";
			this.txtNumeroColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColegiado_KeyDown);
			this.txtNumeroColegiado.Leave += new System.EventHandler(this.txtColegiado_Leave);
			this.txtNumeroColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtColegiado_MouseDoubleClick);
			// 
			// txtNombreColegiado
			// 
			this.txtNombreColegiado.Location = new System.Drawing.Point(430, 41);
			this.txtNombreColegiado.Name = "txtNombreColegiado";
			this.txtNombreColegiado.ReadOnly = true;
			this.txtNombreColegiado.Size = new System.Drawing.Size(314, 20);
			this.txtNombreColegiado.TabIndex = 309;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(279, 44);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(49, 13);
			this.label27.TabIndex = 308;
			this.label27.Text = "Registro:";
			// 
			// colIdColegiado
			// 
			this.colIdColegiado.DataPropertyName = "IdColegiado";
			this.colIdColegiado.HeaderText = "IdColegiado";
			this.colIdColegiado.Name = "colIdColegiado";
			this.colIdColegiado.ReadOnly = true;
			this.colIdColegiado.Visible = false;
			// 
			// colNumeroColegiado
			// 
			this.colNumeroColegiado.DataPropertyName = "NumeroColegiado";
			this.colNumeroColegiado.HeaderText = "Código";
			this.colNumeroColegiado.MinimumWidth = 6;
			this.colNumeroColegiado.Name = "colNumeroColegiado";
			this.colNumeroColegiado.ReadOnly = true;
			// 
			// colColegiado
			// 
			this.colColegiado.HeaderText = "Nombre";
			this.colColegiado.Name = "colColegiado";
			this.colColegiado.ReadOnly = true;
			// 
			// colNumRegistro
			// 
			this.colNumRegistro.HeaderText = "N° Registro";
			this.colNumRegistro.Name = "colNumRegistro";
			this.colNumRegistro.ReadOnly = true;
			this.colNumRegistro.Visible = false;
			// 
			// colEstable
			// 
			this.colEstable.HeaderText = "Establecimiento";
			this.colEstable.Name = "colEstable";
			this.colEstable.ReadOnly = true;
			this.colEstable.Visible = false;
			// 
			// colCodCategoria
			// 
			this.colCodCategoria.HeaderText = "CodCategoria";
			this.colCodCategoria.Name = "colCodCategoria";
			this.colCodCategoria.Visible = false;
			// 
			// colCategoria
			// 
			this.colCategoria.DataPropertyName = "Nombre";
			this.colCategoria.HeaderText = "Categoria";
			this.colCategoria.Name = "colCategoria";
			this.colCategoria.ReadOnly = true;
			this.colCategoria.Visible = false;
			// 
			// colUltimoCobro
			// 
			this.colUltimoCobro.HeaderText = "Último Cobro";
			this.colUltimoCobro.Name = "colUltimoCobro";
			// 
			// frmCambioUltimoCobro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(862, 313);
			this.Controls.Add(this.txtColegiado);
			this.Controls.Add(this.txtNumeroColegiado);
			this.Controls.Add(this.txtNombreColegiado);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.btnGenerar);
			this.Controls.Add(this.cmbProcesos);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgvCanones);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCambioUltimoCobro";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cambio de Ultimo Cobro";
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
        private System.ComponentModel.BackgroundWorker bwProceso;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label2;
        private Framework.UserControls.cmbSaseg cmbProcesos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtColegiado;
        private Framework.UserControls.txtNormal txtNumeroColegiado;
        private System.Windows.Forms.TextBox txtNombreColegiado;
        private System.Windows.Forms.Label label27;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colColegiado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNumRegistro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colEstable;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodCategoria;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
		private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoCobro;
	}
}