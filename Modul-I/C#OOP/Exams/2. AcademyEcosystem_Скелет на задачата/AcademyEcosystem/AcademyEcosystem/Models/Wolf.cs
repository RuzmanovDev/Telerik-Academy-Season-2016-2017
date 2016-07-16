using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Wolf : MeatEater
    {
        private const int WolfSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, Wolf.WolfSize)
        {
        }

        public override int TryEatAnimal(Animal animal)
        {
            if (animal== null)
            {
                return 0;
            }
            int meatEaten = 0;
            if (this.Size >= animal.Size || AnimalState.Sleeping == animal.State)
            {
                 meatEaten = animal.GetMeatFromKillQuantity();
                // TODO what hapans to the meat??
            }

            return meatEaten;
        }
    }
}
