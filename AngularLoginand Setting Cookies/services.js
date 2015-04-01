var services = services || {}


services.myService = function ($http, $q, URLS) {

    this.doLogin = function (username, password) {

        var req = {
            method: 'POST',
            url: URLS.login,
            headers: {
                'Authorization': undefined
            },
            data: {

                username: username,  //"test_user",
                password: password   //"123"
            }
        }

        var deferred = $q.defer();

        $http(req).success(function (data, status) {

            $http.defaults.headers.common.Authorization = "Bearer " + data.access_token;
            $http.defaults.headers.common.ContentType = "application/x-www-form-urlencoded";

            var date = new Date()
            date.setSeconds(data.expires_in)

            $.cookie('token', data.access_token, { expires: date });

            deferred.resolve(data)

        }).error(function (data, status) {

            deferred.reject(data);
        });

        return deferred.promise;
    },

    this.doRequest = function () {

        var req = {
            method: 'GET',
            url: URLS.doRequest
        }

        var deferred = $q.defer();

        $http(req).success(function (data) {

            deferred.resolve(data)

        }).error(function (data, status) {

            deferred.reject({
                data: data,
                status: status
            })

        })

        return deferred.promise

    }

}

app.service(services);