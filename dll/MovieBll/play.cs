using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieBll
{
    /// <summary>
    /// class to retrive plays
    /// </summary>
    public class play
    {
        private int playCode;
        private int movieCode;
        private string playDate;

        public string PlayDate
        {
            get { return playDate; }
            set { playDate = value; }
        }
        public int MovieCode
        {
            get { return movieCode; }
            set { movieCode = value; }
        }
        
        public int PlayCode
        {
            get { return playCode; }
            set { playCode = value; }
        }
        
        public play() { }
       //inserting play
        public void insertPlay(int playcode, int moviecode, string playdate)
        {
            PlayCode = playcode;
            MovieCode = moviecode;
            PlayDate = playdate;
        }
    }
    
}
