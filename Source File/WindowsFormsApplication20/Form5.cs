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
    public partial class Form5 : Form
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";

        string sql = "select * from 表1";
        DataSet ds = new DataSet();
        public Form3 fr3=new Form3();
        public Form5(Form3 f3)
        {
            fr3 = f3;
            InitializeComponent();
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fr3.Show();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersDataSet4.表1”中。您可以根据需要移动或删除它。
            this.表1TableAdapter.Fill(this.usersDataSet4.表1);
            
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, conn);
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, conn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(ada);
            //ds.Tables[0].TableName = "sheet1";
            ada.Update(ds);
            dataGridView1.Update();
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(3000, "修改成功！\n修改时间：", DateTime.Now.ToLocalTime().ToString(), ToolTipIcon.Info);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(this);
            f11.Show();
            this.Close();
        }
    }
}
