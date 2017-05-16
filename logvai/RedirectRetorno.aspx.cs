using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RedirectRetorno : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idPag = Request.QueryString["id_pagseguro"];
        if (idPag != null)
        {
            gravaCodTransacao(idPag, Session["OSId"].ToString());
        }
    }

    private void gravaCodTransacao(string param1, string param2)
    {
        OperacaoBanco operacao = new OperacaoBanco();
        bool gravar = operacao.Insert("update Tbl_Entregas_Master set PSCodTransacao = '" + param1 + "' where ID_Entrega =" + param2);
        ConexaoBancoSQL.fecharConexao();
        if (gravar == true)
        {
            //direcionando para PainelCliente2.aspx pois não estou conseguindo fazer com que PainelCliente.aspx recarregue a página de histórico no iframe
            //PainelCliente2.aspx deve ser sempre uma copia de PainelCliente.aspx com execssão da página inicial que deve ser a de histórico 
            Response.Write("<script>self.parent.location.href='http://logvai01.azurewebsites.net/PainelCliente2.aspx';</script>");
        }
        else
        {
            Response.Write("<script>self.parent.location.href='http://logvai01.azurewebsites.net/Sorry.aspx';</script>");
        }
    }
}