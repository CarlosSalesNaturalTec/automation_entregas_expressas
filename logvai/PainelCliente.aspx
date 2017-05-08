<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PainelCliente.aspx.cs" Inherits="PainelCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>LOGVAI - Área do Cliente</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <div class="w3-sidebar w3-bar-block w3-light-grey w3-card-2" style="width: 17%">
        <div class="w3-container w3-centered">
            <img src="images/logo.png" alt="Logomarca LOGVAI">
        </div>
        <h1 class="w3-bottombar"></h1>

        <!-- MENU -->
        <section>
            <a href="EntregaNova.aspx" target="iframe_a" class="w3-bar-item w3-button"><i class="fa fa-motorcycle" aria-hidden="true"></i>&nbsp;&nbsp;Nova Entrega</a>
            <a href="EntregaAcompanhar.aspx" target="iframe_a" class="w3-bar-item w3-button"><i class="fa fa-map-marker" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;&nbsp;Acompanhar</a>
            <a href="EntregaHistorico.aspx" target="iframe_a" class="w3-bar-item w3-button"><i class="fa fa-history" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Histórico</a>
            <a href="UserCount.aspx" target="iframe_a" class="w3-bar-item w3-button"><i class="fa fa-cog" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Minha Conta</a>
            <a href="#" onclick="SairExit();" class="w3-bar-item w3-button"><i class="fa fa-sign-out" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp;Sair</a>
            <div class="w3-small w3-text-blue w3-padding">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<asp:Label ID="lblUser" runat="server"></asp:Label>]
            </div>
        </section>
        <!-- MENU -->
    </div>

    <!-- page content -->
    <div style="margin-left: 17%">
        <iframe src="EntregaNova.aspx" width="100%" height="800" frameborder="0" name="iframe_a">Atualize seu Navegador!</iframe>
    </div>
    <!-- page content -->

    <script src="scripts/codePainelCliente.js" type="text/javascript"></script>

    <!-- Scripts diversas -->
    <script type="text/javascript">

        window.addEventListener('DOMContentLoaded', function (e) {
            var iFrame = document.getElementById('iframe_a');
            resizeIFrameToFitContent(iFrame);
        });

        function resizeIFrameToFitContent(iFrame) {
            //iFrame.width = iFrame.contentWindow.document.body.scrollWidth;
            iFrame.height = iFrame.contentWindow.document.body.scrollHeight;
        }

    </script>

</body>
</html>
