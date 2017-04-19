(function () {
    "use strict";

    angular
        .module("app")
        .factory("webApiService", service);

    service.$inject = [
        "$http",
        "$q"
    ];

    function service(
        $http,
        $q
        ) {

        var serviceObj = {
            confirm: "yes",
            get: get,
            post: post
        };

        return serviceObj;

        ////////

        function get(controller, method, id) {
            var url = generateUrl(controller, method, id);

            var requestPromise = $http({
                method: "GET",
                url: url
            });

            return generateResultPromise(requestPromise);
        };
        
        function post(controller, method, dto) {
            var url = generateUrl(controller, method, null);

            var requestPromise = $http({
                method: "POST",
                url: url,
                data: dto
            });

            return generateResultPromise(requestPromise);
        };

        function generateResultPromise(inputPromise) {
            var defered = $q.defer();
            inputPromise.then(function (data) {
                if (!data)
                    defered.resolve(null);
                else
                    defered.resolve(data.data);
            });

            return defered.promise;
        };

        function generateUrl(controller, method, id) {
            if (!controller || !method)
                return console.error("webApiService: params can not be empty");

            var urlArray = [];
            urlArray.push("http://localhost:44300/api");
            urlArray.push(controller);
            urlArray.push(method);
            if (id)
                urlArray.push(id);

            return urlArray.join("/");
        };
    };


    //function refresh() {
    //    var t = $http({
    //        method: "GET",
    //        url: "http://localhost:44300/api/movies/get/7"
    //    })
    //        .then(function (res) {
    //            $scope.movies = res.data;
    //        });


    //    var dto = {
    //        id: 7,
    //        name: "Elleonora"
    //    };

    //    var t2 = $http({
    //        method: "POST",
    //        url: "http://localhost:44300/api/movies/postmethod/",
    //        data: dto
    //    })
    //        .then(function (res) {
    //            var t3 = res.data;
    //        });
    //};

})();