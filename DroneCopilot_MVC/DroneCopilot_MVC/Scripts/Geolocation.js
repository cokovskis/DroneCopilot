//var x = document.getElementById("myMap");

var startPos;
  var geoOptions = {
      enableHighAccuracy: true
  }

function getLocation() {
    if (navigator.geolocation) {
        //navigator.geolocation.watchPosition(showPosition,showError); //Andrejs Code
        // navigator.geolocation.getCurrentPosition(showPosition, showError);
		navigator.geolocation.getCurrentPosition(geoSuccess, showError, geoOptions); //Cryptos Code
	} else { 
        alert("You must allow location services to automatically position the map.");
    }
}


//Replacement for showPosition(position)
  var geoSuccess = function(position) {
      startPos = position;
      console.log("Position" + startPos.coords.latitude + " " + startPos.coords.longitude);
    //document.getElementById('startLat').innerHTML = startPos.coords.latitude;
    //document.getElementById('startLon').innerHTML = startPos.coords.longitude;
  };

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

getLocation();

