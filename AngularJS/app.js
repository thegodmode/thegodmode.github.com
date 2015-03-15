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

/* set default header for all request */
/*app.run([function ($http) {
	
	/*$http.defaults.headers.common.Authorization = 'Bearer YmVlcDpib29w' 

}])*/

/* delete header per request 
$http({
    method: 'GET',
    url: 'http://.../',

    transformRequest: function(data, headersGetter) {
        var headers = headersGetter();

        delete headers['Authorization'];

        return headers;
    }
}); */