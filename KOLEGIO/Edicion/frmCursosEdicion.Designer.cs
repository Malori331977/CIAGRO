namespace KOLEGIO
{
	partial class frmCursosEdicion
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
			this.txtNombre = new Framework.UserControls.txtNormal();
			this.txtCodigo = new Framework.UserControls.txtNormal();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbTipo = new Framework.UserControls.cmbSaseg();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cmbEstado = new Framework.UserControls.cmbSaseg();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbModalidad = new Framework.UserControls.cmbSaseg();
			this.dtpFecha = new Framework.UserControls.dtpSaseg();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.cmbNivel = new Framework.UserControls.cmbSaseg();
			this.numDuracion = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.txtMonto = new Framework.UserControls.txtNormal();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDuracion)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Size = new System.Drawing.Size(673, 437);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.txtMonto);
			this.tpBasicos.Controls.Add(this.label15);
			this.tpBasicos.Controls.Add(this.numDuracion);
			this.tpBasicos.Controls.Add(this.label14);
			this.tpBasicos.Controls.Add(this.cmbNivel);
			this.tpBasicos.Controls.Add(this.label13);
			this.tpBasicos.Controls.Add(this.label12);
			this.tpBasicos.Controls.Add(this.dtpFecha);
			this.tpBasicos.Controls.Add(this.label11);
			this.tpBasicos.Controls.Add(this.cmbModalidad);
			this.tpBasicos.Controls.Add(this.label9);
			this.tpBasicos.Controls.Add(this.cmbEstado);
			this.tpBasicos.Controls.Add(this.label7);
			this.tpBasicos.Controls.Add(this.cmbTipo);
			this.tpBasicos.Controls.Add(this.txtNombre);
			this.tpBasicos.Controls.Add(this.txtCodigo);
			this.tpBasicos.Controls.Add(this.label10);
			this.tpBasicos.Controls.Add(this.label8);
			this.tpBasicos.Size = new System.Drawing.Size(665, 411);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.cmbTipo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
			this.tpBasicos.Controls.SetChildIndex(this.cmbEstado, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label9, 0);
			this.tpBasicos.Controls.SetChildIndex(this.cmbModalidad, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dtpFecha, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label12, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label13, 0);
			this.tpBasicos.Controls.SetChildIndex(this.cmbNivel, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
			this.tpBasicos.Controls.SetChildIndex(this.numDuracion, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label15, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtMonto, 0);
			// 
			// tpAdmin
			// 
			this.tpAdmin.Size = new System.Drawing.Size(665, 391);
			// 
			// panelAdmin
			// 
			this.panelAdmin.Size = new System.Drawing.Size(659, 21);
			// 
			// panelBasicos
			// 
			this.panelBasicos.Size = new System.Drawing.Size(659, 21);
			// 
			// tpAdjuntos
			// 
			this.tpAdjuntos.Size = new System.Drawing.Size(665, 391);
			// 
			// panelAdjuntos
			// 
			this.panelAdjuntos.Size = new System.Drawing.Size(659, 21);
			// 
			// txtNombre
			// 
			this.txtNombre.FormatearNumero = false;
			this.txtNombre.Location = new System.Drawing.Point(235, 97);
			this.txtNombre.Longitud = 50;
			this.txtNombre.Multilinea = false;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Password = '\0';
			this.txtNombre.ReadOnly = false;
			this.txtNombre.Size = new System.Drawing.Size(343, 21);
			this.txtNombre.TabIndex = 11;
			this.txtNombre.Valor = "";
			// 
			// txtCodigo
			// 
			this.txtCodigo.FormatearNumero = false;
			this.txtCodigo.Location = new System.Drawing.Point(235, 61);
			this.txtCodigo.Longitud = 4;
			this.txtCodigo.Multilinea = false;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Password = '\0';
			this.txtCodigo.ReadOnly = false;
			this.txtCodigo.Size = new System.Drawing.Size(124, 21);
			this.txtCodigo.TabIndex = 10;
			this.txtCodigo.Valor = "";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(175, 101);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "Nombre:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(179, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Código:";
			// 
			// cmbTipo
			// 
			this.cmbTipo.Habilitar = true;
			this.cmbTipo.Index = -1;
			this.cmbTipo.Location = new System.Drawing.Point(235, 133);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(202, 22);
			this.cmbTipo.TabIndex = 15;
			this.cmbTipo.Texto = "";
			this.cmbTipo.Valor = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(193, 137);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Tipo:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(179, 220);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 13);
			this.label9.TabIndex = 18;
			this.label9.Text = "Estado:";
			// 
			// cmbEstado
			// 
			this.cmbEstado.Habilitar = true;
			this.cmbEstado.Index = -1;
			this.cmbEstado.Location = new System.Drawing.Point(235, 216);
			this.cmbEstado.Name = "cmbEstado";
			this.cmbEstado.Size = new System.Drawing.Size(166, 22);
			this.cmbEstado.TabIndex = 17;
			this.cmbEstado.Texto = "";
			this.cmbEstado.Valor = "";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(160, 257);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 13);
			this.label11.TabIndex = 20;
			this.label11.Text = "Modalidad:";
			// 
			// cmbModalidad
			// 
			this.cmbModalidad.Habilitar = true;
			this.cmbModalidad.Index = -1;
			this.cmbModalidad.Location = new System.Drawing.Point(235, 253);
			this.cmbModalidad.Name = "cmbModalidad";
			this.cmbModalidad.Size = new System.Drawing.Size(166, 22);
			this.cmbModalidad.TabIndex = 19;
			this.cmbModalidad.Texto = "";
			this.cmbModalidad.Valor = "";
			// 
			// dtpFecha
			// 
			this.dtpFecha.Checked = true;
			this.dtpFecha.Location = new System.Drawing.Point(235, 330);
			this.dtpFecha.mostrarCheckBox = false;
			this.dtpFecha.mostrarUpDown = false;
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(102, 22);
			this.dtpFecha.TabIndex = 21;
			this.dtpFecha.Value = new System.DateTime(2022, 7, 9, 18, 52, 37, 115);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(122, 298);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(107, 13);
			this.label12.TabIndex = 23;
			this.label12.Text = "Duracion (Horas):";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(183, 333);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(46, 13);
			this.label13.TabIndex = 24;
			this.label13.Text = "Fecha:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(189, 176);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "Nivel:";
			// 
			// cmbNivel
			// 
			this.cmbNivel.Habilitar = true;
			this.cmbNivel.Index = -1;
			this.cmbNivel.Location = new System.Drawing.Point(235, 173);
			this.cmbNivel.Name = "cmbNivel";
			this.cmbNivel.Size = new System.Drawing.Size(166, 22);
			this.cmbNivel.TabIndex = 25;
			this.cmbNivel.Texto = "";
			this.cmbNivel.Valor = "";
			// 
			// numDuracion
			// 
			this.numDuracion.Location = new System.Drawing.Point(235, 296);
			this.numDuracion.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
			this.numDuracion.Name = "numDuracion";
			this.numDuracion.Size = new System.Drawing.Size(102, 20);
			this.numDuracion.TabIndex = 27;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(183, 364);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(46, 13);
			this.label15.TabIndex = 28;
			this.label15.Text = "Monto:";
			// 
			// txtMonto
			// 
			this.txtMonto.FormatearNumero = false;
			this.txtMonto.Location = new System.Drawing.Point(235, 364);
			this.txtMonto.Longitud = 32767;
			this.txtMonto.Multilinea = false;
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Password = '\0';
			this.txtMonto.ReadOnly = false;
			this.txtMonto.Size = new System.Drawing.Size(102, 21);
			this.txtMonto.TabIndex = 31;
			this.txtMonto.Valor = "";
			this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
			// 
			// frmCursosEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(673, 528);
			this.Name = "frmCursosEdicion";
			this.Text = "frmCursosEdicion";
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
			((System.ComponentModel.ISupportInitialize)(this.numDuracion)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Framework.UserControls.txtNormal txtNombre;
		private Framework.UserControls.txtNormal txtCodigo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private Framework.UserControls.dtpSaseg dtpFecha;
		private System.Windows.Forms.Label label11;
		private Framework.UserControls.cmbSaseg cmbModalidad;
		private System.Windows.Forms.Label label9;
		private Framework.UserControls.cmbSaseg cmbEstado;
		private System.Windows.Forms.Label label7;
		private Framework.UserControls.cmbSaseg cmbTipo;
		private System.Windows.Forms.Label label14;
		private Framework.UserControls.cmbSaseg cmbNivel;
		private System.Windows.Forms.NumericUpDown numDuracion;
		private System.Windows.Forms.Label label15;
		private Framework.UserControls.txtNormal txtMonto;
	}
}