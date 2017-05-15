using System;

public partial class NovaEntrega : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string param = Session["UserID"].ToString();
        if (param == "0")
        {
            Response.Redirect("Sorry.aspx");
        } else
        {
            IDHidden.Value = Session["UserID"].ToString();
            FaturarHidden.Value = Session["UserFaturar"].ToString();
        }
    }    
}