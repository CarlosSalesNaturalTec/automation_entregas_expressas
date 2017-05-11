using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Redirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //valida login por meio de parâmetro enviado pelo webservice
        string vValida1 = DateTime.Now.ToString("hh"); // hora
        string vValida2 = DateTime.Now.ToString("mm"); // minuto
        int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
        string vValida4 = vValida3.ToString();

        string param = Request.QueryString["v3"];
        if (param == vValida4)
        {
            Session["UserID"] = Request.QueryString["v1"];
            Session["UserName"] = Request.QueryString["v2"];
            Session["UserFaturar"] = Request.QueryString["v4"];
            Response.Redirect("PainelCliente.aspx");
        }
        else
        {
            Response.Redirect("Sorry.aspx");
        }
    }
}