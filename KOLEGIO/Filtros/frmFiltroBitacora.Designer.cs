namespace KOLEGIO
{
    partial class frmFiltroBitacora
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroBitacora));
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnLimpiarCmbEstad = new System.Windows.Forms.Button();
			this.cmbUsuarios = new System.Windows.Forms.ComboBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label27 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.groupBox6.SuspendLayout();
			this.panel9.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btnLimpiarCmbEstad);
			this.groupBox6.Controls.Add(this.cmbUsuarios);
			this.groupBox6.Location = new System.Drawing.Point(39, 53);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(401, 42);
			this.groupBox6.TabIndex = 160;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Usuario";
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
			// cmbUsuarios
			// 
			this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUsuarios.FormattingEnabled = true;
			this.cmbUsuarios.Location = new System.Drawing.Point(38, 15);
			this.cmbUsuarios.Name = "cmbUsuarios";
			this.cmbUsuarios.Size = new System.Drawing.Size(307, 21);
			this.cmbUsuarios.TabIndex = 166;
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
			this.btnBuscar.Location = new System.Drawing.Point(462, 61);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(41, 43);
			this.btnBuscar.TabIndex = 159;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// frmFiltroBitacora
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(515, 116);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.panel9);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFiltroBitacora";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Definición de Parámetros";
			this.groupBox6.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private Framework.UserControls.txtNormal txtCantonNombreF;
        private Framework.UserControls.txtNormal txtProvinciaNombreF;
        private Framework.UserControls.txtNormal txtProvincia;
        private Framework.UserControls.txtNormal txtDistritoNombreF;
        private Framework.UserControls.txtNormal txtDistrito;
        private Framework.UserControls.txtNormal txtCanton;
        private System.Windows.Forms.Button btnLimpiarCmbEstad;
        private Framework.UserControls.chkSaseg chkActivarRangoFechas;
    }
}