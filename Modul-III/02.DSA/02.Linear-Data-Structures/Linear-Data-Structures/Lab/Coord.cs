namespace Lab
{
    public class Coord
    {
        public Coord(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Value { get; set; }
    }
}
