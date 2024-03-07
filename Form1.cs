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


namespace Image_Downsizer
{
    public partial class Form1 : Form
    {
        private object imageByte;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUplode_Click(object sender, EventArgs e)
        {
            Downsize.uploadByte();

        }
    }
}
