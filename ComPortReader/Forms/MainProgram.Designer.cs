namespace ComPortReader
{
    partial class MainProgram
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.resetB = new System.Windows.Forms.ToolStripButton();
            this.showWindow = new System.Windows.Forms.ToolStripButton();
            this.startingRecordMenuB = new System.Windows.Forms.ToolStripDropDownButton();
            this.startBuilding = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBuilding = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortStatusB = new System.Windows.Forms.ToolStripComboBox();
            this.setCOMB = new System.Windows.Forms.ToolStripButton();
            this.curvesDropDownBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.coord = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.planeGraph = new ZedGraph.ZedGraphControl();
            this.textBox2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetB,
            this.showWindow,
            this.startingRecordMenuB,
            this.comPortStatusB,
            this.setCOMB,
            this.curvesDropDownBtn,
            this.coord,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1159, 31);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // resetB
            // 
            this.resetB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetB.Image = ((System.Drawing.Image)(resources.GetObject("resetB.Image")));
            this.resetB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetB.Name = "resetB";
            this.resetB.Size = new System.Drawing.Size(62, 28);
            this.resetB.Text = "Свойства";
            this.resetB.Click += new System.EventHandler(this.resetB_Click);
            this.resetB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resetB_MouseDown);
            // 
            // showWindow
            // 
            this.showWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showWindow.Enabled = false;
            this.showWindow.Image = ((System.Drawing.Image)(resources.GetObject("showWindow.Image")));
            this.showWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showWindow.Name = "showWindow";
            this.showWindow.Size = new System.Drawing.Size(105, 28);
            this.showWindow.Text = "Показать данные";
            this.showWindow.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // startingRecordMenuB
            // 
            this.startingRecordMenuB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startingRecordMenuB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBuilding,
            this.stopBuilding});
            this.startingRecordMenuB.Image = ((System.Drawing.Image)(resources.GetObject("startingRecordMenuB.Image")));
            this.startingRecordMenuB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startingRecordMenuB.Name = "startingRecordMenuB";
            this.startingRecordMenuB.Size = new System.Drawing.Size(136, 28);
            this.startingRecordMenuB.Text = "Построение графика";
            this.startingRecordMenuB.Click += new System.EventHandler(this.startingRecordMenuB_Click);
            // 
            // startBuilding
            // 
            this.startBuilding.Name = "startBuilding";
            this.startBuilding.Size = new System.Drawing.Size(116, 22);
            this.startBuilding.Text = "Начало";
            this.startBuilding.Click += new System.EventHandler(this.startBuilding_Click);
            // 
            // stopBuilding
            // 
            this.stopBuilding.Enabled = false;
            this.stopBuilding.Name = "stopBuilding";
            this.stopBuilding.Size = new System.Drawing.Size(116, 22);
            this.stopBuilding.Text = "Стоп";
            this.stopBuilding.Click += new System.EventHandler(this.stopBuilding_Click);
            // 
            // comPortStatusB
            // 
            this.comPortStatusB.Name = "comPortStatusB";
            this.comPortStatusB.Size = new System.Drawing.Size(82, 31);
            this.comPortStatusB.DropDownClosed += new System.EventHandler(this.ComPortStatus_DropDownClosed);
            this.comPortStatusB.SelectedIndexChanged += new System.EventHandler(this.portList_SelectedIndexChanged);
            // 
            // setCOMB
            // 
            this.setCOMB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setCOMB.Image = ((System.Drawing.Image)(resources.GetObject("setCOMB.Image")));
            this.setCOMB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setCOMB.Name = "setCOMB";
            this.setCOMB.Size = new System.Drawing.Size(103, 28);
            this.setCOMB.Text = "установить COM";
            this.setCOMB.Click += new System.EventHandler(this.SetupCOMport_Click);
            // 
            // curvesDropDownBtn
            // 
            this.curvesDropDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.curvesDropDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("curvesDropDownBtn.Image")));
            this.curvesDropDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.curvesDropDownBtn.Name = "curvesDropDownBtn";
            this.curvesDropDownBtn.Size = new System.Drawing.Size(37, 28);
            this.curvesDropDownBtn.Text = "Скрыть/Показать графики";
            this.curvesDropDownBtn.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // coord
            // 
            this.coord.Name = "coord";
            this.coord.Size = new System.Drawing.Size(0, 28);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "Печать";
            this.toolStripButton1.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // planeGraph
            // 
            this.planeGraph.AutoSize = true;
            this.planeGraph.IsShowPointValues = true;
            this.planeGraph.Location = new System.Drawing.Point(0, 25);
            this.planeGraph.Name = "planeGraph";
            this.planeGraph.ScrollGrace = 0D;
            this.planeGraph.ScrollMaxX = 900D;
            this.planeGraph.ScrollMaxY = 600D;
            this.planeGraph.ScrollMaxY2 = 0D;
            this.planeGraph.ScrollMinX = 0D;
            this.planeGraph.ScrollMinY = 1000D;
            this.planeGraph.ScrollMinY2 = 1000D;
            this.planeGraph.SelectModifierKeys = System.Windows.Forms.Keys.None;
            this.planeGraph.Size = new System.Drawing.Size(1159, 583);
            this.planeGraph.TabIndex = 13;
            this.planeGraph.UseExtendedPrintDialog = true;
            this.planeGraph.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.planeGraph_MouseMoveEvent);
            this.planeGraph.DoubleClickEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.planeGraph_DoubleClickEvent);
            this.planeGraph.Load += new System.EventHandler(this.planeGraph_Load_1);
            this.planeGraph.DockChanged += new System.EventHandler(this.planeGraph_DockChanged);
            this.planeGraph.DoubleClick += new System.EventHandler(this.planeGraph_DoubleClick);
            this.planeGraph.KeyDown += new System.Windows.Forms.KeyEventHandler(this.planeGraph_KeyDown);
            this.planeGraph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.planeGraph_KeyPress);
            this.planeGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.planeGraph_MouseClick);
            this.planeGraph.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.planeGraph_PreviewKeyDown);
            // 
            // textBox2
            // 
            this.textBox2.AutoSize = true;
            this.textBox2.Location = new System.Drawing.Point(665, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(0, 13);
            this.textBox2.TabIndex = 36;
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 608);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.planeGraph);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Построение графиков";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainProgram_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Resize += new System.EventHandler(this.MainProgram_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton setCOMB;
        private ZedGraph.ZedGraphControl planeGraph;
        private System.Windows.Forms.ToolStripButton resetB;
        private System.Windows.Forms.Label textBox2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel coord;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton curvesDropDownBtn;
        internal System.Windows.Forms.ToolStripDropDownButton startingRecordMenuB;
        internal System.Windows.Forms.ToolStripMenuItem stopBuilding;
        internal System.Windows.Forms.ToolStripMenuItem startBuilding;
        internal System.Windows.Forms.ToolStripButton showWindow;
        public System.Windows.Forms.ToolStripComboBox comPortStatusB;
    }
}

