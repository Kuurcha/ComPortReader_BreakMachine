using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZedGraph;
using System.ComponentModel;

namespace ComPortReader.Classes
{
    static class  MyMath
    {
        public static void zeroTwoSigma2(LineItem originalCurve, PointPair p2, LineItem LineCurve, LineItem curved2, MainProgram form)
        {
            LineItem curve1 = null;
            LineItem curve2 = null;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve1, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 1", Color.DarkCyan, 4, SymbolType.Default, Color.DarkCyan));
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve2, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 2", Color.DarkCyan, 4, SymbolType.Default, Color.DarkCyan));
    
            int max = 0;
            for (int i = 0; i < originalCurve.Points.Count; i++) if (originalCurve.Points[i].X > max) max = (int)originalCurve.Points[i].X;
            double average = 0;
            for (int i = 0; i < curved2.Points.Count - 10; i++) average += Math.Abs(curved2[i].Y);
            average /= curved2.Points.Count - 10;
            int index = 0;
            for (index = 0; index < curved2.Points.Count; index++) { if (curved2[index].Y > 10.0 * average) break; }
            double offSetY = originalCurve[index].Y - p2.Y;
            double offSetX = originalCurve[index].X - p2.X;
            for (int i = 0; i < LineCurve.Points.Count - 1; i++)
            {
                double x = LineCurve.Points[i].X - offSetX;
                double y = LineCurve.Points[i].Y + offSetY;
                curve1.AddPoint(new PointPair(x, y));
            }
            int offSetX2 = (int)Math.Round(0.8 * curve1.Points[0].X);

            for (int i = 0; i < curve1.Points.Count; i++)
            {
                curve2.AddPoint(new PointPair(curve1.Points[i].X - offSetX2, curve1.Points[i].Y));
            }
            curve1.Tag = 5;
            curve2.Tag = 5;
        }
        public static void zeroTwoSigma1(LineItem originalCurve, PointPair p2, LineItem LineCurve, LineItem curved2, MainProgram form)
        {
            LineItem curve1 = null;
            LineItem curve2 = null;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve1, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 2", Color.DarkCyan, 4, SymbolType.Default, Color.DarkCyan));
            curve1 = LineCurve;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve2, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 2", Color.DarkCyan, 4, SymbolType.Default, Color.DarkCyan));
            int max = 0;
            for (int i = 0; i < originalCurve.Points.Count; i++) if (originalCurve.Points[i].X > max) max = (int)originalCurve.Points[i].X;
            double average = 0;
            for (int i = 0; i < curved2.Points.Count - 10; i++) average += Math.Abs(curved2[i].Y);
            average /= curved2.Points.Count - 10;
            int index = 0;
            for (index = 0; index < curved2.Points.Count; index++) { if (curved2[index].Y > 10.0 * average) break; }
            double offSetY = originalCurve[index].Y - p2.Y;
            double offSetX = originalCurve[index].X - p2.X;
            for (int i = 0; i < LineCurve.Points.Count-1; i++)
            {
                curve1.AddPoint(new PointPair(LineCurve.Points[i].X + offSetX, LineCurve.Points[i].Y += offSetY));
            }
            int offSetX2 = (int)Math.Round(0.98 * originalCurve.Points[index].X);

            for (int i = 0; i<curve1.Points.Count; i++)
            {
                curve2.AddPoint(new PointPair(curve1.Points[i].X + offSetX2, curve1.Points[i].Y));
            }

        }
            public static void zeroTwoSigma(LineItem originalCurve, PointPair p2, LineItem LineCurve, LineItem curved2, MainProgram form)
        {

            int max = 0;
            for (int i = 0; i < originalCurve.Points.Count; i++) if (originalCurve.Points[i].X > max) max = (int)originalCurve.Points[i].X;




            double average = 0;
            for (int i = 0; i < curved2.Points.Count - 10; i++) average += Math.Abs(curved2[i].Y);
            average /= curved2.Points.Count - 10;
            int index = 0;
            for (index = 0; index < curved2.Points.Count; index++) { if (curved2[index].Y > 10.0 * average) break; }
            double[] xData = GraphProcessing.CurveToArray(LineCurve, true);
            double[] yData = GraphProcessing.CurveToArray(LineCurve, false);
            double offSetY = originalCurve[index].Y - p2.Y;
            double offSetX = originalCurve[index].X - p2.X;

            for (int i = 0; i < xData.Length; i++)
            {
                xData[i] += offSetX;
                yData[i] += offSetY;
            }

            var ds = new XYDataSet(xData, yData);
            double k = ds.Slope;
            double b = ds.YIntercept;
            LineItem curve = null;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль", Color.DarkCyan, 4, SymbolType.Default, Color.DarkCyan));
           
            for (int i = 0; i < max; i++)
                if ((k * i + b) > 0)
                    curve.AddPoint(new PointPair(i, k * i + b));
            
            int offSetX2 = (int)Math.Round(0.8 * curve.Points[0].X);

            LineItem curve2;
            curve2 = curve;
            form.buttons.Add(GraphProcessing.CreateCurve(ref curve2, form.CurvesDropDownButton, form.ZGCInstance, "Паралелль 2", Color.DarkCyan, 4, SymbolType.Default, Color.DarkCyan));
            for (int i = 0; i < xData.Length; i++)
            {
                xData[i] -= offSetX2;
            }
            var ds1 = new XYDataSet(xData, yData);
            double k1 = ds1.Slope;
            double b1 = ds1.YIntercept;
            for (int i = 0; i < max/2; i++)
                if ( (k1 * i + b1) > 0)
                curve2.AddPoint(new PointPair(i, k1 * i + b1));

            curve.Tag = 5;
            curve2.Tag = 5;
        }

        public static void paralellLine ( double offSetX, double offSetY, ref LineItem curve)
        {
            
            for (int i = 0; i < curve.Points.Count-1; i++)
            {
                if (curve.Points[i].Y >= 0)
                {
                    curve.Points[i].Y += offSetY;
                    curve.Points[i].X += offSetX;
                }
            }
        }
        /// <summary>
        /// Build a curve using the least squares method
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="xData"></param>
        /// <param name="yData"></param>
        /// <param name="curve"></param>
        /// <param name="form"></param>
        public static void leastSquaresBuild (int begin, int end, LineItem allPointsForBuilding, ref LineItem curve, MainProgram form)
        {
            double[] xData = GraphProcessing.CurveToArray(allPointsForBuilding, true);
            double[] yData = GraphProcessing.CurveToArray(allPointsForBuilding, false);
            var ds = new XYDataSet(xData, yData);
            double k = ds.Slope;
            double b = ds.YIntercept;
            curve.Tag = 2;
            for (int i = begin; i < end; i++)
               curve.AddPoint(new PointPair(i, k * i + b));
        }
        public static void leastSquaresBuild(ref LineItem curve, double k, double b, int end)
        {
            for (int i = 0; i < end; i++)
                if (k*i+b > 0) curve.AddPoint(new PointPair(i, k * i + b));

        }
            public static LineItem BuildLine(PointPair p1, PointPair p2, ref LineItem result)
        {

            double x1 = p1.X;
            double x2 = p2.X;
            double y1 = p1.Y;
            double y2 = p2.Y;
            // y= y1+(x-x1) (y2 - y1) / (x2-x1) ; y = k*(x-x1) + y1 = kx - (kx1 + y1)
            // ((y-y1) / k) + x1 = x
            double coef = (y2 - y1) / (x2 - x1);

            int index = (int) Math.Max(x2, x1);
            double resultTemp = 1;
            while (index > 0 && resultTemp >= 0)
            {
                resultTemp = coef * (index - x1) + y1;
                result.AddPoint(new PointPair(index, resultTemp));
                index--;
            }
            resultTemp = x1 + (-y1 / coef);
            result.AddPoint(new PointPair(resultTemp, 0));
            return result;
          
        }
        public static LineItem BuildLine2(PointPair p1, PointPair p2, ref LineItem result, double max)
        {

            double x1 = p1.X;
            double x2 = p2.X;
            double y1 = p1.Y;
            double y2 = p2.Y;
            // y= y1+(x-x1) (y2 - y1) / (x2-x1) ; y = k*(x-x1) + y1 = kx - (kx1 + y1)
            // ((y-y1) / k) + x1 = x
            double coef = (y2 - y1) / (x2 - x1);

            int index = 0;
            double resultTemp = 1;
            while (index < 1000 && resultTemp <= max)
            {
                resultTemp = coef * (index - x1) + y1;
                result.AddPoint(new PointPair(index, resultTemp));
                index++;
            }
            return result;

        }

        public static void buildLine(LineItem d2, ref LineItem curve, MainProgram form)
        {
            PointPair p2 = curve[curve.Points.Count-1];
            double average = 0;
           
            int index = 0;
            for (index = 0; index < d2.Points.Count; index++) { if (d2[index].Y > 10.0 * average) break; }
            double offsetY = curve[index].Y - p2.Y;
            double offsetX = curve[index].X - p2.X;
            for (int i = 0; i < curve.Points.Count; i++)
            {
                curve.Points[i].Y += offsetY;
                curve.Points[i].X += offsetX;
            }
        }

        public static void   OffSetTheLine2(PointPair p1down, PointPair p2top, PointPair p3down, LineItem d2, LineItem curve, MainProgram form)
        {
            double offsetY = p3down.Y - p1down.Y;
            double offsetX = p1down.X - p3down.X;

            double max = Double.MinValue;
            for (int i = 0; i < curve.Points.Count - 1; i++) if (curve.Points[i].Y > max) max = curve.Points[i].Y;

            LineItem parallelLine = null;

            form.buttons.Add(GraphProcessing.CreateCurve(ref parallelLine, form.CurvesDropDownButton, form.ZGCInstance, "паралелька 2", Color.Blue, 6, SymbolType.Circle, Color.Blue));
            BuildLine2(new PointPair(p3down.X, p3down.Y), new PointPair(p2top.X-offsetX, p2top.Y), ref parallelLine, max);
            GraphProcessing.UpdateGraph(form.ZGCInstance);

        }
        public static int OffSetTheLine1(PointPair p1, PointPair p2, LineItem d2, LineItem curve, MainProgram form)
        {
            double average = 0;
            for (int i = 0; i < d2.Points.Count-10; i++) average += Math.Abs(d2[i].Y);
            average = 1 * average;
            average /= d2.Points.Count-11;
            int index = 0;
            for (index = 0; index < d2.Points.Count; index++) { if (d2[index].Y > 10.0 * average) break; }
            double offsetY = curve[index].Y - p2.Y;
            double offsetX = curve[index].X - p2.X;

            p1.X += (float) offsetX;
            p1.Y += (float) offsetY;
            LineItem parallelLine = null;
           
            form.buttons.Add(GraphProcessing.CreateCurve(ref parallelLine, form.CurvesDropDownButton, form.ZGCInstance, "паралелька", Color.Blue, 6, SymbolType.Circle, Color.Blue));
            BuildLine(new PointPair(curve[index].X, curve[index].Y), new PointPair(p1.X, p1.Y), ref parallelLine);
            GraphProcessing.UpdateGraph(form.ZGCInstance);

            OffSetTheLine2(new PointPair(parallelLine[parallelLine.Points.Count - 2].X, parallelLine[parallelLine.Points.Count - 2].Y), new PointPair(parallelLine[0].X, parallelLine[0].Y), new PointPair((int)Math.Round(0.2* parallelLine[parallelLine.Points.Count-1].X - curve[0].X), 0), d2, curve, form);
            return 0;
        }
        public static int OffSetTheLine11(PointPair p1, PointPair p2, LineItem d2, LineItem curve, MainProgram form)
        {
            double average = 0;
            for (int i = 0; i < d2.Points.Count - 10; i++) average += Math.Abs(d2[i].Y);
            average = 1 * average;
            average /= d2.Points.Count - 11;
            int index = 0;
            for (index = 0; index < d2.Points.Count; index++) { if (d2[index].Y > 10.0 * average) break; }
            double offsetY = curve[index].Y - p2.Y;
            double offsetX = curve[index].X - p2.X;

            p1.X += (float)offsetX;
            p1.Y += (float)offsetY;
            LineItem parallelLine = null;

            form.buttons.Add(GraphProcessing.CreateCurve(ref parallelLine, form.CurvesDropDownButton, form.ZGCInstance, "паралелька", Color.Blue, 6, SymbolType.Circle, Color.Blue));
            BuildLine(new PointPair(curve[index].X, curve[index].Y), new PointPair(p1.X, p1.Y), ref parallelLine);
            GraphProcessing.UpdateGraph(form.ZGCInstance);
            OffSetTheLine2(new PointPair(parallelLine[parallelLine.Points.Count - 2].X, parallelLine[parallelLine.Points.Count - 2].Y), new PointPair(parallelLine[0].X, parallelLine[0].Y), new PointPair((int)Math.Round(0.2 * parallelLine[parallelLine.Points.Count - 1].X - curve[0].X), 0), d2, curve, form);
            return 0;
        }

    }
}
