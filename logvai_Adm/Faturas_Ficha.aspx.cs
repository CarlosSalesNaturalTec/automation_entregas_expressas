using System;
using System.Text;

public partial class Faturas_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string param;
    decimal vTotal=0;
    int vQuant=0;

    protected void Page_Load(object sender, EventArgs e)
    {

        lblNome.Text = Request.QueryString["v2"];
        param = Request.QueryString["v1"];
        hiddenID.Value = param;

        montaCabecalho();
        dadosCorpo();
        montaRodape();

        Literal1.Text = str.ToString();
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ORIGEM</th>" +
            "<th>DESTINO</th>" +
            "<th>TIPO</th>" +
            "<th>VALOR</th>" +
            "<th>PAGAM.</th>" +
            "<th>STATUS</th>" +
            "<th>SITUAÇÃO</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select ID_Entrega, LocalOrigem,LocalDestino, " +
                "Tipo_Atendimento, Valor_Total, Forma_Pagam , Status_Pagam, Status_OS " +
                "from Tbl_Entregas_Master " +
                "where Forma_Pagam = 'Faturado' and ID_Cliente = " + param +
                " and ID_Fatura = 0";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id entrega

            string Coluna1 = Convert.ToString(dados[1]).Substring(0, Convert.ToString(dados[1]).IndexOf(","));
            string Coluna2 = Convert.ToString(dados[2]).Substring(0, Convert.ToString(dados[2]).IndexOf(","));
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);    // valor
            string Coluna5 = Convert.ToString(dados[5]);
            string Coluna7 = Convert.ToString(dados[6]);    //Status pagamento
            string Coluna8 = Convert.ToString(dados[7]);

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='EntregaFicha.aspx?v1=" + Coluna0 + "'><i class='fa fa-info-circle' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + "R$" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);

            vTotal += Convert.ToDecimal(Coluna4);
            vQuant += 1;

        }
        ConexaoBancoSQL.fecharConexao();

        lblTotal.Text = "R$ " + vTotal.ToString();
        hiddenValor.Value = vTotal.ToString().Replace(",",".");
        hiddenQuant.Value = vQuant.ToString();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}