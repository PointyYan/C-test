using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace WcfRESTDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //用一个WebClient
            var client = new WebClient();
            //以PUT方式访问Data/1/100，会映射到服务端的CreateData("1", "100")
            client.UploadString("http://localhost:8080/wcf/Data/1/100", "PUT", string.Empty);
            //以GET方式访问Data/1，会映射到服务端的RetrieveData("1")，应该返回"100"
            Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));
            //以POST方式访问Data/1/200，会映射到服务端的UpdateData("1", "200")
            client.UploadString("http://localhost:8080/wcf/Data/1/200", "POST", string.Empty);
            //再GET一次，应该返回"200"
            Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));
            //以DELETE方式访问Data/1，会映射到服务端的DeleteData("1")
            client.UploadString("http://localhost:8080/wcf/Data/1", "DELETE", string.Empty);
            //再GET一次，应该返回"NOT FOUND"
            Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));
        }
    }
}
