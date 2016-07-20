function solve(args) {
    var nk = args[0].split(' ').map(Number),
        s = args[1].split(' ').map(Number),
        result,
        transformations,
        neighbours,
        currentElement,
        newArray;

    transformations = nk[1];
    newArray = [];
    for (var j = 0; j < transformations; j += 1) {

        var length = s.length;

        for (var i = 0; i < length; i += 1) {

            function findNeighbours(s, i) {
                var neighbours = [];
                if (i === 0) {
                    neighbours.push(s[i + 1]);
                    neighbours.push(s[s.length - 1]);
                } else if (i === s.length - 1) {
                    neighbours.push(s[i - 1]);
                    neighbours.push(s[0]);
                } else {
                    neighbours.push(s[i - 1]);
                    neighbours.push((s[i + 1]));
                }

                return neighbours;
            }

            neighbours = findNeighbours(s, i);
            if (s[i] === 0) {
                currentElement = Math.abs(neighbours[0] - neighbours[1]);
            } else if (s[i] % 2 === 0) {
                currentElement = function (firstElement, secondElement) {
                    if (firstElement > secondElement) {
                        return firstElement;
                    } else {
                        return secondElement
                    }
                }(neighbours[0], neighbours[1])
            } else if (s[i] === 1) {
                currentElement = neighbours[0] + neighbours[1];
            } else {
                currentElement = function (firstElement, secondElement) {
                    if (firstElement < secondElement) {
                        return firstElement;
                    } else {
                        return secondElement
                    }
                }(neighbours[0], neighbours[1]);

            }
            newArray.push(currentElement);

        }
        s = newArray;
        newArray = [];

    }
   // console.log(s);
    result = function (s) {
        var i,
            length,
            result;

        length = s.length;
        result = 0;
        for (i = 0; i < length; i += 1) {
            result += s[i];
        }

        return result;
    }(s);

    console.log(result);
}

var test = ['5 1', '9 0 2 4 1'];
var test2 = ['10 3', '1 9 1 9 1 9 1 9 1 9'];
solve(test);
solve(test2);