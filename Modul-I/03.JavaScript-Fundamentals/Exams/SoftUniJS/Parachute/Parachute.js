function solve(args) {
    var OCoords = [];

    OCoords = findO(args);
    var ORow = OCoords[0];
    var OCol = OCoords[1];
    var argsLength = args.length;

    for (var i = ORow + 1; i < argsLength; i += 1) {
        var currentLine = args[i];
        ORow = i;
        var colDiff = windDir(currentLine);
        OCol = OCol + colDiff;

        var symbolAt = currentLine[OCol];

        if (symbolAt === '\\' || symbolAt === '/' || symbolAt === '|') {
            console.log('Got smacked on the rock like a dog!');
            return ORow + ' ' + OCol;
        } else if (symbolAt === '~') {
            console.log('Drowned in the water like a cat!');
            return ORow + ' ' + OCol;
        } else if (symbolAt === '_') {
            console.log('Landed on the ground like a boss!');
            return ORow + ' ' + OCol;
        }
    }

    function windDir(currentLine) {
        var dir = 0;
        var currentLineLength = currentLine.length;

        for (var i = 0; i < currentLineLength; i += 1) {
            if (currentLine[i] === '>') {
                dir += 1;
            } else if (currentLine[i] === '<') {
                dir -= 1;
            }
        }

        return dir;
    }

    function findO(matrix) {
        var matrixlen = matrix.length;
        var coords = [];
        for (var i = 0; i < matrixlen; i += 1) {
            var currentLine = matrix[i];
            var currentLineLen = currentLine.length;
            for (var j = 0; j < currentLineLen; j += 1) {
                if (currentLine[j] === 'o') {
                    coords[0] = i;
                    coords[1] = j;
                    return coords;
                }
            }

        }
    }
}

console.log(solve(
    [
        "--------\\---/------<-----",
        "-->------|o|-------------",
        "----->---|-|-------<-----",
        "---------|>|<------------",
        "->-------/--\\<--->-------",
        "<---<---/----\\---->----><",
        "->>>>--/-<--</----<---<-<",
        "-------\\>>><<\\-----------",
        ">-------\\----/-->--------",
        "---------\\__/------------"
    ]));