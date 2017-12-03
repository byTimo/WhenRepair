function mapOnClick(lat, lng) {
    $("#loading_placeholder").show();
    return api.get("RepairInfo/Get", {latitude: lat, longitude: lng})
        .then(function (data) {
            $("#loading_placeholder").hide();
            if (!data) {
                $("#infoPanel").hide();
                return;
            }
            $("#infoPanel").show();
            $(".left_child").hide();
            $("#repairProperties").show();
            var address = data.address;
            $("#title").text(address["Street"] + ", " + address["House"]);
            $("#subtitle").text(address["City"] + ", " + address["State"]);
            $("#postcode").text(address["Postcode"]);
            
            if (data.repair){
                $("#info_placeholder").hide();
                $("#info").show();
                var house = data.repair.House;
                var houseKeys = Object.keys(house);
                for (var i = 0; i < houseKeys.length; i++){
                    $("#" + houseKeys[i]).text(house[houseKeys[i]]);
                }
            } else{
                $("#info").hide();
                $("#info_placeholder").show();
            }
        });
}

function getRepairInfo(map, lat, lng) {
    targetMarker && targetMarker.removeFrom(map);
    map.panTo(new L.LatLng(lat, lng));
    mapOnClick(lat,  lng).then(function() {
        if (!targetMarker) {
            targetMarker = new L.Marker([lat, lng]);
            targetMarker.addTo(map);
        } else {
            targetMarker.setLatLng([lat, lng]);
            targetMarker.addTo(map);
        }
    });
}

$( function() {
    var cache = {};
    $("#addressInput").autocomplete({
        minLength: 5,
        source: function( request, response ) {
            var term = request.term;
            if (term in cache) {
                response(cache[term]);
                return;
            }

            $.getJSON("Address/Autocomplete", request, function (data, status, xhr) {
                cache[term] = data;
                response(data);
            })
        },
        select: function( event, ui ) {
            $("#loading_placeholder").show();
            api.get("House/Search", { address: ui.item.value })
                .then(function (data) {
                    getRepairInfo(map, data.Latitude, data.Longitude);
                });
        }
    });
} );