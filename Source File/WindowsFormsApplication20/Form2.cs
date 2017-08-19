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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Close();
            f8.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            time.Enabled = true;
            pictureBox1.Image = Properties.Resources.xiyangyang;
           
        }

        private void time_Tick(object sender, EventArgs e)
        {
            //DateTime t = new DateTime();
            label2.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.huitailang;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.xiyangyang;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Close();
        }
    }
}
