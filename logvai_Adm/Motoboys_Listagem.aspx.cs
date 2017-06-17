using System;
using System.Text;

public partial class Motoboys_Listagem : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();
    int TotaldeRegistros=0;

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
        //<!-- *** CUSTOMIZAÇÂO ***  -->
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NOME</th>" +
            "<th>TELEFONE</th>" +
            "<th>ÚLTIM.ATUALIZ.</th>" +
            "<th>MODELO</th>" +
            "<th>PLACA</th>" +
            "<th>ID</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";

        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo()
    {
        // <!-- *** CUSTOMIZAÇÂO ***  -->
        string stringselect = "select ID_Motoboy, nome, telefone, format(GeoDataLoc,'dd/MM/yy HH:mm:ss') as D1, modelo, placa " +
                "from Tbl_Motoboys order by nome";
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna0 = Convert.ToString(dados[0]); //id 

            string Coluna1 = Convert.ToString(dados[1]);
            string Coluna2 = Convert.ToString(dados[2]);
            string Coluna3 = Convert.ToString(dados[3]);
            string Coluna4 = Convert.ToString(dados[4]);
            string Coluna5 = Convert.ToString(dados[5]);

            // <!-- *** CUSTOMIZAÇÂO ***  -->
            string bt1 = "<a class='w3-btn w3-round w3-hover-blue' href='Motoboys_Ficha.aspx?v1=" + Coluna0 + "'><i class='fa fa-id-card-o' aria-hidden='true'></i></a>";
            string bt2 = "<a class='w3-btn w3-round w3-hover-red' onclick='Excluir(" + Coluna0 + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";

            string stringcomaspas = "<tr>" +
                "<td>" + bt1 + bt2 + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "<td>" + Coluna3 + "</td>" +
                "<td>" + Coluna4 + "</td>" +
                "<td>" + Coluna5 + "</td>" +
                "<td>" + Coluna0 + "</td>" +
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