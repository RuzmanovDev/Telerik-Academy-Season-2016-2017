namespace MatrixClass
{
    using System;

    class MatrixManipulator
    {
        static void Main(string[] args)
        {
            Matrix firstMatrix = new Matrix(4, 4);
            Matrix secondMatrix = new Matrix(4, 4);

            for (int r = 0; r < firstMatrix.Rows; r++)
            {
                for (int c = 0; c < firstMatrix.Cols; c++)
                {
                    firstMatrix[r, c] = 1 + r;
                    secondMatrix[r, c] = 2 + r;
                }
            }

            // print
            Console.WriteLine(firstMatrix);
            Console.WriteLine(secondMatrix);

            // add
            Console.WriteLine(firstMatrix + secondMatrix);

            // substract
            Console.WriteLine(firstMatrix - secondMatrix);

            // multiply
            Matrix mul = firstMatrix * secondMatrix;
            Console.WriteLine(mul);
            Console.WriteLine(firstMatrix * secondMatrix);
        }
    }
}
