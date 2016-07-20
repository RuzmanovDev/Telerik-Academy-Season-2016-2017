function solve(args) {

    var number = +args[0];

    if (number % 2 === 0) {
        return 'even ' + number;
    } else {
        return 'odd ' + number;
    }
}