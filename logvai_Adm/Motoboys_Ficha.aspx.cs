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
        string stringSelect = "select Nome " +
            "from Tbl_Motoboys " +
            "where ID_func  = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('input_nome').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('input_apelido').value = \"" + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('input_posicao').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('input_local').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('input_nascimento').value = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('input_nacionalidade').value = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('input_idioma').value = \"" + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('input_clube').value = \"" + Convert.ToString(rcrdset[7]) + "\";" +
                "document.getElementById('input_inicio').value = \"" + Convert.ToString(rcrdset[8]) + "\";" +
                "document.getElementById('input_final').value = \"" + Convert.ToString(rcrdset[9]) + "\";" +
                "document.getElementById('input_cbf').value = \"" + Convert.ToString(rcrdset[10]) + "\";" +
                "document.getElementById('input_direito').value = \"" + Convert.ToString(rcrdset[11]) + "\";" +
                "document.getElementById('input_procura').value = \"" + Convert.ToString(rcrdset[12]) + "\";" +
                "document.getElementById('input_altura').value = \"" + Convert.ToString(rcrdset[13]) + "\";" +
                "document.getElementById('input_peso').value = \"" + Convert.ToString(rcrdset[14]) + "\";" +
                "document.getElementById('input_chute').value = \"" + Convert.ToString(rcrdset[15]) + "\";" +
                "document.getElementById('input_carac').value = \"" + Convert.ToString(rcrdset[16]).Replace("\n", " ") + "\";" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[17]) + "\"/>'; " +
                "</script>";            
        }

        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
    }
}