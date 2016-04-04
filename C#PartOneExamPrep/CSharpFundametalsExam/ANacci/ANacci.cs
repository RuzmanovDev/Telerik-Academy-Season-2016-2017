using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANacci
{
    class ANacci
    {
        static void Main(string[] args)
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
            for (int i = 0; i < numberOfLines; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(firstElement);
                    Console.Write(secondElement);
                    nextElement = NextElement(alphabet, firstElement, secondElement);
                    Console.WriteLine(nextElement);
                    continue;
                }
                nextElement = NextElement(alphabet, firstElement, secondElement);
                Console.Write(nextElement);
                Console.Write(new string(' ', spaceCounter));
                Console.WriteLine(NextElement(alphabet, firstElement, secondElement));
                firstElement = secondElement;
                secondElement = (NextElement(alphabet, firstElement, secondElement)); 
                spaceCounter++;



            }





        }
        static char NextElement(char[] alphabet, int firstElement, int secondElement)
        {
            int indexOfNextElement = Array.IndexOf(alphabet, firstElement) + Array.IndexOf(alphabet, secondElement);
            if (indexOfNextElement > 26)
            {
                indexOfNextElement = indexOfNextElement % 26;
            }
            char nextElement = alphabet[indexOfNextElement];

            return nextElement;


        }
    }
}
