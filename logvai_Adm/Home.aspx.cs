using System;
using System.Text;

public partial class Home : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //MotoboysOnLine();
            EntregasEmAberto();
            EntregasEmAndamento();
            EntregasRealizadas();
            EntregasRetorno();
            montaScript();
        }
    }

    private void MotoboysOnLine()
    {
        OperacaoBanco operacao1 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados1 = operacao1.Select("select ID_Motoboy, Nome ,Latitude ,Longitude, " +
            "format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
            "format(GeoDataLoc,'HH:mm:ss') as UltimaHora, " +
            "DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo  " +
            "FROM Tbl_Motoboys  ");

        coordenadas.Clear();
        nomemotoboy.Clear();

        while (dados1.Read())
        {
            //validações diversas
            int min1 = Convert.ToInt32(dados1[6]);  // diferença em minutos
            if (min1 > 185) { continue; } // verifica se diferença é maior que 5minutos (+dif+3horas getdate)
            if (Convert.ToString(dados1[2]) == "") { continue; } // verifica se existe coordenada lançada

            //adiciona coordenadas dos motoboys ativos nos últimos 5minutos
            coordenadas.Append("{ lat: " + Convert.ToString(dados1[2]) + ", lng: " + Convert.ToString(dados1[3]) + " },");
            nomemotoboy.Append("'" + Convert.ToString(dados1[1]) + "',");

        }
        ConexaoBancoSQL.fecharConexao();

        //remove ultimo caracter "," 
        if (coordenadas.Length == 0) { } else { coordenadas.Length--; }
        if (nomemotoboy.Length == 0) { } else { nomemotoboy.Length--; }

    }

    private void EntregasEmAberto()
    {

        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

        OperacaoBanco operacao2 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados2 = operacao2.Select("select Latitude ,Longitude, Endereco  " +
            "FROM Tbl_Entregas " +
            "where format(Data_Entrega ,'yyyy-MM-dd') ='" + datastatus + "' " +
            "and Status_Entrega = 'Em Aberto'");

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
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados3 = operacao3.Select("select Latitude ,Longitude, Endereco  " +
           "FROM Tbl_Entregas " +
           "where format(Data_Entrega ,'yyyy-MM-dd') ='" + datastatus + "' " +
           "and Status_Entrega = 'Em Andamento'");

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
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados3 = operacao3.Select("select Latitude ,Longitude, Endereco  " +
           "FROM Tbl_Entregas " +
           "where format(Data_Entrega ,'yyyy-MM-dd') ='" + datastatus + "' " +
           "and Status_Entrega = 'Concluído com Sucesso'");

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
        string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

        OperacaoBanco operacao3 = new OperacaoBanco();
        System.Data.SqlClient.SqlDataReader dados3 = operacao3.Select("select Latitude ,Longitude, Endereco  " +
           "FROM Tbl_Entregas " +
           "where format(Data_Entrega ,'yyyy-MM-dd') ='" + datastatus + "' " +
           "and Status_Entrega <> 'Concluído com Sucesso' "+
           "and Chegada_Ok = 1");


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

    // ---------------------------------------------------------------------------------------------------------------------------
    // Monta Mapa 
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

        str.Append(@"var image = 'images/motorcycleUpView22x54.png';
        
        var imageEmAberto = 'images/emaberto32.png';
        var imageEmAndamento = 'images/emandamento32.png';
        var imageEntregue = 'images/realizada32.png';
        var imageRetorno = 'images/retorno32.png';

        function initMap() {

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 13,
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

        </script>");

        Literal1.Text = str.ToString();

    }

}