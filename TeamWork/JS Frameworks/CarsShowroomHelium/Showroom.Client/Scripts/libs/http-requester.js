
var httpRequester = (function () {
	function getJSON(serviceUrl, headers) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			$.ajax({
				url: serviceUrl,
				type: "GET",
                headers: headers,
				dataType: "json",
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err);
				}
			});
		});
		return promise;
	}

	function postJSON(serviceUrl, data, headers) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			$.ajax({
				url: serviceUrl,
				dataType: "json",
				type: "POST",
				contentType: "application/json",
                headers: headers,
				data: JSON.stringify(data),
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err);
				}
			});
		});
		return promise;
	}

	function putJSON(serviceUrl, data, headers) {
	    var promise = new RSVP.Promise(function (resolve, reject) {
	        $.ajax({
	            url: serviceUrl,
	            dataType: "json",
	            type: "PUT",
	            contentType: "application/json",
                headers: headers,
	            data: JSON.stringify(data),
	            success: function (data) {
	                resolve(data);
	            },
	            error: function (err) {
	                reject(err);
	            }
	        });
	    });
	    return promise;
	}

	return {
		getJSON: getJSON,
		postJSON: postJSON,
        putJSON: putJSON
	}
}());