using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dal;
using System.Data.Common; 
namespace MovieBll
{
    public class moviebll
    {
        private movie movie;
        private Dal dal;
        public movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }
        public moviebll(string conactionString)
        {
            dal = new Dal(conactionString);
            movie = new movie();
        }
        //inserting new movie
        public void InsertMovie(movie m)
        {

            string sql = string.Format("INSERT INTO Movies (MovieName, Director,Description) VALUES ('{0}', '{1}','{2}')", m.MovieName, m.Director, m.Description);

            try
            {
                dal.Open();
                dal.ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
                string s = e.Message.ToString();
                //  throw new Exception("Problem in inserting a movie");
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                dal.Close();
            }
        }
        //return the movie to update from the id that was sent
        public movie returnMovieValue(int MovieId)
        {
            DbDataReader reader = null;
            string sql = "SELECT * FROM Movies WHERE MoveiCode = @MovieCode";
            try
            {
                dal.Open();
                DbParameter p = dal.CreateParameter("@MovieCode", MovieId);
                reader = dal.ExecuteReader(sql, p);
                movie m = new movie();
                while (reader.Read())
                {
                    m.Description = reader["Description"].ToString();
                    m.Director = reader["Director"].ToString();
                    m.MovieName = reader["MovieName"].ToString();
                    m.CodeName = (int)reader["MoveiCode"];
                }
                return m;
            }
            catch
            {
                throw new Exception("can not get the movie");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
            
        }

        //getting list of top3 the movie 
        public movie[] getAllMoviesOrTopFree()
        {
            DbDataReader reader = null;
            try
            {
                dal.Open();

                string sql = "SELECT TOP 3 Movies.MoveiCode,Movies.MovieName,Movies.Director,Movies.Description FROM (Movies LEFT JOIN Plays ON Movies.MoveiCode = Plays.MovieCode) LEFT JOIN Orders ON Plays.PlayCode = Orders.PlayCode WHERE ((Plays.PlayDate)>Now()-30) GROUP BY Movies.MoveiCode,Movies.MovieName,Movies.Director,Movies.Description ORDER BY Sum(Orders.CardNumber) DESC"; 
                reader = dal.ExecuteReader(sql);
                List<movie> m = new List<movie>();
                movie movie = null;
                while (reader.Read())
                {
                    movie = new movie();
                    movie.CodeName = ((int)reader["MoveiCode"]);
                    movie.MovieName = (reader["MovieName"].ToString());
                    movie.Description = (reader["Description"].ToString());
                    movie.Director = (reader["Director"].ToString());
                    m.Add(movie);
                }

                return m.ToArray();
            }
            catch
            {
                throw new Exception("problem getting list of movies from arrey");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
        }
        //update movie
        public void updateMovie(movie m)
        {
            string sql = String.Format("UPDATE Movies SET MovieName='{0}',Director='{1}',Description='{2}' WHERE MoveiCode={3}", m.MovieName, m.Director, m.Description, m.CodeName);
            try
            {
                dal.Open();
                dal.ExecuteNonQuery(sql);
            }
            catch
            {
                throw new Exception("problem updating movie");
            }
            finally
            {
                dal.Close();
            }
        }
        //getting list of movies from homepage
        public movie[] getAllMovies(string MovieName)
        {
            DbDataReader reader=null;
            try
            {
                dal.Open();
                string sql = string.Format("SELECT * FROM Movies WHERE MovieName LIKE '{0}%'", MovieName);
                reader = dal.ExecuteReader(sql);
                List<movie> m = new List<movie>();
                movie movie = null;// new movie();
                while (reader.Read())
                {
                    movie = new movie();
                    movie.CodeName = ((int)reader["MoveiCode"]);
                    movie.MovieName = (reader["MovieName"].ToString());
                    movie.Description = (reader["Description"].ToString());
                    movie.Director = (reader["Director"].ToString());
                    m.Add(movie);
                }
                return m.ToArray();
            }
            catch (Exception)
            {
                throw new Exception("problem getting movies by name");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }

         
        }
        //deleting movie
        public void deletMovie(string movieCode)
        {
            string sql = string.Format("DELETE FROM Movies WHERE MoveiCode ={0}", movieCode);
            try
            {
                dal.Open();
                dal.ExecuteNonQuery(sql);
            }
            catch
            {
                throw new Exception("problem deleting the novie");
            }
            finally
            {
                dal.Close();
            }
        }
       //getting list of moviesID
        public string[] getMovieId()
        {
            List<string> moviecode = null;
            DbDataReader reader = null;
            try
            {
                string sql = "SELECT MoveiCode FROM Movies";
                dal.Open();
                reader = dal.ExecuteReader(sql);
                moviecode = new List<string>();
                while (reader.Read())
                {
                    moviecode.Add(reader["MoveiCode"].ToString());

                }
            }
            catch (Exception)
            {
                throw new Exception("problem getting list of movies");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }
            return moviecode.ToArray();
        }
        //getting auto complete movie
        public string[] getautocomplete(string MovieName)
        {
            DbDataReader reader = null;
            try
            {
                dal.Open();
                string sql = string.Format("SELECT TOP 10 MovieName FROM Movies WHERE MovieName LIKE '{0}%'", MovieName);
                reader = dal.ExecuteReader(sql);
                List<string> m = new List<string>();               
                while (reader.Read())
                { 
                    m.Add(reader["MovieName"].ToString());                 
                }
                return m.ToArray();
            }
            catch (Exception)
            {
                throw new Exception("problem getting movies by name");
            }
            finally
            {
                reader.Close();
                dal.Close();
            }

        }
    }
}
