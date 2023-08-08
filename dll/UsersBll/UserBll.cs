using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data.Common;
namespace UsersBll
{
    public class UserBll
    {
        private User user;
        
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        private Dal dal;
        public UserBll(string conStrName)
        {
            dal = new Dal(conStrName);
            user = new User();
            
            
        }
        //insert reguler users
        public void InsertUsers(User u)
        {
            try
            {
                string sql = string.Format("INSERT INTO Users (FirstName, LastName,UserName,UserPassword,CardNumber,Type,ExpirationDate,Permission) VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')", u.FirstName, u.LastName, u.UserName, u.Password, u.CardNumber, u.CardType, u.ExpiratinDate, u.Permission.ToString());

                dal.Open();
                dal.ExecuteNonQuery(sql);
            }
            catch (Exception)
            {
                throw new Exception("problem instert users");
            }
            finally
            {
                dal.Close();
            }
        }

        //checks if the user exsist
        public bool CheckUserName(string userName)
        {
            DbDataReader reader=null;
            bool isexist = false;
            string sql = "SELECT UserName FROM Users WHERE UserName = @UserName";
            try
            {
                dal.Open();
                DbParameter p = dal.CreateParameter("@UserName", userName);
                reader = dal.ExecuteReader(sql, p);

                if (reader.Read())
                {
                    //if we got here the user exsits
                    isexist = true;
                }
            }
            catch (Exception)
            {
                throw new Exception("problem in checking userName");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
            return isexist;
        }
       
        //checks user and password and password
        public User CheckUserName(string userName, string password)
        {
            DbDataReader reader = null;
            User user = new User();
            string sql = "SELECT Code,Permission FROM Users WHERE UserName = @UserName AND UserPassword =@UserPassword";
            try
            {
                dal.Open();
                DbParameter p = dal.CreateParameter("@UserName", userName);
                DbParameter p1 = dal.CreateParameter("@UserPassword", password);
                reader = dal.ExecuteReader(sql, p, p1);
                //if we found user and password that are maches
                if (reader.Read())
                {
                    if (reader["Permission"].ToString() == "Admin")
                    {
                        user.Permission = permission.Admin;
                    }
                    else
                    {
                        user.Permission = permission.Regular;
                    }
                    user.UserCode = (int)reader["Code"];
                }
                //if we did not found user and password that are maches we return null
                else
                {
                    user = null;
                }
                return user;
            }
            catch
            {
                
                throw new Exception("problem checking users and password");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
            
            
           
                     
        }        
    }
}
