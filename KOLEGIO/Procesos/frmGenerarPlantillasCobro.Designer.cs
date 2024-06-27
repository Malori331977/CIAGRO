namespace KOLEGIO
{
    partial class frmGenerarPlantillasCobro
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarPlantillasCobro));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnProcesar = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCobrador = new System.Windows.Forms.TextBox();
			this.txtNombreCobrador = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProcesar,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(403, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnProcesar
			// 
			this.btnProcesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
			this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(23, 22);
			this.btnProcesar.Text = "Procesar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
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
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(2, 124);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Cobrador:";
			this.label8.Visible = false;
			// 
			// txtCobrador
			// 
			this.txtCobrador.Location = new System.Drawing.Point(61, 121);
			this.txtCobrador.Name = "txtCobrador";
			this.txtCobrador.Size = new System.Drawing.Size(71, 20);
			this.txtCobrador.TabIndex = 9;
			this.txtCobrador.Visible = false;
			this.txtCobrador.DoubleClick += new System.EventHandler(this.txtCobrador_DoubleClick);
			this.txtCobrador.Enter += new System.EventHandler(this.txtCobrador_Enter);
			this.txtCobrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobrador_KeyDown);
			this.txtCobrador.Leave += new System.EventHandler(this.txtCobrador_Leave);
			// 
			// txtNombreCobrador
			// 
			this.txtNombreCobrador.Location = new System.Drawing.Point(138, 121);
			this.txtNombreCobrador.Name = "txtNombreCobrador";
			this.txtNombreCobrador.ReadOnly = true;
			this.txtNombreCobrador.Size = new System.Drawing.Size(237, 20);
			this.txtNombreCobrador.TabIndex = 10;
			this.txtNombreCobrador.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(31, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(344, 31);
			this.label1.TabIndex = 11;
			this.label1.Text = "Este proceso genera los archivos de cobro para los colegiados con base en el cobr" +
    "ador seleccionado.";
			// 
			// txtDesc
			// 
			this.txtDesc.Location = new System.Drawing.Point(156, 95);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ReadOnly = true;
			this.txtDesc.Size = new System.Drawing.Size(237, 20);
			this.txtDesc.TabIndex = 14;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(61, 95);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(89, 20);
			this.txtCodigo.TabIndex = 13;
			this.txtCodigo.DoubleClick += new System.EventHandler(this.txtCodigo_DoubleClick);
			this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Plantilla:";
			// 
			// frmGenerarPlantillasCobro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 143);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNombreCobrador);
			this.Controls.Add(this.txtCobrador);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(500, 182);
			this.MinimumSize = new System.Drawing.Size(419, 182);
			this.Name = "frmGenerarPlantillasCobro";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generar Plantilla de Cobro";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCobrador;
        private System.Windows.Forms.TextBox txtNombreCobrador;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Label label2;
	}
}