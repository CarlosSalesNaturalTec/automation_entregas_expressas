<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaAcompanhar.aspx.cs" Inherits="EntregaAcompanhar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Acompanhamento de Entrega</title>
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
    <div class="w3-container w3-border w3-round w3-padding w3-light-blue w3-center" style="margin-left: 2%; margin-right: 2%">
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

    <!-- Modal Arquivar -->
    <div id="DivArquivar" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">
            <form class="w3-container">
                <div class="w3-section w3-center">
                    <br />
                    <header class="w3-container w3-blue w3-center">
                        <h4><strong>Atenção</strong></h4>
                    </header>
                    <i class="fa fa-3x fa-check-circle-o" aria-hidden="true"></i>
                    <p></p>
                    <h3><strong>Arquivar Entrega ?</strong> </h3>
                    <br />
                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-blue"
                            onclick="document.getElementById('DivArquivar').style.display = 'none'">
                            Não</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-red" onclick="ArquivarRegistro()">Sim</button>
                    </p>
                    <br />
                    <p>Você ainda poderá visualizá-la no Histórico.</p>
                    <br />                  
                </div>
            </form>
        </div>
    </div>

    <!-- Modal Excluir -->
    <div id="DivExcluir" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">
            <form class="w3-container">
                <div class="w3-section w3-center">
                    <header class="w3-container w3-blue w3-center">
                        <span onclick="document.getElementById('DivExcluir').style.display='none'" class="w3-button w3-right">&times;</span>
                        <h4><strong>Atenção</strong></h4>
                    </header>
                    <br />
                    <i class="fa fa-3x fa-check-circle-o" aria-hidden="true"></i>
                    <br />
                    <h3><strong>Excluir Entrega ?</strong> </h3>
                    <br />
                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-blue"
                            onclick="document.getElementById('DivExcluir').style.display = 'none';">
                            Não</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-red"
                            onclick="ExcluirRegistro()">
                            Sim</button>
                    </p>
                    <br />
                </div>
            </form>
        </div>
    </div>

    <!-- ID Auxiliar-->
    <input type="hidden" id="HiddenID" />

</body>

</html>
