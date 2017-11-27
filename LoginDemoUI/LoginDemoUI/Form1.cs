using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;


namespace LoginDemoUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;
            BLL.BLL mgr = new BLL.BLL();
            Model.UserInfo user = mgr.UserLogin(userName, password);

  
            MessageBox.Show("登录用户：" + user.UserName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            BLL.BLL bLL = new BLL.BLL();

            dataGridView1.DataSource = bLL.GetListUser().Tables;
            //
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“userInfoDataSet.UserInfo”中。您可以根据需要移动或删除它。
            this.userInfoTableAdapter.Fill(this.userInfoDataSet.UserInfo);

        }
    }
}
