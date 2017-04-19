(function() {
    angular
        .module("app")
        .config(configure);

    configure.$inject = ["$stateProvider"];

    function configure($stateProvider) {
        $stateProvider
            .state("root", {
                url: "",
                templateUrl: "app/master/master.html",
                controller: "MasterController"
            })
            .state("root.home", {
                url: "/home",
                templateUrl: "app/home/home.html",
                controller: "HomeController"
            })
            .state("root.about", {
                url: "/about",
                templateUrl: "app/about/about.html",
                controller: "AboutController"
            })
            .state("root.movie", {
                url: "/movie",
                templateUrl: "app/movie/movie.html",
                controller: "MovieController"
            })
            .state("root.files", {
                url: "/files",
                templateUrl: "app/files/files.html",
                controller: "FilesController"
            });
    };
})();