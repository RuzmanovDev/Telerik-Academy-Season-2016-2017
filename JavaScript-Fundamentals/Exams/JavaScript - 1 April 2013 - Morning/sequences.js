function solve(params) {
    var N = parseInt(params[0]),
        answer = 1,
        i,
        length,
        numbers = [];

    for (i = 1; i <= N; i += 1) {
        numbers.push(+params[i]);
    }
    length = numbers.length;
    for (i = 1; i < length; i += 1) {
        if (numbers[i] < numbers[i - 1]) {
            answer += 1;
        }
    }
   // console.log(numbers);
    // Your code here...
    console.log(answer);
}

var test = [
    '7',
    '1',
    '2',
    '-3',
    '4',
    '4',
    '0',
    '1',
];

solve(test);
