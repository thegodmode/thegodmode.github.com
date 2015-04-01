var controllers = controllers || {}

controllers.MainController = function ($scope, myService) {


    $scope.doLogin = function () {


        myService.doLogin("test_user", "123").then(
            function (data) {

                alert(data)

            },
            function (reason) {

                alert(reason)
            }
        );

    }

    $scope.doRequest = function () {

        myService.doRequest()
         .then(function (data) {

             alert(data)

         },
         function (reason) {

             alert(reason)
         })
    }
};

app.controller(controllers);