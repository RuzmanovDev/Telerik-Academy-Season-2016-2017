function solve(args) {
    var num = +args,
        startnum,
        row,
        col,
        array,
        value;

    array = [];

    col = num;
    row = num;
    startnum = 1;

    for (var r = 0; r < row; r += 1) {
        array[r] = [];
        value = startnum;
        for (var c = 0; c < col; c += 1) {
            array[r][c] = value;
            value += 1;
        }
        console.log(array[r].join(' '));
        startnum += 1;
    }
}
