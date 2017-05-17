using System;
using System.Data.SqlClient;
using System.Web.Services;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;


namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebServicePS
    /// </summary>
    [WebService(Namespace = "http://webserviceps.azurewebsites.net")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePS : System.Web.Services.WebService
    {

        [WebMethod]
        public string notificacoespag(string notificationCode, string notificationType)
        {

            //webservice recebe coigo de notificação (notificationCode) via post

            string msg = "JESUS IS THE LORD";
            bool isSandbox = true;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            try
            {
                //faz uma requisição a API Pagseguro sobre o status desta notificação
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
                Transaction transaction = NotificationService.CheckTransaction(credentials,notificationCode);

                string codeTransation = transaction.Code.ToString();
                string dataTrasation = transaction.Date.ToString();
                string statusTransation = transaction.TransactionStatus.ToString();
                string referTransation = transaction.Reference.ToString();
                string statusTXT = "";

                switch (statusTransation)
                {
                    case "1":
                        statusTXT = "Aguardando pagamento";
                        break;
                    case "2":
                        statusTXT = "Em análise";
                        break;
                    case "3":
                        statusTXT = "Pago";
                        break;
                    case "4":
                        statusTXT = "Disponível";
                        break;
                    case "5":
                        statusTXT = "Em Disputa";
                        break;
                    case "6":
                        statusTXT = "Devolvida";
                        break;
                    case "7":
                        statusTXT = "Cancelada";
                        break;
                    case "8":
                        statusTXT = "Debitado";
                        break;
                    case "9":
                        statusTXT = "Retenção Temporária";         
                        break;
                    default:
                        statusTXT = "Outros";
                        break;
                }

                //atualiza status da entrega
                OperacaoBanco operacao = new OperacaoBanco();
                bool alterar = operacao.Update("update Tbl_Entregas_Master set " +
                    "Status_Pagam = '" + statusTXT + "' " +
                    "where PSCodTransacao = '" + codeTransation + "'");
                ConexaoBancoSQL.fecharConexao();
                if (alterar != true)
                {
                    msg = "NAO FOI POSSIVEL ATUALIZAR ";
                }


            }
            catch (PagSeguroServiceException exception)
            {
                msg = "erro:"+exception.Message;
            }

            return msg;
        }

    }


    public class ConexaoBancoSQL
    {
        private static SqlConnection objConexao = null;
        private string stringconnection1;

        public void tentarAbrirConexaoRemota()
        {
            objConexao = new SqlConnection();
            objConexao.ConnectionString = stringconnection1;
            objConexao.Open();
        }

        public ConexaoBancoSQL()
        {
            // *** STRING DE CONEXÃO COM BANCO DE DADOS - Atenção! Alterar dados conforme seu servidor
            stringconnection1 = "Server=tcp:serverlogvai.database.windows.net,1433;Initial Catalog=dblogvai;Persist Security Info=False;User ID=admserver;Password=pwd@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                tentarAbrirConexaoRemota();
            }
            catch
            {
                Console.WriteLine("Atenção! Não foi possível Conectar ao Servidor de Banco de Dados.");
            }
        }

        public static SqlConnection getConexao()
        {
            new ConexaoBancoSQL();
            return objConexao;
        }
        public static void fecharConexao()
        {
            objConexao.Close();
        }
    }

    public class OperacaoBanco
    {
        private SqlCommand TemplateMethod(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return Commando;
            }
            catch
            {
                return Commando;
            }
        }

        public SqlDataReader Select(String query)
        {
            SqlDataReader dadosObtidos = TemplateMethod(query).ExecuteReader();
            return dadosObtidos;
        }

        public Boolean Insert(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Update(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean Delete(String query)
        {
            SqlConnection Conexao = ConexaoBancoSQL.getConexao();
            SqlCommand Commando = new SqlCommand(query, Conexao);
            try
            {
                Commando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }



}

