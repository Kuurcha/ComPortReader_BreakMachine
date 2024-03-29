﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ComPortReader.Forms
{
    public partial class FirstInput : Form
    {
        MainProgram form;
        public FirstInput(MainProgram form)
        {

            InitializeComponent();
            this.form = form;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeCB.SelectedItem.ToString() == "Плоская")
            {
                bDimTB.Enabled = true;
                bDimTB.Visible = true;
                secondInputSizeLabel.Visible = true;
                secondInputSizeLabel.Text = "Ширина";
                firstInputSizeLabel.Text = "Длина";
                bDimTB.ReadOnly = false;
                bDimTB.Text = "";
            }
            if (typeCB.SelectedItem.ToString() == "Цилиндрическая")
            {
                bDimTB.ReadOnly = true;
                firstInputSizeLabel.Text = "Диаметр до разрыва";
                secondInputSizeLabel.Text = "Диаметр после разрыва";
                bDimTB.Text = "";

            }

        }

        public static void ShowDialogueBox(MainProgram form)
        {
            switch (MessageBox.Show("Чтение показаний закончились. Вы хотите еще один эксперимент перед формированием отчета?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    form.ReadingInput.DestroyMe();
                    form.ReadingInput = null;          
                    form.ReadingInput = new FirstInput(form);
                    form.ReadingInput.Show();
                    form.ReadingInput.Focus();
                    form.ReadingInput.BringToFront();
                    form.SelectionCurveEnd = null;
                    form.SelectionCurveBegin = null;
                    form.ViewIsPressed = false;
                    break;

                case DialogResult.No:

                    var report = new MakeAWordDocumentForm(form.readingInOneSession, form.GetPath);
                    report.Show();
                    form.showWindow.Enabled = false;

                    break;
            }
        }
        public void PrepareNextForm()
        {
            aDimTB.ReadOnly = true;
            bDimTB.ReadOnly = true;
            startLength.ReadOnly = true;
            typeCB.Enabled = false;
            markingTB.ReadOnly = true;
            endLengthTB.ReadOnly = false;
          

            if (typeCB.Text == "Плоская") bDimTB.ReadOnly = true;
            else { bDimTB.ReadOnly = false; }
        }
        internal void DestroyMe()
        {
            this.Close();
            this.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool error = false;
             double aDimnesion = 0, bDimension = 0, originalLength = 0, endLength = 0, maxForce = 0;
            if (endLengthTB.ReadOnly)
            {
                if (double.TryParse(aDimTB.Text, out aDimnesion) && (double.TryParse(bDimTB.Text, out bDimension) | bDimTB.ReadOnly) && double.TryParse(startLength.Text, out originalLength))
                {
                    if (!form.Port.IsOpen)
                    {
                        try
                        {
                            form.Port.Open();                     
                        }
                        catch (System.UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); error = true; }
                    }
                    if (!error)
                    {
                        form.aDim = aDimnesion;
                        form.bDim = bDimension;
                        form.originalLength = originalLength;
                        form.metalMarking = markingTB.Text;
                        form.type = typeCB.Text;

                        form.ZGCInstance.GraphPane.Title.Text = markingTB.Text;
                        this.Visible = false;

                        GraphProcessing.resetGraph(form);
                        form.subscribe();
                    }
                   

                }
                else
                {
                    MessageBox.Show("Неверно введены параметры.");
                }
            }
            else        
            {

                if (double.TryParse(endLengthTB.Text, out endLength) && double.TryParse(bDimTB.Text, out bDimension))
                {
                    if (form.ViewIsPressed)
                    {
                        form.readingInOneSession.RemoveAt(form.readingInOneSession.Count - 1);
                    }
                        double max = Double.MinValue;
                        for (int i = 0; i < form.getCurve.Points.Count; i++) if (form.getCurve.Points[i].Y > max) max = form.getCurve.Points[i].Y;
                        maxForce = max;



                        form.endLength = Math.Round(endLength, 2);
                        form.originalLength = Math.Round(form.originalLength, 2);
                        form.maxForce = (int)maxForce;

                        form.relativeExpansion = 1;
                        form.tempTearResistance = 1;


                        form.stressFlow = new int?[2];
                        form.forceAtStressFlow = new int?[2];
                        for (int i = 0; i < form.yieldPoints.Length; i++) if (form.yieldPoints[i] != null) form.forceAtStressFlow[i] = (int?)Math.Round((form.yieldPoints[i].Y));
                        form.relativeExpansion = Math.Abs(Math.Round((((form.endLength / form.originalLength) - 1) * 100), 1));
                        if (form.type == "Плоская")
                        {

                            form.aDim = Math.Round(form.aDim, 2);
                            form.bDim = Math.Round(form.bDim, 2);
                            form.totalArea = Math.Round(form.aDim * form.bDim, 2);
                            for (int i = 0; i < form.forceAtStressFlow.Length; i++) if (form.forceAtStressFlow[i] != null) form.stressFlow[i] = (int?)(form.forceAtStressFlow[i] / form.totalArea);
                            form.tempTearResistance = Math.Round(maxForce / form.totalArea);
                            form.readingInOneSession.Add(new Classes.ExperimentReading(form.metalMarking, form.aDim, form.bDim, form.totalArea, form.originalLength, form.endLength, form.maxForce, form.forceAtStressFlow, form.stressFlow, form.tempTearResistance, form.relativeExpansion, form.yieldPoints));
                        }
                        if (form.type == "Цилиндрическая")
                        {
                            form.bDim = bDimension;
                            form.diameterAfter = Math.Round(bDimension, 2);
                            form.diameterBefore = Math.Round(form.aDim, 2);
                            form.totalArea = Math.Round(((Math.PI * form.diameterBefore * form.diameterBefore) / 4), 2);
                            for (int i = 0; i < form.forceAtStressFlow.Length; i++) if (form.forceAtStressFlow[i] != null) form.stressFlow[i] = (int?)(form.forceAtStressFlow[i] / form.totalArea);
                            form.tempTearResistance = Math.Round(maxForce / form.totalArea);

                            form.relativeNarrowing = 100 * Math.Abs(Math.Round(((((Math.PI * form.diameterAfter * form.diameterAfter)/4) / form.totalArea)), 1));
                            form.readingInOneSession.Add(new Classes.ExperimentReading(form.metalMarking, form.aDim, form.bDim, form.totalArea, form.originalLength, form.endLength, form.maxForce, form.forceAtStressFlow, form.stressFlow, form.tempTearResistance, form.relativeExpansion, form.relativeNarrowing, form.yieldPoints));
                        }

                        int pos = form.ZGCInstance.GraphPane.CurveList.IndexOf("Точка 1");
                        if (pos > 0) form.ZGCInstance.GraphPane.CurveList.RemoveAt(pos);

                        int pos2 = form.ZGCInstance.GraphPane.CurveList.IndexOf("Точка 2");
                        if (pos2 > 0) form.ZGCInstance.GraphPane.CurveList.RemoveAt(pos2);



                        double coefOfDiv = Math.Abs((form.originalLength - form.endLength) / (form.IntersectionPointEnd - form.IntersectionPointBegin));
                        double distance = form.IntersectionPointEnd;
                        double distancePositive = form.originalLength;
                        foreach (LineItem elem in form.ZGCInstance.GraphPane.CurveList)
                        {
                            for (int i = 0; i < elem.Points.Count; i++)
                            {
                                elem[i].X -= distance;
                                elem[i].X *= coefOfDiv;
                                elem[i].X += distancePositive;
                                form.ZGCInstance.GraphPane.XAxis.Title.Text = "L, мм";
                            }
                        }
                        GraphProcessing.UpdateGraph(form.ZGCInstance);

                        //form.MinXValue = form.originalLength;
                        //form.MaxXValue = form.endLength;
                        //form.MinYValue = 0;
                        //int maxYValueLocal = Int32.MinValue;
                        //for (int i = 0; i < form.getCurve.Points.Count; i++) if (form.getCurve[i].Y > maxYValueLocal) maxYValueLocal =  (int) form.getCurve[i].Y;
                        //form.MaxYValue = 1.2* maxYValueLocal;

                        //form.ZGCInstance.GraphPane.YAxis.MajorGrid.DashOff = (float) form.MaxYValue/10;
                        //form.ZGCInstance.GraphPane.XAxis.MajorGrid.DashOff = (float)form.MaxXValue /10;
                        form.ZGCInstance.RestoreScale(form.ZGCInstance.GraphPane);
                        GraphProcessing.UpdateGraph(form.ZGCInstance);


                        try
                        {
                            Bitmap imageOfGraph = form.ZGCInstance.GraphPane.GetImage();
                            Graphics g = Graphics.FromImage(imageOfGraph);
                            Bitmap temp = imageOfGraph;
                            temp.Save(Parsing.CheckForDuplicateImage(form.savePath, form.savePath, form.GraphName), System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                      
                        ShowDialogueBox(form);
                    
                   
                


                }
            }
          
        }

        private void startLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            Parsing.checkForDouble(e);
        }

        private void sizeATB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Parsing.checkForDouble(e);
        }

        private void sizeBTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Parsing.checkForDouble(e);
        }

        private void FirstInput_Load(object sender, EventArgs e)
        {
            typeCB.SelectedIndex = 0;
            base.Closing += OnClosing;
        }
        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            cancelEventArgs.Cancel = true;
            this.Visible = false;
            //switch (MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //{
            //    case DialogResult.Yes:
            //        FileOperations.SetVariables(this);
            //        break;
            //    case DialogResult.No:
            //        cancelEventArgs.Cancel = true;
            //        break;
            //}
        }

        private void endLengthTB_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void endLengthTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Parsing.checkForDouble(e);
        }

        private void maxForce_KeyPress(object sender, KeyPressEventArgs e)
        {
            Parsing.checkForDouble(e);
        }

        private void FirstInput_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
    }
}
