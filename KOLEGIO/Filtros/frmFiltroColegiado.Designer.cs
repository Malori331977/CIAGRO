namespace KOLEGIO
{
    partial class frmFiltroColegiado
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroColegiado));
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cmbCondiciones = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dtpPeriodoDesde = new System.Windows.Forms.DateTimePicker();
			this.dtpPeriodoHasta = new System.Windows.Forms.DateTimePicker();
			this.label29 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.grbMoneda = new System.Windows.Forms.GroupBox();
			this.rbEspecialistas2 = new System.Windows.Forms.RadioButton();
			this.rbVidaSilvestre2 = new System.Windows.Forms.RadioButton();
			this.rbPlagui2 = new System.Windows.Forms.RadioButton();
			this.rbViaAerea2 = new System.Windows.Forms.RadioButton();
			this.rbPerito2 = new System.Windows.Forms.RadioButton();
			this.rbRegente2 = new System.Windows.Forms.RadioButton();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label27 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbCategorias = new System.Windows.Forms.ComboBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbGenero = new System.Windows.Forms.ComboBox();
			this.gbCobrador = new System.Windows.Forms.GroupBox();
			this.cmbCobrador = new System.Windows.Forms.ComboBox();
			this.rbBeneficiario2 = new System.Windows.Forms.RadioButton();
			this.chkActivarRangoFechas2 = new System.Windows.Forms.CheckBox();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.grbMoneda.SuspendLayout();
			this.panel9.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbCobrador.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cmbCondiciones);
			this.groupBox6.Location = new System.Drawing.Point(39, 29);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(401, 42);
			this.groupBox6.TabIndex = 160;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Condición";
			// 
			// cmbCondiciones
			// 
			this.cmbCondiciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondiciones.FormattingEnabled = true;
			this.cmbCondiciones.Location = new System.Drawing.Point(38, 15);
			this.cmbCondiciones.Name = "cmbCondiciones";
			this.cmbCondiciones.Size = new System.Drawing.Size(331, 21);
			this.cmbCondiciones.TabIndex = 166;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.chkActivarRangoFechas2);
			this.groupBox5.Controls.Add(this.dtpPeriodoDesde);
			this.groupBox5.Controls.Add(this.dtpPeriodoHasta);
			this.groupBox5.Controls.Add(this.label29);
			this.groupBox5.Controls.Add(this.label64);
			this.groupBox5.Location = new System.Drawing.Point(39, 333);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(401, 42);
			this.groupBox5.TabIndex = 157;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Rango de Nacimiento";
			// 
			// dtpPeriodoDesde
			// 
			this.dtpPeriodoDesde.Enabled = false;
			this.dtpPeriodoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpPeriodoDesde.Location = new System.Drawing.Point(81, 16);
			this.dtpPeriodoDesde.Name = "dtpPeriodoDesde";
			this.dtpPeriodoDesde.Size = new System.Drawing.Size(101, 20);
			this.dtpPeriodoDesde.TabIndex = 140;
			// 
			// dtpPeriodoHasta
			// 
			this.dtpPeriodoHasta.Enabled = false;
			this.dtpPeriodoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpPeriodoHasta.Location = new System.Drawing.Point(242, 16);
			this.dtpPeriodoHasta.Name = "dtpPeriodoHasta";
			this.dtpPeriodoHasta.Size = new System.Drawing.Size(99, 20);
			this.dtpPeriodoHasta.TabIndex = 139;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(34, 19);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(41, 13);
			this.label29.TabIndex = 132;
			this.label29.Text = "Desde:";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(198, 19);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(38, 13);
			this.label64.TabIndex = 133;
			this.label64.Text = "Hasta:";
			// 
			// grbMoneda
			// 
			this.grbMoneda.Controls.Add(this.rbBeneficiario2);
			this.grbMoneda.Controls.Add(this.rbEspecialistas2);
			this.grbMoneda.Controls.Add(this.rbVidaSilvestre2);
			this.grbMoneda.Controls.Add(this.rbPlagui2);
			this.grbMoneda.Controls.Add(this.rbViaAerea2);
			this.grbMoneda.Controls.Add(this.rbPerito2);
			this.grbMoneda.Controls.Add(this.rbRegente2);
			this.grbMoneda.Location = new System.Drawing.Point(39, 209);
			this.grbMoneda.Name = "grbMoneda";
			this.grbMoneda.Size = new System.Drawing.Size(401, 118);
			this.grbMoneda.TabIndex = 163;
			this.grbMoneda.TabStop = false;
			this.grbMoneda.Text = "Registros";
			// 
			// rbEspecialistas2
			// 
			this.rbEspecialistas2.AutoSize = true;
			this.rbEspecialistas2.Location = new System.Drawing.Point(118, 80);
			this.rbEspecialistas2.Name = "rbEspecialistas2";
			this.rbEspecialistas2.Size = new System.Drawing.Size(86, 17);
			this.rbEspecialistas2.TabIndex = 5;
			this.rbEspecialistas2.TabStop = true;
			this.rbEspecialistas2.Text = "Especialistas";
			this.rbEspecialistas2.UseVisualStyleBackColor = true;
			// 
			// rbVidaSilvestre2
			// 
			this.rbVidaSilvestre2.AutoSize = true;
			this.rbVidaSilvestre2.Location = new System.Drawing.Point(22, 80);
			this.rbVidaSilvestre2.Name = "rbVidaSilvestre2";
			this.rbVidaSilvestre2.Size = new System.Drawing.Size(87, 17);
			this.rbVidaSilvestre2.TabIndex = 4;
			this.rbVidaSilvestre2.TabStop = true;
			this.rbVidaSilvestre2.Text = "Vida silvestre";
			this.rbVidaSilvestre2.UseVisualStyleBackColor = true;
			// 
			// rbPlagui2
			// 
			this.rbPlagui2.AutoSize = true;
			this.rbPlagui2.Location = new System.Drawing.Point(268, 31);
			this.rbPlagui2.Name = "rbPlagui2";
			this.rbPlagui2.Size = new System.Drawing.Size(79, 17);
			this.rbPlagui2.TabIndex = 3;
			this.rbPlagui2.TabStop = true;
			this.rbPlagui2.Text = "Plaguicidas";
			this.rbPlagui2.UseVisualStyleBackColor = true;
			// 
			// rbViaAerea2
			// 
			this.rbViaAerea2.AutoSize = true;
			this.rbViaAerea2.Location = new System.Drawing.Point(189, 31);
			this.rbViaAerea2.Name = "rbViaAerea2";
			this.rbViaAerea2.Size = new System.Drawing.Size(73, 17);
			this.rbViaAerea2.TabIndex = 2;
			this.rbViaAerea2.TabStop = true;
			this.rbViaAerea2.Text = "Vía Áerea";
			this.rbViaAerea2.UseVisualStyleBackColor = true;
			// 
			// rbPerito2
			// 
			this.rbPerito2.AutoSize = true;
			this.rbPerito2.Location = new System.Drawing.Point(118, 31);
			this.rbPerito2.Name = "rbPerito2";
			this.rbPerito2.Size = new System.Drawing.Size(65, 17);
			this.rbPerito2.TabIndex = 1;
			this.rbPerito2.TabStop = true;
			this.rbPerito2.Text = "Peritajes";
			this.rbPerito2.UseVisualStyleBackColor = true;
			// 
			// rbRegente2
			// 
			this.rbRegente2.AutoSize = true;
			this.rbRegente2.Location = new System.Drawing.Point(22, 31);
			this.rbRegente2.Name = "rbRegente2";
			this.rbRegente2.Size = new System.Drawing.Size(76, 17);
			this.rbRegente2.TabIndex = 0;
			this.rbRegente2.TabStop = true;
			this.rbRegente2.Text = "Regencias";
			this.rbRegente2.UseVisualStyleBackColor = true;
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.DarkGray;
			this.panel9.Controls.Add(this.label27);
			this.panel9.Location = new System.Drawing.Point(3, 2);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(509, 21);
			this.panel9.TabIndex = 155;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label27.Location = new System.Drawing.Point(3, 4);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(198, 14);
			this.label27.TabIndex = 0;
			this.label27.Text = "Información del Filtro del Reporte";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbCategorias);
			this.groupBox2.Location = new System.Drawing.Point(39, 77);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(401, 42);
			this.groupBox2.TabIndex = 165;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Categoria";
			// 
			// cmbCategorias
			// 
			this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategorias.FormattingEnabled = true;
			this.cmbCategorias.Location = new System.Drawing.Point(38, 15);
			this.cmbCategorias.Name = "cmbCategorias";
			this.cmbCategorias.Size = new System.Drawing.Size(331, 21);
			this.cmbCategorias.TabIndex = 166;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(453, 342);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(50, 38);
			this.btnBuscar.TabIndex = 159;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbGenero);
			this.groupBox1.Location = new System.Drawing.Point(39, 119);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(401, 42);
			this.groupBox1.TabIndex = 166;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Genero";
			// 
			// cmbGenero
			// 
			this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGenero.FormattingEnabled = true;
			this.cmbGenero.Location = new System.Drawing.Point(38, 15);
			this.cmbGenero.Name = "cmbGenero";
			this.cmbGenero.Size = new System.Drawing.Size(331, 21);
			this.cmbGenero.TabIndex = 166;
			// 
			// gbCobrador
			// 
			this.gbCobrador.Controls.Add(this.cmbCobrador);
			this.gbCobrador.Location = new System.Drawing.Point(39, 161);
			this.gbCobrador.Name = "gbCobrador";
			this.gbCobrador.Size = new System.Drawing.Size(401, 42);
			this.gbCobrador.TabIndex = 167;
			this.gbCobrador.TabStop = false;
			this.gbCobrador.Text = "Cobrador";
			// 
			// cmbCobrador
			// 
			this.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCobrador.FormattingEnabled = true;
			this.cmbCobrador.Location = new System.Drawing.Point(38, 15);
			this.cmbCobrador.Name = "cmbCobrador";
			this.cmbCobrador.Size = new System.Drawing.Size(331, 21);
			this.cmbCobrador.TabIndex = 166;
			// 
			// rbBeneficiario2
			// 
			this.rbBeneficiario2.AutoSize = true;
			this.rbBeneficiario2.Location = new System.Drawing.Point(210, 80);
			this.rbBeneficiario2.Name = "rbBeneficiario2";
			this.rbBeneficiario2.Size = new System.Drawing.Size(85, 17);
			this.rbBeneficiario2.TabIndex = 6;
			this.rbBeneficiario2.TabStop = true;
			this.rbBeneficiario2.Text = "Beneficiarios";
			this.rbBeneficiario2.UseVisualStyleBackColor = true;
			// 
			// chkActivarRangoFechas2
			// 
			this.chkActivarRangoFechas2.AutoSize = true;
			this.chkActivarRangoFechas2.Location = new System.Drawing.Point(354, 19);
			this.chkActivarRangoFechas2.Name = "chkActivarRangoFechas2";
			this.chkActivarRangoFechas2.Size = new System.Drawing.Size(15, 14);
			this.chkActivarRangoFechas2.TabIndex = 141;
			this.chkActivarRangoFechas2.UseVisualStyleBackColor = true;
			this.chkActivarRangoFechas2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkActivarRangoFechas_MouseClick);
			// 
			// frmFiltroColegiado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(515, 395);
			this.Controls.Add(this.gbCobrador);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.grbMoneda);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.panel9);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFiltroColegiado";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Definición de Parámetros";
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.grbMoneda.ResumeLayout(false);
			this.grbMoneda.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.gbCobrador.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbCondiciones;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpPeriodoDesde;
        private System.Windows.Forms.DateTimePicker dtpPeriodoHasta;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox grbMoneda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCategorias;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbGenero;
		private System.Windows.Forms.GroupBox gbCobrador;
		private System.Windows.Forms.ComboBox cmbCobrador;
		private System.Windows.Forms.RadioButton rbRegente2;
		private System.Windows.Forms.RadioButton rbViaAerea2;
		private System.Windows.Forms.RadioButton rbPerito2;
		private System.Windows.Forms.RadioButton rbPlagui2;
		private System.Windows.Forms.RadioButton rbVidaSilvestre2;
		private System.Windows.Forms.RadioButton rbEspecialistas2;
		private System.Windows.Forms.RadioButton rbBeneficiario2;
		private System.Windows.Forms.CheckBox chkActivarRangoFechas2;
	}
}