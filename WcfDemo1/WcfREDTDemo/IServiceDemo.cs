using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfREDTDemo
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServiceDemo”。
    [ServiceContract]
    public interface IServiceDemo
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,UriTemplate = "GetStudentById/Id={Id}")]
        Student GetStudentById(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetStudentList")]
        List<Student> GetStudentList();
    }

    [DataContract]
    public class Student
    {
        /// <summary>
        /// 在数据传送过程中，只有成员变量可以被传送而成员方法不可以。并且只有当成员变量加上DataMember时才可以被序列进行数据传输，如果不加DataMember，客户端将无法获得该属性的任何信息
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
