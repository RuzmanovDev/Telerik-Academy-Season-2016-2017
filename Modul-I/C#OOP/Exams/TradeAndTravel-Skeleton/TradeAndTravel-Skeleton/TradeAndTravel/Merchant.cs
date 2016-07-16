namespace TradeAndTravel
{
    using System;

    class Merchant : Shopkeeper, IShopkeeper, ITraveller
    {
        public Merchant(string name, Location location) 
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }

    }
}
