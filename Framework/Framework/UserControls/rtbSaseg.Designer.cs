namespace Framework.UserControls
{
    partial class rtbSaseg
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
            this.rtbNormal = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbNormal
            // 
            this.rtbNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNormal.Location = new System.Drawing.Point(0, 0);
            this.rtbNormal.Name = "rtbNormal";
            this.rtbNormal.Size = new System.Drawing.Size(231, 66);
            this.rtbNormal.TabIndex = 0;
            this.rtbNormal.Text = "";
            this.rtbNormal.TextChanged += new System.EventHandler(this.rtbNormal_TextChanged);
            this.rtbNormal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbNormal_KeyPress);
            // 
            // rtbSaseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbNormal);
            this.Name = "rtbSaseg";
            this.Size = new System.Drawing.Size(231, 66);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNormal;
    }
}
