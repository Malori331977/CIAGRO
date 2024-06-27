namespace Framework.UserControls
{
    partial class rbSaseg
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
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(0, 0);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(85, 17);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "radioButton1";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.Click += new System.EventHandler(this.rbNormal_Click);
            this.rbNormal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rbNormal_MouseClick);
            // 
            // rbSaseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbNormal);
            this.Name = "rbSaseg";
            this.Size = new System.Drawing.Size(90, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbNormal;
    }
}
