namespace Framework
{
    partial class frmListado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListado));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnColumnas = new System.Windows.Forms.ToolStripButton();
            this.btnBuscaRapida = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnAyuda = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbltexto = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipoFiltro = new System.Windows.Forms.ComboBox();
            this.flvListado = new BrightIdeasSoftware.FastDataListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bwProceso = new System.ComponentModel.BackgroundWorker();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.toolStripSeparator1,
            this.btnColumnas,
            this.btnBuscaRapida,
            this.toolStripSeparator2,
            this.btnExcel,
            this.btnImprimir,
            this.toolStripSeparator3,
            this.btnActualizar,
            this.btnAyuda,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // btnBuscaRapida
            // 
            this.btnBuscaRapida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscaRapida.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaRapida.Image")));
            this.btnBuscaRapida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscaRapida.Name = "btnBuscaRapida";
            this.btnBuscaRapida.Size = new System.Drawing.Size(23, 22);
            this.btnBuscaRapida.Text = "Filtrar";
            this.btnBuscaRapida.Click += new System.EventHandler(this.btnBuscaRapida_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // btnImprimir
            // 
            this.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(23, 22);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // btnAyuda
            // 
            this.btnAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAyuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAyuda.Image")));
            this.btnAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(23, 22);
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbltexto});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(137, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbltexto
            // 
            this.lbltexto.AutoSize = false;
            this.lbltexto.Name = "lbltexto";
            this.lbltexto.Size = new System.Drawing.Size(115, 17);
            this.lbltexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Location = new System.Drawing.Point(490, 508);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(205, 20);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(431, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtrar por:";
            // 
            // cbTipoFiltro
            // 
            this.cbTipoFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFiltro.FormattingEnabled = true;
            this.cbTipoFiltro.Items.AddRange(new object[] {
            "Cualquier texto",
            "Prefijo"});
            this.cbTipoFiltro.Location = new System.Drawing.Point(701, 508);
            this.cbTipoFiltro.Name = "cbTipoFiltro";
            this.cbTipoFiltro.Size = new System.Drawing.Size(98, 21);
            this.cbTipoFiltro.TabIndex = 5;
            this.cbTipoFiltro.SelectedIndexChanged += new System.EventHandler(this.cbTipoFiltro_SelectedIndexChanged);
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
            this.flvListado.Location = new System.Drawing.Point(0, 25);
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
            this.flvListado.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.ModelDialog;
            this.flvListado.SelectedBackColor = System.Drawing.Color.DodgerBlue;
            this.flvListado.SelectedColumnTint = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flvListado.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flvListado.ShowCommandMenuOnRightClick = true;
            this.flvListado.ShowGroups = false;
            this.flvListado.ShowImagesOnSubItems = true;
            this.flvListado.ShowItemToolTips = true;
            this.flvListado.Size = new System.Drawing.Size(966, 481);
            this.flvListado.SpaceBetweenGroups = 20;
            this.flvListado.TabIndex = 0;
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
            this.flvListado.ColumnRightClick += new BrightIdeasSoftware.ColumnRightClickEventHandler(this.dgListado_ColumnRightClick);
            this.flvListado.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.flvListado_ItemsChanged);
            this.flvListado.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.dgListado_ColumnClick);
            this.flvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgListado_KeyDown);
            this.flvListado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgListado_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Buscar.png");
            this.imageList1.Images.SetKeyName(1, "Buscarx.png");
            // 
            // bwProceso
            // 
            this.bwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProceso_DoWork);
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(911, 511);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 13);
            this.lblCantidad.TabIndex = 43;
            this.lblCantidad.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(810, 511);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Cantidad Registros:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(966, 530);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbTipoFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.flvListado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmListado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected BrightIdeasSoftware.FastDataListView flvListado;
        protected System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton btnNuevo;
        protected System.Windows.Forms.ToolStripButton btnEditar;
        protected System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnColumnas;
        private System.Windows.Forms.ToolStripButton btnBuscaRapida;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbltexto;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoFiltro;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker bwProceso;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton btnAyuda;
    }
}

