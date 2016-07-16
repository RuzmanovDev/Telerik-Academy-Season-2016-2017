using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem.Models
{
    public class Zombie : Animal
    {
        private const int MeatFormEatenZombie = 10;

        public Zombie(string name, Point location)
            : base(name, location, 0)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            IsAlive = true; // always
            return Zombie.MeatFormEatenZombie; ;
        }

    }
}
