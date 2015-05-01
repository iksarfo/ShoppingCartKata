using Moq;
using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void PrintsCost()
        {
            var items = new[] {"apple", "orange"};
            var mockCalculator = new Mock<IPrice>();
            var checkout = new Checkout(mockCalculator.Object);
            var totalCost = checkout.Cost(items);
            Assert.That(totalCost, Is.EqualTo(0.85m));
        }
    }
}