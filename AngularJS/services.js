 var services = services || {}


 services.myService = function($http) {
 	var url = "json.html";
 	


 	this.getCustomers = function() {
        
       
 		return $http.get(url);
 		
        
 	}
 }

 app.service(services);