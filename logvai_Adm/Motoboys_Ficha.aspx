<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Motoboys_Ficha.aspx.cs" Inherits="Motoboys_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Ficha do Motoboy</title>  <!--*******Customização*******-->
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        #results {
            float: right;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

</head>

<body>

   <!--*******MENU LATERAL - Customização*******-->
    <div class="w3-sidebar w3-bar-block w3-blue w3-card-2 w3-animate-left" style="width: 150px">
        <br /><br /><br />

        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-user-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Outros</button>        

        <hr />
        <div class="w3-center">
            <button type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-red" onclick="cancelar()"><i class="fa fa-undo"></i>&nbsp;CANCELAR</button>
            <p></p>
            <button type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue" onclick="AlterarRegistro()" id="btSalvar"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;SALVAR&nbsp;&nbsp;&nbsp;&nbsp;</button>
            <p></p>
            <div id="divhidden" class="w3-container w3-padding w3-center" style="display: none">
                Aguarde...<i class="fa fa-cog fa-spin fa-2x fa-fw"></i>
            </div>
        </div>
    </div>

    <div style="margin-left: 150px">

        <!-- GRUPO 1 -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            <h3><i class="fa fa-user-o" aria-hidden="true"></i>&nbsp;Dados Pessoais</h3> <!--*******Customização*******-->
            <hr />

            <div class="w3-threequarter">
                <form class="form-horizontal">

                    <fieldset>

                        <div class="form-group">
                            <label for="input_nome" class="col-md-2 control-label">Nome</label>
                            <div class="col-md-8">
                                <input type="text" class="form-control" id="input_nome">
                            </div>
                        </div>

                    </fieldset>
                </form>
                <div>
                    <div class="col-md-2"></div>
                    <div class="col-md-2">
                        <button class="w3-btn w3-light-blue w3-hover-blue" onclick="classeBt2()">AVANÇAR</button>
                    </div>
                </div>


            </div>

            <!-- Camera -->
            <div class="w3-quarter">
                <div id="results"></div>
                <div id="my_camera"></div>

                <div class="row">
                    <label for="filePicker">Foto ( 200x300pixels - Tam.Máx.:75Kb )</label><br>
                    <input type="file" id="filePicker">
                </div>
                <input id="Hidden1" name="fotouri" type="hidden" />
            </div>
            <!-- Camera -->

        </div>


        <!-- GRUPO 2 -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa  fa-check-square-o" aria-hidden="true"></i>&nbsp;Documentação</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">

                <fieldset>

                    <div class="form-group">
                        <label for="input_RG" class="col-md-2 control-label">RG</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input_RG">
                        </div>
                    </div> 

                </fieldset>
            </form>

            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-blue w3-hover-blue" onclick="btvoltar1()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-blue w3-hover-blue" onclick="classeBt3()">AVANÇAR</button>
                </div>
            </div>
        </div>


        <!-- GRUPO 3-->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Outros</h3> <!--*******Customização*******-->
            <hr />
            <form class="form-horizontal">
                <fieldset>
                   
                    <div class="form-group">
                        <label for="input_Endereco" class="col-md-2 control-label">Endereco</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input_Endereco">
                        </div>
                    </div>

                </fieldset>
            </form>

            <div>
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-blue w3-hover-blue" onclick="btvoltar2()">VOLTAR</button>
                </div>
                <div class="col-md-1">
                    <button class="w3-btn w3-light-blue w3-hover-blue" onclick="AlterarRegistro()">CONCLUIR</button>
                </div>
            </div>
        </div>

    </div>

    <!-- auxiliares -->
    <input id="IDHidden" name="IDHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts diversos  -->
    <script type="text/javascript" src="scripts/codeMotoboys_Novo.js"></script>  <!--*******Customização*******-->
    <script type="text/javascript" src="Scripts/webcam.js"></script>


</body>

</html>