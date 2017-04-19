(function () {
    "use strict";
    angular
        .module("app")
        .factory("kpiMeasurementService", ser);

    ser.$inject = [];

    function ser() {
        var service = {
            values: null,
            getValues: getValues,
            getByValue: getByValue
        };

        initValues();

        return service;

        /////////////

        function initValues() {
            service.values = [
                { id: 0, value: "human", displayName: "чел." },
                { id: 1, value: "minute", displayName: "мин." },
                { id: 2, value: "percent", displayName: "%" }
            ];
        };

        function getValues() {
            return service.values;
        };

        function getByValue(value) {
            var v = value.toLowerCase();
            var result = _.find(service.values, { value: v });
            return result ? result : {}
        };
    };
})();