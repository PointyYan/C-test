using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo2
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService2”。

    //购买车票的服务契约
    [ServiceContract]
    public interface IService2
    {
        /* 增加车票的方法*/
        [OperationContract]
        void AddTicket(int count);

        /*购买车票的方法*/
        [OperationContract]
        int BuyTickets(int Num);

        /*查询车票的方法*/
        [OperationContract] 
        int GetRemainingNum();
    }

    [DataContract]
    public class Ticket
    {
        bool boolCount = true;//判断是否还有车票
        int howmany = 10; //还有多少车票

        [DataMember] /*判断是否还有票*/
        public bool BoolCount
        {
            get
            {
                return boolCount;
            }
            set
            {
                if (HowMany > 0)
                {
                    boolCount = false;
                }
                else
                {
                    boolCount = true;
                }
            }
        }

        [DataMember] /*返回票数*/
        public int HowMany
        {
            get { return howmany; }
            set { howmany = value; }
        }
    }

}
