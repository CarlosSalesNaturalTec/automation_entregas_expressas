using System;
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
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ORIGEM</th>" +
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
                "where ID_Cliente = " + param + " " +
                "and historico=0";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id entrega

            string Coluna1 = Convert.ToString(dados[1]).Substring(0, Convert.ToString(dados[1]).IndexOf(","));           
            string Coluna2 = Convert.ToString(dados[2]).Substring(0, Convert.ToString(dados[2]).IndexOf(","));
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);
            string Coluna7 = Convert.ToString(dados[6]);    //Status pagamento
            string Coluna8 = Convert.ToString(dados[7]);

            string codePagam = "", classPag="";
            string codeDelete = "", classDelete = "";

            if (Coluna7 == "Em Aberto") {
                if (Coluna5 == "Cartão") {
                    codePagam = "iniciapag(" + Coluna0 + " , " + Coluna4.Replace(",",".") + ");";
                    classPag = "w3-btn w3-round w3-hover-green w3-padding";
                } else
                {
                    codePagam = "";
                    classPag = "w3-btn w3-round w3-padding";
                }

                codeDelete = "excluirEntrega(" + Coluna0 + ");";      
                classDelete = "w3-btn w3-round w3-hover-red w3-padding";

            } else if (Coluna7 == "Faturado")
            {
                codePagam = "Em Aberto";
                classPag = "w3-btn w3-round w3-padding";

                if (Coluna8 == "Em Aberto")
                {
                    codeDelete = "excluirEntrega(" + Coluna0 + ");";
                    classDelete = "w3-btn w3-round w3-hover-red w3-padding";
                }
                else
                {
                    codeDelete = "";
                    classDelete = "w3-btn w3-round w3-padding";
                }
                
            }
            else 
            {
                codePagam = "";
                classPag = "w3-btn w3-round w3-padding";

                if (Coluna8 == "Em Aberto")
                {
                    codeDelete = "excluirEntrega(" + Coluna0 + ");";
                    classDelete = "w3-btn w3-round w3-hover-red w3-padding";
                }
                else
                {
                    codeDelete = "";
                    classDelete = "w3-btn w3-round w3-padding";
                }
            }

            string bt1 = "<a class='" + classPag + "' onclick='" + codePagam +  "'><i class='fa fa-usd' aria-hidden='true'></i></a>";
            string bt2 = "<a class='" + classDelete + "' onclick='" + codeDelete + "'><i class='fa fa-trash-o' aria-hidden='true'></i></a>";
            string bt3 = "<a class='w3-btn w3-round w3-hover-blue' href='EntregaFicha.aspx?v1=" + Coluna0 + "'><i class='fa fa-info-circle' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + bt3 + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + "R$" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
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