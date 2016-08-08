namespace Cosmetics.Tests.Products
{
    using Cosmetics.Contracts;
    using Cosmetics.Tests.Products.Mocks;
    using Cosmetics.Products;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_WhenProductParamIsValid_ShouldAddProductToList()
        {
            var shoppingCart = new MockedShoppingCart();
            var product = new Mock<IProduct>();

            shoppingCart.AddProduct(product.Object);

            Assert.IsTrue(shoppingCart.Products.Contains(product.Object));
        }

        [Test]
        public void RemoveProduct_WhenProductParamIsValid_ShouldRemoveProductFromList()
        {
            var shoppingCart = new MockedShoppingCart();
            var product = new Mock<IProduct>();

            shoppingCart.AddProduct(product.Object);
            shoppingCart.RemoveProduct(product.Object);

            Assert.IsFalse(shoppingCart.Products.Contains(product.Object));
        }

        [Test]
        public void ContainsProduct_WhenProductParamIsValid_ShouldReturnTrueIfProductIsInList()
        {
            var shoppingCart = new MockedShoppingCart();
            var product = new Mock<IProduct>();

            shoppingCart.AddProduct(product.Object);

            Assert.IsTrue(shoppingCart.Products.Contains(product.Object));
        }

        [Test]
        public void ContainsProduct_WhenProductParamIsValid_ShouldReturnFalseIfProductIsNotInList()
        {
            var shoppingCart = new MockedShoppingCart();
            var product = new Mock<IProduct>();


            Assert.IsFalse(shoppingCart.Products.Contains(product.Object));
        }

        [Test]
        public void TotalPrice_WhenThereAreNoProductsInList_ShouldReturnZero()
        {
            var shoppingCart = new MockedShoppingCart();

            Assert.AreEqual(0M, shoppingCart.TotalPrice());
        }

        [Test]
        public void TotalPrice_WhenThereAreProductsInList_ShouldReturnTheTotalSumOfTheirPrices()
        {
            var shoppingCart = new MockedShoppingCart();
            var product1 = new Mock<IProduct>();
            var product2 = new Mock<IProduct>();

            product1.Setup(x => x.Price).Returns(10M);
            product2.Setup(x => x.Price).Returns(10M);

            shoppingCart.AddProduct(product1.Object);
            shoppingCart.AddProduct(product2.Object);

            Assert.AreEqual(20M, shoppingCart.TotalPrice());
        }
    }
}
