namespace Framework
{
    partial class frmAdjunto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjunto));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.PictureBox();
            this.rbServidor = new System.Windows.Forms.RadioButton();
            this.rbBD = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbArchivoDigital = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCargar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(547, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(23, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(86, 111);
            this.txtDescripcion.MaxLength = 60;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(376, 48);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Archivo:";
            // 
            // btnCargar
            // 
            this.btnCargar.BackgroundImage = global::Framework.Properties.Resources.Attach_icon;
            this.btnCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.Location = new System.Drawing.Point(468, 139);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(67, 74);
            this.btnCargar.TabIndex = 8;
            this.btnCargar.TabStop = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            this.btnCargar.MouseHover += new System.EventHandler(this.btnCargar_MouseHover);
            // 
            // rbServidor
            // 
            this.rbServidor.AutoSize = true;
            this.rbServidor.Location = new System.Drawing.Point(247, 20);
            this.rbServidor.Name = "rbServidor";
            this.rbServidor.Size = new System.Drawing.Size(123, 17);
            this.rbServidor.TabIndex = 9;
            this.rbServidor.TabStop = true;
            this.rbServidor.Text = "Servidor de Archivos";
            this.rbServidor.UseVisualStyleBackColor = true;
            // 
            // rbBD
            // 
            this.rbBD.AutoSize = true;
            this.rbBD.Location = new System.Drawing.Point(134, 20);
            this.rbBD.Name = "rbBD";
            this.rbBD.Size = new System.Drawing.Size(95, 17);
            this.rbBD.TabIndex = 10;
            this.rbBD.TabStop = true;
            this.rbBD.Text = "Base de Datos";
            this.rbBD.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbArchivoDigital);
            this.groupBox1.Controls.Add(this.rbBD);
            this.groupBox1.Controls.Add(this.rbServidor);
            this.groupBox1.Location = new System.Drawing.Point(86, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 50);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // rbArchivoDigital
            // 
            this.rbArchivoDigital.AutoSize = true;
            this.rbArchivoDigital.Location = new System.Drawing.Point(21, 20);
            this.rbArchivoDigital.Name = "rbArchivoDigital";
            this.rbArchivoDigital.Size = new System.Drawing.Size(93, 17);
            this.rbArchivoDigital.TabIndex = 11;
            this.rbArchivoDigital.TabStop = true;
            this.rbArchivoDigital.Text = "Archivo Digital";
            this.rbArchivoDigital.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Almacenar en:";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(86, 48);
            this.txtNombreArchivo.MaxLength = 512;
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.ReadOnly = true;
            this.txtNombreArchivo.Size = new System.Drawing.Size(376, 48);
            this.txtNombreArchivo.TabIndex = 13;
            this.txtNombreArchivo.Text = "";
            // 
            // frmAdjunto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 231);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdjunto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjuntar Archivo";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCargar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnCargar;
        private System.Windows.Forms.RadioButton rbServidor;
        private System.Windows.Forms.RadioButton rbBD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtNombreArchivo;
        private System.Windows.Forms.RadioButton rbArchivoDigital;
    }
}