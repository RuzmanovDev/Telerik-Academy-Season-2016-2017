using System;

namespace WalkInMatrix
{
    class WalkInMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int matrixSize;
            while (!int.TryParse(input, out matrixSize) || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            var matrix = new SquareMatrix(matrixSize);

            matrix.RotatingWalkFill();
            Console.WriteLine(matrix);
        }
    }
}
