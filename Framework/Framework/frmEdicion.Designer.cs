namespace Framework
{
    partial class frmEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdicion));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardarSalir = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnAyuda = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpBasicos = new System.Windows.Forms.TabPage();
            this.panelBasicos = new System.Windows.Forms.Panel();
            this.lblTituloBasicos = new System.Windows.Forms.Label();
            this.tpAdmin = new System.Windows.Forms.TabPage();
            this.txtFechaModificacion = new System.Windows.Forms.TextBox();
            this.txtFechaCreacion = new System.Windows.Forms.TextBox();
            this.txtNomUserModificacion = new System.Windows.Forms.TextBox();
            this.txtNomUserCreacion = new System.Windows.Forms.TextBox();
            this.txtUserModificacion = new System.Windows.Forms.TextBox();
            this.txtUserCreacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tpAdjuntos = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoAdjunto = new System.Windows.Forms.ToolStripButton();
            this.btnEliminaAdjunto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnColumnas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizaAdjunto = new System.Windows.Forms.ToolStripButton();
            this.flvListado = new BrightIdeasSoftware.FastDataListView();
            this.colDescripcion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colNombre = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colConsecutivo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colBD = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelAdjuntos = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelAdmin.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.panelAdjuntos.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEliminar,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.btnGuardarSalir,
            this.btnProcesar,
            this.toolStripSeparator4,
            this.btnImprimir,
            this.btnActualizar,
            this.btnAyuda,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(682, 25);
            this.toolStrip1.TabIndex = 2;
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
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Enabled = false;
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
            // btnGuardar
            // 
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(23, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGuardarSalir
            // 
            this.btnGuardarSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardarSalir.Enabled = false;
            this.btnGuardarSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarSalir.Image")));
            this.btnGuardarSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarSalir.Name = "btnGuardarSalir";
            this.btnGuardarSalir.Size = new System.Drawing.Size(23, 22);
            this.btnGuardarSalir.Text = "Guardar y Salir";
            this.btnGuardarSalir.Click += new System.EventHandler(this.btnGuardarSalir_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
            this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(23, 22);
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.Visible = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(23, 22);
            this.btnActualizar.Text = "Actualizar Datos";
            this.btnActualizar.Visible = false;
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
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpBasicos);
            this.tabControl.Controls.Add(this.tpAdmin);
            this.tabControl.Controls.Add(this.tpAdjuntos);
            this.tabControl.Location = new System.Drawing.Point(0, 92);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(682, 393);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.panelBasicos);
            this.tpBasicos.Location = new System.Drawing.Point(4, 22);
            this.tpBasicos.Name = "tpBasicos";
            this.tpBasicos.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasicos.Size = new System.Drawing.Size(674, 367);
            this.tpBasicos.TabIndex = 0;
            this.tpBasicos.Text = "Básicos";
            this.tpBasicos.UseVisualStyleBackColor = true;
            // 
            // panelBasicos
            // 
            this.panelBasicos.BackColor = System.Drawing.Color.DarkGray;
            this.panelBasicos.Controls.Add(this.lblTituloBasicos);
            this.panelBasicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicos.Location = new System.Drawing.Point(3, 3);
            this.panelBasicos.Name = "panelBasicos";
            this.panelBasicos.Size = new System.Drawing.Size(668, 21);
            this.panelBasicos.TabIndex = 1;
            // 
            // lblTituloBasicos
            // 
            this.lblTituloBasicos.AutoSize = true;
            this.lblTituloBasicos.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloBasicos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTituloBasicos.Location = new System.Drawing.Point(3, 3);
            this.lblTituloBasicos.Name = "lblTituloBasicos";
            this.lblTituloBasicos.Size = new System.Drawing.Size(122, 14);
            this.lblTituloBasicos.TabIndex = 0;
            this.lblTituloBasicos.Text = "Información Básicos";
            // 
            // tpAdmin
            // 
            this.tpAdmin.Controls.Add(this.txtFechaModificacion);
            this.tpAdmin.Controls.Add(this.txtFechaCreacion);
            this.tpAdmin.Controls.Add(this.txtNomUserModificacion);
            this.tpAdmin.Controls.Add(this.txtNomUserCreacion);
            this.tpAdmin.Controls.Add(this.txtUserModificacion);
            this.tpAdmin.Controls.Add(this.txtUserCreacion);
            this.tpAdmin.Controls.Add(this.label5);
            this.tpAdmin.Controls.Add(this.label4);
            this.tpAdmin.Controls.Add(this.label3);
            this.tpAdmin.Controls.Add(this.label2);
            this.tpAdmin.Controls.Add(this.panelAdmin);
            this.tpAdmin.Location = new System.Drawing.Point(4, 22);
            this.tpAdmin.Name = "tpAdmin";
            this.tpAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdmin.Size = new System.Drawing.Size(674, 367);
            this.tpAdmin.TabIndex = 1;
            this.tpAdmin.Text = "Administración";
            this.tpAdmin.UseVisualStyleBackColor = true;
            // 
            // txtFechaModificacion
            // 
            this.txtFechaModificacion.Location = new System.Drawing.Point(503, 94);
            this.txtFechaModificacion.Name = "txtFechaModificacion";
            this.txtFechaModificacion.ReadOnly = true;
            this.txtFechaModificacion.Size = new System.Drawing.Size(139, 20);
            this.txtFechaModificacion.TabIndex = 10;
            // 
            // txtFechaCreacion
            // 
            this.txtFechaCreacion.Location = new System.Drawing.Point(503, 64);
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.ReadOnly = true;
            this.txtFechaCreacion.Size = new System.Drawing.Size(139, 20);
            this.txtFechaCreacion.TabIndex = 9;
            // 
            // txtNomUserModificacion
            // 
            this.txtNomUserModificacion.Location = new System.Drawing.Point(233, 94);
            this.txtNomUserModificacion.Name = "txtNomUserModificacion";
            this.txtNomUserModificacion.ReadOnly = true;
            this.txtNomUserModificacion.Size = new System.Drawing.Size(264, 20);
            this.txtNomUserModificacion.TabIndex = 8;
            // 
            // txtNomUserCreacion
            // 
            this.txtNomUserCreacion.Location = new System.Drawing.Point(233, 64);
            this.txtNomUserCreacion.Name = "txtNomUserCreacion";
            this.txtNomUserCreacion.ReadOnly = true;
            this.txtNomUserCreacion.Size = new System.Drawing.Size(264, 20);
            this.txtNomUserCreacion.TabIndex = 7;
            // 
            // txtUserModificacion
            // 
            this.txtUserModificacion.Location = new System.Drawing.Point(127, 94);
            this.txtUserModificacion.Name = "txtUserModificacion";
            this.txtUserModificacion.ReadOnly = true;
            this.txtUserModificacion.Size = new System.Drawing.Size(100, 20);
            this.txtUserModificacion.TabIndex = 6;
            // 
            // txtUserCreacion
            // 
            this.txtUserCreacion.Location = new System.Drawing.Point(127, 64);
            this.txtUserCreacion.Name = "txtUserCreacion";
            this.txtUserCreacion.ReadOnly = true;
            this.txtUserCreacion.Size = new System.Drawing.Size(100, 20);
            this.txtUserCreacion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Última Modificación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Creación:";
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.Color.DarkGray;
            this.panelAdmin.Controls.Add(this.label1);
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdmin.Location = new System.Drawing.Point(3, 3);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(668, 21);
            this.panelAdmin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Información Administrativa y de Auditoría";
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Controls.Add(this.panel1);
            this.tpAdjuntos.Controls.Add(this.flvListado);
            this.tpAdjuntos.Controls.Add(this.panelAdjuntos);
            this.tpAdjuntos.Location = new System.Drawing.Point(4, 22);
            this.tpAdjuntos.Name = "tpAdjuntos";
            this.tpAdjuntos.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdjuntos.Size = new System.Drawing.Size(674, 367);
            this.tpAdjuntos.TabIndex = 2;
            this.tpAdjuntos.Text = "Adjuntos";
            this.tpAdjuntos.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 26);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoAdjunto,
            this.btnEliminaAdjunto,
            this.toolStripSeparator3,
            this.btnColumnas,
            this.toolStripSeparator2,
            this.btnActualizaAdjunto});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(123, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNuevoAdjunto
            // 
            this.btnNuevoAdjunto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoAdjunto.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoAdjunto.Image")));
            this.btnNuevoAdjunto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoAdjunto.Name = "btnNuevoAdjunto";
            this.btnNuevoAdjunto.Size = new System.Drawing.Size(23, 22);
            this.btnNuevoAdjunto.Text = "Nuevo";
            this.btnNuevoAdjunto.Click += new System.EventHandler(this.btnNuevoAdjunto_Click);
            // 
            // btnEliminaAdjunto
            // 
            this.btnEliminaAdjunto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminaAdjunto.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaAdjunto.Image")));
            this.btnEliminaAdjunto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminaAdjunto.Name = "btnEliminaAdjunto";
            this.btnEliminaAdjunto.Size = new System.Drawing.Size(23, 22);
            this.btnEliminaAdjunto.Text = "Eliminar";
            this.btnEliminaAdjunto.Click += new System.EventHandler(this.btnEliminaAdjunto_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnActualizaAdjunto
            // 
            this.btnActualizaAdjunto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizaAdjunto.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizaAdjunto.Image")));
            this.btnActualizaAdjunto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizaAdjunto.Name = "btnActualizaAdjunto";
            this.btnActualizaAdjunto.Size = new System.Drawing.Size(23, 22);
            this.btnActualizaAdjunto.Text = "Refrescar";
            this.btnActualizaAdjunto.Click += new System.EventHandler(this.btnActualizaAdjunto_Click);
            // 
            // flvListado
            // 
            this.flvListado.AllColumns.Add(this.colDescripcion);
            this.flvListado.AllColumns.Add(this.colNombre);
            this.flvListado.AllColumns.Add(this.colConsecutivo);
            this.flvListado.AllColumns.Add(this.colBD);
            this.flvListado.AllowColumnReorder = true;
            this.flvListado.AllowDrop = true;
            this.flvListado.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.flvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flvListado.AutoArrange = false;
            this.flvListado.CellEditUseWholeCell = false;
            this.flvListado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescripcion,
            this.colNombre,
            this.colConsecutivo,
            this.colBD});
            this.flvListado.Cursor = System.Windows.Forms.Cursors.Default;
            this.flvListado.DataSource = null;
            this.flvListado.FullRowSelect = true;
            this.flvListado.GridLines = true;
            this.flvListado.Location = new System.Drawing.Point(12, 65);
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
            this.flvListado.Size = new System.Drawing.Size(654, 293);
            this.flvListado.SpaceBetweenGroups = 20;
            this.flvListado.TabIndex = 2;
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
            this.flvListado.DoubleClick += new System.EventHandler(this.flvListado_DoubleClick);
            // 
            // colDescripcion
            // 
            this.colDescripcion.AspectName = "DescripcionArchivo";
            this.colDescripcion.Text = "Descripción Archivo";
            this.colDescripcion.Width = 59;
            // 
            // colNombre
            // 
            this.colNombre.AspectName = "NombreArchivo";
            this.colNombre.Text = "Nombre Archivo";
            // 
            // colConsecutivo
            // 
            this.colConsecutivo.AspectName = "Consecutivo";
            this.colConsecutivo.MaximumWidth = 0;
            this.colConsecutivo.MinimumWidth = 0;
            this.colConsecutivo.Text = "Consecutivo";
            this.colConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colConsecutivo.Width = 0;
            // 
            // colBD
            // 
            this.colBD.AspectName = "ArchivoEnBaseDatos";
            this.colBD.MaximumWidth = 0;
            this.colBD.MinimumWidth = 0;
            this.colBD.Text = "Base Datos";
            this.colBD.Width = 0;
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.BackColor = System.Drawing.Color.DarkGray;
            this.panelAdjuntos.Controls.Add(this.label6);
            this.panelAdjuntos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdjuntos.Location = new System.Drawing.Point(3, 3);
            this.panelAdjuntos.Name = "panelAdjuntos";
            this.panelAdjuntos.Size = new System.Drawing.Size(668, 21);
            this.panelAdjuntos.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Información Archivos Adjuntos";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.ForeColor = System.Drawing.Color.Black;
            this.lblPerfil.Location = new System.Drawing.Point(12, 42);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(59, 22);
            this.lblPerfil.TabIndex = 4;
            this.lblPerfil.Text = "Perfil";
            // 
            // frmEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 484);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEdicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEdicion_FormClosing);
            this.Load += new System.EventHandler(this.frmEdicion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpBasicos.ResumeLayout(false);
            this.panelBasicos.ResumeLayout(false);
            this.panelBasicos.PerformLayout();
            this.tpAdmin.ResumeLayout(false);
            this.tpAdmin.PerformLayout();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.tpAdjuntos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
            this.panelAdjuntos.ResumeLayout(false);
            this.panelAdjuntos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolStripButton btnNuevo;
        protected System.Windows.Forms.ToolStripButton btnGuardar;
        protected System.Windows.Forms.ToolStripButton btnGuardarSalir;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripButton btnEliminar;
        protected System.Windows.Forms.ToolStripButton btnImprimir;
        protected System.Windows.Forms.ToolStripButton btnAyuda;
        protected System.Windows.Forms.ToolStripButton btnSalir;
        protected System.Windows.Forms.TabControl tabControl;
        protected System.Windows.Forms.TabPage tpBasicos;
        protected System.Windows.Forms.TabPage tpAdmin;
        protected System.Windows.Forms.Label lblPerfil;
        protected System.Windows.Forms.TextBox txtFechaModificacion;
        protected System.Windows.Forms.TextBox txtFechaCreacion;
        protected System.Windows.Forms.TextBox txtNomUserModificacion;
        protected System.Windows.Forms.TextBox txtNomUserCreacion;
        protected System.Windows.Forms.TextBox txtUserModificacion;
        protected System.Windows.Forms.TextBox txtUserCreacion;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel panelBasicos;
        protected System.Windows.Forms.Label lblTituloBasicos;
        protected System.Windows.Forms.TabPage tpAdjuntos;
        protected System.Windows.Forms.Panel panelAdjuntos;
        private System.Windows.Forms.Label label6;
        protected BrightIdeasSoftware.FastDataListView flvListado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnNuevoAdjunto;
        private System.Windows.Forms.ToolStripButton btnEliminaAdjunto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnActualizaAdjunto;
        private BrightIdeasSoftware.OLVColumn colConsecutivo;
        private BrightIdeasSoftware.OLVColumn colNombre;
        private BrightIdeasSoftware.OLVColumn colDescripcion;
        protected System.Windows.Forms.ToolStrip toolStrip1;
        private BrightIdeasSoftware.OLVColumn colBD;
        private System.Windows.Forms.ToolStripButton btnColumnas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.ToolStripButton btnProcesar;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        protected System.Windows.Forms.ToolStripButton btnActualizar;
    }
}