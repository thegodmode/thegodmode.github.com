var controls;
(function (controls) {
    var RowType;
    (function (RowType) {
        RowType[RowType["header"] = 0] = "header";
        RowType[RowType["row"] = 1] = "row";
    })(RowType || (RowType = {}));

    var GridView = (function () {
        function GridView(tableParentId, tableWidth) {
            this.tableWidth = tableWidth;
            this.__parent = document.getElementById(tableParentId);
            this.__tableWidth = tableWidth;
            this.__rows = [];
        }
        GridView.prototype.addHeader = function () {
            var values = [];
            for (var _i = 0; _i < (arguments.length - 0); _i++) {
                values[_i] = arguments[_i + 0];
            }
            if (values.length != this.__tableWidth) {
                throw "Invalid Header. It must have the same length as gridview";
            }

            this.__header = controls.createGridItem(values);
        };

        GridView.prototype.addRow = function () {
            var values = [];
            for (var _i = 0; _i < (arguments.length - 0); _i++) {
                values[_i] = arguments[_i + 0];
            }
            if (values.length != this.__tableWidth) {
                throw "Invalid Row. It must have the same length as gridview";
            }

            this.__rows.push(controls.createGridItem(values));
        };

        GridView.prototype.render = function () {
            var _this = this;
            var table = document.createElement("table");
            table.appendChild(this.createRow(0 /* header */, this.__header.Values));
            this.__rows.forEach(function (element) {
                table.appendChild(_this.createRow(1 /* row */, element.Values));
            });

            if (this.__parent.hasChildNodes) {
                while (this.__parent.firstChild) {
                    this.__parent.removeChild(this.__parent.firstChild);
                }
            }

            this.__parent.appendChild(table);
        };

        GridView.prototype.createRow = function (rowType, values) {
            var parent = null;

            if (rowType == 0 /* header */) {
                parent = document.createElement("th");
            } else if (rowType == 1 /* row */) {
                parent = document.createElement("tr");
            }

            values.forEach(function (element) {
                var td = document.createElement("td");
                td.textContent = element;
                parent.appendChild(td);
            });

            return parent;
        };
        return GridView;
    })();

    function getGridView(tableParentId, tableWidth) {
        return new GridView(tableParentId, tableWidth);
    }
    controls.getGridView = getGridView;
})(controls || (controls = {}));
//# sourceMappingURL=gridview.js.map
