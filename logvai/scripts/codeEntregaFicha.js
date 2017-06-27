var map;

function initMap() {

    // Mapa
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.990281, lng: -38.472187 },
        zoom: 12
    });

}

function ExcluirRegistro() {

    var r = confirm("CONFIRMA EXCLUSÂO ?");
    if (r == false) {
        return;
    }

    var v1 = document.getElementById("IDHidden").value;

    $.ajax({
        type: "POST",
        url: "WebService.asmx/EntregaExcluir",
        data: '{param1: "' + v1 + '" }',
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