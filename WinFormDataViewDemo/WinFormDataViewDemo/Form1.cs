using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using WinFormDataViewDemo;

namespace WinFormDataViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAllUser_Click(object sender, EventArgs e)
        {
            string sql = "select * from UserInfo";
            //DataSet dataSet = new DataSet();
            //dataSet = DBHelper.ExecuteDataSet(sql);
            //dataGridView1.DataSource = dataSet.Tables[0];
            DataTable dataTable = new DataTable();
            dataTable = DBHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
