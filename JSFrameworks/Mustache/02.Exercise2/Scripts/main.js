/// <reference path="tableView.js" />
/// <reference path="school.js" />
/// <reference path="httpRequester.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="jquery-2.0.3.intellisense.js" />

$(document).ready(function () {
    function RegisterEvents() {
        $("#content").on("click", ".mark", function () {
            if ($(this).next().is("ul")) {
                $(this).next().remove();
                $(this).text("Show Marks");
                return;
            }

            var id = $(this).parent().attr("id");
            var self = $(this);
            HttpRequester.getJson("http://localhost:26116/api/students/" + id, function (marks) {
                var marksTemplate = Mustache.compile(document.getElementById("marks").innerHTML);

                var tableView = controls.getTableView(marks, 1);
                var createdMarks = tableView.getMarksView(marksTemplate);
                self.parent().append(createdMarks);
                self.text("Hide Marks");
            }, function (err) {
                console.log(err);
            })
        });
    }

    HttpRequester.getJson("http://localhost:26116/api/students", function (people) {
        var personTemplate = Mustache.compile(document.getElementById("person-template").innerHTML);

        var tableView = controls.getTableView(people, 1);
        var createdTableHtml = tableView.createTableView(personTemplate);
        document.getElementById("content").appendChild(createdTableHtml);
    }, function (err) {
        console.log(err);
    })

    RegisterEvents();
});