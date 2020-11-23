using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using ComPortReader.Classes;
using Xceed.Words.NET;
using Xceed.Document.NET;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection;

namespace ComPortReader.Forms
{
    public partial class MakeAWordDocumentForm : Form
    {
        List<ExperimentReading> readings;
        string defaultPath;
        string savePath;
        internal MakeAWordDocumentForm(List<ExperimentReading> readings, string defaultPath)
        {
            InitializeComponent();
            this.readings = readings;
            this.defaultPath = defaultPath;
            savePath = defaultPath;
            pathTB.Text = defaultPath;


        }

        private void makeAWordDocumentForm_Load(object sender, EventArgs e)
        {
            generalDateTB.Text = "От " + DateTime.Now;
            List<string[]> numbers = new List<string[]>();
            for (int i = 0; i < readings.Count; i++)
            {
                ExperimentReading currentReading = readings[i];
                string name = currentReading.metalMarking;
                bool alreadyContains = false;
                int j = 0;
                while (!alreadyContains && j < numbers.Count())
                {

                    if (numbers.ElementAt(j)[1] == name)
                    {
                        int a = int.Parse(numbers.ElementAt(j)[0]);
                        a++;
                        numbers.ElementAt(j)[0] = a.ToString();
                        alreadyContains = true;
                        break;
                    }
                    j++;
                }

                if (!alreadyContains) { numbers.Add(new string[] { "1", name }); }


                string forceAtStressPointsStr = "";
                if (currentReading.forceAtStressFlow[0] != null) { forceAtStressPointsStr += currentReading.forceAtStressFlow[0].ToString(); if (currentReading.forceAtStressFlow[1] != null) forceAtStressPointsStr += " , " + currentReading.forceAtStressFlow[1].ToString(); }
                else if (currentReading.forceAtStressFlow[1] != null) forceAtStressPointsStr += currentReading.forceAtStressFlow[1].ToString();
                string stressPointStr = "";
                if (currentReading.stressFlow[0] != null) { stressPointStr += currentReading.stressFlow[0].ToString(); if (currentReading.stressFlow[1] != null) stressPointStr += " , " + currentReading.stressFlow[1].ToString(); }
                else if (currentReading.stressFlow[1] != null) stressPointStr += currentReading.stressFlow[1].ToString();


                if (currentReading.type == "Плоская")
                {
                    
                    squareMetalSamplesTable.Rows.Add(currentReading.metalMarking, numbers.ElementAt(j)[0], currentReading.aDim.ToString("N2"), currentReading.bDim.ToString("N2"), currentReading.totalArea.ToString("N2"), currentReading.originalLength.ToString("N2"), currentReading.endLength.ToString("N2"), currentReading.maxForce, forceAtStressPointsStr, currentReading.tempTearResistance, stressPointStr, currentReading.relativeExpansion.ToString("N1"));
                    MetalMarkingsTB.Text += currentReading.metalMarking + " ";
                }

                if (currentReading.type == "Цилиндрическая")
                {
                    roundMetalSamplesTable.Rows.Add(currentReading.metalMarking, numbers.ElementAt(j)[0], currentReading.diameterBefore.ToString("N2"),  currentReading.totalArea.ToString("N2"), currentReading.diameterAfter.ToString("N2"), currentReading.originalLength.ToString("N2"), currentReading.endLength.ToString("N2"), currentReading.maxForce, forceAtStressPointsStr, currentReading.tempTearResistance, stressPointStr, currentReading.relativeExpansion.ToString("N1"), currentReading.relativeNarrowing.ToString("N1"));
                    MetalMarkingsTB.Text += currentReading.metalMarking + " ";
                }


            }
            
        }
        protected static Stream GetResourceStream(string resourcePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<string> resourceNames = new List<string>(assembly.GetManifestResourceNames());

            resourcePath = resourcePath.Replace(@"/", ".");
            resourcePath = resourceNames.FirstOrDefault(r => r.Contains(resourcePath));

            if (resourcePath == null)
                throw new FileNotFoundException("Resource not found");

            return assembly.GetManifestResourceStream(resourcePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                savePath = pathTB.Text;
                string fileName = Parsing.CheckForDuplicateDOCX(savePath, savePath, protocolNumTB.Text + " (" + MetalMarkingsTB.Text + ")");
                var doc = DocX.Create(fileName);



                Xceed.Document.NET.Formatting smallText = new Xceed.Document.NET.Formatting();
                smallText.FontColor = Color.Black;
                smallText.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
                smallText.Size = 11;
                smallText.Bold = false;
                smallText.Position = 1;


                Xceed.Document.NET.Formatting boldSmall = new Xceed.Document.NET.Formatting();
                boldSmall.FontColor = Color.Black;
                boldSmall.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
                boldSmall.Size = 11;
                boldSmall.Bold = true;
                boldSmall.Position = 1;



                doc.PageLayout.Orientation = Xceed.Document.NET.Orientation.Landscape;
                Xceed.Document.NET.Formatting bold = new Xceed.Document.NET.Formatting();
                bold.FontColor = Color.Black;
                bold.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
                bold.Size = 12;
                bold.Bold = true;
                bold.Position = 1;




                Xceed.Document.NET.Formatting defaultText = new Xceed.Document.NET.Formatting();
                defaultText.FontColor = Color.Black;
                defaultText.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
                defaultText.Size = 12;
                defaultText.Bold = false;
                defaultText.Position = 1;






                doc.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"), 12, Color.Black);

                doc.InsertParagraph(protocolNumTB.Text, false, bold).Alignment = Xceed.Document.NET.Alignment.center;
                doc.InsertParagraph(generalDateTB.Text, false, bold).Alignment = Xceed.Document.NET.Alignment.center;
                doc.InsertParagraph(experimentsForTB.Text, false, bold).Alignment = Xceed.Document.NET.Alignment.center;
                var l1 = doc.InsertParagraph(label1.Text, false, bold);
                l1.Append(" " + experimentMethods.Text, defaultText);
                doc.InsertParagraph();
                var l2 = doc.InsertParagraph(label2.Text, false, bold);
                l2.Append(" " + applicationTB.Text, defaultText);
                var l3 = doc.InsertParagraph(label3.Text, false, bold);
                l3.Append(" " + recieveDataTB.Text, defaultText);
                doc.InsertParagraph();
                var l4 = doc.InsertParagraph(label4.Text, false, bold);
                l4.Append(" " + nameAndAdressTB.Text, defaultText);

                var l5 = doc.InsertParagraph(label5.Text, false, bold);
                l5.Append(" " + objectOfTheExperimentTB.Text, defaultText);
                var l6 = doc.InsertParagraph(label6.Text, false, bold);
                l6.Append(" " + MetalMarkingsTB.Text, defaultText);
                doc.InsertParagraph();

                var l7 = doc.InsertParagraph(label7.Text, false, bold);

                Xceed.Document.NET.Table infoData = doc.AddTable(informationData.Rows.Count, 4);


                infoData.Rows[0].Cells[0].InsertParagraph("Объекты испытаний", false, bold);
                infoData.Rows[0].Cells[0].Width += 30;
                infoData.Rows[0].Cells[1].InsertParagraph("Маркировка", false, bold);
                infoData.Rows[0].Cells[2].InsertParagraph("Марка стали", false, bold);
                infoData.Rows[0].Cells[3].InsertParagraph("Сортамент, мм", false, bold);

                for (int i = 0; i < informationData.Rows.Count - 1; i++)
                {
                    if (informationData.Rows[i].Cells[0].Value == null || informationData.Rows[i].Cells[1].Value == null || informationData.Rows[i].Cells[2].Value == null || informationData.Rows[i].Cells[3].Value == null)
                        MessageBox.Show("Проверьте что все значения в ячейках заполнены. (кроме последней строки) Для того чтоб заполнить ячейку после ввода нажмите Enter");
                    else
                    {
                        infoData.Rows[i].Cells[0].InsertParagraph(informationData.Rows[i+1].Cells[0].Value.ToString(), false, defaultText);
                        infoData.Rows[i].Cells[1].InsertParagraph(informationData.Rows[i+1].Cells[1].Value.ToString(), false, defaultText).Alignment = Xceed.Document.NET.Alignment.center;
                        infoData.Rows[i].Cells[2].InsertParagraph(informationData.Rows[i+1].Cells[2].Value.ToString(), false, defaultText).Alignment = Xceed.Document.NET.Alignment.center;
                        infoData.Rows[i].Cells[3].InsertParagraph(informationData.Rows[i+1].Cells[3].Value.ToString(), false, defaultText).Alignment = Xceed.Document.NET.Alignment.center;
                    }

                }


                doc.InsertTable(infoData);
                doc.InsertParagraph();

                var l8 = doc.InsertParagraph(label8.Text, false, bold);
                l8.Append(" " + experimentDateTB.Text, defaultText);
                doc.InsertSectionPageBreak();
                doc.InsertParagraph();
                var l9 = doc.InsertParagraph(label9.Text, false, bold);


                Xceed.Document.NET.Table deviceInfo = doc.AddTable(1, 1);
                deviceInfo.Rows[0].Cells[0].InsertParagraph(deviceInfoTB.Text, false, defaultText);
                deviceInfo.Rows[0].Cells[0].Width = doc.PageWidth;
                doc.InsertTable(deviceInfo);
                doc.InsertParagraph();

                var l10 = doc.InsertParagraph(label10.Text, false, bold);
                doc.InsertParagraph("\t" + temperatureTB.Text, false, defaultText);
                doc.InsertParagraph("\t" + musicalTB.Text, false, defaultText);

                doc.InsertSectionPageBreak();
                var l13 = doc.InsertParagraph(label11.Text, false, bold);
                if (squareMetalSamplesTable.Rows.Count > 1)
                {
                    Xceed.Document.NET.Table squareMetalSamplesTableData = doc.AddTable(squareMetalSamplesTable.Rows.Count, squareMetalSamplesTable.Columns.Count - 1);


                    for (int i = 0; i < squareMetalSamplesTable.RowCount; i++)
                    {
                        for (int j = 0; j < squareMetalSamplesTable.Columns.Count - 1; j++)
                        {
                            if (i == 0)
                            {
                                string tempStr = squareMetalSamplesTable.Columns[j].HeaderText;


                                squareMetalSamplesTableData.Rows[i].Cells[j].InsertParagraph(tempStr, false, boldSmall);

                            }
                            else
                            {
                                squareMetalSamplesTableData.Rows[i].Cells[j].InsertParagraph(squareMetalSamplesTable.Rows[i - 1].Cells[j].Value.ToString(), false, smallText);

                            }

                        }
                    }
                    doc.InsertTable(squareMetalSamplesTableData);
                    doc.InsertSectionPageBreak();
                }
                if (roundMetalSamplesTable.Rows.Count > 1)
                {
                    Xceed.Document.NET.Table roundMetalSamplesTableData = doc.AddTable(roundMetalSamplesTable.Rows.Count, roundMetalSamplesTable.Columns.Count);


                    for (int i = 0; i < roundMetalSamplesTable.RowCount; i++)
                    {
                        for (int j = 0; j < roundMetalSamplesTable.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                string tempStr = roundMetalSamplesTable.Columns[j].HeaderText;


                                roundMetalSamplesTableData.Rows[i].Cells[j].InsertParagraph(tempStr, false, boldSmall);

                            }
                            else
                            {
                                roundMetalSamplesTableData.Rows[i].Cells[j].InsertParagraph(roundMetalSamplesTable.Rows[i - 1].Cells[j].Value.ToString(), false, smallText);

                            }

                        }
                    }
                    doc.InsertTable(roundMetalSamplesTableData);
                }








                doc.AddHeaders();
                doc.DifferentFirstPage = true;
                boldSmall.Size = 10;
                smallText.Size = 10;


                var headerDefault = doc.Headers.Odd;




                Bitmap bmp = new Bitmap(ComPortReader.Properties.Resources.ИТ_Сервис);
                var image = doc.AddImage(GetResourceStream(@"ИТ_Сервис"));
                var picture = image.CreatePicture(196 / 3, 401 / 3);

                var image2 = doc.AddImage(GetResourceStream(@"Визитка"));
                var picture2 = image2.CreatePicture(261 / 3, 818 / 3);

                //var headerFirstParagraph = doc.Headers.First.InsertParagraph();
                //headerFirstParagraph.InsertPicture(picture);
                //headerFirstParagraph.InsertParagraphBeforeSelf(doc.InsertParagraph());


                var headerDefault1 = doc.Headers.First;
                Paragraph hp = headerDefault1.Paragraphs.First();
                hp.InsertPicture(picture, 0);
                hp.Append("                                                                                                 ");
                hp.AppendPicture(picture2);


                doc.Headers.First.InsertParagraph("Испытательный центр", false, boldSmall).Alignment = Xceed.Document.NET.Alignment.center;
                doc.Headers.First.InsertParagraph("443036, г.Самара, Железнодорожный Район, Набережная реки Самара, дом 1", false, smallText).Alignment = Xceed.Document.NET.Alignment.center;
                doc.Headers.First.InsertParagraph("______________________________________________________________________________________________________________________");

                doc.DifferentOddAndEvenPages = false;
                doc.AddFooters();


                Paragraph tempParagraph1 = doc.Footers.First.InsertParagraph(" из ");
                tempParagraph1.Append("").InsertPageCount(PageNumberFormat.normal, 4);
                tempParagraph1.Append("").InsertPageNumber(PageNumberFormat.normal, 0);

                Paragraph tempParagraph2 = doc.Footers.Odd.InsertParagraph(" из ");
                tempParagraph2.Append("").InsertPageCount(PageNumberFormat.normal, 4);
                tempParagraph2.Append("").InsertPageNumber(PageNumberFormat.normal, 0);
                //tempParagraph.AppendLine(" из ").InsertPageCount(PageNumberFormat.normal, 6);

                string info = this.protocolNumTB.Text + " " + generalDateTB.Text;
                doc.Footers.First.InsertParagraph(info);
                doc.Footers.First.InsertParagraph("Не может быть частично и полностью воспроизведен без письменного разрешения испытательного центра");

                doc.Footers.Odd.InsertParagraph(info);
                doc.Footers.Odd.InsertParagraph("Не может быть частично и полностью воспроизведен без письменного разрешения испытательного центра");


                doc.Save();

                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex1)
                { MessageBox.Show(ex1.ToString()); }
            }
            catch (Exception ex)
            {
                if (ex is System.IO.DirectoryNotFoundException) MessageBox.Show("Неверный путь: " + ex.Message);
                else MessageBox.Show(ex.Message);
            }
        }
        private void MetalMarkings_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    pathTB.Text = fbd.SelectedPath;
                }
                
            }
            
        }
    }
}

