 app.service("MyService", function() {
 	
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
 })