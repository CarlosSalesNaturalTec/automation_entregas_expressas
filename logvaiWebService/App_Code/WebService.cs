using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data.SqlClient;

[WebService(Namespace = "http://logvaiws.azurewebsites.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
//[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string VerificaEntregas(int IdMotoboy)
    {
        string Resultado = "";
        List<Object> resultado = new List<object>();

        try
        {

            string result;
            string retorno;

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select("SELECT count(ID_Entrega) as Total_Quant "
                    + "FROM Tbl_Entregas_Master "
                    + "where Status_Pagam<>'Em Aberto' and Status_OS = 'Em Aberto' ");  

            while (dados.Read())
            {

                result = dados[0].ToString();

                if (result == "0")
                {
                    retorno = "9999";
                }
                else
                {
                    retorno = result;
                }

                resultado.Add(new
                {
                    param = retorno,
                });

            }
            ConexaoBancoSQL.fecharConexao();

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    public string Localizacao(string param1, string param2, string param3)
    {

        string url = "XX";
        OperacaoBanco operacao2 = new OperacaoBanco();
        bool inserir2 = operacao2.Insert("update Tbl_Motoboys set Latitude = '" + param2 + "', Longitude = '" + param3 +
            "', GeoDataLoc = dateadd(hh,-3,getdate())" +
            " where ID_Motoboy = " + param1);
        ConexaoBancoSQL.fecharConexao();

        if (inserir2 == true)
        {
            url = "OK";
        }

        ConexaoBancoSQL.fecharConexao();
        return url;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string ListaEntregas(int param1)
    {
        // TODAS AS ENTREGAS EM ABERTO 
        string Resultado = "";
        int totalRegistros = 0;
        List<Object> resultado = new List<object>();
        try
        {
            OperacaoBanco operacao1 = new OperacaoBanco();
            SqlDataReader dados1 = operacao1.Select("select ID_Entrega,Tbl_Usuarios.Nome, LocalOrigem,LocalDestino,Distancia_Total "
                    + "FROM Tbl_Entregas_Master "
                    + "INNER JOIN Tbl_Usuarios ON Tbl_Entregas_Master.ID_Cliente = Tbl_Usuarios.ID_User "
                    + "where Status_Pagam<>'Em Aberto' and Status_OS = 'Em Aberto' ");  

            while (dados1.Read())
            {
                resultado.Add(new
                {
                    ID_Entrega = dados1[0].ToString(),
                    Cliente = dados1[1].ToString(),
                    Origem = dados1[2].ToString(),
                    Destino = dados1[3].ToString(),
                    Distancia = dados1[4].ToString()
                });
                totalRegistros += 1;
            }
            ConexaoBancoSQL.fecharConexao();

            if (totalRegistros == 0)
            {
                resultado.Add(new
                {
                    ID_Entrega = "9999",
                    Cliente = "X",
                    Origem = "X",
                    Destino = "X",
                    Distancia = "X"
                });
            }

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string ListaEntregas2(int param1)
    {
        
        // PONTOS DA ENTREGA MASTER
        string Resultado = "";
        List<Object> resultado = new List<object>();
        try
        {
            OperacaoBanco operacao1 = new OperacaoBanco();
            SqlDataReader dados1 = operacao1.Select("select ID_Entrega_Filho,Endereco,numero,complemento" +
                    " FROM Tbl_Entregas " +
                    " where ID_Entrega = " + param1 +
                    " order by Ordem ");

            while (dados1.Read())
            {
                resultado.Add(new
                {
                    ID_Entrega_Filho = dados1[0].ToString(),
                    Endereco = dados1[1].ToString(),
                    Numero = dados1[2].ToString(),
                    Complemento = dados1[3].ToString(),
                });
            }
            ConexaoBancoSQL.fecharConexao();

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string IdentificaID(int param1)
    {
        string Resultado = "";
        int totalRegistros = 0;
        List<Object> resultado = new List<object>();
        try
        {
            OperacaoBanco IDoperacao = new OperacaoBanco();
            SqlDataReader IDdados = IDoperacao.Select("select ID_Motoboy, Nome "
                    + "FROM Tbl_Motoboys "
                    + "where (ID_Motoboy = " + param1 + ")");
            while (IDdados.Read())
            {
                resultado.Add(new
                {
                    ID_Motoboy = IDdados[0].ToString(),
                    Nome = IDdados[1].ToString() + "xFIMx"
                });
                totalRegistros += 1;
            }
            ConexaoBancoSQL.fecharConexao();

            if (totalRegistros == 0)
            {
                resultado.Add(new
                {
                    ID_Motoboy = "9999",
                    Nome = "ID NÃO CADASTRADO"
                });
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA";
        }

        return Resultado;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string DetalhesEntrega(int param1)
    {
        string Resultado = "";
        List<Object> resultado = new List<object>();
        try
        {
            OperacaoBanco operacao = new OperacaoBanco();
            SqlDataReader dados = operacao.Select("SELECT Endereco,numero,complemento,Contactar,Detalhes,Banco_Repart_Publica,Telefone "
                    + "FROM Tbl_Entregas "
                    + "where ID_Entrega_filho = " + param1);
            while (dados.Read())
            {
                resultado.Add(new
                {
                    Endereco = dados[0].ToString(),
                    numero = dados[1].ToString(),
                    complemento = dados[2].ToString(),
                    Contactar = dados[3].ToString(),
                    Detalhes = dados[4].ToString(),
                    Banco_Repart_Publica = dados[5].ToString(),
                    Telefone = dados[6].ToString(),
                });
            }
            ConexaoBancoSQL.fecharConexao();

            //O JavaScriptSerializer vai fazer o web service retornar JSON
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(resultado);

        }
        catch (Exception)
        {
            Resultado = "FALHA CONEXÃO BANCO DE DADOS";
        }

        return Resultado;
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

