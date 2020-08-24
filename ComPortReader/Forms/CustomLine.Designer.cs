namespace ComPortReader.Forms
{
    partial class CustomLine
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
            this.accept = new System.Windows.Forms.Button();
            this.decline = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(12, 79);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(75, 23);
            this.accept.TabIndex = 2;
            this.accept.Text = "Построить";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // decline
            // 
            this.decline.Location = new System.Drawing.Point(204, 79);
            this.decline.Name = "decline";
            this.decline.Size = new System.Drawing.Size(75, 23);
            this.decline.TabIndex = 3;
            this.decline.Text = "Потвердить";
            this.decline.UseVisualStyleBackColor = true;
            this.decline.Click += new System.EventHandler(this.decline_Click);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(9, 9);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(281, 56);
            this.info.TabIndex = 4;
            this.info.Text = "Автоматическое построение линейного участка завершено.  Если участок построен нев" +
    "ерно вы можете сделать это  вручную, для этого нажмите \r\nпостроить, если пострен" +
    "ие завершено  - потвердить\r\n";
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // CustomLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(293, 110);
            this.Controls.Add(this.info);
            this.Controls.Add(this.decline);
            this.Controls.Add(this.accept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomLine_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomLine_FormClosed);
            this.Load += new System.EventHandler(this.CustomLine_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Button decline;
        private System.Windows.Forms.Label info;
    }
}