(function () {
    "use strict";
    // dependency on $resource
    angular
        .module("common.services", ["ngResource"])
        .constant("appSettings", {
            serverPath: "http://localhost:56138"
        });

} ());