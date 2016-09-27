using System;
using NUnit.Framework;

namespace WalkInMatrix.UnitTests
{
    [TestFixture]
    public class SquareMatrixShould
    {
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void InstansiateCorrecttly(int size)
        {
            var squareMatrix = new SquareMatrix(size);

            Assert.AreEqual(size, squareMatrix.Size);
        }

        [Test]
        public void SetCorrectlyUsingIndexer()
        {
            var squareMatrix = new SquareMatrix(5);
            squareMatrix[3, 3] = 2;

            Assert.AreEqual(2, squareMatrix[3, 3]);
        }

        [Test]
        public void ThrowIndexOutOfRangeExceptionWhenPassedNegativeIndex()
        {
            var squareMatrix = new SquareMatrix(5);

            Assert.Throws<IndexOutOfRangeException>(() => squareMatrix[-3, 3] = 2);
        }

        [Test]
        public void FillCorectlyWhitRotatingWalkFill()
        {
            int[,] expected =
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            var squareMatrix = new SquareMatrix(6);
            squareMatrix.RotatingWalkFill();
            bool areEqual = true;

            for (int r = 0; r < squareMatrix.Size; r++)
            {
                for (int c = 0; c < squareMatrix.Size; c++)
                {
                    if (squareMatrix[r, c] != expected[r, c])
                    {
                        areEqual = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(areEqual);
        }
    }
}
