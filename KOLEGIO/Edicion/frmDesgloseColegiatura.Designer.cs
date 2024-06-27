namespace KOLEGIO
{
    partial class frmDesgloseColegiatura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesgloseColegiatura));
            this.cmbTipoLicencia = new Framework.UserControls.cmbSaseg();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMontoColegiatura = new Framework.UserControls.txtNormal();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCuenta = new Framework.UserControls.txtNormal();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMonto = new Framework.UserControls.txtNormal();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new Framework.UserControls.txtNormal();
            this.chkMutualidad = new Framework.UserControls.chkSaseg();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpFechaEfectiva = new Framework.UserControls.dtpSaseg();
            this.dtpFechaAcuerdo = new Framework.UserControls.dtpSaseg();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAcuerdo = new Framework.UserControls.txtNormal();
            this.label14 = new System.Windows.Forms.Label();
            this.txtActa = new Framework.UserControls.txtNormal();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcuerdo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMutualidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaEfectiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalColegiatura = new Framework.UserControls.txtNormal();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Size = new System.Drawing.Size(682, 539);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.groupBox5);
            this.tpBasicos.Controls.Add(this.dgvDatos);
            this.tpBasicos.Controls.Add(this.groupBox4);
            this.tpBasicos.Controls.Add(this.groupBox3);
            this.tpBasicos.Controls.Add(this.groupBox2);
            this.tpBasicos.Controls.Add(this.groupBox1);
            this.tpBasicos.Size = new System.Drawing.Size(674, 513);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox1, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox2, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox3, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox4, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dgvDatos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.groupBox5, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(674, 513);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(674, 513);
            // 
            // cmbTipoLicencia
            // 
            this.cmbTipoLicencia.Habilitar = true;
            this.cmbTipoLicencia.Index = -1;
            this.cmbTipoLicencia.Location = new System.Drawing.Point(21, 32);
            this.cmbTipoLicencia.Name = "cmbTipoLicencia";
            this.cmbTipoLicencia.Size = new System.Drawing.Size(259, 22);
            this.cmbTipoLicencia.TabIndex = 2;
            this.cmbTipoLicencia.Texto = "";
            this.cmbTipoLicencia.Valor = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoLicencia);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 71);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Licencia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtMontoColegiatura);
            this.groupBox2.Location = new System.Drawing.Point(323, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 71);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Monto Total de Colegiatura";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 25);
            this.label15.TabIndex = 2;
            this.label15.Text = "₡";
            // 
            // txtMontoColegiatura
            // 
            this.txtMontoColegiatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoColegiatura.FormatearNumero = false;
            this.txtMontoColegiatura.Location = new System.Drawing.Point(51, 26);
            this.txtMontoColegiatura.Longitud = 32767;
            this.txtMontoColegiatura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMontoColegiatura.Multilinea = false;
            this.txtMontoColegiatura.Name = "txtMontoColegiatura";
            this.txtMontoColegiatura.Password = '\0';
            this.txtMontoColegiatura.ReadOnly = false;
            this.txtMontoColegiatura.Size = new System.Drawing.Size(253, 32);
            this.txtMontoColegiatura.TabIndex = 0;
            this.txtMontoColegiatura.Valor = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCuenta);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtMonto);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtDescripcion);
            this.groupBox3.Controls.Add(this.chkMutualidad);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCodigo);
            this.groupBox3.Location = new System.Drawing.Point(12, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 140);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Cuenta:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.FormatearNumero = false;
            this.txtCuenta.Location = new System.Drawing.Point(76, 104);
            this.txtCuenta.Longitud = 32767;
            this.txtCuenta.Multilinea = false;
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Password = '\0';
            this.txtCuenta.ReadOnly = false;
            this.txtCuenta.Size = new System.Drawing.Size(204, 21);
            this.txtCuenta.TabIndex = 7;
            this.txtCuenta.Valor = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.FormatearNumero = false;
            this.txtMonto.Location = new System.Drawing.Point(76, 77);
            this.txtMonto.Longitud = 32767;
            this.txtMonto.Multilinea = false;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Password = '\0';
            this.txtMonto.ReadOnly = false;
            this.txtMonto.Size = new System.Drawing.Size(204, 21);
            this.txtMonto.TabIndex = 5;
            this.txtMonto.Valor = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.FormatearNumero = false;
            this.txtDescripcion.Location = new System.Drawing.Point(76, 49);
            this.txtDescripcion.Longitud = 32767;
            this.txtDescripcion.Multilinea = false;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Password = '\0';
            this.txtDescripcion.ReadOnly = false;
            this.txtDescripcion.Size = new System.Drawing.Size(204, 21);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.Valor = "";
            // 
            // chkMutualidad
            // 
            this.chkMutualidad.Checked = false;
            this.chkMutualidad.Location = new System.Drawing.Point(198, 36);
            this.chkMutualidad.Name = "chkMutualidad";
            this.chkMutualidad.Size = new System.Drawing.Size(82, 17);
            this.chkMutualidad.TabIndex = 2;
            this.chkMutualidad.Texto = "Mutualidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(76, 19);
            this.txtCodigo.Longitud = 32767;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(116, 21);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Valor = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpFechaEfectiva);
            this.groupBox4.Controls.Add(this.dtpFechaAcuerdo);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtAcuerdo);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtActa);
            this.groupBox4.Location = new System.Drawing.Point(323, 107);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(319, 140);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // dtpFechaEfectiva
            // 
            this.dtpFechaEfectiva.Checked = true;
            this.dtpFechaEfectiva.Location = new System.Drawing.Point(116, 101);
            this.dtpFechaEfectiva.mostrarCheckBox = false;
            this.dtpFechaEfectiva.mostrarUpDown = false;
            this.dtpFechaEfectiva.Name = "dtpFechaEfectiva";
            this.dtpFechaEfectiva.Size = new System.Drawing.Size(157, 22);
            this.dtpFechaEfectiva.TabIndex = 10;
            this.dtpFechaEfectiva.Value = new System.DateTime(2018, 11, 11, 11, 37, 14, 197);
            // 
            // dtpFechaAcuerdo
            // 
            this.dtpFechaAcuerdo.Checked = true;
            this.dtpFechaAcuerdo.Location = new System.Drawing.Point(116, 75);
            this.dtpFechaAcuerdo.mostrarCheckBox = false;
            this.dtpFechaAcuerdo.mostrarUpDown = false;
            this.dtpFechaAcuerdo.Name = "dtpFechaAcuerdo";
            this.dtpFechaAcuerdo.Size = new System.Drawing.Size(157, 22);
            this.dtpFechaAcuerdo.TabIndex = 9;
            this.dtpFechaAcuerdo.Value = new System.DateTime(2018, 11, 11, 11, 37, 14, 197);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Fecha Efectiva:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Fecha Acuerdo:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Acuerdo:";
            // 
            // txtAcuerdo
            // 
            this.txtAcuerdo.FormatearNumero = false;
            this.txtAcuerdo.Location = new System.Drawing.Point(116, 47);
            this.txtAcuerdo.Longitud = 32767;
            this.txtAcuerdo.Multilinea = false;
            this.txtAcuerdo.Name = "txtAcuerdo";
            this.txtAcuerdo.Password = '\0';
            this.txtAcuerdo.ReadOnly = false;
            this.txtAcuerdo.Size = new System.Drawing.Size(157, 21);
            this.txtAcuerdo.TabIndex = 3;
            this.txtAcuerdo.Valor = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(78, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Acta:";
            // 
            // txtActa
            // 
            this.txtActa.FormatearNumero = false;
            this.txtActa.Location = new System.Drawing.Point(116, 17);
            this.txtActa.Longitud = 32767;
            this.txtActa.Multilinea = false;
            this.txtActa.Name = "txtActa";
            this.txtActa.Password = '\0';
            this.txtActa.ReadOnly = false;
            this.txtActa.Size = new System.Drawing.Size(116, 21);
            this.txtActa.TabIndex = 0;
            this.txtActa.Valor = "";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colDescripcion,
            this.colMonto,
            this.colCuenta,
            this.colActa,
            this.colAcuerdo,
            this.colFecha,
            this.colMutualidad,
            this.colFechaEfectiva,
            this.colTotal});
            this.dgvDatos.Location = new System.Drawing.Point(12, 251);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(654, 176);
            this.dgvDatos.TabIndex = 10;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 65;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 150;
            // 
            // colMonto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.colMonto.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.Width = 80;
            // 
            // colCuenta
            // 
            this.colCuenta.HeaderText = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            // 
            // colActa
            // 
            this.colActa.HeaderText = "Acta";
            this.colActa.Name = "colActa";
            this.colActa.ReadOnly = true;
            this.colActa.Width = 80;
            // 
            // colAcuerdo
            // 
            this.colAcuerdo.HeaderText = "Acuerdo";
            this.colAcuerdo.Name = "colAcuerdo";
            this.colAcuerdo.ReadOnly = true;
            this.colAcuerdo.Width = 80;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 95;
            // 
            // colMutualidad
            // 
            this.colMutualidad.HeaderText = "Mutualidad";
            this.colMutualidad.Name = "colMutualidad";
            this.colMutualidad.ReadOnly = true;
            this.colMutualidad.Width = 65;
            // 
            // colFechaEfectiva
            // 
            this.colFechaEfectiva.HeaderText = "Fecha Efectiva";
            this.colFechaEfectiva.Name = "colFechaEfectiva";
            this.colFechaEfectiva.ReadOnly = true;
            this.colFechaEfectiva.Width = 95;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txtTotalColegiatura);
            this.groupBox5.Location = new System.Drawing.Point(349, 435);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(319, 71);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Total Monto Colegiatura";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 25);
            this.label16.TabIndex = 2;
            this.label16.Text = "₡";
            // 
            // txtTotalColegiatura
            // 
            this.txtTotalColegiatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalColegiatura.FormatearNumero = false;
            this.txtTotalColegiatura.Location = new System.Drawing.Point(51, 26);
            this.txtTotalColegiatura.Longitud = 32767;
            this.txtTotalColegiatura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalColegiatura.Multilinea = false;
            this.txtTotalColegiatura.Name = "txtTotalColegiatura";
            this.txtTotalColegiatura.Password = '\0';
            this.txtTotalColegiatura.ReadOnly = false;
            this.txtTotalColegiatura.Size = new System.Drawing.Size(253, 32);
            this.txtTotalColegiatura.TabIndex = 0;
            this.txtTotalColegiatura.Valor = "";
            // 
            // frmDesgloseColegiatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 630);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDesgloseColegiatura";
            this.Text = "Desglose de Colegiatura";
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpBasicos.ResumeLayout(false);
            this.tpAdmin.ResumeLayout(false);
            this.tpAdmin.PerformLayout();
            this.panelBasicos.ResumeLayout(false);
            this.panelBasicos.PerformLayout();
            this.tpAdjuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.UserControls.cmbSaseg cmbTipoLicencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Framework.UserControls.chkSaseg chkMutualidad;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtCodigo;
        private System.Windows.Forms.GroupBox groupBox2;
        private Framework.UserControls.txtNormal txtMontoColegiatura;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtDescripcion;
        private System.Windows.Forms.Label label10;
        private Framework.UserControls.txtNormal txtCuenta;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtMonto;
        private System.Windows.Forms.GroupBox groupBox4;
        private Framework.UserControls.dtpSaseg dtpFechaEfectiva;
        private Framework.UserControls.dtpSaseg dtpFechaAcuerdo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.txtNormal txtAcuerdo;
        private System.Windows.Forms.Label label14;
        private Framework.UserControls.txtNormal txtActa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcuerdo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMutualidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaEfectiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label16;
        private Framework.UserControls.txtNormal txtTotalColegiatura;
    }
}