namespace Framework.UserControls
{
    partial class clbSaseg
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
            this.clbNormal = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // clbNormal
            // 
            this.clbNormal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbNormal.FormattingEnabled = true;
            this.clbNormal.Location = new System.Drawing.Point(0, 0);
            this.clbNormal.Name = "clbNormal";
            this.clbNormal.Size = new System.Drawing.Size(353, 174);
            this.clbNormal.TabIndex = 0;
            this.clbNormal.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbNormal_ItemCheck);
            // 
            // clbSaseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clbNormal);
            this.Name = "clbSaseg";
            this.Size = new System.Drawing.Size(353, 174);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbNormal;
    }
}
