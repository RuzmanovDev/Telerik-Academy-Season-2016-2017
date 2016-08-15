namespace ArmyOfCreatures.UnitTests.Extended
{
    using ArmyOfCreatures.Extended;
    using NUnit.Framework;
    using Moq;
    using ArmyOfCreatures.Logic;

    [TestFixture]
    public class BattleManagerWithThreeArmiesTests
    {
        //Constructor should call base() constructor and instantiate the object with all properties set up. 
        //(Use C# integrated PrivateObject class, to expose private fields, so that you can assert, that the object was instantiated properly).

        // Use Private Object only as last resort!!!!!!!!!!!!!!!!!1
        public void Ctor_WhenCalled_ShouldCallBaseCtorAndInstantitateTheObjectWithAllPropertiesSetUp()
        {
            var mockedCreaturesFactoy = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var bmWithThreeArmies = new BattleManagerWithThreeArmies(mockedCreaturesFactoy.Object, mockedLogger.Object);
            var privateObject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(bmWithThreeArmies);

            var creaturesFactoryField = privateObject.GetField("creaturesFactory");
            var loggerField = privateObject.GetField("logger");

            Assert.AreSame(mockedLogger, loggerField);
            Assert.AreSame(mockedCreaturesFactoy, creaturesFactoryField);
        }
    }
}
