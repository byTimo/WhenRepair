function mapOnClick(e) {
    $("#loading_placeholder").show();
    return api.get("RepairInfo/Get", {latitude: e.latlng.lat, longitude: e.latlng.lng})
        .then(function (data) {
            $("#loading_placeholder").hide();
            if (!data) {
                $("#sidebarContainer").hide();
                return;
            }
            $("#sidebarContainer").show();
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