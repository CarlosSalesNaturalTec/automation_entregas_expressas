using System;
using System.Text;

public partial class Mapa_Entregas_Listagem : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    string param = "0";
    int TotaldeRegistros = 0;

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
            "<th>&nbsp;&nbsp;HORA</th>" +
            "<th>CLIENTE</th>" +
            "<th>ORIGEM</th>" +
            "<th>DESTINO</th>" +
            "<th>TIPO</th>" +
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
        string stringselect = "select ID_Entrega, format(Data_Servico,'HH:mm:ss') as D1, Tbl_Usuarios.Nome, LocalOrigem, LocalDestino, " +
                "Tipo_Atendimento, Status_OS " +
                "from Tbl_Entregas_Master " +
                "INNER JOIN Tbl_Usuarios ON Tbl_Entregas_Master.ID_Cliente = Tbl_Usuarios.ID_User " +
                "where Status_Pagam<>'Em Aberto' and Status_OS = 'Em Aberto'";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id entrega

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);

            string Coluna3 = Convert.ToString(dados[3]).Substring(0, Convert.ToString(dados[3]).IndexOf(","));
            string Coluna4 = Convert.ToString(dados[4]).Substring(0, Convert.ToString(dados[4]).IndexOf(","));
            string Coluna5 = Convert.ToString(dados[5]);
            string Coluna6 = Convert.ToString(dados[6]);

            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='Entregas_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-info-circle' aria-hidden='true'></i></a>";

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna6 + "</td>" +
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