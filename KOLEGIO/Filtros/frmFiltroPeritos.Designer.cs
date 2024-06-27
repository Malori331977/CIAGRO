namespace KOLEGIO
{
    partial class frmFiltroPeritos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroPeritos));
            this.panel9 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clbTipos = new System.Windows.Forms.CheckedListBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelToolStrip = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoEst = new System.Windows.Forms.ToolStripButton();
            this.btnEliminaEst = new System.Windows.Forms.ToolStripButton();
            this.dgvInstituciones = new System.Windows.Forms.DataGridView();
            this.colCodigoInst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreInst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelToolStrip.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstituciones)).BeginInit();
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
            this.btnBuscar.Location = new System.Drawing.Point(459, 273);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 43);
            this.btnBuscar.TabIndex = 159;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelToolStrip);
            this.groupBox3.Controls.Add(this.dgvInstituciones);
            this.groupBox3.Location = new System.Drawing.Point(40, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 188);
            this.groupBox3.TabIndex = 175;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instituciones a Filtrar";
            // 
            // panelToolStrip
            // 
            this.panelToolStrip.Controls.Add(this.toolStrip3);
            this.panelToolStrip.Location = new System.Drawing.Point(6, 19);
            this.panelToolStrip.Name = "panelToolStrip";
            this.panelToolStrip.Size = new System.Drawing.Size(61, 30);
            this.panelToolStrip.TabIndex = 46;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoEst,
            this.btnEliminaEst});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(61, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnNuevoEst
            // 
            this.btnNuevoEst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoEst.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoEst.Image")));
            this.btnNuevoEst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoEst.Name = "btnNuevoEst";
            this.btnNuevoEst.Size = new System.Drawing.Size(23, 22);
            this.btnNuevoEst.Text = "Nuevo Establecimiento";
            this.btnNuevoEst.Click += new System.EventHandler(this.btnNuevoEst_Click);
            // 
            // btnEliminaEst
            // 
            this.btnEliminaEst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminaEst.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaEst.Image")));
            this.btnEliminaEst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminaEst.Name = "btnEliminaEst";
            this.btnEliminaEst.Size = new System.Drawing.Size(23, 22);
            this.btnEliminaEst.Text = "Eliminar Establecimiento";
            this.btnEliminaEst.Click += new System.EventHandler(this.btnEliminaEst_Click);
            // 
            // dgvInstituciones
            // 
            this.dgvInstituciones.AllowUserToAddRows = false;
            this.dgvInstituciones.AllowUserToDeleteRows = false;
            this.dgvInstituciones.AllowUserToResizeRows = false;
            this.dgvInstituciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInstituciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstituciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstituciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoInst,
            this.colNombreInst});
            this.dgvInstituciones.Location = new System.Drawing.Point(6, 47);
            this.dgvInstituciones.MultiSelect = false;
            this.dgvInstituciones.Name = "dgvInstituciones";
            this.dgvInstituciones.RowHeadersVisible = false;
            this.dgvInstituciones.Size = new System.Drawing.Size(390, 135);
            this.dgvInstituciones.TabIndex = 45;
            this.dgvInstituciones.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInstituciones_CellMouseDoubleClick);
            // 
            // colCodigoInst
            // 
            this.colCodigoInst.FillWeight = 83.35025F;
            this.colCodigoInst.HeaderText = "Codigo";
            this.colCodigoInst.Name = "colCodigoInst";
            // 
            // colNombreInst
            // 
            this.colNombreInst.FillWeight = 182.7481F;
            this.colNombreInst.HeaderText = "Nombre";
            this.colNombreInst.Name = "colNombreInst";
            this.colNombreInst.ReadOnly = true;
            // 
            // frmFiltroPeritos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 321);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiltroPeritos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definición de Parámetros";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panelToolStrip.ResumeLayout(false);
            this.panelToolStrip.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstituciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox clbTipos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panelToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevoEst;
        private System.Windows.Forms.ToolStripButton btnEliminaEst;
        private System.Windows.Forms.DataGridView dgvInstituciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoInst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreInst;
    }
}