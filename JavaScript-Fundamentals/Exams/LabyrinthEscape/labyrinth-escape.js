function solve(args) {
    var mn = args[0].split(' '),
        rc = args[1].split(' '),
        matrix = [],
        r,
        c,
        m,
        n,
        currentRow,
        currentCol,
        sum,
        nextNum,
        step;

    m = +mn[0];
    n = +mn[1];

    for (r = 0; r < m; r += 1) {
        matrix[r] = [];
        var elements = args[2 + r];
        for (c = 0; c < n; c += 1) {
            matrix[r][c] = elements[c];
        }
    }

    currentRow = +rc[0];
    currentCol = +rc[1];
    // sum = currentRow * n + (currentCol + 1);
    sum = 0;
    step = 0;
    while (true) {
        var direction = matrix[currentRow][currentCol];
        matrix[currentRow][currentCol] = 'v';
        nextNum = 0;
        sum += currentRow * n + (currentCol + 1);
        step+=1;
        if (direction === 'l') {
            currentCol -= 1;
        } else if (direction === 'r') {
            currentCol += 1;
        } else if (direction === 'u') {
            currentRow -= 1;
        } else if (direction === 'd') {
            currentRow += 1;
        }

        if (currentCol >=n || currentRow>=m) {
            console.log('out ' + sum);
            return;
        } else if (matrix[currentRow][currentCol] === 'v') {
            console.log('lost ' + step);
            return;
        }
    }

}

var args =[
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"]


solve(args);