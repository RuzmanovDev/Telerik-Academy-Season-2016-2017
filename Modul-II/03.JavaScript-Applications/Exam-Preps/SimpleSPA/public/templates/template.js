var templates = (function () {
    var handlebars = window.Handlebars || window.handlebars;

    function get(name) {
        var promise = new Promise(function (resolve, reject) {
            var url = `templates/${name}.handlebars`;
            $.get(url, function (html) {
                var template = handlebars.compile(html);
                resolve(template);
            }).error(function (err) {
                reject(err);
            })
        });

        return promise;
    }

    return {
        get: get
    }
}());