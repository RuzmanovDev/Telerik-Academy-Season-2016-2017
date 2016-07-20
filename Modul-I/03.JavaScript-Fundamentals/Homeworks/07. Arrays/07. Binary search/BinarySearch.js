function solve(args) {
    var numbers,
        seekedNumber,
        startIndex,
        endIndex,
        middle,
        seekedIndex,
        numbs;

    numbs = args[0].split('\n');
    numbers = [];
    seekedNumber = +numbs[numbs.length - 1];
    for (var i = 1; i < numbs.length - 1; i += 1) {
        numbers.push(+numbs[i]);
    }

    startIndex = 0;
    endIndex = numbers.length - 1;
    seekedIndex = -1;
    while (startIndex <= endIndex) {
        middle = ((startIndex + endIndex) / 2) | 0;

        if (numbers[middle] > seekedNumber) {
            endIndex = middle - 1;
        }
        else if (numbers[middle] < seekedNumber) {
            startIndex = middle + 1;
        }
        else {
            seekedIndex = middle;
            break;
        }
    }

    return seekedIndex;
}