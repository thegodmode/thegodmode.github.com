var controllers = controllers || {}

controllers.MainController = function ($scope, RaceService, URLS) {

    function init() {

        var race = $.connection.raceHub;
        race.client.changed = function () {

            GetAllRaces();
        };

        $.connection.hub.url = URLS.SignalR;
        $.connection.hub.start();
    }

    function GetAllRaces() {

        RaceService.getAllRaces().then(
          function (data) {

              $scope.raceEvents = data.RaceEvents
          },
          function (reason) {

              alert(reason);
          }

       )
    }

    init();
    GetAllRaces();
};

app.controller(controllers);