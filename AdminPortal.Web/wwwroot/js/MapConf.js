let map;

function initMap() {
	if (map == null) {
		map = new google.maps.Map(document.getElementById("map"), {
			center: { lat: 28.644800, lng: 77.216721 },
			zoom: 8,
		});
	}
}

function getLatLngByZipcode(zipcode, callback) {
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
	getLatLngByZipcode(zipcode, function (latLng) {
		map.setCenter(latLng);
		map.setZoom(16);
	});
}

function setMarker(zipcode) {
	alert(zipcode);
	getLatLngByZipcode(zipcode, function (latLng) {
		let marker = new google.maps.Marker({
			position: latLng,
			title: "This is an installation"
		});
		map.setMarker(latLng);
		map.setCenter(latLng);
		map.setZoom(16);
	});
}