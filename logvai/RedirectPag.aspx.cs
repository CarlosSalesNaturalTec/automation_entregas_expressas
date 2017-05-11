using System;
using System.Collections.Generic;
using System.Net;
using Uol.PagSeguro;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;

public partial class Pagseguro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        bool isSandbox = false;
        EnvironmentConfiguration.ChangeEnvironment(isSandbox);

        // Instantiate a new payment request
        PaymentRequest payment = new PaymentRequest();

        // Sets the currency
        payment.Currency = Currency.Brl;

        // Add an item for this payment request
        payment.Items.Add(new Item("0001", "Entrega Expressa", 1, 35.80m));

        // Sets a reference code for this payment request, it is useful to identify this payment in future notifications.
        payment.Reference = "LOG123";

        // Sets shipping information for this payment request
        payment.Shipping = new Shipping();
        payment.Shipping.ShippingType = ShippingType.Sedex;

        //Passando valor para ShippingCost
        payment.Shipping.Cost = 10.00m;

        payment.Shipping.Address = new Address(
            "BRA",
            "SP",
            "Sao Paulo",
            "Jardim Paulistano",
            "01452002",
            "Av. Brig. Faria Lima",
            "1384",
            "5o andar"
        );

        // Sets your customer information.
        payment.Sender = new Sender(
            "Joao Comprador",
            "comprador@uol.com.br",
            new Phone("11", "56273440")
        );

        SenderDocument document = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
        payment.Sender.Documents.Add(document);

        // Sets the url used by PagSeguro for redirect user after ends checkout process
        payment.RedirectUri = new Uri("http://www.lojamodelo.com.br");

        // Add checkout metadata information
        payment.AddMetaData(MetaDataItemKeys.GetItemKeyByDescription("CPF do passageiro"), "123.456.789-09", 1);
        payment.AddMetaData("PASSENGER_PASSPORT", "23456", 1);

        // Another way to set checkout parameters
        payment.AddParameter("senderBirthday", "07/05/1980");
        payment.AddIndexedParameter("itemColor", "verde", 1);
        payment.AddIndexedParameter("itemId", "0003", 3);
        payment.AddIndexedParameter("itemDescription", "Mouse", 3);
        payment.AddIndexedParameter("itemQuantity", "1", 3);
        payment.AddIndexedParameter("itemAmount", "200.00", 3);

        // Add and remove groups and payment methods
        List<string> accept = new List<string>();
        accept.Add(ListPaymentMethodNames.DebitoItau);
        accept.Add(ListPaymentMethodNames.DebitoHSBC);
        payment.AcceptPaymentMethodConfig(ListPaymentMethodGroups.CreditCard, accept);

        List<string> exclude = new List<string>();
        exclude.Add(ListPaymentMethodNames.Boleto);
        payment.ExcludePaymentMethodConfig(ListPaymentMethodGroups.Boleto, exclude);

        try
        {
            /// Create new account credentials
            AccountCredentials credentials = new AccountCredentials("carlossalesti@gmail.com", "9C7858A628964441B903138A65412637");
            Uri paymentRedirectUri = payment.Register(credentials);

            string urlcheckout = paymentRedirectUri.ToString();
            string codcheckout = "000";
            int pos = urlcheckout.IndexOf("code=");
            if (pos != -1) { codcheckout = urlcheckout.Substring(pos+5); }

            //Response.Write("<script>alert('" + codcheckout + "');</script>");
            Response.Redirect(urlcheckout);
            
        }
        catch (PagSeguroServiceException exception)
        {
            Response.Write("<script>alert('Erro Requisição');</script>");

            Console.WriteLine(exception.Message + "\n");

            foreach (ServiceError element in exception.Errors)
            {
                Console.WriteLine(element + "\n");
            }
            Console.ReadKey();
        }

    }
}