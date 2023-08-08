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
using UsersBll;
public enum UserRole { Regular, Adiminstrator, None };


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // initialize the master page to ponit to log out function(login_logoutevent())
        ((MasterPage)Master).logoutevent += new logoutdelegate1(login_logoutevent);
        ((MasterPage)Master).sighnInVisble();
    }

    //loging out from the page
    void login_logoutevent()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        FormsAuthentication.Initialize();
        
    }
    protected void txtUser_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserRole role;
        try
        {
            //reciving role 
            role = AuthenticateUser();
        }
        catch(Exception error)
        {
            //if we could not open db
            lblerror.Text = error.Message.ToString();
            return;
        }
        //if the user does not exsist
        if (role == UserRole.None)
        {
            lblconfirm.Text = "שם משתמש או סיסמא שגויים";
            return;
        }
       FormsAuthentication.RedirectFromLoginPage(role.ToString(), false);
       //if the user is regular we go to homepage if not we got to the admin users
       if (role == UserRole.Regular)
           Response.Redirect("HomePage.aspx");
       else
            
            Response.Redirect("Adiminstrator/hendlemovies.aspx");

      //Adiminstrator\hendlemovies.aspx
       

    }

    private UserRole AuthenticateUser()
    {
        UserRole UserRole;
        UserBll userbll = new UserBll("SinemuConst");
        //get user information 
        userbll.User = userbll.CheckUserName(txtUser.Text, txtPassword.Text);
        //if the user does not exsist
        if (userbll.User == null)
        {
            lblconfirm.Text = "שם משתמש או סיסמא שגויים";
            return UserRole.None;
        }
        
        //return permissins
        if (userbll.User.Permission == permission.Admin)
        {
            UserRole = UserRole.Adiminstrator;
        }
        else
        {
            //if the user is regular we will need the session
            UserRole = UserRole.Regular;
            Session["UserCode"] = userbll.User.UserCode;
        }
        return UserRole;       
        
    }
    //handelinig error
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }
}
