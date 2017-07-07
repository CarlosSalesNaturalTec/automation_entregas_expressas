using System;
using System.Text;

public partial class EntregaHistorico : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    StringBuilder strFoto = new StringBuilder();
    StringBuilder strPath = new StringBuilder();

    StringBuilder coordenadas = new StringBuilder();
    StringBuilder nomemotoboy = new StringBuilder();

    StringBuilder emaberto = new StringBuilder();
    StringBuilder emabertoStr = new StringBuilder();

    StringBuilder emandamento = new StringBuilder();
    StringBuilder emandamentoStr = new StringBuilder();

    StringBuilder realizadas = new StringBuilder();
    StringBuilder realizadasStr = new StringBuilder();

    StringBuilder retorno = new StringBuilder();
    StringBuilder retornoStr = new StringBuilder();

    String IDAux;
    string idmotoboy = "";
    string TipoFicha = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        IDAux = Request.QueryString["v1"];
        TipoFicha = Request.QueryString["v2"];

        //preenche campos
        PreencheCampos(IDAux);


        //grid entregas filhas
        montaCabecalho();
        dadosCorpo(IDAux);
        montaRodape();

        //Monta Mapa
        montaMapa();

    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // preenche detalhes da entrega
    private void PreencheCampos(string ID)
    {
        string ScriptDados = "", ScriptFoto = "";


        string stringSelect = "select format(Data_OS,'dd/MM/yyyy hh:mm:ss') as DataOS, Distancia_Total,Tipo_Atendimento, Valor_Total,  " +
            "Forma_Pagam, Status_Pagam, Status_OS, PSCodTransacao, ID_Motoboy " +
            "from Tbl_Entregas_Master " +
            "where ID_Entrega = " + ID;

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptDados = "<script type=\"text/javascript\">" +
                "document.getElementById('IDHidden').value = \"" + ID + "\";" +
                "document.getElementById('OSdata').textContent = \"Data: " + Convert.ToString(rcrdset[0]) + "\";" +
                "document.getElementById('OSid').textContent = \"Número: " + ID + "\";" +
                "document.getElementById('OSdist').textContent = \"Distancia Total: " + Convert.ToString(rcrdset[1]) + "\";" +
                "document.getElementById('OStipo').textContent = \"Tipo Atendimento: " + Convert.ToString(rcrdset[2]) + "\";" +
                "document.getElementById('OSvalor').textContent = \"Valor Total: R$ " + Convert.ToString(rcrdset[3]) + "\";" +
                "document.getElementById('OSFormaPag').textContent = \"Forma de Pagam.: " + Convert.ToString(rcrdset[4]) + "\";" +
                "document.getElementById('OSstatusPag').textContent = \"Status do Pagam.: " + Convert.ToString(rcrdset[5]) + "\";" +
                "document.getElementById('OSstatusOS').textContent = \"Status da OS: " + Convert.ToString(rcrdset[6]) + "\";" +
                "document.getElementById('OSCod').textContent = \"Cod.Transação: " + Convert.ToString(rcrdset[7]) + "\";" +
                "</script>";
            idmotoboy = Convert.ToString(rcrdset[8]);
        }
        ConexaoBancoSQL.fecharConexao();
        str.Clear();
        str.Append(ScriptDados);
        Literal1.Text = str.ToString();


        //foto do motoboy
        stringSelect = "select FotoDataURI, Nome, Placa " +
            "from Tbl_Motoboys " +
            "where ID_Motoboy = " + idmotoboy;
        operacao = new OperacaoBanco();
        rcrdset = operacao.Select(stringSelect);
        while (rcrdset.Read())
        {
            ScriptFoto = "<script type=\"text/javascript\">" +
                "document.getElementById('results').innerHTML = '<img src=\"" + Convert.ToString(rcrdset[0]) + "\"/>'; " +
                "document.getElementById('OSNome').textContent = \"" + Convert.ToString(rcrdset[1]) + " / Placa: " + Convert.ToString(rcrdset[2]) + "\";" +
                "</script>";
        }
        ConexaoBancoSQL.fecharConexao();
        strFoto.Clear();
        strFoto.Append(ScriptFoto);
        LiteralFoto.Text = strFoto.ToString();

    }




    // ---------------------------------------------------------------------------------------------------------------------------
    // Grid Endereços e Status
    private void montaCabecalho()
    {
        string stringcomaspas = "<table id=\"tabela\" class=\"table table-striped table-hover \">" +
            "<thead>" +
            "<tr>" +
            "<th>ENDEREÇO</th>" +
            "<th>STATUS</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";
        str.Clear();
        str.Append(stringcomaspas);
    }

    private void dadosCorpo(string ID)
    {
        strPath.Clear();

        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
        string stringselect = "select Endereco, numero , Status_Entrega " +
                "from Tbl_Entregas " +
                "where ID_Entrega = " + ID +
                " order by Ordem";

        OperacaoBanco operacao = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

        while (dados.Read())
        {
            string Coluna1 = Convert.ToString(dados[0]);
            string Coluna2 = Convert.ToString(dados[2]);

            string stringcomaspas = "<tr>" +
                "<td>" + Coluna1 + "</td>" +
                "<td>" + Coluna2 + "</td>" +
                "</tr>";

            str.Append(stringcomaspas);

            strPath.Append("'" + Convert.ToString(dados[0]) + "," + Convert.ToString(dados[1]) + "',");
        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter (virgula)
        if (strPath.Length == 0) { } else { strPath.Length--; }

    }

    private void montaRodape()
    {
        string footer = "</tbody></table>";
        str.Append(footer);

        Literal2.Text = str.ToString();
    }



    // ---------------------------------------------------------------------------------------------------------------------------
    // Monta Mapa 
    private void montaMapa()
    {
        if (TipoFicha == "0") {LocalizacaoMotoboy();}
        
        EntregasEmAberto();
        EntregasEmAndamento();
        EntregasRealizadas();
        EntregasRetorno();
        montaScript();
    }

    private void LocalizacaoMotoboy()
    {
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados1 = operacao1.Select("select ID_Motoboy, Nome ,Latitude ,Longitude, " +
            "format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
            "format(GeoDataLoc,'HH:mm:ss') as UltimaHora " +
            "FROM Tbl_Motoboys " +
            "where ID_Motoboy=" + idmotoboy);

        coordenadas.Clear();
        nomemotoboy.Clear();

        while (dados1.Read())
        {
            //adiciona coordenadas do motoboy
            coordenadas.Append("{ lat: " + Convert.ToString(dados1[2]) + ", lng: " + Convert.ToString(dados1[3]) + " },");
            nomemotoboy.Append("'Motoboy: " + Convert.ToString(dados1[1]) + "',");
        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter "," 
        if (coordenadas.Length == 0) { } else { coordenadas.Length--; }
        if (nomemotoboy.Length == 0) { } else { nomemotoboy.Length--; }

    }

    private void EntregasEmAberto()
    {

        OperacaoBanco operacao2 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados2 = operacao2.Select("select Latitude ,Longitude, Endereco  " +
            "FROM Tbl_Entregas " +
            "where Status_Entrega = 'Em Aberto' "+
            "and ID_Entrega =" + IDAux);

        emaberto.Clear();
        emabertoStr.Clear();

        while (dados2.Read())
        {
            emaberto.Append("{ lat: " + Convert.ToString(dados2[0]) + ", lng: " + Convert.ToString(dados2[1]) + " },");
            emabertoStr.Append("'EM ABERTO: " + Convert.ToString(dados2[2]) + "',");

        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter "," 
        if (emaberto.Length == 0) { } else { emaberto.Length--; }
        if (emabertoStr.Length == 0) { } else { emabertoStr.Length--; }

    }

    private void EntregasEmAndamento()
    {

        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados3 = operacao3.Select("select Latitude ,Longitude, Endereco  " +
           "FROM Tbl_Entregas " +
           "where Status_Entrega = 'Em Andamento' " +
           "and ID_Entrega =" + IDAux);

        emandamento.Clear();
        emandamentoStr.Clear();

        while (dados3.Read())
        {
            emandamento.Append("{ lat: " + Convert.ToString(dados3[0]) + ", lng: " + Convert.ToString(dados3[1]) + " },");
            emandamentoStr.Append("'EM ANDAMENTO: " + Convert.ToString(dados3[2]) + "',");

        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter "," 
        if (emandamento.Length == 0) { } else { emandamento.Length--; }
        if (emandamentoStr.Length == 0) { } else { emandamentoStr.Length--; }

    }

    private void EntregasRealizadas()
    {
        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados3 = operacao3.Select("select Latitude ,Longitude, Endereco  " +
           "FROM Tbl_Entregas " +
           "where Status_Entrega = 'Concluído com Sucesso' " +
           "and ID_Entrega =" + IDAux);

        realizadas.Clear();
        realizadasStr.Clear();

        while (dados3.Read())
        {
            realizadas.Append("{ lat: " + Convert.ToString(dados3[0]) + ", lng: " + Convert.ToString(dados3[1]) + " },");
            realizadasStr.Append("'REALIZADA: " + Convert.ToString(dados3[2]) + "',");

        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter "," 
        if (realizadas.Length == 0) { } else { realizadas.Length--; }
        if (realizadasStr.Length == 0) { } else { realizadasStr.Length--; }

    }

    private void EntregasRetorno()
    {
        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados3 = operacao3.Select("select Latitude ,Longitude, Endereco  " +
           "FROM Tbl_Entregas " +
           "where Status_Entrega <> 'Concluído com Sucesso' " +
           "and Chegada_Ok = 1 " +
           "and ID_Entrega =" + IDAux);

        retorno.Clear();
        retornoStr.Clear();

        while (dados3.Read())
        {
            retorno.Append("{ lat: " + Convert.ToString(dados3[0]) + ", lng: " + Convert.ToString(dados3[1]) + " },");
            retornoStr.Append("'RETORNO: " + Convert.ToString(dados3[2]) + "',");

        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter "," 
        if (retorno.Length == 0) { } else { retorno.Length--; }
        if (retornoStr.Length == 0) { } else { retornoStr.Length--; }

    }

    private void montaScript()
    {
        str.Clear();

        str.Append(@"<script type='text/javascript'> 
            var map;
            var coordEntregador = [");
        str.Append(coordenadas.ToString());
        str.Append(@"];");

        str.Append(@"var NomeEntregador = [");
        str.Append(nomemotoboy.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasEmAberto = [");
        str.Append(emaberto.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasEmAbertoSTR = [");
        str.Append(emabertoStr.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasEmAndamento = [");
        str.Append(emandamento.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasEmAndamentoSTR = [");
        str.Append(emandamentoStr.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasRealizadas = [");
        str.Append(realizadas.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasRealizadasSTR = [");
        str.Append(realizadasStr.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasRetorno = [");
        str.Append(retorno.ToString());
        str.Append(@"];");

        str.Append(@"var EntregasRetornoSTR = [");
        str.Append(retornoStr.ToString());
        str.Append(@"];");

        str.Append(@"var PontosPath = [");
        str.Append(strPath.ToString());
        str.Append(@"];");

        str.Append(@"var image = 'images/motorcycleUpView22x54.png';
        
        var imageEmAberto = 'images/emaberto32.png';
        var imageEmAndamento = 'images/flagEmAndamento.png';
        var imageEntregue = 'images/emandamento32.png';
        var imageRetorno = 'images/retorno32.png';

        var directionsService;
        var directionsDisplay;

        function initMap() {

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 11,
                center: { lat: -12.9525123, lng: -38.4535139 }
            });

            for (var i = 0; i < coordEntregador.length; i++) {
                MarcadorEntregador(coordEntregador[i],NomeEntregador[i]);
            }

            for (var i = 0; i < EntregasEmAberto.length; i++) {
                MarcadorEntrega(EntregasEmAberto[i],EntregasEmAbertoSTR[i]);
            }

            for (var i = 0; i < EntregasEmAndamento.length; i++) {
                MarcadorEmAndamento(EntregasEmAndamento[i],EntregasEmAndamentoSTR[i]);
            }

            for (var i = 0; i < EntregasRealizadas.length; i++) {
                MarcadorRealizadas(EntregasRealizadas[i],EntregasRealizadasSTR[i]);
            }

            for (var i = 0; i < EntregasRetorno.length; i++) {
                MarcadorRetornos(EntregasRetorno[i],EntregasRetornoSTR[i]);
            }

            //tracar roteiro
            directionsService = new google.maps.DirectionsService;
            directionsDisplay = new google.maps.DirectionsRenderer;
            directionsDisplay.setMap(map);

            // Exibe roteiro no mapa
            calculateAndDisplayRoute(directionsService, directionsDisplay);

        }
     
        function MarcadorEntregador(position,dadosc) {

            var marker = new google.maps.Marker({
            position: position,
            icon: image,
            title: dadosc,
            map: map
            });

            var infowindow = new google.maps.InfoWindow({
                content: dadosc
            });

            marker.addListener('click', function() {
                infowindow.open(marker.get('map'), marker);
            });

        }

        function MarcadorEntrega(position,info) {

            var markersEntregas = new google.maps.Marker({
            position: position,
            title: info,
            map: map
            });

            markersEntregas.setAnimation(google.maps.Animation.BOUNCE);

            var infowindow2 = new google.maps.InfoWindow({
                content: info
            });

            markersEntregas.addListener('click', function() {
                infowindow2.open(markersEntregas.get('map'), markersEntregas);
            });

        }

        function MarcadorEmAndamento(position,dadosc) {

            var marker1 = new google.maps.Marker({
            position: position,
            icon: imageEmAndamento,
            title: dadosc,
            map: map
            });

            var infowindow1 = new google.maps.InfoWindow({
                content: dadosc
            });

            marker1.addListener('click', function() {
                infowindow1.open(marker1.get('map'), marker1);
            });


        }

        function MarcadorRealizadas(position,dadosc) {

            var marker3 = new google.maps.Marker({
            position: position,
            icon: imageEntregue,
            title: dadosc,
            map: map
            });

            var infowindow3 = new google.maps.InfoWindow({
                content: dadosc
            });

            marker3.addListener('click', function() {
                infowindow3.open(marker3.get('map'), marker3);
            });

        }

        function MarcadorRetornos(position,dadosc) {

            var marker4 = new google.maps.Marker({
            position: position,
            icon: imageRetorno,
            title: dadosc,
            map: map
            });

            var infowindow4 = new google.maps.InfoWindow({
                content: dadosc
            });

            marker4.addListener('click', function() {
                infowindow4.open(marker4.get('map'), marker4);
            });

        }

        function calculateAndDisplayRoute(directionsService, directionsDisplay) {

            directionsService.route({
                origin: PontosPath[0],
                destination: PontosPath[1],
                travelMode: 'DRIVING'
            }, function (response, status) {
                if (status === 'OK') {
                    //pinta o roteiro no mapa
                    directionsDisplay.setDirections(response);
                } else {
                    //window.alert('Directions request failed due to ' + status);
                }
            });
        }

        </script>");

        LiteralMapa.Text = str.ToString();

    }

}