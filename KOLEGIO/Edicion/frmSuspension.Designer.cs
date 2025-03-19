namespace KOLEGIO.Edicion
{
    partial class frmSuspension
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumResolucion = new System.Windows.Forms.Label();
            this.lblTipoSuspension = new System.Windows.Forms.Label();
            this.txtNumeroResolución = new Framework.UserControls.txtNormal();
            this.txtTipoSuspension = new Framework.UserControls.txtNormal();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblNumResolucion);
            this.groupBox1.Controls.Add(this.lblTipoSuspension);
            this.groupBox1.Controls.Add(this.txtNumeroResolución);
            this.groupBox1.Controls.Add(this.txtTipoSuspension);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 150);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Suspensión";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(166, 114);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(136, 20);
            this.dtpFechaFinal.TabIndex = 308;
            this.dtpFechaFinal.Value = new System.DateTime(2025, 3, 6, 14, 40, 55, 0);
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.CustomFormat = "dd-MM-yyyy";
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicial.Location = new System.Drawing.Point(6, 114);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(136, 20);
            this.dtpFechaInicial.TabIndex = 15;
            this.dtpFechaInicial.Value = new System.DateTime(2025, 3, 6, 14, 40, 55, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 307;
            this.label6.Text = "Fecha Final";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 306;
            this.label5.Text = "Fecha de Inicio";
            // 
            // lblNumResolucion
            // 
            this.lblNumResolucion.AutoSize = true;
            this.lblNumResolucion.Location = new System.Drawing.Point(6, 56);
            this.lblNumResolucion.Name = "lblNumResolucion";
            this.lblNumResolucion.Size = new System.Drawing.Size(183, 13);
            this.lblNumResolucion.TabIndex = 305;
            this.lblNumResolucion.Text = "Número de Resolución de la Sanción";
            // 
            // lblTipoSuspension
            // 
            this.lblTipoSuspension.AutoSize = true;
            this.lblTipoSuspension.Location = new System.Drawing.Point(6, 16);
            this.lblTipoSuspension.Name = "lblTipoSuspension";
            this.lblTipoSuspension.Size = new System.Drawing.Size(101, 13);
            this.lblTipoSuspension.TabIndex = 15;
            this.lblTipoSuspension.Text = "Tipo de Suspensión";
            // 
            // txtNumeroResolución
            // 
            this.txtNumeroResolución.FormatearNumero = false;
            this.txtNumeroResolución.Location = new System.Drawing.Point(6, 72);
            this.txtNumeroResolución.Longitud = 32767;
            this.txtNumeroResolución.Multilinea = false;
            this.txtNumeroResolución.Name = "txtNumeroResolución";
            this.txtNumeroResolución.Password = '\0';
            this.txtNumeroResolución.ReadOnly = false;
            this.txtNumeroResolución.Size = new System.Drawing.Size(296, 21);
            this.txtNumeroResolución.TabIndex = 14;
            this.txtNumeroResolución.Valor = "";
            // 
            // txtTipoSuspension
            // 
            this.txtTipoSuspension.FormatearNumero = false;
            this.txtTipoSuspension.Location = new System.Drawing.Point(6, 32);
            this.txtTipoSuspension.Longitud = 32767;
            this.txtTipoSuspension.Multilinea = false;
            this.txtTipoSuspension.Name = "txtTipoSuspension";
            this.txtTipoSuspension.Password = '\0';
            this.txtTipoSuspension.ReadOnly = false;
            this.txtTipoSuspension.Size = new System.Drawing.Size(296, 21);
            this.txtTipoSuspension.TabIndex = 12;
            this.txtTipoSuspension.Valor = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Número de Resolución de la Sanción";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(160, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(97, 168);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(57, 23);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmSuspension
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(339, 211);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuspension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suspención";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private Framework.UserControls.txtNormal txtNumeroResolución;
        private System.Windows.Forms.Label label2;
        private Framework.UserControls.txtNormal txtTipoSuspension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNumResolucion;
        private System.Windows.Forms.Label lblTipoSuspension;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private Framework.UserControls.dtpSaseg dtpRegresoCondicion;
    }
}