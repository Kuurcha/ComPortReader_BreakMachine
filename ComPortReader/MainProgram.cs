using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using ZedGraph;
using System.Threading;
using System.Management;
using System.Timers;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
namespace ComPortReader
{
    public partial class MainProgram : Form
    {
        LineItem curve;
        GraphPane pane;
        PointPairList list = new PointPairList();
        private MainProgram form;

        
        private string comPort;
        string defaultPath;
        int counterTimer;
        public string savePath; 
        bool atLeastOnePointPassed = false;
        System.Timers.Timer everySecond;
        SerialPort port;
        TwoCordLinkedList listOfPoints = new TwoCordLinkedList();
        

        Settings settingsForm;
        bool isCoefficentEnabled = true;

       
        public delegate void drawGraphMethod(ZedGraphControl zgc, double x, double y);
        public delegate void testGraph();

        double coefficient = 1.0;
        private int yValue;
        public LineItem getCurve

        {
            get { return curve; }
            set { curve = value; }
        }
        public int YValue
        {
            get { return yValue; }
            set
            {
                yValue = value;
            }
        }
        public double GetCoefficent
        {
            get { return coefficient; }
            set { coefficient = value; }
        }
        testGraph drawTest;
        Point[] testPointsArray;

        /// <summary>
        /// тестовый график
        /// </summary>
        private void  addToGraph()
        {
            СreateTimer();
            Point[] points = { new Point(1, 8), new Point(2, 8), new Point(3, 8), new Point(4, 8), new Point(5, 9), new Point(6, 9), new Point(7, 8), new Point(8, 9), new Point(9, 9), new Point(10, 10), new Point(11, 10), new Point(12, 12), new Point(13, 13), new Point(14, 16), new Point(15, 19), new Point(16, 21), new Point(17, 23), new Point(18, 27), new Point(19, 30), new Point(20, 33), new Point(21, 36), new Point(22, 38), new Point(23, 43), new Point(24, 47), new Point(25, 51), new Point(26, 55), new Point(27, 62), new Point(28, 66), new Point(29, 72), new Point(30, 78), new Point(31, 83), new Point(32, 90), new Point(33, 96), new Point(34, 101), new Point(35, 107), new Point(36, 114), new Point(37, 120), new Point(38, 125), new Point(39, 132), new Point(40, 137), new Point(41, 143), new Point(42, 148), new Point(43, 155), new Point(44, 159), new Point(45, 166), new Point(46, 172), new Point(47, 178), new Point(48, 184), new Point(49, 190), new Point(50, 196), new Point(51, 203), new Point(52, 209), new Point(53, 217), new Point(54, 222), new Point(55, 229), new Point(56, 236), new Point(57, 243), new Point(58, 250), new Point(59, 258), new Point(60, 264), new Point(61, 271), new Point(62, 278), new Point(63, 287), new Point(64, 295), new Point(65, 302), new Point(66, 309), new Point(67, 318), new Point(68, 325), new Point(69, 334), new Point(70, 342), new Point(71, 351), new Point(72, 358), new Point(73, 367), new Point(74, 376), new Point(75, 384), new Point(76, 392), new Point(77, 402), new Point(78, 411), new Point(79, 420), new Point(80, 429), new Point(81, 439), new Point(82, 447), new Point(83, 457), new Point(84, 466), new Point(85, 476), new Point(86, 485), new Point(87, 494), new Point(88, 503), new Point(89, 512), new Point(90, 520), new Point(91, 528), new Point(92, 535), new Point(93, 542), new Point(94, 548), new Point(95, 553), new Point(96, 557), new Point(97, 557), new Point(98, 555), new Point(99, 557), new Point(100, 560), new Point(101, 561), new Point(102, 560), new Point(103, 560), new Point(104, 560), new Point(105, 558), new Point(106, 561), new Point(107, 563), new Point(108, 564), new Point(109, 566), new Point(110, 564), new Point(111, 563), new Point(112, 564), new Point(113, 563), new Point(114, 564), new Point(115, 565), new Point(116, 564), new Point(117, 563), new Point(118, 563), new Point(119, 564), new Point(120, 564), new Point(121, 562), new Point(122, 562), new Point(123, 562), new Point(124, 563), new Point(125, 562), new Point(126, 563), new Point(127, 563), new Point(128, 564), new Point(129, 562), new Point(130, 560), new Point(131, 562), new Point(132, 561), new Point(133, 560), new Point(134, 560), new Point(135, 564), new Point(136, 564), new Point(137, 563), new Point(138, 562), new Point(139, 562), new Point(140, 562), new Point(141, 558), new Point(142, 554), new Point(143, 566), new Point(144, 571), new Point(145, 575), new Point(146, 576), new Point(147, 578), new Point(148, 579), new Point(149, 581), new Point(150, 583), new Point(151, 583), new Point(152, 585), new Point(153, 587), new Point(154, 588), new Point(155, 590), new Point(156, 591), new Point(157, 592), new Point(158, 593), new Point(159, 595), new Point(160, 596), new Point(161, 597), new Point(162, 598), new Point(163, 600), new Point(164, 601), new Point(165, 602), new Point(166, 604), new Point(167, 605), new Point(168, 605), new Point(169, 607), new Point(170, 608), new Point(171, 608), new Point(172, 609), new Point(173, 611), new Point(174, 612), new Point(175, 613), new Point(176, 615), new Point(177, 616), new Point(178, 617), new Point(179, 618), new Point(180, 619), new Point(181, 620), new Point(182, 621), new Point(183, 621), new Point(184, 622), new Point(185, 624), new Point(186, 625), new Point(187, 626), new Point(188, 627), new Point(189, 628), new Point(190, 628), new Point(191, 629), new Point(192, 630), new Point(193, 631), new Point(194, 632), new Point(195, 633), new Point(196, 633), new Point(197, 634), new Point(198, 636), new Point(199, 637), new Point(200, 637), new Point(201, 638), new Point(202, 639), new Point(203, 640), new Point(204, 640), new Point(205, 642), new Point(206, 642), new Point(207, 643), new Point(208, 644), new Point(209, 644), new Point(210, 645), new Point(211, 646), new Point(212, 647), new Point(213, 647), new Point(214, 648), new Point(215, 648), new Point(216, 649), new Point(217, 650), new Point(218, 651), new Point(219, 652), new Point(220, 652), new Point(221, 653), new Point(222, 653), new Point(223, 654), new Point(224, 654), new Point(225, 655), new Point(226, 655), new Point(227, 656), new Point(228, 657), new Point(229, 658), new Point(230, 658), new Point(231, 659), new Point(232, 659), new Point(233, 660), new Point(234, 661), new Point(235, 661), new Point(236, 661), new Point(237, 662), new Point(238, 662), new Point(239, 664), new Point(240, 664), new Point(241, 664), new Point(242, 664), new Point(243, 665), new Point(244, 666), new Point(245, 666), new Point(246, 666), new Point(247, 667), new Point(248, 668), new Point(249, 668), new Point(250, 668), new Point(251, 669), new Point(252, 669), new Point(253, 670), new Point(254, 670), new Point(255, 670), new Point(256, 671), new Point(257, 671), new Point(258, 671), new Point(259, 672), new Point(260, 672), new Point(261, 673), new Point(262, 673), new Point(263, 674), new Point(264, 673), new Point(265, 674), new Point(266, 675), new Point(267, 675), new Point(268, 675), new Point(269, 676), new Point(270, 676), new Point(271, 677), new Point(272, 677), new Point(273, 677), new Point(274, 678), new Point(275, 678), new Point(276, 679), new Point(277, 680), new Point(278, 679), new Point(279, 680), new Point(280, 680), new Point(281, 680), new Point(282, 680), new Point(283, 681), new Point(284, 681), new Point(285, 682), new Point(286, 682), new Point(287, 682), new Point(288, 682), new Point(289, 683), new Point(290, 684), new Point(291, 683), new Point(292, 683), new Point(293, 684), new Point(294, 684), new Point(295, 685), new Point(296, 685), new Point(297, 685), new Point(298, 686), new Point(299, 685), new Point(300, 686), new Point(301, 686), new Point(302, 687), new Point(303, 687), new Point(304, 687), new Point(305, 688), new Point(306, 688), new Point(307, 688), new Point(308, 688), new Point(309, 689), new Point(310, 688), new Point(311, 689), new Point(312, 690), new Point(313, 690), new Point(314, 690), new Point(315, 690), new Point(316, 690), new Point(317, 690), new Point(318, 690), new Point(319, 691), new Point(320, 691), new Point(321, 691), new Point(322, 692), new Point(323, 691), new Point(324, 692), new Point(325, 692), new Point(326, 692), new Point(327, 692), new Point(328, 692), new Point(329, 693), new Point(330, 692), new Point(331, 693), new Point(332, 693), new Point(333, 694), new Point(334, 694), new Point(335, 694), new Point(336, 694), new Point(337, 694), new Point(338, 694), new Point(339, 694), new Point(340, 695), new Point(341, 695), new Point(342, 695), new Point(343, 695), new Point(344, 696), new Point(345, 695), new Point(346, 695), new Point(347, 696), new Point(348, 696), new Point(349, 697), new Point(350, 696), new Point(351, 697), new Point(352, 696), new Point(353, 697), new Point(354, 697), new Point(355, 697), new Point(356, 697), new Point(357, 697), new Point(358, 697), new Point(359, 697), new Point(360, 697), new Point(361, 697), new Point(362, 697), new Point(363, 698), new Point(364, 698), new Point(365, 697), new Point(366, 698), new Point(367, 699), new Point(368, 698), new Point(369, 699), new Point(370, 698), new Point(371, 698), new Point(372, 698), new Point(373, 698), new Point(374, 699), new Point(375, 699), new Point(376, 699), new Point(377, 699), new Point(378, 699), new Point(379, 700), new Point(380, 699), new Point(381, 700), new Point(382, 699), new Point(383, 700), new Point(384, 700), new Point(385, 699), new Point(386, 699), new Point(387, 700), new Point(388, 700), new Point(389, 701), new Point(390, 700), new Point(391, 700), new Point(392, 700), new Point(393, 700), new Point(394, 701), new Point(395, 701), new Point(396, 700), new Point(397, 701), new Point(398, 701), new Point(399, 701), new Point(400, 702), new Point(401, 701), new Point(402, 701), new Point(403, 702), new Point(404, 702), new Point(405, 702), new Point(406, 701), new Point(407, 701), new Point(408, 702), new Point(409, 701), new Point(410, 702), new Point(411, 702), new Point(412, 701), new Point(413, 702), new Point(414, 701), new Point(415, 702), new Point(416, 702), new Point(417, 702), new Point(418, 702), new Point(419, 702), new Point(420, 702), new Point(421, 702), new Point(422, 702), new Point(423, 702), new Point(424, 703), new Point(425, 703), new Point(426, 703), new Point(427, 703), new Point(428, 703), new Point(429, 703), new Point(430, 703), new Point(431, 703), new Point(432, 703), new Point(433, 703), new Point(434, 704), new Point(435, 704), new Point(436, 704), new Point(437, 704), new Point(438, 704), new Point(439, 703), new Point(440, 704), new Point(441, 703), new Point(442, 703), new Point(443, 703), new Point(444, 704), new Point(445, 704), new Point(446, 704), new Point(447, 704), new Point(448, 703), new Point(449, 704), new Point(450, 703), new Point(451, 703), new Point(452, 704), new Point(453, 703), new Point(454, 703), new Point(455, 704), new Point(456, 703), new Point(457, 704), new Point(458, 704), new Point(459, 704), new Point(460, 704), new Point(461, 704), new Point(462, 705), new Point(463, 704), new Point(464, 704), new Point(465, 704), new Point(466, 704), new Point(467, 704), new Point(468, 703), new Point(469, 704), new Point(470, 704), new Point(471, 705), new Point(472, 704), new Point(473, 704), new Point(474, 705), new Point(475, 705), new Point(476, 704), new Point(477, 704), new Point(478, 704), new Point(479, 704), new Point(480, 704), new Point(481, 705), new Point(482, 704), new Point(483, 703), new Point(484, 704), new Point(485, 705), new Point(486, 703), new Point(487, 704), new Point(488, 704), new Point(489, 704), new Point(490, 704), new Point(491, 703), new Point(492, 704), new Point(493, 704), new Point(494, 704), new Point(495, 704), new Point(496, 703), new Point(497, 703), new Point(498, 704), new Point(499, 704), new Point(500, 704), new Point(501, 703), new Point(502, 704), new Point(503, 704), new Point(504, 703), new Point(505, 703), new Point(506, 703), new Point(507, 703), new Point(508, 704), new Point(509, 703), new Point(510, 703), new Point(511, 703), new Point(512, 703), new Point(513, 703), new Point(514, 703), new Point(515, 703), new Point(516, 702), new Point(517, 703), new Point(518, 703), new Point(519, 703), new Point(520, 703), new Point(521, 703), new Point(522, 701), new Point(523, 702), new Point(524, 703), new Point(525, 702), new Point(526, 703), new Point(527, 702), new Point(528, 702), new Point(529, 703), new Point(530, 702), new Point(531, 701), new Point(532, 702), new Point(533, 701), new Point(534, 701), new Point(535, 702), new Point(536, 700), new Point(537, 701), new Point(538, 701)};
            testPointsArray = points;
            for (int x = 0; x < testPointsArray.Length; x++)
            {
                counterTimer = 0;
                atLeastOnePointPassed = true;
                YValue = points[x].Y;
                curve.AddPoint((double)points[x].X*coefficient, (double)points[x].Y * coefficient) ;
                planeGraph.Refresh();
                planeGraph.AxisChange();
            }
            Bitmap imageOfGraph = pane.GetImage();
            
        }
        public double AutoSavePointValue
        {
            get { return AutoSavePointValue; }
            set { AutoSavePointValue = value; }
        }
        public string XAxisData
        {
            get { return pane.XAxis.Title.Text; }
            set { pane.XAxis.Title.Text = value; }
        }
        public string YAxisData
        {
            get { return pane.YAxis.Title.Text; }
            set { pane.YAxis.Title.Text = value; }
        }
        public string GraphName
        {
            get { return pane.Title.Text; }
            set { pane.Title.Text = value; }
        }
        public double MinXValue
        {
            get { return pane.XAxis.Scale.Min; }
            set { pane.XAxis.Scale.Min = value; }
        }
        public double MaxXValue
        {
            get { return pane.XAxis.Scale.Max; }
            set { pane.XAxis.Scale.Max = value; }
        }
        public double MinYValue
        {
            get { return pane.YAxis.Scale.Min; }
            set { pane.YAxis.Scale.Min = value; }
        }
        public double MaxYValue
        {
            get { return pane.YAxis.Scale.Max; }
            set { pane.YAxis.Scale.Max = value; }
        }
        public GraphPane Graph
        {
            get { return pane; }
            set { pane = value; }
        }
        public ZedGraphControl GraphInstanse
        {
            get { return planeGraph; }
            set { planeGraph = value; }
        }
        public string GetPath
        {
            get { return savePath; }
            set { savePath = value; }
        }
        public MainProgram()
        {
            drawTest = new testGraph(addToGraph);
            defaultPath = @"C:\r5";
            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }
            savePath = defaultPath;
            InitializeComponent();
            form = this;
        }
        public testGraph getTestDrawingMethod
        {
            get { return drawTest; }
        }

        /// <summary>
        /// Алгоритм обработки текстовых от данных трех датчиков температуры написанных на Arduino
        /// </summary>
        /// <param name="s">полученные данные от датчиков</param>
        /// <returns>переводит текст в числа, получая чистые данные температуры</returns>
        private List<double> getTemperatureNumbers(string s)
        {
            char pivot;
            List<double> output = new List<double>();
            bool numFound = false;
            string temp = null;
            for (int i = 0; i < s.Length; i++)
            {
                pivot = s[i];
                if (pivot == '+') numFound = true;
                if (numFound && ((Char.IsNumber(pivot)) || pivot == '.')) { if (pivot == '.') pivot = ','; temp += pivot; }
                if (pivot == '\r' && numFound) { numFound = false; output.Add(Double.Parse(temp)); temp = null; }
            }
            return output;
        }
        /// <summary>
        /// Метод добавляющий точку на граф к кривой myCurve
        /// </summary>
        /// <param name="zgc">график на который добавляется точка</param>
        /// <param name="pointX">координаты точки х</param>
        /// <param name="pointY"> координаты точки у</param>
        private void addInRealTime(ZedGraphControl zgc, double pointX, double pointY)
        {
            curve.AddPoint(pointX, pointY);
            zgc.Refresh();
            zgc.AxisChange();
            textBox2.Text +=    "Данные получены " + pointY;
        }
        /// <summary>
        /// метод обновления графа
        /// </summary>
        private void updateGraph()
        {
            planeGraph.Refresh();
            planeGraph.AxisChange();
        }
        /// <summary>
        /// Событие, реагирующее при получении информации с порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///     
       
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)

        {

            if (everySecond == null) СreateTimer(); 

            
            drawGraphMethod print = new drawGraphMethod(addInRealTime);
            SerialPort sp = (SerialPort)sender;
            // Show all the incoming data in the port's buffer
            string comPortData = sp.ReadExisting().ToString();
           
                TwoCordLinkedList.Node temp = destructionMachineData(comPortData);
                listOfPoints.addLast(temp);
                if (temp!=null)
                  { 
               
                planeGraph.Invoke((Action)(() => print(planeGraph, temp.X,temp.Y)));
                planeGraph.Invoke((Action)(() => updateGraph()));

                    }
        }
        [STAThread]
        private void button1_Click(object sender, EventArgs e)
        {

        
        }
        /// <summary>
        /// Метод обратаывающий данные типа N= 000XX F= 000XX, получает число или 0, если значением является 0000
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <returns> Элемент списка содержащий две координаты: x и у.</returns>
        private TwoCordLinkedList.Node destructionMachineData (string s)
        {
            TwoCordLinkedList.Node output = null;
            if (s!=null)
            {
                int counter = 0;
                bool zero = true;
                bool onlyZeroes = true;
                byte zeroesCounter = 0;
               
                string[] sOutput = new string[2];


                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Length != 0 && s[0] == 'N')
                    {
                        char pivot = s[i];
                        if (pivot == 'F') { zero = true; counter++; zeroesCounter = 0; onlyZeroes = true; }

                        if (Char.IsNumber(pivot))
                        {
                            if (pivot != '0') { zero = false; }
                            if (!zero) { sOutput[counter] += pivot; onlyZeroes = false; }
                            if ((pivot == '0') && zero) { zeroesCounter++; }
                        }

                        if (zeroesCounter == 4 && onlyZeroes) { sOutput[counter] = "0"; }
                    }
                }
                int xValue; int tempY;
                if (sOutput!=null && int.TryParse(sOutput[0], out xValue) && int.TryParse(sOutput[1], out tempY)) { output = new TwoCordLinkedList.Node(xValue * coefficient, YValue * coefficient); }

            }             
            return output;
        }

        private void setSizeB_Click(object sender, EventArgs e)
        {

        }

        private void planeCanvas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            CreateGraph(planeGraph);
            
            planeGraph.Visible = true;
            settingsForm = new Settings(form);
            form.Size = new Size(form.Width - 1, form.Height - 1);
            string[] test = SerialPort.GetPortNames();
            for (int i = 0; i < test.Length; i++)
            {
                comPortStatusB.Items.Add(test[i]);
            }
            pane.XAxis.MajorGrid.IsVisible = true;
            // Длина штрихов равна 10 пикселям, ...
            pane.XAxis.MajorGrid.DashOff = 0;
            pane.XAxis.Scale.MajorStep = 100;


            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOff = 0;
            pane.YAxis.Scale.MajorStep = 100;

            // затем 5 пикселей - пропуск



            // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y 

            //creating icons
            /*         Graphics drawingIcons = this.CreateGraphics();
                     Pen myPen = new Pen(Color.Black, 2);
                     Rectangle forDrawing = new Rectangle(0, 0, 10, 10);
                     drawingIcons.DrawEllipse(myPen, forDrawing);
                     Bitmap temp = new Bitmap(10, 10, drawingIcons);
                     Image Circle = temp;
                     imgComboBox.ImageList.Images.Add(Circle, Color.Transparent);
                     imgComboBox.Items.Add(new ImageComboBox.ImageComboBoxItem(0, "Тест", 10));
                     drawingIcons.Dispose(); */



        }

        private void planeGraph_Load(object sender, EventArgs e)
        {
            


        }
       
  
       /// <summary>
       /// Стартовые настройки графика, имя
       /// </summary>
       /// <param name="zgc"></param>
        private void CreateGraph(ZedGraphControl zgc)
        {

            pane = planeGraph.GraphPane;
            // Make up some data points from the Sine function
           
            curve = pane.AddCurve(" "+ "0", list, Color.Red
                              );
            curve.Symbol.Size = 4;
            curve.Symbol.Type = SymbolType.Square;
          
            curve.Symbol.Fill = new Fill(Color.White);

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 600.0*coefficient;

            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 800.0*coefficient;
            


            planeGraph.AxisChange();
            planeGraph.Refresh();

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend

            // Fill the area under the curve with a white-red gradient at 45 degrees
            //    myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);

            pane.Title.Text = "Именовани Маркировки";
            pane.XAxis.Title.Text = "N Value";
            pane.YAxis.Title.Text = "F Value";



        }
        private void SetSize()
        {
           // planeGraph.Location = new Point(195, 89);
            // Leave a small margin around the outside of the cont` rol
            
            planeGraph.Size = new Size(planeGraph.Size.Width+1, planeGraph.Size.Height);
            planeGraph.Visible = true;
            // Set the titles and axis labels
         
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var newForm = new About(this.form);
            newForm.Show();

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            startingRecordMenuB.Enabled = false;
            
            if (comPort != null)
            {
                port = new SerialPort(comPort, 38400, Parity.None, 8, StopBits.One);
                startingRecordMenuB.Enabled = true;


            }
           
        }

        private void portList_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort = comPortStatusB.Text;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void startBuilding_Click(object sender, EventArgs e)
        {
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // InvalidOperationException  
           stopBuilding.Enabled = true;
            try { port.Open(); isCoefficentEnabled = false;
                settingsForm.SetGetCoefficentTBEnabled = false;
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException || ex is InvalidOperationException)
                {
                    ErrorMessage form = new ErrorMessage("Невозможно открыть порт, так как порт уже открыт!");
                    form.Show();
                }
            }
            planeGraph.Refresh();
            planeGraph.AxisChange();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void stopBuilding_Click(object sender, EventArgs e)
        {

                port.Close(); isCoefficentEnabled = true; settingsForm.SetGetCoefficentTBEnabled = isCoefficentEnabled; stopBuilding.Enabled = false;
                planeGraph.Refresh();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void planeSizeTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mode_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void ComPortStatus_DropDownClosed(object sender, EventArgs e)
        {
            comPort = comPortStatusB.Text;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void planeGraph_Load_1(object sender, EventArgs e)
        {

        }

        private void testB_Click(object sender, EventArgs e)
        {
           
            try { settingsForm.SetGetCoefficentTBEnabled = isCoefficentEnabled; settingsForm.Show(); }
            catch (System.ObjectDisposedException)
            {
                settingsForm = new Settings(form);
                settingsForm.SetGetCoefficentTBEnabled = isCoefficentEnabled;
                settingsForm.Show();
               
            }
             
        }
     
    /// <summary>
    /// Проверяет на стаднартный путь и дубликаты пути, добавляя число 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
        public string CheckForDuplicateImage(string path)
        {
            int counter = 1;
            if (path == defaultPath)
            {
                path += @"\" + pane.Title.Text + ".png";
            }
            while (File.Exists(path))
            {
                string temp = path.Remove(path.Length - 5);
                path = temp + counter + ".png";
                counter++;
            }
            return path;
        }
        /// <summary>
        /// Проверяет на стаднартный путь и дубликаты пути, добавляя число если дубликат найден. 
        /// Для файлов 
        /// </summary>
        /// <param name="path">путь к файлу</param>
        public string CheckForDuplicateTXT(string path)
        {
            int counter = 1;
            if (path == defaultPath)
            {
                path += @"\" + pane.Title.Text + ".txt";
            }
            while (File.Exists(path))
            {
                string temp = path.Remove(path.Length - 5);
                path = temp + counter + ".txt";
                counter++;
            }

            return path;
        }


        public string GetData ()
        {
            string s = "";
            if (port != null && port.IsOpen)
            {

                TwoCordLinkedList.Node temp = listOfPoints.Head.Prev;
                while (temp.Prev != listOfPoints.Head)
                {
                    s += "N = " + temp.X + " " + "F = " + temp.Y + " \r\n";
                    temp = temp.Prev;
                }
            }
            else
            {

                for (int i = 0; i < testPointsArray.Length; i++)
                {
                    s += "N = " + testPointsArray[i].X + " " + " F = " + testPointsArray[i].Y + " \r\n";
                }

            }
            return s;
        }
        /// <summary>
        /// Cохраняет текстовый файл по пути, и в случае если путь - дубликат, добавляет соотвествующую цифорку
        /// </summary>
        /// <param name="path"></param>
        public string saveTextFile(string path)
        {

            string s = GetData();
            try
            {
                using (StreamWriter file = new StreamWriter(path))
                {
           
                    file.Write(s);
                    file.Close();

                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {

            }
            return path;
        }

        public void Printing (Bitmap image)
        {
                    
                // объект для печати
                PrintDocument printDocument = new PrintDocument();

            // обработчик события печати
            printDocument.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                PrintPageHandler(sender, e, image);
            };



                // диалог наст ройки печати
            PrintDialog printDialog = new PrintDialog();

                // установка объекта печати для его настройки
                printDialog.Document = printDocument;

                // если в диалоге было нажато ОК
                if (printDialog.ShowDialog() == DialogResult.OK)
                    printDialog.Document.Print(); // печатаем
            }

        // обработчик события печати
        void PrintPageHandler(object sender,  PrintPageEventArgs e, Bitmap image)
        {
            // печать строки result
            e.Graphics.DrawImage(image, 0, 0);
        }



        int saveTimerTick = 0;
        public void timer_tick(object source, EventArgs e)
        {

            saveTimerTick++;
            if (saveTimerTick == 3)
            {
                new Thread(() =>
                {
                    System.IO.File.WriteAllText(savePath + @"\" + "tempAntiCrashLog.txt", GetData());
                }).Start();
            }
            counterTimer++;
            if (counterTimer > 5 && atLeastOnePointPassed)
            {
 
                counterTimer = 0;
                atLeastOnePointPassed = false;      //Сохранение текстового файла автоматом
                everySecond = null;
                using (Bitmap imageOfGraph = pane.GetImage())
                {
                    using (Graphics g = Graphics.FromImage(imageOfGraph))
                    {
                        Bitmap temp = imageOfGraph;
                        temp.Save(CheckForDuplicateImage(savePath), System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
                saveTextFile(CheckForDuplicateTXT(savePath));
            }
        }
        public void СreateTimer ()
        {
            everySecond = new System.Timers.Timer();
            everySecond.Interval = 1000; //10000 ms = 10 seconds
            everySecond.Enabled = true;
            everySecond.Elapsed += new System.Timers.ElapsedEventHandler(timer_tick);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void imageComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainProgram_ResizeEnd(object sender, EventArgs e)
        {
         
        
        }

        private void MainProgram_ResizeBegin(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (Bitmap imageOfGraph = pane.GetImage())
            {
                using (Graphics g = Graphics.FromImage(imageOfGraph))
                {
                    Bitmap temp = imageOfGraph;
                    Printing(temp);
                }
            }
            
        }

        private void MainProgram_Resize(object sender, EventArgs e)
        {
            planeGraph.Height = this.Height - 60;
            planeGraph.Width = this.Width - 15;
        }

        private void planeGraph_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void MainProgram_MouseHover(object sender, EventArgs e)
        {
            
           
        }

        private void planeGraph_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = planeGraph.PointToClient(Cursor.Position);
            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            planeGraph.GraphPane.ReverseTransform(pos, out x, out y);
            double xmin = planeGraph.GraphPane.XAxis.Scale.Min;
            double ymin = planeGraph.GraphPane.YAxis.Scale.Min;
            double xmax = planeGraph.GraphPane.XAxis.Scale.Max;
            double ymax = planeGraph.GraphPane.YAxis.Scale.Max;

            x = Math.Round(x);
            y = Math.Round(y);
            if ( (x > xmin) && (y>ymin) && (y<ymax) && (x < xmax) )
            {
                string text = string.Format("X: {0};    Y: {1}", x, y);
                coord.Text = text;
            }
            // Выводим результат
        }
    }
}






///Сортировка температуры

