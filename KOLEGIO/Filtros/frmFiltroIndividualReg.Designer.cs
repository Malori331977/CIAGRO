namespace KOLEGIO
{
    partial class frmFiltroIndividualReg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroIndividualReg));
			this.panel9 = new System.Windows.Forms.Panel();
			this.label27 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnLimpiarCmbCateg = new System.Windows.Forms.Button();
			this.cmbCategorias = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnLimpiarCmbEstad = new System.Windows.Forms.Button();
			this.cmbEstados = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.chkActivarRangoFechasEst = new Framework.UserControls.chkSaseg();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.grbCole = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnLimpiarCmbCategCole = new System.Windows.Forms.Button();
			this.cmbCategoriasCole = new System.Windows.Forms.ComboBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnLimpiarCmbCondi = new System.Windows.Forms.Button();
			this.cmbCondiciones = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.chkActivarRangoFechas = new Framework.UserControls.chkSaseg();
			this.dtpPeriodoDesde = new System.Windows.Forms.DateTimePicker();
			this.dtpPeriodoHasta = new System.Windows.Forms.DateTimePicker();
			this.label29 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.grbTipoReporte = new System.Windows.Forms.GroupBox();
			this.rbPorProvincia = new Framework.UserControls.rbSaseg();
			this.rbLinea = new Framework.UserControls.rbSaseg();
			this.rbGeneral = new Framework.UserControls.rbSaseg();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.btnLimpiarEstadoReg = new System.Windows.Forms.Button();
			this.cmbEstadosReg = new System.Windows.Forms.ComboBox();
			this.panel9.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.grbCole.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.grbTipoReporte.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
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
			// btnBuscar
			// 
			this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
			this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(453, 435);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(50, 38);
			this.btnBuscar.TabIndex = 159;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox7);
			this.groupBox1.Location = new System.Drawing.Point(12, 301);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(441, 175);
			this.groupBox1.TabIndex = 167;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Establecimiento";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnLimpiarCmbCateg);
			this.groupBox3.Controls.Add(this.cmbCategorias);
			this.groupBox3.Location = new System.Drawing.Point(20, 67);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(401, 42);
			this.groupBox3.TabIndex = 168;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Categoria";
			// 
			// btnLimpiarCmbCateg
			// 
			this.btnLimpiarCmbCateg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCmbCateg.BackgroundImage")));
			this.btnLimpiarCmbCateg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnLimpiarCmbCateg.Location = new System.Drawing.Point(351, 13);
			this.btnLimpiarCmbCateg.Name = "btnLimpiarCmbCateg";
			this.btnLimpiarCmbCateg.Size = new System.Drawing.Size(27, 23);
			this.btnLimpiarCmbCateg.TabIndex = 168;
			this.btnLimpiarCmbCateg.UseVisualStyleBackColor = true;
			this.btnLimpiarCmbCateg.Click += new System.EventHandler(this.btnLimpiarCmbCateg_Click);
			// 
			// cmbCategorias
			// 
			this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategorias.FormattingEnabled = true;
			this.cmbCategorias.Location = new System.Drawing.Point(38, 15);
			this.cmbCategorias.Name = "cmbCategorias";
			this.cmbCategorias.Size = new System.Drawing.Size(307, 21);
			this.cmbCategorias.TabIndex = 166;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnLimpiarCmbEstad);
			this.groupBox4.Controls.Add(this.cmbEstados);
			this.groupBox4.Location = new System.Drawing.Point(20, 19);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(401, 42);
			this.groupBox4.TabIndex = 167;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Estados";
			// 
			// btnLimpiarCmbEstad
			// 
			this.btnLimpiarCmbEstad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCmbEstad.BackgroundImage")));
			this.btnLimpiarCmbEstad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnLimpiarCmbEstad.Location = new System.Drawing.Point(352, 15);
			this.btnLimpiarCmbEstad.Name = "btnLimpiarCmbEstad";
			this.btnLimpiarCmbEstad.Size = new System.Drawing.Size(27, 23);
			this.btnLimpiarCmbEstad.TabIndex = 167;
			this.btnLimpiarCmbEstad.UseVisualStyleBackColor = true;
			this.btnLimpiarCmbEstad.Click += new System.EventHandler(this.btnLimpiarCmbEst_Click);
			// 
			// cmbEstados
			// 
			this.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEstados.FormattingEnabled = true;
			this.cmbEstados.Location = new System.Drawing.Point(38, 15);
			this.cmbEstados.Name = "cmbEstados";
			this.cmbEstados.Size = new System.Drawing.Size(307, 21);
			this.cmbEstados.TabIndex = 166;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.chkActivarRangoFechasEst);
			this.groupBox7.Controls.Add(this.dateTimePicker1);
			this.groupBox7.Controls.Add(this.dateTimePicker2);
			this.groupBox7.Controls.Add(this.label1);
			this.groupBox7.Controls.Add(this.label2);
			this.groupBox7.Location = new System.Drawing.Point(20, 115);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(401, 42);
			this.groupBox7.TabIndex = 166;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Rango Fecha Ingreso";
			// 
			// chkActivarRangoFechasEst
			// 
			this.chkActivarRangoFechasEst.Checked = false;
			this.chkActivarRangoFechasEst.Location = new System.Drawing.Point(363, 19);
			this.chkActivarRangoFechasEst.Name = "chkActivarRangoFechasEst";
			this.chkActivarRangoFechasEst.Size = new System.Drawing.Size(32, 17);
			this.chkActivarRangoFechasEst.TabIndex = 141;
			this.chkActivarRangoFechasEst.Texto = "";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Enabled = false;
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(81, 16);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
			this.dateTimePicker1.TabIndex = 140;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Enabled = false;
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new System.Drawing.Point(246, 16);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(99, 20);
			this.dateTimePicker2.TabIndex = 139;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 132;
			this.label1.Text = "Desde:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(202, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 133;
			this.label2.Text = "Hasta:";
			// 
			// grbCole
			// 
			this.grbCole.Controls.Add(this.groupBox8);
			this.grbCole.Controls.Add(this.groupBox2);
			this.grbCole.Controls.Add(this.groupBox6);
			this.grbCole.Controls.Add(this.groupBox5);
			this.grbCole.Location = new System.Drawing.Point(12, 82);
			this.grbCole.Name = "grbCole";
			this.grbCole.Size = new System.Drawing.Size(441, 213);
			this.grbCole.TabIndex = 166;
			this.grbCole.TabStop = false;
			this.grbCole.Text = "Colegiado";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnLimpiarCmbCategCole);
			this.groupBox2.Controls.Add(this.cmbCategoriasCole);
			this.groupBox2.Location = new System.Drawing.Point(20, 114);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(401, 42);
			this.groupBox2.TabIndex = 171;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Categoria";
			// 
			// btnLimpiarCmbCategCole
			// 
			this.btnLimpiarCmbCategCole.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCmbCategCole.BackgroundImage")));
			this.btnLimpiarCmbCategCole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnLimpiarCmbCategCole.Location = new System.Drawing.Point(351, 15);
			this.btnLimpiarCmbCategCole.Name = "btnLimpiarCmbCategCole";
			this.btnLimpiarCmbCategCole.Size = new System.Drawing.Size(27, 23);
			this.btnLimpiarCmbCategCole.TabIndex = 168;
			this.btnLimpiarCmbCategCole.UseVisualStyleBackColor = true;
			this.btnLimpiarCmbCategCole.Click += new System.EventHandler(this.btnLimpiarCmbCategCole_Click);
			// 
			// cmbCategoriasCole
			// 
			this.cmbCategoriasCole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategoriasCole.FormattingEnabled = true;
			this.cmbCategoriasCole.Location = new System.Drawing.Point(38, 15);
			this.cmbCategoriasCole.Name = "cmbCategoriasCole";
			this.cmbCategoriasCole.Size = new System.Drawing.Size(307, 21);
			this.cmbCategoriasCole.TabIndex = 166;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btnLimpiarCmbCondi);
			this.groupBox6.Controls.Add(this.cmbCondiciones);
			this.groupBox6.Location = new System.Drawing.Point(20, 66);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(401, 42);
			this.groupBox6.TabIndex = 170;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Condición";
			// 
			// btnLimpiarCmbCondi
			// 
			this.btnLimpiarCmbCondi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCmbCondi.BackgroundImage")));
			this.btnLimpiarCmbCondi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnLimpiarCmbCondi.Location = new System.Drawing.Point(351, 13);
			this.btnLimpiarCmbCondi.Name = "btnLimpiarCmbCondi";
			this.btnLimpiarCmbCondi.Size = new System.Drawing.Size(27, 23);
			this.btnLimpiarCmbCondi.TabIndex = 168;
			this.btnLimpiarCmbCondi.UseVisualStyleBackColor = true;
			this.btnLimpiarCmbCondi.Click += new System.EventHandler(this.btnLimpiarCmbCondi_Click);
			// 
			// cmbCondiciones
			// 
			this.cmbCondiciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondiciones.FormattingEnabled = true;
			this.cmbCondiciones.Location = new System.Drawing.Point(38, 15);
			this.cmbCondiciones.Name = "cmbCondiciones";
			this.cmbCondiciones.Size = new System.Drawing.Size(307, 21);
			this.cmbCondiciones.TabIndex = 166;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.chkActivarRangoFechas);
			this.groupBox5.Controls.Add(this.dtpPeriodoDesde);
			this.groupBox5.Controls.Add(this.dtpPeriodoHasta);
			this.groupBox5.Controls.Add(this.label29);
			this.groupBox5.Controls.Add(this.label64);
			this.groupBox5.Location = new System.Drawing.Point(20, 162);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(401, 42);
			this.groupBox5.TabIndex = 169;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Rango de Nacimiento";
			// 
			// chkActivarRangoFechas
			// 
			this.chkActivarRangoFechas.Checked = false;
			this.chkActivarRangoFechas.Location = new System.Drawing.Point(363, 18);
			this.chkActivarRangoFechas.Name = "chkActivarRangoFechas";
			this.chkActivarRangoFechas.Size = new System.Drawing.Size(32, 17);
			this.chkActivarRangoFechas.TabIndex = 142;
			this.chkActivarRangoFechas.Texto = "";
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
			// grbTipoReporte
			// 
			this.grbTipoReporte.Controls.Add(this.rbPorProvincia);
			this.grbTipoReporte.Controls.Add(this.rbLinea);
			this.grbTipoReporte.Controls.Add(this.rbGeneral);
			this.grbTipoReporte.Location = new System.Drawing.Point(12, 32);
			this.grbTipoReporte.Name = "grbTipoReporte";
			this.grbTipoReporte.Size = new System.Drawing.Size(441, 44);
			this.grbTipoReporte.TabIndex = 168;
			this.grbTipoReporte.TabStop = false;
			this.grbTipoReporte.Text = "Tipo Reporte";
			// 
			// rbPorProvincia
			// 
			this.rbPorProvincia.Checked = false;
			this.rbPorProvincia.Location = new System.Drawing.Point(289, 19);
			this.rbPorProvincia.Name = "rbPorProvincia";
			this.rbPorProvincia.Size = new System.Drawing.Size(91, 18);
			this.rbPorProvincia.TabIndex = 2;
			this.rbPorProvincia.Texto = "Por Provincia";
			// 
			// rbLinea
			// 
			this.rbLinea.Checked = false;
			this.rbLinea.Location = new System.Drawing.Point(178, 19);
			this.rbLinea.Name = "rbLinea";
			this.rbLinea.Size = new System.Drawing.Size(64, 18);
			this.rbLinea.TabIndex = 1;
			this.rbLinea.Texto = "En Linea";
			// 
			// rbGeneral
			// 
			this.rbGeneral.Checked = true;
			this.rbGeneral.Location = new System.Drawing.Point(63, 19);
			this.rbGeneral.Name = "rbGeneral";
			this.rbGeneral.Size = new System.Drawing.Size(119, 18);
			this.rbGeneral.TabIndex = 0;
			this.rbGeneral.Texto = "Por Registro";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.btnLimpiarEstadoReg);
			this.groupBox8.Controls.Add(this.cmbEstadosReg);
			this.groupBox8.Location = new System.Drawing.Point(20, 18);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(401, 42);
			this.groupBox8.TabIndex = 168;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Estado Regencia";
			// 
			// btnLimpiarEstadoReg
			// 
			this.btnLimpiarEstadoReg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiarEstadoReg.BackgroundImage")));
			this.btnLimpiarEstadoReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnLimpiarEstadoReg.Location = new System.Drawing.Point(352, 15);
			this.btnLimpiarEstadoReg.Name = "btnLimpiarEstadoReg";
			this.btnLimpiarEstadoReg.Size = new System.Drawing.Size(27, 23);
			this.btnLimpiarEstadoReg.TabIndex = 167;
			this.btnLimpiarEstadoReg.UseVisualStyleBackColor = true;
			this.btnLimpiarEstadoReg.Click += new System.EventHandler(this.btnLimpiarEstadoReg_Click);
			// 
			// cmbEstadosReg
			// 
			this.cmbEstadosReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEstadosReg.FormattingEnabled = true;
			this.cmbEstadosReg.Location = new System.Drawing.Point(38, 15);
			this.cmbEstadosReg.Name = "cmbEstadosReg";
			this.cmbEstadosReg.Size = new System.Drawing.Size(307, 21);
			this.cmbEstadosReg.TabIndex = 166;
			// 
			// frmFiltroIndividualReg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(515, 488);
			this.Controls.Add(this.grbTipoReporte);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grbCole);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.panel9);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFiltroIndividualReg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Definición de Parámetros";
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.grbCole.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.grbTipoReporte.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLimpiarCmbCateg;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLimpiarCmbEstad;
        private System.Windows.Forms.ComboBox cmbEstados;
        private System.Windows.Forms.GroupBox groupBox7;
        private Framework.UserControls.chkSaseg chkActivarRangoFechasEst;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbCole;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCategoriasCole;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbCondiciones;
        private System.Windows.Forms.GroupBox groupBox5;
        private Framework.UserControls.chkSaseg chkActivarRangoFechas;
        private System.Windows.Forms.DateTimePicker dtpPeriodoDesde;
        private System.Windows.Forms.DateTimePicker dtpPeriodoHasta;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button btnLimpiarCmbCategCole;
        private System.Windows.Forms.Button btnLimpiarCmbCondi;
        private System.Windows.Forms.GroupBox grbTipoReporte;
        private Framework.UserControls.rbSaseg rbLinea;
        private Framework.UserControls.rbSaseg rbGeneral;
        private Framework.UserControls.rbSaseg rbPorProvincia;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button btnLimpiarEstadoReg;
		private System.Windows.Forms.ComboBox cmbEstadosReg;
	}
}