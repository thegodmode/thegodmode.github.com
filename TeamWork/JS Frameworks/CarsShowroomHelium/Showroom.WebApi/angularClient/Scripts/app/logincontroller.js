/// <reference path="../libs/underscore.js" />
/// <reference path="../posts.js" />

function LoginController($scope, $http, $location) {
    $scope.user = {
        username: "admin",
        password: "admin123456",
    };
    
    $scope.loginUser = function (ev) {
        ev.preventDefault();

        var userData = {

            username: $scope.user.username,
            authCode: CryptoJS.SHA1($scope.user.password).toString()
           
        }

        $http.post("http://localhost:51597/api/users/login", userData)
        .success(function (result) {
            if (result.isAdmin) {
                localStorage.setItem("username", result.username)
                localStorage.setItem("sessionKey", result.sessionKey)
                $location.path("/main");
                $scope.user = {
                    username: "",
                    password: "",
                };
            }
            else {

                $("#error").html("You are not admin").show(300);
            }
        })
    }
}