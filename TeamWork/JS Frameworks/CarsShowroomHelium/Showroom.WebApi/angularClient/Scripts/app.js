/// <reference path="../libs/underscore.js" />
/// <reference path="../libs/angular.js" />

angular.module("carsroom", ['ngGrid'])
	.config(["$routeProvider", function ($routeProvider) {
		$routeProvider
			.when("/adminlogin", { templateUrl: "Scripts/partials/login.html", controller: LoginController })
            .when("/main", { templateUrl: "scripts/partials/main.html", controller: MainPageController })
			.when("/offers/:id", { templateUrl: "scripts/partials/offert.html", controller: OffertController })
			.otherwise({ redirectTo: "/adminlogin" });
	}]);
