using System;
using System.Text;

public partial class Motoboys_Ficha : System.Web.UI.Page
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

        //<!--*******Customização*******-->
        string stringSelect = "select Nome,rg,endereco,FotoDataURI  " +
            "from Tbl_Motoboys " +
            "where ID_Motoboy = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('input_nome').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('input_RG').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('input_Endereco').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('Hidden1').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[3]) + "\"/>'; " +
                "</script>";            
        }

        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
    }
}