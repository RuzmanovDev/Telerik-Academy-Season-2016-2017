namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Task3
    {
        public static void Main(string[] args)
        {
            int moves = 0;

            int[] dimentions = Console.ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .ToArray();
            int a = dimentions[0];
            int b = dimentions[1];
            int c = dimentions[2];
            int d = dimentions[3];

            string[,,,] cube = new string[a, b, c, d];

            int[] harryCoord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int haaryA = harryCoord[0];
            int haaryB = harryCoord[1];
            int haaryC = harryCoord[2];
            int haaryD = harryCoord[3];
            cube[haaryA, haaryB, haaryC, haaryD] = "@";

            int numberOfBasilisk = int.Parse(Console.ReadLine());
            Dictionary<string, int[]> units = new Dictionary<string, int[]>();

            // add harry to the dictionary
            units.Add("@", new int[] { haaryA, haaryB, haaryC, haaryD });

            for (int i = 0; i < numberOfBasilisk; i++)
            {
                string[] coordsOfBasiliks = Console.ReadLine().Split(' ');
                string basiliskName = coordsOfBasiliks[0];
                int basiliskA = int.Parse(coordsOfBasiliks[1]);
                int basiliskB = int.Parse(coordsOfBasiliks[2]);
                int basiliskC = int.Parse(coordsOfBasiliks[3]);
                int basiliskD = int.Parse(coordsOfBasiliks[4]);

                cube[basiliskA, basiliskB, basiliskC, basiliskD] += basiliskName;
                units.Add(basiliskName, new int[] { basiliskA, basiliskB, basiliskC, basiliskD });
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] commands = command.Split(' ');
                string unitName = commands[0];
                string dimentionChange = commands[1];
                int indexChange = int.Parse(commands[2]);

                int[] coords = units[unitName];
                cube[coords[0], coords[1], coords[2], coords[3]] = string.Empty;

                if (dimentionChange == "A")
                {
                    if (units[unitName][0] + indexChange < 0)
                    {
                        units[unitName][0] = 0;
                    }
                    else if (units[unitName][0] + indexChange >= cube.GetLength(0))
                    {
                        units[unitName][0] = cube.GetLength(0) - 1;
                    }
                    else
                    {
                        units[unitName][0] += indexChange;
                    }
                }
                else if (dimentionChange == "B")
                {
                    if (units[unitName][1] + indexChange < 0)
                    {
                        units[unitName][1] = 0;
                    }
                    else if (units[unitName][1] + indexChange >= cube.GetLength(1))
                    {
                        units[unitName][1] = cube.GetLength(1) - 1;
                    }
                    else
                    {
                        units[unitName][1] += indexChange;
                    }
                }
                else if (dimentionChange == "C")
                {
                    if (units[unitName][2] + indexChange < 0)
                    {
                        units[unitName][2] = 0;
                    }
                    else if (units[unitName][2] + indexChange >= cube.GetLength(2))
                    {
                        units[unitName][2] = cube.GetLength(2) - 1;
                    }
                    else
                    {
                        units[unitName][2] += indexChange;
                    }
                }
                else if (dimentionChange == "D")
                {
                    if (units[unitName][3] + indexChange < 0)
                    {
                        units[unitName][3] = 0;
                    }
                    else if (units[unitName][3] + indexChange >= cube.GetLength(3))
                    {
                        units[unitName][3] = cube.GetLength(3) - 1;
                    }
                    else
                    {
                        units[unitName][3] += indexChange;
                    }
                }

                // make the move
                int unitA = units[unitName][0];
                int unitB = units[unitName][1];
                int unitC = units[unitName][2];
                int unitD = units[unitName][3];

                if (unitName == "@")
                {
                    moves++;
                }

                cube[unitA, unitB, unitC, unitD] += unitName;
                string cubeContent = cube[unitA, unitB, unitC, unitD];
                if (cubeContent.Length > 1 && cubeContent[0] == '@')
                {
                    // harry FOund basilisk
                    // B: "Step 3 was the worst you ever made."
                    // B: "You will regret until the rest of your life... All 3 seconds of it!"
                    string basiliskNameLex = cubeContent[1].ToString();
                    Console.WriteLine("{0}: \"You thought you could escape, didn't you?\" - {1}", basiliskNameLex, moves);
                    return;
                }
                else if (cubeContent.Length > 1 && cubeContent[1] == '@')
                {
                    Console.WriteLine("{0}: \"Step {1} was the worst you ever made.\"", cubeContent[0], moves); // cubecontent[0] should be the basilisk
                    Console.WriteLine("{0}: \"You will regret until the rest of your life... All 3 seconds of it!\"", cubeContent[0]);
                    return;
                }
            }

            Console.WriteLine("@: \"I am the chosen one!\" - {0}", moves);
        }
    }
}
