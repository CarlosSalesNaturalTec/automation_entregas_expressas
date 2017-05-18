<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaFicha.aspx.cs" Inherits="EntregaHistorico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Ficha Detalhe de Entregas</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <div class="w3-container w3-light-gray w3-center">
        <header>
            <h5><strong>Ficha Detalhe da Solicitação</strong></h5>
        </header>
    </div>
    
    <div class="w3-container w3-section w3-padding w3-light-grey w3-border w3-small ">

        <div class="w3-quarter w3-padding">
            <p>Solicitação:</p>
            <p>Local Origem:</p>
            <p>Local Destino:</p>
            <p>Distancia Total (Km):</p>
            <p>Tipo Atendimento:</p>
            <p>Valor Total:</p>
            <p>Cod.Transação:</p>
            <p>Forma de Pagam.:</p>
            <p>Status do Pagam.:</p>
            <p>Status da OS:</p>
            
        </div>
        <div class="w3-half w3-padding">
            <p>[<span id="OSid"></span>]&nbsp;&nbsp;<span id="OSdata"></span></p>
            <p><span id="OSorigem"></span></p>
            <p><span id="OSdestino"></span></p>
            <p><span id="OSdist"></span> Km</p>
            <p><span id="OStipo"></span></p>
            <p>R$ <span id="OSvalor"></span></p>
            <p><span id="OSCod"></span></p>
            <p><span id="OSFormaPag"></span></p>
            <p><span id="OSstatusPag"></span></p>
            <p><span id="OSstatusOS"></span></p>
            
        </div>

    </div>

    <!-- campo auxiliar -->
    <input id="IDHidden" name="IDHidden" type="hidden" />

    <!-- Scripts diversas -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <script src="scripts/codeEntregaFicha.js"></script>
    <script src="scripts/jquery-3.1.1.min.js" type="text/javascript"></script>

</body>

</html>
