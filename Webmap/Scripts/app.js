function mapOnClick(e) {
    api.get("RepairInfo/Get", {latitude: e.latlng.lat, longitude: e.latlng.lng})
        .then(function (address) {
            alert(JSON.stringify(address));
        });
}