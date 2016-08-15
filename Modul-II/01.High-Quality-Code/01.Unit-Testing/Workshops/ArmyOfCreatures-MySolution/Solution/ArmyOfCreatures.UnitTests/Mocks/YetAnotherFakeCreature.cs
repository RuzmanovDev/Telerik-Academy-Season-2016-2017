using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.UnitTests.Mocks
{
    public class YetAnotherFakeCreature : Creature
    {
        public YetAnotherFakeCreature()
            : base(10, 10, 10, 10)
        {
        }
    }
}
