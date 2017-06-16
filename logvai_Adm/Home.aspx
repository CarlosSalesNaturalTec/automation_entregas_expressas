<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Status Atual</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</head>
<body>

    <div class="w3-half w3-padding">
        <iframe height="800px" width="100%" frameborder="0" scrolling="no" src="Mapa_StatusAtual.aspx"></iframe>
    </div>
    <div class="w3-half w3-padding">
        <iframe height="800px" width="100%" frameborder="0" scrolling="no" src="Mapa_Entregas_Listagem.aspx"></iframe>
    </div>

</body>
</html>
