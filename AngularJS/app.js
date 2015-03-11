var app = angular.module("app", ['ngRoute']);

app.constant('URLS', {
    
    "Customers": "../customer/"
    
});

app.config(function($routeProvider) {
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

