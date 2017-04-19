(function () {
    "use strict";

    angular
        .module("app")
        .controller("AboutController", controller);

    controller.$inject = ["$scope"];

    function controller($scope) {
        $scope.value = "About";

        ////////////
    };
})();