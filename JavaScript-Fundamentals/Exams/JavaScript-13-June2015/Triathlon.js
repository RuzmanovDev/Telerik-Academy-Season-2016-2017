function solve(args) {
    var result, text = args[0],
        offset = parseInt(args[1], 10),
        CONSTANTS = {
            ALPHABET: 'abcdefghijklmnopqrstuvwxyz'
        };

    function compress(text) {
        var previousChar = text[0];
        var count = 1;
        var length = text.length;
        var compressedText = '';

        for (var i = 1; i < length; i += 1) {
            var currentChar = text[i];
            if (previousChar === currentChar) {
                count += 1
                if (i === length - 1) {
                    if (count === 1) {
                        compressedText += previousChar;
                    } else if (count === 2) {
                        compressedText += previousChar + previousChar
                    } else {
                        compressedText += count + previousChar;
                    }
                }
            } else {
                if (count > 2) {
                    compressedText += count + previousChar;
                } else {
                    compressedText += count === 1 ? previousChar : previousChar + previousChar;

                }
                count = 1;
            }

            previousChar = currentChar;
        }
        return compressedText;
    }

    var shortenedText = compress(text);

    function encode(shortenedText, offset) {
        var result = '';
        var firstpartOfCipher = CONSTANTS.ALPHABET.substr(26 - offset);
        var secondPart = CONSTANTS.ALPHABET.substr(0, 26 - offset);
        var cipher = firstpartOfCipher + secondPart;

        for (var i = 0; i < shortenedText.length; i++) {
            var currentChar = shortenedText[i];

            if (isNaN(currentChar)) {
                var xOrWith = cipher[currentChar.charCodeAt(0) - 'a'.charCodeAt(0)];
                var encodedChar = currentChar.charCodeAt(0) ^ xOrWith.charCodeAt(0);
                result += encodedChar;

            } else {
                result += currentChar;
            }
        }

        return result;
    }

    var number = encode(shortenedText, offset);

    function transformationEven(number) {
        var result = 0;
        for (var i = 0; i < number.length; i++) {
            var currentNumber = parseInt(number[i]);
            if (currentNumber % 2 === 0) {
                result += currentNumber;
            }

        }
        return result;
    }

    function transformationOdd(number) {
        var result = 1;
        for (var i = 0; i < number.length; i++) {
            var currentNumber = parseInt(number[i]);
            if (currentNumber % 2 !== 0) {
                result *= currentNumber;
            }

        }
        return result;
    }

    console.log(transformationEven(number));
    console.log(transformationOdd(number));
    //console.log(shortenedText)

}

var test = ['aaaabbbccccaaaaa',
    '3'
]
solve(test);
