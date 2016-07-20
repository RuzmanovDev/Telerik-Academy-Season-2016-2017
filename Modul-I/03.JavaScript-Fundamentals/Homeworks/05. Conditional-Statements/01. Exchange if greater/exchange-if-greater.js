function solve(args) {
    var firstNum = +args[0],
        secondNum = +args[1],
        temp;

    if (firstNum > secondNum) {
        console.log(secondNum + ' ' + firstNum);
    } else {
        console.log(firstNum + ' ' + secondNum);
    }
}
