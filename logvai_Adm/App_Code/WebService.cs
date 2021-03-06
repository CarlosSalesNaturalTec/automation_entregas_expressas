﻿using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data.SqlClient;

[WebService(Namespace = "http://logvaiadm.azurewebsites.net")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string tentarlogin(string param1, string param2)
    {

        string url = "Default.aspx";

        string stringselect = "select ID_User,nome " +
            "from Tbl_Usuarios_adm  " +
            "where usuario='" + param1 + "' and senha='" + param2 + "'";
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);

        while (dados.Read())
        {
            //cria parametros para validação de acesso
            string vValida1 = DateTime.Now.ToString("hh"); // hora
            string vValida2 = DateTime.Now.ToString("mm"); // minuto
            int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
            string vValida4 = vValida3.ToString();

            url = "PainelPrincipal.aspx?v1=" + Convert.ToString(dados[0]) + "&v2=" + Convert.ToString(dados[1]) +
                "&v3=" + vValida4;
        }

        return url;
    }

    [WebMethod]
    public string UserExcluir(string param1)
    {

        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Usuarios where ID_User =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Clientes_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string alteraFaturamento(string param1, string param2)
    {

        string url = "Sorry.aspx";

        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update Tbl_Usuarios set faturar = " + param2 +
            " where ID_User = " + param1);
        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "Clientes_Ficha.aspx?v1=" + param1;
        }
        return url;
    }

    [WebMethod]
    public string gerarFatura(string param1, string param2, string param3)
    {

        string url = "Sorry.aspx";
        string idfat = "";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("insert into Tbl_Faturas (ID_Cliente,Quant,Valor_Total,Data_Fatura,Status_Pagam) values " +
            "(" + param1 +", " + param2 + " , " + param3 + " , dateadd(hh,-3,getdate()) , 'Em Aberto' ) ");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            //obtem o numero da fatura criada
            string stringselect = "select ID_Fatura from Tbl_Faturas " +
                 " where ID_Cliente = " + param1 +
                 " order by ID_Fatura desc";
            OperacaoBanco operacao1 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);
            while (dados.Read())
            {
                idfat = Convert.ToString(dados[0]);
                break;
            }
            ConexaoBancoSQL.fecharConexao();

            //define as entregas como pertencentes a fatura recem criada
            OperacaoBanco operacao2 = new OperacaoBanco();
            bool alterar = operacao2.Update("update Tbl_Entregas_Master set " +
                "ID_Fatura  = " + idfat +
                " where ID_Cliente = " + param1 + " and ID_Fatura = 0 and Forma_Pagam = 'Faturado'");
            ConexaoBancoSQL.fecharConexao();
            url = "Faturas_Gerar.aspx";
        }
        return url;
    }

    [WebMethod]
    public string MotoboyExcluir(string param1)
    {
        
        string url;

        OperacaoBanco operacao3 = new OperacaoBanco();
        Boolean deletar = operacao3.Delete("delete from Tbl_Motoboys where ID_Motoboy = " + param1);  // <!--*******Customização*******-->
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "Motoboys_Listagem.aspx"; // <!--*******Customização*******-->
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string MotoboySalvar(string param1, string param2, string param3, string param4)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO Tbl_Motoboys (Nome, RG , endereco, FotoDataURI ) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "')");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Motoboys_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string MotoboyAlterar(string param1, string param2, string param3, string param4, string param5)
    {
        string url;

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("update Tbl_Motoboys set " +
            "Nome= '" + param2 + "', " +
            "RG = '" + param3 + "', " +
            "Endereco = '" + param4 + "', " +
            "FotoDataURI = '" + param5 + "' " +
            "where ID_Motoboy =" + param1);

        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            url = "Motoboys_Listagem.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
    }

    [WebMethod]
    public string confirmaDeposito(string param1)
    {

        string url = "Sorry.aspx";

        OperacaoBanco operacao = new OperacaoBanco();
        bool alterar = operacao.Update("update Tbl_Entregas_Master set Status_Pagam = 'Pago' " +
            "where ID_Entrega = " + param1);
        ConexaoBancoSQL.fecharConexao();

        if (alterar == true)
        {
            url = "Entregas_Listagem.aspx";
        }
        return url;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string MotoboysOnLine()
    {

        string Resultado = "";
        List<Object> resultado = new List<object>();

        try
        {
            OperacaoBanco operacao1 = new OperacaoBanco();
            SqlDataReader dados1 = operacao1.Select("select ID_Motoboy, Nome ,Latitude ,Longitude, " +
            "DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo  " +
            "FROM Tbl_Motoboys  ");

            while (dados1.Read())
            {
                //validações diversas
                int min1 = Convert.ToInt32(dados1[4]);  // diferença em minutos
                if (min1 > 185) { continue; } // verifica se diferença é maior que 5minutos (+dif+3horas getdate not brazilian server)

                resultado.Add(new
                {
                    ID_Motoboy = dados1[0].ToString(),
                    Nome = dados1[1].ToString(),
                    Latitude = dados1[2].ToString(),
                    Longitude = dados1[3].ToString()
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


