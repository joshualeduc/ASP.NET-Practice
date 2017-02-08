(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource",
                ["$resource",
                 "appSettings",
                    productResource])

    //null and "update" arguments create a custom action to $resource
    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/products/:id", null, 
            {
                "update": { method: 'Put' }
            });
    }
}());