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
using playBll;
public partial class Adiminstrator_addPlay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //atteching function to the control event
        WebUserControl1.logoutdelegate += new logoutdelegate(WebUserControl1_logoutdelegate);
        if (IsPostBack)
            return;
       
        try
        {
            moviebll moviebll = new moviebll("SinemuConst");
            string[] movieId = moviebll.getMovieId();
            //if there are no movies we go back to handle movies
            if (movieId.Length == 0)
            {
                Response.Redirect("hendlemovies.aspx");
                return;
            
            }
            drpmovies.DataSource = movieId;
            drpmovies.DataBind();
        }
        catch
        {
            lblerror.Text = "בעיה בדף לא תוכל להוסיף סרטים נסה לרענן את הדף";
            Button1.Enabled = false;
            return;
        }
       //if we got here from the movie page select the right movie in the dropdownlist
        if (Request.QueryString["MovieCode"] != null)
        {
            drpmovies.SelectedValue = Request.QueryString["MovieCode"];
        }
        //the minimum of the date can be today
        RangeValidator1.MinimumValue = DateTime.Today.ToShortDateString();
        //can inset play to maximum 2 mounth
        RangeValidator1.MaximumValue = DateTime.Today.AddMonths(2).ToShortDateString();
        for (int i = 1; i < 24; i++)
            ddlhour.Items.Add(i.ToString());
        for (int i = 1; i < 60; i++)
            ddlminit.Items.Add(i.ToString());
    }

   //loging out from the form
    void WebUserControl1_logoutdelegate()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        FormsAuthentication.Initialize();
        Response.Redirect("LogIn.aspx");
    }
    //inserting the play
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        playbll playbll = new playbll("SinemuConst");
        //getting the date
        DateTime d = returnDate.convertingStringTodate(txtdate.Text,ddlhour.SelectedValue.ToString(),ddlminit.SelectedValue.ToString());
        try
        {
            //inserting the play
            playbll.insertPlay(int.Parse(drpmovies.SelectedItem.ToString()), d);
            string script = "alert('ההצגה הוזנה בהצלחה'); ";
            ClientScript.RegisterStartupScript(this.GetType(), "function", script, true);
        }
        catch(Exception erorr)
        {
            lblerror.Text = erorr.Message.ToString();
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
}
