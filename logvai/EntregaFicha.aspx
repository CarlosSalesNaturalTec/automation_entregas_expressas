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

    <style>
        #map {
            width: 100%;
            height: 400px;
        }

    </style>

</head>

<body>

    <!-- Mapa -->
    <div id="map" class="w3-container w3-padding" height="400px" frameborder="0" ></div>

    <!-- Dados da Solicitação -->
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
            <h4>&nbsp;Status</h4>
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
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>

</body>

</html>
