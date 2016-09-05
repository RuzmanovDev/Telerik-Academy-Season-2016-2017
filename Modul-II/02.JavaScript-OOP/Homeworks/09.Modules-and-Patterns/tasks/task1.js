/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    function _validateName(name) {
        let nameFirstLetter = name[0];
        if (nameFirstLetter !== nameFirstLetter.toUpperCase()) {
            throw new Error("The name must start with capital letter!");
        }

        for (let i = 1, len = name.length; i < len; i += 1) {
            if (name[i] !== name[i].toLowerCase()) {
                throw new Error("All letters in the name except the first one must be lowercase!")
            }
        }
    }

    function _validateTitle(title) {
        if (!title) {
            throw new Error("Please provide a title!");
        }

        let titleFirstLetter = title[0];
        let titleLastLetter = title[title.length - 1];

        if (titleLastLetter === " " || titleFirstLetter === " ") {
            throw new Error("The title must not start and end with space!");
        }

        if (title === "") {
            throw new Error("The title cannot be empty !");
        }

        let spaceCount = 0;
        for (let i = 0, len = title.length; i < len; i += 1) {
            if (title[i] === " ") {
                spaceCount += 1;
            } else {
                spaceCount = 0;
            }

            if (spaceCount >= 2) {
                throw new Error("The tittle cannot contain consecutive spaces!");
            }
        }


    }

    function _validateId(id, min, max) {
        if (!id) {
            throw  new Error("Invalid id!")
        }

        if (id < min) {
            throw  new Error("the id is less than the minimum");
        }

        if (id > max) {
            throw new Error("the id is greater than the max");
        }
    }

    function _presentationValidation(presentations) {
        if (!presentations || presentations.length === 0) {
            throw new Error("The presentations does not exist!");
        }

        presentations.forEach(function (element) {
            _validateTitle(element.title);
        })
    }

    function _createPresentations(titles) {
        var presnetations = [];
        if (titles.length === 0) {
            throw new Error("there are no titles");
        }
        titles.forEach(function (title) {
            _validateTitle(title);
            var presentation = new Presentation(title, "hw");
            presnetations.push(presentation);
        });

        return presnetations;
    }

    var id = 0;
    var _studentsById = {};

    class Presentation {
        constructor(title, homework) {
            this.title = title;
            this.homework = homework;
        }

        get title() {
            return this._title;
        }

        set title(value) {
            _validateTitle(value);
            this._title = value;
        }

    }

    class Student {
        constructor(firstname, lastname) {
            this.firstname = firstname;
            this.lastname = lastname;
            this._id = (id += 1);
        }

        get firstname() {
            return this._firstname;
        }

        set firstname(value) {
            _validateName(value);
            this._firstname = value;
        }

        get lastname() {
            return this._lastname;
        }

        set lastname(value) {
            _validateName(value);
            this._lastname = value;
        }


    }

    var Course = {
        init: function (title, presentations) {
            _validateTitle(title);
            this.title = title;
            this.presentations = _createPresentations(presentations);
            this.students = [];

            return this;
        },
        addStudent: function (name) {
            let names = name.split(" ");
            if (names.length > 2) {
                throw  new Error("The student can have only two names");
            }
            let fname = names[0];
            let lname = names[1];
            let student = new Student(fname, lname);

            let studentToAdd = {
                firstname: student.firstname,
                lastname: student.lastname,
                id: student.id
            };
            this.students.push(studentToAdd);
            _studentsById[student.id] = student;
            return student._id;
        },
        getAllStudents: function () {
            return this._students;
        },
        submitHomework: function (studentID, homeworkID) {
            _validateId(studentID, 1, this.students.length);
            _validateId(homeworkID, 1, this.presentations.length);

            var student  = _studentsById[studentID];
            var hws = this.presentations.length;


        },
        pushExamResults: function (results) {
        },
        getTopStudents: function () {
        }
    };

    return Course;
}


module.exports = solve;
var module = solve();
var validTitles = [
        'Modules and Patterns',
        'Ofcourse, this is a valid title!',
        'No errors hIr.',
        'Moar taitles',
        'Businessmen arrested for harassment of rockers',
        'Miners handed cabbages to the delight of children',
        'Dealer stole Moskvitch',
        'Shepherds huddle',
        'Retired Officers rally',
        'Moulds detonate tunnel',
        'sailors furious'
    ],
    validNames = [
        'Pesho',
        'Notaname',
        'Johny',
        'Marulq',
        'Keremidena',
        'Samomidena',
        'Medlar',
        'Yglomer',
        'Elegant',
        'Analogical',
        'Bolsheviks',
        'Reddish',
        'Arbitrage',
        'Toyed',
        'Willfully',
        'Transcribing'
    ];

// validTitles.forEach(function (element) {
//     var course = module.init(element, ["TA", "JS"]);
//
//     console.log(course);
// });

// var jsOop = module.init("JSOOP",["task1","task2"]);
// console.log(jsOop);
// validNames.forEach(function (element) {
//     var student = jsOop.addStudent(element + " " + element);
//
// });

// var students = module.getAllStudents();
// console.log(students);