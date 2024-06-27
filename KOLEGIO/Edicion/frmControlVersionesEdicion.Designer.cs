namespace KOLEGIO
{
    partial class frmControlVersionesEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlVersionesEdicion));
            this.panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new Framework.UserControls.dtpSaseg();
            this.rtbDescripcion = new Framework.UserControls.rtbSaseg();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCia = new Framework.UserControls.txtNormal();
            this.label9 = new System.Windows.Forms.Label();
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
            this.tabControl.Size = new System.Drawing.Size(679, 390);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.txtCia);
            this.tpBasicos.Controls.Add(this.label9);
            this.tpBasicos.Controls.Add(this.dtpFecha);
            this.tpBasicos.Controls.Add(this.rtbDescripcion);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.label7);
            this.tpBasicos.Controls.Add(this.panel);
            this.tpBasicos.Size = new System.Drawing.Size(671, 364);
            this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbDescripcion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpFecha, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label9, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCia, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(671, 364);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(665, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(665, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(671, 364);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(665, 21);
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
            // dtpFecha
            // 
            this.dtpFecha.Checked = true;
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(134, 90);
            this.dtpFecha.mostrarCheckBox = false;
            this.dtpFecha.mostrarUpDown = false;
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(107, 22);
            this.dtpFecha.TabIndex = 18;
            this.dtpFecha.Value = new System.DateTime(2017, 8, 31, 17, 8, 12, 211);
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.Location = new System.Drawing.Point(134, 118);
            this.rtbDescripcion.Longitud = 2147483647;
            this.rtbDescripcion.Mayusculas = false;
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = true;
            this.rtbDescripcion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang5130{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbDescripcion.Size = new System.Drawing.Size(456, 229);
            this.rtbDescripcion.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(85, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Detalle:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(134, 36);
            this.txtCodigo.Longitud = 32767;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(107, 21);
            this.txtCodigo.TabIndex = 13;
            this.txtCodigo.Valor = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Fecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Versión:";
            // 
            // txtCia
            // 
            this.txtCia.FormatearNumero = false;
            this.txtCia.Location = new System.Drawing.Point(134, 63);
            this.txtCia.Longitud = 32767;
            this.txtCia.Multilinea = false;
            this.txtCia.Name = "txtCia";
            this.txtCia.Password = '\0';
            this.txtCia.ReadOnly = true;
            this.txtCia.Size = new System.Drawing.Size(107, 21);
            this.txtCia.TabIndex = 19;
            this.txtCia.Valor = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Compañia:";
            // 
            // frmControlVersionesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 482);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmControlVersionesEdicion";
            this.Text = "frmEstadosTramiteEdicion";
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
        private Framework.UserControls.dtpSaseg dtpFecha;
        private Framework.UserControls.rtbSaseg rtbDescripcion;
        private System.Windows.Forms.Label label14;
        private Framework.UserControls.txtNormal txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtCia;
        private System.Windows.Forms.Label label9;
    }
}