using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication20
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9(this);
            f9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection myConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb");//创建连接对象
            myConnection.Open();      //建立连接

            OleDbCommand myCommand = myConnection.CreateCommand(); //创建命令对象

            myCommand.CommandText = "select * from 表1 where Pname = ";
            myCommand.CommandText += ("'" + textBox1.Text + "'");          //提供SQL命令
            OleDbDataReader myReader = myCommand.ExecuteReader();  //执行命令返回结果指派给DataReader对象
            int cou = 0;
            while (myReader.Read())                                 //从读取器中获取结果
            {
                ++cou;
                if (myReader["pword"].ToString() == textBox2.Text)
                {
                    Form3 yy = new Form3();
                    //yy.ID = Int32.Parse(myReader["ID"].ToString());
                    //yy.pw = myReader["Ppwd"].ToString();
                    yy.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("您输入的密码有误，请重新输入", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (cou == 0) MessageBox.Show("您输入的用户名有错，请重新输入", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            myReader.Close();//关闭DataReader
            myConnection.Close();//关闭数据库连接
        }
    }
}
