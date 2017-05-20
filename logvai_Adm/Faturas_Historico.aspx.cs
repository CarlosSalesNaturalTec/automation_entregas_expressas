using System;
using System.Text;

public partial class Faturas_Historico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

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
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NÚMERO</th>" +
            "<th>CLIENTE</th>" +
            "<th>EMISSÃO</th>" +
            "<th>QUANT.</th>" +
            "<th>VALOR</th>" +
            "<th>VENCIMENTO</th>" +
            "<th>STATUS</th>" +
            "<th>DATA PAGAM</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_Fatura, Tbl_Usuarios.nome, Data_Fatura ,Quant , Valor_Total , Vencimento , Status_Pagam , Data_Pagamento  " +
                "from Tbl_Faturas " +
                "INNER JOIN Tbl_Usuarios ON Tbl_Faturas.ID_Cliente = Tbl_Usuarios.ID_User " +
                "order by ID_Fatura desc";
        
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

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='Faturas_HistoricoFicha.aspx?v1=" + Coluna1 + "&v2=" + Coluna2
                + "'><i class='fa fa-list-ul' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "<td>" + Coluna8 + "</td>" +
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