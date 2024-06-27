namespace KOLEGIO
{
    partial class frmMachotesEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachotesEdicion));
            this.panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.colArticuloFms = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAgregarCampo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarCampo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.txtNombre = new Framework.UserControls.txtNormal();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFrec = new Framework.UserControls.txtNormal();
            this.txtFrecDescripcion = new Framework.UserControls.txtNormal();
            this.labelFrec = new System.Windows.Forms.Label();
            this.chkAplicaClienteERP = new Framework.UserControls.chkSaseg();
            this.lblDescTotalPlantilla = new System.Windows.Forms.Label();
            this.lblTotalPlantilla = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.toolStrip8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Size = new System.Drawing.Size(619, 467);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.lblTotalPlantilla);
            this.tpBasicos.Controls.Add(this.lblDescTotalPlantilla);
            this.tpBasicos.Controls.Add(this.chkAplicaClienteERP);
            this.tpBasicos.Controls.Add(this.labelFrec);
            this.tpBasicos.Controls.Add(this.txtFrecDescripcion);
            this.tpBasicos.Controls.Add(this.txtFrec);
            this.tpBasicos.Controls.Add(this.groupBox1);
            this.tpBasicos.Controls.Add(this.txtNombre);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.panel);
            this.tpBasicos.Size = new System.Drawing.Size(611, 441);
            this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtFrec, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtFrecDescripcion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.labelFrec, 0);
            this.tpBasicos.Controls.SetChildIndex(this.chkAplicaClienteERP, 0);
            this.tpBasicos.Controls.SetChildIndex(this.lblDescTotalPlantilla, 0);
            this.tpBasicos.Controls.SetChildIndex(this.lblTotalPlantilla, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(611, 441);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(605, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(605, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(611, 441);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(605, 21);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(665, 21);
            this.panel.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Datos del Criterio de Evaluación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(108, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Código:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(104, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(164, 48);
            this.txtCodigo.Longitud = 4;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(95, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Valor = "";
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.AllowUserToResizeRows = false;
            this.dgvArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArticuloFms,
            this.colArticulo,
            this.colDescripcion,
            this.colPrecio});
            this.dgvArticulos.Location = new System.Drawing.Point(3, 43);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersVisible = false;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(410, 180);
            this.dgvArticulos.TabIndex = 310;
            this.dgvArticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellClick);
            // 
            // colArticuloFms
            // 
            this.colArticuloFms.HeaderText = "FMS";
            this.colArticuloFms.Name = "colArticuloFms";
            this.colArticuloFms.ReadOnly = true;
            // 
            // colArticulo
            // 
            this.colArticulo.HeaderText = "Código";
            this.colArticulo.Name = "colArticulo";
            this.colArticulo.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(55, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(58, 25);
            this.miniToolStrip.TabIndex = 306;
            // 
            // btnAgregarCampo
            // 
            this.btnAgregarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCampo.Image")));
            this.btnAgregarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarCampo.Name = "btnAgregarCampo";
            this.btnAgregarCampo.Size = new System.Drawing.Size(23, 22);
            this.btnAgregarCampo.Text = "Nuevo";
            this.btnAgregarCampo.Click += new System.EventHandler(this.btnAgregarCampo_Click);
            // 
            // btnEliminarCampo
            // 
            this.btnEliminarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCampo.Image")));
            this.btnEliminarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarCampo.Name = "btnEliminarCampo";
            this.btnEliminarCampo.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarCampo.Text = "Eliminar";
            this.btnEliminarCampo.Click += new System.EventHandler(this.btnEliminarCampo_Click);
            // 
            // toolStrip8
            // 
            this.toolStrip8.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarCampo,
            this.btnEliminarCampo});
            this.toolStrip8.Location = new System.Drawing.Point(3, 15);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(58, 25);
            this.toolStrip8.TabIndex = 306;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.FormatearNumero = false;
            this.txtNombre.Location = new System.Drawing.Point(164, 75);
            this.txtNombre.Longitud = 50;
            this.txtNombre.Multilinea = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Password = '\0';
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Size = new System.Drawing.Size(347, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Valor = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.toolStrip8);
            this.groupBox1.Controls.Add(this.dgvArticulos);
            this.groupBox1.Location = new System.Drawing.Point(95, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 229);
            this.groupBox1.TabIndex = 311;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Artículos";
            // 
            // txtFrec
            // 
            this.txtFrec.FormatearNumero = false;
            this.txtFrec.Location = new System.Drawing.Point(163, 102);
            this.txtFrec.Longitud = 4;
            this.txtFrec.Multilinea = false;
            this.txtFrec.Name = "txtFrec";
            this.txtFrec.Password = '\0';
            this.txtFrec.ReadOnly = false;
            this.txtFrec.Size = new System.Drawing.Size(95, 21);
            this.txtFrec.TabIndex = 312;
            this.txtFrec.Valor = "";
            this.txtFrec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrecuencia_KeyDown);
            this.txtFrec.Leave += new System.EventHandler(this.txtFrecuencia_Leave);
            this.txtFrec.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtFrecuencia_MouseDoubleClick);
            // 
            // txtFrecDescripcion
            // 
            this.txtFrecDescripcion.FormatearNumero = false;
            this.txtFrecDescripcion.Location = new System.Drawing.Point(264, 102);
            this.txtFrecDescripcion.Longitud = 4;
            this.txtFrecDescripcion.Multilinea = false;
            this.txtFrecDescripcion.Name = "txtFrecDescripcion";
            this.txtFrecDescripcion.Password = '\0';
            this.txtFrecDescripcion.ReadOnly = true;
            this.txtFrecDescripcion.Size = new System.Drawing.Size(247, 21);
            this.txtFrecDescripcion.TabIndex = 313;
            this.txtFrecDescripcion.Valor = "";
            // 
            // labelFrec
            // 
            this.labelFrec.AutoSize = true;
            this.labelFrec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrec.Location = new System.Drawing.Point(84, 106);
            this.labelFrec.Name = "labelFrec";
            this.labelFrec.Size = new System.Drawing.Size(74, 13);
            this.labelFrec.TabIndex = 315;
            this.labelFrec.Text = "Frecuencia:";
            // 
            // chkAplicaClienteERP
            // 
            this.chkAplicaClienteERP.Checked = false;
            this.chkAplicaClienteERP.Location = new System.Drawing.Point(163, 129);
            this.chkAplicaClienteERP.Name = "chkAplicaClienteERP";
            this.chkAplicaClienteERP.Size = new System.Drawing.Size(216, 35);
            this.chkAplicaClienteERP.TabIndex = 316;
            this.chkAplicaClienteERP.Texto = "Aplica para Generación de Cliente";
            // 
            // lblDescTotalPlantilla
            // 
            this.lblDescTotalPlantilla.AutoSize = true;
            this.lblDescTotalPlantilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescTotalPlantilla.Location = new System.Drawing.Point(420, 423);
            this.lblDescTotalPlantilla.Name = "lblDescTotalPlantilla";
            this.lblDescTotalPlantilla.Size = new System.Drawing.Size(40, 13);
            this.lblDescTotalPlantilla.TabIndex = 317;
            this.lblDescTotalPlantilla.Text = "Total:";
            // 
            // lblTotalPlantilla
            // 
            this.lblTotalPlantilla.AutoSize = true;
            this.lblTotalPlantilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPlantilla.Location = new System.Drawing.Point(455, 423);
            this.lblTotalPlantilla.Name = "lblTotalPlantilla";
            this.lblTotalPlantilla.Size = new System.Drawing.Size(14, 13);
            this.lblTotalPlantilla.TabIndex = 318;
            this.lblTotalPlantilla.Text = "0";
            // 
            // frmMachotesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 559);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMachotesEdicion";
            this.Text = "Plantillas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMachotesEdicion_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpBasicos.ResumeLayout(false);
            this.tpBasicos.PerformLayout();
            this.tpAdmin.ResumeLayout(false);
            this.tpAdmin.PerformLayout();
            this.panelBasicos.ResumeLayout(false);
            this.panelBasicos.PerformLayout();
            this.tpAdjuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtCodigo;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnAgregarCampo;
        private System.Windows.Forms.ToolStripButton btnEliminarCampo;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private Framework.UserControls.txtNormal txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.UserControls.txtNormal txtFrecDescripcion;
        private Framework.UserControls.txtNormal txtFrec;
        private System.Windows.Forms.Label labelFrec;
        private Framework.UserControls.chkSaseg chkAplicaClienteERP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colArticuloFms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.Label lblTotalPlantilla;
        private System.Windows.Forms.Label lblDescTotalPlantilla;
    }
}