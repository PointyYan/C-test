using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class BLL
    {
        public Model.UserInfo UserLogin(string userName, string password)
        {
            DAL.userDAO uDao = new DAL.userDAO();   //实例化DAL层  
            Model.UserInfo user = uDao.SelectUser(userName, password);


            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("登录失败");
            }
        }


        public DataSet GetListUser()
        {
            DAL.userDAO uDao = new DAL.userDAO();   //实例化DAL层  
            //List<UserInfo> list = new List<UserInfo>();
            DataSet dataSet = new DataSet();
            dataSet = uDao.GetListUser();

            return dataSet;
        }
    }
}
