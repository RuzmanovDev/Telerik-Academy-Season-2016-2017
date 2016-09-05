function solve() {
	// -------------------------- Helper functions --------------------------
	// TODO Improve regex logic
	function isValidTitle(title) {
		return !(/^\s+/.test(title) ||
			/\s+$/.test(title) ||
			/\s{2,}/.test(title)) && title;
	}

	function isValidName(name) {
		return /^[A-Z][a-z]*$/.test(name);
	}

	function isValidID(id) {
		return id % 1 === 0 && id > 0;
	}

	function isCorrectID(id, max) {
		return id > 0 && id < max;
	}

	function isNumber(number) {
		return !isNaN(parseFloat(number)) && isFinite(number);
	}

	function validateTitle(title) {
		if (!title) {
			throw new Error('Title cannot be an empty string!');
		}

		if (!isValidTitle(title)) {
			throw new Error('Title is not valid!');
		}
	}

	function validatePresentations(presentations) {
		if (!presentations.length) {
			throw new Error('Presentations cannot be an empty array!');
		}

		if (!presentations.every(isValidTitle)) {
			throw new Error('Some presentation titles are not valid!');
		}
	}

	function validateFullname(fullname) {
		if (fullname.length != 2) {
			throw new Error('Student cannot have more than two names!');
		}
	}

	function validateNames(firstname, lastname) {
		if (!(isValidName(firstname) && isValidName(lastname))) {
			throw new Error('Invalid name!');
		}
	}

	function validateIDs(studentID, homeworkID, studentsCount, presentationsCount) {
		if (!isValidID(studentID)) {
			throw new Error('Invalid student ID!');
		}

		if (!isValidID(homeworkID)) {
			throw new Error('Invalid homework ID!');
		}

		if (studentID > studentsCount) {
			throw new Error('Incorrect student ID!');
		}

		if (homeworkID > presentationsCount) {
			throw new Error('Incorrect homework ID!');
		}
	}

	function validateResults(results) {
		var uniqueIDs = [],
			studentID,
			score;

		results.forEach(function(result) {
			studentID = result.StudentID;
			score = result.Score;
			uniqueIDs.push(studentID);

			if (!isValidID(studentID)) {
				throw new Error('Invalid student ID!');
			}

			if (uniqueIDs[studentID]) {
				throw new Error('A student cannot participate a course more than once!');
			}

			if (!isNumber(score)) {
				throw new Error('Score must be a number!');
			}
		})
	}

	// **********************************************************************
	var Course;

	Course = {
		init: function(title, presentations) {
			validateTitle(title);
			validatePresentations(presentations);

			this._title = title;
			this._presentations = presentations;
			this._students = [];
			this._studentID = 1;

			return this;
		},
		addStudent: function(name) {
			var fullname = name.split(' '),
				firstname = fullname[0].trim(),
				lastname = fullname[1].trim(),
				newStudent;

			validateFullname(fullname);
			validateNames(firstname, lastname);

			this._students.push({
				firstname: firstname,
				lastname: lastname,
				id: this._studentID
			});

			return this._studentID++;
		},
		getAllStudents: function() {
			return this._students.slice();
		},
		submitHomework: function(studentID, homeworkID) {
			validateIDs(studentID, homeworkID, this._students.length, this._presentations.length);

			// this._homeworks is an array of arrays, in which the indexes are student IDs and the elements - array of
			// homework IDs
			this._homeworks = [];
			this._homeworks[studentID] = [].push(homeworkID);

			return this;
		},
		pushExamResults: function(results) {
			validateResults(results);

			this._results = results.map(function(result) {
				return isCorrectID(result.StudentID, this._students.length)
					? result
					: {
					StudentID: result.StudentID,
					Score: 0
				};
			});

			return this;
		},
		getTopStudents: function() {
			var topStudents = this._students.slice();

			// Sorting by descending scores

		}
	};

	return Course;
}

module.exports = solve;