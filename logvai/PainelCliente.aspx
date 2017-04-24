<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PainelCliente.aspx.cs" Inherits="PainelCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>LOGVAI - Área do Cliente</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</head>

<body>

    <div class="w3-sidebar w3-bar-block w3-light-grey w3-card-2" style="width: 15%">
        <div class="w3-container">
            <img src="images/logo.png" alt="Logomarca LOGVAI" class="w3-left">
        </div>
        <h1 class="w3-bottombar"></h1>
        <a href="EntregaNova.aspx" target="iframe_a" class="w3-bar-item w3-button">Nova Entrega</a>
        <a href="EntregaAcompanhar.aspx" target="iframe_a" class="w3-bar-item w3-button">Acompanhar Entrega</a>
        <a href="EntregaHistorico.aspx" target="iframe_a" class="w3-bar-item w3-button">Histórico</a>
        <a href="UserCount.aspx" target="iframe_a" class="w3-bar-item w3-button">Minha Conta</a>
    </div>

    <div style="margin-left: 15%">

        <iframe src="EntregaNova.aspx" width="100%" height="840" frameborder="0" name="iframe_a">Atualize seu Navegador!</iframe>

    </div>

</body>
</html>
