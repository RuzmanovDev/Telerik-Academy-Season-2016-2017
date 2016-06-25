function solve(args) {
    var input = args[0].split('\n'),
        numbers = input[1].split(' ').map(Number),
        index,
        i,
        currentNumber,
        length,
        prevNumber,
        nextNumber;


    length = numbers.length;
    index = -1;
    for (i = 1; i < length - 1; i += 1) {
        currentNumber = numbers[i];
        prevNumber = numbers[i - 1];
        nextNumber = numbers[i + 1];
        if (currentNumber > prevNumber && currentNumber > nextNumber) {
            index = i;
            break;
        }
    }

    return index;
}