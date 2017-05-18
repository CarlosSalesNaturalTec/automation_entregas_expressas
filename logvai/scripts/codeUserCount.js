﻿function habilitacampos() {
    document.getElementById('input_nomeRazao').disabled = false;
    document.getElementById('input_cpfCnpj').disabled = false;
    document.getElementById('input_contato').disabled = false;
    document.getElementById('input_User').disabled = false;
    document.getElementById('input_endereco').disabled = false;
    document.getElementById('input_numero').disabled = false;
    document.getElementById('input_complemento').disabled = false;
    document.getElementById('input_telefone').disabled = false;
    document.getElementById('input_cupom').disabled = false;

    document.getElementById('input_nomeRazao').focus();

    document.getElementById('divBotoes').style.display = 'none';
    document.getElementById('divbotoes1').style.display = 'block';

}

function cancelar() {
    window.open('UserCount.aspx', 'iframe_a');
}

function salvar() {

    $("body").css("cursor", "progress");

    var v1 = document.getElementById("input_User").value;
    var v2 = document.getElementById("input_psw").value;
    var v2a = document.getElementById("input_pswConf").value;
    var v3 = document.getElementById("input_cpfCnpj").value;
    var v4 = document.getElementById("input_nomeRazao").value;
    var v5 = document.getElementById("input_contato").value;
    var v6 = document.getElementById("input_endereco").value;
    var v7 = document.getElementById("input_numero").value;
    var v8 = document.getElementById("input_complemento").value;
    var v9 = document.getElementById("input_telefone").value;
    var v10 = document.getElementById("input_cupom").value;

    var tipoP = document.getElementById("TipoPHidden").value;

    if (v4 == "") { alert('Informe Nome ou Razão Social!'); document.getElementById('input_nomeRazao').focus(); return; }
    if (v3 == "") { alert('Informe CPF/CNPJ!'); document.getElementById('input_cpfCnpj').focus(); return; }
    if (v1 == "") { alert('Informe e-mail!'); document.getElementById('input_User').focus(); return; }

    if (v2 == "") { alert('Informe Senha!'); document.getElementById('input_psw').focus(); return; }
    if (v2 != v2a) { alert('Senhas não conferem!'); document.getElementById('input_pswConf').focus(); return; }

    if (v6 == "") { alert('Informe endereço!'); document.getElementById('input_endereco').focus(); return; }
    if (v7 == "") { alert('Informe número do endereço!'); document.getElementById('input_numero').focus(); return; }
    if (v9 == "") { alert('Informe telefone!'); document.getElementById('input_telefone').focus(); return; }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/useredit",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '", param10: "' + v10 + '", param11: "' + tipoP + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            window.open('EntregaNova.aspx', 'iframe_a');
        },
        failure: function (response) {
            alert('Tente Novamente');
        }
    });
}