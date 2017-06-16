using System;
using System.Collections.Generic;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using System.Net.Mail;

public partial class Pagseguro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // envia email para gestores avisando sobre nova entrega
        EnviarEmail();

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
        payment.Reference = "Cli_" + Session["UserID"].ToString();

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

    public void EnviarEmail()
    {

        //Define os dados do e-mail
        string nomeRemetente = "LOGVAI";
        string emailRemetente = "suporte@loglogistica.com.br";
        string senha = "pwd@1973";

        //Host da porta SMTP
        string SMTP = "smtp.terra.com.br";

        string emailDestinatario = "suporte@loglogistica.com.br";
        string emailComCopia = "ivansuarez@loglogistica.com.br";
        string emailComCopia1 = "sergiosuarez@loglogistica.com.br";
        string emailComCopia2 = "regiscorreia@loglogistica.com.br";

        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "Nova Solicitação de Entrega";

        DateTime hora = DateTime.Now.AddHours(-3);

        string l0 = "<img alt=\"LOGVAI\" src=\"https://logvai.azurewebsites.net/images/logo.png\"/>";
        string l1 = "<b><p>LOGVAI - Nova Solicitação de Entrega (CARTÃO)</p></b>";
        string l2 = "<p>Cliente : " + Session["UserName"].ToString() + " </p>";
        string l3 = "<p>Data: " + hora.ToString("dd/MM/yyyy HH:mm:ss") + "</p>";
        string l4 = "<br/>";

        string conteudoMensagem = l0 + l1 + l2 + l3 + l4;

        //Cria objeto com dados do e-mail.
        MailMessage objEmail = new MailMessage();

        //Define o Campo From e ReplyTo do e-mail.
        objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");

        //Define os destinatários do e-mail.
        objEmail.To.Add(emailDestinatario);

        //Enviar cópia para.
        //objEmail.CC.Add(emailComCopia);
        //objEmail.CC.Add(emailComCopia1);
        //objEmail.CC.Add(emailComCopia2);

        //Enviar cópia oculta para.
        //objEmail.Bcc.Add(emailComCopiaOculta);

        //Define a prioridade do e-mail.
        objEmail.Priority = MailPriority.Normal;

        //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
        objEmail.IsBodyHtml = true;

        //Define título do e-mail.
        objEmail.Subject = assuntoMensagem;

        //Define o corpo do e-mail.
        objEmail.Body = conteudoMensagem;

        //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
        objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
        objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


        // Caso queira enviar um arquivo anexo
        //Caminho do arquivo a ser enviado como anexo
        //string arquivo = Server.MapPath("arquivo.jpg");

        // Ou especifique o caminho manualmente
        //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

        // Cria o anexo para o e-mail
        //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

        // Anexa o arquivo a mensagem
        //objEmail.Attachments.Add(anexo);

        //Cria objeto com os dados do SMTP
        SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

        //Alocamos o endereço do host para enviar os e-mails  
        objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
        objSmtp.Host = SMTP;
        objSmtp.Port = 587;
        //Caso utilize conta de email do exchange da locaweb deve habilitar o SSL
        //objEmail.EnableSsl = true;

        //Enviamos o e-mail através do método .send()
        try
        {
            objSmtp.Send(objEmail);
            //Response.Write("E-mail enviado com sucesso !");

        }
        catch (Exception ex)
        {
            Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
        }
        finally
        {
            //excluímos o objeto de e-mail da memória
            objEmail.Dispose();
            //anexo.Dispose();
        }
    }

}