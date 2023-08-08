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

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // initialize the master page to ponit to log out function(LogIn_logoutevent)
        ((MasterPage)Master).logoutevent += new logoutdelegate1(LogIn_logoutevent);
        if (IsPostBack)
            return;
        //define the range of the date
        RangeValidator1.MinimumValue = DateTime.Today.ToShortDateString();
        RangeValidator1.MaximumValue = DateTime.Today.AddYears(100).ToShortDateString();
    }
    //hendle error
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }

   //event from usercontrol
    void LogIn_logoutevent()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //checks if the credit card is from digits only and number of the digits is beetween 10-20 digits
        if (!ckeckNumber())
        {
            args.IsValid = false;
            return;
        }
        
        if (!(txtcardnumber.Text.Length >= 10 && txtcardnumber.Text.Length <= 20))
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    //checkes if the string is from numbers only
    private bool ckeckNumber()
    {

        for (int i = 0; i < txtcardnumber.Text.Length; i++)
        {
            if (!((char)(txtcardnumber.Text[i]) >= 48 && (char)(txtcardnumber.Text[i]) <= 57))
            {
                return false;
            }
        }
        return true;
    }
    //if rhe user already exsit
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        UserBll bll = new UserBll("SinemuConst");
        try
        {
            //checks if the user exsit
            if (bll.CheckUserName(txtusername.Text))
                args.IsValid = false;
            else
                args.IsValid = true;
        }
        catch(Exception e)
        {
            lblerrors.Text = e.Message;
        }
        
    }
    //insertingt user
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        UserBll bll = new UserBll("SinemuConst");
        //converting the date from string to datetime
        DateTime d = returnDate.convertingStringTodate(txtvalidatecard.Text);
        //inserting the movie
        bll.User.InsertUser(txtfirstname.Text, txtlastname.Text, txtusername.Text, txtpassword.Text, txtcardtype.Text, permission.Regular, txtcardnumber.Text, d);
        try
        {
            bll.InsertUsers(bll.User);
        }
        catch(Exception error)
        {
            lblerrors.Text = error.Message.ToString();
        }
        Response.Redirect("HomePage.aspx");
                           
    }
    
}
