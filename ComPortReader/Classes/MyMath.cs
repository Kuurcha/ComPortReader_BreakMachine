using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZedGraph;
namespace ComPortReader.Classes
{
    static class  MyMath
    {
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

    }
}
