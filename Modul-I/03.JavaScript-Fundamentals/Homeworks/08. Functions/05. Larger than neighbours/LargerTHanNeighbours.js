function solve(args) {
    var  numbers = args[1].split(' ').map(Number),
        largerThanNeighbpurCount,
        i,
        currentNumber,
        length,
        prevNumber,
        nextNumber;


    length = numbers.length;
    largerThanNeighbpurCount = 0;

    for (i = 1; i < length - 1; i += 1) {
        currentNumber = numbers[i];
        prevNumber = numbers[i - 1];
        nextNumber = numbers[i + 1];
        if (currentNumber > prevNumber && currentNumber > nextNumber) {
            largerThanNeighbpurCount += 1;
        }
    }

    return largerThanNeighbpurCount;
}