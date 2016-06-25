function solve(args) {
    var word = args[0].split("\n"),
        firstString = word[0],
        secondString = word[1];

    if (firstString > secondString) {
        return '>';
    } else if (firstString < secondString) {
        return '<';
    } else {
        return '=';
    }

}