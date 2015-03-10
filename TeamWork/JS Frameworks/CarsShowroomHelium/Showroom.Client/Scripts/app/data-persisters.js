/// <reference path="../libs/_references.js" />

window.dataPersister = (function () {
    var sessionKey = localStorage.getItem("sessionKey");
    var username = localStorage.getItem("username");

    function saveToLocalStorage(session, user) {
        localStorage.setItem("sessionKey", session);
        localStorage.setItem("username", user);
        sessionKey = session;
        username = user;
    }

    function clearLocalStorage() {
        localStorage.clear();
        sessionKey = null;
        username = null;
    }

    var MainPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UserPersister(this.apiUrl + "users/");
            this.offers = new OffersPersister(this.apiUrl + "offers/");
            this.brands = new BrandsPersister(this.apiUrl + "brands/");
        }
    });

    var UserPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        isLoggedIn: function () {
            if (sessionKey != null) {
                return true;
            }
            else {
                return false;
            }
        },
        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            }

            return httpRequester.postJSON(this.serviceUrl + "login", user)
            .then(function (data) {
                saveToLocalStorage(data.sessionKey, data.username);
            });
        },
        register: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            }

            return httpRequester.postJSON(this.serviceUrl + "register", user)
            .then(function (data) {
                saveToLocalStorage(data.sessionKey, data.username);
            });
        },
        logout: function () {
            if (!sessionKey) {
                throw new Error("Invalid authentication");
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.putJSON(this.serviceUrl + "logout", headers)
            .then(function () {
                clearLocalStorage();
            });
        },
        profile: function () {
            if (!sessionKey) {
                throw new Error("Invalid authentication");
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(this.serviceUrl + "profile", headers);
        }
    });

    var OffersPersister = Class.create({
        init: function (url) {
            this.serviceUrl = url;
        },
        getAll: function () {
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(this.serviceUrl, headers);
        },
        getOfferById: function (id) {
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(this.serviceUrl + id, headers);
        }
    });

    var BrandsPersister = Class.create({
        init: function (url) {
            this.serviceUrl = url;
        },
        getById: function (id) {
            var headers = {
                "X-sessionKey": sessionKey
            };

            return httpRequester.getJSON(this.serviceUrl + id, headers);
        }
    });

    return {
        getDataPersister: function (url) {
            return new MainPersister(url);
        }
    }
}());