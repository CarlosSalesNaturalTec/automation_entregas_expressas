<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
        <a href="cotacao.html" target="iframe_a" class="w3-bar-item w3-button w3-left">
            <img src="images/logo.png" alt=""></a>

        <a href="#" class="w3-bar-item w3-button w3-right"><i class="fa fa-search" aria-hidden="true"></i></a>
        <input type="text" class="w3-bar-item w3-input w3-border w3-right" placeholder="Localizar Entrega">
        <a onclick="ExibirModal();" class="w3-bar-item w3-button w3-mobile w3-right w3-hover-text-blue">Entrar <i class="fa fa-sign-in" aria-hidden="true"></i></a>
        <a href="contact.html" target="iframe_a" class="w3-bar-item w3-button w3-mobile w3-right w3-hover-text-blue">Contato <i class="fa fa-volume-control-phone" aria-hidden="true"></i></a>
        <a href="como.html" target="iframe_a" class="w3-bar-item w3-button w3-mobile w3-right w3-hover-text-blue">Como Funciona <i class="fa fa-question" aria-hidden="true"></i></a>
        <a href="services.html" target="iframe_a" class="w3-bar-item w3-button w3-mobile w3-right w3-hover-text-blue">Serviços <i class="fa fa-list-alt" aria-hidden="true"></i></a>
    </div>
    <!-- MENU -->


    <!-- page content -->
    <div class="right_col" role="main">
        <iframe src="cotacao.aspx" width="100%" height="840" frameborder="0" name="iframe_a">
            <p>Seu browser não suporta iframes.</p>
        </iframe>
    </div>
    <!-- /page content -->



    <!-- Modal Login -->
    <div id="id01" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <div class="w3-center">
                <br>
                <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright"
                    title="Fechar">&times;</span>
            </div>

            <form class="w3-container">
                <div class="w3-section">
                    <label><b>Usuario</b></label>
                    <input id="input_User" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Nome do Usuário" name="usrname"
                        required>
                    <label><b>Senha</b></label>
                    <input class="w3-input w3-border" type="password" placeholder="Digite sua senha" name="psw" required>
                    <button class="w3-button w3-block w3-green w3-section w3-padding" type="submit">Entrar</button>
                </div>
            </form>

            <div class="w3-container w3-center">
                <p><a href="#" onclick="SignIn();">Criar Conta</a></p>
            </div>
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
            window.open('signin.html', 'iframe_a');
        }
    </script>


</body>
</html>
