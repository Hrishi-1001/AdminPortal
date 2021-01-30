let map;
let marker = [];

function initMap() {
	if (map == null) {
		map = new google.maps.Map(document.getElementById("map"), {
			center: { lat: 28.644800, lng: 77.216721 },
			zoom: 8,
		});
		if (marker.length > 0) {
			marker.forEach(setMarker(latLng));
		}
	}
}

function setLatLng(zipcode, callback) {
	let geocoder = new google.maps.Geocoder();
	geocoder.geocode(
		{ address: zipcode },
		function (results, status) {
			if (status == google.maps.GeocoderStatus.OK) {
				callback(new google.maps.LatLng(results[0].geometry.location.lat(), results[0].geometry.location.lng()));
			} else {
				alert("Request failed.");
				callback(null);
			}
		}
	);
}

function moveToLoc(zipcode) {
	setLatLng(zipcode, function (latLng) {
		map.setCenter(latLng);
		map.setZoom(16);
	});
}

function markLocation(zipcode) {
	alert(zipcode);
	setLatLng(zipcode, function (latLng) {
		marker.push(latLng);
	});
}

function setMarker(latLng) {
	marker = new google.maps.Marker({
		position: latLng,
	});
	marker.setMap(map);
}