window.vmFactory = (function () {
    var dataPersister = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "",
            password: "",
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            }
        };
        return kendo.observable(viewModel);
    };

    function getHomeViewModel() {
        return data.offers.getAll()
            .then(function (offers) {
                var dataSource = new kendo.data.DataSource({
                    data: offers
                });

                debugger;

                var viewModel = {
                    offers: dataSource
                }

                return kendo.observable(viewModel);
            })
    };

    function getOfferByIdViewModel(id) {
        return data.offers.getOfferById(id).then(function (offer) {
            console.log(data.brands.getById(offer.car.brand));
            var viewModel = {
                offer: offer,
                carBrand: data.brands.getById(offer.car.brand).then(function (brandName) {
                    console.log(brandName);
                    return brandName;
                })
            }

            return kendo.observable(viewModel);
        });
    }

    return {
        getLoginViewModel: getLoginViewModel,
        getHomeViewModel: getHomeViewModel,
        getOfferByIdViewModel:getOfferByIdViewModel,
        setPersister: function (persister) {
            data = persister
        }
    }
}());