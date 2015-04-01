var app = angular.module("app", ['ngRoute']);


app.constant('URLS', {

    "login": "http://softuni-ads.azurewebsites.net/api/user/login",
    "doRequest": "http://softuni-ads.azurewebsites.net/api/user/ads"

});


app.config(function ($routeProvider) {
    $routeProvider
		.when('/', {

		    controller: "MainController",
		    templateUrl: "Partials/View.html"
		})
		.when('/test/:id', {
		    templateUrl: 'Partials/TestPartial.html'
		})
		.otherwise({
		    redirectTo: '/'
		});
});


/* set default header for all request */
app.run(function ($http) {

    var access_token = $.cookie("token")
    if (access_token !== undefined) {
        $http.defaults.headers.common.Authorization = 'Bearer ' + access_token;
    }

})

