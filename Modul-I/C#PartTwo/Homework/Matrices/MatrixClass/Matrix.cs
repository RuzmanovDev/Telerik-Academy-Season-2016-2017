namespace MatrixClass
{
    using System.Text;

    class Matrix
    {
        public int[,] MatrixObject { get; set; }

        public Matrix(int rows, int cols)
        {
            this.MatrixObject = new int[rows, cols];
        }

        public int Rows
        {
            get
            {
                return MatrixObject.GetLength(0);
            }
        }
        public int Cols
        {
            get
            {
                return MatrixObject.GetLength(1);
            }
        }
        public int this[int rows, int cols]
        {
            get
            {
                return this.MatrixObject[rows, cols];
            }
            set
            {
                this.MatrixObject[rows, cols] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < MatrixObject.GetLength(0); r++)
            {
                for (int c = 0; c < MatrixObject.GetLength(1); c++)
                {
                    sb.Append(MatrixObject[r, c] + " ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {

            return Add(matrixA, matrixB);
        }
        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            return Substract(matrixA, matrixB);
        }
        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            return Multiply(matrixA, matrixB);
        }
        public static Matrix Add(Matrix matrixA, Matrix matrixB)
        {
            Matrix result = new Matrix(matrixA.Rows, matrixB.Cols);
            for (int r = 0; r < result.Cols; r++)
            {
                for (int c = 0; c < result.Cols; c++)
                {
                    result[r, c] = matrixA[r, c] + matrixB[r, c];
                }
            }
            return result;
        }
        public static Matrix Substract(Matrix matrixA, Matrix matrixB)
        {
            Matrix result = new Matrix(matrixA.Rows, matrixB.Cols);
            for (int r = 0; r < result.Cols; r++)
            {
                for (int c = 0; c < result.Cols; c++)
                {
                    result[r, c] = matrixA[r, c] - matrixB[r, c];
                }
            }
            return result;
        }

        public static Matrix Multiply(Matrix matrixA, Matrix matrixB)
        {
            Matrix matrixC = new Matrix(matrixA.Rows, matrixB.Cols);

            for (int r = 0; r < matrixC.Rows; r++)
            {
                for (int c = 0; c < matrixC.Cols; c++)
                {
                   
                    for (int k = 0; k < matrixA.Cols; k++)
                    {
                        matrixC[r, c] +=  matrixA[r, k] * matrixB[k, c];
                    }
                }
            }

            return matrixC;
        }
    }
}
