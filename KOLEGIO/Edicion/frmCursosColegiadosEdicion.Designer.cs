
namespace KOLEGIO
{
	partial class frmCursosColegiadosEdicion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCursosColegiadosEdicion));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoCurso = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaCurso = new System.Windows.Forms.ToolStripButton();
			this.dgvCursos = new System.Windows.Forms.DataGridView();
			this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDuracionHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.btnGuardarSalir = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnResize = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNColegiado = new Framework.UserControls.txtNormal();
			this.txtNombreColegiado = new Framework.UserControls.txtNormal();
			this.txtNumColegiado = new Framework.UserControls.txtNormal();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.dgvCursos);
			this.groupBox1.Location = new System.Drawing.Point(23, 107);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(939, 478);
			this.groupBox1.TabIndex = 42;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cursos";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.toolStrip3);
			this.panel2.Location = new System.Drawing.Point(6, 14);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(135, 28);
			this.panel2.TabIndex = 44;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoCurso,
            this.btnEliminaCurso});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(135, 25);
			this.toolStrip3.TabIndex = 0;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// btnNuevoCurso
			// 
			this.btnNuevoCurso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoCurso.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoCurso.Image")));
			this.btnNuevoCurso.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoCurso.Name = "btnNuevoCurso";
			this.btnNuevoCurso.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoCurso.Text = "Nuevo Establecimiento";
			this.btnNuevoCurso.Click += new System.EventHandler(this.btnNuevoCurso_Click);
			// 
			// btnEliminaCurso
			// 
			this.btnEliminaCurso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaCurso.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaCurso.Image")));
			this.btnEliminaCurso.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaCurso.Name = "btnEliminaCurso";
			this.btnEliminaCurso.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaCurso.Text = "Eliminar Establecimiento";
			this.btnEliminaCurso.Visible = false;
			// 
			// dgvCursos
			// 
			this.dgvCursos.AllowUserToAddRows = false;
			this.dgvCursos.AllowUserToDeleteRows = false;
			this.dgvCursos.AllowUserToResizeRows = false;
			this.dgvCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNombre,
            this.colTipo,
            this.colNivel,
            this.colEstado,
            this.colModalidad,
            this.colDuracionHoras,
            this.colFecha});
			this.dgvCursos.Location = new System.Drawing.Point(6, 48);
			this.dgvCursos.MultiSelect = false;
			this.dgvCursos.Name = "dgvCursos";
			this.dgvCursos.RowHeadersVisible = false;
			this.dgvCursos.Size = new System.Drawing.Size(927, 424);
			this.dgvCursos.TabIndex = 0;
			this.dgvCursos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCursos_CurrentCellDirtyStateChanged);
			this.dgvCursos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCursos_MouseDoubleClick);
			// 
			// colCodigo
			// 
			this.colCodigo.FillWeight = 76.14214F;
			this.colCodigo.HeaderText = "Código";
			this.colCodigo.Name = "colCodigo";
			this.colCodigo.ReadOnly = true;
			// 
			// colNombre
			// 
			this.colNombre.FillWeight = 182.7481F;
			this.colNombre.HeaderText = "Nombre";
			this.colNombre.Name = "colNombre";
			this.colNombre.ReadOnly = true;
			// 
			// colTipo
			// 
			this.colTipo.FillWeight = 83.35025F;
			this.colTipo.HeaderText = "Tipo";
			this.colTipo.Name = "colTipo";
			this.colTipo.ReadOnly = true;
			// 
			// colNivel
			// 
			this.colNivel.FillWeight = 65.49435F;
			this.colNivel.HeaderText = "Nivel";
			this.colNivel.Name = "colNivel";
			this.colNivel.ReadOnly = true;
			// 
			// colEstado
			// 
			this.colEstado.FillWeight = 92.26519F;
			this.colEstado.HeaderText = "Estado";
			this.colEstado.Name = "colEstado";
			this.colEstado.ReadOnly = true;
			this.colEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// colModalidad
			// 
			this.colModalidad.HeaderText = "Modalidad";
			this.colModalidad.Name = "colModalidad";
			this.colModalidad.ReadOnly = true;
			// 
			// colDuracionHoras
			// 
			this.colDuracionHoras.HeaderText = "DuracionHoras";
			this.colDuracionHoras.Name = "colDuracionHoras";
			this.colDuracionHoras.ReadOnly = true;
			// 
			// colFecha
			// 
			this.colFecha.HeaderText = "Fecha";
			this.colFecha.Name = "colFecha";
			this.colFecha.ReadOnly = true;
			// 
			// toolStrip2
			// 
			this.toolStrip2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnGuardarSalir,
            this.toolStripSeparator4,
            this.btnResize,
            this.btnSalir});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(983, 25);
			this.toolStrip2.TabIndex = 281;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// btnGuardar
			// 
			this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnGuardar.Enabled = false;
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(23, 22);
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnGuardarSalir
			// 
			this.btnGuardarSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnGuardarSalir.Enabled = false;
			this.btnGuardarSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarSalir.Image")));
			this.btnGuardarSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGuardarSalir.Name = "btnGuardarSalir";
			this.btnGuardarSalir.Size = new System.Drawing.Size(23, 22);
			this.btnGuardarSalir.Text = "Guardar y Salir";
			this.btnGuardarSalir.Click += new System.EventHandler(this.btnGuardarSalir_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(26, 60);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 282;
			this.label7.Text = "Nº Colegiado:";
			// 
			// txtNColegiado
			// 
			this.txtNColegiado.FormatearNumero = false;
			this.txtNColegiado.Location = new System.Drawing.Point(118, 60);
			this.txtNColegiado.Longitud = 32767;
			this.txtNColegiado.Multilinea = false;
			this.txtNColegiado.Name = "txtNColegiado";
			this.txtNColegiado.Password = '\0';
			this.txtNColegiado.ReadOnly = false;
			this.txtNColegiado.Size = new System.Drawing.Size(102, 21);
			this.txtNColegiado.TabIndex = 283;
			this.txtNColegiado.Valor = "";
			this.txtNColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumColegiado_KeyDown);
			this.txtNColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNumColegiado_MouseDoubleClick);
			this.txtNColegiado.MouseLeave += new System.EventHandler(this.txtNumColegiado_Leave);
			// 
			// txtNombreColegiado
			// 
			this.txtNombreColegiado.FormatearNumero = false;
			this.txtNombreColegiado.Location = new System.Drawing.Point(226, 60);
			this.txtNombreColegiado.Longitud = 32767;
			this.txtNombreColegiado.Multilinea = false;
			this.txtNombreColegiado.Name = "txtNombreColegiado";
			this.txtNombreColegiado.Password = '\0';
			this.txtNombreColegiado.ReadOnly = true;
			this.txtNombreColegiado.Size = new System.Drawing.Size(306, 21);
			this.txtNombreColegiado.TabIndex = 284;
			this.txtNombreColegiado.Valor = "";
			// 
			// txtNumColegiado
			// 
			this.txtNumColegiado.FormatearNumero = false;
			this.txtNumColegiado.Location = new System.Drawing.Point(118, 87);
			this.txtNumColegiado.Longitud = 32767;
			this.txtNumColegiado.Multilinea = false;
			this.txtNumColegiado.Name = "txtNumColegiado";
			this.txtNumColegiado.Password = '\0';
			this.txtNumColegiado.ReadOnly = false;
			this.txtNumColegiado.Size = new System.Drawing.Size(102, 21);
			this.txtNumColegiado.TabIndex = 285;
			this.txtNumColegiado.Valor = "";
			this.txtNumColegiado.Visible = false;
			// 
			// frmCursosColegiadosEdicion
			// 
			this.ClientSize = new System.Drawing.Size(983, 597);
			this.Controls.Add(this.txtNumColegiado);
			this.Controls.Add(this.txtNombreColegiado);
			this.Controls.Add(this.txtNColegiado);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCursosColegiadosEdicion";
			this.Text = "Cursos por colegiado";
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripButton btnNuevoCurso;
		private System.Windows.Forms.ToolStripButton btnEliminaCurso;
		private System.Windows.Forms.DataGridView dgvCursos;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNivel;
		private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
		private System.Windows.Forms.DataGridViewTextBoxColumn colModalidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDuracionHoras;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
		protected System.Windows.Forms.ToolStrip toolStrip2;
		protected System.Windows.Forms.ToolStripButton btnGuardar;
		protected System.Windows.Forms.ToolStripButton btnGuardarSalir;
		protected System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnResize;
		protected System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.Label label7;
		private Framework.UserControls.txtNormal txtNColegiado;
		private Framework.UserControls.txtNormal txtNombreColegiado;
		private Framework.UserControls.txtNormal txtNumColegiado;
	}
}