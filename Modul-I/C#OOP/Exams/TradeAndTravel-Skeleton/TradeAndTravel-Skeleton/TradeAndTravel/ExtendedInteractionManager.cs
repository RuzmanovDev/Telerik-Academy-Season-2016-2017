using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon": return item = new Weapon(itemNameString, itemLocation);
                case "wood": return item = new Wood(itemNameString, itemLocation);
                case "iron": return item = new Iron(itemNameString, itemLocation);

                default: return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {

            switch (locationTypeString)
            {
                case "mine": return new Mine(locationName);
                case "forest": return new Forest(locationName);

                default: return base.CreateLocation(locationTypeString, locationName);

            }
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGather(actor, commandWords[2]);
                    break;
                case "craft":
                   HandleCraft(actor, commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }

        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant": return new Merchant(personNameString, personLocation);
                default: return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }

        private void HandleCraft(Person actor, string name)
        {
            var itemName = name;
            bool hasIron = false;
            bool hasWood = false;

            var actorInventory = actor.ListInventory();

            foreach (var item in actorInventory)
            {
                if (item.ItemType == ItemType.Iron)
                {
                    hasIron = true;
                }

                if (item.ItemType == ItemType.Wood)
                {
                    hasWood = true;
                }
            }

            if (hasWood && hasIron)
            {
                // create weapon
                var weapon = new Weapon(itemName);
                this.AddToPerson(actor, weapon);
            }
            else if (hasIron)
            {
                var armor = new Armor(itemName);
                this.AddToPerson(actor, armor);

                // craft armor
            }

        }

        private void HandleGather(Person actor, string name)
        {
            var gatheringLocation = actor.Location as IGatheringLocation;
            if (gatheringLocation != null)
            {
                var requiredItemType = gatheringLocation.RequiredItem;
                var actorInventory = actor.ListInventory();

                bool actorHasItemType = InventoryHasItemType(requiredItemType, actorInventory);

                if (actorHasItemType)
                {
                    this.AddToPerson(actor, gatheringLocation.ProduceItem(name));
                }
            }
        }

        private static bool InventoryHasItemType(ItemType requiredItemType, List<Item> actorInventory)
        {
            bool actorHasItemType = false;
            foreach (var item in actorInventory)
            {
                if (item.ItemType == requiredItemType)
                {
                    actorHasItemType = true;
                    break;
                }
            }
            return actorHasItemType;
        }
    }
}
