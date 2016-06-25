function solve(args) {
    var numbers = [],
        i,
        nums = args[0].split('\n'),
        j,
        temp;

    for (i = 1; i < nums.length; i += 1) {
        numbers.push(+nums[i]);
    }

    for (i = 0; i < numbers.length - 1; i += 1) {
        for (j = i + 1; j < numbers.length; j += 1) {
            if (numbers[i] > numbers[j]) {
                temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }
    }


    return numbers.join('\n');
}

