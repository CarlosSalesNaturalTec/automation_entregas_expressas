<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entregas_Listagem.aspx.cs" Inherits="Entregas_Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Solicitações em Aberto</title>
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
    <div>
        <header class="w3-container w3-blue w3-text-white w3-center w3-padding-small">
            <h4><strong>Solicitações em Aberto</strong></h4>
        </header>
    </div>

    <br />
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray" style="margin-left: 2%; margin-right: 2%">
        <small><i class="fa fa-calendar-check-o fa-2x w3-text-blue"></i>&nbsp;&nbsp;Total de Entregas em Aberto:
            <asp:Literal ID="lblTotalRegistros" runat="server"></asp:Literal></small> <!--*******Customização*******-->
    </div>
    <br />

    <div class="w3-small w3-animate-left">
        <!-- Planilha  -->
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <!-- Planilha  -->
    </div>

</body>
</html>