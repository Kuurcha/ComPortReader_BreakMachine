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
            base.Closing += OnClosing;
        }
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            switch (MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    cancelEventArgs.Cancel = true;
                    break;
            }
        }

        private void decline_Click(object sender, EventArgs e)
        {
            base.Closing -= OnClosing;
            this.Close();
            Task.Delay(1500);
            form.ChooseMode = true;
        }

        private void accept_Click(object sender, EventArgs e)
        {
                if (form.SelectionCurveBegin != null && form.SelectionCurveEnd != null)
                {
                int index = form.ZGCInstance.GraphPane.CurveList.IndexOf("Линейный участок МНК");
                if (index >= 0)
                {
                    form.ZGCInstance.GraphPane.CurveList.RemoveAt(index);
                    
                    DynamicToolStripButton tempBtn = null;
                    for (int i = 0; i < form.buttons.Count; i++)
                    {
                        string test = form.buttons[i].curve.Label.Text;
                        if (test == "Линейный участок МНК") { tempBtn = form.buttons[i]; break; }
                    }
                    form.CurvesDropDownButton.DropDownItems.Remove(tempBtn.button);
                }
                

                PointPairList tempPointPair = (PointPairList)form.getCurve.Points;
                
                double beginX = tempPointPair.IndexOf(form.SelectionCurveBegin.Points[0]);
                double endX = tempPointPair.IndexOf(form.SelectionCurveEnd.Points[0]);
                int begin = (int)Math.Min(beginX, endX);
                int end = (int)Math.Max(beginX, endX);
                LineItem temp = new LineItem("tempCurve");
                temp.Tag = 5;
                LineItem aproximateLinearCurve = null;
                if (form.getCurve != null)
                {
                    if (leastSquaresMode)
                    {
                        for (int i = begin; i < end; i++) temp.AddPoint(form.getCurve.Points[i]);
                        begin =  (int) form.getCurve.Points[begin].X;
                        end = (int) form.getCurve.Points[end].X;
                    
                        form.buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, form.CurvesDropDownButton, form.ZGCInstance, "Линейный участок МНК", Color.Green, 2, SymbolType.Default, Color.Green));
                        aproximateLinearCurve.Tag = 2;
                        MyMath.leastSquaresBuild(begin, end, temp, ref aproximateLinearCurve, form);
                     
                        form.ZGCInstance.Refresh();
                        GraphProcessing.UpdateGraph(form.ZGCInstance);
                        //LineItem curve1 = form.AproximateLinearCurve;
                        //LineItem curve2 = null;
                        //form.buttons.Add(GraphProcessing.CreateCurve(ref curve1, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 1", Color.DarkCyan, 6, SymbolType.Circle, Color.DarkCyan));
                        //form.buttons.Add(GraphProcessing.CreateCurve(ref curve2, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 2", Color.DarkCyan, 6, SymbolType.Circle, Color.DarkCyan));
                        MyMath.zeroTwoSigma(form.getCurve, new PointPair (form.SelectionCurveEnd.Points[0]), aproximateLinearCurve, form.secondDerivativeCurve, form);
                        //MyMath.OffSetTheLine1(new PointPair(xData[0], yData[0]), new PointPair(xData[xData.Length-1], yData[yData.Length-1]), form.secondDerivativeCurve, form.getCurve, form);
                        //GraphProcessing.UpdateGraph(form.ZGCInstance);

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

                        form.buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, form.CurvesDropDownButton, form.ZGCInstance, "Линейный участок через две точки", Color.DarkCyan, 6, SymbolType.Circle, Color.DarkCyan));
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
                }

                //if (form.processedCurve != null) { form.ZGCInstance.GraphPane.CurveList.Remove(form.processedCurve); form.processedCurve = null; }
                //if (form.processedCurve2 != null) {  form.ZGCInstance.GraphPane.CurveList.Remove(form.processedCurve2); form.processedCurve2 = null; }
                base.Closing -= OnClosing;
                this.Close();
               
                Task.Delay(1500);
                form.ChooseMode = true;



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
            this.leastSquares.Checked = true;
            this.regular.Checked = false;
            leastSquaresMode = true;
            regularMode = false;
        }

        private void regular_Click(object sender, EventArgs e)
        {
            this.leastSquares.Checked = false;
            this.regular.Checked = true;
            leastSquaresMode = false;
            regularMode = true;
        }

        private void info_Click(object sender, EventArgs e)
        {

        }

        private void CustomLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Delay(500);
            MessageBox.Show("Выберите одну или две точки где находится предел текучести и нажмите Enter как будет готово");

        }

        private void CustomLine_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
