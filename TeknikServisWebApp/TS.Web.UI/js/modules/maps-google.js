        function initMap(konum) {
            var latlng = {
                lat: konum.coords.latitude,
                lng: konum.coords.longitude
            };
            console.log(latlng);
            var mapdiv = document.getElementById('map');
            var settings = {
                center: latlng,
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                mapTypeControl: true,
                navigationControlOptions: {
                    style: google.maps.NavigationControlStyle.SMALL
                }
            };
            var map = new google.maps.Map(mapdiv, settings);
            var marker = new google.maps.Marker({
                position: latlng,
                map: map,
                title: "Þu anda buradasýnýz",
                animation: google.maps.Animation.DROP,
                draggable: true
            });

            var trafficLayer = new google.maps.TrafficLayer();
            trafficLayer.setMap(map);
            var transitLayer = new google.maps.TransitLayer();
            transitLayer.setMap(map);

            function toggleMarker() {
                if (marker.getAnimation() !== null) {
                    marker.setAnimation(null);
                } else {
                    marker.setAnimation(google.maps.Animation.BOUNCE);
                }
            }

            marker.addListener("click", toggleMarker);
            marker.addListener("dragend",
                function (e) {
                    var enboy = {
                        enlem: e.latLng.lat(),
                        boylam: e.latLng.lng()
                    };
                    console.log(enboy);
                });

            map.addListener("click",
                function () {
                    marker.setMap(null);
                });
            map.addListener("click",
                function (e) {
                    placeMarkerAndPanTo(e.latLng, map);
                });

            function placeMarkerAndPanTo(pos, m) {
                google.maps.Marker
                marker = new google.maps.Marker({
                    position: pos,
                    map: m
                });
                var enboy = {
                    enlem: pos.lat(),
                    boylam: pos.lng()
                };
                console.log(enboy);
                lokantalarigetir(enboy);
                map.panTo(pos);
                var streetdiv = document.getElementById("street");
                var streetsettings = {
                    position: { lat: enboy.enlem, lng: enboy.boylam },
                    addressControlOptions: {
                        position: google.maps.ControlPosition.BOTTOM_CENTER
                    },
                    linksControl: false,
                    panControl: false,
                    enableCloseButton: false
                };
                var street = new google.maps.StreetViewPanorama(streetdiv, streetsettings);
                var calisti = false;
                street.addListener('position_changed', function () {
                    console.log(street.getPosition());
                    if (calisti) {
                        marker.setMap(null);
                        placeMarkerAndPanTo(street.getPosition(), map);
                    }
                    calisti = true;
                });
            }
        }

$("#btnkonumbul").click(function () {
    navigator.geolocation.getCurrentPosition(initMap);
});
