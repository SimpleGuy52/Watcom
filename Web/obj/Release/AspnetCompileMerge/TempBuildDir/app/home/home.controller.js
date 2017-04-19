(function () {
    "use strict";

    angular
        .module("app")
        .controller("HomeController", controller);

    controller.$inject = ["$scope"];

    function controller($scope) {
        $scope.value = "Home - angular 2";

        ////////////
    };
})();