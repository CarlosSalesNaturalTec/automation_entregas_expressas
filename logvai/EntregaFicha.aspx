<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaFicha.aspx.cs" Inherits="EntregaHistorico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Ficha Detalhe de Entregas</title>
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

    <!-- Mapa -->
    <div class="w3-container w3-padding-16 w3-light-grey">
        <iframe src="EntregaFicha_Mapa.aspx" width="100%" height="400" frameborder="0" name="iframeMap">Atualize seu Navegador!</iframe>
    </div>

    <div>
        <div class="w3-third w3-container w3-section w3-padding w3-small">

            <h4>Dados da Solicitação</h4>
            <p><span id="OSid"></span></p>
            <p><span id="OSstatusOS"></span></p>
            <p><span id="OSdata"></span>&nbsp;&nbsp;</p>            
            <p><span id="OSdist"></span>Km</p>
            <p><span id="OStipo"></span></p>
            <p><span id="OSvalor"></span></p>
            <p><span id="OSFormaPag"></span></p>
            <p><span id="OSstatusPag"></span></p>
            <p><span id="OSCod"></span></p>            
        </div>

        <div class="w3-third w3-container w3-section w3-padding w3-small">
            <h4>&nbsp;&nbsp;Status</h4>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        </div>

        <div class="w3-third w3-container w3-section w3-padding w3-small w3-center">
            <h4>Dados do Entregador/Motoboy</h4>
            <p><span id="OSNome"></span></p>
            <div id="results"></div>
        </div>

    </div>


    <!-- campo auxiliar -->
    <input id="IDHidden" name="IDHidden" type="hidden" />

    <!-- Scripts diversas -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <asp:Literal ID="LiteralFoto" runat="server"></asp:Literal>
    <asp:Literal ID="LiteralMapa" runat="server"></asp:Literal>

    <script src="scripts/codeEntregaFicha.js"></script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

</body>

</html>
