﻿namespace KOLEGIO
{
    partial class frmPaisesEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaisesEdicion));
            this.panel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodigo = new Framework.UserControls.txtNormal();
            this.txtNombre = new Framework.UserControls.txtNormal();
            this.txtNacionalidad = new Framework.UserControls.txtNormal();
            this.label7 = new System.Windows.Forms.Label();
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
            this.tabControl.Size = new System.Drawing.Size(635, 291);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.txtNacionalidad);
            this.tpBasicos.Controls.Add(this.label7);
            this.tpBasicos.Controls.Add(this.txtNombre);
            this.tpBasicos.Controls.Add(this.txtCodigo);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.panel);
            this.tpBasicos.Size = new System.Drawing.Size(627, 265);
            this.tpBasicos.Controls.SetChildIndex(this.panel, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCodigo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNacionalidad, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(627, 265);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(621, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(621, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(627, 265);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(621, 21);
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
            this.label8.Location = new System.Drawing.Point(108, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Código:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(104, 109);
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
            // txtNacionalidad
            // 
            this.txtNacionalidad.FormatearNumero = false;
            this.txtNacionalidad.Location = new System.Drawing.Point(164, 132);
            this.txtNacionalidad.Longitud = 50;
            this.txtNacionalidad.Multilinea = false;
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Password = '\0';
            this.txtNacionalidad.ReadOnly = false;
            this.txtNacionalidad.Size = new System.Drawing.Size(343, 21);
            this.txtNacionalidad.TabIndex = 6;
            this.txtNacionalidad.Valor = "";
            this.txtNacionalidad.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nacionalidad:";
            this.label7.Visible = false;
            // 
            // frmPaisesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 383);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPaisesEdicion";
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
        private Framework.UserControls.txtNormal txtNacionalidad;
        private System.Windows.Forms.Label label7;
    }
}