using System;

namespace Task2
{
    public class Refactor
    {
        private const int MinX = 0;
        private const int MaxX = 10;
        private const int MinY = 0;
        private const int MaxY = 10;

        private bool cellIsVisited;

        public void FirstRefacor(Potato potato)
        {
            if (potato == null)
            {
                throw new ArgumentNullException("The potato cannot be null!");
            }

            if (!potato.HasBeenPeeled)
            {
                throw new ArgumentException("The potato must be pilled in order to be cooked!");
            }

            if (potato.IsRotten)
            {
                throw new ArgumentException("The potato must be fresh in order to be cooked!");
            }

            this.Cook(potato);
        }

        public void SecondRefactor(int x, int y)
        {
            if (x >= MinX && (x <= MaxX && ((MaxY >= y && MinY <= y) && !this.cellIsVisited)))
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            // some freeky logic 
        }

        private void Cook(Potato potato)
        {
            // Cook delicous potato mmmm
        }
    }
}
