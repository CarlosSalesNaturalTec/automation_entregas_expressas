var input1 = document.getElementById('input_endereco');

var defaultBounds = new google.maps.LatLngBounds(
    new google.maps.LatLng(-13.0099, -38.5323),
    new google.maps.LatLng(-12.7894, -38.2115));

var options1 = {
    bounds: defaultBounds
};

google.maps.event.addDomListener(window, 'load', function () {
    var places1 = new google.maps.places.Autocomplete(input1, options1);
});