(function () {
    var promise = new Promise(function (resolve, reject) {
        navigator.geolocation.getCurrentPosition(
            function (position) {
                resolve(position);
            },
            function (error) {
                reject(error)
            });
    });

    function parseCoords(position) {
        if (position.coords) {
            return {lat: position.coords.latitude, long: position.coords.longitude};
        } else {
            throw new Error("The object does not have coords property!")
        }
    }

    function createImg(coords) {
        var image = document.createElement("img"),
            container = document.getElementById("container"),
            imgSrc = "http://maps.googleapis.com/maps/api/staticmap?center=" + coords.lat + "," + coords.long
                + "&zoom=13&size=500x500&key=AIzaSyARvdHKfvAub5XZwqYmXL3i-h0G5Ucnk6g";
        image.setAttribute("src", imgSrc);

        container.appendChild(image);
    }

    promise
        .then(parseCoords)
        .then(createImg);
}());
