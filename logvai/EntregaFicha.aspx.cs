using System;
using System.Text;

public partial class EntregaHistorico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        PreencheCampos(Request.QueryString["ID"]);
        Literal1.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        string stringSelect = @"select Endereco , Ponto_Ref  , Observacoes " +
            "from Tbl_Entregas " +
            "where ID_Entrega  = " + ID;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('inputPonto1').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('inputComplemento1').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('detalhes1').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);
    }


}