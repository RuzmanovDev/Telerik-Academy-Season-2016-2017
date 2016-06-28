using ArmyOfCreatures.Logic.Specialties;
using System;
using ArmyOfCreatures.Logic.Battles;
using System.Globalization;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class AddAttackWhenSkip : Specialty
    {
        private readonly  int atackToAdd;

        public AddAttackWhenSkip(int atackToAdd)
        {
            if (atackToAdd < 1 || atackToAdd > 10)
            {
                throw new ArgumentOutOfRangeException("atackToAdd", "atackToAdd should be between 1 and 10, inclusive");
            }

            this.atackToAdd = atackToAdd;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.atackToAdd;
        }
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.atackToAdd);
        }
    }
}
