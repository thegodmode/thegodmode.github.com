﻿/// <reference path="jquery-2.0.2.js" />
/// <reference path="q.js" />

define(["jquery", "que"], function ($, Q) {
    var httpRequester = (function () {
        var makeHttpRequest = function (url, type, data) {
            var deferred = Q.defer();

            var stringifiedData = "";
            if (data) {
                stringifiedData = JSON.stringify(data);
            }

            $.ajax({
                url: url,
                type: type,
                contentType: "application/json",
                data: stringifiedData,
                success: function (result) {
                    deferred.resolve(result);
                },

                error: function (errorData) {
                    deferred.reject(errorData);
                }
            })

            return deferred.promise;
        }

        var makeHttpGetRequest = function (url) {
            return makeHttpRequest(url, "get")
        }

        var makeHttpPostRequest = function (url, data) {
            return makeHttpRequest(url, "post", data)
        }

        var makeHttpPutRequest = function (url, data) {
            return makeHttpRequest(url, "put", data)
        }

        return {
            httpPost: makeHttpPostRequest,
            httpGet: makeHttpGetRequest,
            httpPut: makeHttpPutRequest
        }
    }());

    return httpRequester;
});