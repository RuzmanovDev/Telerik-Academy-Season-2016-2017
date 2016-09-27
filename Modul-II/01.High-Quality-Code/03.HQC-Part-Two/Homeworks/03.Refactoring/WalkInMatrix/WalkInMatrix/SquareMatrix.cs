using System;
using System.Text;

namespace WalkInMatrix
{
    public class SquareMatrix
    {
        private const int MinSize = 0;
        private const int MaxSize = 100;
        private int size;
        private int[,] matrix;

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < MinSize || value > MaxSize)
                {
                    throw new ArgumentOutOfRangeException("The marix size must be between 0 and 100");
                }

                this.size = value;
            }
        }

        public int this[int row, int col]
        {
            get
            {
                this.ValidateIndeces(row, col);

                return this.matrix[row, col];
            }

            set
            {
                this.ValidateIndeces(row, col);

                this.matrix[row, col] = value;
            }
        }

        public void RotatingWalkFill()
        {
            Coordinates position = this.matrix.GetStartingPosition();
            Direction direction = Direction.DownRight;
            int rowChange = MatrixWalkUtils.GetRowChange(direction);
            int colChange = MatrixWalkUtils.GetColChange(direction);
            int cellValue = 1;

            while (cellValue <= this.Size * this.Size)
            {
                this.matrix[position.Row, position.Col] = cellValue;

                if (!this.matrix.CanContinueInDirection(position.Row + rowChange, position.Col + colChange))
                {
                    bool neighboursAreFilled = false;

                    if (this.matrix.NeighboursAreFilled(position.Row, position.Col))
                    {
                        neighboursAreFilled = true;

                        position = this.matrix.GetStartingPosition();
                        if (position == null)
                        {
                            break;
                        }

                        direction = Direction.DownRight;
                    }
                    else
                    {
                        direction = this.matrix.GetNextDirection(direction, position.Row, position.Col);
                    }

                    rowChange = MatrixWalkUtils.GetRowChange(direction);
                    colChange = MatrixWalkUtils.GetColChange(direction);

                    if (neighboursAreFilled)
                    {
                        cellValue += 1;
                        continue;
                    }
                }

                position.Row += rowChange;
                position.Col += colChange;
                cellValue += 1;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    builder.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        private void ValidateIndeces(int row, int col)
        {
            if (row < 0 || col < 0 || row >= this.size || col >= this.Size)
            {
                throw new IndexOutOfRangeException("The index it's outisde of the boundries!");
            }
        }
    }
}
