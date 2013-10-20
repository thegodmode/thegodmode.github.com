
function MainPageController($scope, $http, $location) {
    $scope.admin = {
        username: localStorage.getItem("username"),

    };
    var headers = { "X-sessionKey": localStorage.getItem("sessionKey") };
    $scope.itemsToUpdate = [];
    loadUsersTable();

    $scope.logoutUser = function () {
        var headers = { "X-sessionKey": localStorage.getItem("sessionKey") };

        $http.put("http://localhost:51597/api/users/logout", null, {
            headers: headers
        })
        .success(function (result) {
            localStorage.clear();
            $location.path("/adminlogin");
        });
    }

    $scope.setAdminRights = function () {
        $scope.itemsToUpdate;
        for (var i = 0; i < $scope.itemsToUpdate.length; i++) {
            $scope.itemsToUpdate[i].isAdmin = true;
        }

        $http.put('http://localhost:51597/api/users/update', $scope.itemsToUpdate, {
            headers: headers
        }).success(function () {
        });
    }

    $scope.removeAdminRights = function () {
        $scope.itemsToUpdate;
        for (var i = 0; i < $scope.itemsToUpdate.length; i++) {
            $scope.itemsToUpdate[i].isAdmin = false;
        }

        $http.put('http://localhost:51597/api/users/update', $scope.itemsToUpdate, {
            headers: headers
        }).success(function () {
        });
    }

    $scope.deleteUsers = function () {
        for (var i = 0; i < $scope.itemsToUpdate.length; i++) {
            $scope.myData = _.filter($scope.myData, function(element) {
                return element.username != $scope.itemsToUpdate[i].username;
            });
        }
        //$http.put('http://localhost:51597/api/users/update', $scope.itemsToUpdate, {
        //    headers: headers
        //}).success(function () {
        //});
    }
    function loadUsersTable() {
        $scope.filterOptions = {
            filterText: "",
            useExternalFilter: true
        };
        $scope.totalServerItems = 0;
        $scope.pagingOptions = {
            pageSizes: [5, 10, 20],
            pageSize: 5,
            currentPage: 1
        };
        $scope.setPagingData = function (data, page, pageSize) {
            var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
            $scope.myData = pagedData;
            $scope.totalServerItems = data.length;
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        };
        $scope.getPagedDataAsync = function (pageSize, page, searchText) {
            setTimeout(function () {
                var data;
                if (searchText) {
                    var ft = searchText.toLowerCase();
                    $http.get('http://localhost:51597/api/users/all', {
                        headers: headers
                    }).success(function (largeLoad) {
                        data = largeLoad.filter(function (item) {
                            return JSON.stringify(item).toLowerCase().indexOf(ft) != -1;
                        });
                        $scope.setPagingData(data, page, pageSize);
                    });
                }
                else {
                    $http.get('http://localhost:51597/api/users/all', {
                        headers: headers
                    }).success(function (largeLoad) {
                        $scope.setPagingData(largeLoad, page, pageSize);
                    });
                }
            }, 100);
        };

        $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);

        $scope.$watch('pagingOptions', function (newVal, oldVal) {
            if (newVal !== oldVal && newVal.currentPage !== oldVal.currentPage) {
                $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
            }
        }, true);
        $scope.$watch('filterOptions', function (newVal, oldVal) {
            if (newVal !== oldVal) {
                $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
            }
        }, true);

        $scope.gridOptions = {
            data: 'myData',
            enablePaging: true,
            showFooter: true,
            totalServerItems: 'totalServerItems',
            pagingOptions: $scope.pagingOptions,
            filterOptions: $scope.filterOptions,
            columnDefs: [
                { field: 'username', displayName: 'User' },
                { field: 'isAdmin', displayName: 'Admin' }
            ],
            selectedItems: $scope.itemsToUpdate,
        };
    }
}