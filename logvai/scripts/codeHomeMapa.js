MostraMotoboys();

function MostraMotoboys() {

    $.ajax({
        type: "POST",
        url: "WebService.asmx/MotoboysOnLine",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            // formata retorno em formato padrão JSON 
            var strRetorno = "{\"counters\": " + response.d + "}";
           
            var jsonData = JSON.parse(strRetorno);
            for (var i = 0; i < jsonData.counters.length; i++) {
                var counter = jsonData.counters[i];

                console.log(counter.Nome);
                console.log(counter.Latitude);
                console.log(counter.Longitude);
            }


        },
        failure: function (response) {
            alert('Tente Novamente');
        }
    });

}

