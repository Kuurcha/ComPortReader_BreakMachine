namespace ComPortReader
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            ImageComboBox.ImageComboBoxItem imageComboBoxItem5 = new ImageComboBox.ImageComboBoxItem();
            ImageComboBox.ImageComboBoxItem imageComboBoxItem6 = new ImageComboBox.ImageComboBoxItem();
            ImageComboBox.ImageComboBoxItem imageComboBoxItem7 = new ImageComboBox.ImageComboBoxItem();
            ImageComboBox.ImageComboBoxItem imageComboBoxItem8 = new ImageComboBox.ImageComboBoxItem();
            this.xAxisRangeLabel = new System.Windows.Forms.Label();
            this.xAxisNameLabel = new System.Windows.Forms.Label();
            this.graphNameLabel = new System.Windows.Forms.Label();
            this.yAxisNameLabel = new System.Windows.Forms.Label();
            this.xAxisNameTB = new System.Windows.Forms.TextBox();
            this.yAxisNameTB = new System.Windows.Forms.TextBox();
            this.graphNameLabelTB = new System.Windows.Forms.TextBox();
            this.yAxisRangeLabel = new System.Windows.Forms.Label();
            this.xMinValueTb = new System.Windows.Forms.TextBox();
            this.xMaxValueTb = new System.Windows.Forms.TextBox();
            this.yMinValueTb = new System.Windows.Forms.TextBox();
            this.yMaxValueTb = new System.Windows.Forms.TextBox();
            this.dash1 = new System.Windows.Forms.Label();
            this.dash2 = new System.Windows.Forms.Label();
            this.autosaveFileLabel = new System.Windows.Forms.Label();
            this.autosavePathTB = new System.Windows.Forms.TextBox();
            this.applyChanges = new System.Windows.Forms.Button();
            this.drawGraphB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.coefficientTB = new System.Windows.Forms.TextBox();
            this.coefficientL = new System.Windows.Forms.Label();
            this.ListForCombo = new System.Windows.Forms.ImageList(this.components);
            this.symbolCB = new ImageComboBox.ImageComboBox();
            this.afterSelectEventHandlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.sizeCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.afterSelectEventHandlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // xAxisRangeLabel
            // 
            this.xAxisRangeLabel.AutoSize = true;
            this.xAxisRangeLabel.Location = new System.Drawing.Point(12, 115);
            this.xAxisRangeLabel.Name = "xAxisRangeLabel";
            this.xAxisRangeLabel.Size = new System.Drawing.Size(139, 13);
            this.xAxisRangeLabel.TabIndex = 34;
            this.xAxisRangeLabel.Text = "Диапазон значений оси Х";
            // 
            // xAxisNameLabel
            // 
            this.xAxisNameLabel.AutoSize = true;
            this.xAxisNameLabel.Location = new System.Drawing.Point(12, 76);
            this.xAxisNameLabel.Name = "xAxisNameLabel";
            this.xAxisNameLabel.Size = new System.Drawing.Size(88, 13);
            this.xAxisNameLabel.TabIndex = 35;
            this.xAxisNameLabel.Text = "Название оси Х";
            // 
            // graphNameLabel
            // 
            this.graphNameLabel.AutoSize = true;
            this.graphNameLabel.Location = new System.Drawing.Point(12, 32);
            this.graphNameLabel.Name = "graphNameLabel";
            this.graphNameLabel.Size = new System.Drawing.Size(104, 13);
            this.graphNameLabel.TabIndex = 35;
            this.graphNameLabel.Text = "Название Графика";
            // 
            // yAxisNameLabel
            // 
            this.yAxisNameLabel.AutoSize = true;
            this.yAxisNameLabel.Location = new System.Drawing.Point(12, 55);
            this.yAxisNameLabel.Name = "yAxisNameLabel";
            this.yAxisNameLabel.Size = new System.Drawing.Size(89, 13);
            this.yAxisNameLabel.TabIndex = 36;
            this.yAxisNameLabel.Text = "Название оси У";
            // 
            // xAxisNameTB
            // 
            this.xAxisNameTB.Location = new System.Drawing.Point(122, 77);
            this.xAxisNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.xAxisNameTB.MaxLength = 30;
            this.xAxisNameTB.Name = "xAxisNameTB";
            this.xAxisNameTB.Size = new System.Drawing.Size(132, 20);
            this.xAxisNameTB.TabIndex = 37;
            this.xAxisNameTB.TextChanged += new System.EventHandler(this.xAxisNameTB_TextChanged);
            // 
            // yAxisNameTB
            // 
            this.yAxisNameTB.Location = new System.Drawing.Point(122, 53);
            this.yAxisNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.yAxisNameTB.MaxLength = 30;
            this.yAxisNameTB.Name = "yAxisNameTB";
            this.yAxisNameTB.Size = new System.Drawing.Size(132, 20);
            this.yAxisNameTB.TabIndex = 38;
            this.yAxisNameTB.Click += new System.EventHandler(this.yAxisNameTB_Click);
            this.yAxisNameTB.TextChanged += new System.EventHandler(this.yAxisNameTB_TextChanged);
            // 
            // graphNameLabelTB
            // 
            this.graphNameLabelTB.Location = new System.Drawing.Point(122, 30);
            this.graphNameLabelTB.Margin = new System.Windows.Forms.Padding(2);
            this.graphNameLabelTB.MaxLength = 30;
            this.graphNameLabelTB.Name = "graphNameLabelTB";
            this.graphNameLabelTB.Size = new System.Drawing.Size(132, 20);
            this.graphNameLabelTB.TabIndex = 39;
            this.graphNameLabelTB.TextChanged += new System.EventHandler(this.graphNameLabelTB_TextChanged);
            // 
            // yAxisRangeLabel
            // 
            this.yAxisRangeLabel.AutoSize = true;
            this.yAxisRangeLabel.Location = new System.Drawing.Point(12, 138);
            this.yAxisRangeLabel.Name = "yAxisRangeLabel";
            this.yAxisRangeLabel.Size = new System.Drawing.Size(140, 13);
            this.yAxisRangeLabel.TabIndex = 40;
            this.yAxisRangeLabel.Text = "Диапазон значений оси У";
            this.yAxisRangeLabel.Click += new System.EventHandler(this.yAxisRangeLabel_Click);
            // 
            // xMinValueTb
            // 
            this.xMinValueTb.Location = new System.Drawing.Point(159, 112);
            this.xMinValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.xMinValueTb.MaxLength = 300;
            this.xMinValueTb.Name = "xMinValueTb";
            this.xMinValueTb.Size = new System.Drawing.Size(51, 20);
            this.xMinValueTb.TabIndex = 41;
            this.xMinValueTb.TextChanged += new System.EventHandler(this.xMinValueTb_TextChanged);
            // 
            // xMaxValueTb
            // 
            this.xMaxValueTb.Location = new System.Drawing.Point(230, 112);
            this.xMaxValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.xMaxValueTb.MaxLength = 300;
            this.xMaxValueTb.Name = "xMaxValueTb";
            this.xMaxValueTb.Size = new System.Drawing.Size(51, 20);
            this.xMaxValueTb.TabIndex = 42;
            // 
            // yMinValueTb
            // 
            this.yMinValueTb.Location = new System.Drawing.Point(159, 138);
            this.yMinValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.yMinValueTb.MaxLength = 300;
            this.yMinValueTb.Name = "yMinValueTb";
            this.yMinValueTb.Size = new System.Drawing.Size(51, 20);
            this.yMinValueTb.TabIndex = 43;
            // 
            // yMaxValueTb
            // 
            this.yMaxValueTb.Location = new System.Drawing.Point(230, 140);
            this.yMaxValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.yMaxValueTb.MaxLength = 300;
            this.yMaxValueTb.Name = "yMaxValueTb";
            this.yMaxValueTb.Size = new System.Drawing.Size(51, 20);
            this.yMaxValueTb.TabIndex = 44;
            // 
            // dash1
            // 
            this.dash1.AutoSize = true;
            this.dash1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dash1.Location = new System.Drawing.Point(213, 112);
            this.dash1.Name = "dash1";
            this.dash1.Size = new System.Drawing.Size(14, 20);
            this.dash1.TabIndex = 45;
            this.dash1.Text = "-";
            // 
            // dash2
            // 
            this.dash2.AutoSize = true;
            this.dash2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dash2.Location = new System.Drawing.Point(213, 137);
            this.dash2.Name = "dash2";
            this.dash2.Size = new System.Drawing.Size(14, 20);
            this.dash2.TabIndex = 46;
            this.dash2.Text = "-";
            // 
            // autosaveFileLabel
            // 
            this.autosaveFileLabel.AutoEllipsis = true;
            this.autosaveFileLabel.AutoSize = true;
            this.autosaveFileLabel.Location = new System.Drawing.Point(12, 9);
            this.autosaveFileLabel.Name = "autosaveFileLabel";
            this.autosaveFileLabel.Size = new System.Drawing.Size(105, 13);
            this.autosaveFileLabel.TabIndex = 47;
            this.autosaveFileLabel.Text = "Путь по умолчанию";
            // 
            // autosavePathTB
            // 
            this.autosavePathTB.Location = new System.Drawing.Point(122, 6);
            this.autosavePathTB.Margin = new System.Windows.Forms.Padding(2);
            this.autosavePathTB.MaxLength = 100;
            this.autosavePathTB.Name = "autosavePathTB";
            this.autosavePathTB.Size = new System.Drawing.Size(133, 20);
            this.autosavePathTB.TabIndex = 48;
            // 
            // applyChanges
            // 
            this.applyChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyChanges.Location = new System.Drawing.Point(283, 187);
            this.applyChanges.Margin = new System.Windows.Forms.Padding(2);
            this.applyChanges.Name = "applyChanges";
            this.applyChanges.Size = new System.Drawing.Size(133, 23);
            this.applyChanges.TabIndex = 49;
            this.applyChanges.Text = "Сохранить изменения";
            this.applyChanges.UseVisualStyleBackColor = true;
            this.applyChanges.Click += new System.EventHandler(this.applyChanges_Click);
            // 
            // drawGraphB
            // 
            this.drawGraphB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.drawGraphB.Location = new System.Drawing.Point(8, 187);
            this.drawGraphB.Margin = new System.Windows.Forms.Padding(2);
            this.drawGraphB.Name = "drawGraphB";
            this.drawGraphB.Size = new System.Drawing.Size(88, 23);
            this.drawGraphB.TabIndex = 50;
            this.drawGraphB.Text = "О программе";
            this.drawGraphB.UseVisualStyleBackColor = true;
            this.drawGraphB.Click += new System.EventHandler(this.drawGraphB_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(308, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 21);
            this.button1.TabIndex = 51;
            this.button1.Text = "Обнулить график";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // coefficientTB
            // 
            this.coefficientTB.Location = new System.Drawing.Point(104, 162);
            this.coefficientTB.Margin = new System.Windows.Forms.Padding(2);
            this.coefficientTB.MaxLength = 8;
            this.coefficientTB.Name = "coefficientTB";
            this.coefficientTB.Size = new System.Drawing.Size(51, 20);
            this.coefficientTB.TabIndex = 53;
            // 
            // coefficientL
            // 
            this.coefficientL.AutoSize = true;
            this.coefficientL.Location = new System.Drawing.Point(12, 165);
            this.coefficientL.Name = "coefficientL";
            this.coefficientL.Size = new System.Drawing.Size(77, 13);
            this.coefficientL.TabIndex = 53;
            this.coefficientL.Text = "Коэффициент";
            this.coefficientL.Click += new System.EventHandler(this.coefficientL_Click);
            // 
            // ListForCombo
            // 
            this.ListForCombo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListForCombo.ImageStream")));
            this.ListForCombo.TransparentColor = System.Drawing.Color.Transparent;
            this.ListForCombo.Images.SetKeyName(0, "Circle.png");
            this.ListForCombo.Images.SetKeyName(1, "Cross.png");
            this.ListForCombo.Images.SetKeyName(2, "empty.png");
            this.ListForCombo.Images.SetKeyName(3, "line.png");
            // 
            // symbolCB
            // 
            this.symbolCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.symbolCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.symbolCB.ImageList = this.ListForCombo;
            this.symbolCB.Indent = 0;
            this.symbolCB.ItemHeight = 15;
            imageComboBoxItem5.Font = null;
            imageComboBoxItem5.Image = "1";
            imageComboBoxItem5.ImageIndex = 1;
            imageComboBoxItem5.IndentLevel = 0;
            imageComboBoxItem5.Item = null;
            imageComboBoxItem5.Text = "Звезда";
            imageComboBoxItem6.Font = null;
            imageComboBoxItem6.Image = "3";
            imageComboBoxItem6.ImageIndex = 3;
            imageComboBoxItem6.IndentLevel = 0;
            imageComboBoxItem6.Item = null;
            imageComboBoxItem6.Text = "Палка";
            imageComboBoxItem7.Font = null;
            imageComboBoxItem7.Image = "0";
            imageComboBoxItem7.ImageIndex = 0;
            imageComboBoxItem7.IndentLevel = 0;
            imageComboBoxItem7.Item = null;
            imageComboBoxItem7.Text = "Круг";
            imageComboBoxItem8.Font = null;
            imageComboBoxItem8.Image = "2";
            imageComboBoxItem8.ImageIndex = 2;
            imageComboBoxItem8.IndentLevel = 0;
            imageComboBoxItem8.Item = null;
            imageComboBoxItem8.Text = "Линия";
            this.symbolCB.Items.AddRange(new ImageComboBox.ImageComboBoxItem[] {
            imageComboBoxItem5,
            imageComboBoxItem6,
            imageComboBoxItem7,
            imageComboBoxItem8});
            this.symbolCB.Location = new System.Drawing.Point(365, 19);
            this.symbolCB.Margin = new System.Windows.Forms.Padding(2);
            this.symbolCB.Name = "symbolCB";
            this.symbolCB.Size = new System.Drawing.Size(59, 21);
            this.symbolCB.TabIndex = 54;
            this.symbolCB.SelectedIndexChanged += new System.EventHandler(this.imageComboBox1_SelectedIndexChanged);
            // 
            // afterSelectEventHandlerBindingSource
            // 
            this.afterSelectEventHandlerBindingSource.DataSource = typeof(ImageComboBox.ItemImagesContainer.AfterSelectEventHandler);
            this.afterSelectEventHandlerBindingSource.CurrentChanged += new System.EventHandler(this.afterSelectEventHandlerBindingSource_CurrentChanged);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Форма и размер точки";
            // 
            // sizeCB
            // 
            this.sizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeCB.FormattingEnabled = true;
            this.sizeCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.sizeCB.Location = new System.Drawing.Point(302, 19);
            this.sizeCB.Margin = new System.Windows.Forms.Padding(2);
            this.sizeCB.Name = "sizeCB";
            this.sizeCB.Size = new System.Drawing.Size(29, 21);
            this.sizeCB.TabIndex = 57;
            this.sizeCB.SelectedIndexChanged += new System.EventHandler(this.sizeCB_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 215);
            this.Controls.Add(this.sizeCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.symbolCB);
            this.Controls.Add(this.coefficientTB);
            this.Controls.Add(this.coefficientL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drawGraphB);
            this.Controls.Add(this.applyChanges);
            this.Controls.Add(this.autosavePathTB);
            this.Controls.Add(this.autosaveFileLabel);
            this.Controls.Add(this.dash2);
            this.Controls.Add(this.dash1);
            this.Controls.Add(this.yMaxValueTb);
            this.Controls.Add(this.yMinValueTb);
            this.Controls.Add(this.xMaxValueTb);
            this.Controls.Add(this.xMinValueTb);
            this.Controls.Add(this.yAxisRangeLabel);
            this.Controls.Add(this.graphNameLabelTB);
            this.Controls.Add(this.yAxisNameTB);
            this.Controls.Add(this.xAxisNameTB);
            this.Controls.Add(this.yAxisNameLabel);
            this.Controls.Add(this.graphNameLabel);
            this.Controls.Add(this.xAxisNameLabel);
            this.Controls.Add(this.xAxisRangeLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.Text = "Настройки ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.afterSelectEventHandlerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xAxisRangeLabel;
        private System.Windows.Forms.Label xAxisNameLabel;
        private System.Windows.Forms.Label graphNameLabel;
        private System.Windows.Forms.Label yAxisNameLabel;
        private System.Windows.Forms.TextBox xAxisNameTB;
        private System.Windows.Forms.TextBox yAxisNameTB;
        private System.Windows.Forms.TextBox graphNameLabelTB;
        private System.Windows.Forms.Label yAxisRangeLabel;
        private System.Windows.Forms.TextBox xMinValueTb;
        private System.Windows.Forms.TextBox xMaxValueTb;
        private System.Windows.Forms.TextBox yMinValueTb;
        private System.Windows.Forms.TextBox yMaxValueTb;
        private System.Windows.Forms.Label dash1;
        private System.Windows.Forms.Label dash2;
        private System.Windows.Forms.Label autosaveFileLabel;
        private System.Windows.Forms.TextBox autosavePathTB;
        private System.Windows.Forms.Button applyChanges;
        private System.Windows.Forms.Button drawGraphB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox coefficientTB;
        private System.Windows.Forms.Label coefficientL;
        private System.Windows.Forms.ImageList ListForCombo;
        private ImageComboBox.ImageComboBox symbolCB;
        private System.Windows.Forms.BindingSource afterSelectEventHandlerBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sizeCB;
    }
}