function solve(args) {
    var input = args[0].split('\n'),
        numbers = input[1].split(' ').map(Number),
        i,
        length;

    
    return numbers.sort().join(' ');
}