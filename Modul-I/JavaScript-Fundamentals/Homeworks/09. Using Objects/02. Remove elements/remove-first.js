function solve(args) {
    var elements = args.slice();
    var remove = elements[0];
    Array.prototype.removeElement = function (element) {
        var result = [];

        for (var i in this) {
            if (this[i] !== element && typeof this[i] !== 'function') {
                result.push(this[i])
            }
        }

        return result;
    };

    console.log(elements.removeElement(remove).join('\n'));
}

var test = ['1', '2', '3', '2', '1', '2', '3', '2'];
solve(test);