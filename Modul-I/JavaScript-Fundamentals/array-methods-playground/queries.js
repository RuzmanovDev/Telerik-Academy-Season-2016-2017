'use strict';

const exporter = require('./student-exporter'),
    students = require('./data/data-scripts/students');

// queries go here

// 2. Get all students that didn't attend the **CSS** exam(their exam points will be `null`).
let allThatPassCSS = students
    .filter(student => student.courses[1].exam > 250
    || student.courses[1].exam * 0.75 + student.courses[1].homeworkAssignments * 1.5 + student.courses[1].attendance * 1.25 > 50);

// export to html page
exporter.exportToHtml(allThatPassCSS);