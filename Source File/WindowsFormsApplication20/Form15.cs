using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication20
{
    public partial class Form15 : Form
    {
        string stext;
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            StreamReader sr=new StreamReader(@"jieguo.txt",System.Text.Encoding.Default);
            string add;
            add = sr.ReadLine();
            while (add!=null)
            {
                textBox1.Text += add;
                textBox1.Text += "\r\n";
                add = sr.ReadLine();
            }
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printdialog = new PrintDialog();
            printdialog.Document = printDocument1;
            stext = textBox1.SelectedText;
            
            printDocument1.DocumentName = "Result";
            printdialog.AllowCurrentPage = true;
            printdialog.ShowHelp = true;
            //printDialog1.AllowSomePages = true;
            printdialog.AllowSelection = true;
            printdialog.AllowSomePages = true;
            if (printdialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    printDocument1.Print();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message, "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //MessageBox.Show(stext);
            e.Graphics.DrawString(stext, textBox1.Font, System.Drawing.Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
        }
    }
}
