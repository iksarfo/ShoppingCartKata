using System.Collections.Generic;
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
            var pricing = new Pricing(new List<Discount> { discount });
            Assert.That(pricing.Discounts().Single(), Is.EqualTo(discount));
        }
    }
}