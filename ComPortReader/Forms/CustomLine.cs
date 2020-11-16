using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing.Drawing2D;
using ComPortReader.Classes;
using ComPortReader.Forms;
using System.CodeDom;

namespace ComPortReader.Forms
{
    public partial class CustomLine : Form
    {

        bool regularMode = false;
        bool leastSquaresMode = true;
        MainProgram form;
        public CustomLine(MainProgram form)
        {
            InitializeComponent();
            this.form = form;
        }



        private void CustomLine_Load(object sender, EventArgs e)
        {
            double maxY = double.MinValue;
            double maxX = double.MinValue;
            for (int i = 0; i < form.ZGCInstance.GraphPane.CurveList[0].Points.Count; i++)
            {
                if (form.ZGCInstance.GraphPane.CurveList[0].Points[i].Y > maxY) maxY = form.ZGCInstance.GraphPane.CurveList[0].Points[i].Y;
                if (form.ZGCInstance.GraphPane.CurveList[0].Points[i].X > maxX) maxX = form.ZGCInstance.GraphPane.CurveList[0].Points[i].X;
            }
            base.Closing += OnClosing;
        }
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            switch (MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    GraphProcessing.OnClosingMethod(form);
                    break;
                case DialogResult.No:
                    cancelEventArgs.Cancel = true;
                    break;
            }
        }
        public void closeForm()
        {
            base.Closing -= OnClosing;
            this.Close();
            Task.Delay(1500);
            form.ChooseMode = true;
        }
        private void decline_Click(object sender, EventArgs e)
        {
            if (!isUsed) MessageBox.Show("Вы не построили линию", "Внимание");
            else
            {
                GraphProcessing.RemoveSelection(form);
                closeForm();
                GraphProcessing.RemoveSelection(form);
                form.readingStressFlowForm = new ChooseStressFlow(form);
                form.readingStressFlowForm.Show();
                form.readingStressFlowForm.Focus();
                form.readingStressFlowForm.BringToFront();
            }
        }
        
        const string MNK_NAME = "Линейный участок МНК";
        const string REG_NAME = "Линейный участок через две точки";
      
        bool isUsed = false;
        LineItem aproximateLinearCurve = null;
        private void accept_Click(object sender, EventArgs e)
        {
            aproximateLinearCurve = null;
            GraphProcessing.RemoveLine(MNK_NAME, form);
            GraphProcessing.RemoveLine(MNK_NAME, form);
            GraphProcessing.RemoveLine(REG_NAME, form);

            GraphProcessing.UpdateGraph(form.ZGCInstance);
            if (form.SelectionCurveBegin != null && form.SelectionCurveEnd != null)
                {
                int index = form.ZGCInstance.GraphPane.CurveList.IndexOf(MNK_NAME);
                if (index >= 0)
                {
                    form.ZGCInstance.GraphPane.CurveList.RemoveAt(index);           
                    DynamicToolStripButton tempBtn = null;
                    for (int i = 0; i < form.buttons.Count; i++)
                    {
                        string test = form.buttons[i].curve.Label.Text;
                        if (test == MNK_NAME) { tempBtn = form.buttons[i]; break; }
                    }
                    form.CurvesDropDownButton.DropDownItems.Remove(tempBtn.button);
                }
                

                PointPairList tempPointPair = (PointPairList) form.getCurve.Points;
                double beginX = tempPointPair.IndexOf(form.SelectionCurveBegin.Points[0]);
                double endX = tempPointPair.IndexOf(form.SelectionCurveEnd.Points[0]);
                int begin = (int)Math.Min(beginX, endX);
                int end = (int)Math.Max(beginX, endX);
                LineItem temp = new LineItem("tempCurve");
                temp.Tag = 5;
            
                if (form.getCurve != null)
                {
                    if (leastSquaresMode)
                    {
                        for (int i = begin; i < end; i++) temp.AddPoint(form.getCurve.Points[i]);
                        begin =  (int) form.getCurve.Points[begin].X;
                        end = (int) form.getCurve.Points[end].X;
                    
                        form.buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, form.CurvesDropDownButton, form.ZGCInstance, MNK_NAME, Color.Green, 2, SymbolType.Default, Color.Green));
                        aproximateLinearCurve.Tag = 2;
                        double[] data = MyMath.leastSquaresBuild(begin, end, temp, ref aproximateLinearCurve, form);
                        form.kCoef = data[0];
                        form.bCoef = data[1];
                        form.ZGCInstance.Refresh();
                        GraphProcessing.UpdateGraph(form.ZGCInstance);
                       
                        form.AproximateLinearCurve = aproximateLinearCurve;


                    }
                    if (regularMode)
                    {
                        aproximateLinearCurve = null;
                        double x1 = form.getCurve.Points[begin].X;
                        double y1 = form.getCurve.Points[begin].Y;

                        double x2 = form.getCurve.Points[end].X;
                        double y2 = form.getCurve.Points[end].Y;
                  
                        // y= y1+(x-x1) (y2 - y1) / (x2-x1) ; y = k*(x-x1) + y1 = kx - (kx1 + y1)

                        double coef = (y2 - y1) / (x2 - x1);

                        form.buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, form.CurvesDropDownButton, form.ZGCInstance, REG_NAME, Color.DarkCyan, 6, SymbolType.Circle, Color.DarkCyan));
                        for (int i = (int) form.getCurve.Points[(int)begin].X; i < form.getCurve.Points[(int)end].X; i++) aproximateLinearCurve.AddPoint(new PointPair(i, coef * (i - x1) + y1));
                        form.AproximateLinearCurve = aproximateLinearCurve;
                        GraphProcessing.UpdateGraph(form.ZGCInstance);
                        LineItem curveTemp = form.getCurve;
                        curveTemp.Tag = 5;
                        aproximateLinearCurve.Tag = 2;
                        //MyMath.buildLine(form.secondDerivativeCurve, ref curveTemp, form);
                        form.getCurve = curveTemp;
                        
                        GraphProcessing.UpdateGraph(form.ZGCInstance);
                        //y = (x-x1)*(y2-y1)/(x2-x1) + y1
                    }
                    isUsed = true;
                }

                //if (form.processedCurve != null) { form.ZGCInstance.GraphPane.CurveList.Remove(form.processedCurve); form.processedCurve = null; }
                //if (form.processedCurve2 != null) {  form.ZGCInstance.GraphPane.CurveList.Remove(form.processedCurve2); form.processedCurve2 = null; }
            }
            else
            {
                MessageBox.Show("Выберите две точки на прямой который будут использованы для построения прямой");
            }
            
        }

        private void leastSquares_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void leastSquares_Click(object sender, EventArgs e)
        {
            //this.leastSquares.Checked = true;
            //this.regular.Checked = false;
            //leastSquaresMode = true;
            //regularMode = false;
        }

        private void regular_Click(object sender, EventArgs e)
        {
            //this.leastSquares.Checked = false;
            //this.regular.Checked = true;
            //leastSquaresMode = false;
            //regularMode = true;
        }

        private void info_Click(object sender, EventArgs e)
        {

        }

        private void CustomLine_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }

        private void CustomLine_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
