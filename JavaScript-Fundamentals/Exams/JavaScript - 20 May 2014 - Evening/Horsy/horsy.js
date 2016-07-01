function solve(args) {
    let rc = args[0].split(' ');
    let row = +rc[0];
    let col = +rc[1];
    let directions = [];

    for (let i = 0; i < row; i += 1) {
        let currentRow = args[1 + i].split('').map(Number);
        directions[i] = [];
        for (let j = 0; j < col; j += 1) {
            directions[i][j] = currentRow[j];
        }
    }

    function calculateSum(currentRow, currentCol) {

        return Math.pow(2, currentRow) - currentCol;
    }

    function calculateNext(dir) {
        let deltaRow,
            deltaCol;

        if (dir === 1) {
            deltaRow = -2;
            deltaCol = 1;
        } else if (dir === 2) {
            deltaRow = -1;
            deltaCol = 2;
        } else if (dir === 3) {
            deltaRow = 1;
            deltaCol = 2;
        } else if (dir === 4) {
            deltaRow = 2;
            deltaCol = 1;
        } else if (dir === 5) {
            deltaRow = 2;
            deltaCol = -1;
        } else if (dir === 6) {
            deltaRow = 1;
            deltaCol = -2;
        } else if (dir === 7) {
            deltaRow = -1;
            deltaCol = -2;
        } else if (dir === 8) {
            deltaRow = -2;
            deltaCol = -1;
        }

        return {
            row: deltaRow,
            col: deltaCol
        }
    }

    let currentRow = row - 1;
    let currentCol = col - 1;
    let sum = 0;
    let jumps = 1;
    while (1) {
        sum += calculateSum(currentRow, currentCol);
        let dir = directions[currentRow][currentCol];
        let delta = calculateNext(dir);
        directions[currentRow][currentCol] = 'v';
        currentRow += delta.row;
        currentCol += delta.col;
        if (currentCol < 0 || currentCol > col - 1 || currentRow < 0 || currentRow > row - 1) {
            console.log("Go go Horsy! Collected " + sum + " weeds");
            return;
        } else if (directions[currentRow][currentCol] === 'v') {
            console.log("Sadly the horse is doomed in " + jumps + " jumps");
            return;
        }
        jumps += 1;

    }
    // console.log(row);
    // console.log(col);
    // console.log(directions);

}

const args = [
    '3 5',
    '54561',
    '43328',
    '52388'
];

solve(args);