function solve(args) {
    let numbers = args.map(Number);

    let result = 0;

    result = numbers[1];
    // i know this sucks :D have fun :D
    if (result % 2 !== 0) {
        for (let i = 2; i < numbers.length; i += 1) {
            let number = numbers[i];

            if (number % 2 !== 0) {
                result *= number;
            } else {
                result += number;
                i += 1;
            }

            result %= 1024;
        }
    } else {
        for (let i = 3; i < numbers.length; i += 1) {
            let number = numbers[i];

            if (number % 2 !== 0) {
                result *= number;
            } else {
                result += number;
                i += 1;
            }

            result %= 1024;
        }
    }

    console.log(result);

}

solve([
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9'
]);