using System;
using System.Net.Mail;

public partial class Redirect : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //valida login por meio de parâmetro enviado pelo webservice
        string vValida1 = DateTime.Now.ToString("hh"); // hora
        string vValida2 = DateTime.Now.ToString("mm"); // minuto
        int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
        string vValida4 = vValida3.ToString();

        string param = Request.QueryString["v3"];
        if (param == vValida4)
        {
            Session["UserID"] = Request.QueryString["v1"];
            Session["UserName"] = Request.QueryString["v2"];
            Session["UserFaturar"] = Request.QueryString["v4"];

            EnviarEmail();

            Response.Redirect("PainelCliente.aspx");
        }
        else
        {
            Response.Redirect("Sorry.aspx");
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
        //string emailComCopia = "ivansuarez@loglogistica.com.br";
        //string emailComCopia1 = "sergiosuarez@loglogistica.com.br";
        string emailComCopia2 = "regiscorreia@loglogistica.com.br";

        //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

        string assuntoMensagem = "LOGVAI - Cadastro de Novo Cliente";

        DateTime hora = DateTime.Now.AddHours(-3);

        string l0 = "<b><p>LOGVAI - Novo cliente cadastrado no sistema</p></b>";
        string l1 = "<p>Nome: " + Session["UserName"]  + "</p>";
        string l2 = "<p>Data: " + hora.ToString("dd/MM/yyyy HH:mm:ss") +  "</p>";
        string l3 = "<br/>";

        string conteudoMensagem = l0 + l1 + l2 + l3;

        //Cria objeto com dados do e-mail.
        MailMessage objEmail = new MailMessage();

        //Define o Campo From e ReplyTo do e-mail.
        objEmail.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");

        //Define os destinatários do e-mail.
        objEmail.To.Add(emailDestinatario);

        //Enviar cópia para.
        //objEmail.CC.Add(emailComCopia);
        //objEmail.CC.Add(emailComCopia1);
        objEmail.CC.Add(emailComCopia2);

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