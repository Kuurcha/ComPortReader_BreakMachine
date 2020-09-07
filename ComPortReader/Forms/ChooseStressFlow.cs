using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComPortReader.Classes;
using ZedGraph; 

namespace ComPortReader.Forms
{
    public partial class ChooseStressFlow : Form
    {

        string defaultMsg = "Выберите находимый параметр и способ его нахождения.";
        MainProgram form;
        public ChooseStressFlow(MainProgram form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void zeroTwoCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void zeroTwoCB_Click(object sender, EventArgs e)
        {
            zeroTwoCB.Checked = true;
            zeroFiveCB.Checked = false; 
        }

        private void zeroFiveCB_Click(object sender, EventArgs e)
        {
            zeroTwoCB.Checked = false;
            zeroFiveCB.Checked = true;
        }
        public void clear()
        {
            GraphProcessing.RemoveLine(PARALELL1_NAME, form);
            GraphProcessing.RemoveLine(PARALELL2_NAME, form);
            if (zeroTwoCB.Checked) GraphProcessing.RemoveLine(SIGMANZEROTWO, form);
            else GraphProcessing.RemoveLine(SIGMANZEROFIVE, form);
        }
        PointPair stressFlowPoint1 = null;
        PointPair stressFlowPoint2 = null;
        const string PARALELL1_NAME = "Параллель 1";
        const string PARALELL2_NAME = "Параллель 2";
        const string SIGMANZEROTWO = "Сигма 0.2";
        const string SIGMANZEROFIVE = "Сигма 0.5";
        private void manualBtn_Click(object sender, EventArgs e)
        {
            stressFlowPoint1 = null;
            stressFlowPoint2 = null;
            clear();
            Task.Delay(500);
            form.Focus();
            form.BringToFront();
            form.yieldPoints = null;
            string coord = "";
            if (!((form.SelectionCurveBegin == null) && (form.SelectionCurveEnd == null)))
            {
                form.yieldPoints = new PointPair[2];
             
                if (form.SelectionCurveBegin != null)
                {
                    coord += ("Точка 1 с координатами {" + form.SelectionCurveBegin.Points[0].X + "," + form.SelectionCurveBegin.Points[0].Y + "}");
                    form.yieldPoints[0] = form.SelectionCurveBegin.Points[0];

                }
                if (form.SelectionCurveEnd != null)
                {
                    coord += ("Точка 2 с координатами {" + form.SelectionCurveEnd.Points[0].X + "," + form.SelectionCurveEnd.Points[0].Y + "}");
                    form.yieldPoints[1] = form.SelectionCurveEnd.Points[0];
                }
        
            }
            else
            {
                coord = "ничего";
                MessageBox.Show("Выберите хотя бы одну точку и нажмите Enter");
            }
            msgLbl.Text = "Вы выбрали " + coord + ". Вас устраивает выбор?";
            if (form.yieldPoints!=null && form.yieldPoints[0]!=null) stressFlowPoint1 = new PointPair(form.yieldPoints[0].X, form.yieldPoints[0].Y);
            if (form.yieldPoints != null && form.yieldPoints[1] != null) stressFlowPoint2 = new PointPair(form.yieldPoints[1].X, form.yieldPoints[1].Y);
        }

        private void autoBtn_Click(object sender, EventArgs e)
        {
            
            stressFlowPoint1 = null;
            stressFlowPoint2 = null;
            clear();
            if (zeroFiveCB.Checked) stressFlowPoint1 = MyMath.Sigma(form.getCurve, new PointPair(form.AproximateLinearCurve[form.AproximateLinearCurve.Points.Count - 1]), form.AproximateLinearCurve, form.secondDerivativeCurve, form, false, SIGMANZEROFIVE);
            else stressFlowPoint1 = MyMath.Sigma(form.getCurve, new PointPair(form.AproximateLinearCurve[form.AproximateLinearCurve.Points.Count-1]), form.AproximateLinearCurve, form.secondDerivativeCurve, form, true, SIGMANZEROTWO);
            msgLbl.Text = defaultMsg + Environment.NewLine + "Предел текучести автоматически найден на {" + Math.Round(stressFlowPoint1.X,2) + " " + Math.Round(stressFlowPoint1.Y,2) + " }";
        }

        private void ChooseStressFlow_Load(object sender, EventArgs e)
        {
            
            msgLbl.Text = defaultMsg;
            base.Closing += OnClosing;
        }
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            switch (MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    GraphProcessing.OnClosingMethod(form);
                    break;
                case DialogResult.No:
                    cancelEventArgs.Cancel = true;
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (stressFlowPoint1!=null &&  stressFlowPoint2 != null)
            {
                form.yieldPoints = new PointPair[2];
                   form.yieldPoints[0] = stressFlowPoint1;
                form.yieldPoints[1] = stressFlowPoint2;
            }
            else if (stressFlowPoint1!=null)
            {
                form.yieldPoints = new PointPair[1];
                form.yieldPoints[0] = stressFlowPoint1;
            }
            else if (stressFlowPoint2 != null)
            {
                form.yieldPoints = new PointPair[1];
                form.yieldPoints[0] = stressFlowPoint2;
            }    

                form.ReadingInput.Visible = true;
            form.ReadingInput.Show();
            form.ReadingInput.BringToFront();
            if (stressFlowPoint1!=null || stressFlowPoint2 !=null)
            {
                base.Closing -= OnClosing;
                this.Close();
            }
            form.ReadingInput.PrepareNextForm();
        }
    }
}
