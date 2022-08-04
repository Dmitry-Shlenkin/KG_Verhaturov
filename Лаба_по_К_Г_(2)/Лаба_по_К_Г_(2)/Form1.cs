using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_по_К_Г__2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Input_Class input_Output = new Input_Class();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            input_Output.Input(pictureBox1, trackBar3.Value, trackBar2.Value, trackBar1.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value, radioButton1);
            input_Output.Paint_Ortogonal(pictureBox1);
            input_Output.PaintComplex(pictureBox2);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            label6.Text = Convert.ToString(trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            label5.Text = Convert.ToString(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            label4.Text = Convert.ToString(trackBar3.Value);
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            label8.Text = Convert.ToString(trackBar4.Value);
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            label7.Text = Convert.ToString(trackBar5.Value);
        }
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
            label9.Text = Convert.ToString(trackBar6.Value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            label4.Text = Convert.ToString(trackBar3.Value);
        }
    }
}
