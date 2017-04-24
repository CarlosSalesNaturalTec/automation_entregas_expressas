var input1 = document.getElementById('inputPonto1');
var input2 = document.getElementById('inputPonto2');

var defaultBounds = new google.maps.LatLngBounds(
    new google.maps.LatLng(-13.0099, -38.5323),
    new google.maps.LatLng(-12.7894, -38.2115));

var options1 = {
    bounds: defaultBounds
};

google.maps.event.addDomListener(window, 'load', function () {
    var places1 = new google.maps.places.Autocomplete(input1, options1);
    var places2 = new google.maps.places.Autocomplete(input2, options1);

});