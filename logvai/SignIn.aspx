<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>LOGVAI - Nova Conta de usuário</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <!-- Formulário -->
    <div class="w3-display-container">
        <img src="images/background.jpg" alt="background" class="w3-opacity" style="width: 100%">

        <div class="w3-padding w3-display-middle">
            <div class="w3-card-4" style="width: 800px">
                <header class="w3-container w3-blue">
                    <h3><i class="fa fa-user-plus" aria-hidden="true"></i>&nbsp;Cadastro de Novo Usuário</h3>
                </header>
                <div class="w3-container w3-white">
                    <br>
                    <div class="w3-container w3-border">

                        <form class="w3-container">

                            <p>
                                <input class="w3-radio" type="radio" name="tipoPessoa" value="F" checked onclick="if (this.checked) { PessoaF() }">
                                <label>Pessoa Física</label>
                                <input class="w3-radio" type="radio" name="tipoPessoa" value="J" onclick="if (this.checked) { PessoaJ() }">
                                <label>Jurídica</label>
                            </p>

                            <label id="lblNomeRazao">Nome</label>
                            <input type="text" name="nomeRazao" id="input_nomeRazao" class="w3-input w3-border w3-round-large" required autofocus>

                            <div class="w3-row">
                                <div class="w3-half">
                                    <label id="lblcpfCnpj">CPF</label>
                                    <input type="text" name="cpfCnpj" id="input_cpfCnpj" class="w3-input w3-border w3-round-large" style="width: 95%" required>
                                </div>
                                <div id="divContato" class="w3-half" style="display: none">
                                    <label>Contato</label>
                                    <input type="text" name="contato" id="input_contato" class="w3-input w3-border w3-round-large">
                                </div>
                            </div>

                            <label>e-mail</label>
                            <input type="email" name="usrname" id="input_User" class="w3-input w3-border w3-round-large" required>

                            <div class="w3-row">
                                <div class="w3-half">
                                    <label>Senha</label>
                                    <input type="password" name="psw" id="input_psw" class="w3-input w3-border w3-round-large" style="width: 95%" required>
                                </div>
                                <div class="w3-half">
                                    <label>Confirme a Senha</label>
                                    <input type="password" name="pswConf" id="input_pswConf" class="w3-input w3-border w3-round-large" required>
                                </div>
                            </div>

                            <div class="w3-row">
                                <div class="w3-threequarter">
                                    <label>Endereço</label>
                                    <input type="text" name="endereco" id="input_endereco" class="w3-input w3-border w3-round-large" style="width: 95%" required>
                                </div>
                                <div class="w3-quarter">
                                    <label>Número</label>
                                    <input type="text" name="numero" id="input_numero" class="w3-input w3-border w3-round-large">
                                </div>
                            </div>

                            <div class="w3-row">
                                <div class="w3-half">
                                    <label>Complemento</label>
                                    <input type="text" name="complemento" id="input_complemento" class="w3-input w3-border w3-round-large" style="width: 95%">
                                </div>
                                <div class="w3-half">
                                    <label>Telefone</label>
                                    <input type="text" name="telefone" id="input_telefone" class="w3-input w3-border w3-round-large" required>
                                </div>
                            </div>

                            <div class="w3-row">
                                <div class="w3-half">
                                    <label>Cupom de Desconto</label>
                                    <input type="text" name="telefone" id="input_cupom" class="w3-input w3-border w3-round-large" style="width: 95%">
                                </div>
                                <div class="w3-half">
                                    <p></p>
                                    <input onchange="aceiteTermos();" class="w3-check" type="checkbox" name="chkAceite" id="chkAceite"><label class="w3-small">&nbsp;Li e aceito as condições dos <a href="#" onclick="ExibirModal();">Termos de Uso</a></label>
                                </div>
                            </div>

                            <div class="w3-section">
                                <input id="btSignIn" type="button" class="w3-button w3-block w3-blue w3-hover-light-blue w3-section w3-padding" onclick="NovoUsuario();" value="Salvar" disabled />
                            </div>

                            <div id="divHidden" style="display: none" class="w3-center">
                                <i class="fa fa-spinner fa-pulse fa-fw"></i>
                            </div>

                        </form>

                    </div>
                    <br>
                </div>
            </div>
        </div>
    </div>
    <!-- Formulário -->

    <!-- Modal Termos de Uso -->
    <div id="idTermo" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 600px">

            <div class="w3-center">
                <br>
                <span onclick="document.getElementById('idTermo').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright"
                    title="Fechar">&times;</span>
            </div>

            <form class="w3-container">
                <div class="w3-section w3-center">
                    <h4>Termos de Uso</h4>
                </div>
            </form>
        </div>
    </div>
    <!-- Modal Termos de Uso -->

    <script type="text/javascript">
        function ExibirModal() {
            document.getElementById('idTermo').style.display = 'block';
        }

        function aceiteTermos() {
            var chktermo = document.getElementsByName('chkAceite');
            var chktermo2 = chktermo[0].checked;
            if (chktermo2 == true) {
                document.getElementById('btSignIn').disabled = false;
            } else {
                document.getElementById('btSignIn').disabled = true;
            }

        }

    </script>

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
