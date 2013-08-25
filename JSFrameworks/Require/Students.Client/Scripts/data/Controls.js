/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/q.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="DataPersister.js" />

define(["class", "dataPersister"], function (Class, dataPersister) {
    var MainControl = Class.create({

        init: function (studentsMainContainer, baseUrl) {
            var persister = dataPersister.getDataPersister(baseUrl);
            var container = document.getElementById(studentsMainContainer);
            this.studentsControl = new StudentsControl(container, persister.studentsPersister)
        }

    });

    var StudentsControl = Class.create({

        init: function (container, studentsPersister) {
            this.container = container;
            this.studentsPersister = studentsPersister
        },
        renderStudentsInfo: function (template) {
            selfContainer = this.container;
            this.studentsPersister.getAll().then(function (studentsData) {
                var studentsinfo = document.createElement("div");
                studentsinfo.id = "student-info";
                var header = document.createElement("span");
                header.innerText = "Students List";
                selfContainer.appendChild(studentsinfo);
                studentsinfo.appendChild(header);
                var list = document.createElement("ul");
                studentsinfo.appendChild(list);
                for (var i = 0; i < studentsData.length; i++) {
                    var item = studentsData[i];
                    var li = document.createElement("li");
                    li.innerHTML = template(item);
                    list.appendChild(li);
                }

            }).done();
          
            return this;
        },
        renderStudentMarks: function (template, studentId) {
            selfContainer = this.container;
            this.studentsPersister.getMarksById(studentId).then(function (marks) {
                var studentsinfo = document.createElement("div");
                studentsinfo.id = "student-marks";
                selfContainer.appendChild(studentsinfo);
                var list = document.createElement("ul");
                studentsinfo.appendChild(list);
                for (var i = 0; i < marks.length; i++) {
                    var mark = marks[i];
                    var li = document.createElement("li");
                    li.innerHTML = template(mark);
                    list.appendChild(li);
                }
            });

            return this;
        }

    });

    return {

        getControls: function (studentsMainContainer,baseUrl) {
            return new MainControl(studentsMainContainer,baseUrl)
        }
    }
});