function solve(){
  return function(){
    $.fn.listview = function(data){
        var $this = $(this),
            templateSelector = '#' + $this.attr('data-template'),
            htmlTemplate = $(templateSelector).html(),
            template = handlebars.compile(htmlTemplate);

        [].forEach.call(data, function (currentData) {
            $this.append(template(currentData));
        });

        // enable chaining
        return this;
    };
    };
}

module.exports = solve;