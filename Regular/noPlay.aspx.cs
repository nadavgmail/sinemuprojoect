using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class noPlay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // initialize the master page to ponit to log out function(noPlay_logoutevent())
        ((MasterPage)Master).logoutevent += new logoutdelegate1(noPlay_logoutevent);
    }

    //loging out from the form
    void noPlay_logoutevent()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
    }
   //hendeling error
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }
}
