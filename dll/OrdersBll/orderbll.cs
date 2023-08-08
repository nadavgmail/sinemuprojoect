using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;

namespace OrdersBll
{
    public class orderbll
    {
    private Dal dal;

    public orderbll(string constr)
        {
            dal = new Dal(constr);          
        }
        //inserting new oreder
    public void insertOrder(int PlayCode, int UserCode, int CardNumber)
        {
            string sql = string.Format("INSERT INTO Orders (PlayCode, UserCode ,CardNumber) VALUES ('{0}', '{1}','{2}')", PlayCode, UserCode, CardNumber);
            try
            {
                dal.Open();
                dal.ExecuteNonQuery(sql);
            }
            catch
            {
                throw new Exception("problem opening play db");
            }
            finally
            {
                dal.Close();
            }
        }
    }
}
