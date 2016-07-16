namespace ANacci
{
    using System;
    using System.Collections.Generic;

    public class ANacci
    {
        public static void Main(string[] args)
        {
            char[] alphabet = new char[27];
            char symbol = 'A';

            for (int i = 1; i < alphabet.Length; i++)
            {
                alphabet[i] = symbol;
                symbol++;
            }

            char firstElement = char.Parse(Console.ReadLine());
            char secondElement = char.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());
            int spaceCounter = 0;
            char nextElement = ' ';

            List<char> result = new List<char>();
            result.Add(firstElement);
            result.Add(secondElement);

            for (int i = 0; i <= numberOfLines; i++)
            {
                nextElement = NextElement(alphabet, firstElement, secondElement);
                firstElement = secondElement;
                secondElement = nextElement;
                result.Add(nextElement);
                nextElement = NextElement(alphabet, firstElement, secondElement);
                firstElement = secondElement;
                secondElement = nextElement;
                result.Add(nextElement);
            }

            int index = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(result[index]);
                    index++;
                    if (index > result.Count - 1)
                    {
                        index = 0;
                    }
                }
                else
                {
                    if (index > result.Count - 1)
                    {
                        index = 0;
                    }

                    Console.Write(result[index]);
                    Console.Write(new string(' ', spaceCounter));
                    if (index >= result.Count - 1)
                    {
                        index = 0;
                    }

                    Console.WriteLine(result[index + 1]);
                    index += 2;
                    spaceCounter++;
                }
            }
        }

        private static char NextElement(char[] alphabet, char firstElement, char secondElement)
        {
            int firstIndex = Array.IndexOf(alphabet, firstElement);
            int secondIndex = Array.IndexOf(alphabet, secondElement);

            int indexOfNextElement = firstIndex + secondIndex;

            if (indexOfNextElement > 26)
            {
                indexOfNextElement = indexOfNextElement % 26;
            }

            char nextElement = alphabet[indexOfNextElement];

            return nextElement;
        }
    }
}
