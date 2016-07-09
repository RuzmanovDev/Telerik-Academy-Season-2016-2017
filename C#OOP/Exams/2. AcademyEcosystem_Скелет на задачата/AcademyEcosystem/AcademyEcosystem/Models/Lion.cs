using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Lion : MeatEater
    {
        private const int LionSize = 6;

        public Lion(string name, Point location)
            : base(name, location, Lion.LionSize)
        {
        }

        public override int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                return 0;
            }
            int meatEaten = 0;
            if (this.Size * 2 >= animal.Size)
            {
                meatEaten = animal.GetMeatFromKillQuantity();
                this.Size++;
            }

            return meatEaten;
        }
    }
}
