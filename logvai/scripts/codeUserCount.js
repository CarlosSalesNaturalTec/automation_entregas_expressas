function habilitacampos() {
    document.getElementById('input_nomeRazao').disabled = false;
    document.getElementById('input_cpfCnpj').disabled = false;
    document.getElementById('input_contato').disabled = false;
    document.getElementById('input_User').disabled = false;
    document.getElementById('input_endereco').disabled = false;
    document.getElementById('input_numero').disabled = false;
    document.getElementById('input_complemento').disabled = false;
    document.getElementById('input_telefone').disabled = false;
    document.getElementById('input_cupom').disabled = false;

    document.getElementById('input_User').focus();

    document.getElementById('divBotoes').style.display = 'none';

}