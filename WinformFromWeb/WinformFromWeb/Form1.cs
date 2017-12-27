using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using WinformFromWeb.ServiceReference2;
using WinformFromWeb.cn.com.webxml.www;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft;
using Newtonsoft.Json;


namespace WinformFromWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            WebService1SoapClient LocalWS = new WebService1SoapClient();
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                return;
            double s1 = double.Parse(textBox1.Text);
            double s2 = Convert.ToDouble(this.textBox2.Text.ToString());
            this.textBox3.Text = LocalWS.Add(s1, s2).ToString();
                       
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WebClient(也可以用 HttpClient，）
            WebClient client = new WebClient();
            //访问以发布在IIS的WebAPI
            var json = client.DownloadData("http://localhost:8002/api/Students"); //Products是控制器名称
            string pageHtml = Encoding.UTF8.GetString(json);
            List<Student> st = JsonConvert.DeserializeObject<List<Student>>(pageHtml); //(json字符串反系列化)
            dataGridView1.DataSource = st;
            var jsons = client.DownloadData("http://localhost:8002/api/Students");
            string pageHtmls = Encoding.UTF8.GetString(jsons);
            label1.Text = pageHtmls.ToString();

            WebService1SoapClient webService1SoapClient = new WebService1SoapClient();
            dataGridView2.DataSource = webService1SoapClient.GetDataSet("select * from UserInfo").Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //WeatherWebServiceSoapClient weather = new WeatherWebServiceSoapClient();

            WeatherWebService weather = new WeatherWebService();

            string[] s = new string[23];
            string city = this.textBox4.Text.Trim();
            s = weather.getWeatherbyCityName(city);

            if (s[8] == "")
            {
                MessageBox.Show("暂时不支持您查询的城市");
            }
            else
            {
                //pictureBox1.Image = Image.FromFile(@"d:\image\" + s[8] + "");
                //this.label4.Text = s[1] + " " + s[6];
                textBox5.Text = s[10];
            }



            //label2.Text = weather.getSupportCity(s).ToString();
            //var json = weather.getWeatherbyCityName(s).ToString();
            //label2.Text = weather.getWeatherbyCityName(s).ToString();
            //label2.Text = json.ToString();
        }
    }
}
