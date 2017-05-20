<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PainelPrincipal.aspx.cs" Inherits="PainelPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>LOG VAI - Painel de Controle</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <div class="w3-sidebar w3-bar-block w3-light-grey w3-card-2" style="width: 17%">

        <div>
            <header class="w3-container w3-blue w3-text-white w3-center">
                <h5><strong>Painel de Controle</strong></h5>
            </header>
        </div>

        <div class="w3-section w3-padding w3-center">
            <a href="PainelInicial.aspx" target="iframe_a">
                <img src="images/logo.png" alt="Logomarca LOGVAI"></a>
        </div>

        <!-- MENU -->
        <section>
            <a href="Clientes_Listagem.aspx" target="iframe_a" class="w3-bar-item w3-btn w3-hover-light-blue"><i class="fa fa-user" aria-hidden="true"></i>&nbsp;&nbsp;Clientes</a>

            <div class="w3-dropdown-hover">
                <a class="w3-btn w3-block w3-left-align w3-hover-light-blue" onclick="myFunction('submenu1')"><i class="fa fa-calculator" aria-hidden="true"></i>&nbsp;Faturamento </a>
                <div id="submenu1" class="w3-container w3-hide">
                    <a href="Faturas_Gerar.aspx" target="iframe_a" onclick="myFunction('submenu1')" class="w3-bar-item w3-button w3-hover-light-blue">Gerar Faturas</a>
                    <a href="Faturas_Historico.aspx" target="iframe_a" onclick="myFunction('submenu1')" class="w3-bar-item w3-button w3-hover-light-blue">Histórico </a>
                </div>
            </div>

            <a href="#" onclick="SairExit();" class="w3-bar-item w3-btn w3-hover-light-blue"><i class="fa fa-sign-out" aria-hidden="true"></i>&nbsp;Sair</a>
            <div class="w3-small w3-text-blue w3-padding">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<asp:Label ID="lblUser" runat="server"></asp:Label>]
            </div>
        </section>
        <!-- MENU -->
    </div>

    <!-- page content -->
    <div style="margin-left: 17%">
        <iframe src="PainelInicial.aspx" width="100%" height="880" frameborder="0" name="iframe_a">Atualize seu Navegador!</iframe>
    </div>
    <!-- page content -->

    <script type="text/javascript" src="scripts/codePainelPrincipal.js"></script>
    <script>
        function myFunction(id) {
            var x = document.getElementById(id);
            if (x.className.indexOf("w3-show") == -1) {
                x.className += " w3-show";
            } else {
                x.className = x.className.replace(" w3-show", "");
            }
        }
    </script>

</body>
</html>
