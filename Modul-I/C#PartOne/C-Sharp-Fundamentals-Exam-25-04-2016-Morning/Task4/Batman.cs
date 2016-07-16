using System;

class Task4
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char c = char.Parse(Console.ReadLine());

        char space = ' ';
        int symbolCount = size;
        int spaceCount = size;
        int sideSpace = 0;

        for (int i = 0; i < size / 2; i++)
        {
            if (i == size / 2 - 1)
            {
                spaceCount = (spaceCount - 3) / 2;
                Console.Write(new string(space, sideSpace));
                Console.Write(new string(c, symbolCount));
                Console.Write(new string(space, spaceCount));
                Console.Write("{0} {0}", c);
                Console.Write(new string(space, spaceCount));
                Console.Write(new string(c, symbolCount));
                Console.WriteLine(new string(space, sideSpace));
            }
            else
            {
                Console.Write(new string(space, sideSpace));
                Console.Write(new string(c, symbolCount));
                Console.Write(new string(space, spaceCount));
                Console.Write(new string(c, symbolCount));
                Console.WriteLine(new string(space, sideSpace));
                symbolCount--;
                sideSpace++;
            }
        }

        // second part
        sideSpace++;
        symbolCount = (size * 3) - (2 * sideSpace);
        for (int i = 0; i < size / 3; i++)
        {
            Console.Write(new string(space, sideSpace));
            Console.Write(new string(c, symbolCount));
            Console.WriteLine(new string(space, sideSpace));
        }
        // down part

        symbolCount = size - 2;
        sideSpace = ((3 * size) - symbolCount) / 2;

        while (symbolCount > 0)
        {
            Console.Write(new string(space, sideSpace));
            Console.Write(new string(c, symbolCount));
            Console.WriteLine(new string(space, sideSpace));
            symbolCount -= 2; ;
            sideSpace++;
        }
    }
}

