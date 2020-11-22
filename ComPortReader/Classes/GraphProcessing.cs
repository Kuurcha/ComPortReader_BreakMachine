using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using ComPortReader.Classes;
using System.Xml.Schema;
using System.IO.Ports;
namespace ComPortReader
{
    class GraphProcessing
    {
       
       /// <summary>
       /// Addss a point to a LineItem curve with coordinates x and y, used for the delegate.
       /// </summary>
       /// <param name="curve">Curve to add point to</param>
       /// <param name="x">x point coordinate</param>
       /// <param name="y">y point coordinate</param>
        static internal void AddInRealTime(LineItem curve, double x, double y)
        {
            if (curve !=null) curve.AddPoint(x, y);
        }
        /// <summary>
        /// Updates ZedGraphControl
        /// </summary>
        /// <param name="zgc">ZedGraphControl to update</param>
        static internal void UpdateGraph(ZedGraphControl zgc)
        {
            zgc.Refresh();
            zgc.Invalidate();
            zgc.AxisChange();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        static internal double[] CurveToArray(LineItem curve, bool isXAxis)
        {
            int length = curve.Points.Count;
            int a = ((isXAxis) ? 1 : 2);
            double[] array = new double[length];
            for (int i = 0; i < length - 2; i++) { array[i] = (isXAxis ?  curve.Points[i].X : array[i] = curve.Points[i].Y); }
            return array;
        }
      

        /// <summary>
        /// Algorythm for the jumps in graph to be less sudden. Moving average or something. Arithmetic sum of `period` previous numbers.
        /// </summary>
        /// <param name="data">Initial array of data</param>
        /// <param name="period">length for averaging</param>
        /// <returns>Moving averaged array</returns>
        static internal double[] MovingAverage(double[] data, int period)
        {
            double[] buffer = new double[period];
            double[] output = new double[data.Length];
            int current_index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                buffer[current_index] = data[i] / period;
                double ma = 0.0;
                for (int j = 0; j < period; j++)
                {
                    ma += buffer[j];
                }
                output[i] = ma;
                current_index = (current_index + 1) % period;
            }
            return output;
        }

        /// <summary>
        /// Graph used for testing
        /// </summary>
        // static internal void drawTestGraph( MainProgram form)
        // {
        //    form.getTestCurve = null;
        //    LineItem curve = form.getTestCurve;
        //    GraphPane pane = form.GraphPaneInstance;
        //    form.buttons.Add(GraphProcessing.CreateCurve(ref curve, ref pane, form.CurvesButtons, form.ZGCInstance, "Тестовый график", Color.Red, 4, SymbolType.Circle, Color.Red));

        //    form.СreateTimer();
        //        Point[] points = { new Point(1, 8), new Point(2, 8), new Point(3, 8), new Point(4, 8), new Point(5, 9), new Point(6, 9), new Point(7, 8), new Point(8, 9), new Point(9, 9), new Point(10, 10), new Point(11, 10), new Point(12, 12), new Point(13, 13), new Point(14, 16), new Point(15, 19), new Point(16, 21), new Point(17, 23), new Point(18, 27), new Point(19, 30), new Point(20, 33), new Point(21, 36), new Point(22, 38), new Point(23, 43), new Point(24, 47), new Point(25, 51), new Point(26, 55), new Point(27, 62), new Point(28, 66), new Point(29, 72), new Point(30, 78), new Point(31, 83), new Point(32, 90), new Point(33, 96), new Point(34, 101), new Point(35, 107), new Point(36, 114), new Point(37, 120), new Point(38, 125), new Point(39, 132), new Point(40, 137), new Point(41, 143), new Point(42, 148), new Point(43, 155), new Point(44, 159), new Point(45, 166), new Point(46, 172), new Point(47, 178), new Point(48, 184), new Point(49, 190), new Point(50, 196), new Point(51, 203), new Point(52, 209), new Point(53, 217), new Point(54, 222), new Point(55, 229), new Point(56, 236), new Point(57, 243), new Point(58, 250), new Point(59, 258), new Point(60, 264), new Point(61, 271), new Point(62, 278), new Point(63, 287), new Point(64, 295), new Point(65, 302), new Point(66, 309), new Point(67, 318), new Point(68, 325), new Point(69, 334), new Point(70, 342), new Point(71, 351), new Point(72, 358), new Point(73, 367), new Point(74, 376), new Point(75, 384), new Point(76, 392), new Point(77, 402), new Point(78, 411), new Point(79, 420), new Point(80, 429), new Point(81, 439), new Point(82, 447), new Point(83, 457), new Point(84, 466), new Point(85, 476), new Point(86, 485), new Point(87, 494), new Point(88, 503), new Point(89, 512), new Point(90, 520), new Point(91, 528), new Point(92, 535), new Point(93, 542), new Point(94, 548), new Point(95, 553), new Point(96, 557), new Point(97, 557), new Point(98, 555), new Point(99, 557), new Point(100, 560), new Point(101, 561), new Point(102, 560), new Point(103, 560), new Point(104, 560), new Point(105, 558), new Point(106, 561), new Point(107, 563), new Point(108, 564), new Point(109, 566), new Point(110, 564), new Point(111, 563), new Point(112, 564), new Point(113, 563), new Point(114, 564), new Point(115, 565), new Point(116, 564), new Point(117, 563), new Point(118, 563), new Point(119, 564), new Point(120, 564), new Point(121, 562), new Point(122, 562), new Point(123, 562), new Point(124, 563), new Point(125, 562), new Point(126, 563), new Point(127, 563), new Point(128, 564), new Point(129, 562), new Point(130, 560), new Point(131, 562), new Point(132, 561), new Point(133, 560), new Point(134, 560), new Point(135, 564), new Point(136, 564), new Point(137, 563), new Point(138, 562), new Point(139, 562), new Point(140, 562), new Point(141, 558), new Point(142, 554), new Point(143, 566), new Point(144, 571), new Point(145, 575), new Point(146, 576), new Point(147, 578), new Point(148, 579), new Point(149, 581), new Point(150, 583), new Point(151, 583), new Point(152, 585), new Point(153, 587), new Point(154, 588), new Point(155, 590), new Point(156, 591), new Point(157, 592), new Point(158, 593), new Point(159, 595), new Point(160, 596), new Point(161, 597), new Point(162, 598), new Point(163, 600), new Point(164, 601), new Point(165, 602), new Point(166, 604), new Point(167, 605), new Point(168, 605), new Point(169, 607), new Point(170, 608), new Point(171, 608), new Point(172, 609), new Point(173, 611), new Point(174, 612), new Point(175, 613), new Point(176, 615), new Point(177, 616), new Point(178, 617), new Point(179, 618), new Point(180, 619), new Point(181, 620), new Point(182, 621), new Point(183, 621), new Point(184, 622), new Point(185, 624), new Point(186, 625), new Point(187, 626), new Point(188, 627), new Point(189, 628), new Point(190, 628), new Point(191, 629), new Point(192, 630), new Point(193, 631), new Point(194, 632), new Point(195, 633), new Point(196, 633), new Point(197, 634), new Point(198, 636), new Point(199, 637), new Point(200, 637), new Point(201, 638), new Point(202, 639), new Point(203, 640), new Point(204, 640), new Point(205, 642), new Point(206, 642), new Point(207, 643), new Point(208, 644), new Point(209, 644), new Point(210, 645), new Point(211, 646), new Point(212, 647), new Point(213, 647), new Point(214, 648), new Point(215, 648), new Point(216, 649), new Point(217, 650), new Point(218, 651), new Point(219, 652), new Point(220, 652), new Point(221, 653), new Point(222, 653), new Point(223, 654), new Point(224, 654), new Point(225, 655), new Point(226, 655), new Point(227, 656), new Point(228, 657), new Point(229, 658), new Point(230, 658), new Point(231, 659), new Point(232, 659), new Point(233, 660), new Point(234, 661), new Point(235, 661), new Point(236, 661), new Point(237, 662), new Point(238, 662), new Point(239, 664), new Point(240, 664), new Point(241, 664), new Point(242, 664), new Point(243, 665), new Point(244, 666), new Point(245, 666), new Point(246, 666), new Point(247, 667), new Point(248, 668), new Point(249, 668), new Point(250, 668), new Point(251, 669), new Point(252, 669), new Point(253, 670), new Point(254, 670), new Point(255, 670), new Point(256, 671), new Point(257, 671), new Point(258, 671), new Point(259, 672), new Point(260, 672), new Point(261, 673), new Point(262, 673), new Point(263, 674), new Point(264, 673), new Point(265, 674), new Point(266, 675), new Point(267, 675), new Point(268, 675), new Point(269, 676), new Point(270, 676), new Point(271, 677), new Point(272, 677), new Point(273, 677), new Point(274, 678), new Point(275, 678), new Point(276, 679), new Point(277, 680), new Point(278, 679), new Point(279, 680), new Point(280, 680), new Point(281, 680), new Point(282, 680), new Point(283, 681), new Point(284, 681), new Point(285, 682), new Point(286, 682), new Point(287, 682), new Point(288, 682), new Point(289, 683), new Point(290, 684), new Point(291, 683), new Point(292, 683), new Point(293, 684), new Point(294, 684), new Point(295, 685), new Point(296, 685), new Point(297, 685), new Point(298, 686), new Point(299, 685), new Point(300, 686), new Point(301, 686), new Point(302, 687), new Point(303, 687), new Point(304, 687), new Point(305, 688), new Point(306, 688), new Point(307, 688), new Point(308, 688), new Point(309, 689), new Point(310, 688), new Point(311, 689), new Point(312, 690), new Point(313, 690), new Point(314, 690), new Point(315, 690), new Point(316, 690), new Point(317, 690), new Point(318, 690), new Point(319, 691), new Point(320, 691), new Point(321, 691), new Point(322, 692), new Point(323, 691), new Point(324, 692), new Point(325, 692), new Point(326, 692), new Point(327, 692), new Point(328, 692), new Point(329, 693), new Point(330, 692), new Point(331, 693), new Point(332, 693), new Point(333, 694), new Point(334, 694), new Point(335, 694), new Point(336, 694), new Point(337, 694), new Point(338, 694), new Point(339, 694), new Point(340, 695), new Point(341, 695), new Point(342, 695), new Point(343, 695), new Point(344, 696), new Point(345, 695), new Point(346, 695), new Point(347, 696), new Point(348, 696), new Point(349, 697), new Point(350, 696), new Point(351, 697), new Point(352, 696), new Point(353, 697), new Point(354, 697), new Point(355, 697), new Point(356, 697), new Point(357, 697), new Point(358, 697), new Point(359, 697), new Point(360, 697), new Point(361, 697), new Point(362, 697), new Point(363, 698), new Point(364, 698), new Point(365, 697), new Point(366, 698), new Point(367, 699), new Point(368, 698), new Point(369, 699), new Point(370, 698), new Point(371, 698), new Point(372, 698), new Point(373, 698), new Point(374, 699), new Point(375, 699), new Point(376, 699), new Point(377, 699), new Point(378, 699), new Point(379, 700), new Point(380, 699), new Point(381, 700), new Point(382, 699), new Point(383, 700), new Point(384, 700), new Point(385, 699), new Point(386, 699), new Point(387, 700), new Point(388, 700), new Point(389, 701), new Point(390, 700), new Point(391, 700), new Point(392, 700), new Point(393, 700), new Point(394, 701), new Point(395, 701), new Point(396, 700), new Point(397, 701), new Point(398, 701), new Point(399, 701), new Point(400, 702), new Point(401, 701), new Point(402, 701), new Point(403, 702), new Point(404, 702), new Point(405, 702), new Point(406, 701), new Point(407, 701), new Point(408, 702), new Point(409, 701), new Point(410, 702), new Point(411, 702), new Point(412, 701), new Point(413, 702), new Point(414, 701), new Point(415, 702), new Point(416, 702), new Point(417, 702), new Point(418, 702), new Point(419, 702), new Point(420, 702), new Point(421, 702), new Point(422, 702), new Point(423, 702), new Point(424, 703), new Point(425, 703), new Point(426, 703), new Point(427, 703), new Point(428, 703), new Point(429, 703), new Point(430, 703), new Point(431, 703), new Point(432, 703), new Point(433, 703), new Point(434, 704), new Point(435, 704), new Point(436, 704), new Point(437, 704), new Point(438, 704), new Point(439, 703), new Point(440, 704), new Point(441, 703), new Point(442, 703), new Point(443, 703), new Point(444, 704), new Point(445, 704), new Point(446, 704), new Point(447, 704), new Point(448, 703), new Point(449, 704), new Point(450, 703), new Point(451, 703), new Point(452, 704), new Point(453, 703), new Point(454, 703), new Point(455, 704), new Point(456, 703), new Point(457, 704), new Point(458, 704), new Point(459, 704), new Point(460, 704), new Point(461, 704), new Point(462, 705), new Point(463, 704), new Point(464, 704), new Point(465, 704), new Point(466, 704), new Point(467, 704), new Point(468, 703), new Point(469, 704), new Point(470, 704), new Point(471, 705), new Point(472, 704), new Point(473, 704), new Point(474, 705), new Point(475, 705), new Point(476, 704), new Point(477, 704), new Point(478, 704), new Point(479, 704), new Point(480, 704), new Point(481, 705), new Point(482, 704), new Point(483, 703), new Point(484, 704), new Point(485, 705), new Point(486, 703), new Point(487, 704), new Point(488, 704), new Point(489, 704), new Point(490, 704), new Point(491, 703), new Point(492, 704), new Point(493, 704), new Point(494, 704), new Point(495, 704), new Point(496, 703), new Point(497, 703), new Point(498, 704), new Point(499, 704), new Point(500, 704), new Point(501, 703), new Point(502, 704), new Point(503, 704), new Point(504, 703), new Point(505, 703), new Point(506, 703), new Point(507, 703), new Point(508, 704), new Point(509, 703), new Point(510, 703), new Point(511, 703), new Point(512, 703), new Point(513, 703), new Point(514, 703), new Point(515, 703), new Point(516, 702), new Point(517, 703), new Point(518, 703), new Point(519, 703), new Point(520, 703), new Point(521, 703), new Point(522, 701), new Point(523, 702), new Point(524, 703), new Point(525, 702), new Point(526, 703), new Point(527, 702), new Point(528, 702), new Point(529, 703), new Point(530, 702), new Point(531, 701), new Point(532, 702), new Point(533, 701), new Point(534, 701), new Point(535, 702), new Point(536, 700), new Point(537, 701), new Point(538, 701) };
        //        for (int i = 0; i < points.Length; i++)
        //        {
        //            form.CounterTimer = 0;
        //            form.AtLeastOnePointPassed = true;
        //            curve.AddPoint((double)points[i].X * form.Coefficent, (double)points[i].Y * form.Coefficent);
        //            UpdateGraph(form.ZGCInstance);
        //        }
        //        Bitmap imageOfGraph = form.GraphPaneInstance.GetImage();
        //        form.getTestCurve = curve;
                   
        //}


        static internal DynamicToolStripButton CreateCurve(ref LineItem curve, ToolStripDropDownButton dropdownBtn, ZedGraphControl zgc, string name, Color color, float size, SymbolType symbolType, Color fillColor)
        {
            PointPairList list = new PointPairList();
            curve = new LineItem(name);
            curve = zgc.GraphPane.AddCurve(name, list, color);
            curve.Symbol.Size = size;
            curve.Symbol.Type = symbolType;
            curve.Symbol.Fill = new Fill(fillColor);
            curve.Label.FontSpec = new FontSpec("Arial", 8, Color.Black, false, false, false);

           
            DynamicToolStripButton btn = new DynamicToolStripButton(curve, zgc, dropdownBtn);
            dropdownBtn.DropDownItems.Add(btn.button);
            return btn;
    }

        /// <summary>
        /// Стартовые настройки графика, имя
        /// </summary>
        /// <param name="zgc"></param>
        internal static void CreateGraph(ZedGraphControl zgc, string name, string xName, string yName, double stepX, double stepY)
        {  
            
            zgc.GraphPane.Title.Text = name;
            zgc.GraphPane.XAxis.Title.Text = xName;
            zgc.GraphPane.YAxis.Title.Text = yName;
            zgc.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zgc.GraphPane.XAxis.MajorGrid.DashOff = 0;
            zgc.GraphPane.XAxis.Scale.MajorStep = stepX;
            zgc.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zgc.GraphPane.YAxis.MajorGrid.DashOff = 0;
            zgc.GraphPane.YAxis.Scale.MajorStep = stepY;
            UpdateGraph(zgc);    
        }
        private static LinkedList<double> NormalizeData(LinkedList<double>data)
        {
            double max = 1;
            LinkedListNode<double> temp = data.First;
            while(temp != null)
            {
                if (temp.Value > max) max = temp.Value;
                temp = temp.Next;
            }
            temp = data.First;
            while (temp != null)
            {
                temp.Value /= max;
                temp = temp.Next;
            }
            return data;
        }
        internal static double computePirson(LinkedList<double> xCoord, LinkedList<double> yCoord)
        {
            double averageX = xCoord.Average();
            double averageY = yCoord.Average();
            int length = xCoord.Count();
            double top = 0;
            int counter = 0;
            xCoord = NormalizeData(xCoord);
            yCoord = NormalizeData(yCoord);
            LinkedListNode<double> tempX = xCoord.First;
            LinkedListNode<double> tempY= yCoord.First;
            while (counter < xCoord.Count)
            {
                top += (tempX.Value - averageX) * (tempY.Value - averageY);
                tempX = tempX.Next;
                tempY = tempY.Next;
                counter++;
            }
            double bottomX = 0;
            tempX = xCoord.First;
            counter = 0;
            while (counter < xCoord.Count)
            {
                bottomX += (tempX.Value - averageX) * (tempX.Value - averageX);
                tempX = tempX.Next;
                counter++;
            }
            double bottomY = 0;
            tempY = yCoord.First;
            counter = 0;
            while (counter < yCoord.Count)
            {   
                bottomY += (tempY.Value - averageY) * (tempY.Value - averageY);
                tempY = tempY.Next;
                counter++;
            }
            double bottom = Math.Sqrt(bottomX * bottomY);
            return top / bottom;
        }
        public static IEnumerable<double> GetEnum(LinkedList<double> list)
        {
            return list;
        }
        private static double Correlation(IEnumerable<Double> xs, IEnumerable<Double> ys)
        {
            // sums of x, y, x squared etc.
            double sx = 0.0;
            double sy = 0.0;
            double sxx = 0.0;
            double syy = 0.0;
            double sxy = 0.0;

            int n = 0;

            using (var enX = xs.GetEnumerator())
            {
                using (var enY = ys.GetEnumerator())
                {
                    while (enX.MoveNext() && enY.MoveNext())
                    {
                        double x = enX.Current;
                        double y = enY.Current;

                        n += 1;
                        sx += x;
                        sy += y;
                        sxx += x * x;
                        syy += y * y;
                        sxy += x * y;
                    }
                }
            }

            // covariation
            double cov = sxy / n - sx * sy / n / n;
            // standard error of x
            double sigmaX = Math.Sqrt(sxx / n - sx * sx / n / n);
            // standard error of y
            double sigmaY = Math.Sqrt(syy / n - sy * sy / n / n);

            // correlation is just a normalized covariation
            return cov / sigmaX / sigmaY;
        }
        
        internal static double Derivative(double prev, double next)
        {
            return (next - prev) / 2;
        }

        public static void resetGraph(MainProgram mainForm)
        {
            PointPairList list = new PointPairList();

            mainForm.MinXValue = 0;
            mainForm.MinYValue = 0;
            mainForm.MaxXValue = 100;
            mainForm.MaxYValue = 100;
            mainForm.ZGCInstance.GraphPane.CurveList.Clear();
            mainForm.ZGCInstance.AxisChange();
            mainForm.ZGCInstance.Invalidate();
            mainForm.ZGCInstance.GraphPane.CurveList.Clear();
            mainForm.buttons.Clear();
            mainForm.getCurve = null;
            mainForm.CurvesButtons.DropDownItems.Clear();
            if (mainForm.everySecond!=null) mainForm.everySecond.Elapsed += new System.Timers.ElapsedEventHandler(mainForm.timer_tick);
            mainForm.everySecond = null;
            mainForm.AtLeastOnePointPassed = false;
            mainForm.counterTimer = 0;
            mainForm.SelectionCurveBegin = null;
            mainForm.SelectionCurveEnd = null;

            // Установим масштаб по умолчанию для оси X
            mainForm.ZGCInstance.GraphPane.XAxis.Scale.MinAuto = true;
            mainForm.ZGCInstance.GraphPane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            mainForm.ZGCInstance.GraphPane.YAxis.Scale.MinAuto = true;
            mainForm.ZGCInstance.GraphPane.YAxis.Scale.MaxAuto = true;
                mainForm.Port.Close();
                mainForm.Port.DataReceived -= new SerialDataReceivedEventHandler(mainForm.port_DataReceived);
                mainForm.openComPort();
                mainForm.Port.DataReceived += new SerialDataReceivedEventHandler(mainForm.port_DataReceived);
                mainForm.Port.Open();
       
        }
        internal static int[] CalculatePointsForLinear(LineItem originalCurve, LineItem secondDerivativeCurve, LineItem firstMovingAverageCurve)
        {
            // bound[0] - startPoint
            // bound[1] - endPoint
            int startPoint = 0;
            while (originalCurve.Points[startPoint].Y < 25 && startPoint < originalCurve.Points.Count - 1) startPoint++;
            double average = 0;
            for (int i = startPoint; i < secondDerivativeCurve.Points.Count-10; i++) average += Math.Abs(secondDerivativeCurve.Points[i].Y);
            average /= secondDerivativeCurve.Points.Count - 10;
            int counterFlag = 0;
            bool flag = true;
            while( startPoint < secondDerivativeCurve.Points.Count -1 && flag)
            {
                double temp = Math.Abs(secondDerivativeCurve.Points[startPoint].Y);
                if (temp < average/1.2) counterFlag++;
                else counterFlag = 0;
                if (counterFlag == 5) flag = false;

                startPoint++;
            }
            double max = Double.MinValue;
            int endPoint = startPoint;
            for (int i = 0; i < firstMovingAverageCurve.Points.Count-1; i++)
            {
                double currentValue = firstMovingAverageCurve.Points[i].Y;
                if (currentValue > max)
                {
                    max = currentValue;
                    endPoint = i;
                }
            }
            bool negativeMet = false;
            int zeroCounter = 0;
            int positiveCounter = 0;
            while (positiveCounter < 3 && !(positiveCounter > 0 && zeroCounter > 3) && endPoint < secondDerivativeCurve.Points.Count-1)
            {
                double currentValue = secondDerivativeCurve.Points[endPoint].Y;
                if (currentValue < 0)
                {
                    negativeMet = true;
                    endPoint++;
                    zeroCounter = 0;
                    positiveCounter = 0;
                }
                else
                {
                    if (negativeMet && currentValue > 0)
                    {
                        positiveCounter++;
                        
                    }
                    else
                    {
                        zeroCounter++;
                    }
                }
                endPoint++;              
            }
            endPoint -= 2;
            int[] bound = { startPoint, endPoint };
            return bound;
        }
        /// <summary>
        /// Первая попытка в алгоритм для нахождения конкретной точки. Работает описательно используя две производные.
        /// </summary>
        /// <param name="originalCurve"></param>
        /// <param name="firstDerivativeCurve"></param>
        /// <param name="secondDerivativeCurve"></param>
        /// <returns></returns>
        internal static int[] CountPoints(LineItem originalCurve, LineItem firstDerivativeCurve, LineItem secondDerivativeCurve)
        {
            int[] bounds = new int[2];
            int startingPoint = 0;
            int endPoint = 0;
            int lengthOriginal = originalCurve.Points.Count-1;
            while (originalCurve.Points[startingPoint].Y < 20 && startingPoint < lengthOriginal) startingPoint++;

            int secondDerivativeCounter = 0;
            int lengthSecond = firstDerivativeCurve.Points.Count-1;
            while (secondDerivativeCounter < 7 && startingPoint < lengthSecond)
            {
                if (Math.Abs(secondDerivativeCurve.Points[startingPoint].Y) <= 0.5) secondDerivativeCounter++;
                startingPoint++;
            }

            secondDerivativeCounter = 0;
            bool negationStarted = false;
            bool previousIsPositive = false;
            endPoint = startingPoint;
            int lengthFirst = secondDerivativeCurve.Points.Count - 1;
            double sumOfNegative = 0;
            while ((secondDerivativeCounter < 4 && (Math.Abs(sumOfNegative) < 2.5)) &&  endPoint < lengthFirst)
            {
                double pointToCheck = secondDerivativeCurve.Points[endPoint].Y;
                if (pointToCheck > 0)
                {
                    if(secondDerivativeCounter > 2)
                    {
                        if (!negationStarted) { secondDerivativeCounter = 0; sumOfNegative = 0; }
                    }
                    else
                    {
                        secondDerivativeCounter = 0; sumOfNegative = 0;
                    }
                     
                    negationStarted = false;
                    previousIsPositive = true;
                }

                else
                {  
                    
                    if (secondDerivativeCurve.Points[endPoint].Y < 0)
                    {
                        previousIsPositive = false;
                        secondDerivativeCounter++;
                        negationStarted = true;
                        sumOfNegative += pointToCheck;
                    }
                    else 
                    if (previousIsPositive) 
                    { negationStarted = false; secondDerivativeCounter = 0;  }
                }
                endPoint++;
            }
            endPoint = (int) (secondDerivativeCurve.Points[endPoint].X);
            bounds[0] = startingPoint;
            bounds[1] = endPoint;
            return bounds;
        }
        static int mistakes = 0;
        internal static void DerivativeGraph(LineItem curve, ref LineItem printCurve)
        {
            int length = curve.Points.Count;
           
            for (int i = 1; i < length - 2; i++)
            {
                
                double bottom = 2*(curve.Points[i + 1].X - curve.Points[i].X);
                double top = (curve.Points[i + 1].Y - curve.Points[i-1].Y);
                printCurve.AddPoint(curve.Points[i + 1].X, top/bottom);

            }
        }
        internal static void SecondDerivativeGraph(LineItem curve, ref LineItem printCurve)
        {
            int length = curve.Points.Count;
            for (int i = 1; i < length - 2; i++) printCurve.AddPoint(curve.Points[i+1].X, (curve.Points[i + 1].Y -  curve.Points[i].Y)/ (curve.Points[i + 1].X - curve.Points[i].X));
        }
        internal static double DerivativeLinearity(LineItem curve, ref int startPoint, ref int endPoint)
        {
            double derivative = 0;

            while (0.5 < derivative && derivative > 1.5)
            {
                derivative = Derivative(curve.Points[startPoint + 1].Y, curve.Points[startPoint - 1].Y);
                startPoint++;
            }
            endPoint = startPoint;
            while (mistakes < 2 && endPoint < curve.Points.Count - 2)
            {
                derivative = Derivative(curve.Points[endPoint + 1].Y, curve.Points[endPoint - 1].Y);
                if (derivative > 4) mistakes++;
                else mistakes = 0;
                endPoint++;
            }
            mistakes = 0;
            return derivative;
        }

        internal static double PirsonCorrelation(LineItem curve, ref int startPoint, ref int endPoint)
        {
            //plan
            //
            // The array of at least fifty points should be moving number of times how much points there is - lentgh of a 50. 
            //If correlation is good enough it lower bound stops moving, only the top bound until correlation will be more
            //than a specific value
            int length = 100;
            startPoint = 0;
            endPoint = length;
            double pirson = -2;
            double derivative = 0;
            LinkedList<double> xCoord= new LinkedList<double>();
            LinkedList<double> yCoord = new LinkedList<double>();
            while (curve.Points[startPoint].Y < 15 && endPoint < curve.Points.Count)
            {
                startPoint++;
                endPoint++;
            }
            while ((pirson < 0.985 ) && endPoint < curve.Points.Count)
            {
                LinkedList<double> xCoordTemp = new LinkedList<double>();
                LinkedList<double> yCoordTemp =  new LinkedList<double>();
               
                derivative = Derivative(curve.Points[startPoint-1].Y, curve.Points[startPoint+1].Y);
                for (int i = startPoint; i < endPoint; i++)
                {
                    xCoordTemp.AddLast(curve.Points[i].X);
                    yCoordTemp.AddLast(curve.Points[i].Y);
                }
                xCoord = xCoordTemp;
                yCoord = yCoordTemp;
                pirson = Correlation(GetEnum(xCoordTemp), GetEnum(yCoordTemp));
                endPoint++;
                startPoint++;
            }
           
            while ((pirson > 0.98 && (derivative > 0.5 && derivative < 4) && endPoint < curve.Points.Count-2))
            {
                LinkedList<double> xCoordTemp = xCoord;
                LinkedList<double> yCoordTemp = yCoord;
                
                xCoordTemp.AddLast(curve.Points[endPoint].X);
                yCoordTemp.AddLast(curve.Points[endPoint].Y);
                pirson = Correlation(GetEnum(xCoordTemp), GetEnum(yCoordTemp));
                derivative = Derivative(curve.Points[endPoint - 1].Y, curve.Points[endPoint + 1].Y);
                endPoint++;
            }       
            return pirson;
        }

    }
}
