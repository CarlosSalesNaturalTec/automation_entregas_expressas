document.getElementById("txtNome").focus();

function TentarLogin() {

    document.getElementById("btLogin").style.cursor = "progress";

    var v1 = document.getElementById("txtNome").value;
    var v2 = document.getElementById("txtpwd").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/tentarlogin",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
            document.getElementById("btLogin").style.cursor = "default";
        }
    });
}

function OnSuccess(response) {
    document.getElementById("btLogin").style.cursor = "default";
    var linkurl = response.d;
    window.location.href = linkurl;
}