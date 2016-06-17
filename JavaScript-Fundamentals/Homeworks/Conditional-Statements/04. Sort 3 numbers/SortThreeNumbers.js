function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2];

    if (a >= b && b >= c) {
        return a + ' ' + b + ' ' + c;
    }
    else if (a >= c && c >= b) {
        return a + ' ' + c + ' ' + b
    }
    else if (b >= a && a >= c) {
        return b + ' ' + a + ' ' + c;
    }
    else if (b >= c && c >= a) {
        return b + ' ' + c + ' ' + a;
    }
    else if (c >= a && a >= b) {
        return c + ' ' + a + ' ' + b;
    }
    else if (c >= a && b >= a) {
        return c + ' ' + b + ' ' + a
    }
}