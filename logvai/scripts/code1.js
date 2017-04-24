document.getElementById("inputPonto1").focus();

var Ponto1;
var Ponto2;
var DistanciaKM;

function SignIn(){
    document.getElementById('id01').style.display='none';
    window.open('SignIn.aspx', 'iframe_a');
}

function GeoCodeCalc01() {

    document.getElementById("txtDist").textContent = " 0Km"
    document.getElementById("txtDuracao").textContent = " 0min";
    document.getElementById("txtValor").textContent = " R$";

    document.getElementById("btCalcular").style.cursor = "progress";

    var addressInput = document.getElementById('inputPonto1').value + "," + document.getElementById('inputNumero1').value;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: addressInput }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            Ponto1 = results[0].geometry.location;
            GeoCodeCalc02();
        } else {
            document.getElementById("btCalcular").style.cursor = "pointer";
            alert("Informe Endereço de Origem");
            document.getElementById("inputPonto1").focus();
        };
    });

}

function GeoCodeCalc02() {
    var addressInput = document.getElementById('inputPonto2').value + "," + document.getElementById('inputNumero2').value;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: addressInput }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            Ponto2 = results[0].geometry.location;
            calcRoute();
        } else {
            document.getElementById("btCalcular").style.cursor = "pointer";
            alert("Informe Endereço de Destino");
            document.getElementById("inputPonto2").focus();
        };
    });
}

function calcRoute() {

    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix(
        {
            origins: [Ponto1],
            destinations: [Ponto2],
            travelMode: google.maps.TravelMode.DRIVING,
            unitSystem: google.maps.UnitSystem.METRIC,
            avoidHighways: false,
            avoidTolls: false
        }, callback);
}

function callback(response, status) {
    if (status != google.maps.DistanceMatrixStatus.OK) {
        alert(err);
    } else {
        var origin = response.originAddresses[0];
        var destination = response.destinationAddresses[0];
        if (response.rows[0].elements[0].status === "ZERO_RESULTS") {
            alert("Não foi possível encontrar roteiro entre: "
                + document.getElementById('inputPonto1').value + " E " + document.getElementById('inputPonto2').value);
        } else {
            var distance = response.rows[0].elements[0].distance;
            var distance_value = distance.text;
            DistanciaKM = distance.value / 1000;

            var duracao = response.rows[0].elements[0].duration;
            var duracao_text = duracao.text;

            document.getElementById("txtDist").textContent = distance_value;
            document.getElementById("txtDuracao").textContent = duracao_text;

            calculaValor();

            document.getElementById("btCalcular").style.cursor = "pointer";
            document.getElementById("idDiv1").style.display = "block"

        }
    }
}

function calculaValor() {

    var pontoValor = 5;
    var pontoQuant = 2;
    var kmValor = 2.2;
    var adicionalBanco = 15;
    
    var radios = document.getElementsByName("OpTempo");
    var tipoServ = radios[1].checked;
    if (tipoServ == true) {
        valorTotal += adicionalBanco;
    }

    var valorTotal = (pontoQuant * pontoValor) + (DistanciaKM * kmValor)
    

    document.getElementById("txtValor").textContent = "R$ " + valorTotal.toFixed(2);

}