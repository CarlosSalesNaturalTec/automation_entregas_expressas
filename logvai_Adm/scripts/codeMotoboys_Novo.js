document.getElementById("input_nome").focus();

function SalvarRegistro() {

    document.getElementById("divhidden").style.display = "block";

    //<!--*******Customização*******-->
    var v1 = document.getElementById("input_nome").value
    var v2 = document.getElementById("input_RG").value
    var v3 = document.getElementById("input_Endereco").value  
    var v4 = document.getElementById("Hidden1").value   //FOTO

    if (v1 == "") {
        document.getElementById("divhidden").style.display = "none";
        alert("Informe Nome do Motoboy");   //<!--*******Customização*******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_nome").focus();
        return;
    }

    //<!--*******Customização*******-->
    $.ajax({
        type: "POST",
        url: "WebService.asmx/MotoboySalvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            document.getElementById("btSalvar").style.cursor = "default";
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function AlterarRegistro() {

    document.getElementById("divhidden").style.display = "block";
    document.getElementById("btconcluir").disabled = true;
    document.getElementById("btSalvar").disabled = true;

    //<!--*******Customização*******-->
    var v1 = document.getElementById("IDHidden").value

    var v2 = document.getElementById("input_nome").value
    var v3 = document.getElementById("input_RG").value
    var v4 = document.getElementById("input_Endereco").value
    var v5 = document.getElementById("Hidden1").value   //FOTO

    if (v2 == "") {
        document.getElementById("divhidden").style.display = "none";
        alert("Informe Nome do Motoboy");   //<!--*******Customização*******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input_nome").focus();
        return;
    }

    //<!--*******Customização*******-->
    $.ajax({
        type: "POST",
        url: "WebService.asmx/MotoboyAlterar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            document.getElementById("btSalvar").style.cursor = "default";
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function cancelar() {
    var linkurl = "Motoboys_Listagem.aspx";   //<!--*******Customização*******-->
    window.location.href = linkurl;
}

//Menu
function openLink(evt, animName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("grupo");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-blue", "");
    }
    document.getElementById(animName).style.display = "block";
    evt.currentTarget.className += " w3-blue";
}

function classeBt2() {
    openLink(event, 'grupo2')
    $('#bt2').addClass(' w3-blue');
}
function classeBt3() {
    openLink(event, 'grupo3')
    $('#bt3').addClass(' w3-blue');
}
function classeBt4() {
    openLink(event, 'grupo4')
    $('#bt4').addClass(' w3-blue');
}
function classeBt5() {
    openLink(event, 'grupo5')
    $('#bt5').addClass(' w3-blue');
}
function classeBt6() {
    openLink(event, 'grupo6')
    $('#bt6').addClass(' w3-blue');
}
function classeBt7() {
    openLink(event, 'grupo7')
    $('#bt7').addClass(' w3-blue');
}
function classeBt8() {
    openLink(event, 'grupo8')
    $('#bt8').addClass(' w3-blue');
}
function classeBt9() {
    openLink(event, 'grupo9')
    $('#bt9').addClass(' w3-blue');
}



function btvoltar1() {
    openLink(event, 'grupo1')
    $('#bt1').addClass(' w3-blue');
}
function btvoltar2() {
    openLink(event, 'grupo2')
    $('#bt2').addClass(' w3-blue');
}
function btvoltar3() {
    openLink(event, 'grupo3')
    $('#bt3').addClass(' w3-blue');
}
function btvoltar4() {
    openLink(event, 'grupo4')
    $('#bt4').addClass(' w3-blue');
}
function btvoltar5() {
    openLink(event, 'grupo5')
    $('#bt5').addClass(' w3-blue');
}
function btvoltar6() {
    openLink(event, 'grupo6')
    $('#bt6').addClass(' w3-blue');
}
function btvoltar7() {
    openLink(event, 'grupo7')
    $('#bt7').addClass(' w3-blue');
}
function btvoltar8() {
    openLink(event, 'grupo8')
    $('#bt8').addClass(' w3-blue');
}



//Menu

//imagens - foto
var handleFileSelect = function (evt) {
    var files = evt.target.files;
    var file = files[0];
    if (files && file) {
        var reader = new FileReader();
        reader.onload = function (readerEvt) {
            var binaryString = readerEvt.target.result;
            var data_uri = "data:image/png;base64," + btoa(binaryString);
            document.getElementById('results').innerHTML = '<img src="' + data_uri + '"/>';
            document.getElementById("Hidden1").value = data_uri
        };
        reader.readAsBinaryString(file);
    }
};

if (window.File && window.FileReader && window.FileList && window.Blob) {
    document.getElementById('filePicker').addEventListener('change', handleFileSelect, false);
} else {
    alert('The File APIs are not fully supported in this browser.');
}
//imagens - foto