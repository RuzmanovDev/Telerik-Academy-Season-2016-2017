namespace Minesweeper
{
    public class PlayerPoints
    {
        private string name;
        private int totalPoints;

        public PlayerPoints()
        {
        }

        public PlayerPoints(string name, int points)
        {
            this.name = name;
            this.totalPoints = points;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int TotalPoints
        {
            get { return this.totalPoints; }
            set { this.totalPoints = value; }
        }
    }
}
