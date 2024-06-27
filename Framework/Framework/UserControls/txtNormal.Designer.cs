namespace Framework.UserControls
{
    partial class txtNormal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCustom
            // 
            this.txtCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustom.Location = new System.Drawing.Point(0, 1);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(100, 20);
            this.txtCustom.TabIndex = 0;
            this.txtCustom.TextChanged += new System.EventHandler(this.txtCustom_TextChanged);
            this.txtCustom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustom_KeyDown);
            this.txtCustom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustom_KeyUp);
            this.txtCustom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustom_KeyPress);
            this.txtCustom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCustom_MouseDoubleClick);
            // 
            // txtNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCustom);
            this.Name = "txtNormal";
            this.Size = new System.Drawing.Size(102, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtCustom;

    }
}
