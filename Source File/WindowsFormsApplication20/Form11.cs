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
    public partial class Form11 : Form
    {
        string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\users.accdb";

        string sql = "select * from 表2";
        DataSet ds = new DataSet();
        public Form5 fr5 = new Form5();
        public Form11(Form5 f5)
        {
            fr5 = f5;
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersDataSet.表2”中。您可以根据需要移动或删除它。
            this.表2TableAdapter.Fill(this.usersDataSet.表2);

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, conn);
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 ff5 = new Form5();
            ff5.Show();
        }
    }
}
