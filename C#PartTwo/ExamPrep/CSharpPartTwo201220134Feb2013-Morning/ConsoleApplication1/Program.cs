using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{

    static int exit = 0;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        bool[] lamps = new bool[n];

        string commands = Console.ReadLine();
        string secondCommands = Console.ReadLine();
        // Second task
        int answer = LampsSwitch(lamps, 0, 1);
        Console.WriteLine(answer);
        Console.WriteLine(FindBoundedMoves(commands));

        // Second task again

        Console.WriteLine(FindBoundedMoves(secondCommands));

    }

    private static string FindBoundedMoves(string commands)
    {
        int[] movesX = { 1, 0, -1, 0 };
        int[] movesY = { 0, 1, 0, -1 };

        // Starting from (0,0)
        int currentX = 0, currentY = 0, direction = 0;

        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < commands.Length; j++)
            {
                switch (commands[j])
                {
                    case 'S':
                        currentX += movesX[direction];
                        currentY += movesY[direction];
                        break;
                    case 'L':
                        direction = (direction + 3) % 4; // +270 degrees, turns left
                        break;
                    case 'R':
                        direction = (direction + 1) % 4; // +90 degrees, turns right
                        break;
                }
            }
        }

        if (currentX == 0 && currentY == 0)
        {
            // After 4 commands execution he is back on the starting place
            return "bounded";
        }
        else
        {
            // He moved after 4 commands execution
            // He will move again and again in the same direction after every next commands execution
            return "unbounded";
        }
    }

    static int LampsSwitch(bool[] lamps, int start, int counter)
    {
        int lampIndex = 0;

        while (start >= 0)
        {

            counter++;
            for (int i = start; i < lamps.Length; i += counter)
            {
                if (lamps[i] == false)
                {
                    lamps[i] = true;
                    lampIndex = i;
                }


            }

            start = NextStart(lamps);


        }
        return lampIndex;

    }

    private static int NextStart(bool[] lamps)
    {
        for (int i = 0; i < lamps.Length; i++)
        {
            if (lamps[i] == false)
            {
                return i;
            }
        }
        return -1;
    }
   

        


    
}




