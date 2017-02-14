(function () {
    "use strict";

    angular
        .module("productManagement")
        .controller("MainCtrl",
                    ["userAccount",
                        MainCtrl]);

    function MainCtrl(userAccount) {
        var vm = this;
        vm.isLoggedin = false;
        vm.message = '';
        vm.userData = {
            userName: '',
            email: '',
            password: '',
            confirmPassword: ''
        };

        vm.registerUser = function () {
            vm.userData.confirmPassword = vm.userData.password; //don't do this in a real app

            userAccount.registerUser(vm.userData,
                function (data) {
                    vm.confirmPassword = "";
                    vm.message = "... Registeration successful";
                    vm.login();
                },
                function (response) {
                    vm.isLoggedin = false;
                    vm.message = response.statusText + "\r\n";
                    if (response.data.exceptionMessage) {
                        vm.message += response.data.exceptionMessage;
                    }
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            vm.message += response.data.modelState[key] + "\r\n";
                        }
                    }
                });
        }

        vm.login = function () {

        }
    }
})();