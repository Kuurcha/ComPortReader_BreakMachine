using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
namespace ComPortReader.Classes
{
    class FileOperations
    {
        // обработчик события печати
        static void PrintPageHandler(object sender, PrintPageEventArgs e, Bitmap image)
        {
            // печать строки result
            e.Graphics.DrawImage(image, 0, 0);
        }
        public static void Printing(Bitmap image)
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


        /// <summary>
        /// Cохраняет текстовый файл по пути, и в случае если путь - дубликат, добавляет соотвествующую цифорку
        /// </summary>
        /// <param name="path"></param>
        public static string saveTextFile(string path, SerialPort port, TwoCordLinkedList listOfPoints)
        {
            string s = Parsing.GetData(port, listOfPoints);
            try
            {
                using (StreamWriter file = new StreamWriter(path))
                {

                    file.Write(s);
                    file.Close();
                }
            }
            catch (System.IO.DirectoryNotFoundException) { MessageBox.Show("System.IO.DirectoryNotFoundException"); }
            return path;
        }

        /// <summary>
        /// Создание файла конфигов
        /// </summary>
        public static void RecreateConfig(MainProgram form)
        {
            string fileName = Application.StartupPath + "\\config.cfg";
            using (FileStream fileStream = File.Create(fileName))
            {
                string path = Application.StartupPath;
                form.GetPath = path;
                form.leastSquares = true;
                form.Coefficent = 1;
                form.XAxisData = "N spins";
                form.YAxisData = "F Value";
                form.GraphName = "Имя маркировки";
                form.MaxXValue = 10;
                form.MinXValue = 0;
                form.MaxYValue = 10;
                form.MinYValue = 0;
                
                byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(path + "\r");
                fileStream.Write(bytes, 0, bytes.Length);
                byte[] bytes2 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("true\r");
                fileStream.Write(bytes2, 0, bytes2.Length);
                byte[] bytes3 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("1\r");
                fileStream.Write(bytes3, 0, bytes3.Length);
                byte[] bytes4 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("N spins\r");
                fileStream.Write(bytes4, 0, bytes4.Length);
                byte[] bytes5 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("F value\r");
                fileStream.Write(bytes5, 0, bytes5.Length);
                byte[] bytes6 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("Имя маркировки\r");
                fileStream.Write(bytes6, 0, bytes6.Length);
                byte[] bytes7 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(10.0 + "\r");
                fileStream.Write(bytes7, 0, bytes7.Length);
                byte[] bytes8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(0 + "\r");
                fileStream.Write(bytes8, 0, bytes8.Length);
                byte[] bytes9 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(10.0 + "\r");
                fileStream.Write(bytes9, 0, bytes9.Length);
                byte[] bytes10 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(0 + "\r");
                fileStream.Write(bytes10, 0, bytes10.Length);

            }
        }
        public static void SetVariables(MainProgram form)
        {
            string fileName = Application.StartupPath  + "\\config.cfg";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fileStream = File.Create(fileName))
            {
                
                byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.GetPath + "\r");
                fileStream.Write(bytes, 0, bytes.Length);
                byte[] bytes2 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.leastSquares + "\r");
                fileStream.Write(bytes2, 0, bytes2.Length);
                byte[] bytes3 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.Coefficent.ToString() + "\r");
                fileStream.Write(bytes3, 0, bytes3.Length);
                byte[] bytes4 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.XAxisData + "\r");
                fileStream.Write(bytes4, 0, bytes4.Length);
                byte[] bytes5 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.YAxisData + "\r");
                fileStream.Write(bytes5, 0, bytes5.Length);
                byte[] bytes6 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.GraphName + "\r");
                fileStream.Write(bytes6, 0, bytes6.Length);
                byte[] bytes7 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.MaxXValue.ToString() + "\r");
                fileStream.Write(bytes7, 0, bytes7.Length);
                byte[] bytes8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.MinXValue.ToString() + "\r");
                fileStream.Write(bytes8, 0, bytes8.Length);
                byte[] bytes9 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.MaxYValue.ToString() + "\r");
                fileStream.Write(bytes9, 0, bytes9.Length);
                byte[] bytes10 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(form.MinYValue.ToString() + "\r");
                fileStream.Write(bytes10, 0, bytes10.Length);
            }
        }


        /// <summary>
        /// Метод получающий настройки по заданному пути
        /// </summary>
        /// <param name="fileName">Путь к конфигу</param>
        public static void GetVariables(MainProgram form)
        {
            string fileName = Application.StartupPath + "\\config.cfg";
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader streamReader = File.OpenText(fileName))
                    {
                        List<string> list = new List<string>();
                        string text = "";
                        while ((text = streamReader.ReadLine()) != null)
                        {
                            list.Add(text);
                        }
                        form.GetPath = list[0];
                        double.TryParse(list[1], out double result);
                        form.Coefficent = result;
                        form.XAxisData = list[2];
                        form.YAxisData = list[3];
                        form.GraphName = list[4];
                        int.TryParse(list[5], out int intresult);
                        form.MaxXValue = intresult;
                        int.TryParse(list[6], out intresult);
                        form.MinXValue = intresult;
                        int.TryParse(list[7], out intresult);
                        form.MaxYValue = intresult;
                        int.TryParse(list[8], out intresult);
                        form.MinYValue = intresult;
                    }
                }
                else
                {
                    RecreateConfig(form);
                }
            }
            catch (Exception ex)
            {
                RecreateConfig(form);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
