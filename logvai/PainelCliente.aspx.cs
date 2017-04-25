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
        lblUser.Text = Request.QueryString["v2"];
    }
}