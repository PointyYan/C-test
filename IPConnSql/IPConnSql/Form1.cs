using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IPConnSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblIP_Click(object sender, EventArgs e)
        {

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.ToString();
            string dataBase = txtDatabase.Text.ToString();
            string id = txtID.Text.ToString();
            string pwd = txtPwd.Text.ToString();
            string connSql = "Server=" + ip + ";Database=" + dataBase + ";uid=" + id + ";pwd=" + pwd;

            //           MessageBox.Show(connSql);

            SqlConnection conn = new SqlConnection(connSql);

            try{
                conn.Open();
                MessageBox.Show("链接成功");
            }
            catch
            {
                MessageBox.Show("链接失败，请检查textbox文本是否正确。");
            }

            try
            {
                conn.Close();
            }
            catch
            {
                MessageBox.Show("断开链接失败。");
            }
        }
    
    }
}
