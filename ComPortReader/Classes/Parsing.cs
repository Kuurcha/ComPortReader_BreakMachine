using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Runtime.Remoting.Messaging;

namespace ComPortReader
{
    class Parsing
    {
        /// <summary>
        /// Check for default path and renames files (txt) if there is a duplicate with a same name
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="defaultPath">Default for the program folder for the saving</param>
        /// <param name="name">name which you want to set for your file "%PATH%\name" + counter + ".txt</param>
        /// <returns>A string with a different file name if duplicate was found, the same string that entered in other cases</returns>
        public static string CheckForDuplicateTXT(string path, string defaultPath, string name)
        {
            int counter = 1;
            if (path == defaultPath)
            {
                path += @"\" + name + ".txt";
            }
            while (File.Exists(path))
            {
                string temp = path.Remove(path.Length - 5);
                path = temp + counter + ".txt";
                counter++;
            }
            return path;
        }
        /// <summary>
        /// Check for default path and renames files (image) if there is a duplicate with a same name
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="defaultPath">Default for the program folder for the saving</param>
        /// <param name="name">name which you want to set for your file "%PATH%\name" + counter + ".txt</param>
        /// <returns>A string with a different file name if duplicate was found, the same string that entered in other cases</returns>
        public static string CheckForDuplicateImage(string path, string defaultPath, string name)
        {
            int counter = 1;
            if (path == defaultPath)
            {
                path += @"\" + name + ".png";
            }
            while (File.Exists(path))
            {
                string temp = path.Remove(path.Length - 5);
                path = temp + counter + ".png";
                counter++;
            }
            return path;
        }
        /// <summary>
        /// Writes everything from TwoCoordLinkedList to a string. As a result we should get string with all recorded data
        /// </summary>
        /// <param name="port">Port through which transfer is happening, it is required so that GetData wont fire if the port isn't open.</param>
        /// <param name="listOfPoints">Linked list with recieved data</param>
        /// <returns>String containing data from Linked List in a specific form, every node is transformed </returns>
        public static string GetData(SerialPort port, TwoCordLinkedList listOfPoints)
        {
            string s = "";
            if (port != null && port.IsOpen)
            {
                TwoCordLinkedList.Node temp = listOfPoints.Head.Prev; //Ставим ссылку на элемент перед головным.
                while (temp.Prev != listOfPoints.Head)
                {
                    s += "N = " + temp.X + " " + "F = " + temp.Y + " \r\n";
                    temp = temp.Prev; //Почемуму до последнего?
                }
            }
            return s;
        }
      
        internal static int GetLengthOfOneReading(string s)
        {
            int length = 0;
            int nCount = 0;
            while (length < s.Length-1 && nCount < 2)
            {
                if (s[length] == 'N') nCount++;
                length++;
            }
            return length-1;
        }
        /// <summary>
        /// Метод обратаывающий данные типа N= 000XX F= 000XX, получает число или 0, если значением является 0000
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <returns> Элемент списка содержащий две координаты: x и у.</returns>
        [STAThread]
        internal static TwoCordLinkedList.Node ProcessData(string s, double coefficient)
        {
            TwoCordLinkedList.Node output = null;
            if (s != null)
            {
                int counter = 0;
                bool zero = true;
                bool onlyZeroes = true;
                int maxZeroes = 5;
                byte zeroesCounter = 0;
                string[] sOutput = new string[2];
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Length != 0 && s[0] == 'N')
                    {
                        char pivot = s[i];
                        if (pivot == 'F') { zero = true; counter++; zeroesCounter = 0; onlyZeroes = true; maxZeroes = 4; }
                        if (pivot == 'N') { maxZeroes = 5; }
                        if (Char.IsNumber(pivot))
                        {
                            if (pivot != '0') { zero = false; }
                            if (!zero) { sOutput[counter] += pivot; onlyZeroes = false; }
                            if ((pivot == '0') && zero) { zeroesCounter++; }
                        }
                        if (zeroesCounter == maxZeroes && onlyZeroes) { sOutput[counter] = "0"; }
                    }
                }
                int xValue; int yValue;
                if (sOutput != null && int.TryParse(sOutput[0], out xValue) && int.TryParse(sOutput[1], out yValue)) { output = new TwoCordLinkedList.Node(xValue * coefficient, yValue * coefficient); }

            }
            return output;
        }
        /// <summary>
        /// Метод обратаывающий данные типа N= 000XX F= 000XX, получает число или 0, если значением является 0000
        /// </summary>
        /// <param name="s">Строка для обработки</param>
        /// <returns> Элемент списка содержащий две координаты: x и у.</returns>
        [STAThread]
        internal static TwoCordLinkedList.Node ProcessDataMK2(string s, double coefficient)
        {
            TwoCordLinkedList.Node output = null;
            if (s != null)
            {
                int counter = 0;
                string[] sOutput = new string[2];
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Length != 0 && s[0] == 'N')
                    {
                        char pivot = s[i];
                        if (pivot == 'F') {  counter++; }
                        if (Char.IsNumber(pivot))
                        {
                            sOutput[counter] += pivot;
                        }
                    }
                }
                int xValue; int yValue;
                if (sOutput != null && int.TryParse(sOutput[0], out xValue) && int.TryParse(sOutput[1], out yValue)) { output = new TwoCordLinkedList.Node(xValue * coefficient, yValue * coefficient); }

            }
            return output;
        }
    }
}
