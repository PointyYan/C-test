using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserInfo() { }

        public UserInfo(int ID,string UserName ,string Password)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Password = Password;
            //this.Email = Email;
        }
    }
}
