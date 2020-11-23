namespace ComPortReader.Forms
{
    partial class FirstInput
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
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.aDimTB = new System.Windows.Forms.TextBox();
            this.bDimTB = new System.Windows.Forms.TextBox();
            this.startLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.firstInputSizeLabel = new System.Windows.Forms.Label();
            this.secondInputSizeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.endLengthTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.markingTB = new System.Windows.Forms.TextBox();
            this.marking = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeCB
            // 
            this.typeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Items.AddRange(new object[] {
            "Плоская",
            "Цилиндрическая"});
            this.typeCB.Location = new System.Drawing.Point(12, 29);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(121, 21);
            this.typeCB.TabIndex = 1;
            this.typeCB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // aDimTB
            // 
            this.aDimTB.Location = new System.Drawing.Point(278, 30);
            this.aDimTB.MaxLength = 10;
            this.aDimTB.Name = "aDimTB";
            this.aDimTB.Size = new System.Drawing.Size(100, 20);
            this.aDimTB.TabIndex = 3;
            this.aDimTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeATB_KeyPress);
            // 
            // bDimTB
            // 
            this.bDimTB.Location = new System.Drawing.Point(404, 30);
            this.bDimTB.MaxLength = 10;
            this.bDimTB.Name = "bDimTB";
            this.bDimTB.Size = new System.Drawing.Size(100, 20);
            this.bDimTB.TabIndex = 4;
            this.bDimTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeBTB_KeyPress);
            // 
            // startLength
            // 
            this.startLength.Location = new System.Drawing.Point(47, 76);
            this.startLength.MaxLength = 10;
            this.startLength.Name = "startLength";
            this.startLength.Size = new System.Drawing.Size(86, 20);
            this.startLength.TabIndex = 5;
            this.startLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.startLength_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Форма образца";
            // 
            // firstInputSizeLabel
            // 
            this.firstInputSizeLabel.AutoSize = true;
            this.firstInputSizeLabel.Location = new System.Drawing.Point(275, 14);
            this.firstInputSizeLabel.Name = "firstInputSizeLabel";
            this.firstInputSizeLabel.Size = new System.Drawing.Size(40, 13);
            this.firstInputSizeLabel.TabIndex = 5;
            this.firstInputSizeLabel.Text = "Длина";
            // 
            // secondInputSizeLabel
            // 
            this.secondInputSizeLabel.AutoSize = true;
            this.secondInputSizeLabel.Location = new System.Drawing.Point(401, 14);
            this.secondInputSizeLabel.Name = "secondInputSizeLabel";
            this.secondInputSizeLabel.Size = new System.Drawing.Size(46, 13);
            this.secondInputSizeLabel.TabIndex = 6;
            this.secondInputSizeLabel.Text = "Ширина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Изначальная длина рабочей части";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Потвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // endLengthTB
            // 
            this.endLengthTB.Location = new System.Drawing.Point(393, 76);
            this.endLengthTB.MaxLength = 10;
            this.endLengthTB.Name = "endLengthTB";
            this.endLengthTB.ReadOnly = true;
            this.endLengthTB.Size = new System.Drawing.Size(100, 20);
            this.endLengthTB.TabIndex = 6;
            this.endLengthTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.endLengthTB_KeyDown);
            this.endLengthTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.endLengthTB_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Конечная длина рабочей части";
            // 
            // markingTB
            // 
            this.markingTB.Location = new System.Drawing.Point(158, 29);
            this.markingTB.MaxLength = 30;
            this.markingTB.Name = "markingTB";
            this.markingTB.Size = new System.Drawing.Size(100, 20);
            this.markingTB.TabIndex = 2;
            // 
            // marking
            // 
            this.marking.AutoSize = true;
            this.marking.Location = new System.Drawing.Point(155, 13);
            this.marking.Name = "marking";
            this.marking.Size = new System.Drawing.Size(85, 13);
            this.marking.TabIndex = 12;
            this.marking.Text = "Марка образца";
            // 
            // FirstInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 138);
            this.Controls.Add(this.marking);
            this.Controls.Add(this.markingTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endLengthTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secondInputSizeLabel);
            this.Controls.Add(this.firstInputSizeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startLength);
            this.Controls.Add(this.bDimTB);
            this.Controls.Add(this.aDimTB);
            this.Controls.Add(this.typeCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FirstInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirstInput_FormClosing);
            this.Load += new System.EventHandler(this.FirstInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.TextBox aDimTB;
        private System.Windows.Forms.TextBox bDimTB;
        private System.Windows.Forms.TextBox startLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label firstInputSizeLabel;
        private System.Windows.Forms.Label secondInputSizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox endLengthTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox markingTB;
        private System.Windows.Forms.Label marking;
    }
}