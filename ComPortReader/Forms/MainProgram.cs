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

        internal double bCoef;
        internal double kCoef;
        internal double IntersectionPointBegin; //Первая точка пересечения паралелльной прямой линейному участку предела текучести
        internal double IntersectionPointEnd; //Вторая точка пересечения паралелльной прямой линейному участку предела текучести

        internal string metalMarking;
        internal string type;
        internal double aDim;
        internal double bDim;
        internal double diameterBefore;
        internal double diameterAfter;
        internal double totalArea;
        internal double originalLength;
        internal double endLength;
        internal int maxForce;
        internal int?[] forceAtStressFlow;
        internal int forceAtStressFlow2;
        internal double tempTearResistance;
        internal int?[] stressFlow;
        internal int stressFlow2;
        internal double relativeExpansion;
        internal double relativeNarrowing;
        internal PointPair[] yieldPoints;
        internal double currentMachineCoef;


        internal List<ExperimentReading> readingInOneSession;
        internal int readinCount;



        private string comPort;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;

        internal int sensitivy;
        public int Sensitivy
        {
            get { return sensitivy; }
            set { sensitivy = value; }
        }
        public string MyComPort
        {
            get { return comPort; }
            set { comPort = value; }
        }
        public int MyBaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }
        public int MyDataBits
        {
            get { return dataBits; }
            set { dataBits = value; }
        }
        public Parity MyParity
        {
            get { return parity; }
            set { parity = value; }
        }
        public StopBits MyStopBits
        {
            get { return stopBits; }
            set { stopBits = value; }
        }




        internal List<DynamicToolStripButton> buttons = new List<DynamicToolStripButton>();
        
        public MainProgram form;

        


        LineItem curve;
        LineItem lineCurve;
        GraphPane pane;

        public bool leastSquares;



        internal string defaultPath;
        internal int counterTimer;
        public string savePath;
        bool atLeastOnePointPassed = false;
        internal System.Timers.Timer everySecond;
        SerialPort port;
        internal SerialPort Port
        {
            get { return port; }
            set { port = value; }
        }
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
            get { return curvesDropDownBtn; }
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
       

        bool firstValue = false;

        double xMin = 0;

        internal void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (curve == null)
            {
                buttons.Add(GraphProcessing.CreateCurve(ref curve, curvesDropDownBtn, planeGraph, "Основной График", Color.Red, 2, SymbolType.Circle, Color.Red));
                ZGCInstance.GraphPane.YAxis.Title.Text = "F, условных единиц";
                ZGCInstance.GraphPane.XAxis.Title.Text = "N, оборотов";
                curve.Tag = 3;
            }
          // Логика за этим? Зачем таймер.
            drawGraphMethod print = new drawGraphMethod(GraphProcessing.AddInRealTime); //Инициализация переменных для ком-порта
            // Show all the incoming data in the port's buffer
            string comPortData = ((SerialPort)sender).ReadExisting().ToString();//Чтение данных из текущего ком порта.
            comPortData = comPortData.Replace("0\r#0", " "); //Удаление символов перехода строки
            comPortData = comPortData.Replace("\t", " ");
            int lengthOfOneReading = Parsing.GetLengthOfOneReading(comPortData);
            counterTimer = 0;
            saveTimerTick = 0;
            while (lengthOfOneReading > 0 && comPortData.Length > lengthOfOneReading) //Перебираем все пары усилий и поворотов в полученной строке
            {
                if (everySecond == null) СreateTimer();
                
                atLeastOnePointPassed = true;
                lengthOfOneReading = Parsing.GetLengthOfOneReading(comPortData);
                string tempStr = comPortData.Substring(0, lengthOfOneReading); //Если в полученной строке несколько показаний, отделяем одно
                comPortData = comPortData.Substring(lengthOfOneReading); // Вся остальная строка
                TwoCordLinkedList.Node temp = Parsing.ProcessDataMK2(tempStr, coefficient);
                listOfPoints.addLast(temp);
                if (!firstValue && temp!=null) { xMin = temp.X; firstValue = true; }
                
                if (temp != null) // Отрисовка добавленной в список точки
                {
                    try
                    {
                        planeGraph.Invoke((Action)(() => print(curve,  (double) temp.X - xMin, temp.Y)));
                        planeGraph.Invoke((Action)(() => GraphProcessing.UpdateGraph(planeGraph)));
                    }
                    catch (Exception ex) { }
               
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
            GraphProcessing.CreateGraph(planeGraph, GraphName, XAxisData, YAxisData, 100, 100);  //Создать график
            string[] test = SerialPort.GetPortNames(); // Получить список доступных имен ком-портов
            for (int i = 0; i < test.Length; i++) comPortStatusB.Items.Add(test[i]);
            base.Closing += OnClosing;
            FileOperations.GetVariables(this);
        }
        /// <summary>
        /// Calls about window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutWindow_Click(object sender, EventArgs e)
        {


        }
        internal void openComPort()
        {
            startingRecordMenuB.Enabled = false;
            try
            {
                if (comPort != null)
                {
                    port = new SerialPort(MyComPort, MyBaudRate, MyParity, MyDataBits, MyStopBits);
                    startingRecordMenuB.Enabled = true;
                    startingRecordMenuB.DropDownItems[0].Enabled = true;
                }
            }
            catch (Exception Ex) { MessageBox.Show("Не удалось установить порт. Проверьте настройки COM-порта"); }
        }
        FirstInput readingInput;
        internal FirstInput ReadingInput
        {
            get { return readingInput; }
            set { readingInput = value; }
        }
        /// <summary>
        /// Opens chosen comport.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetupCOMport_Click(object sender, EventArgs e)
        {
            comPort = comPortStatusB.Text;
            form.openComPort();
            //if (comPort != null)
            //{

            //  form.openComPort();
               
             
            //}
            //else
            //{
              
            //}
        }
        public void ChangeButtonState()
        {
            
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

            
            if (port!= null && !port.IsOpen & readingInput==null)
            {
                try
                {
                    if (readingInOneSession == null) readingInOneSession = new List<ExperimentReading>();
                    showWindow.Enabled = true;
                    port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                    stopBuilding.Enabled = true;
                    startBuilding.Enabled = false;
                    readingInput = new FirstInput(this);
                    readingInput.Show();

                    
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException || ex is InvalidOperationException)
                    {
                        ErrorMessage form = new ErrorMessage("Невозможно открыть порт, так как порт уже открыт!");
                        form.Show();
                    }
                }
            }
            else { if (port != null) { ErrorMessage form = new ErrorMessage("Невозможно открыть порт, так как порт уже открыт!"); } }         
            GraphProcessing.UpdateGraph(planeGraph);

        }

        private void stopBuilding_Click(object sender, EventArgs e)
        {
            if (readingInput != null) readingInput = null;
            startingRecordMenuB.DropDownItems[0].Enabled = true;
            port.Close(); isCoefficentEnabled = true; settingsForm.SetGetCoefficentTBEnabled = isCoefficentEnabled; stopBuilding.Enabled = false;
            planeGraph.Refresh();
            form.showWindow.Enabled = false;
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
            if (counterTimer > 4 && atLeastOnePointPassed)
            {

                counterTimer = 0;
                atLeastOnePointPassed = false;
                everySecond.Enabled = false;//Сохранение текстового файла автоматом
                everySecond = null;
                firstValue = false;
                xMin = 0;
                try
                {
                    Bitmap imageOfGraph = planeGraph.GraphPane.GetImage();
                    Graphics g = Graphics.FromImage(imageOfGraph);
                    Bitmap temp = imageOfGraph;
                    temp.Save(Parsing.CheckForDuplicateImage(savePath, savePath, GraphName + "original"), System.Drawing.Imaging.ImageFormat.Bmp);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
               
                
                FileOperations.saveTextFile(Parsing.CheckForDuplicateTXT(savePath + @"\" + GraphName + ".txt", defaultPath, GraphName), port, listOfPoints);
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => DrawLinearPart()));
                    return;
                }
               
            }
        }
      
        /// <summary>
        /// 
        /// 
        /// counting the lack of signal.
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
                settingsForm.Focus();
                settingsForm.BringToFront();
            }


        }

        private void planeGraph_Load(object sender, EventArgs e)
        {

        }

        private void startingRecordMenuB_Click(object sender, EventArgs e)
        {

        }
        LineItem selectionCurveBegin;
        LineItem selectionCurveEnd;

        public LineItem SelectionCurveBegin
        {
            get { return selectionCurveBegin; }
            set { selectionCurveBegin = value; }
        }
        public LineItem SelectionCurveEnd
        {
            get { return selectionCurveEnd; }
            set { selectionCurveEnd = value; }
        }

        /// <summary>
        /// Устанавливает кривую с определенным шаблоном и именем
        /// </summary>
        /// <param name="name">имя кривой</param>
        /// <param name="curve">переменная кривой для модификации</param>
        /// <returns></returns>
        public void setCurve(string name, ref LineItem curve)
        {
            PointPairList pointList = new PointPairList();
            curve = planeGraph.GraphPane.AddCurve(name, pointList, Color.Blue);
            curve.Symbol.Size = 10;
            curve.Symbol.Type = SymbolType.XCross;
            curve.Symbol.Fill = curve.Symbol.Fill;
        }

        public string ComputeClosestPoint(double x, double y)
        {
            double distanceToBegin = Math.Abs(x - selectionCurveBegin.Points[0].X);//Math.Sqrt((x - selectionCurveBegin.Points[0].X) * (x - selectionCurveBegin.Points[0].X) + (y - selectionCurveBegin.Points[0].Y) * (y - selectionCurveBegin.Points[0].Y));
            double distanceToEnd = Math.Abs(x - selectionCurveEnd.Points[0].X); //Math.Sqrt((x - selectionCurveEnd.Points[0].X) * (x - selectionCurveEnd.Points[0].X) + (y - selectionCurveEnd.Points[0].Y) * (y - selectionCurveEnd.Points[0].Y));
            if (distanceToBegin < distanceToEnd) return "Точка 1";
            else return "Точка 2";
        }

        private void planeGraph_MouseClick(object sender, MouseEventArgs e)
        {
           
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


        // switch (MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        //    {
        //        case DialogResult.Yes:
        //            FileOperations.SetVariables(this);
        //            break;
        //        case DialogResult.No:
        //            cancelEventArgs.Cancel = true;
        //            break;
        //}
        bool chooseMode = false;
        public bool ChooseMode
        {
            get { return chooseMode; }
            set { chooseMode = value; }
        }
        internal ChooseStressFlow readingStressFlowForm;
        private void planeGraph_KeyDown(object sender, KeyEventArgs e)
        {
            //if (chooseMode && e.KeyCode == Keys.Enter)
            //{
            //    if (!((selectionCurveBegin == null) && (selectionCurveEnd == null)))
            //    {
            //        yieldPoints = new PointPair[2];
            //        string coord = "";
            //        if (selectionCurveBegin != null)
            //        {
            //            coord += ("Точка 1 с координатами (" + selectionCurveBegin.Points[0].X + " , " + selectionCurveBegin.Points[0].Y + " )");
            //            yieldPoints[0] = selectionCurveBegin.Points[0];

            //        }
            //        if (selectionCurveEnd != null)
            //        {
            //            coord += ("Точка 2 с координатами (" + selectionCurveEnd.Points[0].X + " , " + selectionCurveEnd.Points[0].Y + " )");
            //            yieldPoints[1] = selectionCurveEnd.Points[0];
            //        }
            //        switch (MessageBox.Show("Вы выбрали " + coord + ". Вас устраивает выбор?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //        {
            //            case DialogResult.Yes:
            //                chooseMode = false;
            //                readingStressFlowForm.Visible = true;
            //                readingStressFlowForm.Show();
            //                break;
            //            case DialogResult.No:
            //                break;
            //        }
            //    }
            //    else MessageBox.Show("Выберите хотя бы одну точку и нажмите Enter");



            //}
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
        DynamicToolStripButton linearPart;
        internal DynamicToolStripButton LinearPart
        {
            get { return linearPart; }
            set { linearPart = value; }
        }
        LineItem aproximateLinearCurve = null;
        internal LineItem AproximateLinearCurve
        {
            get { return aproximateLinearCurve; }
            set { aproximateLinearCurve = value; }
        }
        public LineItem processedCurve = null;
        public LineItem processedCurve2 = null;
        internal LineItem secondDerivativeCurve = new LineItem("d1");
        public void DrawLinearPart()
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
                lineCurve.Label.IsVisible = false;
                LineItem firstDerivativeCurve = new LineItem("d1");
                firstDerivativeCurve.Tag = 5;
                LineItem firstMovingAverageCurve = new LineItem("mad1");
                firstMovingAverageCurve.Tag = 5;
                processedCurve = new LineItem("movingAverage1");
               
                processedCurve.Tag = 5;
                processedCurve2 = new LineItem("movingAverage2");
                processedCurve2.Tag = 5;
                double[] data = GraphProcessing.CurveToArray(curve, false);
   
                double[] movingAverage1 = GraphProcessing.MovingAverage(data, sensitivy);
                for (int i = 0; i < movingAverage1.Length - 1; i++)
                {
                    processedCurve2.AddPoint(curve.Points[i].X, movingAverage1[i]);
                }
                linearPart.curve.IsVisible = false;
                processedCurve = processedCurve2.Clone();

                GraphProcessing.DerivativeGraph(curve, ref firstDerivativeCurve);

                GraphProcessing.SecondDerivativeGraph(firstDerivativeCurve, ref secondDerivativeCurve);
                GraphProcessing.DerivativeGraph(processedCurve, ref firstMovingAverageCurve);
                LineItem tempCurve = new LineItem("temp");
                tempCurve.Tag = 5;
                LineItem secondMovingAverageCurve = new LineItem("sMAC");
                secondMovingAverageCurve.Tag = 5;
                GraphProcessing.DerivativeGraph(processedCurve2, ref tempCurve);
                GraphProcessing.DerivativeGraph(tempCurve, ref secondMovingAverageCurve);
                int[] bounds = GraphProcessing.CalculatePointsForLinear(curve, secondMovingAverageCurve, firstMovingAverageCurve);
                for (int i = bounds[0]; i < bounds[1]; i++) lineCurve.AddPoint(curve[i]);
                
                aproximateLinearCurve = null;  
                int begin = (int) bounds[0];
                int end = (int) bounds[1];
                buttons.Add(GraphProcessing.CreateCurve(ref aproximateLinearCurve, curvesDropDownBtn, planeGraph, "Линейный участок МНК", Color.Green, 2, SymbolType.Circle, Color.Green));
                //(int) curve.Points[begin].X (int) curve.Points[end].X
                // y= y1+(x-x1) (y2 - y1) / (x2-x1) ; y = k*(x-x1) + y1 = kx - (kx1 + y1)
                MyMath.leastSquaresBuild((int)curve.Points[begin].X, (int)curve.Points[end].X, lineCurve, ref aproximateLinearCurve, this);
                aproximateLinearCurve.Tag = 2;
                form.AproximateLinearCurve = aproximateLinearCurve;
                aproximateLinearCurve.IsVisible = false;
                aproximateLinearCurve.Label.IsVisible = false;
                lineCurve.Tag = 5;
                planeGraph.Refresh();
                GraphProcessing.UpdateGraph(planeGraph);
            }
            else
            {
                ErrorMessage form = new ErrorMessage("Нет графика на котором нужно найти линейный участок");
            }
           
  

            Task.Delay(1500);
            var customLineForm = new CustomLine(this);
            customLineForm.Show();
            customLineForm.Activate();
            customLineForm.Focus();
            customLineForm.BringToFront();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var newForm = new DerivateForm(this.form);
            newForm.Show();
        }

        private void resetB_Click(object sender, EventArgs e)
        {

        }

        private bool planeGraph_DoubleClickEvent(ZedGraphControl sender, MouseEventArgs e)
        {
           
            object nearestObject;
            int index;
            this.planeGraph.GraphPane.FindNearestObject(new PointF(e.X, e.Y), this.CreateGraphics(), out nearestObject, out index);
            if (nearestObject != null && nearestObject.GetType() == typeof(LineItem))
            {
                LineItem nearestLineItemObject = (LineItem)nearestObject;
                PointPair clickedPoint = nearestLineItemObject.Points[index];
                int i = 0;
                bool pointBelongToCurve = false;
                PointPairList temp = (PointPairList) curve.Points;
                if (temp.Contains(clickedPoint))
                {
                        if (selectionCurveBegin == null)
                        {
                            setCurve("Точка 1", ref selectionCurveBegin);
                            selectionCurveBegin.AddPoint(clickedPoint);
                            selectionCurveBegin.Label.IsVisible = false;
                            selectionCurveBegin.Tag = 0;

                        }
                        else if (selectionCurveEnd == null)
                        {
                            setCurve("Точка 2", ref selectionCurveEnd);
                            selectionCurveEnd.AddPoint(clickedPoint);
                            selectionCurveEnd.Label.IsVisible = false;
                            selectionCurveEnd.Tag = 0;
                        }
                        else
                        {
                            string curveName = ComputeClosestPoint(clickedPoint.X, clickedPoint.Y);
                            int pos = planeGraph.GraphPane.CurveList.IndexOf(curveName);
                            if (pos >= 0) planeGraph.GraphPane.CurveList.RemoveAt(pos);
                            LineItem curve = null;
                            setCurve(curveName, ref curve);
                            curve.AddPoint(clickedPoint);
                            curve.Label.IsVisible = false;
                            curve.Tag = 0;
                            if (curveName == "Точка 1") selectionCurveBegin = curve;
                            else if (curveName == "Точка 2") selectionCurveEnd = curve;
                        }
                    }
                    else
                    {
                        int posBegin = planeGraph.GraphPane.CurveList.IndexOf("Точка 1");

                        if (posBegin >= 0)
                        {
                            planeGraph.GraphPane.CurveList.RemoveAt(posBegin);
                            selectionCurveBegin = null;
                        }
                        int posEnd = planeGraph.GraphPane.CurveList.IndexOf("Точка 2");
                        if (posEnd >= 0)
                        {
                            planeGraph.GraphPane.CurveList.RemoveAt(posEnd);
                            selectionCurveEnd = null;
                        }
                }
            }
            else
            {
                int posBegin = planeGraph.GraphPane.CurveList.IndexOf("Точка 1");

                if (posBegin >= 0)
                {
                    planeGraph.GraphPane.CurveList.RemoveAt(posBegin);
                    selectionCurveBegin = null;
                }
                int posEnd = planeGraph.GraphPane.CurveList.IndexOf("Точка 2");
                if (posEnd >= 0)
                {
                    planeGraph.GraphPane.CurveList.RemoveAt(posEnd);
                    selectionCurveEnd = null;
                }
            }
                GraphProcessing.UpdateGraph(planeGraph);
           
            return false;
        }
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            switch (MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    FileOperations.SetVariables(this);
                    break;
                case DialogResult.No:
                    cancelEventArgs.Cancel = true;
                    break;
            }
        }

            private void MainProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var report = new MakeAWordDocumentForm(readingInOneSession, GetPath);
            report.Show();
        }

        private void planeGraph_DockChanged(object sender, EventArgs e)
        {

        }

        private void planeGraph_DoubleClick(object sender, EventArgs e)
        {
            
        }
        bool viewIsPressed = false;
        public bool ViewIsPressed
        {
            get { return viewIsPressed; }
            set { viewIsPressed = value; }
        }
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
     
            viewIsPressed = true;
            form.ReadingInput.Show();
            form.ReadingInput.Focus();
            form.ReadingInput.BringToFront();
            form.ReadingInput.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void planeGraph_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}





