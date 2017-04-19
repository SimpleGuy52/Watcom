(function() {
    "use strict";

    angular
        .module("app")
        .factory("fileExtensionsService", service);

    service.$inject = [];

    function service() {

        var serviceObj = {
            values: [],
            get: get,
            getDispayName: getDispayName
        };

        initValues();

        return serviceObj;

        ////////

        //Txt,
        //Pdf,
        //Js

        function initValues() {
            serviceObj.values = [
                { id: 0, value: "txt", dispayName: ".txt" },
                { id: 1, value: "pdf", dispayName: ".pdf" },
                { id: 2, value: "js", dispayName: ".js" }
            ];
        };

        function get(id) {
            var result = null;

            switch (id) {
            case 0:
                result = serviceObj.values[0];
                break;
            case 1:
                result = serviceObj.values[1];
                break;
            case 2:
                result = serviceObj.values[2];
                break;
            };

            return result;
        };
        
        function getDispayName(id) {
            var obj = get(id);
            if (obj)
                return obj.dispayName;
            else
                return id;
        };
    };
})();