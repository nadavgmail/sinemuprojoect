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
/// Summary description for returnDate
/// </summary>
public static class returnDate
{
    
   //reterning date i am using params because i am using this function twice with difrent parametrs 
    //with hour and minits and without them 
    public static DateTime convertingStringTodate(string stringDate, params string[] hourAndMinits)
    {
        DateTime d;
        //getting date from string
        string[] mystringdate = stringDate.Split('/', '.');
        int mounth = int.Parse(mystringdate[0]);
        int day = int.Parse(mystringdate[1]);
        int year = int.Parse(mystringdate[2]);
        //if we did not transfer hour and minits
        if (hourAndMinits.Length == 0)
        {
             d = new DateTime(year, mounth, day);
            return d;
        }
        return d = new DateTime(year,mounth,day,int.Parse(hourAndMinits[0]),int.Parse(hourAndMinits[1]),1);


    }
}
