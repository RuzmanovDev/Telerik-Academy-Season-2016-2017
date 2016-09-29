System.config({
    transpiler: 'babel',
    map: {
        jquery: 'bower_components/jquery/dist/jquery.js',
        handlebars: 'bower_components/handlebars/handlebars.js',
        sammy: 'bower_components/sammy/lib/sammy.js',
        sha1: 'bower_components/js-sha1/src/sha1.js',
    }
});
System.import('js/app.js');