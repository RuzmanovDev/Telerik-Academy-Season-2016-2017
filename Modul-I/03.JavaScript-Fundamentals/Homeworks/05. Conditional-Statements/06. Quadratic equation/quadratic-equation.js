function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        descriminant,
        x1,
        x2;

    descriminant = (b * b) - (4 * a * c);
    x1 = 0;
    x2 = 0;

    if (descriminant == 0) {
        x1 = -b / (2 * a);
        x2 = x1;
        return 'x1=x2='+ x1.toFixed(2);
    }
    else if (descriminant > 0) {
        x1 = (-b + Math.sqrt(descriminant)) / (2 * a);
        x2 = (-b - Math.sqrt(descriminant)) / (2 * a);
    }
    else {
        return 'no real roots';
    }

    return 'x1=' + x2.toFixed(2) +'; x2=' + x1.toFixed(2);
}