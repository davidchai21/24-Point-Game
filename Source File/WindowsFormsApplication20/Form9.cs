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
    public partial class Form9 : Form
    {
        Form8 fr8 = new Form8();
        public Form9(Form8 f8)
        {
            fr8 = f8;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fr8.Show();
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
    }
}
