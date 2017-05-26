<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faturas_Historico.aspx.cs" Inherits="Faturas_Historico" %>

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
    <div>
        <header class="w3-container w3-blue w3-text-white w3-center">
            <h5><strong>Histórico de Faturas</strong></h5>
        </header>
    </div>
    <br />
    <div class="w3-small">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>

</body>
</html>
