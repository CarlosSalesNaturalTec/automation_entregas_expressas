function Selecao_Periodo(selecao) {
    if (selecao == 'ESPECÍFICO') {
        document.getElementById("inputData1").style.visibility = "visible";
        document.getElementById("inputData2").style.visibility = "visible";
        document.getElementById("inputData1").focus();
    } else {
        document.getElementById("inputData1").style.visibility = "hidden";
        document.getElementById("inputData2").style.visibility = "hidden";
    }

}