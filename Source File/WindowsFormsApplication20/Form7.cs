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
    public partial class Form7 : Form
    {
        int a = 0;
        Form6 fr6 = new Form6();
        public Form7(Form6 f6)
        {
            fr6 = f6;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (a == 0)
            {
                pictureBox1.Image = Properties.Resources.a1;
            }
            else if (a == 1)
            {
                pictureBox1.Image = Properties.Resources.a4;
            }
            else if (a == 2)
            {
                pictureBox1.Image = Properties.Resources.a2;
            }
            else if (a == 3)
            {
                pictureBox1.Image = Properties.Resources.a5;
            }
            else if (a == 4)
            {
                pictureBox1.Image = Properties.Resources.a3;
            }
            else if (a == 5)
            {
                pictureBox1.Image = Properties.Resources.a6;
            }
            else
            {
                MessageBox.Show("Error!","The program has the error...",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            a++;
            if (a > 5)
            {
                a = 0;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.xiyangyang;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            fr6.Show();
            this.Close();
        }
    }
}
