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
    public partial class ErrorMessage : Form
    {
        string message = "default message";
        public ErrorMessage()
        {
            InitializeComponent();
        }
        public ErrorMessage(string message)
        {
            InitializeComponent();
            this.message = message;
        }

        private void errorMessage_Load(object sender, EventArgs e)
        {
            errorMesageLabel.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
