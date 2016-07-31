namespace ArmyOfCreatures.Tests
{
    using System;
    using NUnit.Framework;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;
    using System.Collections.Generic;
    using System.Reflection;
    [TestFixture]
    public class ExtemdedCreatureFactoryTests
    {
        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Goblin", typeof(Goblin))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]
        public void CreateCreature_ShouldReturnCorrespondingCreatureInstance_WhenCreated(string creatureName,Type expectedCreature)
        {
            var extendedCreatureFac = new ExtendedCreaturesFactory();

            var actualCreature = extendedCreatureFac.CreateCreature(creatureName);

            Assert.IsInstanceOf(expectedCreature, actualCreature);
        }

        //private IEnumerable<Type> GetAllCreatyreTypes()
        //{
        //    Assembly.LoadFrom("ArmyOfCreatures").GetTypes().Where(x=>x == typeof(c))
        //}
    }
}
