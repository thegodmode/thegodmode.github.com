var controllers = {}

controllers.MainController = function($scope, MyService) {
	unit();

	function unit() {
		var person = {
			firstName: 'Bozhidar',
			lastName: 'Penchev',
			goingTo: 'http://google.com'
		}

		$scope.person = person
		$scope.message = "Hello Angular!"
		$scope.users = MyService.getCustomers();


		
	}
};

app.controller(controllers);