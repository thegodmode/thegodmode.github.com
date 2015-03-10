var controllers = controllers || {}

controllers.MainController = function($scope, myService) {
	unit();

	function unit() {
		var person = {
			firstName: 'Bozhidar',
			lastName: 'Penchev',
			goingTo: 'http://google.com'
		}

		$scope.person = person
		$scope.message = "Hello Angular!"
		$scope.users = myService.getCustomers();


		
	}
};

app.controller(controllers);