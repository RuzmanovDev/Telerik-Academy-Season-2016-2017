function solve(args) {
    let text = args[0];

    let brackets = [];
    let correct = true;
    for (let i = 0; i < text.length; i+=1)
    {
        let currentSymbol = text[i];
        if (currentSymbol == '(')
        {
            brackets.push(currentSymbol);
        }
        else if (currentSymbol == ')' && brackets.length == 0)
        {
            correct = false;
            break;
        }
        else if (currentSymbol == ')')
        {
            brackets.pop();
        }
    }

    if (correct && brackets.length != 0 && brackets[brackets.length-1] == '(')
    {
        correct = false;
    }

    if (!correct)
    {
        console.log("Incorrect");
    }
    else
    {
        console.log("Correct");
    }
}