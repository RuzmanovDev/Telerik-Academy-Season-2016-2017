function solve(params) {
    var N = parseInt(params[0]),
        answer = 0,
        array = [],
        length,
        i,
        maxSoFar,
        maxEnding,
        allnegative


    length = params.length;

    for (i = 1; i < length; i += 1) {
        array.push(+params[i]);
    }

    maxSoFar = 0;
    maxEnding = 0;

    allnegative = false;
    allnegative = array.every(function (element) {
        return element < 0;
    });
    if (allnegative) {
        var min = function (array) {
            var min = array[0],
                length = array.length;
            for (i = 1; i < length; i += 1) {
                if (min < array[i]) {
                    min = array[i];
                }
            }
            return min
        }(array);

        return min;
    }
    length = array.length;
    for (i = 0; i < length; i += 1) {
        maxEnding = maxEnding + array[i];
        if (maxEnding < 0) {
            maxEnding = 0;
        }
        if (maxSoFar < maxEnding) {
            maxSoFar = maxEnding;
        }
    }

    console.log(maxSoFar);
}

var test = [
    '8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'
];

var test2 = [
    '9',
    '-9',
    '-8',
    '-8',
    '-7',
    '-6',
    '-5',
    '-1',
    '-7',
    '-6'
];
console.log(solve(test2));

//solve(test);
