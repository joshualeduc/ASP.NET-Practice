(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource",
                ["$resource",
                 "appSettings",
                 "currentUser",
                    productResource])

    //null and "update" arguments create a custom action to $resource
    function productResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "api/products/:id", null, 
            {
                "update": {
                    method: 'Put',
                    headers: {"Authorization": "Bearer " + currentUser.getProfile().token}
                },
                "save": {
                    headers: { "Authorization": "Bearer " + currentUser.getProfile().token }
                },
                "get": {
                    headers: { "Authorization": "Bearer " + currentUser.getProfile().token }
                }
            });
    }
}());