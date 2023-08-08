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
public partial class handlePlays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //attaching function to usercontrol
        WebUserControl1.logoutdelegate += new logoutdelegate(WebUserControl1_logoutdelegate);
        play[] p = null;
        playbll bll = new playbll("SinemuConst");
        //if we got to the page not from the page of the movie we will see all the plays 
        try
        {
            if (Request.QueryString["movieCode"] == null)
            {

                p = bll.getallplaysfromallmovies();
                //if there are no plays to show
                if (p.Length == 0)
                    {
                    lblpalys.Text = "no plays to show";
                    return;
                    }
                
                GridView1.DataSource = p;
                GridView1.DataBind();
                return;
            }
            //if we got here it means that we got here not from the palys that are connected to the movie and we will see 
            //just the play that are conneted to the movie
            int moviecode = int.Parse(Request.QueryString["movieCode"]);
            //getting plays
            p = bll.getallplays(moviecode, "SELECT * FROM Plays WHERE MovieCode = @MovieCode");
            //if there are no plays to show
            if (p.Length == 0)
            {
                lblpalys.Text = "no plays to show";
                return;
            }
            GridView1.DataSource = p;
            GridView1.DataBind();
        }
        catch
        {
            lblerror.Text = "בעיה בדף בבקשה לחץ על ריענון";
        }
    }

    //logigng of
    void WebUserControl1_logoutdelegate()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //adding play from a diffrent page 
        string movieCode = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
        //we sending to the the page the id of the movie
        Response.Redirect("addPlay.aspx?MovieCode=" + movieCode);
    }
    //handle error
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
   //deleting play
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string playCode = GridView1.Rows[e.NewEditIndex].Cells[2].Text;
        playbll bll = new playbll("SinemuConst");
        try
        {
            bll.deletePlay(playCode);
            Server.Transfer("handlePlays.aspx");
        }
        catch (Exception error)
        {
            lblerror.Text = error.Message.ToString();
        }
    }
}
