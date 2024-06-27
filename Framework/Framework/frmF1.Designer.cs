namespace Framework
{
    partial class frmF1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmF1));
            this.cbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.flvF1 = new BrightIdeasSoftware.FastDataListView();
            this.btnColumnas = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvF1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTipoFiltro
            // 
            this.cbTipoFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltro.FormattingEnabled = true;
            this.cbTipoFiltro.Items.AddRange(new object[] {
            "Cualquier texto",
            "Prefijo"});
            this.cbTipoFiltro.Location = new System.Drawing.Point(496, 257);
            this.cbTipoFiltro.Name = "cbTipoFiltro";
            this.cbTipoFiltro.Size = new System.Drawing.Size(98, 21);
            this.cbTipoFiltro.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(331, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filtrar por:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(390, 257);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 6;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.btnColumnas,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(596, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(23, 22);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            // flvF1
            // 
            this.flvF1.AllowColumnReorder = true;
            this.flvF1.AllowDrop = true;
            this.flvF1.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.flvF1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flvF1.AutoArrange = false;
            this.flvF1.CellEditUseWholeCell = false;
            this.flvF1.DataSource = null;
            this.flvF1.FullRowSelect = true;
            this.flvF1.GridLines = true;
            this.flvF1.Location = new System.Drawing.Point(0, 28);
            this.flvF1.MenuLabelColumns = "Columnas";
            this.flvF1.MenuLabelGroupBy = "Agrupar por \'{0}\'";
            this.flvF1.MenuLabelSelectColumns = "Columnas";
            this.flvF1.MenuLabelSortAscending = "Ordenar ascendente por \'{0}\'";
            this.flvF1.MenuLabelSortDescending = "Ordenar descendente por \'{0}\'";
            this.flvF1.MenuLabelTurnOffGroups = "Quitar grupos";
            this.flvF1.MenuLabelUnlockGroupingOn = "Agrupar por \'{0}\'";
            this.flvF1.MenuLabelUnsort = "";
            this.flvF1.MultiSelect = false;
            this.flvF1.Name = "flvF1";
            this.flvF1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flvF1.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.flvF1.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.flvF1.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flvF1.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flvF1.ShowCommandMenuOnRightClick = true;
            this.flvF1.ShowGroups = false;
            this.flvF1.ShowImagesOnSubItems = true;
            this.flvF1.ShowItemToolTips = true;
            this.flvF1.Size = new System.Drawing.Size(594, 226);
            this.flvF1.SpaceBetweenGroups = 20;
            this.flvF1.TabIndex = 10;
            this.flvF1.TintSortColumn = true;
            this.flvF1.UnfocusedSelectedBackColor = System.Drawing.Color.Transparent;
            this.flvF1.UnfocusedSelectedForeColor = System.Drawing.Color.Transparent;
            this.flvF1.UseAlternatingBackColors = true;
            this.flvF1.UseCompatibleStateImageBehavior = false;
            this.flvF1.UseFilterIndicator = true;
            this.flvF1.UseFiltering = true;
            this.flvF1.UseHotItem = true;
            this.flvF1.UseTranslucentHotItem = true;
            this.flvF1.View = System.Windows.Forms.View.Details;
            this.flvF1.VirtualMode = true;
            this.flvF1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flvF1_KeyDown);
            this.flvF1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.flvF1_MouseDoubleClick);
            // 
            // btnColumnas
            // 
            this.btnColumnas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColumnas.Image = ((System.Drawing.Image)(resources.GetObject("btnColumnas.Image")));
            this.btnColumnas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColumnas.Name = "btnColumnas";
            this.btnColumnas.Size = new System.Drawing.Size(23, 22);
            this.btnColumnas.Text = "Ajustar Tamaño Columnas";
            this.btnColumnas.Click += new System.EventHandler(this.btnColumnas_Click);
            // 
            // frmF1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(596, 282);
            this.Controls.Add(this.flvF1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cbTipoFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmF1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private BrightIdeasSoftware.FastDataListView flvF1;
        private System.Windows.Forms.ToolStripButton btnColumnas;
    }
}