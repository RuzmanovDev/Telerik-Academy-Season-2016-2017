function solveTask(args) {
	function extractURLElements(url) {
		var pattern = /(.*):\/\/(.*?)(\/.*)/g;

		return pattern.exec(url);
	}

	var urlAddress = args[0];

	var fragments = extractURLElements(urlAddress);

	// Convert to JSON object
	var jsonObject = JSON.stringify({
		protocol: fragments[1],
		server: fragments[2],
		resource: fragments[3]
	});


	// Parse JSON object to JS object
	var jsObject = JSON.parse(jsonObject);

	
	console.log("protocol: " + jsObject.protocol);
	console.log("server: " + jsObject.server);
	console.log("resource: " + jsObject.resource);
}

var test = [ 'http://telerikacademy.com/Courses/Courses/Details/239' ];
solveTask(test);