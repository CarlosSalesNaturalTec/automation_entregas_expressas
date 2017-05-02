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
        string msg = "Aleluia. deu certo";
        return msg;
    }

    [WebMethod]
    public string usersave(string param1, string param2, string param3, string param4, string param5,
        string param6, string param7, string param8, string param9)
    {

        string url = "Sorry.aspx";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert("INSERT INTO Tbl_Usuarios (usuario,senha,cpfcnpj,nome,contato,endereco,numero,complemento,telefone,dataCadastro,nivel ) " +
            "VALUES ('" + param1 + "', '" + param2 + "', '" + param3 + "', '" + param4 + "', '" + param5 +
            "', '" + param6 + "', '" + param7 + "', '" + param8 + "', '" + param9 + "', getdate(),1)");
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            string stringselect = "select ID_User,nome" +
                "from Tbl_Usuarios " +
                "where usuario='" + param1 + "' and senha='" + param2 + "' ";
            OperacaoBanco operacao1 = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);

            while (dados.Read())
            {
                url = "PainelCliente.aspx?v1=" + Convert.ToString(dados[0]) + "&v2=" + Convert.ToString(dados[1]);
            }

        }

        return url;
    }

    [WebMethod]
    public string login(string param1, string param2)
    {

        string url = "Default.aspx";

        string stringselect = "select ID_User,nome " +
            "from Tbl_Usuarios " +
            "where usuario='" + param1 + "' and senha='" + param2 + "' ";
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao1.Select(stringselect);

        while (dados.Read())
        {
            url = "PainelCliente.aspx?v1=" + Convert.ToString(dados[0]) + "&v2=" + Convert.ToString(dados[1]);
        }

        return url;
    }

    [WebMethod]
    public string entregaSalvar(string param1, string param2, string param3, string param4, string param5,string param6)
    {
        string param7 = DateTime.Now.ToString("yyyy-MM-dd");
        
        //atenção corrigir
        string id_selecionada = "1";
        string txtDestinatario = "Destinatario";
        string txtBairro = "Bairro";
        string txtCidade = "Salvador";
        string txtTelefone = "(71) 9999-9999";
        string Lat = "-12.5000";
        string Lng = "-38.5000";

        string msg="XXX";

        string strInsert = "INSERT INTO Tbl_Entregas (ID_Cliente, ID_Motoboy, Nome_Destinatario, Endereco, Ponto_Ref, " +
                    "Bairro, Cidade, Data_Encomenda, Telefone, Entregue,Latitude,Longitude,Status_Entrega,Partida_Iniciada,Observacoes ) VALUES (" + param1 +
                    "," + id_selecionada + ", '" + txtDestinatario + "', '" + param2 + "', '" + param4 +
                    "', '" + txtBairro + "', '" + txtCidade + "', '" + param7 + "', '" + txtTelefone + "', 0,'" +
                    Lat  + "', '" + Lng + "','EM ABERTO',0,'" +  param5 + "')";

        OperacaoBanco operacao = new OperacaoBanco();
        bool inserir = operacao.Insert(strInsert);
        ConexaoBancoSQL.fecharConexao();

        if (inserir == true)
        {
            msg = "SOLICITAÇÃO ENVIADA COM SUCESSO";
        }
        else
        {
            msg = "TENTE NOVAMENTE";
        }

        return msg;
    }

    [WebMethod]
    public string EntregaExcluir(string param1)
    {
        string url = "Sorry.aspx";

        OperacaoBanco operacao = new OperacaoBanco();
        Boolean deletar = operacao.Delete("delete from Tbl_Entregas where ID_Entrega = " + param1);
        ConexaoBancoSQL.fecharConexao();

        if (deletar == true)
        {
            url = "EntregaHistorico.aspx";
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
        stringconnection1 = @"Server=tcp:serverlog.database.windows.net,1433;Initial Catalog=dblog;Persist Security Info=False;User ID=admserver;Password=Pwd@2017;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

