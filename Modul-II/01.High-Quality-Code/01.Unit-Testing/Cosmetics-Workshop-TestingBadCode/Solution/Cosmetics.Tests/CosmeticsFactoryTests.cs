using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Cosmetics.Engine;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenNameParameterIsNullOrEmpty_ShouldThrowNullRefferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "someBrand", 22M, GenderType.Men, 1, UsageType.EveryDay));

        }

        [Test]
        public void CreateShampoo_WhenNameParameterOutOfrange_ShouldThrowIndexOutOfRangeException()
        {
            var name = "radnomstringtahaistoolong";
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "someBrand", 22M, GenderType.Men, 1, UsageType.EveryDay));

        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenBrandParameterIsNullOrEmpty_ShouldThrowNullRefferenceException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("validName", brand, 22M, GenderType.Men, 1, UsageType.EveryDay));

        }

        [Test]
        public void CreateShampoo_WhenBrandParameterIsOutOfRannge_ShouldThrowIndexOutOfRandgeException()
        {
            var brand = "BrandNameThatIsTooLongToBeValid";
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("validName", brand, 22M, GenderType.Men, 1, UsageType.EveryDay));

        }

        [Test]
        public void CreateShanpoo_WhenValidParametersArePassed_ShouldReturnNewShampoo()
        {
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo("someName", "someBrand", 22M, GenderType.Men, 1, UsageType.EveryDay);

            Assert.IsInstanceOf<IShampoo>(shampoo);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateCategory_WhenNameParameterIsNullorEmpty_ShouldThrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));

        }

        [Test]
        public void CreateCategory_WhenNameParameterIsTooLong_ShouldThrowIndexOutOfRangeException()
        {
            string name = "InvalidNameTHatIsTooLong";
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));

        }

        [Test]
        public void CreateCategory_WhenValidNameIsPassed_ShouldReturnNewCategory()
        {
            var factory = new CosmeticsFactory();
            string validName = "validName";

            var category = factory.CreateCategory(validName);

            Assert.IsInstanceOf<ICategory>(category);

        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateToothpaste_WhenPassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name,"brand",2M,GenderType.Unisex,new List<string>()));
        }

        [Test]
        public void CreateToothpaste_WhenNameParameterIsOutOfRannge_ShouldThrowIndexOutOfRandgeException()
        {
            var name = "invalidNameThatIsLooonglong";
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name,"brand",2M,GenderType.Unisex,new List<string>()));

        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateToothpaste_WhenPassedBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("name", brand, 2M, GenderType.Unisex, new List<string>()));
        }

        [Test]
        public void CreateToothpaste_WhenBrandParameterIsOutOfRannge_ShouldThrowIndexOutOfRandgeException()
        {
            var brand = "invalidNameThatIsLooonglong";
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("name", brand, 2M, GenderType.Unisex, new List<string>()));
        }

        [Test]
        public void CreateShoppingCart_WhenCalled_ShouldAlwaysReturnNewShoppingCart()
        {
            var factory = new CosmeticsFactory();

            var shoppingCart = factory.CreateShoppingCart();

            Assert.IsInstanceOf<IShoppingCart>(shoppingCart);
        }
    }
}
