using System;
using System.Text;

public partial class EntregaHistorico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //monta GRID
            montaCabecalho();
            dadosCorpo();
            montaRodape();
            Literal1.Text = str.ToString();
        }
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>ID</th>" +
            "<th>DATA</th>" +
            "<th>DIST (KM)</th>" +
            "<th>VALOR (R$)</th>" +
            "<th>TIPO</th>" +
            "<th>FORMA PAGAM.</th>" +
            "<th>STATUS PAGAM.</th>" +
            "<th>STATUS OS</th>" +
            "<th>COD.TRANSACAO</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select ID_Entrega, format(Data_OS,'dd-MM-yyyy HH:mm:ss') as D1, Distancia_Total , " +
                "Valor_Total , Tipo_Atendimento, Forma_Pagam , Status_Pagam, Status_OS , PSCodTransacao  " +
                "from Tbl_Entregas_Master where ID_Cliente = " + Session["UserID"].ToString();

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[1]);
            string Coluna3 = Convert.ToString(dados[2]);
            string Coluna4 = Convert.ToString(dados[3]);
            string Coluna5 = Convert.ToString(dados[4]);
            string Coluna6 = Convert.ToString(dados[5]);
            string Coluna7 = Convert.ToString(dados[6]);
            string Coluna8 = Convert.ToString(dados[7]);
            string Coluna9 = Convert.ToString(dados[8]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
                "<td>" + Coluna9 + "</td>" +
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