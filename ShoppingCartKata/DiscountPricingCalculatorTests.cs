using System.Linq;

using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class DiscountPricingCalculatorTests
    {
        [Test]
        public void HoldsDiscounts()
        {
            var discount = new Discount("apple", 2, 0.60m);
            var pricing = new Pricing(new []{ discount });
            Assert.That(pricing.Discounts().Single(), Is.EqualTo(discount));
        }

        [TestCase(0.50)]
        [TestCase(0.60)]
        public void AppliesDiscount(decimal price)
        {
            var discount = new Discount("apple", 2, price);
            var pricing = new Pricing(new[] { discount });
            Assert.That(pricing.Sum(new[] { "apple", "apple" }), Is.EqualTo(price));
        }
    }
}