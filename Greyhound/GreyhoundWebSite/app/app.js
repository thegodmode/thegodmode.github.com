var app = angular.module("app", ['ngRoute']);


app.constant('URLS', {

    "AllRace": "http://localhost:42300/api/race/getall",
    "SignalR":"http://localhost:42300/signalr"

});


app.config(function ($routeProvider) {
    $routeProvider
		.when('/', {

		    controller: "MainController",
		    templateUrl: "app/View.html"
		})
		.otherwise({
		    redirectTo: '/'
		});
});


