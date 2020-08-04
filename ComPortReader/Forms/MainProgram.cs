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

namespace ComPortReader
{
    public partial class MainProgram : Form
    {



        public MainProgram form;


        LineItem curve;
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
            drawTest = new testGraph(GraphProcessing.drawTestGraph);
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

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
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
                if (temp != null) // Отрисовка добавленной в список точки
                {
                    planeGraph.Invoke((Action)(() => print(curve, temp.X, temp.Y)));
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
            GraphProcessing.CreateGraph(planeGraph, ref curve, ref pane);  //Создать график
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
            var newForm = new About(this.form);
            newForm.Show();
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
                using (Bitmap imageOfGraph = pane.GetImage())
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
            using (Bitmap imageOfGraph = pane.GetImage())
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
            int pos = pane.CurveList.IndexOf("Selection");
            if (pos >= 0) pane.CurveList.RemoveAt(pos);
            selectionCurve = null;
            object nearestObject;
            int index;
            this.planeGraph.GraphPane.FindNearestObject(new PointF(e.X, e.Y), this.CreateGraphics(), out nearestObject, out index);
            if (nearestObject != null && nearestObject.GetType() == typeof(LineItem))
            {
                PointPairList pointList = new PointPairList();
                selectionCurve = pane.AddCurve("Selection", pointList, Color.Blue
  );
                selectionCurve.Symbol.Size = curve.Symbol.Size * 1.5f;
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
            if (e.KeyCode == Keys.Up) 
        }

        private void planeGraph_Load_1(object sender, EventArgs e)
        {

        }
    }
}





