function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2];

    return Math.max(a,Math.max(b,c));
}