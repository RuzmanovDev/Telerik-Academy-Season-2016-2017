function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        d = +args[3],
        e = +args[4];
    if (a >= b && a >= c && a >= d && a >= e) {
        return a;
    }
    else if (b >= a && b >= c && b >= d && b >= e) {
        return b;
    }
    else if (c >= a && c >= b && c >= d && c >= e) {
        return c;
    }
    else if (d >= a && d >= b && d >= c && d >= e) {
        return d;
    }
    else if (e >= a && e >= b && e >= c && e >= d) {
        return e;
    }
}