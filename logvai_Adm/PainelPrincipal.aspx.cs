using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PainelPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //validação
            string vValida1 = DateTime.Now.ToString("hh"); // hora
            string vValida2 = DateTime.Now.ToString("mm"); // minuto
            int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
            string vValida4 = vValida3.ToString();
            string param1 = Request.QueryString["v3"];
            if (param1 != vValida4)
            {
                Response.Redirect("Sorry.aspx");
            }
            else
            {
                Session["IDUser"] = Request.QueryString["v1"];
                lblUser.Text = Request.QueryString["v2"];
            }
            
        }

    }
}