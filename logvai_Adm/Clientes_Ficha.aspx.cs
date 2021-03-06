﻿using System;
using System.Text;

public partial class Clientes_Ficha : System.Web.UI.Page
{

    StringBuilder str = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        //validações de login
        string param = Session["IDUser"].ToString();
        if (param == "00") { Response.Redirect("Sorry.aspx"); }

        string idFicha = Request.QueryString["v1"];

        PreencheCampos(idFicha);
        Literal1.Text = str.ToString();

    }

    private void PreencheCampos(string ID)
    {
        string ScriptDados = "";

        string stringSelect = "select nome,tipoPessoa,usuario,cpfcnpj,contato,endereco,numero,complemento,telefone,Cupom,faturar " +
            "from Tbl_Usuarios " +
            "where ID_User = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            string permite = "";
            if (Convert.ToString(rcrdset[10]) == "True")
            {
                permite = "SIM";
            }
            else
            {
                permite = "NÃO";
            }

            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('input_nomeRazao').value = \"" + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('input_User').value = \"" + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('input_cpfCnpj').value = \"" + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('input_contato').value = \"" + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('input_endereco').value = \"" + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('input_numero').value = \"" + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('input_complemento').value = \"" + Convert.ToString(rcrdset[7]) + "\";" +
                "document.getElementById('input_telefone').value = \"" + Convert.ToString(rcrdset[8]) + "\";" +
                "document.getElementById('input_cupom').value = \"" + Convert.ToString(rcrdset[9]) + "\";" +
                "document.getElementById('input_faturar').value = \"" + permite + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();

        str.Clear();
        str.Append(ScriptDados);
    }
}