function solve(args) {
    let rc = args[0].split(' ').map(Number),
        rows = rc[0],
        cols = rc[1],
        derbises = args[1].split(';'),
        commandsLength = +args[2];


    //find tank
    function findTankCoords(tankId, field) {
        let result = [];
        for (let r = 0; r < rows; r += 1) {
            for (let c = 0; c < cols; c += 1) {
                if (field[r][c] === tankId) {
                    result[0] = r;
                    result[1] = c;
                    return result;
                }
            }
        }
    }

    // calculate dir
    function calculateDir(step, dir) {
        if (dir === 'l') {
            return [0, -1];
        } else if (dir === 'r') {
            return [0, 1];
        } else if (dir === 'u') {
            return [-1, 0];
        } else if (dir === 'd') {
            return [1, 0];
        }

    }

    let derbisCoords = [];

    derbises.forEach(
        function (element) {
            let r = +element[0];
            let c = +element[2];
            derbisCoords.push(r);
            derbisCoords.push(c);
        }
    );
    // initialise and fill the matrix
    let field = [];

    for (let r = 0; r < rows; r += 1) {
        field[r] = [];
        for (let c = 0; c < cols; c += 1) {
            field[r][c] = true;
        }
    }

    // add the prepqttviq
    for (let i = 0; i < derbisCoords.length; i += 2) {
        field[derbisCoords[i]][derbisCoords[i + 1]] = 'd';
    }

    let KoceCount = 4;
    let CukiCount = 4;

    field[0][0] = 0;
    field[0][1] = 1;
    field[0][2] = 2;
    field[0][3] = 3;

    field[rows - 1][cols - 1] = 4;
    field[rows - 1][cols - 2] = 5;
    field[rows - 1][cols - 3] = 6;
    field[rows - 1][cols - 4] = 7;


    // console.log(field);

    for (let i = 0; i < commandsLength; i += 1) {
        // read the command
        let command = args[i + 3].split(' ');
        let tankId = +command[1];
        let tankCoords = findTankCoords(tankId, field);


        if (command[0] === 'x') {

            let dir = command[2];
            let deltaRow = 0;
            let deltaCol = 0;

            if (dir === 'l' || dir === 'r') {
                deltaCol = dir === 'l' ? -1 : 1;
            } else {
                deltaRow = dir === 'u' ? -1 : 1;
            }

            for (let r = 0; r < rows; r += deltaRow) {
                for (let c = 0; c < cols; c += deltaCol) {
                    if (field[r][c] === undefined) {
                        break;
                    } else if (field[r][c] === 'd') {
                        field[r][c] = true;
                    } else if (field[r][c] === true) {
                        continue;
                    } else {
                        var value = field[r][c];
                        field[r][c] = true;
                        if (value < 4) {
                            KoceCount -= 1;
                        } else {
                            CukiCount -= 1;
                        }

                        if (KoceCount === 0) {
                            console.log("Koce is gg");
                            return;
                        } else if (CukiCount === 0) {
                            console.log("Cuki is gg");
                            return;

                        }
                    }

                }
            }
        }

        if (command[0] === 'mv') {
            let steps = +command[2];
            let dir = command[3];

            let currentRow = tankCoords[0];
            let currentCol = tankCoords[1];

            let deltaRow = 0;
            let deltaCol = 0;

            if (dir === 'l' || dir === 'r') {
                deltaCol = dir === 'l' ? -1 : 1;
            } else {
                deltaRow = dir === 'u' ? -1 : 1;
            }

            while (1) {
                currentRow += deltaRow;
                currentCol += deltaCol;

                if (currentCol >= cols || currentCol < 0 || currentRow >= rows || currentRow < 0) {
                    console.log("Tank " + tankId + " is gg");

                    let value = field[currentRow][currentCol];
                    field[currentRow][currentCol] = true;
                    if (value < 4) {
                        KoceCount -= 1;
                    } else {
                        CukiCount -= 1;
                    }
                    if (KoceCount === 0) {
                        console.log("Koce is gg");
                        return;
                    } else if (CukiCount === 0) {
                        console.log("Cuki is gg");
                        return;

                    }
                    break;
                } else if (field[currentRow][currentCol] === true) {
                    field[currentRow][currentCol] = tankId;
                }
                else {
                    break;
                }
            }
        }

    }
}


const test = [
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
];

const test2 = [
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 9 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
];

solve(test);