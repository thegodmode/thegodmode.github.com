/// <reference path="libs/_references.js" />
(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');
    var data = dataPersister.getDataPersister("http://carshowroom.apphb.com/api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/login", function () {
        if (!data.users.isLoggedIn()) {
            viewsFactory.getLoginView().then(function (loginHtml) {

                var loginModel = vmFactory.getLoginViewModel(function () {
                    router.navigate("/");
                });

                var view = new kendo.View(loginHtml, { model: loginModel });
                appLayout.showIn("#main-content", view);
                $("#tabstrip").kendoTabStrip({
                    animation: {
                        open: {
                            effects: "fadeIn"
                        }
                    }
                });
            });
        }
        else {
            router.navigate("/");
        }
    });

    router.route("/", function () {
        if (data.users.isLoggedIn()) {
            viewsFactory.getHomeView().then(function (homeHtml) {
                vmFactory.getHomeViewModel()
                    .then(function (vm) {                        
                        var view = new kendo.View(homeHtml, { model: vm });
                        appLayout.showIn("#main-content", view);
                                                
                        var offersDS = vm.get("offers");                        

                        $("#pager").kendoPager({
                            dataSource: offersDS
                        });

                        $("#listView").kendoListView({
                            dataSource: offersDS,
                            template: kendo.template($("#template").html())
                        });
                    });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    router.route("/offers/:id", function (id) {
        if (data.users.isLoggedIn()) {
            viewsFactory.getOfferView().then(function (offerHtml) {
                vmFactory.getOfferByIdViewModel(id).then(function (offerModel) {
                    var view = new kendo.View(offerHtml, { model: offerModel });
                    appLayout.showIn("#main-content", view);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });


    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());