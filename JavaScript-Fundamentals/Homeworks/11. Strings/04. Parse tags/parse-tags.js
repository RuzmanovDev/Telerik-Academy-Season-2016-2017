
function solve(args) {
	String.prototype.escapeTags = function() {
		return this.escapeUpcaseTags().escapeLowcaseTags().escapeMixcaseTags();
	};

	String.prototype.escapeUpcaseTags = function() {
		return this.replace(/<upcase>(.*?)<\/upcase>/gi, function(tag, match) {
			return match.toUpperCase();
		});
	};

	String.prototype.escapeLowcaseTags = function() {
		return this.replace(/<lowcase>(.*?)<\/lowcase>/gi, function(tag, match) {
			return match.toLowerCase();
		});
	};

	String.prototype.escapeMixcaseTags = function() {
		return this.replace(/<orgcase>(.*?)<\/orgcase>/gi, function(tag, match) {
			return match;
		});
	};


	var text = args[0];
	var escapedText = text.escapeTags();

	console.log(escapedText);
}

let test = [ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]

solve(test);