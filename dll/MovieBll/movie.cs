using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieBll
{
    
    /// <summary>
    /// class of movies we will use it to retrive movies
    /// </summary>
    public class movie
    {
        
        private int codeName;     
        private string movieName;
        private string director;
        private string descripition;
        public int CodeName
        {
            get { return codeName; }
            set { codeName = value; }
        }
        public string MovieName
        {
            get { return movieName; }
            set { movieName = value; }
        }      
        public string Director
        {
            get { return director; }
            set { director = value; }
        }      
        public string Description
        {
            get { return descripition; }
            set { descripition = value; }
        }
        public movie() { }
        public void insertMovie(string moviename, string director, string description)
        {
            MovieName = moviename;
            Director = director;
            Description = description;
        }
        public void insertMovie(int moveiCode,string moviename, string director, string description)
        {
            MovieName = moviename;
            Director = director;
            Description = description;
            CodeName = moveiCode;
        }

    }
}
