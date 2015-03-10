var app = angular.module("app", ['ngRoute']);


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

app.directive('userInfoCard', [function() {
	return {
		restrict: 'E',
		transclude: true,
		scope: {},
		link: function(scope, iElement, iAttrs) {

			$('body').on('keypress', function(evt) {

				var vidEl = $('#video').get(0);
				if (evt.keyCode === 32) {
					if (vidEl.paused) {

						vidEl.play();

					} else {

						vidEl.pause();
					}

				};

			});

		},
		controller: function($scope) {

           
			$scope.$on("change", function(event, data) {

				$scope.$apply(function(){

					$scope.id = data
				});

			})
     


		},
		templateUrl: 'user-info-card.html'

	};
}])

app.directive('test', ['$routeParams', '$rootScope', function($routeParams, $rootScope) {
	return {
		restrict: 'E',
		scope: {},
		transclude: true,
		require: '^userInfoCard',
		link: function(scope, element, iAttrs, userInfoCardCtr) {

			element.on("click", function() {

				$rootScope.$broadcast("change", $routeParams.id)

			});



		},
		controller: function($scope) {



		},
		templateUrl: 'test.html'

	};
}])