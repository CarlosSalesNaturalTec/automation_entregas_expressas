<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cotacao.aspx.cs" Inherits="cotacao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Motoboys para entregas expressas em Salvador-BA</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <!-- SOLICITAÇÃO -->
    <div class="w3-display-container">
        <img src="images/background.jpg" alt="background" class="w3-opacity" style="width: 100%">

        <div class="w3-padding w3-display-middle">

            <div class="w3-card-4">

                <header class="w3-container w3-blue">
                    <h3><i class="fa fa-calculator" aria-hidden="true"></i>Faça aqui sua cotação</h3>
                </header>
                <div class="w3-container w3-white">
                    <br>

                    <div class="w3-container w3-border">
                        <div class="w3-row w3-small w3-gray w3-center w3-text-blue">
                            <label>Endereços</label>
                        </div>
                        <br />
                        
                        <!-- PONTO1 -->
                        <span class="w3-badge w3-light-blue">A</span>
                        <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto1" placeholder="Origem" style="width: 400px" />
                        <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero1" placeholder="No" style="width: 80px" />
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento1" placeholder="Complemento" style="width: 200px" />&nbsp;&nbsp;&nbsp;
                            <input class="w3-check" type="checkbox" name="OpTipoPonto1"><label class="w3-small">&nbsp;Banco, Repartição Pública ou Correios</label>
                        </p>
                        <!-- PONTO1 -->


                        <!-- PONTO2 -->
                        <span class="w3-badge w3-light-blue">B</span>
                        <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto2" placeholder="Destino" style="width: 400px" />
                        <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero2" placeholder="No." style="width: 80px" />
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento2" placeholder="Complemento" style="width: 200px" />&nbsp;&nbsp;&nbsp;
                            <input class="w3-check" type="checkbox" name="OpTipoPonto2" value="BancoPonto2"><label class="w3-small">&nbsp;Banco, Repartição Pública ou Correios</label>
                        </p>
                        <!-- PONTO2 -->


                        <!-- PONTO3 -->
                        <div class="w3-row">
                            <span class="w3-badge w3-light-blue">C</span>
                            &nbsp;<input class="w3-check" type="checkbox" name="chkRetorno" value="retorno">
                            <label class="w3-small">Retornar ao endereço inicial</label>
                        </div>
                        <br>
                        <!-- PONTO3 -->

                        
                        <!-- TEMPO DE ATENDIMENTO -->
                        <div class="w3-row w3-small w3-gray w3-center w3-text-blue">
                            <label>Tempo de Atendimento</label>
                        </div>
                        <div class="w3-row w3-small">
                            <div class="w3-half">
                                &nbsp;&nbsp;&nbsp;<input class="w3-radio" type="radio" name="OpTempo" value="tempo1" checked>
                                <label>Normal (em até 4 horas)</label>
                            </div>
                            <div class="w3-half">
                                <input class="w3-radio" type="radio" name="OpTempo" value="tempo2">
                                <label>Urgente (em até 1 hora)</label>
                            </div>
                        </div>
                        <br>
                        <!-- TOTAIS -->

                    </div>

                    <!-- BOTÕES E TOTAIS -->
                    <br>
                    <div class="w3-container w3-border w3-light-gray">
                        <br>
                        <button id="btCalcular" class="w3-button w3-block w3-round w3-blue w3-hover-green" onclick="GeoCodeCalc01();">Calcular</button>
                        <br>
                        <div class="w3-container">
                            <div class="w3-third w3-center w3-text-gray">Distância:</div>
                            <div class="w3-third w3-center w3-text-gray">Duração:</div>
                            <div class="w3-third w3-center w3-text-gray">Valor:</div>
                        </div>

                        <div class="w3-container">
                            <div class="w3-third w3-center">
                                <strong><span id="txtDist" class="w3-text-blue">0Km</span></strong>
                            </div>
                            <div class="w3-third w3-center">
                                <strong><span id="txtDuracao" class="w3-text-blue">0min</span></strong>
                            </div>
                            <div class="w3-third w3-center">
                                <strong><span id="txtValor" class="w3-text-blue">R$ 0,00</span></strong>
                            </div>
                        </div>

                        <div id="idDiv1" style="display: none">
                            <br>
                            <button id="btSolicitar" class="w3-button w3-block w3-round w3-green w3-hover-blue" onclick="ExibirModal();">Gostou? Solicite Agora</button>
                            <br>
                        </div>
                    </div>
                    <br>
                    <!-- BOTÕES E TOTAIS -->

                </div>
            </div>
        </div>
    </div>
    <!-- SOLICITAÇÃO -->

    <!-- Script Autocomplete-->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places"></script>
    <script type="text/javascript" src="scripts/codeCotacaoAutocomplete.js"></script>
    <!-- Script Autocomplete-->


    <!-- Modal Login -->
    <div id="id01" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <div class="w3-center">
                <br>
                <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright"
                    title="Fechar">&times;</span>
            </div>

            <form class="w3-container">
                <div class="w3-section">
                    <label><b>Usuario</b></label>
                    <input id="input_User" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Nome do Usuário" name="usrname"
                        required>
                    <label><b>Senha</b></label>
                    <input class="w3-input w3-border" type="password" placeholder="Digite sua senha" name="psw" required>
                    <button class="w3-button w3-block w3-green w3-section w3-padding" type="submit">Entrar</button>
                </div>
            </form>

            <div class="w3-container w3-center">
                <p><a href="SignIn.aspx" target="iframe_a">Criar Conta</a></p>
            </div>
        </div>
    </div>
    <!-- Modal Login -->

    <!-- Scripts diversos -->
    <script type="text/javascript" src="scripts/code1.js"></script>
    <script type="text/javascript">
        function ExibirModal() {
            document.getElementById('id01').style.display = 'block';
            document.getElementById('input_User').focus();
        }
    </script>


</body>
</html>
