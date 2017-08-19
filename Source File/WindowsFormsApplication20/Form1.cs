using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.Opacity = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 0.9)
            {
                this.Opacity += 0.05;
            }
            else
            {
                this.Opacity += 0.01;
            }
            if (this.Opacity >= 1)
            {
                timer1.Enabled = false;
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }
    }
}
