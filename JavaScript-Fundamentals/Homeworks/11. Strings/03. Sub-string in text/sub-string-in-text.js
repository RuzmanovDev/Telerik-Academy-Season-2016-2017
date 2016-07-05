function solve(args) {
    let seekedWord = args[0];
    let text = args[1];
    let count = 0;
    const regex = new RegExp(seekedWord,'\gi');

    while(regex.exec(text) !==null){
        count+=1;
    }

    console.log(count);
}

const test = [
    'in',
    'We are living in an yelin low submi narine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
];

solve(test);

