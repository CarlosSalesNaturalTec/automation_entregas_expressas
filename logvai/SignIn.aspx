<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>LOGVAI - Nova Conta de usuário</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        body {
            background-image: url(images/background.jpg);
        }
    </style>

</head>

<body>

    <!-- Formulário -->
    <div class="w3-display-container">
        <img src="images/background.jpg" alt="background" class="w3-opacity" style="width: 100%">

        <div class="w3-padding w3-display-middle">
            <div class="w3-card-4" style="width: 800px">
                <header class="w3-container w3-green">
                    <h3><i class="fa fa-user" aria-hidden="true"></i>Cadastro de Novo Usuário</h3>
                </header>
                <div class="w3-container w3-white">
                    <br>
                    <div class="w3-container w3-border">
                        <form class="w3-container" onsubmit="JavaScript:NovoUsuario()">

                            <div class="w3-row">
                                <div class="w3-third">
                                    <label>e-mail</label>
                                    <input type="text" name="usrname" id="input_User" required>
                                </div>
                                <div class="w3-third">
                                    <label>Senha</label>
                                    <input type="password" name="psw" id="input_psw">
                                </div>
                                <div class="w3-third">
                                    <label>Confirme a Senha</label>
                                    <input type="password" name="pswConf" id="input_pswConf">
                                </div>
                            </div>

                            <div class="w3-row">
                                <div class="w3-third">
                                    <label>CPF/CNPJ</label>
                                    <input type="text" name="cpfCnpj" id="input_cpfCnpj">
                                </div>
                                <div class="w3-third">
                                    <label>Nome/Razão Social</label>
                                    <input type="text" name="nomeRazao" id="input_nomeRazao">
                                </div>
                                <div class="w3-third">
                                    <label>Contato</label>
                                    <input type="text" name="contato" id="input_contato">
                                </div>
                            </div>

                            <div class="w3-row">
                                <div class="w3-third">
                                    <label>Endereço</label>
                                    <input type="text" name="endereco" id="input_endereco">
                                </div>
                                <div class="w3-third">
                                    <label>Número</label>
                                    <input type="text" name="numero" id="input_numero">
                                </div>
                                <div class="w3-third">
                                    <label>Complemento</label>
                                    <input type="text" name="complemento" id="input_complemento">
                                </div>
                            </div>

                            <div class="w3-row">
                                <div class="w3-third">
                                    <label>Telefone</label>
                                    <input type="text" name="telefone" id="input_telefone">
                                </div>
                            </div>

                            <div class="w3-section">
                                <input id="btSignIn" type="button" class="w3-button w3-block w3-green w3-section w3-padding" onclick="NovoUsuario();" value="Continuar" />
                            </div>

                            <div id="divHidden" style="display: none" class="w3-center">
                                <br>
                                <i class="fa fa-spinner fa-pulse fa-2x fa-fw"></i>
                                <br>
                            </div>

                        </form>
                    </div>
                    <br>
                </div>
            </div>
        </div>
    </div>
    <!-- Formulário -->

    <!-- Script Autocomplete Endereço-->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places"></script>
    <script type="text/javascript" src="scripts/codeSignIn.js"></script>
    <!-- Script Autocomplete Endereço-->

    <!-- Script cadastro -->
    <script src="scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/codeSignInNewUser.js"></script>
    <!-- Script cadastro -->

</body>
</html>
