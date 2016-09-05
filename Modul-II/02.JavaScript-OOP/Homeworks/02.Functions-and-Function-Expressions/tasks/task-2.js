/* Task description */
/*
 Write a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `Number`
 3) it must throw an Error if any of the range params is missing
 */

function findPrimes(start, end) {
    start = +start;
    end = +end;
    var result = [],
        j,
        i,
        len,
        number,
        isPrime = true;

    if (start === undefined || end === undefined) {
        throw Error();
    }

    if (start !== 0 && end !== 0) {
        if (!Number(start) || !Number(end)) {
            throw  new Error();
        }
    }


    for (j = start; j <= end; j += 1) {
        number = j;
        isPrime = true;
        len = Math.sqrt(number) | 0;

        for (i = 2; i <= len; i += 1) {
            if (number % i === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime && number !== 1 && number !== 0) {
            result.push(number)
        }
    }

    return result;
}

module.exports = findPrimes;
