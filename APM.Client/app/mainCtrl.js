(function () {
    "use strict";

    angular
        .module("productManagement")
        .controller("MainCtrl", ["userAccount", MainCtrl]); // dependencia con userAccount

    function MainCtrl(userAccount) {
        var vm = this;
        vm.isLoggedIn = false;
        vm.message = '';
        vm.userData = {
            userData: '',
            email: '',
            password: '',
            confirmPassword: ''
        };
        vm.registerUser = function () {
        }
        vm.login = function () { 
        }
    }
})();