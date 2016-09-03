namespace Minesweeper
{
    public class PlayerPoints
    {
        private string name;
        private int totalPoints;

        public PlayerPoints(string name, int points)
        {
            this.name = name;
            this.totalPoints = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public int TotalPoints
        {
            get
            {
                return this.totalPoints;
            }

            private set
            {
                this.totalPoints = value;
            }
        }
    }
}
