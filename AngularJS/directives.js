var directives = directives || {}


directives.userInfoCard = function() {
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

				$scope.id = data


			})



		},
		templateUrl: 'user-info-card.html'

	};
}

directives.test = function($routeParams, $rootScope, myService) {


	return {
		restrict: 'E',
		scope: {},
		transclude: true,
		require: '^userInfoCard',
		link: function(scope, element, iAttrs, userInfoCardCtr) {



		},
		controller: function($scope) {

			function Example() {

				$rootScope.$broadcast("change", $routeParams.id);
				$scope.customers = myService.getCustomers();

			}

			
			
			$scope.update = Example

		},
		templateUrl: 'test.html'

	};
}



app.directive(directives)