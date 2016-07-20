namespace TradeAndTravel
{
    public class Mine : GatheringLocation
    {
        public Mine(string name)
            : base(name, ItemType.Iron, ItemType.Armor, LocationType.Mine)
        {
        }
    }
}
