using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

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
            string msg = "JESUS IS THE LORD";
            string strInsert = "INSERT INTO Tbl_PSNotificacoes (notificationCode , notificationType ) " +
                "values ('" + notificationCode + "','" + notificationType + "')";

            OperacaoBanco operacao2 = new OperacaoBanco();
            bool inserir2 = operacao2.Insert(strInsert);
            ConexaoBancoSQL.fecharConexao();

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

