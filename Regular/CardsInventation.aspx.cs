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
using playBll;
using OrdersBll;
//i need gridview wich i can delete 
public partial class CardsInventation : System.Web.UI.Page
{
    // initialize the master page to ponit to log out function(CardsInventation_logoutevent())
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Master).logoutevent += new logoutdelegate1(CardsInventation_logoutevent);
        if (IsPostBack)
            return;
        //if we got here without picking movie
        if (Request.QueryString["MovieId"] == null)
        {
            Response.Redirect("HomePage.aspx");
            return;
        }
        //show the plays that are attache to the move,because that are another function that does almost the same
        //i sent the sql query from here insteaf of creating two functions in plalbll
        playbll playbll = new playbll("SinemuConst");
        play[] p=null;
        try
        {
             p = playbll.getallplays(int.Parse(Request.QueryString["MovieId"]), "SELECT * FROM Plays WHERE PlayDate > NOW AND MovieCode = @MovieCode");
        }
        catch(Exception eror)
        {
            lbleror.Text = eror.Message.ToString();
        }
        //if there are no plays to this movie
        if (p.Length == 0)
        {
            Response.Redirect("noPlay.aspx");
            Response.End();
            return;
        }
        //attaching play to gridview
        PlayGridView.DataSource = p;// playbll.getPlays(int.Parse(Request.QueryString["MovieId"]));
        PlayGridView.DataBind();
        
    }

   //loging out from the form
    void CardsInventation_logoutevent()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
    }

    
    protected void PlayGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //varfy that the cardnumber is a number
        int cardnumber=0;
        string script = "alert('יש להכניס מספר');";
        string script1 = "alert('הבחירה הוזנה בהצלחה צפייה מהנה');";
        try
        {
            cardnumber=int.Parse(txtcardnumber.Text);
        }
        catch (Exception)
        {
           // ClientScript.registerclientscript
            ClientScript.RegisterStartupScript(this.GetType(), "functions", script, true);
           return;
        }
        int playCode = int.Parse(PlayGridView.SelectedDataKey.Value.ToString());
        int userCode = int.Parse(Session["UserCode"].ToString());
        //insert values to orders db    
        orderbll orderbll = new orderbll("SinemuConst");
        try
        {
            lbleror.Text = "";
            orderbll.insertOrder(playCode, userCode, int.Parse(txtcardnumber.Text));
          
        }
        catch(Exception error)
        {
            lbleror.Text = error.Message.ToString();
        }
        //show message to the client
        ClientScript.RegisterStartupScript(this.GetType(), "functions", script1, true);
    }
    //hadeling error
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }
}
