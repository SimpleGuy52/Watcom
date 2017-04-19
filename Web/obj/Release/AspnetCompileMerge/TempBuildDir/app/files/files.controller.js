(function() {
    "use strict";

    angular
        .module("app")
        .controller("FilesController", controller);

    controller.$inject = [
        "$scope",
        "$q",
        "webApiService",
        "fileExtensionsService"
    ];

    function controller(
        $scope,
        $q,
        webApiService,
        fileExtensionsService
    ) {

        $scope.value = "Files";
        //$scope.folders = [];
        $scope.files = [];
        $scope.foldersTree = null;
        $scope.selectedFolder = null;
        $scope.page = { current: 0, top: 3, skip: 0, total: 0 };
        $scope.loadingPromise = null;
        $scope.loadingPromiseFiles = null;
        $scope.loadingPromiseFolders = null;

        $scope.selectFolder = selectFolder;
        $scope.pageChanged = pageChanged;
        $scope.getFileExtDispName = fileExtensionsService.getDispayName;

        ////////////

        var folders = [];

        function pageChanged(page) {
            $scope.page.skip = (page - 1) * $scope.page.top;
            refreshFiles();
        };

        function selectFolder(item) {
            if ($scope.selectedFolder === item)
                $scope.selectedFolder = null;
            else
                $scope.selectedFolder = item;
        };

        function refreshFiles() {
            $scope.loadingPromiseFiles = getFiles();
        };

        function getFiles() {
            var dto = {
                Skip: $scope.page.skip,
                Top: $scope.page.top
            };

            return webApiService.post("files", "get", dto)
                .then(function(data) {
                    $scope.files = data.values;
                    $scope.page.total = data.total;
                });
        };

        function getFolders() {
            return webApiService.get("folders", "get")
                .then(function(data) {
                    folders = data;
                });
        };

        function prepare() {
            $scope.foldersTree = folders;
            _.forEach($scope.foldersTree, function(f) {
                if (!f.parentId)
                    return;
                var parent = _.find($scope.foldersTree, { id: f.parentId });
                if (!parent.childrens)
                    parent.childrens = [];
                parent.childrens.push(f);
            });
            $scope.foldersTree = _.filter($scope.foldersTree, { parentId: null });
        };

        function refresh() {
            $scope.loadingPromise = $q.all([
                    getFiles(),
                    getFolders()
                ])
                .then(prepare);
        };

        refresh();
    };
})();