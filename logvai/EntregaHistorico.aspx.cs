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
            "<th>ORIGEM</th>" +
            "<th>DESTINO</th>" +
            "<th>TIPO</th>" +
            "<th>FORMA PAGAM.</th>" +
            "<th>VALOR (R$)</th>" +
            "<th>Detalhes</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select ID_Entrega, format(Data_OS,'dd-MM-yyyy HH:mm:ss') as D1, LocalOrigem  , " +
                "LocalDestino , Tipo_Atendimento, Forma_Pagam , Valor_Total " +
                "from Tbl_Entregas_Master " +
                "where ID_Cliente = " + Session["UserID"].ToString() +
                " and historico=1";

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

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='EntregaFicha.aspx?v1=" + Coluna1 + "'><i class='fa fa-info-circle' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + bt1 + "</td>" +
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