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
                <label>Senha</label>
                <input type="password" name="psw" id="input_psw" class="w3-input w3-border w3-round-large" style="width: 95%" disabled>
            </div>

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

            <div class="w3-section">
                <input id="btSignIn" type="button" class="w3-button w3-block w3-green w3-section w3-padding" onclick="" value="Alterar" />
                <a id="btTermos" href="Termos.aspx" class="w3-button w3-block w3-green w3-section w3-padding">Termos de Uso</a>
            </div>

            <div id="divHidden" style="display: none" class="w3-center">
                <i class="fa fa-spinner fa-pulse fa-fw"></i>
            </div>

        </form>

    </div>

</body>

</html>
