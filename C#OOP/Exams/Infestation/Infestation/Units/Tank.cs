using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Tank : Unit
    {
        private const int TankInitialHealth = 20;
        private const int TankInitialPower = 25;
        private const int TankInitialAggression = 25;


        public Tank(string id) : base(id, UnitClassification.Mechanical, TankInitialHealth, TankInitialPower, TankInitialAggression)
        {
        }
    }
}
