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
            controls: "data/Controls",
            application: "data/Application"
        }
    });

    require(["jquery", "application"], function ($, application) {
        $(function () {
            application.startApplication("comboBox", "http://localhost:26116/api/");
        });
    });
}());