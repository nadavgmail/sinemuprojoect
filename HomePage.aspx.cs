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
using System.Drawing;
using MovieBll;
using UsersBll;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // initialize the master page to ponit to log out function(HomePage_logoutevent())
        ((MasterPage)Master).logoutevent += new logoutdelegate1(HomePage_logoutevent);
        if (IsPostBack)
            return;
        movie[] m = null;
        moviebll moviebll = new moviebll("SinemuConst");
        try
        {
           //getting the free selected movies
            m = moviebll.getAllMoviesOrTopFree();
        }
        catch (Exception error)
        {
            lblerror.Text = error.Message.ToString();
            return;
        }
        
        //showing the result on the gridview
        GridView3.DataSource = m;
        GridView3.DataBind();

    }

    //logging out from the site
    void HomePage_logoutevent()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
       
    }

    protected void btnsearchmovie_Click(object sender, EventArgs e)
    {
        //getting mivies from the search
        lblresult.Text = "";
        movie[] m = null;
        moviebll moviebll = new moviebll("SinemuConst");
        try
        {
           //saving movies to aray
            m = moviebll.getAllMovies(txtmobiename.Text);
        }
        catch(Exception error)
        {
            lblerror.Text = error.Message.ToString();
        }
        if (m.Length == 0)
        {
            lblresult.Text = "no such movie";
            return;
        }
       //showing the movie
        GridView2.DataSource = m;
        GridView2.DataBind();
    }
   
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //moving into the cardinvintation page and transfering the movie id
        string movieCode = GridView2.SelectedDataKey.Value.ToString();
        Response.Redirect("Regular/CardsInventation.aspx" + "?movieID=" + movieCode);
       
    }


    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    //chatching exeeption
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }
    //autcompleete
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        //getting the names of the autocomplete
        moviebll moviebll = new moviebll("SinemuConst");
        return moviebll.getautocomplete(prefixText);
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //moving into the cardinvintation page and transfering the movie id
        string movieCode = GridView3.SelectedDataKey.Value.ToString();
        Response.Redirect("Regular/CardsInventation.aspx" + "?movieID=" + movieCode);
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       //getting the decription
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;

        
        TextBox txt = (TextBox)e.Row.FindControl("txt1");
        txt.Text = ((movie)e.Row.DataItem).Description;
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //getting the decription
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;

       
        TextBox txt = (TextBox)e.Row.FindControl("txt2");
        txt.Text = ((movie)e.Row.DataItem).Description;
    }
}
