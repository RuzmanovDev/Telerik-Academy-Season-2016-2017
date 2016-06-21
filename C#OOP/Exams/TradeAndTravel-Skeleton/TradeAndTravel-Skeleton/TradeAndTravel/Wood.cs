namespace TradeAndTravel
{
    public class Wood : Item
    {
        private const int InitialValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.InitialValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (this.Value > 0)
            {
                this.Value--;
            }

            base.UpdateWithInteraction(interaction);
        }
        // TODO: o	The Wood item decreases its value each time it is dropped by 1, until it reaches 0
    }
}
