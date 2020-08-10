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
using System.Xml.Schema;
using System.Runtime.InteropServices;
using ComPortReader.Classes;
using ComPortReader.Forms;
using System.CodeDom;

namespace ComPortReader
{
    public partial class MainProgram : Form
    {


        internal List<DynamicToolStripButton> buttons = new List<DynamicToolStripButton>();
        DynamicToolStripButton linearPart;
        public MainProgram form;


        LineItem curve;
        LineItem lineCurve;
        GraphPane pane;
        
        


        private string comPort;
        string defaultPath;
        int counterTimer;
        public string savePath;
        bool atLeastOnePointPassed = false;
        System.Timers.Timer everySecond;
        SerialPort port;
        TwoCordLinkedList listOfPoints = new TwoCordLinkedList();


        public Settings settingsForm;
        bool isCoefficentEnabled = true;


        public delegate void drawGraphMethod(LineItem curve, double x, double y);
        public delegate void testGraph(MainProgram form);

        double coefficient = 1.0;
       
        public bool AtLeastOnePointPassed
        {
            get { return atLeastOnePointPassed; }
            set { atLeastOnePointPassed = value; }
        }
        public LineItem getCurve

        {
            get { return curve; }
            set { curve = value; }
        }
        public LineItem getLineCurve

        {
            get { return lineCurve; }
            set { lineCurve = value; }
        }

        public ToolStripDropDownButton CurvesDropDownButton
        {
            get { return curvesDropDownBtn; }
            set { curvesDropDownBtn = value; }
        }


        public double Coefficent
        {
            get { return coefficient; }
            set { coefficient = value; }
        }
        testGraph drawTest;

        public int CounterTimer
        {
            get { return counterTimer; }
            set { counterTimer = value; }
        }
        
        public double AutoSavePointValue
        {
            get { return AutoSavePointValue; }
            set { AutoSavePointValue = value; }
        }
        public string XAxisData
        {
            get { return planeGraph.GraphPane.XAxis.Title.Text; }
            set { planeGraph.GraphPane.XAxis.Title.Text = value; }
        }
        public string YAxisData
        {
            get { return planeGraph.GraphPane.YAxis.Title.Text; }
            set { planeGraph.GraphPane.YAxis.Title.Text = value; }
        }
        public string GraphName
        {
            get { return planeGraph.GraphPane.Title.Text; }
            set { planeGraph.GraphPane.Title.Text = value; }
        }
        public double MinXValue
        {
            get { return planeGraph.GraphPane.XAxis.Scale.Min; }
            set { planeGraph.GraphPane.XAxis.Scale.Min = value; }
        }
        public double MaxXValue
        {
            get { return planeGraph.GraphPane.XAxis.Scale.Max; }
            set { planeGraph.GraphPane.XAxis.Scale.Max = value; }
        }
        public double MinYValue
        {
            get { return planeGraph.GraphPane.YAxis.Scale.Min; }
            set { planeGraph.GraphPane.YAxis.Scale.Min = value; }
        }
        public double MaxYValue
        {
            get { return planeGraph.GraphPane.YAxis.Scale.Max; }
            set { planeGraph.GraphPane.YAxis.Scale.Max = value; }
        }
        public GraphPane GraphPaneInstance
        {
            get { return pane; }
            set { pane = value; }
        }
        public ZedGraphControl ZGCInstance
        {
            get { return planeGraph; }
            set { planeGraph = value; }
        }
        public string GetPath
        {
            get { return savePath; }
            set { savePath = value; }
        }
        public ToolStripDropDownButton CurvesButtons
        {
            get { return curvesDropDownBtn;  }
            set { curvesDropDownBtn = value; }
        }
        public testGraph getTestDrawingMethod
        {
            get { return drawTest; }
        }
        public MainProgram()
        {
            /* Инициализация настройки сохранения пути. Сделать так,
             * чтоб в папке с программой сохранялся конфиг, 
             * куда будут добавляться такие вещи, которые пользователь и так 
             * может задать в явном виде
             */
            //drawTest = new testGraph(GraphProcessing.drawTestGraph);
            defaultPath = @"C:\r5";
            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }
            savePath = defaultPath;
            InitializeComponent();  
            form = this;
            settingsForm = new Settings(form);
        }
        /// <summary>
        /// Event that reacts when port received any data. Reads it, divides into individual reading based on 
        /// lengthOfOneReading, fetches it to ProcessData, ads to the list and draws the point on the graph.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        double? xMin = null;
       
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
            if (curve == null)
            {
                buttons.Add(GraphProcessing.CreateCurve(ref curve, curvesDropDownBtn, planeGraph, "Основной График", Color.Red, 4, SymbolType.Circle, Color.Red));
                curve.Tag = 1;  
            }
            if (everySecond == null) СreateTimer(); // Логика за этим? Зачем таймер.
            drawGraphMethod print = new drawGraphMethod(GraphProcessing.AddInRealTime); //Инициализация переменных для ком-порта
            // Show all the incoming data in the port's buffer
            string comPortData = ((SerialPort)sender).ReadExisting().ToString();//Чтение данных из текущего ком порта.
            comPortData = comPortData.Replace("\r \n \0N", " "); //Удаление символов перехода строки
            comPortData = comPortData.Replace("\t", " ");
            int lengthOfOneReading = Parsing.GetLengthOfOneReading(comPortData);
            while (lengthOfOneReading > 0 && comPortData.Length > lengthOfOneReading ) //Перебираем все пары усилий и поворотов в полученной строке
            {
                lengthOfOneReading = Parsing.GetLengthOfOneReading(comPortData);
                string tempStr = comPortData.Substring(0, lengthOfOneReading); //Если в полученной строке несколько показаний, отделяем одно
                comPortData = comPortData.Substring(lengthOfOneReading); // Вся остальная строка
                TwoCordLinkedList.Node temp = Parsing.ProcessDataMK2(tempStr, coefficient);
                listOfPoints.addLast(temp);
                if (xMin == null && temp != null) 
                    xMin = temp.X;
                if (temp != null) // Отрисовка добавленной в список точки
                {
                    planeGraph.Invoke((Action)(() => print(curve, (temp.X - (double) (xMin)), temp.Y)));
                    planeGraph.Invoke((Action)(() => GraphProcessing.UpdateGraph(planeGraph)));
                }
            }
        }
        /// <summary>
        /// Loading the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e)
        {
            GraphProcessing.CreateGraph(planeGraph, "Основной график", "N Value", "F Value", 100, 100);  //Создать график
            string[] test = SerialPort.GetPortNames(); // Получить список доступных имен ком-портов
            for (int i = 0; i < test.Length; i++) comPortStatusB.Items.Add(test[i]);
        }
        /// <summary>
        /// Calls about window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutWindow_Click(object sender, EventArgs e)
        {
 
           
        }
        /// <summary>
        /// Opens chosen comport.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetupCOMport_Click(object sender, EventArgs e)
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
        /// <summary>
        /// Method that starts building building the graph.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBuilding_Click(object sender, EventArgs e)
        {
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            stopBuilding.Enabled = true;
            try
            {
                port.Open(); isCoefficentEnabled = false;
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
            GraphProcessing.UpdateGraph(planeGraph);
        }

        private void stopBuilding_Click(object sender, EventArgs e)
        {

            port.Close(); isCoefficentEnabled = true; settingsForm.SetGetCoefficentTBEnabled = isCoefficentEnabled; stopBuilding.Enabled = false;
            planeGraph.Refresh();
        }


        private void ComPortStatus_DropDownClosed(object sender, EventArgs e)
        {
            comPort = comPortStatusB.Text;
        }


        /// <summary>
        ///  Решение вопроса некликабельности toolstrip если приложение не в фокусе. https://stackoverflow.com/questions/22103913/how-to-make-a-toolstrip-button-immediately-clickable-without-clicking-on-the-for
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private const int WM_PARENTNOTIFY = 0x210;
        private const int WM_LBUTTONDOWN = 0x201;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PARENTNOTIFY)
            {
                if (m.WParam.ToInt32() == WM_LBUTTONDOWN && ActiveForm != this)
                {
                    Point p = PointToClient(Cursor.Position);
                    if (GetChildAtPoint(p) is ToolStrip)
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)p.X, (uint)p.Y, 0, 0);
                }
            }
            base.WndProc(ref m);
        }



        /// <summary>
        /// Counts timer, when counter 
        /// </summary>
        int saveTimerTick = 0;
        public void timer_tick(object source, EventArgs e)
        {
            //  
            saveTimerTick++;
            if (saveTimerTick == 3)
            {
                new Thread(() =>
                {
                    System.IO.File.WriteAllText(savePath + @"\" + "tempAntiCrashLog.txt", Parsing.GetData(port, listOfPoints));
                }).Start();
            }
            counterTimer++;
            if (counterTimer > 5 && atLeastOnePointPassed)
            {

                counterTimer = 0;
                atLeastOnePointPassed = false;      //Сохранение текстового файла автоматом
                everySecond = null;
                xMin = null;
                using (Bitmap imageOfGraph = planeGraph.GraphPane.GetImage())
                {
                    using (Graphics g = Graphics.FromImage(imageOfGraph))
                    {
                        Bitmap temp = imageOfGraph;
                        temp.Save(Parsing.CheckForDuplicateImage(savePath, defaultPath, GraphName), System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
                FileOperations.saveTextFile(Parsing.CheckForDuplicateTXT(savePath, defaultPath, GraphName), port, listOfPoints);
            }
        }
        /// <summary>
        /// Timer counting the lack of signal.
        /// </summary>
        public void СreateTimer()
        {
            everySecond = new System.Timers.Timer();
            everySecond.Interval = 1000; //10000 ms = 10 seconds
            everySecond.Enabled = true;
            everySecond.Elapsed += new System.Timers.ElapsedEventHandler(timer_tick);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            using (Bitmap imageOfGraph = planeGraph.GraphPane.GetImage())
            {
                using (Graphics g = Graphics.FromImage(imageOfGraph))
                {
                    Bitmap temp = imageOfGraph;
                    FileOperations.Printing(temp);
                }
            }
        }


        private void MainProgram_Resize(object sender, EventArgs e)
        {
            planeGraph.Height = this.Height - 60;
            planeGraph.Width = this.Width - 15;
        }

  
        private void planeGraph_MouseMove(object sender, MouseEventArgs e)
        {
                
            // Выводим результат
        }

        private void resetB_MouseDown(object sender, MouseEventArgs e)
        {
            settingsForm.Visible = !settingsForm.Visible;
            if (settingsForm.Visible)
            {
                settingsForm.SetGetCoefficentTBEnabled = isCoefficentEnabled;
                settingsForm.Show();
            }
           

        }

        private void planeGraph_Load(object sender, EventArgs e)
        {

        }

        private void startingRecordMenuB_Click(object sender, EventArgs e)
        {

        }

        LineItem selectionCurve;
        private void planeGraph_MouseClick(object sender, MouseEventArgs e)
        {
            int pos = planeGraph.GraphPane.CurveList.IndexOf("Selection");
            if (pos >= 0) planeGraph.GraphPane.CurveList.RemoveAt(pos);
            selectionCurve = null;
            object nearestObject;
            int index;
            this.planeGraph.GraphPane.FindNearestObject(new PointF(e.X, e.Y), this.CreateGraphics(), out nearestObject, out index);
            if (nearestObject != null && nearestObject.GetType() == typeof(LineItem))
            {
                PointPairList pointList = new PointPairList();
                selectionCurve = planeGraph.GraphPane.AddCurve("Selection", pointList, Color.Blue
  );
                selectionCurve.Symbol.Size = curve.Symbol.Size * 2f;
                selectionCurve.Symbol.Type = SymbolType.Square;
                selectionCurve.Symbol.Fill = curve.Symbol.Fill;
                LineItem nearestLineItemObject = (LineItem)nearestObject;
                PointPair clickedPoint = nearestLineItemObject.Points[index];
                selectionCurve.AddPoint(clickedPoint);
                
            }
            GraphProcessing.UpdateGraph(planeGraph);
        }

        private bool planeGraph_MouseMoveEvent(ZedGraphControl sender, MouseEventArgs e)
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
            if ((x > xmin) && (y > ymin) && (y < ymax) && (x < xmax))
            {
                string text = string.Format("X: {0};    Y: {1}", x, y);
                coord.Text = text;
            }

            return false;
        }
        

        private void planeGraph_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void planeGraph_Load_1(object sender, EventArgs e)
        {

        }

        private void planeGraph_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            double stepX = Math.Log10(Math.Abs(planeGraph.ScrollMaxX - planeGraph.ScrollMinX));
            double stepY = Math.Log10(Math.Abs(planeGraph.ScrollMaxY - planeGraph.ScrollMinY));

            if (e.KeyCode == Keys.Up)
            {
                MinYValue += stepY;
                MaxYValue += stepY;
            }


            if (e.KeyCode == Keys.Down)
            {
                MinYValue -= stepY;
                MaxYValue -= stepY;
            }

            if (e.KeyCode == Keys.Left)
            {
                MinXValue -= stepX;
                MaxXValue -= stepX;
            }

            if (e.KeyCode == Keys.Right)
            {
                MinXValue += stepX;
                MaxXValue += stepX;
            }
         

            GraphProcessing.UpdateGraph(planeGraph);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new About(this.form);
            newForm.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
        public LineItem processedCurve = null;
        public LineItem processedCurve2 = null;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (curve != null)
            {
                if (lineCurve != null)
                {
                    planeGraph.GraphPane.CurveList.Remove(lineCurve);
                    curvesDropDownBtn.DropDownItems.Remove(linearPart.button);
                    buttons.Remove(linearPart);
                    linearPart = null;
                    lineCurve = null;
                }
                linearPart = GraphProcessing.CreateCurve(ref lineCurve, curvesDropDownBtn, planeGraph, "Линейный участок", Color.Blue, 8, SymbolType.Circle, Color.Blue);
                buttons.Add(linearPart);
                LineItem firstDerivativeCurve = new LineItem("d1");
                LineItem secondDerivativeCurve = new LineItem("d1");
                LineItem firstMovingAverageCurve = new LineItem("mad1");


                buttons.Add(GraphProcessing.CreateCurve(ref processedCurve, form.CurvesDropDownButton, planeGraph, "Скользящее среднее", Color.Red, 6, SymbolType.Circle, Color.Blue));
                processedCurve = new LineItem("movingAverage1");
                processedCurve2 = new LineItem("movingAverage2");
                double[] data = GraphProcessing.CurveToArray(curve, false);
                double[] movingAverage = GraphProcessing.MovingAverage(data, 8);
                for (int i = 0; i < movingAverage.Length - 1; i++)
                {
                    processedCurve.AddPoint(curve.Points[i].X, movingAverage[i]);
                }
                double[] movingAverage1 = GraphProcessing.MovingAverage(data, 6);
                for (int i = 0; i < movingAverage1.Length - 1; i++)
                {
                    processedCurve2.AddPoint(curve.Points[i].X, movingAverage1[i]);
                }
         


                GraphProcessing.DerivativeGraph(curve, ref firstDerivativeCurve);
                GraphProcessing.SecondDerivativeGraph(firstDerivativeCurve, ref secondDerivativeCurve);

                GraphProcessing.DerivativeGraph(processedCurve, ref firstMovingAverageCurve);

                LineItem tempCurve = new LineItem("temp");
                LineItem secondMovingAverageCurve = new LineItem("sMAC");
                GraphProcessing.DerivativeGraph(processedCurve2, ref tempCurve);
                GraphProcessing.DerivativeGraph(tempCurve, ref secondMovingAverageCurve);   

                int[] bounds = GraphProcessing.CalculatePointsForLinear(curve, secondMovingAverageCurve, firstMovingAverageCurve);
                for (int i = bounds[0]; i < bounds[1]; i++) lineCurve.AddPoint(curve[i]);
                lineCurve.Tag = 4;
                GraphProcessing.UpdateGraph(planeGraph);
            }
            else
            {
                ErrorMessage form = new ErrorMessage("Нет графика на котором нужно найти линейный участок");
            }
            double[] xData = GraphProcessing.CurveToArray(lineCurve, true);
            double[] yData = GraphProcessing.CurveToArray(lineCurve, false);  
            var ds = new XYDataSet(xData, yData);


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var newForm = new DerivateForm(this.form);
            newForm.Show();
        }

        private void resetB_Click(object sender, EventArgs e)
        {

        }
    }
}





