using System;
using System.Web.Services;
using System.Data.SqlClient;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://logvai.azurewebsites.net")]
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
    public string teste(string param1)
    {
        string msg = "Jesus is the lord";
        return msg;
    }

    [WebMethod]
    public string usersave(string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9,string param10, string param11)
    {

        string url = "Sorry.aspx";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO Tbl_Usuarios (usuario,senha,cpfcnpj,nome,contato,endereco,numero,complemento,telefone,Cupom,dataCadastro,tipoPessoa) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 +
            "', '" + param6 + "', '" + param7 + "', '" + param8 + "', '" + param9 + "', '" + param10 + "', dateadd(hh,-3,getdate()), '" + param11 + "')");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            string stringselect = "select ID_User,nome " +
                "from Tbl_Usuarios " +
                "where usuario='" + param1 + "' and senha='" + param2 + "' ";
            OperacaoBanco operacao1 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);

            while (dados.Read())
            {
                //cria parametros para validação de acesso
                string vValida1 = DateTime.Now.ToString("hh"); // hora
                string vValida2 = DateTime.Now.ToString("mm"); // minuto
                int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
                string vValida4 = vValida3.ToString();

                url = "Redirect.aspx?v1=" + Convert.ToString(dados[0]) + "&v2=" + Convert.ToString(dados[1]) + "&v3=" + vValida4;
            }

        }

        ConexaoBancoSQL.fecharConexao();
        return url;
    }

    [WebMethod]
    public string login(string param1, string param2)
    {

        string url = "Default.aspx";

        string stringselect = "select ID_User,nome,faturar,usuario  " +
            "from Tbl_Usuarios " +
            "where usuario='" + param1 + "' and senha='" + param2 + "' ";
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);

        while (dados.Read())
        {
            //cria parametros para validação de acesso
            string vValida1 = DateTime.Now.ToString("hh"); // hora
            string vValida2 = DateTime.Now.ToString("mm"); // minuto
            int vValida3 = Convert.ToInt16(vValida1) * Convert.ToInt16(vValida2);
            string vValida4 = vValida3.ToString();

            //dados do usuario
            string permitefaturar = Convert.ToString(dados[2]);
            string useremail = Convert.ToString(dados[3]);

            url = "Redirect.aspx?v1=" + Convert.ToString(dados[0]) + "&v2=" + Convert.ToString(dados[1]) + 
                "&v3=" + vValida4 + "&v4=" + permitefaturar + "&v5=" + useremail; 
        }

        return url;
    }

    [WebMethod]
    public string entregMasterSalvar(string param1, string param2, string param3, string param4, string param5, 
        string param6, string param7, string param8, string param9)
    {
        string msg="0";
        string strInsert = "INSERT INTO Tbl_Entregas_Master (ID_Cliente ,Data_OS , Data_Servico , Distancia_Total , Valor_Total , Tipo_Atendimento ," +
            "Forma_Pagam ,Status_OS , Status_Pagam,LocalOrigem ,LocalDestino ) values (" +
            param1 + ", dateadd(hh,-3,getdate()), dateadd(hh,-3,getdate()), " + param2 + " , " + param3 + " , '" + param4 + "', '" + param5 + "' , '" +
            param6 + "', '" + param7 + "', '" + param8 + "', '" + param9 + "')";
 
        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            string stringselect = "select ID_Entrega" +
                 " from Tbl_Entregas_Master" +
                 " where ID_Cliente = " + param1 +
                 " order by ID_Entrega desc";
            OperacaoBanco operacao1 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);

            while (dados.Read())
            {
                msg = Convert.ToString(dados[0]);
                break;
            }
        }
        else
        {
            msg = "0";
        }
        ConexaoBancoSQL.fecharConexao();
        return msg;
    }

    [WebMethod]
    public string entregaSalvar(string param1, string param2, string param3, string param4, string param5, string param6, 
        string param7, string param8, string param9, string param10, string param11)
    {
        string msg = "XXX";
        string strInsert = "INSERT INTO Tbl_Entregas (ID_Entrega,Ordem,Endereco,numero,complemento,Contactar,Detalhes,Banco_Repart_Publica," +
            "Latitude,Longitude,Status_Entrega, Data_Entrega) values ( " +
            param1 + "," + param2 + ", '" + param3 + "', '" + param4 + "', '" + param5 + "', '" + param6 + "', '" + param7 + "', '" +
            param8 + "', '" + param9 + "', '" + param10 + "', '" + param11 + "', dateadd(hh,-3,getdate()) )";

        OperacaoBanco operacao2 = new OperacaoBanco();
        bool inserir2 = operacao2.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir2 == true)
        {
            msg = "SOLICITAÇÃO ENVIADA COM SUCESSO!";
        }
        else
        {
            msg = "TENTE NOVAMENTE.";
        }

        return msg;
    }


    [WebMethod]
    public string entregaExcluir(string param1)
    {
        string url = "Sorry.aspx";
        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Entregas_Master where ID_Entrega  =" + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            OperacaoBanco operacao2 = new OperacaoBanco();
            Boolean deletar2 = operacao2.Delete("delete from Tbl_Entregas where ID_Entrega =" + param1);
            ConexaoBancoSQL.fecharConexao();

            url = "EntregaAcompanhar.aspx";
        }
        else
        {
            url = "Sorry.aspx";
        }

        return url;
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

