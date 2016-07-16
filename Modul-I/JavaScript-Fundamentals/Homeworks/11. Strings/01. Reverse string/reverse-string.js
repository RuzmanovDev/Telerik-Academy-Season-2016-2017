function solve(args) {
    const str = args[0];
    let result = "";
    for (let i = str.length-1; i>=0; i-=1) {
        result += str[i];
    }

  return  result;
}


