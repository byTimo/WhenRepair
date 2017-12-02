var api = {
    get: function (uri, params) {
        var paramsKeys = Object.keys(params);
        var paramLine = "";
        for(var i = 0; i < paramsKeys.length; i++){
            paramLine += paramsKeys[i] + "=" + params[paramsKeys[i]].toString();
            if (i + 1 !== paramsKeys.length)
                paramLine += "&"
        }
        
        uri = uri + (paramLine !== "" ? "?" + paramLine : "");
        
        return fetch(uri, {
            method: "GET"
        }).then(function(response) {
            if (response.ok)
                return response.json();
        })
    }
};