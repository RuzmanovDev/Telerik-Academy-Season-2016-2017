using System;

class MissCat2011
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] cats = new int[10];

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1: cats[0] += 1; break;
                case 2: cats[1] += 1; break;
                case 3: cats[2] += 1; break;
                case 4: cats[3] += 1; break;
                case 5: cats[4] += 1; break;
                case 6: cats[5] += 1; break;
                case 7: cats[6] += 1; break;
                case 8: cats[7] += 1; break;
                case 9: cats[8] += 1; break;
                case 10: cats[9] += 1; break;

                default:
                    break;
            }
        }

        int maxNumberOfVotes = 0;
        int numberOfVotes = 0;
        int catIndex = 0;

        for (int i = 0; i < cats.Length; i++)
        {
            numberOfVotes = cats[i];
            if (numberOfVotes > maxNumberOfVotes)
            {
                maxNumberOfVotes = numberOfVotes;
                catIndex = i;
            }
        }

        Console.WriteLine(catIndex + 1);
    }
}

