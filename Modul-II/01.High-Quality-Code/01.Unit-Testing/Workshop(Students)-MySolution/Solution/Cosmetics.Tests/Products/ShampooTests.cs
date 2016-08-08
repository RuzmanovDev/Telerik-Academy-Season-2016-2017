namespace Cosmetics.Tests.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Products;

    using NUnit.Framework;

    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_WhenInvoked_ShouldReturnShampooDetailsInValidStringFormat()
        {
            var shampoo = new Shampoo("gotin", "shampoo", 10M, GenderType.Unisex, 200, UsageType.EveryDay);

            var builder = new StringBuilder();
            builder.AppendLine("- shampoo - gotin:");
            builder.AppendLine("  * Price: $2000");
            builder.AppendLine("  * For gender: Unisex");
            builder.AppendLine("  * Quantity: 200 ml");
            builder.Append("  * Usage: EveryDay");

            var result = shampoo.Print();

            Assert.AreEqual(builder.ToString(), result);
        }
    }
}