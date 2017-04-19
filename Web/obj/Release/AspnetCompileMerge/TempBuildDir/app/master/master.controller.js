(function () {
    "use strict";

    angular
        .module("app")
        .controller("MasterController", controller);

    controller.$inject = ["$scope"];

    function controller($scope) {
        $scope.value = "MasterController";

        ////////////
    };
})();