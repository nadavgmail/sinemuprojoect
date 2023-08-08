using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal
{
    /// <summary>
    /// class to retrive  a date 
    /// </summary>
    public class MyDateTimeChecker:EventArgs
    {
        int year;
        int mounth;
        int day;
        int hour;
        int minit;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        

        public int Mounth
        {
            get { return mounth; }
            set { mounth = value; }
        }
        

        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        

        public int Minit
        {
            get { return minit; }
            set { minit = value; }
        }
        MyDateTimeChecker(int year, int mounth, int day, int hour, int minit)
        {
            Year = year;
            Mounth = mounth;
            Day = day;
            Hour = hour;
            Minit = minit;
        }

    
    }
}
