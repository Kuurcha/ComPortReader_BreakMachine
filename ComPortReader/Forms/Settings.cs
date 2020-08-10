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
        }
        private SymbolType checkForSymbol()
        {
            SymbolType outPut = SymbolType.Circle;
            if (symbolCB.Text == "Звезда") outPut = SymbolType.Star;
            else if (symbolCB.Text == "Палка") outPut = SymbolType.HDash;
            else if (symbolCB.Text == "Линия") outPut = SymbolType.None;
            return outPut;
        }
        private void applyChanges_Click(object sender, EventArgs e)
        {
            double xMin, xMax, yMin, yMax;
            bool throwError = false;
            string errorMessageString = "";
            double coefficient = 1.0;
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
            mainForm.getCurve.Symbol.Type = checkForSymbol();
            mainForm.getCurve.Symbol.Size = int.Parse(sizeCB.Text);
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
        public void RestoreBackToDefault()
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
            // Установим масштаб по умолчанию для оси X
            mainForm.ZGCInstance.GraphPane.XAxis.Scale.MinAuto = true;
            mainForm.ZGCInstance.GraphPane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            mainForm.ZGCInstance.GraphPane.YAxis.Scale.MinAuto = true;
            mainForm.ZGCInstance.GraphPane.YAxis.Scale.MaxAuto = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RestoreBackToDefault();
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
    }
}
