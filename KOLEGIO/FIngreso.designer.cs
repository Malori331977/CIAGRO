namespace KOLEGIO
{
    partial class FIngreso
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIngreso));
			this.lbContrasena = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.btnIngresar = new System.Windows.Forms.Button();
			this.txtContrasena = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.btnConfiguracion = new System.Windows.Forms.PictureBox();
			this.cbCompania = new System.Windows.Forms.ComboBox();
			this.lbEmpresa = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.btnConfiguracion)).BeginInit();
			this.SuspendLayout();
			// 
			// lbContrasena
			// 
			this.lbContrasena.AutoSize = true;
			this.lbContrasena.Location = new System.Drawing.Point(29, 234);
			this.lbContrasena.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lbContrasena.Name = "lbContrasena";
			this.lbContrasena.Size = new System.Drawing.Size(64, 13);
			this.lbContrasena.TabIndex = 41;
			this.lbContrasena.Text = "Contraseña:";
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.Location = new System.Drawing.Point(47, 204);
			this.lbUsuario.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(46, 13);
			this.lbUsuario.TabIndex = 40;
			this.lbUsuario.Text = "Usuario:";
			// 
			// btnIngresar
			// 
			this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIngresar.Location = new System.Drawing.Point(288, 256);
			this.btnIngresar.Margin = new System.Windows.Forms.Padding(4);
			this.btnIngresar.Name = "btnIngresar";
			this.btnIngresar.Size = new System.Drawing.Size(80, 28);
			this.btnIngresar.TabIndex = 4;
			this.btnIngresar.Text = "Ingresar";
			this.btnIngresar.UseVisualStyleBackColor = true;
			this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
			// 
			// txtContrasena
			// 
			this.txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtContrasena.Location = new System.Drawing.Point(103, 229);
			this.txtContrasena.Margin = new System.Windows.Forms.Padding(4);
			this.txtContrasena.Name = "txtContrasena";
			this.txtContrasena.PasswordChar = '*';
			this.txtContrasena.Size = new System.Drawing.Size(125, 22);
			this.txtContrasena.TabIndex = 2;
			this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasena_KeyPress);
			this.txtContrasena.Leave += new System.EventHandler(this.txtContrasena_Leave);
			// 
			// txtUsuario
			// 
			this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsuario.Location = new System.Drawing.Point(103, 199);
			this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(125, 22);
			this.txtUsuario.TabIndex = 1;
			this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
			this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
			// 
			// btnConfiguracion
			// 
			this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracion.Image")));
			this.btnConfiguracion.Location = new System.Drawing.Point(318, 12);
			this.btnConfiguracion.Name = "btnConfiguracion";
			this.btnConfiguracion.Size = new System.Drawing.Size(50, 50);
			this.btnConfiguracion.TabIndex = 44;
			this.btnConfiguracion.TabStop = false;
			this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
			// 
			// cbCompania
			// 
			this.cbCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCompania.FormattingEnabled = true;
			this.cbCompania.Location = new System.Drawing.Point(103, 261);
			this.cbCompania.Name = "cbCompania";
			this.cbCompania.Size = new System.Drawing.Size(125, 21);
			this.cbCompania.TabIndex = 45;
			// 
			// lbEmpresa
			// 
			this.lbEmpresa.AutoSize = true;
			this.lbEmpresa.Location = new System.Drawing.Point(34, 264);
			this.lbEmpresa.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lbEmpresa.Name = "lbEmpresa";
			this.lbEmpresa.Size = new System.Drawing.Size(59, 13);
			this.lbEmpresa.TabIndex = 46;
			this.lbEmpresa.Text = "Compañía:";
			// 
			// FIngreso
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(393, 326);
			this.Controls.Add(this.cbCompania);
			this.Controls.Add(this.lbEmpresa);
			this.Controls.Add(this.btnConfiguracion);
			this.Controls.Add(this.lbContrasena);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.btnIngresar);
			this.Controls.Add(this.txtContrasena);
			this.Controls.Add(this.txtUsuario);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(409, 365);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(409, 365);
			this.Name = "FIngreso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Acceso de Usuario";
			this.Load += new System.EventHandler(this.FIngreso_Load);
			((System.ComponentModel.ISupportInitialize)(this.btnConfiguracion)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbContrasena;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox btnConfiguracion;
        private System.Windows.Forms.ComboBox cbCompania;
        private System.Windows.Forms.Label lbEmpresa;
	}
}