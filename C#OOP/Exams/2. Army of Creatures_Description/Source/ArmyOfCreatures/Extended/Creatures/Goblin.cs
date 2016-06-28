namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;

    class Goblin : Creature
    {
        private const int InitialAtack = 4;
        private const int Defence = 2;
        private const int HP = 5;
        private const decimal InitialDMG = 1.5M;

        public Goblin()
            : base(Goblin.InitialAtack,Goblin.Defence,Goblin.HP,Goblin.InitialDMG)
        {
        }
    }
}
