namespace KOLEGIO
{
    partial class frmFiltroActividades
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroActividades));
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cmbActividades = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.chkActivarRangoFechas = new Framework.UserControls.chkSaseg();
			this.dtpPeriodoDesde = new System.Windows.Forms.DateTimePicker();
			this.dtpPeriodoHasta = new System.Windows.Forms.DateTimePicker();
			this.label29 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label27 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel9.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cmbActividades);
			this.groupBox6.Location = new System.Drawing.Point(39, 50);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(401, 42);
			this.groupBox6.TabIndex = 160;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Actividad";
			// 
			// cmbActividades
			// 
			this.cmbActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbActividades.FormattingEnabled = true;
			this.cmbActividades.Location = new System.Drawing.Point(38, 15);
			this.cmbActividades.Name = "cmbActividades";
			this.cmbActividades.Size = new System.Drawing.Size(331, 21);
			this.cmbActividades.TabIndex = 166;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.chkActivarRangoFechas);
			this.groupBox5.Controls.Add(this.dtpPeriodoDesde);
			this.groupBox5.Controls.Add(this.dtpPeriodoHasta);
			this.groupBox5.Controls.Add(this.label29);
			this.groupBox5.Controls.Add(this.label64);
			this.groupBox5.Location = new System.Drawing.Point(39, 137);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(401, 42);
			this.groupBox5.TabIndex = 157;
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
			this.btnBuscar.Location = new System.Drawing.Point(453, 145);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(50, 38);
			this.btnBuscar.TabIndex = 159;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// frmFiltroActividades
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(515, 195);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.panel9);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFiltroActividades";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Definición de Parámetros";
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbActividades;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpPeriodoDesde;
        private System.Windows.Forms.DateTimePicker dtpPeriodoHasta;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private Framework.UserControls.chkSaseg chkActivarRangoFechas;
	}
}