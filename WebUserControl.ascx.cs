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
public delegate void logoutdelegate();
public partial class WebUserControl : System.Web.UI.UserControl
{

    public event logoutdelegate logoutdelegate; 
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        if (logoutdelegate != null)
            logoutdelegate();
    }
}
