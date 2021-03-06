﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faturas_Gerar.aspx.cs" Inherits="Faturas_Gerar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

    <!-- Total a Faturar -->
    <br />
    <div class="w3-container w3-border w3-round w3-padding w3-light-gray" style="margin-left: 2%; margin-right: 2%">
        <i class="fa fa-dollar fa-2x w3-text-blue"></i>&nbsp;&nbsp;<strong>Total a Faturar: R$ <asp:Literal ID="lblTotal" runat="server"></asp:Literal></strong>
    </div>
    <br />

    <div class="w3-small">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>

</body>
</html>
