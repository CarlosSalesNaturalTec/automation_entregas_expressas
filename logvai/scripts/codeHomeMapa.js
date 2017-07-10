var markers = [];
var image = 'images/motorcycleUpView22x54.png';
var myVar = setInterval(MostraMotoboys, 1000);

function MostraMotoboys() {

    $.ajax({
        type: "POST",
        url: "WebService.asmx/MotoboysOnLine",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            // formata retorno em formato padrão JSON 
            var strRetorno = "{\"counters\": " + response.d + "}";

            // apaga marcadores. 
            deleteMarkers();
           
            // parse Json
            var jsonData = JSON.parse(strRetorno);
            for (var i = 0; i < jsonData.counters.length; i++) {
                var counter = jsonData.counters[i];
                var cordTemp = new google.maps.LatLng(counter.Latitude, counter.Longitude);
                addMarker(cordTemp, counter.Nome);
            }         

        },
        failure: function (response) {
            alert('Tente Novamente');
        }
    });

}

function addMarker(location,conteudo) {

    // exibe marcador
    var marker = new google.maps.Marker({
        position: location,
        title: conteudo,
        icon: image,
        map: map
    });

    // adiciona marcador em um array (para uso no deleteMarkers)
    markers.push(marker);


    //infwindow ao clicar
    var infowindow = new google.maps.InfoWindow({
        content: conteudo
    });

    marker.addListener('click', function () {
        infowindow.open(marker.get('map'), marker);
    });

}

function deleteMarkers() {

    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }

    markers = [];
}