namespace Framework.UserControls
{
    partial class chkSaseg
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
            this.chbNormal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chbNormal
            // 
            this.chbNormal.AutoSize = true;
            this.chbNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbNormal.Location = new System.Drawing.Point(0, 0);
            this.chbNormal.Name = "chbNormal";
            this.chbNormal.Size = new System.Drawing.Size(82, 17);
            this.chbNormal.TabIndex = 0;
            this.chbNormal.Text = "checkBox1";
            this.chbNormal.UseVisualStyleBackColor = true;
            this.chbNormal.CheckedChanged += new System.EventHandler(this.chbNormal_CheckedChanged);
            this.chbNormal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chbNormal_MouseClick);
            // 
            // chkSaseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbNormal);
            this.Name = "chkSaseg";
            this.Size = new System.Drawing.Size(82, 17);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbNormal;
    }
}
