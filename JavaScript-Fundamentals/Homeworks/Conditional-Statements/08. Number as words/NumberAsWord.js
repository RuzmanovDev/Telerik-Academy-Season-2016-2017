function solve(args) {
    function capitalizeFirstLetter(string) {
        var str = string + '',
            strToRetun = str[0].toUpperCase() + str.substr(1, str.length);

        return strToRetun;
    }

    var wholeNumber = +args,
        numbersToWordsOnes = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"],
        fromElevenToNineteen = ["eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"],
        numbersToWordsTens = ["ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"],
        numbersToWordsHundreds = ["one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred"],
        ones,
        tens,
        hundreds,
        number;

    number = wholeNumber;
    ones = number % 10;
    number /= 10;
    tens = Math.floor(number) % 10;
    number /= 10;
    hundreds = Math.floor(number) % 10;


    if (hundreds === 0 && tens === 0) // едноцифрено число
    {
        return capitalizeFirstLetter(numbersToWordsOnes[ones]);
    }
    else if (wholeNumber > 10 && wholeNumber < 20) // 11-19
    {
        return capitalizeFirstLetter(fromElevenToNineteen[ones - 1]);
    }
    else if (hundreds === 0 && tens !== 0 && ones === 0) // 10,20,30,40,50,60,70,80,90
    {
        return capitalizeFirstLetter(numbersToWordsTens[tens - 1]);
    }
    else if (hundreds !== 0 && tens === 0 && ones === 0) //100,200,300,400,500,600,700,800,900
    {
        return capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1]);
    }
    else if (hundreds === 0 && tens > 1 && ones !== 0) //21, 22, 23, ... 99
    {
        return capitalizeFirstLetter(numbersToWordsTens[tens - 1] + " " + numbersToWordsOnes[ones]);
    }
    else if (hundreds > 0 && tens !== 0 && ones === 0) // 110, 120 ....
    {
        return capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + numbersToWordsTens[tens - 1]);
    }
    else if (hundreds !== 0 && tens === 1 && ones !== 0) // 111,212,313 etc..
    {
        return capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + fromElevenToNineteen[ones - 1]);
    }
    else if (hundreds !== 0 && tens > 1 && ones !== 0) // 121,143...
    {
        return capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + numbersToWordsTens[tens - 1] + " " + numbersToWordsOnes[ones]);
    }
    else if (hundreds !== 0 && tens === 0 && ones !== 0) // 101, 203, 405..
    {
        return capitalizeFirstLetter(numbersToWordsHundreds[hundreds - 1] + " and " + numbersToWordsOnes[ones]);
    }
}
