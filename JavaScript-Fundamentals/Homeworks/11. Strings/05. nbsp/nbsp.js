function solve(args) {
    const text = args[0];
    let result = text.replace(/\s+?/g, '&nbsp;');

    console.log(result);
}

var test = ['This text contains 4 spaces!!'];
solve(test);