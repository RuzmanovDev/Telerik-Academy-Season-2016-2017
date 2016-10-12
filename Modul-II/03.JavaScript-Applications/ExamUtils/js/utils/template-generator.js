/* globals Handlebars, $ */

var templateGenerator = (function () {
    'use strict';

    function load(templateName) {
        var templateUrl = `../../templates/${templateName}.handlebars`;

        return new Promise(function (resolve, reject) {
            $.ajax({
                url: templateUrl,
                success: function (data) {
                    var template = Handlebars.compile(data);
                    resolve(template);
                },
                error: function (err) {
                    reject(err);
                }
            })
        });
    }

    return {
        load
    }
}());
