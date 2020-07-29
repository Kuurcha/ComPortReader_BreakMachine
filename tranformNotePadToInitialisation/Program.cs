using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace tranformNotePadToInitialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool zero = true;
            string path = @"d:\GraphDrawing\graphData.log";
            using (StreamReader sr = new StreamReader(path))
            {
                string text_in_file = " ";

                string fileName = Console.ReadLine();
                string pathNew = @"d:\GraphDrawing\" + fileName + ".log";
                if (!File.Exists(pathNew))
                {

                    StreamWriter sw = File.CreateText(pathNew);


                    int counter = 0;
                    sw.Write("{ ");
                    while (!sr.EndOfStream)
                    {
                        string newFile = " ";
                        counter++;
                        text_in_file = sr.ReadLine();
                        zero = true;

                        if (text_in_file.Length != 0 && text_in_file[0] == 'N')
                        {
                            newFile = "new Point ( ";
                            for (int i = 0; i < text_in_file.Length; i++)
                            {
                                char pivot = text_in_file[i];
                                if (Char.IsNumber(pivot))
                                {
                                    if (pivot != '0') zero = false;
                                    if (!zero)
                                    {
                                        newFile += pivot;
                                    }
                                }
                                if (pivot == 'F') { zero = true; newFile += " , "; };
                            }
                            newFile += " ), ";
                            sw.Write(newFile);
                        }

                    }
                    sw.Write(" }");
                    if ((counter - 5 % 10) == 0) { sw.WriteLine(); };
                    if ((counter % 200) == 0) { };
                }
                else { Console.WriteLine("Путь занят"); };

            }


            Console.ReadLine();

        }
        
    }
}
