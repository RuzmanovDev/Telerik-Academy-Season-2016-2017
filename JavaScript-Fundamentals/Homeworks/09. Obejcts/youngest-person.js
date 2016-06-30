function solve(args) {
    var input = args.slice();

    var res = input.sort(
        function (a, b) {
            return a.age - b.age;
        }
    );

   // console.log(res);
    var output = res[0].firstname + ' ' +res[0].lastname;
    console.log(output);
}

var people = [
    {firstname: 'Gosho', lastname: 'Petrov', age: 32},
    {firstname: 'Bay', lastname: 'Ivan', age: 81},
    {firstname: 'John', lastname: 'Doe', age: 42}
];

solve(people);