using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for MyDateTimeChecker
/// </summary>
public class MyDateTimeChecker:EventArgs
{
    DateTime myDate;    
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
        public MyDateTimeChecker(int year, int mounth, int day, int hour, int minit)
        {
            Year = year;
            Mounth = mounth;
            Day = day;
            Hour = hour;
            Minit = minit;
            MyDate=checkDate();

        }
        public DateTime MyDate
        {
            get { return myDate; }
            set { myDate = value; }
        }
        private DateTime checkDate()
        {
            try
            {
            MyDate = new DateTime(Year, Mounth, Day, Hour, Minit, 1);
            }
            catch(Exception)
            {
            return  DateTime.Now.AddDays(-1);     
            }
         return MyDate;
        
        
        
        }


    }

