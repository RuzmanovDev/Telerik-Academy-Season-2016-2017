function solve(args) {
    var nums = [],
        largest,
        num = args[0].split(' ');

    for (var i = 0; i < num.length; i += 1) {
        nums.push(+num[i]);
    }

    largest = nums[0];
    for (i = 1; i < nums.length; i += 1) {
        if (nums[i] > largest) {
            largest = nums[i];
        }
    }

    return largest
}

var test = ['7 19 19'];
var result = solve(test);
console.log(result);