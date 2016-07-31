(function solve() {

    var element = $("#show-table");
    element.on('click',
        function () {
            $("#customers").toggle();
            if (element.text() === 'show table') {
                element.text("hide table");
            } else {
                element.text("show table");
            }
        });
} ());
