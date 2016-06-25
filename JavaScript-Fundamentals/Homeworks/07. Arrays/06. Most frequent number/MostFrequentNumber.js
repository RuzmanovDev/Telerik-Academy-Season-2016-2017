function solve(args) {
    var numbers = [],
        i,
        j,
        counter,
        maxCounter,
        bestelement,
        nums;

    nums = args[0].split('\n');


    for (i = 1; i < nums.length; i += 1) {
        numbers.push(+nums[i]);
    }

    bestelement = 0;
    counter = 1;
    maxCounter = 0;
    for (i = 0; i < numbers.length - 1; i += 1) {
        counter = 1;
        for (j = i + 1; j < numbers.length; j += 1) {
            if (numbers[i] === numbers[j]) {
                counter += 1;
            }
        }

        if (maxCounter < counter) {
            maxCounter = counter;
            bestelement = numbers[i];
        }
    }

    return bestelement + " (" + maxCounter + " times)";
}