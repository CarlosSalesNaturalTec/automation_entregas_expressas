using System;
using System.Text;

public partial class EntregaHistorico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    StringBuilder strFoto = new StringBuilder();
    StringBuilder strMapa = new StringBuilder();

    String IDAux;
    string idmotoboy = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        IDAux = Request.QueryString["v1"];

        //preenche campos
        PreencheCampos(IDAux);
        Literal1.Text = str.ToString();

        //grid entregas filhas
        montaCabecalho();
        dadosCorpo(IDAux);
        montaRodape();

        //Monta Mapa
        montaMapa(IDAux, idmotoboy);
        LiteralMapa.Text = strMapa.ToString();

    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "", ScriptFoto = "";
        

        string stringSelect = "select format(Data_OS,'dd/MM/yyyy hh:mm:ss') as DataOS, Distancia_Total,Tipo_Atendimento, Valor_Total,  " +
            "Forma_Pagam, Status_Pagam, Status_OS, PSCodTransacao, ID_Motoboy " +
            "from Tbl_Entregas_Master " +
            "where ID_Entrega = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('OSdata').textContent = \"Data: " + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('OSid').textContent = \"Número: " + ID + "\";" +
                "document.getElementById('OSdist').textContent = \"Distancia Total: " + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('OStipo').textContent = \"Tipo Atendimento: " + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('OSvalor').textContent = \"Valor Total: R$ " + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('OSFormaPag').textContent = \"Forma de Pagam.: " + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('OSstatusPag').textContent = \"Status do Pagam.: " + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('OSstatusOS').textContent = \"Status da OS: " + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('OSCod').textContent = \"Cod.Transação: " + Convert.ToString(rcrdset[7]) + "\";" +
                "</script>";
            idmotoboy = Convert.ToString(rcrdset[8]);
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);


        //foto do motoboy
        stringSelect = "select FotoDataURI, Nome, Placa " +
            "from Tbl_Motoboys " +
            "where ID_Motoboy = " + idmotoboy;
        operacao = new OperacaoBanco();
        rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptFoto = "<script type=\"text/javascript\">" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[0]) + "\"/>'; " +
                "document.getElementById('OSNome').textContent = \"" + Convert.ToString(rcrdset[1]) + " / Placa: " + Convert.ToString(rcrdset[2]) +  "\";" +              
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        strFoto.Clear();
        strFoto.Append(ScriptFoto);
        LiteralFoto.Text = strFoto.ToString();

    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>ENDEREÇO</th>" +
            "<th>STATUS</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo(string ID)
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select Endereco, Status_Entrega " +
                "from Tbl_Entregas " +
                "where ID_Entrega = " + ID +
                " order by Ordem";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);
          
            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
        }
        ConexaoBancoSQL.fecharConexao();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal2.Text = str.ToString();
    }

    private void montaMapa(string IDEntrega, string IDMotoboy)
    {

        string scriptTxt = "";
        strMapa.Clear();

        scriptTxt = "<script type='text/javascript'>";
        strMapa.Append(scriptTxt);

        scriptTxt = "var linkurl = \"EntregaFicha_Mapa.aspx?v1=\"" + IDEntrega + "&v2=" + IDMotoboy + "\";";
        strMapa.Append(scriptTxt);

        scriptTxt = "window.open(linkurl, 'iframeMap');";
        strMapa.Append(scriptTxt);

        scriptTxt = "</script>";
        strMapa.Append(scriptTxt);
    }
}