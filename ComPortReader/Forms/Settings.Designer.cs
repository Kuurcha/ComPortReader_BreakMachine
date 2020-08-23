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
            ImageComboBox.ImageComboBoxItem imageComboBoxItem1 = new ImageComboBox.ImageComboBoxItem();
            ImageComboBox.ImageComboBoxItem imageComboBoxItem2 = new ImageComboBox.ImageComboBoxItem();
            ImageComboBox.ImageComboBoxItem imageComboBoxItem3 = new ImageComboBox.ImageComboBoxItem();
            ImageComboBox.ImageComboBoxItem imageComboBoxItem4 = new ImageComboBox.ImageComboBoxItem();
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.baudRateTB = new System.Windows.Forms.TextBox();
            this.parityTB = new System.Windows.Forms.ComboBox();
            this.dataBitTB = new System.Windows.Forms.TextBox();
            this.stopBitTB = new System.Windows.Forms.ComboBox();
            this.sensitivityTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.afterSelectEventHandlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // xAxisRangeLabel
            // 
            this.xAxisRangeLabel.AutoSize = true;
            this.xAxisRangeLabel.Location = new System.Drawing.Point(12, 108);
            this.xAxisRangeLabel.Name = "xAxisRangeLabel";
            this.xAxisRangeLabel.Size = new System.Drawing.Size(139, 13);
            this.xAxisRangeLabel.TabIndex = 34;
            this.xAxisRangeLabel.Text = "Диапазон значений оси Х";
            // 
            // xAxisNameLabel
            // 
            this.xAxisNameLabel.AutoSize = true;
            this.xAxisNameLabel.Location = new System.Drawing.Point(17, 77);
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
            this.yAxisNameLabel.Location = new System.Drawing.Point(16, 56);
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
            this.yAxisRangeLabel.Location = new System.Drawing.Point(14, 135);
            this.yAxisRangeLabel.Name = "yAxisRangeLabel";
            this.yAxisRangeLabel.Size = new System.Drawing.Size(140, 13);
            this.yAxisRangeLabel.TabIndex = 40;
            this.yAxisRangeLabel.Text = "Диапазон значений оси У";
            this.yAxisRangeLabel.Click += new System.EventHandler(this.yAxisRangeLabel_Click);
            // 
            // xMinValueTb
            // 
            this.xMinValueTb.Location = new System.Drawing.Point(159, 105);
            this.xMinValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.xMinValueTb.MaxLength = 300;
            this.xMinValueTb.Name = "xMinValueTb";
            this.xMinValueTb.Size = new System.Drawing.Size(51, 20);
            this.xMinValueTb.TabIndex = 41;
            this.xMinValueTb.TextChanged += new System.EventHandler(this.xMinValueTb_TextChanged);
            // 
            // xMaxValueTb
            // 
            this.xMaxValueTb.Location = new System.Drawing.Point(230, 105);
            this.xMaxValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.xMaxValueTb.MaxLength = 300;
            this.xMaxValueTb.Name = "xMaxValueTb";
            this.xMaxValueTb.Size = new System.Drawing.Size(51, 20);
            this.xMaxValueTb.TabIndex = 42;
            // 
            // yMinValueTb
            // 
            this.yMinValueTb.Location = new System.Drawing.Point(159, 133);
            this.yMinValueTb.Margin = new System.Windows.Forms.Padding(2);
            this.yMinValueTb.MaxLength = 300;
            this.yMinValueTb.Name = "yMinValueTb";
            this.yMinValueTb.Size = new System.Drawing.Size(51, 20);
            this.yMinValueTb.TabIndex = 43;
            // 
            // yMaxValueTb
            // 
            this.yMaxValueTb.Location = new System.Drawing.Point(230, 133);
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
            this.dash1.Location = new System.Drawing.Point(213, 105);
            this.dash1.Name = "dash1";
            this.dash1.Size = new System.Drawing.Size(14, 20);
            this.dash1.TabIndex = 45;
            this.dash1.Text = "-";
            // 
            // dash2
            // 
            this.dash2.AutoSize = true;
            this.dash2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dash2.Location = new System.Drawing.Point(213, 130);
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
            this.applyChanges.Location = new System.Drawing.Point(305, 245);
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
            this.drawGraphB.Location = new System.Drawing.Point(17, 245);
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
            this.button1.Location = new System.Drawing.Point(326, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 29);
            this.button1.TabIndex = 51;
            this.button1.Text = "Обнулить график";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // coefficientTB
            // 
            this.coefficientTB.Location = new System.Drawing.Point(159, 158);
            this.coefficientTB.Margin = new System.Windows.Forms.Padding(2);
            this.coefficientTB.MaxLength = 8;
            this.coefficientTB.Name = "coefficientTB";
            this.coefficientTB.Size = new System.Drawing.Size(51, 20);
            this.coefficientTB.TabIndex = 53;
            // 
            // coefficientL
            // 
            this.coefficientL.AutoSize = true;
            this.coefficientL.Location = new System.Drawing.Point(74, 161);
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
            imageComboBoxItem1.Font = null;
            imageComboBoxItem1.Image = "1";
            imageComboBoxItem1.ImageIndex = 1;
            imageComboBoxItem1.IndentLevel = 0;
            imageComboBoxItem1.Item = null;
            imageComboBoxItem1.Text = "Звезда";
            imageComboBoxItem2.Font = null;
            imageComboBoxItem2.Image = "3";
            imageComboBoxItem2.ImageIndex = 3;
            imageComboBoxItem2.IndentLevel = 0;
            imageComboBoxItem2.Item = null;
            imageComboBoxItem2.Text = "Палка";
            imageComboBoxItem3.Font = null;
            imageComboBoxItem3.Image = "0";
            imageComboBoxItem3.ImageIndex = 0;
            imageComboBoxItem3.IndentLevel = 0;
            imageComboBoxItem3.Item = null;
            imageComboBoxItem3.Text = "Круг";
            imageComboBoxItem4.Font = null;
            imageComboBoxItem4.Image = "2";
            imageComboBoxItem4.ImageIndex = 2;
            imageComboBoxItem4.IndentLevel = 0;
            imageComboBoxItem4.Item = null;
            imageComboBoxItem4.Text = "Линия";
            this.symbolCB.Items.AddRange(new ImageComboBox.ImageComboBoxItem[] {
            imageComboBoxItem1,
            imageComboBoxItem2,
            imageComboBoxItem3,
            imageComboBoxItem4});
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
            this.label2.Location = new System.Drawing.Point(313, 3);
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
            this.sizeCB.Location = new System.Drawing.Point(332, 19);
            this.sizeCB.Margin = new System.Windows.Forms.Padding(2);
            this.sizeCB.Name = "sizeCB";
            this.sizeCB.Size = new System.Drawing.Size(29, 21);
            this.sizeCB.TabIndex = 57;
            this.sizeCB.SelectedIndexChanged += new System.EventHandler(this.sizeCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Настройки COM-порта";
            // 
            // baudRateTB
            // 
            this.baudRateTB.Location = new System.Drawing.Point(63, 220);
            this.baudRateTB.Name = "baudRateTB";
            this.baudRateTB.Size = new System.Drawing.Size(77, 20);
            this.baudRateTB.TabIndex = 59;
            this.toolTip1.SetToolTip(this.baudRateTB, "Скорость передачи (Baud Rate)");
            this.baudRateTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.baudRateTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.baudRateTB_KeyPress);
            // 
            // parityTB
            // 
            this.parityTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityTB.FormattingEnabled = true;
            this.parityTB.Items.AddRange(new object[] {
            "Отсуствует",
            "Всегда чет",
            "Всегда нечет",
            "Всегда 1",
            "Всегда 0"});
            this.parityTB.Location = new System.Drawing.Point(178, 219);
            this.parityTB.Name = "parityTB";
            this.parityTB.Size = new System.Drawing.Size(70, 21);
            this.parityTB.TabIndex = 61;
            this.toolTip1.SetToolTip(this.parityTB, "Бит четности (Parity)");
            this.parityTB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // dataBitTB
            // 
            this.dataBitTB.Location = new System.Drawing.Point(285, 219);
            this.dataBitTB.MaxLength = 1;
            this.dataBitTB.Name = "dataBitTB";
            this.dataBitTB.Size = new System.Drawing.Size(25, 20);
            this.dataBitTB.TabIndex = 63;
            this.toolTip1.SetToolTip(this.dataBitTB, "Бит данных (dataBit)");
            this.dataBitTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataBitTB_KeyPress);
            // 
            // stopBitTB
            // 
            this.stopBitTB.BackColor = System.Drawing.SystemColors.HotTrack;
            this.stopBitTB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitTB.ForeColor = System.Drawing.SystemColors.Info;
            this.stopBitTB.FormattingEnabled = true;
            this.stopBitTB.Items.AddRange(new object[] {
            "0",
            "1",
            "1,5",
            "2"});
            this.stopBitTB.Location = new System.Drawing.Point(346, 218);
            this.stopBitTB.Name = "stopBitTB";
            this.stopBitTB.Size = new System.Drawing.Size(39, 21);
            this.stopBitTB.TabIndex = 65;
            this.toolTip1.SetToolTip(this.stopBitTB, "Стоп бит (Stop Bit)");
            this.stopBitTB.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // sensitivityTB
            // 
            this.sensitivityTB.Location = new System.Drawing.Point(346, 108);
            this.sensitivityTB.Margin = new System.Windows.Forms.Padding(2);
            this.sensitivityTB.MaxLength = 3;
            this.sensitivityTB.Name = "sensitivityTB";
            this.sensitivityTB.Size = new System.Drawing.Size(51, 20);
            this.sensitivityTB.TabIndex = 68;
            this.toolTip1.SetToolTip(this.sensitivityTB, "Чувствительность сглаживания графика для определения предела текучести");
            this.sensitivityTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sensitivityTB_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Скорость передачи";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Бит четности";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Бит данных";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Cтоп бит";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Чувствительность зуб";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Чувствительность низ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(346, 151);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 20);
            this.textBox1.TabIndex = 70;
            this.toolTip1.SetToolTip(this.textBox1, "Коэф на сколько маленькой допускается разброс производной для определения нижней " +
        "границы");
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 279);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sensitivityTB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopBitTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataBitTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.parityTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baudRateTB);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox baudRateTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox parityTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dataBitTB;
        private System.Windows.Forms.ComboBox stopBitTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sensitivityTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
    }
}