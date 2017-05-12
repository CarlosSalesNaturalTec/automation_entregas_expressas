using System;
using System.Collections.Generic;
using Uol.PagSeguro;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;

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