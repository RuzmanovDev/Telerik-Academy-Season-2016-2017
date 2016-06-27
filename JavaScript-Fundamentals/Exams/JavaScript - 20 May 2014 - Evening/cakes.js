function solve(params) {
    var s = +params[0], c1 = +params[1], c2 = +params[2], c3 = +params[3],
        answer = 0, i, j, k, sum = 0;

    for (i = 0; i <= s / c1 + 1; i += 1) {
        for (j = 0; j <= s / c2 + 1; j += 1) {
            for (k = 0; k <= s / c3 + 1; k += 1) {
                sum = i * c1 + j * c2 + k * c3;
                if (sum <= s) {
                    answer = Math.max(sum, answer);
                }
            }
        }
    }
    console.log(answer);

}

var test = ['110', '13', '15', '17'];
var test2 = ['20', '11', '200', '300'];
solve(test);
solve(test2);