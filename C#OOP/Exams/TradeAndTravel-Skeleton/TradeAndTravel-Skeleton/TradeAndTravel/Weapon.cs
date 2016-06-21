namespace TradeAndTravel
{
    public class Weapon : Item
    {
        private const int InitialValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.InitialValue, ItemType.Weapon, location)
        {
        }
    }
}
