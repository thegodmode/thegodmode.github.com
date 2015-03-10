var Class = (function() {
	function createClass(properties) {
		var f = function() {
			this.init.apply(this, arguments);
		}
		for (var prop in properties) {
			f.prototype[prop] = properties[prop];
		}
		if (!f.prototype.init) {
			f.prototype.init = function() {}
		}
		return f;
	}

	Function.prototype.inherit = function(parent) {
		var oldPrototype = this.prototype;
		var prototype = new parent();
		this.prototype = Object.create(prototype);
		this.prototype._super = prototype;
		for (var prop in oldPrototype) {
			this.prototype[prop] = oldPrototype[prop];
		}
	}

	return {
		create: createClass,
	};
}());



var schoolRepository = (function() {
	'use strict';

	// base class
	var Person = Class.create({

		init: function(fName, lName, age) {

			this.fName = fName;
			this.lName = lName;
			this.age = age;
		},

		introduce: function() {

			return "Name: " + this.fName + " " + this.lName + ", Age:" + this.age;
		}
	});

	// student class
	var Student = Class.create({
		init: function(fname, lname, age, grade) {
			this._super = Object.create(this._super);
			this._super.init(fname, lname, age);
			this.grade = grade;
		},
		introduce: function() {
			return "  -Student introducement - " + this._super.introduce() + ", Grade: " + this.grade;
		}
	});

	Student.inherit(Person);

	// teacher class
	var Teacher = Class.create({
		init: function(fname, lname, age, speciality) {
			this._super = Object.create(this._super);
			this._super.init(fname, lname, age);
			this.speciality = speciality;
		},
		introduce: function() {
			return "Teacher intraducement - " + this._super.introduce() + ", Speciality: " + this.speciality;
		}

	});

	Teacher.inherit(Person);

	// Course class
	var Course = Class.create({

		init: function(courseName, students, teacher) {
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
	})

	// School class
	var School = Class.create({
		init: function(schoolName, town, schoolCourses) {
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
	});

	return {

		createStudent: function(fname, lname, age, grade) {
			var student = new Student(fname, lname, age, grade);
			return student;
		},
		createTeacher: function(fname, lname, age, speciality) {
			var teacher = new Teacher(fname, lname, age, speciality);
			return teacher;
		},
		createCourse: function(courseName, students, teacher) {
			var course = new Course(courseName, students, teacher);
			return course;
		},
		createSchool: function(schoolName, town, schoolCourses) {
			var school = new School(schoolName, town, schoolCourses);
			return school;
		}
	}
}());



// unit students
var joro = schoolRepository.createStudent("Joro", "Mentata", "23", "12");
var pesho = schoolRepository.createStudent("Pesho", "Mentata", "13", "4");
var danu = schoolRepository.createStudent("Danu", "Mentata", "43", "6");
var kasu = schoolRepository.createStudent("Kasu", "Mentata", "33", "12");
students = [joro, pesho, danu, kasu];

//unit teacher
var nakov = schoolRepository.createTeacher("Svetlin", "Nakov", "32", "Technical Trainer");

// unit course
var jsOOP = schoolRepository.createCourse("jsOOP", students, nakov);
var courses = [jsOOP];

//unit School
var telerikAcedemy = schoolRepository.createSchool("telerikAcedemy", "Sofia", courses);
 telerikAcedemy.introduce();