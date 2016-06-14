function solve(args) {
    var number = +args,
        bit;

    number >>= 3;
    bit = number & 1;

    return bit;
}
