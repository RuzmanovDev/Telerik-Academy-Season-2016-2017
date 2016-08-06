using Cosmetics.Common;
using Cosmetics.Engine;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class PrinMethodsTests
    {
        [Test]
        public void ShampooPrint_WhenGivenValidData_ShouldReturnStringInRequiredFormat()
        {
            // Arrange
            var shampoo = new Shampoo("example", "Pesho", 10M, GenderType.Unisex, 100, UsageType.EveryDay);

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Pesho - example:");
            expectedResult.AppendLine("  * Price: $1000");
            expectedResult.AppendLine("  * For gender: Unisex");
            expectedResult.AppendLine("  * Quantity: 100 ml");
            expectedResult.Append("  * Usage: EveryDay");

            // Act
            var executionResult = shampoo.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), executionResult);
        }

        [Test]
        public void Toothpaste_WhenGivenValidData_ShouldReturnStringInRequiredFormat()
        {

        }

        [Test]
        public void Category_WhenGivenValidData_ShouldReturnStringInRequiredFormat()
        {

        }

        [Test]
        public void ShoppingCart_WhenGivenValidData_ShouldReturnStringInRequiredFormat()
        {

        }

    }
}
