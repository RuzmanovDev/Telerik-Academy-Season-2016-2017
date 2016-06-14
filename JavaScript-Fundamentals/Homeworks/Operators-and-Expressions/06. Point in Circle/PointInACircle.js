function solve(args) {
    var x = +args[0],
        y = +args[1],
        radius = 2;

    var distance = Math.sqrt((0 - x) * (0 - x) + (0 - y) * (0 - y));

    var isInTheCircle = distance <= radius ? true : false;

    if (isInTheCircle) {
        return "yes " + distance.toFixed(2);
    }
    else {
        return "no " + distance.toFixed(2);
    }
}

