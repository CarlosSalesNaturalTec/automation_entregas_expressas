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

    <div>
        <!-- Menu -->
        <div class="w3-bar w3-light-blue">

            <a href="#" class="w3-bar-item w3-btn w3-hover-blue w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-blue"><i class="fa fa-cog" aria-hidden="true"></i>&nbsp;Configurações</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="UserCount.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-blue">Minha Conta</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-blue"><i class="fa fa-calendar-check-o" aria-hidden="true"></i>&nbsp;Solicitações</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="EntregaNova.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-blue">Nova</a>
                    <a href="EntregaAcompanhar.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-blue">Em Andamento</a>
                    <a href="EntregaHistorico.aspx" target="iframe" class="w3-bar-item w3-button w3-hover-blue">Histórico</a>
                </div>
            </div>

            <a href="Home.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-blue w3-right"><i class="fa fa-home"></i>&nbsp;Início</a>

        </div>

    </div>

    <!-- page content -->
    <div>
        <div class="w3-display-middle w3-opacity-max">
            <img src="images/LOGO1.png" />
        </div>
        <div class="w3-container w3-padding-16 w3-light-grey">
            <iframe src="EntregaNova.aspx" width="100%" height="880" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
        </div>
    </div>
    <!-- page content -->

    

    <!-- Modal LogOff -->
    <div id="DivLogOut" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <form class="w3-container">
                <div class="w3-section w3-center">
                    <header class="w3-container w3-blue w3-center">
                        <h4><strong>Atenção</strong></h4>
                    </header>
                    <br />
                    <i class="fa fa-3x fa-exclamation-triangle" aria-hidden="true"></i>
                    <br />
                    <h3><strong>Confirma Saida?</strong> </h3>
                    <br />
                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-blue" onclick="sair_cancel()">Não</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-red" onclick="sair_exit()">Sim</button>
                    </p>
                    <br />
                </div>
            </form>
        </div>
    </div>
    <!-- Modal LogOff -->

    <!-- scripts diversos -->
    <script src="scripts/codePainelCliente.js" type="text/javascript"></script>

</body>
</html>
