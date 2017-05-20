using System;
using System.Text;

public partial class Faturas_Gerar : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        //validações de login
        string param = Session["IDUser"].ToString();
        if (param == "00") { Response.Redirect("Sorry.aspx"); }

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
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLIENTE</th>" +
            "<th>QUANT.</th>" +
            "<th>VALOR</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        string stringselect = "select ID_Cliente,Tbl_Usuarios.nome,  count(ID_Entrega) as Quant, sum(Valor_Total) as ValorTotal " +
            "from Tbl_Entregas_master " +
            "INNER JOIN Tbl_Usuarios ON Tbl_Entregas_Master.ID_Cliente = Tbl_Usuarios.ID_User " +
            "where Forma_Pagam = 'Faturado' and ID_Fatura = 0 " +
            "group by ID_Cliente,Tbl_Usuarios.nome";

        decimal Vtotal=0;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id cliente

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
           
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='Faturas_Ficha.aspx?v1=" + Coluna0 + "&v2=" + Coluna1
                + "'><i class='fa fa-list-ul' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);

            Vtotal += Convert.ToDecimal(Coluna3);

        }
        ConexaoBancoSQL.fecharConexao();
        lblTotal.Text = Vtotal.ToString();

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);
    }
}