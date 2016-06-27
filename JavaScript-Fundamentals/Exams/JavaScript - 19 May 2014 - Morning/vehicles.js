function solve(params) {
    var s = +params[0],
        count = 0,
        i, j, k;

    for (i = 0; i <= s; i += 1) {
        for (j = 0; j <= s; j += 1) {
            for (k = 0; k <= s; k += 1) {
                if (i * 4 + j * 3 + k * 10 === s) {
                    count += 1;
                }
            }
        }
    }


    console.log(count);
}
var test = ['40'];
solve(test);