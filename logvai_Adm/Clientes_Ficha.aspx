<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Clientes_Ficha.aspx.cs" Inherits="Clientes_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGVAI - Painel de Controle</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>

    <div>
        <header class="w3-container w3-blue w3-text-white w3-center">
            <h5><strong>Ficha Individual de Cliente</strong></h5>
        </header>

        <form class="w3-container">

            <label id="lblNomeRazao">Nome</label>
            <input type="text" name="nomeRazao" id="input_nomeRazao" class="w3-input w3-border w3-round-large" disabled>

            <div class="w3-row">
                <div class="w3-half">
                    <label id="lblcpfCnpj">CPF/CNPJ</label>
                    <input type="text" name="cpfCnpj" id="input_cpfCnpj" class="w3-input w3-border w3-round-large" style="width: 95%" disabled>
                </div>
                <div id="divContato" class="w3-half">
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
            <div class="w3-row">
                <div class="w3-half">
                    <label>Cupom de Desconto</label>
                    <input type="text" name="cupom" id="input_cupom" class="w3-input w3-border w3-round-large" style="width: 95%" disabled>
                </div>
                <div class="w3-half">
                    <label>Permite Faturar</label>
                    <input type="text" name="faturar" id="input_faturar" class="w3-input w3-border w3-round-large" disabled>
                </div>
            </div>

            <div id="divBotoes" class="w3-section">
                <div class="w3-half">
                    <input id="btvoltar" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" onclick="window.open('Clientes_Listagem.aspx', 'iframe');" value="Voltar" style="width: 95%" />
                </div>
                <div class="w3-half">
                    <input id="btSignIn" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" onclick="liberaFaturamento()" value="Liberar/Bloquear Faturamento" />
                </div>
            </div>

            <input type="hidden" id="IDHidden" />

        </form>

    </div>

    <!-- scripts diversos -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <script type="text/javascript" src="scripts/codeClientes_Ficha.js"></script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

</body>
</html>
