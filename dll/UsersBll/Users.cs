using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
namespace UsersBll
{
    public class Users
    {
        private User user;
        private Dal dal;
        public Users(string conStrName)
        {
            dal = new Dal(conStrName);
            user = new User();
            
        }
        public void InsertUsers(User u)
        {
            string sql = string.Format("INSERT INTO Users (FirstName, LastName,UserName,Password,CardNumber,Type,ExpirationDate,Permission) VALUES('{0}', '{1}','{2},{3},{4},{5},{6},{7},{8})",u.FirstName,u.LastName,u.UserName,u.Password,u.CardNumber,u.Type,u.Permission.ToString());

            dal.Open();
            dal.ExecuteNonQuery(sql);
            dal.Close();
        }
    }
}
