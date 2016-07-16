function solve(args) {
    var number = +args[0];

    if (number % 5 === 0 && number % 7 === 0) {
        return 'true ' + number;
    }else {
        return 'false ' + number;
    }
}