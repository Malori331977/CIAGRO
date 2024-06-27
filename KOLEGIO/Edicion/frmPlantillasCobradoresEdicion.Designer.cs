namespace KOLEGIO
{
    partial class frmPlantillasCobradoresEdicion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlantillasCobradoresEdicion));
			this.txtNombre = new Framework.UserControls.txtNormal();
			this.txtCobrador = new Framework.UserControls.txtNormal();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCobradorNombre = new Framework.UserControls.txtNormal();
			this.dgvPlantilla = new System.Windows.Forms.DataGridView();
			this.colOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCaracteres = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTamColumna = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMacro = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btnNuevaFila = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarFila = new System.Windows.Forms.ToolStripButton();
			this.tpConfiguracion = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.grbTipoIdentificacion = new System.Windows.Forms.GroupBox();
			this.rbRespNumCole = new Framework.UserControls.rbSaseg();
			this.rbRespCedula = new Framework.UserControls.rbSaseg();
			this.txtSubTipoDocNombre = new Framework.UserControls.txtNormal();
			this.txtSubTipoDoc = new Framework.UserControls.txtNormal();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbPREDEF = new Framework.UserControls.rbSaseg();
			this.rbIGUAL = new Framework.UserControls.rbSaseg();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkCeroCedula = new Framework.UserControls.chkSaseg();
			this.chkTotalMonto = new Framework.UserControls.chkSaseg();
			this.chkTotalReg = new Framework.UserControls.chkSaseg();
			this.txtFormatoInicioLinea = new Framework.UserControls.txtNormal();
			this.label10 = new System.Windows.Forms.Label();
			this.grbSeparadorCsv = new System.Windows.Forms.GroupBox();
			this.rbSeparadorPuntoComa = new Framework.UserControls.rbSaseg();
			this.rbSeparadorComa = new Framework.UserControls.rbSaseg();
			this.chkConTab = new Framework.UserControls.chkSaseg();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.rbCobrador = new Framework.UserControls.rbSaseg();
			this.rbTotal = new Framework.UserControls.rbSaseg();
			this.chkListadoArchFactura = new Framework.UserControls.chkSaseg();
			this.chkProyeccion = new Framework.UserControls.chkSaseg();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.rbAPagoPorDoc = new Framework.UserControls.rbSaseg();
			this.rbAPagoSumar = new Framework.UserControls.rbSaseg();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkRubroPLAGUI = new Framework.UserControls.chkSaseg();
			this.chkRubroAEREA = new Framework.UserControls.chkSaseg();
			this.chkRubroPER = new Framework.UserControls.chkSaseg();
			this.chkRubroREG = new Framework.UserControls.chkSaseg();
			this.chkRubroCOL = new Framework.UserControls.chkSaseg();
			this.chkIngresaCerosAdelante = new Framework.UserControls.chkSaseg();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbCSV = new Framework.UserControls.rbSaseg();
			this.rbTXT = new Framework.UserControls.rbSaseg();
			this.rbXLS = new Framework.UserControls.rbSaseg();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label31 = new System.Windows.Forms.Label();
			this.chkDetEncabezado = new Framework.UserControls.chkSaseg();
			this.label11 = new System.Windows.Forms.Label();
			this.txtCodigo = new Framework.UserControls.txtNormal();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlantilla)).BeginInit();
			this.panel2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.tpConfiguracion.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.grbTipoIdentificacion.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grbSeparadorCsv.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpConfiguracion);
			this.tabControl.Size = new System.Drawing.Size(885, 517);
			this.tabControl.Controls.SetChildIndex(this.tpConfiguracion, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
			this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.label11);
			this.tpBasicos.Controls.Add(this.txtCodigo);
			this.tpBasicos.Controls.Add(this.panel2);
			this.tpBasicos.Controls.Add(this.dgvPlantilla);
			this.tpBasicos.Controls.Add(this.txtCobradorNombre);
			this.tpBasicos.Controls.Add(this.label8);
			this.tpBasicos.Controls.Add(this.label7);
			this.tpBasicos.Controls.Add(this.txtCobrador);
			this.tpBasicos.Controls.Add(this.txtNombre);
			this.tpBasicos.Size = new System.Drawing.Size(877, 491);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCobrador, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCobradorNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dgvPlantilla, 0);
			this.tpBasicos.Controls.SetChildIndex(this.panel2, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
			// 
			// tpAdmin
			// 
			this.tpAdmin.Size = new System.Drawing.Size(877, 437);
			// 
			// panelAdmin
			// 
			this.panelAdmin.Size = new System.Drawing.Size(871, 21);
			// 
			// panelBasicos
			// 
			this.panelBasicos.Size = new System.Drawing.Size(871, 21);
			// 
			// tpAdjuntos
			// 
			this.tpAdjuntos.Size = new System.Drawing.Size(877, 437);
			// 
			// panelAdjuntos
			// 
			this.panelAdjuntos.Size = new System.Drawing.Size(871, 21);
			// 
			// txtNombre
			// 
			this.txtNombre.FormatearNumero = false;
			this.txtNombre.Location = new System.Drawing.Point(279, 35);
			this.txtNombre.Longitud = 32767;
			this.txtNombre.Multilinea = false;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Password = '\0';
			this.txtNombre.ReadOnly = false;
			this.txtNombre.Size = new System.Drawing.Size(244, 21);
			this.txtNombre.TabIndex = 2;
			this.txtNombre.Valor = "";
			// 
			// txtCobrador
			// 
			this.txtCobrador.FormatearNumero = false;
			this.txtCobrador.Location = new System.Drawing.Point(584, 35);
			this.txtCobrador.Longitud = 32767;
			this.txtCobrador.Multilinea = false;
			this.txtCobrador.Name = "txtCobrador";
			this.txtCobrador.Password = '\0';
			this.txtCobrador.ReadOnly = false;
			this.txtCobrador.Size = new System.Drawing.Size(76, 21);
			this.txtCobrador.TabIndex = 3;
			this.txtCobrador.Valor = "";
			this.txtCobrador.Enter += new System.EventHandler(this.txtCobrador_Enter);
			this.txtCobrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobrador_KeyDown);
			this.txtCobrador.Leave += new System.EventHandler(this.txtCobrador_Leave);
			this.txtCobrador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCobrador_MouseDoubleClick);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 39);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Codigo:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(529, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Cobrador:";
			// 
			// txtCobradorNombre
			// 
			this.txtCobradorNombre.FormatearNumero = false;
			this.txtCobradorNombre.Location = new System.Drawing.Point(662, 35);
			this.txtCobradorNombre.Longitud = 32767;
			this.txtCobradorNombre.Multilinea = false;
			this.txtCobradorNombre.Name = "txtCobradorNombre";
			this.txtCobradorNombre.Password = '\0';
			this.txtCobradorNombre.ReadOnly = true;
			this.txtCobradorNombre.Size = new System.Drawing.Size(207, 21);
			this.txtCobradorNombre.TabIndex = 6;
			this.txtCobradorNombre.Valor = "";
			// 
			// dgvPlantilla
			// 
			this.dgvPlantilla.AllowUserToAddRows = false;
			this.dgvPlantilla.AllowUserToDeleteRows = false;
			this.dgvPlantilla.AllowUserToResizeRows = false;
			this.dgvPlantilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPlantilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvPlantilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPlantilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrden,
            this.colColumna,
            this.colCaracteres,
            this.colTamColumna,
            this.colDetalle,
            this.colMacro,
            this.colFormato});
			this.dgvPlantilla.Location = new System.Drawing.Point(3, 112);
			this.dgvPlantilla.Name = "dgvPlantilla";
			this.dgvPlantilla.RowHeadersVisible = false;
			this.dgvPlantilla.Size = new System.Drawing.Size(866, 373);
			this.dgvPlantilla.TabIndex = 8;
			this.dgvPlantilla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlantilla_CellEndEdit);
			this.dgvPlantilla.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPlantilla_CurrentCellDirtyStateChanged);
			// 
			// colOrden
			// 
			this.colOrden.FillWeight = 64.9189F;
			this.colOrden.HeaderText = "Orden";
			this.colOrden.Name = "colOrden";
			// 
			// colColumna
			// 
			this.colColumna.FillWeight = 67.32555F;
			this.colColumna.HeaderText = "Columna";
			this.colColumna.Name = "colColumna";
			this.colColumna.Visible = false;
			// 
			// colCaracteres
			// 
			this.colCaracteres.FillWeight = 60.9137F;
			this.colCaracteres.HeaderText = "Cantidad Caracteres";
			this.colCaracteres.Name = "colCaracteres";
			this.colCaracteres.Visible = false;
			// 
			// colTamColumna
			// 
			this.colTamColumna.HeaderText = "Tamaño Columna";
			this.colTamColumna.Name = "colTamColumna";
			this.colTamColumna.Visible = false;
			// 
			// colDetalle
			// 
			this.colDetalle.FillWeight = 198.6103F;
			this.colDetalle.HeaderText = "Detalle";
			this.colDetalle.Name = "colDetalle";
			// 
			// colMacro
			// 
			this.colMacro.FillWeight = 114.9065F;
			this.colMacro.HeaderText = "Macro";
			this.colMacro.Items.AddRange(new object[] {
            "AÑO",
            "APLICACION",
            "CARNET",
            "CEDULA",
            "CONSTANTE",
            "CONTADOR",
            "CORREO",
            "DECIMALES",
            "FECHA",
            "FECHA_CON_CONSECUTIVO",
            "FECHA_FACTURA",
            "FECHA_FIN_MES",
            "FECHA_INICIO_MES",
            "MES",
            "MONTO",
            "NOMBRE",
            "NUMERO_FACTURA",
            "SALDO",
            "TARJETA",
            "VENCIMIENTO_FACTURA",
            "VENCIMIENTO_TARJETA",
            "VENDEDOR"});
			this.colMacro.Name = "colMacro";
			this.colMacro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colMacro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colFormato
			// 
			this.colFormato.FillWeight = 93.32505F;
			this.colFormato.HeaderText = "Formato";
			this.colFormato.Name = "colFormato";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.toolStrip3);
			this.panel2.Location = new System.Drawing.Point(3, 85);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(105, 29);
			this.panel2.TabIndex = 9;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevaFila,
            this.btnEliminarFila});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(105, 25);
			this.toolStrip3.TabIndex = 0;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// btnNuevaFila
			// 
			this.btnNuevaFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevaFila.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaFila.Image")));
			this.btnNuevaFila.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevaFila.Name = "btnNuevaFila";
			this.btnNuevaFila.Size = new System.Drawing.Size(23, 22);
			this.btnNuevaFila.Text = "Nuevo";
			this.btnNuevaFila.Click += new System.EventHandler(this.btnNuevaFila_Click);
			// 
			// btnEliminarFila
			// 
			this.btnEliminarFila.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarFila.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarFila.Image")));
			this.btnEliminarFila.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarFila.Name = "btnEliminarFila";
			this.btnEliminarFila.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarFila.Text = "Eliminar";
			this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
			// 
			// tpConfiguracion
			// 
			this.tpConfiguracion.Controls.Add(this.groupBox7);
			this.tpConfiguracion.Controls.Add(this.groupBox3);
			this.tpConfiguracion.Controls.Add(this.panel3);
			this.tpConfiguracion.Location = new System.Drawing.Point(4, 22);
			this.tpConfiguracion.Name = "tpConfiguracion";
			this.tpConfiguracion.Padding = new System.Windows.Forms.Padding(3);
			this.tpConfiguracion.Size = new System.Drawing.Size(877, 437);
			this.tpConfiguracion.TabIndex = 3;
			this.tpConfiguracion.Text = "Configuración";
			this.tpConfiguracion.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.grbTipoIdentificacion);
			this.groupBox7.Controls.Add(this.txtSubTipoDocNombre);
			this.groupBox7.Controls.Add(this.txtSubTipoDoc);
			this.groupBox7.Controls.Add(this.label9);
			this.groupBox7.Controls.Add(this.groupBox2);
			this.groupBox7.Location = new System.Drawing.Point(523, 30);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(322, 391);
			this.groupBox7.TabIndex = 52;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Archivo de Respuesta";
			// 
			// grbTipoIdentificacion
			// 
			this.grbTipoIdentificacion.Controls.Add(this.rbRespNumCole);
			this.grbTipoIdentificacion.Controls.Add(this.rbRespCedula);
			this.grbTipoIdentificacion.Location = new System.Drawing.Point(21, 116);
			this.grbTipoIdentificacion.Name = "grbTipoIdentificacion";
			this.grbTipoIdentificacion.Size = new System.Drawing.Size(241, 46);
			this.grbTipoIdentificacion.TabIndex = 58;
			this.grbTipoIdentificacion.TabStop = false;
			this.grbTipoIdentificacion.Text = "Tipo de Identificación";
			this.grbTipoIdentificacion.Visible = false;
			// 
			// rbRespNumCole
			// 
			this.rbRespNumCole.Checked = false;
			this.rbRespNumCole.Location = new System.Drawing.Point(112, 17);
			this.rbRespNumCole.Name = "rbRespNumCole";
			this.rbRespNumCole.Size = new System.Drawing.Size(100, 18);
			this.rbRespNumCole.TabIndex = 1;
			this.rbRespNumCole.Texto = "N° Colegiado";
			// 
			// rbRespCedula
			// 
			this.rbRespCedula.Checked = false;
			this.rbRespCedula.Location = new System.Drawing.Point(30, 17);
			this.rbRespCedula.Name = "rbRespCedula";
			this.rbRespCedula.Size = new System.Drawing.Size(62, 18);
			this.rbRespCedula.TabIndex = 0;
			this.rbRespCedula.Texto = "Cedula";
			// 
			// txtSubTipoDocNombre
			// 
			this.txtSubTipoDocNombre.FormatearNumero = false;
			this.txtSubTipoDocNombre.Location = new System.Drawing.Point(99, 34);
			this.txtSubTipoDocNombre.Longitud = 32767;
			this.txtSubTipoDocNombre.Multilinea = false;
			this.txtSubTipoDocNombre.Name = "txtSubTipoDocNombre";
			this.txtSubTipoDocNombre.Password = '\0';
			this.txtSubTipoDocNombre.ReadOnly = true;
			this.txtSubTipoDocNombre.Size = new System.Drawing.Size(207, 21);
			this.txtSubTipoDocNombre.TabIndex = 57;
			this.txtSubTipoDocNombre.Valor = "";
			// 
			// txtSubTipoDoc
			// 
			this.txtSubTipoDoc.FormatearNumero = false;
			this.txtSubTipoDoc.Location = new System.Drawing.Point(21, 34);
			this.txtSubTipoDoc.Longitud = 32767;
			this.txtSubTipoDoc.Multilinea = false;
			this.txtSubTipoDoc.Name = "txtSubTipoDoc";
			this.txtSubTipoDoc.Password = '\0';
			this.txtSubTipoDoc.ReadOnly = false;
			this.txtSubTipoDoc.Size = new System.Drawing.Size(76, 21);
			this.txtSubTipoDoc.TabIndex = 55;
			this.txtSubTipoDoc.Valor = "";
			this.txtSubTipoDoc.Enter += new System.EventHandler(this.txtSubTipoDoc_Enter);
			this.txtSubTipoDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubTipoDoc_KeyDown);
			this.txtSubTipoDoc.Leave += new System.EventHandler(this.txtSubTipoDoc_Leave);
			this.txtSubTipoDoc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtSubTipoDoc_MouseDoubleClick);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(18, 18);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(73, 13);
			this.label9.TabIndex = 56;
			this.label9.Text = "SubTipo Doc:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbPREDEF);
			this.groupBox2.Controls.Add(this.rbIGUAL);
			this.groupBox2.Location = new System.Drawing.Point(21, 61);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(241, 46);
			this.groupBox2.TabIndex = 52;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Formato Respuesta";
			// 
			// rbPREDEF
			// 
			this.rbPREDEF.Checked = false;
			this.rbPREDEF.Location = new System.Drawing.Point(112, 17);
			this.rbPREDEF.Name = "rbPREDEF";
			this.rbPREDEF.Size = new System.Drawing.Size(100, 18);
			this.rbPREDEF.TabIndex = 1;
			this.rbPREDEF.Texto = "Predefinida";
			this.rbPREDEF.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbPREDEF_MouseClick);
			// 
			// rbIGUAL
			// 
			this.rbIGUAL.Checked = false;
			this.rbIGUAL.Location = new System.Drawing.Point(30, 17);
			this.rbIGUAL.Name = "rbIGUAL";
			this.rbIGUAL.Size = new System.Drawing.Size(62, 18);
			this.rbIGUAL.TabIndex = 0;
			this.rbIGUAL.Texto = "Igual";
			this.rbIGUAL.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbIGUAL_MouseClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkDetEncabezado);
			this.groupBox3.Controls.Add(this.chkCeroCedula);
			this.groupBox3.Controls.Add(this.chkTotalMonto);
			this.groupBox3.Controls.Add(this.chkTotalReg);
			this.groupBox3.Controls.Add(this.txtFormatoInicioLinea);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.grbSeparadorCsv);
			this.groupBox3.Controls.Add(this.chkConTab);
			this.groupBox3.Controls.Add(this.groupBox6);
			this.groupBox3.Controls.Add(this.chkListadoArchFactura);
			this.groupBox3.Controls.Add(this.chkProyeccion);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.chkIngresaCerosAdelante);
			this.groupBox3.Controls.Add(this.groupBox1);
			this.groupBox3.Location = new System.Drawing.Point(36, 30);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(465, 391);
			this.groupBox3.TabIndex = 50;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Archivo a Generar";
			// 
			// chkCeroCedula
			// 
			this.chkCeroCedula.Checked = false;
			this.chkCeroCedula.Location = new System.Drawing.Point(8, 305);
			this.chkCeroCedula.Name = "chkCeroCedula";
			this.chkCeroCedula.Size = new System.Drawing.Size(168, 17);
			this.chkCeroCedula.TabIndex = 73;
			this.chkCeroCedula.Texto = "Cero incial en cédula";
			// 
			// chkTotalMonto
			// 
			this.chkTotalMonto.Checked = false;
			this.chkTotalMonto.Location = new System.Drawing.Point(239, 282);
			this.chkTotalMonto.Name = "chkTotalMonto";
			this.chkTotalMonto.Size = new System.Drawing.Size(168, 17);
			this.chkTotalMonto.TabIndex = 72;
			this.chkTotalMonto.Texto = "Sumatoria de monto al final";
			// 
			// chkTotalReg
			// 
			this.chkTotalReg.Checked = false;
			this.chkTotalReg.Location = new System.Drawing.Point(8, 282);
			this.chkTotalReg.Name = "chkTotalReg";
			this.chkTotalReg.Size = new System.Drawing.Size(168, 17);
			this.chkTotalReg.TabIndex = 71;
			this.chkTotalReg.Texto = "Total de registros al final";
			// 
			// txtFormatoInicioLinea
			// 
			this.txtFormatoInicioLinea.FormatearNumero = false;
			this.txtFormatoInicioLinea.Location = new System.Drawing.Point(9, 203);
			this.txtFormatoInicioLinea.Longitud = 32767;
			this.txtFormatoInicioLinea.Multilinea = false;
			this.txtFormatoInicioLinea.Name = "txtFormatoInicioLinea";
			this.txtFormatoInicioLinea.Password = '\0';
			this.txtFormatoInicioLinea.ReadOnly = false;
			this.txtFormatoInicioLinea.Size = new System.Drawing.Size(220, 21);
			this.txtFormatoInicioLinea.TabIndex = 70;
			this.txtFormatoInicioLinea.Valor = "";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 186);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(115, 13);
			this.label10.TabIndex = 69;
			this.label10.Text = "Fomato inicio de linea: ";
			// 
			// grbSeparadorCsv
			// 
			this.grbSeparadorCsv.Controls.Add(this.rbSeparadorPuntoComa);
			this.grbSeparadorCsv.Controls.Add(this.rbSeparadorComa);
			this.grbSeparadorCsv.Location = new System.Drawing.Point(9, 123);
			this.grbSeparadorCsv.Name = "grbSeparadorCsv";
			this.grbSeparadorCsv.Size = new System.Drawing.Size(225, 46);
			this.grbSeparadorCsv.TabIndex = 67;
			this.grbSeparadorCsv.TabStop = false;
			this.grbSeparadorCsv.Text = "Separador CSV";
			this.grbSeparadorCsv.Visible = false;
			// 
			// rbSeparadorPuntoComa
			// 
			this.rbSeparadorPuntoComa.Checked = false;
			this.rbSeparadorPuntoComa.Location = new System.Drawing.Point(110, 17);
			this.rbSeparadorPuntoComa.Name = "rbSeparadorPuntoComa";
			this.rbSeparadorPuntoComa.Size = new System.Drawing.Size(91, 18);
			this.rbSeparadorPuntoComa.TabIndex = 1;
			this.rbSeparadorPuntoComa.Texto = "Punto y coma";
			// 
			// rbSeparadorComa
			// 
			this.rbSeparadorComa.Checked = false;
			this.rbSeparadorComa.Location = new System.Drawing.Point(30, 17);
			this.rbSeparadorComa.Name = "rbSeparadorComa";
			this.rbSeparadorComa.Size = new System.Drawing.Size(46, 18);
			this.rbSeparadorComa.TabIndex = 0;
			this.rbSeparadorComa.Texto = "Coma";
			// 
			// chkConTab
			// 
			this.chkConTab.Checked = false;
			this.chkConTab.Location = new System.Drawing.Point(8, 259);
			this.chkConTab.Name = "chkConTab";
			this.chkConTab.Size = new System.Drawing.Size(168, 17);
			this.chkConTab.TabIndex = 66;
			this.chkConTab.Texto = "Con tab al finalizar frase";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.rbCobrador);
			this.groupBox6.Controls.Add(this.rbTotal);
			this.groupBox6.Location = new System.Drawing.Point(240, 19);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(214, 46);
			this.groupBox6.TabIndex = 65;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Generar por";
			// 
			// rbCobrador
			// 
			this.rbCobrador.Checked = false;
			this.rbCobrador.Location = new System.Drawing.Point(122, 17);
			this.rbCobrador.Name = "rbCobrador";
			this.rbCobrador.Size = new System.Drawing.Size(79, 18);
			this.rbCobrador.TabIndex = 1;
			this.rbCobrador.Texto = "Cobrador";
			// 
			// rbTotal
			// 
			this.rbTotal.Checked = false;
			this.rbTotal.Location = new System.Drawing.Point(30, 17);
			this.rbTotal.Name = "rbTotal";
			this.rbTotal.Size = new System.Drawing.Size(46, 18);
			this.rbTotal.TabIndex = 0;
			this.rbTotal.Texto = "Total";
			// 
			// chkListadoArchFactura
			// 
			this.chkListadoArchFactura.Checked = false;
			this.chkListadoArchFactura.Location = new System.Drawing.Point(239, 259);
			this.chkListadoArchFactura.Name = "chkListadoArchFactura";
			this.chkListadoArchFactura.Size = new System.Drawing.Size(168, 17);
			this.chkListadoArchFactura.TabIndex = 64;
			this.chkListadoArchFactura.Texto = "Listado por factura";
			// 
			// chkProyeccion
			// 
			this.chkProyeccion.Checked = false;
			this.chkProyeccion.Location = new System.Drawing.Point(239, 236);
			this.chkProyeccion.Name = "chkProyeccion";
			this.chkProyeccion.Size = new System.Drawing.Size(168, 17);
			this.chkProyeccion.TabIndex = 63;
			this.chkProyeccion.Texto = "Proyectar siguiente mes";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.rbAPagoPorDoc);
			this.groupBox5.Controls.Add(this.rbAPagoSumar);
			this.groupBox5.Location = new System.Drawing.Point(8, 71);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(226, 46);
			this.groupBox5.TabIndex = 62;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Arreglos de Pago";
			// 
			// rbAPagoPorDoc
			// 
			this.rbAPagoPorDoc.Checked = false;
			this.rbAPagoPorDoc.Location = new System.Drawing.Point(117, 17);
			this.rbAPagoPorDoc.Name = "rbAPagoPorDoc";
			this.rbAPagoPorDoc.Size = new System.Drawing.Size(107, 18);
			this.rbAPagoPorDoc.TabIndex = 10;
			this.rbAPagoPorDoc.Texto = "Por Documento";
			// 
			// rbAPagoSumar
			// 
			this.rbAPagoSumar.Checked = false;
			this.rbAPagoSumar.Location = new System.Drawing.Point(6, 17);
			this.rbAPagoSumar.Name = "rbAPagoSumar";
			this.rbAPagoSumar.Size = new System.Drawing.Size(112, 18);
			this.rbAPagoSumar.TabIndex = 0;
			this.rbAPagoSumar.Texto = "Sumar a Factura";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkRubroPLAGUI);
			this.groupBox4.Controls.Add(this.chkRubroAEREA);
			this.groupBox4.Controls.Add(this.chkRubroPER);
			this.groupBox4.Controls.Add(this.chkRubroREG);
			this.groupBox4.Controls.Add(this.chkRubroCOL);
			this.groupBox4.Location = new System.Drawing.Point(240, 71);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(214, 98);
			this.groupBox4.TabIndex = 61;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Rubros";
			// 
			// chkRubroPLAGUI
			// 
			this.chkRubroPLAGUI.Checked = false;
			this.chkRubroPLAGUI.Location = new System.Drawing.Point(18, 68);
			this.chkRubroPLAGUI.Name = "chkRubroPLAGUI";
			this.chkRubroPLAGUI.Size = new System.Drawing.Size(86, 17);
			this.chkRubroPLAGUI.TabIndex = 59;
			this.chkRubroPLAGUI.Texto = "Plaguicidas";
			// 
			// chkRubroAEREA
			// 
			this.chkRubroAEREA.Checked = false;
			this.chkRubroAEREA.Location = new System.Drawing.Point(110, 45);
			this.chkRubroAEREA.Name = "chkRubroAEREA";
			this.chkRubroAEREA.Size = new System.Drawing.Size(86, 17);
			this.chkRubroAEREA.TabIndex = 58;
			this.chkRubroAEREA.Texto = "Vía aérea";
			// 
			// chkRubroPER
			// 
			this.chkRubroPER.Checked = false;
			this.chkRubroPER.Location = new System.Drawing.Point(18, 45);
			this.chkRubroPER.Name = "chkRubroPER";
			this.chkRubroPER.Size = new System.Drawing.Size(86, 17);
			this.chkRubroPER.TabIndex = 57;
			this.chkRubroPER.Texto = "Peritos";
			// 
			// chkRubroREG
			// 
			this.chkRubroREG.Checked = false;
			this.chkRubroREG.Location = new System.Drawing.Point(110, 19);
			this.chkRubroREG.Name = "chkRubroREG";
			this.chkRubroREG.Size = new System.Drawing.Size(79, 17);
			this.chkRubroREG.TabIndex = 56;
			this.chkRubroREG.Texto = "Regencias";
			// 
			// chkRubroCOL
			// 
			this.chkRubroCOL.Checked = false;
			this.chkRubroCOL.Location = new System.Drawing.Point(18, 19);
			this.chkRubroCOL.Name = "chkRubroCOL";
			this.chkRubroCOL.Size = new System.Drawing.Size(86, 17);
			this.chkRubroCOL.TabIndex = 55;
			this.chkRubroCOL.Texto = "Colegiaturas";
			// 
			// chkIngresaCerosAdelante
			// 
			this.chkIngresaCerosAdelante.Checked = false;
			this.chkIngresaCerosAdelante.Location = new System.Drawing.Point(8, 236);
			this.chkIngresaCerosAdelante.Name = "chkIngresaCerosAdelante";
			this.chkIngresaCerosAdelante.Size = new System.Drawing.Size(168, 17);
			this.chkIngresaCerosAdelante.TabIndex = 58;
			this.chkIngresaCerosAdelante.Texto = "Con ceros al inicio en Montos";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbCSV);
			this.groupBox1.Controls.Add(this.rbTXT);
			this.groupBox1.Controls.Add(this.rbXLS);
			this.groupBox1.Location = new System.Drawing.Point(8, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(226, 46);
			this.groupBox1.TabIndex = 50;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Formato";
			// 
			// rbCSV
			// 
			this.rbCSV.Checked = false;
			this.rbCSV.Location = new System.Drawing.Point(161, 17);
			this.rbCSV.Name = "rbCSV";
			this.rbCSV.Size = new System.Drawing.Size(46, 18);
			this.rbCSV.TabIndex = 10;
			this.rbCSV.Texto = "CSV";
			this.rbCSV.Click += new System.EventHandler(this.rbCSV_Click);
			this.rbCSV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbCSV_MouseClick);
			// 
			// rbTXT
			// 
			this.rbTXT.Checked = false;
			this.rbTXT.Location = new System.Drawing.Point(92, 17);
			this.rbTXT.Name = "rbTXT";
			this.rbTXT.Size = new System.Drawing.Size(46, 18);
			this.rbTXT.TabIndex = 1;
			this.rbTXT.Texto = "TXT";
			this.rbTXT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbTXT_MouseClick);
			// 
			// rbXLS
			// 
			this.rbXLS.Checked = false;
			this.rbXLS.Location = new System.Drawing.Point(30, 17);
			this.rbXLS.Name = "rbXLS";
			this.rbXLS.Size = new System.Drawing.Size(46, 18);
			this.rbXLS.TabIndex = 0;
			this.rbXLS.Texto = "XLS";
			this.rbXLS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbXLS_MouseClick);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.DarkGray;
			this.panel3.Controls.Add(this.label31);
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(871, 21);
			this.panel3.TabIndex = 40;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label31.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label31.Location = new System.Drawing.Point(3, 4);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(65, 14);
			this.label31.TabIndex = 0;
			this.label31.Text = "Categorías";
			// 
			// chkDetEncabezado
			// 
			this.chkDetEncabezado.Checked = false;
			this.chkDetEncabezado.Location = new System.Drawing.Point(239, 305);
			this.chkDetEncabezado.Name = "chkDetEncabezado";
			this.chkDetEncabezado.Size = new System.Drawing.Size(168, 17);
			this.chkDetEncabezado.TabIndex = 74;
			this.chkDetEncabezado.Texto = "Detalle como encabezado";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(229, 39);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 13);
			this.label11.TabIndex = 11;
			this.label11.Text = "Nombre:";
			// 
			// txtCodigo
			// 
			this.txtCodigo.FormatearNumero = false;
			this.txtCodigo.Location = new System.Drawing.Point(58, 35);
			this.txtCodigo.Longitud = 10;
			this.txtCodigo.Multilinea = false;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Password = '\0';
			this.txtCodigo.ReadOnly = false;
			this.txtCodigo.Size = new System.Drawing.Size(162, 21);
			this.txtCodigo.TabIndex = 10;
			this.txtCodigo.Valor = "";
			// 
			// frmPlantillasCobradoresEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(885, 608);
			this.Name = "frmPlantillasCobradoresEdicion";
			this.Text = "frmPlantillasCobradoresEdicion";
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
			((System.ComponentModel.ISupportInitialize)(this.dgvPlantilla)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.tpConfiguracion.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.grbTipoIdentificacion.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.grbSeparadorCsv.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Framework.UserControls.txtNormal txtNombre;
        private Framework.UserControls.txtNormal txtCobradorNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtCobrador;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevaFila;
        private System.Windows.Forms.ToolStripButton btnEliminarFila;
        private System.Windows.Forms.DataGridView dgvPlantilla;
        private System.Windows.Forms.TabPage tpConfiguracion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox3;
        private Framework.UserControls.chkSaseg chkIngresaCerosAdelante;
        private Framework.UserControls.txtNormal txtSubTipoDocNombre;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtSubTipoDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private Framework.UserControls.rbSaseg rbPREDEF;
        private Framework.UserControls.rbSaseg rbIGUAL;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.UserControls.rbSaseg rbCSV;
        private Framework.UserControls.rbSaseg rbTXT;
        private Framework.UserControls.rbSaseg rbXLS;
        private System.Windows.Forms.GroupBox groupBox5;
        private Framework.UserControls.rbSaseg rbAPagoPorDoc;
        private Framework.UserControls.rbSaseg rbAPagoSumar;
        private System.Windows.Forms.GroupBox groupBox4;
        private Framework.UserControls.chkSaseg chkRubroREG;
        private Framework.UserControls.chkSaseg chkRubroCOL;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox grbTipoIdentificacion;
        private Framework.UserControls.rbSaseg rbRespNumCole;
        private Framework.UserControls.rbSaseg rbRespCedula;
        private Framework.UserControls.chkSaseg chkProyeccion;
        private Framework.UserControls.chkSaseg chkListadoArchFactura;
        private System.Windows.Forms.GroupBox groupBox6;
        private Framework.UserControls.rbSaseg rbCobrador;
        private Framework.UserControls.rbSaseg rbTotal;
		private Framework.UserControls.chkSaseg chkConTab;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOrden;
		private System.Windows.Forms.DataGridViewTextBoxColumn colColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCaracteres;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTamColumna;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
		private System.Windows.Forms.DataGridViewComboBoxColumn colMacro;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFormato;
		private System.Windows.Forms.GroupBox grbSeparadorCsv;
		private Framework.UserControls.rbSaseg rbSeparadorPuntoComa;
		private Framework.UserControls.rbSaseg rbSeparadorComa;
		private System.Windows.Forms.Label label10;
		private Framework.UserControls.txtNormal txtFormatoInicioLinea;
		private Framework.UserControls.chkSaseg chkRubroPLAGUI;
		private Framework.UserControls.chkSaseg chkRubroAEREA;
		private Framework.UserControls.chkSaseg chkRubroPER;
		private Framework.UserControls.chkSaseg chkTotalMonto;
		private Framework.UserControls.chkSaseg chkTotalReg;
		private Framework.UserControls.chkSaseg chkCeroCedula;
		private Framework.UserControls.chkSaseg chkDetEncabezado;
		private System.Windows.Forms.Label label11;
		private Framework.UserControls.txtNormal txtCodigo;
	}
}