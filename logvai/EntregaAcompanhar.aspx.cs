using System;
using System.Globalization;
using System.Text;

public partial class EntregaAcompanhar : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string param = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        param = Session["UserID"].ToString();
        if (param == "0")
        {
            Response.Redirect("Sorry.aspx");
        }

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
            "<th>ORIGEM</th>" +
            "<th>DESTINO</th>" +
            "<th>TIPO</th>" +
            "<th>VALOR</th>" +
            "<th>STATUS PAGAM.</th>" +
            "<th></th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select LocalOrigem,LocalDestino, " +
                "Tipo_Atendimento, Valor_Total, Status_Pagam, ID_Entrega " +
                "from Tbl_Entregas_Master where ID_Cliente = " + param;

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

            string bt1 = "<input type='button' class='w3-button w3-round w3-green' value='Pagar&nbsp;'/> ";
            string bt2 = "<input type='button' class='w3-button w3-round w3-red' value='Excluir' onclick='excluirEntrega(" + Coluna6 + ");' /> ";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + "R$" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + bt1 + bt2 + "</td>" +
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