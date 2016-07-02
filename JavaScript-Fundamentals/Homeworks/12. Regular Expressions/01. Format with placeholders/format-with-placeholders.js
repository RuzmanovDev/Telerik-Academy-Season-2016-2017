function solve(args) {
    let options = JSON.parse(args[0]);
    let template = args[1];

    String.prototype.format = function (options) {
        let result = this;
        result = result.replace(/#{(.*?)}/g, function (match, token) {
            return options[token] || match;
        });

        return result;
    };
    let answer = template.format(options);


    console.log(answer);
}

const test = [
    '{ "name": "John", "age": 13 , "pesho": 2 , "gosho": 4, "petkan": "5", "dragan": 4,"cvetan":10}',
    "My name is #{name} and I am #{age} years-old #{pesho} years-old #{gosho} years-old #{petkan} years-old #{dragan} years-old #{cvetan} years-old"
];

solve(test);