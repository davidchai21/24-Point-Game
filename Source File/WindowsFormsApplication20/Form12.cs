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
    public partial class Form12 : Form
    {
        int choice = -1;
        int ok = 0;
        int combit = -1;
        int ren = 0;
        int diannao = 0;
        int total = 0;//游戏总共进行的盘数；
        public Form6 fr6 = new Form6();
        public Form12(Form6 f6)
        {
            fr6 = f6;
            InitializeComponent();
        }
        //初始化设置；
        private void Form12_Load(object sender, EventArgs e)
        {
            label1.Text = "   你有 Ipad，我有 Upad\n欢迎使用Upad之剪刀石头布！";
            timer1.Enabled = true;
            comboBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button4.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            pictureBox4.Image = Properties.Resources.none;
            pictureBox5.Image = Properties.Resources.none;
            pictureBox1.Image = Properties.Resources.stone;
            pictureBox2.Image = Properties.Resources.scissor;
            pictureBox3.Image = Properties.Resources.palm;
            comboBox1.Text = "娱乐模式";
        }
        //返回用户选择界面；
        private void button1_Click(object sender, EventArgs e)
        {
            fr6.Show();
            this.Close();
        }
        //主界面开始显示；
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button2.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            label1.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            comboBox1.Visible = true;
        }
        //帮助弹出；
        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }
        //检查用户是否选择出的内容；
        int check_option()
        {
            if (choice < 1 || choice > 3)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        //电脑该出什么确定；
        void ran_com()
        {
            Random pp = new Random();
            int a = pp.Next(1,4);
            switch (a)
            {
                case 1: combit = 1; break;
                case 2: combit = 2; break;
                case 3: combit = 3; break;
                default:
                    {
                        combit = -1;
                        MessageBox.Show("Error!", "cao!",MessageBoxButtons.OK);
                        break;
                    }
            }
        }
        //进行一次比试；
        void once()
        {
            if (combit == 1)
            {
                pictureBox5.Image = Properties.Resources.stone;
                if (choice == 2)
                {
                    pictureBox4.Image = Properties.Resources.scissor;
                    diannao++;
                }
                else if (choice == 3)
                {
                    pictureBox4.Image = Properties.Resources.palm;
                    ren++;
                }
                else if (choice == 1)
                {
                    pictureBox4.Image = Properties.Resources.stone;
                    Form14 f14 = new Form14();
                    f14.Show();
                }
                else
                {
                    MessageBox.Show("Eoor!","quququ",MessageBoxButtons.OK);
                }
            }
            else if (combit == 2)
            {
                pictureBox5.Image = Properties.Resources.scissor;
                if (choice == 3)
                {
                    pictureBox4.Image = Properties.Resources.palm;
                    diannao++;
                }
                else if (choice == 1)
                {
                    pictureBox4.Image = Properties.Resources.stone;
                    ren++;
                }
                else if (choice == 2)
                {
                    pictureBox4.Image = Properties.Resources.scissor;
                    Form14 f14 = new Form14();
                    f14.Show();
                }
                else
                {
                    MessageBox.Show("Eoor!", "quququ", MessageBoxButtons.OK);
                }
            }
            else if (combit == 3)
            {
                pictureBox5.Image = Properties.Resources.palm;
                if (choice == 1)
                {
                    pictureBox4.Image = Properties.Resources.stone;
                    diannao++;
                }
                else if (choice == 2)
                {
                    pictureBox4.Image = Properties.Resources.scissor;
                    ren++;
                }
                else if (choice == 3)
                {
                    pictureBox4.Image = Properties.Resources.palm;
                    Form14 f14 = new Form14();
                    f14.Show();
                }
                else
                {
                    MessageBox.Show("Eoor!", "quququ", MessageBoxButtons.OK);
                }
            }
            else 
            {
                MessageBox.Show("额……","Error..",MessageBoxButtons.OK);
            }
        }
        //确定游戏模式，返回值为游戏最大进行盘数；
        int judgetime()
        {
            int m = -9;
            if (comboBox1.Text == "娱乐模式")
            {
                m = 32000;
            }
            else if (comboBox1.Text == "1打1胜")
            {
                m = 1;
            }
            else if (comboBox1.Text == "3打2胜")
            {
                m =3;
            }
            else if (comboBox1.Text == "5打3胜")
            {
                m = 5;
            }
            else if (comboBox1.Text == "7打4胜")
            {
                m = 7;
            }
            else if (comboBox1.Text == "9打5胜")
            {
                m = 9;
            }
            else if (comboBox1.Text == "11打6胜")
            {
                m = 11;
            }
            return m;
        }
        //确定模式、初始化按钮；
        private void button2_Click(object sender, EventArgs e)
        {
            //初始化分数；
            ren = 0;
            diannao = 0;
            xianshi();
            //确定游戏模式；
            int a;
            a = judgetime();
            if (a < 0)
            {
                MessageBox.Show("请选择模式！", "模式不对！", MessageBoxButtons.OK);
            }
            else 
            {
                total = a;
                total = total / 2 + 1;//确定如果大于等于total的值就算赢了；
                button4.Enabled = true;
            }
        }
        //显示当前比分函数；
        void xianshi()
        {
            label5.Text = ren.ToString();
            label6.Text = diannao.ToString();
        }

        void check_end()
        {
            if (ren >= total)
            {
                MessageBox.Show("恭喜！您获胜了！！！","游戏结束！",MessageBoxButtons.OK);
                button4.Enabled = false;
            }
            else if (diannao >= total)
            {
                MessageBox.Show("啊！电脑赢了……真可恶！", "游戏结束！", MessageBoxButtons.OK);
                button4.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            choice = 1;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            choice = 2;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            choice = 3;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }
        //开始按钮；
        private void button4_Click(object sender, EventArgs e)
        {
            ok=check_option();
            if (ok == -1)
            {
                MessageBox.Show("Please choose a target!", "???", MessageBoxButtons.OK);
            }
            else
            {
                ran_com();
                once();
                xianshi();
                check_end();
            }
        }
    }
}
