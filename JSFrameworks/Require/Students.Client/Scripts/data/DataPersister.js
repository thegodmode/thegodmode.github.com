/// <reference path="httpRequester.js" />
/// <reference path="../libs/class.js" />

define(["httpRequester", "class"], function (httpRequester, Class) {
    var MainDataPersister = Class.create({

        init: function (baseUrl) {
            this.studentsPersister = new StudentsPersister(baseUrl + 'students')
        }

    });

    var StudentsPersister = Class.create({

        init: function (url) {
            this.baseUrl = url
        },
        getAll: function () {
            return httpRequester.httpGet(this.baseUrl);
        },
        getMarksById: function (studentId) {
            return httpRequester.httpGet(this.baseUrl + "/" + studentId + "/marks");
        }

    });

    return {
        getDataPersister: function (baseUrl) {
            return new MainDataPersister(baseUrl);
        }
    }
});