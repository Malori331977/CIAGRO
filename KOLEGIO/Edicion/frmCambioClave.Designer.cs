namespace KOLEGIO
{
    partial class frmCambioClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioClave));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtConfirmacion = new Framework.UserControls.txtNormal();
            this.txtNuevaClave = new Framework.UserControls.txtNormal();
            this.txtClaveActual = new Framework.UserControls.txtNormal();
            this.txtUsuario = new Framework.UserControls.txtNormal();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtConfirmacion);
            this.groupBox1.Controls.Add(this.txtNuevaClave);
            this.groupBox1.Controls.Add(this.txtClaveActual);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Confirmación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nueva Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Clave Actual";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(131, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(68, 129);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(57, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtConfirmacion
            // 
            this.txtConfirmacion.FormatearNumero = false;
            this.txtConfirmacion.Location = new System.Drawing.Point(114, 100);
            this.txtConfirmacion.Longitud = 32767;
            this.txtConfirmacion.Multilinea = false;
            this.txtConfirmacion.Name = "txtConfirmacion";
            this.txtConfirmacion.Password = '\0';
            this.txtConfirmacion.ReadOnly = false;
            this.txtConfirmacion.Size = new System.Drawing.Size(102, 21);
            this.txtConfirmacion.TabIndex = 8;
            this.txtConfirmacion.Valor = "";
            this.txtConfirmacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCambioClave_KeyDown);
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.FormatearNumero = false;
            this.txtNuevaClave.Location = new System.Drawing.Point(114, 73);
            this.txtNuevaClave.Longitud = 32767;
            this.txtNuevaClave.Multilinea = false;
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.Password = '\0';
            this.txtNuevaClave.ReadOnly = false;
            this.txtNuevaClave.Size = new System.Drawing.Size(102, 21);
            this.txtNuevaClave.TabIndex = 7;
            this.txtNuevaClave.Valor = "";
            this.txtNuevaClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCambioClave_KeyDown);
            // 
            // txtClaveActual
            // 
            this.txtClaveActual.FormatearNumero = false;
            this.txtClaveActual.Location = new System.Drawing.Point(114, 46);
            this.txtClaveActual.Longitud = 32767;
            this.txtClaveActual.Multilinea = false;
            this.txtClaveActual.Name = "txtClaveActual";
            this.txtClaveActual.Password = '\0';
            this.txtClaveActual.ReadOnly = false;
            this.txtClaveActual.Size = new System.Drawing.Size(102, 21);
            this.txtClaveActual.TabIndex = 6;
            this.txtClaveActual.Valor = "";
            this.txtClaveActual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCambioClave_KeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.FormatearNumero = false;
            this.txtUsuario.Location = new System.Drawing.Point(114, 19);
            this.txtUsuario.Longitud = 32767;
            this.txtUsuario.Multilinea = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Password = '\0';
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(102, 21);
            this.txtUsuario.TabIndex = 5;
            this.txtUsuario.Valor = "";
            // 
            // frmCambioClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 162);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Clave de Ingreso";
            this.Load += new System.EventHandler(this.frmCambioClave_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCambioClave_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private Framework.UserControls.txtNormal txtUsuario;
        private Framework.UserControls.txtNormal txtConfirmacion;
        private Framework.UserControls.txtNormal txtNuevaClave;
        private Framework.UserControls.txtNormal txtClaveActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}