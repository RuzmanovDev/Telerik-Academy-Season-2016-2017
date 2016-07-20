function solve(args) {
    var numbers = [],
        i,
        currentCounter,
        maxCounter,
        nums = args[0].split('\n');

    for (i = 1; i < nums.length; i += 1) {
        numbers.push(+nums[i]);
    }

    currentCounter = 1;
    maxCounter = 0;
    for (i = 0; i < numbers.length - 1; i += 1) {
        if (numbers[i] < numbers[i + 1]) {
            currentCounter += 1;
        } else {
            currentCounter = 1;
        }

        if (currentCounter > maxCounter) {
            maxCounter = currentCounter;
        }
    }

    return maxCounter;
}

