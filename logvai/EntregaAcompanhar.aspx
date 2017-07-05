﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaAcompanhar.aspx.cs" Inherits="EntregaAcompanhar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Nova Entrega</title>
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

    <br />
    <div class="w3-container w3-border w3-round w3-padding w3-blue w3-center" style="margin-left: 2%; margin-right: 2%">
        <h5><strong>Acompanhamento de Solicitações</strong></h5>
    </div>
    <br />

    <!-- QUADRO 1 -->
    <div id="div1" class="w3-container w3-border w3-round w3-padding w3-light-gray w3-animate-left" style="margin-left: 2%; margin-right: 2%">
        <div class="w3-small">
            <!-- Planilha  -->
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <!-- Planilha  -->
        </div>
    </div>
    <!-- QUADRO 1 -->

    <script src="scripts/codeEntregaAcompanhar.js"></script>

    <script type="text/javascript">
        function iniciapag(idMaster, valor) {
            $("body").css("cursor", "progress");
            var chkurl = "RedirectPagam.aspx?v1=" + valor + "&v2=" + idMaster;
            window.open(chkurl, 'iframe');
        }
    </script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

</body>

</html>
