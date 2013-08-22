/// <reference path="class.js" />

var controls = controls || {};

(function (controls) {
    var TableView = Class.create({

        init: function (itemsToRender, cols) {
            if (cols == 0) {
                throw "Invalid Arguments cols";
            }

            if (itemsToRender == null) {
                throw "itemsToRender cannot be null";
            }

            if (!(itemsToRender instanceof Array)) {
                throw "itemsToRendermust be instance of Array";
            }
            
            this.sourceItems = itemsToRender;
            this.cols = cols;
        },
        createTableView: function (template) {
            var table = document.createElement("table");
            var fragment = document.createDocumentFragment();
            fragment.appendChild(table);

            if (this.sourceItems instanceof Array) {
                var tr = document.createElement("tr");

                // interate each sourceitem
                for (var index = 0; index < this.sourceItems.length; index++) {
                    if (index % this.cols == 0 && index != 0) {
                        table.appendChild(tr);
                        tr = document.createElement("tr");
                    }

                    var td = document.createElement("td");
                    td.id = index;
                    var item = this.sourceItems[index];
                    td.innerHTML = template(item);
                    tr.appendChild(td);
                }

                // check last tr if has children
                if (tr.hasChildNodes) {
                    table.appendChild(tr)
                }
            }
            
            return fragment;
        },

        getMarksView: function (template) {
            var list = document.createElement("ul");
            for (var index = 0; index < this.sourceItems.length; index++) {
                var item = this.sourceItems[index];
                var markInHtml = template(item);
                list.innerHTML += markInHtml;
            }

            return list
        }


       
    });
    
    controls.getTableView = function (itemsToRender, cols) {
        return new TableView(itemsToRender, cols);
    }
}(controls));