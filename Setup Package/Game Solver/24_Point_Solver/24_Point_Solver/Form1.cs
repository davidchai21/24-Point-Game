using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace _24_Point_Solver
{
    public partial class Form1 : Form
    {
        int[] d=new int[4];     //传入的4个数；
        string[] ans=new string[50];
        int num = 0;
        int heli = 0;
        SoundPlayer sp = new SoundPlayer();

        void check_empty()      //检查函数，目的是检查输入是否为空，不为空则检查输入合法性，若合法则存入d[]数组内；
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入数字！", "Empty", MessageBoxButtons.OK);
            }
            else
            {
                string[] test = textBox1.Text.Split(' ');
                if (test.Length != 4)
                {
                    MessageBox.Show("请输入正确的数字！", "Error@1", MessageBoxButtons.OK);
                    textBox1.Text = "";
                }
                else
                {
                    int[] f = new int[4];
                    int mes = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (test[i] != "1" && test[i] != "2" && test[i] != "3" && test[i] != "4" && test[i] != "5" && test[i] != "6" && test[i] != "7" && test[i] != "8" && test[i] != "9" && test[i] != "10" && test[i] != "11" && test[i] != "12" && test[i] != "13")
                        //f[i] = Convert.ToInt16(test[i]);
                        {
                            mes = 1;
                        }
                    }
                    if (mes == 1)
                    {
                        MessageBox.Show("请输入正确的在范围内的数字！", "Error@2", MessageBoxButtons.OK);
                        textBox1.Text = "";
                    }
                    else
                    {
                        heli = 1;
                        for (int j = 0; j < 4; j++)
                        {
                            d[j] = Convert.ToInt16(test[j]);
                        }
                    }
                }
            }
        }

        void go_on()
        {
            int xuan;
            int d1, d2, d3, d4;
            d1 = d[0];
            d2 = d[1];
            d3 = d[2];
            d4 = d[3];
            int[] v = new int[4];
            for (xuan = 0; xuan < 24; xuan++)
            {
                switch (xuan)       //将数组v 内的4个值附上d1-d4（采取不同组合）；
                {
                    case 0: v[0] = d1; v[1] = d2; v[2] = d3; v[3] = d4; break;
                    case 1: v[0] = d1; v[1] = d2; v[2] = d4; v[3] = d3; break;
                    case 2: v[0] = d1; v[1] = d3; v[2] = d2; v[3] = d4; break;
                    case 3: v[0] = d1; v[1] = d3; v[2] = d4; v[3] = d2; break;
                    case 4: v[0] = d1; v[1] = d4; v[2] = d3; v[3] = d2; break;
                    case 5: v[0] = d1; v[1] = d4; v[2] = d2; v[3] = d3; break;
                    case 6: v[0] = d2; v[1] = d1; v[2] = d3; v[3] = d4; break;
                    case 7: v[0] = d2; v[1] = d1; v[2] = d4; v[3] = d3; break;
                    case 8: v[0] = d2; v[1] = d3; v[2] = d4; v[3] = d1; break;
                    case 9: v[0] = d2; v[1] = d3; v[2] = d1; v[3] = d4; break;
                    case 10: v[0] = d2; v[1] = d4; v[2] = d3; v[3] = d1; break;
                    case 11: v[0] = d2; v[1] = d4; v[2] = d1; v[3] = d3; break;
                    case 12: v[0] = d3; v[1] = d2; v[2] = d1; v[3] = d4; break;
                    case 13: v[0] = d3; v[1] = d2; v[2] = d4; v[3] = d1; break;
                    case 14: v[0] = d3; v[1] = d1; v[2] = d2; v[3] = d4; break;
                    case 15: v[0] = d3; v[1] = d1; v[2] = d4; v[3] = d2; break;
                    case 16: v[0] = d3; v[1] = d4; v[2] = d1; v[3] = d2; break;
                    case 17: v[0] = d3; v[1] = d4; v[2] = d2; v[3] = d1; break;
                    case 18: v[0] = d4; v[1] = d1; v[2] = d2; v[3] = d3; break;
                    case 19: v[0] = d4; v[1] = d1; v[2] = d3; v[3] = d2; break;
                    case 20: v[0] = d4; v[1] = d3; v[2] = d2; v[3] = d1; break;
                    case 21: v[0] = d4; v[1] = d3; v[2] = d1; v[3] = d2; break;
                    case 22: v[0] = d4; v[1] = d2; v[2] = d3; v[3] = d1; break;
                    case 23: v[0] = d4; v[1] = d2; v[2] = d1; v[3] = d3; break;
                    default:
                        MessageBox.Show("xuan!!!", "Error", MessageBoxButtons.OK); break;
                }
                geili(v[0],v[1],v[2],v[3]);
            }
        }

        void geili(double p1, double p2,double p3,double p4)
        {
            //int biaozhi = -1;
            double[] total = new double[45];
            //只有加减；
            total[0] = p1 + p2 + p3 + p4;
            total[1] = p1 + p2 + p3 - p4;
            total[2] = p1 + p2 - p3 - p4;
            //有2个加减，有1个乘除；
            total[3] = (p1 + p2) * p3 + p4;
            total[4] = (p1 + p2) * p3 - p4;
            total[5] = (p1 + p2) / p3 + p4;
            total[6] = (p1 + p2) / p3 - p4;
            total[7] = (p1 - p2) * p3 + p4;
            total[8] = (p1 - p2) * p3 - p4;
            total[9] = (p1 - p2) / p3 + p4;

            total[10] = (p1 + p2) * (p3 + p4);
            total[11] = (p1 - p2) * (p3 + p4);
            total[12] = (p1 - p2) * (p3 - p4);

            total[13] = p1 / (p2 + p3) + p4;
            if (p2 != p3)
            {
                total[14] = p1 / (p2 - p3) + p4;
            }
            else { total[14] = 0; }

            total[15] = (p1 + p2 + p3) * p4;
            total[16] = (p1 + p2 + p3) / p4;
            total[17] = (p1 + p2 - p3) * p4;
            total[18] = (p1 + p2 - p3) / p4;
            total[19] = (p1 - p2 - p3) * p4;

            total[20] = p1 * p2 + p3 + p4;
            total[21] = p1 * p2 + p3 - p4;
            total[22] = p1 * p2 - p3 - p4;
            total[23] = p1 / p2 + p3 + p4;
            total[24] = p1 / p2 + p3 - p4;
            //有2个乘除，有1个加减；
            total[25] = (p1 + p2 * p3) * p4;
            total[26] = (p1 - p2 * p3) * p4;
            total[27] = (p1 + p2 / p3) * p4;
            total[28] = (p1 - p2 / p3) * p4;
            total[29] = (p1 + p2 * p3) / p4;
            total[30] = (p1 + p2 / p3) / p4;

            if (p2 - p3 / p4 == 0)
            {
                total[31] = 0;
            }
            else
            {
                total[31] = p1 / (p2 - p3 / p4);
            }

            total[32] = (p1 + p2) * p3 * p4;
            total[33] = (p1 - p2) * p3 * p4;
            total[34] = (p1 + p2) * p3 / p4;
            total[35] = (p1 - p2) * p3 / p4;
            total[36] = p1 * p2 / (p3 + p4);
            if (p3 != p4)
            {
                total[37] = p1 * p2 / (p3 - p4);
            }
            else { total[37] = 0; }

            total[38] = (p1 * p2 - p3) * p4;
            total[39] = (p1 / p2 - p3) * p4;
            total[40] = (p1 * p2 - p3) / p4;

            if (p2 / p3 - p4 == 0)
            {
                total[41] = 0;
            }
            else
            {
                total[41] = p1 / (p2 / p3 - p4);
            }
            //只有乘除；
            total[42] = p1 * p2 * p3 * p4;
            total[43] = p1 * p2 * p3 / p4;
            total[44] = p1 * p2 / p3 / p4;

            for (int m = 0; m < 45; m++)
            {
                if (total[m] == 24)
                {
                    switch (m)
                    {
                        case 0: ans[num] = p1.ToString() + "+" + p2.ToString() + "+" + p3.ToString() + "+" + p4.ToString(); break;
                        case 1: ans[num] = p1.ToString() + "+" + p2.ToString() + "+" + p3.ToString() + "-" + p4.ToString(); break;
                        case 2: ans[num] = p1.ToString() + "+" + p2.ToString() + "-" + p3.ToString() + "-" + p4.ToString(); break;
                        case 3: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")" + "*" + p3.ToString() + "+" + p4.ToString(); break;
                        case 4: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")" + "*" + p3.ToString() + "-" + p4.ToString(); break;
                        case 5: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")" + "/" + p3.ToString() + "+" + p4.ToString(); break;
                        case 6: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")" + "/" + p3.ToString() + "-" + p4.ToString(); break;
                        case 7: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")" + "*" + p3.ToString() + "+" + p4.ToString(); break;
                        case 8: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")" + "*" + p3.ToString() + "-" + p4.ToString(); break;
                        case 9: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")" + "/" + p3.ToString() + "+" + p4.ToString(); break;
                        case 10: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")*(" + p3.ToString() + "+" + p4.ToString() + ")"; break;
                        case 11: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")*(" + p3.ToString() + "+" + p4.ToString() + ")"; break;
                        case 12: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")*(" + p3.ToString() + "-" + p4.ToString() + ")"; break;
                        case 13: ans[num] = p1.ToString() + "/(" + p2.ToString() + "+" + p3.ToString() + ")+" + p4.ToString(); break;
                        case 14: ans[num] = p1.ToString() + "/(" + p2.ToString() + "-" + p3.ToString() + ")+" + p4.ToString(); break;
                        case 15: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "+" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 16: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "+" + p3.ToString() + ")/" + p4.ToString(); break;
                        case 17: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "-" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 18: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "-" + p3.ToString() + ")/" + p4.ToString(); break;
                        case 19: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + "-" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 20: ans[num] = p1.ToString() + "*" + p2.ToString() + "+" + p3.ToString() + "+" + p4.ToString(); break;
                        case 21: ans[num] = p1.ToString() + "*" + p2.ToString() + "+" + p3.ToString() + "-" + p4.ToString(); break;
                        case 22: ans[num] = p1.ToString() + "*" + p2.ToString() + "-" + p3.ToString() + "-" + p4.ToString(); break;
                        case 23: ans[num] = p1.ToString() + "/" + p2.ToString() + "+" + p3.ToString() + "+" + p4.ToString(); break;
                        case 24: ans[num] = p1.ToString() + "/" + p2.ToString() + "+" + p3.ToString() + "-" + p4.ToString(); break;
                        case 25: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "*" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 26: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + "*" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 27: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "/" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 28: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + "/" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 29: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "*" + p3.ToString() + ")/" + p4.ToString(); break;
                        case 30: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + "/" + p3.ToString() + ")/" + p4.ToString(); break;
                        case 31: ans[num] = p1.ToString() + "/(" + p2.ToString() + "-" + p3.ToString() + "/" + p4.ToString() + ")"; break;
                        case 32: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")*" + p3.ToString() + "*" + p4.ToString(); break;
                        case 33: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")*" + p3.ToString() + "*" + p4.ToString(); break;
                        case 34: ans[num] = "(" + p1.ToString() + "+" + p2.ToString() + ")*" + p3.ToString() + "/" + p4.ToString(); break;
                        case 35: ans[num] = "(" + p1.ToString() + "-" + p2.ToString() + ")*" + p3.ToString() + "/" + p4.ToString(); break;
                        case 36: ans[num] = p1.ToString() + "*" + p2.ToString() + "/(" + p3.ToString() + "+" + p4.ToString() + ")"; break;
                        case 37: ans[num] = p1.ToString() + "*" + p2.ToString() + "/(" + p3.ToString() + "-" + p4.ToString() + ")"; break;
                        case 38: ans[num] = "(" + p1.ToString() + "*" + p2.ToString() + "-" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 39: ans[num] = "(" + p1.ToString() + "/" + p2.ToString() + "-" + p3.ToString() + ")*" + p4.ToString(); break;
                        case 40: ans[num] = "(" + p1.ToString() + "*" + p2.ToString() + "-" + p3.ToString() + ")/" + p4.ToString(); break;
                        case 41: ans[num] = p1.ToString() + "/(" + p2.ToString() + "/" + p3.ToString() + "-" + p4.ToString() + ")"; break;
                        case 42: ans[num] = p1.ToString() + "*" + p2.ToString() + "*" + p3.ToString() + "*" + p4.ToString(); break;
                        case 43: ans[num] = p1.ToString() + "*" + p2.ToString() + "*" + p3.ToString() + "/" + p4.ToString(); break;
                        case 44: ans[num] = p1.ToString() + "*" + p2.ToString() + "/" + p3.ToString() + "/" + p4.ToString(); break;
                        default:
                            MessageBox.Show("ans[num] !!!!", "Error", MessageBoxButtons.OK); break;
                    }
                    num++;
                }
            }
        }

        void shuang()
        {
            int l = 0;
            while (l < num)
            {
                if (ans[l] != "")
                {
                    for (int p = l+1; p < num; p++)
                    {
                        if (ans[p] == ans[l])
                        {
                            ans[p] = "";
                        }
                    }
                }
                else { }
                l++;
            }
        }

        void show_ans()
        {
            while (heli == 1)
            {
                if (num == 0)
                {
                    textBox2.Text = "您输入的数字无法通过加减乘除四则运算得到24！";
                }
                else
                {
                    shuang();
                    textBox2.Text = "您输入的数字为：   " + d[0].ToString() + " " + d[1].ToString() + " " + d[2].ToString() + " " + d[3].ToString() + Environment.NewLine;
                    textBox2.Text = textBox2.Text + "正确结果如下：" + Environment.NewLine;
                    for (int h = 0; h < num; h++)
                    {
                        if (ans[h] != "")
                        {
                            textBox2.Text += ans[h];
                            textBox2.Text += Environment.NewLine;
                        }
                    }
                    textBox2.Text += "结果显示完毕！";
                }
                for (int k = 0; k < 50; k++)
                {
                    ans[k] = "";
                }
                heli = 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Left = (this.Width - label1.Width) / 2;
            label2.Left = this.Width / 2 - label2.Width;
            textBox1.Left = this.Width / 2;
            sp.SoundLocation = @"earth.wav";
            sp.Load();
            sp.PlayLooping();

            //sp.SoundLocation = "D:\\SMM.wav";
            //sp.Load();
           // sp.PlaySync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num = 0;
            check_empty();
            go_on();
            show_ans();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
