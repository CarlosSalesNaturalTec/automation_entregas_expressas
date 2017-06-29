<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entregas_Ficha.aspx.cs" Inherits="Entregas_Ficha" %>

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
            height: 100%;
            width: 50%;
        }

        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>

</head>

<body>

    <div class="w3-half w3-container w3-section w3-padding w3-light-grey w3-border w3-small ">

        <div class="w3-padding">
                <p>[ID: <span id="OSid"></span>]&nbsp;&nbsp;<span id="OSdata"></span></p>
                <p><span id="OSdist"></span>Km</p>
                <p><span id="OStipo"></span></p>
                <p><span id="OSvalor"></span></p>
                <p><span id="OSFormaPag"></span></p>
                <p><span id="OSstatusPag"></span></p>
                <p><span id="OSCod"></span></p>
                <p><span id="OSstatusOS"></span></p>
        </div>

        <div id="divBotoes" class="w3-section">
            <div class="w3-half">
                <input id="btConfDep" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue"
                    onclick="confirmaDep()" value="Confirma Depósito Bancário" style="width: 95%" />
            </div>
        </div>

        <div class="w3-small">
            <!-- Planilha  -->
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            <!-- Planilha  -->
        </div>

    </div>


    <!-- MAPA -->
    <div id="map" class="w3-right"></div>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>
    <!-- MAPA -->

    <!-- campo auxiliar -->
    <input id="IDHidden" name="IDHidden" type="hidden" />

    <!-- Scripts diversas -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <script src="scripts/codeEntregas_Ficha.js"></script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

</body>

</html>
