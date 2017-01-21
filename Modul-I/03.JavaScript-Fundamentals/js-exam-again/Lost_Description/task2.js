function solve(args) {
    const rc = args[0].split(' ').map(Number);
    const rows = rc[0];
    const cols = rc[1];

    let maze = [];
    let startRow = rows / 2 | 0;
    let startCol = cols / 2 | 0;

    for (let r = 0; r < rows; r += 1) {
        let line = args[r + 1].split(' ').map(Number);
        maze.push(line);
    }

    let r = 0;
    let c = 0;

    while (true) {
        let currentCellValue = maze[startRow][startCol];

        maze[startRow][startCol] = -1; // mark visited

        if ((currentCellValue & 1 === 1)) { // up
            if (startRow - 1 < 0) {
                console.log(`No rakiya, only JavaScript ${startRow} ${startCol}`);
                break;
            }

            if (maze[startRow - 1][startCol] !== -1) {
                startRow -= 1;
                continue;
            }
        }

        if ((currentCellValue & (1 << 1)) >> 1 === 1) { // right
            if (startCol + 1 > cols - 1) {
                console.log(`No rakiya, only JavaScript ${startRow} ${startCol}`);
                break;
            }

            if (maze[startRow][startCol + 1] !== -1) {
                startCol += 1;
                continue;
            }
        }

        if ((currentCellValue & (1 << 2)) >> 2 === 1) { // down
            if (startRow + 1 > rows - 1) {
                console.log(`No rakiya, only JavaScript ${startRow} ${startCol}`);
                break;
            }

            if (maze[startRow + 1][startCol] !== -1) {
                startRow += 1;
                continue;
            }
        }

        if ((currentCellValue & (1 << 3)) >> 3 === 1) {// left
            if (startCol - 1 < 0) {
                console.log(`No rakiya, only JavaScript ${startRow} ${startCol}`);
                break;
            }

            if (maze[startRow][startCol - 1] !== -1) {
                startCol -= 1;
                continue;
            } else {
                console.log(`No JavaScript, only rakiya ${startRow} ${startCol}`);
                break;
            }
        }
        else {
            console.log(`No JavaScript, only rakiya ${startRow} ${startCol}`);
            break;
        }
    }
}

solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
]);