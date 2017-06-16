using System;
using System.Text;

public partial class Clientes_Listagem : System.Web.UI.Page
{
    int TotaldeRegistros = 0;
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        montaCabecalho();
        dadosCorpo();
        montaRodape();

        Literal1.Text = str.ToString();
        lblTotalRegistros.Text = TotaldeRegistros.ToString();
    }

    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NOME</th>" +
            "<th>E-MAIL</th>" +
            "<th>CPF/CNPJ</th>" +
            "<th>CONTATO</th>" +
            "<th>TELEFONE</th>" +
            "<th>FATURAR</th>" +
            "<th>DATA CADASTRO</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_User , nome, usuario,cpfcnpj, contato, telefone, faturar, dataCadastro " +
                "from Tbl_Usuarios order by nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id usuario

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);
            string Coluna6 = Convert.ToString(dados[6]); //permite faturar
            string Coluna6a = "";
            if (Coluna6 == "True") { Coluna6a = "SIM"; } else { Coluna6a = "NÃO"; }

            string Coluna7 = Convert.ToString(dados[7]);
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='Clientes_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6a + "</td>" +
                "<td>" + Coluna7 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);
            TotaldeRegistros += 1;
        }
        ConexaoBancoSQL.fecharConexao();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}