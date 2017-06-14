<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faturas_Ficha.aspx.cs" Inherits="Faturas_Ficha" %>

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
            <h5><strong>Detalhamento de Fatura</strong></h5>
        </header>
    </div>

    <div class="w3-section w3-padding">
        <p><strong>Cliente: </strong>
            <asp:Literal ID="lblNome" runat="server"></asp:Literal></p>
        <p><strong>Valor: </strong>
            <asp:Literal ID="lblTotal" runat="server"></asp:Literal></p>
        <input type="button" class="w3-btn w3-round w3-blue w3-hover-light-blue w3-padding" value="Voltar" onclick="window.open('Faturas_Gerar.aspx', 'iframe')" />
        <input type="button" class="w3-btn w3-round w3-blue w3-hover-light-blue w3-padding" value="Gerar Fatura" onclick="gerarFatura()" />
    </div>

    <div class="w3-small">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>

    <!-- auxiliares -->
    <input type="hidden" runat="server" id="hiddenID" />
    <input type="hidden" runat="server" id="hiddenValor" />
    <input type="hidden" runat="server" id="hiddenQuant" />

    <!-- Scripts -->
    <script type="text/javascript" src="scripts/codeFaturas.js"></script>
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

</body>
</html>
