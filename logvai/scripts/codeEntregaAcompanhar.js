function excluirEntrega(idMaster) {

    var r = confirm("CONFIRMA EXCLUSÂO ?");
    if (r == false) {
        return;
    }

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