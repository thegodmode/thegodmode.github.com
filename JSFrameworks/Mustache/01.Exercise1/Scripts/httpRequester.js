var HttpRequester = (function () {
    var ajaxRequest =
    function (url, type, success, error, data) {
        if (data) {
            data = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            data: data,
            contentType: "application/json",
            success: function (responseData) {
                success(responseData);
            },
            error: function (errorData) {
                error(errorData);
            }
        });
    }

    var AjaxRequestGet = function (url, success, error) {
        ajaxRequest(url, "get", success, error);
    }

    var AjaxRequestPost = function (url, data, success, error) {
        ajaxRequest(url, "post", data, success, error);
    }

    return {
        getJson: AjaxRequestGet,
        postJson: AjaxRequestPost
    }
}());