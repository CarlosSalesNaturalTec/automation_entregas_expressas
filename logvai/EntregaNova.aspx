﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregaNova.aspx.cs" Inherits="NovaEntrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>LOGVAI - Nova Entrega</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        #map {
            height: 100%;
            width: 50%;
        }

        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>

</head>

<body>

    <!-- ENDEREÇOS -->
    <div class="w3-half w3-animate-left" id="divEnderecos">

        <div id="divEnderecos1" class="w3-animate-left">
            <!-- PONTO1 -->
            <div class="w3-container">
                <p><span id="badge1" class="w3-badge w3-light-blue">A</span> Local de retirada (coleta) &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="w3-small">Utilizar meu Endereço</a></p>
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto1" placeholder="Ex: Av. Tancredo Neves" style="width: 400px" />
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero1" placeholder="No." style="width: 80px" />
                <p>
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento1" placeholder="Complemento" style="width: 220px" />
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputdestinatario1" placeholder="Com quem falar?" style="width: 220px" />
                </p>
                <p>
                    <textarea class="w3-input w3-border w3-round" id="detalhes1" rows="2" placeholder="O que deve ser feito?" style="width: 490px"></textarea>
                </p>
            </div>
            <!-- PONTO1 -->


            <!-- PONTO2 -->
            <div class="w3-container">
                <p><span id="badge2" class="w3-badge w3-light-blue">B</span> Local de destino (entrega)</p>
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto2" placeholder="Ex: Av. Tanclight-blueo Neves" style="width: 400px" />
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero2" placeholder="No." style="width: 80px" />
                <p>
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento2" placeholder="Complemento.Ex: Sala 401" style="width: 220px" />
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputdestinatario2" placeholder="Com quem falar?" style="width: 220px" />
                    <input class="w3-check" type="checkbox" name="ChkBancoPonto2"><label class="w3-tiny">&nbsp;Banco,Rep.Pública ou Correios</label>
                </p>
                <p>
                    <textarea class="w3-input w3-border w3-round" name="detalhes2" id="detalhes2" rows="2" placeholder="O que deve ser feito?" style="width: 490px"></textarea>
                </p>
                <p class="w3-tiny">
                    <span id="badgePlus" class="w3-badge w3-light-blue">+</span>&nbsp;<a href="#" onclick="adicionarEndereco()">Adicionar Destino</a>
                </p>
            </div>
            <br />
            <!-- PONTO2 -->
        </div>

        <!-- ENDEREÇOS  Pontos C e D-->
        <div id="divEnderecos2" class="w3-animate-left" style="display: none">

            <!-- PONTO 3 - C -->
            <div class="w3-container">
                <p><span id="badge3" class="w3-badge w3-light-blue">C</span> Local de retirada (coleta)</p>
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto3" placeholder="Ex: Av. Tancredo Neves" style="width: 400px" />
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero3" placeholder="No." style="width: 80px" />
                <p>
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento3" placeholder="Complemento" style="width: 220px" />
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputdestinatario3" placeholder="Com quem falar?" style="width: 220px" />
                </p>
                <p>
                    <textarea class="w3-input w3-border w3-round" id="detalhes3" rows="2" placeholder="O que deve ser feito?" style="width: 490px"></textarea>
                </p>
            </div>
            <!-- PONTO 3 -->


            <!-- PONTO 4 - D  -->
            <div class="w3-container">
                <p><span id="badge4" class="w3-badge w3-light-blue">D</span> Local de destino (entrega)</p>
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputPonto4" placeholder="Ex: Av. Tanclight-blueo Neves" style="width: 400px" />
                <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputNumero4" placeholder="No." style="width: 80px" />
                <p>
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputComplemento4" placeholder="Complemento.Ex: Sala 401" style="width: 220px" />
                    <input class="w3-border w3-round w3-hover-light-gray" type="text" id="inputdestinatario4" placeholder="Com quem falar?" style="width: 220px" />
                </p>
                <p>
                    <textarea class="w3-input w3-border w3-round" name="detalhes2" id="detalhes4" rows="2" placeholder="O que deve ser feito?" style="width: 490px"></textarea>
                </p>
                <p class="w3-tiny">
                    <span id="badgeCancel" class="w3-badge w3-light-blue">X</span>&nbsp;<a href="#" onclick="CancelarEndereco()">Remover Destinos Adicionais</a>
                </p>
            </div>
            <br />
            <!-- PONTO 4 -->

        </div>
        <!-- ENDEREÇOS -->


        <!-- CALCULO DE TOTAIS -->
        <div class="w3-section w3-border w3-light-gray w3-padding" style="width: 98%;">

            <!-- TEMPO DE ATENDIMENTO -->
            <div class="w3-row w3-small w3-gray w3-center">
                <strong>
                    <label>Tempo de Atendimento</label></strong>
            </div>
            <div class="w3-row w3-small">
                <div class="w3-half">
                    &nbsp;&nbsp;&nbsp;&nbsp;<input class="w3-radio" type="radio" name="OpTempo" value="tempo1" checked>
                    <label>Normal (horário comercial)</label>
                </div>
                <div class="w3-half">
                    <input class="w3-radio" type="radio" name="OpTempo" value="tempo2">
                    <label>Urgente (em até 1 hora)</label>
                </div>
            </div>
            <!-- TEMPO DE ATENDIMENTO -->

            <br>
            <button id="btCalcular" class="w3-btn w3-block w3-round w3-blue w3-hover-light-blue" onclick="CalculoGeral();">Calcular</button>
            <br>
            <div class="w3-container">
                <div class="w3-half w3-center w3-text-gray">Distância:</div>
                <div class="w3-half w3-center w3-text-gray">Valor:</div>
            </div>

            <div class="w3-container">
                <div class="w3-half w3-center">
                    <strong><span id="txtDist" class="w3-text-blue">0Km</span></strong>
                </div>
                <div class="w3-half w3-center">
                    <strong><span id="txtValor" class="w3-text-blue">R$ 0,00</span></strong>
                </div>
            </div>

            <div id="idDiv1" style="display: none">
                <br>
                <button id="btSolicitar" class="w3-btn w3-block w3-round w3-blue w3-hover-light-blue" onclick="exibirResumo();">Avançar</button>
                <br>
            </div>
        </div>
        <!-- CALCULO DE TOTAIS -->

        <!-- campos auxiliares -->
        <input id="IDHidden" runat="server" type="hidden" />
        <input id="FaturarHidden" runat="server" type="hidden" />
        <input id="DistanciaHidden" runat="server" type="hidden" />
        <input id="ValorHidden" runat="server" type="hidden" />

    </div>
    <!-- ENDEREÇOS -->

    <!-- RESUMO -->
    <div id="divResumo" class="w3-half w3-animate-left" style="display: none">

        <header class="w3-container w3-blue w3-text-white w3-center">
            <h6><strong>Resumo da Solicitação</strong></h6>
        </header>

        <section class="w3-section w3-padding w3-small">
            <span class="w3-badge w3-light-blue">A</span>&nbsp;<span id="Resumo_Ponto1"></span>
            <br />
            <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span id="Resumo_Complem1"></span>
        </section>

        <section class="w3-section w3-padding w3-small">
            <span class="w3-badge w3-light-blue">B</span>&nbsp;<span id="Resumo_Ponto2"></span>
            <br />
            <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span id="Resumo_Complem2"></span>
        </section>

        <section class="w3-section w3-padding w3-small">
            <i class="fa fa-map fa-2x w3-light-blue" aria-hidden="true"></i>&nbsp;
            <span>Distância:</span>&nbsp;<strong><span id="Resumo_Distancia"></span></strong>
        </section>

        <!-- FORMA DE PAGAMENTO -->
        <section class="w3-container w3-padding-16 w3-border w3-light-gray">
            <i class="fa fa-calculator fa-2x w3-light-blue" aria-hidden="true"></i>&nbsp;<span>Total:</span>&nbsp;<strong><span id="Resumo_Total"></span></strong>
            <br />
            <p>Selecione Forma de Pagamento</p>
            <p>
                <select id="formaPag" name="formaPag" class="w3-select w3-border w3-half">
                    <option value="Cartão" disabled>Cartão</option>
                    <option value="Faturado" disabled>Faturado</option>
                    <option value="Dinheiro">Dinheiro</option>
                    <option value="Depósito">Depósito/Transf.</option>
                </select>
            </p>
        </section>

        <section id="sectionBotoes" class="w3-section w3-padding">
            <div class="w3-half w3-padding">
                <input id="btVoltar" type="button" value="Voltar" class="w3-btn w3-round w3-block w3-blue w3-hover-light-blue" onclick="voltarEnderecos();" />
            </div>
            <div class="w3-half w3-padding">
                <input id="btCheckOut" type="button" value="Concluir" class="w3-btn w3-round w3-block w3-blue w3-hover-light-blue" onclick="salvarMaster();" />
            </div>
            <div id="divhidden" class="w3-container w3-padding w3-center" style="display: none">
                <p>Aguarde <i class="fa fa-cog fa-spin fa-2x fa-fw"></i></p>
            </div>
        </section>

    </div>
    <!-- RESUMO -->

    <!-- MAPA -->
    <div id="map" class="w3-right w3-animate-left"></div>
    <script src="scripts/codeEntregaNova.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDhhdJ8S6LYpsu33sFG26cWSUN3V9Qrorw&libraries=places&callback=initMap" async defer></script>
    <!-- MAPA -->

    <!-- Script cadastro -->
    <script src="scripts/jquery-3.2.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function adicionarEndereco() {
            document.getElementById('divEnderecos1').style.display = 'none';
            document.getElementById('divEnderecos2').style.display = 'block';
        }
        function CancelarEndereco() {
            document.getElementById('divEnderecos2').style.display = 'none';
            document.getElementById('divEnderecos1').style.display = 'block';
        }
    </script>

</body>

</html>
