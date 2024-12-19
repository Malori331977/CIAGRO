namespace KOLEGIO
{
    partial class frmGenerarCelNotificacionPorMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarCelNotificacionPorMes));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.bwProceso = new System.ComponentModel.BackgroundWorker();
            this.dgvColegiados = new System.Windows.Forms.DataGridView();
            this.chkGenTotal = new Framework.UserControls.chkSaseg();
            this.lblRegistrosCant = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTotalRegArchivo = new System.Windows.Forms.Label();
            this.lblRegArchivo = new System.Windows.Forms.Label();
            this.grbTipo = new System.Windows.Forms.GroupBox();
            this.chkREG = new Framework.UserControls.chkSaseg();
            this.chkCOL = new Framework.UserControls.chkSaseg();
            this.chkPLAGUI = new Framework.UserControls.chkSaseg();
            this.chkPER = new Framework.UserControls.chkSaseg();
            this.chkAEREA = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEST = new Framework.UserControls.chkSaseg();
            this.chkCONSUL = new Framework.UserControls.chkSaseg();
            this.panelMorosidades = new System.Windows.Forms.Panel();
            this.dgvGestionCobro2 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdColegiado2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCompromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panelGestionCobro = new System.Windows.Forms.Panel();
            this.colIdColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreColegiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMeses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIncorporacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Canton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).BeginInit();
            this.grbTipo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMorosidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro2)).BeginInit();
            this.panelGestionCobro.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 13);
            this.label1.TabIndex = 283;
            this.label1.Text = "Este proceso genera un archivo con celulares como una búsqueda por mes de colegia" +
    "dos con pendientes.";
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(62, 39);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(64, 20);
            this.txtMeses.TabIndex = 281;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(15, 42);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 13);
            this.label27.TabIndex = 280;
            this.label27.Text = "Meses:";
            // 
            // iList
            // 
            this.iList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList.ImageStream")));
            this.iList.TransparentColor = System.Drawing.Color.Transparent;
            this.iList.Images.SetKeyName(0, "gris.png");
            this.iList.Images.SetKeyName(1, "rojo.png");
            this.iList.Images.SetKeyName(2, "verde.png");
            this.iList.Images.SetKeyName(3, "amarillo.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefrescar,
            this.btnProcesar,
            this.btnExcel,
            this.btnResize,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1156, 25);
            this.toolStrip1.TabIndex = 278;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescar.Image")));
            this.btnRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(23, 22);
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
            this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(23, 22);
            this.btnProcesar.Text = "Generar Archivo";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
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
            // btnResize
            // 
            this.btnResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResize.Image = ((System.Drawing.Image)(resources.GetObject("btnResize.Image")));
            this.btnResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(23, 22);
            this.btnResize.Text = "Ajustar Tamaño de Columnas";
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
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
            this.btnSalir.DoubleClick += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvColegiados
            // 
            this.dgvColegiados.AllowUserToAddRows = false;
            this.dgvColegiados.AllowUserToResizeRows = false;
            this.dgvColegiados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvColegiados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColegiados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvColegiados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColegiados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdColegiado,
            this.colNumeroColegiado,
            this.colNombreColegiado,
            this.colCelular,
            this.colMeses,
            this.Condicion,
            this.Cobrador,
            this.FechaIncorporacion,
            this.Provincia,
            this.Canton});
            this.dgvColegiados.Location = new System.Drawing.Point(16, 16);
            this.dgvColegiados.Name = "dgvColegiados";
            this.dgvColegiados.ReadOnly = true;
            this.dgvColegiados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColegiados.Size = new System.Drawing.Size(1121, 343);
            this.dgvColegiados.TabIndex = 285;
            this.dgvColegiados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColegiados_CellClick);
            this.dgvColegiados.SelectionChanged += new System.EventHandler(this.dgvColegiados_SelectionChanged);
            // 
            // chkGenTotal
            // 
            this.chkGenTotal.Checked = false;
            this.chkGenTotal.Location = new System.Drawing.Point(190, 42);
            this.chkGenTotal.Name = "chkGenTotal";
            this.chkGenTotal.Size = new System.Drawing.Size(114, 17);
            this.chkGenTotal.TabIndex = 294;
            this.chkGenTotal.Texto = "Generación Total";
            this.chkGenTotal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkGenTotal_MouseClick);
            // 
            // lblRegistrosCant
            // 
            this.lblRegistrosCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosCant.AutoSize = true;
            this.lblRegistrosCant.Location = new System.Drawing.Point(1107, 362);
            this.lblRegistrosCant.Name = "lblRegistrosCant";
            this.lblRegistrosCant.Size = new System.Drawing.Size(13, 13);
            this.lblRegistrosCant.TabIndex = 296;
            this.lblRegistrosCant.Text = "0";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(1045, 362);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(57, 13);
            this.lblRegistros.TabIndex = 295;
            this.lblRegistros.Text = "Registros: ";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(1044, 73);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(93, 20);
            this.txtFiltro.TabIndex = 298;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(985, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 297;
            this.label5.Text = "Filtrar por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(133, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(51, 23);
            this.btnBuscar.TabIndex = 299;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTotalRegArchivo
            // 
            this.lblTotalRegArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRegArchivo.AutoSize = true;
            this.lblTotalRegArchivo.Location = new System.Drawing.Point(959, 362);
            this.lblTotalRegArchivo.Name = "lblTotalRegArchivo";
            this.lblTotalRegArchivo.Size = new System.Drawing.Size(13, 13);
            this.lblTotalRegArchivo.TabIndex = 301;
            this.lblTotalRegArchivo.Text = "0";
            // 
            // lblRegArchivo
            // 
            this.lblRegArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegArchivo.AutoSize = true;
            this.lblRegArchivo.Location = new System.Drawing.Point(842, 362);
            this.lblRegArchivo.Name = "lblRegArchivo";
            this.lblRegArchivo.Size = new System.Drawing.Size(111, 13);
            this.lblRegArchivo.TabIndex = 300;
            this.lblRegArchivo.Text = "Registros en Archivo: ";
            // 
            // grbTipo
            // 
            this.grbTipo.Controls.Add(this.chkREG);
            this.grbTipo.Controls.Add(this.chkCOL);
            this.grbTipo.Controls.Add(this.chkPLAGUI);
            this.grbTipo.Controls.Add(this.chkPER);
            this.grbTipo.Controls.Add(this.chkAEREA);
            this.grbTipo.Location = new System.Drawing.Point(557, 12);
            this.grbTipo.Name = "grbTipo";
            this.grbTipo.Size = new System.Drawing.Size(223, 60);
            this.grbTipo.TabIndex = 302;
            this.grbTipo.TabStop = false;
            this.grbTipo.Text = "Colegiado";
            // 
            // chkREG
            // 
            this.chkREG.Checked = false;
            this.chkREG.Location = new System.Drawing.Point(121, 32);
            this.chkREG.Name = "chkREG";
            this.chkREG.Size = new System.Drawing.Size(82, 17);
            this.chkREG.TabIndex = 9;
            this.chkREG.Texto = "Regencias";
            // 
            // chkCOL
            // 
            this.chkCOL.Checked = false;
            this.chkCOL.Location = new System.Drawing.Point(33, 32);
            this.chkCOL.Name = "chkCOL";
            this.chkCOL.Size = new System.Drawing.Size(82, 17);
            this.chkCOL.TabIndex = 8;
            this.chkCOL.Texto = "Colegiaturas";
            // 
            // chkPLAGUI
            // 
            this.chkPLAGUI.Checked = false;
            this.chkPLAGUI.Location = new System.Drawing.Point(135, 15);
            this.chkPLAGUI.Name = "chkPLAGUI";
            this.chkPLAGUI.Size = new System.Drawing.Size(82, 17);
            this.chkPLAGUI.TabIndex = 7;
            this.chkPLAGUI.Texto = "Plaguicidas";
            // 
            // chkPER
            // 
            this.chkPER.Checked = false;
            this.chkPER.Location = new System.Drawing.Point(75, 15);
            this.chkPER.Name = "chkPER";
            this.chkPER.Size = new System.Drawing.Size(65, 17);
            this.chkPER.TabIndex = 6;
            this.chkPER.Texto = "Peritos";
            // 
            // chkAEREA
            // 
            this.chkAEREA.AutoSize = true;
            this.chkAEREA.Location = new System.Drawing.Point(18, 15);
            this.chkAEREA.Name = "chkAEREA";
            this.chkAEREA.Size = new System.Drawing.Size(54, 17);
            this.chkAEREA.TabIndex = 5;
            this.chkAEREA.Text = "Aerea";
            this.chkAEREA.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEST);
            this.groupBox1.Controls.Add(this.chkCONSUL);
            this.groupBox1.Location = new System.Drawing.Point(786, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 60);
            this.groupBox1.TabIndex = 303;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empresa";
            // 
            // chkEST
            // 
            this.chkEST.Checked = false;
            this.chkEST.Location = new System.Drawing.Point(30, 37);
            this.chkEST.Name = "chkEST";
            this.chkEST.Size = new System.Drawing.Size(111, 17);
            this.chkEST.TabIndex = 7;
            this.chkEST.Texto = "Establecimientos";
            // 
            // chkCONSUL
            // 
            this.chkCONSUL.Checked = false;
            this.chkCONSUL.Location = new System.Drawing.Point(30, 15);
            this.chkCONSUL.Name = "chkCONSUL";
            this.chkCONSUL.Size = new System.Drawing.Size(82, 17);
            this.chkCONSUL.TabIndex = 6;
            this.chkCONSUL.Texto = "Consultoras";
            // 
            // panelMorosidades
            // 
            this.panelMorosidades.Controls.Add(this.dgvColegiados);
            this.panelMorosidades.Controls.Add(this.lblRegArchivo);
            this.panelMorosidades.Controls.Add(this.lblRegistros);
            this.panelMorosidades.Controls.Add(this.lblTotalRegArchivo);
            this.panelMorosidades.Controls.Add(this.lblRegistrosCant);
            this.panelMorosidades.Location = new System.Drawing.Point(0, 103);
            this.panelMorosidades.Name = "panelMorosidades";
            this.panelMorosidades.Size = new System.Drawing.Size(1156, 389);
            this.panelMorosidades.TabIndex = 304;
            // 
            // dgvGestionCobro2
            // 
            this.dgvGestionCobro2.AllowUserToAddRows = false;
            this.dgvGestionCobro2.AllowUserToDeleteRows = false;
            this.dgvGestionCobro2.AllowUserToResizeRows = false;
            this.dgvGestionCobro2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGestionCobro2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGestionCobro2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGestionCobro2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGestionCobro2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIdColegiado2,
            this.colMedio,
            this.colFecha,
            this.colCompromiso,
            this.colFechaCompromiso,
            this.colObservacion,
            this.ColEstado});
            this.dgvGestionCobro2.Location = new System.Drawing.Point(16, 19);
            this.dgvGestionCobro2.Name = "dgvGestionCobro2";
            this.dgvGestionCobro2.ReadOnly = true;
            this.dgvGestionCobro2.RowHeadersVisible = false;
            this.dgvGestionCobro2.Size = new System.Drawing.Size(1121, 226);
            this.dgvGestionCobro2.TabIndex = 251;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colIdColegiado2
            // 
            this.colIdColegiado2.HeaderText = "Id Colegiado";
            this.colIdColegiado2.Name = "colIdColegiado2";
            this.colIdColegiado2.ReadOnly = true;
            // 
            // colMedio
            // 
            this.colMedio.HeaderText = "Medio";
            this.colMedio.Items.AddRange(new object[] {
            "LLAMADA",
            "CORREO"});
            this.colMedio.Name = "colMedio";
            this.colMedio.ReadOnly = true;
            this.colMedio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMedio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colCompromiso
            // 
            this.colCompromiso.HeaderText = "Compromiso";
            this.colCompromiso.Name = "colCompromiso";
            this.colCompromiso.ReadOnly = true;
            // 
            // colFechaCompromiso
            // 
            this.colFechaCompromiso.HeaderText = "Fecha Compromiso";
            this.colFechaCompromiso.Name = "colFechaCompromiso";
            this.colFechaCompromiso.ReadOnly = true;
            // 
            // colObservacion
            // 
            this.colObservacion.HeaderText = "Observaciones";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.ReadOnly = true;
            // 
            // ColEstado
            // 
            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.Items.AddRange(new object[] {
            "Abierto",
            "Cerrado"});
            this.ColEstado.Name = "ColEstado";
            this.ColEstado.ReadOnly = true;
            // 
            // panelGestionCobro
            // 
            this.panelGestionCobro.Controls.Add(this.dgvGestionCobro2);
            this.panelGestionCobro.Location = new System.Drawing.Point(0, 498);
            this.panelGestionCobro.Name = "panelGestionCobro";
            this.panelGestionCobro.Size = new System.Drawing.Size(1156, 260);
            this.panelGestionCobro.TabIndex = 305;
            // 
            // colIdColegiado
            // 
            this.colIdColegiado.DataPropertyName = "IdColegiado";
            this.colIdColegiado.HeaderText = "Id Colegiado";
            this.colIdColegiado.Name = "colIdColegiado";
            this.colIdColegiado.ReadOnly = true;
            // 
            // colNumeroColegiado
            // 
            this.colNumeroColegiado.DataPropertyName = "NumeroColegiado";
            this.colNumeroColegiado.HeaderText = "Nº Colegiado";
            this.colNumeroColegiado.MinimumWidth = 6;
            this.colNumeroColegiado.Name = "colNumeroColegiado";
            this.colNumeroColegiado.ReadOnly = true;
            // 
            // colNombreColegiado
            // 
            this.colNombreColegiado.DataPropertyName = "Nombre";
            this.colNombreColegiado.HeaderText = "Nombre";
            this.colNombreColegiado.Name = "colNombreColegiado";
            this.colNombreColegiado.ReadOnly = true;
            // 
            // colCelular
            // 
            this.colCelular.HeaderText = "Celular";
            this.colCelular.Name = "colCelular";
            this.colCelular.ReadOnly = true;
            // 
            // colMeses
            // 
            this.colMeses.HeaderText = "Meses ";
            this.colMeses.Name = "colMeses";
            this.colMeses.ReadOnly = true;
            // 
            // Condicion
            // 
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.Name = "Condicion";
            this.Condicion.ReadOnly = true;
            // 
            // Cobrador
            // 
            this.Cobrador.HeaderText = "Cobrador";
            this.Cobrador.Name = "Cobrador";
            this.Cobrador.ReadOnly = true;
            // 
            // FechaIncorporacion
            // 
            this.FechaIncorporacion.HeaderText = "Fecha Incorporación";
            this.FechaIncorporacion.Name = "FechaIncorporacion";
            this.FechaIncorporacion.ReadOnly = true;
            // 
            // Provincia
            // 
            this.Provincia.HeaderText = "Provincia";
            this.Provincia.Name = "Provincia";
            this.Provincia.ReadOnly = true;
            // 
            // Canton
            // 
            this.Canton.HeaderText = "Cantón";
            this.Canton.Name = "Canton";
            this.Canton.ReadOnly = true;
            // 
            // frmGenerarCelNotificacionPorMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 749);
            this.Controls.Add(this.panelGestionCobro);
            this.Controls.Add(this.panelMorosidades);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbTipo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkGenTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMeses);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenerarCelNotificacionPorMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Reporte de Morosidad";
            this.Load += new System.EventHandler(this.frmGenerarCelNotificacionPorMes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColegiados)).EndInit();
            this.grbTipo.ResumeLayout(false);
            this.grbTipo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelMorosidades.ResumeLayout(false);
            this.panelMorosidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro2)).EndInit();
            this.panelGestionCobro.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeses;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ImageList iList;
        private System.ComponentModel.BackgroundWorker bwProceso;
        private System.Windows.Forms.DataGridView dgvColegiados;
        private Framework.UserControls.chkSaseg chkGenTotal;
        private System.Windows.Forms.Label lblRegistrosCant;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTotalRegArchivo;
        private System.Windows.Forms.Label lblRegArchivo;
		private System.Windows.Forms.GroupBox grbTipo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkAEREA;
		private Framework.UserControls.chkSaseg chkREG;
		private Framework.UserControls.chkSaseg chkCOL;
		private Framework.UserControls.chkSaseg chkPLAGUI;
		private Framework.UserControls.chkSaseg chkPER;
		private Framework.UserControls.chkSaseg chkEST;
		private Framework.UserControls.chkSaseg chkCONSUL;
		private System.Windows.Forms.Panel panelMorosidades;
		private System.Windows.Forms.DataGridView dgvGestionCobro2;
		private System.Windows.Forms.Panel panelGestionCobro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado2;
		private System.Windows.Forms.DataGridViewComboBoxColumn colMedio;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCompromiso;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCompromiso;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
		private System.Windows.Forms.DataGridViewComboBoxColumn ColEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreColegiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cobrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIncorporacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Canton;
    }
}