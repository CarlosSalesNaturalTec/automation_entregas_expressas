<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaAcompanhar.aspx.cs" Inherits="EntregaAcompanhar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Acompanhar Entrega</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        #map {
            height: 100%;
            width: 100%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>

</head>

<body>

    <div >
        <header class="w3-container w3-light-gray w3-center">
            <h6><strong>Acompanhamento de Entregas</strong></h6>
        </header>
    </div>

    <!-- MAPA -->
    <div id="map"></div>
    <!-- MAPA -->

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>

</body>

</html>
