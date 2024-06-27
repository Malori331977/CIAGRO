namespace KOLEGIO
{
    partial class frmLevantamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLevantamiento));
            this.txtNombreColegiado = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvRubros = new System.Windows.Forms.DataGridView();
            this.colArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.txtNumeroColegiado = new Framework.UserControls.txtNormal();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dgvGestionCobro = new System.Windows.Forms.DataGridView();
            this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAplicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCobrador = new System.Windows.Forms.TextBox();
            this.txtColegiado = new System.Windows.Forms.TextBox();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.txtDescCondicion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMontoArreglo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMontoPrima = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubTotalLev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubTotalPend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtPorcPrima = new System.Windows.Forms.TextBox();
            this.txtMesesArreglo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubros)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreColegiado
            // 
            this.txtNombreColegiado.Location = new System.Drawing.Point(196, 35);
            this.txtNombreColegiado.Name = "txtNombreColegiado";
            this.txtNombreColegiado.ReadOnly = true;
            this.txtNombreColegiado.Size = new System.Drawing.Size(314, 20);
            this.txtNombreColegiado.TabIndex = 279;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(39, 38);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 13);
            this.label27.TabIndex = 277;
            this.label27.Text = "Colegiado:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefrescar,
            this.btnProcesar,
            this.btnResize,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 25);
            this.toolStrip1.TabIndex = 280;
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
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
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
            // 
            // dgvRubros
            // 
            this.dgvRubros.AllowUserToAddRows = false;
            this.dgvRubros.AllowUserToResizeRows = false;
            this.dgvRubros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRubros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRubros.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArticulo,
            this.colCantidad,
            this.colDescripcion,
            this.colPrecio});
            this.dgvRubros.Location = new System.Drawing.Point(12, 71);
            this.dgvRubros.Name = "dgvRubros";
            this.dgvRubros.ReadOnly = true;
            this.dgvRubros.RowHeadersVisible = false;
            this.dgvRubros.Size = new System.Drawing.Size(789, 235);
            this.dgvRubros.TabIndex = 281;
            // 
            // colArticulo
            // 
            this.colArticulo.HeaderText = "Código";
            this.colArticulo.Name = "colArticulo";
            this.colArticulo.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // txtMeses
            // 
            this.txtMeses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeses.Location = new System.Drawing.Point(756, 35);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(42, 20);
            this.txtMeses.TabIndex = 285;
            this.txtMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMeses.TextChanged += new System.EventHandler(this.txtMeses_TextChanged);
            this.txtMeses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeses_KeyPress);
            // 
            // txtNumeroColegiado
            // 
            this.txtNumeroColegiado.FormatearNumero = false;
            this.txtNumeroColegiado.Location = new System.Drawing.Point(96, 34);
            this.txtNumeroColegiado.Longitud = 32767;
            this.txtNumeroColegiado.Multilinea = false;
            this.txtNumeroColegiado.Name = "txtNumeroColegiado";
            this.txtNumeroColegiado.Password = '\0';
            this.txtNumeroColegiado.ReadOnly = false;
            this.txtNumeroColegiado.Size = new System.Drawing.Size(88, 21);
            this.txtNumeroColegiado.TabIndex = 287;
            this.txtNumeroColegiado.Valor = "";
            this.txtNumeroColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColegiado_KeyDown);
            this.txtNumeroColegiado.Leave += new System.EventHandler(this.txtColegiado_Leave);
            this.txtNumeroColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtColegiado_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 284;
            this.label2.Text = "Cantidad Meses a Pagar:";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.dgvGestionCobro);
            this.groupBox9.Location = new System.Drawing.Point(12, 312);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(789, 241);
            this.groupBox9.TabIndex = 289;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Pendientes";
            // 
            // dgvGestionCobro
            // 
            this.dgvGestionCobro.AllowUserToAddRows = false;
            this.dgvGestionCobro.AllowUserToDeleteRows = false;
            this.dgvGestionCobro.AllowUserToResizeRows = false;
            this.dgvGestionCobro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGestionCobro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGestionCobro.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGestionCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGestionCobro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocumento,
            this.colAplicacion,
            this.colFechaDocumento,
            this.colMonto,
            this.colSaldo});
            this.dgvGestionCobro.Location = new System.Drawing.Point(3, 16);
            this.dgvGestionCobro.Name = "dgvGestionCobro";
            this.dgvGestionCobro.ReadOnly = true;
            this.dgvGestionCobro.RowHeadersVisible = false;
            this.dgvGestionCobro.Size = new System.Drawing.Size(783, 219);
            this.dgvGestionCobro.TabIndex = 246;
            // 
            // colDocumento
            // 
            this.colDocumento.HeaderText = "Documento";
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.ReadOnly = true;
            // 
            // colAplicacion
            // 
            this.colAplicacion.HeaderText = "Aplicacion";
            this.colAplicacion.Name = "colAplicacion";
            this.colAplicacion.ReadOnly = true;
            // 
            // colFechaDocumento
            // 
            this.colFechaDocumento.HeaderText = "Fecha";
            this.colFechaDocumento.Name = "colFechaDocumento";
            this.colFechaDocumento.ReadOnly = true;
            // 
            // colMonto
            // 
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            // 
            // colSaldo
            // 
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            // 
            // txtCobrador
            // 
            this.txtCobrador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCobrador.Location = new System.Drawing.Point(196, 12);
            this.txtCobrador.Name = "txtCobrador";
            this.txtCobrador.Size = new System.Drawing.Size(88, 20);
            this.txtCobrador.TabIndex = 305;
            this.txtCobrador.Visible = false;
            // 
            // txtColegiado
            // 
            this.txtColegiado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtColegiado.Location = new System.Drawing.Point(102, 12);
            this.txtColegiado.Name = "txtColegiado";
            this.txtColegiado.Size = new System.Drawing.Size(88, 20);
            this.txtColegiado.TabIndex = 304;
            this.txtColegiado.Visible = false;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCondicion.Location = new System.Drawing.Point(290, 12);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(88, 20);
            this.txtCondicion.TabIndex = 306;
            this.txtCondicion.Visible = false;
            // 
            // txtDescCondicion
            // 
            this.txtDescCondicion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDescCondicion.Location = new System.Drawing.Point(384, 12);
            this.txtDescCondicion.Name = "txtDescCondicion";
            this.txtDescCondicion.Size = new System.Drawing.Size(145, 20);
            this.txtDescCondicion.TabIndex = 307;
            this.txtDescCondicion.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(486, 644);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 16);
            this.label6.TabIndex = 325;
            this.label6.Text = "Meses de Arreglo:";
            // 
            // txtMontoArreglo
            // 
            this.txtMontoArreglo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoArreglo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoArreglo.Location = new System.Drawing.Point(698, 641);
            this.txtMontoArreglo.Name = "txtMontoArreglo";
            this.txtMontoArreglo.ReadOnly = true;
            this.txtMontoArreglo.Size = new System.Drawing.Size(100, 22);
            this.txtMontoArreglo.TabIndex = 324;
            this.txtMontoArreglo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(569, 616);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 323;
            this.label5.Text = "Prima:";
            // 
            // txtMontoPrima
            // 
            this.txtMontoPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPrima.Location = new System.Drawing.Point(698, 613);
            this.txtMontoPrima.Name = "txtMontoPrima";
            this.txtMontoPrima.ReadOnly = true;
            this.txtMontoPrima.Size = new System.Drawing.Size(100, 22);
            this.txtMontoPrima.TabIndex = 322;
            this.txtMontoPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(297, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 321;
            this.label4.Text = "Total Levantamiento:";
            // 
            // txtSubTotalLev
            // 
            this.txtSubTotalLev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotalLev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotalLev.Location = new System.Drawing.Point(456, 557);
            this.txtSubTotalLev.Name = "txtSubTotalLev";
            this.txtSubTotalLev.ReadOnly = true;
            this.txtSubTotalLev.Size = new System.Drawing.Size(100, 22);
            this.txtSubTotalLev.TabIndex = 320;
            this.txtSubTotalLev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(562, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 319;
            this.label3.Text = "Total Pendientes:";
            // 
            // txtSubTotalPend
            // 
            this.txtSubTotalPend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotalPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotalPend.Location = new System.Drawing.Point(698, 557);
            this.txtSubTotalPend.Name = "txtSubTotalPend";
            this.txtSubTotalPend.ReadOnly = true;
            this.txtSubTotalPend.Size = new System.Drawing.Size(100, 22);
            this.txtSubTotalPend.TabIndex = 318;
            this.txtSubTotalPend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(617, 588);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 317;
            this.label1.Text = "SubTotal:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(698, 585);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(100, 22);
            this.txtSubTotal.TabIndex = 316;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPorcPrima
            // 
            this.txtPorcPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcPrima.Location = new System.Drawing.Point(627, 613);
            this.txtPorcPrima.Name = "txtPorcPrima";
            this.txtPorcPrima.Size = new System.Drawing.Size(37, 22);
            this.txtPorcPrima.TabIndex = 326;
            this.txtPorcPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcPrima.TextChanged += new System.EventHandler(this.txtPorcPrima_TextChanged);
            this.txtPorcPrima.Enter += new System.EventHandler(this.txtPorcPrima_Enter);
            this.txtPorcPrima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcPrima_KeyPress);
            this.txtPorcPrima.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPorcPrima_KeyUp);
            this.txtPorcPrima.Leave += new System.EventHandler(this.txtPorcPrima_Leave);
            // 
            // txtMesesArreglo
            // 
            this.txtMesesArreglo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesesArreglo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMesesArreglo.Location = new System.Drawing.Point(627, 641);
            this.txtMesesArreglo.Name = "txtMesesArreglo";
            this.txtMesesArreglo.Size = new System.Drawing.Size(58, 22);
            this.txtMesesArreglo.TabIndex = 327;
            this.txtMesesArreglo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMesesArreglo.TextChanged += new System.EventHandler(this.txtMesesArreglo_TextChanged);
            this.txtMesesArreglo.Enter += new System.EventHandler(this.txtMesesArreglo_Enter);
            this.txtMesesArreglo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesesArreglo_KeyPress);
            this.txtMesesArreglo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMesesArreglo_KeyUp);
            this.txtMesesArreglo.Leave += new System.EventHandler(this.txtMesesArreglo_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(670, 618);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 328;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(644, 672);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 330;
            this.label8.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(698, 669);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 329;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmLevantamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 707);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMesesArreglo);
            this.Controls.Add(this.txtPorcPrima);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMontoArreglo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMontoPrima);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubTotalLev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubTotalPend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtDescCondicion);
            this.Controls.Add(this.txtCondicion);
            this.Controls.Add(this.txtCobrador);
            this.Controls.Add(this.txtColegiado);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.txtNumeroColegiado);
            this.Controls.Add(this.txtMeses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvRubros);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNombreColegiado);
            this.Controls.Add(this.label27);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLevantamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Levantamineto de Condición";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubros)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreColegiado;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.DataGridView dgvRubros;
        private System.Windows.Forms.TextBox txtMeses;
        private Framework.UserControls.txtNormal txtNumeroColegiado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dgvGestionCobro;
        private System.Windows.Forms.TextBox txtCobrador;
        private System.Windows.Forms.TextBox txtColegiado;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.TextBox txtDescCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAplicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMontoArreglo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMontoPrima;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubTotalLev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubTotalPend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtPorcPrima;
        private System.Windows.Forms.TextBox txtMesesArreglo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotal;
    }
}