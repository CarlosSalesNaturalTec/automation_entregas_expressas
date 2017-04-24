function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.990281, lng: -38.472187 },
        zoom: 12
    });
    var input1 = document.getElementById('inputPonto1');
    var input2 = document.getElementById('inputPonto2');

    var autocomplete1 = new google.maps.places.Autocomplete(input1);
    autocomplete1.bindTo('bounds', map);

    var autocomplete2 = new google.maps.places.Autocomplete(input2);
    autocomplete2.bindTo('bounds', map);

    document.getElementById('inputPonto1').focus();
}