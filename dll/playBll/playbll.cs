using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data.Common;
using System.Data;
namespace playBll
{
    public class playbll
    {
        
        private Dal dal;
        
        public playbll(string constr)
        {
            dal = new Dal(constr);
           
        }
        //inserting new play
        public void insertPlay(int movieCode,DateTime playTime)
        {
            string sql = string.Format("INSERT INTO Plays (MovieCode, PlayDate) VALUES ('{0}', '{1}')", movieCode, playTime);
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
        //this function get also the query because we call it twice with diffrent parameters 
        //from cardinvetion and from and handleplays
        public play[] getallplays(int movieCode, string mySql)
        {
            //string sql = string.Format("SELECT * FROM Plays WHERE MovieCode = @MovieCode");
            string sql = string.Format(mySql);
            DbParameter p = dal.CreateParameter("@MovieCode", movieCode);
            DbDataReader reader = null;
            List<play> playlist = new List<play>();
            try
            {
                dal.Open();
                reader = dal.ExecuteReader(sql, p);

                while (reader.Read())
                {
                    play play = new play();
                    play.PlayCode = (int)reader["PlayCode"];
                    play.MovieCode = (int)reader["MovieCode"];
                    play.PlayDate = (DateTime)reader["PlayDate"];
                    playlist.Add(play);
                }
            }
            catch
            {
                throw new Exception("problem with play db");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
            return playlist.ToArray();

        }
        //getting all the plays from all the movies
        public play[] getallplaysfromallmovies()
        {
            DbDataReader reader=null;
            string sql = string.Format("SELECT * FROM Plays");
            try
            {
                dal.Open();
                 reader = dal.ExecuteReader(sql);
                List<play> playlist = new List<play>();
                while (reader.Read())
                {
                    play play = new play();
                    play.PlayCode = (int)reader["PlayCode"];
                    play.MovieCode = (int)reader["MovieCode"];
                    play.PlayDate = (DateTime)reader["PlayDate"];
                    playlist.Add(play);
                }
                return playlist.ToArray();
            }
            catch (Exception)
            {
                throw new Exception("problem getting plays");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
            
        }
        //delete play
        public void deletePlay(string playNum)
        {
            string sql = string.Format("DELETE FROM Plays WHERE PlayCode ={0}", playNum);
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
