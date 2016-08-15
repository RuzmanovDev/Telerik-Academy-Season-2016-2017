using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.UnitTests.Mocks
{
    public class FakeCreature : Creature
    {
        public FakeCreature()
            : base(10, 10, 10, 10)
        {
        }

        public void AddNewSpecialty(Specialty specialty)
        {
            this.AddSpecialty(specialty);
        }
    }
}
