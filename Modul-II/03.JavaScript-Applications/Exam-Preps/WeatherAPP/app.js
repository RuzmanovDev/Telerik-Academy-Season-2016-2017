$(document).ready(function () {
    var $container = $("#container");

    var $input = $("<input />")
        .attr("id", "city");

    var $btn = $("<button />")
        .text("CLICK");

    $container
        .append($input)
        .append($btn);

    $btn.on("click", function () {
        var $this = $(this),
            city = $input.val(),
            $weatherContainer = $("#weather");

        $weatherContainer.empty();

        let url = `http://api.openweathermap.org/data/2.5/forecast/daily?q=${city}&units=metric&cnt=7&mode=JSON&appid=66dedd63b8db4c6781ec7d22bdd53c7b`;
        const promise = new Promise(function (resolve, reject) {
            $.ajax(url, {
                success: function (data) {
                    resolve(data);
                    console.log(data);
                }
            });
        });
        promise
            .then(function (data) {
                for (let i = 0; i < 7; i += 1) {
                    var $currentDay = $div.clone(true)
                        .text(data.list[i].temp.day);

                    let dayOfWeek = new Date(data.list[i].dt);
                    dayOfWeek = dayOfWeek.toString("MMM dd"); // "Dec 20"

                    var $dayOfWeek = $("<span />")
                        .text(dayOfWeek)
                        .css({
                            display: "inline-block",
                            border: "1px solid black",
                            padding: "5px"
                        });

                    $dayOfWeek.append($currentDay);

                    $weatherContainer.append($dayOfWeek);
                }

                $weatherContainer
                    .appendTo($container);
            });

        $this.val("");
    });

    var $div = $('<div />')
        .css({
            padding: "10px"
        });


});
