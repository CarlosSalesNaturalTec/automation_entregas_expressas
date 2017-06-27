using System;
using System.Text;

public partial class EntregaHistorico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    String IDAux;

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
        Literal2.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";

        string stringSelect = "select Data_OS, LocalOrigem, LocalDestino , Distancia_Total,Tipo_Atendimento, Valor_Total,  " +
            "Forma_Pagam, Status_Pagam, Status_OS, PSCodTransacao " +
            "from Tbl_Entregas_Master " +
            "where ID_Entrega = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('OSid').textContent = \"" + ID + "\";" +
                "document.getElementById('OSdata').textContent = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('OSorigem').textContent = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('OSdestino').textContent = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('OSdist').textContent = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('OStipo').textContent = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('OSvalor').textContent = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('OSFormaPag').textContent = \"" + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('OSstatusPag').textContent = \"" + Convert.ToString(rcrdset[7]) + "\";" +
                "document.getElementById('OSstatusOS').textContent = \"" + Convert.ToString(rcrdset[8]) + "\";" +
                "document.getElementById('OSCod').textContent = \"" + Convert.ToString(rcrdset[9]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
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
                "where ID_Entrega = " + ID ;

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
    }
}