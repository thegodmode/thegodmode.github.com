window.viewsFactory = (function () {
    var url = "Partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: url + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getHomeView() {
        return getTemplate("home-partial");
    }

    function getOfferView() {
        return getTemplate("offer-partial");
    }

    return {
        getLoginView: getLoginView,
        getHomeView: getHomeView,
        getOfferView: getOfferView
    }
}());