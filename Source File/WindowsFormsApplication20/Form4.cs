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
    public partial class Form4 : Form
    {
        int start = 9;
        public Form3 fr3;
        //确定输入车辆初始点是否正确；
        int check_input_data()
        {
            int total = 0;
            if (textBox1.Text!="A"&&textBox1.Text!="B")
            {
                total++;
            }
            if (textBox2.Text != "A" && textBox2.Text != "B")
            {
                total++;
            }
            if (textBox3.Text != "A" && textBox3.Text != "B")
            {
                total++;
            }
            if (textBox4.Text != "A" && textBox4.Text != "B")
            {
                total++;
            }
            if (textBox5.Text != "A" && textBox5.Text != "B")
            {
                total++;
            }
            if (textBox6.Text != "A" && textBox6.Text != "B")
            {
                total++;
            }
            if (textBox7.Text != "A" && textBox7.Text != "B")
            {
                total++;
            }
            if (textBox8.Text != "A" && textBox8.Text != "B")
            {
                total++;
            }
            if (textBox9.Text != "A" && textBox9.Text != "B")
            {
                total++;
            }
            return total;
        }

        public Form4()
        {
            InitializeComponent();
        }
        //平台初始化；
        private void Form4_Load(object sender, EventArgs e)
        {
            //车辆初始点：
            textBox1.Text = "A";
            textBox2.Text = "A";
            textBox3.Text = "A";
            textBox4.Text = "A";
            textBox5.Text = "B";
            textBox6.Text = "B";
            textBox7.Text = "B";
            textBox8.Text = "B";
            textBox9.Text = "B";
            //省1灾害点需求量：
            textBox10.Text = "50";
            textBox11.Text = "90";
            textBox12.Text = "110";
            textBox13.Text = "70";
            textBox14.Text = "80";
            //省2灾害点需求量：
            textBox19.Text = "100";
            textBox18.Text = "90";
            textBox17.Text = "115";
            textBox16.Text = "135";
            textBox15.Text = "80";
            textBox21.Text = "150";
            textBox20.Text = "110";
            //省1存货量：
            textBox25.Text = "50";
            textBox24.Text = "100";
            textBox23.Text = "150";
            //省2存货量：
            textBox29.Text = "0";
            textBox28.Text = "0";
            textBox27.Text = "40";
            textBox26.Text = "50";
            //运载量：
            textBox22.Text = "5";
            textBox30.Text = "3";
            //初始化次数 和 运算次数：
            comboBox1.Text = "5";
            comboBox2.Text = "5";
        }
        //退出键；
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //开始键；
        private void button2_Click(object sender, EventArgs e)
        {
            start=check_input_data();
            if (start != 0)
            {
                MessageBox.Show("初始点设置有问题！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                save_data();

                process1.StartInfo.FileName = @"Advanced 2 for test.exe";
                process1.StartInfo.UseShellExecute = false;
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                //MessageBox.Show("任务完成！","Finished",MessageBoxButtons.OK);
                //show_data();

                this.Hide();
                Form16 f16 = new Form16();
                f16.ff = this;
                f16.Show();
            }
        }
        //将应用到的值传给C++程序；
        void save_data()
        {
            StreamWriter sw = new StreamWriter(@"front.txt");
            sw.WriteLine(textBox1.Text);
            sw.WriteLine(textBox2.Text);
            sw.WriteLine(textBox3.Text);
            sw.WriteLine(textBox4.Text);
            sw.WriteLine(textBox5.Text);
            sw.WriteLine(textBox6.Text);
            sw.WriteLine(textBox7.Text);
            sw.WriteLine(textBox8.Text);
            sw.WriteLine(textBox9.Text);
            sw.WriteLine(textBox10.Text);
            sw.WriteLine(textBox11.Text);
            sw.WriteLine(textBox12.Text);
            sw.WriteLine(textBox13.Text);
            sw.WriteLine(textBox14.Text);
            sw.WriteLine(textBox19.Text); 
            sw.WriteLine(textBox18.Text);
            sw.WriteLine(textBox17.Text);
            sw.WriteLine(textBox16.Text);
            sw.WriteLine(textBox15.Text);
            sw.WriteLine(textBox21.Text);
            sw.WriteLine(textBox20.Text);
            sw.WriteLine(textBox25.Text);
            sw.WriteLine(textBox24.Text);
            sw.WriteLine(textBox23.Text);
            sw.WriteLine(textBox29.Text);
            sw.WriteLine(textBox28.Text);
            sw.WriteLine(textBox27.Text);
            sw.WriteLine(textBox26.Text);
            sw.WriteLine(textBox22.Text);
            sw.WriteLine(textBox30.Text);
            sw.WriteLine(comboBox1.Text);
            sw.WriteLine(comboBox2.Text);
            sw.Close();
        }

        /*void show_data()
        {
            StreamReader sr = new StreamReader(@"G:\jieguo.txt");
            string a=sr.ReadLine();
            sr.Close();
        }*/

        //重置按钮；
        private void button3_Click(object sender, EventArgs e)
        {
            //车辆初始点：
            textBox1.Text = "A";
            textBox2.Text = "A";
            textBox3.Text = "A";
            textBox4.Text = "A";
            textBox5.Text = "B";
            textBox6.Text = "B";
            textBox7.Text = "B";
            textBox8.Text = "B";
            textBox9.Text = "B";
            //省1灾害点需求量：
            textBox10.Text = "50";
            textBox11.Text = "90";
            textBox12.Text = "110";
            textBox13.Text = "70";
            textBox14.Text = "80";
            //省2灾害点需求量：
            textBox19.Text = "100";
            textBox18.Text = "90";
            textBox17.Text = "115";
            textBox16.Text = "135";
            textBox15.Text = "80";
            textBox21.Text = "150";
            textBox20.Text = "110";
            //省1存货量：
            textBox25.Text = "50";
            textBox24.Text = "100";
            textBox23.Text = "150";
            //省2存货量：
            textBox29.Text = "0";
            textBox28.Text = "0";
            textBox27.Text = "40";
            textBox26.Text = "50";
            //运载量：
            textBox22.Text = "5";
            textBox30.Text = "3";
            //初始化次数 和 运算次数：
            comboBox1.Text = "5";
            comboBox2.Text = "5";
        }
        //当C++进程执行完了以后现实的内容；
        private void process1_Exited(object sender, EventArgs e)
        {
           //// MessageBox.Show("Finished!","Ok!",MessageBoxButtons.OK);
           // this.Show();
        }
        //显示结果键；
        private void button4_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
        }
    }
}
