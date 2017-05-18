<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCount.aspx.cs" Inherits="UserCount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Minha Conta</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</head>

<body>

    <div>
        <header class="w3-container w3-light-gray w3-center">
            <h6><strong>Minha Conta</strong></h6>
        </header>

        <form class="w3-container">

            <label id="lblNomeRazao">Nome</label>
            <input type="text" name="nomeRazao" id="input_nomeRazao" class="w3-input w3-border w3-round-large" disabled>

            <div class="w3-row">
                <div class="w3-half">
                    <label id="lblcpfCnpj">CPF</label>
                    <input type="text" name="cpfCnpj" id="input_cpfCnpj" class="w3-input w3-border w3-round-large" style="width: 95%" disabled>
                </div>
                <div id="divContato" class="w3-half" style="display: none">
                    <label>Contato</label>
                    <input type="text" name="contato" id="input_contato" class="w3-input w3-border w3-round-large" disabled>
                </div>
            </div>

            <label>e-mail</label>
            <input type="email" name="usrname" id="input_User" class="w3-input w3-border w3-round-large" disabled>

            <div class="w3-row">
                <div class="w3-threequarter">
                    <label>Endereço</label>
                    <input type="text" name="endereco" id="input_endereco" class="w3-input w3-border w3-round-large" style="width: 95%" disabled>
                </div>
                <div class="w3-quarter">
                    <label>Número</label>
                    <input type="text" name="numero" id="input_numero" class="w3-input w3-border w3-round-large" disabled>
                </div>
            </div>

            <div class="w3-row">
                <div class="w3-half">
                    <label>Complemento</label>
                    <input type="text" name="complemento" id="input_complemento" class="w3-input w3-border w3-round-large" style="width: 95%" disabled>
                </div>
                <div class="w3-half">
                    <label>Telefone</label>
                    <input type="text" name="telefone" id="input_telefone" class="w3-input w3-border w3-round-large" disabled>
                </div>
            </div>

            <label>Cupom de Desconto</label>
            <input type="text" name="telefone" id="input_cupom" class="w3-input w3-border w3-round-large" disabled>

            <div id="divBotoes" class="w3-section">
                <div class="w3-half">
                    <input id="btSignIn" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-green w3-hover-green" onclick="habilitacampos();" value="Alterar Dados" style="width: 95%" />
                </div>
                <div class="w3-half">
                    <a id="btTermos" href="Termos.aspx" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-green w3-hover-green">Termos de Uso</a>
                </div>
            </div>

            <div id="divbotoes1" style="display: none">

                <div class="w3-row">
                    <div class="w3-half">
                        <label>Senha</label>
                        <input type="password" name="psw" id="input_psw" class="w3-input w3-border w3-round-large" style="width: 95%" required>
                    </div>
                    <div class="w3-half">
                        <label>Confirme a Senha</label>
                        <input type="password" name="pswConf" id="input_pswConf" class="w3-input w3-border w3-round-large" required>
                    </div>
                </div>

                <div class="w3-half">
                    <input id="btsalvar" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-green w3-hover-green" onclick="salvar();" value="Salvar" />
                </div>
                <div class="w3-half">
                    <input id="btcancelar" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" onclick="cancelar();" value="Cancelar" style="width: 95%" />                    
                </div>
            </div>

            <input type="hidden" id="IDHidden" />
            <input type="hidden" id="TipoPHidden" />

        </form>

    </div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Script diversos -->
    <script type="text/javascript" src="scripts/codeUserCount.js"></script>
    <script src="scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <!-- Script diversos -->

</body>

</html>
