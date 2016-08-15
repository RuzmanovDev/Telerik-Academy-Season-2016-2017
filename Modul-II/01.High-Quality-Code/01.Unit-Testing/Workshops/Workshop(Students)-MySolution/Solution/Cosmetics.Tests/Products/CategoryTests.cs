namespace Cosmetics.Tests.Products
{
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cosmetics.Tests.Products.Mocks;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AddCosmetics_WhenProductParamIsValid_ShouldAddProductToList()
        {
            var mockedProduct = new Mock<IProduct>();
            var mockedCategory = new MockedCategory("ForMale");

            mockedCategory.AddProduct(mockedProduct.Object);

            Assert.IsTrue(mockedCategory.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void RemoveCosmetics_WhenProductParamIsValid_ShouldRemoveProductFromList()
        {
            var mockedProduct = new Mock<IProduct>();
            var mockedCategory = new MockedCategory("ForMale");

            mockedCategory.AddProduct(mockedProduct.Object);
            mockedCategory.RemoveProduct(mockedProduct.Object);

            Assert.IsFalse(mockedCategory.Products.Contains(mockedProduct.Object));

        }

        [Test]
        public void Print_WhenInvoked_ShouldReturnCategoryDetailsInValidStringFormat()
        {
            //    var categoryString = string.Format("{0} category - {1} {2} in total", this.Name, this.products.Count, this.products.Count != 1 ? "products" : "product");

            var mockedProduct = new Mock<IProduct>();
            var mockedCategory = new MockedCategory("ForMale");

            mockedCategory.AddProduct(mockedProduct.Object);

            var expected = "ForMale category - 1 product in total";

            Assert.AreEqual(expected, mockedCategory.Print());

        }
    }
}