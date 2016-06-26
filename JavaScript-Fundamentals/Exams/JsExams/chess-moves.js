function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]), i, move, r, c, board;

    // read the board
    board = [];
    for (r = 0; r < rows; r += 1) {
        board[r] = [];
        for (c = 0; c < cols; c += 1) {
            board[r][c] = params[2 + r][c];
        }
    }

    for (i = 0; i < tests; i += 1) {
        move = params[rows + 3 + i];

        // take the figure at move[0]
        var figureCol = move[0].charCodeAt(0) - 'a'.charCodeAt(0);
        var figureRow = (board[0].length - 1) - (+move[1]-1);
        //console.log(figureCol);
        //console.log(figureRow);
        // calculate where shoudl i put it
        var goToCol = move[3].charCodeAt(0) - 'a'.charCodeAt(0);
        var goToRow = (board[0].length - 1 ) - (+move[4]-1);
        //console.log(goToCol);
        //console.log(goToRow);
        // check if the figure can move in this direction
        var canMove = function (figureCol, figureRow, goToCol, goToRow) {
            var colDiff,
                rowDiff;
            // magic
            var figure = board[figureRow][figureCol];
            if (figure === '-') {
                return false;
            } else if (figure === "R") {
                colDiff = figureCol - goToCol;
                rowDiff = figureRow - goToRow;

                if (colDiff !== 0 && rowDiff !== 0) {
                    // the rook cannot move diagonaly
                    return false;
                } else {
                    colDiff = colDiff < 0 ? -1 : 1;
                    rowDiff = rowDiff < 0 ? -1 : 1;

                    while (figureRow !== goToRow && figureCol !== goToCol) {
                        figureRow += rowDiff;
                        figureCol += colDiff;
                        if (board[figureRow][figureCol] !== '-') {
                            return false;
                        }
                    }

                    return true;
                }

            } else if (figure === 'B') {
                colDiff = figureCol - goToCol;
                rowDiff = figureRow - goToRow;

                if (colDiff === 0 || rowDiff === 0) {
                    // the rook cannot move horizontaly or vertically
                    return false;
                } else {
                    colDiff = colDiff < 0 ? -1 : 1;
                    rowDiff = rowDiff < 0 ? -1 : 1;

                    while (figureRow !== goToRow && figureCol !== goToCol) {
                        figureRow += rowDiff;
                        figureCol += colDiff;
                        if (board[figureRow][figureCol] !== '-') {
                            return false;
                        }
                    }

                    return true;
                }
            }
            else if (figure === 'Q') {
                colDiff = colDiff < 0 ? -1 : 1;
                rowDiff = rowDiff < 0 ? -1 : 1;

                while (figureRow !== goToRow && figureCol !== goToCol) {
                    figureRow += rowDiff;
                    figureCol += colDiff;
                    if (board[figureRow][figureCol] !== '-') {
                        return false;
                    }
                }
                return true;
            }
        }(figureCol, figureRow, goToCol, goToRow);

        move = canMove ? 'yes' : 'no';
        console.log(move); // or console.log('no');
    }
}
var test = [
    '3',
    '4',
    '--R-',
    'B--B',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 b3',
    'd2 c1',
    'b1 b2',
    'c3 b1',
    'a2 a3',
    'd1 d3'
];

var test2 =
    [
        '5',
        '5',
        'Q---Q',
        '-----',
        '-B---',
        '--R--',
        'Q---Q',
        '10',
        'a1 a1',
        'a1 d4',
        'e1 b4',
        'a5 d2',
        'e5 b2',
        'b3 d5',
        'b3 a2',
        'b3 d1',
        'b3 a4',
        'c2 c5'
    ];
//solve(test);
solve(test);