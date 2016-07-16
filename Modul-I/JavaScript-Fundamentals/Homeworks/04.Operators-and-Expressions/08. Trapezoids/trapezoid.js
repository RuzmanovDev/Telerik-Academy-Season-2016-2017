function solve(args) {
    var a = +args[0],
        b = +args[1],
        h = +args[2],
        area = (a + b) / 2 * h;

    return area.toFixed(7)
}