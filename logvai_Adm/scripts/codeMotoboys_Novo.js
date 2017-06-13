document.getElementById("input_nome").focus();

function SalvarRegistro() {

    document.getElementById("divhidden").style.display = "block";

    //<!--*******Customização*******-->
    var v1 = document.getElementById("input_nome").value
    var v2 = document.getElementById("input_apelido").value
    var v3 = document.getElementById("input_posicao").value
    var v4 = document.getElementById("input_local").value
    var v5 = document.getElementById("input_nascimento").value
    var v6 = document.getElementById("input_nacionalidade").value
    var v7 = document.getElementById("input_idioma").value
    var v8 = document.getElementById("input_clube").value
    var v9 = document.getElementById("input_inicio").value
    var v10 = document.getElementById("input_final").value
    var v11 = document.getElementById("input_cbf").value
    var v12 = document.getElementById("input_direito").value
    var v13 = document.getElementById("input_procura").value
    var v14 = document.getElementById("input_altura").value
    var v15 = document.getElementById("input_peso").value
    var v16 = document.getElementById("input_chute").value
    var v17 = document.getElementById("input_carac").value
    var v18 = document.getElementById("Hidden1").value


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
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '", param10: "' + v10 +
            '", param11: "' + v11 + '", param12: "' + v12 + '", param13: "' + v13 + '", param14: "' + v14 + '", param15: "' + v15 +
            '", param16: "' + v16 + '", param17: "' + v17 + '", param18: "' + v18 + '" }',
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

    //<!--*******Customização*******-->
    var v1 = document.getElementById("input_nome").value
    var v2 = document.getElementById("input_apelido").value
    var v3 = document.getElementById("input_posicao").value
    var v4 = document.getElementById("input_local").value
    var v5 = document.getElementById("input_nascimento").value
    var v6 = document.getElementById("input_nacionalidade").value
    var v7 = document.getElementById("input_idioma").value
    var v8 = document.getElementById("input_clube").value
    var v9 = document.getElementById("input_inicio").value
    var v10 = document.getElementById("input_final").value
    var v11 = document.getElementById("input_cbf").value
    var v12 = document.getElementById("input_direito").value
    var v13 = document.getElementById("input_procura").value
    var v14 = document.getElementById("input_altura").value
    var v15 = document.getElementById("input_peso").value
    var v16 = document.getElementById("input_chute").value
    var v17 = document.getElementById("input_carac").value
    var v18 = document.getElementById("Hidden1").value
    var v19 = document.getElementById("IDHidden").value


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
        url: "WebService.asmx/MotoboyAlterar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '", param10: "' + v10 +
            '", param11: "' + v11 + '", param12: "' + v12 + '", param13: "' + v13 + '", param14: "' + v14 + '", param15: "' + v15 +
            '", param16: "' + v16 + '", param17: "' + v17 + '", param18: "' + v18 + '", param19: "' + v19 + '" }',
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