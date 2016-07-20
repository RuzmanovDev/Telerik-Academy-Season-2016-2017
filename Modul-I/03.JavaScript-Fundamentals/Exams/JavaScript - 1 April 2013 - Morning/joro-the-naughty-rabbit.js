function solve(args) {
    var nmj = args[0].split(' '),
        rows = +nmj[0],
        cols = +nmj[1],
        jumps = +nmj[2],
        rc = args[1].split(' '),
        startRow = +rc[0],
        startCol = +rc[1],
        sum,
        length, r, c, i,
        field,
        value,
        jumpCoord = [],
        numberOfJumps;

    value = 1;
    field = [];
    for (r = 0; r < rows; r += 1) {
        field[r] = [];
        for (c = 0; c < cols; c += 1) {
            field[r][c] = value;
            value += 1;
        }
    }

    numberOfJumps = 0;
    sum = 0;
    sum += field[startRow][startCol];
    field[startRow][startCol] = 'v';
    while (true) {
        for (i = 0; i < jumps; i += 1) {

            jumpCoord[i] = args[2 + i].split(' ').map(Number);

            numberOfJumps += 1;
            startRow += jumpCoord[i][0];
            startCol += jumpCoord[i][1];


            if (startRow >= rows || startCol >= cols || startRow < 0 || startCol < 0) {
                console.log("escaped " + sum);
                return;
            }

            if (field[startRow][startCol] === 'v') {
                console.log('caught ' + numberOfJumps);
                return;
            }
            sum += field[startRow][startCol];
            field[startRow][startCol] = 'v';
            // console.log(jumpCoord);
        }
    }
}

var test = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];

solve(test);
