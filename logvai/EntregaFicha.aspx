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
            <h3><strong>Ficha Detalhe da Entrega</strong></h3>
        </header>
    </div>

    <div class="w3-container w3-padding-16">

        <!-- PONTO1 -->
        <div class="w3-container">
            <p>Endereço</p>
            <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto1" style="width: 400px" disabled />
            <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero1" style="width: 80px" disabled />
            <p>
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento1" style="width: 400px" disabled />&nbsp;&nbsp;&nbsp;
            </p>
            <p>
                <textarea class="w3-input w3-border w3-round" id="detalhes1" rows="2" style="width: 490px" disabled></textarea>
            </p>
        </div>
        <!-- PONTO1 -->


        <br>
        <button id="btExcluir" class="w3-button w3-round w3-red" onclick="ExcluirRegistro();">Excluir</button>
        <br>
    </div>

    <input id="IDHidden" name="IDHidden" type="hidden" />

    <!-- literal para script -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

     <!-- Scripts com registros -->
    <script src="scripts/codeEntregaFicha.js"></script>
    <script src="scripts/jquery-3.1.1.min.js" type="text/javascript"></script>


</body>

</html>
