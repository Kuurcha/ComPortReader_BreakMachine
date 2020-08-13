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

        }

        private void decline_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accept_Click(object sender, EventArgs e)
        {
            if (form.SelectionCurveBegin != null && form.SelectionCurveEnd != null)
            {
                double beginX = form.SelectionCurveBegin.Points[0].X;
                double endX = form.SelectionCurveEnd.Points[0].X;
                int begin = (int)Math.Min(beginX, endX);
                int end = (int)Math.Max(beginX, endX);
                LineItem temp = new LineItem("tempCurve");
                if (form.getCurve != null)
                {
                    if (leastSquaresMode)
                    {
                        for (int i = begin; i < end; i++) temp.AddPoint(form.getCurve.Points[i]);
                        double[] xData = GraphProcessing.CurveToArray(temp, true);
                        double[] yData = GraphProcessing.CurveToArray(temp, false);
                        var ds = new XYDataSet(xData, yData);
                        double k = ds.Slope;
                        double b = ds.YIntercept;
                        LineItem aproximateLinearCurve = null;
                        form.buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, form.CurvesDropDownButton, form.ZGCInstance, "Линейный участок методом наименьших квадратов", Color.DarkCyan, 6, SymbolType.Circle, Color.DarkCyan));
                        for (int i = begin; i < form.getLineCurve[form.getLineCurve.Points.Count - 1].X; i++)
                        {
                            aproximateLinearCurve.AddPoint(new PointPair(i, k * i + b));
                        }
                    }
                    if (regularMode)
                    {
                        LineItem aproximateLinearCurve = null;
                        double x1 = form.getCurve.Points[begin].X;
                        double y1 = form.getCurve.Points[begin].Y;

                        double x2 = form.getCurve.Points[end].X;
                        double y2 = form.getCurve.Points[end].Y;

                        double coef = (y2 - y1) / (x2 - x1);

                        form.buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, form.CurvesDropDownButton, form.ZGCInstance, "Линейный участок через две точки", Color.DarkCyan, 6, SymbolType.Circle, Color.DarkCyan));
                        for (int i = begin; i < end; i++) aproximateLinearCurve.AddPoint(new PointPair(i, coef * (i - x1) + y1));
                        //y = (x-x1)*(y2-y1)/(x2-x1) + y1
                    }
                }
                GraphProcessing.UpdateGraph(form.ZGCInstance);
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
    }
}
