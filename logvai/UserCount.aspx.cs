using System;
using System.Text;

public partial class UserCount : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        //PreencheCampos(Session["UserID"].ToString());
        //Literal1.Text = str.ToString();
    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";
        string stringSelect = @"select nome, usuario , cpfcnpj ,endereco , telefone " +
            "from Tbl_Usuarios  " +
            "where ID_User = " + ID;
        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('inputNome').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('inputUser').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('inputCPF').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('inputEnd').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('inputTel').value = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);
    }
}