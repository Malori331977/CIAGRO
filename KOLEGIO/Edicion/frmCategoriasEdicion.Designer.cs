namespace KOLEGIO
{
    partial class frmCategoriasEdicion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoriasEdicion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.rtbDescripcion = new Framework.UserControls.rtbSaseg();
            this.txtNombre = new Framework.UserControls.txtNormal();
            this.tpArticulos = new System.Windows.Forms.TabPage();
            this.gbArticulos = new System.Windows.Forms.GroupBox();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.btnAgregarCampo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarCampo = new System.Windows.Forms.ToolStripButton();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.colArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpArticulosEstable = new System.Windows.Forms.TabPage();
            this.grbArtEstable = new System.Windows.Forms.GroupBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoArtEstable = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarArtEstable = new System.Windows.Forms.ToolStripButton();
            this.dgvArtEstablecimiento = new System.Windows.Forms.DataGridView();
            this.colCodArtEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescArtEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioArtEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.tpArticulos.SuspendLayout();
            this.gbArticulos.SuspendLayout();
            this.toolStrip8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.tpArticulosEstable.SuspendLayout();
            this.grbArtEstable.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtEstablecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpArticulos);
            this.tabControl.Controls.Add(this.tpArticulosEstable);
            this.tabControl.Size = new System.Drawing.Size(639, 291);
            this.tabControl.Controls.SetChildIndex(this.tpArticulosEstable, 0);
            this.tabControl.Controls.SetChildIndex(this.tpArticulos, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
            this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.rtbDescripcion);
            this.tpBasicos.Controls.Add(this.txtNombre);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.panel);
            this.tpBasicos.Size = new System.Drawing.Size(631, 265);
            this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbDescripcion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(631, 265);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(625, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(625, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(631, 265);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(625, 21);
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
            this.label8.Location = new System.Drawing.Point(108, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Código:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(104, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nombre:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(92, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Descripción:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(164, 78);
            this.txtCodigo.Longitud = 4;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(124, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Valor = "";
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.Location = new System.Drawing.Point(164, 133);
            this.rtbDescripcion.Longitud = 500;
            this.rtbDescripcion.Mayusculas = false;
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = false;
            this.rtbDescripcion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbDescripcion.Size = new System.Drawing.Size(343, 76);
            this.rtbDescripcion.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.FormatearNumero = false;
            this.txtNombre.Location = new System.Drawing.Point(164, 106);
            this.txtNombre.Longitud = 50;
            this.txtNombre.Multilinea = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Password = '\0';
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Size = new System.Drawing.Size(343, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Valor = "";
            // 
            // tpArticulos
            // 
            this.tpArticulos.Controls.Add(this.gbArticulos);
            this.tpArticulos.Location = new System.Drawing.Point(4, 22);
            this.tpArticulos.Name = "tpArticulos";
            this.tpArticulos.Padding = new System.Windows.Forms.Padding(3);
            this.tpArticulos.Size = new System.Drawing.Size(631, 265);
            this.tpArticulos.TabIndex = 3;
            this.tpArticulos.Text = "Artículos Regencia";
            this.tpArticulos.UseVisualStyleBackColor = true;
            // 
            // gbArticulos
            // 
            this.gbArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbArticulos.Controls.Add(this.toolStrip8);
            this.gbArticulos.Controls.Add(this.dgvArticulos);
            this.gbArticulos.Location = new System.Drawing.Point(8, 5);
            this.gbArticulos.Name = "gbArticulos";
            this.gbArticulos.Size = new System.Drawing.Size(617, 260);
            this.gbArticulos.TabIndex = 312;
            this.gbArticulos.TabStop = false;
            this.gbArticulos.Text = "Agregar Artículos";
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
            this.colArticulo,
            this.colDescripcion,
            this.colPrecio});
            this.dgvArticulos.Location = new System.Drawing.Point(6, 43);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersVisible = false;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(605, 211);
            this.dgvArticulos.TabIndex = 310;
            // 
            // colArticulo
            // 
            this.colArticulo.HeaderText = "Código";
            this.colArticulo.Name = "colArticulo";
            this.colArticulo.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FillWeight = 137.0558F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle7;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // tpArticulosEstable
            // 
            this.tpArticulosEstable.Controls.Add(this.grbArtEstable);
            this.tpArticulosEstable.Location = new System.Drawing.Point(4, 22);
            this.tpArticulosEstable.Name = "tpArticulosEstable";
            this.tpArticulosEstable.Size = new System.Drawing.Size(631, 265);
            this.tpArticulosEstable.TabIndex = 4;
            this.tpArticulosEstable.Text = "Artículos Establecimineto";
            this.tpArticulosEstable.UseVisualStyleBackColor = true;
            // 
            // grbArtEstable
            // 
            this.grbArtEstable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbArtEstable.Controls.Add(this.toolStrip3);
            this.grbArtEstable.Controls.Add(this.dgvArtEstablecimiento);
            this.grbArtEstable.Location = new System.Drawing.Point(7, 2);
            this.grbArtEstable.Name = "grbArtEstable";
            this.grbArtEstable.Size = new System.Drawing.Size(617, 260);
            this.grbArtEstable.TabIndex = 313;
            this.grbArtEstable.TabStop = false;
            this.grbArtEstable.Text = "Agregar Artículos";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoArtEstable,
            this.btnEliminarArtEstable});
            this.toolStrip3.Location = new System.Drawing.Point(3, 15);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(89, 25);
            this.toolStrip3.TabIndex = 306;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnNuevoArtEstable
            // 
            this.btnNuevoArtEstable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoArtEstable.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoArtEstable.Image")));
            this.btnNuevoArtEstable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoArtEstable.Name = "btnNuevoArtEstable";
            this.btnNuevoArtEstable.Size = new System.Drawing.Size(23, 22);
            this.btnNuevoArtEstable.Text = "Nuevo";
            this.btnNuevoArtEstable.Click += new System.EventHandler(this.btnNuevoArtEstable_Click);
            // 
            // btnEliminarArtEstable
            // 
            this.btnEliminarArtEstable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarArtEstable.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarArtEstable.Image")));
            this.btnEliminarArtEstable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarArtEstable.Name = "btnEliminarArtEstable";
            this.btnEliminarArtEstable.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarArtEstable.Text = "Eliminar";
            this.btnEliminarArtEstable.Click += new System.EventHandler(this.btnEliminarArtEstable_Click);
            // 
            // dgvArtEstablecimiento
            // 
            this.dgvArtEstablecimiento.AllowUserToAddRows = false;
            this.dgvArtEstablecimiento.AllowUserToDeleteRows = false;
            this.dgvArtEstablecimiento.AllowUserToResizeRows = false;
            this.dgvArtEstablecimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArtEstablecimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtEstablecimiento.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvArtEstablecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtEstablecimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodArtEstable,
            this.colDescArtEstable,
            this.colPrecioArtEstable});
            this.dgvArtEstablecimiento.Location = new System.Drawing.Point(6, 43);
            this.dgvArtEstablecimiento.MultiSelect = false;
            this.dgvArtEstablecimiento.Name = "dgvArtEstablecimiento";
            this.dgvArtEstablecimiento.RowHeadersVisible = false;
            this.dgvArtEstablecimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArtEstablecimiento.Size = new System.Drawing.Size(605, 211);
            this.dgvArtEstablecimiento.TabIndex = 310;
            // 
            // colCodArtEstable
            // 
            this.colCodArtEstable.HeaderText = "Código";
            this.colCodArtEstable.Name = "colCodArtEstable";
            this.colCodArtEstable.ReadOnly = true;
            // 
            // colDescArtEstable
            // 
            this.colDescArtEstable.FillWeight = 137.0558F;
            this.colDescArtEstable.HeaderText = "Descripción";
            this.colDescArtEstable.Name = "colDescArtEstable";
            this.colDescArtEstable.ReadOnly = true;
            // 
            // colPrecioArtEstable
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.colPrecioArtEstable.DefaultCellStyle = dataGridViewCellStyle8;
            this.colPrecioArtEstable.HeaderText = "Precio";
            this.colPrecioArtEstable.Name = "colPrecioArtEstable";
            // 
            // frmCategoriasEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 383);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCategoriasEdicion";
            this.Text = "Categorías";
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
            this.tpArticulos.ResumeLayout(false);
            this.gbArticulos.ResumeLayout(false);
            this.gbArticulos.PerformLayout();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.tpArticulosEstable.ResumeLayout(false);
            this.grbArtEstable.ResumeLayout(false);
            this.grbArtEstable.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtEstablecimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtCodigo;
        private Framework.UserControls.rtbSaseg rtbDescripcion;
        private Framework.UserControls.txtNormal txtNombre;
        private System.Windows.Forms.TabPage tpArticulos;
        private System.Windows.Forms.GroupBox gbArticulos;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnAgregarCampo;
        private System.Windows.Forms.ToolStripButton btnEliminarCampo;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.TabPage tpArticulosEstable;
        private System.Windows.Forms.GroupBox grbArtEstable;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevoArtEstable;
        private System.Windows.Forms.ToolStripButton btnEliminarArtEstable;
        private System.Windows.Forms.DataGridView dgvArtEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodArtEstable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescArtEstable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioArtEstable;
    }
}