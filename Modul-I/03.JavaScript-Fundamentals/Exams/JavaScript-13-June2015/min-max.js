function solve(params) {
    var N = parseInt(params[0]),
        K = parseInt(params[1]),
        numbersAsString = params[2];

    var array = [];
    var result = [];
    var splitted = numbersAsString.split(' ');

    for (var i = 0; i < N; i++) {
        array.push(parseInt(splitted[i]));
    }

    var lengthOfCycle = array.length - K;
    for (var i = 0; i <= lengthOfCycle; i+=1) {
        var subarray = array.slice(i, i + K);
        var minValue = min(subarray);
        var maxValue = max(subarray);
        result.push(minValue + maxValue);
    }

    console.log(result.join(','));

    function min(subarray) {
        var min = subarray[0];

        for (var i = 1; i < subarray.length; i++) {
            if (min > subarray[i]) {
                min = subarray[i];
            }

        }
        return min;
    }

    function max(subarray) {
        var max = subarray[0];

        for (var i = 1; i < subarray.length; i++) {
            if (max < subarray[i]) {
                max = subarray[i];
            }

        }
        return max;
    }
}

var test = [
    4,
    2,
    '1 3 1 8'

]
solve(test);