using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public abstract class MeatEater : Animal, ICarnivore
    {
        public MeatEater(string name, Point location, int size)
            : base(name, location, size)
        {
        }

        public virtual int TryEatAnimal(Animal animal)
        {
            if (animal == null)
            {
                return 0;
            }

            return 0;
        }
    }
}
