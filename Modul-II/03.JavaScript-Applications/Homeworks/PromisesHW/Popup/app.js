(function () {
    var div = document.createElement("div");
    div.style.width = "40%";
    div.style.height = "40%";
    div.style.border = "1px solid black";
    div.style.borderRadius = "5px";
    div.style.padding = "10%";
    div.style.backgroundColor = "lightBlue";
    div.innerHTML = "<h1>You will be redirected to stackoverflow in 2 seconds </h1>";

    var promise = new Promise(function (resolve, reject) {
        var timeout = 2000;
        setTimeout(function () {
            window.location.href = "http://stackoverflow.com";
            resolve(timeout);
        }, timeout)


    });

    // promise.then(function (timeout) {
    //     div.innerHTML = `<h1>You will be redirected to stackoverflow in ${timeout} seconds </h1>`;
    // });
    document.body.appendChild(div);
}());