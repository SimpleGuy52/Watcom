(function() {
    'use strict';
    angular
        .module('app')
        .factory('kpiService', service);

    service.$inject = [
        '$q'
    ];

    function service(
        $q
    ) {
        var service = {
            selectedKpi: { value: null },
            getKpi: getKpi,
            setKpi: setKpi,
            kpiSelectedEventHandlers: []
        };

        ////////////

        function setKpi(kpi) {
            service.selectedKpi.value = kpi;
            if (service.kpiSelectedEventHandlers && service.kpiSelectedEventHandlers.length > 0) {
                service.kpiSelectedEventHandlers.forEach(function (handler) {
                    handler(service.selectedKpi);
                });
            };
        };

        function getKpi() {
            return service.selectedKpi;
        };

        ///////////

        return service;
    };
})();