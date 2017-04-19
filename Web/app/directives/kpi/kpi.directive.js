(function () {
    "use strict";

    angular
        .module("app")
        .directive("kpi", dir);

    dir.$inject = [
        "$compile",
        "kpiService"
    ];

    function dir(
        $compile,
        kpiService
        ) {

        var directive = {
            link: link,
            scope: {
                data: "="
            },
            restrict: "A",
            replace: true,
            templateUrl: "app/directives/kpi/kpi.html",
            controller: "KpiController",
        };
        return directive;


        function link(scope, element, attrs) {
            element.bind('click', function () {
                if (scope.data.isNoData)
                    return;
                kpiService.setKpi(scope);
            });
        };
    };
})();