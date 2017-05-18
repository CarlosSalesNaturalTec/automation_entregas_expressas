<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaHistorico.aspx.cs" Inherits="EntregaHistorico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Histórico de Entregas</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>

<body>

    <div>
        <header class="w3-container w3-light-gray w3-center">
            <h5><strong>Histórico de Solicitações</strong></h5>
        </header>
    </div>

    <div class="w3-container w3-padding-16 w3-small">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>

    <!-- Busca e Paginação modelo: datatables.net -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <link rel="stylesheet" href="//cdn.datatables.net/1.10.10/css/jquery.dataTables.min.css">
    <script src="//cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.10/css/dataTables.bootstrap.min.css">

    <script>
        $(document).ready(function () {
            $('#tabela').DataTable({
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros por página",
                    "zeroRecords": "Nada encontrado",
                    "info": " _MAX_ registros no total",
                    "infoEmpty": "Nenhum registro disponível",
                    "infoFiltered": "(filtrado de _MAX_ registros no total)",
                    "search": "Pesquisa:"
                }
            });
        });
    </script>
</body>

</html>
