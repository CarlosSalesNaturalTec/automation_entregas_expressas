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
        decimal chkvalor = Convert.ToDecimal(chkvalorstr.Replace(".",","));

        //dados do cliente
        string sNome = "nome"; //Session["UserName"].ToString();
        string sEmail = "dev@uol.com";  // Session["UserEmail"].ToString();
        string sel = "1203456";  // Session["UserTel"].ToString();

        bool isSandbox = false;
        EnvironmentConfiguration.ChangeEnvironment(isSandbox);

        // Instantiate a new payment request
        PaymentRequest payment = new PaymentRequest();

        // Sets the currency
        payment.Currency = Currency.Brl;

        // Add an item for this payment request
        payment.Items.Add(new Item("0001", "Notebook Prata", 1, chkvalor));

        // Sets a reference code for this payment request, it is useful to identify this payment in future notifications.
        payment.Reference = "REF1234";

        // Sets your customer information.
        payment.Sender = new Sender(
                "Joao Comprador",
                "comprador@uol.com.br",
                new Phone("11", "56273440")
            );

        SenderDocument document = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
        payment.Sender.Documents.Add(document);

        // Sets the url used by PagSeguro for redirect user after ends checkout process
        payment.RedirectUri = new Uri("http://logvai01.azurewebsites.net/PainelCliente.aspx");

        // Add checkout metadata information
        payment.AddMetaData(MetaDataItemKeys.GetItemKeyByDescription("CPF do passageiro"), "123.456.789-09", 1);
        payment.AddMetaData("PASSENGER_PASSPORT", "23456", 1);

        payment.AddParameter("shippingAddressRequired", "false");

        // Add and remove groups and payment methods
        List<string> accept = new List<string>();
        accept.Add(ListPaymentMethodNames.DebitoItau);
        accept.Add(ListPaymentMethodNames.DebitoBradesco);
        accept.Add(ListPaymentMethodNames.DebitoBancoDoBrasil);

        payment.AcceptPaymentMethodConfig(ListPaymentMethodGroups.CreditCard, accept);

        List<string> exclude = new List<string>();
        exclude.Add(ListPaymentMethodNames.Boleto);
        payment.ExcludePaymentMethodConfig(ListPaymentMethodGroups.Boleto, exclude);

        try
        {
            /// Create new account credentials
            /// This configuration let you set your credentials from your ".cs" file.
            AccountCredentials credentials = new AccountCredentials("carlossalesti@gmail.com", "9C7858A628964441B903138A65412637");

            /// @todo with you want to get credentials from xml config file uncommend the line below and comment the line above.
            //AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

            Uri paymentRedirectUri = payment.Register(credentials);
            string urlcheckout = paymentRedirectUri.ToString();

            Response.Redirect(urlcheckout);
        }
        catch (PagSeguroServiceException exception)
        {
            Console.WriteLine(exception.Message + "\n");

            foreach (ServiceError element in exception.Errors)
            {
                Console.WriteLine(element + "\n");
            }
            Console.ReadKey();
        }

    }
}