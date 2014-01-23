var controls;
(function (controls) {
    var GridItem = (function () {
        function GridItem(values) {
            this.__gridItemValues = values;
        }
        Object.defineProperty(GridItem.prototype, "Values", {
            get: function () {
                return this.__gridItemValues;
            },
            enumerable: true,
            configurable: true
        });
        return GridItem;
    })();

    function createGridItem(values) {
        var item = new GridItem(values);
        return item;
    }
    controls.createGridItem = createGridItem;
})(controls || (controls = {}));
//# sourceMappingURL=gridItem.js.map
