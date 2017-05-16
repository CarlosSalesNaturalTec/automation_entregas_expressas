using System;
using System.Collections.Generic;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;

public partial class Pagseguro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //dados da solicitação
        string chkvalorstr = Request.QueryString["v1"];
        decimal chkvalor = Convert.ToDecimal(chkvalorstr);

        Session["OSId"] = Request.QueryString["v2"];

        bool isSandbox = true;
        EnvironmentConfiguration.ChangeEnvironment(isSandbox);

        // Instantiate a new payment request
        PaymentRequest payment = new PaymentRequest();

        // Sets the currency
        payment.Currency = Currency.Brl;

        // Add an item for this payment request
        payment.Items.Add(new Item("0001", "Servico de Motoboy", 1, chkvalor));

        // Sets a reference code for this payment request, it is useful to identify this payment in future notifications.
        payment.Reference = "Cliente:" + Session["UserID"].ToString() + "-OS:" + Session["OSId"].ToString();

        payment.AddParameter("shippingAddressRequired", "false");


        // Sets the url used by PagSeguro for redirect user after ends checkout process
        payment.RedirectUri = new Uri("http://logvai01.azurewebsites.net/RedirectRetorno.aspx");

        // Add and remove groups and payment methods
        List<string> accept = new List<string>();
        accept.Add(ListPaymentMethodNames.DebitoItau);
        payment.AcceptPaymentMethodConfig(ListPaymentMethodGroups.CreditCard, accept);

        try
        {
            //faz requisição de check-out e aguarda retorno com link para pagamento
            AccountCredentials credentials = new AccountCredentials("carlossalesti@gmail.com", "C1BF7C4BE89A481A8C215B3275F41973");
            Uri paymentRedirectUri = payment.Register(credentials);
            string urlpagam = paymentRedirectUri.ToString();

            //encaminha usuário para pagina de pagamento (ambiente pagseguro)
            Response.Write("<script>self.parent.location.href='" + urlpagam +"';</script>");
        }
        catch (PagSeguroServiceException exception)
        {
            Response.Write("<script>alert('Tente Novamente! Motivo: " + exception.Message + "');</script>");
        }

    }
}