<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contatos.aspx.cs" Inherits="Contatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGVAI - Fale Conosco</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        body{
            background-image:url(images/background.jpg)
        }
    </style>

</head>
<body>

    <br><br><br><br><br>

    <div class="w3-light-gray" id="contact">
        <h1 class="w3-bottombar"><i class="fa fa-volume-control-phone" aria-hidden="true"></i> Contatos - Fale Conosco</h1>
        <div class="w3-row">
            <div class="w3-col m5">
                <div class="w3-padding-16"><span class="w3-xlarge w3-border-teal"></span></div>
                <p><i class="fa fa-map-marker w3-text-blue w3-xlarge"></i>&nbsp;&nbsp;Av. ACM, 2671, Parque Bela Vista, Edf.
                    Bahia Center</p>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Salvador-Bahia. CEP: 40.280-000</p>
                <p><i class="fa fa-phone w3-text-blue w3-xlarge"></i>&nbsp;&nbsp;+55 (71) 3555-2700</p>
                <i class="fa fa-envelope-o w3-text-blue w3-xlarge"></i>&nbsp;&nbsp;<a href="mailto:comercial@loglogistica.com.br">comercial@loglogistica.com.br</a>
            </div>
            <div class="w3-col m7">
                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15550.942991215768!2d-38.4718281!3d-12.9887461!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x3e98edcaaf0fdf3d!2sEdif%C3%ADcio+Bahia+Center!5e0!3m2!1spt-BR!2sbr!4v1492218134296"
                    width="100%" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
            </div>
        </div>
        <br>
    </div>

</body>
</html>
