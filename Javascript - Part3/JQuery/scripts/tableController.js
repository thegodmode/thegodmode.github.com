var TableController = (function($) {
    'use strict';

    var Table = {

        init: function(selector) {
            this.container = $(selector);
            this.students = [];
        },
        addStudents: function(data) {
            for (var i = 0; i < data.length; i++) {
                var student = Object.create(Student);
                student._init(data[i].fName, data[i].sName, data[i].grade);
                this.students.push(student);
            }
            ;
        },
        buildTable: function() {
            var table = document.createElement('table');
            table.appendChild(this._buildTableHeader());
            for (var i = 0; i < this.students.length; i++) {
                table.appendChild(this.students[i]._serialize());
            }
            this.container.append(table);
        },
        _buildTableHeader: function() {
            var fragment = document.createDocumentFragment();
            var tr = document.createElement('tr');
            var fNameElement = document.createElement('th');
            fNameElement.innerHTML = 'First name';
            var sNameElement = document.createElement('th');
            sNameElement.innerHTML = 'Last name';
            var gradeElement = document.createElement('th');
            gradeElement.innerHTML = 'grade';
            fragment.appendChild(tr);
            tr.appendChild(fNameElement);
            tr.appendChild(sNameElement)
            tr.appendChild(gradeElement)
            return fragment;
        }

    }

    var Student = {

        _init: function(fName, sName, grade) {
            this.fName = fName;
            this.sName = sName;
            this.grade = grade;
        },
        _serialize: function() {
            var tr = document.createElement('tr');
            var fNameElement = document.createElement('td');
            fNameElement.innerHTML = this.fName;
            var sNameElement = document.createElement('td');
            sNameElement.innerHTML = this.sName;
            var gradeElement = document.createElement('td');
            gradeElement.innerHTML = this.grade;
            tr.appendChild(fNameElement);
            tr.appendChild(sNameElement);
            tr.appendChild(gradeElement);
            return tr;
        }
    }

    return {

        getNewTable: function(selector) {
            var table = Object.create(Table);
            table.init(selector);
            return table;
        }

    }
}(jQuery));

$(document).ready(function() {
    var data = [

        {
            fName: "Pesho",
            sName: "Mentata",
            grade: 4
        },{
            fName: "Kiro",
            sName: "Vodkata",
            grade: 7
        },{
            fName: "Kaval",
            sName: "Zavarchik",
            grade: 12
        }, {

            fName: "Bai",
            sName: "Hoi",
            grade: 7
        }
    ]

    var table = TableController.getNewTable('#table');
    table.addStudents(data);
    table.buildTable();
});