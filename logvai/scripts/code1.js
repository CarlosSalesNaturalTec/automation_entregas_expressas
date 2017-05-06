document.getElementById("inputPonto1").focus();

var Ponto1;
var Ponto2;
var DistanciaKM;

function ExibirModal() {
    document.getElementById('id01').style.display = 'block';
    document.getElementById('input_User').focus();
}

function SignIn() {
    document.getElementById('id01').style.display = 'none';
    window.open('SignIn.aspx', 'iframe_a');
}

function CalculoGeral() {

    // UI - User Interface 
    document.getElementById("btCalcular").style.cursor = "progress";
    document.getElementById("txtDist").textContent = " 0Km"
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
            alert("Não foi possível encontrar roteiro");
        } else {

            var distance = response.rows[0].elements[0].distance;
            DistanciaKM = (distance.value / 1000);

            var chkretorno = document.getElementsByName('chkRetorno');
            var chkretorno2 = chkretorno[0].checked;
            if (chkretorno2 == true) {
                distance = response.rows[1].elements[1].distance;
                DistanciaKM += (distance.value / 1000);
            }

            document.getElementById("txtDist").textContent = DistanciaKM.toFixed(2) + 'Km';
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
    if (tipotempo == true) { kmValor = 1.5; } else { kmValor = 2.2; }

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

function TentarLoginCot() {

    var v1 = document.getElementById("input_User").value;
    var v2 = document.getElementById("input_pwd").value;

    if (v1 == "") { alert('Informe nome do Usuário!'); document.getElementById('input_User').focus(); return; }
    if (v2 == "") { alert('Informe Senha!'); document.getElementById('input_pwd').focus(); return; }

    document.getElementById('bt_loginCot').style.cursor = "progress";

    $.ajax({
        type: "POST",
        url: "WebService.asmx/login",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var linkurl = response.d;
            window.open(linkurl, '_parent');
        },
        failure: function (response) {
            alert('Tente Novamente');
        }
    });
}