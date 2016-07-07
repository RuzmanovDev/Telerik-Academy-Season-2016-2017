function solve(args) {
    let valley = args[0].slice().split(' ').map(Number);

    function isPeak(valley, index) {
        return valley[index] > valley[index - 1] && valley[index] > valley[index + 1];
    }

    let result;

    var maxSum = 0;
    var currentSum = 0;
    var foundValley = false;
    var foundPeak = false;

    currentSum += valley[0];

    for (let i = 1; i < valley.length; i += 1) {
        //check if iam at last element
        if (i === valley.length - 1) {
            currentSum += valley[i];
            maxSum = Math.max(currentSum, maxSum);
            break;
        }
        // check if it is peak
        let amIInPeak = isPeak(valley, i);
        // if it's not add it to the sum
        if (!amIInPeak) {
            currentSum += valley[i];
        } else {
            currentSum += valley[i];
            maxSum = Math.max(currentSum, maxSum);
            currentSum = valley[i];
        }
        // if it is add it to the sum and check max sum
        //continue from it

    }
    //result = max;

    console.log(maxSum);
}

const test = [
    "5 1 7 6 5 6 4 2 3 8"
]

solve(test);