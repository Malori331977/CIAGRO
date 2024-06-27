namespace KOLEGIO
{
    partial class frmCarrerasEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarrerasEdicion));
            this.panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.txtNombre = new Framework.UserControls.txtNormal();
            this.rtbDescripcion = new Framework.UserControls.rtbSaseg();
            this.label14 = new System.Windows.Forms.Label();
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
            this.tabControl.Size = new System.Drawing.Size(639, 275);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.rtbDescripcion);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.txtNombre);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.panel);
            this.tpBasicos.Size = new System.Drawing.Size(631, 249);
            this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbDescripcion, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(671, 249);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(665, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(625, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(671, 249);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(108, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Código:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(104, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nombre:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.FormatearNumero = false;
            this.txtCodigo.Location = new System.Drawing.Point(164, 78);
            this.txtCodigo.Longitud = 4;
            this.txtCodigo.Multilinea = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Password = '\0';
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(124, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Valor = "";
            // 
            // txtNombre
            // 
            this.txtNombre.FormatearNumero = false;
            this.txtNombre.Location = new System.Drawing.Point(164, 105);
            this.txtNombre.Longitud = 50;
            this.txtNombre.Multilinea = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Password = '\0';
            this.txtNombre.ReadOnly = false;
            this.txtNombre.Size = new System.Drawing.Size(343, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Valor = "";
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.Location = new System.Drawing.Point(164, 132);
            this.rtbDescripcion.Longitud = 500;
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = false;
            this.rtbDescripcion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbDescripcion.Size = new System.Drawing.Size(343, 76);
            this.rtbDescripcion.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(92, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Descripción:";
            // 
            // frmCarrerasEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 367);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCarrerasEdicion";
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.txtNormal txtCodigo;
        private Framework.UserControls.txtNormal txtNombre;
        private Framework.UserControls.rtbSaseg rtbDescripcion;
        private System.Windows.Forms.Label label14;
    }
}