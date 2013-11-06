/// <reference path="httpRequester.js" />
/// <reference path="httpRequester.js" />


define(["httpRequester"], function (httpRequester) {
    var ui = (function () {
        function getLoginUI() {
            return httpRequester.httpGet("Scripts/templates/login.html")
        }

        function getRegisterUI() {
            return httpRequester.httpGet("Scripts/templates/register.html")
        }

        function getGameUI() {
            return httpRequester.httpGet("Scripts/templates/game.html")
        }

        function getScoreTemplate() {
            return httpRequester.httpGet("Scripts/templates/score-template.html")
        }

        function getOpenGamesTemplate() {
            return httpRequester.httpGet("Scripts/templates/open-games-template.html")
        }

        function getMyActiveGamesTemplate() {
            return httpRequester.httpGet("Scripts/templates/my-active-template.html")
        }
        
        return {
            getLoginUI: getLoginUI,
            getRegisterUI: getRegisterUI,
            getGameUI: getGameUI,
            getScoreTemplate: getScoreTemplate,
            getOpenGamesTemplate: getOpenGamesTemplate,
            getMyActiveGamesTemplate: getMyActiveGamesTemplate
        }
    }());

    return ui;
});