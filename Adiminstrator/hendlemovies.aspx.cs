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
using MovieBll;
using playBll;

public partial class Adiminstrator_hendlemovies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //attaching to the user control the function
        WebUserControl1.logoutdelegate += new logoutdelegate(WebUserControl1_logoutdelegate);
        moviebll moviebll = new moviebll("SinemuConst");
        //showing the movies on the gridview
        try
        {
            movie[] m = moviebll.getAllMovies("");
            GridView1.DataSource = m;
            GridView1.DataBind();
        }
        catch (Exception )
        {
            lblerror.Text = "problem with the page please try to refresh it";
        }
    }

   //loging out this function is attach to the user control
    void WebUserControl1_logoutdelegate()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
    }
    //adding movie
    protected void btnAddMovie_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateMovie.aspx");
    }

    //updateing movie we go to we trasfaer to the page the movie code
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string movieCode = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
        Response.Redirect("UpdateMovie.aspx?MovieCode=" + movieCode);
        
    }
    //deleteting the movie
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
      
        string movieCode = GridView1.DataKeys[e.RowIndex].Value.ToString();
        moviebll bll = new moviebll("SinemuConst");
        try
        {
            //deleting the movie
            bll.deletMovie(movieCode);
            //reternig to the page 
            Server.Transfer("hendlemovies.aspx");
        }
        catch (Exception error)
        {
            lblerror.Text= error.Message.ToString();
        }
    }
    //uploding picture
    protected void btnUpload_Click(object sender, EventArgs e)
    {

       
        try
        {

            FileUpload1.SaveAs(Server.MapPath("~/moviePicture/" + FileUpload1.FileName));
        }
        catch
        {
            lblerror.Text = "problem inserting picture";
        }
    }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    //going to handle play transafering the movie id
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string movieCode = GridView1.DataKeys[e.RowIndex].Value.ToString();
        Response.Redirect("handlePlays.aspx?MovieCode=" + movieCode);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        string movieCode = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
        Response.Redirect("handlePlays.aspx?MovieCode=" + movieCode);
    }
    //handel errors
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }
    //getting movie description
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        TextBox txt = (TextBox)e.Row.FindControl("txt1");
        txt.Text = ((movie)e.Row.DataItem).Description;
    }
}
