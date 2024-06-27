namespace Framework
{
    partial class frmFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltro));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSel = new System.Windows.Forms.ToolStripButton();
            this.btnTod = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnSalir1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSel,
            this.btnTod,
            this.toolStripSeparator1,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(485, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSel
            // 
            this.btnSel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSel.Image = ((System.Drawing.Image)(resources.GetObject("btnSel.Image")));
            this.btnSel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(23, 22);
            this.btnSel.Text = "Seleccionar";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnTod
            // 
            this.btnTod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTod.Image = ((System.Drawing.Image)(resources.GetObject("btnTod.Image")));
            this.btnTod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTod.Name = "btnTod";
            this.btnTod.Size = new System.Drawing.Size(23, 22);
            this.btnTod.Text = "Todos";
            this.btnTod.Click += new System.EventHandler(this.btnTod_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeleccionar.Location = new System.Drawing.Point(113, 292);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTodos.Location = new System.Drawing.Point(194, 292);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(75, 23);
            this.btnTodos.TabIndex = 5;
            this.btnTodos.Text = "Todos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir1.Location = new System.Drawing.Point(275, 292);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(75, 23);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "Salir";
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 357);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelFiltro);
            this.tabPage1.Controls.Add(this.btnSeleccionar);
            this.tabPage1.Controls.Add(this.btnSalir1);
            this.tabPage1.Controls.Add(this.btnTodos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parametros";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelFiltro
            // 
            this.panelFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelFiltro.Controls.Add(this.lblFiltro);
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Location = new System.Drawing.Point(3, 3);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(471, 21);
            this.panelFiltro.TabIndex = 7;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFiltro.Location = new System.Drawing.Point(3, 3);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(89, 14);
            this.lblFiltro.TabIndex = 0;
            this.lblFiltro.Text = "Datos de Filtro";
            // 
            // frmFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 382);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFiltro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtrar";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        protected System.Windows.Forms.Button btnSeleccionar;
        protected System.Windows.Forms.Button btnTodos;
        protected System.Windows.Forms.Button btnSalir1;
        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.Panel panelFiltro;
        protected System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ToolStripButton btnSel;
        private System.Windows.Forms.ToolStripButton btnTod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}