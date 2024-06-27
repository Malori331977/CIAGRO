namespace KOLEGIO.Edicion
{
	partial class frmActividadesEdicion
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
			this.rtbDescripcion = new Framework.UserControls.rtbSaseg();
			this.txtNombre = new Framework.UserControls.txtNormal();
			this.txtCodigo = new Framework.UserControls.txtNormal();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Size = new System.Drawing.Size(800, 359);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.rtbDescripcion);
			this.tpBasicos.Controls.Add(this.txtNombre);
			this.tpBasicos.Controls.Add(this.txtCodigo);
			this.tpBasicos.Controls.Add(this.label14);
			this.tpBasicos.Controls.Add(this.label10);
			this.tpBasicos.Controls.Add(this.label8);
			this.tpBasicos.Size = new System.Drawing.Size(792, 333);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.rtbDescripcion, 0);
			// 
			// panelBasicos
			// 
			this.panelBasicos.Size = new System.Drawing.Size(786, 21);
			// 
			// rtbDescripcion
			// 
			this.rtbDescripcion.Location = new System.Drawing.Point(261, 156);
			this.rtbDescripcion.Longitud = 500;
			this.rtbDescripcion.Mayusculas = false;
			this.rtbDescripcion.Name = "rtbDescripcion";
			this.rtbDescripcion.ReadOnly = false;
			this.rtbDescripcion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.18362}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbDescripcion.Size = new System.Drawing.Size(343, 76);
			this.rtbDescripcion.TabIndex = 12;
			// 
			// txtNombre
			// 
			this.txtNombre.FormatearNumero = false;
			this.txtNombre.Location = new System.Drawing.Point(261, 129);
			this.txtNombre.Longitud = 50;
			this.txtNombre.Multilinea = false;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Password = '\0';
			this.txtNombre.ReadOnly = false;
			this.txtNombre.Size = new System.Drawing.Size(343, 21);
			this.txtNombre.TabIndex = 11;
			this.txtNombre.Valor = "";
			// 
			// txtCodigo
			// 
			this.txtCodigo.FormatearNumero = false;
			this.txtCodigo.Location = new System.Drawing.Point(261, 101);
			this.txtCodigo.Longitud = 4;
			this.txtCodigo.Multilinea = false;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Password = '\0';
			this.txtCodigo.ReadOnly = false;
			this.txtCodigo.Size = new System.Drawing.Size(124, 21);
			this.txtCodigo.TabIndex = 10;
			this.txtCodigo.Valor = "";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(189, 159);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(66, 13);
			this.label14.TabIndex = 15;
			this.label14.Text = "Descripción:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(201, 133);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "Nombre:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(205, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Código:";
			// 
			// frmActividadesEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Name = "frmActividadesEdicion";
			this.Text = "frmActividadesEdicion";
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Framework.UserControls.rtbSaseg rtbDescripcion;
		private Framework.UserControls.txtNormal txtNombre;
		private Framework.UserControls.txtNormal txtCodigo;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
	}
}