using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playBll
{
    /// <summary>
    /// class to retrive play
    /// </summary>
    public class play
    {
        private int playCode;
        private int movieCode;
        private DateTime playDate;

        public DateTime PlayDate
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
        public void insertPlay(int playcode, int moviecode, DateTime playdate)
        {
            PlayCode = playcode;
            MovieCode = moviecode;
            PlayDate = playdate;
        }
    }
    
}
