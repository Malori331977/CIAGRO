namespace Framework.UserControls
{
    partial class dtpSaseg
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
            this.dtpNormal = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dtpNormal
            // 
            this.dtpNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNormal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNormal.Location = new System.Drawing.Point(0, 0);
            this.dtpNormal.Name = "dtpNormal";
            this.dtpNormal.Size = new System.Drawing.Size(202, 20);
            this.dtpNormal.TabIndex = 0;
            this.dtpNormal.ValueChanged += new System.EventHandler(this.dtpNormal_ValueChanged);
            // 
            // dtpSaseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpNormal);
            this.Name = "dtpSaseg";
            this.Size = new System.Drawing.Size(202, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNormal;
    }
}
