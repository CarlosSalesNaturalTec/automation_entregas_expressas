﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGVAI - Motoboy para Entregas Expressas em Salvador-BA</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <!-- MENU -->
    <div class="w3-bar w3-white" id="mypage">
        <a class="w3-bar-item w3-btn w3-border w3-round w3-right w3-text-red" style="margin-top: 10px; margin-bottom: 10px; margin-right: 40px"
            onclick="ExibirModal();">Entrar
            <i class="fa fa-sign-in" aria-hidden="true"></i>
        </a>
    </div>
    <!-- MENU -->

    <!-- page content -->
    <div>
        <iframe src="HtmlPage2.html" width="100%" height="790" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>
    <!-- /page content -->

    <!-- Modal Login -->
    <div id="id01" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <header class="w3-container w3-red w3-center">
                <span onclick="document.getElementById('id01').style.display='none'"
                    class="w3-button w3-display-topright">&times;</span>
                <h4>Área do Cliente</h4>
            </header>

            <form class="w3-container">
                <div class="w3-section">
                    <label><b>Usuario</b></label>
                    <input id="input_User" class="w3-input w3-border w3-round w3-margin-bottom" type="text" placeholder="Nome do Usuário" name="usrname"
                        required>
                    <label><b>Senha</b></label>
                    <input id="input_pwd" class="w3-input w3-border w3-round" type="password" placeholder="Digite sua senha" name="psw" required>

                    <a id="btentrar" class="w3-btn w3-block w3-round w3-border w3-hover-red w3-section w3-padding" onclick="TentarLogin()">Entrar <i class="fa fa-sign-in" aria-hidden="true"></i></a>
                    <p><a href="#" class="w3-btn w3-block w3-round w3-border w3-hover-red w3-section w3-padding" onclick="SignIn();">Criar Conta</a></p>
                </div>
            </form>
        </div>
    </div>
    <!-- Modal Login -->
    <!-- Scripts diversas -->
    <script type="text/javascript">

        function ExibirModal() {
            document.getElementById('id01').style.display = 'block';
            document.getElementById('input_User').focus();
        }

        function SignIn() {
            document.getElementById('id01').style.display = 'none';
            window.open('SignIn.aspx', 'iframe');
        }
    </script>

    <!-- Script cadastro -->
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/codeLogin.js"></script>
    <!-- Script cadastro -->

</body>
</html>
