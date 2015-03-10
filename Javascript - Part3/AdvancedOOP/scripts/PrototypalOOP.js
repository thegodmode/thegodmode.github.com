// add Shim for create  and extend Object
(function() {
	'use strict';
	if (!Object.create) {
		Object.create = function(obj) {
			function Fun() {}
			Fun.prototype = obj;
			return new Fun();
		};
	}

	if (!Object.prototype.extend) {
		Object.prototype.extend = function(properties) {
			function Fun() {};
			Fun.prototype = Object.create(this);
			for (var prop in properties) {
				Fun.prototype[prop] = properties[prop];
			}
			Fun.prototype._super = this;
			return new Fun();
		}
	}
}());

var schoolRepository = (function() {
	'use strict';

	// base class
	var Person = {
        
		unit: function(fName, lName, age) {

			this.fName = fName;
			this.lName = lName;
			this.age = age;
		},

		introduce: function() {

			return "Name: " + this.fName + " " + this.lName + ", Age:" + this.age;
		}
	}

	// student class
	var Student = Person.extend({
		unit: function(fname, lname, age, grade) {
			this._super = Object.create(this._super);
			this._super.unit(fname, lname, age);
			this.grade = grade;
		},
		introduce: function() {
			return "  -Student introducement - " + this._super.introduce() + ", Grade: " + this.grade;
		}
	});

	// teacher class
	var Teacher = Person.extend({
		unit: function(fname, lname, age, speciality) {
			this._super = Object.create(this._super);
			this._super.unit(fname, lname, age);
			this.speciality = speciality;
		},
		introduce: function() {
			return "Teacher intraducement - " + this._super.introduce() + ", Speciality: " + this.speciality;
		}

	});

	// Course class
	var Course = {

		unit: function(courseName, students, teacher) {
			this.students = students;
			this.teacher = teacher;
			this.courseName = courseName;
		},
		introduce: function() {
			console.log(" -Course: " + this.courseName + ", Teacher: " + this.teacher.introduce() + ", \n -Students:");
			for (var i = 0; i < this.students.length; i++) {
				console.log(this.students[i].introduce());
			};
		}
	}

	// School class
	var School = {
		unit: function(schoolName, town, schoolCourses) {
			this.schoolName = schoolName;
			this.town = town;
			this.schoolCourses = schoolCourses;
		},
		introduce: function() {
			console.log("School: " + this.schoolName + ", Town: " + this.town + ", \nClasses: ");
			if (this.schoolCourses == null) {
				console.log("Empty");
			} else {
				for (var i = 0; i < this.schoolCourses.length; i++) {
					this.schoolCourses[i].introduce();
				};
			}
		},
		addCourse: function(course) {
			this.schoolCourses.push(course);
		},
	}

	return {

		createStudent: function(fname, lname, age, grade) {
			var student = Object.create(Student);
			student.unit(fname, lname, age, grade);
			return student;
		},
		createTeacher: function(fname, lname, age, speciality) {
			var teacher = Object.create(Teacher);
			teacher.unit(fname, lname, age, speciality);
			return teacher;
		},
		createCourse: function(courseName, students, teacher) {
			var course = Object.create(Course);
			course.unit(courseName, students, teacher);
			return course;
		},
		createSchool: function(schoolName, town, schoolCourses) {
			var school = Object.create(School);
			school.unit(schoolName, town, schoolCourses);
			return school;
		}
	}
}());



// unit students
var joro = schoolRepository.createStudent("Joro", "Mentata", "3", "1");
var pesho = schoolRepository.createStudent("Pesho", "Mentata", "3", "7");
var danu = schoolRepository.createStudent("Danu", "Mentata", "4", "8");
var kasu = schoolRepository.createStudent("Kasu", "Mentata", "5", "9");
students = [joro, pesho, danu, kasu];

//unit teacher
var nakov = schoolRepository.createTeacher("Svetlin", "Nakov", "32", "Technical Trainer");

// unit course
var jsOOP = schoolRepository.createCourse("jsOOP", students, nakov)
var courses = [jsOOP];

//unit School
var telerikAcedemy = schoolRepository.createSchool("telerikAcedemy", "Sofia", courses)
telerikAcedemy.introduce();