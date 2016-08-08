namespace Cosmetics.Tests.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cosmetics.Tests.Engine.Mocks;

    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputStringIsValidCreateCategoryCommand_CategoryShouldBeAddedToList()
        {
            // Arrange
            var categoryName = "ForMen";
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedCommands = new Mock<ICommand>();
            mockedCommands.Setup(x => x.Name).Returns("CreateCategory");
            mockedCommands.Setup(x => x.Parameters).Returns(new List<string> { categoryName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommands.Object });

            var mockedCategory = new Mock<ICategory>();
            mockedCategory.Setup(x => x.Name).Returns(categoryName);
            mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);

            // Act
            engine.Start();

            // Assert 
            Assert.IsTrue(engine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidAddToCategoryCommand_ProductShouldBeAddedToCategory()
        {
            // Arrange
            var categoryName = "ForMen";
            var productName = "pesho";
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            var mockedCommands = new Mock<ICommand>();
            mockedCommands.Setup(x => x.Name).Returns("AddToCategory");
            mockedCommands.Setup(x => x.Parameters).Returns(new List<string> { categoryName, productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommands.Object });

            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            // Act
            engine.Start();

            // Assert
            mockedCategory.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);

        }

        [Test]
        public void Start_WhenInputStringIsValidRemoveFromCategoryCommand_ProductShouldBeRemovedFromCategory()
        {
            // Arange
            var categoryName = "ForMale";
            var productName = "BalsamaNaPesho";

            var mockeFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedEngine = new MockedCosmeticsEngine(mockeFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            var mockedCategory = new Mock<ICategory>();
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("RemoveFromCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });
            var mockedProduct = new Mock<IProduct>();

            mockedEngine.Categories.Add(categoryName, mockedCategory.Object);
            mockedEngine.Products.Add(productName, mockedProduct.Object);


            // Act
            mockedEngine.Start();

            // Assert
            mockedCategory.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidShowCategoryCommand_RespectiveCategoryPrintMethodShouldBeInvoked()
        {
            var categoryName = "ForMale";

            var mockeFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedEngine = new MockedCosmeticsEngine(mockeFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            var mockedCategory = new Mock<ICategory>();
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("ShowCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            mockedEngine.Categories.Add(categoryName, mockedCategory.Object);

            // Act
            mockedEngine.Start();

            // Assert
            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_WhenInputStringIsValidCreateShampooCommand_ShampooShouldBeAddedToProducts()
        {
            var shampooName = "PehoFresh";
            var shampooBrand = "PeshoBrand";

            var mockeFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedShampoo = new Mock<IShampoo>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.Setup(x => x.Name).Returns("CreateShampoo");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { shampooName, shampooBrand, "0,50", "men", "500", "everyday" });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            mockeFactory
              .Setup(x => x.CreateShampoo(shampooName, shampooBrand, 0.50M, GenderType.Men, 500, UsageType.EveryDay))
              .Returns(mockedShampoo.Object);

            var mockedEgnine = new MockedCosmeticsEngine(mockeFactory.Object, mockedShoppingCart.Object,
                mockedCommandParser.Object);

            mockedEgnine.Start();

            Assert.IsTrue(mockedEgnine.Products.ContainsKey(shampooName));
            Assert.AreSame(mockedShampoo.Object, mockedEgnine.Products[shampooName]);

        }


        [Test]
        public void Start_WhenInputStringIsValidCreateCreateToothpasteCommand_ToothpasteShouldBeAddedToProducts()
        {
            var toothpasteName = "PehoFresh";
            var toothPasteBrand = "PeshoBrand";

            var mockeFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedToothpaste = new Mock<IToothpaste>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.Setup(x => x.Name).Returns("CreateToothpaste");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { toothpasteName, toothPasteBrand, "10", "unisex", "luk", });

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            mockeFactory
              .Setup(x => x.CreateToothpaste(toothpasteName, toothPasteBrand, 10M, GenderType.Unisex, new List<string>() { "luk" }))
              .Returns(mockedToothpaste.Object);

            var mockedEgnine = new MockedCosmeticsEngine(mockeFactory.Object, mockedShoppingCart.Object,
                mockedCommandParser.Object);

            mockedEgnine.Start();

            Assert.IsTrue(mockedEgnine.Products.ContainsKey(toothpasteName));
            Assert.AreSame(mockedToothpaste.Object, mockedEgnine.Products[toothpasteName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidAddToShoppingCartCommand_ProductShouldBeAddedToShoppingCart()
        {
            // Arrange
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedProduct = new Mock<IProduct>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.Setup(x => x.Name).Returns("AddToShoppingCart");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object,
                mockedCommandParser.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            engine.Start();

            mockedShoppingCart.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);

        }

        [Test]
        public void Start_WhenInputStringIsValidRemoveFromShoppingCartCommand_ProductShouldBeRemovedFromShoppingCart()
        {
            // Arrange
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedProduct = new Mock<IProduct>();
            var mockedCommand = new Mock<ICommand>();

            mockedCommand.Setup(x => x.Name).Returns("RemoveFromShoppingCart");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { productName });
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            mockedShoppingCart.Setup(x => x.ContainsProduct(mockedProduct.Object)).Returns(true);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object,
                mockedCommandParser.Object);
            engine.Products.Add(productName, mockedProduct.Object);

            engine.Start();

            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }
    }
}
