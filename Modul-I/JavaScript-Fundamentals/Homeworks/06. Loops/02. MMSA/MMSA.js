function solve(args) {
    var numbers = [],
        min,
        max,
        sum = 0,
        average;

    for (var i = 0; i < args.length; i += 1) {
        numbers.push(+args[i]);
    }

    min = Math.min.apply(null,numbers);
    max = Math.max.apply(null,numbers);
    for (var j = 0; j < numbers.length; j += 1) {
        sum += numbers[j];
    }
    average = sum / numbers.length;

    console.log('min='+min.toFixed(2));
    console.log('max='+max.toFixed(2));
    console.log('sum='+sum.toFixed(2));
    console.log('avg='+average.toFixed(2));
}

var test = ['2','5','1'];
solve(test);