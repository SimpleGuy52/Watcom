(function () {
    "use strict";

    angular
        .module("app")
        .controller("KpiListController", controller);

    controller.$inject = [
        "$scope",
        "$compile",
        "$q",
        "$timeout",
        "kpiService",
        "webApiService"
    ];

    function controller(
        $scope,
        $compile,
        $q,
        $timeout,
        kpiService,
        webApiService
    ) {
        $scope.selectedKpi = kpiService.selectedKpi;
        $scope.kpies = [];
        $scope.loadingPromise = null;
        $scope.savingPromise = null;

        $scope.onValueChanged = onValueChanged;
        $scope.save = save;

        ////////////

        var resolvedPromise = $q.resolve();

        function save() {
            var dto = [];
            $scope.kpies.forEach(function(i) {
                var ob = {
                    Id: i.id,
                    Name: i.name
                }
                dto.push(ob);
            });

            $scope.savingPromise =
                $q.all([
                    artificialDelay(),
                    saveRequest(dto)
                ])
                .then(refresh);
        };

        function saveRequest(dto) {
            return webApiService.post("kpi", "update", dto)
                .then(function (data) {
                    $scope.kpies = data || [];
                });
        };

        function onValueChanged() {
            $scope.selectedKpi.value.refreshTrend();
        };

        function getKpies() {
            webApiService.get("kpi", "getAll")
                .then(function (data) {
                    $scope.kpies = data || [];
                });
        };

        var kpiPage = "";

        function getPage() {
            return webApiService.get("kpi", "getPage")
                .then(function (data) {
                    kpiPage = data.value;
                });
        };

        function preparePage() {
            var myElement = angular.element(document.querySelector("#kpiList"));
            var newElement = angular.element(kpiPage);
            myElement.append(newElement);
            $compile(newElement)($scope);
            return resolvedPromise;
        };

        function artificialDelay() {
            var defer = $q.defer();
            $timeout(function () {
                defer.resolve();
            }, 1000);
            return defer.promise;
        };

        function delay() {
            var defer = $q.defer();
            $timeout(function () {
                defer.resolve();
            }, 5000);
            return defer.promise;
        };

        function refreshWithDelay() {
            $scope.loadingPromise =
                delay()
                .then(getPage)
                .then(refresh)
                .then(preparePage);
        };

        function refresh() {
            return getKpies();
        };

        refreshWithDelay();
    };
})();