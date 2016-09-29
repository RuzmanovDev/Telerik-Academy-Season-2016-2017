const templateLoader = (()=> {

    function get(templateName) {
        let url = `templates/${templateName}.handlebars`;

        return new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                method: 'GET',
                success: function (data) {
                    var template = Handlebars.compile(data);
                    resolve(template);
                },
                error: function (errorLog) {
                    console.log(errorLog);
                }
            })
        });
    }

    return {
        get
    }
})();

export {templateLoader}