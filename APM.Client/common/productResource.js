(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("productResource", ["$resource", "appSettings", productResource]);// factory service


    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/products/:id");
    };
} ());