using System;
using System.Net.Mail;

public partial class SignIn_Confirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //========================================================================================================
        //========================== ENVIAR EMAIL 
        //========================================================================================================

        //Define os dados do e-mail
        string nomeRemetente = "LOG Transportes";
        string emailRemetente = "sergiosuarez@loglogistica.com.br";
        string senha = "ss040470";

        //Host da porta SMTP
        string SMTP = "smtp.terra.com.br";

        //destinatarios - emails
        string emailDestinatario = Request.QueryString["v1"];
        //string emailComCopia = ""; 
        //string emailComCopia1 = "";
        //string emailComCopia2 = "";
        //string emailComCopia3 = "";
        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "LOGVAI Motoboy Online - Confirmação de Cadastro";

        string l1 = "<b><p>CONFIRMAÇÃO DE CADASTRO</p></b>";
        string l2 = "<br/>";
        string l3 = "<p>Clique <a href=\"http://logvaionline.azurewebsites.net/SignIn_Confirm_Ok.aspx\">aqui</a> para confirmar seu cadastro e solicitar sua entrega:</p>";
        string l4 = "<p></p>";

        string conteudoMensagem = l1 + l2 + l3 + l4;

        //Cria objeto com dados do e-mail.
        MailMessage objEmail = new MailMessage();

        //Define o Campo From e ReplyTo do e-mail.
        objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

        //Define os destinatários do e-mail.
        objEmail.To.Add(emailDestinatario);

        /*/Enviar cópia para.
        objEmail.CC.Add(emailComCopia);
        objEmail.CC.Add(emailComCopia1);
        objEmail.CC.Add(emailComCopia2);
        objEmail.CC.Add(emailComCopia3);

        //Enviar cópia oculta para.
        //objEmail.Bcc.Add(emailComCopiaOculta); */

        //Define a prioridade do e-mail.
        objEmail.Priority = System.Net.Mail.MailPriority.Normal;

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
        System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

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
            Literal1.Text = "Verifique a mensagem que enviamos para seu e-mail e confirme seu Cadastro.";

        }
        catch (Exception ex)
        {
            Literal1.Text = "Ocorreram problemas no envio do e-mail. Erro = " + ex.Message;
        }
        finally
        {
            //excluímos o objeto de e-mail da memória
            objEmail.Dispose();
            //anexo.Dispose();
        }
    }
}