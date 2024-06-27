namespace KOLEGIO
{
    partial class frmFiltroRegentes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroRegentes));
			this.panel9 = new System.Windows.Forms.Panel();
			this.label27 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.clbTipos = new System.Windows.Forms.CheckedListBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.panel9.SuspendLayout();
			this.groupBox4.SuspendLayout();
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
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.clbTipos);
			this.groupBox4.Location = new System.Drawing.Point(41, 29);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(401, 91);
			this.groupBox4.TabIndex = 161;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Tipos";
			// 
			// clbTipos
			// 
			this.clbTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.clbTipos.FormattingEnabled = true;
			this.clbTipos.Location = new System.Drawing.Point(6, 19);
			this.clbTipos.Name = "clbTipos";
			this.clbTipos.Size = new System.Drawing.Size(389, 60);
			this.clbTipos.TabIndex = 139;
			this.clbTipos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbTipos_ItemCheck);
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
			this.btnBuscar.Location = new System.Drawing.Point(459, 85);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(41, 43);
			this.btnBuscar.TabIndex = 159;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// frmFiltroRegentes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(512, 133);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.panel9);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFiltroRegentes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Definición de Parámetros";
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox clbTipos;
    }
}