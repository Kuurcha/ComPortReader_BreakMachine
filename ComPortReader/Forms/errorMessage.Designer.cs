namespace ComPortReader
{
    partial class ErrorMessage
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
            this.errorMesageLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorMesageLabel
            // 
            this.errorMesageLabel.AutoSize = true;
            this.errorMesageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMesageLabel.Location = new System.Drawing.Point(24, 23);
            this.errorMesageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorMesageLabel.Name = "errorMesageLabel";
            this.errorMesageLabel.Size = new System.Drawing.Size(0, 20);
            this.errorMesageLabel.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 37);
            this.button1.TabIndex = 36;
            this.button1.Text = "Окэй";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 162);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorMesageLabel);
            this.Name = "ErrorMessage";
            this.Text = "            Ошибка";
            this.Load += new System.EventHandler(this.errorMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorMesageLabel;
        private System.Windows.Forms.Button button1;
    }
}