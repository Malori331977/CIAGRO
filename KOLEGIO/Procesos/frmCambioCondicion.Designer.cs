namespace KOLEGIO
{
    partial class frmCambioCondicion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioCondicion));
			this.txtDescCondicionIni = new System.Windows.Forms.TextBox();
			this.txtCondicionIni = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.iList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.pbProceso = new System.Windows.Forms.ProgressBar();
			this.bwProceso = new System.ComponentModel.BackgroundWorker();
			this.dgvColegiados = new System.Windows.Forms.DataGridView();
			this.colSeleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colIdColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtDescCondicionFin = new System.Windows.Forms.TextBox();
			this.txtCondicionFin = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSesionApro = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpFechaApro = new System.Windows.Forms.DateTimePicker();
			this.chkMasivo = new Framework.UserControls.chkSaseg();
			this.lblRegistrosCant = new System.Windows.Forms.Label();
			this.lblRegistros = new System.Windows.Forms.Label();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpRegresoCondicion = new System.Windows.Forms.DateTimePicker();
			this.lblRegresoCondicion = new System.Windows.Forms.Label();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.colResultado = new System.Windows.Forms.DataGridViewImageColumn();
			this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
			this.btnProcesar = new System.Windows.Forms.ToolStripButton();
			this.btnExcel = new System.Windows.Forms.ToolStripButton();
			this.btnResize = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDescCondicionIni
			// 
			this.txtDescCondicionIni.Location = new System.Drawing.Point(178, 39);
			this.txtDescCondicionIni.Name = "txtDescCondicionIni";
			this.txtDescCondicionIni.ReadOnly = true;
			this.txtDescCondicionIni.Size = new System.Drawing.Size(183, 20);
			this.txtDescCondicionIni.TabIndex = 282;
			// 
			// txtCondicionIni
			// 
			this.txtCondicionIni.Location = new System.Drawing.Point(108, 39);
			this.txtCondicionIni.Name = "txtCondicionIni";
			this.txtCondicionIni.Size = new System.Drawing.Size(64, 20);
			this.txtCondicionIni.TabIndex = 281;
			this.txtCondicionIni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicionIni_KeyDown);
			this.txtCondicionIni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicionIni_MouseDoubleClick);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(15, 42);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(87, 13);
			this.label27.TabIndex = 280;
			this.label27.Text = "Condición Inicial:";
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
			this.toolStrip1.Size = new System.Drawing.Size(892, 25);
			this.toolStrip1.TabIndex = 278;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// pbProceso
			// 
			this.pbProceso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbProceso.Location = new System.Drawing.Point(12, 497);
			this.pbProceso.Name = "pbProceso";
			this.pbProceso.Size = new System.Drawing.Size(868, 23);
			this.pbProceso.TabIndex = 284;
			// 
			// bwProceso
			// 
			this.bwProceso.WorkerReportsProgress = true;
			this.bwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProceso_DoWork);
			this.bwProceso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProceso_ProgressChanged);
			this.bwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProceso_RunWorkerCompleted);
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
            this.colSeleccion,
            this.colIdColegiado,
            this.colNumeroColegiado,
            this.colNombreColegiado,
            this.colResultado,
            this.colObservaciones});
			this.dgvColegiados.Location = new System.Drawing.Point(15, 101);
			this.dgvColegiados.Name = "dgvColegiados";
			this.dgvColegiados.RowHeadersVisible = false;
			this.dgvColegiados.Size = new System.Drawing.Size(865, 390);
			this.dgvColegiados.TabIndex = 285;
			this.dgvColegiados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColegiados_CellClick);
			// 
			// colSeleccion
			// 
			this.colSeleccion.HeaderText = "Cambio";
			this.colSeleccion.Name = "colSeleccion";
			this.colSeleccion.ReadOnly = true;
			this.colSeleccion.TrueValue = "";
			this.colSeleccion.Width = 65;
			// 
			// colIdColegiado
			// 
			this.colIdColegiado.DataPropertyName = "IdColegiado";
			this.colIdColegiado.HeaderText = "Id Colegiado";
			this.colIdColegiado.Name = "colIdColegiado";
			this.colIdColegiado.ReadOnly = true;
			this.colIdColegiado.Width = 110;
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
			// colObservaciones
			// 
			this.colObservaciones.HeaderText = "Observaciones";
			this.colObservaciones.Name = "colObservaciones";
			this.colObservaciones.ReadOnly = true;
			this.colObservaciones.Width = 440;
			// 
			// txtDescCondicionFin
			// 
			this.txtDescCondicionFin.Location = new System.Drawing.Point(178, 69);
			this.txtDescCondicionFin.Name = "txtDescCondicionFin";
			this.txtDescCondicionFin.ReadOnly = true;
			this.txtDescCondicionFin.Size = new System.Drawing.Size(183, 20);
			this.txtDescCondicionFin.TabIndex = 288;
			// 
			// txtCondicionFin
			// 
			this.txtCondicionFin.Location = new System.Drawing.Point(108, 69);
			this.txtCondicionFin.Name = "txtCondicionFin";
			this.txtCondicionFin.Size = new System.Drawing.Size(64, 20);
			this.txtCondicionFin.TabIndex = 287;
			this.txtCondicionFin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicionFin_KeyDown);
			this.txtCondicionFin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicionFin_MouseDoubleClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 286;
			this.label2.Text = "Condición Final:";
			// 
			// txtSesionApro
			// 
			this.txtSesionApro.Location = new System.Drawing.Point(472, 39);
			this.txtSesionApro.Name = "txtSesionApro";
			this.txtSesionApro.Size = new System.Drawing.Size(100, 20);
			this.txtSesionApro.TabIndex = 290;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(367, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 13);
			this.label3.TabIndex = 289;
			this.label3.Text = "Sesión Aprobación:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(363, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 13);
			this.label4.TabIndex = 291;
			this.label4.Text = "Fecha Aprobación:";
			// 
			// dtpFechaApro
			// 
			this.dtpFechaApro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaApro.Location = new System.Drawing.Point(472, 69);
			this.dtpFechaApro.Name = "dtpFechaApro";
			this.dtpFechaApro.Size = new System.Drawing.Size(100, 20);
			this.dtpFechaApro.TabIndex = 293;
			// 
			// chkMasivo
			// 
			this.chkMasivo.Checked = false;
			this.chkMasivo.Location = new System.Drawing.Point(595, 68);
			this.chkMasivo.Name = "chkMasivo";
			this.chkMasivo.Size = new System.Drawing.Size(80, 17);
			this.chkMasivo.TabIndex = 294;
			this.chkMasivo.Texto = "Masivo";
			this.chkMasivo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkMasivo_MouseClick);
			// 
			// lblRegistrosCant
			// 
			this.lblRegistrosCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRegistrosCant.AutoSize = true;
			this.lblRegistrosCant.Location = new System.Drawing.Point(809, 524);
			this.lblRegistrosCant.Name = "lblRegistrosCant";
			this.lblRegistrosCant.Size = new System.Drawing.Size(13, 13);
			this.lblRegistrosCant.TabIndex = 296;
			this.lblRegistrosCant.Text = "0";
			// 
			// lblRegistros
			// 
			this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRegistros.AutoSize = true;
			this.lblRegistros.Location = new System.Drawing.Point(746, 525);
			this.lblRegistros.Name = "lblRegistros";
			this.lblRegistros.Size = new System.Drawing.Size(57, 13);
			this.lblRegistros.TabIndex = 295;
			this.lblRegistros.Text = "Registros: ";
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(787, 69);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(93, 20);
			this.txtFiltro.TabIndex = 298;
			this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(728, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 297;
			this.label5.Text = "Filtrar por:";
			// 
			// dtpRegresoCondicion
			// 
			this.dtpRegresoCondicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpRegresoCondicion.Location = new System.Drawing.Point(703, 39);
			this.dtpRegresoCondicion.Name = "dtpRegresoCondicion";
			this.dtpRegresoCondicion.Size = new System.Drawing.Size(100, 20);
			this.dtpRegresoCondicion.TabIndex = 300;
			this.dtpRegresoCondicion.Visible = false;
			// 
			// lblRegresoCondicion
			// 
			this.lblRegresoCondicion.AutoSize = true;
			this.lblRegresoCondicion.Location = new System.Drawing.Point(594, 42);
			this.lblRegresoCondicion.Name = "lblRegresoCondicion";
			this.lblRegresoCondicion.Size = new System.Drawing.Size(100, 13);
			this.lblRegresoCondicion.TabIndex = 299;
			this.lblRegresoCondicion.Text = "Regreso Condición:";
			this.lblRegresoCondicion.Visible = false;
			// 
			// dataGridViewImageColumn1
			// 
			this.dataGridViewImageColumn1.HeaderText = "Detalle Carga";
			this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.Width = 83;
			// 
			// colResultado
			// 
			this.colResultado.HeaderText = "Detalle Carga";
			this.colResultado.Image = ((System.Drawing.Image)(resources.GetObject("colResultado.Image")));
			this.colResultado.Name = "colResultado";
			this.colResultado.Width = 83;
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
			this.btnSalir.DoubleClick += new System.EventHandler(this.btnSalir_Click);
			// 
			// frmCambioCondicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(892, 546);
			this.Controls.Add(this.dtpRegresoCondicion);
			this.Controls.Add(this.lblRegresoCondicion);
			this.Controls.Add(this.txtFiltro);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblRegistrosCant);
			this.Controls.Add(this.lblRegistros);
			this.Controls.Add(this.chkMasivo);
			this.Controls.Add(this.dtpFechaApro);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSesionApro);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDescCondicionFin);
			this.Controls.Add(this.txtCondicionFin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgvColegiados);
			this.Controls.Add(this.pbProceso);
			this.Controls.Add(this.txtDescCondicionIni);
			this.Controls.Add(this.txtCondicionIni);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCambioCondicion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cambio de Condición";
			this.Load += new System.EventHandler(this.frmCambioCondicion_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescCondicionIni;
        private System.Windows.Forms.TextBox txtCondicionIni;
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
        private System.Windows.Forms.DataGridView dgvColegiados;
        private System.Windows.Forms.TextBox txtDescCondicionFin;
        private System.Windows.Forms.TextBox txtCondicionFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSesionApro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaApro;
        private Framework.UserControls.chkSaseg chkMasivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreColegiado;
        private System.Windows.Forms.DataGridViewImageColumn colResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
        private System.Windows.Forms.Label lblRegistrosCant;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpRegresoCondicion;
        private System.Windows.Forms.Label lblRegresoCondicion;
		private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
	}
}