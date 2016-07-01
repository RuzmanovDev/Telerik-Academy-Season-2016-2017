function solve(args) {
    var people = [],
        step = 3,
        input = args,
        i;

    for (i = 0; i < input.length; i += step) {
        people.push({
                firstName: input[i] + '',
                lastName: input[i + 1] + '',
                age: +input[i + 2]
            }
        );
    }

    var youngest = people.reduce(
        function (a, b) {
            return a.age <= b.age ? a : b;
        });

    console.log(youngest.firstName + ' ' + youngest.lastName);
}

var people = [
    {firstname: 'Gosho', lastname: 'Petrov', age: 32},
    {firstname: 'Bay', lastname: 'Ivan', age: 81},
    {firstname: 'John', lastname: 'Doe', age: 42}
];

solve(people);