function solve(args) {
    var numbers = args[1].split(' ').map(Number),
        i,
        length;

    
    return numbers.sort().join(' ');
}