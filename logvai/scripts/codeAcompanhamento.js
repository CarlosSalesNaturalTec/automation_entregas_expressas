function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.990281, lng: -38.472187 },
        zoom: 12
    });

    document.getElementById('inputPonto1').focus();
}