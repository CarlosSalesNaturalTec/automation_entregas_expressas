function liberaFaturamento() {

    var atual = document.getElementById('input_faturar').value;
    var texto = "";
    var v2 = "";
    if (atual == "SIM") {
        texto = "Bloqueia Faturamento ?"
        v2 = "0";
    } else {
        texto = "Libera Faturamento ?"
        v2 = "1";
    }

    var r = confirm(texto);
    if (r != true) {
        return;
    }

    $("body").css("cursor", "progress");

    var v1 = document.getElementById('IDHidden').value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/alteraFaturamento",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var url = response.d;
            window.open(url, 'iframe');
        },
        failure: function (response) {
            document.getElementById("btSignIn").style.cursor = "pointer";
            alert('Tente Novamente. Erro no envio para web-service');
        }
    });



}