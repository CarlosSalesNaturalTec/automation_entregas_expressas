using System;

public partial class LogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserID"] = "0";
        Response.Redirect("Default.aspx");
    }
}