﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
        
    }
}