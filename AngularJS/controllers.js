var controllers = controllers || {}

controllers.MainController = function($scope, $http, myService) {
	unit();

	function unit() {
		var person = {
			firstName: 'Bozhidar',
			lastName: 'Penchev',
			goingTo: 'http://google.com'
		}

		var customers = [{
 			name: "Tohn",
 			city: 'Lovech'
 		}, {
 			name: "Aose",
 			city: 'Pleven'
 		}, {
 			name: "Borka",
 			city: 'Tihyana'
 		}]


		$scope.person = person
		$scope.message = "Hello Angular!"
		myService.getCustomers().then(function(data){

              $scope.users = customers;

		});



	}
};

app.controller(controllers);