namespace Framework.UserControls
{
    partial class cmbSaseg
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
            this.cmbNormal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbNormal
            // 
            this.cmbNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNormal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNormal.FormattingEnabled = true;
            this.cmbNormal.Location = new System.Drawing.Point(0, 0);
            this.cmbNormal.Name = "cmbNormal";
            this.cmbNormal.Size = new System.Drawing.Size(123, 21);
            this.cmbNormal.TabIndex = 0;
            this.cmbNormal.SelectedIndexChanged += new System.EventHandler(this.cmbNormal_SelectedIndexChanged);
            // 
            // cmbSaseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbNormal);
            this.Name = "cmbSaseg";
            this.Size = new System.Drawing.Size(123, 22);
            this.ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNormal;
    }
}
