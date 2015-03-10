/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../data/Application.js" />
(function () {
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3.min",
            que: "libs/q",
            "class": "libs/class",
            mustache: "libs/mustache",
            httpRequester: "data/httpRequester",
            dataPersister: "data/DataPersister",
            controller: "data/controller",
            sha: "libs/sha1",
            ui: "data/ui",
            sammy: "libs/sammy-0.7.4",
            underscore: "libs/underscore.min"
        }
    });

    require(["jquery", "controller","sammy"], function ($, controller, sammy) {
        var app = sammy(function () {
            var gameController = controller.get("#container", "http://localhost:22954/api/");
            gameController.registerEvents();
            
            this.get("#/home", function () {
                $(function () {
                    gameController.loadUI();
                });
            });

            this.get("#/register", function () {
                gameController.loadRegisterUI();
            });

            this.get("#/game", function () {
                gameController.loadGameUI();
            });
        });

        app.run("#/home");
    });
}());