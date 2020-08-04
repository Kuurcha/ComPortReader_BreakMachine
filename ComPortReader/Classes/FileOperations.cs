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
    }
}
