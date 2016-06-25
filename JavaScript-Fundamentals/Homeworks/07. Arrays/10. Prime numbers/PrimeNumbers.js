function solve(args){
    var n = +args[0],
        j,
        i,
        isPrime,
        number;

    for ( j = n; j >= 0; j-=1)
    {
         number = j;
         isPrime = true;

        for ( i = 2; i <= Math.sqrt(number); i+=1)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            console.log(number);
            break;
        }
    }

}