(function () {
    "use strict";
    angular
        .module("app")
        .controller("KpiController", controller);

    controller.$inject = [
        "$scope",
        "kpiService",
        "kpiMeasurementService"
    ];

    function controller(
        $scope,
        kpiService,
        kpiMeasurementService

        ) {

        $scope.data = ($scope.data && $scope.data.value) ? $scope.data : {
            name: "SHOPPING INDEX",
            value: "-",
            previousValue: 0,
            measure: "",
            trendDisplay: "- Нет данных",
            isNoData: true
        };

        $scope.isActive = false;

        $scope.refreshTrend = refreshTrend;
        $scope.getMeasurementDisplayName = getMeasurementDisplayName;

        ///////////

        function getMeasurementDisplayName(measurement) {
            return kpiMeasurementService.getByValue(measurement).displayName;
        };

        function prepareData() {
            if (!$scope.data || $scope.data.isNoData)
                return;

            refreshTrend();
        };

        function refreshTrend() {
            var trendValue = 0;
            var trendMeasure = "%";
            var trendIcon = "";
            var trend = ($scope.data.value - $scope.data.previousValue);

            if (trend === 0) {
            }
            else if (trend < 0) {
                trendIcon = "-";
                trendValue = (1 - ($scope.data.value / $scope.data.previousValue)) * 100;
            }
            else if (trend > 0) {
                trendIcon = "+";
                trendValue = (($scope.data.value - $scope.data.previousValue) / $scope.data.previousValue) * 100;
            };

            trendValue = (Math.round(trendValue)).toFixed(2);
            $scope.data.trend = trend;
            $scope.data.trendDisplay = trendIcon + trendValue + trendMeasure;
        };

        function kpiSelectedEventHandler(kpi) {
            var t = kpi;
            if ((kpi.value.data === $scope.data)) {
                $scope.isActive = true;
            } else {
                $scope.isActive = false;
            }
        };

        function subscribe() {
            kpiService.kpiSelectedEventHandlers.push(kpiSelectedEventHandler);
        };

        function refresh() {
            prepareData();
            subscribe();
        };


        refresh();
    };
})();