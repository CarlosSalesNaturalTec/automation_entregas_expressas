function ExcluirRegistro() {

    var idMaster = document.getElementById('HiddenID').value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/entregaExcluir",
        data: '{param1: "' + idMaster + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}

function excluirEntrega(IDExc) {
    document.getElementById('HiddenID').value = IDExc;
    document.getElementById('DivExcluir').style.display = "block";
}

function ArquivarEntrega(IDAux) {
    document.getElementById('HiddenID').value = IDAux;
    document.getElementById("DivArquivar").style.display = "block";
}

function ArquivarRegistro() {

    var idMaster = document.getElementById('HiddenID').value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/entregaArquivar",
        data: '{param1: "' + idMaster + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}