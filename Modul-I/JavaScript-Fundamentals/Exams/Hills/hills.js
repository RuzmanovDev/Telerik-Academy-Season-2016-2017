function solve(params) {
    var s = params[0].split(' ').map(Number),
        result,
        i;

    var max = 0;
    var count = 0;
    var foundValley = false;
    var foundPeak = false;
    for (i = 1; i < s.length; i += 1) {
        if (s[i] < s[i - 1]) {
            foundValley = true;
            foundPeak = false;
        } else if (i == s.length - 1) {
            foundPeak=true;
            foundValley = false;
        } else if (s[i] > s[i - 1] && s[i] > s[i + 1]) {
            foundPeak = true;
            foundValley = false;
        }

        if (foundValley) {
            count += 1;
        }

        if (foundPeak) {
            count += 1;
            max = Math.max(max, count);
            count = 0;
        }
    }
    result = max;

    console.log(result)
}
var test = ['5 1 7 6 3 6 4 2 3 8'];
var test2 = ['5 1 7 4 8'];
var test3 = ['10 1 2 3 4 5 4 3 2 1 10'];
solve(test);
solve(test3);
solve(test2);