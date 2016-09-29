import 'jquery'
import Handlebars from 'handlebars'

function load(templateName) {
    let templateUrl = `js/templates/${templateName}.handlebars`;

    return new Promise(function (resolve, reject) {
        $.ajax({
            url: templateUrl,
            success: function (data) {
                resolve(Handlebars.compile(data));
            },
            error: function (err) {
                reject(err);
            }
        })
    });
}

export default {
    load
}