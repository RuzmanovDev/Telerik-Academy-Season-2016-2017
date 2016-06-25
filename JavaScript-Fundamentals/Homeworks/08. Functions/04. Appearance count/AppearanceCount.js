function solve(args) {
    var input = args[0].split('\n'),
        seekedNum = +input[2],
        numbers = input[1].split(' ').map(Number),
        counter = 0,
        i,
        length;

    length = numbers.length;
    for (i = 0; i < length; i += 1) {
        if (numbers[i] === seekedNum) {
            counter += 1;
        }
    }

    return counter;
}
