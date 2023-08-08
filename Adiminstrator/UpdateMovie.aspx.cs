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
using MovieBll;
public partial class Adiminstrator_UpdateMovie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //attaching the event to the control
        WebUserControl1.logoutdelegate += new logoutdelegate(WebUserControl1_logoutdelegate);
        if (IsPostBack)
            return;
        moviebll bll = new moviebll("SinemuConst");
        try
        {
            //getting list of moviesID
            string[] movieId = bll.getMovieId();
            //if there are no movies we can not updatre movie but we can add one because there no movies to update
            if (movieId.Length == 0)
            {
                drpmovies.Visible = false;
                btnupdate.Visible = false;
                drpmovies.Enabled = false;
                btnupdate.Visible = false;
                return;
            }
            drpmovies.DataSource = movieId;
            //if there are no movies
            
            
            drpmovies.DataBind();
            //showing index of the movie
            getMovieToUpdate();
        }
        catch(Exception error)
        {
            lblerror.Text = error.Message.ToString();
        }
        //if we got here from handalemovies and we clicked on update
        if (Request.QueryString["MovieCode"] != null)
        {
            drpmovies.SelectedValue = Request.QueryString["MovieCode"];
            try
            {
                getMovieToUpdate();
            }
            catch(Exception error)
            {
                lblerror.Text = error.Message.ToString();
            }
        }
           
        
        

    }
    //loging of
    void WebUserControl1_logoutdelegate()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("LogIn.aspx");
    }
    //getting the movie to update
    private void getMovieToUpdate()
    {
        moviebll bll = new moviebll("SinemuConst");
        movie m = bll.returnMovieValue(int.Parse(drpmovies.SelectedValue.ToString()));       
        txtMovieName.Text = m.MovieName;
        txtdirector.Text = m.Director;
        txtdescription.Text = m.Description;
    }
    //updating the movie
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        
        if (!IsValid)
            return;
        string script = "alert('הסרט עודכן בהצלחה');";// window.location='UpdateMovie.aspx'";
         moviebll bll = new moviebll("SinemuConst");
         bll.Movie.insertMovie(int.Parse(drpmovies.SelectedValue.ToString()), txtMovieName.Text, txtdirector.Text, txtdescription.Text);
        //updating the movie 
        try
         {
             bll.updateMovie(bll.Movie);
             ClientScript.RegisterStartupScript(this.GetType(), "function", script, true);
         }
         catch(Exception error)
         {
             lblerror.Text = error.Message.ToString();
         }
    }
    //inserting the movie
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //get the last value of the index in the dropdownlist
        int value = int.Parse(drpmovies.Items[drpmovies.Items.Count-1].Text);
        //when we insert a movei the next item will be one more
        value++;
       string script = string.Format("alert('הסרט הוזן בהצלחה');window.location='UpdateMovie.aspx?MovieCode={0}'", value);
       // string script = "alert('הסרט הוזן בהצלחה'); window.location='UpdateMovie.aspx?MovieCode="+r+@"'"+@""";//50'";
        if (!IsValid)
            return;
        moviebll bll = new moviebll("SinemuConst");        
        bll.Movie.insertMovie(txtMovieName.Text, txtdirector.Text, txtdescription.Text);
        try
        {
            bll.InsertMovie(bll.Movie);
            ClientScript.RegisterStartupScript(this.GetType(), "function", script, true);
        }
        catch (Exception error)
        {
            lblerror.Text = error.Message.ToString();
        }
    }
   //filling the terxtbox with the movie that we picked
    protected void drpmovies_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {
            getMovieToUpdate();
        }
        catch(Exception error)
        {
            lblerror.Text = error.Message.ToString();
        }
    }
    //handle error
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception exp = Server.GetLastError();
        string msg = exp.Message;
        Response.Write(msg);
        Server.ClearError();
    }
    //uploading movie 
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {

            FileUpload1.SaveAs(Server.MapPath("~/moviePicture/" + FileUpload1.FileName));
        }
        catch
        {
            lblerror.Text = "problem uploding the file";
        }
    }
}
