function solve(args) {
    var number = +args,
        isPrime = true,
        cycleLimit = 0;

    if (number <= 2) {
        isPrime = false;
    }
    else {
        cycleLimit = Math.sqrt(number)
        for (var i = 2; i <= cycleLimit; i += 1) {
            if (number % i == 0 && i != number) {
                isPrime = false;
            }
        }
    }

    if (isPrime) {
        return true;
    }
    else {
        return false;
    }
}