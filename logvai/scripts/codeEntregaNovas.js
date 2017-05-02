var Ponto1;
var Ponto2;
var DistanciaKM;

var map;
var directionsService;
var directionsDisplay;

document.getElementById('inputPonto1').focus();

function initMap() {

    // Mapa
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.990281, lng: -38.472187 },
        zoom: 12
    });

    // Autocomplete
    var input1 = document.getElementById('inputPonto1');
    var input2 = document.getElementById('inputPonto2');

    var autocomplete1 = new google.maps.places.Autocomplete(input1);
    autocomplete1.bindTo('bounds', map);

    var autocomplete2 = new google.maps.places.Autocomplete(input2);
    autocomplete2.bindTo('bounds', map);
    
    //tracar roteiro
    directionsService = new google.maps.DirectionsService;
    directionsDisplay = new google.maps.DirectionsRenderer;

    directionsDisplay.setMap(map);

}

function CalculoGeral() {

    // UI - User Interface
    document.getElementById("btCalcular").style.cursor = "progress";
    document.getElementById("txtDist").textContent = " 0Km"
    document.getElementById("txtValor").textContent = " R$";

    Ponto1 = document.getElementById('inputPonto1').value + "," + document.getElementById('inputNumero1').value;
    Ponto2 = document.getElementById('inputPonto2').value + "," + document.getElementById('inputNumero2').value;

    //calcula distancia e tempo
    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix(
        {
            origins: [Ponto1, Ponto2],
            destinations: [Ponto2, Ponto1],
            travelMode: google.maps.TravelMode.DRIVING,
            unitSystem: google.maps.UnitSystem.METRIC,
            avoidHighways: false,
            avoidTolls: false
        }, retorno);
}

function retorno(response, status) {
    if (status != google.maps.DistanceMatrixStatus.OK) {
        alert('Atenção: ' + response);
    } else {
        var origin = response.originAddresses[0];
        var destination = response.destinationAddresses[0];
        if (response.rows[0].elements[0].status === "ZERO_RESULTS") {
            document.getElementById("btCalcular").style.cursor = "pointer";
            alert("Não foi possível encontrar roteiro! Verifique os endereços digitados");
        } else {
            var distance = response.rows[0].elements[0].distance;
            DistanciaKM = (distance.value / 1000);

            document.getElementById("txtDist").textContent = DistanciaKM.toFixed(2) + 'Km';

            document.getElementById("btCalcular").style.cursor = "pointer";
            document.getElementById("idDiv1").style.display = "block"

            CalculoTempoEValor();
        }
    }
}

function CalculoTempoEValor() {

    var valorTotal;
    var pontoQuant=2;
    var kmValor;

    var pontoValor = 5;
    var adicionalBanco = 0;

    var tipo = document.getElementsByName('OpTempo');
    var tipotempo = tipo[0].checked;
    if (tipotempo == true) { kmValor = 1.2; } else { kmValor = 2.2; }

    valorTotal = (pontoQuant * pontoValor) + (DistanciaKM * kmValor);

    var chkbanco = document.getElementsByName('ChkBancoPonto2');
    var chkbanco2 = chkbanco[0].checked;
    if (chkbanco2 == true) {
        valorTotal += adicionalBanco;
    }

    document.getElementById("txtValor").textContent = "R$ " + valorTotal.toFixed(2);

    // Exibe roteiro no mapa
    calculateAndDisplayRoute(directionsService, directionsDisplay);

}

function calculateAndDisplayRoute(directionsService, directionsDisplay) {
    directionsService.route({
        origin: Ponto1,
        destination: Ponto2,
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
        } else {
            //window.alert('Directions request failed due to ' + status);
        }
    });
}

function salvaPonto1() {
    
    document.getElementById("btSolicitar").style.cursor = "progress";

    var v1 = document.getElementById("IDHidden").value;
    var v2 = document.getElementById("inputPonto1").value;
    var v3 = document.getElementById("inputNumero1").value;
    var v4 = document.getElementById("inputComplemento1").value;
    var v5 = document.getElementById("detalhes1").value;        
    var v6 = "XXX" //telefone   

    $.ajax({
        type: "POST",
        url: "WebService.asmx/entregaSalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            salvaPonto2();
        },
        failure: function (response) {
            document.getElementById("btSignIn").style.cursor = "pointer";
            alert('Tente Novamente');
        }
    });
}

function salvaPonto2() {

    var v1 = document.getElementById("IDHidden").value;
    var v2 = document.getElementById("inputPonto2").value;
    var v3 = document.getElementById("inputNumero2").value;
    var v4 = document.getElementById("inputComplemento2").value;
    var v5 = document.getElementById("detalhes2").value;
    var v6 = "XXX" //telefone   

    $.ajax({
        type: "POST",
        url: "WebService.asmx/entregaSalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var msg = response.d;
            alert(msg);
            window.open("EntregaNova.aspx", 'iframe_a');
        },
        failure: function (response) {
            document.getElementById("btSignIn").style.cursor = "pointer";
            alert('Tente Novamente');
        }
    });
}