/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="Controls.js" />
/// <reference path="DataPersister.js" />

define(["jquery", "controls", "mustache"], function ($, controls, Mustache) {
    function registerEvents(studentControl) {
        $("#comboBox").on("click", "#student-info span", function () {
            $(this).next().slideToggle('slow');
        });

        $("#comboBox").on("click", "#student-info li", function () {
            if ($('#student-marks') != undefined) {
                $('#student-marks').remove();
            }

            var id = $(this).children().first().attr("student-id");
            var text = $(this).children().first().children().first().text();

            var markTemplate = Mustache.compile(document.getElementById("mark-template").innerHTML);
            studentControl.renderStudentMarks(markTemplate, id);

            $('#student-info').children().first().text(text);
            $('#student-info ul').slideToggle('slow');
        });
    }

    function renderUI(studentsMainContainer, baseUrl) {
        var studentControl = controls.getControls(studentsMainContainer, baseUrl).studentsControl;
        var studentTemplate = Mustache.compile(document.getElementById("student-template").innerHTML);
        studentControl.renderStudentsInfo(studentTemplate);
        registerEvents(studentControl);
    }

    function startApplication(studentsMainContainer, baseUrl) {
        renderUI(studentsMainContainer, baseUrl);
    }

    return {

        startApplication: function (studentsMainContainer, baseUrl) {
            startApplication(studentsMainContainer, baseUrl);
        }
    }
});