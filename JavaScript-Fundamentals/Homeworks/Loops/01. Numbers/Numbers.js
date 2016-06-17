function solve(args) {
    var number = +args,
        numbers = '';

    for (var i = 1; i <= number; i += 1) {
        numbers += i + ' ';
    }
    return numbers;
}