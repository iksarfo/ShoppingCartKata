using System.Linq;
using Moq;
using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase(0.01)]
        [TestCase(0.85)]
        public void ShowsCost(decimal expectedTotalCost)
        {
            var items = new[] {"apple", "orange"};
            var mockCalculator = new Mock<ICalculate>();
            mockCalculator.Setup(x => x.Sum(items)).Returns(expectedTotalCost);
            var checkout = new Checkout(mockCalculator.Object);
            var checkoutResult = checkout.Complete(items);
            Assert.That(checkoutResult.TotalCost, Is.EqualTo(expectedTotalCost));
        }

        [TestCase("apple,orange")]
        public void ShowsItems(string items)
        {
            var scannedItems = items.Split(new [] { ',' });
            var mockCalculator = new Mock<ICalculate>();

            var checkout = new Checkout(mockCalculator.Object);
            var checkoutResult = checkout.Complete(scannedItems);
            Assert.That(checkoutResult.Items.Contains("apple")); 
            Assert.That(checkoutResult.Items.Contains("orange"));
            Assert.That(checkoutResult.Items.Length, Is.EqualTo(2));
        }
    }
}