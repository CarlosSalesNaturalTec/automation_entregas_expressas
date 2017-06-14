<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entregas_Ficha.aspx.cs" Inherits="Entregas_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Ficha Detalhe de Entregas</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <header class="w3-container w3-blue w3-text-white w3-center">
        <h5><strong>Ficha Detalhe da Solicitação</strong></h5>
    </header>

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
            <p><span id="OSdist"></span>Km</p>
            <p><span id="OStipo"></span></p>
            <p>R$ <span id="OSvalor"></span></p>
            <p><span id="OSCod"></span></p>
            <p><span id="OSFormaPag"></span></p>
            <p><span id="OSstatusPag"></span></p>
            <p><span id="OSstatusOS"></span></p>

        </div>

        <div id="divBotoes" class="w3-section">
            <div class="w3-half">
                <input id="btvoltar" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" onclick="window.open('Entregas_Listagem.aspx', 'iframe');" value="Voltar" style="width: 95%" />
            </div>
            <div class="w3-half">
                <input id="btConfDep" type="button" class="w3-btn w3-round w3-section w3-padding w3-block w3-light-blue w3-hover-blue" 
                    onclick="confirmaDep()" value="Confirma Depósito Bancário" style="width: 95%" />
            </div>
        </div>

    </div>

    <!-- campo auxiliar -->
    <input id="IDHidden" name="IDHidden" type="hidden" />

    <!-- Scripts diversas -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <script type="text/javascript" src="scripts/codeEntregas_Ficha.js"></script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

</body>

</html>
