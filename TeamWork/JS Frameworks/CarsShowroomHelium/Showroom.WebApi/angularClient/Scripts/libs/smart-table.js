﻿!function (a, b) { "use strict"; function c(a, c) { function d(a) { return this instanceof d ? (b.extend(this, a), void 0) : new d(a) } this.setDefaultOption = function (a) { b.extend(d.prototype, a) }, a.headerTemplateUrl = c.defaultHeader, this.setDefaultOption(a), this.$get = function () { return d } } var d = b.module("smartTable.column", ["smartTable.templateUrlList"]).constant("DefaultColumnConfiguration", { isSortable: !0, isEditable: !1, type: "text", headerTemplateUrl: "", map: "", label: "", sortPredicate: "", formatFunction: "", formatParameter: "", filterPredicate: "", cellTemplateUrl: "", headerClass: "", cellClass: "" }); c.$inject = ["DefaultColumnConfiguration", "templateUrlList"], d.provider("Column", c), a.ColumnProvider = c }(window, angular), function (a) { "use strict"; a.module("smartTable.directives", ["smartTable.templateUrlList", "smartTable.templates"]).directive("smartTable", ["templateUrlList", "DefaultTableConfiguration", function (b, c) { return { restrict: "EA", scope: { columnCollection: "=columns", dataCollection: "=rows", config: "=" }, replace: "true", templateUrl: b.smartTable, controller: "TableCtrl", link: function (d, e, f, g) { var h; d.$watch("config", function (e) { var f = a.extend({}, c, e), h = void 0 !== d.columns ? d.columns.length : 0; if (g.setGlobalConfig(f), "multiple" !== f.selectionMode || f.displaySelectionCheckbox !== !0) for (var i = h - 1; i >= 0; i--) d.columns[i].isSelectionColumn === !0 && g.removeColumn(i); else g.insertColumn({ cellTemplateUrl: b.selectionCheckbox, headerTemplateUrl: b.selectAllCheckbox, isSelectionColumn: !0 }, 0) }, !0), d.$watch("columnCollection", function () { if (d.columnCollection) for (var b = 0, c = d.columnCollection.length; c > b; b++) g.insertColumn(d.columnCollection[b]); else d.dataCollection && d.dataCollection.length > 0 && (h = d.dataCollection[0], a.forEach(h, function (a, b) { "$" != b[0] && g.insertColumn({ label: b, map: b }) })) }, !0), d.$watch("dataCollection.length", function (a, b) { a !== b && g.sortBy() }) } } }]).directive("smartTableDataRow", function () { return { require: "^smartTable", restrict: "C", link: function (a, b, c, d) { b.bind("click", function () { a.$apply(function () { d.toggleSelection(a.dataRow) }) }) } } }).directive("smartTableHeaderCell", function () { return { restrict: "C", require: "^smartTable", link: function (a, b, c, d) { b.bind("click", function () { a.$apply(function () { d.sortBy(a.column) }) }) } } }).directive("smartTableSelectAll", function () { return { restrict: "C", require: "^smartTable", link: function (a, b, c, d) { b.bind("click", function () { d.toggleSelectionAll(b[0].checked === !0) }) } } }).directive("stopEvent", function () { return { restrict: "A", link: function (a, b, c) { b.bind(c.stopEvent, function (a) { a.stopPropagation() }) } } }).directive("smartTableGlobalSearch", ["templateUrlList", function (a) { return { restrict: "C", require: "^smartTable", scope: { columnSpan: "@" }, templateUrl: a.smartTableGlobalSearch, replace: !1, link: function (a, b, c, d) { a.searchValue = "", a.$watch("searchValue", function (a) { d.search(a) }) } } }]).directive("smartTableDataCell", ["$filter", "$http", "$templateCache", "$compile", "$parse", function (a, b, c, d, e) { return { restrict: "C", link: function (f, g) { function h() { j.isEditable ? (g.html('<div editable-cell="" row="dataRow" column="column" type="column.type"></div>'), d(g.contents())(f)) : g.text(f.formatedValue) } var i, j = f.column, k = f.dataRow, l = a("format"), m = e(j.map); f.formatedValue = l(m(k), j.formatFunction, j.formatParameter), f.$watch("column.cellTemplateUrl", function (a) { a ? b.get(a, { cache: c }).success(function (a) { i = f.$new(), g.html(a), d(g.contents())(i) }).error(h) : h() }) } } }]).directive("inputType", function () { return { restrict: "A", priority: 1, link: function (a, b, c) { var d = a.$eval(c.type); c.$set("type", d) } } }).directive("editableCell", ["templateUrlList", "$parse", function (b, c) { return { restrict: "EA", require: "^smartTable", templateUrl: b.editableCell, scope: { row: "=", column: "=", type: "=" }, replace: !0, link: function (b, d, e, f) { var g = a.element(d.children()[1]), h = a.element(g.children()[0]), i = c(b.column.map); b.isEditMode = !1, b.value = i(b.row), b.submit = function () { b.myForm.$valid === !0 && (f.updateDataRow(b.row, b.column.map, b.value), f.sortBy()), b.toggleEditMode() }, b.toggleEditMode = function () { b.value = i(b.row), b.isEditMode = b.isEditMode !== !0 }, b.$watch("isEditMode", function (a) { a && (h[0].select(), h[0].focus()) }), h.bind("blur", function () { b.$apply(function () { b.submit() }) }) } } }]) }(angular), function (a) { "use strict"; a.module("smartTable.filters", []).constant("DefaultFilters", ["currency", "date", "json", "lowercase", "number", "uppercase"]).filter("format", ["$filter", "DefaultFilters", function (b, c) { return function (d, e, f) { var g; return g = e && a.isFunction(e) ? e : -1 !== c.indexOf(e) ? b(e) : function (a) { return a }, g(d, f) } }]) }(angular), function (a) { "use strict"; a.module("smartTable.table", ["smartTable.column", "smartTable.utilities", "smartTable.directives", "smartTable.filters", "ui.bootstrap.pagination.smartTable"]).constant("DefaultTableConfiguration", { selectionMode: "none", isGlobalSearchActivated: !1, displaySelectionCheckbox: !1, isPaginationEnabled: !0, itemsByPage: 10, maxSize: 5, sortAlgorithm: "", filterAlgorithm: "" }).controller("TableCtrl", ["$scope", "Column", "$filter", "$parse", "ArrayUtility", "DefaultTableConfiguration", function (b, c, d, e, f, g) { function h() { var a, c = b.displayedCollection.length; for (a = 0; c > a; a++) if (b.displayedCollection[a].isSelected !== !0) return !1; return !0 } function i(c) { return a.isArray(c) ? 0 === c.length || b.itemsByPage < 1 ? 1 : Math.ceil(c.length / b.itemsByPage) : 1 } function j(c, e) { var g = (b.sortAlgorithm && a.isFunction(b.sortAlgorithm)) === !0 ? b.sortAlgorithm : d("orderBy"); return e ? f.sort(c, g, e.sortPredicate, e.reverse) : c } function k(c, d, e, f) { var g, i; if (a.isArray(c) && ("multiple" === d || "single" === d) && e >= 0 && e < c.length) { if (g = c[e], "single" === d) for (var j = 0, k = c.length; k > j; j++) i = c[j].isSelected, c[j].isSelected = !1, i === !0 && b.$emit("selectionChange", { item: c[j] }); g.isSelected = f, b.holder.isAllSelected = h(), b.$emit("selectionChange", { item: g }) } } b.columns = [], b.dataCollection = b.dataCollection || [], b.displayedCollection = [], b.numberOfPages = i(b.dataCollection), b.currentPage = 1, b.holder = { isAllSelected: !1 }; var l, m = {}; this.setGlobalConfig = function (c) { a.extend(b, g, c) }, this.changePage = function (c) { var d = b.currentPage; a.isNumber(c.page) && (b.currentPage = c.page, b.displayedCollection = this.pipe(b.dataCollection), b.holder.isAllSelected = h(), b.$emit("changePage", { oldValue: d, newValue: b.currentPage })) }, this.sortBy = function (a) { var c = b.columns.indexOf(a); -1 !== c && a.isSortable === !0 && (l && l !== a && (l.reverse = "none"), a.sortPredicate = a.sortPredicate || a.map, a.reverse = a.reverse !== !0, l = a), b.displayedCollection = this.pipe(b.dataCollection) }, this.search = function (a, c) { if (c && -1 !== b.columns.indexOf(c)) m.$ = "", c.filterPredicate = a; else { for (var d = 0, e = b.columns.length; e > d; d++) b.columns[d].filterPredicate = ""; m.$ = a } for (var d = 0, e = b.columns.length; e > d; d++) m[b.columns[d].map] = b.columns[d].filterPredicate; b.displayedCollection = this.pipe(b.dataCollection) }, this.pipe = function (c) { var e, g = (b.filterAlgorithm && a.isFunction(b.filterAlgorithm)) === !0 ? b.filterAlgorithm : d("filter"); return e = j(f.filter(c, g, m), l), b.numberOfPages = i(e), b.isPaginationEnabled ? f.fromTo(e, (b.currentPage - 1) * b.itemsByPage, b.itemsByPage) : e }, this.insertColumn = function (a, d) { var e = new c(a); f.insertAt(b.columns, d, e) }, this.removeColumn = function (a) { f.removeAt(b.columns, a) }, this.moveColumn = function (a, c) { f.moveAt(b.columns, a, c) }, this.toggleSelection = function (a) { var c = b.dataCollection.indexOf(a); -1 !== c && k(b.dataCollection, b.selectionMode, c, a.isSelected !== !0) }, this.toggleSelectionAll = function (a) { var c = 0, d = b.displayedCollection.length; if ("multiple" === b.selectionMode) for (; d > c; c++) k(b.displayedCollection, b.selectionMode, c, a === !0) }, this.removeDataRow = function (a) { var c = f.removeAt(b.displayedCollection, a); f.removeAt(b.dataCollection, b.dataCollection.indexOf(c)) }, this.moveDataRow = function (a, c) { f.moveAt(b.displayedCollection, a, c) }, this.updateDataRow = function (a, c, d) { var f, g = b.displayedCollection.indexOf(a), h = e(c), i = h.assign; -1 !== g && (f = h(b.displayedCollection[g]), f !== d && (i(b.displayedCollection[g], d), b.$emit("updateDataRow", { item: b.displayedCollection[g] }))) } }]) }(angular), angular.module("smartTable.templates", ["partials/defaultCell.html", "partials/defaultHeader.html", "partials/editableCell.html", "partials/globalSearchCell.html", "partials/pagination.html", "partials/selectAllCheckbox.html", "partials/selectionCheckbox.html", "partials/smartTable.html"]), angular.module("partials/defaultCell.html", []).run(["$templateCache", function (a) { a.put("partials/defaultCell.html", "{{formatedValue}}") }]), angular.module("partials/defaultHeader.html", []).run(["$templateCache", function (a) { a.put("partials/defaultHeader.html", "<span class=\"header-content\" ng-class=\"{'sort-ascent':column.reverse==true,'sort-descent':column.reverse==false}\">{{column.label}}</span>") }]), angular.module("partials/editableCell.html", []).run(["$templateCache", function (a) { a.put("partials/editableCell.html", '<div ng-dblclick="toggleEditMode($event)">\n <span ng-hide="isEditMode">{{value | format:column.formatFunction:column.formatParameter}}</span>\n\n <form ng-submit="submit()" ng-show="isEditMode" name="myForm">\n <input name="myInput" ng-model="value" type="type" input-type/>\n </form>\n</div>') }]), angular.module("partials/globalSearchCell.html", []).run(["$templateCache", function (a) { a.put("partials/globalSearchCell.html", '<label>Search :</label>\n<input type="text" ng-model="searchValue"/>') }]), angular.module("partials/pagination.html", []).run(["$templateCache", function (a) { a.put("partials/pagination.html", '<div class="pagination">\n <ul>\n <li ng-repeat="page in pages" ng-class="{active: page.active, disabled: page.disabled}"><a\n ng-click="selectPage(page.number)">{{page.text}}</a></li>\n </ul>\n</div> ') }]), angular.module("partials/selectAllCheckbox.html", []).run(["$templateCache", function (a) { a.put("partials/selectAllCheckbox.html", '<input class="smart-table-select-all" type="checkbox" ng-model="holder.isAllSelected"/>') }]), angular.module("partials/selectionCheckbox.html", []).run(["$templateCache", function (a) { a.put("partials/selectionCheckbox.html", '<input type="checkbox" ng-model="dataRow.isSelected" stop-event="click"/>') }]), angular.module("partials/smartTable.html", []).run(["$templateCache", function (a) { a.put("partials/smartTable.html", '<table class="smart-table">\n <thead>\n <tr class="smart-table-global-search-row" ng-show="isGlobalSearchActivated">\n <td class="smart-table-global-search" column-span="{{columns.length}}" colspan="{{columnSpan}}">\n </td>\n </tr>\n <tr class="smart-table-header-row">\n <th ng-repeat="column in columns" ng-include="column.headerTemplateUrl"\n class="smart-table-header-cell {{column.headerClass}}" scope="col">\n </th>\n </tr>\n </thead>\n <tbody>\n <tr ng-repeat="dataRow in displayedCollection" ng-class="{selected:dataRow.isSelected}"\n class="smart-table-data-row">\n <td ng-repeat="column in columns" class="smart-table-data-cell {{column.cellClass}}"></td>\n </tr>\n </tbody>\n <tfoot ng-show="isPaginationEnabled">\n <tr class="smart-table-footer-row">\n <td colspan="{{columns.length}}">\n <div pagination-smart-table="" num-pages="numberOfPages" max-size="maxSize" current-page="currentPage"></div>\n </td>\n </tr>\n </tfoot>\n</table>\n\n\n') }]), function (a) { "use strict"; a.module("smartTable.templateUrlList", []).constant("templateUrlList", { smartTable: "partials/smartTable.html", smartTableGlobalSearch: "partials/globalSearchCell.html", editableCell: "partials/editableCell.html", selectionCheckbox: "partials/selectionCheckbox.html", selectAllCheckbox: "partials/selectAllCheckbox.html", defaultHeader: "partials/defaultHeader.html", pagination: "partials/pagination.html" }) }(angular), function (a) { "use strict"; a.module("smartTable.utilities", []).factory("ArrayUtility", function () { var b = function (a, b) { return b >= 0 && b < a.length ? a.splice(b, 1)[0] : void 0 }, c = function (a, b, c) { b >= 0 && b < a.length ? a.splice(b, 0, c) : a.push(c) }, d = function (a, b, c) { var d; b >= 0 && b < a.length && c >= 0 && c < a.length && (d = a.splice(b, 1)[0], a.splice(c, 0, d)) }, e = function (b, c, d, e) { return c && a.isFunction(c) ? c(b, d, e === !0) : b }, f = function (b, c, d) { return c && a.isFunction(c) ? c(b, d) : b }, g = function (b, c, d) { var e, f, g = []; if (!a.isArray(b)) return b; f = Math.max(c, 0), f = Math.min(f, b.length - 1 > 0 ? b.length - 1 : 0), d = Math.max(0, d), e = Math.min(f + d, b.length); for (var h = f; e > h; h++) g.push(b[h]); return g }; return { removeAt: b, insertAt: c, moveAt: d, sort: e, filter: f, fromTo: g } }) }(angular), function (a) { a.module("ui.bootstrap.pagination.smartTable", ["smartTable.templateUrlList"]).constant("paginationConfig", { boundaryLinks: !1, directionLinks: !0, firstText: "First", previousText: "<", nextText: ">", lastText: "Last" }).directive("paginationSmartTable", ["paginationConfig", "templateUrlList", function (b, c) { return { restrict: "EA", require: "^smartTable", scope: { numPages: "=", currentPage: "=", maxSize: "=" }, templateUrl: c.pagination, replace: !0, link: function (c, d, e, f) { function g(a, b, c, d) { return { number: a, text: b, active: c, disabled: d } } var h = a.isDefined(e.boundaryLinks) ? c.$eval(e.boundaryLinks) : b.boundaryLinks, i = a.isDefined(e.directionLinks) ? c.$eval(e.directionLinks) : b.directionLinks, j = a.isDefined(e.firstText) ? e.firstText : b.firstText, k = a.isDefined(e.previousText) ? e.previousText : b.previousText, l = a.isDefined(e.nextText) ? e.nextText : b.nextText, m = a.isDefined(e.lastText) ? e.lastText : b.lastText; c.$watch("numPages + currentPage + maxSize", function () { c.pages = []; var a = 1, b = c.numPages; c.maxSize && c.maxSize < c.numPages && (a = Math.max(c.currentPage - Math.floor(c.maxSize / 2), 1), b = a + c.maxSize - 1, b > c.numPages && (b = c.numPages, a = b - c.maxSize + 1)); for (var d = a; b >= d; d++) { var e = g(d, d, c.isActive(d), !1); c.pages.push(e) } if (i) { var f = g(c.currentPage - 1, k, !1, c.noPrevious()); c.pages.unshift(f); var n = g(c.currentPage + 1, l, !1, c.noNext()); c.pages.push(n) } if (h) { var o = g(1, j, !1, c.noPrevious()); c.pages.unshift(o); var p = g(c.numPages, m, !1, c.noNext()); c.pages.push(p) } c.currentPage > c.numPages && c.selectPage(c.numPages) }), c.noPrevious = function () { return 1 === c.currentPage }, c.noNext = function () { return c.currentPage === c.numPages }, c.isActive = function (a) { return c.currentPage === a }, c.selectPage = function (a) { !c.isActive(a) && a > 0 && a <= c.numPages && (c.currentPage = a, f.changePage({ page: a })) } } } }]) }(angular);