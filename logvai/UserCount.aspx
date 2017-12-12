<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCount.aspx.cs" Inherits="UserCount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Minha Conta</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>

<body>


    <br />
    <div class="w3-container w3-border w3-round w3-padding w3-light-blue w3-center" style="margin-left: 2%; margin-right: 2%">
        <h5><strong>Minha Conta</strong></h5>
    </div>
    <br />

    <div id="div1" class="w3-container w3-border w3-round w3-padding w3-light-gray w3-animate-left" style="margin-left: 2%; margin-right: 2%">

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
                    <a id="btTermos" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" onclick="document.getElementById('id01').style.display='block'" style="width: 95%">Termos de Uso</a>
                </div>
                <div class="w3-half">
                    <input id="btSignIn" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" onclick="habilitacampos();" value="Alterar Dados" />
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
                    <input id="btcancelar" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-blue w3-hover-light-blue" onclick="cancelar();" value="Cancelar" style="width: 95%" />
                </div>
                <div class="w3-half">
                    <input id="btsalvar" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-blue w3-hover-light-blue" onclick="salvar()" value="Salvar" />
                </div>

            </div>

            <input type="hidden" id="IDHidden" />
            <input type="hidden" id="TipoPHidden" />

        </form>

    </div>

    <div id="id01" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 600px">
            <header class="w3-container w3-light-blue w3-center">
                <span onclick="document.getElementById('id01').style.display='none'"
                    class="w3-button w3-display-topright">&times;</span>
                <h2>Termos de Uso</h2>
            </header>
            <div class="w3-container w3-section w3-padding w3-small">
                <iframe src="other/termos.txt" frameborder="0" scrolling="yes" height="400" width="550"></iframe>
            </div>
        </div>
    </div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Script diversos -->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDhhdJ8S6LYpsu33sFG26cWSUN3V9Qrorw&libraries=places"></script>
    <script type="text/javascript" src="scripts/codeUserCount.js"></script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <!-- Script diversos -->

</body>

</html>
