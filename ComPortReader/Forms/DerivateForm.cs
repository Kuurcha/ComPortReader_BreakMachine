using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ComPortReader.Forms
{
    public partial class DerivateForm : Form
    {
        MainProgram form;
        public DerivateForm(MainProgram form)
        {
            this.form = form;
            InitializeComponent();
            GraphProcessing.CreateGraph(firstDerivative,"Первая производная", "X", "Y'", 50, 5);
            GraphProcessing.CreateGraph(secondDerivative, "Вторая производная", "X", "Y''",50, 5);
            firstDerivative.Tag = 5;
            secondDerivative.Tag = 5;
            LineItem curve = null;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve, form.CurvesDropDownButton, firstDerivative, "Первая производная", Color.Red, 6, SymbolType.Circle, Color.Red));
            curve.Tag = 5;
            GraphProcessing.DerivativeGraph(form.getCurve, ref curve);
            LineItem curve2 = null;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve2, form.CurvesDropDownButton, secondDerivative, "Вторая производная", Color.Blue, 6, SymbolType.Circle, Color.Blue));
            GraphProcessing.SecondDerivativeGraph(curve, ref curve2);
            curve2.Tag = 5;

            LineItem movingAverage = null;
            form.buttons.Add(GraphProcessing.CreateCurve(ref movingAverage, form.CurvesDropDownButton, firstDerivative, "Первая производная 2", Color.Cyan, 6, SymbolType.Circle, Color.Red));
            GraphProcessing.DerivativeGraph(form.processedCurve, ref movingAverage);
            movingAverage.Tag = 5;
            LineItem movingAverageTemp = new LineItem("temp");
           
            LineItem movingAverage2 = null;
           
            form.buttons.Add(GraphProcessing.CreateCurve(ref movingAverage2, form.CurvesDropDownButton, secondDerivative, "Вторая производная 2", Color.Cyan, 6, SymbolType.Circle, Color.Red));
            movingAverage2.Tag = 5;
            GraphProcessing.DerivativeGraph(form.processedCurve2, ref movingAverageTemp);
            GraphProcessing.SecondDerivativeGraph(movingAverageTemp, ref movingAverage2);
            GraphProcessing.UpdateGraph(firstDerivative);
            GraphProcessing.UpdateGraph(secondDerivative);
        }

        private void DerivateForm_Load(object sender, EventArgs e)
        {

        }

        private void DerivateForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
             
        }

        private void firstDerivative_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            double stepX = 10;//Math.Log10(Math.Abs(firstDerivative.ScrollMaxX - firstDerivative.ScrollMinX));
            double stepY = 1; Math.Log10(Math.Abs(firstDerivative.ScrollMaxY - firstDerivative.ScrollMinY));

            if (e.KeyCode == Keys.Up)
            {
                firstDerivative.ScrollMinY += stepY;
                firstDerivative.ScrollMaxY += stepY;
                secondDerivative.ScrollMinY += stepY;
                secondDerivative.ScrollMaxY += stepY;
            }


            if (e.KeyCode == Keys.Down)
            {
                firstDerivative.ScrollMinY -= stepY;
                firstDerivative.ScrollMaxY -= stepY;
                secondDerivative.ScrollMinY -= stepY;
                secondDerivative.ScrollMaxY -= stepY; ;
            }

            if (e.KeyCode == Keys.Left)
            {
                firstDerivative.ScrollMinX -= stepX;
                firstDerivative.ScrollMaxX -= stepX;
                secondDerivative.ScrollMinX -= stepX;
                secondDerivative.ScrollMaxX -= stepX;
            }

            if (e.KeyCode == Keys.Right)
            {
                firstDerivative.ScrollMinX += stepX;
                firstDerivative.ScrollMaxX += stepX;
                secondDerivative.ScrollMinX += stepX;
                secondDerivative.ScrollMaxX += stepX;
            }
            GraphProcessing.UpdateGraph(firstDerivative);
            GraphProcessing.UpdateGraph(secondDerivative);
        }
    }
}
