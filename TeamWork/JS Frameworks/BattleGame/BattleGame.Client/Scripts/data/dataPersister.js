/// <reference path="httpRequester.js" />
/// <reference path="httpRequester.js" />
/// <reference path="../libs/class.js" />


define(["httpRequester", "class", "sha"], function (httpRequester, Class, CryptoJS) {
    var dataPersister = (function () {
        var MainDataPersister = Class.create({
            
            init: function (baseUrl) {
                this.loginPersister = new LoginPersister(baseUrl + 'user/')
                this.gamePersister = new GamePersister(baseUrl + 'game/')
            },
            isUserLoggin: function () {
                var nickname = localStorage.getItem("nickname");
                if (nickname) {
                    return true;
                }
                else {
                    return false;
                }
            }

        });

        var LoginPersister = Class.create({

            init: function (url) {
                this.baseUrl = url
            },
            register: function (user) {
                var userData = {
                    username:user.username,
                    nickname:user.nickname,
                    authCode:CryptoJS.SHA1(user.username + user.password).toString()
                }
                return httpRequester.httpPost(this.baseUrl + 'register', userData);
            },
            login: function (user) {
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                }
                return httpRequester.httpPost(this.baseUrl + 'login', userData);
            },
            logout: function (sessionKey) {
                return httpRequester.httpPut(this.baseUrl + 'logout/' + sessionKey,null);
            },
            score: function (sessionKey) {
                return httpRequester.httpGet(this.baseUrl + 'scores/' + sessionKey);
            }

        });

        var GamePersister = Class.create({

            init: function (url) {
                this.baseUrl = url
            },
            create: function (game, sessionKey) {
                var gameData = {

                    title: game.title,
                }
                return httpRequester.httpPost(this.baseUrl + 'create/' + sessionKey, gameData);
            },
            join: function (game, sessionKey) {
                var gameData = {

                    id: game.id,
                }
                return httpRequester.httpPost(this.baseUrl + 'join/' + sessionKey, gameData);
            },
            start: function (gameId, sessionKey) {
                return httpRequester.httpPut(this.baseUrl + gameId + '/start/' + sessionKey, null);
            },
            active: function (sessionKey) {
                return httpRequester.httpGet(this.baseUrl + '/my-active/' + sessionKey);
            },
            open: function (sessionKey) {
                return httpRequester.httpGet(this.baseUrl + '/open/' + sessionKey);
            },
            field: function (gameId, sessionKey) {
                return httpRequester.httpGet(this.baseUrl + gameId + '/field/' + sessionKey);
            },

        });

        return {
            get: function (baseUrl) {
                return new MainDataPersister(baseUrl);
            }
        }
    }());
    return dataPersister;
});