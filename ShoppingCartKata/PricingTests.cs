using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class PricingTests
    {
        [TestCase("apple", 0.60)]
        [TestCase("orange", 0.25)]
        public void PricesItems(string itemName, double price)
        {
            var pricingList = new PricingList("apple,0.60;orange,0.25");
            var itemPrice = pricingList.Item(itemName);
            Assert.That(itemPrice, Is.EqualTo(price));
        }
    }
}