using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication20
{
    public partial class Form16 : Form
    {
        public Form4 ff;
        int counter = 0;//对应于核心程序中的counter，用于确定动态计算次数；
        int total = 0;//已经过去的时间；
        int read = 0;//timer1到时间后运行哪一块儿程序标志；
        int xin = -1;
        public Form16()
        {
            InitializeComponent();
        }
        //面板初始化；
        private void Form16_Load(object sender, EventArgs e)
        {
            //开始时间载入；
            label4.Text = System.DateTime.Now.ToString();
            label5.Text = "∞";
            //确定timer参数；
            timer1.Enabled = true;
            jishu.Enabled = true;
            timer1.Interval = 1000;
            jishu.Interval = 1000;
            total = 0;
            //processbar1设置；
            progressBar1.Enabled = true;
            progressBar1.Value = 0;
            
            //确定counter的值；
            //StreamReader sr = new StreamReader(@"G:\counter.txt");
            /*counter = int.Parse(sr.ReadLine());
            counter *= 2;       //由于有两个省，所以乘以2；*/
            //Thread.Sleep(500);
            //old = int.Parse(sr.ReadLine());
            //old = old * 12;
            //label5.Text ="大于"+ old.ToString();
            //sr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (read == 1)
            {
                StreamReader s2 = new StreamReader(@"shu.txt");
                string st = s2.ReadLine();
                if (st.Length > 0)
                {
                    xin = int.Parse(st);
                }
                progressBar1.Value =xin*100/counter;
                renew();
                s2.Close();
                if (progressBar1.Value==100)
                {
                    this.Close();
                }
            }
            if (read == 0)
            {
                checkmark();
            }
        }

        void renew()
        {
            if (xin > 0)
            {
                double a = (double)counter / xin;
                a *= total;
                a -= total;
                if (a < 0)
                { a = 0; }
                a = (int)a;
                label5.Text = a.ToString();
            }
        }

        void checkmark()
        {
            StreamReader p = new StreamReader(@"counter.txt");
            string ch;
            ch = p.ReadLine();
            if (ch.Length>0)
                {
                    counter = int.Parse(ch);
                    read = 1;
                    counter *= 2;
                }
            p.Close();
            
            //progressBar1.Value = 20;
            //read = 1;
        }
        //计时器到时间，总时间量加1；
        private void jishu_Tick(object sender, EventArgs e)
        {
            total++;
        }
        //界面退出时，将重要数据点清零，方便下次使用；
        private void Form16_FormClosed(object sender, FormClosedEventArgs e)
        {
            ff.Show();
            StreamWriter t2 = new StreamWriter(@"shu.txt");
            t2.WriteLine();
            t2.Close();
            StreamWriter t3 = new StreamWriter(@"counter.txt");
            t3.WriteLine();
            t3.Close();
        }
    }
}
