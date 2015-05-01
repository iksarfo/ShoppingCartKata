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
            var pricing = new Pricing(new PricingList(""), new []{ discount });
            Assert.That(pricing.Discounts().Single(), Is.EqualTo(discount));
        }

        [TestCase(0.50)]
        [TestCase(0.60)]
        public void AppliesDiscount(decimal price)
        {
            var discount = new Discount("apple", 2, price);
            var pricing = new Pricing(new PricingList(""), new[] { discount });
            Assert.That(pricing.Sum(new[] { "apple", "apple" }), Is.EqualTo(price));
        }

        [Test]
        public void AppliesNoDiscountToItemsNotQualifyingByCount()
        {
            var discount = new Discount("apple", 2, 0.60m);
            var pricingList = new PricingList("apple,0.60");
            var pricing = new Pricing(pricingList, new[] { discount });
            Assert.That(pricing.Sum(new[] { "apple", "apple", "apple" }), Is.EqualTo(1.20m));
        }

        [Test]
        public void AppliesNoDiscountToItemsNotQualifyingByName()
        {
            var discount = new Discount("orange", 3, 1.00m);
            var pricingList = new PricingList("apple,0.60;orange,0.25");
            var pricing = new Pricing(pricingList, new[] { discount });
            Assert.That(pricing.Sum(new[] { "apple", "apple", "apple" }), Is.EqualTo(1.80m));
        }

        [Test]
        public void AppliesMultipleDiscounts()
        {
            var threeForTwoOnOranges = new Discount("orange", 3, 1.00m);
            var twoForOneOnApples = new Discount("apple", 2, 0.60m);
            var pricingList = new PricingList("apple,0.60;orange,0.25");
            var pricing = new Pricing(pricingList, new[] { threeForTwoOnOranges, twoForOneOnApples });
            Assert.That(pricing.Sum(new[] { "apple", "orange", "apple", "orange", "orange", "orange", "apple" }), Is.EqualTo(2.45m));
        }
    }
}