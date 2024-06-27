namespace KOLEGIO
{
    partial class frmEstadosEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadosEdicion));
            this.panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.rtbDescripcion = new Framework.UserControls.rtbSaseg();
            this.txtNombre = new Framework.UserControls.txtNormal();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDiferenciador = new Framework.UserControls.cmbSaseg();
            this.chkGeneraCobro = new Framework.UserControls.chkSaseg();
            this.chkRegresoEstado = new Framework.UserControls.chkSaseg();
            this.txtDescEstado = new Framework.UserControls.txtNormal();
            this.txtEstado = new Framework.UserControls.txtNormal();
            this.chkCierre = new Framework.UserControls.chkSaseg();
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
            this.tabControl.Size = new System.Drawing.Size(612, 291);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.chkCierre);
            this.tpBasicos.Controls.Add(this.txtDescEstado);
            this.tpBasicos.Controls.Add(this.txtEstado);
            this.tpBasicos.Controls.Add(this.chkRegresoEstado);
            this.tpBasicos.Controls.Add(this.chkGeneraCobro);
            this.tpBasicos.Controls.Add(this.cmbDiferenciador);
            this.tpBasicos.Controls.Add(this.label7);
            this.tpBasicos.Controls.Add(this.rtbDescripcion);
            this.tpBasicos.Controls.Add(this.txtNombre);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.panel);
            this.tpBasicos.Size = new System.Drawing.Size(604, 265);
            this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbDescripcion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
            this.tpBasicos.Controls.SetChildIndex(this.cmbDiferenciador, 0);
            this.tpBasicos.Controls.SetChildIndex(this.chkGeneraCobro, 0);
            this.tpBasicos.Controls.SetChildIndex(this.chkRegresoEstado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtEstado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtDescEstado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.chkCierre, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(604, 265);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(598, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(598, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(604, 265);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(598, 21);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(665, 21);
            this.panel.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Datos del Criterio de Evaluación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(102, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Código:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(98, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nombre:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(86, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Descripción:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(158, 66);
            this.txtCodigo.Longitud = 4;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(124, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Valor = "";
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.Location = new System.Drawing.Point(158, 121);
            this.rtbDescripcion.Longitud = 500;
            this.rtbDescripcion.Mayusculas = false;
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = false;
            this.rtbDescripcion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbDescripcion.Size = new System.Drawing.Size(343, 76);
            this.rtbDescripcion.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.FormatearNumero = false;
            this.txtNombre.Location = new System.Drawing.Point(158, 94);
            this.txtNombre.Longitud = 50;
            this.txtNombre.Multilinea = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Password = '\0';
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Size = new System.Drawing.Size(343, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Valor = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Para:";
            // 
            // cmbDiferenciador
            // 
            this.cmbDiferenciador.Habilitar = true;
            this.cmbDiferenciador.Index = -1;
            this.cmbDiferenciador.Location = new System.Drawing.Point(158, 38);
            this.cmbDiferenciador.Name = "cmbDiferenciador";
            this.cmbDiferenciador.Size = new System.Drawing.Size(123, 22);
            this.cmbDiferenciador.TabIndex = 12;
            this.cmbDiferenciador.Texto = "";
            this.cmbDiferenciador.Valor = "";
            // 
            // chkGeneraCobro
            // 
            this.chkGeneraCobro.Checked = false;
            this.chkGeneraCobro.Location = new System.Drawing.Point(302, 44);
            this.chkGeneraCobro.Name = "chkGeneraCobro";
            this.chkGeneraCobro.Size = new System.Drawing.Size(142, 17);
            this.chkGeneraCobro.TabIndex = 13;
            this.chkGeneraCobro.Texto = "Genera Cobro de Canon";
            // 
            // chkRegresoEstado
            // 
            this.chkRegresoEstado.Checked = false;
            this.chkRegresoEstado.Location = new System.Drawing.Point(158, 203);
            this.chkRegresoEstado.Name = "chkRegresoEstado";
            this.chkRegresoEstado.Size = new System.Drawing.Size(165, 17);
            this.chkRegresoEstado.TabIndex = 14;
            this.chkRegresoEstado.Texto = "Requiere Regreso de Estado";
            this.chkRegresoEstado.Click += new System.EventHandler(this.chkRegresoEstado_Click);
            this.chkRegresoEstado.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkRegresoEstado_MouseClick);
            // 
            // txtDescEstado
            // 
            this.txtDescEstado.FormatearNumero = false;
            this.txtDescEstado.Location = new System.Drawing.Point(222, 226);
            this.txtDescEstado.Longitud = 32767;
            this.txtDescEstado.Multilinea = false;
            this.txtDescEstado.Name = "txtDescEstado";
            this.txtDescEstado.Password = '\0';
            this.txtDescEstado.ReadOnly = true;
            this.txtDescEstado.Size = new System.Drawing.Size(279, 21);
            this.txtDescEstado.TabIndex = 282;
            this.txtDescEstado.Valor = "";
            // 
            // txtEstado
            // 
            this.txtEstado.FormatearNumero = false;
            this.txtEstado.Location = new System.Drawing.Point(158, 226);
            this.txtEstado.Longitud = 4;
            this.txtEstado.Multilinea = false;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Password = '\0';
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(64, 21);
            this.txtEstado.TabIndex = 281;
            this.txtEstado.Valor = "";
            this.txtEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEstado_KeyDown);
            this.txtEstado.Leave += new System.EventHandler(this.txtEstado_Leave);
            this.txtEstado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEstado_MouseDoubleClick);
            // 
            // chkCierre
            // 
            this.chkCierre.Checked = false;
            this.chkCierre.Location = new System.Drawing.Point(302, 71);
            this.chkCierre.Name = "chkCierre";
            this.chkCierre.Size = new System.Drawing.Size(126, 17);
            this.chkCierre.TabIndex = 283;
            this.chkCierre.Texto = "Estado de Cierre";
            // 
            // frmEstadosEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 383);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEstadosEdicion";
            this.Text = "Estados";
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

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtCodigo;
        private Framework.UserControls.rtbSaseg rtbDescripcion;
        private Framework.UserControls.txtNormal txtNombre;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.cmbSaseg cmbDiferenciador;
        private Framework.UserControls.chkSaseg chkGeneraCobro;
        private Framework.UserControls.chkSaseg chkRegresoEstado;
        private Framework.UserControls.txtNormal txtDescEstado;
        private Framework.UserControls.txtNormal txtEstado;
        private Framework.UserControls.chkSaseg chkCierre;
    }
}