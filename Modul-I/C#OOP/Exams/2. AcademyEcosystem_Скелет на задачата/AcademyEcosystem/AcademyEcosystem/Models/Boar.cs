using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Boar : MeatEater, IHerbivore
    {
        private const int BoarSize = 4;
        private readonly int biteSize = 2;

        public Boar(string name, Point location)
            : base(name, location, Boar.BoarSize)
        {
        }

        public int EatPlant(Plant plant)
        {
            if (plant == null)
            {
                return 0;
            }
            int eaten = 0;
            eaten = plant.GetEatenQuantity(this.biteSize);
            this.Size++;
            return eaten;
        }

        public override int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                return 0;
            }

            int meatEaten = 0;
            if (this.Size >= animal.Size)
            {
                meatEaten = animal.GetMeatFromKillQuantity();
            }

            return meatEaten;
        }
    }
}
