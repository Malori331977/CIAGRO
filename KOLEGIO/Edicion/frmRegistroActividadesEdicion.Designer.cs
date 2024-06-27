namespace KOLEGIO.Edicion
{
	partial class frmRegistroActividadesEdicion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroActividadesEdicion));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
			this.btnExcel = new System.Windows.Forms.ToolStripButton();
			this.btnResize = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.dtpDuracion = new System.Windows.Forms.DateTimePicker();
			this.lblRegresoCondicion = new System.Windows.Forms.Label();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpFecha = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtActividadDesc = new System.Windows.Forms.TextBox();
			this.txtActividad = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvColegiados = new System.Windows.Forms.DataGridView();
			this.txtIdentificacionDesc = new System.Windows.Forms.TextBox();
			this.txtIdentificacion = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.gbReg = new System.Windows.Forms.GroupBox();
			this.rbConsultora = new System.Windows.Forms.RadioButton();
			this.rbEstablecimiento = new System.Windows.Forms.RadioButton();
			this.rbColegiado = new System.Windows.Forms.RadioButton();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btnAgregarActividad = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarActividad = new System.Windows.Forms.ToolStripButton();
			this.btnEditarActividad = new System.Windows.Forms.ToolStripButton();
			this.rtbObservacion = new System.Windows.Forms.RichTextBox();
			this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colIdRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colIdActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
			this.gbReg.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefrescar,
            this.btnExcel,
            this.btnResize,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(950, 25);
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
			this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
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
			// dtpDuracion
			// 
			this.dtpDuracion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDuracion.Location = new System.Drawing.Point(779, 73);
			this.dtpDuracion.Name = "dtpDuracion";
			this.dtpDuracion.ShowUpDown = true;
			this.dtpDuracion.Size = new System.Drawing.Size(100, 20);
			this.dtpDuracion.TabIndex = 316;
			// 
			// lblRegresoCondicion
			// 
			this.lblRegresoCondicion.AutoSize = true;
			this.lblRegresoCondicion.Location = new System.Drawing.Point(723, 76);
			this.lblRegresoCondicion.Name = "lblRegresoCondicion";
			this.lblRegresoCondicion.Size = new System.Drawing.Size(53, 13);
			this.lblRegresoCondicion.TabIndex = 315;
			this.lblRegresoCondicion.Text = "Duración:";
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(857, 160);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(93, 20);
			this.txtFiltro.TabIndex = 314;
			this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(798, 163);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 313;
			this.label5.Text = "Filtrar por:";
			// 
			// dtpFecha
			// 
			this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFecha.Location = new System.Drawing.Point(603, 76);
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(100, 20);
			this.dtpFecha.TabIndex = 311;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(560, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 310;
			this.label4.Text = "Fecha:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(46, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 308;
			this.label3.Text = "Observación:";
			// 
			// txtActividadDesc
			// 
			this.txtActividadDesc.Location = new System.Drawing.Point(672, 40);
			this.txtActividadDesc.Name = "txtActividadDesc";
			this.txtActividadDesc.ReadOnly = true;
			this.txtActividadDesc.Size = new System.Drawing.Size(207, 20);
			this.txtActividadDesc.TabIndex = 307;
			// 
			// txtActividad
			// 
			this.txtActividad.Location = new System.Drawing.Point(602, 40);
			this.txtActividad.Name = "txtActividad";
			this.txtActividad.Size = new System.Drawing.Size(64, 20);
			this.txtActividad.TabIndex = 306;
			this.txtActividad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtActividad_KeyDown);
			this.txtActividad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtActividad_MouseDoubleClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(546, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 305;
			this.label2.Text = "Actividad:";
			// 
			// dgvColegiados
			// 
			this.dgvColegiados.AllowUserToAddRows = false;
			this.dgvColegiados.AllowUserToResizeRows = false;
			this.dgvColegiados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvColegiados.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvColegiados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvColegiados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIdRegistro,
            this.colRegistro,
            this.colIdActividad,
            this.ColActividad,
            this.colDuracion,
            this.colFecha,
            this.colObservaciones});
			this.dgvColegiados.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvColegiados.Location = new System.Drawing.Point(0, 186);
			this.dgvColegiados.Name = "dgvColegiados";
			this.dgvColegiados.RowHeadersVisible = false;
			this.dgvColegiados.Size = new System.Drawing.Size(950, 334);
			this.dgvColegiados.TabIndex = 304;
			// 
			// txtIdentificacionDesc
			// 
			this.txtIdentificacionDesc.Location = new System.Drawing.Point(170, 38);
			this.txtIdentificacionDesc.Name = "txtIdentificacionDesc";
			this.txtIdentificacionDesc.ReadOnly = true;
			this.txtIdentificacionDesc.Size = new System.Drawing.Size(310, 20);
			this.txtIdentificacionDesc.TabIndex = 303;
			// 
			// txtIdentificacion
			// 
			this.txtIdentificacion.Location = new System.Drawing.Point(78, 38);
			this.txtIdentificacion.Name = "txtIdentificacion";
			this.txtIdentificacion.Size = new System.Drawing.Size(86, 20);
			this.txtIdentificacion.TabIndex = 302;
			this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
			this.txtIdentificacion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtIdentificacion_MouseDoubleClick);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(3, 41);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(73, 13);
			this.label27.TabIndex = 301;
			this.label27.Text = "Identificación:";
			// 
			// gbReg
			// 
			this.gbReg.Controls.Add(this.rbConsultora);
			this.gbReg.Controls.Add(this.rbEstablecimiento);
			this.gbReg.Controls.Add(this.rbColegiado);
			this.gbReg.Controls.Add(this.txtIdentificacionDesc);
			this.gbReg.Controls.Add(this.label27);
			this.gbReg.Controls.Add(this.txtIdentificacion);
			this.gbReg.Location = new System.Drawing.Point(40, 28);
			this.gbReg.Name = "gbReg";
			this.gbReg.Size = new System.Drawing.Size(486, 65);
			this.gbReg.TabIndex = 318;
			this.gbReg.TabStop = false;
			this.gbReg.Text = "Tipo Registro";
			// 
			// rbConsultora
			// 
			this.rbConsultora.AutoSize = true;
			this.rbConsultora.Location = new System.Drawing.Point(405, 15);
			this.rbConsultora.Name = "rbConsultora";
			this.rbConsultora.Size = new System.Drawing.Size(75, 17);
			this.rbConsultora.TabIndex = 306;
			this.rbConsultora.TabStop = true;
			this.rbConsultora.Text = "Consultora";
			this.rbConsultora.UseVisualStyleBackColor = true;
			// 
			// rbEstablecimiento
			// 
			this.rbEstablecimiento.AutoSize = true;
			this.rbEstablecimiento.Location = new System.Drawing.Point(233, 15);
			this.rbEstablecimiento.Name = "rbEstablecimiento";
			this.rbEstablecimiento.Size = new System.Drawing.Size(99, 17);
			this.rbEstablecimiento.TabIndex = 305;
			this.rbEstablecimiento.TabStop = true;
			this.rbEstablecimiento.Text = "Establecimiento";
			this.rbEstablecimiento.UseVisualStyleBackColor = true;
			// 
			// rbColegiado
			// 
			this.rbColegiado.AutoSize = true;
			this.rbColegiado.Location = new System.Drawing.Point(78, 15);
			this.rbColegiado.Name = "rbColegiado";
			this.rbColegiado.Size = new System.Drawing.Size(72, 17);
			this.rbColegiado.TabIndex = 304;
			this.rbColegiado.TabStop = true;
			this.rbColegiado.Text = "Colegiado";
			this.rbColegiado.UseVisualStyleBackColor = true;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarActividad,
            this.btnEliminarActividad,
            this.btnEditarActividad});
			this.toolStrip3.Location = new System.Drawing.Point(0, 158);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(81, 25);
			this.toolStrip3.TabIndex = 320;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// btnAgregarActividad
			// 
			this.btnAgregarActividad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAgregarActividad.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarActividad.Image")));
			this.btnAgregarActividad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregarActividad.Name = "btnAgregarActividad";
			this.btnAgregarActividad.Size = new System.Drawing.Size(23, 22);
			this.btnAgregarActividad.Text = "Agregar";
			this.btnAgregarActividad.Click += new System.EventHandler(this.btnAgregarActividad_Click);
			// 
			// btnEliminarActividad
			// 
			this.btnEliminarActividad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarActividad.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarActividad.Image")));
			this.btnEliminarActividad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarActividad.Name = "btnEliminarActividad";
			this.btnEliminarActividad.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarActividad.Text = "Eliminar";
			this.btnEliminarActividad.Click += new System.EventHandler(this.btnEliminarActividades_Click);
			// 
			// btnEditarActividad
			// 
			this.btnEditarActividad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEditarActividad.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarActividad.Image")));
			this.btnEditarActividad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditarActividad.Name = "btnEditarActividad";
			this.btnEditarActividad.Size = new System.Drawing.Size(23, 22);
			this.btnEditarActividad.Text = "Editar";
			this.btnEditarActividad.Click += new System.EventHandler(this.btnEditarActividades_Click);
			// 
			// rtbObservacion
			// 
			this.rtbObservacion.Location = new System.Drawing.Point(118, 102);
			this.rtbObservacion.Name = "rtbObservacion";
			this.rtbObservacion.Size = new System.Drawing.Size(402, 40);
			this.rtbObservacion.TabIndex = 321;
			this.rtbObservacion.Text = "";
			// 
			// colId
			// 
			this.colId.HeaderText = "Id";
			this.colId.Name = "colId";
			this.colId.ReadOnly = true;
			this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colId.Visible = false;
			// 
			// colIdRegistro
			// 
			this.colIdRegistro.DataPropertyName = "IdRegistro";
			this.colIdRegistro.HeaderText = "Codigo registro";
			this.colIdRegistro.Name = "colIdRegistro";
			this.colIdRegistro.ReadOnly = true;
			// 
			// colRegistro
			// 
			this.colRegistro.HeaderText = "Registro";
			this.colRegistro.Name = "colRegistro";
			// 
			// colIdActividad
			// 
			this.colIdActividad.HeaderText = "Codigo actividad";
			this.colIdActividad.MinimumWidth = 6;
			this.colIdActividad.Name = "colIdActividad";
			// 
			// ColActividad
			// 
			this.ColActividad.HeaderText = "Actividad";
			this.ColActividad.Name = "ColActividad";
			// 
			// colDuracion
			// 
			this.colDuracion.HeaderText = "Duración";
			this.colDuracion.Name = "colDuracion";
			this.colDuracion.ReadOnly = true;
			// 
			// colFecha
			// 
			this.colFecha.HeaderText = "Fecha";
			this.colFecha.Name = "colFecha";
			// 
			// colObservaciones
			// 
			this.colObservaciones.HeaderText = "Observaciones";
			this.colObservaciones.Name = "colObservaciones";
			this.colObservaciones.ReadOnly = true;
			// 
			// frmRegistroActividadesEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(950, 520);
			this.Controls.Add(this.rtbObservacion);
			this.Controls.Add(this.toolStrip3);
			this.Controls.Add(this.gbReg);
			this.Controls.Add(this.dtpDuracion);
			this.Controls.Add(this.lblRegresoCondicion);
			this.Controls.Add(this.txtFiltro);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtpFecha);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtActividadDesc);
			this.Controls.Add(this.txtActividad);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgvColegiados);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRegistroActividadesEdicion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registro Actividades";
			this.Load += new System.EventHandler(this.frmRegistroActividadesEdicion_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
			this.gbReg.ResumeLayout(false);
			this.gbReg.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnRefrescar;
		private System.Windows.Forms.ToolStripButton btnExcel;
		private System.Windows.Forms.ToolStripButton btnResize;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.DateTimePicker dtpDuracion;
		private System.Windows.Forms.Label lblRegresoCondicion;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtActividadDesc;
		private System.Windows.Forms.TextBox txtActividad;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvColegiados;
		private System.Windows.Forms.TextBox txtIdentificacionDesc;
		private System.Windows.Forms.TextBox txtIdentificacion;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox gbReg;
		private System.Windows.Forms.RadioButton rbConsultora;
		private System.Windows.Forms.RadioButton rbEstablecimiento;
		private System.Windows.Forms.RadioButton rbColegiado;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton btnAgregarActividad;
		private System.Windows.Forms.ToolStripButton btnEliminarActividad;
		private System.Windows.Forms.ToolStripButton btnEditarActividad;
		private System.Windows.Forms.RichTextBox rtbObservacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdRegistro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colRegistro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdActividad;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColActividad;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDuracion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
	}
}