var x = document.getElementById("myMap");

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.watchPosition(showPosition,showError);
        // navigator.geolocation.getCurrentPosition(showPosition, showError);
    } else { 
        alert("You must allow location services to automatically position the map.");
    }
}

function showPosition(position) {
    /*
    x.innerHTML = "Latitude: " + position.coords.latitude + 
    "<br>Longitude: " + position.coords.longitude;
    */

}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            alert("You must allow location services to automatically position the map.");
            break;
        case error.POSITION_UNAVAILABLE:
            alert("Location information is unavailable.");
            break;
        case error.TIMEOUT:
            alert("The request to get user location timed out.");
            break;
        case error.UNKNOWN_ERROR:
            alert("An unknown error occurred.");
            break;
    }
}
