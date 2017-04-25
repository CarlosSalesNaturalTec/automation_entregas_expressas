var Ponto1;
var Ponto2;
var DistanciaKM;

var LatLngPonto1;
var LatLngPonto2;
var NaoLocalizado1 = true;
var NaoLocalizado2 = true;

function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.990281, lng: -38.472187 },
        zoom: 12
    });
    var input1 = document.getElementById('inputPonto1');
    var input2 = document.getElementById('inputPonto2');

    var autocomplete1 = new google.maps.places.Autocomplete(input1);
    autocomplete1.bindTo('bounds', map);

    var autocomplete2 = new google.maps.places.Autocomplete(input2);
    autocomplete2.bindTo('bounds', map);
}

function CalculoGeral() {

    if (NaoLocalizado1) {
        alert('Endereço Inicial NÃO localizado');
        document.getElementById('inputPonto1').focus();
        return;
    }

    if (NaoLocalizado2) {
        alert('Endereço de Destino NÃO localizado');
        document.getElementById('inputPonto2').focus();
        return;
    }

    var chkretorno = document.getElementsByName('chkRetorno');
    var chkretorno2 = chkretorno[0].checked;
    if (chkretorno2 == true) {
        document.getElementById("badge3").className = "w3-badge w3-green";
    } else {
        document.getElementById("badge3").className = "w3-badge w3-gray";
    }

    document.getElementById("btCalcular").style.cursor = "progress";
    document.getElementById("txtDist").textContent = " 0Km"
    document.getElementById("txtDuracao").textContent = " 0min";
    document.getElementById("txtValor").textContent = " R$";

    Ponto1 = document.getElementById('inputPonto1').value + "," + document.getElementById('inputNumero1').value;
    Ponto2 = document.getElementById('inputPonto2').value + "," + document.getElementById('inputNumero2').value;

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
            alert("Não foi possível encontrar roteiro entre: "
                + document.getElementById('inputPonto1').value + " E " + document.getElementById('inputPonto2').value);
        } else {

            var distance = response.rows[0].elements[0].distance;
            DistanciaKM = (distance.value / 1000);

            var chkretorno = document.getElementsByName('chkRetorno');
            var chkretorno2 = chkretorno[0].checked;
            if (chkretorno2 == true) {
                distance = response.rows[1].elements[1].distance;
                DistanciaKM += (distance.value / 1000);
            }

            var duracao = response.rows[0].elements[0].duration;
            var duracao_text = duracao.text;

            document.getElementById("txtDist").textContent = DistanciaKM.toFixed(2) + 'Km';
            document.getElementById("txtDuracao").textContent = duracao_text;

            document.getElementById("btCalcular").style.cursor = "pointer";
            document.getElementById("idDiv1").style.display = "block"

            CalculoTempoEValor();
        }
    }
}

function CalculoTempoEValor() {

    var valorTotal;
    var pontoQuant;
    var kmValor;

    var pontoValor = 5;
    var adicionalBanco = 15;

    var tipo = document.getElementsByName('OpTempo');
    var tipotempo = tipo[0].checked;
    if (tipotempo == true) { kmValor = 1.8; } else { kmValor = 2.2; }

    var chkretorno = document.getElementsByName('chkRetorno');
    var chkretorno2 = chkretorno[0].checked;
    if (chkretorno2 == true) {
        pontoQuant = 3
    } else {
        pontoQuant = 2
    }

    valorTotal = (pontoQuant * pontoValor) + (DistanciaKM * kmValor);

    var chkbanco = document.getElementsByName('ChkBancoPonto2');
    var chkbanco2 = chkbanco[0].checked;
    if (chkbanco2 == true) {
        valorTotal += adicionalBanco;
    }

    document.getElementById("txtValor").textContent = "R$ " + valorTotal.toFixed(2);

}

function coordponto1() {

    var addressInput = document.getElementById('inputPonto1').value + "," + document.getElementById('inputNumero1').value;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: addressInput }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            LatLngPonto1 = results[0].geometry.location;
            document.getElementById("badge1").className = "w3-badge w3-green";
            NaoLocalizado1 = false;
        } else {
            document.getElementById("badge1").className = "w3-badge w3-red";
            NaoLocalizado1 = true;
        };
    });

    var marker = new google.maps.Marker({
        position: LatLngPonto1,
        map: map
    });

}

function coordponto2() {

    var addressInput = document.getElementById('inputPonto2').value + "," + document.getElementById('inputNumero2').value;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: addressInput }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            LatLngPonto2 = results[0].geometry.location;
            document.getElementById("badge2").className = "w3-badge w3-green";
            NaoLocalizado2 = false;
        } else {
            document.getElementById("badge2").className = "w3-badge w3-red";
            NaoLocalizado2 = true;
        };
    });

}
