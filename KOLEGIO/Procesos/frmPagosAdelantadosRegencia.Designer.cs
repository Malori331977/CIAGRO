namespace KOLEGIO
{
    partial class frmPagosAdelantadosRegencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosAdelantadosRegencia));
            this.txtNombreColegiado = new System.Windows.Forms.TextBox();
            this.txtColegiado = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefrescar = new System.Windows.Forms.ToolStripButton();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnResize = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvRubros = new System.Windows.Forms.DataGridView();
            this.colSeleccionada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCodEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtNumeroColegiado = new Framework.UserControls.txtNormal();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSaseg1 = new Framework.UserControls.chkSaseg();
            this.txtCobrador = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreColegiado
            // 
            this.txtNombreColegiado.Location = new System.Drawing.Point(190, 35);
            this.txtNombreColegiado.Name = "txtNombreColegiado";
            this.txtNombreColegiado.ReadOnly = true;
            this.txtNombreColegiado.Size = new System.Drawing.Size(314, 20);
            this.txtNombreColegiado.TabIndex = 279;
            // 
            // txtColegiado
            // 
            this.txtColegiado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtColegiado.Location = new System.Drawing.Point(416, 61);
            this.txtColegiado.Name = "txtColegiado";
            this.txtColegiado.Size = new System.Drawing.Size(88, 20);
            this.txtColegiado.TabIndex = 278;
            this.txtColegiado.Visible = false;
            this.txtColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColegiado_KeyDown);
            this.txtColegiado.Leave += new System.EventHandler(this.txtColegiado_Leave);
            this.txtColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtColegiado_MouseDoubleClick);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(39, 38);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 13);
            this.label27.TabIndex = 277;
            this.label27.Text = "Regente:";
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
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
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
            this.dgvRubros.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleccionada,
            this.colCodEstable,
            this.colEstable,
            this.colCodCategoria,
            this.colCategoria,
            this.colUltimoCobro,
            this.colCodigoArt,
            this.colDescArticulo,
            this.colPrecio});
            this.dgvRubros.Location = new System.Drawing.Point(1, 87);
            this.dgvRubros.Name = "dgvRubros";
            this.dgvRubros.ReadOnly = true;
            this.dgvRubros.RowHeadersVisible = false;
            this.dgvRubros.Size = new System.Drawing.Size(776, 307);
            this.dgvRubros.TabIndex = 281;
            this.dgvRubros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRubros_CellClick);
            // 
            // colSeleccionada
            // 
            this.colSeleccionada.HeaderText = "";
            this.colSeleccionada.Name = "colSeleccionada";
            this.colSeleccionada.ReadOnly = true;
            this.colSeleccionada.Width = 30;
            // 
            // colCodEstable
            // 
            this.colCodEstable.HeaderText = "CodEstable";
            this.colCodEstable.Name = "colCodEstable";
            this.colCodEstable.ReadOnly = true;
            this.colCodEstable.Visible = false;
            // 
            // colEstable
            // 
            this.colEstable.HeaderText = "Establecimiento";
            this.colEstable.Name = "colEstable";
            this.colEstable.ReadOnly = true;
            this.colEstable.Width = 131;
            // 
            // colCodCategoria
            // 
            this.colCodCategoria.HeaderText = "CodCategoria";
            this.colCodCategoria.Name = "colCodCategoria";
            this.colCodCategoria.ReadOnly = true;
            this.colCodCategoria.Visible = false;
            // 
            // colCategoria
            // 
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.Width = 131;
            // 
            // colUltimoCobro
            // 
            this.colUltimoCobro.HeaderText = "Último Cobro";
            this.colUltimoCobro.Name = "colUltimoCobro";
            this.colUltimoCobro.ReadOnly = true;
            // 
            // colCodigoArt
            // 
            this.colCodigoArt.HeaderText = "Código Artículo";
            this.colCodigoArt.Name = "colCodigoArt";
            this.colCodigoArt.ReadOnly = true;
            this.colCodigoArt.Width = 131;
            // 
            // colDescArticulo
            // 
            this.colDescArticulo.HeaderText = "Artículo";
            this.colDescArticulo.Name = "colDescArticulo";
            this.colDescArticulo.ReadOnly = true;
            this.colDescArticulo.Width = 131;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 131;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(637, 418);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(140, 22);
            this.txtTotal.TabIndex = 282;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(583, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 283;
            this.label1.Text = "Total:";
            // 
            // txtMeses
            // 
            this.txtMeses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeses.Location = new System.Drawing.Point(642, 35);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.Size = new System.Drawing.Size(42, 20);
            this.txtMeses.TabIndex = 285;
            this.txtMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMeses.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeses_KeyPress);
            this.txtMeses.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMeses_KeyUp);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalcular.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcular.Image")));
            this.btnCalcular.Location = new System.Drawing.Point(690, 28);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(22, 32);
            this.btnCalcular.TabIndex = 286;
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Visible = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
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
            this.label2.Location = new System.Drawing.Point(510, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 284;
            this.label2.Text = "Cantidad Meses a Pagar:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 288;
            this.label3.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuento.Location = new System.Drawing.Point(642, 61);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(42, 20);
            this.txtDescuento.TabIndex = 289;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.Enter += new System.EventHandler(this.txtDescuento_Enter);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            this.txtDescuento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyUp);
            this.txtDescuento.Leave += new System.EventHandler(this.txtDescuento_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 290;
            this.label4.Text = "%";
            // 
            // chkSaseg1
            // 
            this.chkSaseg1.Checked = false;
            this.chkSaseg1.Location = new System.Drawing.Point(190, 65);
            this.chkSaseg1.Name = "chkSaseg1";
            this.chkSaseg1.Size = new System.Drawing.Size(114, 17);
            this.chkSaseg1.TabIndex = 291;
            this.chkSaseg1.Texto = "Seleccionar todos";
            this.chkSaseg1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkSaseg1_MouseClick);
            // 
            // txtCobrador
            // 
            this.txtCobrador.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCobrador.Location = new System.Drawing.Point(322, 61);
            this.txtCobrador.Name = "txtCobrador";
            this.txtCobrador.Size = new System.Drawing.Size(88, 20);
            this.txtCobrador.TabIndex = 292;
            this.txtCobrador.Visible = false;
            // 
            // frmPagosAdelantadosRegencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCobrador);
            this.Controls.Add(this.chkSaseg1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumeroColegiado);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtMeses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgvRubros);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNombreColegiado);
            this.Controls.Add(this.txtColegiado);
            this.Controls.Add(this.label27);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPagosAdelantadosRegencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar Adelanto de Pagos por Regencia";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreColegiado;
        private System.Windows.Forms.TextBox txtColegiado;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefrescar;
        private System.Windows.Forms.ToolStripButton btnProcesar;
        private System.Windows.Forms.ToolStripButton btnResize;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.DataGridView dgvRubros;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeses;
        private System.Windows.Forms.Button btnCalcular;
        private Framework.UserControls.txtNormal txtNumeroColegiado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label4;
        private Framework.UserControls.chkSaseg chkSaseg1;
        private System.Windows.Forms.TextBox txtCobrador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodEstable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimoCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
    }
}