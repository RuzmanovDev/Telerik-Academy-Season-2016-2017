namespace Exercise_8_10
{
    using System;
    using System.Text;

    public class Matrix<T>
    {
        private T[,] array;

        public Matrix(int rows, int cols)
        {
            this.array = new T[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.array.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.array.GetLength(1);
            }
        }

        public T this[int rows, int cols]
        {
            get
            {
                if (rows < 0 || cols < 0 || rows > this.Rows - 1 || cols > this.Cols - 1)
                {
                    throw new IndexOutOfRangeException("The index is outside of the bondries of the matrix!");
                }

                return this.array[rows, cols];
            }

            set
            {
                if (rows < 0 || cols < 0 || rows > this.Rows - 1 || cols > this.Cols - 1)
                {
                    throw new IndexOutOfRangeException("The index is outside of the bondries of the matrix!");
                }

                this.array[rows, cols] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            return Add(matrixA, matrixB);
        }

        public static Matrix<T> operator -(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            return Substract(matrixA, matrixB);
        }

        public static Matrix<T> operator *(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            return Multiply(matrixA, matrixB);
        }

        public static bool operator true(Matrix<T> matrix)
        {
            bool isTrue = true;
            for (int r = 0; r < matrix.array.GetLength(0) && isTrue; r++)
            {
                for (int c = 0; c < matrix.array.GetLength(1) && isTrue; c++)
                {
                    if ((dynamic)matrix[r, c] == 0)
                    {
                        isTrue = false;
                    }
                }
            }

            return isTrue;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            bool isTrue = true;
            for (int r = 0; r < matrix.array.GetLength(0) && isTrue; r++)
            {
                for (int c = 0; c < matrix.array.GetLength(1) && isTrue; c++)
                {
                    if ((dynamic)matrix[r, c] == 0)
                    {
                        isTrue = false;
                    }
                }
            }

            return !isTrue;
        }

        public static bool operator !(Matrix<T> matrix)
        {
            if (matrix)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < this.array.GetLength(0); r++)
            {
                for (int c = 0; c < this.array.GetLength(1); c++)
                {
                    sb.Append(this.array[r, c] + " ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static Matrix<T> Add(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.array.GetLength(0) != matrixB.array.GetLength(0) ||
            matrixA.array.GetLength(1) != matrixB.array.GetLength(1))
            {
                throw new ArgumentException("Matrices should have equal dimentions");
            }

            Matrix<T> result = new Matrix<T>(matrixA.Rows, matrixB.Cols);
            for (int r = 0; r < result.Cols; r++)
            {
                for (int c = 0; c < result.Cols; c++)
                {
                    result[r, c] = (dynamic)matrixA[r, c] + (dynamic)matrixB[r, c];
                }
            }

            return result;
        }

        private static Matrix<T> Substract(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.array.GetLength(0) != matrixB.array.GetLength(0) ||
            matrixA.array.GetLength(1) != matrixB.array.GetLength(1))
            {
                throw new ArgumentException("Matrices should have equal dimentions");
            }

            Matrix<T> result = new Matrix<T>(matrixA.Rows, matrixB.Cols);
            for (int r = 0; r < result.Cols; r++)
            {
                for (int c = 0; c < result.Cols; c++)
                {
                    result[r, c] = (dynamic)matrixA[r, c] - (dynamic)matrixB[r, c];
                }
            }

            return result;
        }

        private static Matrix<T> Multiply(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.array.GetLength(1) != matrixB.array.GetLength(0))
            {
                throw new ArgumentException("The rows from the first matrix must be equal to the cols of the other one");
            }

            Matrix<T> matrixC = new Matrix<T>(matrixA.Rows, matrixB.Cols);

            for (int r = 0; r < matrixC.Rows; r++)
            {
                for (int c = 0; c < matrixC.Cols; c++)
                {
                    for (int k = 0; k < matrixA.Cols; k++)
                    {
                        matrixC[r, c] += (dynamic)matrixA[r, k] * (dynamic)matrixB[k, c];
                    }
                }
            }

            return matrixC;
        }
    }
}
