namespace ComPortReader.Forms
{
    partial class DerivateForm
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
            this.firstDerivative = new ZedGraph.ZedGraphControl();
            this.secondDerivative = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // firstDerivative
            // 
            this.firstDerivative.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.firstDerivative.IsShowPointValues = true;
            this.firstDerivative.Location = new System.Drawing.Point(12, 3);
            this.firstDerivative.Name = "firstDerivative";
            this.firstDerivative.ScrollGrace = 0D;
            this.firstDerivative.ScrollMaxX = 900D;
            this.firstDerivative.ScrollMaxY = 600D;
            this.firstDerivative.ScrollMaxY2 = 0D;
            this.firstDerivative.ScrollMinX = 0D;
            this.firstDerivative.ScrollMinY = 1000D;
            this.firstDerivative.ScrollMinY2 = 1000D;
            this.firstDerivative.SelectModifierKeys = System.Windows.Forms.Keys.None;
            this.firstDerivative.Size = new System.Drawing.Size(569, 309);
            this.firstDerivative.TabIndex = 14;
            this.firstDerivative.UseExtendedPrintDialog = true;
            this.firstDerivative.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.firstDerivative_PreviewKeyDown);
            // 
            // secondDerivative
            // 
            this.secondDerivative.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.secondDerivative.IsShowPointValues = true;
            this.secondDerivative.Location = new System.Drawing.Point(587, 3);
            this.secondDerivative.Name = "secondDerivative";
            this.secondDerivative.ScrollGrace = 0D;
            this.secondDerivative.ScrollMaxX = 900D;
            this.secondDerivative.ScrollMaxY = 600D;
            this.secondDerivative.ScrollMaxY2 = 0D;
            this.secondDerivative.ScrollMinX = 0D;
            this.secondDerivative.ScrollMinY = 1000D;
            this.secondDerivative.ScrollMinY2 = 1000D;
            this.secondDerivative.SelectModifierKeys = System.Windows.Forms.Keys.None;
            this.secondDerivative.Size = new System.Drawing.Size(569, 309);
            this.secondDerivative.TabIndex = 15;
            this.secondDerivative.UseExtendedPrintDialog = true;
            // 
            // DerivateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 333);
            this.Controls.Add(this.secondDerivative);
            this.Controls.Add(this.firstDerivative);
            this.Name = "DerivateForm";
            this.Text = "й";
            this.Load += new System.EventHandler(this.DerivateForm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DerivateForm_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl firstDerivative;
        private ZedGraph.ZedGraphControl secondDerivative;
    }
}