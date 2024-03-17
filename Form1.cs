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

        public Form1()
        {
            InitializeComponent();
            textBox4 = new System.Windows.Forms.TextBox();
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUplode_Click(object sender, EventArgs e)
        {
            Downsize.uploadByte();
            currentTB.Text = Downsize.getDementions();
            
        }

        private void changeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int number = (int)numericUpDown1.Value;
                Console.WriteLine(number);
                Downsize.startProcess(number);
            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
