using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfREDTDemo
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceDemo”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceDemo.svc 或 ServiceDemo.svc.cs，然后开始调试。
    public class ServiceDemo : IServiceDemo
    {
        private List<Student> Users = new List<Student>{
            new Student {Id = 1, Name = "张三",Sex="男",Age=20 },
            new Student {Id = 2, Name = "李四",Sex="女",Age=19 },
            new Student {Id = 3, Name = "王五",Sex="女",Age=18 },
            new Student {Id = 4, Name = "春天",Sex="女",Age=20 },
            new Student {Id = 5, Name = "夏天",Sex="男",Age=30 },
            new Student {Id = 6, Name = "晴天",Sex="女",Age=26 }
        };
        public Student GetStudentById(string Id)
        {
            return Users[int.Parse(Id)];
        }
        public List<Student> GetStudentList()
        {
            return Users;
        }

    }
}
