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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.msgLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zeroTwoCB
            // 
            this.zeroTwoCB.AutoSize = true;
            this.zeroTwoCB.Location = new System.Drawing.Point(95, 88);
            this.zeroTwoCB.Name = "zeroTwoCB";
            this.zeroTwoCB.Size = new System.Drawing.Size(51, 17);
            this.zeroTwoCB.TabIndex = 0;
            this.zeroTwoCB.Text = "σ 0.2";
            this.zeroTwoCB.UseVisualStyleBackColor = true;
            // 
            // zeroFiveCB
            // 
            this.zeroFiveCB.AutoSize = true;
            this.zeroFiveCB.Location = new System.Drawing.Point(95, 68);
            this.zeroFiveCB.Name = "zeroFiveCB";
            this.zeroFiveCB.Size = new System.Drawing.Size(51, 17);
            this.zeroFiveCB.TabIndex = 1;
            this.zeroFiveCB.Text = "σ 0.5";
            this.zeroFiveCB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // msgLbl
            // 
            this.msgLbl.Location = new System.Drawing.Point(13, 13);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(252, 52);
            this.msgLbl.TabIndex = 4;
            // 
            // ChooseStressFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 154);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zeroFiveCB);
            this.Controls.Add(this.zeroTwoCB);
            this.Name = "ChooseStressFlow";
            this.Text = "ChooseStressFlow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox zeroTwoCB;
        private System.Windows.Forms.CheckBox zeroFiveCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label msgLbl;
    }
}