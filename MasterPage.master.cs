using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
public delegate void logoutdelegate1();
public partial class MasterPage : System.Web.UI.MasterPage
{
    public event logoutdelegate1 logoutevent;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //event for loging out
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        if (logoutevent != null)
            logoutevent();
    }
    //hiding the button
    public void sighnInVisble()
    {
        btnLogOut.Visible = false;
    }
}
