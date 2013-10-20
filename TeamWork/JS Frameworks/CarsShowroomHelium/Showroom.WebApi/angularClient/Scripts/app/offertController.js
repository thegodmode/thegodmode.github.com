function OffertController($scope, $http, $location, $routeParams) {
    var id = $routeParams.id;
   
    var headers = { "X-sessionKey": localStorage.getItem("sessionKey") };
   
    $http.get("http://localhost:51597/api/offers/" + id, {
        headers: headers
    })
    .success(function (result) {
        $scope.offer = {
            title: result.title,
            description: result.description,
            id: result.id
        }
    });

    $scope.updateOffer = function () {
        $http.put("http://localhost:51597/api/offers/", $scope.offer, {
            headers: headers
        }).success(function (result) {
            alert("Update Successfull!");
        });
    };

    $scope.back = function () {
        $location.path("/main");
    }
}