function gerarFatura() {

    var r = confirm("CONFIRMA GERAÇÃO DE FATURA?");
    if (r == false) {
        return;
    }

    var v1 = document.getElementById('hiddenID').value;
    var v2 = document.getElementById('hiddenQuant').value;
    var v3 = document.getElementById('hiddenValor').value;

    $("body").css("cursor", "progress");

    $.ajax({
        type: "POST",
        url: "WebService.asmx/gerarFatura",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var url = response.d;
            window.open(url, 'iframe_a');
        },
        failure: function (response) {
            document.getElementById("btSignIn").style.cursor = "pointer";
            alert('Tente Novamente. Erro no envio para web-service');
        }
    });



}