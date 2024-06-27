namespace Framework
{
    partial class frmListadoB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoB));
            this.flvListado = new BrightIdeasSoftware.FastDataListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.Salir = new System.Windows.Forms.ToolStripButton();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.cbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flvListado
            // 
            this.flvListado.AllowColumnReorder = true;
            this.flvListado.AllowDrop = true;
            this.flvListado.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.flvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flvListado.AutoArrange = false;
            this.flvListado.CellEditUseWholeCell = false;
            this.flvListado.DataSource = null;
            this.flvListado.FullRowSelect = true;
            this.flvListado.GridLines = true;
            this.flvListado.Location = new System.Drawing.Point(0, 60);
            this.flvListado.MenuLabelColumns = "Columnas";
            this.flvListado.MenuLabelGroupBy = "Agrupar por \'{0}\'";
            this.flvListado.MenuLabelSelectColumns = "Columnas";
            this.flvListado.MenuLabelSortAscending = "Ordenar ascendente por \'{0}\'";
            this.flvListado.MenuLabelSortDescending = "Ordenar descendente por \'{0}\'";
            this.flvListado.MenuLabelTurnOffGroups = "Quitar grupos";
            this.flvListado.MenuLabelUnlockGroupingOn = "Agrupar por \'{0}\'";
            this.flvListado.MenuLabelUnsort = "";
            this.flvListado.MultiSelect = false;
            this.flvListado.Name = "flvListado";
            this.flvListado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flvListado.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.flvListado.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.flvListado.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flvListado.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flvListado.ShowCommandMenuOnRightClick = true;
            this.flvListado.ShowGroups = false;
            this.flvListado.ShowImagesOnSubItems = true;
            this.flvListado.ShowItemToolTips = true;
            this.flvListado.Size = new System.Drawing.Size(966, 442);
            this.flvListado.SpaceBetweenGroups = 20;
            this.flvListado.TabIndex = 1;
            this.flvListado.TintSortColumn = true;
            this.flvListado.UnfocusedSelectedBackColor = System.Drawing.Color.Transparent;
            this.flvListado.UnfocusedSelectedForeColor = System.Drawing.Color.Transparent;
            this.flvListado.UseAlternatingBackColors = true;
            this.flvListado.UseCompatibleStateImageBehavior = false;
            this.flvListado.UseFilterIndicator = true;
            this.flvListado.UseFiltering = true;
            this.flvListado.UseHotItem = true;
            this.flvListado.UseTranslucentHotItem = true;
            this.flvListado.View = System.Windows.Forms.View.Details;
            this.flvListado.VirtualMode = true;
            this.flvListado.ColumnRightClick += new BrightIdeasSoftware.ColumnRightClickEventHandler(this.flvListado_ColumnRightClick);
            this.flvListado.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.flvListado_ColumnClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.btnExcel,
            this.Salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(23, 22);
            this.btnActualizar.Text = "Actualizar Datos";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 22);
            this.btnExcel.Text = "Exportar a Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Salir
            // 
            this.Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Salir.Image = ((System.Drawing.Image)(resources.GetObject("Salir.Image")));
            this.Salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(23, 22);
            this.Salir.Text = "Salir";
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(323, 32);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Inicial:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(540, 32);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // cbTipoFiltro
            // 
            this.cbTipoFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltro.FormattingEnabled = true;
            this.cbTipoFiltro.Items.AddRange(new object[] {
            "Cualquier texto",
            "Prefijo"});
            this.cbTipoFiltro.Location = new System.Drawing.Point(844, 507);
            this.cbTipoFiltro.Name = "cbTipoFiltro";
            this.cbTipoFiltro.Size = new System.Drawing.Size(98, 21);
            this.cbTipoFiltro.TabIndex = 9;
            this.cbTipoFiltro.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(679, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filtrar por:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(738, 507);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro.TabIndex = 7;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // frmListadoB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(966, 530);
            this.Controls.Add(this.cbTipoFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.flvListado);
            this.Name = "frmListadoB";
            this.Text = "frmListadoB";
            this.Load += new System.EventHandler(this.frmListadoB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected BrightIdeasSoftware.FastDataListView flvListado;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton Salir;
        protected System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.ComboBox cbTipoFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}