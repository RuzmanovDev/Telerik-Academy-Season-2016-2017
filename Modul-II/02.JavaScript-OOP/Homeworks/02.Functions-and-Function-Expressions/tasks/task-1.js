/* Task Description */
/* 
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined)
 throws if any of the elements is not convertible to Number

 */

function sum(numbers) {
    function checkIfAllAreNumbers(numbers) {
        var allAreNumbers = true;
        numbers.forEach(function (element) {
            if (!Number(+element)) {
                allAreNumbers = false;
                return allAreNumbers;
            }
        });

        return allAreNumbers;
    }

    if (!numbers || !checkIfAllAreNumbers(numbers)) {
        throw new Error()
    }

    if (numbers.length === 0) {
        return null;
    }

    var sum = numbers.reduce(function (a, b) {
        return +a + +b;
    }, 0);

    return sum
}

module.exports = sum;