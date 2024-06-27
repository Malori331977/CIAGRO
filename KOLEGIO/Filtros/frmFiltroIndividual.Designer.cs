namespace KOLEGIO
{
    partial class frmFiltroIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroIndividual));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCmbEstad = new System.Windows.Forms.Button();
            this.cmbEstados = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkActivarRangoFechas = new Framework.UserControls.chkSaseg();
            this.dtpPeriodoDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodoHasta = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCantonNombreF = new Framework.UserControls.txtNormal();
            this.txtProvinciaNombreF = new Framework.UserControls.txtNormal();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtProvincia = new Framework.UserControls.txtNormal();
            this.txtDistritoNombreF = new Framework.UserControls.txtNormal();
            this.txtDistrito = new Framework.UserControls.txtNormal();
            this.txtCanton = new Framework.UserControls.txtNormal();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnLimpiarCmbEstad);
            this.groupBox6.Controls.Add(this.cmbEstados);
            this.groupBox6.Location = new System.Drawing.Point(38, 29);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(401, 42);
            this.groupBox6.TabIndex = 160;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Estados";
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
            this.btnLimpiarCmbEstad.Click += new System.EventHandler(this.btnLimpiarCmb_Click);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkActivarRangoFechas);
            this.groupBox5.Controls.Add(this.dtpPeriodoDesde);
            this.groupBox5.Controls.Add(this.dtpPeriodoHasta);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label64);
            this.groupBox5.Location = new System.Drawing.Point(38, 77);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(401, 42);
            this.groupBox5.TabIndex = 157;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rango Fecha Ingreso";
            // 
            // chkActivarRangoFechas
            // 
            this.chkActivarRangoFechas.Checked = false;
            this.chkActivarRangoFechas.Location = new System.Drawing.Point(363, 19);
            this.chkActivarRangoFechas.Name = "chkActivarRangoFechas";
            this.chkActivarRangoFechas.Size = new System.Drawing.Size(32, 17);
            this.chkActivarRangoFechas.TabIndex = 141;
            this.chkActivarRangoFechas.Texto = "";
            this.chkActivarRangoFechas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkActivarRangoFechas_MouseClick);
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
            this.dtpPeriodoHasta.Location = new System.Drawing.Point(246, 16);
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
            this.label64.Location = new System.Drawing.Point(202, 19);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(38, 13);
            this.label64.TabIndex = 133;
            this.label64.Text = "Hasta:";
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
            this.btnBuscar.Location = new System.Drawing.Point(462, 189);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 43);
            this.btnBuscar.TabIndex = 159;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCantonNombreF);
            this.groupBox3.Controls.Add(this.txtProvinciaNombreF);
            this.groupBox3.Controls.Add(this.label43);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Controls.Add(this.label45);
            this.groupBox3.Controls.Add(this.txtProvincia);
            this.groupBox3.Controls.Add(this.txtDistritoNombreF);
            this.groupBox3.Controls.Add(this.txtDistrito);
            this.groupBox3.Controls.Add(this.txtCanton);
            this.groupBox3.Location = new System.Drawing.Point(38, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 100);
            this.groupBox3.TabIndex = 166;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ubicación";
            // 
            // txtCantonNombreF
            // 
            this.txtCantonNombreF.FormatearNumero = false;
            this.txtCantonNombreF.Location = new System.Drawing.Point(159, 42);
            this.txtCantonNombreF.Longitud = 32767;
            this.txtCantonNombreF.Multilinea = false;
            this.txtCantonNombreF.Name = "txtCantonNombreF";
            this.txtCantonNombreF.Password = '\0';
            this.txtCantonNombreF.ReadOnly = true;
            this.txtCantonNombreF.Size = new System.Drawing.Size(210, 21);
            this.txtCantonNombreF.TabIndex = 275;
            this.txtCantonNombreF.Valor = "";
            // 
            // txtProvinciaNombreF
            // 
            this.txtProvinciaNombreF.FormatearNumero = false;
            this.txtProvinciaNombreF.Location = new System.Drawing.Point(159, 15);
            this.txtProvinciaNombreF.Longitud = 32767;
            this.txtProvinciaNombreF.Multilinea = false;
            this.txtProvinciaNombreF.Name = "txtProvinciaNombreF";
            this.txtProvinciaNombreF.Password = '\0';
            this.txtProvinciaNombreF.ReadOnly = true;
            this.txtProvinciaNombreF.Size = new System.Drawing.Size(210, 21);
            this.txtProvinciaNombreF.TabIndex = 274;
            this.txtProvinciaNombreF.Valor = "";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(41, 20);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(54, 13);
            this.label43.TabIndex = 271;
            this.label43.Text = "Provincia:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(51, 46);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 13);
            this.label44.TabIndex = 272;
            this.label44.Text = "Cantón:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(53, 74);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(42, 13);
            this.label45.TabIndex = 273;
            this.label45.Text = "Distrito:";
            // 
            // txtProvincia
            // 
            this.txtProvincia.FormatearNumero = false;
            this.txtProvincia.Location = new System.Drawing.Point(101, 15);
            this.txtProvincia.Longitud = 2;
            this.txtProvincia.Multilinea = false;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Password = '\0';
            this.txtProvincia.ReadOnly = false;
            this.txtProvincia.Size = new System.Drawing.Size(59, 21);
            this.txtProvincia.TabIndex = 267;
            this.txtProvincia.Valor = "";
            this.txtProvincia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvincia_KeyDown);
            this.txtProvincia.Leave += new System.EventHandler(this.txtProvincia_Leave);
            this.txtProvincia.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtProvincia_MouseDoubleClick);
            // 
            // txtDistritoNombreF
            // 
            this.txtDistritoNombreF.FormatearNumero = false;
            this.txtDistritoNombreF.Location = new System.Drawing.Point(159, 69);
            this.txtDistritoNombreF.Longitud = 32767;
            this.txtDistritoNombreF.Multilinea = false;
            this.txtDistritoNombreF.Name = "txtDistritoNombreF";
            this.txtDistritoNombreF.Password = '\0';
            this.txtDistritoNombreF.ReadOnly = true;
            this.txtDistritoNombreF.Size = new System.Drawing.Size(210, 21);
            this.txtDistritoNombreF.TabIndex = 270;
            this.txtDistritoNombreF.Valor = "";
            // 
            // txtDistrito
            // 
            this.txtDistrito.FormatearNumero = false;
            this.txtDistrito.Location = new System.Drawing.Point(101, 69);
            this.txtDistrito.Longitud = 2;
            this.txtDistrito.Multilinea = false;
            this.txtDistrito.Name = "txtDistrito";
            this.txtDistrito.Password = '\0';
            this.txtDistrito.ReadOnly = false;
            this.txtDistrito.Size = new System.Drawing.Size(59, 21);
            this.txtDistrito.TabIndex = 269;
            this.txtDistrito.Valor = "";
            this.txtDistrito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDistrito_KeyDown);
            this.txtDistrito.Leave += new System.EventHandler(this.txtDistrito_Leave);
            this.txtDistrito.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDistrito_MouseDoubleClick);
            // 
            // txtCanton
            // 
            this.txtCanton.FormatearNumero = false;
            this.txtCanton.Location = new System.Drawing.Point(101, 42);
            this.txtCanton.Longitud = 2;
            this.txtCanton.Multilinea = false;
            this.txtCanton.Name = "txtCanton";
            this.txtCanton.Password = '\0';
            this.txtCanton.ReadOnly = false;
            this.txtCanton.Size = new System.Drawing.Size(59, 21);
            this.txtCanton.TabIndex = 268;
            this.txtCanton.Valor = "";
            this.txtCanton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCanton_KeyDown);
            this.txtCanton.Leave += new System.EventHandler(this.txtCanton_Leave);
            this.txtCanton.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCanton_MouseDoubleClick);
            // 
            // frmFiltroIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 237);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiltroIndividual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definición de Parámetros";
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbEstados;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpPeriodoDesde;
        private System.Windows.Forms.DateTimePicker dtpPeriodoHasta;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox3;
        private Framework.UserControls.txtNormal txtCantonNombreF;
        private Framework.UserControls.txtNormal txtProvinciaNombreF;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private Framework.UserControls.txtNormal txtProvincia;
        private Framework.UserControls.txtNormal txtDistritoNombreF;
        private Framework.UserControls.txtNormal txtDistrito;
        private Framework.UserControls.txtNormal txtCanton;
        private System.Windows.Forms.Button btnLimpiarCmbEstad;
        private Framework.UserControls.chkSaseg chkActivarRangoFechas;
    }
}