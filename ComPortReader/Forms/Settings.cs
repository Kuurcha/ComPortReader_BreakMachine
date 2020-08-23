using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using ZedGraph;

namespace ComPortReader
{
    public partial class Settings : Form
    {
        MainProgram mainForm;


        public Settings()
        {
            InitializeComponent();

        }
        public Settings(MainProgram form)
        {
            InitializeComponent();
            mainForm = form;
            this.BringToFront();
        }
        public bool SetGetCoefficentTBEnabled
        {
            get { return coefficientTB.Enabled; }
            set { coefficientTB.Enabled = value; }
        }
        private void settings_Load(object sender, EventArgs e)
        {
            sizeCB.Text = "4";
            coefficientTB.Text = mainForm.Coefficent.ToString();
            autosavePathTB.Text = mainForm.GetPath;
            xAxisNameTB.Text = mainForm.XAxisData;
            yAxisNameTB.Text = mainForm.YAxisData;
            graphNameLabelTB.Text = mainForm.GraphName;
            xMaxValueTb.Text = mainForm.MaxXValue.ToString();
            xMinValueTb.Text = mainForm.MinXValue.ToString();
            yMaxValueTb.Text = mainForm.MaxYValue.ToString();
            yMinValueTb.Text = mainForm.MinYValue.ToString();
            baudRateTB.Text = mainForm.MyBaudRate.ToString();
            parityTB.Text = ParityEnumToString((int)mainForm.MyParity);
            dataBitTB.Text = mainForm.MyDataBits.ToString();
            stopBitTB.Text = StopEnumToString(mainForm.MyStopBits);
            sensitivityTB.Text = mainForm.Sensitivy.ToString();
        }
        private SymbolType checkForSymbol()
        {
            SymbolType outPut = SymbolType.Circle;
            if (symbolCB.Text == "Звезда") outPut = SymbolType.Star;
            else if (symbolCB.Text == "Палка") outPut = SymbolType.HDash;
            else if (symbolCB.Text == "Линия") outPut = SymbolType.None;
            return outPut;
        }

        public StopBits StringToStopEnum(string enumS)
        {
            switch (enumS)
            {
                case "0":
                    return (StopBits)0;
                case "1":
                    return (StopBits)1;
                case "1.5":
                    return (StopBits)2;
                case "2":
                    return (StopBits)3;
                default:
                    return (StopBits)0;
            }
        }
        public string StopEnumToString(StopBits enumVar)
        {
            int enumInt = (int)enumVar;
            switch (enumInt)
            {
                case 0:
                    return "0";
                case 1:
                    return "1";
                case 2:
                    return "1.5";
                case 3:
                    return "2";
                default:
                    return "0";
            }
        }

        /// <summary>
        /// Метод для перевода из названия для пользовател в конкретный Enum состояния Parity.
        /// </summary>
        /// <param name="enumS">Строка из TextBox</param>
        /// <returns>Соответсвующий Enum</returns>
        private int StringToParityEnum(string enumS)
        {
            switch (enumS)
            {
                case "Отсуствует":
                    return 0;
                case "Всегда нечет":
                    return 1;
                case "Всегда чет":
                    return 2;
                case "Всегда 1":
                    return 3;
                case "Всегда 0":
                    return 4;
                default:
                    return -1;
            }
        }
        /// <summary>
        /// Метод для перевода из чисел в активное название в Textbox
        /// </summary>
        /// <param name="enumInt">Число из настроек COM порта</param>
        /// <returns>Соответсвующую текущую строку в Textbox</returns>
        private string ParityEnumToString(int enumInt)
        {
            switch (enumInt)
            {
                case 0:
                    return "Отсуствует";
                case 1:
                    return "Всегда нечет";
                case 2:
                    return "Всегда чет";
                case 3:
                    return "Всегда 1";
                case 4:
                    return "Всегда 0";
                default:
                    return "Неопознанная ошибка";
            }
        }
        private void applyChanges_Click(object sender, EventArgs e)
        {
            double xMin, xMax, yMin, yMax;
            bool throwError = false;
            string errorMessageString = "";
            double coefficient = 1.0;
            int baudRate, dataBit, sensitivity;
            if (double.TryParse(xMinValueTb.Text, out xMin) && double.TryParse(xMaxValueTb.Text, out xMax) && double.TryParse(yMinValueTb.Text, out yMin) && double.TryParse(yMaxValueTb.Text, out yMax))
            {
                mainForm.MinXValue = xMin;
                mainForm.MaxXValue = xMax;
                mainForm.MinYValue = yMin;
                mainForm.MaxYValue = yMax;
            }
            else
            {
                errorMessageString += " ";
                errorMessageString += "Неверный диапазон значений";
                throwError = true;
            }
            if (Directory.Exists(autosavePathTB.Text))
            {
                mainForm.savePath = autosavePathTB.Text;
            }
            else
            {
                errorMessageString += "\r\n ";
                errorMessageString += "Пути не существует";
                throwError = true;
            }
            if (double.TryParse(coefficientTB.Text, out coefficient) && coefficient > 0 && coefficient < 100000)
            {
                mainForm.Coefficent = coefficient;
                mainForm.ZGCInstance.GraphPane.XAxis.Scale.Min *= coefficient;
                mainForm.ZGCInstance.GraphPane.XAxis.Scale.Max *= coefficient;
                mainForm.ZGCInstance.GraphPane.YAxis.Scale.Min *= coefficient;
                mainForm.ZGCInstance.GraphPane.YAxis.Scale.Max *= coefficient;

            }
            else
            {
                errorMessageString += " \r\n ";
                errorMessageString += "Коэффициент принимает диапозон значений (0;100000) ";
                throwError = true;
            }
            if (!throwError)
            {

                mainForm.ZGCInstance.Refresh();
                mainForm.ZGCInstance.AxisChange();
                mainForm.ZGCInstance.GraphPane.XAxis.Title.Text = yAxisNameTB.Text;
                mainForm.ZGCInstance.GraphPane.YAxis.Title.Text = yAxisNameTB.Text;
                mainForm.ZGCInstance.GraphPane.Title.Text = graphNameLabelTB.Text;
            }
            else
            {
                ErrorMessage form = new ErrorMessage(errorMessageString);
                form.Show();
            }
            if (mainForm.getCurve != null)
            {
                mainForm.getCurve.Symbol.Type = checkForSymbol();
                mainForm.getCurve.Symbol.Size = int.Parse(sizeCB.Text);
            }
            if (int.TryParse(baudRateTB.Text, out baudRate) && int.TryParse(dataBitTB.Text, out dataBit) && int.TryParse(sensitivityTB.Text, out sensitivity))
            {
                mainForm.MyBaudRate = baudRate;
                mainForm.MyDataBits = dataBit;
                mainForm.Sensitivy = sensitivity;
            }
            mainForm.MyParity = (Parity)StringToParityEnum(parityTB.Text);
            mainForm.MyStopBits = StringToStopEnum(stopBitTB.Text);


            mainForm.ZGCInstance.Refresh();
            mainForm.ZGCInstance.AxisChange();

            // Установим масштаб по умолчанию для оси X
            mainForm.ZGCInstance.GraphPane.XAxis.Scale.MinAuto = true;
            mainForm.ZGCInstance.GraphPane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            mainForm.ZGCInstance.GraphPane.YAxis.Scale.MinAuto = true;
            mainForm.ZGCInstance.GraphPane.YAxis.Scale.MaxAuto = true;
        }

        private void graphNameLabelTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void xAxisNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void xMinValueTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void drawGraphB_Click(object sender, EventArgs e)
        {
            var newForm = new About();
            newForm.Show();
        }
       
       
        private void button1_Click(object sender, EventArgs e)
        {
                GraphProcessing.resetGraph(mainForm);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
        
        }

        private void yAxisNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void yAxisNameTB_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            Graphics g = this.CreateGraphics();
  

            //g.DrawRectangle(myPen, 0, 0, 10,10);
           /// g.DrawEllipse(myPen, draw);




        }

        private void afterSelectEventHandlerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void imageComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void sizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coefficientL_Click(object sender, EventArgs e)
        {

        }

        private void yAxisRangeLabel_Click(object sender, EventArgs e)
        {

        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.settingsForm = new Settings(mainForm);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void baudRateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataBitTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sensitivityTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Parsing.checkForDouble(e);
        }
    }
}
