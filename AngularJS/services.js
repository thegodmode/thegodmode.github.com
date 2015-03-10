 var services = services || {}


 services.myService =  function() {
 	
 	this.getCustomers = function() {
 		var customers = [{
 			name: "Tohn",
 			city: 'Lovech'
 		}, {
 			name: "Aose",
 			city: 'Pleven'
 		}, {
 			name: "Borka",
 			city: 'Tihyana'
 		}];

 		return customers;
 	}
 }

 app.service(services);