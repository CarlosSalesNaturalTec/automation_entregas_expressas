function liberaFaturamento() {

    var atual = document.getElementById('input_faturar').value;
    var texto = "";
    if (atual == "SIM") {
        texto = "Bloqueia Faturamento ?"
    } else {
        texto = "Libera Faturamento ?"
    }

    var r = confirm(texto);
    if (r != true) {
        return;
    } else {

    }



}