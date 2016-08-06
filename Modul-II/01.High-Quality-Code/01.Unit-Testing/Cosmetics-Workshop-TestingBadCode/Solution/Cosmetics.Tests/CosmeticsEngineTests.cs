using Cosmetics.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Cosmetics.Contracts;
using System.IO;
using Cosmetics.Tests.Mock;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenTheInputStringIsincorrect_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object);
            var invalidCommand = " in va lid comm an";
            Console.SetIn(new StringReader(invalidCommand));

            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        public void Start_WhenPassedValidInput_ShouldReadParseAndExecuteWhichResultsAddingNewCategory()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedEngine = new MockedEngine(mockedFactory.Object, mockedShoppingCart.Object);

            var validCommand = "CreateCategory ForMale" + Environment.NewLine;
            Console.SetIn(new StringReader(validCommand));
            mockedEngine.Start();

            Assert.AreEqual(1, mockedEngine.Categories.Count);
        }

        [Test]
        public void Start_WhenRemovingFromCategory_ShouldRemoveTheCategoryFromTheCollection()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedEngine = new MockedEngine(mockedFactory.Object, mockedShoppingCart.Object);

            var validCommand = "CreateCategory ForMale" + Environment.NewLine;
            Console.SetIn(new StringReader(validCommand));
            var addTocategoryCommand = "AddToCategory ForMale Cool";
            Console.SetIn(new StringReader(addTocategoryCommand));
            var removeCommand = "RemoveFromCategory ForMale Cool" + Environment.NewLine;
            Console.SetIn(new StringReader(removeCommand));
            mockedEngine.Start();

            Assert.AreEqual(0, mockedEngine.Categories.Count);
        }

        [Test]
        public void Start_WhenCallsShowCategory_ShouldCallPrintMethod()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedEngine = new MockedEngine(mockedFactory.Object, mockedShoppingCart.Object);

            var validCommand = "CreateCategory ForMale" + Environment.NewLine;
            Console.SetIn(new StringReader(validCommand));
            var showCategoryComand = "ShowCategory ForMale";
            Console.SetIn(new StringReader(showCategoryComand));
            mockedEngine.Start();




        }
    }
}
