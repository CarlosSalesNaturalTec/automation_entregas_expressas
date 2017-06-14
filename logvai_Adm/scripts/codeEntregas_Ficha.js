var formaPag = document.getElementById('OSFormaPag').textContent;
if (formaPag != 'Depósito') {
    document.getElementById('btConfDep').style.display = "none";
}

function confirmaDep() {

    var r = confirm("Depósito Confirmado ?");
    if (r != true) {
        return;
    }

    $("body").css("cursor", "progress");
    document.getElementById('btConfDep').disabled = true;

    var v1 = document.getElementById('IDHidden').value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/confirmaDeposito",
        data: '{param1: "' + v1 + '"}',
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