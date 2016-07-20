function solve(args) {
    var input = args;
    var inputLength = input.length;
    var viktorDmg = 0;
    var naskorDmg = 0;
    var viktorConsecutive = 0;
    var naskorConsecutive = 0;
    var victorPreviousDmg = 0;
    var naskorPreviousDmg = 0;


    for (var i = 0; i < inputLength; i += 1) {
        var currentLine = input[i].split(' ');
        var dmg = +currentLine[0] * 60;
        var person = currentLine[1];
        if (person === 'white') {
            if (victorPreviousDmg === dmg) {
                viktorConsecutive += 1;
            }
            naskorConsecutive = 1;
            naskorPreviousDmg = 0;

            dmg = viktorConsecutive === 5 ? dmg * 4.5 : dmg;
            viktorDmg += dmg;
            victorPreviousDmg = parseFloat(dmg);

        } else {
            if (naskorPreviousDmg === dmg) {
                naskorConsecutive += 1;
            }
            viktorConsecutive = 0;
            victorPreviousDmg = 0;

            dmg = naskorConsecutive === 2 ? dmg * 2.75 : dmg;
            naskorDmg += dmg;
            naskorPreviousDmg = parseFloat(dmg);
        }
    }


    if (viktorDmg > naskorDmg) {
        return 'Winner - Vitkor' + '\n' + 'Damage - ' + viktorDmg;
    } else {
        return 'Winner - Naskor' + '\n' + 'Damage - ' + naskorDmg;

    }

}


var test = ['2 dark medenkas',
    '1 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
    '15 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas'
];

var test2 = ['5 white medenkas',
    '5 dark medenkas',
    '4 white medenkas'
];

console.log(solve(test2));