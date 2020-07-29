using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComPortReader
{
    public partial class About : Form
    {
        MainProgram mainForm;
        public About()
        {
            InitializeComponent();
        }
        public About (MainProgram form)
        {
            InitializeComponent();
            mainForm = form;
        }
        private void about_Load(object sender, EventArgs e)
        {
            infoL.Text = "Программа считывает текстовые данные с COM порта, сортирует данные + \r\n типа N= 000XX F= 000YY, где 4 ноля и отсуствие цифры далее означает 0. + \r\n после чего строит по числам график с помощью библиотеки ZedGraph";
        }

        private void versionL_Click(object sender, EventArgs e)
        {
        }
    }
}
