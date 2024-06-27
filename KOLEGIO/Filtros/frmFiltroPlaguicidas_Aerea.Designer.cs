namespace KOLEGIO
{
    partial class frmFiltroPlaguicidas_Aerea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroPlaguicidas_Aerea));
            this.panel9 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelToolStrip = new System.Windows.Forms.Panel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoEst = new System.Windows.Forms.ToolStripButton();
            this.btnEliminaEst = new System.Windows.Forms.ToolStripButton();
            this.dgvColegiados = new System.Windows.Forms.DataGridView();
            this.colIdColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNColegiado = new Framework.UserControls.txtNormal();
            this.txtIdColegiado = new Framework.UserControls.txtNormal();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreColegiado = new Framework.UserControls.txtNormal();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAerea = new Framework.UserControls.rbSaseg();
            this.rbPlagui = new Framework.UserControls.rbSaseg();
            this.panel9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelToolStrip.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkGray;
            this.panel9.Controls.Add(this.label27);
            this.panel9.Location = new System.Drawing.Point(3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(550, 21);
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
            this.btnBuscar.Location = new System.Drawing.Point(503, 306);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 43);
            this.btnBuscar.TabIndex = 159;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelToolStrip);
            this.groupBox3.Controls.Add(this.dgvColegiados);
            this.groupBox3.Location = new System.Drawing.Point(11, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 214);
            this.groupBox3.TabIndex = 166;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Colegiados a Filtrar";
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
            // dgvColegiados
            // 
            this.dgvColegiados.AllowUserToAddRows = false;
            this.dgvColegiados.AllowUserToDeleteRows = false;
            this.dgvColegiados.AllowUserToResizeRows = false;
            this.dgvColegiados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColegiados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColegiados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColegiados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdColegiado,
            this.colNumColegiado,
            this.colNombre});
            this.dgvColegiados.Location = new System.Drawing.Point(6, 47);
            this.dgvColegiados.MultiSelect = false;
            this.dgvColegiados.Name = "dgvColegiados";
            this.dgvColegiados.RowHeadersVisible = false;
            this.dgvColegiados.Size = new System.Drawing.Size(476, 161);
            this.dgvColegiados.TabIndex = 45;
            // 
            // colIdColegiado
            // 
            this.colIdColegiado.FillWeight = 76.14214F;
            this.colIdColegiado.HeaderText = "IdColegiado";
            this.colIdColegiado.Name = "colIdColegiado";
            this.colIdColegiado.ReadOnly = true;
            this.colIdColegiado.Visible = false;
            // 
            // colNumColegiado
            // 
            this.colNumColegiado.FillWeight = 83.35025F;
            this.colNumColegiado.HeaderText = "N° Colegiado";
            this.colNumColegiado.Name = "colNumColegiado";
            // 
            // colNombre
            // 
            this.colNombre.FillWeight = 182.7481F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // txtNColegiado
            // 
            this.txtNColegiado.FormatearNumero = false;
            this.txtNColegiado.Location = new System.Drawing.Point(100, 94);
            this.txtNColegiado.Longitud = 30;
            this.txtNColegiado.Multilinea = false;
            this.txtNColegiado.Name = "txtNColegiado";
            this.txtNColegiado.Password = '\0';
            this.txtNColegiado.ReadOnly = false;
            this.txtNColegiado.Size = new System.Drawing.Size(112, 21);
            this.txtNColegiado.TabIndex = 170;
            this.txtNColegiado.Valor = "";
            this.txtNColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNColegiado_KeyDown);
            this.txtNColegiado.Leave += new System.EventHandler(this.txtNColegiado_Leave);
            this.txtNColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNColegiado_MouseDoubleClick);
            // 
            // txtIdColegiado
            // 
            this.txtIdColegiado.FormatearNumero = false;
            this.txtIdColegiado.Location = new System.Drawing.Point(100, 67);
            this.txtIdColegiado.Longitud = 30;
            this.txtIdColegiado.Multilinea = false;
            this.txtIdColegiado.Name = "txtIdColegiado";
            this.txtIdColegiado.Password = '\0';
            this.txtIdColegiado.ReadOnly = false;
            this.txtIdColegiado.Size = new System.Drawing.Size(112, 21);
            this.txtIdColegiado.TabIndex = 169;
            this.txtIdColegiado.Valor = "";
            this.txtIdColegiado.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 168;
            this.label7.Text = "Nº Colegiado:";
            // 
            // txtNombreColegiado
            // 
            this.txtNombreColegiado.FormatearNumero = false;
            this.txtNombreColegiado.Location = new System.Drawing.Point(214, 94);
            this.txtNombreColegiado.Longitud = 30;
            this.txtNombreColegiado.Multilinea = false;
            this.txtNombreColegiado.Name = "txtNombreColegiado";
            this.txtNombreColegiado.Password = '\0';
            this.txtNombreColegiado.ReadOnly = true;
            this.txtNombreColegiado.Size = new System.Drawing.Size(285, 21);
            this.txtNombreColegiado.TabIndex = 167;
            this.txtNombreColegiado.Valor = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAerea);
            this.groupBox1.Controls.Add(this.rbPlagui);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 58);
            this.groupBox1.TabIndex = 171;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rbAerea
            // 
            this.rbAerea.Checked = false;
            this.rbAerea.Location = new System.Drawing.Point(354, 19);
            this.rbAerea.Name = "rbAerea";
            this.rbAerea.Size = new System.Drawing.Size(90, 18);
            this.rbAerea.TabIndex = 1;
            this.rbAerea.Texto = "Vía Aérea";
            this.rbAerea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbAerea_MouseClick);
            // 
            // rbPlagui
            // 
            this.rbPlagui.Checked = false;
            this.rbPlagui.Location = new System.Drawing.Point(71, 19);
            this.rbPlagui.Name = "rbPlagui";
            this.rbPlagui.Size = new System.Drawing.Size(90, 18);
            this.rbPlagui.TabIndex = 0;
            this.rbPlagui.Texto = "Plaguicidas";
            this.rbPlagui.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPlagui_MouseClick);
            // 
            // frmFiltroPlaguicidas_Aerea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(556, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNColegiado);
            this.Controls.Add(this.txtIdColegiado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNombreColegiado);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiltroPlaguicidas_Aerea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definición de Parámetros";
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panelToolStrip.ResumeLayout(false);
            this.panelToolStrip.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox3;
        private Framework.UserControls.txtNormal txtNColegiado;
        private Framework.UserControls.txtNormal txtIdColegiado;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtNombreColegiado;
        private System.Windows.Forms.Panel panelToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevoEst;
        private System.Windows.Forms.ToolStripButton btnEliminaEst;
        private System.Windows.Forms.DataGridView dgvColegiados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.UserControls.rbSaseg rbAerea;
        private Framework.UserControls.rbSaseg rbPlagui;
    }
}