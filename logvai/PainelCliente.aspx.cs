using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PainelCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = Session["UserName"].ToString();

        string idPag = Request.QueryString["id_pagseguro"];
        if (idPag != null)
        {
            Response.Write("<script>alert('Retorno: " + idPag + "');</script>");
        }

    }
}