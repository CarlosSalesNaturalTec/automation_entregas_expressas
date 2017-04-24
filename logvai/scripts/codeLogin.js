function TentarLogin() {

    var v1 = document.getElementById("input_User").value;
    var v2 = document.getElementById("input_pwd").value;

    if (v1 == "") { alert('Informe nome do Usuário!'); document.getElementById('input_User').focus(); return; }
    if (v2 == "") { alert('Informe Senha!'); document.getElementById('input_User').focus(); return; }

    $.ajax({
        type: "POST",
        url: "WebService.asmx/login",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var linkurl = response.d;
            window.open(linkurl, '_parent');
        },
        failure: function (response) {
            alert('Tente Novamente');
        }
    });
}