namespace KOLEGIO
{
    partial class frmCobrosColegiados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobrosColegiados));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvColegiados = new System.Windows.Forms.DataGridView();
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.bwProceso = new System.ComponentModel.BackgroundWorker();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.txtDescCondicion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.chkGenTotal = new Framework.UserControls.chkSaseg();
            this.lblErroresCant = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.lblExitososCant = new System.Windows.Forms.Label();
            this.lblExitosos = new System.Windows.Forms.Label();
            this.lblRegistrosCant = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.colIdColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCobradorCole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewImageColumn();
            this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
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
            // dgvColegiados
            // 
            this.dgvColegiados.AllowUserToAddRows = false;
            this.dgvColegiados.AllowUserToResizeRows = false;
            this.dgvColegiados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColegiados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvColegiados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColegiados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdColegiado,
            this.colCedula,
            this.colNumeroColegiado,
            this.colNombreColegiado,
            this.colUltimoCobro,
            this.colCobradorCole,
            this.colResultado,
            this.colObservaciones});
            this.dgvColegiados.Location = new System.Drawing.Point(12, 67);
            this.dgvColegiados.Name = "dgvColegiados";
            this.dgvColegiados.RowHeadersVisible = false;
            this.dgvColegiados.Size = new System.Drawing.Size(921, 409);
            this.dgvColegiados.TabIndex = 3;
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
            this.label27.Location = new System.Drawing.Point(12, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 13);
            this.label27.TabIndex = 273;
            this.label27.Text = "Condición:";
            // 
            // txtCondicion
            // 
            this.txtCondicion.Location = new System.Drawing.Point(75, 28);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(63, 20);
            this.txtCondicion.TabIndex = 275;
            this.txtCondicion.TextChanged += new System.EventHandler(this.txtCondicion_TextChanged);
            this.txtCondicion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicion_KeyDown);
            this.txtCondicion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicion_MouseDoubleClick);
            // 
            // txtDescCondicion
            // 
            this.txtDescCondicion.Location = new System.Drawing.Point(144, 28);
            this.txtDescCondicion.Name = "txtDescCondicion";
            this.txtDescCondicion.ReadOnly = true;
            this.txtDescCondicion.Size = new System.Drawing.Size(260, 20);
            this.txtDescCondicion.TabIndex = 276;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 13);
            this.label1.TabIndex = 277;
            this.label1.Text = "Este proceso genera al ERP los pedidos a los colegiados con base en la condición " +
    "seleccionada.";
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
            this.chkGenTotal.Location = new System.Drawing.Point(603, 31);
            this.chkGenTotal.Name = "chkGenTotal";
            this.chkGenTotal.Size = new System.Drawing.Size(122, 17);
            this.chkGenTotal.TabIndex = 278;
            this.chkGenTotal.Texto = "Generación Total";
            this.chkGenTotal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkGenTotal_MouseClick);
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
            // colIdColegiado
            // 
            this.colIdColegiado.DataPropertyName = "IdColegiado";
            this.colIdColegiado.HeaderText = "Id Colegiado";
            this.colIdColegiado.Name = "colIdColegiado";
            this.colIdColegiado.ReadOnly = true;
            this.colIdColegiado.Width = 110;
            // 
            // colCedula
            // 
            this.colCedula.HeaderText = "Cedula";
            this.colCedula.Name = "colCedula";
            this.colCedula.Visible = false;
            // 
            // colNumeroColegiado
            // 
            this.colNumeroColegiado.DataPropertyName = "NumeroColegiado";
            this.colNumeroColegiado.HeaderText = "Nº Colegiado";
            this.colNumeroColegiado.MinimumWidth = 6;
            this.colNumeroColegiado.Name = "colNumeroColegiado";
            this.colNumeroColegiado.Width = 140;
            // 
            // colNombreColegiado
            // 
            this.colNombreColegiado.DataPropertyName = "Nombre";
            this.colNombreColegiado.HeaderText = "Nombre";
            this.colNombreColegiado.Name = "colNombreColegiado";
            this.colNombreColegiado.ReadOnly = true;
            this.colNombreColegiado.Width = 255;
            // 
            // colUltimoCobro
            // 
            this.colUltimoCobro.HeaderText = "Último Cobro";
            this.colUltimoCobro.Name = "colUltimoCobro";
            // 
            // colCobradorCole
            // 
            this.colCobradorCole.HeaderText = "Cobrador";
            this.colCobradorCole.Name = "colCobradorCole";
            this.colCobradorCole.Visible = false;
            // 
            // colResultado
            // 
            this.colResultado.HeaderText = "Detalle Carga";
            this.colResultado.Image = ((System.Drawing.Image)(resources.GetObject("colResultado.Image")));
            this.colResultado.Name = "colResultado";
            this.colResultado.Width = 83;
            // 
            // colObservaciones
            // 
            this.colObservaciones.HeaderText = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.ReadOnly = true;
            this.colObservaciones.Width = 440;
            // 
            // frmCobrosColegiados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 529);
            this.Controls.Add(this.lblErroresCant);
            this.Controls.Add(this.lblErrores);
            this.Controls.Add(this.lblExitososCant);
            this.Controls.Add(this.lblExitosos);
            this.Controls.Add(this.lblRegistrosCant);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.chkGenTotal);
            this.Controls.Add(this.dgvColegiados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescCondicion);
            this.Controls.Add(this.txtCondicion);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCobrosColegiados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de Colegiaturas";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvColegiados;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.ComponentModel.BackgroundWorker bwProceso;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.TextBox txtDescCondicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Framework.UserControls.chkSaseg chkGenTotal;
        private System.Windows.Forms.Label lblErroresCant;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Label lblExitososCant;
        private System.Windows.Forms.Label lblExitosos;
        private System.Windows.Forms.Label lblRegistrosCant;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobradorCole;
        private System.Windows.Forms.DataGridViewImageColumn colResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
    }
}