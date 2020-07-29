namespace ComPortReader
{
    partial class About
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
            this.versionL = new System.Windows.Forms.Label();
            this.infoL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // versionL
            // 
            this.versionL.AutoSize = true;
            this.versionL.Location = new System.Drawing.Point(548, 119);
            this.versionL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionL.Name = "versionL";
            this.versionL.Size = new System.Drawing.Size(107, 20);
            this.versionL.TabIndex = 41;
            this.versionL.Text = "Версия: 1.0.0";
            this.versionL.Click += new System.EventHandler(this.versionL_Click);
            // 
            // infoL
            // 
            this.infoL.AccessibleName = "";
            this.infoL.AutoSize = true;
            this.infoL.Location = new System.Drawing.Point(0, 9);
            this.infoL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoL.Name = "infoL";
            this.infoL.Size = new System.Drawing.Size(0, 20);
            this.infoL.TabIndex = 42;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 155);
            this.Controls.Add(this.infoL);
            this.Controls.Add(this.versionL);
            this.Name = "About";
            this.Text = "about";
            this.Load += new System.EventHandler(this.about_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label versionL;
        private System.Windows.Forms.Label infoL;
    }
}