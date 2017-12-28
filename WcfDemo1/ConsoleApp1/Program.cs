using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Description;

using ConsoleApp1.ServiceReference1;

//using WcfDemo1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var proxy = new Service2Client())
            {
                Console.WriteLine("{0} + {1} = {2}", 23, 5, proxy.Add(23, 5));
                Console.WriteLine("{0} - {1} = {2}", 13, 5, proxy.Subtract(13, 5));
                Console.Read();
            }

        }
    }
}
