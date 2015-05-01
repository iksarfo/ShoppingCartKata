using Moq;
using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void CalculatesTotalCost()
        {
            var expectedTotalCost = 0.60m;
            var mockPricingList = new Mock<IPrice>();
            var items = "apple,apple";
            var scannedItems = items.Split(new[] {','});
            var totalCost = new Calculator(mockPricingList.Object).Sum(scannedItems);

            Assert.That(totalCost, Is.EqualTo(expectedTotalCost));
        }
    }
}