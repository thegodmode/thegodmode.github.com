var services = services || {}


services.RaceService = function ($http, $q, URLS) {

    this.getAllRaces = function () {

        var req = {
            method: 'GET',
            url: URLS.AllRace,
            headers: {
                'Authorization': undefined
            }
        }

        var deferred = $q.defer();

        $http(req).success(function (data, status) {

            deferred.resolve(data)

        }).error(function (data, status) {

            deferred.reject(data);
        });

        return deferred.promise;
    }

}

app.service(services);