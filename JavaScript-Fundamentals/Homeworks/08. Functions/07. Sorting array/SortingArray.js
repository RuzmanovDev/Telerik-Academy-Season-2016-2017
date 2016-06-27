function solve(args) {
    var numbers = args[1].split(' ').map(Number),
        i,
        length;

    return numbers.sort(function (x, y) {
        if (x > y) {
            return 1;
        } else {
            return -1;
        }
    }).join(' ');
}