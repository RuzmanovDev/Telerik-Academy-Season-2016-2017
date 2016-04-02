using System;
class BatGoiko
{
    static void Main()
    {
        int heigh = int.Parse(Console.ReadLine());
        int width = heigh * 2;

        for (int r = 0; r < heigh; r++)
        {
            for (int c = 0; c < width; c++)
            {

                if (c == heigh - 1 && r < 1)
                {
                    Console.Write("/");
                }
                else if (c == heigh && r < 1)
                {
                    Console.Write("\\");
                }
                else if (r + c == heigh - 1)
                {
                    Console.Write("/");
                }
                else if (r - c == -heigh)
                {
                    Console.Write("\\");
                }
                else if ((r == 1 && (c == heigh - 1 || c == heigh))
                    || r == 3 && (c >= heigh - 3 && c <= heigh + 2)
                    || r == 6 && (c >= heigh - 6 && c <= heigh + 5)
                    || r == 10 && (c >= heigh - 10 && c <= heigh + 9)
                    || r == 15 && (c >= heigh - 15 && c <= heigh + 14)
                    || r == 21 && (c >= heigh - 21 && c <= heigh + 20)
                    || r == 28 && (c >= heigh - 28 && c <= heigh + 27)
                    || r == 36 && (c >= heigh - 36 && c <= heigh + 35)

                    )
                    

                {
                    Console.Write("-");
                }



                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

    }
}


