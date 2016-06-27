function solve(args) {
    var input = args,
        points = [],
        sides;

    points = function buildPoints(input) {
        var x, y,
            points = [],
            length,
            nums = input;

        length = nums.length - 1;
        for (var index = 0; index < length; index += 2) {
            x = parseFloat(nums[index]);
            y = parseFloat(nums[index + 1]);
            points.push({
                x: parseFloat(x),
                y: parseFloat(y)
            });
        }


        return points;
    } (input);

    sides = function (points) {
        var sides = [],
            length,
            side,
            index,
            firstPoint,
            secondPoint;

        length = points.length - 1;
        for (index = 0; index < length; index += 2) {
            firstPoint = points[index];
            secondPoint = points[index + 1];

            side = Math.sqrt((secondPoint.x - firstPoint.x) * (secondPoint.x - firstPoint.x) +
                (secondPoint.y - firstPoint.y) * (secondPoint.y - firstPoint.y));
            sides.push(side);
        }

        return sides;
    } (points);

    console.log()
}

var test = [
    '5', '6', '7', '8',
    '1', '2', '3', '4',
    '9', '10', '11', '12'
];

var secondTest = [
    '7', '7', '2', '2',
    '5', '6', '2', '2',
    '95', '-14.5', '0', '-0.123'
];
solve(secondTest);