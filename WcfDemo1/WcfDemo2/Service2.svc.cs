using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo2
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service2”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service2.svc 或 Service2.svc.cs，然后开始调试。
    public class Service2 : IService2
    {
        Ticket T = new Ticket(); //购买车票的服务方法
        public void AddTicket(int count) /*实现添加票数的方法*/
        {
            T.HowMany = T.HowMany + count;
        }
        public int GetRemainingNum() /*实现返回票数的方法*/
        {
            return T.HowMany;
        }
        public int BuyTickets(int Num) /*实现购买车票的方法*/
        {
            if (T.BoolCount)
            {
                T.HowMany = T.HowMany - Num;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
