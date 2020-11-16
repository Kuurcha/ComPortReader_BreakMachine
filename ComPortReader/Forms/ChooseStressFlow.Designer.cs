namespace ComPortReader.Forms
{
    partial class ChooseStressFlow
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
            this.zeroTwoCB = new System.Windows.Forms.CheckBox();
            this.zeroFiveCB = new System.Windows.Forms.CheckBox();
            this.manualBtn = new System.Windows.Forms.Button();
            this.autoBtn = new System.Windows.Forms.Button();
            this.msgLbl = new System.Windows.Forms.Label();
            this.accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zeroTwoCB
            // 
            this.zeroTwoCB.AutoSize = true;
            this.zeroTwoCB.Checked = true;
            this.zeroTwoCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zeroTwoCB.Location = new System.Drawing.Point(136, 84);
            this.zeroTwoCB.Name = "zeroTwoCB";
            this.zeroTwoCB.Size = new System.Drawing.Size(51, 17);
            this.zeroTwoCB.TabIndex = 0;
            this.zeroTwoCB.Text = "σ 0.2";
            this.zeroTwoCB.UseVisualStyleBackColor = true;
            this.zeroTwoCB.CheckedChanged += new System.EventHandler(this.zeroTwoCB_CheckedChanged);
            this.zeroTwoCB.Click += new System.EventHandler(this.zeroTwoCB_Click);
            // 
            // zeroFiveCB
            // 
            this.zeroFiveCB.AutoSize = true;
            this.zeroFiveCB.Location = new System.Drawing.Point(136, 63);
            this.zeroFiveCB.Name = "zeroFiveCB";
            this.zeroFiveCB.Size = new System.Drawing.Size(51, 17);
            this.zeroFiveCB.TabIndex = 1;
            this.zeroFiveCB.Text = "σ 0.5";
            this.zeroFiveCB.UseVisualStyleBackColor = true;
            this.zeroFiveCB.Click += new System.EventHandler(this.zeroFiveCB_Click);
            // 
            // manualBtn
            // 
            this.manualBtn.Location = new System.Drawing.Point(12, 57);
            this.manualBtn.Name = "manualBtn";
            this.manualBtn.Size = new System.Drawing.Size(101, 23);
            this.manualBtn.TabIndex = 2;
            this.manualBtn.Text = "Вручную";
            this.manualBtn.UseVisualStyleBackColor = true;
            this.manualBtn.Click += new System.EventHandler(this.manualBtn_Click);
            // 
            // autoBtn
            // 
            this.autoBtn.Location = new System.Drawing.Point(207, 57);
            this.autoBtn.Name = "autoBtn";
            this.autoBtn.Size = new System.Drawing.Size(109, 23);
            this.autoBtn.TabIndex = 3;
            this.autoBtn.Text = "Автомат";
            this.autoBtn.UseVisualStyleBackColor = true;
            this.autoBtn.Click += new System.EventHandler(this.autoBtn_Click);
            // 
            // msgLbl
            // 
            this.msgLbl.Location = new System.Drawing.Point(9, 9);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(316, 45);
            this.msgLbl.TabIndex = 4;
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(110, 107);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(97, 23);
            this.accept.TabIndex = 5;
            this.accept.Text = "Потвердить";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChooseStressFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 133);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.autoBtn);
            this.Controls.Add(this.manualBtn);
            this.Controls.Add(this.zeroFiveCB);
            this.Controls.Add(this.zeroTwoCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseStressFlow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChooseStressFlow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox zeroTwoCB;
        private System.Windows.Forms.CheckBox zeroFiveCB;
        private System.Windows.Forms.Button manualBtn;
        private System.Windows.Forms.Button autoBtn;
        private System.Windows.Forms.Label msgLbl;
        private System.Windows.Forms.Button accept;
    }
}