using Moq;
using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase("apple", 0.60)]
        [TestCase("orange", 0.25)]
        [TestCase("apple,apple", 1.20)]
        [TestCase("orange,orange", 0.50)]
        public void CalculatesTotalCost(string items, double expectedTotalCost)
        {
            var mockPricingList = new Mock<IPrice>();
            mockPricingList.Setup(x => x.Item("apple")).Returns(0.60m);
            mockPricingList.Setup(x => x.Item("orange")).Returns(0.25m);

            var scannedItems = items.Split(new[] {','});
            var totalCost = new Calculator(mockPricingList.Object).Sum(scannedItems);

            Assert.That(totalCost, Is.EqualTo(expectedTotalCost));
        }
    }
}