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
        /**
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
    */

        public DataSet GetListUser()
        {
            DAL.userDAO uDao = new DAL.userDAO();   //实例化DAL层  
            //List<UserInfo> list = new List<UserInfo>();
            DataSet dataSet = new DataSet();
            dataSet = uDao.GetListUser();

            return dataSet;
        }

        //插入
        public void Insert(UserInfo userInfo)
        {
            DAL.userDAO userDAO = new DAL.userDAO();
            userDAO.Insert(userInfo);
        }

        //更新
        public void Update(UserInfo userInfo)
        {
            DAL.userDAO userDAO = new DAL.userDAO();
            userDAO.Update(userInfo);
        }
        
        //查询数据
        public DataSet Select(UserInfo userInfo)
        {
            DAL.userDAO uDao = new DAL.userDAO(); 
            DataSet dataSet = new DataSet();
            dataSet = uDao.Select(userInfo);
            return dataSet;
        }

        //删除数据
        public void Delete(UserInfo userInfo)
        {
            DAL.userDAO userDAO = new DAL.userDAO();
            userDAO.Delete(userInfo);
        }
    }
}
