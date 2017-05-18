using System;
using System.Text;

public partial class EntregaHistorico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["v1"]);
        Literal1.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";

        string stringSelect = "select Data_OS, LocalOrigem, LocalDestino , Distancia_Total,Tipo_Atendimento, Valor_Total,  " +
            "Forma_Pagam, Status_Pagam, Status_OS, PSCodTransacao " +
            "from Tbl_Entregas_Master " +
            "where ID_Entrega = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('OSid').textContent = \"" + ID + "\";" +
                "document.getElementById('OSdata').textContent = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('OSorigem').textContent = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('OSdestino').textContent = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('OSdist').textContent = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('OStipo').textContent = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('OSvalor').textContent = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('OSFormaPag').textContent = \"" + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('OSstatusPag').textContent = \"" + Convert.ToString(rcrdset[7]) + "\";" +
                "document.getElementById('OSstatusOS').textContent = \"" + Convert.ToString(rcrdset[8]) + "\";" +
                "document.getElementById('OSCod').textContent = \"" + Convert.ToString(rcrdset[9]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
    }


}