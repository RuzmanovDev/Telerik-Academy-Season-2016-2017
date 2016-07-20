function solve(args) {
    var number = args + '';
    var thirdDigit = 0;

    if (number.length >= 3) {
        thirdDigit = +number[number.length - 3];
    }

    return Math.floor(thirdDigit) === 7 ? true : 'false' + ' ' + thirdDigit;
}

